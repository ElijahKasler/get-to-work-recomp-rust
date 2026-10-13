using Isto.Core.Game;
using Isto.Core.StateMachine;
using Isto.GTW.SectionLoading;
using UnityEngine;

namespace Isto.GTW.Player.States;

[CreateAssetMenu(fileName = "GTW-PlayerWaitForSectionLoading", menuName = "Scriptables/GTW/States/New GTW Player WaitForSectionLoading")]
public class GTWPlayerWaitForSectionLoading : State
{
	public bool teleportToGroundOnExit;

	public bool keepVelocity;

	public Vector3 velocity = Vector3.zero;

	public Vector3 angularVelocity = Vector3.zero;

	private PlayerController _playerController;

	public override void Enter(ScriptableStateMachine controller)
	{
		Debug.Log("Activating Wait for Section Loading");
		_playerController = controller as PlayerController;
		_playerController.Rigidbody.isKinematic = true;
	}

	public override IState Run(ScriptableStateMachine controller)
	{
		if (!SectionLoader.IsBusy && SectionLoader.SectionLoadingProgress > 0.999f && !GameState.CurrentlyLoading)
		{
			return _playerController._moveState;
		}
		return this;
	}

	public override void Exit(ScriptableStateMachine controller)
	{
		_playerController.Rigidbody.isKinematic = false;
		if (teleportToGroundOnExit)
		{
			_playerController.TeleportToGround();
			teleportToGroundOnExit = false;
		}
		if (keepVelocity)
		{
			_playerController.SetVelocity(velocity, angularVelocity);
			keepVelocity = false;
		}
	}
}
