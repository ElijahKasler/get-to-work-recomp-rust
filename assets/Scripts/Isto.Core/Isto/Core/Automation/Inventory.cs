using System;
using System.Collections.Generic;
using System.Linq;
using Isto.Core.Items;
using UnityEngine;

namespace Isto.Core.Automation;

public class Inventory : IInventory
{
	public List<string> validItemIDs = new List<string>();

	public int PileCount { get; protected set; }

	public int PileSize { get; set; }

	public List<ItemPile> Items { get; protected set; }

	public event EventHandler<ItemEventArgs> InventoryChanged;

	public Inventory(int pileCount, int pileSize)
	{
		PileCount = pileCount;
		PileSize = pileSize;
		InitializeList();
	}

	public void InitializeList()
	{
		if (Items == null)
		{
			Items = new List<ItemPile>(PileCount);
			for (int i = 0; i < PileCount; i++)
			{
				Items.Add(new ItemPile());
			}
		}
	}

	public virtual int Add(CoreItem item, int count = 1, bool sendUpdateEvent = true)
	{
		if (Items == null)
		{
			Items = new List<ItemPile>(PileCount);
		}
		if (validItemIDs.Count != 0 && !validItemIDs.Contains(item.itemID))
		{
			return 0;
		}
		if (item == null)
		{
			return 0;
		}
		List<ItemPile> list = Items.FindAll((ItemPile x) => x.item == item);
		int num = count;
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			int num3 = PileSize - list[num2].count;
			if (num3 < num)
			{
				list[num2].count += num3;
				num -= num3;
			}
			else
			{
				list[num2].count += num;
				num = 0;
			}
		}
		while (num > 0)
		{
			int num4 = Items.FindIndex((ItemPile x) => x.item == null || x.count == 0);
			if (num4 == -1)
			{
				break;
			}
			if (num > PileSize)
			{
				Items[num4].Set(item, PileSize);
				num -= PileSize;
			}
			else
			{
				Items[num4].Set(item, num);
				num = 0;
			}
		}
		int num5 = count - num;
		if ((num5 != 0) & sendUpdateEvent)
		{
			SendUpdateEvents(item, num5);
		}
		return num5;
	}

	public int Add(ItemPile pile)
	{
		return Add(pile.item, pile.count);
	}

	public virtual int AddAt(ItemPile pile, int index)
	{
		if (Items.Count <= index)
		{
			return 0;
		}
		int num = 0;
		if (Items[index].item == null || Items[index].item == pile.item)
		{
			Items[index].item = pile.item;
			int num2 = PileSize - Items[index].count;
			num = ((num2 >= pile.count) ? pile.count : num2);
			Items[index].count += num;
		}
		if (num != 0)
		{
			SendUpdateEvents(pile.item, num);
		}
		return num;
	}

	public virtual int Remove(CoreItem item, int count = 1, bool sendUpdateEvent = true)
	{
		if (Items == null || Items.Count == 0 || item == null)
		{
			return 0;
		}
		List<ItemPile> list = (from x in Items.FindAll((ItemPile x) => x.item == item)
			orderby x.count
			select x).ToList();
		int num = count;
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			if (list[num2].count > num)
			{
				list[num2].count -= num;
				num = 0;
				break;
			}
			num -= list[num2].count;
			list[num2].count = 0;
			if (list[num2].count == 0)
			{
				list[num2].item = null;
			}
		}
		int num3 = count - num;
		if ((num3 != 0) & sendUpdateEvent)
		{
			SendUpdateEvents(item, -num3);
		}
		return num3;
	}

	public virtual ItemPile RemoveAt(int index, int count)
	{
		if (Items.Count < index + 1)
		{
			return null;
		}
		ItemPile itemPile = Items[index];
		ItemPile itemPile2 = new ItemPile();
		if (itemPile.count <= count)
		{
			itemPile2.Set(itemPile);
			Items[index].Clear();
		}
		else
		{
			itemPile.count -= count;
			itemPile2.Set(itemPile.item, count);
		}
		if (itemPile2.count != 0)
		{
			SendUpdateEvents(itemPile2.item, itemPile2.count);
		}
		return itemPile2;
	}

	public virtual ItemPile RemoveHalfAt(int index)
	{
		if (Items.Count < index + 1)
		{
			return null;
		}
		int count = Mathf.CeilToInt((float)Items[index].count / 2f);
		return RemoveAt(index, count);
	}

	public virtual ItemPile RemoveAt(int index)
	{
		if (Items.Count < index + 1)
		{
			return null;
		}
		return RemoveAt(index, Items[index].count);
	}

	public virtual List<ItemPile> RemoveAll(bool triggerEvent = true)
	{
		List<ItemPile> list = new List<ItemPile>();
		for (int i = 0; i < Items.Count; i++)
		{
			if (Items[i].item != null && Items[i].count != 0)
			{
				list.Add(new ItemPile(Items[i].item, Items[i].count));
			}
			Items[i].Clear();
		}
		if ((list.Count != 0) & triggerEvent)
		{
			SendUpdateEvents(null, 0);
		}
		return list;
	}

	public List<ItemPile> RemoveAllBut(List<Item> invalidItems, bool triggerEvent = true)
	{
		List<ItemPile> list = new List<ItemPile>();
		for (int i = 0; i < Items.Count; i++)
		{
			if (Items[i].item != null && Items[i].count != 0 && !invalidItems.Contains(Items[i].item))
			{
				list.Add(new ItemPile(Items[i].item, Items[i].count));
				Items[i].Clear();
			}
		}
		if ((list.Count != 0) & triggerEvent)
		{
			SendUpdateEvents(null, 0);
		}
		return list;
	}

	public int GetCountOfItem(CoreItem item)
	{
		if (Items == null || item == null)
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < Items.Count; i++)
		{
			num += ((Items[i].item == item) ? Items[i].count : 0);
		}
		return num;
	}

	public int GetCountOfItem(string itemID)
	{
		if (Items == null || string.IsNullOrEmpty(itemID))
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < Items.Count; i++)
		{
			if (Items[i].item != null)
			{
				num += (Items[i].item.itemID.Equals(itemID, StringComparison.OrdinalIgnoreCase) ? Items[i].count : 0);
			}
		}
		return num;
	}

	public int GetCountAt(int index)
	{
		if (Items == null)
		{
			return 0;
		}
		if (Items.Count < index)
		{
			return 0;
		}
		return Items[index].count;
	}

	public int GetHalfCountAt(int index)
	{
		if (Items == null)
		{
			return 0;
		}
		if (Items.Count < index + 1)
		{
			return 0;
		}
		return Mathf.CeilToInt((float)Items[index].count / 2f);
	}

	public int GetNumberOfPiles()
	{
		int num = 0;
		for (int i = 0; i < Items.Count; i++)
		{
			if (Items[i] != null && Items[i].item != null)
			{
				num++;
			}
		}
		return num;
	}

	public int GetTotalNumberOfItems()
	{
		int num = 0;
		for (int i = 0; i < Items.Count; i++)
		{
			if (Items[i] != null && Items[i].item != null)
			{
				num += Items[i].count;
			}
		}
		return num;
	}

	public ItemPile GetItemAt(int index)
	{
		if (index >= Items.Count)
		{
			return null;
		}
		return Items[index];
	}

	public int GetFirstIndexOfItem(CoreItem item)
	{
		return Items.FindIndex((ItemPile x) => x.item == item);
	}

	public bool AcceptsItem(CoreItem item)
	{
		if (validItemIDs.Count != 0 && !validItemIDs.Contains(item.itemID))
		{
			return false;
		}
		return true;
	}

	public bool AcceptsItem(ItemPile pile)
	{
		if (pile.item != null)
		{
			return AcceptsItem(pile.item);
		}
		return false;
	}

	public void SortAlphabetically()
	{
		List<ItemPile> list = RemoveAll(triggerEvent: false);
		for (int i = 0; i < list.Count; i++)
		{
			Add(list[i].item, list[i].count, sendUpdateEvent: false);
		}
		ItemPileComparer compare = new ItemPileComparer();
		Items.Sort((ItemPile x, ItemPile y) => compare.Compare(x, y));
	}

	public virtual int GetSpaceAvailable(CoreItem item)
	{
		if (item != null)
		{
			return GetSpaceAvailable(item.itemID);
		}
		return -1;
	}

	public virtual int GetSpaceAvailable(string itemID)
	{
		if (Items == null)
		{
			Items = new List<ItemPile>(PileCount);
		}
		if (validItemIDs.Count != 0 && !validItemIDs.Contains(itemID))
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < Items.Count; i++)
		{
			ItemPile itemPile = Items[i];
			if (itemPile.item != null && itemPile.item.itemID.Equals(itemID, StringComparison.OrdinalIgnoreCase))
			{
				num += PileSize - itemPile.count;
			}
			else if (itemPile.item == null)
			{
				num += PileSize;
			}
		}
		return num;
	}

	public int GetNumOpenSlots()
	{
		return Items.FindAll((ItemPile x) => x.item == null || x.count == 0).Count;
	}

	public float GetContainerPercentUsed()
	{
		int num = PileCount * PileSize;
		return (float)GetTotalNumberOfItems() / (float)num;
	}

	public bool HasSpaceFor(List<ItemPile> outputs)
	{
		if (outputs.Count > 1)
		{
			Debug.LogError("Inventory space check not fully robust enough to check for multiple outputs, please extend functionality");
		}
		bool flag = true;
		for (int i = 0; i < outputs.Count; i++)
		{
			flag &= GetSpaceAvailable(outputs[i].item) >= outputs[i].count;
		}
		return flag;
	}

	public bool HasIngredients(CoreItem item)
	{
		bool flag = true;
		if (item == null || item.GetRecipe() == null)
		{
			return false;
		}
		for (int i = 0; i < item.GetRecipe().inputs.Count; i++)
		{
			ItemPile itemPile = item.GetRecipe().inputs[i];
			flag = flag && GetCountOfItem(itemPile.item) >= itemPile.count;
		}
		return flag;
	}

	public bool HasAllInputs(Recipe recipe)
	{
		bool flag = true;
		for (int i = 0; i < recipe.inputs.Count; i++)
		{
			flag &= GetCountOfItem(recipe.inputs[i].item) >= recipe.inputs[i].count;
		}
		return flag;
	}

	public void SetPileCount(int count)
	{
		if (PileCount == count)
		{
			return;
		}
		if (Items.Count > count)
		{
			int num = count - 1;
			int count2 = Items.Count - count;
			if (num >= 0)
			{
				Items.RemoveRange(num, count2);
			}
			else
			{
				Items.Clear();
			}
		}
		else
		{
			int num2 = count - Items.Count;
			for (int i = 0; i < num2; i++)
			{
				Items.Add(new ItemPile());
			}
		}
		PileCount = count;
	}

	protected void SendUpdateEvents(CoreItem item, int change)
	{
		InventoryChanged?.Invoke(this, new ItemEventArgs(this, item, change));
	}
}
