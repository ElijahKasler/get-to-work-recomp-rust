using System;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Data;

public interface IGameData
{
	public enum GameDataLocation
	{
		PersistentDataPath = 0,
		ResourcesFolder = 1,
		UserAccount = 2
	}

	GameDataLocation CurrentSaveLocation { get; }

	int MaximumSaveSlots { get; }

	void GetLowestAvailableSlotNumber(Action<int> onSlotNumberFound = null);

	void GetNextAvailableSlotNumber(int previousSlot, Action<int> onNextSlotFound);

	void HasAnySaveData(Action<bool> onCheckComplete = null);

	void GetAllExistingSaveSlots(Action<List<int>> onListReady = null);

	void GetRemainingSaveFileSpace(Action<long> onFileSpaceObtained = null);

	void GetMaximumSaveFileSpace(Action<long> onMaxFileSpaceObtained = null);

	void SaveGameMetaData(int saveSlot, GameStateSaveData saveData, Action<bool> onSaveComplete, bool async = true);

	void SaveGameData(int saveSlot, bool createBackup, Action<bool> onSaveComplete = null, bool async = true);

	void LoadGameMetaData(int saveSlot, Action<GameStateSaveData> onLoadComplete);

	void LoadThumbnailForSaveSlot(int slotNumber, Action<Texture2D> onThumbnailReady = null);

	void LoadGameData(int saveSlot, Action<bool> onLoadComplete = null);

	void DuplicateGameData(int sourceSaveSlot, int destinationSaveSlot, Action<bool> onDuplicationComplete);

	void UpgradeGameData(int saveSlot, string targetSaveVersion, Action<bool> onUpgradeComplete);

	void HasSaveData(int slotNumber, Action<bool> onCheckComplete = null);

	void ClearAllSaveData(Action<bool> onClearComplete = null);

	void ClearSaveData(int slotNumber, Action<bool> onClearComplete = null);

	void HasCustomControlsData(Action<bool> onCheckComplete = null);

	void SaveCustomControlMappings(PlayerCustomControlsSaveData controlSaveData);

	void LoadCustomControlMappings(Action<PlayerCustomControlsSaveData> onLoadComplete);

	void SaveSpeedrunTimes(SpeedrunTimerData timerData, Action<bool> onSaveComplete);

	void LoadSpeedrunTimes(Action<SpeedrunTimerData> onLoadComplete);

	void LoadGoldSplitTimes(Action<SpeedrunTimerData> onLoadComplete);
}
