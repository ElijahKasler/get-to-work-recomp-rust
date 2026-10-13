using System;
using System.Collections.Generic;
using System.Linq;
using Isto.Core.Analytics;
using Isto.Core.Cheats;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class CheatMenuState : MonoState
{
	[Header("Dashboard Display")]
	public CanvasGroup dashboardContainerGroup;

	public Selectable controllerDefaultSelection;

	public List<Selectable> nonInteractableForController;

	[Header("Skin Picker Display")]
	public CanvasGroup skinPickerContainerGroup;

	[Header("Terminal Display")]
	[FormerlySerializedAs("terminal")]
	public UIConsole console;

	[Header("Garbage Collect Inducer")]
	public UIButtonHoldDisplay forceGarbageCollectButton;

	private List<CheatAction> _activeActions;

	private GameObject _selectedBeforeConsoleOpened;

	private readonly List<UIConsole.DeveloperConsoleCommandEntry> _currentCommandStates = new List<UIConsole.DeveloperConsoleCommandEntry>();

	private List<UIConsole.ConsoleCommandDefinition> _commands = new List<UIConsole.ConsoleCommandDefinition>();

	private MonoStateMachine _menuStateMachine;

	private IControls _controls;

	private IAnalyticsHandler _analytics;

	private IUIGameMenu _gameMenu;

	private CheatSettings _cheatSettings;

	public bool IsOpen { get; private set; }

	public List<UIConsole.DeveloperConsoleCommandEntry> CurrentCommandStates => _currentCommandStates;

	private List<CheatAction> startUpActions => _cheatSettings.startUpActions;

	private List<CheatAction> cheatCommands => _cheatSettings.playerCommands;

	private List<CheatAction> devCommands => _cheatSettings.debugCommands;

	private List<CheatAction> keyCodeCommands => _cheatSettings.keyCodeCommands;

	[Inject]
	public void Inject(IControls controls, IAnalyticsHandler analytics, IUIGameMenu gameMenu, CheatSettings cheatSettings)
	{
		_controls = controls;
		_analytics = analytics;
		_gameMenu = gameMenu;
		_cheatSettings = cheatSettings;
	}

	protected void Awake()
	{
		_activeActions = new List<CheatAction>();
		forceGarbageCollectButton?.gameObject.SetActive(_cheatSettings.showForceGCTool && Debug.isDebugBuild);
	}

	protected void Start()
	{
		if (Debug.isDebugBuild)
		{
			cheatCommands.AddRange(devCommands);
		}
		for (int i = 0; i < cheatCommands.Count; i++)
		{
			CheatAction cheatAction = cheatCommands[i];
			for (int j = 0; j < cheatAction.aliases.Count; j++)
			{
				string commandStr = cheatAction.aliases[j];
				UIConsole.ConsoleCommandDefinition item = new UIConsole.ConsoleCommandDefinition
				{
					commandStr = commandStr,
					closeConsoleWhenUsed = cheatAction.closeMenuAfterActivation,
					actions = new List<CheatAction> { cheatAction }
				};
				_commands.Add(item);
			}
		}
		_commands.Sort((UIConsole.ConsoleCommandDefinition x, UIConsole.ConsoleCommandDefinition y) => x.commandStr.CompareTo(y.commandStr));
		console.RegisterCommands(_commands);
		RunStartUpActions();
		RegisterEvents();
	}

	protected void OnDestroy()
	{
		for (int i = 0; i < _activeActions.Count; i++)
		{
			try
			{
				_activeActions[i].Deactivate();
			}
			catch (Exception)
			{
			}
		}
		UnregisterEvents();
	}

	private void OnEnable()
	{
		console.CloseConsole();
		dashboardContainerGroup.SetCanvasValues(0f, interactable: false, blockRaycast: false);
		skinPickerContainerGroup.SetCanvasValues(0f, interactable: false, blockRaycast: false);
	}

	protected void Update()
	{
		for (int i = 0; i < _activeActions.Count; i++)
		{
			_activeActions[i].OnUpdate();
		}
		if (_cheatSettings.disableAllKeyCodeCommands)
		{
			return;
		}
		for (int j = 0; j < keyCodeCommands.Count; j++)
		{
			if (Input.GetKeyDown(keyCodeCommands[j].hotkey))
			{
				string[] splitInput = new string[1] { keyCodeCommands[j].aliases[0] };
				UIConsole.ConsoleCommandDefinition devCommand = new UIConsole.ConsoleCommandDefinition
				{
					commandStr = keyCodeCommands[j].aliases[0],
					closeConsoleWhenUsed = keyCodeCommands[j].closeMenuAfterActivation,
					actions = new List<CheatAction> { keyCodeCommands[j] }
				};
				ActivateCommand(devCommand, splitInput);
			}
		}
	}

	public override void Enter(MonoStateMachine controller)
	{
		_menuStateMachine = controller;
		OpenConsole();
	}

	public override void Exit(MonoStateMachine controller)
	{
		CloseConsole();
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		if (Input.anyKeyDown && !Controls.UsingController)
		{
			console.SelectConsole();
		}
		return this;
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
	}

	private void RegisterEvents()
	{
		console.OnCommandActivated += Terminal_OnCommandActivated;
		Events.Subscribe("InputChanged", Events_OnSettingsChanged);
	}

	private void UnregisterEvents()
	{
		console.OnCommandActivated -= Terminal_OnCommandActivated;
		Events.UnSubscribe("InputChanged", Events_OnSettingsChanged);
	}

	private void Terminal_OnCommandActivated(UIConsole.ConsoleCommandDefinition definition, string[] args)
	{
		ProcessCommand(definition, args);
	}

	private void Events_OnSettingsChanged()
	{
		if (IsOpen)
		{
			UpdateControllerDependentObjects();
			EventSystem.current.SetSelectedGameObject((!Controls.UsingController) ? null : controllerDefaultSelection?.gameObject);
		}
	}

	public void OpenConsole()
	{
		IsOpen = true;
		dashboardContainerGroup.SetCanvasValues(1f, interactable: true, blockRaycast: true);
		_controls.SetControlMode(Controls.Mode.DeveloperConsole);
		_selectedBeforeConsoleOpened = EventSystem.current.currentSelectedGameObject;
		console.OpenConsole();
		UpdateControllerDependentObjects();
		if (Controls.UsingController && controllerDefaultSelection != null)
		{
			controllerDefaultSelection.Select();
		}
		_analytics?.RegisterDeveloperConsoleOpened();
	}

	public void CloseConsole()
	{
		IsOpen = false;
		console.CloseConsole();
		dashboardContainerGroup.SetCanvasValues(0f, interactable: false, blockRaycast: false);
		_controls.SetControlMode(Controls.Mode.Gameplay);
		EventSystem.current.SetSelectedGameObject(Controls.UsingController ? _selectedBeforeConsoleOpened : null);
	}

	public void Run(List<UIConsole.DeveloperConsoleCommandEntry> sequence)
	{
		if (sequence == null)
		{
			Debug.LogWarning("DeveloperConsole trying to run a null command list");
			return;
		}
		for (int i = 0; i < sequence.Count; i++)
		{
			UpdateCurrentCommand(sequence[i]);
		}
		console.RunCommands(sequence);
		Events.RaiseEvent("DeveloperCommand", sequence);
	}

	private string[] GroupTokensByQuotationMarks(string[] splitInput)
	{
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = list;
		for (int i = 0; i < splitInput.Length; i++)
		{
			string text = splitInput[i];
			if (splitInput[i].StartsWith("\"") && !splitInput[i].EndsWith("\""))
			{
				list3 = list2;
			}
			if (text.StartsWith("\""))
			{
				text = text.Substring(1);
			}
			if (text.EndsWith("\""))
			{
				text = text.Substring(0, text.Length - 1);
			}
			list3.Add(text);
			if (splitInput[i].EndsWith("\"") && !splitInput[i].StartsWith("\""))
			{
				list.Add(string.Join(" ", list2));
				list2.Clear();
				list3 = list;
			}
		}
		return list.ToArray();
	}

	public void ProcessCommand(UIConsole.ConsoleCommandDefinition devCommand, string[] splitInput)
	{
		if (ActivateCommand(devCommand, splitInput) && devCommand.closeConsoleWhenUsed)
		{
			_gameMenu.CloseMenu();
		}
	}

	public bool ActivateCommand(UIConsole.ConsoleCommandDefinition devCommand, string[] splitInput)
	{
		ReportCheatAnalyticsData(devCommand);
		if (splitInput.Any((string x) => x.StartsWith("\"")))
		{
			splitInput = GroupTokensByQuotationMarks(splitInput);
		}
		bool flag = true;
		for (int num = 0; num < devCommand.actions.Count; num++)
		{
			CheatAction currentAction = devCommand.actions[num];
			flag &= ActivateAction(currentAction, splitInput);
		}
		return flag;
	}

	private void ReportCheatAnalyticsData(UIConsole.ConsoleCommandDefinition cmd)
	{
		_analytics?.RegisterCheatActivated(cmd.commandStr);
	}

	public bool ActivateAction(CheatAction currentAction, string[] splitInput)
	{
		if (!_activeActions.Contains(currentAction))
		{
			try
			{
				if (splitInput.Length - 1 != currentAction.numberOfParameters)
				{
					console.AddResponseText($"Invalid number of arguments passed to action.  Expecting {currentAction.numberOfParameters} args.");
					return false;
				}
				if (currentAction.numberOfParameters > 0)
				{
					string[] array = new string[splitInput.Length - 1];
					Array.ConstrainedCopy(splitInput, 1, array, 0, splitInput.Length - 1);
					object[] args = array;
					currentAction.Activate(args);
				}
				else
				{
					currentAction.Activate();
				}
				console.AddResponseText(string.Format("{0} {1}", currentAction.continuous ? "Starting" : "Triggering", currentAction.name));
				if (currentAction.continuous)
				{
					_activeActions.Add(currentAction);
				}
				if (!string.IsNullOrEmpty(currentAction.ResultMessage))
				{
					console.AddResponseText(currentAction.ResultMessage);
				}
				return true;
			}
			catch (Exception ex)
			{
				console.AddResponseText($"Error performing action {currentAction.name}.  Error: {ex.Message}");
				return false;
			}
		}
		try
		{
			currentAction.Deactivate();
			console.AddResponseText($"Deactivating {currentAction.name}");
			_activeActions.Remove(currentAction);
			return true;
		}
		catch (Exception ex2)
		{
			console.AddResponseText($"Error deactivating action {currentAction.name}.  Error: {ex2.Message}");
			return false;
		}
	}

	public void ShowAllActiveCommands()
	{
		console.AddResponseText("Active dev mode actions:");
		if (_activeActions.Count == 0)
		{
			console.AddResponseText("None");
		}
		for (int i = 0; i < _activeActions.Count; i++)
		{
			console.AddResponseText(_activeActions[i].name);
		}
	}

	public void ShowSkinSelector()
	{
		skinPickerContainerGroup.gameObject.SetActive(value: true);
		skinPickerContainerGroup.SetCanvasValues(1f, interactable: true, blockRaycast: true);
	}

	public void HideSkinSelector()
	{
		skinPickerContainerGroup.SetCanvasValues(0f, interactable: false, blockRaycast: false);
		skinPickerContainerGroup.gameObject.SetActive(value: false);
	}

	[ContextMenu("ForceGCCollect")]
	public void ForceGCCollect()
	{
		Debug.Log("Inducing garbage collection.");
		GC.Collect();
	}

	private UIConsole.ConsoleCommandDefinition GetCommand(string commandStr)
	{
		for (int i = 0; i < _commands.Count; i++)
		{
			if (_commands[i].commandStr.Equals(commandStr, StringComparison.OrdinalIgnoreCase))
			{
				return _commands[i];
			}
		}
		return null;
	}

	private void RunStartUpActions()
	{
		for (int i = 0; i < startUpActions.Count; i++)
		{
			try
			{
				startUpActions[i].Activate();
				if (startUpActions[i].continuous)
				{
					_activeActions.Add(startUpActions[i]);
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning($"Error performing startup DeveloperConsoleAction {startUpActions[i].name}.  Error: {ex.Message}");
			}
		}
	}

	private void UpdateControllerDependentObjects()
	{
		bool flag = !Controls.UsingController;
		foreach (Selectable item in nonInteractableForController)
		{
			item.interactable = flag;
		}
		if (flag)
		{
			if (!console.IsOpen)
			{
				console.OpenConsole();
			}
		}
		else
		{
			console.CloseConsole();
		}
	}

	private void UpdateCurrentCommand(UIConsole.DeveloperConsoleCommandEntry newEntry)
	{
		UIConsole.DeveloperConsoleCommandEntry developerConsoleCommandEntry = _currentCommandStates.FirstOrDefault((UIConsole.DeveloperConsoleCommandEntry commandEntry) => commandEntry.command.Equals(newEntry.command, StringComparison.OrdinalIgnoreCase));
		if (developerConsoleCommandEntry != null)
		{
			if (!Enumerable.SequenceEqual(developerConsoleCommandEntry.arguments, newEntry.arguments))
			{
				int index = _currentCommandStates.IndexOf(developerConsoleCommandEntry);
				_currentCommandStates[index] = newEntry;
			}
		}
		else
		{
			_currentCommandStates.Add(newEntry);
		}
	}
}
