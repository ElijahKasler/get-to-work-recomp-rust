using System.Collections.Generic;
using System.Linq;
using Isto.Core.Game;
using Isto.Core.Items;
using UPool;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using Zenject;

namespace Isto.Core.Pooling;

public class PooledItemFactory : MonoBehaviour
{
	private static readonly string CORE_ITEM_ID = "CoreItem";

	private bool _initialized;

	private Dictionary<string, int> _poolRequests;

	private Dictionary<string, FlexiblePool<PoolableObject>> _pools;

	private Transform _templatesContainer;

	private int _poolsReady;

	private MasterItemList _masterItemList;

	private PoolingConfiguration _poolingConfiguration;

	[Inject]
	public void Inject(MasterItemList masterItemList, PoolingConfiguration poolingConfiguration)
	{
		_masterItemList = masterItemList;
		_poolingConfiguration = poolingConfiguration;
	}

	public void Awake()
	{
		GameState.PoolsInitialized = false;
		Initialize();
	}

	public GameObject GetPooledCoreItem()
	{
		if (!_initialized || _pools == null)
		{
			Debug.LogError("Trying to get CoreItem from PooledItemFactory while not initialized", base.gameObject);
			return null;
		}
		if (!_pools.ContainsKey(CORE_ITEM_ID))
		{
			Debug.LogError("CoreItem does not have a pool configured for it");
			return null;
		}
		return _pools[CORE_ITEM_ID].Acquire().gameObject;
	}

	public void Request(string itemID)
	{
		if (_poolRequests == null)
		{
			_poolRequests = new Dictionary<string, int>();
		}
		if (!_poolRequests.ContainsKey(itemID))
		{
			_poolRequests.Add(itemID, 0);
		}
		_poolRequests[itemID]++;
	}

	private int GetRequestCount(Item itemDef)
	{
		if (_poolRequests == null)
		{
			return 0;
		}
		if (!_poolRequests.ContainsKey(itemDef.itemID))
		{
			return 0;
		}
		return _poolRequests[itemDef.itemID];
	}

	public GameObject GetPooledItem(Item itemDef)
	{
		if (!_initialized || _pools == null)
		{
			Debug.LogError("Trying to get item " + itemDef.itemID + " from PooledItemFactory while not initialized", base.gameObject);
			return null;
		}
		if (!_pools.ContainsKey(itemDef.itemID))
		{
			return null;
		}
		return _pools[itemDef.itemID].Acquire().gameObject;
	}

	public bool IsCoreItemInsidePool(PoolableObject item)
	{
		if (item.IsNullOrDestroyed())
		{
			Debug.LogError("Should not be testing null or destroyed game objects against the core item pool", base.gameObject);
			return false;
		}
		if (!_pools.ContainsKey(CORE_ITEM_ID))
		{
			Debug.LogWarning("PooledItemFactory.IsCoreItemInsidePool called on item " + item.gameObject.name + " but core item pool is not available", item.gameObject);
			return false;
		}
		Transform container = _pools[CORE_ITEM_ID].Container;
		if (container != null)
		{
			return item.transform.parent == container;
		}
		return false;
	}

	public bool IsInsidePool(PooledInteractableItem item)
	{
		string itemID = item.ItemID;
		if (itemID == null || !_pools.ContainsKey(itemID))
		{
			return false;
		}
		Transform container = _pools[itemID].Container;
		if (container != null)
		{
			return item.transform.parent == container;
		}
		return false;
	}

	public void ReturnPooledCoreItem(PoolableObject item)
	{
		if (!_initialized || _pools == null)
		{
			Debug.LogError("Trying to return CoreItem " + item.gameObject.name + " to PooledItemFactory but the pools are not initialized", base.gameObject);
		}
		IActionOnRecycle[] componentsInChildren = item.GetComponentsInChildren<IActionOnRecycle>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].OnRecycle();
		}
		_pools[CORE_ITEM_ID].Recycle(item);
	}

	public void ReturnPooledAdvancedItem(PooledInteractableItem item)
	{
		if (!_initialized || _pools == null)
		{
			Debug.LogError("Trying to return item " + item.gameObject.name + " to PooledItemFactory but the pools are not initialized", base.gameObject);
		}
		if (item.PoolingComponent == null)
		{
			Debug.LogError("Trying to return to PooledItemFactory item " + item.gameObject.name + " but it has no PoolableObject", base.gameObject);
		}
		if (!item.IsPooled)
		{
			Debug.LogError("Trying to return to PooledItemFactory the PooledInteractableItem " + item.gameObject.name + " but it is not from a pool", base.gameObject);
		}
		IActionOnRecycle[] componentsInChildren = item.GetComponentsInChildren<IActionOnRecycle>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].OnRecycle();
		}
		string itemID = item.ItemID;
		_pools[itemID].Recycle(item.PoolingComponent);
	}

	public bool IsItemPooled(Item item)
	{
		for (int i = 0; i < _poolingConfiguration.ItemPools.Count; i++)
		{
			if (_poolingConfiguration.ItemPools[i].item == item)
			{
				return true;
			}
		}
		return false;
	}

	public void ResizePool(string itemId, int size)
	{
		if (!_initialized || _pools == null)
		{
			Debug.LogError("Trying to resize " + itemId + " pool but the pools are not initialized", base.gameObject);
			return;
		}
		PoolingConfiguration.PooledItemConfiguration pooledItemConfiguration = _poolingConfiguration.ItemPools.Where((PoolingConfiguration.PooledItemConfiguration x) => x.item.itemID == itemId).FirstOrDefault();
		if (pooledItemConfiguration == null)
		{
			Debug.LogError("Trying to resize " + itemId + " pool but config was not found for it", base.gameObject);
			return;
		}
		if (!_pools.ContainsKey(itemId))
		{
			Debug.LogError("Trying to resize " + itemId + " pool but that pool does not exist", base.gameObject);
			return;
		}
		GameState.PoolsInitialized = false;
		_pools[itemId].DestroyAndDeallocateAll();
		_pools.Remove(itemId);
		PreLoad(pooledItemConfiguration.item, size);
	}

	private void Initialize()
	{
		if (_initialized)
		{
			return;
		}
		if (_pools == null)
		{
			_pools = new Dictionary<string, FlexiblePool<PoolableObject>>();
			_templatesContainer = new GameObject("PooledItemPrefabs").transform;
			_templatesContainer.parent = base.transform;
		}
		PreLoadCoreItemPool();
		foreach (PoolingConfiguration.PooledItemConfiguration itemPool in _poolingConfiguration.ItemPools)
		{
			PreLoad(itemPool.item);
		}
		_initialized = true;
	}

	private void PreLoadCoreItemPool()
	{
		AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle = Addressables.LoadResourceLocationsAsync(_poolingConfiguration.coreItemAddressable);
		asyncOperationHandle.Completed += (AsyncOperationHandle<IList<IResourceLocation>> op) =>
		{
			if (op.Result != null && op.Result.Count > 0)
			{
				AsyncOperationHandle<GameObject> asyncOperationHandle2 = _poolingConfiguration.coreItemAddressable.InstantiateAsync(Vector3.up * 1000f, Quaternion.identity, _templatesContainer);
				asyncOperationHandle2.Completed += (AsyncOperationHandle<GameObject> asyncOperationHandle3) =>
				{
					if (asyncOperationHandle3.Status == AsyncOperationStatus.Succeeded)
					{
						GameObject result = asyncOperationHandle3.Result;
						result.SetActive(value: false);
						int coreItemPoolStartingAmount = _poolingConfiguration.coreItemPoolStartingAmount;
						Transform transform = new GameObject(CORE_ITEM_ID + "Pool").transform;
						transform.parent = base.transform;
						_pools.Add(CORE_ITEM_ID, new FlexiblePool<PoolableObject>(coreItemPoolStartingAmount, result, transform, hideContainerInHierarchy: false));
						result.gameObject.name = result.gameObject.name + _pools[CORE_ITEM_ID].Size;
						OnPoolInitializationDone();
					}
				};
			}
			else
			{
				Debug.LogError("Cannot find key for core item addressable asset");
			}
		};
	}

	private void PreLoad(Item itemDef, int sizeOverride = -1)
	{
		if (string.IsNullOrEmpty(itemDef.addressableAsset?.AssetGUID))
		{
			Debug.LogError("Advanced item " + itemDef.itemID + " has failed to preload into PooledItemFactory because it has no valid addressable");
		}
		else
		{
			if (_pools.ContainsKey(itemDef.itemID))
			{
				return;
			}
			AsyncOperationHandle<IList<IResourceLocation>> asyncOperationHandle = Addressables.LoadResourceLocationsAsync(itemDef.addressableAsset);
			asyncOperationHandle.Completed += (AsyncOperationHandle<IList<IResourceLocation>> op) =>
			{
				if (op.Result != null && op.Result.Count > 0)
				{
					AsyncOperationHandle<GameObject> asyncOperationHandle2 = itemDef.addressableAsset.InstantiateAsync(Vector3.up * 1000f, Quaternion.identity, _templatesContainer);
					asyncOperationHandle2.Completed += (AsyncOperationHandle<GameObject> asyncOperationHandle3) =>
					{
						if (asyncOperationHandle3.Status == AsyncOperationStatus.Succeeded)
						{
							GameObject createdItem = asyncOperationHandle3.Result;
							createdItem.SetActive(value: false);
							if (createdItem.GetComponent<PooledInteractableItem>() == null)
							{
								Debug.LogWarning("Trying to preload a pool for item " + itemDef.itemID + " but item is not a PooledInteractableItem");
								OnPoolInitializationDone();
							}
							else
							{
								int poolSize = 2;
								PoolingConfiguration.PooledItemConfiguration pooledItemConfiguration = _poolingConfiguration.ItemPools.Where((PoolingConfiguration.PooledItemConfiguration x) => x.item.itemID == itemDef.itemID).FirstOrDefault();
								if (pooledItemConfiguration == null)
								{
									Debug.LogWarning("Poolable item has no configuration data in asset " + _poolingConfiguration.name, _poolingConfiguration);
								}
								else
								{
									poolSize = pooledItemConfiguration.startingAmount;
								}
								this.WaitForConditionIfNeeded(() => !GameState.WaitingForSaveFileLoad, () =>
								{
									int requestCount = GetRequestCount(itemDef);
									poolSize += requestCount;
									if (sizeOverride >= 0)
									{
										poolSize = sizeOverride;
									}
									Transform transform = new GameObject(itemDef.itemID + "Pool").transform;
									transform.parent = base.transform;
									_pools.Add(itemDef.itemID, new FlexiblePool<PoolableObject>(poolSize, createdItem, transform, hideContainerInHierarchy: false));
									createdItem.gameObject.name = createdItem.gameObject.name + _pools[itemDef.itemID].Size;
									OnPoolInitializationDone();
								});
							}
						}
					};
				}
				else
				{
					Debug.LogError($"Cannot find key {itemDef.addressableAsset.RuntimeKey}");
				}
			};
		}
	}

	private void OnPoolInitializationDone()
	{
		_poolsReady++;
		if (_poolsReady >= _poolingConfiguration.ItemPools.Count + 1)
		{
			Debug.Log("PooledItemFactory: all pools have been initialized");
			GameState.PoolsInitialized = true;
		}
	}

	[ContextMenu("Log All Pools")]
	private void LogAllPools()
	{
		if (_pools == null)
		{
			Debug.Log("Pools do not exist");
			return;
		}
		Debug.Log("===POOL=OF=POOLS===");
		foreach (KeyValuePair<string, FlexiblePool<PoolableObject>> pool in _pools)
		{
			Debug.Log($"[{pool.Key}] SIZE: {pool.Value.Size} AVAIL:{pool.Value.AvailableItems}");
		}
	}
}
