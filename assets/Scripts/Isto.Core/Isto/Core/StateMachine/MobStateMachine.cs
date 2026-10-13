using System.Collections.Generic;
using I2.Loc;
using Isto.Core.AI;
using Isto.Core.Beings;
using Isto.Core.Data;
using Isto.Core.Inputs;
using Isto.Core.Items;
using Isto.Core.Localization;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.StateMachine;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AnimationController))]
[SelectionBase]
public class MobStateMachine : InteractableItem, IItemTopmostParent, IInteractable, IActivatable, IActionOnSpawn, IDataLoadCompleteHandler, IActionOnPickup
{
	public SpriteRenderer actionIcon;

	public string mobName;

	public LocalizedString mobNameKey;

	[Header("Mob States")]
	public MobNeutralState neutralState;

	public MobAgroState agroState;

	public MobPlayerOverrideState overrideState;

	[Header("")]
	public MobState startState;

	[Header("Player Interaction")]
	[Tooltip("Sets if the player can pickup the mob or not without stunning it.  Used for harvesters for example")]
	public bool canBeDismantled;

	public bool canBePickedUp;

	public bool canBePet;

	[Header("Visuals")]
	public Image progressSlider;

	public Image overrideSlider;

	[Header("Group Interaction")]
	public bool registerInMainGroup;

	[HideInInspector]
	public NavMeshAgent agent;

	protected MobState _currentState;

	protected MobState _previousState;

	private Vector3 _forwardDirection;

	private AnimationController _animationControl;

	private AnimationController.CharacterDirections _currentDirection = AnimationController.CharacterDirections.down_right;

	private ItemContainer _inventory;

	private List<UserActions> _validActionList = new List<UserActions>();

	private Vector3 _startingPosition;

	private bool _loadComplete;

	public MobState CurrentState => _currentState;

	public float Speed => agent.speed;

	public float Acceleration => agent.acceleration;

	public float RemainingDistance => agent.remainingDistance - agent.stoppingDistance;

	public ItemContainer Inventory => _inventory;

	public Vector3 Forward => _forwardDirection;

	public bool IsMovingByAutomation => false;

	public MobGroupController GroupController { get; private set; }

	[Inject]
	private void Inject(MobGroupController mobGroupController)
	{
		GroupController = mobGroupController;
	}

	protected override void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		_animationControl = GetComponent<AnimationController>();
		_inventory = GetComponent<ItemContainer>();
		base.Awake();
	}

	private void OnDisable()
	{
		actionIcon.enabled = false;
		_currentDirection = AnimationController.CharacterDirections.down_left;
		if (registerInMainGroup)
		{
			GroupController.RemoveFromGroup(base.gameObject);
		}
	}

	private void Start()
	{
		if (registerInMainGroup)
		{
			GroupController.AddToGroup(base.gameObject);
		}
		ChangeState(startState);
		_startingPosition = base.transform.position;
	}

	protected override void Update()
	{
		if (_loadComplete)
		{
			base.Update();
			MobState mobState = _currentState.Run(this);
			if (mobState != _currentState)
			{
				ChangeState(mobState);
			}
		}
	}

	public void OnDataLoadComplete()
	{
		_loadComplete = true;
	}

	public void MoveToPosition(Vector3 position, float speed)
	{
		MoveToPosition(position, speed, AnimationController.AnimationType.run);
	}

	public void MoveToPosition(Vector3 position, float speed, AnimationController.AnimationType animType)
	{
		Vector3 vector = FindPointOnNavMesh(position);
		_forwardDirection = vector - base.transform.position;
		float angleFromForward = _animationControl.GetAngleFromForward(_forwardDirection);
		float characterHorizontalDirection = _animationControl.GetCharacterHorizontalDirection(_forwardDirection);
		AnimationController.CharacterDirections characterDirection = _animationControl.GetCharacterDirection(angleFromForward, characterHorizontalDirection);
		SetCharacterAnimation(animType, characterDirection);
		_currentDirection = _animationControl.GetCharacterDirection(angleFromForward, characterHorizontalDirection);
		_animationControl.SetCharacterDirection(_currentDirection);
		SetSpeed(speed, animType);
		agent.SetDestination(vector);
		vector.y = base.transform.position.y;
	}

	public void SetAnimationDirectionAndState(Vector3 forward, AnimationController.AnimationType animationState)
	{
		float angleFromForward = _animationControl.GetAngleFromForward(forward);
		float characterHorizontalDirection = _animationControl.GetCharacterHorizontalDirection(forward);
		AnimationController.CharacterDirections characterDirection = _animationControl.GetCharacterDirection(angleFromForward, characterHorizontalDirection);
		SetCharacterAnimation(animationState, characterDirection);
	}

	public void SetSpeed(float speed, AnimationController.AnimationType type)
	{
		agent.speed = speed;
		_animationControl.SetAnimationSpeed(type);
	}

	public void SetAcceleration(float acceleration)
	{
		agent.acceleration = acceleration;
	}

	public void SetSliderValue(float value)
	{
		if (progressSlider != null)
		{
			progressSlider.fillAmount = value;
		}
	}

	public void SetSliderActive(bool active)
	{
		if (progressSlider != null)
		{
			progressSlider.gameObject.SetActive(active);
		}
	}

	public void SetOverrideSliderValue(float value)
	{
		if (overrideSlider != null)
		{
			overrideSlider.fillAmount = value;
		}
	}

	public void SetOverrideSliderActive(bool active)
	{
		if (overrideSlider != null)
		{
			overrideSlider.gameObject.SetActive(active);
		}
	}

	public void SetCharacterAnimation(AnimationController.AnimationType animType)
	{
		SetCharacterAnimation(animType, _currentDirection);
	}

	public void SetCharacterAnimation(AnimationController.AnimationType animType, AnimationController.CharacterDirections direction)
	{
		_animationControl.SetCharacterAnimation(animType, direction);
		_animationControl.SetCharacterDirection(direction);
	}

	public void StopMob(bool setIdleAnimation = false)
	{
		agent.ResetPath();
		agent.velocity = Vector3.zero;
		if (setIdleAnimation)
		{
			SetCharacterAnimation(AnimationController.AnimationType.idle);
		}
	}

	public void ChangeState(MobState nextState)
	{
		if (_currentState != null)
		{
			_currentState.Exit(this);
		}
		_previousState = _currentState;
		_currentState = nextState;
		if (_currentState != null)
		{
			_currentState.Enter(this);
		}
	}

	public void ChangeToPreviousState()
	{
		ChangeState(_previousState);
	}

	private Vector3 FindPointOnNavMesh(Vector3 targetPosition)
	{
		if (NavMesh.SamplePosition(targetPosition, out var hit, 0.5f, agent.areaMask))
		{
			return targetPosition;
		}
		Vector3 vector = (targetPosition - base.transform.position) * 0.75f;
		int i = 0;
		float num = 45f;
		float num2 = num;
		int num3 = 1;
		for (; i < 6; i++)
		{
			vector = Quaternion.AngleAxis(num2 * (float)num3, Vector3.up) * vector;
			Vector3 vector2 = vector + base.transform.position;
			if (NavMesh.SamplePosition(vector2, out hit, 0.5f, agent.areaMask))
			{
				return vector2;
			}
			num2 += num;
			num3 *= -1;
		}
		return targetPosition;
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public override List<UserActions> GetValidActions()
	{
		_validActionList.Clear();
		if (_currentState.CurrentAction is AIMobStunnedAction && _inventory != null)
		{
			_validActionList.Add(UserActions.GIVEITEM);
		}
		if (canBeDismantled)
		{
			_validActionList.Add(UserActions.DISMANTLE);
		}
		if (canBePickedUp || canBePet)
		{
			_validActionList.Add(UserActions.INTERACT);
		}
		return _validActionList;
	}

	public override void ShowTooltip()
	{
	}

	public override string GetItemName()
	{
		return Loc.Get(mobNameKey);
	}

	public override string GetToolTip(UserActions action)
	{
		return base.gameObject.name;
	}

	public void Activate()
	{
		_loadComplete = true;
		base.enabled = true;
		base.gameObject.SetColliderState(enabled: true);
		ChangeState(startState);
		actionIcon.enabled = true;
	}

	public float GetDistanceFromSpawnPosition()
	{
		return Vector3.Distance(_startingPosition, base.transform.position);
	}

	public void DoSpawnAction()
	{
		base.enabled = false;
	}

	public void DoPickupAction()
	{
		Object.Destroy(base.gameObject);
	}
}
