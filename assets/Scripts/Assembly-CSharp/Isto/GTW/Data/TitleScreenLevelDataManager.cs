using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.GTW.Managers;
using Zenject;

namespace Isto.GTW.Data;

public class TitleScreenLevelDataManager : DataManager, IDataLoadCompleteHandler
{
	private const string FILE_NAME = "level";

	private const string FILE_PREFIX = "/level_";

	private LevelVariables _levelVariables;

	private IGameProgressProvider _gameProgress;

	public override string FilePrefix => "/level_";

	public override string BlobName => "level";

	[Inject]
	public void Inject(LevelVariables levelVariables, IGameProgressProvider gameProgress)
	{
		_levelVariables = levelVariables;
		_gameProgress = gameProgress;
	}

	public override bool Validate(in TextReader reader, in object previousDataObject)
	{
		bool result = false;
		LevelSaveData levelSaveData = previousDataObject as LevelSaveData;
		LevelSaveData levelSaveData2 = DataManager.LoadXMLFile<LevelSaveData>(reader);
		if (levelSaveData2 != null)
		{
			result = levelSaveData.ContentEquals(levelSaveData2);
		}
		return result;
	}

	public override bool Load(in TextReader reader)
	{
		bool result = false;
		LevelSaveData levelSaveData = DataManager.LoadXMLFile<LevelSaveData>(reader);
		if (levelSaveData != null)
		{
			_gameProgress.LoadLevelTimes(levelSaveData.GetLevelTimes());
			_levelVariables.boolVariables = new Dictionary<string, bool>();
			foreach (LevelSaveData.EntryBool boolVariable in levelSaveData.boolVariables)
			{
				_levelVariables.boolVariables.Add(boolVariable.Key, boolVariable.Value);
			}
			_levelVariables.intVariables = new Dictionary<string, int>();
			foreach (LevelSaveData.EntryInt intVariable in levelSaveData.intVariables)
			{
				_levelVariables.intVariables.Add(intVariable.Key, intVariable.Value);
			}
			_levelVariables.floatVariables = new Dictionary<string, float>();
			foreach (LevelSaveData.EntryFloat floatVariable in levelSaveData.floatVariables)
			{
				_levelVariables.floatVariables.Add(floatVariable.Key, floatVariable.Value);
			}
			_levelVariables.OutputVariables();
			result = true;
		}
		return result;
	}

	public override void Save(out object saveData)
	{
		saveData = null;
	}

	public override object GetSampleSaveData()
	{
		return new LevelSaveData();
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
