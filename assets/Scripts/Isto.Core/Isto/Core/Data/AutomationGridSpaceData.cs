using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Isto.Core.Data;

[Serializable]
public class AutomationGridSpaceData
{
	public Vector3 position;

	public string resourceID;

	public float resourceHealth;

	public float growthPercent;

	public List<ItemData> items;

	public AutomationProcessorData processorData;

	public AutomationGridSpaceData()
	{
		items = new List<ItemData>();
	}

	public bool IsEmpty()
	{
		if (string.IsNullOrEmpty(resourceID) && items.Count == 0)
		{
			return processorData == null;
		}
		return false;
	}

	public override string ToString()
	{
		string text = ((items == null || items.Count <= 0) ? "no items" : ((items.Count == 1) ? ("item=" + items[0].id) : $"items.Count={items.Count}"));
		string text2 = ((processorData == null) ? "no processor" : processorData.typeId);
		return $"Space Data: pos={position}, r={resourceID}, h={resourceHealth}, g={growthPercent}, {text}, p={text2}";
	}

	public bool ContentEquals(AutomationGridSpaceData other)
	{
		if (other == null)
		{
			return false;
		}
		if (position != other.position)
		{
			return false;
		}
		if (!resourceID.IsEqualWithNullsAsEmpty(other.resourceID))
		{
			return false;
		}
		if (!resourceHealth.Approx(other.resourceHealth))
		{
			return false;
		}
		if (!growthPercent.Approx(other.growthPercent))
		{
			return false;
		}
		if (processorData == null && other.processorData != null)
		{
			return false;
		}
		if (processorData != null && !processorData.Equals(other.processorData))
		{
			return false;
		}
		if (items == null && other.items != null)
		{
			return false;
		}
		if (items != null && other.items == null)
		{
			return false;
		}
		if (items.Count != other.items.Count)
		{
			return false;
		}
		return items.SequenceEqual(other.items);
	}
}
