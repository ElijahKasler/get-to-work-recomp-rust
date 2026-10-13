using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Item List", menuName = "Scriptables/Item/Item List")]
public class ItemList : ScriptableObject
{
	public List<CoreItem> items;

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
		if (index < items.Count)
		{
			return true;
		}
		return false;
	}

	public bool ContainsItem(CoreItem item)
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
