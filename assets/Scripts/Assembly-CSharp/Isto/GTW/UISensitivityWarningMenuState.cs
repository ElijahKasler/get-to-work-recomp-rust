using Isto.Core;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using Isto.Core.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.GTW;

public class UISensitivityWarningMenuState : MonoState
{
	[SerializeField]
	private float _initialLoadDelay = 0.5f;

	[SerializeField]
	private MonoPushdownStateMachine _menuController;

	[SerializeField]
	private CanvasGroup _canvasGroup;

	[SerializeField]
	private Selectable _firstSelection;

	private const string SENSITIVITY_MENU_SEEN_PREFS_KEY = "SensitivityWarningSeen";

	private MonoPushdownStateMachine _controller;

	private IControls _controls;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	private void Awake()
	{
		_canvasGroup.SetCanvasValues(0f, interactable: false, blockRaycast: false);
	}

	private void OnDestroy()
	{
		UnregisterEvents();
	}

	private void Start()
	{
		RegisterEvents();
		Invoke("TryOpenMenu", _initialLoadDelay);
	}

	public override void Enter(MonoStateMachine controller)
	{
		_controller = controller as MonoPushdownStateMachine;
		StartCoroutine(UIUtils.SetCanvasAlpha(_canvasGroup, 1f, Constants.CANVAS_FADE_TIME, interactable: true, _firstSelection));
	}

	public override void Exit(MonoStateMachine controller)
	{
		_controller = null;
		StartCoroutine(UIUtils.SetCanvasAlpha(_canvasGroup, 0f, Constants.CANVAS_FADE_TIME, interactable: false));
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (_controls.GetButton(UserActions.UICANCEL))
		{
			ExitMenu();
		}
		return this;
	}

	private void RegisterEvents()
	{
		Events.Subscribe("InputChanged", Events_OnInputModeChanged);
	}

	private void UnregisterEvents()
	{
		Events.UnSubscribe("InputChanged", Events_OnInputModeChanged);
	}

	private void Events_OnInputModeChanged()
	{
		if (!(_controller == null) && !(_controller.GetCurrentState() != this))
		{
			if (_controls.UsingJoystick())
			{
				_firstSelection.Select();
			}
			else
			{
				EventSystem.current.SetSelectedGameObject(null);
			}
		}
	}

	public void Button_OnExitClicked()
	{
		ExitMenu();
	}

	private void TryOpenMenu()
	{
		if (PlayerPrefs.GetFloat("SensitivityWarningSeen", 0f) != 1f && _menuController != null)
		{
			_menuController.EnterSubState(this);
		}
	}

	private void ExitMenu()
	{
		if (_menuController.GetCurrentState() == this)
		{
			_menuController.ExitSubState();
			PlayerPrefs.SetFloat("SensitivityWarningSeen", 1f);
			PlayerPrefs.Save();
		}
	}

	[ContextMenu("TestResetMenuSeenFlag")]
	private void ResetMenuSeenFlag()
	{
		PlayerPrefs.SetFloat("SensitivityWarningSeen", 0f);
		Debug.Log("Player pref for seeing UISensitivityWarningMenuState has been reset to UNSEEN");
	}
}
