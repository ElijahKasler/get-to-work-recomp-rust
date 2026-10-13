using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.GTW.Player.States;

[CreateAssetMenu(fileName = "GTW-PlayerCutsceneState", menuName = "Scriptables/GTW/States/New GTW Player Cutscene State")]
public class GTWPlayerCutsceneState : State
{
	public bool teleportToGroundOnExit;

	public bool unblock;

	private PlayerController _playerController;

	public override void Enter(ScriptableStateMachine controller)
	{
		Debug.Log("Activating Wait for Section Loading");
		_playerController = controller as PlayerController;
		_playerController.Rigidbody.isKinematic = true;
		_playerController.PlayerModelController.gameObject.SetActive(value: false);
	}

	public override IState Run(ScriptableStateMachine controller)
	{
		if (unblock)
		{
			return _playerController._moveState;
		}
		return this;
	}

	public override void Exit(ScriptableStateMachine controller)
	{
		_playerController.PlayerModelController.gameObject.SetActive(value: true);
		_playerController.Rigidbody.isKinematic = false;
		if (teleportToGroundOnExit)
		{
			_playerController.TeleportToGround();
			teleportToGroundOnExit = false;
		}
	}
}
