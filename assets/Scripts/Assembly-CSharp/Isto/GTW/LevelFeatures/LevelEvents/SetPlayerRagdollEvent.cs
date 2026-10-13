using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class SetPlayerRagdollEvent : LevelEvent
{
	[SerializeField]
	private bool _ragdollStateActive = true;

	private PlayerController _playerController;

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (initialization)
		{
			return;
		}
		if (_ragdollStateActive)
		{
			_playerController._ragdollState.AutoReset = false;
			_playerController._ragdollState.AllowGrab = false;
			if (!_playerController.IsRagdollState)
			{
				_playerController.ChangeToRagdollState();
			}
		}
		else if (!_ragdollStateActive && _playerController.IsRagdollState)
		{
			_playerController.ChangeToMoveState();
		}
	}
}
