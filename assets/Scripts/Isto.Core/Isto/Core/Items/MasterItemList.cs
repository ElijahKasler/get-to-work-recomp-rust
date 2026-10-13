using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "Master Item List", menuName = "Scriptables/Item/Master Item List")]
public class MasterItemList : ScriptableObject
{
	public static readonly string ITEM_ENTRANCE_ID = "ItemEntrance";

	public static readonly string LOCKED_ITEM_ID = "LockedItem";

	public List<Item> items;

	public List<ResearchItem> researchItems;

	public List<BuffEffect> buffEffects;

	private Dictionary<string, Item> _allItemsByID;

	public void Init()
	{
		_allItemsByID = new Dictionary<string, Item>();
		for (int i = 0; i < items.Count; i++)
		{
			if (!items[i])
			{
				Debug.LogError("Missing or null item in MasterItem list. If an item was deleted this may need to be cleaned up", this);
				continue;
			}
			_allItemsByID.Add(items[i].itemID, items[i]);
			if (!_allItemsByID.ContainsKey(items[i].itemID.ToLower()))
			{
				_allItemsByID.Add(items[i].itemID.ToLower(), items[i]);
			}
		}
	}

	public T GetItemByName<T>(string name) where T : Item
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (string.Equals(items[i].itemName, name, StringComparison.CurrentCultureIgnoreCase))
			{
				if (items[i] is T)
				{
					return (T)items[i];
				}
				Debug.LogWarning($"Expecting type {typeof(T).ToString()} for item {name} but type is {items[i].GetType()}");
				return null;
			}
		}
		Debug.LogError("couldn't find the item: " + name);
		return null;
	}

	public T GetItemByID<T>(string id, string itemName = "") where T : Item
	{
		if (string.IsNullOrEmpty(id))
		{
			return null;
		}
		if (_allItemsByID == null)
		{
			Init();
		}
		if (_allItemsByID.ContainsKey(id))
		{
			if (_allItemsByID[id] is T)
			{
				return (T)_allItemsByID[id];
			}
			return null;
		}
		if (!id.Equals("ItemEntrance") && !id.Equals("BoosterEntrance"))
		{
			Debug.LogWarning("couldn't find Item:" + itemName + " with guid: " + id + " in master item list.  Make sure it exists in the list");
		}
		return null;
	}

	public bool TryGetBuffEffectByID(string id, out BuffEffect buffEffect)
	{
		for (int i = 0; i < buffEffects.Count; i++)
		{
			if (buffEffects[i].ID == id)
			{
				buffEffect = buffEffects[i];
				return true;
			}
		}
		buffEffect = null;
		return false;
	}

	public bool TryGetItemByID<T>(string id, out T item, string itemName = "") where T : Item
	{
		item = GetItemByID<T>(id, itemName);
		if (item == null)
		{
			return false;
		}
		return true;
	}

	public List<AdvancedItem> GetAllAdvancedItems()
	{
		List<Item> list = items.Where((Item x) => x.GetType() == typeof(AdvancedItem)).ToList();
		List<AdvancedItem> list2 = new List<AdvancedItem>();
		for (int num = 0; num < list.Count; num++)
		{
			list2.Add((AdvancedItem)list[num]);
		}
		return list2;
	}

	public List<EquippableItem> GetAllEquippableItems()
	{
		List<Item> list = items.Where((Item x) => x.GetType() == typeof(EquippableItem)).ToList();
		List<EquippableItem> list2 = new List<EquippableItem>();
		for (int num = 0; num < list.Count; num++)
		{
			list2.Add((EquippableItem)list[num]);
		}
		return list2;
	}

	public List<CoreItem> GetAllCoreItems()
	{
		List<Item> list = items.Where((Item x) => x.GetType() == typeof(CoreItem)).ToList();
		List<CoreItem> list2 = new List<CoreItem>();
		for (int num = 0; num < list.Count; num++)
		{
			list2.Add((CoreItem)list[num]);
		}
		return list2;
	}

	public List<CoreItem> GetAllCoreHarvestedItems()
	{
		List<Item> list = items.Where((Item x) => x.GetType() == typeof(CoreItem)).ToList();
		List<CoreItem> list2 = new List<CoreItem>();
		for (int num = 0; num < list.Count; num++)
		{
			if (((CoreItem)list[num]).fromHarvestableItem)
			{
				list2.Add((CoreItem)list[num]);
			}
		}
		return list2;
	}

	public List<HarvestableItem> GetAllHarvestableItems()
	{
		List<Item> list = items.Where((Item x) => x.GetType() == typeof(HarvestableItem)).ToList();
		List<HarvestableItem> list2 = new List<HarvestableItem>();
		for (int num = 0; num < list.Count; num++)
		{
			list2.Add((HarvestableItem)list[num]);
		}
		return list2;
	}

	public ResearchItem GetResearchItemByID(string id, string itemName)
	{
		for (int i = 0; i < researchItems.Count; i++)
		{
			if (string.Equals(researchItems[i].ID, id, StringComparison.CurrentCultureIgnoreCase))
			{
				return researchItems[i];
			}
		}
		Debug.LogError("couldn't find ResearchItem:" + itemName + " with ID: " + id + " in master item list.  Make sure it exists in the list");
		return null;
	}
}
