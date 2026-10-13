using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class DashboardToggleGroupCommands : MonoBehaviour
{
	[Serializable]
	private class ToggleData
	{
		public string Name;

		public Toggle Toggle;

		public List<UIConsole.DeveloperConsoleCommandEntry> ActivationCommands;

		public List<UIConsole.DeveloperConsoleCommandEntry> DeactivationCommands;
	}

	[SerializeField]
	private ToggleGroup _group;

	[SerializeField]
	private ToggleData[] _toggles;

	private CheatMenuState _console;

	private ColorBlock _normalToggleColors;

	private ColorBlock _engagedToggleColors;

	private ToggleData _currentEngagedToggle;

	private void Start()
	{
		_console = base.gameObject.GetComponentInParent<CheatMenuState>();
		if (_group == null || _toggles == null || _toggles.Length == 0 || _console == null)
		{
			Debug.LogError("DashboardToggleGroupCommands not setup properly in the DeveloperConsole prefab", this);
		}
	}

	private void OnEnable()
	{
		_normalToggleColors = _toggles[0].Toggle.colors;
		_engagedToggleColors = _normalToggleColors;
		_engagedToggleColors.normalColor = _normalToggleColors.pressedColor;
		_engagedToggleColors.pressedColor = _normalToggleColors.normalColor;
		ToggleData[] toggles = _toggles;
		foreach (ToggleData data in toggles)
		{
			if (data.Toggle.isOn)
			{
				_currentEngagedToggle = data;
			}
			UpdateDashboard(data.Toggle, data.Toggle.isOn);
			data.Toggle.onValueChanged.AddListener((bool value) =>
			{
				OnTogglePressed(data, value);
			});
		}
	}

	private void OnDisable()
	{
		ToggleData[] toggles = _toggles;
		for (int i = 0; i < toggles.Length; i++)
		{
			toggles[i].Toggle.onValueChanged.RemoveAllListeners();
		}
	}

	private void OnDestroy()
	{
	}

	private void OnTogglePressed(ToggleData data, bool value)
	{
		if (value)
		{
			if (_currentEngagedToggle != data)
			{
				_console.Run(data.ActivationCommands);
				_currentEngagedToggle = data;
			}
		}
		else
		{
			_console.Run(data.DeactivationCommands);
		}
		UpdateDashboard(data.Toggle, value);
	}

	private void UpdateDashboard(Toggle toggle, bool engaged)
	{
		if (engaged)
		{
			toggle.colors = _engagedToggleColors;
		}
		else
		{
			toggle.colors = _normalToggleColors;
		}
	}
}
