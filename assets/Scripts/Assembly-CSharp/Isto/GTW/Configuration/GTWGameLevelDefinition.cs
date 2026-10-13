using System;
using I2.Loc;
using Isto.Core.Configuration;
using Isto.Core.Localization;
using UnityEngine;

namespace Isto.GTW.Configuration;

[CreateAssetMenu(fileName = "Scriptables/New GTW Game Mode Definition", menuName = "Scriptables/New GTW Game Mode Definition")]
public class GTWGameLevelDefinition : ScriptableObject
{
	[Header("Player Facing")]
	[SearchableLocalizedString]
	public LocalizedString LevelName;

	[Tooltip("In case the name of the level has not yet been localized, fallback to this")]
	public string fallbackLevelName;

	public int LevelNumber;

	[NonSerialized]
	public int Attempts;

	[NonSerialized]
	public string TotalTimeInLevel = "--";

	[NonSerialized]
	public string FastestCompletedTime = "--";

	[NonSerialized]
	public bool IsCompleted;

	[NonSerialized]
	public bool IsUnlocked;

	public Sprite LevelImage;

	[Space]
	public bool loadPlayerPositionFromSave;

	public bool saveOnQuit;

	[Header("Internal")]
	public GameModeDefinition gameMode;

	[Tooltip("Checkpoints start at 0, level numbers start at 1")]
	public int CheckpointNumber;

	public string UniqueID => gameMode.internalName + "_" + LevelNumber;

	public string UniqueIDAttempts => UniqueID + "_ATTEMPTS";

	public string UniqueIDCompleted => UniqueID + "_COMPLETED";

	public string UniqueIDBest => UniqueID + "_BEST";

	public string UniqueIDTotal => UniqueID + "_TOTAL";

	public void SetupSO(int attempts, float bestValue, float totalValue, bool isCompleted)
	{
		Attempts = attempts;
		IsCompleted = isCompleted;
		if (LevelNumber <= 1)
		{
			IsUnlocked = true;
		}
		TotalTimeInLevel = ((totalValue > 0f) ? totalValue.ToString("0.00") : "--");
		if (bestValue > 0f)
		{
			FastestCompletedTime = bestValue.ToString("0.00");
		}
		else
		{
			FastestCompletedTime = "--";
		}
	}
}
