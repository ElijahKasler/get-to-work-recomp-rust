using Isto.Core;
using Isto.Core.Achievements;
using Isto.Core.StateMachine;
using Isto.GTW.Inputs;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Player.States;

[CreateAssetMenu(fileName = "GTW-PlayerRagdollState", menuName = "Scriptables/GTW/States/New GTW Player Ragdoll State")]
public class GTWPlayerRagdollState : State
{
	public float resetTime = 1f;

	public float giveUpCooldownTime = 1f;

	private PlayerController _playerController;

	private bool _allowGrab = true;

	private bool _autoReset = true;

	private bool _giveUpMode;

	private bool _allowRagdollRecovery = true;

	private bool _resetOnInput;

	private float _ragdollTime;

	private float _totalGiveUpTime;

	private bool _giveUpAchievementSent;

	private bool _isEnterFrame;

	private bool _interuptedFromRespawn;

	private IAchievements _achievements;

	public bool AutoReset
	{
		get
		{
			return _autoReset;
		}
		set
		{
			_autoReset = value;
		}
	}

	public bool InGiveUpMode
	{
		get
		{
			return _giveUpMode;
		}
		set
		{
			_giveUpMode = value;
		}
	}

	public bool AllowGrab
	{
		get
		{
			return _allowGrab;
		}
		set
		{
			_allowGrab = value;
		}
	}

	public bool ResetOnInput
	{
		get
		{
			return _resetOnInput;
		}
		set
		{
			_resetOnInput = value;
		}
	}

	public bool AllowRagdollRecovery
	{
		get
		{
			return _allowRagdollRecovery;
		}
		set
		{
			_allowRagdollRecovery = value;
		}
	}

	[Inject]
	public void Inject(IAchievements achievements)
	{
		_achievements = achievements;
	}

	public override void Enter(ScriptableStateMachine controller)
	{
		Debug.Log("Activating Player Ragdoll");
		_playerController = controller as PlayerController;
		_playerController.PlayerIkController.PlayerRagdoll.SetRagdollActive(isActive: true);
		_playerController.SetPhysicsActive(isActive: false);
		ResetRagdollTime();
		_playerController.SetVelocity(Vector3.zero, Vector3.zero);
		_playerController.PlayerCollisionHandler.ClearGroundHit();
		_isEnterFrame = true;
	}

	public override IState Run(ScriptableStateMachine controller)
	{
		if (_playerController.CheckpointManager != null)
		{
			if (_playerController.restartAbilityAvailable && (_playerController.InputControls.GetButtonDown(GTWUserActions.RESPAWNACTIVECHECKPOINT) || _playerController.InputControls.GetButtonDown(GTWUserActions.RESTART)))
			{
				_interuptedFromRespawn = true;
				Events.RaiseEvent(GTWEvents.DOINKLER_STAGE_RESET, args: true);
				return _playerController._waitForSectionLoading;
			}
			if (_playerController.restartStartingCheckpointAbilityAvailable && _playerController.InputControls.GetButtonDown(GTWUserActions.RESPAWNSTARTINGCHECKPOINT))
			{
				_playerController.CheckpointManager.RespawnAtStartingCheckpoint();
				return _playerController._waitForSectionLoading;
			}
		}
		if (_playerController.noClipAbilityAvailable && _playerController.InputControls.GetButtonDown(GTWUserActions.NOCLIP))
		{
			return _playerController._noClipState;
		}
		_ragdollTime += Time.deltaTime;
		if ((AutoReset && _ragdollTime > resetTime) || (_playerController.ragDollAbilityAvailable && _allowRagdollRecovery && _playerController.InputControls.GetButtonDown(GTWUserActions.GIVEUP) && _ragdollTime > giveUpCooldownTime))
		{
			return _playerController._moveState;
		}
		if (!_giveUpAchievementSent && InGiveUpMode)
		{
			_totalGiveUpTime += Time.deltaTime;
			if (_totalGiveUpTime >= IGTWAchievements.REAL_QUITTER_TIME)
			{
				_achievements.TriggerAchievement(IGTWAchievements.GTWAchievementsEnum.REAL_QUITTER);
				_giveUpAchievementSent = true;
			}
		}
		if (_resetOnInput && _playerController.MovementInput.sqrMagnitude > 0.01f)
		{
			return _playerController._moveState;
		}
		if (!_isEnterFrame && AllowGrab && !AutoReset && _playerController.grabAbilityAvailable && !_playerController.IsGrabLinkActive && _playerController.InputControls.GetButton(GTWUserActions.GRAB) && _ragdollTime > giveUpCooldownTime)
		{
			_playerController.ActivateGrabLink();
			return _playerController._moveState;
		}
		_playerController.UpdateBodyVelocity();
		_isEnterFrame = false;
		return this;
	}

	public override void Exit(ScriptableStateMachine controller)
	{
		Rigidbody pelvisRigidBody = _playerController.PlayerIkController.PlayerRagdoll.PelvisRigidBody;
		Vector3 linearVelocity = pelvisRigidBody.linearVelocity;
		Vector3 angularVelocity = pelvisRigidBody.angularVelocity;
		_playerController.PlayerCollisionHandler.ClearGroundHit();
		_playerController.SetPhysicsActive(isActive: true);
		if (_interuptedFromRespawn)
		{
			_playerController.ResetVelocityToZero();
			_playerController.PlayerIkController.PlayerRagdoll.SetRagdollActive(isActive: false, instant: true);
		}
		else
		{
			Transform transform = pelvisRigidBody.transform;
			_playerController.TeleportCharacter(transform.position + -_playerController.GravityDirection * 0.01f);
			if (!_playerController.TeleportToGround(_playerController.BallRadius + 0.02f))
			{
				_playerController.TeleportCharacter(transform.position);
			}
			_playerController.SetVelocity(linearVelocity, angularVelocity);
			_playerController.PlayerIkController.PlayerRagdoll.SetRagdollActive(isActive: false);
		}
		AutoReset = true;
		AllowGrab = true;
		_resetOnInput = false;
		InGiveUpMode = false;
		_interuptedFromRespawn = false;
	}

	public void ResetRagdollTime()
	{
		_ragdollTime = 0f;
	}
}
