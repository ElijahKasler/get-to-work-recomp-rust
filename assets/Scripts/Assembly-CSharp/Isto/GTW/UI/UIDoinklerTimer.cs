using System;
using Isto.Core;
using Isto.Core.Game;
using Isto.GTW.Configuration;
using Isto.GTW.Managers;
using Isto.GTW.Providers;
using TMPro;
using UnityEngine;
using Zenject;

namespace Isto.GTW.UI;

public class UIDoinklerTimer : MonoBehaviour
{
	private bool _loadTargetTimesPending;

	private int _previousLevel;

	private int _currentLevel;

	private bool _isTimeOverride;

	[SerializeField]
	private TextMeshProUGUI _currentLevelTimer;

	[SerializeField]
	private TextMeshProUGUI _totalWorldTimer;

	private IDoinklerWorldDefinitionProvider _doinklerWorldDefinitionProvider;

	private IGameProgressProvider _gameProgress;

	private DoinklerLevelVariables _doinklerLevelVariables;

	[Inject]
	public void Inject(IGameProgressProvider gameProgress, IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider, DoinklerLevelVariables levelVariables)
	{
		_gameProgress = gameProgress;
		_doinklerWorldDefinitionProvider = doinklerWorldDefinitionProvider;
		_doinklerLevelVariables = levelVariables;
	}

	private void Update()
	{
		if (_gameProgress.GetCurrentGameProgressLevel() != -1)
		{
			UpdateTotalWorldTime();
			UpdateCurrentLevelTime();
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
		if (_isTimeOverride)
		{
			return;
		}
		float num = 0f;
		foreach (GTWGameLevelDefinition gameLevel in _doinklerWorldDefinitionProvider.Current.GameLevels)
		{
			num += _doinklerLevelVariables.GetFloat(gameLevel.UniqueIDTotal);
		}
		int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
		num += _gameProgress.GetGameSecondsElapsedInLevel(currentGameProgressLevel);
		TimeSpan timeSpan = TimeSpan.FromSeconds(num);
		_totalWorldTimer.text = UnityUtils.ConvertTimespanToTotalHoursMinutesSeconds(timeSpan);
	}

	private void UpdateCurrentLevelTime()
	{
		if (!_isTimeOverride)
		{
			int currentGameProgressLevel = _gameProgress.GetCurrentGameProgressLevel();
			TimeSpan timeSpan = TimeSpan.FromSeconds(_gameProgress.GetGameSecondsElapsedInLevel(currentGameProgressLevel));
			_currentLevelTimer.text = UnityUtils.ConvertTimespanToTotalHoursMinutesSeconds(timeSpan);
		}
	}
}
