using Isto.Core.Cheats;
using Isto.GTW.LevelFeatures;
using UnityEngine;

namespace Isto.GTW.DeveloperMode.Actions;

[CreateAssetMenu(fileName = "DevMode - Teleport To Checkpoint Action", menuName = "Scriptables/Dev Mode Actions/Teleport to Checkpoint Action")]
public class TeleportToCheckpointAction : CheatAction
{
	private CheckpointManager _checkpointManager;

	public CheckpointManager CheckpointManager
	{
		get
		{
			if (_checkpointManager == null)
			{
				_checkpointManager = Object.FindObjectOfType<CheckpointManager>();
			}
			return _checkpointManager;
		}
	}

	public override void Activate(params object[] args)
	{
		if (int.TryParse(args[0].ToString(), out var result))
		{
			if (result >= 0 && result < CheckpointManager.CheckpointData.levelCheckpointDatas.Count)
			{
				CheckpointManager.PlayerController.RespawnAtCheckpoint(CheckpointManager.CheckpointData.levelCheckpointDatas[result]);
			}
			return;
		}
		throw new UnityException("Argument error. Useage: Checkpoint 12");
	}

	public override void OnUpdate()
	{
	}

	public override void Deactivate()
	{
	}
}
