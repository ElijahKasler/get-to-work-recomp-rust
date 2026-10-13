using System;
using System.Collections.Generic;
using System.Linq;
using Isto.Core.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Isto.Core.Speedrun;

[CreateAssetMenu(fileName = "SpeedrunSettings", menuName = "Scriptables/SpeedrunSettings")]
public class SpeedrunSettings : ScriptableObject
{
	public class SpeedrunTimerSectionEnum : Int32Enum<SpeedrunTimerSectionEnum>
	{
		public static readonly SpeedrunTimerSectionEnum EMPTY = new SpeedrunTimerSectionEnum(0, "EMPTY");

		public static readonly SpeedrunTimerSectionEnum MAIN_TIMER = new SpeedrunTimerSectionEnum(1, "MAIN_TIMER");

		public static readonly SpeedrunTimerSectionEnum RUN_DETAILS = new SpeedrunTimerSectionEnum(2, "RUN_DETAILS");

		public static readonly SpeedrunTimerSectionEnum CHAPTER_INFO = new SpeedrunTimerSectionEnum(4, "CHAPTER_INFO");

		public static readonly SpeedrunTimerSectionEnum FULL_DISPLAY = new SpeedrunTimerSectionEnum(8, "FULL_DISPLAY");

		public SpeedrunTimerSectionEnum(int value, string name)
			: base(value, name)
		{
		}
	}

	public enum SpeedrunFullSectionListTypeEnum
	{
		ListOfAbsoluteTimes = 0,
		ListOfRelativeTimes = 1,
		ListOfPersonalBestTimes = 2,
		ListOfDiffsFromPersonalBest = 3
	}

	public enum SpeedrunPersonalBestsSaveLocationEnum
	{
		DoNotSave = 0,
		SaveSlot = 1,
		LocalLow = 2
	}

	[Serializable]
	public class SpeedrunTimerSectionWrapper
	{
		[EnumDropdown(typeof(SpeedrunTimerSectionEnum))]
		public int timerSectionValue;
	}

	[Serializable]
	public class SpeedrunTimerConfig
	{
		public string internalName;

		public string setupNameLocKey;

		[Header("Sections - one of each max - reordering not supported yet")]
		public List<SpeedrunTimerSectionWrapper> timerSectionsToShow;

		[Header("Run Details options")]
		public bool showGameName;

		public bool showRunCategory;

		public bool showTotalPersonalBest;

		[Header("Chapter Details options")]
		public bool showCurrentChapterBestTime;

		[Header("Full Display options")]
		public SpeedrunFullSectionListTypeEnum segmentTimersType;

		public bool showChapterIcons;

		public bool showUpcomingChapters;

		public bool userCanScrollTimesList;

		public bool autoScrollTimesListOnSplitChange;

		public bool autoResizeTimesListPanel;

		[Tooltip("This makes the timer change color if the player's time becomes behind the Target time")]
		public bool showPBColorsInSegmentTime;

		[Tooltip("This adds a column to the left of the segment time to display the diff from your PB as you finish segments")]
		public bool showPersonalBestDeltas;

		public bool cumulativePersonalBestDeltas;

		[Tooltip("This adds a column to the right to display the PB times")]
		public bool showPersonalBestColumn;

		[Header("Bottom extras")]
		[Tooltip("This controls if a toggle button is shown at the bottom of the timer widget")]
		public bool showStyleToggleButton;

		[Tooltip("This controls if a save button is shown at the bottom of the timer widget")]
		public bool showPersonalBestSaveButton;

		public bool IsSectionShown(SpeedrunTimerSectionEnum section)
		{
			return timerSectionsToShow.Where((SpeedrunTimerSectionWrapper x) => x.timerSectionValue == section.Value).Any();
		}
	}

	[Serializable]
	public class PBStyleSettings
	{
		[Header("Warning - the 3 following settings are not implemented but they are often used in livesplit")]
		public Color belowPersonalBest;

		public bool flashTextWhenBelowPersonalBest;

		public Color belowPersonalBestFlashColor;

		[Space]
		public Color belowTarget;

		public Color exactTarget;

		public Color passedTarget;
	}

	[Serializable]
	public class PBLocKeys
	{
		[Header("Save Popup")]
		public string savePopupTitle;

		public string savePopupQuestion;

		public string savePopupInfo;

		[Header("Confirm Popup")]
		public string confirmPopupTitle;

		public string confirmPopupCloud;

		public string confirmPopupFile;

		public string confirmPopupFolder;

		[Header("Other")]
		public string chapterLabel;

		public string bestChapterTimeLabel;

		public string bestRunTimeLabel;
	}

	[Header("Timer UI Configuration")]
	[SerializeField]
	private string _gameName = "Atrio";

	[SerializeField]
	private string _emptyTimerDefaultText = "--:--:--";

	[Tooltip("This is optional. We will show the internal split names if the titles are not defined.")]
	[SerializeField]
	private string[] _chapterTitleLocKeys;

	[Tooltip("This is optional.")]
	[SerializeField]
	private Sprite[] _chapterSprites;

	[FormerlySerializedAs("_styleOptions")]
	[SerializeField]
	private SpeedrunTimerConfig[] _timerConfigs;

	[Header("Main Timer Configuration")]
	[SerializeField]
	private Color _normalText;

	[SerializeField]
	private Color _notReadyText;

	[Header("Personal Best Configuration")]
	[FormerlySerializedAs("_personalBestsSaving")]
	[SerializeField]
	private SpeedrunPersonalBestsSaveLocationEnum _personalBestsSavingLocation;

	[SerializeField]
	private string _personalBestsFileName = "best_split_times.txt";

	[SerializeField]
	private string _goldSplitsFileName = "gold_split_times.txt";

	[SerializeField]
	private PBStyleSettings _personalBestsStyleSettings;

	[SerializeField]
	private PBLocKeys _personalBestsLocKeys;

	[Header("Game Settings Menu Options")]
	[SerializeField]
	private bool _userCanTurnOnTimer;

	[SerializeField]
	private bool _userCanRelocate;

	[SerializeField]
	private bool _userCanResize;

	[SerializeField]
	private bool _userCanAdjustTransparency;

	[SerializeField]
	private bool _userCanChangeStyle;

	[SerializeField]
	private bool _userCanAssignStyleToggleButton;

	[Header("Default Settings")]
	[Tooltip("Not to be confused with the hidden option in the timer configs list. The timer can be turned on but hidden, to the user it's the same but your project might only support one.")]
	[SerializeField]
	private bool _timerIsOn;

	[FormerlySerializedAs("_speedrunTimerStyleSetupIndex")]
	[SerializeField]
	private int _timerConfigIndex;

	[SerializeField]
	[Range(0f, 1f)]
	private float _topToBottomOffset;

	[SerializeField]
	[Range(0f, 1f)]
	private float _leftToRightOffset = 1f;

	[SerializeField]
	[Range(0.25f, 2f)]
	private float _uiPanelSizeMultiplier = 1f;

	[SerializeField]
	[Range(0.1f, 1f)]
	private float _uiPanelAlpha = 1f;

	private const string COMPILED_ASSET_NAME = "SpeedrunSettings";

	public static readonly string ASSET_NAME = "SpeedrunSettings";

	public static readonly string MENU_ACTIVE_PLAYER_PREFS_KEY = "SpeedRunMenuSetting";

	public static readonly string CONFIG_PLAYER_PREFS_KEY = "SpeedRunMenuStyleSetting";

	public static readonly string HORIZONTAL_POS_PLAYER_PREFS_KEY = "SpeedRunHPositionSetting";

	public static readonly string VERTICAL_POS_PLAYER_PREFS_KEY = "SpeedRunVPositionSetting";

	private void OnValidate()
	{
		if (_personalBestsStyleSettings.flashTextWhenBelowPersonalBest)
		{
			_personalBestsStyleSettings.flashTextWhenBelowPersonalBest = false;
			Debug.LogError("Flashing Text For Personal Best Splits is not supported yet.");
		}
		if (_userCanResize)
		{
			_userCanResize = false;
			Debug.LogError("User Can Resize setting is not supported yet.");
		}
		if (_userCanAdjustTransparency)
		{
			_userCanAdjustTransparency = false;
			Debug.LogError("User Can Adjust Transparency setting is not supported yet.");
		}
		if (_userCanAssignStyleToggleButton)
		{
			_userCanAssignStyleToggleButton = false;
			Debug.LogError("User Can Assign Style Toggle Button setting is not supported yet.");
		}
		if (_personalBestsSavingLocation == SpeedrunPersonalBestsSaveLocationEnum.SaveSlot)
		{
			_personalBestsSavingLocation = SpeedrunPersonalBestsSaveLocationEnum.DoNotSave;
			Debug.LogError("Personal Bests Saved In Save Slot is not supported yet.");
		}
	}

	public bool GetDefaultTimerIsOnSetting()
	{
		return _timerIsOn;
	}

	public SpeedrunTimerConfig GetTimerConfig(int index)
	{
		return _timerConfigs[index];
	}

	public SpeedrunTimerConfig GetTimerConfig(string internalName)
	{
		SpeedrunTimerConfig result = null;
		for (int i = 0; i < _timerConfigs.Length; i++)
		{
			if (_timerConfigs[i].internalName == internalName)
			{
				result = _timerConfigs[i];
				break;
			}
		}
		return result;
	}

	public SpeedrunTimerConfig GetDefaultTimerConfig()
	{
		return GetTimerConfig(GetDefaultTimerConfigIndex());
	}

	public SpeedrunTimerConfig GetPlayerSelectedTimerConfig()
	{
		return GetTimerConfig(GetPlayerSelectedConfigIndex());
	}

	public int GetTimerConfigIndex(string locKey)
	{
		int result = -1;
		for (int i = 0; i < _timerConfigs.Length; i++)
		{
			if (_timerConfigs[i].setupNameLocKey == locKey || _timerConfigs[i].internalName == locKey)
			{
				result = i;
				break;
			}
		}
		return result;
	}

	public int GetDefaultTimerConfigIndex()
	{
		return _timerConfigIndex;
	}

	public int GetPlayerSelectedConfigIndex()
	{
		int num = PlayerPrefs.GetInt(CONFIG_PLAYER_PREFS_KEY, -1);
		if (num == -1)
		{
			int defaultTimerConfigIndex = GetDefaultTimerConfigIndex();
			PlayerPrefs.SetInt(CONFIG_PLAYER_PREFS_KEY, defaultTimerConfigIndex);
			num = defaultTimerConfigIndex;
		}
		return num;
	}

	public int GetTimerConfigsCount()
	{
		return _timerConfigs.Length;
	}

	public Color GetNormalTimerTextColor()
	{
		return _normalText;
	}

	public Color GetUninitializedTimerTextColor()
	{
		return _notReadyText;
	}

	public string GetGameName()
	{
		return _gameName;
	}

	public string GetDefaultTimerText()
	{
		return _emptyTimerDefaultText;
	}

	public Sprite GetIcon(int chapter)
	{
		if (_chapterSprites == null || _chapterSprites.Length <= chapter + 1)
		{
			return null;
		}
		return _chapterSprites[chapter];
	}

	public string GetLocalizationKey(int chapter)
	{
		if (_chapterTitleLocKeys == null || _chapterTitleLocKeys.Length <= chapter + 1)
		{
			return null;
		}
		return _chapterTitleLocKeys[chapter];
	}

	public bool CanUserToggleTimer()
	{
		return _userCanTurnOnTimer;
	}

	public bool CanUserChangeTimerPosition()
	{
		return _userCanRelocate;
	}

	public bool CanUserChangeTimerStyle()
	{
		return _userCanChangeStyle;
	}

	public float GetDefaultScreenWidthRatio()
	{
		return _leftToRightOffset;
	}

	public float GetDefaultScreenHeightRatio()
	{
		return _topToBottomOffset;
	}

	public SpeedrunPersonalBestsSaveLocationEnum GetPersonalBestSaveLocation()
	{
		return _personalBestsSavingLocation;
	}

	public string GetPersonalBestsFileName()
	{
		return _personalBestsFileName;
	}

	public string GetGoldSplitsFileName()
	{
		return _goldSplitsFileName;
	}

	public PBStyleSettings GetPersonalBestsStyleSettings()
	{
		return _personalBestsStyleSettings;
	}

	public PBLocKeys GetPersonalBestsLocKeys()
	{
		return _personalBestsLocKeys;
	}

	public static SpeedrunSettings LoadFromResources()
	{
		SpeedrunSettings speedrunSettings = Resources.Load<SpeedrunSettings>(ASSET_NAME);
		if (speedrunSettings == null)
		{
			Debug.LogError("Could not find " + ASSET_NAME + " file in the project");
		}
		return speedrunSettings;
	}
}
