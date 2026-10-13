using System;
using System.Collections;
using System.Linq;
using I2.Loc;
using Isto.Core;
using Isto.Core.Data;
using Isto.Core.Localization;
using Isto.Core.Speedrun;
using Isto.GTW.Configuration;
using Isto.GTW.Managers;
using Isto.GTW.Providers;
using Isto.GTW.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.GTW.Speedrun;

public class DoinklerSpeedrunTimer : SpeedrunTimer
{
	[Header("Doinkler Hookups")]
	[SearchableLocalizedString]
	[SerializeField]
	private LocalizedString _fileNumberLocString;

	[SearchableLocalizedString]
	[SerializeField]
	private LocalizedString _incompleteLocString;

	[SerializeField]
	private TextMeshProUGUI _fileNameHeader;

	[SerializeField]
	private TextMeshProUGUI _currentLevelTimer;

	[SerializeField]
	private GTWDoinklerPortfolioDefinition _doinklerPortfolioDefinition;

	[SerializeField]
	private Slider _progressSlider;

	private bool _isTimeOverride;

	private int _currentSpeedrunTimerConfigIndex;

	private IDoinklerWorldDefinitionProvider _doinklerWorldDefinitionProvider;

	private GTWProgressProvider _gtwProgressProvider;

	private GTWGameState _gtwGameState;

	private LocTerm.Factory _localizedStringFactory;

	private DoinklerLevelVariables _doinklerLevelVariables;

	[Inject]
	public void Inject(GTWGameState gameState, IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider, LocTerm.Factory localizedStringFactory, DoinklerLevelVariables doinklerLevelVariables)
	{
		_gtwGameState = gameState;
		_doinklerWorldDefinitionProvider = doinklerWorldDefinitionProvider;
		_localizedStringFactory = localizedStringFactory;
		_gtwProgressProvider = _gameProgress as GTWProgressProvider;
		_doinklerLevelVariables = doinklerLevelVariables;
	}

	protected override IEnumerator Start()
	{
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		yield return null;
		_fileNameHeader.color = _speedrunSettings.GetUninitializedTimerTextColor();
		_currentLevelTimer.color = _speedrunSettings.GetUninitializedTimerTextColor();
		_chapterName.color = _speedrunSettings.GetUninitializedTimerTextColor();
		_currentSpeedrunTimerConfigIndex = PlayerPrefs.GetInt(SpeedrunSettings.CONFIG_PLAYER_PREFS_KEY, 0);
		_gtwProgressProvider.GameTime[_gtwGameState.GetCurrentDoinklerWorld()] = 0f;
		UpdateFileNameLocalization();
		UpdateFileProgressSlider();
		yield return base.Start();
		_fileNameHeader.color = _speedrunSettings.GetNormalTimerTextColor();
		_currentLevelTimer.color = _speedrunSettings.GetNormalTimerTextColor();
		_chapterName.color = _speedrunSettings.GetNormalTimerTextColor();
		UpdateLanguages();
	}

	protected override void Update()
	{
		base.Update();
		if (_gameProgress.GetCurrentGameProgressLevel() == -1)
		{
			return;
		}
		if (_gtwProgressProvider.GameEnded)
		{
			FinishPreviousChapter();
			if (_gameProgress.IsLastProgressLevel())
			{
				UpdateTotalLevelTime(SpeedrunTimer.SPEEDRUN_GREEN_TEXT);
				UpdateCurrentLevelTime(SpeedrunTimer.SPEEDRUN_GREEN_TEXT);
				_mainTimer.color = SpeedrunTimer.SPEEDRUN_GREEN_TEXT;
				_currentLevelTimer.color = SpeedrunTimer.SPEEDRUN_GREEN_TEXT;
				UpdateFileProgressSlider();
				return;
			}
		}
		UpdateFileProgressSlider();
		UpdateTotalLevelTime(Color.white);
		UpdateCurrentLevelTime(Color.white);
	}

	private void OnEnable()
	{
		RegisterEvents();
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		Events.Subscribe(GTWEvents.DOINKLER_STAGE_COMPLETE, Events_OnStageCompleted);
		Events.Subscribe(GTWEvents.DOINKLER_STAGE_START, Events_OnStageStarted);
		Events.Subscribe("LanguageChanged", Events_OnLanguageChanged);
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe(GTWEvents.DOINKLER_STAGE_COMPLETE, Events_OnStageCompleted);
		Events.UnSubscribe(GTWEvents.DOINKLER_STAGE_START, Events_OnStageStarted);
		Events.UnSubscribe("LanguageChanged", Events_OnLanguageChanged);
	}

	private void Events_OnStageStarted()
	{
		_isTimeOverride = false;
		Color normalTimerTextColor = _speedrunSettings.GetNormalTimerTextColor();
		if (_mainTimer.color != normalTimerTextColor)
		{
			_mainTimer.color = normalTimerTextColor;
			_currentLevelTimer.color = normalTimerTextColor;
		}
		UpdateChapterNameLocalization();
		UpdateFileProgressSlider();
		UpdateFileNameLocalization();
		_segmentTimes[_gameProgress.GetCurrentGameProgressLevel()].SetDiffTimer("");
	}

	private void Events_OnStageCompleted()
	{
		_isTimeOverride = true;
	}

	private void Events_OnLanguageChanged()
	{
		UpdateLanguages();
	}

	protected override float GetIndividualSplit(int progressLevel)
	{
		if (progressLevel >= _doinklerPortfolioDefinition.GTWGameWorldDefinitions.Count)
		{
			Debug.LogError($"DoinklerSpeedrunTimer: Attempting to get time for world {progressLevel} but only have {_doinklerPortfolioDefinition.GTWGameWorldDefinitions.Count} worlds.");
			return 0f;
		}
		float num = 0f;
		foreach (GTWGameLevelDefinition gameLevel in _doinklerPortfolioDefinition.GTWGameWorldDefinitions[progressLevel].GameLevels)
		{
			num += _doinklerLevelVariables.GetFloat(gameLevel.UniqueIDTotal);
		}
		if (!_isTimeOverride)
		{
			num += _gameProgress.GetGameSecondsElapsedInLevel(progressLevel);
		}
		return num;
	}

	private float GetLevelSplit(int progressLevel)
	{
		if (progressLevel >= _doinklerPortfolioDefinition.GTWGameWorldDefinitions.Count)
		{
			Debug.LogError($"DoinklerSpeedrunTimer: Attempting to get time for world {progressLevel} but only have {_doinklerPortfolioDefinition.GTWGameWorldDefinitions.Count} worlds.");
			return 0f;
		}
		float num = ((_gtwGameState.GameLevelDefinition != null) ? _doinklerLevelVariables.GetFloat(_gtwGameState.GameLevelDefinition.UniqueIDTotal) : 0f);
		if (!_isTimeOverride)
		{
			num += _gameProgress.GetGameSecondsElapsedInLevel(progressLevel);
		}
		return num;
	}

	protected override void UpdateChapterNameLocalization()
	{
		if (_gtwGameState.GameLevelDefinition == null)
		{
			LocTerm locTerm = _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, "ERROR: No Game Level Definition");
			locTerm.LocalizeInto(_chapterName);
		}
		else
		{
			LocTerm locTerm = (string.IsNullOrEmpty(_gtwGameState.GameLevelDefinition.LevelName.mTerm) ? _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, _gtwGameState.GameLevelDefinition.fallbackLevelName) : _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _gtwGameState.GameLevelDefinition.LevelName.mTerm));
			locTerm.LocalizeInto(_chapterName);
		}
	}

	protected override void SetupSegmentTimer(SpeedRunSingleTime timer, int chapter)
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
			bool flag2 = chapter <= _gameProgress.GetCurrentGameProgressLevel();
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

	protected override void AddDeltaTimeToSegmentTimer(float segmentTime, int segmentIndex, bool cumulativeDeltas = false)
	{
		base.AddDeltaTimeToSegmentTimer(segmentTime, segmentIndex, cumulativeDeltas);
		Color passedTarget = _speedrunSettings.GetPersonalBestsStyleSettings().passedTarget;
		GTWGameWorldDefinition gTWGameWorldDefinition = _doinklerPortfolioDefinition.GTWGameWorldDefinitions[segmentIndex];
		LocTerm locTerm = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _incompleteLocString.mTerm);
		if (!gTWGameWorldDefinition.IsWorldCompleted)
		{
			_segmentTimes[segmentIndex].SetDiffTimer(locTerm.Localize());
			_segmentTimes[segmentIndex].SetDiffColor(passedTarget);
		}
	}

	protected override void SaveRecordTimes()
	{
		SpeedrunTimerData speedrunTimerData = new SpeedrunTimerData();
		int maxGameProgressLevel = _gameProgress.GetMaxGameProgressLevel();
		speedrunTimerData.times = new float[maxGameProgressLevel];
		for (int i = 0; i < maxGameProgressLevel; i++)
		{
			GTWGameWorldDefinition gTWGameWorldDefinition = _doinklerPortfolioDefinition.GTWGameWorldDefinitions[i];
			if (!gTWGameWorldDefinition.IsWorldCompleted)
			{
				continue;
			}
			float num = 0f;
			foreach (GTWGameLevelDefinition gameLevel in gTWGameWorldDefinition.GameLevels)
			{
				num += _doinklerLevelVariables.GetFloat(gameLevel.UniqueIDTotal);
			}
			speedrunTimerData.times[i] = num;
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

	protected override void InitializeChapterBestTime(SpeedrunSettings.SpeedrunTimerConfig config)
	{
		base.InitializeChapterBestTime(config);
		UpdateChapterNameLocalization();
	}

	protected override IEnumerator RefreshConfiguration()
	{
		yield return base.RefreshConfiguration();
		_currentSpeedrunTimerConfigIndex = PlayerPrefs.GetInt(SpeedrunSettings.CONFIG_PLAYER_PREFS_KEY, 0);
	}

	private void UpdateTotalLevelTime(Color color)
	{
		if ((bool)_doinklerWorldDefinitionProvider.Current)
		{
			int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
			TimeSpan timeSpan = TimeSpan.FromMilliseconds(GetLevelSplit(currentGameProgressLevel) * 1000f);
			_mainTimer.text = GTWUtils.GetFormattedTimeOrDefaultStringSeconds(timeSpan.TotalSeconds.ToString(), color, greyOutZeros: false);
		}
	}

	private void UpdateCurrentLevelTime(Color color)
	{
		int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
		string formattedTimeOrDefaultString = GTWUtils.GetFormattedTimeOrDefaultString(TimeSpan.FromMilliseconds(_gameProgress.GetGameSecondsElapsedInLevel(currentGameProgressLevel) * 1000f).TotalSeconds.ToString(), color, greyOutZeros: false);
		if (_currentSpeedrunTimerConfigIndex > 1)
		{
			_mainTimer.text = formattedTimeOrDefaultString;
		}
		else
		{
			_currentLevelTimer.text = formattedTimeOrDefaultString;
		}
	}

	private void UpdateLanguages()
	{
		UpdateFileNameLocalization();
		UpdateChapterNameLocalization();
	}

	private void UpdateFileNameLocalization()
	{
		int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
		LocTerm locTerm = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _fileNumberLocString.mTerm);
		if (currentGameProgressLevel != -1)
		{
			locTerm = _gameProgress.GetGameProgressLevelName(currentGameProgressLevel);
		}
		locTerm.LocalizeInto(_fileNameHeader);
		if (_gtwGameState.GameLevelDefinition != null)
		{
			TextMeshProUGUI fileNameHeader = _fileNameHeader;
			fileNameHeader.text = fileNameHeader.text + " - " + _gtwGameState.GameLevelDefinition.LevelNumber;
		}
	}

	private void UpdateFileProgressSlider()
	{
		GTWGameWorldDefinition current = _doinklerWorldDefinitionProvider.Current;
		int count = current.GameLevels.Count;
		int num = current.GameLevels.Count((GTWGameLevelDefinition x) => x.IsCompleted);
		float value = 0f;
		if (num != 0)
		{
			value = (float)num / (float)count;
		}
		_progressSlider.value = value;
	}
}
