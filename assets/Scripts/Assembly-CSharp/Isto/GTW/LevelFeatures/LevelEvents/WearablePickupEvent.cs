using Isto.GTW.LevelFeatures.Wearables;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class WearablePickupEvent : LevelEvent
{
	[SerializeField]
	protected CharacterWearableData _characterWearableData;

	private PlayerController _playerController;

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		_playerController.PlayerWearableController.SetCharacterWearablePart(_characterWearableData);
	}
}
