using System.Collections.Generic;
using FMODUnity;
using I2.Loc;
using Isto.Core.Achievements;
using Isto.Core.Audio;
using Isto.Core.Automation;
using Isto.Core.Configuration;
using Isto.Core.Game;
using Isto.Core.Items;
using Isto.Core.Localization;
using Isto.Core.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Isto.Core.Beings;

public class PlayerInventory : ItemContainer
{
	[Header("Equip")]
	[SerializeField]
	private int _numEquipSlots = 8;

	[Header("Death")]
	[SerializeField]
	private bool _dropAllItemsOnDeath = true;

	public GameObject backpackPrefab;

	public AssetReference backpackAddressableAsset;

	[Header("Message Params")]
	public LocalizedString fullInventoryMessageKey;

	[EventRef]
	public string fullInventorySoundRef;

	[HideInInspector]
	public ItemPileList startingItems;

	[HideInInspector]
	public ItemList startingEquippedItems;

	private bool _suppressFiringOnChangedEvents;

	private ItemPileList _equippedItems;

	private GameplaySettings _gameplaySettings;

	private IUIDisplayMessage _playerMessageDisplay;

	private IUIMessages _uIMessages;

	private IGameSounds _gameSounds;

	private PlayerHealth _playerHealth;

	private AutomationSystem _autoSystem;

	private IAchievements _achievements;

	private GameState _gameState;

	public int EquipSlotCount => _numEquipSlots;

	[Inject]
	public void Inject(IUIDisplayMessage messageDisplay, IGameSounds gameSounds, IAchievements achievements, [Inject(Id = UIMessageHandlerType.Message)] IUIMessages uIMessages, PlayerHealth playerHealth, AutomationSystem automationSystem, GameplaySettings gameplaySettings, GameState gameState)
	{
		_gameplaySettings = gameplaySettings;
		_playerMessageDisplay = messageDisplay;
		_uIMessages = uIMessages;
		_gameSounds = gameSounds;
		_playerHealth = playerHealth;
		_autoSystem = automationSystem;
		_playerHealth.Killed += OnPlayerKilled;
		ScenarioSetup startingSetup = gameplaySettings.GetStartingSetup();
		startingItems = startingSetup?.items;
		startingEquippedItems = startingSetup?.equipped;
		_achievements = achievements;
		_gameState = gameState;
	}

	public override void Awake()
	{
		_suppressFiringOnChangedEvents = true;
		_equippedItems = ScriptableObject.CreateInstance(typeof(ItemPileList)) as ItemPileList;
		_equippedItems.itemPiles = new List<ItemPile>();
		base.Awake();
	}

	protected void OnDisable()
	{
		if (_playerHealth != null)
		{
			_playerHealth.Killed -= OnPlayerKilled;
		}
	}

	public void LoadStartingItemsAndEquipment()
	{
		if (startingItems != null)
		{
			for (int i = 0; i < startingItems.itemPiles.Count; i++)
			{
				AddAt(startingItems.itemPiles[i], i, triggerEvents: false);
			}
		}
		if (startingEquippedItems != null)
		{
			int count = startingEquippedItems.items.Count;
			if (count > _numEquipSlots)
			{
				Debug.LogError($"Your starting equipped items can be maximum {_numEquipSlots} but you have {count}");
			}
			else
			{
				for (int j = 0; j < _numEquipSlots; j++)
				{
					if (startingEquippedItems.items.Count > j)
					{
						CoreItem coreItem = startingEquippedItems.items[j];
						ItemPile item = new ItemPile(itemCount: GetItemCount(startingEquippedItems.items[j]), item: coreItem);
						_equippedItems.itemPiles.Add(item);
					}
					else
					{
						ItemPile item2 = new ItemPile();
						_equippedItems.itemPiles.Add(item2);
					}
				}
			}
		}
		_suppressFiringOnChangedEvents = false;
		Events.RaiseEvent("PlayerInventoryChanged");
	}

	public int GetItemCount(Item item)
	{
		int num = 0;
		for (int i = 0; i < base.Items.Count; i++)
		{
			if (base.Items[i].item == item)
			{
				num += base.Items[i].count;
			}
		}
		return num;
	}

	public int GetItemIndex(Item item)
	{
		int result = -1;
		for (int i = 0; i < base.Items.Count; i++)
		{
			if (base.Items[i].item == item)
			{
				result = i;
			}
		}
		return result;
	}

	public void EquipItem(Item item, int slotNumber)
	{
		if (slotNumber >= _numEquipSlots)
		{
			Debug.LogError($"Attempted to equip an item to a slot greater than max number of slots. Slot:{slotNumber}, Max:{_numEquipSlots}");
			return;
		}
		int itemCount = GetItemCount(item);
		ItemPile itemPile = new ItemPile((CoreItem)item, itemCount);
		for (int i = 0; i < _equippedItems.itemPiles.Count; i++)
		{
			if (i != slotNumber && _equippedItems.itemPiles[i].HasItems() && _equippedItems.itemPiles[i].item == item)
			{
				RemoveEquippedItem(i);
			}
		}
		if (_equippedItems.IsInRange(slotNumber))
		{
			_equippedItems.itemPiles[slotNumber] = itemPile;
		}
		else
		{
			_equippedItems.itemPiles.Add(itemPile);
		}
		Events.RaiseEvent("PlayerInventoryChanged");
		GlobalGameplayEvents.OnItemEquipped(this, (CoreItem)item);
	}

	public bool TryAutoEquipItem(Item item, bool canRemove)
	{
		if (item == null)
		{
			return false;
		}
		if (item.GetType() == typeof(UpgradeItem))
		{
			return false;
		}
		if (item.GetType() != typeof(AdvancedItem))
		{
			return false;
		}
		for (int i = 0; i < _numEquipSlots; i++)
		{
			if (_equippedItems.itemPiles[i].item == item)
			{
				if (canRemove)
				{
					RemoveEquippedItem(i);
				}
				return false;
			}
		}
		for (int j = 0; j < _numEquipSlots; j++)
		{
			if (_equippedItems.itemPiles[j].item == null)
			{
				EquipItem(item, j);
				return true;
			}
		}
		return false;
	}

	public Item GetEquippedItem(int slotNumber)
	{
		if (slotNumber >= _numEquipSlots)
		{
			Debug.LogError("Attempted to equip an item to a slot greater than " + _numEquipSlots);
			return null;
		}
		if (_equippedItems.IsInRange(slotNumber))
		{
			return _equippedItems.itemPiles[slotNumber].item;
		}
		return null;
	}

	public ItemPile GetEquippedPile(int slotNumber)
	{
		if (slotNumber >= _numEquipSlots)
		{
			Debug.LogError("Attempted to equip an item to a slot greater than " + _numEquipSlots);
			return null;
		}
		if (_equippedItems.IsInRange(slotNumber))
		{
			_equippedItems.itemPiles[slotNumber].count = GetCountOfItem(_equippedItems.itemPiles[slotNumber].item);
			return _equippedItems.itemPiles[slotNumber];
		}
		Debug.LogError("Equipped Item list is not of correct size.");
		return new ItemPile();
	}

	public void RemoveEquippedItem(int index)
	{
		if (_equippedItems.IsInRange(index))
		{
			_equippedItems.itemPiles[index].item = null;
			Events.RaiseEvent("PlayerInventoryChanged");
		}
	}

	public override void SetPileCount(int newCount)
	{
		InitializeList();
		if (base.Items.Capacity < newCount)
		{
			base.Items.Capacity = newCount;
		}
		int num = newCount - pileCount;
		if (num < 0)
		{
			for (int i = num; i < 0; i++)
			{
				base.Items.RemoveAt(base.Items.Count - 1);
			}
		}
		else
		{
			for (int j = 0; j < num; j++)
			{
				base.Items.Add(new ItemPile());
			}
		}
		pileCount = newCount;
	}

	public override int Add(CoreItem item, int count = 1, bool sendUpdateEvent = true)
	{
		int num = base.Add(item, count, sendUpdateEvent);
		if (num > 0)
		{
			Events.RaiseEvent(Events.PLAYER_ITEM_ACQUIRED, item);
		}
		if (num > 0 && !_suppressFiringOnChangedEvents)
		{
			TryAutoEquipItem(item, canRemove: false);
			if (sendUpdateEvent)
			{
				GlobalGameplayEvents.OnItemAddedToPlayerInventory(this, item, num, this);
				SendPlayerInventoryUpdateEvents(item, num);
			}
			if ((_uIMessages != null) & sendUpdateEvent)
			{
				string localizedMessage = $"+{num} {item.itemName}";
				_uIMessages.CreateMessage(localizedMessage, item.icon);
			}
		}
		return num;
	}

	public int AddAt(ItemPile pile, int index, bool triggerEvents = true)
	{
		int num = base.AddAt(pile, index);
		if (num > 0)
		{
			GlobalGameplayEvents.OnItemAddedToPlayerInventory(this, pile.item, pile.count, this);
			if (triggerEvents)
			{
				SendPlayerInventoryUpdateEvents(pile.item, pile.count);
			}
		}
		return num;
	}

	public override int Remove(CoreItem item, int count = 1, bool sendUpdateEvent = true)
	{
		int num = base.Remove(item, count, sendUpdateEvent);
		if ((num > 0 && !_suppressFiringOnChangedEvents) & sendUpdateEvent)
		{
			SendPlayerInventoryUpdateEvents(item, count);
		}
		return num;
	}

	public override ItemPile RemoveAt(int index)
	{
		ItemPile itemPile = base.RemoveAt(index);
		if (itemPile != null && itemPile.count > 0)
		{
			SendPlayerInventoryUpdateEvents(itemPile.item, itemPile.count);
		}
		return itemPile;
	}

	public override ItemPile RemoveAt(int index, int count)
	{
		ItemPile itemPile = base.RemoveAt(index, count);
		if (itemPile != null && itemPile.count > 0)
		{
			SendPlayerInventoryUpdateEvents(itemPile.item, count);
		}
		return itemPile;
	}

	public override List<ItemPile> RemoveAll(bool triggerEvent = true)
	{
		List<ItemPile> list = base.RemoveAll(triggerEvent);
		if ((list.Count > 0) & triggerEvent)
		{
			SendPlayerInventoryUpdateEvents(null, 0);
		}
		return list;
	}

	public void InventoryFull()
	{
		if (_playerMessageDisplay != null)
		{
			_playerMessageDisplay.DisplayMessage(Loc.Get(fullInventoryMessageKey), Constants.DEFAULT_PLAYER_MESSAGE_DISPLAY_TIME);
		}
		Events.RaiseEvent("PlayerInventoryFull");
		_gameSounds.PlayOneShot(fullInventorySoundRef, base.transform.position);
	}

	public bool IsItemEquipped(CoreItem item, out int slotNumber)
	{
		slotNumber = -1;
		for (int i = 0; i < EquipSlotCount; i++)
		{
			Item equippedItem = GetEquippedItem(i);
			if (equippedItem != null && equippedItem.itemName != string.Empty && equippedItem.itemName.Equals(item.itemName))
			{
				slotNumber = i;
				return true;
			}
		}
		return false;
	}

	public void DisableEventFiring()
	{
		_suppressFiringOnChangedEvents = true;
	}

	public void EnableEventFiring()
	{
		_suppressFiringOnChangedEvents = false;
	}

	private void SendPlayerInventoryUpdateEvents(CoreItem item, int change)
	{
		Events.RaiseEvent("PlayerInventoryChanged");
	}

	private void OnPlayerKilled(object sender, HealthEventArgs e)
	{
		if (_dropAllItemsOnDeath && GetTotalNumberOfItems() > 0)
		{
			DropInventory();
			SendPlayerInventoryUpdateEvents(null, 0);
			SendUpdateEvents(null, 0);
		}
	}

	public void SendUpdateEvent()
	{
		SendPlayerInventoryUpdateEvents(null, 0);
		SendUpdateEvents(null, 0);
	}

	public void DropInventory()
	{
		if (GetTotalNumberOfItems() < 0)
		{
			return;
		}
		Vector3 position = base.transform.position + Vector3.right + Vector3.back;
		List<ItemPile> packItems = new List<ItemPile>();
		foreach (ItemPile item in base.Items)
		{
			packItems.Add(new ItemPile(item));
		}
		if (!string.IsNullOrEmpty(backpackAddressableAsset.AssetGUID))
		{
			AsyncOperationHandle<GameObject> asyncOperationHandle = backpackAddressableAsset.InstantiateAsync(position, Quaternion.identity);
			asyncOperationHandle.Completed += (AsyncOperationHandle<GameObject> op) =>
			{
				if (op.Status == AsyncOperationStatus.Succeeded)
				{
					op.Result.GetComponent<DroppedBackPack>().ReceiveContents(packItems, base.PileCount, base.PileSize);
				}
			};
		}
		else
		{
			Debug.LogWarning("No valid AddressableAsset GUID for dropped backpack. Cannot drop");
		}
		RemoveAll(triggerEvent: false);
	}
}
