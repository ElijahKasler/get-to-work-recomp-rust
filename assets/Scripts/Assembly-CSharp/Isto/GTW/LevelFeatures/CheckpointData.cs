using System;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.GTW.LevelFeatures;

[CreateAssetMenu(fileName = "GTW-CheckpointData", menuName = "Scriptables/GTW/CheckpointData")]
public class CheckpointData : ScriptableObject
{
	[Serializable]
	public class LevelCheckpointData
	{
		public string checkpointName;

		public string sceneName;

		public int checkpointId;

		public Vector3 position;

		public Vector3 forward;

		public bool spawnOnGround;

		public bool showInSpeedrunTimer;

		public string FullName => sceneName + checkpointName;
	}

	public List<LevelCheckpointData> levelCheckpointDatas = new List<LevelCheckpointData>();

	public int startingCheckpointId;

	public LevelCheckpointData StartingCheckpoint
	{
		get
		{
			if (startingCheckpointId < 0 || startingCheckpointId >= levelCheckpointDatas.Count)
			{
				return null;
			}
			return levelCheckpointDatas[startingCheckpointId];
		}
	}

	public bool AddCheckpoint(Checkpoint checkpoint)
	{
		return AddCheckpoint(checkpoint.ToLevelCheckpointData());
	}

	public bool AddCheckpoint(LevelCheckpointData levelCheckpointData)
	{
		int num = levelCheckpointDatas.FindIndex((LevelCheckpointData x) => x?.checkpointName == levelCheckpointData.checkpointName && x?.sceneName == levelCheckpointData.sceneName);
		if (num < 0)
		{
			levelCheckpointDatas.Add(levelCheckpointData);
			levelCheckpointData.checkpointId = levelCheckpointDatas.Count - 1;
			return false;
		}
		levelCheckpointDatas[num] = levelCheckpointData;
		levelCheckpointData.checkpointId = num;
		return true;
	}

	public int GetCheckpointId(Checkpoint checkpoint)
	{
		return GetCheckpointId(checkpoint.name, checkpoint.SceneName);
	}

	public int GetCheckpointId(LevelCheckpointData levelCheckpointData)
	{
		if (levelCheckpointData.checkpointId < 0)
		{
			levelCheckpointData.checkpointId = GetCheckpointId(levelCheckpointData.checkpointName, levelCheckpointData.sceneName);
		}
		return levelCheckpointData.checkpointId;
	}

	public int GetCheckpointId(string name, string sceneName)
	{
		return levelCheckpointDatas.FindIndex((LevelCheckpointData x) => x.checkpointName == name && x.sceneName == sceneName);
	}

	public void SetSpawnAtStartId(int id)
	{
		startingCheckpointId = id;
	}

	public void SetSpawnAtStartId(string name, string sceneName)
	{
		SetSpawnAtStartId(levelCheckpointDatas.FindIndex((LevelCheckpointData x) => x.checkpointName == name && x.sceneName == sceneName));
	}

	public void SetSpawnAtStartId(Checkpoint checkpoint)
	{
		SetSpawnAtStartId(checkpoint.CheckpointName, checkpoint.SceneName);
	}

	public void SetSpawnAtStartId(LevelCheckpointData levelCheckpointData)
	{
		SetSpawnAtStartId(levelCheckpointData.checkpointName, levelCheckpointData.sceneName);
	}
}
