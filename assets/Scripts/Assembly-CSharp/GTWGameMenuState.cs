using FMOD.Studio;
using Isto.Core;
using Isto.Core.Audio;
using Isto.Core.Game;
using Isto.Core.StateMachine;
using Isto.Core.UI;
using Isto.GTW;
using Isto.GTW.Audio;
using Isto.GTW.Configuration;
using Isto.GTW.Managers;
using Isto.GTW.Player;
using Isto.GTW.Providers;
using Isto.GTW.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GTWGameMenuState : UISimpleGameMenuState
{
	public MonoState levelSelectSubMenu;

	public Button saveSplitsButton;

	public Button levelSelectButton;

	private GTWGameSounds _sounds;

	private GTWGameState _gtwGameState;

	private TimeManager _timeManager;

	private PlayerController _playerController;

	private GTWProgressProvider _gameProgressProvider;

	private DoinklerLevelVariables _doinklerLevelVariables;

	private IDoinklerWorldDefinitionProvider _doinklerWorldDefinitionProvider;

	[Inject]
	private void Inject(IGameSounds sounds, GTWGameState gtwGameState, TimeManager timeManager, PlayerController playerController, IGameProgressProvider gameProgressProvider, [Inject(Optional = true)] DoinklerLevelVariables doinklerLevelVariables, IDoinklerWorldDefinitionProvider doinklerWorldDefinitionProvider)
	{
		_sounds = sounds as GTWGameSounds;
		_gtwGameState = gtwGameState;
		_timeManager = timeManager;
		_playerController = playerController;
		_gameProgressProvider = gameProgressProvider as GTWProgressProvider;
		_doinklerLevelVariables = doinklerLevelVariables;
		_doinklerWorldDefinitionProvider = doinklerWorldDefinitionProvider;
	}

	public override void Enter(MonoStateMachine controller)
	{
		base.Enter(controller);
		DialogueManager.instance.Pause();
		_sounds.SetGameplaySoundsPaused(isPaused: true);
	}

	public override void Exit(MonoStateMachine controller)
	{
		base.Exit(controller);
		DialogueManager.instance.Unpause();
		_sounds.SetGameplaySoundsPaused(isPaused: false);
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		if (previousState is UIModalChoicePopup)
		{
			_inSubState = false;
			if (_previousSelection != null && !_controls.UsingJoystick())
			{
				_previousSelection = null;
			}
			StartCoroutine(UIUtils.SetCanvasAlpha(canvasGroup, 1f, 0f, interactable: true, GetCurrentSelectable()));
		}
		else if (previousState == levelSelectSubMenu)
		{
			_inSubState = false;
			if (_previousSelection != null && !_controls.UsingJoystick())
			{
				_previousSelection = null;
			}
			StartCoroutine(UIUtils.SetCanvasAlpha(canvasGroup, 1f, Constants.CANVAS_FADE_TIME, interactable: true, GetCurrentSelectable()));
		}
		else
		{
			base.ReturnFromSubState(controller, previousState);
		}
	}

	public void Button_OnSaveSplits()
	{
		_inSubState = true;
		Events.RaiseEvent("SaveSpeedrunButtonClicked");
	}

	public void Button_OnLevelSelect()
	{
		if (_mainMenu.CurrentState != levelSelectSubMenu)
		{
			_inSubState = true;
			_mainMenu.EnterSubState(levelSelectSubMenu);
			_controls.DisableControls(Constants.CANVAS_FADE_TIME);
		}
	}

	public override void HandleRestartClicked()
	{
		_sounds.StopAllSounds(STOP_MODE.IMMEDIATE);
		_sounds.StopAllEventInstances();
		base.HandleRestartClicked();
	}

	protected override void UpdateActiveButtons()
	{
		loadButton.gameObject.SetActive(value: false);
		saveButton.gameObject.SetActive(value: false);
		bool flag = IsRestartButtonAllowed();
		restartButton.interactable = flag;
		restartButton.gameObject.SetActive(flag);
		if (saveSplitsButton != null)
		{
			bool flag2 = IsSaveBestTimesButtonAllowed();
			saveSplitsButton.interactable = flag2;
			saveSplitsButton.gameObject.SetActive(flag2);
		}
		if (levelSelectButton != null)
		{
			bool flag3 = IsLevelSelectButtonAllowed();
			levelSelectButton.interactable = flag3;
			levelSelectButton.gameObject.SetActive(flag3);
		}
	}

	protected override bool IsRestartButtonAllowed()
	{
		bool flag = base.IsRestartButtonAllowed();
		if (flag)
		{
			flag = PlayerPrefs.GetInt(GTWUISettingsGameplaySubState.SHOW_RESTART_BUTTON_PREFS_KEY, GTWUISettingsGameplaySubState.DEFAULT_SHOW_RESTART_BUTTON) == 1;
		}
		return flag;
	}

	protected bool IsSaveBestTimesButtonAllowed()
	{
		return PlayerPrefs.GetInt(GTWUISettingsGameplaySubState.SHOW_SAVE_PB_BUTTON_PREFS_KEY, GTWUISettingsGameplaySubState.DEFAULT_SHOW_SAVE_PB_BUTTON) == 1;
	}

	protected bool IsLevelSelectButtonAllowed()
	{
		return _gtwGameState.IsDoinklerPortfolio;
	}

	protected override void QuitConfirmed()
	{
		if (_gtwGameState.GameLevelDefinition != null && _gtwGameState.GameLevelDefinition.saveOnQuit)
		{
			AutoSave();
		}
		_sounds.StopAllEventInstances();
		base.QuitConfirmed();
	}

	private void AutoSave()
	{
		int currentGameProgressLevel = _gameProgressProvider.GetCurrentGameProgressLevel();
		float gameSecondsElapsedInLevel = _gameProgressProvider.GetGameSecondsElapsedInLevel(currentGameProgressLevel);
		if (!_gtwGameState.IsDoinklerSpecial)
		{
			_gameProgressProvider.GameTime[currentGameProgressLevel] = 0f;
		}
		GTWGameLevelDefinition gTWGameLevelDefinition = _gtwGameState.GameLevelDefinition ?? _doinklerWorldDefinitionProvider.Current.GameLevels[currentGameProgressLevel];
		if (_doinklerLevelVariables != null)
		{
			float num = _doinklerLevelVariables.GetFloat(gTWGameLevelDefinition.UniqueIDTotal);
			_doinklerLevelVariables.SetFloat(gTWGameLevelDefinition.UniqueIDTotal, num + gameSecondsElapsedInLevel);
		}
		Debug.Log("ActivateCheckpointEvent.AutoSave()");
		Events.RaiseEvent("GameAutoSaving");
		int slotNumber = _gtwGameState.SaveSlot;
		_gameState.SelectSaveGame(slotNumber);
		_gameState.LoadGameStateData(null, -1);
		_gameData.SaveGameData(slotNumber, createBackup: false, (bool success) =>
		{
			if (success)
			{
				Events.RaiseEvent("GameSaved");
				_gameState.LoadSaveSlotMetaData(slotNumber, null);
			}
			else
			{
				Debug.LogError($"SaveGameData for slot#{slotNumber} has failed ");
			}
		}, async: false);
	}
}
