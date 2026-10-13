using System.Collections.Generic;
using System.Linq;
using Isto.Core.Configuration;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class CoreUISetGameModeSubState : MonoState
{
	public enum MenuExitMode
	{
		Confirm = 0,
		Cancel = 1
	}

	public CanvasGroup canvasGroup;

	public Transform modeButtonsParent;

	private MonoPushdownStateMachine _mainMenu;

	private List<Selectable> _gameModeButtons;

	private Selectable _firstSelection;

	protected IControls _controls;

	private bool _eventsRegistered;

	public MenuExitMode ExitMode { get; private set; }

	public GameModeDefinition SelectedGameMode { get; private set; }

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	private void Awake()
	{
		InitializeButtonsForNavigation();
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	public override void Enter(MonoStateMachine controller)
	{
		_mainMenu = controller as MonoPushdownStateMachine;
		RegisterEvents();
		Selectable selection = (_controls.UsingJoystick() ? _firstSelection : null);
		StartCoroutine(UIUtils.SetCanvasAlpha(canvasGroup, 1f, Constants.CANVAS_FADE_TIME, interactable: true, selection));
		ExitMode = MenuExitMode.Cancel;
	}

	public override void Exit(MonoStateMachine controller)
	{
		UnregisterEvents();
		if (ExitMode == MenuExitMode.Cancel)
		{
			StartCoroutine(UIUtils.SetCanvasAlpha(canvasGroup, 0f, Constants.CANVAS_FADE_TIME, interactable: false));
		}
		else
		{
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
			canvasGroup.alpha = 0f;
		}
		_controls.DisableControls(Constants.BUTTON_SPAM_DELAY);
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		Debug.LogWarning("UISetGameModeSubState not expected to have running substates. Cascading the Return.");
		(controller as MonoPushdownStateMachine)?.ExitSubState();
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (_controls.GetButton(UserActions.UICANCEL))
		{
			_mainMenu.ExitSubState();
		}
		return this;
	}

	protected virtual void RegisterEvents()
	{
		if (!_eventsRegistered)
		{
			Events.Subscribe("InputChanged", Events_OnInputModeChanged);
			_eventsRegistered = true;
		}
	}

	protected virtual void UnregisterEvents()
	{
		if (_eventsRegistered)
		{
			Events.UnSubscribe("InputChanged", Events_OnInputModeChanged);
			_eventsRegistered = false;
		}
	}

	private void Events_OnInputModeChanged()
	{
		if (_mainMenu.GetCurrentState() != this)
		{
			return;
		}
		if (_controls.UsingJoystick())
		{
			if (EventSystem.current.currentSelectedGameObject == null)
			{
				HighlightFallbackSelectable();
			}
		}
		else if (EventSystem.current.currentSelectedGameObject != null)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
	}

	public void ModeButton_OnSubmitted(GameModeDefinition currentGameMode)
	{
		ExitMode = MenuExitMode.Confirm;
		SelectedGameMode = currentGameMode;
		_mainMenu.ExitSubState();
	}

	public void ExitArea_OnClicked()
	{
		_mainMenu.ExitSubState();
	}

	private void InitializeButtonsForNavigation()
	{
		if (!(modeButtonsParent == null))
		{
			_gameModeButtons = new List<Selectable>(modeButtonsParent.GetComponentsInChildren<Selectable>());
			_firstSelection = _gameModeButtons.FirstOrDefault();
			UIUtils.SetupVerticalButtonsNavigation(_gameModeButtons);
		}
	}

	protected virtual void HighlightFallbackSelectable()
	{
		_firstSelection.Select();
	}
}
