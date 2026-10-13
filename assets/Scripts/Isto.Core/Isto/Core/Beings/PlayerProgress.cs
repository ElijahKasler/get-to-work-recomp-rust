using System.Collections.Generic;
using Isto.Core.Audio;
using Isto.Core.Configuration;
using Isto.Core.Data;
using Isto.Core.Enums;
using Isto.Core.Game;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Beings;

public class PlayerProgress : MonoBehaviour, IDataLoadCompleteHandler
{
	public class ItemUnlockStepsEnum : Int32Enum<ItemUnlockStepsEnum>
	{
		public static readonly ItemUnlockStepsEnum NONE = new ItemUnlockStepsEnum(0, "NONE");

		public ItemUnlockStepsEnum(int value, string name)
			: base(value, name)
		{
		}
	}

	public List<ItemList> playerUnlocks;

	[Header("Harvesting")]
	public List<HarvestableItem> defaultHarvestableItems;

	[Header("Testing only")]
	[Tooltip("TESTING ONLY, UNLOCKS ALL ITEMS")]
	public bool unlockAll;

	private HashSet<string> _unlockedItems = new HashSet<string>();

	private HashSet<string> _createdItems = new HashSet<string>();

	private HashSet<string> _seenItems = new HashSet<string>();

	private HashSet<string> _playerHarvestableItems;

	private CoreItem _trackedItem;

	private GameplaySettings _gameplaySettings;

	private GameState _gameState;

	public HashSet<string> UnlockedItems => _unlockedItems;

	public HashSet<string> CreatedItems => _createdItems;

	public HashSet<string> SeenItems => _seenItems;

	[Inject]
	public void Inject(IGameSounds gameSounds, GameplaySettings gameplaySettings, GameState gameState)
	{
		_gameplaySettings = gameplaySettings;
		_gameState = gameState;
	}

	private void Awake()
	{
		if (_playerHarvestableItems == null)
		{
			_playerHarvestableItems = new HashSet<string>();
		}
		for (int i = 0; i < defaultHarvestableItems.Count; i++)
		{
			_playerHarvestableItems.Add(defaultHarvestableItems[i].itemID);
		}
		if (playerUnlocks.Count > 0)
		{
			for (int j = 0; j < playerUnlocks[0].items.Count; j++)
			{
				_unlockedItems.Add(playerUnlocks[0].items[j].itemID);
			}
		}
	}

	private void Start()
	{
		UnlockStartingItemSet();
	}

	private void OnEnable()
	{
		RegisterEvents();
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		GlobalGameplayEvents.ItemCrafted += OnItemCrafted;
		GlobalGameplayEvents.ItemAddedToPlayerInventory += OnItemAddedToPlayerInv;
	}

	private void UnregisterEvents()
	{
		GlobalGameplayEvents.ItemCrafted -= OnItemCrafted;
		GlobalGameplayEvents.ItemAddedToPlayerInventory -= OnItemAddedToPlayerInv;
	}

	public void OnDataLoadComplete()
	{
		UnlockMissingItemSetsForCurrentGameState();
	}

	private void OnItemCrafted(object sender, ItemEventArgs e)
	{
		AddCraftedItem(e.item);
	}

	private void OnItemAddedToPlayerInv(object sender, ItemEventArgs e)
	{
		if (e.item != null)
		{
			_seenItems.Add(e.item.itemID);
		}
	}

	public virtual void UnlockStartingItemSet()
	{
		AddStartingItems();
	}

	public virtual void UnlockMissingItemSetsForCurrentGameState()
	{
	}

	private void AddStartingItems()
	{
		ScenarioSetup startingSetup = _gameplaySettings.GetStartingSetup();
		if (!(startingSetup == null))
		{
			for (int i = 0; i < startingSetup.items.itemPiles.Count; i++)
			{
				ItemPile itemPile = startingSetup.items.itemPiles[i];
				AddCraftedItem(itemPile.item);
			}
			for (int j = 0; j < startingSetup.startingUpgrades.Count; j++)
			{
				AddCraftedItem(startingSetup.startingUpgrades[j]);
			}
		}
	}

	public void AddCraftedItem(CoreItem item)
	{
		if (item != null)
		{
			_createdItems.Add(item.itemID);
			_unlockedItems.Add(item.itemID);
		}
		else
		{
			Debug.LogError("Null Item passed to PlayerProgress");
		}
	}

	public void UnlockItems(ItemList unlockList)
	{
		for (int i = 0; i < unlockList.items.Count; i++)
		{
			CoreItem item = unlockList.items[i];
			if (!IsItemUnlocked(item))
			{
				UnlockItem(item);
			}
		}
	}

	public void UnlockItemSet(ItemUnlockStepsEnum unlock)
	{
		ItemList allItemsFromUnlock = GetAllItemsFromUnlock(unlock);
		UnlockItems(allItemsFromUnlock);
	}

	public ItemList GetItemListFromUnlock(ItemUnlockStepsEnum unlock)
	{
		ItemList itemList = ScriptableObject.CreateInstance(typeof(ItemList)) as ItemList;
		itemList.items = new List<CoreItem>();
		if (unlock == ItemUnlockStepsEnum.NONE)
		{
			return itemList;
		}
		int value = unlock.Value;
		if (value >= playerUnlocks.Count)
		{
			return itemList;
		}
		itemList.items.AddRange(playerUnlocks[value].items);
		return itemList;
	}

	public ItemList GetNextItemFromUnlock(ItemUnlockStepsEnum unlock)
	{
		ItemList itemList = ScriptableObject.CreateInstance(typeof(ItemList)) as ItemList;
		itemList.items = new List<CoreItem>();
		int value = unlock.Value;
		if (value + 1 < playerUnlocks.Count)
		{
			itemList.items.AddRange(playerUnlocks[value + 1].items);
		}
		return itemList;
	}

	public ItemList GetAllItemsFromUnlock(ItemUnlockStepsEnum unlock)
	{
		ItemList itemList = ScriptableObject.CreateInstance(typeof(ItemList)) as ItemList;
		itemList.items = new List<CoreItem>();
		if (unlock == ItemUnlockStepsEnum.NONE)
		{
			return itemList;
		}
		int num = unlock.Value;
		if (num > playerUnlocks.Count - 1)
		{
			num = playerUnlocks.Count - 1;
			Debug.LogWarning("Not enough unlocks in PlayerProgress.PlayerUnlocks list for item unlock set: " + unlock);
		}
		for (int i = 0; i <= num; i++)
		{
			if (i >= playerUnlocks.Count || playerUnlocks[i] == null)
			{
				Debug.LogError("No Item Unlock" + i + "Set for Player Progress. This will cause errors");
				return null;
			}
			itemList.items.AddRange(playerUnlocks[i].items);
		}
		return itemList;
	}

	public ItemList GetLockedItems(ItemList itemList)
	{
		ItemList itemList2 = ScriptableObject.CreateInstance<ItemList>();
		itemList2.items = new List<CoreItem>();
		for (int i = 0; i < itemList.items.Count; i++)
		{
			CoreItem item = itemList.items[i];
			if (!IsItemUnlocked(item))
			{
				itemList2.items.Add(item);
			}
		}
		return itemList2;
	}

	public void UnlockItem(CoreItem item)
	{
		if (item != null)
		{
			_unlockedItems.Add(item.itemID);
		}
		else
		{
			Debug.LogWarning("Trying to unlock null item in Player Progress.");
		}
	}

	public void ItemSeen(CoreItem item)
	{
		if (!(item == null))
		{
			_seenItems.Add(item.itemID);
		}
	}

	public bool HasItemBeenSeen(CoreItem item)
	{
		if (item == null)
		{
			return false;
		}
		return _seenItems.Contains(item.itemID);
	}

	public bool IsItemUnlocked(CoreItem item)
	{
		if (item == null)
		{
			return false;
		}
		if (_gameState.CurrentGameMode != null && item.ForbiddenForCurrentGameMode(_gameState.CurrentGameMode))
		{
			return false;
		}
		if (!_unlockedItems.Contains(item.itemID))
		{
			return unlockAll;
		}
		return true;
	}

	public bool HasItemBeenCreated(CoreItem advancedItem)
	{
		if (advancedItem == null)
		{
			return false;
		}
		return _createdItems.Contains(advancedItem.itemID);
	}

	public void UnlockPlayerHarvestableItem(HarvestableItem item)
	{
		if (_playerHarvestableItems == null)
		{
			_playerHarvestableItems = new HashSet<string>();
		}
		_playerHarvestableItems.Add(item.itemID);
	}

	public void LockPlayerHarvestableItem(HarvestableItem item)
	{
		_playerHarvestableItems.Remove(item.itemID);
	}

	public bool PlayerCanHarvest(HarvestableItem item)
	{
		bool flag = item.droppedItemsWhileGrowing.Count > 0;
		return (_playerHarvestableItems.Contains(item.itemID) || unlockAll) | flag;
	}
}
