using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Isto.Core.Data;
using Isto.Core.Inputs;
using Isto.GTW.LevelFeatures;
using Isto.GTW.Managers;
using Isto.GTW.Player;
using UI.ReadyScreen;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Data;

public class PlayerDataManager : DataManager, IDataLoadCompleteHandler
{
	private const string FILE_NAME = "player";

	private const string FILE_PREFIX = "/player_";

	private PlayerController _playerControl;

	private TimeManager _timeManager;

	private GTWGameStats _gtwGameStats;

	private GTWGameState _gameState;

	private IControls _controls;

	public override string FilePrefix => "/player_";

	public override string BlobName => "player";

	public CheckpointManager CheckpointManager => _playerControl.CheckpointManager;

	[Inject]
	public void Inject(PlayerController playerController, TimeManager timeManager, GTWGameStats gtwGameStats, GTWGameState gameState, IControls controls)
	{
		_playerControl = playerController;
		_timeManager = timeManager;
		_gtwGameStats = gtwGameStats;
		_gameState = gameState;
		_controls = controls;
	}

	public override bool Validate(in TextReader reader, in object previousDataObject)
	{
		bool result = false;
		PlayerSaveData playerSaveData = previousDataObject as PlayerSaveData;
		PlayerSaveData playerSaveData2 = DataManager.LoadXMLFile<PlayerSaveData>(reader);
		if (playerSaveData2 != null)
		{
			result = playerSaveData.ContentEquals(playerSaveData2);
		}
		return result;
	}

	public override bool Load(in TextReader reader)
	{
		bool result = false;
		PlayerSaveData playerSaveData = DataManager.LoadXMLFile<PlayerSaveData>(reader);
		if (playerSaveData != null && CheckpointManager != null)
		{
			if (playerSaveData.checkpointId >= 0 && playerSaveData.checkpointId < CheckpointManager.CheckpointData.levelCheckpointDatas.Count)
			{
				CheckpointData.LevelCheckpointData levelCheckpointData = null;
				if (playerSaveData.seenCheckpoints != null)
				{
					for (int i = 0; i < playerSaveData.seenCheckpoints.Count; i++)
					{
						int num = playerSaveData.seenCheckpoints[i];
						if (num > 0 && num < CheckpointManager.CheckpointData.levelCheckpointDatas.Count)
						{
							levelCheckpointData = CheckpointManager.CheckpointData.levelCheckpointDatas[num];
							CheckpointManager.SetActiveCheckpoint(levelCheckpointData);
						}
					}
				}
				levelCheckpointData = CheckpointManager.CheckpointData.levelCheckpointDatas[playerSaveData.checkpointId];
				if (_gameState.GameLevelDefinition != null)
				{
					int checkpointNumber = _gameState.GameLevelDefinition.CheckpointNumber;
					if (checkpointNumber >= 0 && checkpointNumber < CheckpointManager.CheckpointData.levelCheckpointDatas.Count)
					{
						levelCheckpointData = CheckpointManager.CheckpointData.levelCheckpointDatas[checkpointNumber];
					}
				}
				CheckpointManager.SetActiveCheckpoint(levelCheckpointData);
			}
			bool flag = false;
			if (_gameState.GameLevelDefinition != null)
			{
				if (_controls.GetControlMode() == Controls.Mode.UI)
				{
					return true;
				}
				flag = _gameState.GameLevelDefinition.loadPlayerPositionFromSave;
			}
			if (flag)
			{
				_playerControl.TeleportCharacter(playerSaveData.position, playerSaveData.forward);
				if (playerSaveData.checkpointId != CheckpointManager.CheckpointData.levelCheckpointDatas.Count - 1)
				{
					ReadyScreen.ShowReadyScreen = true;
				}
			}
			else
			{
				_playerControl.TeleportCharacter(CheckpointManager.ActiveCheckpoint.position, CheckpointManager.ActiveCheckpoint.forward);
			}
			_playerControl.ResetVelocityToZero();
			_playerControl.SetVelocity(playerSaveData.velocity, playerSaveData.angularVelocity);
			_playerControl.SetDirection(playerSaveData.velocity);
			_playerControl.ChangeToWaitForSectionLoadingState(playerSaveData.velocity, playerSaveData.angularVelocity);
			_playerControl.ragDollAbilityAvailable = playerSaveData.giveUpAbility;
			_timeManager.TotalGameTime = playerSaveData.totalGameTime;
			_timeManager.TotalGameTimeUnscaled = playerSaveData.totalGameTimeUnscaled;
			_gtwGameStats.TotalHeightGained = playerSaveData.totalHeightGained;
			_gtwGameStats.TotalDistanceFallen = playerSaveData.totalDistanceFallen;
			_gtwGameStats.TotalBigCrashes = playerSaveData.totalBigCrashes;
			_gtwGameStats.DunceHatsCollected = playerSaveData.dunceHatsCollected;
			_playerControl.PlayerWearableController.SetCharacterDunceHat(_gtwGameStats.DunceHatsCollected);
			Debug.Log("PlayerDataManager: _timeManager.TotalGameTime:" + _timeManager.TotalGameTime);
			result = true;
		}
		return result;
	}

	public override void Save(out object saveData)
	{
		Vector3 position = _playerControl.PlayerPosition;
		Vector3 forward = _playerControl.DirectionFlat;
		Vector3 velocity = _playerControl.Rigidbody.linearVelocity;
		Vector3 angularVelocity = _playerControl.Rigidbody.angularVelocity;
		int checkpointId = -1;
		if (CheckpointManager.ActiveCheckpoint != null)
		{
			checkpointId = CheckpointManager.CheckpointData.GetCheckpointId(CheckpointManager.ActiveCheckpoint);
			bool flag = false;
			if (_gameState.GameLevelDefinition != null)
			{
				flag = _gameState.GameLevelDefinition.loadPlayerPositionFromSave;
			}
			if (!flag)
			{
				position = CheckpointManager.ActiveCheckpoint.position;
				forward = CheckpointManager.ActiveCheckpoint.forward;
				velocity = Vector3.zero;
				angularVelocity = Vector3.zero;
			}
		}
		bool ragDollAbilityAvailable = _playerControl.ragDollAbilityAvailable;
		float totalHeightGained = _gtwGameStats.TotalHeightGained;
		float totalDistanceFallen = _gtwGameStats.TotalDistanceFallen;
		int totalBigCrashes = _gtwGameStats.TotalBigCrashes;
		int dunceHatsCollected = _gtwGameStats.DunceHatsCollected;
		List<int> seenCheckpoints = CheckpointManager.GetSeenCheckpoints();
		PlayerSaveData playerSaveData = new PlayerSaveData
		{
			position = position,
			forward = forward,
			velocity = velocity,
			angularVelocity = angularVelocity,
			checkpointId = checkpointId,
			seenCheckpoints = seenCheckpoints,
			giveUpAbility = ragDollAbilityAvailable,
			totalGameTime = _timeManager.TotalGameTime,
			totalGameTimeUnscaled = _timeManager.TotalGameTimeUnscaled,
			totalHeightGained = totalHeightGained,
			totalDistanceFallen = totalDistanceFallen,
			totalBigCrashes = totalBigCrashes,
			dunceHatsCollected = dunceHatsCollected
		};
		saveData = playerSaveData;
	}

	public override object GetSampleSaveData()
	{
		return new PlayerSaveData();
	}

	public override Type[] GetSaveExtraTypes()
	{
		return null;
	}

	public override void UpgradeSave(string targetVersion, GameStateSaveData metaData, TextReader reader, out XmlSerializer serializer, out object saveData)
	{
		serializer = null;
		saveData = null;
	}

	public void OnDataLoadComplete()
	{
	}
}
