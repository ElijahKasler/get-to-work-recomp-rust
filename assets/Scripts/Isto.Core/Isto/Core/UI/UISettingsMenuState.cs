using System.Collections.Generic;
using System.Linq;
using Isto.Core.Localization;
using Isto.Core.StateMachine;
using UnityEngine;
using Zenject;

namespace Isto.Core.UI;

public class UISettingsMenuState : MonoState
{
	[Header("UI Component Hookups")]
	[SerializeField]
	private CanvasGroup _canvasGroup;

	[Header("Confirm Dialogue")]
	[SerializeField]
	private UISimpleConfirmModalState _confirmationSubState;

	[Header("Reset to Defaults")]
	[SerializeField]
	private UISimpleConfirmModalState _resetToDefaultsSubState;

	[HideInInspector]
	public CanvasGroup _settingsCanvas;

	[HideInInspector]
	public CanvasGroup _gameplayCanvas;

	[HideInInspector]
	public CanvasGroup _videoCanvas;

	[HideInInspector]
	public CanvasGroup _audioCanvas;

	[HideInInspector]
	public CanvasGroup _controlsCanvas;

	private UISettingsBaseSubState _activeSubMenuState;

	private MonoPushdownStateMachine _menuController;

	private UISettingsBaseSubState _postPopUpMenuState;

	private List<UISettingsBaseSubState> _allSettingsSubMenuStates;

	private List<UISettingsBaseSubState> _settingsCategorySubMenuStates;

	private CoreButton[] _subMenuButtons;

	private bool _closeSettingsAfterSave;

	private LocTerm _resetCurrentPageMessage;

	private LocTerm _resetAllSettingsMessage;

	private LocTerm _saveSettingsMessage;

	protected LocTerm.Factory _localizedStringFactory;

	private bool IsNavigationInTabButtonBar
	{
		get
		{
			bool result = false;
			for (int i = 0; i < _subMenuButtons.Length; i++)
			{
				if (_subMenuButtons[i].IsSelected)
				{
					result = true;
					break;
				}
			}
			return result;
		}
	}

	[Inject]
	public virtual void Inject(LocTerm.Factory localizedFactory)
	{
		_localizedStringFactory = localizedFactory;
	}

	protected void Awake()
	{
		InitializeSubMenuNavigation();
		InitializeSubMenuButtonsNavigation();
		_resetCurrentPageMessage = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, Constants.UI_SETTINGS_MESSAGE_RESET_CURRENT_PAGE);
		_resetAllSettingsMessage = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, Constants.UI_SETTINGS_MESSAGE_RESET_ALL_SETTINGS);
		_saveSettingsMessage = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, Constants.UI_SETTINGS_MESSAGE_SAVE_SETTINGS);
	}

	public override void Enter(MonoStateMachine controller)
	{
		base.gameObject.SetActive(value: true);
		StartCoroutine(UIUtils.FadeInAndEnableCanvasGroup(_canvasGroup, Constants.CANVAS_FADE_TIME));
		SetupStateMachineController(controller);
		_menuController.EnterSubState(_activeSubMenuState);
		UpdateSubMenusTabNavigation();
		RegisterEvents();
	}

	public override void Exit(MonoStateMachine controller)
	{
		StartCoroutine(UIUtils.FadeOutAndDeactivateObject(_canvasGroup, Constants.CANVAS_FADE_TIME, base.gameObject));
		UnregisterEvents();
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		return this;
	}

	private void RegisterEvents()
	{
		foreach (UISettingsBaseSubState allSettingsSubMenuState in _allSettingsSubMenuStates)
		{
			AttachSettingsSubStateHandlers(allSettingsSubMenuState);
		}
	}

	private void UnregisterEvents()
	{
		foreach (UISettingsBaseSubState allSettingsSubMenuState in _allSettingsSubMenuStates)
		{
			DetachSettingsSubStateHandlers(allSettingsSubMenuState);
		}
	}

	private void AttachSettingsSubStateHandlers(UISettingsBaseSubState subState)
	{
		if (!(subState is UISettingsSubCategorySubState))
		{
			subState.OnTabDirection += SettingsSubState_OnTabDirection;
		}
		subState.OnSubStateAttemptClose += SettingsSubState_OnRequestClose;
		subState.OnResetToDefaultsSubmit += SettingsSubState_OnResetToDefaults;
		subState.OnResetAllToDefaultsSubmit += SettingsSubState_OnResetAllToDefaults;
		subState.OnSubMenuCategoryChanged += SettingsSubState_OnCategoryChanged;
	}

	private void DetachSettingsSubStateHandlers(UISettingsBaseSubState subState)
	{
		if (!(subState is UISettingsSubCategorySubState))
		{
			subState.OnTabDirection -= SettingsSubState_OnTabDirection;
		}
		subState.OnSubStateAttemptClose -= SettingsSubState_OnRequestClose;
		subState.OnResetToDefaultsSubmit -= SettingsSubState_OnResetToDefaults;
		subState.OnResetAllToDefaultsSubmit -= SettingsSubState_OnResetAllToDefaults;
		subState.OnSubMenuCategoryChanged -= SettingsSubState_OnCategoryChanged;
	}

	public void Button_OpenGameplaySettings()
	{
		RequestChangeSubMenu(SettingsSubMenusEnum.Gameplay);
	}

	public void Button_OpenVideoSettings()
	{
		RequestChangeSubMenu(SettingsSubMenusEnum.Video);
	}

	public void Button_OpenAudioSettings()
	{
		RequestChangeSubMenu(SettingsSubMenusEnum.Audio);
	}

	public void Button_OpenControlSettings()
	{
		RequestChangeSubMenu(SettingsSubMenusEnum.Controls);
	}

	public void Button_NextTabLeft()
	{
		ChangeTab(UISettingsBaseSubState.TabDirection.Left);
	}

	public void Button_NextTabRight()
	{
		ChangeTab(UISettingsBaseSubState.TabDirection.Right);
	}

	private void SettingsSubState_OnTabDirection(UISettingsBaseSubState.TabDirection tabDirection)
	{
		ChangeTab(tabDirection);
	}

	private void SettingsSubState_OnRequestClose(bool isChangesMade)
	{
		if (isChangesMade)
		{
			if ((_menuController.GetCurrentState() as UISettingsBaseSubState).RequiresUserValidation)
			{
				CloseSettingsSubStateWithChangesAndValidation();
			}
			else
			{
				CloseSettingsSubStateWithChanges();
			}
		}
		else
		{
			_menuController.ExitSubState();
		}
	}

	private void SettingsSubState_OnResetToDefaults()
	{
		_postPopUpMenuState = _activeSubMenuState;
		_resetToDefaultsSubState.SetCallbacks(ConfirmationSubState_ResetToDefaults, ConfirmationSubState_CancelReset);
		_resetToDefaultsSubState.SetMainText(_resetCurrentPageMessage);
		_menuController.EnterSubState(_resetToDefaultsSubState);
	}

	private void SettingsSubState_OnResetAllToDefaults()
	{
		_postPopUpMenuState = _activeSubMenuState;
		_resetToDefaultsSubState.SetCallbacks(ConfirmationSubState_ResetAllToDefaults, ConfirmationSubState_CancelReset);
		_resetToDefaultsSubState.SetMainText(_resetAllSettingsMessage);
		_menuController.EnterSubState(_resetToDefaultsSubState);
	}

	private void SettingsSubState_OnCategoryChanged()
	{
		UpdateSubMenusTabNavigation();
	}

	private void ConfirmationSubstate_SaveConfirmedIntoValidate()
	{
		if (_menuController.GetCurrentState() is UISettingsBaseSubState uISettingsBaseSubState)
		{
			uISettingsBaseSubState.ApplySettingsForUserValidation();
		}
		EnterValidationModalState();
	}

	private void ConfirmationSubState_SaveConfirmed()
	{
		if (_menuController.GetCurrentState() is UISettingsBaseSubState uISettingsBaseSubState)
		{
			uISettingsBaseSubState.ApplySettingsChanges();
		}
		ClosePopupSubstate();
	}

	private void ConfirmationSubState_SaveCancelled()
	{
		if (_menuController.GetCurrentState() is UISettingsBaseSubState uISettingsBaseSubState)
		{
			uISettingsBaseSubState.DiscardSettingsChanges();
		}
		ClosePopupSubstate();
	}

	private void ConfirmationSubState_CancelReset()
	{
		ChangeSubMenu(_postPopUpMenuState);
	}

	private void ConfirmationSubState_ResetToDefaults()
	{
		if (_menuController.GetCurrentState() is UISettingsBaseSubState uISettingsBaseSubState)
		{
			uISettingsBaseSubState.ResetToDefaults();
		}
	}

	private void ConfirmationSubState_ResetAllToDefaults()
	{
		foreach (UISettingsBaseSubState allSettingsSubMenuState in _allSettingsSubMenuStates)
		{
			allSettingsSubMenuState.ResetToDefaults();
		}
	}

	private UISettingsBaseSubState GetSubMenuState(SettingsSubMenusEnum menuEnum)
	{
		return _settingsCategorySubMenuStates.Find((UISettingsBaseSubState state) => state.SettingsSubMenu == menuEnum);
	}

	private void InitializeSubMenuNavigation()
	{
		_allSettingsSubMenuStates = GetComponentsInChildren<UISettingsBaseSubState>(includeInactive: true).ToList();
		_settingsCategorySubMenuStates = _allSettingsSubMenuStates.Where((UISettingsBaseSubState state) => !(state is UISettingsSubCategorySubState)).ToList();
		_activeSubMenuState = _settingsCategorySubMenuStates.FirstOrDefault();
		if (_activeSubMenuState == null)
		{
			Debug.LogError("No valid UISettingsBaseSubState components found in children. Ensure there are valid submenu states assigned in the scene hierarchy.");
		}
	}

	private void InitializeSubMenuButtonsNavigation()
	{
		_subMenuButtons = _settingsCategorySubMenuStates.Select((UISettingsBaseSubState state) => state.TabButton).ToArray();
	}

	private void SetupStateMachineController(MonoStateMachine controller)
	{
		if (controller is MonoPushdownStateMachine menuController)
		{
			_menuController = menuController;
		}
		else
		{
			Debug.LogError("Using settings menu without a push down menu controller, this won't work");
		}
	}

	private void ChangeTab(UISettingsBaseSubState.TabDirection tabDirection)
	{
		int num = _settingsCategorySubMenuStates.IndexOf(_activeSubMenuState);
		UISettingsBaseSubState uISettingsBaseSubState = ((tabDirection != UISettingsBaseSubState.TabDirection.Left) ? _settingsCategorySubMenuStates[(num + 1) % _settingsCategorySubMenuStates.Count] : ((num != 0) ? _settingsCategorySubMenuStates[num - 1] : _settingsCategorySubMenuStates[_settingsCategorySubMenuStates.Count - 1]));
		RequestChangeSubMenu(uISettingsBaseSubState.SettingsSubMenu);
	}

	private void RequestChangeSubMenu(SettingsSubMenusEnum menuEnum)
	{
		UISettingsBaseSubState subMenuState = GetSubMenuState(menuEnum);
		if (!(subMenuState != _menuController.GetCurrentState()))
		{
			return;
		}
		if (_activeSubMenuState.HasChanges)
		{
			if ((_menuController.GetCurrentState() as UISettingsBaseSubState).RequiresUserValidation)
			{
				ChangeTabWithChangesAndValidation(subMenuState);
			}
			else
			{
				ChangeTabsWithChanges(subMenuState);
			}
		}
		else
		{
			ChangeSubMenu(subMenuState);
		}
	}

	private void CloseSettingsSubStateWithChanges()
	{
		EnterConfirmationModalState(_activeSubMenuState, closeSettingsAfterSave: true);
	}

	private void CloseSettingsSubStateWithChangesAndValidation()
	{
		EnterConfirmationValidationModalState(_activeSubMenuState, closeSettingsAfterSave: true);
	}

	private void ChangeTabsWithChanges(UISettingsBaseSubState menuSubState)
	{
		EnterConfirmationModalState(menuSubState, closeSettingsAfterSave: false);
	}

	private void ChangeTabWithChangesAndValidation(UISettingsBaseSubState menuSubState)
	{
		EnterConfirmationValidationModalState(menuSubState, closeSettingsAfterSave: false);
	}

	private void EnterConfirmationModalState(UISettingsBaseSubState targetState, bool closeSettingsAfterSave)
	{
		_closeSettingsAfterSave = closeSettingsAfterSave;
		_postPopUpMenuState = targetState;
		_confirmationSubState.SetCallbacks(ConfirmationSubState_SaveConfirmed, ConfirmationSubState_SaveCancelled);
		_confirmationSubState.SetMainText(_saveSettingsMessage);
		_menuController.EnterSubState(_confirmationSubState);
	}

	private void EnterConfirmationValidationModalState(UISettingsBaseSubState targetState, bool closeSettingsAfterSave)
	{
		_closeSettingsAfterSave = closeSettingsAfterSave;
		_postPopUpMenuState = targetState;
		_confirmationSubState.SetCallbacks(ConfirmationSubstate_SaveConfirmedIntoValidate, ConfirmationSubState_SaveCancelled);
		_confirmationSubState.SetMainText(_saveSettingsMessage);
		_menuController.EnterSubState(_confirmationSubState);
	}

	private void EnterValidationModalState()
	{
		_confirmationSubState.SetTimer(10f);
		_confirmationSubState.SetCallbacks(ConfirmationSubState_SaveConfirmed, ConfirmationSubState_SaveCancelled);
		_confirmationSubState.SetMainText(Loc.GetString(Constants.UI_SETTINGS_MESSAGE_KEEP_SETTINGS));
		_menuController.EnterSubState(_confirmationSubState);
	}

	private void ClosePopupSubstate()
	{
		if (_closeSettingsAfterSave)
		{
			_menuController.ExitSubState();
			_menuController.ExitSubState();
		}
		else
		{
			ChangeSubMenu(_postPopUpMenuState);
		}
	}

	private void ChangeSubMenu(UISettingsBaseSubState subMenuState)
	{
		if (!(subMenuState == _activeSubMenuState))
		{
			_activeSubMenuState = subMenuState;
			ChangeSubMenuState(subMenuState);
			UpdateSubMenusTabNavigation();
		}
	}

	private void ChangeSubMenuState(UISettingsBaseSubState nextSubState)
	{
		nextSubState.KeepNavInStateButtonsBar = IsNavigationInTabButtonBar;
		_menuController.ExitSubState();
		_menuController.EnterSubState(nextSubState);
	}

	private void UpdateSubMenusTabNavigation()
	{
		CoreButton[] array = _subMenuButtons.Where((CoreButton subMenuButton) => subMenuButton.enabled).ToArray();
		CoreButton[] array2 = array;
		for (int num = 0; num < array2.Length; num++)
		{
			UIUtils.SetNavigation(array2[num], UIUtils.NavigationDirection.Down, _activeSubMenuState.FirstSelectable);
		}
		for (int num2 = 0; num2 < array.Length; num2++)
		{
			CoreButton selectable = array[num2];
			CoreButton target = array[(num2 + 1) % array.Length];
			CoreButton target2 = array[(num2 - 1 + array.Length) % array.Length];
			UIUtils.SetNavigation(selectable, UIUtils.NavigationDirection.Right, target);
			UIUtils.SetNavigation(selectable, UIUtils.NavigationDirection.Left, target2);
		}
	}
}
