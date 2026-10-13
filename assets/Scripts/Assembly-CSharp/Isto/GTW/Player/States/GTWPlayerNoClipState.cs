using Isto.Core.StateMachine;
using Isto.GTW.Inputs;
using UnityEngine;

namespace Isto.GTW.Player.States;

[CreateAssetMenu(fileName = "GTW-PlayerNoClipState", menuName = "Scriptables/GTW/States/New GTW Player No Clip State")]
public class GTWPlayerNoClipState : State
{
	private PlayerController _playerController;

	public override void Enter(ScriptableStateMachine controller)
	{
		Debug.Log("Activating Player No clip");
		_playerController = controller as PlayerController;
		_playerController.ResetVelocityToZero();
		_playerController.Rigidbody.isKinematic = true;
		_playerController.SetPlayerColliderState(state: false);
		_playerController.PlayerVirtualCameraController.SetCameraDamping(Vector3.zero, Vector3.zero);
	}

	public override IState Run(ScriptableStateMachine controller)
	{
		if (Time.timeScale == 0f || Time.deltaTime < 1E-05f)
		{
			return this;
		}
		if (_playerController.CheckpointManager != null)
		{
			if (_playerController.restartAbilityAvailable && _playerController.InputControls.GetButtonDown(GTWUserActions.RESPAWNACTIVECHECKPOINT))
			{
				_playerController.CheckpointManager.Respawn(showBlackOut: true);
				return _playerController._moveState;
			}
			if (_playerController.restartStartingCheckpointAbilityAvailable && _playerController.InputControls.GetButtonDown(GTWUserActions.RESPAWNSTARTINGCHECKPOINT))
			{
				_playerController.CheckpointManager.RespawnAtStartingCheckpoint();
				return _playerController._moveState;
			}
		}
		if (_playerController.InputControls.GetButtonDown(GTWUserActions.NOCLIP))
		{
			return _playerController._moveState;
		}
		_playerController.UpdateNoClipMovements();
		_playerController.UpdateDirectionalVectorsInNoClipMode();
		return this;
	}

	public override void Exit(ScriptableStateMachine controller)
	{
		_playerController.PlayerVirtualCameraController.SetDefaultCameraDamping();
	}
}
