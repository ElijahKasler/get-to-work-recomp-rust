using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Isto.Core.Items;
using UnityEngine;

namespace Isto.Core.Automation;

[Serializable]
[XmlRoot("AutomationSystem")]
public class AutomationSystem
{
	public enum SystemComponents
	{
		ItemProcessor = 0,
		Item = 1,
		Resource = 2
	}

	private AutomationCoreItem.Factory _itemFactory;

	private AutomationResource.Factory _resourceFactory;

	private float _moveTime;

	private AutomationGrid _grid;

	private AutomationGridSpace[] _activeSpaceBuffer;

	private AutomationQuad _gridQuadTree = new AutomationQuad(new Vector3Int(-256, 0, 256), new Vector3Int(768, 0, -768));

	public float ItemMoveTime => _moveTime;

	public AutomationGrid Grid => _grid;

	public AutomationCoreItem.Factory CoreItemFactory => _itemFactory;

	public AutomationQuad Tree => _gridQuadTree;

	public event EventHandler<AutomationSystemChangedEventArgs> SystemChanged;

	public event EventHandler<PositionEventArgs> ItemAdded;

	public AutomationSystem()
	{
	}

	public AutomationSystem(float moveTime, AutomationCoreItem.Factory itemFactory, AutomationResource.Factory resourceFactory)
	{
		_grid = new AutomationGrid(dummyFlag: false);
		_moveTime = moveTime;
		_itemFactory = itemFactory;
		_resourceFactory = resourceFactory;
		_activeSpaceBuffer = new AutomationGridSpace[10000];
	}

	public void TickSystem(float deltaTime)
	{
		ValidateBufferSize();
		_grid.ActiveSpaces.CopyTo(_activeSpaceBuffer, 0);
		int count = _grid.ActiveSpaces.Count;
		for (int i = 0; i < count; i++)
		{
			_activeSpaceBuffer[i].Tick(deltaTime);
			if (ShouldSpaceSleep(_activeSpaceBuffer[i]))
			{
				_grid.PutSpaceToSleep(_activeSpaceBuffer[i]);
			}
		}
	}

	private void ValidateBufferSize()
	{
		if (_grid.ActiveSpaces.Count > _activeSpaceBuffer.Length)
		{
			Debug.LogWarning("Active space buffer needs expansion. Increasing space cound by 5000");
			AutomationGridSpace[] array = new AutomationGridSpace[_activeSpaceBuffer.Length + 5000];
			for (int i = 0; i < _activeSpaceBuffer.Length; i++)
			{
				array[i] = _activeSpaceBuffer[i];
			}
			_activeSpaceBuffer = array;
		}
	}

	private bool ShouldSpaceSleep(AutomationGridSpace space)
	{
		if (space.Resource != null && space.Resource.IsFullyGrown && space.itemProcessor == null && space.Resource.Health > 0f)
		{
			return true;
		}
		return false;
	}

	public bool DoesSpaceExist(float x, float z)
	{
		return _grid.DoesSpaceExist(x, z);
	}

	public bool DoesSpaceExist(Vector3 worldPosition)
	{
		return _grid.DoesSpaceExist(worldPosition.x, worldPosition.z);
	}

	public bool TryAddResource(Vector3 position, HarvestableItem itemType, bool triggerEvent = true, bool visualCulling = true, float growthPercent = 0f)
	{
		AutomationResource resource = _resourceFactory.Create(new AutomationResourceParams(itemType, itemType.harvestHP, growthPercent, itemType.infiniteResrouce));
		return TryAddResource(position, resource, triggerEvent, visualCulling);
	}

	public bool TryAddResource(Vector3 position, AutomationResource resource, bool triggerEvent = true, bool visualCulling = true)
	{
		AutomationGridSpace orCreateGridSpace = GetOrCreateGridSpace(position);
		if (orCreateGridSpace.TrySetResource(resource, visualCulling))
		{
			if (triggerEvent)
			{
				SystemChanged?.Invoke(this, new AutomationSystemChangedEventArgs(orCreateGridSpace, AutomationSystemChangedEventArgs.Change.AddResource));
			}
			ItemAdded?.Invoke(this, new PositionEventArgs(orCreateGridSpace.position, resource.ID));
			return true;
		}
		return false;
	}

	public bool TryRemoveResource(Vector3 position)
	{
		if (DoesSpaceExist(position))
		{
			AutomationGridSpace space = null;
			if (_grid.TryGetSpace(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.z), ref space))
			{
				space.ClearResource();
				if (space.IsEmpty())
				{
					DeleteGridSpace(space);
				}
				SystemChanged?.Invoke(this, new AutomationSystemChangedEventArgs(space, AutomationSystemChangedEventArgs.Change.RemoveResource));
				return true;
			}
			Debug.LogWarning("Couldn't retrieve space even though IsSpaceOccupied returned true.");
			return false;
		}
		return false;
	}

	public bool TryAddItemProcessor(Vector3 position, IItemProcessor processor, Vector3 forward = default(Vector3), bool triggerEvent = false)
	{
		AutomationGridSpace orCreateGridSpace = GetOrCreateGridSpace(position);
		if (orCreateGridSpace.itemProcessor.IsNullOrDestroyed())
		{
			if (processor is IAutomationGridSpaceUser automationGridSpaceUser)
			{
				automationGridSpaceUser.SetGridSpace(orCreateGridSpace);
			}
			if (forward != default(Vector3) && processor is IDirectionalItem directionalItem)
			{
				directionalItem.SetForwardDirection(forward);
			}
			if (orCreateGridSpace.Sleeping)
			{
				_grid.WakeUpSleepingSpace(orCreateGridSpace);
			}
			else if (processor is AutomationGenericProcessor && orCreateGridSpace.Resource == null)
			{
				_grid.PutSpaceToSleep(orCreateGridSpace);
			}
			else if (processor is AutomationBlockedSpace)
			{
				_grid.PutSpaceToSleep(orCreateGridSpace);
			}
			orCreateGridSpace.itemProcessor = processor;
			if (triggerEvent)
			{
				SystemChanged?.Invoke(this, new AutomationSystemChangedEventArgs(orCreateGridSpace, AutomationSystemChangedEventArgs.Change.AddProcessor));
			}
			ItemAdded?.Invoke(this, new PositionEventArgs(orCreateGridSpace.position, processor.ProcessorID, orCreateGridSpace));
			return true;
		}
		return false;
	}

	public Vector3? AddItemProcessorToNearestSpace(Vector3 position, IItemProcessor processor, Vector3 forward = default(Vector3), bool triggerEvent = false)
	{
		Vector3? result = null;
		List<Vector3> list = new List<Vector3>();
		for (float num = 0f - Constants.BACKPACK_DROP_MAX_DISTANCE; num < Constants.BACKPACK_DROP_MAX_DISTANCE + 0.5f; num++)
		{
			for (float num2 = 0f - Constants.BACKPACK_DROP_MAX_DISTANCE; num2 < Constants.BACKPACK_DROP_MAX_DISTANCE + 0.5f; num2++)
			{
				list.Add(new Vector3(position.x + num, position.y, position.z + num2));
			}
		}
		foreach (Vector3 item in list.OrderBy((Vector3 x) => (position - x).sqrMagnitude))
		{
			if (TryAddItemProcessor(item, processor, forward, triggerEvent))
			{
				result = item;
				break;
			}
		}
		if (!result.HasValue)
		{
			Debug.LogError($"AddItemProcessorToNearestSpace was not able to find a free space near {position} to place {processor.ProcessorID}");
		}
		return result;
	}

	public bool TryRemoveProcessor(float x, float z)
	{
		if (DoesSpaceExist(Mathf.RoundToInt(x), Mathf.RoundToInt(z)))
		{
			AutomationGridSpace space = null;
			if (_grid.TryGetSpace(Mathf.RoundToInt(x), Mathf.RoundToInt(z), ref space))
			{
				if (space.itemProcessor != null && space.itemProcessor is IAutomationInventory automationInventory)
				{
					IInventory inventory = automationInventory.GetInventory();
					space.RemoveProcessor();
					DropAllInventoryItems(inventory, space.position);
				}
				else
				{
					space.RemoveProcessor();
				}
				if (space.IsEmpty())
				{
					DeleteGridSpace(space);
				}
				SystemChanged?.Invoke(this, new AutomationSystemChangedEventArgs(space, AutomationSystemChangedEventArgs.Change.RemoveProcessor));
				return true;
			}
			Debug.LogWarning("Couldn't retrieve space even though IsSpaceOccupied returned true.");
			return false;
		}
		return false;
	}

	public bool TryRemoveProcessor(Vector3 position)
	{
		return TryRemoveProcessor(position.x, position.z);
	}

	public bool TryAddCoreItemToSpace(Vector3 gridSpacePosition, AutomationCoreItem item, bool autoCollectItem = false, bool triggerEvent = true, bool ignoreProcessor = false)
	{
		AutomationGridSpace orCreateGridSpace = GetOrCreateGridSpace(gridSpacePosition);
		if (autoCollectItem || orCreateGridSpace.TrySetItem(item, ignoreProcessor))
		{
			if (triggerEvent)
			{
				AutomationSystemChangedEventArgs.Source changeSource = ((!autoCollectItem) ? AutomationSystemChangedEventArgs.Source.ItemProcessor : AutomationSystemChangedEventArgs.Source.Player);
				SystemChanged?.Invoke(this, new AutomationSystemChangedEventArgs(orCreateGridSpace, item, AutomationSystemChangedEventArgs.Change.AddCoreItem, changeSource));
			}
			return true;
		}
		return false;
	}

	public bool TryAddCoreItemToSpace(AutomationGridSpace space, AutomationCoreItem item, bool triggerEvent = true)
	{
		if (space.TrySetItem(item))
		{
			AutomationSystemChangedEventArgs.Source changeSource = AutomationSystemChangedEventArgs.Source.ItemProcessor;
			if (triggerEvent)
			{
				SystemChanged?.Invoke(this, new AutomationSystemChangedEventArgs(space, item, AutomationSystemChangedEventArgs.Change.AddCoreItem, changeSource));
			}
			return true;
		}
		return false;
	}

	public bool TryAddCoreItem(Vector3 position, CoreItem item, int count = 1, bool autoCollectItem = false, bool triggerEvent = true)
	{
		AutomationCoreItem item2 = _itemFactory.Create(new CoreItemParams(item.itemID, count, position));
		return TryAddCoreItemToSpace(position, item2, autoCollectItem, triggerEvent);
	}

	public bool TryDeleteCoreItem(Vector3 position)
	{
		if (DoesSpaceExist(position))
		{
			AutomationGridSpace space = null;
			if (_grid.TryGetSpace(position.x, position.z, ref space))
			{
				AutomationCoreItem activeItem = space.ActiveItem;
				space.ConsumeItem(space.ActiveItem);
				if (space.IsEmpty())
				{
					DeleteGridSpace(space);
				}
				SystemChanged?.Invoke(this, new AutomationSystemChangedEventArgs(space, AutomationSystemChangedEventArgs.Change.RemoveCoreItem)
				{
					changedItem = activeItem
				});
				return true;
			}
			Debug.LogWarning("Couldn't retrieve space even though IsSpaceOccupied returned true.");
			return false;
		}
		return false;
	}

	public bool DeleteCoreItem(AutomationCoreItem item)
	{
		bool result = false;
		AutomationGridSpace space = null;
		Vector3 vector = ((item.GridSpace == null) ? (item.IsMoving ? item.TargetPosition : item.position) : item.GridSpace.position);
		if (_grid.TryGetSpace(vector.x, vector.z, ref space) && space.ContainsItem(item))
		{
			space.ConsumeItem(item);
			SystemChanged?.Invoke(this, new AutomationSystemChangedEventArgs(space, item, AutomationSystemChangedEventArgs.Change.RemoveCoreItem));
			if (space.IsEmpty())
			{
				DeleteGridSpace(space);
			}
			result = true;
		}
		else
		{
			SystemChanged?.Invoke(this, new AutomationSystemChangedEventArgs(space, item, AutomationSystemChangedEventArgs.Change.RemoveCoreItem));
		}
		return result;
	}

	public void DropAllInventoryItems(IInventory inventory, Vector3 position, int dropRadius = 0, bool autoCollect = true)
	{
		for (int i = 0; i < inventory.Items.Count; i++)
		{
			ItemPile itemPile = inventory.Items[i];
			if (itemPile.HasItems())
			{
				Vector3 vector = position + UnityUtils.GetNearestAxisDirection(UnityUtils.RandomXZVector(1f)) * dropRadius;
				AutomationCoreItem item = _itemFactory.Create(new CoreItemParams(itemPile.item.itemID, itemPile.count, vector));
				if (!TryAddCoreItemToSpace(vector, item, autoCollect) && !TryAddCoreItemToSpace(position, item, autoCollect))
				{
					Vector3 vector2 = vector;
					Debug.LogError("Couldn't drop inventory item on to grid space at " + vector2.ToString());
				}
			}
		}
	}

	public bool CanMoveItemToGridSpace(AutomationGridSpace destination, AutomationCoreItem item, out int spaceAvailable)
	{
		spaceAvailable = 0;
		if (destination.Resource != null && !(destination.itemProcessor is AutomationPlanter))
		{
			return false;
		}
		if (!destination.itemProcessor.IsNullOrDestroyed())
		{
			spaceAvailable = destination.itemProcessor.IsAvailable(item);
			return spaceAvailable > 0;
		}
		if (destination.ActiveItem == null)
		{
			spaceAvailable = item.count;
			return true;
		}
		return false;
	}

	public AutomationGridSpace GetOrCreateGridSpace(Vector3 position)
	{
		AutomationGridSpace space = null;
		if (_grid.TryGetSpace(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.z), ref space))
		{
			return space;
		}
		AutomationGridSpace automationGridSpace = new AutomationGridSpace(position);
		_gridQuadTree.Insert(new QuadTreeNode(Vector3Int.RoundToInt(position), automationGridSpace));
		if (_grid.TryAddToGrid(automationGridSpace))
		{
			return automationGridSpace;
		}
		Debug.LogError("Cannot add grid space to expected empty space.");
		return automationGridSpace;
	}

	public AutomationGridSpace GetOrCreateGridSpace(Vector3Int position)
	{
		AutomationGridSpace space = null;
		if (_grid.TryGetSpace(position.x, position.z, ref space))
		{
			return space;
		}
		AutomationGridSpace automationGridSpace = new AutomationGridSpace(position);
		_gridQuadTree.Insert(new QuadTreeNode(Vector3Int.RoundToInt(position), automationGridSpace));
		if (_grid.TryAddToGrid(automationGridSpace))
		{
			return automationGridSpace;
		}
		Debug.LogError("Cannot add grid space to expected empty space.");
		return automationGridSpace;
	}

	public bool TryGetExistingGridSpace(Vector3Int position, out AutomationGridSpace space)
	{
		space = null;
		return _grid.TryGetSpace(position.x, position.z, ref space);
	}

	public bool TryGetExistingGridSpace(Vector3 position, out AutomationGridSpace space)
	{
		space = null;
		return _grid.TryGetSpace(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.z), ref space);
	}

	public bool TryGetExistingGridSpace(int x, int z, out AutomationGridSpace space)
	{
		space = null;
		return _grid.TryGetSpace(x, z, ref space);
	}

	public void DeleteGridSpace(AutomationGridSpace space)
	{
		Tree.Remove(Vector3Int.RoundToInt(space.position));
		_grid.RemoveSpace(space);
	}

	public override string ToString()
	{
		return _grid.ToString();
	}

	public static bool DoesSpaceContainAnyItem(List<string> itemList, AutomationGridSpace space, bool includePickerPalReservedResources = true)
	{
		bool flag = space.Resource != null && space.Resource.IsFullyGrown && (includePickerPalReservedResources || !space.Resource.IsReservedByPickerPal);
		if (!flag && space.AllItemsOnSpace.Count == 0)
		{
			return false;
		}
		for (int i = 0; i < itemList.Count; i++)
		{
			if (flag && space.Resource.ID.Equals(itemList[i]))
			{
				return true;
			}
			for (int j = 0; j < space.AllItemsOnSpace.Count; j++)
			{
				if (space.AllItemsOnSpace[j].ID.Equals(itemList[i]))
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool DoesSpaceContainAnyItem(HashSet<string> itemList, AutomationGridSpace space, bool includePickerPalReservedResources = true)
	{
		bool flag = space.Resource != null && space.Resource.IsFullyGrown && (includePickerPalReservedResources || !space.Resource.IsReservedByPickerPal);
		if (!flag && space.AllItemsOnSpace.Count == 0)
		{
			return false;
		}
		if (flag && itemList.Contains(space.Resource.ID))
		{
			return true;
		}
		for (int i = 0; i < space.AllItemsOnSpace.Count; i++)
		{
			if (itemList.Contains(space.AllItemsOnSpace[i].ID))
			{
				return true;
			}
		}
		return false;
	}

	public static bool DoesSpaceContainAnyHarvestableWithoutReservations(HashSet<string> itemList, AutomationGridSpace space, AutomationCreatureHive homeAddress)
	{
		if (space.Resource != null && space.Resource.IsHarvestable && itemList.Contains(space.Resource.ID))
		{
			if (space.Resource.IsReservedByPickerPal)
			{
				return space.Resource.ReservationHiveAddress == homeAddress;
			}
			return true;
		}
		return false;
	}

	public static bool DoesSpaceContainHarvestable(AutomationGridSpace space)
	{
		return space.Resource != null;
	}

	public List<AutomationGridSpace> GetAllActiveGridSpacesInRadius(Vector3 centerPoint, float radius)
	{
		List<AutomationGridSpace> list = new List<AutomationGridSpace>();
		int num = Mathf.RoundToInt(radius);
		int num2 = Mathf.RoundToInt(radius);
		for (int i = -num; i < num; i++)
		{
			for (int j = -num2; j < num2; j++)
			{
				Vector3 position = new Vector3(i, 0f, j) + centerPoint;
				if (TryGetExistingGridSpace(position, out var space))
				{
					list.Add(space);
				}
			}
		}
		return list;
	}
}
