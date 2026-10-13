using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Isto.Core.Automation;
using Isto.Core.Items;
using UnityEngine;

namespace Isto.Core.Data;

[Serializable]
public class ItemData
{
	[XmlAttribute("ID")]
	public string id;

	[XmlAttribute("Name")]
	public string itemName;

	public int count;

	public ItemData()
	{
		id = "";
		itemName = "";
		count = 0;
	}

	public ItemData(ItemPile itemPile)
	{
		if (itemPile != null && itemPile.HasItems())
		{
			id = itemPile.item.itemID;
			itemName = itemPile.item.itemName;
			count = itemPile.count;
		}
	}

	public ItemData(string guid, string itemName, int count)
	{
		id = guid;
		this.itemName = itemName;
		this.count = count;
	}

	public static List<ItemData> ConvertItemPileList(List<ItemPile> items)
	{
		List<ItemData> list = new List<ItemData>();
		foreach (ItemPile item in items)
		{
			list.Add(new ItemData(item));
		}
		return list;
	}

	public static void LoadItemsIntoInventory(ItemData[] items, IInventory inventory, MasterItemList masterItemList)
	{
		for (int i = 0; i < items.Length; i++)
		{
			CoreItem itemByID = masterItemList.GetItemByID<CoreItem>(items[i].id);
			if (itemByID != null && inventory.Add(itemByID, items[i].count) != items[i].count)
			{
				Debug.LogWarning("Cannot put ItemData into inventory, should be only used for loading data and this shouldn't happen.");
			}
		}
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ItemData itemData))
		{
			return false;
		}
		if (!id.IsEqualWithNullsAsEmpty(itemData.id))
		{
			return false;
		}
		return count == itemData.count;
	}

	public override int GetHashCode()
	{
		return (id, itemName, count).GetHashCode();
	}
}
