using System;
using Isto.Core.Automation;
using Isto.Core.Pooling;
using UPool;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Isto.Core.Items;

public abstract class PooledInteractableItem : InteractableItem
{
	public enum AllocationStates
	{
		None = 0,
		Allocated = 1,
		Deallocated = 2
	}

	protected PoolableObject _poolableObj;

	protected AllocationStates _state;

	private bool _eventsRegistered;

	private bool _excludedFromPool;

	protected PooledItemFactory _pooledItemFactory;

	public AllocationStates AllocationState => _state;

	public PoolableObject PoolingComponent => _poolableObj;

	public bool IsPooled
	{
		get
		{
			if (_state != AllocationStates.None)
			{
				return !_excludedFromPool;
			}
			return false;
		}
	}

	public string ItemID
	{
		get
		{
			if (!(this is HarvestableController harvestableController))
			{
				return itemPile.item?.itemID;
			}
			return harvestableController.item.itemID;
		}
	}

	[Inject]
	public void Inject(PooledItemFactory pooledItemFactory)
	{
		_pooledItemFactory = pooledItemFactory;
	}

	protected virtual void Start()
	{
		if (TryGetComponent<PoolableObject>(out _poolableObj))
		{
			RegisterEvents();
			_state = AllocationStates.Deallocated;
		}
	}

	protected override void OnDestroy()
	{
		UnregisterEvents();
		base.OnDestroy();
		if (IsPooled && !_pooledItemFactory.IsCoreItemInsidePool(_poolableObj) && !_pooledItemFactory.IsInsidePool(this) && base.gameObject.scene.isLoaded)
		{
			Debug.LogError("PooledInteractableItem.OnDestroy: " + base.gameObject.name + " is being destroyed outside of the pool instead of returned to it.", base.gameObject);
		}
	}

	public void DeconfigurePooling()
	{
		UnregisterEvents();
		if (!IsPooled)
		{
			_excludedFromPool = true;
			return;
		}
		if (_state == AllocationStates.Allocated)
		{
			Debug.LogError("PooledInteractableItem.DeconfigurePooling: Should not deconfigure item " + base.gameObject.name + " that really comes from a pool");
		}
		_excludedFromPool = true;
	}

	private void RegisterEvents()
	{
		if (!_eventsRegistered)
		{
			PoolableObject poolableObj = _poolableObj;
			poolableObj.ObjectAllocated = (Action)Delegate.Combine(poolableObj.ObjectAllocated, new Action(OnAllocate));
			PoolableObject poolableObj2 = _poolableObj;
			poolableObj2.ObjectDeallocated = (Action)Delegate.Combine(poolableObj2.ObjectDeallocated, new Action(OnDeallocate));
			_eventsRegistered = true;
		}
	}

	private void UnregisterEvents()
	{
		if (_eventsRegistered)
		{
			PoolableObject poolableObj = _poolableObj;
			poolableObj.ObjectAllocated = (Action)Delegate.Remove(poolableObj.ObjectAllocated, new Action(OnAllocate));
			PoolableObject poolableObj2 = _poolableObj;
			poolableObj2.ObjectDeallocated = (Action)Delegate.Remove(poolableObj2.ObjectDeallocated, new Action(OnDeallocate));
			_eventsRegistered = false;
		}
	}

	public virtual void OnAllocate()
	{
		if (!IsPooled)
		{
			Debug.LogError("PooledInteractableItem: Should not be allocating item " + base.gameObject.name + " witch is not truly pooled !");
		}
		else
		{
			_state = AllocationStates.Allocated;
		}
	}

	public virtual void OnDeallocate()
	{
		if (!IsPooled)
		{
			Debug.LogError("PooledInteractableItem: Should not be deallocating item " + base.gameObject.name + " witch is not truly pooled !");
		}
		else
		{
			_state = AllocationStates.Deallocated;
		}
	}

	public virtual void DestroyGameObject()
	{
		if (PoolingComponent != null && IsPooled)
		{
			bool num = itemPile.item is AdvancedItem || this is HarvestableController;
			AutomationCoreItemRegister component = GetComponent<AutomationCoreItemRegister>();
			if (!num || component != null)
			{
				bool flag;
				try
				{
					_pooledItemFactory.ReturnPooledCoreItem(PoolingComponent);
					flag = true;
				}
				catch (InvalidOperationException)
				{
					flag = false;
				}
				if (!flag)
				{
					Debug.LogError("PooledInteractableItem.DestroyGameObject Could not return item " + base.gameObject.name + " to the CoreItemPool. Trying the AdvancedItem Pools");
					_pooledItemFactory.ReturnPooledAdvancedItem(this);
				}
			}
			else
			{
				_pooledItemFactory.ReturnPooledAdvancedItem(this);
			}
		}
		else
		{
			string text = base.gameObject.name;
			if (!Addressables.ReleaseInstance(base.gameObject))
			{
				Debug.LogWarning("ReleaseInstance failed to release GO: " + text + ". It will be destroyed directly.", base.gameObject);
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	public void DestroyGameObject(float delay)
	{
		Invoke("DestroyGameObject", delay);
	}
}
