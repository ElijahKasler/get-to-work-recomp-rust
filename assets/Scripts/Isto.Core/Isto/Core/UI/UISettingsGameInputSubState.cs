using System.Collections.Generic;
using Isto.Core.Data;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UISettingsGameInputSubState : UISettingsSubCategorySubState
{
	[Header("First Selectable Setup")]
	[SerializeField]
	private UISettingsSelectable _firstInputSelectable;

	[Header("Controller Maps")]
	[SerializeField]
	private List<ControllerType> _controllerTypes;

	protected UIControlRebindingBase[] _keyRebindings;

	private bool _hasChanges;

	private UserKeybindingDataStore _dataStore;

	public UIControlRebindingBase[] KeyRebindings => _keyRebindings;

	public override bool HasChanges => _hasChanges;

	public override Selectable DefaultSelectable => _firstInputSelectable;

	public bool KeepNavInSubTabButtonsBar { get; set; }

	[Inject]
	public virtual void Inject(UserKeybindingDataStore dataStore)
	{
		_dataStore = dataStore;
	}

	private void Awake()
	{
		_keyRebindings = GetComponentsInChildren<UIControlRebindingBase>();
	}

	private void Start()
	{
		SetupSelectableNavigation(base.transform);
	}

	public override void Enter(MonoStateMachine controller)
	{
		EventSystem.current.SetSelectedGameObject(null);
		base.Enter(controller);
		RefreshControlsDisplay();
	}

	private void SetHasChanges(bool hasChanges)
	{
		if (_hasChanges != hasChanges)
		{
			SetButtonEnabled(_applySettingsButton, hasChanges);
			SetButtonEnabled(_discardSettingsButton, hasChanges);
			_hasChanges = hasChanges;
		}
	}

	private void SetButtonEnabled(CoreButton button, bool state)
	{
		if (button.enabled != state)
		{
			button.enabled = state;
		}
	}

	protected override void SetSelectionToDefaultSelectable()
	{
		if (Controls.UsingController)
		{
			if (KeepNavInSubTabButtonsBar && base.SubTabButton != null)
			{
				base.SubTabButton.Select();
			}
			else
			{
				base.SetSelectionToDefaultSelectable();
			}
		}
	}

	public override void ApplySettingsChanges()
	{
		base.ApplySettingsChanges();
		_dataStore.Save();
		UpdateControlKeys();
		SetHasChanges(hasChanges: false);
		Events.RaiseEvent("ControlsChanged");
	}

	public override void DiscardSettingsChanges()
	{
		base.DiscardSettingsChanges();
		_dataStore.Load();
		RefreshControlsDisplay();
		SetHasChanges(hasChanges: false);
		Events.RaiseEvent("ControlsChanged");
	}

	public override void ResetToDefaults()
	{
		Player player = ReInput.players.GetPlayer(Controls.DEFAULT_REWIRED_PLAYER_ID);
		foreach (ControllerType controllerType in _controllerTypes)
		{
			player.controllers.maps.LoadDefaultMaps(controllerType);
		}
		RefreshControlsDisplay();
		ApplySettingsChanges();
	}

	public void RefreshControlsDisplay()
	{
		if (_keyRebindings != null)
		{
			UIControlRebindingBase[] keyRebindings = _keyRebindings;
			for (int i = 0; i < keyRebindings.Length; i++)
			{
				keyRebindings[i].RefreshDisplay();
			}
		}
	}

	public void VerifyRemapDirtyFlags()
	{
		bool hasChanges = false;
		UISettingsSelectable[] selectableSettings = _selectableSettings;
		for (int i = 0; i < selectableSettings.Length; i++)
		{
			if (selectableSettings[i].IsDirty)
			{
				hasChanges = true;
				break;
			}
		}
		SetHasChanges(hasChanges);
	}

	private void UpdateControlKeys()
	{
		if (_keyRebindings != null)
		{
			UIControlRebindingBase[] keyRebindings = _keyRebindings;
			for (int i = 0; i < keyRebindings.Length; i++)
			{
				keyRebindings[i].ClearRebindingCache();
			}
		}
	}
}
