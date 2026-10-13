using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

namespace Isto.Core.Data;

[Serializable]
[XmlRoot("Automation System")]
public class AutomationSystemData
{
	[Serializable]
	public class SuperBulbData
	{
		public Vector3 position;

		public string bulbID;

		public SuperBulbData()
		{
		}

		public SuperBulbData(Vector3 position, string bulbID)
		{
			this.position = position;
			this.bulbID = bulbID;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is SuperBulbData superBulbData))
			{
				return false;
			}
			if (position != superBulbData.position)
			{
				return false;
			}
			return bulbID == superBulbData.bulbID;
		}

		public override int GetHashCode()
		{
			return (position, bulbID).GetHashCode();
		}
	}

	public List<AutomationGridSpaceData> gridSpaces;

	public List<Vector3> lightBulbPositions;

	public List<SuperBulbData> superBulbPositions;

	public AutomationSystemData()
	{
		gridSpaces = new List<AutomationGridSpaceData>();
		lightBulbPositions = new List<Vector3>();
		superBulbPositions = new List<SuperBulbData>();
	}

	public bool ContentEquals(AutomationSystemData other)
	{
		if (gridSpaces != null && other.gridSpaces == null)
		{
			return false;
		}
		if (gridSpaces == null && other.gridSpaces != null)
		{
			return false;
		}
		if (gridSpaces != null && gridSpaces.Count != other.gridSpaces.Count)
		{
			return false;
		}
		if (!superBulbPositions.SequenceEqualOrNull(other.superBulbPositions))
		{
			return false;
		}
		if (!lightBulbPositions.SequenceEqualOrNull(other.lightBulbPositions))
		{
			return false;
		}
		bool result = true;
		if (gridSpaces != null && other.gridSpaces != null)
		{
			for (int i = 0; i < gridSpaces.Count; i++)
			{
				AutomationGridSpaceData automationGridSpaceData = gridSpaces[i];
				AutomationGridSpaceData automationGridSpaceData2 = other.gridSpaces[i];
				if (automationGridSpaceData == null || automationGridSpaceData2 == null || !automationGridSpaceData.ContentEquals(automationGridSpaceData2))
				{
					result = false;
					Debug.LogError("Automation grid space mismatch in automation data post serialization");
					break;
				}
			}
		}
		return result;
	}
}
