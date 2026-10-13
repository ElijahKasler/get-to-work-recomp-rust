using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Isto.Core.Automation;

[Serializable]
public class AutomationGrid
{
	public const int AUTOMATION_TABLE_SIZE = 4194304;

	public const int INVALID_ARRAY_INDEX = -1;

	private Dictionary<int, AutomationGridSpace> _automationGrid;

	private Dictionary<int, AutomationGridSpace> _sleepingGridSpaces;

	private AutomationGridSpace[] _automationTable;

	public Dictionary<int, AutomationGridSpace>.ValueCollection ActiveSpaces => _automationGrid.Values;

	public Dictionary<int, AutomationGridSpace>.ValueCollection SleepingSpaces => _sleepingGridSpaces.Values;

	public IEnumerable<AutomationGridSpace> AllSpaces => _automationGrid.Values.Union(_sleepingGridSpaces.Values);

	public AutomationGrid()
	{
	}

	public AutomationGrid(bool dummyFlag)
	{
		_automationGrid = new Dictionary<int, AutomationGridSpace>();
		_sleepingGridSpaces = new Dictionary<int, AutomationGridSpace>();
		_automationTable = new AutomationGridSpace[4194304];
	}

	public bool TryAddToGrid(AutomationGridSpace space)
	{
		if (DoesSpaceExist((int)space.position.x, (int)space.position.z))
		{
			return false;
		}
		int num = HashCoordinate((int)space.position.x, (int)space.position.z);
		_automationGrid.Add(num, space);
		_automationTable[num] = space;
		return true;
	}

	public bool DoesSpaceExist(float x, float y)
	{
		return DoesSpaceExist(Mathf.RoundToInt(x), Mathf.RoundToInt(y));
	}

	public bool DoesSpaceExist(int x, int y)
	{
		int num = HashCoordinate(x, y);
		return _automationTable[num] != null;
	}

	public bool TryGetSpace(float x, float y, ref AutomationGridSpace space)
	{
		return TryGetSpace(Mathf.RoundToInt(x), Mathf.RoundToInt(y), ref space);
	}

	public bool TryGetSpace(int x, int y, ref AutomationGridSpace space)
	{
		int num = HashCoordinate(x, y);
		space = _automationTable[num];
		return space != null;
	}

	public void RemoveSpace(AutomationGridSpace space)
	{
		int num = HashCoordinate((int)space.position.x, (int)space.position.z);
		if (!_automationGrid.Remove(num))
		{
			_sleepingGridSpaces.Remove(num);
		}
		_automationTable[num] = null;
	}

	public void ClearGrid()
	{
		_automationGrid = new Dictionary<int, AutomationGridSpace>();
		_sleepingGridSpaces = new Dictionary<int, AutomationGridSpace>();
		_automationTable = new AutomationGridSpace[4194304];
	}

	public void PutSpaceToSleep(AutomationGridSpace space)
	{
		int key = HashCoordinate(Mathf.RoundToInt(space.position.x), Mathf.RoundToInt(space.position.z));
		if (_automationGrid.ContainsKey(key) && !_sleepingGridSpaces.ContainsKey(key))
		{
			_automationGrid.Remove(key);
			_sleepingGridSpaces.Add(key, space);
			space.SetSleepingFlag();
		}
		else if (_sleepingGridSpaces.ContainsKey(key))
		{
			Debug.LogError($"Automation Grid Space is already sleeping at {space.position}");
		}
		else if (!_automationGrid.ContainsKey(key))
		{
			Debug.LogError($"Trying to put to sleep a grid space that is not in the active spaces dictionary. {space.position}");
		}
	}

	public void WakeUpSleepingSpace(AutomationGridSpace space)
	{
		int key = HashCoordinate(Mathf.RoundToInt(space.position.x), Mathf.RoundToInt(space.position.z));
		if (_sleepingGridSpaces.ContainsKey(key) && !_automationGrid.ContainsKey(key))
		{
			_sleepingGridSpaces.Remove(key);
			_automationGrid.Add(key, space);
			space.ClearSleepingFlag();
		}
		else if (!_sleepingGridSpaces.ContainsKey(key))
		{
			Debug.LogError($"Automation Grid Space is not sleeping at {space.position}");
		}
		else if (_automationGrid.ContainsKey(key))
		{
			Debug.LogError($"Trying to wake up a grid space that is not in the sleeping spaces dictionary. {space.position}");
		}
	}

	public static int HashCoordinate(int x, int y)
	{
		if (x < -1023 || x > 1023 || y < -1023 || y > 1023)
		{
			return -1;
		}
		int num = x + 1023;
		uint num2 = (uint)(y + 1023);
		uint num3 = (uint)(num << 11) + num2;
		if (num3 >= 4194304)
		{
			return -1;
		}
		return (int)num3;
	}

	public void SearchForSpaces(Vector3Int topLeft, Vector3Int botRight, Func<AutomationGridSpace, bool> predicate, ref List<Vector3> spacePositions)
	{
		spacePositions.Clear();
		SearchInternal(topLeft.x, topLeft.z, botRight.x, botRight.z, predicate, ref spacePositions);
	}

	private void SearchInternal(int leftX, int leftZ, int rightX, int rightZ, Func<AutomationGridSpace, bool> predicate, ref List<Vector3> spacePositions)
	{
		for (int i = leftX; i < rightX; i++)
		{
			for (int j = leftZ; j < rightZ; j++)
			{
				AutomationGridSpace space = null;
				if (TryGetSpace(i, j, ref space) && space != null && predicate(space))
				{
					spacePositions.Add(space.position);
				}
			}
		}
	}

	public override string ToString()
	{
		string text = "";
		text += $"Total Automation Spaces: {_automationGrid.Values.Count} \n";
		foreach (AutomationGridSpace value in _automationGrid.Values)
		{
			text = text + $"({value.position.x},{value.position.z}).  HashPos:{HashCoordinate((int)value.position.x, (int)value.position.z)}." + "  Resource:" + value.Resource?.ID + ".  Processor:" + value.itemProcessor?.ToString() + ".  CoreItem:" + value.ActiveItem?.ID + "\n";
		}
		return text;
	}
}
