using System;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using Isto.Core;
using Isto.Core.Audio;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.StateMachine;
using Isto.Core.UI;
using Isto.GTW.Configuration;
using Isto.GTW.LevelFeatures;
using Isto.GTW.Managers;
using Isto.GTW.Providers;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.GTW.UI;

public class GTWUINextLevelPopup : MonoState
{
	[Header("Canvas")]
	[SerializeField]
	private CanvasGroup _canvasGroup;

	[Header("Unity Hookup")]
	[SerializeField]
	private TextMeshProUGUI _panelHeaderLabel;

	[SerializeField]
	private TextMeshProUGUI _levelTitleLabel;

	[SerializeField]
	private TextMeshProUGUI _worldTitleLabel;

	[SerializeField]
	private Image _selectedLevelImage;

	[SerializeField]
	private TextMeshProUGUI _timeLabel;

	[SerializeField]
	private TextMeshProUGUI _totalTimeLabel;

	[SerializeField]
	private TextMeshProUGUI _bestTimeLabel;

	[SerializeField]
	private GameObject _newBestTimeLabel;

	[SerializeField]
	private Image _progressCircleCurrentFile;

	[SerializeField]
	private TextMeshProUGUI _progressLabelCurrentFile;

	[SerializeField]
	private LocalizationParamsManager _progressLabelCurrentFileNameParam;

	[SerializeField]
	private Image _progressCircleAudioFilesHeard;

	[SerializeField]
	private TextMeshProUGUI _progressLabelAudioFilesHeard;

	[SerializeField]
	private Image _progressCircleTotalProgress;

	[SerializeField]
	private TextMeshProUGUI _progressLabelTotalProgress;

	[Header("Buttons")]
	[SerializeField]
	private CoreButtonController _nextLevelButton;

	[SerializeField]
	private CoreButtonController _retryLevelButton;

	[SerializeField]
	private CoreButtonController _levelSelectButton;

	[SerializeField]
	private CoreButtonController _quitToMainButton;

	[Header("Doinkler Data Hookup")]
	[SerializeField]
	private UIDoinklerPortfolio _doinklerLevelSelectSubState;

	[SerializeField]
	private DialogueDatabase _doinklerDialogueDatabase;

	[SerializeField]
	private GTWDoinklerPortfolioDefinition _doinklerPortfolioDefinition;

	private GameObject _previousSelection;

	private GTWGameLevelDefinition _currentLevel;

	private GTWGameLevelDefinition _nextLevel;

	private MonoPushdownStateMachine _menuController;

	private bool _isOpen;

	private Action _onRespawn;

	private IControls _controls;

	private UISounds _uiSounds;

	private GTWGameState _gameState;

	private IGameData _gameData;

	private CheckpointManager _checkpointManager;

	private GTWProgressProvider _gameProgressProvider;

	private LevelVariables _levelVariables;

	private DoinklerLevelVariables _doinklerLevelVariables;

	private IDoinklerWorldDefinitionProvider _doinklerWorldDefinitionProvider;

	private LocTerm.Factory _localizedStringFactory;

	public bool IsOpen => _isOpen;

	[Inject]
	public void Inject(IControls controls, UISounds uiSounds, GTWGameState gameState, CheckpointManager checkpointManager, IGameProgressProvider gameProgressProvider, LevelVariables levelVariables, IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider, DoinklerLevelVariables doinklerLevelVariables, LocTerm.Factory localizedStringFactory, IGameData gameData)
	{
		_controls = controls;
		_uiSounds = uiSounds;
		_gameState = gameState;
		_checkpointManager = checkpointManager;
		_gameProgressProvider = gameProgressProvider as GTWProgressProvider;
		_levelVariables = levelVariables;
		_doinklerWorldDefinitionProvider = doinklerWorldDefinitionProvider;
		_localizedStringFactory = localizedStringFactory;
		_doinklerLevelVariables = doinklerLevelVariables;
		_gameData = gameData;
	}

	private void Awake()
	{
		ClosePopup();
	}

	private void OnDestroy()
	{
		Events.UnSubscribe("InputChanged", Events_OnInputModeChanged);
	}

	public override void Enter(MonoStateMachine controller)
	{
		_menuController = controller as MonoPushdownStateMachine;
		_previousSelection = (Controls.UsingController ? EventSystem.current.currentSelectedGameObject : null);
		int currentGameProgressLevel = _gameProgressProvider.GetCurrentGameProgressLevel();
		float gameSecondsElapsedInLevel = _gameProgressProvider.GetGameSecondsElapsedInLevel(currentGameProgressLevel);
		if ((bool)_nextLevel && _nextLevel.CheckpointNumber > currentGameProgressLevel)
		{
			_checkpointManager.SetActiveCheckpoint(_checkpointManager.CheckpointData.levelCheckpointDatas[_nextLevel.CheckpointNumber]);
			_checkpointManager.SetActiveCheckpoint(_checkpointManager.CheckpointData.levelCheckpointDatas[_currentLevel.CheckpointNumber]);
		}
		float completedLevelsInFilePercentage = GetCompletedLevelsInFilePercentage(_doinklerWorldDefinitionProvider.Current);
		_progressCircleCurrentFile.fillAmount = completedLevelsInFilePercentage;
		_progressLabelCurrentFile.text = completedLevelsInFilePercentage.ToString("P0");
		LocalizationParamsManager progressLabelCurrentFileNameParam = _progressLabelCurrentFileNameParam;
		int saveSlotId = (int)_doinklerWorldDefinitionProvider.Current.SaveSlotId;
		progressLabelCurrentFileNameParam.SetParameterValue("0", saveSlotId.ToString());
		float activatedDoinklerDialoguesPercentage = GetActivatedDoinklerDialoguesPercentage();
		_progressCircleAudioFilesHeard.fillAmount = activatedDoinklerDialoguesPercentage;
		_progressLabelAudioFilesHeard.text = activatedDoinklerDialoguesPercentage.ToString("P0");
		float completedLevelsInDoinklerPercentage = GetCompletedLevelsInDoinklerPercentage();
		_progressCircleTotalProgress.fillAmount = completedLevelsInDoinklerPercentage;
		_progressLabelTotalProgress.text = completedLevelsInDoinklerPercentage.ToString("P0");
		_timeLabel.SetText(GTWUtils.GetFormattedTimeOrDefaultString(gameSecondsElapsedInLevel, greyOutZeros: false));
		float num = _doinklerLevelVariables.GetFloat(_currentLevel.UniqueIDBest);
		float inputTime = _doinklerLevelVariables.GetFloat(_currentLevel.UniqueIDTotal);
		_newBestTimeLabel.SetActive(gameSecondsElapsedInLevel.Equals(num));
		_bestTimeLabel.SetText(GTWUtils.GetFormattedTimeOrDefaultString(num, greyOutZeros: false));
		_totalTimeLabel.SetText(GTWUtils.GetFormattedTimeOrDefaultString(inputTime, greyOutZeros: false));
		if (!string.IsNullOrEmpty(_currentLevel.LevelName.mTerm))
		{
			_localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _currentLevel.LevelName.mTerm).LocalizeInto(_levelTitleLabel);
		}
		else
		{
			_levelTitleLabel.SetText(_currentLevel.fallbackLevelName);
		}
		if (!string.IsNullOrEmpty(_doinklerWorldDefinitionProvider.Current.WorldTitle.mTerm))
		{
			_localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _doinklerWorldDefinitionProvider.Current.WorldTitle.mTerm).LocalizeInto(_worldTitleLabel);
		}
		_selectedLevelImage.sprite = _currentLevel.LevelImage;
		if ((bool)_nextLevel)
		{
			_nextLevelButton.GetSelectable().Select();
		}
		else
		{
			_retryLevelButton.GetSelectable().Select();
		}
		RegisterEvents();
	}

	public override void Exit(MonoStateMachine controller)
	{
		UnregisterEvents();
		Time.timeScale = 1f;
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		return this;
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		OpenPopup();
		if (previousState == _doinklerLevelSelectSubState)
		{
			_nextLevelButton.Select();
		}
	}

	protected void RegisterEvents()
	{
		Events.Subscribe("InputChanged", Events_OnInputModeChanged);
	}

	protected void UnregisterEvents()
	{
		Events.UnSubscribe("InputChanged", Events_OnInputModeChanged);
	}

	private void Events_OnInputModeChanged()
	{
		if (_controls.UsingJoystick())
		{
			_nextLevelButton.Select();
		}
		else if (!_controls.UsingJoystick() && EventSystem.current.currentSelectedGameObject != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	public void Button_NextLevel()
	{
		ClosePopup();
		RestoreUIContext();
		if (_nextLevel.gameMode.InternalName != _currentLevel.gameMode.InternalName)
		{
			StartNextWorldLevel();
			return;
		}
		_gameState.GameLevelDefinition = _nextLevel;
		_checkpointManager.SetActiveCheckpoint(_checkpointManager.CheckpointData.levelCheckpointDatas[_nextLevel.CheckpointNumber]);
		Events.RaiseEvent(GTWEvents.DOINKLER_STAGE_RESET, args: false);
		_onRespawn?.Invoke();
	}

	public void Button_RetryLevel()
	{
		ClosePopup();
		RestoreUIContext();
		if (_gameProgressProvider.GameEnded)
		{
			DialogueManager.ResetDatabase(DatabaseResetOptions.KeepAllLoaded);
		}
		Events.RaiseEvent(GTWEvents.DOINKLER_STAGE_RESET, args: false);
		_onRespawn?.Invoke();
	}

	public void Button_LevelSelect()
	{
		ClosePopup();
		_menuController.EnterSubState(_doinklerLevelSelectSubState);
	}

	public void Button_QuitToMain()
	{
		ClosePopup();
		RestoreUIContext();
		_gameState.LoadTitleScene();
	}

	public void SetLevelDefinitionData(GTWGameLevelDefinition currentLevel, GTWGameLevelDefinition nextLevel, Action onRespawn)
	{
		_currentLevel = currentLevel;
		_nextLevel = nextLevel;
		_onRespawn = onRespawn;
		OpenPopup();
		StealUIContext();
	}

	private float GetActivatedDoinklerDialoguesPercentage()
	{
		int count = _levelVariables.boolVariables.Count;
		int num = _levelVariables.boolVariables.Count((KeyValuePair<string, bool> x) => x.Value);
		float result = 0f;
		if (num != 0)
		{
			result = (float)num / (float)count;
		}
		return result;
	}

	private float GetCompletedLevelsInFilePercentage(GTWGameWorldDefinition gtwGameWorldDefinition)
	{
		int count = gtwGameWorldDefinition.GameLevels.Count;
		int num = 0;
		foreach (GTWGameLevelDefinition gameLevel in gtwGameWorldDefinition.GameLevels)
		{
			if (gameLevel.IsCompleted)
			{
				num++;
			}
		}
		float result = 0f;
		if (num != 0)
		{
			result = (float)num / (float)count;
		}
		return result;
	}

	private float GetCompletedLevelsInDoinklerPercentage()
	{
		int num = _doinklerPortfolioDefinition.GTWGameWorldDefinitions.Sum((GTWGameWorldDefinition x) => x.GameLevels.Count);
		int num2 = 0;
		foreach (GTWGameWorldDefinition gTWGameWorldDefinition in _doinklerPortfolioDefinition.GTWGameWorldDefinitions)
		{
			foreach (GTWGameLevelDefinition gameLevel in gTWGameWorldDefinition.GameLevels)
			{
				if (_doinklerLevelVariables.GetBool(gameLevel.UniqueIDCompleted))
				{
					num2++;
				}
			}
		}
		float result = 0f;
		if (num2 != 0)
		{
			result = (float)num2 / (float)num;
		}
		return result;
	}

	private void OpenPopup()
	{
		_canvasGroup.alpha = 1f;
		_canvasGroup.interactable = true;
		_canvasGroup.blocksRaycasts = true;
		_isOpen = true;
		_nextLevelButton.GetSelectable().interactable = _nextLevel;
	}

	private void ClosePopup()
	{
		_canvasGroup.alpha = 0f;
		_canvasGroup.interactable = false;
		_canvasGroup.blocksRaycasts = false;
		_isOpen = false;
	}

	private void RestoreUIContext()
	{
		Time.timeScale = 1f;
		_controls.SetControlMode(Controls.Mode.Gameplay);
		_menuController.ExitSubState();
		if (Controls.UsingController && _previousSelection != null)
		{
			EventSystem.current.SetSelectedGameObject(_previousSelection);
		}
	}

	private void StealUIContext()
	{
		if (_controls.GetControlMode() != Controls.Mode.UI)
		{
			_controls.SetControlMode(Controls.Mode.UI);
		}
		Time.timeScale = 0f;
	}

	private void StartNextWorldLevel()
	{
		GTWGameWorldDefinition gTWGameWorldDefinition = null;
		foreach (GTWGameWorldDefinition gTWGameWorldDefinition2 in _doinklerPortfolioDefinition.GTWGameWorldDefinitions)
		{
			foreach (GTWGameLevelDefinition gameLevel in gTWGameWorldDefinition2.GameLevels)
			{
				if (gameLevel.UniqueID == _nextLevel.UniqueID)
				{
					gTWGameWorldDefinition = gTWGameWorldDefinition2;
					break;
				}
			}
		}
		if (gTWGameWorldDefinition == null)
		{
			Debug.LogError("Next Level Popup: Could not find world definition for next level " + _nextLevel.UniqueID + "!");
			Button_LevelSelect();
			return;
		}
		_doinklerWorldDefinitionProvider.Current = gTWGameWorldDefinition;
		_nextLevel = _doinklerWorldDefinitionProvider.Current.GameLevels.First((GTWGameLevelDefinition x) => x.UniqueID == _nextLevel.UniqueID);
		_gameState.GameLevelDefinition = _nextLevel;
		int saveSlot = (int)_doinklerWorldDefinitionProvider.Current.SaveSlotId;
		_gameData.HasSaveData(saveSlot, (bool dataExists) =>
		{
			_gameState.SaveSlot = saveSlot;
			if (dataExists)
			{
				_gameState.LoadSaveSlotMetaData(saveSlot, (bool gameStateData) =>
				{
					_gameState.LoadSaveGame(saveSlot);
				});
			}
			else
			{
				_gameState.StartGameMode(_nextLevel.gameMode);
			}
		});
	}
}
