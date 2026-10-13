using FMODUnity;
using Isto.Core.Audio;
using Isto.Core.Inputs;
using Isto.Core.Items;
using Isto.Core.StateMachine;
using UnityEngine;
using Zenject;

namespace Isto.Core.Beings;

[CreateAssetMenu(fileName = "New Player Harvest State", menuName = "Scriptables/State/Player Harvest State")]
public class PlayerHarvestState : State
{
	public float harvestdps;

	[Tooltip("Minimum distance the player must be from harvest position to start harvesting.")]
	public float minHarvestDistance = 0.25f;

	[Header("Audio")]
	[EventRef]
	public string miningAudio;

	protected AutomationPlayerMoveState _moveState;

	protected IControls _controls;

	protected AutomationPlayerController _controller;

	private PlayerProgress _progress;

	private PlayerHealth _playerHealth;

	private IGameSounds _sounds;

	private IPlayerAnimationController _playerAnimation;

	private Vector3 _interactionPosition;

	private bool _harvesting;

	private float _spamDelay;

	private float? _cheaterDPS;

	private float? _cheaterMinHarvestDistance;

	public bool skipHarvestAnimation;

	protected HarvestableController _harvestItem;

	protected GameObject _interactionObject;

	private bool _beamActive;

	public float HarvestDPS
	{
		get
		{
			return _cheaterDPS ?? harvestdps;
		}
		set
		{
			_cheaterDPS = value;
		}
	}

	public float MinHarvestDistance
	{
		get
		{
			return _cheaterMinHarvestDistance ?? minHarvestDistance;
		}
		set
		{
			_cheaterMinHarvestDistance = value;
		}
	}

	public GameObject CurrentTarget => _interactionObject;

	private bool HasAnimationController => _playerAnimation != null;

	[Inject]
	public void Inject(AutomationPlayerController playerController, AutomationPlayerMoveState moveState, IControls controls, PlayerProgress playerProgress, PlayerHealth playerHealth, IGameSounds gameSounds, [InjectOptional] IPlayerAnimationController playerAnimation)
	{
		_controller = playerController;
		_controls = controls;
		_moveState = moveState;
		_progress = playerProgress;
		_playerHealth = playerHealth;
		_sounds = gameSounds;
		_playerAnimation = playerAnimation;
	}

	public override void Enter(ScriptableStateMachine controller)
	{
		_harvesting = false;
		if (IsTargetInInteractionRange())
		{
			Harvest(HarvestDPS * Time.deltaTime);
		}
		else
		{
			SetMovementTowardsItem();
		}
		_spamDelay = 0f;
		if (!_controls.UsingJoystick())
		{
			_controls.DisableControls(Constants.BUTTON_SPAM_DELAY);
		}
		_playerHealth.TookDamage += OnPlayerTakeDamage;
		if (HasAnimationController)
		{
			_playerAnimation.AnimationComplete += OnAnimationComplete;
		}
	}

	private void OnPlayerTakeDamage(object sender, HealthEventArgs e)
	{
		_controller.ChangeToMoveState();
	}

	public override void Exit(ScriptableStateMachine controller)
	{
		_controller.DelayItemInteraction(Constants.BUTTON_SPAM_DELAY + 0.25f);
		_sounds.StopLoop(miningAudio);
		if (HasAnimationController)
		{
			_playerAnimation.AnimationComplete -= OnAnimationComplete;
		}
		_playerHealth.TookDamage -= OnPlayerTakeDamage;
		if (_harvestItem != null)
		{
			_harvestItem.HarvestingStopped();
		}
		StopHarvestAnimation();
	}

	public override IState Run(ScriptableStateMachine controller)
	{
		_spamDelay += Time.deltaTime;
		if (_spamDelay < 0.25f)
		{
			return this;
		}
		bool itemInteraction = !_controls.GetButton(UserActions.INTERACT);
		State state = _controller.ProcessMovementAndInteractions(movement: true, ability: true, itemInteraction);
		if (state != null && state != this)
		{
			return state;
		}
		if (_controls.UsingJoystick())
		{
			if (_controls.GetButton(UserActions.DISMANTLE))
			{
				return _moveState;
			}
			if (IsTargetInInteractionRange())
			{
				Harvest(HarvestDPS * Time.deltaTime);
				if (_interactionObject == null || _harvestItem.HarvestHealth <= 0f)
				{
					return _moveState;
				}
			}
		}
		else if (IsTargetInInteractionRange() || _harvesting)
		{
			if (!_progress.PlayerCanHarvest(_harvestItem.item))
			{
				return _moveState;
			}
			Harvest(HarvestDPS * Time.deltaTime);
			if (_interactionObject == null || _harvestItem.HarvestHealth <= 0f)
			{
				return _moveState;
			}
		}
		return this;
	}

	private void StopHarvestAnimation()
	{
		if (HasAnimationController)
		{
			_playerAnimation.StopHarvestAnimation();
		}
		_beamActive = false;
	}

	public void SetHarvestItem(GameObject targetObject)
	{
		if (targetObject.layer != Layers.HARVESTABLE)
		{
			throw new UnityException("Non-harvestable item passed to Harvest state. Item: " + targetObject.name);
		}
		_interactionObject = targetObject;
		_harvestItem = targetObject.GetComponent<HarvestableController>();
		_interactionPosition = _harvestItem.GetInteractionPosition(_controller.transform.position);
	}

	protected bool IsTargetInInteractionRange()
	{
		return Vector3.Distance(_interactionPosition, _controller.transform.position) < MinHarvestDistance;
	}

	private void SetMovementTowardsItem()
	{
		_controller.MoveCharacterToPosition(_interactionPosition, _moveState.speed);
	}

	protected void Harvest(float damage)
	{
		if (_harvestItem == null || _interactionObject == null || !_progress.PlayerCanHarvest(_harvestItem.item))
		{
			Debug.LogError("PlayerHarvestState could not harvest the target");
			_controller.SetCharacterIdle();
			return;
		}
		if (!_harvesting)
		{
			_controller.StopCharacter();
			_controller.SetFacingDirection(_interactionObject.transform.position - _controller.transform.position);
			if (HasAnimationController)
			{
				_playerAnimation.StartHarvestAnimation();
			}
			_controller.TeleportCharacter(_interactionPosition);
			_harvesting = true;
			_sounds.PlayLoop(miningAudio, _controller.transform.position);
		}
		if (_beamActive || skipHarvestAnimation)
		{
			if (skipHarvestAnimation)
			{
				_controller.SetFacingDirection(_interactionObject.transform.position - _controller.transform.position);
			}
			_harvestItem.TakeHarvestDamageFromPlayer(damage, _controller.Facing);
		}
	}

	private void OnAnimationComplete(string animationName)
	{
		if (animationName.Contains(_playerAnimation.GetHarvestWarmupAnimationName()))
		{
			_beamActive = true;
		}
	}

	public void DeactiveDPSCheats()
	{
		_cheaterDPS = null;
		_cheaterMinHarvestDistance = null;
	}
}
