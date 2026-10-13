using System;
using System.IO;
using System.Xml.Serialization;
using Isto.Core;
using Isto.Core.Data;
using Isto.GTW.Data;

namespace Data;

public class TitleScreenDialogueDataManager : DataManager, IDataLoadCompleteHandler
{
	private const string FILE_NAME = "dialogue";

	private const string FILE_PREFIX = "/dialogue_";

	public override string FilePrefix => "/dialogue_";

	public override string BlobName => "dialogue";

	private void OnEnable()
	{
		Events.Subscribe("SettingsChanged", SettingsEvent_OnSettingsChanged);
	}

	private void OnDisable()
	{
		Events.UnSubscribe("SettingsChanged", SettingsEvent_OnSettingsChanged);
	}

	private void SettingsEvent_OnSettingsChanged()
	{
	}

	public override bool Validate(in TextReader reader, in object previousDataObject)
	{
		bool result = false;
		DialogueSaveData dialogueSaveData = previousDataObject as DialogueSaveData;
		DialogueSaveData dialogueSaveData2 = DataManager.LoadXMLFile<DialogueSaveData>(reader);
		if (dialogueSaveData2 != null)
		{
			result = dialogueSaveData.ContentEquals(dialogueSaveData2);
		}
		return result;
	}

	public override bool Load(in TextReader reader)
	{
		bool result = false;
		if (DataManager.LoadXMLFile<DialogueSaveData>(reader) != null)
		{
			result = true;
		}
		return result;
	}

	public override void Save(out object saveData)
	{
		DialogueSaveData dialogueSaveData = new DialogueSaveData
		{
			dialogueData = ""
		};
		saveData = dialogueSaveData;
	}

	public override object GetSampleSaveData()
	{
		return new DialogueSaveData();
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
