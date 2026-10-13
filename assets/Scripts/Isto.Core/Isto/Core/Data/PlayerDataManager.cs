using System;
using System.IO;
using System.Xml.Serialization;
using Isto.Core.Beings;
using Zenject;

namespace Isto.Core.Data;

public class PlayerDataManager : DataManager
{
	private const string FILE_NAME = "coreplayer";

	private const string FILE_PREFIX = "/coreplayer_";

	private IPlayerController _playerControl;

	public override string FilePrefix => "/coreplayer_";

	public override string BlobName => "coreplayer";

	[Inject]
	public void Inject(IPlayerController playerController)
	{
		_playerControl = playerController;
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
		if (playerSaveData != null)
		{
			_playerControl.SetPlayerPosition(playerSaveData.position);
			result = true;
		}
		return result;
	}

	public override void Save(out object saveData)
	{
		PlayerSaveData playerSaveData = new PlayerSaveData
		{
			position = _playerControl.GetPlayerPosition()
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
}
