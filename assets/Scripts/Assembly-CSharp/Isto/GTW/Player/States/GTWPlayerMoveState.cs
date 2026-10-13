using Isto.Core;
using Isto.Core.Achievements;
using Isto.Core.StateMachine;
using Isto.GTW.Inputs;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Player.States;

[CreateAssetMenu(fileName = "GTW-PlayerMoveState", menuName = "Scriptables/GTW/States/New GTW Player Move State")]
public class GTWPlayerMoveState : State
{
	private PlayerController _playerController;

	private TorquePhysics _torquePhysics;

	private bool _allowGrabAbility = true;

	private bool _allowRagdollAbility = true;

	private IAchievements _achievements;

	public bool AllowGrabAbility
	{
		get
		{
			return _allowGrabAbility;
		}
		set
		{
			_allowGrabAbility = value;
		}
	}

	public bool AllowRagdollAbility
	{
		get
		{
			return _allowRagdollAbility;
		}
		set
		{
			_allowRagdollAbility = value;
		}
	}

	[Inject]
	public void Inject(IAchievements achievements)
	{
		_achievements = achievements;
	}

	public override void Enter(ScriptableStateMachine controller)
	{
		Debug.Log("Activating Player Move");
		_playerController = controller as PlayerController;
		_torquePhysics = _playerController.TorquePhysics;
		_playerController.Rigidbody.isKinematic = false;
		_playerController.SetPlayerColliderState(state: true);
	}

	public override IState Run(ScriptableStateMachine controller)
	{
		if (_playerController.CheckpointManager != null)
		{
			if (_playerController.restartAbilityAvailable && (_playerController.InputControls.GetButtonDown(GTWUserActions.RESPAWNACTIVECHECKPOINT) || _playerController.InputControls.GetButtonDown(GTWUserActions.RESTART)))
			{
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
		_playerController.UpdateDirectionalVectorsAndSpeed();
		_playerController.UpdateBodyVelocity();
		_playerController.UpdateAngularVelocity();
		if (_playerController.grabAbilityAvailable)
		{
			bool flag = AllowGrabAbility && _playerController.InputControls.GetButton(GTWUserActions.GRAB);
			if (!_playerController.IsGrabLinkActive & flag)
			{
				_playerController.ActivateGrabLink();
			}
			else if (_playerController.IsGrabLinkActive && !flag)
			{
				_playerController.DeactivateGrabLink();
				if (!_playerController.IsGrabLinkActive)
				{
					_playerController.TurnPlayerTowardCamera();
				}
			}
		}
		if (AllowRagdollAbility && _playerController.ragDollAbilityAvailable && _playerController.InputControls.GetButtonDown(GTWUserActions.GIVEUP) && !_playerController.IsGrabLinkActive)
		{
			_achievements.TriggerAchievement(IGTWAchievements.GTWAchievementsEnum.QUITTER);
			_playerController._ragdollState.InGiveUpMode = true;
			_playerController._ragdollState.AutoReset = false;
			return _playerController._ragdollState;
		}
		if (_playerController.slowMotionAbilityAvailable && _playerController.InputControls.GetButton(GTWUserActions.SLOWMOTION))
		{
			_playerController.TimeManager.SetSlowMotionActive(isActive: true);
		}
		else if (_playerController.InputControls.GetButtonUp(GTWUserActions.SLOWMOTION))
		{
			_playerController.TimeManager.SetSlowMotionActive(isActive: false);
		}
		return this;
	}

	public override void Exit(ScriptableStateMachine controller)
	{
		_playerController.DeactivateGrabLink();
		_playerController.TimeManager.SetSlowMotionActive(isActive: false);
	}
}
