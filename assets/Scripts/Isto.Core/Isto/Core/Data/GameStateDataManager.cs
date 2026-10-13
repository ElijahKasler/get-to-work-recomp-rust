using System;
using System.IO;
using System.Xml.Serialization;
using Isto.Core.Game;
using Zenject;

namespace Isto.Core.Data;

public class GameStateDataManager : DataManager
{
	public const string FILE_NAME = "gamestate";

	public const string FILE_PREFIX = "/gamestate_";

	private GameState _gameState;

	private string _filename = "_data.xml";

	private IGameData _gameData;

	public override string FilePrefix => "/gamestate_";

	public override string BlobName => "gamestate";

	[Inject]
	public void Inject(GameState gameState, [Inject(Id = "SaveFileSuffix")] string saveFile, IGameData gameData)
	{
		_gameState = gameState;
		_gameData = gameData;
		_filename = saveFile;
	}

	public void PreLoad(int saveSlot, Action<GameStateSaveData> onLoaded)
	{
		_gameData.LoadGameMetaData(saveSlot, onLoaded);
	}

	public void PreSave(int saveSlot, GameStateSaveData data, Action<bool> onSaved)
	{
		_gameData.SaveGameMetaData(saveSlot, data, onSaved);
	}

	public override bool Load(in TextReader reader)
	{
		return true;
	}

	public override bool Validate(in TextReader reader, in object previousDataObject)
	{
		bool result = false;
		GameStateSaveData gameStateSaveData = previousDataObject as GameStateSaveData;
		GameStateSaveData gameStateSaveData2 = DataManager.LoadXMLFile<GameStateSaveData>(reader);
		if (gameStateSaveData2 != null)
		{
			result = gameStateSaveData.Equals(gameStateSaveData2);
		}
		return result;
	}

	public override void Save(out object saveData)
	{
		GameStateSaveData gameStateSaveData = _gameState.SaveGameStateData();
		saveData = gameStateSaveData;
	}

	public override object GetSampleSaveData()
	{
		return new GameStateSaveData();
	}

	public override Type[] GetSaveExtraTypes()
	{
		return null;
	}

	public override void UpgradeSave(string targetVersion, GameStateSaveData metaData, TextReader reader, out XmlSerializer serializer, out object saveData)
	{
		metaData.gameVersion = targetVersion;
		metaData.saveDate = DateTime.Now;
		serializer = DataManager.GetXMLSerializer(metaData);
		saveData = metaData;
	}
}
