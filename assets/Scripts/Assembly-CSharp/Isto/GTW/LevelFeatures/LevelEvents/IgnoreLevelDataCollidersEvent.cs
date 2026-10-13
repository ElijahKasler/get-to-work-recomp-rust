using System.Collections.Generic;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class IgnoreLevelDataCollidersEvent : LevelEvent
{
	[SerializeField]
	private List<string> _sceneNamesToIgnore = new List<string>();

	private PlayerController _playerController;

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		_playerController.SetIgnoreLevelDataColliders(_sceneNamesToIgnore);
	}
}
