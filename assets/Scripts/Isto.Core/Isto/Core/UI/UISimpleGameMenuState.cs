using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.Core.Scenes;
using Isto.Core.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UISimpleGameMenuState : MonoState
{
	public CanvasGroup canvasGroup;

	public Transform buttonsParent;

	public Button loadButton;

	public Button saveButton;

	public Button settingsButton;

	public Button restartButton;

	[Header("Confirm Dialogue")]
	[SerializeField]
	private UISimpleConfirmModalState _confirmationSubState;

	[Header("Sub State")]
	public MonoState settingsSubMenu;

	public CoreUISetSaveSlotSubState setSaveSlotState;

	[Space(20f)]
	[Range(0f, 1f)]
	public float mainCanvasFadeOutPercent = 0.3f;

	[SerializeField]
	private ScrollRect _saveListScrollRect;

	protected SimpleGameMenuStateMachine _mainMenu;

	private bool _exiting;

	private float _spamTimer;

	protected bool _inSubState;

	protected Selectable _previousSelection;

	protected IGameData _gameData;

	protected GameState _gameState;

	protected IControls _controls;

	protected GameScenesReference _coreGameScenesReference;

	private bool _subscribed;

	public UISimpleConfirmModalState QuitConfirmationPopUp => _confirmationSubState;

	[Inject]
	private void Inject(IGameData gameData, IControls controls, GameState gameState, GameScenesReference coreGameScenesReference)
	{
		_gameState = gameState;
		_gameData = gameData;
		_controls = controls;
		_coreGameScenesReference = coreGameScenesReference;
	}

	protected virtual void OnDestroy()
	{
		UnregisterEvents();
	}

	public override void Enter(MonoStateMachine controller)
	{
		Debug.Log("SpeedrunMode - Game paused");
		_controls.SetControlMode(Controls.Mode.UI);
		_mainMenu = controller as SimpleGameMenuStateMachine;
		if ((bool)_saveListScrollRect)
		{
			_saveListScrollRect.enabled = true;
		}
		UpdateActiveButtons();
		UpdateButtonNavigation();
		_previousSelection = null;
		StartCoroutine(UIUtils.SetCanvasAlpha(canvasGroup, 1f, Constants.CANVAS_FADE_TIME, interactable: true, GetCurrentSelectable()));
		Time.timeScale = 0f;
		_exiting = false;
		_spamTimer = 0f - Constants.BUTTON_SPAM_DELAY;
		GlobalGameplayEvents.OnMenuInteraction(this, GameMenusEnum.GAME, MenuInteractionEventArgs.Action.Open);
		RegisterEvents();
	}

	public override void Exit(MonoStateMachine controller)
	{
		Debug.Log("SpeedrunMode - Game unpaused");
		UnregisterEvents();
		StartCoroutine(UIUtils.SetCanvasAlpha(canvasGroup, 0f, Constants.CANVAS_FADE_TIME, interactable: false));
		Time.timeScale = 1f;
		GlobalGameplayEvents.OnMenuInteraction(this, GameMenusEnum.GAME, MenuInteractionEventArgs.Action.Close);
		if ((bool)_saveListScrollRect)
		{
			_saveListScrollRect.enabled = false;
		}
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		_spamTimer += Time.unscaledDeltaTime;
		if (_spamTimer < Constants.BUTTON_SPAM_DELAY)
		{
			return this;
		}
		if (_controls.GetButtonDown(UserActions.UICANCEL) || _controls.GetButtonDown(UserActions.PAUSE) || _controls.GetButtonDown(UserActions.TOGGLEGAMEMENU))
		{
			_mainMenu.CloseMenu();
			_exiting = true;
		}
		return this;
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		_inSubState = false;
		UpdateActiveButtons();
		UpdateButtonNavigation();
		if (_previousSelection != null && !_controls.UsingJoystick())
		{
			_previousSelection = null;
		}
		if (previousState == settingsSubMenu)
		{
			StartCoroutine(UIUtils.SetCanvasAlpha(canvasGroup, 1f, Constants.CANVAS_FADE_TIME, interactable: true, GetCurrentSelectable()));
			return;
		}
		if (previousState is IStateExitResult { Result: IStateExitResult.ResultType.Cancelled })
		{
			StartCoroutine(UIUtils.SetCanvasAlpha(canvasGroup, 1f, Constants.CANVAS_FADE_TIME, interactable: true, GetCurrentSelectable()));
			return;
		}
		ExitingMenuCleanup();
		_mainMenu.ExitSubState();
		_exiting = true;
	}

	protected virtual void RegisterEvents()
	{
		if (!_subscribed)
		{
			Events.Subscribe("InputChanged", Events_OnInputModeChanged);
			_subscribed = true;
		}
	}

	protected virtual void UnregisterEvents()
	{
		if (_subscribed)
		{
			Events.UnSubscribe("InputChanged", Events_OnInputModeChanged);
			_subscribed = false;
		}
	}

	private void Events_OnInputModeChanged()
	{
		if (!_exiting && !_inSubState && !(_mainMenu.CurrentState != this))
		{
			if (_controls.UsingJoystick())
			{
				GetCurrentSelectable().Select();
			}
			else if (EventSystem.current.currentSelectedGameObject != null)
			{
				EventSystem.current.SetSelectedGameObject(null);
			}
		}
	}

	public virtual void HandleSaveClicked()
	{
		if (!_inSubState)
		{
			_inSubState = true;
			StartCoroutine(UIUtils.SetCanvasAlpha(canvasGroup, mainCanvasFadeOutPercent, Constants.CANVAS_FADE_TIME, interactable: false));
			setSaveSlotState.SetMenuMode(CoreUISetSaveSlotSubState.MenuMode.Save);
			_mainMenu.EnterSubState(setSaveSlotState);
			_controls.DisableControls(Constants.CANVAS_FADE_TIME);
			_previousSelection = saveButton;
		}
	}

	public virtual void HandleLoadClicked()
	{
		if (!_inSubState)
		{
			_inSubState = true;
			StartCoroutine(UIUtils.SetCanvasAlpha(canvasGroup, mainCanvasFadeOutPercent, Constants.CANVAS_FADE_TIME, interactable: false));
			setSaveSlotState.SetMenuMode(CoreUISetSaveSlotSubState.MenuMode.Load);
			_mainMenu.EnterSubState(setSaveSlotState);
			_controls.DisableControls(Constants.BUTTON_SPAM_DELAY);
			_previousSelection = loadButton;
		}
	}

	public virtual void HandleRestartClicked()
	{
		if (!_exiting)
		{
			ExitingMenuCleanup();
			_gameState.StartGameMode(_gameState.CurrentGameMode);
		}
	}

	public virtual void HandleSettingsClicked()
	{
		if (_mainMenu.CurrentState == _confirmationSubState)
		{
			_confirmationSubState.CancelClicked();
		}
		if (_mainMenu.CurrentState != settingsSubMenu)
		{
			_mainMenu.EnterSubState(settingsSubMenu);
			_controls.DisableControls(Constants.CANVAS_FADE_TIME);
			_previousSelection = settingsButton;
		}
	}

	public virtual void QuitGame()
	{
		if (!_exiting && !(_mainMenu.CurrentState == _confirmationSubState))
		{
			_confirmationSubState.SetCallbacks(QuitConfirmed, null);
			_mainMenu.EnterSubState(_confirmationSubState);
		}
	}

	protected virtual void UpdateActiveButtons()
	{
		loadButton.interactable = false;
		saveButton.interactable = !(_gameState.CurrentGameMode != null) || _gameState.CurrentGameMode.CanSaveGame;
		bool flag = IsRestartButtonAllowed();
		restartButton.interactable = flag;
		restartButton.gameObject.SetActive(flag);
		_gameData.HasAnySaveData((bool dataExists) =>
		{
			bool flag2 = dataExists && (!(_gameState.CurrentGameMode != null) || _gameState.CurrentGameMode.CanLoadGame);
			if (loadButton.interactable != flag2)
			{
				loadButton.interactable = flag2;
				UpdateButtonNavigation();
			}
		});
	}

	protected virtual bool IsRestartButtonAllowed()
	{
		if (!(_gameState.CurrentGameMode != null))
		{
			return false;
		}
		return _gameState.CurrentGameMode.ShowRestartButton;
	}

	private void UpdateButtonNavigation()
	{
		Button target = null;
		for (int i = 0; i < buttonsParent.childCount; i++)
		{
			Button component = buttonsParent.GetChild(i).GetComponent<Button>();
			if (!(component != null) || !component.interactable)
			{
				continue;
			}
			UIUtils.SetNavigation(component, UIUtils.NavigationDirection.Up, target);
			for (int j = i + 1; j < buttonsParent.childCount; j++)
			{
				Button component2 = buttonsParent.GetChild(j).GetComponent<Button>();
				if (component2 != null && component2.interactable)
				{
					UIUtils.SetNavigation(component, UIUtils.NavigationDirection.Down, component2);
					break;
				}
			}
			target = component;
		}
	}

	protected Selectable GetCurrentSelectable()
	{
		if (_previousSelection != null)
		{
			return _previousSelection;
		}
		Selectable selectable = null;
		if (!(_gameState.CurrentGameMode != null) || _gameState.CurrentGameMode.CanSaveGame)
		{
			return saveButton;
		}
		if ((!(_gameState.CurrentGameMode != null) || _gameState.CurrentGameMode.CanLoadGame) & loadButton.interactable)
		{
			return loadButton;
		}
		return settingsButton;
	}

	protected virtual void QuitConfirmed()
	{
		ExitingMenuCleanup();
		_gameState.LoadScene(_coreGameScenesReference.TitleScreen);
	}

	protected virtual void ExitingMenuCleanup()
	{
		Time.timeScale = 1f;
		_exiting = true;
	}
}
