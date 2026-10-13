using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Item List", menuName = "Scriptables/Item/ItemPile List")]
public class ItemPileList : ScriptableObject
{
	public List<ItemPile> itemPiles;

	public bool IsInRange(int index)
	{
		if (index >= itemPiles.Count)
		{
			return false;
		}
		return true;
	}

	public bool HasItem(int index)
	{
		if (index < itemPiles.Count && itemPiles[index].item != null)
		{
			return true;
		}
		return false;
	}

	public bool HasItem(Item item)
	{
		if (itemPiles.Count > 0)
		{
			for (int i = 0; i < itemPiles.Count; i++)
			{
				if (itemPiles[i].item == item)
				{
					return true;
				}
			}
		}
		return false;
	}

	public int FindIndexOfItem(Item item)
	{
		if (HasItem(item))
		{
			int result = 0;
			for (int i = 0; i < itemPiles.Count; i++)
			{
				if (itemPiles[i].item == item)
				{
					result = i;
				}
			}
			return result;
		}
		Debug.LogError("Couldn't Find item in ItemPile (Despite doing a check)");
		return -1;
	}
}
