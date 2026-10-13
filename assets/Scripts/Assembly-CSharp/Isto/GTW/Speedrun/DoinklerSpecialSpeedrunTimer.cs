using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using Isto.Core;
using Isto.Core.Beings;
using Isto.Core.Data;
using Isto.Core.Localization;
using Isto.Core.Speedrun;
using Isto.GTW.Configuration;
using Isto.GTW.LevelFeatures;
using Isto.GTW.Managers;
using Isto.GTW.Player;
using Isto.GTW.Providers;
using TMPro;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Speedrun;

public class DoinklerSpecialSpeedrunTimer : SpeedrunTimer
{
	[Header("Doinkler Hookups")]
	[SerializeField]
	private TextMeshProUGUI _fileNameHeader;

	[SerializeField]
	private TextMeshProUGUI _personalBest;

	[SerializeField]
	private TextMeshProUGUI _currentCheckpointProgress;

	[SerializeField]
	private TextMeshProUGUI _currentHeightProgress;

	[SerializeField]
	private GTWGameLevelDefinition _doinklerSpecialDefinition;

	[SearchableLocalizedString]
	[SerializeField]
	private LocalizedString _heightLocString;

	[SearchableLocalizedString]
	[SerializeField]
	private LocalizedString _personalBestLocString;

	[SearchableLocalizedString]
	[SerializeField]
	private LocalizedString _checkpointLocString;

	private bool _isTimeOverride;

	private int _maxCheckpoint = 1;

	private MultiTermLocExpression _heightLocExpression;

	private MultiTermLocExpression _personalBestLocExpression;

	private MultiTermLocExpression _checkpointLocExpression;

	private IPlayerController _player;

	private IDoinklerWorldDefinitionProvider _doinklerWorldDefinitionProvider;

	private GTWProgressProvider _gtwProgressProvider;

	private PlayerController _playerController;

	private DoinklerLevelVariables _doinklerLevelVariables;

	private LocTerm.Factory _localizedStringFactory;

	private CheckpointManager CheckpointManager => _playerController.CheckpointManager;

	[Inject]
	public void Inject(IPlayerController player, IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider, PlayerController playerController, DoinklerLevelVariables doinklerLevelVariables, LocTerm.Factory localizedStringFactory)
	{
		_player = player;
		_doinklerWorldDefinitionProvider = doinklerWorldDefinitionProvider;
		_gtwProgressProvider = _gameProgress as GTWProgressProvider;
		_playerController = playerController;
		_doinklerLevelVariables = doinklerLevelVariables;
		_localizedStringFactory = localizedStringFactory;
	}

	protected override IEnumerator Start()
	{
		_fileNameHeader.color = _speedrunSettings.GetUninitializedTimerTextColor();
		_personalBest.color = _speedrunSettings.GetUninitializedTimerTextColor();
		_currentCheckpointProgress.color = _speedrunSettings.GetUninitializedTimerTextColor();
		_chapterName.color = _speedrunSettings.GetUninitializedTimerTextColor();
		_mainTimer.color = _speedrunSettings.GetUninitializedTimerTextColor();
		_fileNameHeader.gameObject.SetActive(value: false);
		yield return base.Start();
		_fileNameHeader.color = _speedrunSettings.GetNormalTimerTextColor();
		_personalBest.color = _speedrunSettings.GetNormalTimerTextColor();
		_currentCheckpointProgress.color = _speedrunSettings.GetNormalTimerTextColor();
		_chapterName.color = _speedrunSettings.GetNormalTimerTextColor();
	}

	protected override void Update()
	{
		base.Update();
		if (_gameProgress.GetCurrentGameProgressLevel() != -1)
		{
			UpdateTotalWorldTime();
			UpdateCurrentLevel();
		}
	}

	private void OnEnable()
	{
		RegisterEvents();
	}

	private void RegisterEvents()
	{
		Events.Subscribe(GTWEvents.DOINKLER_STAGE_COMPLETE, Events_OnStageCompleted);
		Events.Subscribe(GTWEvents.DOINKLER_STAGE_START, Events_OnStageStarted);
	}

	private void Events_OnStageStarted()
	{
		_isTimeOverride = false;
		UpdateChapterNameLocalization();
	}

	private void Events_OnStageCompleted()
	{
		_isTimeOverride = true;
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe(GTWEvents.DOINKLER_STAGE_COMPLETE, Events_OnStageCompleted);
		Events.UnSubscribe(GTWEvents.DOINKLER_STAGE_START, Events_OnStageStarted);
	}

	private void UpdateTotalWorldTime()
	{
		if ((bool)_doinklerWorldDefinitionProvider.Current)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(_gameProgress.GetTotalGameSecondsElapsedInPlaythrough());
			_mainTimer.text = UnityUtils.ConvertTimespanToTotalHoursMinutesSeconds(timeSpan);
		}
	}

	private void UpdateCurrentLevel()
	{
		LocalizeCheckpoint();
		int currentHeightPercent = Mathf.FloorToInt(_gtwProgressProvider.PlayerHeightPercent);
		LocalizeHeight(currentHeightPercent);
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

	protected override float GetIndividualSplit(int progressLevel)
	{
		float num = 0f;
		num += _doinklerLevelVariables.GetFloat(_doinklerSpecialDefinition.UniqueIDTotal);
		if (!_isTimeOverride)
		{
			num += _gameProgress.GetGameSecondsElapsedInLevel(progressLevel);
		}
		return num;
	}

	protected override void SaveRecordTimes()
	{
		SpeedrunTimerData speedrunTimerData = new SpeedrunTimerData();
		int maxGameProgressLevel = _gtwProgressProvider.GetMaxGameProgressLevel();
		speedrunTimerData.times = new float[maxGameProgressLevel];
		for (int i = 0; i < maxGameProgressLevel; i++)
		{
			float value = 0f;
			_gtwProgressProvider.GameTime.TryGetValue(i, out value);
			speedrunTimerData.times[i] = value;
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

	private void LocalizeHeight(int currentHeightPercent)
	{
		LocTerm item = _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, ": ");
		LocTerm item2 = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _heightLocString.mTerm);
		LocTerm item3 = _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, $"{currentHeightPercent}%");
		_heightLocExpression = new MultiTermLocExpression(new List<LocTerm> { item2, item, item3 });
		_heightLocExpression.LocalizeInto(_currentHeightProgress);
	}

	private void LocalizeCheckpoint()
	{
		int checkpointId = CheckpointManager.ActiveCheckpoint.checkpointId;
		List<int> seenCheckpoints = CheckpointManager.GetSeenCheckpoints();
		int num;
		if (seenCheckpoints.Count <= 0)
		{
			num = 0;
		}
		else
		{
			num = seenCheckpoints[seenCheckpoints.Count - 1];
		}
		int num2 = num;
		_maxCheckpoint = CheckpointManager.CheckpointData.levelCheckpointDatas.OrderBy((CheckpointData.LevelCheckpointData x) => x.checkpointId).Last().checkpointId;
		LocTerm item = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _checkpointLocString.mTerm);
		LocTerm item2 = _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, ": ");
		LocTerm item3 = _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, $"{checkpointId}/{_maxCheckpoint}");
		_checkpointLocExpression = new MultiTermLocExpression(new List<LocTerm> { item, item2, item3 });
		_checkpointLocExpression.LocalizeInto(_currentCheckpointProgress);
		LocTerm item4 = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _personalBestLocString.mTerm);
		LocTerm item5 = _localizedStringFactory.Create(LocTerm.LocalizationType.NonLocalized, $"{num2}/{_maxCheckpoint}");
		_personalBestLocExpression = new MultiTermLocExpression(new List<LocTerm> { item4, item2, item5 });
		_personalBestLocExpression.LocalizeInto(_personalBest);
	}
}
