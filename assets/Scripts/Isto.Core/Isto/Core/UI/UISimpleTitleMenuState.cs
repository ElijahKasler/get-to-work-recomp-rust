using System;
using System.Collections;
using System.Collections.Generic;
using Isto.Core.Analytics;
using Isto.Core.Audio;
using Isto.Core.Cheats;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.StateMachine;
using Isto.Core.Themes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UISimpleTitleMenuState : MonoState
{
	[Header("Menu Parts")]
	public CanvasGroup canvas_Title;

	public CanvasGroup canvas_FadeOut;

	public float fadeTime = 1f;

	public Selectable startFocusObject;

	public GameObject quickPatchNotesRoot;

	public GameObject discordQRCode;

	[Header("Menu Navigation")]
	public Button newGameButton;

	public Button loadButton;

	public Button settingsButton;

	public Button creditsButton;

	public Button quitButton;

	public Button patchNotesButton;

	public Button latestVlogButton;

	public Button discordButton;

	[Header("Sub Menus")]
	public CoreUISetGameModeSubState gameModeSubstate;

	public CoreUISetSaveSlotSubState saveSlotSubstate;

	public UISettingsMenuState settingsSubState;

	public CoreUICreditsMenuState creditsSubState;

	public UISimpleConfirmModalState confirmOpenBrowserState;

	[Header("Feedback")]
	public string feedbackUrl;

	protected MonoPushdownStateMachine _controller;

	protected Selectable _previousSelection;

	private List<Selectable> _controllerNavigation = new List<Selectable>();

	protected IControls _controls;

	protected IGameData _gameData;

	protected IAnalyticsHandler _analytics;

	protected GameState _gameState;

	protected UISounds _uiSounds;

	protected ThemeManager _themeManager;

	protected UserKeybindingDataStore _controlsDataStore;

	[Inject]
	private void Inject(IControls controls, IGameData gameData, IAnalyticsHandler analytics, GameState gameState, UISounds uISounds, ThemeManager themeManager, UserKeybindingDataStore dataStore)
	{
		_controls = controls;
		_gameData = gameData;
		_analytics = analytics;
		_gameState = gameState;
		_uiSounds = uISounds;
		_themeManager = themeManager;
		_controlsDataStore = dataStore;
	}

	private void Awake()
	{
		InitializeButtonsForNavigation();
		UIUtils.SetupVerticalButtonsNavigation(_controllerNavigation);
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	public override void Enter(MonoStateMachine controller)
	{
		_controller = controller as MonoPushdownStateMachine;
		_previousSelection = newGameButton;
		SetupLoadButton();
		UpdateTheme();
		RegisterEvents();
		if (_controls.UsingJoystick())
		{
			startFocusObject.Select();
		}
		SetupControls();
		_controls.SetControlMode(Controls.Mode.UI);
		_gameState.CurrentGameMode = null;
	}

	public override void Exit(MonoStateMachine controller)
	{
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		return this;
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		_uiSounds.PlayButtonClickSound();
		SetupLoadButton();
		if (previousState == gameModeSubstate && gameModeSubstate.ExitMode == CoreUISetGameModeSubState.MenuExitMode.Confirm)
		{
			StartGameButtonClicked(gameModeSubstate.SelectedGameMode);
			return;
		}
		if (Controls.UsingController)
		{
			EventSystem.current.SetSelectedGameObject(_previousSelection.gameObject);
		}
		else
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
		StartCoroutine(UIUtils.SetCanvasAlpha(canvas_Title, 1f, Constants.CANVAS_FADE_TIME, interactable: true));
	}

	protected virtual void RegisterEvents()
	{
		Events.Subscribe("ThemeChanged", Events_OnThemeChanged);
		Events.Subscribe("InputChanged", Events_OnInputModeChanged);
	}

	protected virtual void UnregisterEvents()
	{
		Events.UnSubscribe("ThemeChanged", Events_OnThemeChanged);
		Events.UnSubscribe("InputChanged", Events_OnInputModeChanged);
	}

	protected void Events_OnThemeChanged()
	{
		UpdateTheme();
	}

	private void Events_OnInputModeChanged()
	{
		if (_controller.GetCurrentState() != this)
		{
			return;
		}
		if (_controls.UsingJoystick())
		{
			if (EventSystem.current.currentSelectedGameObject == null)
			{
				if (_previousSelection != null)
				{
					_previousSelection.Select();
				}
				else
				{
					startFocusObject.Select();
				}
			}
		}
		else if (EventSystem.current.currentSelectedGameObject != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	protected void Events_OnUserChanged()
	{
		SetupLoadButton();
	}

	public void NewGameButtonClicked()
	{
		_previousSelection = newGameButton;
		CloseAllStatesAndEnterNewState(gameModeSubstate);
	}

	public void StartGameButtonClicked(GameModeDefinition gameMode)
	{
		StartCoroutine(UIUtils.SetCanvasAlpha(canvas_Title, 0f, fadeTime, interactable: false));
		StartCoroutine(UIUtils.SetCanvasAlpha(canvas_FadeOut, 1f, fadeTime, interactable: false));
		StartCoroutine(WaitToExitTitleScreen(fadeTime, gameMode));
	}

	public void RunTestsButtonClicked()
	{
		Debug.LogError("No default test to run right now.");
	}

	public void GCCollectButtonClicked()
	{
		GC.Collect();
	}

	public void DowngradeSaveButtonClicked()
	{
		_gameData.LoadGameMetaData(0, (GameStateSaveData data) =>
		{
			data.gameVersion = "0.0.1";
			_gameData.SaveGameMetaData(0, data, (bool success) =>
			{
				Debug.LogError("Made save slot #0 into a fake 0.0.1 save file!");
			});
		});
	}

	public void GetRemainingDataButtonClicked()
	{
		Debug.LogError("Sending GetRemainingSaveFileSpace request...");
		_gameData.GetRemainingSaveFileSpace((long size) =>
		{
			Debug.Log("got callback for remaining file space size = " + Loc.GetFileSizeLocalizedAndFormated(size));
		});
	}

	public void QuitButtonClicked()
	{
		Application.Quit();
	}

	public void LoadButtonClicked()
	{
		MonoState currentState = _controller.GetCurrentState();
		if (currentState != saveSlotSubstate)
		{
			while (currentState != this && currentState != null)
			{
				_controller.ExitSubState();
				currentState = _controller.GetCurrentState();
			}
			_previousSelection = loadButton;
			saveSlotSubstate.SetMenuMode(CoreUISetSaveSlotSubState.MenuMode.Load);
			_controller.EnterSubState(saveSlotSubstate);
		}
		_analytics.RegisterMenuPageVisited("Load Menu");
	}

	public void ClearSaveButtonClicked()
	{
		_gameData.ClearAllSaveData((bool success) =>
		{
			loadButton.interactable = !success;
		});
	}

	public void ClearPlayerPrefsButtonClicked()
	{
		PlayerPrefs.DeleteAll();
	}

	public void FeedbackButtonClicked()
	{
		Application.OpenURL(feedbackUrl);
		_analytics.RegisterMenuPageVisited("Feedback");
	}

	public void SettingsButtonClicked()
	{
		_previousSelection = settingsButton;
		CloseAllStatesAndEnterNewState(settingsSubState);
		_analytics.RegisterMenuPageVisited("Settings");
	}

	public void CreditsButtonClicked()
	{
		_previousSelection = creditsButton;
		CloseAllStatesAndEnterNewState(creditsSubState);
		_analytics.RegisterMenuPageVisited("Credits");
	}

	public virtual void PatchNotesButtonClicked()
	{
		OpenPatchNotesURL();
	}

	public void VlogButtonClicked()
	{
		_analytics.RegisterMenuPageVisited("Latest Vlog");
	}

	public void ClearNotificationsButtonClicked()
	{
		_analytics.RegisterMenuPageVisited("Clear Notifications");
	}

	private void InitializeButtonsForNavigation()
	{
		_controllerNavigation.Clear();
		if (newGameButton.gameObject.activeSelf)
		{
			_controllerNavigation.Add(newGameButton);
		}
		if (loadButton.gameObject.activeSelf)
		{
			_controllerNavigation.Add(loadButton);
		}
		if (settingsButton.gameObject.activeSelf)
		{
			_controllerNavigation.Add(settingsButton);
		}
		if (creditsButton.gameObject.activeSelf)
		{
			_controllerNavigation.Add(creditsButton);
		}
		if (quitButton.gameObject.activeSelf)
		{
			_controllerNavigation.Add(quitButton);
		}
		if (patchNotesButton.gameObject.activeSelf)
		{
			_controllerNavigation.Add(patchNotesButton);
		}
		if (latestVlogButton.gameObject.activeSelf)
		{
			_controllerNavigation.Add(latestVlogButton);
		}
		if (discordButton.gameObject.activeSelf)
		{
			_controllerNavigation.Add(discordButton);
		}
	}

	private IEnumerator WaitToExitTitleScreen(float time, GameModeDefinition gameMode)
	{
		CheatCodeDetector.CheatsBlocked = true;
		yield return new WaitForSeconds(time);
		_gameState.StartGameMode(gameMode);
		CheatCodeDetector.CheatsBlocked = false;
	}

	protected void OpenPatchNotesURL()
	{
		Application.OpenURL("https://store.steampowered.com/news/app/1125390");
		_analytics.RegisterMenuPageVisited("Patch Notes");
	}

	protected virtual void SetupLoadButton()
	{
		SetLoadButton(interactable: false);
		_gameData.HasAnySaveData((bool dataExists) =>
		{
			SetLoadButton(dataExists);
		});
	}

	protected virtual void SetLoadButton(bool interactable)
	{
		loadButton.interactable = interactable;
	}

	private void SetupControls()
	{
		_controlsDataStore.Load();
	}

	protected void CloseAllStatesAndEnterNewState(MonoState nextState)
	{
		_controls.DisableControls(0.25f);
		MonoState currentState = _controller.GetCurrentState();
		if (currentState != nextState)
		{
			while (currentState != this && currentState != null)
			{
				_controller.ExitSubState();
				currentState = _controller.GetCurrentState();
			}
			_controller.EnterSubState(nextState);
		}
	}

	protected virtual void UpdateTheme()
	{
	}
}
