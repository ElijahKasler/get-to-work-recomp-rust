using System.Collections.Generic;
using I2.Loc;
using Isto.Core.Beings;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "Crafting Category", menuName = "Scriptables/Item/CraftingCategory")]
public class CraftingCategory : ScriptableObject
{
	[Tooltip("Not in use, this string is kept only for reference")]
	public string title;

	public LocalizedString titleKey;

	public Sprite image;

	public List<CraftingSubCategory> itemList;

	public CoreItem GetItem(int row, int col)
	{
		if (row >= itemList.Count)
		{
			return null;
		}
		if (col >= itemList[row].list.Count)
		{
			return null;
		}
		return itemList[row].list[col];
	}

	public bool ContainsItem(CoreItem item)
	{
		for (int i = 0; i < itemList.Count; i++)
		{
			for (int j = 0; j < itemList[i].list.Count; j++)
			{
				if (itemList[i].list[j].itemID.Equals(item.itemID))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool HasUnlockedItems(PlayerProgress progress)
	{
		for (int i = 0; i < itemList.Count; i++)
		{
			CraftingSubCategory craftingSubCategory = itemList[i];
			for (int j = 0; j < craftingSubCategory.list.Count; j++)
			{
				if (progress.IsItemUnlocked(craftingSubCategory.list[j]))
				{
					return true;
				}
			}
		}
		return false;
	}

	public int GetNumberUnseenItems(PlayerProgress playerProgress)
	{
		int num = 0;
		for (int i = 0; i < itemList.Count; i++)
		{
			for (int j = 0; j < itemList[i].list.Count; j++)
			{
				CoreItem item = itemList[i].list[j];
				if (playerProgress.IsItemUnlocked(item) && !playerProgress.HasItemBeenSeen(item))
				{
					num++;
				}
			}
		}
		return num;
	}
}
