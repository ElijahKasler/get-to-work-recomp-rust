using System;
using System.Collections.Generic;
using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

[Serializable]
public class AutomationHarvester : IItemProcessor, IDirectionalItem, IAutomationGridSpaceUser
{
	public class Factory : PlaceholderFactory<AutomationHarvesterParams, AutomationHarvester>
	{
	}

	public float harvestDamagePerSecond = 55f;

	[Inject]
	private MasterItemList _masteritemList;

	[Inject]
	private AutomationSystem _system;

	[Inject]
	private AutomationCoreItem.Factory _itemsFactory;

	private Vector3 _forward = Vector3.right;

	private AutomationGridSpace _space;

	private HarvestableItem _resourceItem;

	private Queue<AutomationCoreItem> _harvestedItemQueue = new Queue<AutomationCoreItem>();

	private bool _hasItemToDrop;

	private bool _destroyOnHarvestComplete;

	public bool Harvesting
	{
		get
		{
			if (_space.Resource != null && !_hasItemToDrop && _space != null)
			{
				return _space.Powered;
			}
			return false;
		}
	}

	public string ProcessorID { get; private set; }

	public bool Visible => true;

	public bool DestroyOnHarvestComplete => _destroyOnHarvestComplete;

	public event EventHandler DroppedItem;

	public AutomationHarvester(AutomationHarvesterParams harvesterParams)
	{
		harvestDamagePerSecond = harvesterParams.harvestDps;
		ProcessorID = harvesterParams.harvesterID;
		_destroyOnHarvestComplete = harvesterParams.destroyOnHarvestComplete;
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		_space = space;
		if (_space.Resource != null)
		{
			_resourceItem = _masteritemList.GetItemByID<HarvestableItem>(_space.Resource.ID);
		}
		if (_harvestedItemQueue.Count > 0)
		{
			AutomationCoreItem[] array = _harvestedItemQueue.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].position = _space.position;
			}
		}
	}

	public void Tick(float deltaTime)
	{
		if (_space.Powered)
		{
			if (_hasItemToDrop)
			{
				TryDropItems();
			}
			if (_space.Resource != null && !_hasItemToDrop && _space.Resource.TakeDamage(harvestDamagePerSecond * deltaTime, ref _harvestedItemQueue))
			{
				_hasItemToDrop = true;
				TryDropItems();
			}
		}
	}

	public int IsAvailable(AutomationCoreItem movingItem)
	{
		return 0;
	}

	public void SetForwardDirection(Vector3 forward)
	{
		_forward = forward;
	}

	public Vector3 GetDirection()
	{
		return _forward;
	}

	private void TryDropItems()
	{
		AutomationGridSpace orCreateGridSpace = _system.GetOrCreateGridSpace(_space.position + _forward);
		while (_harvestedItemQueue.Count > 0)
		{
			AutomationCoreItem automationCoreItem = _harvestedItemQueue.Dequeue();
			if (_system.CanMoveItemToGridSpace(orCreateGridSpace, automationCoreItem, out var _))
			{
				automationCoreItem.position = _space.position;
				_system.TryAddCoreItemToSpace(orCreateGridSpace.position, automationCoreItem);
				orCreateGridSpace.MoveItemToSpace(new AutomationLaunchMove(automationCoreItem, orCreateGridSpace.position, _system.ItemMoveTime));
				continue;
			}
			_harvestedItemQueue.Enqueue(automationCoreItem);
			return;
		}
		DroppedItem?.Invoke(this, EventArgs.Empty);
		_hasItemToDrop = false;
		if (_destroyOnHarvestComplete)
		{
			_system.TryRemoveProcessor(_space.position);
		}
	}

	public AutomationProcessorData GetSaveData()
	{
		AutomationHarvesterData automationHarvesterData = new AutomationHarvesterData
		{
			direction = _forward,
			harvesterDPS = harvestDamagePerSecond,
			typeId = ProcessorID,
			destroyOnHarvestComplete = _destroyOnHarvestComplete
		};
		foreach (AutomationCoreItem item in _harvestedItemQueue)
		{
			automationHarvesterData.itemsQueue.Add(new ItemData(item.ID, "", item.count));
		}
		return automationHarvesterData;
	}

	public void LoadData(AutomationProcessorData data)
	{
		AutomationHarvesterData automationHarvesterData = data as AutomationHarvesterData;
		ProcessorID = automationHarvesterData.typeId;
		if (ProcessorID.Equals("TreeChomper"))
		{
			_destroyOnHarvestComplete = true;
		}
		_forward = automationHarvesterData.direction;
		harvestDamagePerSecond = automationHarvesterData.harvesterDPS;
		foreach (ItemData item2 in automationHarvesterData.itemsQueue)
		{
			CoreItemParams param = new CoreItemParams(item2.id, item2.count, data.position);
			AutomationCoreItem item = _itemsFactory.Create(param);
			_harvestedItemQueue.Enqueue(item);
		}
		_hasItemToDrop = automationHarvesterData.itemsQueue.Count > 0;
	}
}
