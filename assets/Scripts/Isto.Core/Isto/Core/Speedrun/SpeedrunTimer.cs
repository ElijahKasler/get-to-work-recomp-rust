using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Localization;
using Isto.Core.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.Speedrun;

public class SpeedrunTimer : MonoBehaviour
{
	private enum TimeFormat
	{
		MinutesSecondsMilliseconds = 0,
		HoursMinutesSeconds = 1,
		DaysHoursMinutes = 2
	}

	[Header("Panel")]
	[SerializeField]
	private int _panelLeftPaddingPixels;

	[SerializeField]
	private int _panelRightPaddingPixels;

	[SerializeField]
	private int _panelTopPaddingPixels;

	[SerializeField]
	private int _panelBottomPaddingPixels;

	[Header("Main Timer")]
	[SerializeField]
	private RectTransform _mainTimerSection;

	[SerializeField]
	protected TextMeshProUGUI _mainTimer;

	[SerializeField]
	private TimeFormat _timeFormat = TimeFormat.HoursMinutesSeconds;

	[Header("Run Details")]
	[SerializeField]
	private RectTransform _runDetailsSection;

	[SerializeField]
	private TextMeshProUGUI _runDescription;

	[SerializeField]
	private TextMeshProUGUI _personalFullRunBestTime;

	[Header("Level/Chapter Details")]
	[SerializeField]
	private RectTransform _chapterDetailsSection;

	[SerializeField]
	protected TextMeshProUGUI _chapterName;

	[SerializeField]
	protected TextMeshProUGUI _chapterBestTime;

	[Header("Times List")]
	[SerializeField]
	private RectTransform _fullDisplaySection;

	[FormerlySerializedAs("_timesListStandardHeight")]
	[SerializeField]
	private float _segmentListStandardHeight = 210f;

	[FormerlySerializedAs("_singleTimePrefab")]
	[SerializeField]
	private SpeedRunSingleTime _singleSegmentTimerPrefab;

	[FormerlySerializedAs("_speedrunTimesScrollRect")]
	[SerializeField]
	private ScrollRect _segmentTimesScrollRect;

	[FormerlySerializedAs("_timesListLayout")]
	[SerializeField]
	private LayoutGroup _segmentsListLayout;

	[Header("Extra Features")]
	[SerializeField]
	private RectTransform _extraFeaturesSection;

	[SerializeField]
	private CoreButton _toggleDisplayMode;

	[SerializeField]
	private CoreButton _saveSplits;

	protected static readonly Color SPEEDRUN_GREEN_TEXT = new Color(0.49f, 0.729f, 0.337f);

	private RectTransform _backgroundPanel;

	private LayoutGroup _mainPanelLayout;

	protected List<SpeedRunSingleTime> _segmentTimes;

	protected List<float> _targetTimes;

	private List<float> _personalBestTimes;

	private float _totalTime;

	private float _totalBestTimes;

	private int _previousLevel;

	protected bool _autoScroll;

	protected bool _autoResize;

	private bool _showIcons;

	protected bool _showUpcomingChapters;

	private bool _showTargetInExtraColumn;

	private bool _displayIndividualSplits;

	protected bool _displaySplitsTargets;

	private bool _displaySplitsDeltas;

	protected bool _deltasAreCumulative;

	private bool _toggleCoolingDown;

	private float _cooldownTime = 0.1f;

	private bool _loadTargetTimesPending;

	private Coroutine _crCache;

	protected IGameProgressProvider _gameProgress;

	protected IGameData _gameData;

	private ILocalizationProvider _locProvider;

	private UIModalChoicePopup _modalPopup;

	private GameState _gameState;

	protected SpeedrunSettings _speedrunSettings;

	protected Color bgOdd = new Color(0.1226f, 0.1226f, 0.1226f, 0f);

	protected Color bgEven = new Color(0.1226f, 0.1226f, 0.1226f, 0.4f);

	protected Color bgSelected = new Color(0.1226f, 0.1226f, 0.1226f, 1f);

	[Inject]
	public void Inject(IGameProgressProvider gameProgress, IGameData gameData, ILocalizationProvider locProvider, UIModalChoicePopup modalPopup, GameState gameState, [InjectOptional] SpeedrunSettings speedrunSettings)
	{
		_gameProgress = gameProgress;
		_gameData = gameData;
		_locProvider = locProvider;
		_modalPopup = modalPopup;
		_gameState = gameState;
		_speedrunSettings = speedrunSettings;
	}

	protected virtual void Awake()
	{
		_backgroundPanel = GetComponent<RectTransform>();
		_mainPanelLayout = GetComponent<LayoutGroup>();
		_mainPanelLayout.enabled = false;
	}

	protected virtual IEnumerator Start()
	{
		if (_speedrunSettings == null)
		{
			Debug.LogWarning("SpeedrunTimer aborting because SpeedrunSettings were not found in the project.");
			yield break;
		}
		LoadRecordTimes();
		LoadPersonalBestSplitTimes();
		if (PlayerPrefs.GetInt(SpeedrunSettings.MENU_ACTIVE_PLAYER_PREFS_KEY, -1) == -1)
		{
			int value = (_speedrunSettings.GetDefaultTimerIsOnSetting() ? 1 : 0);
			PlayerPrefs.SetInt(SpeedrunSettings.MENU_ACTIVE_PLAYER_PREFS_KEY, value);
		}
		if (PlayerPrefs.GetInt(SpeedrunSettings.CONFIG_PLAYER_PREFS_KEY, -1) == -1)
		{
			int defaultTimerConfigIndex = _speedrunSettings.GetDefaultTimerConfigIndex();
			PlayerPrefs.SetInt(SpeedrunSettings.CONFIG_PLAYER_PREFS_KEY, defaultTimerConfigIndex);
		}
		if (PlayerPrefs.GetFloat(SpeedrunSettings.VERTICAL_POS_PLAYER_PREFS_KEY, -1f) < -0.1f)
		{
			float defaultScreenHeightRatio = _speedrunSettings.GetDefaultScreenHeightRatio();
			PlayerPrefs.SetFloat(SpeedrunSettings.VERTICAL_POS_PLAYER_PREFS_KEY, defaultScreenHeightRatio);
		}
		if (PlayerPrefs.GetFloat(SpeedrunSettings.HORIZONTAL_POS_PLAYER_PREFS_KEY, -1f) < -0.1f)
		{
			float defaultScreenWidthRatio = _speedrunSettings.GetDefaultScreenWidthRatio();
			PlayerPrefs.SetFloat(SpeedrunSettings.HORIZONTAL_POS_PLAYER_PREFS_KEY, defaultScreenWidthRatio);
		}
		_mainTimer.color = _speedrunSettings.GetUninitializedTimerTextColor();
		yield return RefreshConfiguration();
		int currentLevel;
		do
		{
			yield return null;
			currentLevel = _gameProgress.GetCurrentGameProgressLevel();
		}
		while (currentLevel < 0 || _loadTargetTimesPending);
		_segmentTimes = new List<SpeedRunSingleTime>();
		int maxGameProgressLevel = _gameProgress.GetMaxGameProgressLevel();
		SpeedrunSettings.SpeedrunTimerConfig playerSelectedTimerConfig = _speedrunSettings.GetPlayerSelectedTimerConfig();
		for (int i = 0; i < maxGameProgressLevel; i++)
		{
			SpeedRunSingleTime speedRunSingleTime = UnityEngine.Object.Instantiate(_singleSegmentTimerPrefab, _segmentsListLayout.transform);
			_segmentTimes.Add(speedRunSingleTime);
			SetupSegmentTimer(speedRunSingleTime, i);
		}
		InitializeChapterBestTime(playerSelectedTimerConfig);
		string gameName = _speedrunSettings.GetGameName();
		GetGameModeName();
		string text = "No Major Glitch";
		string text2 = "Any %";
		string text3 = "";
		if (playerSelectedTimerConfig.showGameName)
		{
			text3 += gameName;
			if (playerSelectedTimerConfig.showRunCategory)
			{
				text3 += " - ";
			}
		}
		if (playerSelectedTimerConfig.showRunCategory)
		{
			text3 = text3 + text + " - " + text2;
		}
		_runDescription.text = text3;
		UpdateMainTimer();
		RegisterEvents();
		yield return UpdateAllTimersConfiguration();
		currentLevel = _gameProgress.GetCurrentGameProgressLevel();
		while (GetIndividualSplit(currentLevel).Approx(0f))
		{
			yield return new WaitForSeconds(0.1f);
		}
		Color normalTimerTextColor = _speedrunSettings.GetNormalTimerTextColor();
		if (_mainTimer.color != normalTimerTextColor)
		{
			_mainTimer.color = normalTimerTextColor;
		}
	}

	protected virtual void InitializeChapterBestTime(SpeedrunSettings.SpeedrunTimerConfig config)
	{
		int num = 0;
		_gameProgress.GetGameProgressLevelName(num).LocalizeInto(_chapterName);
		if (config.showCurrentChapterBestTime && IsTargetTimeAvailableForChapter(num))
		{
			UpdateCurrentChapterBestTime();
			_chapterBestTime.gameObject.SetActive(value: true);
		}
		else
		{
			_chapterBestTime.gameObject.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	protected virtual void Update()
	{
		if (_segmentTimes == null)
		{
			return;
		}
		int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
		if (currentGameProgressLevel == -1)
		{
			return;
		}
		if (_previousLevel != currentGameProgressLevel)
		{
			FinishPreviousChapter();
			if (currentGameProgressLevel > _previousLevel + 1)
			{
				Debug.LogWarning("Speedrun issue: timer is more than one level late on player progress. Undefined outcome.");
			}
			_previousLevel = currentGameProgressLevel;
			if (_gameProgress.IsLastProgressLevel())
			{
				_mainTimer.color = SPEEDRUN_GREEN_TEXT;
				return;
			}
			BeginCurrentChapter();
		}
		if (!_gameProgress.IsLastProgressLevel())
		{
			UpdateTimeForChapter(currentGameProgressLevel);
			UpdateMainTimer();
		}
	}

	private void RegisterEvents()
	{
		Events.Subscribe("SettingsSaved", Events_OnSettingsSaved);
		Events.Subscribe("SaveSpeedrunButtonClicked", Events_OnSaveSpeedrunButtonClicked);
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe("SettingsSaved", Events_OnSettingsSaved);
		Events.UnSubscribe("SaveSpeedrunButtonClicked", Events_OnSaveSpeedrunButtonClicked);
	}

	private void Events_OnSaveSpeedrunButtonClicked()
	{
		ShowSavePopup();
	}

	private void Events_OnSettingsSaved()
	{
		if (_crCache == null)
		{
			_crCache = StartCoroutine(RefreshConfiguration());
		}
	}

	public void Button_OnSaveSplits()
	{
		ShowSavePopup();
	}

	private void ModalPopup_OnConfirmSaveSplits()
	{
		SaveRecordTimes();
	}

	private void ModalPopup_OnCancelSaveSplits()
	{
	}

	public void Button_OnReloadSplits()
	{
		LoadRecordTimes();
		LoadPersonalBestSplitTimes();
	}

	public void Button_OnToggleDisplayMode()
	{
		if (!_toggleCoolingDown)
		{
			int num = PlayerPrefs.GetInt(SpeedrunSettings.CONFIG_PLAYER_PREFS_KEY);
			if (++num >= _speedrunSettings.GetTimerConfigsCount())
			{
				num = 0;
			}
			PlayerPrefs.SetInt(SpeedrunSettings.CONFIG_PLAYER_PREFS_KEY, num);
			if (_crCache == null)
			{
				_crCache = StartCoroutine(RefreshConfiguration());
				StartCoroutine(CooldownToggle());
			}
		}
	}

	protected virtual void SetupSegmentTimer(SpeedRunSingleTime timer, int chapter)
	{
		timer.SetColorBG((chapter % 2 == 0) ? bgEven : bgOdd);
		timer.ActivateImage();
		LocTerm gameProgressLevelName = _gameProgress.GetGameProgressLevelName(chapter);
		timer.SetChapterName(gameProgressLevelName);
		bool flag = IsTargetTimeAvailableForChapter(chapter);
		if (_displaySplitsTargets & flag)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(_targetTimes[chapter]);
			timer.SetTimer(UnityUtils.ConvertTimespanToTotalHoursMinutesSeconds(timeSpan));
		}
		else
		{
			timer.SetTimer(_speedrunSettings.GetDefaultTimerText());
		}
		SpeedrunSettings.SpeedrunTimerConfig playerSelectedTimerConfig = _speedrunSettings.GetPlayerSelectedTimerConfig();
		if (playerSelectedTimerConfig.showPersonalBestDeltas)
		{
			bool flag2 = !GetIndividualSplit(chapter).Approx(0f);
			if (flag & flag2)
			{
				float individualSplit = GetIndividualSplit(chapter);
				_deltasAreCumulative = playerSelectedTimerConfig.cumulativePersonalBestDeltas;
				AddDeltaTimeToSegmentTimer(individualSplit, chapter, _deltasAreCumulative);
			}
			else
			{
				timer.SetDiffTimer("");
			}
		}
		else
		{
			timer.HideDiffTimer();
		}
	}

	private string GetGameModeName()
	{
		GameModeDefinition currentGameMode = _gameState.CurrentGameMode;
		if ((object)currentGameMode != null)
		{
			_ = currentGameMode.NameLoc;
			if (true)
			{
				return Loc.Get(_gameState.CurrentGameMode.NameLoc);
			}
		}
		if (_gameState.CurrentGameMode != null)
		{
			return _gameState.CurrentGameMode.internalName;
		}
		return "Story Mode";
	}

	protected void FinishPreviousChapter()
	{
		float individualSplit = GetIndividualSplit(_previousLevel);
		TimeSpan timeSpan = TimeSpan.FromSeconds(individualSplit);
		string gameProgressLevelInternalName = _gameProgress.GetGameProgressLevelInternalName(_previousLevel);
		TimeSpan timeSpan2 = timeSpan;
		Debug.Log("Speedrun Mode- Completed:" + gameProgressLevelInternalName + ", Split: " + timeSpan2);
		SpeedrunSettings.SpeedrunTimerConfig playerSelectedTimerConfig = _speedrunSettings.GetPlayerSelectedTimerConfig();
		if (playerSelectedTimerConfig.showPersonalBestDeltas && IsTargetTimeAvailableForChapter(_previousLevel))
		{
			AddDeltaTimeToSegmentTimer(individualSplit, _previousLevel, playerSelectedTimerConfig.cumulativePersonalBestDeltas);
		}
		_segmentTimes[_previousLevel].SetColor(_speedrunSettings.GetNormalTimerTextColor());
		_segmentTimes[_previousLevel].SetColorBG((_previousLevel % 2 == 0) ? bgEven : bgOdd);
	}

	protected virtual void BeginCurrentChapter()
	{
		int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
		_segmentTimes[currentGameProgressLevel].SetColorBG(bgSelected);
		if (!_showUpcomingChapters)
		{
			_segmentTimes[currentGameProgressLevel].gameObject.SetActive(value: true);
		}
		_gameProgress.GetGameProgressLevelName(currentGameProgressLevel).LocalizeInto(_chapterName);
		if (_speedrunSettings.GetPlayerSelectedTimerConfig().showCurrentChapterBestTime && IsTargetTimeAvailableForChapter(currentGameProgressLevel))
		{
			UpdateCurrentChapterBestTime();
			_chapterBestTime.gameObject.SetActive(value: true);
		}
		else
		{
			_chapterBestTime.gameObject.SetActive(value: false);
		}
		if (_autoScroll)
		{
			AdjustScrollViewForChapter(currentGameProgressLevel);
		}
		if (_autoResize)
		{
			StartCoroutine(UpdateAllTimersConfiguration());
		}
	}

	protected virtual void AddDeltaTimeToSegmentTimer(float segmentTime, int segmentIndex, bool cumulativeDeltas = false)
	{
		SpeedrunSettings.PBStyleSettings personalBestsStyleSettings = _speedrunSettings.GetPersonalBestsStyleSettings();
		Color diffColor = _speedrunSettings.GetNormalTimerTextColor();
		float num = _targetTimes[segmentIndex];
		float num2 = -1f;
		if (_personalBestTimes != null)
		{
			num2 = _personalBestTimes[segmentIndex];
		}
		if (cumulativeDeltas)
		{
			segmentTime = GetCumulativeSplit(segmentIndex);
			num = GetCumulativeSplitTarget(segmentIndex);
		}
		string text = "+";
		if (segmentTime.Approx(num, 0.01f))
		{
			diffColor = personalBestsStyleSettings.exactTarget;
		}
		else if (segmentTime > num)
		{
			diffColor = personalBestsStyleSettings.passedTarget;
		}
		else if (segmentTime < num2)
		{
			diffColor = personalBestsStyleSettings.belowPersonalBest;
			text = "-";
		}
		else if (segmentTime < num)
		{
			diffColor = personalBestsStyleSettings.belowTarget;
			text = "-";
		}
		float num3 = Mathf.Abs(segmentTime - num);
		TimeSpan timeSpan = TimeSpan.FromSeconds(num3);
		string diffTimer = ((num3 >= 3600f) ? (text + UnityUtils.ConvertTimespanToTotalHoursMinutesSeconds(timeSpan)) : ((!(num3 >= 60f)) ? (text + timeSpan.ToString("ss")) : (text + timeSpan.ToString("mm':'ss"))));
		_segmentTimes[segmentIndex].SetDiffTimer(diffTimer);
		_segmentTimes[segmentIndex].SetDiffColor(diffColor);
	}

	protected void AdjustScrollViewForChapter(int currentLevel)
	{
		Scrollbar verticalScrollbar = _segmentTimesScrollRect.verticalScrollbar;
		int num = 9;
		if (currentLevel >= num)
		{
			verticalScrollbar.value = (float)(1.0 - (double)(currentLevel - num) * 0.055);
		}
		else
		{
			verticalScrollbar.value = 1f;
		}
	}

	private void UpdateMainTimer()
	{
		_totalTime = _gameProgress.GetTotalGameSecondsElapsedInPlaythrough();
		if (_timeFormat == TimeFormat.DaysHoursMinutes)
		{
			TimeSpan timeSpan = TimeSpan.FromMinutes(_totalTime / 60f);
			_mainTimer.text = UnityUtils.ConvertTimespanToTotalDaysHoursMinutes(timeSpan);
		}
		else if (_timeFormat == TimeFormat.MinutesSecondsMilliseconds)
		{
			TimeSpan timeSpan2 = TimeSpan.FromMilliseconds(_totalTime * 1000f);
			_mainTimer.text = UnityUtils.ConvertTimespanToTotalMinutesSecondsMilliseconds(timeSpan2);
		}
		else
		{
			TimeSpan timeSpan3 = TimeSpan.FromSeconds(_totalTime);
			_mainTimer.text = UnityUtils.ConvertTimespanToTotalHoursMinutesSeconds(timeSpan3);
		}
	}

	[ContextMenu("UpdateAllTimers")]
	private void UpdateAllTimers()
	{
		int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
		for (int i = 0; i < _segmentTimes.Count; i++)
		{
			if (i < currentGameProgressLevel)
			{
				UpdateTimeForChapter(i);
			}
		}
	}

	protected IEnumerator UpdateAllTimersConfiguration()
	{
		if (_gameProgress.GetCurrentGameProgressLevel() != -1 && _segmentTimes != null)
		{
			for (int i = 0; i < _segmentTimes.Count; i++)
			{
				UpdateTimerConfiguration(i);
			}
			if (_autoResize)
			{
				FitScrollRectToContents();
			}
			else
			{
				_fullDisplaySection.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _segmentListStandardHeight);
			}
			FitPanelToVerticalContents();
			FitPanelHorizontalContents();
			_mainPanelLayout.enabled = true;
			yield return null;
			_mainPanelLayout.enabled = false;
			_segmentsListLayout.enabled = true;
			yield return null;
			_segmentsListLayout.enabled = false;
			Vector2 anchoredPosition = _segmentTimesScrollRect.content.anchoredPosition;
			anchoredPosition.y = 0f;
			_segmentTimesScrollRect.content.anchoredPosition = anchoredPosition;
		}
	}

	[ContextMenu("SetScrollBarToTop")]
	private void SetScrollBarToTop()
	{
		_segmentTimesScrollRect.verticalScrollbar.value = 1f;
	}

	private void UpdateTimeForChapter(int chapter)
	{
		float num = ((_displaySplitsTargets && IsTargetTimeAvailableForChapter(chapter)) ? _targetTimes[chapter] : ((_displaySplitsDeltas && IsTargetTimeAvailableForChapter(chapter)) ? (GetIndividualSplit(chapter) - _targetTimes[chapter]) : ((!_displayIndividualSplits) ? GetCumulativeSplit(chapter) : GetIndividualSplit(chapter))));
		SpeedRunSingleTime speedRunSingleTime = _segmentTimes[chapter];
		int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
		SpeedrunSettings.SpeedrunTimerConfig playerSelectedTimerConfig = _speedrunSettings.GetPlayerSelectedTimerConfig();
		if (_displaySplitsTargets || chapter != currentGameProgressLevel)
		{
			speedRunSingleTime.SetColor(_speedrunSettings.GetNormalTimerTextColor());
		}
		else if (playerSelectedTimerConfig.showPBColorsInSegmentTime && IsTargetTimeAvailableForChapter(chapter))
		{
			SpeedrunSettings.PBStyleSettings personalBestsStyleSettings = _speedrunSettings.GetPersonalBestsStyleSettings();
			Color color = _speedrunSettings.GetNormalTimerTextColor();
			float individualSplit = GetIndividualSplit(chapter);
			float num2 = _targetTimes[chapter];
			if (individualSplit > num2)
			{
				color = personalBestsStyleSettings.passedTarget;
			}
			speedRunSingleTime.SetColor(color);
		}
		TimeSpan timeSpan = TimeSpan.FromSeconds(num);
		speedRunSingleTime.SetTimer(UnityUtils.ConvertTimespanToTotalHoursMinutesSeconds(timeSpan));
	}

	private void UpdateTimerConfiguration(int chapter)
	{
		SpeedRunSingleTime speedRunSingleTime = _segmentTimes[chapter];
		SetupSegmentTimer(speedRunSingleTime, chapter);
		if (chapter > _gameProgress.GetMaxGameProgressLevel())
		{
			speedRunSingleTime.SetTimer("");
			return;
		}
		int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
		if (chapter > currentGameProgressLevel)
		{
			if (!_showUpcomingChapters)
			{
				if (speedRunSingleTime.gameObject.activeSelf)
				{
					speedRunSingleTime.gameObject.SetActive(value: false);
				}
				return;
			}
			if (!speedRunSingleTime.gameObject.activeSelf)
			{
				speedRunSingleTime.gameObject.SetActive(value: true);
				speedRunSingleTime.SetDiffTimer("");
			}
		}
		if (chapter == currentGameProgressLevel)
		{
			speedRunSingleTime.SetColorBG(bgSelected);
			speedRunSingleTime.SetDiffTimer("");
		}
		else
		{
			speedRunSingleTime.SetColorBG((chapter % 2 == 0) ? bgEven : bgOdd);
		}
		if (_showIcons)
		{
			Sprite icon = _speedrunSettings.GetIcon(chapter);
			speedRunSingleTime.SetIcon(icon);
		}
		else
		{
			speedRunSingleTime.HideIcon();
		}
		if (_showTargetInExtraColumn && AreTargetTimesAvailable())
		{
			if (IsTargetTimeAvailableForChapter(chapter))
			{
				float num = ((!_displayIndividualSplits) ? GetCumulativeSplitTarget(chapter) : GetIndividualSplitTarget(chapter));
				TimeSpan timeSpan = TimeSpan.FromSeconds(num);
				speedRunSingleTime.SetTargetTimer(UnityUtils.ConvertTimespanToTotalHoursMinutesSeconds(timeSpan));
			}
			else
			{
				speedRunSingleTime.SetTargetTimer("");
			}
		}
		else
		{
			speedRunSingleTime.HideTargetTimer();
		}
		if (chapter <= currentGameProgressLevel)
		{
			UpdateTimeForChapter(chapter);
		}
		else if (_displaySplitsTargets && IsTargetTimeAvailableForChapter(chapter))
		{
			TimeSpan timeSpan2 = TimeSpan.FromSeconds(_targetTimes[chapter]);
			speedRunSingleTime.SetTimer(UnityUtils.ConvertTimespanToTotalHoursMinutesSeconds(timeSpan2));
		}
		else
		{
			speedRunSingleTime.SetTimer(_speedrunSettings.GetDefaultTimerText());
		}
	}

	private void TurnOffSplitsLayout()
	{
		_segmentsListLayout.enabled = false;
	}

	protected virtual float GetIndividualSplit(int progressLevel)
	{
		return _gameProgress.GetGameSecondsElapsedInLevel(progressLevel);
	}

	private float GetCumulativeSplit(int progressLevel)
	{
		float num = 0f;
		for (int i = 0; i <= progressLevel; i++)
		{
			float individualSplit = GetIndividualSplit(i);
			num += individualSplit;
		}
		return num;
	}

	public IEnumerator CooldownToggle()
	{
		if (!_toggleCoolingDown)
		{
			_toggleCoolingDown = true;
			yield return new WaitForSeconds(_cooldownTime);
			_toggleCoolingDown = false;
		}
	}

	protected virtual IEnumerator RefreshConfiguration()
	{
		PlayerPrefs.GetInt(SpeedrunSettings.MENU_ACTIVE_PLAYER_PREFS_KEY);
		SpeedrunSettings.SpeedrunTimerConfig playerSelectedTimerConfig = _speedrunSettings.GetPlayerSelectedTimerConfig();
		ApplyTimerConfig(playerSelectedTimerConfig);
		_mainPanelLayout.enabled = true;
		yield return null;
		_mainPanelLayout.enabled = false;
		UpdateChapterNameLocalization();
		UpdatePersonalBestTimeDisplay();
		yield return UpdateAllTimersConfiguration();
		_crCache = null;
	}

	private void ApplyTimerConfig(SpeedrunSettings.SpeedrunTimerConfig config)
	{
		_mainTimerSection.gameObject.SetActive(config.IsSectionShown(SpeedrunSettings.SpeedrunTimerSectionEnum.MAIN_TIMER));
		_runDetailsSection.gameObject.SetActive(config.IsSectionShown(SpeedrunSettings.SpeedrunTimerSectionEnum.RUN_DETAILS));
		_chapterDetailsSection.gameObject.SetActive(config.IsSectionShown(SpeedrunSettings.SpeedrunTimerSectionEnum.CHAPTER_INFO));
		_fullDisplaySection.gameObject.SetActive(config.IsSectionShown(SpeedrunSettings.SpeedrunTimerSectionEnum.FULL_DISPLAY));
		FitPanelToVerticalContents();
		FitPanelHorizontalContents();
		_runDescription.gameObject.SetActive(config.showGameName || config.showRunCategory);
		_personalFullRunBestTime.gameObject.SetActive(config.showTotalPersonalBest);
		int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
		currentGameProgressLevel = Mathf.Max(currentGameProgressLevel, 0);
		if (config.showCurrentChapterBestTime && IsTargetTimeAvailableForChapter(currentGameProgressLevel))
		{
			UpdateCurrentChapterBestTime();
			_chapterBestTime.gameObject.SetActive(value: true);
		}
		else
		{
			_chapterBestTime.gameObject.SetActive(value: false);
		}
		bool active = false;
		if (config.showPersonalBestSaveButton)
		{
			_saveSplits?.gameObject.SetActive(value: true);
			active = true;
		}
		else
		{
			_saveSplits?.gameObject.SetActive(value: false);
		}
		if (config.showStyleToggleButton)
		{
			_toggleDisplayMode?.gameObject.SetActive(value: true);
			active = true;
		}
		else
		{
			_toggleDisplayMode?.gameObject.SetActive(value: false);
		}
		_extraFeaturesSection?.gameObject.SetActive(active);
		switch (config.segmentTimersType)
		{
		case SpeedrunSettings.SpeedrunFullSectionListTypeEnum.ListOfAbsoluteTimes:
			_displayIndividualSplits = false;
			_displaySplitsTargets = false;
			_displaySplitsDeltas = false;
			break;
		case SpeedrunSettings.SpeedrunFullSectionListTypeEnum.ListOfRelativeTimes:
			_displayIndividualSplits = true;
			_displaySplitsTargets = false;
			_displaySplitsDeltas = false;
			break;
		case SpeedrunSettings.SpeedrunFullSectionListTypeEnum.ListOfPersonalBestTimes:
			_displayIndividualSplits = false;
			_displaySplitsTargets = true;
			_displaySplitsDeltas = false;
			break;
		case SpeedrunSettings.SpeedrunFullSectionListTypeEnum.ListOfDiffsFromPersonalBest:
			_displayIndividualSplits = false;
			_displaySplitsTargets = false;
			_displaySplitsDeltas = true;
			break;
		default:
			Debug.LogWarning($"Individual segment timer display value {config.segmentTimersType} is not supported.");
			break;
		}
		_segmentTimesScrollRect.vertical = config.userCanScrollTimesList;
		_autoScroll = config.autoScrollTimesListOnSplitChange;
		_showIcons = config.showChapterIcons;
		_showUpcomingChapters = config.showUpcomingChapters;
		_showTargetInExtraColumn = config.showPersonalBestColumn;
		_autoResize = config.autoResizeTimesListPanel;
		_deltasAreCumulative = config.cumulativePersonalBestDeltas;
	}

	protected void UpdateCurrentChapterBestTime()
	{
		int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
		currentGameProgressLevel = Mathf.Max(currentGameProgressLevel, 0);
		TimeSpan timeSpan = TimeSpan.FromSeconds(_targetTimes[currentGameProgressLevel]);
		_chapterBestTime.text = UnityUtils.ConvertTimespanToTotalHoursMinutesSeconds(timeSpan);
	}

	private void FitScrollRectToContents()
	{
		float height = _singleSegmentTimerPrefab.GetComponent<RectTransform>().rect.height;
		float size = (float)_segmentTimes.Count((SpeedRunSingleTime x) => x.gameObject.activeSelf) * height;
		_fullDisplaySection.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
	}

	private void FitPanelToVerticalContents()
	{
		float num = 0f;
		if (_mainTimerSection.gameObject.activeSelf)
		{
			num += _mainTimerSection.rect.height;
		}
		if (_runDetailsSection.gameObject.activeSelf)
		{
			float num2 = 0f;
			if (_runDescription.gameObject.activeSelf)
			{
				num2 += 20f;
			}
			if (_personalFullRunBestTime.gameObject.activeSelf)
			{
				num2 += 20f;
			}
			_runDetailsSection.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num2);
			num += _runDetailsSection.rect.height;
		}
		if (_chapterDetailsSection.gameObject.activeSelf)
		{
			num += _chapterDetailsSection.rect.height;
		}
		if (_fullDisplaySection.gameObject.activeSelf)
		{
			num += _fullDisplaySection.rect.height;
		}
		_backgroundPanel.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num);
	}

	private void FitPanelHorizontalContents()
	{
		if (_segmentTimes != null)
		{
			float num = 0f;
			num = _segmentTimes[0].GetContentsWidth();
			num = MathF.Min(num, 370f);
			_fullDisplaySection.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num);
		}
	}

	private void RepositionPanelFromScreenHeight(float heightRatio)
	{
		int num = Mathf.CeilToInt(_backgroundPanel.rect.height);
		int num2 = _panelTopPaddingPixels + num + _panelBottomPaddingPixels;
		int num3 = Screen.height - num2;
		float num4 = heightRatio * (float)num3;
		Vector2 anchoredPosition = _backgroundPanel.anchoredPosition;
		anchoredPosition.y = 0f - (num4 + (float)_panelTopPaddingPixels);
		_backgroundPanel.anchoredPosition = anchoredPosition;
	}

	private void RepositionPanelFromScreenWidth(float widthRatio)
	{
		int num = Mathf.CeilToInt(_backgroundPanel.rect.width);
		int num2 = _panelLeftPaddingPixels + num + _panelRightPaddingPixels;
		int num3 = Screen.width - num2;
		float num4 = (1f - widthRatio) * (float)num3;
		Vector2 anchoredPosition = _backgroundPanel.anchoredPosition;
		anchoredPosition.x = 0f - (num4 + (float)_panelRightPaddingPixels);
		_backgroundPanel.anchoredPosition = anchoredPosition;
	}

	private bool AreTargetTimesAvailable()
	{
		if (_targetTimes == null)
		{
			return false;
		}
		if (_targetTimes.Count == 0)
		{
			return false;
		}
		return true;
	}

	protected bool IsTargetTimeAvailableForChapter(int n)
	{
		if (_targetTimes == null)
		{
			return false;
		}
		if (_targetTimes.Count <= n)
		{
			return false;
		}
		if (_targetTimes[n].Approx(0f, 0.01f))
		{
			return false;
		}
		return true;
	}

	private float GetIndividualSplitTarget(int progressLevel)
	{
		if (_targetTimes == null)
		{
			return 0f;
		}
		if (_targetTimes.Count <= progressLevel)
		{
			return 0f;
		}
		return _targetTimes[progressLevel];
	}

	private float GetCumulativeSplitTarget(int progressLevel)
	{
		if (_targetTimes == null)
		{
			return 0f;
		}
		if (_targetTimes.Count <= progressLevel)
		{
			return 0f;
		}
		float num = 0f;
		for (int i = 0; i <= progressLevel; i++)
		{
			float individualSplitTarget = GetIndividualSplitTarget(i);
			num += individualSplitTarget;
		}
		return num;
	}

	private void ShowSavePopup()
	{
		SpeedrunSettings.PBLocKeys personalBestsLocKeys = _speedrunSettings.GetPersonalBestsLocKeys();
		string localizedText = _locProvider.GetLocalizedText(personalBestsLocKeys.savePopupTitle);
		string localizedText2 = _locProvider.GetLocalizedText(personalBestsLocKeys.savePopupQuestion);
		string localizedText3 = _locProvider.GetLocalizedText(personalBestsLocKeys.savePopupInfo);
		_modalPopup.DisplayChoice(UIModalChoicePopup.ChoicePopupType.OkCancelChoice, localizedText2, ModalPopup_OnConfirmSaveSplits, ModalPopup_OnCancelSaveSplits, localizedText3, localizedText);
	}

	protected virtual void SaveRecordTimes()
	{
		SpeedrunTimerData speedrunTimerData = new SpeedrunTimerData();
		int maxGameProgressLevel = _gameProgress.GetMaxGameProgressLevel();
		speedrunTimerData.times = new float[maxGameProgressLevel];
		for (int i = 0; i < _previousLevel; i++)
		{
			float gameSecondsElapsedInLevel = _gameProgress.GetGameSecondsElapsedInLevel(i);
			speedrunTimerData.times[i] = gameSecondsElapsedInLevel;
		}
		switch (_speedrunSettings.GetPersonalBestSaveLocation())
		{
		case SpeedrunSettings.SpeedrunPersonalBestsSaveLocationEnum.DoNotSave:
			Debug.LogWarning("Best splits currently configured not to be saved.");
			break;
		case SpeedrunSettings.SpeedrunPersonalBestsSaveLocationEnum.SaveSlot:
			SaveRecordToSlot(speedrunTimerData);
			break;
		case SpeedrunSettings.SpeedrunPersonalBestsSaveLocationEnum.LocalLow:
			SaveRecordToLocalLow(speedrunTimerData);
			break;
		default:
			Debug.LogError($"Best splits save location has unsupported configuration {_speedrunSettings.GetPersonalBestSaveLocation()}");
			break;
		}
	}

	protected void SaveRecordToSlot(SpeedrunTimerData data)
	{
		Debug.LogError("Saving Splits in Save Slot not supported yet.");
	}

	protected void SaveRecordToLocalLow(SpeedrunTimerData data)
	{
		_gameData.SaveSpeedrunTimes(data, (bool saveResult) =>
		{
			if (!saveResult)
			{
				Debug.LogError("Speedrun splits could not be saved as PB!");
			}
			else
			{
				Debug.Log("Speedrun splits saved as new PB.");
				ShowSaveSuccessPopup();
			}
		});
	}

	private void ShowSaveSuccessPopup()
	{
		SpeedrunSettings.PBLocKeys personalBestsLocKeys = _speedrunSettings.GetPersonalBestsLocKeys();
		string localizedText = _locProvider.GetLocalizedText(personalBestsLocKeys.confirmPopupTitle);
		string localizedText2 = _locProvider.GetLocalizedText(personalBestsLocKeys.confirmPopupFile);
		localizedText2 = localizedText2.Replace("{filename}", _speedrunSettings.GetPersonalBestsFileName());
		string localizedText3 = _locProvider.GetLocalizedText(personalBestsLocKeys.confirmPopupFolder);
		localizedText3 = GetSanitizedPersistentPath();
		_modalPopup.DisplayChoice(UIModalChoicePopup.ChoicePopupType.NoChoice, localizedText2 + "\n" + localizedText3, null, null, null, localizedText);
	}

	[ContextMenu("LoadRecordTimes")]
	private void LoadRecordTimes()
	{
		_loadTargetTimesPending = true;
		_gameData.LoadSpeedrunTimes((SpeedrunTimerData speedrunData) =>
		{
			_loadTargetTimesPending = false;
			if (speedrunData == null)
			{
				Debug.Log("Speedrun data not found. Won't be able to show PB.");
				_personalFullRunBestTime.text = "";
				_personalFullRunBestTime.gameObject.SetActive(value: false);
			}
			else
			{
				_totalBestTimes = 0f;
				bool flag = false;
				for (int i = 0; i < speedrunData.times.Length; i++)
				{
					if (speedrunData.times[i].Approx(0f, 0.01f))
					{
						flag = true;
						break;
					}
					_totalBestTimes += speedrunData.times[i];
				}
				if (flag)
				{
					_personalFullRunBestTime.text = "";
					_personalFullRunBestTime.gameObject.SetActive(value: false);
				}
				else
				{
					UpdatePersonalBestTimeDisplay();
					SpeedrunSettings.SpeedrunTimerConfig playerSelectedTimerConfig = _speedrunSettings.GetPlayerSelectedTimerConfig();
					_personalFullRunBestTime.gameObject.SetActive(playerSelectedTimerConfig.showTotalPersonalBest);
				}
				if (_totalBestTimes.Approx(0f, 0.01f))
				{
					_targetTimes = null;
				}
				else
				{
					_targetTimes = new List<float>(speedrunData.times);
				}
			}
		});
	}

	[ContextMenu("LoadPersonalBestSplitTimes")]
	private void LoadPersonalBestSplitTimes()
	{
		_gameData.LoadGoldSplitTimes((SpeedrunTimerData personalBestSplitsData) =>
		{
			if (personalBestSplitsData == null)
			{
				Debug.Log("Personal best splits data not found.");
				_personalBestTimes = null;
			}
			else if (personalBestSplitsData.times == null || personalBestSplitsData.times.Length == 0)
			{
				Debug.Log("Personal best splits data is empty.");
				_personalBestTimes = null;
			}
			else
			{
				_personalBestTimes = new List<float>(personalBestSplitsData.times);
				Debug.Log($"Personal best splits loaded successfully. {_personalBestTimes.Count} splits available.");
			}
		});
	}

	private void UpdatePersonalBestTimeDisplay()
	{
		if (!_totalBestTimes.Approx(0f, 0.01f))
		{
			SpeedrunSettings.PBLocKeys personalBestsLocKeys = _speedrunSettings.GetPersonalBestsLocKeys();
			string localizedText = _locProvider.GetLocalizedText(personalBestsLocKeys.bestRunTimeLabel);
			TimeSpan timeSpan = TimeSpan.FromSeconds(_totalBestTimes);
			_personalFullRunBestTime.text = localizedText + UnityUtils.ConvertTimespanToTotalHoursMinutesSeconds(timeSpan);
		}
	}

	protected virtual void UpdateChapterNameLocalization()
	{
		int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
		if (currentGameProgressLevel > 0)
		{
			_gameProgress.GetGameProgressLevelName(currentGameProgressLevel).LocalizeInto(_chapterName);
		}
	}

	private string GetSanitizedPersistentPath()
	{
		string persistentDataPath = Application.persistentDataPath;
		char altDirectorySeparatorChar = Path.AltDirectorySeparatorChar;
		List<string> list = persistentDataPath.Split(altDirectorySeparatorChar).ToList();
		int num = list.FindIndex((string p) => p.Equals("Users", StringComparison.OrdinalIgnoreCase));
		num++;
		list[num] = "<your-username>";
		return string.Join(altDirectorySeparatorChar.ToString(), list);
	}
}
