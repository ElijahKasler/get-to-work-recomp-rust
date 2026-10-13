using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Isto.Core.Data;

[Serializable]
[XmlRoot("PlayerData")]
public class PlayerResearchSaveData
{
	public List<string> researchedItemsIds;

	public string currentResearchItemID;

	public float currentResearchedPercent;

	public bool moduleOnline;

	public bool moduleInspected;

	public int buildingLevel;

	public PlayerResearchSaveData()
	{
		researchedItemsIds = new List<string>();
	}

	public bool ContentEquals(PlayerResearchSaveData other)
	{
		if (other == null)
		{
			return false;
		}
		if (!currentResearchItemID.IsEqualWithNullsAsEmpty(other.currentResearchItemID))
		{
			return false;
		}
		if (!currentResearchedPercent.Approx(other.currentResearchedPercent))
		{
			return false;
		}
		if (moduleOnline != other.moduleOnline)
		{
			return false;
		}
		if (moduleInspected != other.moduleInspected)
		{
			return false;
		}
		if (buildingLevel != other.buildingLevel)
		{
			return false;
		}
		return researchedItemsIds.SequenceEqualOrNull(other.researchedItemsIds);
	}
}
