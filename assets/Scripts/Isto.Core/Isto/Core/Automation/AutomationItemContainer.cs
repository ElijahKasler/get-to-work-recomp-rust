using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationItemContainer : IItemProcessor, IAutomationGridSpaceUser, IAutomationInventory
{
	public class Factory : PlaceholderFactory<AutomationItemContainerParams, AutomationItemContainer>
	{
	}

	[Inject]
	private MasterItemList _masterItemList;

	[Inject]
	private AutomationSystem _system;

	private AutomationGridSpace _space;

	private Inventory _inventory;

	private bool _pullItemsFromNeighborSpaces;

	private AutomationCoreItem _targetItem;

	private Vector3 _nextOffsetForPull = Vector3.right;

	public string ProcessorID { get; private set; }

	public bool Visible { get; private set; }

	public AutomationItemContainer(AutomationItemContainerParams conatinerParams)
	{
		if (conatinerParams.isRigidInventory)
		{
			_inventory = new RigidInventory(conatinerParams.pileCount, conatinerParams.pileSize);
		}
		else
		{
			_inventory = new Inventory(conatinerParams.pileCount, conatinerParams.pileSize);
		}
		ProcessorID = conatinerParams.typeID;
		Visible = true;
		_pullItemsFromNeighborSpaces = conatinerParams.pullsItemsFromNeighbors;
	}

	public IInventory GetInventory()
	{
		return _inventory;
	}

	public void Resize(int pileCount, int pileSize)
	{
		if (_inventory != null)
		{
			_inventory.SetPileCount(pileCount);
			_inventory.PileSize = pileSize;
		}
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
	}

	public void Tick(float deltaTime)
	{
		CheckForIncomingItem();
		if (_pullItemsFromNeighborSpaces)
		{
			CheckToPullItemFromAdjacentSpaces();
		}
	}

	public void SetVisibility(bool isVisible)
	{
		Visible = isVisible;
	}

	private void CheckForIncomingItem()
	{
		if (_space.ActiveItem != null && !_space.ActiveItem.IsMoving && !_space.ActiveItem.IsReserved)
		{
			CoreItem itemByID = _masterItemList.GetItemByID<CoreItem>(_space.ActiveItem.ID);
			int num = _inventory.Add(itemByID, _space.ActiveItem.count);
			if (num == _space.ActiveItem.count)
			{
				_system.DeleteCoreItem(_space.ActiveItem);
			}
			else if (num != 0)
			{
				_space.ActiveItem.count -= num;
			}
		}
	}

	private void CheckToPullItemFromAdjacentSpaces()
	{
		if (_targetItem != null || _space.ActiveItem != null)
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			if (_system.TryGetExistingGridSpace(_space.position + _nextOffsetForPull, out var space) && space.ActiveItem != null && _inventory.GetSpaceAvailable(_masterItemList.GetItemByID<CoreItem>(space.ActiveItem.ID)) > 0 && _space.ActiveItem == null)
			{
				if (!space.ActiveItem.IsMoving)
				{
					StartPullOfItem(space.ActiveItem);
					_nextOffsetForPull = Quaternion.Euler(0f, 90f, 0f) * _nextOffsetForPull;
					break;
				}
				_targetItem = space.ActiveItem;
				_targetItem.MoveComplete += OnIncomingMoveComplete;
			}
			_nextOffsetForPull = Quaternion.Euler(0f, 90f, 0f) * _nextOffsetForPull;
		}
	}

	private void OnIncomingMoveComplete(object sender, CoreItemMoveEventArgs e)
	{
		if (_targetItem != null)
		{
			AutomationCoreItem targetItem = _targetItem;
			_targetItem = null;
			targetItem.MoveComplete -= OnIncomingMoveComplete;
			if (!targetItem.IsMoving && !targetItem.IsReserved && !targetItem.IsConsumed)
			{
				StartPullOfItem(targetItem);
			}
		}
	}

	private void StartPullOfItem(AutomationCoreItem item)
	{
		item.IsReserved = true;
		AutomationGridSpace gridSpace = item.GridSpace;
		gridSpace.CancelAllMoves();
		if (!AutomationItemMover.TryItemMove(item, gridSpace, _space, item.count, _system, GetMover, out var _))
		{
			Debug.LogError("Couldn't move item to expected free space");
		}
		item.IsReserved = false;
	}

	public IItemMoveType GetMover(AutomationCoreItem item, Vector3 destination, AutomationGridSpace nextSpace)
	{
		return new AutomationLinearMove(item, destination, _system.ItemMoveTime);
	}

	public AutomationProcessorData GetSaveData()
	{
		if (ProcessorID.Equals(MasterItemList.ITEM_ENTRANCE_ID))
		{
			return null;
		}
		return new AutomationItemContainerData
		{
			typeId = ProcessorID,
			inventoryPileCount = _inventory.PileCount,
			inventoryPileSize = _inventory.PileSize,
			visible = Visible,
			isRigidInventory = (_inventory is IRigidInventory),
			pullsItemsFromNeighbors = _pullItemsFromNeighborSpaces,
			inventory = ItemData.ConvertItemPileList(_inventory.Items).ToArray()
		};
	}

	public void LoadData(AutomationProcessorData data)
	{
		if (data is AutomationItemContainerData automationItemContainerData)
		{
			Visible = automationItemContainerData.visible;
			ItemData.LoadItemsIntoInventory(automationItemContainerData.inventory, _inventory, _masterItemList);
		}
	}
}
