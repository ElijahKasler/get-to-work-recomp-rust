using System;
using System.Collections.Generic;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationResource
{
	public class Factory : PlaceholderFactory<AutomationResourceParams, AutomationResource>
	{
	}

	public string ID;

	public AutomationCreatureHive ReservationHiveAddress;

	public bool VisualCulling = true;

	[Inject]
	private AutomationSystem _automationsystem;

	[Inject]
	private AutomationCoreItem.Factory _itemFactory;

	private float _maxHealth;

	private float _itemDropIncrement = 100f;

	private float _healthTillNextDrop;

	private float _totalGrowTime = 10f;

	private float _currentGrowTime;

	private bool _harvestableWhileGrowing;

	private bool _isInfinite;

	public float Health { get; private set; }

	public HarvestableItem Item { get; private set; }

	public float HarvestPercent => 1f - _healthTillNextDrop / _itemDropIncrement;

	public float GrowthPercent => _currentGrowTime / _totalGrowTime;

	public bool IsFullyGrown => GrowthPercent >= 1f;

	public bool IsHarvestable
	{
		get
		{
			if (!IsFullyGrown)
			{
				if (Item.droppedItemsWhileGrowing.Count > 0)
				{
					return _harvestableWhileGrowing;
				}
				return false;
			}
			return true;
		}
	}

	public bool IsReservedByPickerPal => ReservationHiveAddress != null;

	public AutomationGridSpace Space { get; internal set; }

	public event EventHandler<AutomationResourceEventArgs> Consumed;

	public event EventHandler<AutomationResourceEventArgs> GrowthComplete;

	public event EventHandler<AutomationPullEventArgs> PullStart;

	public event EventHandler PullEnd;

	public AutomationResource(AutomationResourceParams resourceParams)
	{
		HarvestableItem item = resourceParams.item;
		if (item.itemID.Equals("NO ID SET", StringComparison.CurrentCultureIgnoreCase))
		{
			Debug.LogWarning("No id set for Resource " + item.ToString());
		}
		Item = item;
		ID = item.itemID;
		_harvestableWhileGrowing = resourceParams.harvestableWhileGrowing;
		_maxHealth = item.harvestHP;
		_totalGrowTime = ((item.growingTime == 0f) ? 0.1f : item.growingTime);
		_currentGrowTime = resourceParams.currentGrowthPercent * _totalGrowTime;
		_isInfinite = resourceParams.infiniteResource;
		_itemDropIncrement = ((item.harvestAmountPerItemDrop == 0f) ? item.harvestHP : item.harvestAmountPerItemDrop);
		SetRemainingHealth(resourceParams.currentHealth);
	}

	public void Tick(float deltaTime)
	{
		if (GrowthPercent < 1f)
		{
			TickGrowing(deltaTime);
		}
	}

	private void TickGrowing(float deltaTime)
	{
		_currentGrowTime = Mathf.Clamp(_currentGrowTime + deltaTime, 0f, _totalGrowTime);
		if (_currentGrowTime >= _totalGrowTime)
		{
			GrowthComplete?.Invoke(this, new AutomationResourceEventArgs(AutomationResourceEventArgs.EventType.FullyGrown));
		}
	}

	public void SetRemainingHealth(float health)
	{
		Health = health;
		if (Item.harvestAmountPerItemDrop == 0f)
		{
			_healthTillNextDrop = health;
		}
		else
		{
			_healthTillNextDrop = Item.harvestAmountPerItemDrop;
		}
	}

	public void Remove()
	{
		if (Space != null)
		{
			if (Space.itemProcessor.IsNullOrDestroyed() && Space.ActiveItem == null)
			{
				_automationsystem.DeleteGridSpace(Space);
			}
			else if (Space.Sleeping)
			{
				_automationsystem.Grid.WakeUpSleepingSpace(Space);
			}
		}
		Space = null;
		Consumed?.Invoke(this, new AutomationResourceEventArgs(AutomationResourceEventArgs.EventType.Deleted));
	}

	public bool TakeDamage(float amount, ref Queue<AutomationCoreItem> droppedItems)
	{
		Health = Mathf.Clamp(Health - amount, 0f, _maxHealth);
		_healthTillNextDrop -= amount;
		if (_healthTillNextDrop <= 0f || Health == 0f)
		{
			droppedItems.Clear();
			List<ItemPile> itemsToDrop = GetItemsToDrop();
			for (int i = 0; i < itemsToDrop.Count; i++)
			{
				if (UnityEngine.Random.value <= itemsToDrop[i].dropPercentage)
				{
					droppedItems.Enqueue(_itemFactory.Create(new CoreItemParams(itemsToDrop[i].item.itemID, itemsToDrop[i].count, Vector3.zero)));
				}
			}
			_healthTillNextDrop += _itemDropIncrement;
			if (_isInfinite)
			{
				Health = _maxHealth;
			}
			if (GrowthPercent < 1f)
			{
				Health = 0f;
			}
			if (Health == 0f)
			{
				if (Space != null && Space.Sleeping)
				{
					_automationsystem.Grid.WakeUpSleepingSpace(Space);
				}
				Consumed?.Invoke(this, new AutomationResourceEventArgs(AutomationResourceEventArgs.EventType.FullyHarvested));
			}
			return true;
		}
		return false;
	}

	public void StartTornatoadPull(Vector3 directionOfPull)
	{
		PullStart?.Invoke(this, new AutomationPullEventArgs(directionOfPull));
	}

	public void EndTornatoadPull()
	{
		PullEnd?.Invoke(this, EventArgs.Empty);
	}

	private List<ItemPile> GetItemsToDrop()
	{
		if (GrowthPercent < 1f && Item.droppedItemsWhileGrowing.Count > 0)
		{
			return Item.droppedItemsWhileGrowing;
		}
		return Item.droppedItems;
	}
}
