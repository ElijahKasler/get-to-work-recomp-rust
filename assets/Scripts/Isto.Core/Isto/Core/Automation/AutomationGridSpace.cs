using System;
using System.Collections.Generic;
using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;

namespace Isto.Core.Automation;

[Serializable]
public class AutomationGridSpace
{
	public Vector3 position;

	public IItemProcessor itemProcessor;

	public bool ResourceRendered;

	public bool ProcessorRendered;

	private List<AutomationCoreItem> _itemsOnSpace = new List<AutomationCoreItem>();

	private List<IItemMoveType> _runningItemMoves = new List<IItemMoveType>();

	public AutomationResource Resource { get; private set; }

	public AutomationCoreItem ActiveItem
	{
		get
		{
			List<AutomationCoreItem> itemsOnSpace = _itemsOnSpace;
			if (itemsOnSpace == null || itemsOnSpace.Count <= 0)
			{
				return null;
			}
			return _itemsOnSpace[0];
		}
	}

	public GameObject DisplayItem { get; set; }

	public bool Powered { get; private set; }

	public List<AutomationCoreItem> AllItemsOnSpace => _itemsOnSpace;

	public bool Sleeping { get; private set; }

	public AutomationGridSpace(Vector3 position)
	{
		this.position = new Vector3(Mathf.RoundToInt(position.x), 0f, Mathf.RoundToInt(position.z));
	}

	public AutomationGridSpace(Vector3 position, IItemProcessor processor, AutomationResource resouce, List<AutomationCoreItem> items)
	{
		this.position = position;
		itemProcessor = processor;
		if (processor is IAutomationGridSpaceUser)
		{
			(processor as IAutomationGridSpaceUser).SetGridSpace(this);
		}
		Resource = resouce;
		if (items != null && items.Count > 0)
		{
			_itemsOnSpace = items;
		}
	}

	public void Tick(float deltaTime)
	{
		TickMovers(deltaTime);
		if (!itemProcessor.IsNullOrDestroyed())
		{
			itemProcessor.Tick(deltaTime);
		}
		if (!Resource.IsNullOrDestroyed())
		{
			if (Resource.Health == 0f)
			{
				Resource = null;
			}
			else
			{
				Resource.Tick(deltaTime);
			}
		}
	}

	private void TickMovers(float deltaTime)
	{
		for (int num = _runningItemMoves.Count - 1; num >= 0; num--)
		{
			_runningItemMoves[num].Tick(deltaTime);
			if (num < _runningItemMoves.Count && _runningItemMoves[num].Complete)
			{
				_runningItemMoves.RemoveAt(num);
			}
		}
	}

	public void SetPowered(bool isPowered)
	{
		Powered = isPowered;
	}

	public bool IsEmpty()
	{
		if (itemProcessor.IsNullOrDestroyed() && Resource == null)
		{
			return ActiveItem == null;
		}
		return false;
	}

	public bool IsItemOnSpace(string itemID)
	{
		if (ActiveItem == null)
		{
			return false;
		}
		if (ActiveItem.ID.Equals(itemID, StringComparison.CurrentCultureIgnoreCase))
		{
			return true;
		}
		for (int i = 0; i < _itemsOnSpace.Count; i++)
		{
			if (_itemsOnSpace[i].ID.Equals(itemID, StringComparison.CurrentCultureIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	public int GetCountOfItemsIncoming(string itemId)
	{
		int num = 0;
		for (int i = 0; i < AllItemsOnSpace.Count; i++)
		{
			if (AllItemsOnSpace[i].ID.Equals(itemId, StringComparison.OrdinalIgnoreCase))
			{
				num += AllItemsOnSpace[i].count;
			}
		}
		return num;
	}

	public bool ContainsItem(AutomationCoreItem item)
	{
		return _itemsOnSpace.Contains(item);
	}

	public bool ContainsItem(string itemID)
	{
		for (int i = 0; i < _itemsOnSpace.Count; i++)
		{
			if (_itemsOnSpace[i].ID.Equals(itemID))
			{
				return true;
			}
		}
		return false;
	}

	public void ConsumeItem(AutomationCoreItem item)
	{
		if (_itemsOnSpace.Contains(item))
		{
			_itemsOnSpace.Remove(item);
			item.ConsumeItem();
		}
		else
		{
			Debug.LogError($"Can't consume item {item.ID} because it does not exist on this space: {position}");
		}
	}

	public void ClearItem(AutomationCoreItem item)
	{
		if (ActiveItem == item)
		{
			_itemsOnSpace.RemoveAt(0);
		}
		else
		{
			_itemsOnSpace.Remove(item);
		}
	}

	public void ClearAllItems()
	{
		_itemsOnSpace.Clear();
	}

	public bool TrySetItem(AutomationCoreItem coreItem, bool ignoreProcessor = false)
	{
		bool flag = !itemProcessor.IsNullOrDestroyed() && itemProcessor.IsAvailable(coreItem) >= coreItem.count;
		if (itemProcessor.IsNullOrDestroyed() | flag | ignoreProcessor)
		{
			coreItem.SetGridSpace(this);
			_itemsOnSpace.Add(coreItem);
			return true;
		}
		return false;
	}

	public bool TryGetItem(out AutomationCoreItem item, string itemID)
	{
		for (int i = 0; i < _itemsOnSpace.Count; i++)
		{
			if (_itemsOnSpace[i].ID.Equals(itemID))
			{
				item = _itemsOnSpace[i];
				return true;
			}
		}
		item = null;
		return false;
	}

	public bool TrySetResource(AutomationResource resource, bool visualCulling)
	{
		if (Resource != null)
		{
			return false;
		}
		Resource = resource;
		Resource.VisualCulling = visualCulling;
		Resource.Space = this;
		return true;
	}

	public void ClearResource()
	{
		if (Resource != null)
		{
			Resource.Remove();
		}
		Resource = null;
	}

	public void RemoveProcessor()
	{
		if (itemProcessor is IAutomationActionOnRemoved automationActionOnRemoved)
		{
			automationActionOnRemoved.Removed();
		}
		itemProcessor = null;
	}

	public void MoveItemToSpace(IItemMoveType moveType)
	{
		_runningItemMoves.Add(moveType);
	}

	public void CancelAllMoves()
	{
		for (int i = 0; i < _runningItemMoves.Count; i++)
		{
			_runningItemMoves[i].Cancel();
		}
		_runningItemMoves.Clear();
	}

	public void CancelItemMove(AutomationCoreItem item)
	{
		int num = _runningItemMoves.IndexOf(item.MoveType);
		if (num != -1)
		{
			_runningItemMoves[num].Cancel();
			_runningItemMoves.RemoveAt(num);
		}
	}

	public void SetSleepingFlag()
	{
		Sleeping = true;
	}

	public void ClearSleepingFlag()
	{
		Sleeping = false;
	}

	public AutomationGridSpaceData GetSaveData()
	{
		if (IsEmpty())
		{
			return null;
		}
		AutomationGridSpaceData automationGridSpaceData = new AutomationGridSpaceData
		{
			position = position
		};
		if (Resource != null)
		{
			automationGridSpaceData.resourceHealth = Resource.Health;
			automationGridSpaceData.resourceID = Resource.ID;
			automationGridSpaceData.growthPercent = Resource.GrowthPercent;
			if (Resource.ID.Equals("NO ID SET", StringComparison.CurrentCultureIgnoreCase))
			{
				Debug.LogWarning($"No id set for Resource on space at {position}");
			}
		}
		foreach (AutomationCoreItem item in _itemsOnSpace)
		{
			automationGridSpaceData.items.Add(new ItemData(item.ID, "", item.count));
		}
		if (itemProcessor != null)
		{
			automationGridSpaceData.processorData = itemProcessor.GetSaveData();
			if (automationGridSpaceData.processorData != null)
			{
				automationGridSpaceData.processorData.position = position;
			}
		}
		if (!automationGridSpaceData.IsEmpty())
		{
			return automationGridSpaceData;
		}
		return null;
	}

	public int OrthogonalDistance(AutomationGridSpace target)
	{
		return OrthogonalXDistance(target) + OrthogonalZDistance(target);
	}

	public int OrthogonalXDistance(AutomationGridSpace target)
	{
		return Mathf.RoundToInt(Mathf.Abs(target.position.x - position.x));
	}

	public int OrthogonalZDistance(AutomationGridSpace target)
	{
		return Mathf.RoundToInt(Mathf.Abs(target.position.z - position.z));
	}

	private AutomationCoreItem GetNextFloatingItem()
	{
		if (_itemsOnSpace.Count > 0)
		{
			AutomationCoreItem result = _itemsOnSpace[0];
			_itemsOnSpace.RemoveAt(0);
			return result;
		}
		return null;
	}
}
