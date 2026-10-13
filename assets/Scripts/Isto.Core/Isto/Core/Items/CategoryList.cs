using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "Category List", menuName = "Scriptables/Item/Category List")]
public class CategoryList : ScriptableObject
{
	public List<CraftingCategory> categories;

	public CoreItem defaultItem;

	public List<CoreItem> GetAllItemsInList()
	{
		List<CoreItem> list = new List<CoreItem>();
		for (int i = 0; i < categories.Count; i++)
		{
			CraftingCategory craftingCategory = categories[i];
			for (int j = 0; j < craftingCategory.itemList.Count; j++)
			{
				CraftingSubCategory craftingSubCategory = craftingCategory.itemList[j];
				for (int k = 0; k < craftingSubCategory.list.Count; k++)
				{
					if (craftingSubCategory.list[k].itemID != MasterItemList.LOCKED_ITEM_ID)
					{
						list.Add(craftingSubCategory.list[k]);
					}
				}
			}
		}
		return list;
	}
}
