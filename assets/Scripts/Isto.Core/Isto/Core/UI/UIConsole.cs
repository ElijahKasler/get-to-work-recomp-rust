using System;
using System.Collections.Generic;
using System.Linq;
using Isto.Core.Cheats;
using Isto.Core.Inputs;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace Isto.Core.UI;

public class UIConsole : MonoBehaviour
{
	public class ConsoleCommandDefinition
	{
		public string commandStr;

		public bool closeConsoleWhenUsed = true;

		public List<CheatAction> actions;
	}

	[Serializable]
	public class DeveloperConsoleCommandEntry
	{
		public string command;

		public CheatAction action;

		public string[] arguments;
	}

	[Header("Terminal Display")]
	[FormerlySerializedAs("containerGroup")]
	public CanvasGroup terminalContainerGroup;

	public TMP_InputField inputField;

	public TextMeshProUGUI responseField;

	public string openMessage = "Dev Console.  Type 'commands' to see list of possible commands";

	private List<ConsoleCommandDefinition> _commands;

	private Queue<string> _responseMessages;

	private int _responseMessagesCount = 4;

	private Queue<string> _previousCommands = new Queue<string>(5);

	private int _previousCmdsToKeep = 10;

	private int _previousCmdIndex;

	public bool IsOpen { get; private set; }

	public event Action<ConsoleCommandDefinition, string[]> OnCommandActivated;

	protected void Awake()
	{
		_commands = new List<ConsoleCommandDefinition>();
		_responseMessages = new Queue<string>();
	}

	protected void Start()
	{
		RegisterEvents();
	}

	protected void OnDestroy()
	{
		UnregisterEvents();
	}

	private void OnEnable()
	{
	}

	protected void Update()
	{
		if (IsOpen)
		{
			if (Input.anyKeyDown && EventSystem.current.currentSelectedGameObject != inputField.gameObject && !Controls.UsingController)
			{
				inputField.Select();
			}
			if (Input.GetKeyDown(KeyCode.UpArrow) && _previousCommands.Count > 0)
			{
				SetInputFieldText(GetNextPreviousCommand());
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow) && _previousCommands.Count > 0)
			{
				SetInputFieldText(GetLastPreviousCommand());
			}
			else if (Input.GetKeyDown(KeyCode.Tab))
			{
				OnTabPressed();
			}
		}
	}

	private void RegisterEvents()
	{
		inputField.onSubmit.AddListener(InputField_OnSubmit);
	}

	private void UnregisterEvents()
	{
		inputField.onSubmit.RemoveListener(InputField_OnSubmit);
	}

	private void InputField_OnSubmit(string fieldText)
	{
		OnConsoleSubmit();
	}

	public void RegisterCommand(ConsoleCommandDefinition commandDefinition)
	{
		_commands.Add(commandDefinition);
	}

	public void RegisterCommands(List<ConsoleCommandDefinition> commandDefinitions)
	{
		_commands.AddRange(commandDefinitions);
	}

	public void OpenConsole()
	{
		IsOpen = true;
		responseField.text = openMessage;
		inputField.enabled = true;
		inputField.text = "";
		terminalContainerGroup.SetCanvasValues(1f, interactable: true, blockRaycast: true);
		SelectConsole();
	}

	public void SelectConsole()
	{
		if (EventSystem.current.currentSelectedGameObject != inputField.gameObject)
		{
			inputField.Select();
		}
	}

	public void CloseConsole()
	{
		IsOpen = false;
		terminalContainerGroup.SetCanvasValues(0f, interactable: false, blockRaycast: false);
		inputField.enabled = false;
	}

	public void OnConsoleSubmit()
	{
		if (inputField.enabled && !string.IsNullOrEmpty(inputField.text))
		{
			AddCommandToPreviousQueue(inputField.text);
			ProcessInput(inputField.text);
			SetInputFieldText("");
			inputField.DeactivateInputField();
			inputField.ActivateInputField();
			DisplayResponseText();
		}
	}

	private void AddCommandToPreviousQueue(string text)
	{
		_previousCommands.Enqueue(text);
		if (_previousCommands.Count >= _previousCmdsToKeep)
		{
			_previousCommands.Dequeue();
		}
		_previousCmdIndex = 0;
	}

	private string GetNextPreviousCommand()
	{
		string result = _previousCommands.ToArray()[_previousCommands.Count - 1 - _previousCmdIndex];
		_previousCmdIndex = Mathf.Clamp(_previousCmdIndex + 1, 0, _previousCommands.Count - 1);
		return result;
	}

	private string GetLastPreviousCommand()
	{
		_previousCmdIndex--;
		if (_previousCmdIndex < 0)
		{
			_previousCmdIndex = 0;
			return "";
		}
		return _previousCommands.ToArray()[_previousCommands.Count - 1 - _previousCmdIndex];
	}

	public void RunCommands(List<DeveloperConsoleCommandEntry> sequence)
	{
		if (sequence == null)
		{
			Debug.LogWarning("DeveloperConsole trying to run a null command list");
			return;
		}
		for (int i = 0; i < sequence.Count; i++)
		{
			string text = sequence[i].command;
			for (int j = 0; j < sequence[i].arguments.Length; j++)
			{
				text = text + " " + sequence[i].arguments[j];
			}
			ProcessInput(text);
		}
	}

	public void OnTabPressed()
	{
		if (inputField.text.Length == 0)
		{
			ShowAllAvailableCommands();
			DisplayResponseText();
			return;
		}
		string[] array = inputField.text.ToLower().Split(' ');
		ConsoleCommandDefinition command = GetCommand(array[0]);
		if (command == null)
		{
			string text = FindFirstCommand(array[0]);
			if (!string.IsNullOrEmpty(text))
			{
				SetInputFieldText(text);
			}
			return;
		}
		if (array.Length == 1)
		{
			SetInputFieldText(FindNextCommand(array[0]));
			return;
		}
		if (array.Any((string x) => x.StartsWith("\"")))
		{
			array = GroupTokensByQuotationMarks(array);
		}
		for (int num = 0; num < command.actions.Count; num++)
		{
			CheatAction cheatAction = command.actions[num];
			string[] array2 = new string[array.Length - 1];
			Array.Copy(array, 1, array2, 0, array2.Length);
			if (cheatAction.TryAutoCompleteParameters(array2, out var output))
			{
				SetInputFieldText(command.commandStr + " " + output);
			}
		}
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

	private string FindFirstCommand(string input)
	{
		for (int i = 0; i < _commands.Count; i++)
		{
			if (_commands[i].commandStr.StartsWith(input, StringComparison.CurrentCultureIgnoreCase))
			{
				return _commands[i].commandStr;
			}
		}
		return "";
	}

	private string FindNextCommand(string input)
	{
		for (int i = 0; i < _commands.Count; i++)
		{
			if (_commands[i].commandStr.StartsWith(input, StringComparison.CurrentCultureIgnoreCase))
			{
				i = ((!Input.GetKey(KeyCode.LeftShift)) ? ((i + 1) % _commands.Count) : ((i == 0) ? (_commands.Count - 1) : (i - 1)));
				return _commands[i].commandStr;
			}
		}
		return "";
	}

	private void ProcessInput(string consoleInput)
	{
		string[] array = consoleInput.Trim().ToLower().Split(' ');
		ConsoleCommandDefinition command = GetCommand(array[0]);
		if (command == null)
		{
			AddResponseText("Unkown command: " + array[0]);
		}
		else
		{
			OnCommandActivated?.Invoke(command, array);
		}
	}

	public void ShowAllAvailableCommands()
	{
		string text = "";
		for (int i = 0; i < _commands.Count; i++)
		{
			text += _commands[i].commandStr;
			if (i < _commands.Count - 1)
			{
				text += ", ";
			}
		}
		_responseMessages.Enqueue(text);
	}

	private ConsoleCommandDefinition GetCommand(string commandStr)
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

	public void AddResponseText(string text)
	{
		if (IsOpen)
		{
			if (_responseMessages.Count == _responseMessagesCount)
			{
				_responseMessages.Dequeue();
			}
			_responseMessages.Enqueue(text);
		}
		else
		{
			Debug.Log("[DevConsole] " + text);
		}
	}

	public void DisplayResponseText()
	{
		responseField.text = "";
		foreach (string responseMessage in _responseMessages)
		{
			TextMeshProUGUI textMeshProUGUI = responseField;
			textMeshProUGUI.text = textMeshProUGUI.text + responseMessage + "\n";
		}
		_responseMessages.Clear();
	}

	public void SetInputFieldText(string text)
	{
		inputField.text = text;
		inputField.caretPosition = text.Length;
	}
}
