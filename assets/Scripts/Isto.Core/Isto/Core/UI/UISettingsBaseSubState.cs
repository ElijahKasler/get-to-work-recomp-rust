using System;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public abstract class UISettingsBaseSubState : MonoState
{
	public enum TabDirection
	{
		Left = 0,
		Right = 1
	}

	[Header("UI Component Hookups")]
	[SerializeField]
	protected CanvasGroup _canvasGroup;

	[Header("Confirm Dialogue")]
	[SerializeField]
	protected UISimpleConfirmModalState _confirmationSubState;

	[Header("Settings Apply/Discard Buttons")]
	[SerializeField]
	protected CoreButton _applySettingsButton;

	[SerializeField]
	protected CoreButton _defaultsSettingsButton;

	[SerializeField]
	protected CoreButton _discardSettingsButton;

	[Header("Tab Button")]
	[FormerlySerializedAs("_defaultSubMenusButton")]
	[SerializeField]
	protected CoreButton _tabButton;

	[SerializeField]
	protected CoreButtonHighlightableController _tabButtonHighlighter;

	[Header("Xbox Specific")]
	[SerializeField]
	private bool _removeFromXboxBuild;

	private static readonly float MAX_VERTICAL_ANGLE = 0.35f;

	private static readonly float MIN_HORIZONTAL_BUFFER = 0.85f;

	protected MonoPushdownStateMachine _menuController;

	protected UISettingsSelectable[] _selectableSettings;

	private static readonly string NORTH_BUTTON_RAW_INPUT_NAME = "joystick button 3";

	private bool _isHorizontalAxisInUse;

	private float _cooldownAtSateEnter;

	private bool _isButtonHeldFromPreviousState;

	private UISettingsSelectable _lastSelectableInSubState;

	private Selectable _previousSelectionMade;

	private IControls _controls;

	private static GameObject CurrentSelection => EventSystem.current.currentSelectedGameObject;

	public abstract bool HasChanges { get; }

	public abstract Selectable FirstSelectable { get; }

	public abstract Selectable DefaultSelectable { get; }

	public abstract SettingsSubMenusEnum SettingsSubMenu { get; }

	public virtual bool RequiresUserValidation => false;

	public bool KeepNavInStateButtonsBar { get; set; }

	public CoreButton TabButton => _tabButton;

	public bool RemoveFromXboxBuild => _removeFromXboxBuild;

	private CoreButtonHighlightableController TabButtonHighlighter
	{
		get
		{
			if (_tabButtonHighlighter == null)
			{
				_tabButtonHighlighter = _tabButton.GetComponent<CoreButtonHighlightableController>();
			}
			return _tabButtonHighlighter;
		}
	}

	public event Action<bool> OnSubStateAttemptClose;

	public event Action OnResetToDefaultsSubmit;

	public event Action OnResetAllToDefaultsSubmit;

	public event Action<TabDirection> OnTabDirection;

	public event Action OnSubMenuCategoryChanged;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	protected virtual void OnDestroy()
	{
	}

	public override void Enter(MonoStateMachine controller)
	{
		_menuController = controller as MonoPushdownStateMachine;
		_cooldownAtSateEnter = Constants.BUTTON_SPAM_DELAY;
		_canvasGroup.alpha = 1f;
		_canvasGroup.interactable = true;
		_canvasGroup.blocksRaycasts = true;
		base.gameObject.SetActive(value: true);
		_isButtonHeldFromPreviousState = false;
		TabButtonHighlighter?.SetHighlighted(isHighlighted: true);
		SetSelectionToDefaultSelectable();
		SetupLastSelectable();
		RegisterEvents();
	}

	public override void Exit(MonoStateMachine controller)
	{
		TabButtonHighlighter?.SetHighlighted(isHighlighted: false);
		DeselectAllSelectableSettings();
		UnregisterEvents();
		base.gameObject.SetActive(value: false);
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		_cooldownAtSateEnter = Constants.BUTTON_SPAM_DELAY;
		SetSelectionToPrevious();
		if (_controls.GetAnyButton())
		{
			_isButtonHeldFromPreviousState = true;
		}
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		_cooldownAtSateEnter -= Time.unscaledDeltaTime;
		if (_cooldownAtSateEnter > 0f)
		{
			return null;
		}
		SettingsNavigation();
		VerifyApplyDiscardButtons();
		return null;
	}

	protected virtual void RegisterEvents()
	{
		_defaultsSettingsButton.OnSubmitEvent += DefaultsButton_OnSubmit;
		_applySettingsButton.OnSubmitEvent += ApplySettings_OnSubmit;
		_discardSettingsButton.OnSubmitEvent += DiscardSettings_OnSubmit;
		Events.Subscribe("InputChanged", Events_OnInputModeChanged);
	}

	protected virtual void UnregisterEvents()
	{
		_applySettingsButton.OnSubmitEvent -= ApplySettings_OnSubmit;
		_discardSettingsButton.OnSubmitEvent -= DiscardSettings_OnSubmit;
		_defaultsSettingsButton.OnSubmitEvent -= DefaultsButton_OnSubmit;
		Events.UnSubscribe("InputChanged", Events_OnInputModeChanged);
	}

	protected virtual void ApplySettings_OnSubmit()
	{
		ApplySettingsChanges();
		_defaultsSettingsButton.Select();
	}

	protected void DiscardSettings_OnSubmit()
	{
		DiscardSettingsChanges();
		_defaultsSettingsButton.Select();
	}

	private void DefaultsButton_OnSubmit()
	{
		_previousSelectionMade = _defaultsSettingsButton;
		OnResetToDefaultsSubmit?.Invoke();
	}

	private void Events_OnInputModeChanged()
	{
		if (_previousSelectionMade == null)
		{
			_previousSelectionMade = DefaultSelectable;
		}
		_previousSelectionMade.Select();
	}

	protected virtual void SetSelectionToDefaultSelectable()
	{
		if (Controls.UsingController)
		{
			if (KeepNavInStateButtonsBar && TabButton != null)
			{
				TabButton.Select();
			}
			else if (DefaultSelectable != null)
			{
				DefaultSelectable.Select();
			}
		}
	}

	private void SetSelectionToPrevious()
	{
		if ((bool)_previousSelectionMade)
		{
			_previousSelectionMade.Select();
			_previousSelectionMade = null;
		}
	}

	public virtual void ApplySettingsForUserValidation()
	{
	}

	public abstract void ResetToDefaults();

	public virtual void ApplySettingsChanges()
	{
		PlayerPrefs.Save();
		Events.RaiseEvent("SettingsSaved");
		ClearSelectablesDirtyFlag();
	}

	public virtual void DiscardSettingsChanges()
	{
		ClearSelectablesDirtyFlag();
	}

	protected void SetupSelectableNavigation(Transform selectablesContainer)
	{
		_selectableSettings = selectablesContainer.GetComponentsInChildren<UISettingsSelectable>();
		if (_selectableSettings.Length == 0)
		{
			Debug.LogWarning("Warning: There are no selectable options in this menu.");
		}
		if (_selectableSettings.Length == 1)
		{
			_lastSelectableInSubState = _selectableSettings[0];
			SetupLastSelectable();
			return;
		}
		for (int i = 0; i < _selectableSettings.Length; i++)
		{
			if (i == _selectableSettings.Length - 1)
			{
				UIUtils.SetNavigation(_selectableSettings[i], UIUtils.NavigationDirection.Up, _selectableSettings[i - 1]);
				_lastSelectableInSubState = _selectableSettings[i];
				SetupLastSelectable();
				continue;
			}
			UIUtils.SetNavigation(_selectableSettings[i], UIUtils.NavigationDirection.Down, _selectableSettings[i + 1]);
			if (i != 0)
			{
				UIUtils.SetNavigation(_selectableSettings[i], UIUtils.NavigationDirection.Up, _selectableSettings[i - 1]);
			}
		}
	}

	protected virtual void VerifyApplyDiscardButtons()
	{
		if (HasChanges != _applySettingsButton.interactable)
		{
			_applySettingsButton.interactable = HasChanges;
			_applySettingsButton.enabled = HasChanges;
		}
		if (HasChanges != _discardSettingsButton.interactable)
		{
			_discardSettingsButton.interactable = HasChanges;
			_discardSettingsButton.enabled = HasChanges;
		}
	}

	protected void InvokeTabDirection(TabDirection tabDirection)
	{
		OnTabDirection?.Invoke(tabDirection);
	}

	protected void InvokeSubCategoryChanged()
	{
		OnSubMenuCategoryChanged?.Invoke();
	}

	private void HandleDirectionChanges(float horizontalValue, float verticalValue)
	{
		if (!(EventSystem.current.currentSelectedGameObject == null) && (bool)CurrentSelection.GetComponent<UISettingsSelectable>())
		{
			float num = Mathf.Abs(horizontalValue);
			float num2 = Mathf.Abs(verticalValue);
			if (!_isHorizontalAxisInUse && num > num2 && num >= MIN_HORIZONTAL_BUFFER && num2 <= MAX_VERTICAL_ANGLE)
			{
				InvokeDirectionChange(horizontalValue);
				_isHorizontalAxisInUse = true;
			}
			else if (num == 0f)
			{
				_isHorizontalAxisInUse = false;
			}
		}
	}

	private void InvokeDirectionChange(float horizontalValue)
	{
		UISettingsSelectable component = CurrentSelection.GetComponent<UISettingsSelectable>();
		if (Mathf.Sign(horizontalValue) == 1f)
		{
			component.HandleRightInput();
		}
		else
		{
			component.HandleLeftInput();
		}
	}

	private void ClearSelectablesDirtyFlag()
	{
		if (_selectableSettings != null)
		{
			UISettingsSelectable[] selectableSettings = _selectableSettings;
			for (int i = 0; i < selectableSettings.Length; i++)
			{
				selectableSettings[i].SetDirtyFlag(isDirty: false);
			}
		}
	}

	private void DeselectAllSelectableSettings()
	{
		if (_selectableSettings != null)
		{
			UISettingsSelectable[] selectableSettings = _selectableSettings;
			for (int i = 0; i < selectableSettings.Length; i++)
			{
				selectableSettings[i].SetSelection(isSelected: false);
			}
		}
	}

	private void SettingsNavigation()
	{
		float axis = _controls.GetAxis(Controls.MovementAxis.UIHorizontal);
		float axis2 = _controls.GetAxis(Controls.MovementAxis.UIVertical);
		HandleDirectionChanges(axis, axis2);
		if (_controls.GetButtonUp(UserActions.UICANCEL) && !_isButtonHeldFromPreviousState)
		{
			if (!HasChanges)
			{
				_menuController.ExitSubState();
			}
			OnSubStateAttemptClose?.Invoke(HasChanges);
		}
		if (_isButtonHeldFromPreviousState && !_controls.GetAnyButton())
		{
			_isButtonHeldFromPreviousState = false;
		}
		if (_controls.GetButtonDown(UserActions.UITABLEFT))
		{
			InvokeTabDirection(TabDirection.Left);
		}
		else if (_controls.GetButtonDown(UserActions.UITABRIGHT))
		{
			InvokeTabDirection(TabDirection.Right);
		}
		if (_controls.GetButtonDown(UserActions.UISETTINGSRESETALLTODEFAULTS))
		{
			CacheCurrentSelection();
			OnResetAllToDefaultsSubmit?.Invoke();
		}
	}

	private void CacheCurrentSelection()
	{
		if (CurrentSelection != null)
		{
			Selectable component = CurrentSelection.GetComponent<Selectable>();
			if ((bool)component)
			{
				_previousSelectionMade = component;
			}
		}
	}

	private void SetupLastSelectable()
	{
		if (!(_lastSelectableInSubState == null))
		{
			UIUtils.SetNavigation(_lastSelectableInSubState, UIUtils.NavigationDirection.Down, _defaultsSettingsButton);
			UIUtils.SetNavigation(_discardSettingsButton, UIUtils.NavigationDirection.Up, _lastSelectableInSubState);
			UIUtils.SetNavigation(_defaultsSettingsButton, UIUtils.NavigationDirection.Up, _lastSelectableInSubState);
			UIUtils.SetNavigation(_applySettingsButton, UIUtils.NavigationDirection.Up, _lastSelectableInSubState);
		}
	}
}
