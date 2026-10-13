using System;
using System.Collections.Generic;
using System.Linq;
using Isto.Core.Automation;
using UnityEngine;

namespace Isto.Core.Items;

public class ItemContainer : MonoBehaviour, IItemTopmostParent, IInventory
{
	[Tooltip("The total number of item piles that this container has")]
	public int pileCount = 10;

	[Tooltip("This maximum count for each item pile (stack size)")]
	public int maxPileSize = 50;

	[Tooltip("Items that can be placed in container, if empty, all items are valid")]
	public List<CoreItem> validItems = new List<CoreItem>();

	private List<string> _validItemIDs = new List<string>();

	private List<ItemPile> _items;

	public List<ItemPile> Items => _items;

	public int PileCount => pileCount;

	public int PileSize => maxPileSize;

	public event EventHandler<ItemEventArgs> InventoryChanged;

	public virtual void Awake()
	{
		InitializeList();
	}

	public void InitializeList()
	{
		if (_items == null)
		{
			_items = new List<ItemPile>(pileCount);
			for (int i = 0; i < pileCount; i++)
			{
				_items.Add(new ItemPile());
			}
			for (int j = 0; j < validItems.Count; j++)
			{
				_validItemIDs.Add(validItems[j].itemID);
			}
		}
	}

	public virtual int Add(CoreItem item, int count = 1, bool sendUpdateEvent = true)
	{
		if (_items == null)
		{
			_items = new List<ItemPile>(pileCount);
		}
		if (_validItemIDs.Count != 0 && !_validItemIDs.Contains(item.itemID))
		{
			return 0;
		}
		if (item == null)
		{
			return 0;
		}
		List<ItemPile> list = _items.FindAll((ItemPile x) => x.item == item);
		int num = count;
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			int num3 = maxPileSize - list[num2].count;
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
			int num4 = _items.FindIndex((ItemPile x) => x.item == null || x.count == 0);
			if (num4 == -1)
			{
				SendMessage(MessageFunctions.INVENTORY_FULL, SendMessageOptions.DontRequireReceiver);
				break;
			}
			if (num > maxPileSize)
			{
				_items[num4].Set(item, maxPileSize);
				num -= maxPileSize;
			}
			else
			{
				_items[num4].Set(item, num);
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
		if (_items.Count <= index)
		{
			return 0;
		}
		int num = 0;
		if (_items[index].item == null || _items[index].item == pile.item)
		{
			_items[index].item = pile.item;
			int num2 = maxPileSize - _items[index].count;
			num = ((num2 >= pile.count) ? pile.count : num2);
			_items[index].count += num;
		}
		if (num != 0)
		{
			SendUpdateEvents(pile.item, num);
		}
		return num;
	}

	public virtual int Remove(CoreItem item, int count = 1, bool sendUpdateEvent = true)
	{
		if (_items == null || _items.Count == 0 || item == null)
		{
			return 0;
		}
		List<ItemPile> list = (from x in _items.FindAll((ItemPile x) => x.item == item)
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
		if (_items.Count < index + 1)
		{
			return null;
		}
		ItemPile itemPile = _items[index];
		ItemPile itemPile2 = new ItemPile();
		if (itemPile.count <= count)
		{
			itemPile2.Set(itemPile);
			_items[index].Clear();
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
		if (_items.Count < index + 1)
		{
			return null;
		}
		int count = (int)Mathf.Ceil((float)_items[index].count / 2f);
		return RemoveAt(index, count);
	}

	public virtual ItemPile RemoveAt(int index)
	{
		if (_items.Count < index + 1)
		{
			return null;
		}
		return RemoveAt(index, _items[index].count);
	}

	public virtual List<ItemPile> RemoveAll(bool triggerEvent = true)
	{
		List<ItemPile> list = new List<ItemPile>();
		for (int i = 0; i < _items.Count; i++)
		{
			if (_items[i].item != null && _items[i].count != 0)
			{
				list.Add(new ItemPile(_items[i].item, _items[i].count));
			}
			_items[i].Clear();
		}
		if ((list.Count != 0) & triggerEvent)
		{
			SendUpdateEvents(null, 0);
		}
		return list;
	}

	public virtual List<ItemPile> RemoveAllBut(List<Item> invalidItems, bool triggerEvent = true)
	{
		List<ItemPile> list = new List<ItemPile>();
		for (int i = 0; i < _items.Count; i++)
		{
			if (_items[i].item != null && _items[i].count != 0 && !invalidItems.Contains(_items[i].item))
			{
				list.Add(new ItemPile(_items[i].item, _items[i].count));
				_items[i].Clear();
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
		if (_items == null || item == null)
		{
			return 0;
		}
		return GetCountOfItem(item.itemID);
	}

	public int GetCountOfItem(string itemID)
	{
		if (_items == null || string.IsNullOrEmpty(itemID))
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < _items.Count; i++)
		{
			num += ((_items[i].item?.itemID == itemID) ? _items[i].count : 0);
		}
		return num;
	}

	public int GetCountAt(int index)
	{
		if (_items == null)
		{
			return 0;
		}
		if (_items.Count < index)
		{
			return 0;
		}
		return _items[index].count;
	}

	public int GetHalfCountAt(int index)
	{
		if (_items == null)
		{
			return 0;
		}
		if (_items.Count < index + 1)
		{
			return 0;
		}
		return (int)Mathf.Ceil((float)_items[index].count / 2f);
	}

	public int GetNumberOfPiles()
	{
		int num = 0;
		for (int i = 0; i < _items.Count; i++)
		{
			if (_items[i] != null && _items[i].item != null)
			{
				num++;
			}
		}
		return num;
	}

	public int GetTotalNumberOfItems()
	{
		int num = 0;
		for (int i = 0; i < _items.Count; i++)
		{
			if (_items[i] != null && _items[i].item != null)
			{
				num += _items[i].count;
			}
		}
		return num;
	}

	public ItemPile GetItemAt(int index)
	{
		if (index >= _items.Count)
		{
			return null;
		}
		return _items[index];
	}

	public int GetFirstIndexOfItem(CoreItem item)
	{
		return _items.FindIndex((ItemPile x) => x.item == item);
	}

	public bool AcceptsItem(CoreItem item)
	{
		if (_validItemIDs.Count != 0 && !_validItemIDs.Contains(item.itemID))
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
		MyComparer compare = new MyComparer();
		_items.Sort((ItemPile x, ItemPile y) => compare.Compare(x, y));
	}

	public int GetSpaceAvailable(CoreItem item)
	{
		if (_items == null)
		{
			_items = new List<ItemPile>(pileCount);
		}
		if (_validItemIDs.Count != 0 && !_validItemIDs.Contains(item.itemID))
		{
			return 0;
		}
		List<ItemPile> list = _items.FindAll((ItemPile x) => x.item == item);
		int num = 0;
		for (int num2 = 0; num2 < list.Count; num2++)
		{
			num += maxPileSize - list[num2].count;
		}
		int count = _items.FindAll((ItemPile x) => x.item == null || x.count == 0).Count;
		return num + count * maxPileSize;
	}

	public int GetNumOpenSlots()
	{
		return _items.FindAll((ItemPile x) => x.item == null || x.count == 0).Count;
	}

	public float GetContainerPercentUsed()
	{
		return 1f - (float)GetNumOpenSlots() / (float)pileCount;
	}

	public bool HasSpaceFor(List<ItemPile> outputs)
	{
		bool result = true;
		int num = 0;
		for (int i = num; i < outputs.Count; i++)
		{
			if (GetSpaceAvailable(outputs[i].item) > outputs[i].count)
			{
				Add(outputs[i].item, outputs[i].count, sendUpdateEvent: false);
				num++;
				continue;
			}
			result = false;
			break;
		}
		for (int num2 = num - 1; num2 >= 0; num2--)
		{
			Remove(outputs[num2].item, outputs[num2].count, sendUpdateEvent: false);
		}
		return result;
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

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	protected virtual void SendUpdateEvents(CoreItem item, int change)
	{
		SendMessage(MessageFunctions.INVENTORY_UPDATE, SendMessageOptions.DontRequireReceiver);
		InventoryChanged?.Invoke(this, new ItemEventArgs(this, item, change));
	}

	public virtual void SetPileCount(int count)
	{
		if (pileCount == count)
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
		pileCount = count;
	}
}
