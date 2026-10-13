using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Isto.Core.Data;

[Serializable]
[XmlRoot("GameStateData")]
public class GameStateSaveData
{
	public bool isAutoSave;

	public string saveSlotName;

	public string gameModeName;

	public string gameVersion;

	public string internalBuildVersion;

	public float totalGameTimeSeconds;

	public DateTime saveDate;

	public List<DateTime> autoSaveDates;

	public ThemeManagerData themeData;

	public override bool Equals(object obj)
	{
		if (!(obj is GameStateSaveData gameStateSaveData))
		{
			return false;
		}
		if (isAutoSave != gameStateSaveData.isAutoSave)
		{
			return false;
		}
		if (!saveSlotName.IsEqualWithNullsAsEmpty(gameStateSaveData.saveSlotName))
		{
			return false;
		}
		if (!gameModeName.IsEqualWithNullsAsEmpty(gameStateSaveData.gameModeName))
		{
			return false;
		}
		if (!gameVersion.IsEqualWithNullsAsEmpty(gameStateSaveData.gameVersion))
		{
			return false;
		}
		if (!totalGameTimeSeconds.Approx(gameStateSaveData.totalGameTimeSeconds, 1f))
		{
			return false;
		}
		if (saveDate != gameStateSaveData.saveDate)
		{
			return false;
		}
		return themeData.Equals(gameStateSaveData.themeData);
	}

	public override int GetHashCode()
	{
		return (isAutoSave, saveSlotName, gameModeName, gameVersion, totalGameTimeSeconds, saveDate, themeData).GetHashCode();
	}
}
