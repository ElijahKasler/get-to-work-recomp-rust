using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class SetPlayerAllowRagdollRecoveryEvent : LevelEvent
{
	[SerializeField]
	private bool _allowRagdollRecovery = true;

	private PlayerController _playerController;

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (!initialization)
		{
			_playerController._ragdollState.AllowRagdollRecovery = _allowRagdollRecovery;
		}
	}
}
