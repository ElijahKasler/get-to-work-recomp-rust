using System;
using System.Collections;
using System.Collections.Generic;
using Isto.Core.Automation;
using Isto.Core.Cameras;
using Isto.Core.Inputs;
using Isto.Core.Items;
using Isto.Core.Skins;
using Isto.Core.StateMachine;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Isto.Core.Beings;

public class AutomationPlayerController : CorePlayerController
{
	public LayerMask pickupLayers;

	[Header("Animation")]
	[Tooltip("The distance before reaching destination when the animator switches to idle")]
	public float switchToIdleDistance = 0.11f;

	public List<GameObject> animators;

	[Header("Collisions")]
	public Collider mainHitBox;

	public LayerMask obstaclesToMovementMask;

	public Vector3 obstacleDetectionBoxSize;

	protected Collider[] _hitBuffer;

	protected Vector3 _forwardDirection;

	protected HashSet<GameObject> _currentCollisions;

	protected float _desiredSpeed;

	protected float _desiredSpeedOverride;

	protected bool _desiredSpeedOverriden;

	private IPlayerAnimationController _animationControl;

	private SkinController _skinControl;

	protected NavMeshPath _pathBuffer;

	protected float _movementDestinationLeniency;

	protected Transform _currentHandTransform;

	protected Dictionary<CategoryList, Recipe> _mostRecentRecipe;

	protected bool _isCurrentInteractionConsumed;

	public float moveDeltaFactor = 0.2f;

	public EquippableItemController itemInHand;

	public EventHandler<ItemEventArgs> ItemEquippedToPlayer;

	private PlayerInteractWithItemState _interactionState;

	private PlayerPlaceItemState _placeAdvancedItemState;

	private PlayerHarvestState _harvestState;

	private AutomationPlayerMoveState _moveState;

	private PlayerDismantleState _dismantleState;

	private PlayerItemInteraction _itemInteraction;

	private PlayerInventory _inventory;

	private CameraController _camController;

	protected NavMeshAgent _agent;

	protected MasterItemList _masteritemList;

	protected AutomationSystem _automationSystem;

	public Vector3 Forward => _forwardDirection;

	public Vector3 MoveDelta { get; private set; }

	public float RemainingDistance => _agent.remainingDistance;

	public float AvoidRadius => _agent.radius;

	public bool HasPath
	{
		get
		{
			if (!_agent.hasPath)
			{
				return _agent.pathPending;
			}
			return true;
		}
	}

	public override bool IsMoving
	{
		get
		{
			if (_controls.UsingJoystick() && (_controls.GetAxis(Controls.MovementAxis.MoveHorizontal) != 0f || _controls.GetAxis(Controls.MovementAxis.MoveVertical) != 0f))
			{
				return true;
			}
			if (!_agent.IsNullOrDestroyed())
			{
				return _agent.IsMoving(_movementDestinationLeniency);
			}
			return true;
		}
	}

	public float InteractionRange => _interactionState.InteractionRange;

	public NavMeshAgent Agent => _agent;

	protected override Collider MainHitBox => mainHitBox;

	public override State MovementState => _moveState;

	public AutomationPlayerMoveState MoveState => _moveState;

	public PlayerPlaceItemBaseState PlaceAdvItemState => _placeAdvancedItemState;

	public PlayerDismantleState DismantleState => _dismantleState;

	public PlayerInteractWithItemState InteractionState => _interactionState;

	public PlayerInventory Inventory => _inventory;

	public AnimationController.CharacterDirections Facing
	{
		get
		{
			if (_animationControl == null)
			{
				return AnimationController.CharacterDirections.down_right;
			}
			return _animationControl.GetFacing();
		}
	}

	public PlayerItemInteraction ItemInteraction => _itemInteraction;

	public PlayerHarvestState HarvestState => _harvestState;

	public Transform Hand => _currentHandTransform;

	public IPlayerAnimationController Animation => _animationControl;

	[Inject]
	private void Inject(PlayerInteractWithItemState interactState, AutomationPlayerMoveState moveState, PlayerDismantleState dismantlingState, PlayerItemInteraction itemInteraction, PlayerPlaceItemState advState, PlayerHarvestState harvestState, PlayerInventory playerInventory, CameraController camcontrol, NavMeshAgent agent, MasterItemList masterItemList, AutomationSystem automationSystem)
	{
		_interactionState = interactState;
		_placeAdvancedItemState = advState;
		_harvestState = harvestState;
		_moveState = moveState;
		_dismantleState = dismantlingState;
		_itemInteraction = itemInteraction;
		_inventory = playerInventory;
		_camController = camcontrol;
		_agent = agent;
		_masteritemList = masterItemList;
		_automationSystem = automationSystem;
	}

	protected override void Awake()
	{
		base.Awake();
		_hitBuffer = new Collider[20];
		_currentCollisions = new HashSet<GameObject>();
		_animationControl = GetComponent<IPlayerAnimationController>();
		_pathBuffer = new NavMeshPath();
	}

	protected override void Start()
	{
		StartCoroutine(DelayedInitialization());
		base.Start();
	}

	protected override void Update()
	{
		base.Update();
		if (!_statesPaused)
		{
			UpdateForwardDirection();
			UpdateEquippedItemPosition();
			UpdateMoveDelta();
			_agent.speed = GetAdjustedMoveSpeed();
		}
	}

	private void LateUpdate()
	{
		if (Mathf.Abs(_agent.velocity.sqrMagnitude) > 0.25f)
		{
			SetFacingDirection(_agent.velocity);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (pickupLayers.IsInLayerMask(other.gameObject.layer))
		{
			AddToCollisions(other.gameObject);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (pickupLayers.IsInLayerMask(collision.gameObject.layer))
		{
			AddToCollisions(collision.gameObject);
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (pickupLayers.IsInLayerMask(collision.gameObject.layer))
		{
			RemoveFromCollisions(collision.gameObject);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		RemoveFromCollisions(other.gameObject);
	}

	protected override void OnPlayerTakeDamage(object sender, HealthEventArgs e)
	{
		if (!(e.type == Health.DamageTypeEnum.PHYSICAL))
		{
			StartCoroutine(DisablePlayerForTimeRoutine(e.stunTime));
		}
	}

	protected override void OnPlayerKilled(object sender, HealthEventArgs e)
	{
		StopAllCoroutines();
		_statesPaused = false;
	}

	public override Vector3 GetPlayerPosition()
	{
		return _agent.transform.position;
	}

	public override void SetPlayerPosition(Vector3 pos)
	{
		TeleportCharacter(pos);
	}

	private float GetAdjustedMoveSpeed()
	{
		float num = Vector3.Angle(Constants.RIGHT, _forwardDirection);
		num = ((num > 90f) ? (180f - num) : num);
		return _desiredSpeed + num / 90f * 1.2f;
	}

	public void SetMoveSpeed(float speed)
	{
		_desiredSpeed = speed;
	}

	public void SetBaseMoveSpeedOverride(float speed)
	{
		_desiredSpeedOverride = speed;
		_desiredSpeedOverriden = true;
		SetMoveSpeed(speed);
	}

	public void ResetBaseMoveSpeedOverride()
	{
		SetMoveSpeed(MoveState.speed);
		_desiredSpeedOverriden = false;
	}

	public float GetMoveSpeed()
	{
		return _desiredSpeed;
	}

	public float GetMoveSpeedOverride()
	{
		return _desiredSpeedOverride;
	}

	public bool IsSpeedOverrideEnabled()
	{
		return _desiredSpeedOverriden;
	}

	public void SetCurrentInteractionConsumed()
	{
		_isCurrentInteractionConsumed = true;
	}

	public virtual void SetFacingDirection(Vector3 direction)
	{
		_forwardDirection = direction.normalized;
		if (float.IsNaN(_forwardDirection.x))
		{
			_forwardDirection = Constants.FORWARD;
		}
	}

	public void SetPickupItem(IInteractable targetInteractable)
	{
		if (_currentState.isInterruptable)
		{
			_interactionState.SetPickupItem(targetInteractable);
			ChangeState(_interactionState);
		}
	}

	public void SetHarvestItem(GameObject targetObject)
	{
		if (_currentState.isInterruptable && (_currentState != _harvestState || (_currentState == _harvestState && _harvestState.CurrentTarget != targetObject)))
		{
			_harvestState.SetHarvestItem(targetObject);
			ChangeState(_harvestState);
		}
	}

	public override void SetMovementEnabled(bool active)
	{
		_placeAdvancedItemState.SetMovementState(active);
	}

	private IEnumerator DelayedInitialization()
	{
		NavMeshSurface navMeshSurface = null;
		while (navMeshSurface == null)
		{
			yield return null;
			navMeshSurface = UnityEngine.Object.FindObjectOfType<NavMeshSurface>(includeInactive: true);
		}
		_agent.enabled = true;
		Rigidbody component = GetComponent<Rigidbody>();
		if (component != null)
		{
			component.useGravity = true;
		}
	}

	private void UpdateMoveDelta()
	{
		float maxDistanceDelta = ((_agent.velocity == Vector3.zero) ? 0.5f : moveDeltaFactor);
		MoveDelta = Vector3.ClampMagnitude(Vector3.MoveTowards(MoveDelta, _agent.velocity, maxDistanceDelta), 1f);
	}

	protected virtual void UpdateEquippedItemPosition()
	{
	}

	private void AddToCollisions(GameObject hitObject)
	{
		IItemTopmostParent componentInParent = hitObject.GetComponentInParent<IItemTopmostParent>();
		if (componentInParent != null)
		{
			_currentCollisions.Add(componentInParent.GetGameObject());
		}
	}

	private void RemoveFromCollisions(GameObject hitObject)
	{
		IItemTopmostParent componentInParent = hitObject.GetComponentInParent<IItemTopmostParent>();
		if (componentInParent != null)
		{
			_currentCollisions.Remove(componentInParent.GetGameObject());
		}
	}

	public bool IsHittingAnyMobs(out GameObject mob)
	{
		foreach (GameObject currentCollision in _currentCollisions)
		{
			if (currentCollision.layer == Layers.MOB)
			{
				mob = currentCollision;
				return true;
			}
		}
		mob = null;
		return false;
	}

	public virtual State ProcessMovementAndInteractions(bool movement, bool ability, bool itemInteraction)
	{
		if (_isCurrentInteractionConsumed)
		{
			_isCurrentInteractionConsumed = _controls.GetButton(UserActions.INTERACT);
		}
		if (ability)
		{
			PlayerAbilityState readyAbility = _abilities.GetReadyAbility();
			if (readyAbility != null)
			{
				return readyAbility;
			}
		}
		if (itemInteraction && _itemInteraction.ProcessInput())
		{
			_isCurrentInteractionConsumed = _controls.GetButtonDown(UserActions.INTERACT);
			return _currentState;
		}
		if (movement && SetNewMovement(_isCurrentInteractionConsumed))
		{
			return _moveState;
		}
		return null;
	}

	protected bool SetNewMovement(bool ignoreCurrentInteraction)
	{
		bool result = false;
		float axis = _controls.GetAxis(Controls.MovementAxis.MoveHorizontal);
		float axis2 = _controls.GetAxis(Controls.MovementAxis.MoveVertical);
		if (axis != 0f || axis2 != 0f)
		{
			MoveCharacter(axis, axis2);
			result = true;
		}
		else if (!_controls.UsingJoystick() && !ignoreCurrentInteraction && _controls.GetButton(UserActions.INTERACT, ignoreMouse: true) && !_controls.GetPointerOverUI())
		{
			Vector3 vector = _controls.GetPointerPositionOnGround() + Constants.PLAYER_MOUSE_CENTERING_OFFEST;
			if (Vector3.Distance(vector, base.transform.position) > 1.25f)
			{
				MoveCharacterToPosition(vector);
				result = true;
			}
		}
		return result;
	}

	public void ClearNavPath()
	{
		if (_agent.isOnNavMesh)
		{
			_agent.ResetPath();
		}
	}

	public void InstantRelativeMove(Vector3 relativePosition)
	{
		_agent.Move(relativePosition);
	}

	public void MoveCharacterToPosition(Vector3 position)
	{
		MoveCharacterToPosition(position, _desiredSpeed);
	}

	public void MoveCharacterToPosition(Vector3 position, float speed)
	{
		Vector3 vector = position;
		_desiredSpeed = speed;
		vector.y = base.transform.position.y;
		Collider[] array = Physics.OverlapBox(vector, obstacleDetectionBoxSize, Quaternion.identity, obstaclesToMovementMask, QueryTriggerInteraction.Collide);
		_movementDestinationLeniency = 0f;
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (collider.bounds.extents.x > _movementDestinationLeniency)
			{
				_movementDestinationLeniency = collider.bounds.extents.x;
			}
			if (collider.bounds.extents.y > _movementDestinationLeniency)
			{
				_movementDestinationLeniency = collider.bounds.extents.y;
			}
		}
		_agent.CalculatePath(vector, _pathBuffer);
		if (_pathBuffer.status == NavMeshPathStatus.PathInvalid)
		{
			if (NavMesh.SamplePosition(position, out var hit, 10f, -1))
			{
				_agent.CalculatePath(hit.position, _pathBuffer);
				_agent.SetPath(_pathBuffer);
			}
		}
		else
		{
			_agent.SetPath(_pathBuffer);
		}
	}

	public void MoveCharacter(float horiz, float vert)
	{
		Vector3 vector = UnityUtils.ConvertScreenVectorToIsometric(horiz, vert) * _desiredSpeed * Time.deltaTime;
		_agent.ResetPath();
		_agent.velocity = vector.normalized * GetAdjustedMoveSpeed();
	}

	public void TeleportCharacter(Vector3 position)
	{
		if (_agent.isOnNavMesh)
		{
			_agent.SetDestination(position);
			_agent.Warp(position);
		}
		else
		{
			Vector3 vector = position;
			Debug.LogWarning("Trying to teleport player that is not on a nav mesh. Player may be set outside of normal gameplay bounds in EssentialScene or the additive scene has not been loaded yet. Position: " + vector.ToString(), base.gameObject);
			_agent.transform.position = position;
		}
	}

	public void StopCharacter()
	{
		ClearNavPath();
	}

	public virtual void SetCharacterIdle()
	{
		StopCharacter();
	}

	public void SetMoveToAndInteractWithItem(IInteractable targetInteractable, float interactionDistanceOverride = 0f)
	{
		if (_currentState.isInterruptable)
		{
			_itemInteraction.DelayInteraction(Constants.BUTTON_SPAM_DELAY);
			_interactionState.SetInteractWithItem(targetInteractable, interactionDistanceOverride);
			ChangeState(_interactionState);
		}
	}

	public bool UseEquippedItem(Vector3 position, ItemPile itemPile, IItemInteractionCallback callback)
	{
		if (itemPile.item is AdvancedItem advancedItem)
		{
			if (!advancedItem.simpleDrop)
			{
				if ((_currentState.isInterruptable || _currentState == _placeAdvancedItemState) && (_placeAdvancedItemState.CurrentItem == null || _placeAdvancedItemState.CurrentItem.CurrentItem.item.itemID != itemPile.item.itemID))
				{
					_placeAdvancedItemState.SetupItemDrop(itemPile.item);
					if (_currentState != _placeAdvancedItemState)
					{
						ChangeState(_placeAdvancedItemState);
					}
					return true;
				}
				return false;
			}
			_interactionState.SetItemDrop(position, itemPile, callback);
			ChangeState(_interactionState);
			return true;
		}
		if (itemPile.item.coreItemAssetOverride != null && itemPile.item.coreItemAssetOverride.RuntimeKeyIsValid())
		{
			_interactionState.SetItemDrop(position, itemPile, callback);
			ChangeState(_interactionState);
			return true;
		}
		if (_inventory.GetCountOfItem(itemPile.item) > 0 && _automationSystem.TryAddCoreItem(base.transform.position + -Constants.FORWARD * 0.5f, itemPile.item))
		{
			_inventory.Remove(itemPile.item);
		}
		return true;
	}

	public void SetDropComplete(bool stopDropping = false)
	{
		_placeAdvancedItemState.SetDropComplete(stopDropping);
	}

	public void SetDropCancelled(bool stopDropping = false)
	{
		_placeAdvancedItemState.SetDropComplete(stopDropping, wasCancelled: true);
	}

	public void SetDismantleComplete(bool stopDropping = false)
	{
		_dismantleState.SetDropComplete(stopDropping);
	}

	public void SetDismantleCancelled()
	{
		_dismantleState.AbortAllDismantling();
		_dismantleState.SetDropComplete(stopDropping: true);
	}

	public void EquipItemOnPlayer(AdvancedItem item)
	{
		EquippableItemController component = item.DropItem(base.transform.position, base.transform, 1, true).GetComponent<EquippableItemController>();
		if (component != null)
		{
			if (itemInHand == null || component.Consumable)
			{
				component.ItemEquipped();
			}
			else
			{
				itemInHand.ItemUnequipped();
				component.ItemEquipped();
			}
			_inventory.Remove(item);
			ItemEquippedToPlayer?.Invoke(this, new ItemEventArgs(_inventory, item));
		}
	}

	public void StartDismantling()
	{
		AdvancedItem itemByID = _masteritemList.GetItemByID<AdvancedItem>("Eraser");
		if (_currentState.isInterruptable || _currentState == _dismantleState)
		{
			_dismantleState.SetupItemDrop(itemByID);
			if (_currentState != _dismantleState)
			{
				ChangeState(_dismantleState);
			}
		}
	}

	public override void ChangeToMoveState()
	{
		ChangeState(_moveState);
	}

	public override void ChangeToCustomState(State state)
	{
		ChangeState(state);
	}

	public override void DisableAllPlayerControls(float time)
	{
		base.DisableAllPlayerControls(time);
		_itemInteraction.DelayInteraction(time);
	}

	public virtual void DelayItemInteraction(float time)
	{
		_itemInteraction.DelayInteraction(time);
	}

	private GameObject ItemInRange(Vector3 centerPosition, float range, int layers)
	{
		int num = Physics.OverlapSphereNonAlloc(centerPosition, range, _hitBuffer, layers);
		if (num != 0)
		{
			Collider collider = _hitBuffer[0];
			float num2 = Vector3.Distance(collider.transform.position, base.transform.position);
			for (int i = 1; i < num; i++)
			{
				float num3 = Vector3.Distance(_hitBuffer[i].transform.position, base.transform.position);
				if (num3 < num2)
				{
					num2 = num3;
					collider = _hitBuffer[i];
				}
			}
			IItemTopmostParent componentInParent = collider.GetComponentInParent<IItemTopmostParent>();
			if (componentInParent == null)
			{
				string text = "";
				Transform parent = collider.transform;
				while (parent != null)
				{
					text = text + ":" + parent.name;
					parent = parent.parent;
				}
				throw new UnityException("Unable to find TopmostParent interface on gameobject: " + text);
			}
			GameObject obj = componentInParent.GetGameObject();
			if (obj == null)
			{
				throw new UnityException("No Item Controller attached to item on pickup target layers.  Item name: " + collider.name);
			}
			return obj;
		}
		return null;
	}

	private void UpdateForwardDirection()
	{
		if (_agent.hasPath)
		{
			_forwardDirection = _agent.velocity.normalized;
		}
	}
}
