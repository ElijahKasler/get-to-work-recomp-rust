using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class SetPlayerAllowRagdollAbilityEvent : LevelEvent
{
	[SerializeField]
	private bool _allowRagdollAbility = true;

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
			_playerController._moveState.AllowRagdollAbility = _allowRagdollAbility;
		}
	}
}
