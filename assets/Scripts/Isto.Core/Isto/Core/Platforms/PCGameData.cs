using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using I2.Loc;
using Isto.Core.Cameras;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Localization;
using Isto.Core.Speedrun;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.Core.Platforms;

public class PCGameData : MonoBehaviour, IGameData, IDataLoadCompleteHandler
{
	public static readonly int MaximumNumberOfRegularSaveSlots = 50;

	public static readonly string SaveSlotFolderPrefix = "SaveSlot";

	[SerializeField]
	private Settings _settings;

	[SerializeField]
	private LocalizedString _upgradeSuffix;

	[SerializeField]
	private string _customControlsSaveFilename = "CustomControlMap";

	[SerializeField]
	private bool _allowScreenshots = true;

	[SerializeField]
	private bool _allowValidation = true;

	private string _thumbnailFilename = "\\thumb.png";

	private bool _initialized;

	private DataManager[] _managers;

	private XmlSerializer[] _serializers;

	protected string _baseFilename;

	private static UIModalPopup _errorPopup;

	private IGameData.GameDataLocation _saveSlotLocation;

	private SpeedrunSettings _speedrunSettings;

	private Exception loadException;

	private GameStateSaveData loadedData;

	private static Exception saveException = null;

	private static int saveCount = 0;

	private static Dictionary<string, Thread> _threadPool = new Dictionary<string, Thread>();

	private static readonly string NO_FILE_PREFIX = "/";

	public IGameData.GameDataLocation CurrentSaveLocation => _saveSlotLocation;

	public int MaximumSaveSlots => MaximumNumberOfRegularSaveSlots;

	[Inject]
	public void Inject([Inject(Id = "SaveSlotLocation")] IGameData.GameDataLocation saveSlotLocation, [Inject(Id = "SaveFileSuffix")] string saveFile, SpeedrunSettings speedrunSettings, [InjectOptional] UIModalPopup errorPopup)
	{
		_saveSlotLocation = saveSlotLocation;
		_baseFilename = saveFile;
		_speedrunSettings = speedrunSettings;
		_errorPopup = errorPopup;
		if (_saveSlotLocation != IGameData.GameDataLocation.PersistentDataPath && _saveSlotLocation != IGameData.GameDataLocation.ResourcesFolder)
		{
			Debug.LogError($"GameDataLocation {_saveSlotLocation} is not supported on PC yet");
		}
	}

	private void Start()
	{
	}

	public void OnDataLoadComplete()
	{
		Initialize();
	}

	private void Initialize()
	{
		if (_initialized)
		{
			for (int i = 0; i < _managers.Length; i++)
			{
				if (_managers[i] == null)
				{
					_initialized = false;
					break;
				}
			}
		}
		if (!_initialized)
		{
			_managers = UnityEngine.Object.FindObjectsOfType<DataManager>();
			_serializers = new XmlSerializer[_managers.Length];
			for (int j = 0; j < _managers.Length; j++)
			{
				object sampleSaveData = _managers[j].GetSampleSaveData();
				Type[] saveExtraTypes = _managers[j].GetSaveExtraTypes();
				_serializers[j] = new XmlSerializer(sampleSaveData.GetType(), saveExtraTypes);
			}
			_initialized = true;
		}
	}

	public static string GetFilePath(string fileName, string saveLocation, string prefix)
	{
		return saveLocation + prefix + fileName;
	}

	public void SaveGameMetaData(int saveSlot, GameStateSaveData saveData, Action<bool> onSaveComplete, bool async = true)
	{
		string saveDirectory = GetSaveDirectory(saveSlot);
		string filePath = GetFilePath(_baseFilename, saveDirectory, "/gamestate_");
		XmlSerializer serializer = new XmlSerializer(typeof(GameStateSaveData));
		bool obj = WriteFile(filePath, serializer, saveData, async);
		onSaveComplete?.Invoke(obj);
	}

	public void LoadGameMetaData(int saveSlot, Action<GameStateSaveData> onLoadComplete)
	{
		loadedData = null;
		string saveDirectory = GetSaveDirectory(saveSlot);
		string fullFilename = GetFilePath(_baseFilename, saveDirectory, "/gamestate_");
		if (XMLFileExists(fullFilename))
		{
			loadException = null;
			ThreadPool.QueueUserWorkItem((object state) =>
			{
				using TextReader textReader = ReadFile(fullFilename);
				if (textReader != null)
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameStateSaveData));
					try
					{
						loadedData = (GameStateSaveData)xmlSerializer.Deserialize(textReader);
						return;
					}
					catch (InvalidOperationException ex)
					{
						loadException = ex;
						return;
					}
				}
			});
			StartCoroutine(WaitThreadForLoad(onLoadComplete));
		}
		else
		{
			onLoadComplete?.Invoke(loadedData);
		}
	}

	private IEnumerator WaitThreadForLoad(Action<GameStateSaveData> onLoadComplete)
	{
		while (loadedData == null && loadException == null)
		{
			yield return null;
		}
		if (loadException != null)
		{
			Debug.LogError("caught InvalidOperationException: " + loadException.InnerException.Message);
			onLoadComplete?.Invoke(null);
		}
		else
		{
			onLoadComplete?.Invoke(loadedData);
		}
	}

	public void SaveGameData(int saveSlot, bool createBackup, Action<bool> onSaveComplete, bool async = true)
	{
		if (createBackup)
		{
			GetNextAvailableSlotNumber(saveSlot, (int backupSlotNum) =>
			{
				if (backupSlotNum != -1)
				{
					DuplicateGameData(saveSlot, backupSlotNum, (bool backupSuccess) =>
					{
						if (backupSuccess)
						{
							LoadGameMetaData(backupSlotNum, (GameStateSaveData backupMetaData) =>
							{
								if (backupMetaData == null)
								{
									Debug.LogError($"LoadSaveSlotMetaData returned null data for slot#{backupSlotNum} during backup process");
								}
								else
								{
									string text = " " + Loc.Get(_upgradeSuffix);
									if (backupMetaData.saveSlotName.Length > _settings.MaxCharactersInSaveName - text.Length)
									{
										backupMetaData.saveSlotName = backupMetaData.saveSlotName.Substring(0, _settings.MaxCharactersInSaveName - text.Length);
									}
									backupMetaData.saveSlotName += text;
									SaveGameMetaData(backupSlotNum, backupMetaData, (bool success) =>
									{
										Debug.Log(string.Format("UpdateSaveSlotMetaData to rename backup slot#{0} was a {1}", backupSlotNum, success ? "success" : "failure"));
										InternalSaveGameData(saveSlot, backupSuccess ? backupSlotNum : (-1), onSaveComplete);
									}, async);
								}
							});
						}
						else
						{
							InternalSaveGameData(saveSlot, backupSuccess ? backupSlotNum : (-1), onSaveComplete, async);
						}
					});
				}
				else
				{
					InternalSaveGameData(saveSlot, -1, onSaveComplete, async);
				}
			});
		}
		else
		{
			InternalSaveGameData(saveSlot, -1, onSaveComplete, async);
		}
	}

	private void InternalSaveGameData(int saveSlot, int backupSlot, Action<bool> onSaveComplete, bool async = true)
	{
		Initialize();
		saveCount = _managers.Length;
		string saveDirectory = GetSaveDirectory(saveSlot);
		bool flag = WriteSaveGameDataToPath(saveDirectory, async);
		if (backupSlot != -1)
		{
			Debug.LogError("Logic for backup save and validation is not supported yet since we have upgraded the fundamental saving logic on PC! Keep this turned off until it can be fixed!");
			if (flag)
			{
				Debug.Log("Save success. Cleaning backup data.");
				ClearSaveData(backupSlot, (bool cleanupSuccess) =>
				{
					Debug.Log($"Cleanup done on slot {backupSlot}. Succeeded? " + cleanupSuccess);
				});
			}
			else
			{
				Debug.Log("Save failure. Trying to restore backed up data");
				DuplicateGameData(backupSlot, saveSlot, (bool restoreSuccess) =>
				{
					if (restoreSuccess)
					{
						Debug.Log($"Backup restoration on slot {saveSlot} done. Succeeded? " + restoreSuccess);
						ClearSaveData(backupSlot, (bool cleanupSuccess) =>
						{
							Debug.Log($"Cleanup done on slot {backupSlot}. Succeeded? " + cleanupSuccess);
						});
					}
					else
					{
						_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.UnknownError, new Exception("Save failed. The save slot might be corrupted. A copy of your original save file should be available if you exit and re-enter the save menu."));
						Debug.LogWarning($"Backup restoration on slot {saveSlot} failed. Backup slot should still exist.");
					}
				});
			}
		}
		StartCoroutine(WaitThreadForSave(onSaveComplete));
	}

	private IEnumerator WaitThreadForSave(Action<bool> onSaveComplete)
	{
		while (saveCount > 0 && saveException == null)
		{
			yield return null;
		}
		if (saveException != null)
		{
			Debug.LogError("caught InvalidOperationException: " + saveException.InnerException.Message);
			onSaveComplete?.Invoke(obj: false);
		}
		else
		{
			onSaveComplete?.Invoke(obj: true);
		}
	}

	public void LoadGameData(int saveSlot, Action<bool> onLoadComplete = null)
	{
		string saveDirectory = GetSaveDirectory(saveSlot);
		bool obj = LoadGameData(saveDirectory);
		onLoadComplete?.Invoke(obj);
	}

	private bool WriteSaveGameDataToPath(string saveDirectory, bool async = true)
	{
		Initialize();
		bool flag = true;
		for (int i = 0; i < _managers.Length; i++)
		{
			string filePath = GetFilePath(_baseFilename, saveDirectory, _managers[i].FilePrefix);
			_managers[i].Save(out var saveData);
			WriteFile(filePath, _serializers[i], saveData, async);
			if (!_allowValidation)
			{
				continue;
			}
			bool flag2 = ValidateXmlFileAsString(filePath, _serializers[i], saveData);
			using (TextReader reader = ReadFile(filePath))
			{
				if (reader != null)
				{
					bool flag3 = _managers[i].Validate(in reader, in saveData);
					Debug.Log("File " + filePath + " loaded and checked against current data, and is " + (flag3 ? "confirmed" : "not") + " correct");
					if (!flag3 || !flag2)
					{
						flag = false;
					}
					continue;
				}
				flag = false;
			}
			break;
		}
		bool result = flag;
		if (_allowScreenshots && saveDirectory.Contains(SaveSlotFolderPrefix))
		{
			SaveScreenShot(saveDirectory);
		}
		return result;
	}

	private bool ValidateXmlFileAsString(string fullFilename, XmlSerializer serializer, object saveData)
	{
		using TextReader textReader = ReadFile(fullFilename);
		string text = null;
		string text2 = null;
		bool flag = false;
		try
		{
			text = textReader.ReadToEnd();
			XmlWriterSettings settings = new XmlWriterSettings
			{
				CloseOutput = false,
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = false,
				Indent = true
			};
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings))
				{
					serializer.Serialize(xmlWriter, saveData);
				}
				text2 = Encoding.UTF8.GetString(memoryStream.ToArray());
			}
			text2 = text2.Substring(1);
			flag = text != null && text == text2;
			Debug.Log("File " + fullFilename + " checked against serialized original data, and " + (flag ? "is confirmed to be correct" : "IS INCORRECT"));
			if (!flag)
			{
				Debug.LogError("Non matching saved data found. Here are the strings.");
				Debug.Log("read from file: " + text);
				Debug.Log("serialized from game data: " + text2);
			}
		}
		catch (Exception arg)
		{
			Debug.LogError($"Exception during ValidateXmlFileAsString: {arg}");
			flag = false;
		}
		return flag;
	}

	public static bool WriteFile(string filePath, XmlSerializer serializer, object saveData, bool async = true)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(filePath);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			if (async)
			{
				ThreadPool.QueueUserWorkItem((object state) =>
				{
					using (TextWriter textWriter2 = new StreamWriter(filePath))
					{
						serializer.Serialize(textWriter2, saveData);
					}
					saveCount--;
				});
			}
			else
			{
				using TextWriter textWriter = new StreamWriter(filePath);
				serializer.Serialize(textWriter, saveData);
				saveCount--;
			}
			return true;
		}
		catch (UnauthorizedAccessException ex)
		{
			_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.UnauthorizedAccessException, ex);
			Debug.LogError("Unable to save file at path \"" + filePath + "\". " + ex.Message + ". Inner: " + ex.InnerException?.Message);
			return false;
		}
		catch (PathTooLongException ex2)
		{
			_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.PathTooLongException, ex2);
			Debug.LogError("Unable to save file at path \"" + filePath + "\". " + ex2.Message + ". Inner: " + ex2.InnerException?.Message);
			return false;
		}
		catch (DirectoryNotFoundException ex3)
		{
			_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.DirectoryNotFoundException, ex3);
			Debug.LogError("Unable to save file at path \"" + filePath + "\". " + ex3.Message + ". Inner: " + ex3.InnerException?.Message);
			return false;
		}
		catch (Exception ex4)
		{
			_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.UnknownError, ex4);
			Debug.LogError("Unable to save file at path \"" + filePath + "\". " + ex4.Message + ". Inner: " + ex4.InnerException?.Message);
			return false;
		}
	}

	private bool LoadGameData(string saveDirectory)
	{
		Initialize();
		bool flag = false;
		DataManager[] array = Resources.FindObjectsOfTypeAll<DataManager>();
		for (int i = 0; i < array.Length; i++)
		{
			string filePath = GetFilePath(_baseFilename, saveDirectory, array[i].FilePrefix);
			using TextReader reader = ReadFile(filePath);
			if (reader != null)
			{
				if (!array[i].Load(in reader))
				{
					flag = true;
					Debug.LogWarning("File " + filePath + " was read but failed to load");
				}
			}
			else
			{
				flag = true;
				Debug.LogWarning("File " + filePath + " could not be read");
			}
		}
		return !flag;
	}

	public static TextReader ReadFile(string filePath)
	{
		if (filePath.Contains("Resources"))
		{
			try
			{
				string[] separator = new string[1] { "Resources/" };
				string text = filePath.Split(separator, StringSplitOptions.None)[^1];
				int num = text.LastIndexOf('.');
				return new StringReader(Resources.Load<TextAsset>((num == -1) ? text : text.Substring(0, num)).text);
			}
			catch (Exception ex)
			{
				_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.UnknownError, ex);
				Debug.Log("Unable to load file \"" + filePath + "\", Error: " + ex.Message + ", Inner: " + ex.InnerException?.Message);
				return null;
			}
		}
		try
		{
			return new StreamReader(filePath);
		}
		catch (Exception ex2)
		{
			Debug.Log($"Unable to load file \"{filePath}\", {ex2.GetType()}: {ex2.Message}, Inner: {ex2.InnerException?.Message}");
			return null;
		}
	}

	public static bool SaveXMLFile<T>(string filePath, T saveData, Type[] extraTypes = null)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(filePath);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			XmlSerializer xMLSerializer = DataManager.GetXMLSerializer(saveData, extraTypes);
			using (TextWriter textWriter = new StreamWriter(filePath))
			{
				xMLSerializer.Serialize(textWriter, saveData);
			}
			return true;
		}
		catch (UnauthorizedAccessException ex)
		{
			_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.UnauthorizedAccessException, ex);
			Debug.LogError("Unable to save file at path \"" + filePath + "\". " + ex.Message + ". Inner: " + ex.InnerException?.Message);
			return false;
		}
		catch (PathTooLongException ex2)
		{
			_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.PathTooLongException, ex2);
			Debug.LogError("Unable to save file at path \"" + filePath + "\". " + ex2.Message + ". Inner: " + ex2.InnerException?.Message);
			return false;
		}
		catch (DirectoryNotFoundException ex3)
		{
			_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.DirectoryNotFoundException, ex3);
			Debug.LogError("Unable to save file at path \"" + filePath + "\". " + ex3.Message + ". Inner: " + ex3.InnerException?.Message);
			return false;
		}
		catch (Exception ex4)
		{
			_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.UnknownError, ex4);
			Debug.LogError("Unable to save file at path \"" + filePath + "\". " + ex4.Message + ". Inner: " + ex4.InnerException?.Message);
			return false;
		}
	}

	public static bool XMLFileExists(string filePath)
	{
		if (filePath.Contains("Resources"))
		{
			string[] separator = new string[1] { "Resources/" };
			string text = filePath.Split(separator, StringSplitOptions.None)[^1];
			int num = text.LastIndexOf('.');
			return Resources.Load<TextAsset>((num == -1) ? text : text.Substring(0, num)) != null;
		}
		return File.Exists(filePath);
	}

	public static T LoadXMLFile<T>(string filePath, Type[] extraTypes = null)
	{
		if (string.IsNullOrEmpty(filePath))
		{
			return default;
		}
		if (filePath.Contains("Resources"))
		{
			try
			{
				string[] separator = new string[1] { "Resources/" };
				string text = filePath.Split(separator, StringSplitOptions.None)[^1];
				int num = text.LastIndexOf('.');
				TextAsset textAsset = Resources.Load<TextAsset>((num == -1) ? text : text.Substring(0, num));
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), extraTypes);
				StringReader stringReader = new StringReader(textAsset.text);
				T result = (T)xmlSerializer.Deserialize(stringReader);
				stringReader.Close();
				return result;
			}
			catch (Exception ex)
			{
				_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.UnknownError, ex);
				Debug.Log("Unable to load file \"" + filePath + "\", Error: " + ex.Message + ", Inner: " + ex.InnerException?.Message);
				return default;
			}
		}
		StreamReader streamReader = null;
		XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(T), extraTypes);
		try
		{
			streamReader = new StreamReader(filePath);
			return (T)xmlSerializer2.Deserialize(streamReader);
		}
		catch (Exception ex2)
		{
			_errorPopup?.DisplayError(UIModalPopup.ErrorPopupType.UnknownError, ex2);
			Debug.Log("Unable to load file \"" + filePath + "\", Error: " + ex2.Message + ", Inner: " + ex2.InnerException?.Message);
			return default;
		}
		finally
		{
			streamReader?.Dispose();
		}
	}

	public void DuplicateGameData(int sourceSaveSlot, int destinationSaveSlot, Action<bool> onDuplicationComplete)
	{
		string saveDirectory = GetSaveDirectory(sourceSaveSlot);
		string saveDirectory2 = GetSaveDirectory(destinationSaveSlot);
		bool obj = CopyFiles(saveDirectory, saveDirectory2);
		onDuplicationComplete?.Invoke(obj);
	}

	public static bool CopyFiles(string sourceFolder, string backupFolder)
	{
		bool result = false;
		try
		{
			if (Directory.Exists(sourceFolder))
			{
				Directory.CreateDirectory(backupFolder);
				string[] files = Directory.GetFiles(sourceFolder);
				foreach (string obj in files)
				{
					string fileName = Path.GetFileName(obj);
					string destFileName = Path.Combine(backupFolder, fileName);
					File.Copy(obj, destFileName, overwrite: true);
				}
				result = true;
			}
			else
			{
				Debug.LogError("Source path does not exist!");
			}
		}
		catch (Exception arg)
		{
			Debug.LogError($"CopyFiles provoked an exception, probably trying to back up a save file: {arg}");
			try
			{
				if (Directory.Exists(backupFolder))
				{
					Directory.Delete(backupFolder, recursive: true);
				}
			}
			catch (Exception arg2)
			{
				Debug.LogError($"CopyFiles could not cleanup after the exception, and caused a second exception: {arg2}");
			}
		}
		return result;
	}

	public virtual void UpgradeGameData(int saveSlot, string targetSaveVersion, Action<bool> onUpgradeComplete)
	{
	}

	public void HasAnySaveData(Action<bool> onCheckComplete = null)
	{
		bool obj = false;
		for (int i = 0; i < MaximumNumberOfRegularSaveSlots; i++)
		{
			if (HasSaveData(i))
			{
				obj = true;
				break;
			}
		}
		onCheckComplete?.Invoke(obj);
	}

	public void HasSaveData(int slotNumber, Action<bool> onCheckComplete = null)
	{
		onCheckComplete?.Invoke(HasSaveData(slotNumber));
	}

	public bool HasSaveData(int slotNumber)
	{
		bool result = false;
		if (slotNumber > MaximumNumberOfRegularSaveSlots)
		{
			return true;
		}
		string saveDirectory = GetSaveDirectory(slotNumber);
		string searchPattern = "*" + _baseFilename;
		if (Directory.Exists(saveDirectory))
		{
			try
			{
				result = Directory.GetFiles(saveDirectory, searchPattern, SearchOption.TopDirectoryOnly).Length > 1;
			}
			catch (PathTooLongException ex)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.PathTooLongException, ex);
				Debug.LogError($"Error checking save slot {slotNumber} at {saveDirectory} for save data.  Exception: {ex.Message}\n{ex.InnerException?.Message}");
			}
			catch (IOException ex2)
			{
				Debug.LogError($"Error checking save slot {slotNumber} at {saveDirectory} for save data.  Exception: {ex2.Message}\n{ex2.InnerException?.Message}");
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.IOException, ex2);
			}
			catch (Exception ex3)
			{
				Debug.LogError($"Error checking save slot {slotNumber} at {saveDirectory} for save data.  Exception: {ex3.Message}\n{ex3.InnerException?.Message}");
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.UnknownError, ex3);
			}
		}
		return result;
	}

	public bool HasSaveMetaData(int slotNumber)
	{
		string saveDirectory = GetSaveDirectory(slotNumber);
		string text = "\\gamestate_data.xml";
		if (!Directory.Exists(saveDirectory))
		{
			return false;
		}
		return File.Exists(saveDirectory + text);
	}

	public void GetAllExistingSaveSlots(Action<List<int>> onListReady = null)
	{
		List<int> list = new List<int>();
		string saveSlotsDirectory = GetSaveSlotsDirectory();
		string searchPattern = SaveSlotFolderPrefix + "*";
		try
		{
			string[] directories = Directory.GetDirectories(saveSlotsDirectory, searchPattern, SearchOption.TopDirectoryOnly);
			string[] separator = new string[1] { SaveSlotFolderPrefix };
			string[] array = directories;
			foreach (string text in array)
			{
				string[] array2 = text.Split(separator, StringSplitOptions.None);
				int result;
				if (array2.Length == 0)
				{
					Debug.LogError("Unexpected results in save slot lookup algorithm (offender path=" + text + ")");
				}
				else if (int.TryParse(array2[^1], out result))
				{
					list.Add(result);
				}
				else
				{
					Debug.LogError("Unexpected results in save slot lookup algorithm (offender path=" + text + ")");
				}
			}
		}
		catch (PathTooLongException ex)
		{
			_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.PathTooLongException, ex);
			Debug.LogError("Error getting existing save slots at " + saveSlotsDirectory + ".  Exception: " + ex.Message + "\n" + ex.InnerException?.Message);
		}
		catch (IOException ex2)
		{
			Debug.LogError("Error getting existing save slots at " + saveSlotsDirectory + ".  Exception: " + ex2.Message + "\n" + ex2.InnerException?.Message);
			_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.IOException, ex2);
		}
		catch (Exception ex3)
		{
			Debug.LogError("Error getting existing save slots at " + saveSlotsDirectory + ".  Exception: " + ex3.Message + "\n" + ex3.InnerException?.Message);
			_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.UnknownError, ex3);
		}
		onListReady?.Invoke(list);
	}

	public void ClearAllSaveData(Action<bool> onClearComplete = null)
	{
		string saveSlotsDirectory = GetSaveSlotsDirectory();
		string searchPattern = "SaveSlot*";
		try
		{
			string[] directories = Directory.GetDirectories(saveSlotsDirectory, searchPattern, SearchOption.TopDirectoryOnly);
			for (int i = 0; i < directories.Length; i++)
			{
				Debug.Log("Deleting folder " + directories[i]);
				Directory.Delete(directories[i], recursive: true);
			}
		}
		catch
		{
			Debug.LogError("Exception happened while running ClearAllSaveData ");
		}
		onClearComplete?.Invoke(obj: true);
	}

	public void ClearSaveData(int slotNumber, Action<bool> onClearComplete = null)
	{
		bool obj = false;
		string saveDirectory = GetSaveDirectory(slotNumber);
		string searchPattern = "*" + _baseFilename;
		string path = GetSaveDirectory(slotNumber) + _thumbnailFilename;
		if (!Directory.Exists(saveDirectory))
		{
			onClearComplete?.Invoke(obj: false);
			return;
		}
		Debug.Log("Deleting save slot #" + slotNumber);
		try
		{
			string[] files = Directory.GetFiles(saveDirectory, searchPattern, SearchOption.TopDirectoryOnly);
			for (int i = 0; i < files.Length; i++)
			{
				File.Delete(files[i]);
			}
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			Directory.Delete(saveDirectory);
			obj = true;
		}
		catch (Exception ex)
		{
			Debug.LogError("Exception when trying to delete save slot #" + slotNumber + " (" + ex.Message + ")");
		}
		onClearComplete?.Invoke(obj);
	}

	private void SaveScreenShot(string saveDirectory)
	{
		Texture2D texture2D = null;
		CameraController cameraController = UnityEngine.Object.FindObjectOfType<CameraController>();
		texture2D = ((!(cameraController != null)) ? Camera.main.GetScreenCapture() : cameraController.GetScreenCapture());
		if (texture2D != null)
		{
			try
			{
				byte[] bytes = texture2D.EncodeToPNG();
				File.WriteAllBytes(saveDirectory + _thumbnailFilename, bytes);
			}
			catch (PathTooLongException ex)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.PathTooLongException, ex);
				Debug.LogError("Something went wrong when trying to save thumbnail at \"" + saveDirectory + "\". Exception:" + ex.Message + " (inner:" + ((ex.InnerException != null) ? ex.InnerException.Message : "null") + ")");
			}
			catch (DirectoryNotFoundException ex2)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.DirectoryNotFoundException, ex2);
				Debug.LogError("Something went wrong when trying to save thumbnail at \"" + saveDirectory + "\". Exception:" + ex2.Message + " (inner:" + ((ex2.InnerException != null) ? ex2.InnerException.Message : "null") + ")");
			}
			catch (IOException ex3)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.IOException, ex3);
				Debug.LogError("Something went wrong when trying to save thumbnail at \"" + saveDirectory + "\". Exception:" + ex3.Message + " (inner:" + ((ex3.InnerException != null) ? ex3.InnerException.Message : "null") + ")");
			}
			catch (UnauthorizedAccessException ex4)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.UnauthorizedAccessException, ex4);
				Debug.LogError("Something went wrong when trying to save thumbnail at \"" + saveDirectory + "\". Exception:" + ex4.Message + " (inner:" + ((ex4.InnerException != null) ? ex4.InnerException.Message : "null") + ")");
			}
			catch (SecurityException ex5)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.SecurityException, ex5);
				Debug.LogError("Something went wrong when trying to save thumbnail at \"" + saveDirectory + "\". Exception:" + ex5.Message + " (inner:" + ((ex5.InnerException != null) ? ex5.InnerException.Message : "null") + ")");
			}
			catch (Exception ex6)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.UnknownError, ex6);
				Debug.LogError("Something went wrong when trying to save thumbnail at \"" + saveDirectory + "\". Exception:" + ex6.Message + " (inner:" + ((ex6.InnerException != null) ? ex6.InnerException.Message : "null") + ")");
			}
		}
	}

	public void LoadThumbnailForSaveSlot(int slotNumber, Action<Texture2D> onThumbnailReady = null)
	{
		Texture2D texture2D = null;
		string path = GetSaveDirectory(slotNumber) + _thumbnailFilename;
		if (File.Exists(path))
		{
			try
			{
				byte[] data = File.ReadAllBytes(path);
				texture2D = new Texture2D(2, 2);
				texture2D.LoadImage(data);
			}
			catch (PathTooLongException ex)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.PathTooLongException, ex);
				Debug.LogError(string.Format("Something went wrong when trying to read thumbnail for save slot {0}. Exception:{1} (inner:{2})", slotNumber, ex.Message, (ex.InnerException != null) ? ex.InnerException.Message : "null"));
			}
			catch (DirectoryNotFoundException ex2)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.DirectoryNotFoundException, ex2);
				Debug.LogError(string.Format("Something went wrong when trying to read thumbnail for save slot {0}. Exception:{1} (inner:{2})", slotNumber, ex2.Message, (ex2.InnerException != null) ? ex2.InnerException.Message : "null"));
			}
			catch (IOException ex3)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.IOException, ex3);
				Debug.LogError(string.Format("Something went wrong when trying to read thumbnail for save slot {0}. Exception:{1} (inner:{2})", slotNumber, ex3.Message, (ex3.InnerException != null) ? ex3.InnerException.Message : "null"));
			}
			catch (UnauthorizedAccessException ex4)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.UnauthorizedAccessException, ex4);
				Debug.LogError(string.Format("Something went wrong when trying to read thumbnail for save slot {0}. Exception:{1} (inner:{2})", slotNumber, ex4.Message, (ex4.InnerException != null) ? ex4.InnerException.Message : "null"));
			}
			catch (SecurityException ex5)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.SecurityException, ex5);
				Debug.LogError(string.Format("Something went wrong when trying to read thumbnail for save slot {0}. Exception:{1} (inner:{2})", slotNumber, ex5.Message, (ex5.InnerException != null) ? ex5.InnerException.Message : "null"));
			}
			catch (Exception ex6)
			{
				_errorPopup.DisplayError(UIModalPopup.ErrorPopupType.UnknownError, ex6);
				Debug.LogError(string.Format("Something went wrong when trying to read thumbnail for save slot {0}. Exception:{1} (inner:{2})", slotNumber, ex6.Message, (ex6.InnerException != null) ? ex6.InnerException.Message : "null"));
			}
		}
		onThumbnailReady?.Invoke(texture2D);
	}

	private string GetSaveSlotsDirectory()
	{
		IGameData.GameDataLocation saveSlotLocation = _saveSlotLocation;
		if (saveSlotLocation != IGameData.GameDataLocation.PersistentDataPath && saveSlotLocation == IGameData.GameDataLocation.ResourcesFolder)
		{
			return Application.dataPath + "/Resources/InternalSaveSlots";
		}
		return Application.persistentDataPath;
	}

	public string GetSaveDirectory(int slotNumber)
	{
		return GetSaveSlotsDirectory() + $"\\{SaveSlotFolderPrefix}{slotNumber}";
	}

	public void GetLowestAvailableSlotNumber(Action<int> onSlotNumberFound = null)
	{
		int num = -1;
		for (int i = 0; i < MaximumNumberOfRegularSaveSlots; i++)
		{
			if (!HasSaveData(i))
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			Debug.LogWarning("User already has 50 save slots");
		}
		onSlotNumberFound?.Invoke(num);
	}

	public void GetNextAvailableSlotNumber(int previousSlot, Action<int> onNextSlotFound)
	{
		for (int i = previousSlot; i < MaximumNumberOfRegularSaveSlots; i++)
		{
			if (!HasSaveMetaData(i))
			{
				onNextSlotFound(i);
				return;
			}
		}
		GetLowestAvailableSlotNumber(onNextSlotFound);
	}

	public void GetRemainingSaveFileSpace(Action<long> onFileSpaceObtained = null)
	{
		long obj = 0L;
		try
		{
			obj = GetSaveSlotsDriveInfo().AvailableFreeSpace;
		}
		catch (IOException ex)
		{
			Debug.LogError("IOException during GetRemainingSaveFileSpace: " + ex.Message + " (Inner: " + ((ex.InnerException != null) ? ex.InnerException.Message : "null") + ") Stack:" + ex.StackTrace);
		}
		catch (UnauthorizedAccessException ex2)
		{
			Debug.LogError("UnauthorizedAccessException during GetRemainingSaveFileSpace: " + ex2.Message + " (Inner: " + ((ex2.InnerException != null) ? ex2.InnerException.Message : "null") + ") Stack:" + ex2.StackTrace);
		}
		catch (Exception ex3)
		{
			Debug.LogError("Exception during GetRemainingSaveFileSpace: " + ex3.Message + " (Inner: " + ((ex3.InnerException != null) ? ex3.InnerException.Message : "null") + ") Stack:" + ex3.StackTrace);
		}
		onFileSpaceObtained?.Invoke(obj);
	}

	public void GetMaximumSaveFileSpace(Action<long> onMaxFileSpaceObtained = null)
	{
		long obj = 0L;
		try
		{
			obj = GetSaveSlotsDriveInfo().TotalSize;
		}
		catch (DriveNotFoundException ex)
		{
			Debug.LogError("UnauthorizedAccessException during GetRemainingSaveFileSpace: " + ex.Message + " (Inner: " + ((ex.InnerException != null) ? ex.InnerException.Message : "null") + ") Stack:" + ex.StackTrace);
		}
		catch (IOException ex2)
		{
			Debug.LogError("IOException during GetRemainingSaveFileSpace: " + ex2.Message + " (Inner: " + ((ex2.InnerException != null) ? ex2.InnerException.Message : "null") + ") Stack:" + ex2.StackTrace);
		}
		catch (UnauthorizedAccessException ex3)
		{
			Debug.LogError("UnauthorizedAccessException during GetRemainingSaveFileSpace: " + ex3.Message + " (Inner: " + ((ex3.InnerException != null) ? ex3.InnerException.Message : "null") + ") Stack:" + ex3.StackTrace);
		}
		catch (Exception ex4)
		{
			Debug.LogError("Exception during GetRemainingSaveFileSpace: " + ex4.Message + " (Inner: " + ((ex4.InnerException != null) ? ex4.InnerException.Message : "null") + ") Stack:" + ex4.StackTrace);
		}
		onMaxFileSpaceObtained?.Invoke(obj);
	}

	private DriveInfo GetSaveSlotsDriveInfo()
	{
		DriveInfo result = null;
		string value = GetSaveSlotsDirectory().Substring(0, 1);
		DriveInfo[] drives = DriveInfo.GetDrives();
		foreach (DriveInfo driveInfo in drives)
		{
			if (driveInfo.IsReady && driveInfo.Name.StartsWith(value))
			{
				result = driveInfo;
			}
		}
		return result;
	}

	public void HasCustomControlsData(Action<bool> onCheckComplete = null)
	{
		string filePath = GetFilePath(GetControlsSaveFilename(), Application.persistentDataPath + "/", "");
		onCheckComplete?.Invoke(XMLFileExists(filePath));
	}

	public void SaveCustomControlMappings(PlayerCustomControlsSaveData controlSaveData)
	{
		SaveXMLFile(GetFilePath(GetControlsSaveFilename(), Application.persistentDataPath + "/", ""), controlSaveData);
	}

	public void LoadCustomControlMappings(Action<PlayerCustomControlsSaveData> onLoadComplete)
	{
		string filePath = GetFilePath(GetControlsSaveFilename(), Application.persistentDataPath + "/", "");
		if (XMLFileExists(filePath))
		{
			PlayerCustomControlsSaveData obj = LoadXMLFile<PlayerCustomControlsSaveData>(filePath);
			onLoadComplete(obj);
		}
		else
		{
			onLoadComplete(null);
		}
	}

	public void SaveSpeedrunTimes(SpeedrunTimerData timerData, Action<bool> onSaveComplete)
	{
		string personalBestsFileName = _speedrunSettings.GetPersonalBestsFileName();
		string saveSlotsDirectory = GetSaveSlotsDirectory();
		string filePath = GetFilePath(personalBestsFileName, saveSlotsDirectory, NO_FILE_PREFIX);
		XmlSerializer serializer = new XmlSerializer(typeof(SpeedrunTimerData));
		bool obj = WriteFile(filePath, serializer, timerData);
		SaveGoldSplits(timerData);
		onSaveComplete?.Invoke(obj);
	}

	private void SaveGoldSplits(SpeedrunTimerData newTimerData)
	{
		LoadGoldSplitTimes((SpeedrunTimerData existingGoldSplits) =>
		{
			SpeedrunTimerData speedrunTimerData = new SpeedrunTimerData();
			if (existingGoldSplits != null && existingGoldSplits.times != null)
			{
				speedrunTimerData.times = new float[existingGoldSplits.times.Length];
				for (int i = 0; i < existingGoldSplits.times.Length; i++)
				{
					speedrunTimerData.times[i] = existingGoldSplits.times[i];
				}
			}
			else
			{
				speedrunTimerData.times = new float[newTimerData.times.Length];
				for (int j = 0; j < newTimerData.times.Length; j++)
				{
					speedrunTimerData.times[j] = newTimerData.times[j];
				}
			}
			if (speedrunTimerData.times.Length != newTimerData.times.Length)
			{
				float[] array = new float[newTimerData.times.Length];
				for (int k = 0; k < newTimerData.times.Length; k++)
				{
					if (k < speedrunTimerData.times.Length)
					{
						array[k] = speedrunTimerData.times[k];
					}
					else
					{
						array[k] = newTimerData.times[k];
					}
				}
				speedrunTimerData.times = array;
			}
			for (int l = 0; l < newTimerData.times.Length; l++)
			{
				if (newTimerData.times[l] > 0f && (speedrunTimerData.times[l] <= 0f || newTimerData.times[l] < speedrunTimerData.times[l]))
				{
					speedrunTimerData.times[l] = newTimerData.times[l];
				}
			}
			string goldSplitsFileName = _speedrunSettings.GetGoldSplitsFileName();
			string saveSlotsDirectory = GetSaveSlotsDirectory();
			string filePath = GetFilePath(goldSplitsFileName, saveSlotsDirectory, NO_FILE_PREFIX);
			XmlSerializer serializer = new XmlSerializer(typeof(SpeedrunTimerData));
			if (WriteFile(filePath, serializer, speedrunTimerData))
			{
				Debug.Log("Gold splits updated successfully.");
			}
			else
			{
				Debug.LogError("Failed to save gold best splits.");
			}
		});
	}

	public void LoadGoldSplitTimes(Action<SpeedrunTimerData> onLoadComplete)
	{
		SpeedrunTimerData obj = null;
		string goldSplitsFileName = _speedrunSettings.GetGoldSplitsFileName();
		string saveSlotsDirectory = GetSaveSlotsDirectory();
		string filePath = GetFilePath(goldSplitsFileName, saveSlotsDirectory, NO_FILE_PREFIX);
		if (XMLFileExists(filePath))
		{
			using TextReader textReader = ReadFile(filePath);
			if (textReader != null)
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(SpeedrunTimerData));
				try
				{
					obj = (SpeedrunTimerData)xmlSerializer.Deserialize(textReader);
				}
				catch (InvalidOperationException ex)
				{
					Debug.LogError("caught InvalidOperationException: " + ex.InnerException.Message);
				}
			}
		}
		onLoadComplete?.Invoke(obj);
	}

	public void LoadSpeedrunTimes(Action<SpeedrunTimerData> onLoadComplete)
	{
		SpeedrunTimerData obj = null;
		string personalBestsFileName = _speedrunSettings.GetPersonalBestsFileName();
		string saveSlotsDirectory = GetSaveSlotsDirectory();
		string filePath = GetFilePath(personalBestsFileName, saveSlotsDirectory, NO_FILE_PREFIX);
		if (XMLFileExists(filePath))
		{
			using TextReader textReader = ReadFile(filePath);
			if (textReader != null)
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(SpeedrunTimerData));
				try
				{
					obj = (SpeedrunTimerData)xmlSerializer.Deserialize(textReader);
				}
				catch (InvalidOperationException ex)
				{
					Debug.LogError("caught InvalidOperationException: " + ex.InnerException.Message);
				}
			}
		}
		onLoadComplete?.Invoke(obj);
	}

	private string GetControlsSaveFilename()
	{
		string text = _customControlsSaveFilename;
		if (text.IndexOf(".xml", StringComparison.OrdinalIgnoreCase) < 0)
		{
			text += ".xml";
		}
		return text;
	}
}
