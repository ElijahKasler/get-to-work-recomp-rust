using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Isto.Core.Automation;

public class RigidInventory : Inventory, IRigidInventory, IInventory
{
	public RigidInventory(int pileCount, int pileSize)
		: base(pileCount, pileSize)
	{
	}

	public bool HasItemsSetOnPiles()
	{
		if (base.Items.Count == 0)
		{
			return false;
		}
		for (int i = 0; i < base.Items.Count; i++)
		{
			if (base.Items[i].item == null)
			{
				return false;
			}
		}
		return true;
	}

	public void SetItemConstraintForPile(int index, CoreItem item)
	{
		if (base.Items.Count < 0 || index >= base.Items.Count)
		{
			Debug.LogError("Trying to add at index that is out of bounds.  Index: " + index);
			return;
		}
		base.Items[index].item = item;
		base.Items[index].count = 0;
	}

	public override int Add(CoreItem item, int count = 1, bool sendUpdateEvent = true)
	{
		if (base.Items == null)
		{
			base.Items = new List<ItemPile>(base.PileCount);
		}
		if (item == null)
		{
			return 0;
		}
		List<ItemPile> list = base.Items.FindAll((ItemPile x) => x.item == item);
		int num = count;
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			int num3 = base.PileSize - list[num2].count;
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
		int num4 = count - num;
		if ((num4 != 0) & sendUpdateEvent)
		{
			SendUpdateEvents(item, num4);
		}
		return num4;
	}

	public override int AddAt(ItemPile pile, int index)
	{
		if (base.Items.Count <= index)
		{
			return 0;
		}
		int num = 0;
		if (base.Items[index].item == pile.item)
		{
			base.Items[index].item = pile.item;
			int num2 = base.PileSize - base.Items[index].count;
			num = ((num2 >= pile.count) ? pile.count : num2);
			base.Items[index].count += num;
		}
		if (num != 0)
		{
			SendUpdateEvents(pile.item, num);
		}
		return num;
	}

	public override int Remove(CoreItem item, int count = 1, bool sendUpdateEvent = true)
	{
		if (base.Items == null || base.Items.Count == 0 || item == null)
		{
			return 0;
		}
		return Remove(item.itemID, count);
	}

	public int Remove(string itemID, int count = 1)
	{
		if (base.Items == null || base.Items.Count == 0 || string.IsNullOrEmpty(itemID))
		{
			return 0;
		}
		IOrderedEnumerable<ItemPile> orderedEnumerable = from x in base.Items.FindAll((ItemPile x) => x.item.itemID.Equals(itemID, StringComparison.OrdinalIgnoreCase))
			orderby x.count
			select x;
		int num = count;
		foreach (ItemPile item in orderedEnumerable)
		{
			if (item.count > num)
			{
				item.count -= num;
				num = 0;
				break;
			}
			num -= item.count;
			item.count = 0;
		}
		int num2 = count - num;
		if (num2 != 0)
		{
			SendUpdateEvents(null, -num2);
		}
		return num2;
	}

	public override ItemPile RemoveAt(int index, int count)
	{
		if (base.Items.Count < index + 1)
		{
			return null;
		}
		ItemPile itemPile = base.Items[index];
		ItemPile itemPile2 = new ItemPile();
		if (itemPile.count <= count)
		{
			itemPile2.Set(itemPile);
			base.Items[index].count = 0;
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

	public override List<ItemPile> RemoveAll(bool triggerEvent = true)
	{
		List<ItemPile> list = new List<ItemPile>();
		for (int i = 0; i < base.Items.Count; i++)
		{
			if (base.Items[i].item != null && base.Items[i].count != 0)
			{
				list.Add(new ItemPile(base.Items[i].item, base.Items[i].count));
			}
			base.Items[i].count = 0;
		}
		if ((list.Count != 0) & triggerEvent)
		{
			SendUpdateEvents(null, 0);
		}
		return list;
	}

	public override int GetSpaceAvailable(CoreItem item)
	{
		if (item != null)
		{
			return GetSpaceAvailable(item.itemID);
		}
		return 0;
	}

	public override int GetSpaceAvailable(string itemID)
	{
		if (base.Items == null)
		{
			base.Items = new List<ItemPile>(base.PileCount);
		}
		int num = 0;
		for (int i = 0; i < base.Items.Count; i++)
		{
			if (base.Items[i].item != null && base.Items[i].item.itemID.Equals(itemID, StringComparison.OrdinalIgnoreCase))
			{
				num += base.PileSize - base.Items[i].count;
			}
		}
		return num;
	}
}
