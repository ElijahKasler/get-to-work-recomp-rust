using Isto.Core;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class RespawnEvent : LevelEvent
{
	public enum RestartType
	{
		NORMAL = 0,
		DOINKLER_STAGE_RESET = 1
	}

	[SerializeField]
	private bool _showBlackOut = true;

	[SerializeField]
	private bool _restartAtFirstCheckpoint;

	[SerializeField]
	private RestartType _restartType;

	private PlayerController _playerController;

	private CheckpointManager _checkpointManager;

	[Inject]
	public void Inject(PlayerController playerController, CheckpointManager checkpointManager)
	{
		playerController = _playerController;
		_checkpointManager = checkpointManager;
	}

	public override void TriggerEvent(bool initialization = false)
	{
		if (_restartAtFirstCheckpoint)
		{
			_checkpointManager.SetActiveCheckpoint(_checkpointManager.StartingCheckpoint);
		}
		switch (_restartType)
		{
		case RestartType.DOINKLER_STAGE_RESET:
			Events.RaiseEvent(GTWEvents.DOINKLER_STAGE_RESET, args: true);
			break;
		case RestartType.NORMAL:
			_checkpointManager.Respawn(_showBlackOut);
			break;
		}
	}
}
