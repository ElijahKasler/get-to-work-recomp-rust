using System;
using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationItemMover : IItemProcessor, IDirectionalItem, IAutomationGridSpaceUser
{
	public enum MovementType
	{
		Linear = 0,
		Launch = 1
	}

	public class Factory : PlaceholderFactory<int, MovementType, string, AutomationItemMover>
	{
	}

	protected AutomationSystem _system;

	private bool _visible = true;

	private Vector3 _forward = Vector3.right;

	private AutomationGridSpace _space;

	private Vector3Int _moveToPosition;

	public bool Visible => _visible;

	public Vector3 Position
	{
		get
		{
			if (_space == null)
			{
				return Vector3.zero;
			}
			return _space.position;
		}
	}

	public int MoveDistance { get; private set; }

	public MovementType MoveType { get; private set; }

	public string ProcessorID { get; private set; }

	public IAutomationItemFilter ItemFilter { get; set; }

	public event EventHandler DistanceChanged;

	public event EventHandler<ItemMoveArgs> ItemMoved;

	public AutomationItemMover(int moveDistance, MovementType moveType, string processorTypeId)
	{
		MoveDistance = moveDistance;
		MoveType = moveType;
		ProcessorID = processorTypeId;
	}

	[Inject]
	public void Inject(AutomationSystem system)
	{
		_system = system;
	}

	public void SetVisible(bool visible)
	{
		_visible = visible;
	}

	public Vector3 GetDirection()
	{
		return _forward;
	}

	public void SetForwardDirection(Vector3 forward)
	{
		_forward = forward;
		if (_space != null)
		{
			_moveToPosition = Vector3Int.RoundToInt(_space.position + _forward * MoveDistance);
		}
	}

	public virtual int IsAvailable(AutomationCoreItem movingItem)
	{
		if (_space.ActiveItem != null)
		{
			return 0;
		}
		return movingItem.count;
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		_space = space;
		_moveToPosition = Vector3Int.RoundToInt(_space.position + _forward * MoveDistance);
	}

	public AutomationGridSpace GetGridSpace()
	{
		return _space;
	}

	public void SetDistance(int distance)
	{
		MoveDistance = distance;
		DistanceChanged?.Invoke(this, EventArgs.Empty);
	}

	public virtual void Tick(float deltaTime)
	{
		if (CanTick())
		{
			AutomationCoreItem activeItem = GetActiveItem();
			if (!activeItem.IsMoving)
			{
				MoveItem(activeItem);
			}
		}
	}

	protected virtual AutomationCoreItem GetActiveItem()
	{
		return _space?.ActiveItem;
	}

	protected virtual bool CanTick()
	{
		bool result = true;
		if (!_space.Powered)
		{
			result = false;
		}
		else if (!CanTakeItem(GetActiveItem()))
		{
			result = false;
		}
		return result;
	}

	protected bool CanTakeItem(AutomationCoreItem item)
	{
		bool result = true;
		if (item == null)
		{
			result = false;
		}
		else if (item.IsReserved || item.IsConsumed)
		{
			result = false;
		}
		else if (ItemFilter != null && !ItemFilter.IsAccepted(item))
		{
			result = false;
		}
		return result;
	}

	public void MoveItem(AutomationCoreItem item)
	{
		AutomationGridSpace orCreateGridSpace = _system.GetOrCreateGridSpace(_moveToPosition);
		if (_system.CanMoveItemToGridSpace(orCreateGridSpace, item, out var spaceAvailable))
		{
			item.IsReserved = true;
			AutomationGridSpace gridSpace = item.GridSpace;
			gridSpace.CancelAllMoves();
			if (TryItemMove(item, gridSpace, orCreateGridSpace, spaceAvailable, _system, GetMover, out var createdItemMover))
			{
				ItemMoved?.Invoke(this, new ItemMoveArgs(createdItemMover));
			}
			else
			{
				Debug.LogError("Couldn't move item to expected free space");
			}
			item.IsReserved = false;
		}
	}

	public static bool TryItemMove(AutomationCoreItem item, AutomationGridSpace sourceSpace, AutomationGridSpace nextSpace, int amount, AutomationSystem system, Func<AutomationCoreItem, Vector3, AutomationGridSpace, IItemMoveType> moverFactory, out IItemMoveType createdItemMover)
	{
		if (item.count > amount)
		{
			AutomationCoreItem automationCoreItem = new AutomationCoreItem(new CoreItemParams(item.ID, amount, sourceSpace.position));
			if (system.TryAddCoreItemToSpace(nextSpace, automationCoreItem))
			{
				automationCoreItem.position = sourceSpace.position;
				automationCoreItem.SetGridSpace(nextSpace);
				createdItemMover = moverFactory(automationCoreItem, nextSpace.position, nextSpace);
				nextSpace.MoveItemToSpace(createdItemMover);
				item.count -= amount;
				return true;
			}
		}
		else if (nextSpace.TrySetItem(item))
		{
			item.position = sourceSpace.position;
			sourceSpace.ClearItem(item);
			createdItemMover = moverFactory(item, nextSpace.position, nextSpace);
			nextSpace.MoveItemToSpace(createdItemMover);
			item.SetGridSpace(nextSpace);
			return true;
		}
		createdItemMover = null;
		return false;
	}

	public IItemMoveType GetMover(AutomationCoreItem item, Vector3 destination, AutomationGridSpace nextSpace)
	{
		switch (MoveType)
		{
		case MovementType.Linear:
			return new AutomationLinearMove(item, destination, _system.ItemMoveTime);
		case MovementType.Launch:
			if (nextSpace.itemProcessor is AutomationFactory)
			{
				destination.y++;
			}
			return new AutomationLaunchMove(item, destination, _system.ItemMoveTime);
		default:
			Debug.LogWarning("No handler for MovementType : " + MoveType);
			return new AutomationLinearMove(item, destination, _system.ItemMoveTime);
		}
	}

	public virtual AutomationProcessorData GetSaveData()
	{
		return new AutomationItemMoverData
		{
			typeId = ProcessorID,
			direction = _forward,
			visible = _visible,
			distance = MoveDistance,
			moveType = MoveType
		};
	}

	public virtual void LoadData(AutomationProcessorData data)
	{
		AutomationItemMoverData automationItemMoverData = data as AutomationItemMoverData;
		SetForwardDirection(automationItemMoverData.direction);
		MoveDistance = automationItemMoverData.distance;
		MoveType = automationItemMoverData.moveType;
		ProcessorID = automationItemMoverData.typeId;
		_visible = automationItemMoverData.visible;
	}
}
