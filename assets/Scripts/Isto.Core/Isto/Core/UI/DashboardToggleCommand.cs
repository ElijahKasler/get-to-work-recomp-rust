using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class DashboardToggleCommand : DashboardCommand
{
	[Header("DashboardToggleCommand Config")]
	[SerializeField]
	private Button _button;

	[SerializeField]
	private Toggle _toggle;

	[SerializeField]
	[Tooltip("Uses the toggle GameObject name to save in EditorPrefs")]
	private bool _saveStateInEditor;

	private ColorBlock _engagedButtonColors;

	private ColorBlock _normalButtonColors;

	protected override void Start()
	{
		if (_button == null || _toggle == null)
		{
			Debug.LogError("DashboardToggleCommand not setup properly in the CheaterDashboardToggle prefab", this);
		}
		base.Start();
	}

	protected override void OnEnable()
	{
		InitializeButtonColors();
		RegisterEvents();
	}

	protected override void OnDisable()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		_button.onClick.AddListener(Button_OnPressed);
		Events.SubscribeWithParams("DeveloperCommand", DeveloperCommand_HandleArguments);
	}

	private void UnregisterEvents()
	{
		_button.onClick.RemoveListener(Button_OnPressed);
		Events.UnSubscribeWithParams("DeveloperCommand", DeveloperCommand_HandleArguments);
	}

	private void DeveloperCommand_HandleArguments(object[] args)
	{
		if (!(_console == null))
		{
			UpdateDashboard();
		}
	}

	private void Button_OnPressed()
	{
		bool value = !_toggle.isOn;
		SendActivateCommand(value);
	}

	private bool IsActivationAndCurrentCommandsEqual()
	{
		bool flag = true;
		foreach (UIConsole.DeveloperConsoleCommandEntry activationCommand in ActivationCommands)
		{
			if (flag)
			{
				flag = _console.CurrentCommandStates.Any((UIConsole.DeveloperConsoleCommandEntry commandEntry) => commandEntry.command.Equals(activationCommand.command, StringComparison.OrdinalIgnoreCase) && Enumerable.SequenceEqual(commandEntry.arguments, activationCommand.arguments));
			}
		}
		return flag;
	}

	private void SendActivateCommand(bool value)
	{
		if (value)
		{
			if (ActivationCommands != null && ActivationCommands.Count > 0)
			{
				foreach (UIConsole.DeveloperConsoleCommandEntry activationCommand in ActivationCommands)
				{
					Debug.Log("Activate Command " + activationCommand.command);
				}
			}
			ActivateCommand();
			return;
		}
		if (DeactivationCommands != null && DeactivationCommands.Count > 0)
		{
			foreach (UIConsole.DeveloperConsoleCommandEntry deactivationCommand in DeactivationCommands)
			{
				Debug.Log("Deactivate Command " + deactivationCommand.command);
			}
		}
		DeactivateCommand();
	}

	private void InitializeButtonColors()
	{
		_normalButtonColors = _button.colors;
		_engagedButtonColors = _normalButtonColors;
		_engagedButtonColors.normalColor = _normalButtonColors.pressedColor;
		_engagedButtonColors.pressedColor = _normalButtonColors.normalColor;
	}

	private void UpdateDashboard()
	{
		bool flag = IsActivationAndCurrentCommandsEqual();
		_toggle.isOn = flag;
		_button.colors = (flag ? _engagedButtonColors : _normalButtonColors);
	}
}
