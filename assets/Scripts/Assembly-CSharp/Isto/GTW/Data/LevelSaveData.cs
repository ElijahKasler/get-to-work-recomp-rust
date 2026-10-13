using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Isto.Core;

namespace Isto.GTW.Data;

[Serializable]
[XmlRoot("LevelData")]
public class LevelSaveData
{
	public class LevelTime
	{
		public int levelID;

		public float time;

		public override bool Equals(object obj)
		{
			if (!(obj is LevelTime levelTime))
			{
				return false;
			}
			if (levelID != levelTime.levelID)
			{
				return false;
			}
			return time.Approx(levelTime.time);
		}

		public override int GetHashCode()
		{
			return (levelID, time).GetHashCode();
		}
	}

	public class EntryBool
	{
		public string Key;

		public bool Value;

		public EntryBool()
		{
		}

		public EntryBool(string key, bool value)
		{
			Key = key;
			Value = value;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			EntryBool entryBool = (EntryBool)obj;
			if (Key == entryBool.Key)
			{
				return Value == entryBool.Value;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Key.GetHashCode() ^ Value.GetHashCode();
		}
	}

	public class EntryInt
	{
		public string Key;

		public int Value;

		public EntryInt()
		{
		}

		public EntryInt(string key, int value)
		{
			Key = key;
			Value = value;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			EntryInt entryInt = (EntryInt)obj;
			if (Key == entryInt.Key)
			{
				return Value == entryInt.Value;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Key.GetHashCode() ^ Value.GetHashCode();
		}
	}

	public class EntryFloat
	{
		public string Key;

		public float Value;

		public EntryFloat()
		{
		}

		public EntryFloat(string key, float value)
		{
			Key = key;
			Value = value;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			EntryFloat entryFloat = (EntryFloat)obj;
			if (Key == entryFloat.Key)
			{
				return Value == entryFloat.Value;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Key.GetHashCode() ^ Value.GetHashCode();
		}
	}

	public List<EntryBool> boolVariables = new List<EntryBool>();

	public List<EntryInt> intVariables = new List<EntryInt>();

	public List<EntryFloat> floatVariables = new List<EntryFloat>();

	public List<LevelTime> gameTimePerLevel;

	public bool ContentEquals(LevelSaveData other)
	{
		if (other == null)
		{
			return false;
		}
		if (!boolVariables.All(other.boolVariables.Contains))
		{
			return false;
		}
		if (!intVariables.All(other.intVariables.Contains))
		{
			return false;
		}
		if (!floatVariables.All(other.floatVariables.Contains))
		{
			return false;
		}
		if (!gameTimePerLevel.SequenceEqualOrNull(other.gameTimePerLevel))
		{
			return false;
		}
		return true;
	}

	public void AddLevelTime(int level, float time)
	{
		if (gameTimePerLevel == null)
		{
			gameTimePerLevel = new List<LevelTime>();
		}
		gameTimePerLevel.Add(new LevelTime
		{
			levelID = level,
			time = time
		});
	}

	public Dictionary<int, float> GetLevelTimes()
	{
		Dictionary<int, float> dictionary = new Dictionary<int, float>();
		foreach (LevelTime item in gameTimePerLevel)
		{
			dictionary.Add(item.levelID, item.time);
		}
		return dictionary;
	}
}
