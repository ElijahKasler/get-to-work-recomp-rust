using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Isto.Core.Cheats;

public abstract class CheatAction : ScriptableObject
{
	public List<string> aliases;

	public KeyCode hotkey;

	public int numberOfParameters;

	public bool continuous;

	public bool closeMenuAfterActivation;

	protected DiContainer _projectContextContainer;

	public string ResultMessage { get; private set; }

	[Inject]
	private void Inject(DiContainer container)
	{
		_projectContextContainer = container;
	}

	public abstract void Activate(params object[] args);

	public abstract void OnUpdate();

	public abstract void Deactivate();

	public virtual bool TryAutoCompleteParameters(string[] inputs, out string output)
	{
		output = "";
		return false;
	}

	protected Vector3? ArgToDirection(object arg)
	{
		Vector3? result = null;
		string text = arg.ToString();
		if (UnityUtils.TryParseToVector3(text, out var result2))
		{
			result = result2;
		}
		else
		{
			switch (text)
			{
			case "NorthEast":
			case "northeast":
			case "NE":
			case "ne":
			case "Forward":
			case "forward":
			case "F":
			case "f":
				result = Vector3.forward;
				break;
			case "SouthWest":
			case "southwest":
			case "SW":
			case "sw":
			case "Back":
			case "back":
			case "B":
			case "b":
				result = Vector3.back;
				break;
			case "SouthEast":
			case "southeast":
			case "SE":
			case "se":
			case "Right":
			case "right":
			case "R":
			case "r":
				result = Vector3.right;
				break;
			case "NorthWest":
			case "northwest":
			case "NW":
			case "nw":
			case "Left":
			case "left":
			case "L":
			case "l":
				result = Vector3.left;
				break;
			case "East":
			case "east":
			case "E":
			case "e":
				result = Vector3.forward + Vector3.right;
				break;
			case "North":
			case "north":
			case "N":
			case "n":
				result = Vector3.forward + Vector3.left;
				break;
			case "South":
			case "south":
			case "S":
			case "s":
				result = Vector3.back + Vector3.right;
				break;
			case "West":
			case "west":
			case "W":
			case "w":
				result = Vector3.back + Vector3.left;
				break;
			case "Up":
			case "up":
			case "U":
			case "u":
				result = Vector3.up;
				break;
			case "Down":
			case "down":
			case "D":
			case "d":
				result = Vector3.down;
				break;
			default:
				Debug.LogWarning($"DeveloperConsoleAction.ArgToDirection: can't convert arg \"{arg}\"");
				break;
			}
		}
		return result;
	}

	protected bool TryAutoCompleteDirection(string[] inputs, out string output)
	{
		output = "";
		if (inputs.Length != 1)
		{
			return false;
		}
		if (inputs[0].StartsWith("NorthE", StringComparison.CurrentCultureIgnoreCase) || inputs[0].StartsWith("NE", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "Northeast";
			return true;
		}
		if (inputs[0].StartsWith("NorthW", StringComparison.CurrentCultureIgnoreCase) || inputs[0].StartsWith("NW", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "Northwest";
			return true;
		}
		if (inputs[0].StartsWith("SouthE", StringComparison.CurrentCultureIgnoreCase) || inputs[0].StartsWith("SE", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "Southeast";
			return true;
		}
		if (inputs[0].StartsWith("SouthW", StringComparison.CurrentCultureIgnoreCase) || inputs[0].StartsWith("SE", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "Southwest";
			return true;
		}
		if (inputs[0].StartsWith("N", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "North";
			return true;
		}
		if (inputs[0].StartsWith("S", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "South";
			return true;
		}
		if (inputs[0].StartsWith("E", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "East";
			return true;
		}
		if (inputs[0].StartsWith("W", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "West";
			return true;
		}
		if (inputs[0].StartsWith("U", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "Up";
			return true;
		}
		if (inputs[0].StartsWith("D", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "Down";
			return true;
		}
		if (inputs[0].StartsWith("L", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "Left";
			return true;
		}
		if (inputs[0].StartsWith("R", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "Right";
			return true;
		}
		if (inputs[0].StartsWith("F", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "Forward";
			return true;
		}
		if (inputs[0].StartsWith("B", StringComparison.CurrentCultureIgnoreCase))
		{
			output = "Back";
			return true;
		}
		return false;
	}

	protected bool? ArgToBool(object arg)
	{
		bool? result = null;
		string text = arg.ToString();
		int result3;
		if (bool.TryParse(text, out var result2))
		{
			result = result2;
		}
		else if (int.TryParse(text, out result3))
		{
			result = Convert.ToBoolean(result3);
		}
		else if (text.Equals("T", StringComparison.CurrentCultureIgnoreCase))
		{
			result = true;
		}
		else if (text.Equals("F", StringComparison.CurrentCultureIgnoreCase))
		{
			result = false;
		}
		else
		{
			Debug.LogWarning($"DeveloperConsoleAction.ArgToBool: can't convert arg \"{arg}\"");
		}
		return result;
	}

	protected bool TryAutoCompleteBoolean(string[] inputs, out string output)
	{
		output = "";
		if (inputs.Length != 1)
		{
			return false;
		}
		if (inputs[0].StartsWith("F", StringComparison.CurrentCultureIgnoreCase) || (int.TryParse(inputs[0].ToString(), out var result) && result == 0))
		{
			output = "False";
		}
		else
		{
			output = "True";
		}
		return true;
	}

	protected bool TryAutoCompleteFromList(string[] inputs, List<string> validOutputs, out string output)
	{
		output = "";
		if (inputs.Length != 1)
		{
			return false;
		}
		string value = inputs[0];
		for (int i = 0; i < validOutputs.Count; i++)
		{
			if (validOutputs[i].Equals(value, StringComparison.CurrentCultureIgnoreCase))
			{
				i++;
				if (i > validOutputs.Count - 1)
				{
					i = 0;
				}
				output = validOutputs[i];
				break;
			}
			if (validOutputs[i].StartsWith(value, StringComparison.CurrentCultureIgnoreCase))
			{
				output = validOutputs[i];
				break;
			}
		}
		if (output.Contains(" "))
		{
			output = "\"" + output + "\"";
		}
		return !string.IsNullOrEmpty(output);
	}
}
