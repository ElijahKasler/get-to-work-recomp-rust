using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Isto.Core.Data;
using Isto.GTW.LevelFeatures;
using UnityEngine;

namespace Isto.GTW.Data;

public class TitleScreenPlayerDataManager : DataManager, IDataLoadCompleteHandler
{
	[SerializeField]
	private CheckpointManagerTitleScreen _checkpointManager;

	private List<int> _seenCheckpointIds = new List<int>();

	private const string FILE_NAME = "player";

	private const string FILE_PREFIX = "/player_";

	public override string FilePrefix => "/player_";

	public override string BlobName => "player";

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
		if (playerSaveData != null)
		{
			if (playerSaveData.checkpointId >= 0 && playerSaveData.checkpointId < _checkpointManager.CheckpointData.levelCheckpointDatas.Count)
			{
				CheckpointData.LevelCheckpointData levelCheckpointData = null;
				if (playerSaveData.seenCheckpoints != null)
				{
					for (int i = 0; i < playerSaveData.seenCheckpoints.Count; i++)
					{
						int index = playerSaveData.seenCheckpoints[i];
						levelCheckpointData = _checkpointManager.CheckpointData.levelCheckpointDatas[index];
						_checkpointManager.SetActiveCheckpoint(levelCheckpointData);
					}
					_seenCheckpointIds = playerSaveData.seenCheckpoints;
				}
				levelCheckpointData = _checkpointManager.CheckpointData.levelCheckpointDatas[playerSaveData.checkpointId];
				_checkpointManager.SetActiveCheckpoint(levelCheckpointData);
			}
			result = true;
		}
		return result;
	}

	public override void Save(out object saveData)
	{
		Vector3 zero = Vector3.zero;
		Vector3 forward = Vector3.forward;
		Vector3 zero2 = Vector3.zero;
		Vector3 zero3 = Vector3.zero;
		int checkpointId = -1;
		float totalHeightGained = 0f;
		float totalDistanceFallen = 0f;
		int totalBigCrashes = 0;
		int dunceHatsCollected = 0;
		List<int> seenCheckpoints = new List<int>();
		PlayerSaveData playerSaveData = new PlayerSaveData
		{
			position = zero,
			forward = forward,
			velocity = zero2,
			angularVelocity = zero3,
			checkpointId = checkpointId,
			seenCheckpoints = seenCheckpoints,
			giveUpAbility = false,
			totalGameTime = 0f,
			totalGameTimeUnscaled = 0f,
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

	public List<int> GetSeenCheckpoints()
	{
		return _seenCheckpointIds;
	}

	public int GetMaxGameProgressLevel()
	{
		return _checkpointManager.CheckpointData.levelCheckpointDatas.OrderBy((CheckpointData.LevelCheckpointData x) => x.checkpointId).Last().checkpointId;
	}

	public int GetCurrentGameProgressLevel()
	{
		return _checkpointManager.CheckpointData.GetCheckpointId(_checkpointManager.ActiveCheckpoint);
	}
}
