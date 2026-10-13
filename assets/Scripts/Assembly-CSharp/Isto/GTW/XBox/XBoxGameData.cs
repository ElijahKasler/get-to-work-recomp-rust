using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Isto.Core.Cameras;
using Isto.Core.Data;
using Isto.Core.Platforms.Xbox;
using UnityEngine;

namespace Isto.GTW.XBox;

public class XBoxGameData : MonoBehaviour, IGameData, IDataLoadCompleteHandler
{
	[SerializeField]
	private bool _allowScreenshots = true;

	[SerializeField]
	private bool _allowValidation = true;

	public static readonly long MaximumSaveSpaceInBytes = 268435456L;

	public static readonly int MaximumNumberOfRegularSaveSlots = 50;

	public static readonly string SaveSlotContainerPrefix = "SaveSlot";

	public static readonly string CustomControlsMappingSaveContainer = "CustomControls";

	public static readonly string CustomControlsBlobName = "CustomControlsData";

	public static readonly string CustomGameDataContainer = "CustomGameData";

	private string _thumbnailBlobName = "thumb.png";

	private bool _anAsyncOperationIsActive;

	private IGameData.GameDataLocation _saveSlotLocation = IGameData.GameDataLocation.UserAccount;

	private bool _initialized;

	private DataManager[] _managers;

	private XmlSerializer[] _serializers;

	private Coroutine hasSaveDataCR;

	public IGameData.GameDataLocation CurrentSaveLocation => _saveSlotLocation;

	public int MaximumSaveSlots => MaximumNumberOfRegularSaveSlots;

	public void OnDataLoadComplete()
	{
		Initialize();
	}

	public string GetContainerName(int slotNumber)
	{
		return $"{SaveSlotContainerPrefix}{slotNumber}";
	}

	private int GetSaveSlotNumberFromName(string containerName)
	{
		if (!containerName.StartsWith(SaveSlotContainerPrefix) || containerName.Length <= SaveSlotContainerPrefix.Length)
		{
			return -1;
		}
		return int.Parse(containerName.Substring(SaveSlotContainerPrefix.Length));
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

	public void SaveGameData(int saveSlot, bool createBackup, Action<bool> onSaveComplete = null, bool async = true)
	{
		string containerName = GetContainerName(saveSlot);
		SaveGameData(containerName, onSaveComplete);
	}

	public void SaveGameMetaData(int saveSlot, GameStateSaveData saveData, Action<bool> onSaveComplete, bool async = true)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameStateSaveData));
		StringBuilder stringBuilder = new StringBuilder();
		using (StringWriter textWriter = new StringWriter(stringBuilder))
		{
			xmlSerializer.Serialize(textWriter, saveData);
		}
		string s = stringBuilder.ToString();
		GetContainerName(saveSlot);
		new List<GDK_XGameSaveManager.Blob>().Add(new GDK_XGameSaveManager.Blob
		{
			blobName = "gamestate",
			dataToSave = Encoding.UTF8.GetBytes(s)
		});
	}

	public void LoadGameData(int saveSlot, Action<bool> onLoadComplete = null)
	{
		string containerName = GetContainerName(saveSlot);
		LoadGameData(containerName, onLoadComplete);
	}

	public void LoadGameMetaData(int saveSlot, Action<GameStateSaveData> onLoadComplete)
	{
		Debug.Log("loading metadata...");
		GetContainerName(saveSlot);
		string text = "gamestate";
		(new string[1])[0] = text;
	}

	private void SaveGameData(string saveContainer, Action<bool> onSaveComplete)
	{
		Initialize();
		List<GDK_XGameSaveManager.Blob> list = new List<GDK_XGameSaveManager.Blob>();
		string[] array = new string[_managers.Length];
		object[] array2 = new object[_managers.Length];
		string[] array3 = new string[_managers.Length];
		for (int i = 0; i < _managers.Length; i++)
		{
			array[i] = _managers[i].BlobName;
			_managers[i].Save(out var saveData);
			array2[i] = saveData;
			string text;
			using (StringWriter stringWriter = new StringWriter())
			{
				_serializers[i].Serialize(stringWriter, saveData);
				text = stringWriter.ToString();
			}
			array3[i] = text;
			list.Add(new GDK_XGameSaveManager.Blob
			{
				blobName = _managers[i].BlobName,
				dataToSave = Encoding.UTF8.GetBytes(text)
			});
		}
		if (_allowScreenshots)
		{
			SaveScreenShot(saveContainer, out var data);
			if (data != null)
			{
				list.Add(new GDK_XGameSaveManager.Blob
				{
					blobName = _thumbnailBlobName,
					dataToSave = data
				});
			}
		}
	}

	private void LoadGameData(string saveContainer, Action<bool> onLoadComplete)
	{
		Initialize();
		string[] array = new string[_managers.Length];
		for (int i = 0; i < _managers.Length; i++)
		{
			array[i] = _managers[i].BlobName;
		}
	}

	public void DuplicateGameData(int sourceSaveSlot, int destinationSaveSlot, Action<bool> onDuplicationComplete)
	{
		Debug.Log("DuplicateGameData start");
		GetContainerName(sourceSaveSlot);
		GetContainerName(destinationSaveSlot);
		GameObject gameObject = new GameObject("Managers");
		List<DataManager> list = new List<DataManager>();
		list.Add(gameObject.AddComponent<PlayerDataManager>());
		list.Add(gameObject.AddComponent<GameStateDataManager>());
		string[] array = new string[list.Count];
		for (int i = 0; i < list.Count; i++)
		{
			array[i] = list[i].BlobName;
		}
	}

	private void DuplicateSaveDataInternal(string sourceContainer, string destinationContainer, string[] blobNames, Action<bool> onDuplicationComplete)
	{
	}

	public void UpgradeGameData(int saveSlot, string targetSaveVersion, Action<bool> onUpgradeComplete)
	{
		Debug.Log("UpgradeGameData start");
		GetContainerName(saveSlot);
		DataManager[] array = Resources.FindObjectsOfTypeAll<DataManager>();
		string[] array2 = new string[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i].BlobName;
		}
	}

	public void HasAnySaveData(Action<bool> onCheckComplete = null)
	{
	}

	public void HasSaveData(int slotNumber, Action<bool> onCheckComplete = null)
	{
		if (slotNumber > MaximumNumberOfRegularSaveSlots)
		{
			onCheckComplete?.Invoke(obj: true);
		}
		else if (slotNumber < 0)
		{
			onCheckComplete?.Invoke(obj: false);
		}
		else
		{
			GetContainerName(slotNumber);
		}
	}

	public void GetAllExistingSaveSlots(Action<List<int>> onListReady = null)
	{
	}

	public void ClearAllSaveData(Action<bool> onClearComplete = null)
	{
	}

	public void ClearSaveData(int slotNumber, Action<bool> onClearComplete = null)
	{
		GetContainerName(slotNumber);
	}

	private void SaveScreenShot(string saveDirectory, out byte[] data)
	{
		data = null;
		CameraController cameraController = UnityEngine.Object.FindObjectOfType<CameraController>();
		if (cameraController != null)
		{
			Texture2D screenCapture = cameraController.GetScreenCapture();
			if (screenCapture != null)
			{
				data = screenCapture.EncodeToPNG();
			}
			return;
		}
		UnityEngine.Camera main = UnityEngine.Camera.main;
		if (main != null)
		{
			Texture2D screenCapture2 = main.GetScreenCapture();
			if (screenCapture2 != null)
			{
				data = screenCapture2.EncodeToPNG();
			}
		}
	}

	public void LoadThumbnailForSaveSlot(int slotNumber, Action<Texture2D> onThumbnailReady = null)
	{
		if (slotNumber >= 0)
		{
			GetContainerName(slotNumber);
			string thumbnailBlobName = _thumbnailBlobName;
			(new string[1])[0] = thumbnailBlobName;
		}
	}

	public void GetLowestAvailableSlotNumber(Action<int> onSlotNumberFound = null)
	{
		GetAllExistingSaveSlots((List<int> list) =>
		{
			int lowestAvailableSlotNumber = GetLowestAvailableSlotNumber(list);
			onSlotNumberFound?.Invoke(lowestAvailableSlotNumber);
		});
	}

	private int GetLowestAvailableSlotNumber(List<int> existingSlots)
	{
		int result = -1;
		if (existingSlots.Count < MaximumNumberOfRegularSaveSlots)
		{
			for (int i = 0; i < MaximumNumberOfRegularSaveSlots; i++)
			{
				if (!existingSlots.Contains(i))
				{
					result = i;
					Debug.Log($"GetLowestAvailableSlotNumber: lowest available slot number is {i} ");
					break;
				}
			}
		}
		else
		{
			Debug.LogWarning("GetLowestAvailableSlotNumber: too many slots already!");
		}
		return result;
	}

	public void GetNextAvailableSlotNumber(int previousSlot, Action<int> onNextSlotFound)
	{
		GetAllExistingSaveSlots((List<int> list) =>
		{
			int num = -1;
			for (int i = previousSlot; i < MaximumNumberOfRegularSaveSlots; i++)
			{
				if (!list.Contains(i))
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				num = GetLowestAvailableSlotNumber(list);
			}
			onNextSlotFound?.Invoke(num);
		});
	}

	public void GetRemainingSaveFileSpace(Action<long> onFileSpaceObtained = null)
	{
	}

	public void GetMaximumSaveFileSpace(Action<long> onMaxFileSpaceObtained = null)
	{
		onMaxFileSpaceObtained?.Invoke(MaximumSaveSpaceInBytes);
	}

	public void HasCustomControlsData(Action<bool> onCheckComplete = null)
	{
	}

	public void SaveCustomControlMappings(PlayerCustomControlsSaveData controlSaveData)
	{
		List<GDK_XGameSaveManager.Blob> list = new List<GDK_XGameSaveManager.Blob>();
		XmlSerializer xMLSerializer = DataManager.GetXMLSerializer(controlSaveData);
		string s;
		using (StringWriter stringWriter = new StringWriter())
		{
			xMLSerializer.Serialize(stringWriter, controlSaveData);
			s = stringWriter.ToString();
		}
		list.Add(new GDK_XGameSaveManager.Blob
		{
			blobName = CustomControlsBlobName,
			dataToSave = Encoding.UTF8.GetBytes(s)
		});
	}

	public void LoadCustomControlMappings(Action<PlayerCustomControlsSaveData> onLoadComplete)
	{
		(new string[1])[0] = CustomControlsBlobName;
	}

	public void SaveSpeedrunTimes(SpeedrunTimerData timerData, Action<bool> onSaveComplete)
	{
		new List<GDK_XGameSaveManager.Blob>();
		XmlSerializer xMLSerializer = DataManager.GetXMLSerializer(timerData);
		using StringWriter stringWriter = new StringWriter();
		xMLSerializer.Serialize(stringWriter, timerData);
		stringWriter.ToString();
	}

	private void SaveGoldSplits(SpeedrunTimerData newTimerData)
	{
		Debug.LogWarning("Gold Splits cannot be saved on xbox.");
	}

	public void LoadSpeedrunTimes(Action<SpeedrunTimerData> onLoadComplete)
	{
	}

	public void LoadGoldSplitTimes(Action<SpeedrunTimerData> onLoadComplete)
	{
		Debug.LogWarning("Gold Splits cannot be saved or loaded on xbox.");
		onLoadComplete?.Invoke(null);
	}
}
