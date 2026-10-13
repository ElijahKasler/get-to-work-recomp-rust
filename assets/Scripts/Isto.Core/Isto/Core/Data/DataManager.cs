using System;
using System.IO;
using System.Xml.Serialization;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.Core.Data;

public abstract class DataManager : MonoBehaviour, IDataManager
{
	private static UIModalPopup _errorPopup;

	public abstract string FilePrefix { get; }

	public abstract string BlobName { get; }

	public static string SaveBackupFolderName => "/Backup";

	[Inject]
	public void Inject([InjectOptional] UIModalPopup errorPopup)
	{
		_errorPopup = errorPopup;
	}

	public abstract bool Load(in TextReader reader);

	public abstract void Save(out object saveData);

	public abstract bool Validate(in TextReader reader, in object previousData);

	public abstract void UpgradeSave(string targetVersion, GameStateSaveData metaData, TextReader reader, out XmlSerializer serializer, out object saveData);

	public abstract object GetSampleSaveData();

	public abstract Type[] GetSaveExtraTypes();

	public static XmlSerializer GetXMLSerializer<T>(T saveData, Type[] extraTypes = null)
	{
		return new XmlSerializer(saveData.GetType(), extraTypes);
	}

	public static T LoadXMLFile<T>(TextReader reader, Type[] extraTypes = null)
	{
		if (reader == null)
		{
			Debug.LogError($"LoadXMLFile for type {typeof(T)} received a null reader and as such cannot read the file");
			_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.UnknownError, new NullReferenceException($"LoadXMLFile cannot provide {typeof(T)} because reader was invalid. Save file might be corrupted."));
			return default;
		}
		try
		{
			return (T)new XmlSerializer(typeof(T), extraTypes).Deserialize(reader);
		}
		catch (Exception ex)
		{
			Debug.Log($"Unable to load data file for {typeof(T)}, Error: {ex.Message}, Inner: {ex.InnerException?.Message}");
			Exception e = new Exception($"[{typeof(T)}] " + ex.Message, ex.InnerException);
			_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.UnknownError, e);
			return default;
		}
		finally
		{
			reader?.Close();
		}
	}
}
