using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.GTW.Configuration;
using Isto.GTW.Managers;
using Isto.GTW.Providers;
using Zenject;

namespace Isto.GTW.Data;

public class DoinklerLevelDataManager : DataManager, IDataLoadCompleteHandler
{
	private const string FILE_NAME = "doinkler_level";

	private const string FILE_PREFIX = "/doinkler_level_";

	private DoinklerLevelVariables _doinklerLevelVariables;

	private IGameProgressProvider _gameProgress;

	private IDoinklerWorldDefinitionProvider _doinklerWorldDefinitionProvider;

	public override string FilePrefix => "/doinkler_level_";

	public override string BlobName => "doinkler_level";

	[Inject]
	public void Inject(DoinklerLevelVariables levelVariables, IGameProgressProvider gameProgress, IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider)
	{
		_doinklerLevelVariables = levelVariables;
		_gameProgress = gameProgress;
		_doinklerWorldDefinitionProvider = doinklerWorldDefinitionProvider;
	}

	public override bool Validate(in TextReader reader, in object previousDataObject)
	{
		bool result = false;
		DoinklerLevelSaveData doinklerLevelSaveData = previousDataObject as DoinklerLevelSaveData;
		DoinklerLevelSaveData doinklerLevelSaveData2 = DataManager.LoadXMLFile<DoinklerLevelSaveData>(reader);
		if (doinklerLevelSaveData2 != null)
		{
			result = doinklerLevelSaveData.ContentEquals(doinklerLevelSaveData2);
		}
		return result;
	}

	public override bool Load(in TextReader reader)
	{
		bool result = false;
		DoinklerLevelSaveData doinklerLevelSaveData = DataManager.LoadXMLFile<DoinklerLevelSaveData>(reader);
		if (doinklerLevelSaveData != null)
		{
			_gameProgress.LoadLevelTimes(doinklerLevelSaveData.GetLevelTimes());
			_doinklerLevelVariables.intVariables = new Dictionary<string, int>();
			foreach (DoinklerLevelSaveData.EntryInt intVariable in doinklerLevelSaveData.intVariables)
			{
				_doinklerLevelVariables.intVariables.TryAdd(intVariable.Key, intVariable.Value);
			}
			foreach (DoinklerLevelSaveData.EntryBool boolVariable in doinklerLevelSaveData.boolVariables)
			{
				_doinklerLevelVariables.boolVariables.TryAdd(boolVariable.Key, boolVariable.Value);
			}
			foreach (DoinklerLevelSaveData.EntryFloat floatVariable in doinklerLevelSaveData.floatVariables)
			{
				_doinklerLevelVariables.floatVariables.TryAdd(floatVariable.Key, floatVariable.Value);
			}
			_doinklerLevelVariables.OutputVariables();
			result = true;
		}
		return result;
	}

	public override void Save(out object saveData)
	{
		List<DoinklerLevelSaveData.EntryBool> list = new List<DoinklerLevelSaveData.EntryBool>();
		foreach (string key in _doinklerLevelVariables.boolVariables.Keys)
		{
			list.Add(new DoinklerLevelSaveData.EntryBool(key, _doinklerLevelVariables.boolVariables[key]));
		}
		List<DoinklerLevelSaveData.EntryInt> list2 = new List<DoinklerLevelSaveData.EntryInt>();
		foreach (string key2 in _doinklerLevelVariables.intVariables.Keys)
		{
			list2.Add(new DoinklerLevelSaveData.EntryInt(key2, _doinklerLevelVariables.intVariables[key2]));
		}
		List<DoinklerLevelSaveData.EntryFloat> list3 = new List<DoinklerLevelSaveData.EntryFloat>();
		foreach (string key3 in _doinklerLevelVariables.floatVariables.Keys)
		{
			list3.Add(new DoinklerLevelSaveData.EntryFloat(key3, _doinklerLevelVariables.floatVariables[key3]));
		}
		FilterFloatVariablesByWorldKeys(list3);
		FilterBoolVariablesByWorldKeys(list);
		DoinklerLevelSaveData doinklerLevelSaveData = new DoinklerLevelSaveData
		{
			boolVariables = list,
			intVariables = list2,
			floatVariables = list3
		};
		saveData = doinklerLevelSaveData;
	}

	public override object GetSampleSaveData()
	{
		return new DoinklerLevelSaveData();
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

	private void FilterFloatVariablesByWorldKeys(List<DoinklerLevelSaveData.EntryFloat> floatVars)
	{
		List<string> worldKeys = new List<string>();
		worldKeys.AddRange(_doinklerWorldDefinitionProvider.Current.GameLevels.Select((GTWGameLevelDefinition x) => x.UniqueIDBest));
		worldKeys.AddRange(_doinklerWorldDefinitionProvider.Current.GameLevels.Select((GTWGameLevelDefinition x) => x.UniqueIDTotal));
		floatVars.RemoveAll((DoinklerLevelSaveData.EntryFloat x) => !worldKeys.Contains(x.Key));
	}

	private void FilterBoolVariablesByWorldKeys(List<DoinklerLevelSaveData.EntryBool> boolVars)
	{
		List<string> worldKeys = new List<string>();
		worldKeys.AddRange(_doinklerWorldDefinitionProvider.Current.GameLevels.Select((GTWGameLevelDefinition x) => x.UniqueIDCompleted));
		boolVars.RemoveAll((DoinklerLevelSaveData.EntryBool x) => !worldKeys.Contains(x.Key));
	}
}
