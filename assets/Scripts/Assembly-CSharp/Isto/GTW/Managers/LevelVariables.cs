using System.Collections.Generic;
using UnityEngine;

namespace Isto.GTW.Managers;

public class LevelVariables : MonoBehaviour
{
	public Dictionary<string, bool> boolVariables = new Dictionary<string, bool>();

	public Dictionary<string, int> intVariables = new Dictionary<string, int>();

	public Dictionary<string, float> floatVariables = new Dictionary<string, float>();

	public bool GetBool(string id, bool defaultValue = false)
	{
		bool value = defaultValue;
		if (!boolVariables.TryGetValue(id, out value))
		{
			boolVariables.Add(id, value);
		}
		return value;
	}

	public void SetBool(string id, bool value)
	{
		if (boolVariables.ContainsKey(id))
		{
			boolVariables[id] = value;
		}
		else
		{
			boolVariables.Add(id, value);
		}
	}

	public int GetInt(string id, int defaultValue = 0)
	{
		int value = defaultValue;
		if (!intVariables.TryGetValue(id, out value))
		{
			intVariables.Add(id, value);
		}
		return value;
	}

	public void SetInt(string id, int value)
	{
		if (intVariables.ContainsKey(id))
		{
			intVariables[id] = value;
		}
		else
		{
			intVariables.Add(id, value);
		}
	}

	public float GetFloat(string id, float defaultValue = 0f)
	{
		float value = defaultValue;
		if (!floatVariables.TryGetValue(id, out value))
		{
			floatVariables.Add(id, value);
		}
		return value;
	}

	public void SetFloat(string id, float value)
	{
		if (floatVariables.ContainsKey(id))
		{
			floatVariables[id] = value;
		}
		else
		{
			floatVariables.Add(id, value);
		}
	}

	public void OutputVariables()
	{
		string text = "LevelVariables:";
		if (boolVariables != null)
		{
			text = text + "\nBool variable count: " + boolVariables.Count;
		}
		if (intVariables != null)
		{
			text = text + "\nInt variable count: " + intVariables.Count;
		}
		if (floatVariables != null)
		{
			text = text + "\nFloat variable count: " + floatVariables.Count;
		}
		Debug.Log(text);
	}
}
