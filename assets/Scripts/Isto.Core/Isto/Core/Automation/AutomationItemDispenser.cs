using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationItemDispenser : IItemProcessor, IAutomationGridSpaceUser, IAutomationInventory, IDirectionalItem, IAutomationActionOnRemoved
{
	public struct ItemDispenserParams(string typeID, int pileCount, int stackSize, float timePerDrop, float timeToNextDrop, Vector3 forward)
	{
		public string typeID = typeID;

		public int pileCount = pileCount;

		public int stackSize = stackSize;

		public float timePerDrop = timePerDrop;

		public float timeToNextDrop = timeToNextDrop;

		public Vector3 forward = forward;
	}

	public class Factory : PlaceholderFactory<ItemDispenserParams, AutomationItemDispenser>
	{
	}

	private float _maxTimePerDrop;

	private float _minTimePerDrop;

	private AutomationGridSpace _space;

	private AutomationGridSpace _proxySpace;

	[Inject]
	private MasterItemList _masterItemList;

	[Inject]
	private AutomationSystem _system;

	[Inject]
	private AutomationCoreItem.Factory _itemFactory;

	private Inventory _inventory;

	private Vector3 _forward;

	private float _timePerDrop;

	private float _timeToNextDrop;

	public string ProcessorID { get; private set; }

	public bool Visible { get; private set; }

	public float DropTimerPercent => 1f - _timeToNextDrop / _timePerDrop;

	public float TimePerDrop => _timePerDrop;

	public bool IsFacingUpDirection
	{
		get
		{
			if (_forward.x != -1f)
			{
				return _forward.z == 1f;
			}
			return true;
		}
	}

	public float MaxDropRate => 32f;

	public float MinDropRate => 1f;

	public AutomationItemDispenser(ItemDispenserParams p)
	{
		if (p.pileCount > 1)
		{
			Debug.LogError("Automation Item Dispenser is not setup for inventories with more than one pile.  Incorrect behavior will probably happen!");
		}
		_inventory = new Inventory(p.pileCount, p.stackSize);
		_timePerDrop = p.timePerDrop;
		_timeToNextDrop = p.timeToNextDrop;
		_forward = p.forward;
		ProcessorID = p.typeID;
		Visible = true;
	}

	public IInventory GetInventory()
	{
		return _inventory;
	}

	public virtual int IsAvailable(AutomationCoreItem movingItem)
	{
		if (_inventory.GetContainerPercentUsed() == 1f)
		{
			return 0;
		}
		int spaceAvailable = _inventory.GetSpaceAvailable(movingItem.ID);
		int countOfItemsIncoming = _space.GetCountOfItemsIncoming(movingItem.ID);
		return spaceAvailable - countOfItemsIncoming;
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		_space = space;
		CreateProxyProcessor();
	}

	private void CreateProxyProcessor()
	{
		if (!IsFacingUpDirection)
		{
			_proxySpace = _system.GetOrCreateGridSpace(_space.position - _forward);
			_proxySpace.itemProcessor = new AutomationProcessorProxy(this);
		}
	}

	public void Tick(float deltaTime)
	{
		if (!_space.Powered)
		{
			return;
		}
		AutomationGridSpace automationGridSpace = ((_proxySpace != null) ? _proxySpace : _space);
		AutomationCoreItem activeItem = automationGridSpace.ActiveItem;
		if (activeItem != null && !activeItem.IsMoving)
		{
			CoreItem itemByID = _masterItemList.GetItemByID<CoreItem>(activeItem.ID);
			int num = _inventory.Add(itemByID, activeItem.count);
			if (num == activeItem.count)
			{
				_system.DeleteCoreItem(activeItem);
			}
			else if (num != 0)
			{
				automationGridSpace.ActiveItem.count -= num;
			}
		}
		_timeToNextDrop -= deltaTime;
		if (_timeToNextDrop <= 0f && TryDropItem())
		{
			_timeToNextDrop = _timePerDrop;
		}
	}

	public void SetVisibility(bool isVisible)
	{
		Visible = isVisible;
	}

	public void SetDropTime(float value)
	{
		_maxTimePerDrop = 60f / MinDropRate;
		_minTimePerDrop = 60f / MaxDropRate * 0.99f;
		value *= 0.99f;
		float num = _timeToNextDrop / _timePerDrop;
		_timePerDrop = Mathf.Clamp(value, _minTimePerDrop, _maxTimePerDrop);
		_timeToNextDrop = _timePerDrop * num;
	}

	public void SetForwardDirection(Vector3 forward)
	{
		_forward = forward;
	}

	public Vector3 GetDirection()
	{
		return _forward;
	}

	private bool TryDropItem()
	{
		if (_inventory.GetTotalNumberOfItems() > 0)
		{
			CoreItem item = _inventory.Items[0].item;
			Vector3 position = _space.position + (IsFacingUpDirection ? (_forward * 2f) : _forward);
			AutomationGridSpace orCreateGridSpace = _system.GetOrCreateGridSpace(position);
			int num = ((!IsFacingUpDirection) ? 1 : 2);
			AutomationCoreItem item2 = _itemFactory.Create(new CoreItemParams(item.itemID, 1, _space.position));
			if (_system.CanMoveItemToGridSpace(orCreateGridSpace, item2, out var _))
			{
				_system.TryAddCoreItemToSpace(orCreateGridSpace.position, item2);
				orCreateGridSpace.MoveItemToSpace(new AutomationLinearMove(item2, orCreateGridSpace.position, _system.ItemMoveTime * (float)num));
				item2 = null;
				_inventory.Remove(item);
				return true;
			}
		}
		return false;
	}

	public void Removed()
	{
		if (!IsFacingUpDirection)
		{
			_system.TryRemoveProcessor(_space.position - _forward);
		}
	}

	public AutomationProcessorData GetSaveData()
	{
		return new AutomationItemDispenserData
		{
			typeId = ProcessorID,
			inventoryPileCount = _inventory.PileCount,
			inventoryPileSize = _inventory.PileSize,
			visible = Visible,
			direction = _forward,
			timePerDrop = _timePerDrop,
			timeToNextDrop = _timeToNextDrop,
			inventory = ItemData.ConvertItemPileList(_inventory.Items)
		};
	}

	public void LoadData(AutomationProcessorData data)
	{
		if (data is AutomationItemDispenserData automationItemDispenserData)
		{
			Visible = automationItemDispenserData.visible;
			ItemData.LoadItemsIntoInventory(automationItemDispenserData.inventory.ToArray(), _inventory, _masterItemList);
			_forward = automationItemDispenserData.direction;
			_timePerDrop = automationItemDispenserData.timePerDrop;
			_timeToNextDrop = automationItemDispenserData.timeToNextDrop;
		}
	}
}
