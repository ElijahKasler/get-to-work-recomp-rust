using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Harvestable Item List", menuName = "Scriptables/Item/Harvestable Item List")]
public class HarvestableItemList : ScriptableObject
{
	public List<HarvestableItem> items;

	public bool IsInRange(int num)
	{
		if (num >= items.Count)
		{
			return false;
		}
		return true;
	}

	public bool HasItem(int index)
	{
		return index < items.Count;
	}

	public bool ContainsItem(HarvestableItem item)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (items[i] == item)
			{
				return true;
			}
		}
		return false;
	}
}
