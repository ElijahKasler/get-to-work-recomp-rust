using System;
using I2.Loc;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.StateMachine;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class UISettingsControlsSubState : UISettingsBaseSubState
{
	public enum TargetInputDevice
	{
		Keyboard = 0,
		Controller = 1
	}

	[Header("Pop up States")]
	[SerializeField]
	private UISimpleTimedModalState _rebindingUIPrompt;

	[SerializeField]
	private UISimpleAcknowledgementModalState _rebindingImpossiblePrompt;

	[SerializeField]
	private UISimpleConfirmModalState _conflictUIPrompt;

	[SerializeField]
	private UISimpleConfirmModalState _confirmationUIPrompt;

	[Header("Rebinding Localization")]
	[SerializeField]
	private LocalizedString _actionNameStartString;

	[Header("Key Conflict Localization")]
	[SerializeField]
	private LocalizedString _conflictMessageLoc;

	[SerializeField]
	private LocalizedString _timeRemainingLoc;

	[Header("Cannot Bind Localization")]
	[SerializeField]
	private LocalizedString _noControllerFoundLoc;

	[SerializeField]
	private LocalizedString _inputForbiddenLoc;

	[SerializeField]
	private LocalizedString _reservedKeyLoc;

	[Header("Viewport Content")]
	[SerializeField]
	private RectTransform _viewportContentContainer;

	[Header("Keyboard Setup")]
	[SerializeField]
	private RectTransform _keyboardControlsContainer;

	[SerializeField]
	private CoreButtonHighlightableController _keyboardHighlightableButton;

	[Header("Controller Setup")]
	[SerializeField]
	private RectTransform _controllerControlsContainer;

	[SerializeField]
	private CoreButtonHighlightableController _controllerHighlightableButton;

	[Header("Controller Category SubStates")]
	[SerializeField]
	private UISettingsGameInputSubState _keyboardMouseSubState;

	[SerializeField]
	private UISettingsGameInputSubState _controllerSubState;

	private UISettingsGameInputSubState _currentGameInputSubState;

	private UISettingsGameInputSubState _nextGameInputSubState;

	public override bool HasChanges
	{
		get
		{
			if (!_keyboardMouseSubState.HasChanges)
			{
				return _controllerSubState.HasChanges;
			}
			return true;
		}
	}

	public override Selectable FirstSelectable => _currentGameInputSubState?.SubTabButton;

	public override Selectable DefaultSelectable => _currentGameInputSubState?.DefaultSelectable;

	public override SettingsSubMenusEnum SettingsSubMenu => SettingsSubMenusEnum.Controls;

	public TargetInputDevice CurrentDevice => GetCurrentGameInputCategory();

	private bool IsNavigationInSubTabButtonBar
	{
		get
		{
			if (!_keyboardHighlightableButton.IsSelected)
			{
				return _controllerHighlightableButton.IsSelected;
			}
			return true;
		}
	}

	public override void Enter(MonoStateMachine controller)
	{
		base.Enter(controller);
		SetupPushdownStateMachine(controller);
		EnterInitialDeviceSubState();
		RefreshSubTabMenuNavigation();
	}

	public override void Exit(MonoStateMachine controller)
	{
		base.Exit(controller);
		_keyboardHighlightableButton.SetHighlighted(isHighlighted: false);
		_controllerHighlightableButton.SetHighlighted(isHighlighted: false);
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		base.ReturnFromSubState(controller, previousState);
		_menuController.ExitSubState();
	}

	protected override void RegisterEvents()
	{
		_controllerSubState.OnTabDirection += InputSubState_OnTabDirection;
		_keyboardMouseSubState.OnTabDirection += InputSubState_OnTabDirection;
	}

	private void InputSubState_OnTabDirection(TabDirection tabDirection)
	{
		InvokeTabDirection(tabDirection);
	}

	protected override void UnregisterEvents()
	{
		_controllerSubState.OnTabDirection -= InputSubState_OnTabDirection;
		_keyboardMouseSubState.OnTabDirection -= InputSubState_OnTabDirection;
	}

	public void Button_SelectKeyboardLayout()
	{
		RequestChangeCurrentSubState(_keyboardMouseSubState);
	}

	public void Button_SelectControllerLayout()
	{
		RequestChangeCurrentSubState(_controllerSubState);
	}

	public UIControlRebindingBase GetControlRebinder(string actionName, Pole pole)
	{
		UIControlRebindingBase result = null;
		switch (CurrentDevice)
		{
		case TargetInputDevice.Keyboard:
		{
			UIControlRebindingBase[] keyRebindings2 = _keyboardMouseSubState.KeyRebindings;
			for (int j = 0; j < keyRebindings2.Length; j++)
			{
				if (keyRebindings2[j].InputActionName.Equals(actionName) && keyRebindings2[j].AxisDirection == pole)
				{
					result = keyRebindings2[j];
					break;
				}
			}
			break;
		}
		case TargetInputDevice.Controller:
		{
			UIControlRebindingBase[] keyRebindings = _controllerSubState.KeyRebindings;
			for (int i = 0; i < keyRebindings.Length; i++)
			{
				if (keyRebindings[i].InputActionName.Equals(actionName) && keyRebindings[i].AxisDirection == pole)
				{
					result = keyRebindings[i];
					break;
				}
			}
			break;
		}
		}
		return result;
	}

	public void SetRebindingTimeRemaining(float time)
	{
		string countdownText = time.ToString("F0") + _timeRemainingLoc;
		_rebindingUIPrompt.SetCountdownText(countdownText);
	}

	private string GetLocActionNameForAxis(string actionName, Pole pole)
	{
		UIControlRebindingBase controlRebinder = GetControlRebinder(actionName, pole);
		if (!(controlRebinder != null))
		{
			return actionName;
		}
		return controlRebinder.ActionName;
	}

	private void SetCurrentSubState(UISettingsGameInputSubState currentSubState)
	{
		_currentGameInputSubState = currentSubState;
		_currentGameInputSubState.KeepNavInStateButtonsBar = base.KeepNavInStateButtonsBar;
		base.KeepNavInStateButtonsBar = false;
		_currentGameInputSubState.KeepNavInSubTabButtonsBar = IsNavigationInSubTabButtonBar;
		UpdateCurrentDeviceVisuals();
		RefreshSubTabMenuNavigation();
	}

	private TargetInputDevice GetCurrentGameInputCategory()
	{
		TargetInputDevice result = TargetInputDevice.Keyboard;
		if (_currentGameInputSubState == _keyboardMouseSubState)
		{
			result = TargetInputDevice.Keyboard;
		}
		else if (_currentGameInputSubState == _controllerSubState)
		{
			result = TargetInputDevice.Controller;
		}
		return result;
	}

	public override void ResetToDefaults()
	{
	}

	private void RefreshSubTabMenuNavigation()
	{
		UIUtils.SetNavigation(_currentGameInputSubState.TabButton, UIUtils.NavigationDirection.Down, _currentGameInputSubState.SubTabButton);
		UIUtils.SetNavigation(_keyboardHighlightableButton.GetSelectable(), UIUtils.NavigationDirection.Down, _currentGameInputSubState.DefaultSelectable);
		UIUtils.SetNavigation(_controllerHighlightableButton.GetSelectable(), UIUtils.NavigationDirection.Down, _currentGameInputSubState.DefaultSelectable);
		UIUtils.SetNavigation(_keyboardMouseSubState.DefaultSelectable, UIUtils.NavigationDirection.Up, _keyboardHighlightableButton.GetSelectable());
		UIUtils.SetNavigation(_controllerSubState.DefaultSelectable, UIUtils.NavigationDirection.Up, _controllerHighlightableButton.GetSelectable());
		UIUtils.SetNavigation(_keyboardHighlightableButton.GetSelectable(), UIUtils.NavigationDirection.Up, _keyboardMouseSubState.TabButton);
		UIUtils.SetNavigation(_controllerHighlightableButton.GetSelectable(), UIUtils.NavigationDirection.Up, _controllerSubState.TabButton);
	}

	public void RefreshControlUIState()
	{
		_currentGameInputSubState.RefreshControlsDisplay();
		_currentGameInputSubState.VerifyRemapDirtyFlags();
	}

	public void ShowRebindingPopUp(string actionName)
	{
		if (CheckIfStackIsReady())
		{
			string text = _actionNameStartString.ToString();
			text = text.Replace("{action}", "<color=#" + ColorUtility.ToHtmlStringRGBA(Constants.ATRIO_PINK_LIGHT) + ">" + actionName + "</color>");
			_rebindingUIPrompt.SetMainText(text);
			_menuController.EnterSubState(_rebindingUIPrompt);
		}
	}

	public void HideRebindingPopUp()
	{
		_rebindingUIPrompt.Hide();
		RefreshControlUIState();
	}

	public void ShowConflictPopUp(ElementAssignmentConflictInfo conflictInfo, Action<bool> onPopUpClose)
	{
		if (CheckIfStackIsReady())
		{
			string text;
			switch (conflictInfo.controllerType)
			{
			case ControllerType.Mouse:
			case ControllerType.Joystick:
				text = conflictInfo.elementMap.elementIdentifierName;
				break;
			default:
				text = conflictInfo.keyCode.ToString();
				break;
			}
			string actionName = conflictInfo.action.name;
			string locActionNameForAxis = GetLocActionNameForAxis(actionName, conflictInfo.elementMap.axisContribution);
			string mainText = "<color=#" + ColorUtility.ToHtmlStringRGBA(Constants.ATRIO_PINK_LIGHT) + ">" + text + "</color>" + $" {_conflictMessageLoc} <color=#{ColorUtility.ToHtmlStringRGBA(Constants.ATRIO_PINK_LIGHT)}>{locActionNameForAxis}</color>";
			_conflictUIPrompt.SetMainText(mainText);
			_conflictUIPrompt.SetCallbacks(() =>
			{
				onPopUpClose(obj: true);
			}, () =>
			{
				onPopUpClose(obj: false);
			});
			_menuController.EnterSubState(_conflictUIPrompt);
		}
	}

	public void ShowControllerRequiredPopup(Action onClose = null)
	{
		if (CheckIfStackIsReady())
		{
			_rebindingImpossiblePrompt.SetDetailsText(Loc.Get(_noControllerFoundLoc));
			_rebindingImpossiblePrompt.SetCallbacks(onClose, null);
			_menuController.EnterSubState(_rebindingImpossiblePrompt);
		}
	}

	public void ShowBindingForbiddenPopup(Action onClose = null)
	{
		if (CheckIfStackIsReady())
		{
			_rebindingImpossiblePrompt.SetDetailsText(Loc.Get(_inputForbiddenLoc));
			_rebindingImpossiblePrompt.SetCallbacks(onClose, null);
			_menuController.EnterSubState(_rebindingImpossiblePrompt);
		}
	}

	public void ShowOverrideFailedPopup(Action onClose = null)
	{
		if (CheckIfStackIsReady())
		{
			_rebindingImpossiblePrompt.SetDetailsText(_reservedKeyLoc);
			_rebindingImpossiblePrompt.SetCallbacks(onClose, null);
			_menuController.EnterSubState(_rebindingImpossiblePrompt);
		}
	}

	private void GoToInitialSubState(UISettingsGameInputSubState nextSubState)
	{
		SetCurrentSubState(nextSubState);
		_menuController.EnterSubState(nextSubState);
	}

	private void SetupPushdownStateMachine(MonoStateMachine controller)
	{
		if (controller is MonoPushdownStateMachine menuController)
		{
			_menuController = menuController;
		}
		else
		{
			Debug.LogError("Using Settings menu without a push down menu controller, this won't work");
		}
	}

	private void EnterInitialDeviceSubState()
	{
		UISettingsGameInputSubState nextSubState = (Controls.UsingController ? _controllerSubState : _keyboardMouseSubState);
		GoToInitialSubState(nextSubState);
	}

	private void UpdateCurrentDeviceVisuals()
	{
		if (CurrentDevice == TargetInputDevice.Keyboard)
		{
			_keyboardHighlightableButton.SetHighlighted(isHighlighted: true);
			_controllerHighlightableButton.SetHighlighted(isHighlighted: false);
			_viewportContentContainer.sizeDelta = new Vector2(0f, _keyboardControlsContainer.sizeDelta.y);
		}
		else
		{
			_keyboardHighlightableButton.SetHighlighted(isHighlighted: false);
			_controllerHighlightableButton.SetHighlighted(isHighlighted: true);
			_viewportContentContainer.sizeDelta = new Vector2(0f, _controllerControlsContainer.sizeDelta.y);
		}
	}

	private bool CheckIfStackIsReady()
	{
		bool result = true;
		if (_menuController.GetCurrentState() is UISimpleModalStateBase)
		{
			Debug.LogWarning("Requesting to enter a substate for a popup, but there is already a popup on the state stack. This will probably lead to some menu stack issues.");
			result = false;
		}
		return result;
	}

	private void RequestChangeCurrentSubState(UISettingsGameInputSubState nextState)
	{
		_nextGameInputSubState = nextState;
		if (_currentGameInputSubState.HasChanges)
		{
			ShowGameInputSubStateChangesConfirmationPopup();
		}
		else
		{
			ChangeToNextState();
		}
	}

	private void ShowGameInputSubStateChangesConfirmationPopup()
	{
		_confirmationSubState.SetCallbacks(ConfirmationSubState_ApplyGameInputChanges, ConfirmationSubState_DiscardGameInputChanges);
		_menuController.EnterSubState(_confirmationSubState);
		_confirmationSubState.SetMainText(Loc.GetString(Constants.UI_SETTINGS_MESSAGE_SAVE_SETTINGS));
	}

	private void ChangeToNextState()
	{
		SetCurrentSubState(_nextGameInputSubState);
		_menuController.ChangeState(_currentGameInputSubState);
		_nextGameInputSubState = null;
		InvokeSubCategoryChanged();
	}

	private void ConfirmationSubState_ApplyGameInputChanges()
	{
		_currentGameInputSubState.ApplySettingsChanges();
		ChangeToNextState();
	}

	private void ConfirmationSubState_DiscardGameInputChanges()
	{
		_currentGameInputSubState.DiscardSettingsChanges();
		ChangeToNextState();
	}
}
