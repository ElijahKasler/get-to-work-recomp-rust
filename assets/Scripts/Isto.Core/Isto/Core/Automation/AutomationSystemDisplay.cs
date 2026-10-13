using System;
using System.Collections;
using System.Collections.Generic;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Items;
using Isto.Core.ObjectCulling;
using Isto.Core.Pooling;
using UPool;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationSystemDisplay : MonoBehaviour, IDataLoadCompleteHandler
{
	public enum AddedObjectType
	{
		Other = 0,
		ItemProcessor = 1,
		Ressource = 2
	}

	[SerializeField]
	private Vector3 _bottomCorner = new Vector3(-200f, 0f, -200f);

	[Header("Display Item Containers")]
	[SerializeField]
	private Transform _resourcesContainer;

	[SerializeField]
	private Transform _processorsContainer;

	[SerializeField]
	private Transform _coreItemContainer;

	private CullingStaticObjectsController _cullingController;

	private Vector3[] _gridPositionsBuffer = new Vector3[400];

	[SerializeField]
	private int _cullingAreaGridDiameter = 10;

	[SerializeField]
	private int _cullingSpheresPerRow = 80;

	[Header("Wrong visual flag hack fix")]
	[SerializeField]
	private List<Item> _brokenVisualFlagItemsToFix;

	private Dictionary<int, Coroutine> _runningShowObjectsRoutines = new Dictionary<int, Coroutine>();

	private bool _dataLoadComplete;

	private AutomationSystem _system;

	private MasterItemList _masterItemList;

	private PooledItemFactory _pooledItemFactory;

	[Header("Moving Items Culling")]
	[SerializeField]
	private int _maxMovingItemCount = 30;

	[SerializeField]
	private float _movingItemSphereRadius = 6f;

	private Dictionary<int, GameObject> _movingDisplayObjects;

	private Dictionary<int, AutomationCoreItem> _movingItems;

	private Dictionary<AutomationCoreItem, int> _movingItemToIndexMap;

	private CullingGroup _movingItemsCullingGroup;

	private BoundingSphere[] _movingSpheres;

	private Queue<int> _movingItemIndexes = new Queue<int>();

	[Header("Gizmos")]
	[SerializeField]
	private bool _showStaticCullingSpheres = true;

	[SerializeField]
	private bool _showCullingGridBounds = true;

	[SerializeField]
	private bool _showCullingIndex;

	[SerializeField]
	private Color _staticCullingSphereVisibleColor;

	[SerializeField]
	private Color _staticCullingSphereHIddenColor;

	[Space(20f)]
	[SerializeField]
	private bool _showSpaceContents;

	[SerializeField]
	private Color _processorColor;

	[SerializeField]
	private Color _coreItemColor;

	[SerializeField]
	private Color _resourceColor;

	[SerializeField]
	private Color _poweredColor;

	[Space(20f)]
	[SerializeField]
	private bool _showMovingItemSpheres;

	[SerializeField]
	private Color _movingItemSphereColor;

	public bool DrawTree;

	public Color gridTreeColor = Color.white;

	public Vector3Int topLeftSearch;

	public Vector3Int botRightSearch;

	public Vector3 BottomCorner => _bottomCorner;

	public int CullingAreaGridDiameter => _cullingAreaGridDiameter;

	public event EventHandler<AutomationDisplayChangedEvent> MovingItemDisplayObjectCreated;

	[Inject]
	public void Inject(AutomationSystem automationSystem, MasterItemList masterItemList, PooledItemFactory pooledItemFactory)
	{
		_system = automationSystem;
		_masterItemList = masterItemList;
		_pooledItemFactory = pooledItemFactory;
	}

	private void OnEnable()
	{
		_system.SystemChanged += OnSystemChanged;
		_cullingController = new CullingStaticObjectsController(_cullingAreaGridDiameter, _cullingSpheresPerRow, _bottomCorner, Camera.main, CullingGroupStateChanged);
		InitializeMovingCullingGroup();
	}

	private void Update()
	{
		UpdateMovingItemsSpherePositions();
	}

	private void OnDisable()
	{
		_system.SystemChanged -= OnSystemChanged;
		_cullingController.CullingGroup.Dispose();
		_movingItemsCullingGroup.Dispose();
		_movingItemsCullingGroup = null;
	}

	[ContextMenu("ForceRefreshVisibleItems")]
	public void RefreshVisibleItems()
	{
		int[] array = new int[_cullingController.Spheres.Length];
		int num = _cullingController.CullingGroup.QueryIndices(visible: true, array, 0);
		for (int i = 0; i < num; i++)
		{
			int gridPositionsInBoundingArea = _cullingController.GetGridPositionsInBoundingArea(array[i], ref _gridPositionsBuffer);
			Vector3[] gridPositions = (Vector3[])_gridPositionsBuffer.Clone();
			HideObjectsInArea(array[i]);
			Coroutine value = StartCoroutine(ShowObjectsInArea(gridPositions, gridPositionsInBoundingArea));
			_runningShowObjectsRoutines[array[i]] = value;
		}
	}

	private void OnSystemChanged(object sender, AutomationSystemChangedEventArgs e)
	{
		bool flag = ((e.space != null) ? _cullingController.IsSpaceVisible(e.space.position) : _cullingController.IsSpaceVisible(e.changedItem.position));
		switch (e.changeType)
		{
		case AutomationSystemChangedEventArgs.Change.AddResource:
		{
			if (!flag)
			{
				break;
			}
			if (_masterItemList.TryGetItemByID<HarvestableItem>(e.space.Resource.ID, out var item))
			{
				if (IsItemAssetValid(item))
				{
					if (e.space.Resource.VisualCulling)
					{
						TryGetPooledDisplayPrefab(item, e.space, _resourcesContainer, AddedObjectType.Ressource);
						e.space.ResourceRendered = true;
					}
				}
				else
				{
					Debug.LogWarning("Trying to create resource in automation system but " + e.space.Resource.ID + " asset is invalid.");
				}
			}
			else
			{
				Debug.LogWarning("Trying to create resource in automation system but " + e.space.Resource.ID + " item not found in masteritemlist.");
			}
			break;
		}
		case AutomationSystemChangedEventArgs.Change.AddProcessor:
			if (flag)
			{
				AdvancedItem itemByID = _masterItemList.GetItemByID<AdvancedItem>(e.space.itemProcessor.ProcessorID);
				if (itemByID != null && IsItemAssetValid(itemByID))
				{
					TryGetPooledDisplayPrefab(itemByID, e.space, _processorsContainer, AddedObjectType.ItemProcessor);
					e.space.ProcessorRendered = true;
				}
				else
				{
					Debug.LogWarning("Trying to create processor in automation system but " + e.space.itemProcessor.ProcessorID + " item not found in masteritemlist.  Processor type: " + e.space.itemProcessor.ToString());
				}
			}
			break;
		case AutomationSystemChangedEventArgs.Change.AddCoreItem:
		{
			int nextMovingItemIndexAndIncrement = GetNextMovingItemIndexAndIncrement();
			_movingItemToIndexMap.Add(e.changedItem, nextMovingItemIndexAndIncrement);
			if (flag)
			{
				bool bounceOnSpawn = e.space == null || e.space.itemProcessor == null;
				CreateItemDisplayPrefabAsync(e.changedItem, nextMovingItemIndexAndIncrement, e.changedItem.position, _coreItemContainer, e.changeSource == AutomationSystemChangedEventArgs.Source.Player, bounceOnSpawn);
			}
			else if (_movingItems.ContainsKey(nextMovingItemIndexAndIncrement))
			{
				Debug.LogError($"Item at index {nextMovingItemIndexAndIncrement} exists already.  Item: {_movingItems[nextMovingItemIndexAndIncrement].ID}");
			}
			else
			{
				_movingItems.Add(nextMovingItemIndexAndIncrement, e.changedItem);
				_movingSpheres[nextMovingItemIndexAndIncrement].position = e.changedItem.position;
				_movingSpheres[nextMovingItemIndexAndIncrement].radius = _movingItemSphereRadius;
			}
			break;
		}
		case AutomationSystemChangedEventArgs.Change.RemoveCoreItem:
		{
			if (_movingItemToIndexMap.TryGetValue(e.changedItem, out var value))
			{
				_movingItems.Remove(value);
				_movingItemToIndexMap.Remove(e.changedItem);
				if (_movingDisplayObjects.TryGetValue(value, out var value2))
				{
					value2.GetComponent<ItemController>().DestroyGameObject();
					_movingDisplayObjects.Remove(value);
				}
				_movingItemIndexes.Enqueue(value);
			}
			else if (!e.changedItem.IsConsumed)
			{
				Debug.LogWarning("Attempted to remove a CoreItem that is not part of the moving item map. Flagging it to be destroyed instead.");
				e.changedItem.ConsumeItem();
			}
			break;
		}
		case AutomationSystemChangedEventArgs.Change.RemoveResource:
		case AutomationSystemChangedEventArgs.Change.RemoveProcessor:
		case AutomationSystemChangedEventArgs.Change.Rotate:
			break;
		}
	}

	private bool IsItemAssetValid(Item newItem)
	{
		if (newItem.addressableAsset == null)
		{
			Debug.LogError("AddressableAsset not set for " + newItem.itemID);
			return false;
		}
		if (!newItem.addressableAsset.RuntimeKeyIsValid())
		{
			Debug.LogError("AddressableAsset runtime key not valid.  Item: " + newItem.itemID);
			return false;
		}
		return true;
	}

	private void TryGetPooledDisplayPrefab(Item item, AutomationGridSpace space, Transform container, AddedObjectType objectType)
	{
		if (_pooledItemFactory.IsItemPooled(item))
		{
			this.WaitForConditionIfNeeded(() => GameState.PoolsInitialized && GameState.GameDataLoaded, () =>
			{
				GameObject pooledItem = _pooledItemFactory.GetPooledItem(item);
				if (pooledItem != null)
				{
					pooledItem.transform.position = space.position;
					pooledItem.transform.parent = container;
					ReadyNewDisplayPrefab(pooledItem, space, objectType);
				}
				else
				{
					CreateDisplayPrefabAsync(item.addressableAsset, space, container, objectType);
				}
			});
		}
		else
		{
			CreateDisplayPrefabAsync(item.addressableAsset, space, container, objectType);
		}
	}

	private void CreateDisplayPrefabAsync(AssetReference asset, AutomationGridSpace space, Transform container, AddedObjectType objectType)
	{
		if (asset.RuntimeKeyIsValid())
		{
			AsyncOperationHandle<GameObject> asyncOperationHandle = asset.InstantiateAsync(space.position, Quaternion.identity, container);
			asyncOperationHandle.Completed += (AsyncOperationHandle<GameObject> op) =>
			{
				if (op.Status == AsyncOperationStatus.Succeeded)
				{
					GameObject result = op.Result;
					if (result == null)
					{
						Debug.LogError("Null GameObject returned from CreateDisplayPrefabAsync call. Asset Guid:" + asset.AssetGUID + ", Key:" + asset.Asset.name + ".");
					}
					else
					{
						ReadyNewDisplayPrefab(result, space, objectType);
					}
				}
			};
		}
		else
		{
			Debug.LogError("Runtime key invalid for asset: " + asset);
		}
	}

	private void ReadyNewDisplayPrefab(GameObject createdObject, AutomationGridSpace space, AddedObjectType objectType)
	{
		space.DisplayItem = createdObject;
		if (createdObject.TryGetComponent<ISpecialPositioning>(out var component))
		{
			component.SetupWorldPosition(space);
		}
		createdObject.SetActive(value: true);
		IAutomationGridSpaceDisplay[] components = createdObject.GetComponents<IAutomationGridSpaceDisplay>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].SetGridSpace(space);
		}
		if (((objectType == AddedObjectType.ItemProcessor && space.itemProcessor.Visible) || (objectType == AddedObjectType.Ressource && space.Resource.VisualCulling)) && !NeedsVisualFlagFixHack(space.itemProcessor?.ProcessorID))
		{
			_cullingController.AddStaticDisplayObject(createdObject);
		}
	}

	public void AddObjectToAreaDictionary(GameObject createdObject)
	{
		_cullingController.AddStaticDisplayObject(createdObject);
		_system.GetOrCreateGridSpace(createdObject.transform.position).DisplayItem = createdObject;
	}

	public void RemoveObjectFromAreaDictionary(GameObject objectToRemove)
	{
		_cullingController.ReleaseStaticDisplayObject(objectToRemove);
		if (_system.TryGetExistingGridSpace(objectToRemove.transform.position, out var space) && space.DisplayItem == objectToRemove)
		{
			space.DisplayItem = null;
		}
	}

	public void AddObjectToMovingItems(GameObject displayObject, AutomationCoreItem coreItem)
	{
		int nextMovingItemIndexAndIncrement = GetNextMovingItemIndexAndIncrement();
		_movingItemToIndexMap.Add(coreItem, nextMovingItemIndexAndIncrement);
		if (!_movingItems.ContainsKey(nextMovingItemIndexAndIncrement))
		{
			_movingItems.Add(nextMovingItemIndexAndIncrement, coreItem);
		}
		else if (_movingItems[nextMovingItemIndexAndIncrement] != coreItem)
		{
			Debug.LogWarning($"Index {nextMovingItemIndexAndIncrement} already exists in MovingItems dictionary. Existing item {_movingItems[nextMovingItemIndexAndIncrement].ID}.  Total moving items: {_movingItems.Count}");
		}
		_movingSpheres[nextMovingItemIndexAndIncrement].position = ((coreItem.GridSpace != null) ? coreItem.GridSpace.position : coreItem.position);
		_movingSpheres[nextMovingItemIndexAndIncrement].radius = 10f;
		_movingDisplayObjects[nextMovingItemIndexAndIncrement] = displayObject;
	}

	public void RemoveObjectFromMovingItems(AutomationCoreItem coreItem)
	{
		if (!_movingItemToIndexMap.TryGetValue(coreItem, out var value))
		{
			return;
		}
		_movingItems.Remove(value);
		_movingItemToIndexMap.Remove(coreItem);
		if (_movingDisplayObjects.TryGetValue(value, out var value2))
		{
			PoolableObject component = value2.GetComponent<PoolableObject>();
			if (component != null)
			{
				_pooledItemFactory.ReturnPooledCoreItem(component);
			}
			else
			{
				Debug.LogError("AutomationSystemDisplay.RemoveObjectFromMovingItems unexpectedly sees that " + value2.name + " is not poolable and releases it.");
				Addressables.ReleaseInstance(value2);
			}
			_movingDisplayObjects.Remove(value);
		}
		_movingItemIndexes.Enqueue(value);
	}

	public void CreateItemDisplayPrefab(AutomationCoreItem item, Vector3 position, bool autoCollect, bool bounceOnSpawn = false)
	{
		bool num = _cullingController.IsSpaceVisible(item.position);
		int nextMovingItemIndexAndIncrement = GetNextMovingItemIndexAndIncrement();
		_movingItemToIndexMap.Add(item, nextMovingItemIndexAndIncrement);
		if (num)
		{
			CreateItemDisplayPrefabAsync(item, nextMovingItemIndexAndIncrement, item.position, _coreItemContainer, autoCollect: false, bounceOnSpawn: false);
			return;
		}
		if (_movingItems.ContainsKey(nextMovingItemIndexAndIncrement))
		{
			Debug.LogError($"Item at index {nextMovingItemIndexAndIncrement} exists already.  Item: {_movingItems[nextMovingItemIndexAndIncrement].ID}");
			return;
		}
		_movingItems.Add(nextMovingItemIndexAndIncrement, item);
		_movingSpheres[nextMovingItemIndexAndIncrement].position = item.position;
		_movingSpheres[nextMovingItemIndexAndIncrement].radius = _movingItemSphereRadius;
	}

	private void CreateItemDisplayPrefabAsync(AutomationCoreItem item, int cullingIndex, Vector3 position, Transform container, bool autoCollect, bool bounceOnSpawn = true)
	{
		Vector3 spawnPosition = position;
		if (_system.GetOrCreateGridSpace(position).itemProcessor == null)
		{
			spawnPosition += UnityUtils.RandomXZVector(0.35f);
		}
		if (item.DisplayAssetOverride != null && item.DisplayAssetOverride.RuntimeKeyIsValid())
		{
			AsyncOperationHandle<GameObject> asyncOperationHandle = item.DisplayAssetOverride.InstantiateAsync(spawnPosition, Quaternion.identity, container);
			asyncOperationHandle.Completed += (AsyncOperationHandle<GameObject> op) =>
			{
				if (op.Status == AsyncOperationStatus.Succeeded)
				{
					GameObject result = op.Result;
					if (item == null || item.IsConsumed)
					{
						UnityEngine.Object.Destroy(result);
					}
					else
					{
						InitializeCoreItemInstance(result, item, cullingIndex, position, autoCollect, bounceOnSpawn);
					}
				}
			};
		}
		else
		{
			this.WaitForConditionIfNeeded(() => GameState.GameDataLoaded, () =>
			{
				GameObject pooledCoreItem = _pooledItemFactory.GetPooledCoreItem();
				pooledCoreItem.transform.position = spawnPosition;
				pooledCoreItem.transform.rotation = Quaternion.identity;
				pooledCoreItem.transform.parent = container;
				InitializeCoreItemInstance(pooledCoreItem, item, cullingIndex, position, autoCollect, bounceOnSpawn);
			});
		}
	}

	private void InitializeCoreItemInstance(GameObject createdObject, AutomationCoreItem item, int cullingIndex, Vector3 position, bool autoCollect, bool bounceOnSpawn)
	{
		createdObject.SetActive(value: true);
		if (!_movingItems.ContainsKey(cullingIndex))
		{
			_movingItems.Add(cullingIndex, item);
		}
		else if (_movingItems[cullingIndex] != item)
		{
			Debug.LogWarning($"Index {cullingIndex} already exists in MovingItems dictionary. Existing item {_movingItems[cullingIndex].ID}.  Total moving items: {_movingItems.Count}");
		}
		_movingSpheres[cullingIndex].position = position;
		_movingSpheres[cullingIndex].radius = 10f;
		_movingDisplayObjects[cullingIndex] = createdObject;
		if ((bounceOnSpawn | autoCollect) && createdObject.TryGetComponent<ItemSpawnBehaviour>(out var component))
		{
			if (!bounceOnSpawn)
			{
				component.SetStartForce(0f);
			}
			component.StartItemBounce(autoCollect);
		}
		IAutomationItemDisplay[] components = createdObject.GetComponents<IAutomationItemDisplay>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].SetItem(item, _system);
		}
		MovingItemDisplayObjectCreated?.Invoke(this, new AutomationDisplayChangedEvent(AutomationDisplayChangedEvent.ChangeType.AddMovingItem, createdObject, item));
	}

	private int GetIndexForNearestBoundingSphere(Vector3 vector)
	{
		Vector3 vector2 = (vector.GetSnappedPosition(_cullingAreaGridDiameter) - _bottomCorner) / _cullingAreaGridDiameter;
		return (int)(vector2.x * (float)_cullingSpheresPerRow + vector2.z);
	}

	private void CullingGroupStateChanged(CullingGroupEvent evt)
	{
		if (_dataLoadComplete)
		{
			if (evt.hasBecomeInvisible)
			{
				HideObjectsInArea(evt.index);
			}
			else if (evt.hasBecomeVisible)
			{
				int gridPositionsInBoundingArea = _cullingController.GetGridPositionsInBoundingArea(evt.index, ref _gridPositionsBuffer);
				Vector3[] gridPositions = (Vector3[])_gridPositionsBuffer.Clone();
				StartCoroutine(ShowObjectsInArea(gridPositions, gridPositionsInBoundingArea));
			}
		}
	}

	private void HideObjectsInArea(int sphereIndex)
	{
		if (_runningShowObjectsRoutines.TryGetValue(sphereIndex, out var value))
		{
			if (value != null)
			{
				StopCoroutine(value);
			}
			_runningShowObjectsRoutines.Remove(sphereIndex);
		}
		_cullingController.ReleaseObjectsInBoundingArea(sphereIndex, _system);
	}

	private IEnumerator ShowObjectsInArea(Vector3[] gridPositions, int count)
	{
		for (int i = 0; i < count; i++)
		{
			if (_system.DoesSpaceExist(gridPositions[i]))
			{
				AutomationGridSpace orCreateGridSpace = _system.GetOrCreateGridSpace(gridPositions[i]);
				CreateDisplayObjectsForSpace(orCreateGridSpace);
				if (i % 4 == 0)
				{
					yield return null;
				}
			}
		}
	}

	private void CreateDisplayObjectsForSpace(AutomationGridSpace space)
	{
		if (!space.ProcessorRendered && space.itemProcessor != null && space.itemProcessor.Visible && _masterItemList.TryGetItemByID<AdvancedItem>(space.itemProcessor.ProcessorID, out var item))
		{
			TryGetPooledDisplayPrefab(item, space, _processorsContainer, AddedObjectType.ItemProcessor);
			space.ProcessorRendered = true;
		}
		if (!space.ResourceRendered && space.Resource != null && space.Resource.VisualCulling && _masterItemList.TryGetItemByID<HarvestableItem>(space.Resource.ID, out var item2))
		{
			if (item2.addressableAsset.RuntimeKeyIsValid())
			{
				TryGetPooledDisplayPrefab(item2, space, _resourcesContainer, AddedObjectType.Ressource);
			}
			else
			{
				Debug.LogError("Cannot create asset for " + item2.itemID + ". RuntimeKey not valid");
			}
			space.ResourceRendered = true;
		}
	}

	private void InitializeMovingCullingGroup()
	{
		_movingDisplayObjects = new Dictionary<int, GameObject>(_maxMovingItemCount);
		_movingItems = new Dictionary<int, AutomationCoreItem>(_maxMovingItemCount);
		_movingItemToIndexMap = new Dictionary<AutomationCoreItem, int>(_maxMovingItemCount);
		_movingSpheres = new BoundingSphere[_maxMovingItemCount];
		_movingItemIndexes = new Queue<int>(_maxMovingItemCount);
		for (int i = 0; i < _maxMovingItemCount; i++)
		{
			_movingItemIndexes.Enqueue(i);
		}
		_movingItemsCullingGroup = new CullingGroup();
		_movingItemsCullingGroup.targetCamera = Camera.main;
		_movingItemsCullingGroup.SetBoundingSpheres(_movingSpheres);
		_movingItemsCullingGroup.SetBoundingSphereCount(_maxMovingItemCount);
		_movingItemsCullingGroup.onStateChanged = MovingCullingGroupStateChanged;
	}

	private void MovingCullingGroupStateChanged(CullingGroupEvent evt)
	{
		if (evt.hasBecomeVisible && _movingItems.ContainsKey(evt.index))
		{
			AutomationCoreItem automationCoreItem = _movingItems[evt.index];
			if (!_movingDisplayObjects.ContainsKey(evt.index))
			{
				CreateItemDisplayPrefabAsync(automationCoreItem, evt.index, automationCoreItem.position, _coreItemContainer, autoCollect: false, bounceOnSpawn: false);
			}
		}
		else if (evt.hasBecomeInvisible && _movingDisplayObjects.ContainsKey(evt.index))
		{
			GameObject gameObject = _movingDisplayObjects[evt.index];
			if (gameObject.IsNullOrDestroyed())
			{
				Debug.LogError("It seems we've left a destroyed GameObject in the moving display objects dictionary.");
			}
			PoolableObject component = gameObject.GetComponent<PoolableObject>();
			if (component != null)
			{
				_pooledItemFactory.ReturnPooledCoreItem(component);
			}
			else
			{
				Debug.LogWarning("AutomationSystemDisplay.MovingCullingGroupStateChanged sees that " + gameObject.name + " is not poolable and releases it.");
				Addressables.ReleaseInstance(gameObject);
			}
			_movingDisplayObjects.Remove(evt.index);
		}
	}

	private int GetNextMovingItemIndexAndIncrement()
	{
		if (_movingItemIndexes.Count > 0)
		{
			return _movingItemIndexes.Dequeue();
		}
		Debug.LogWarning("Out of available indexes for moving items.  Increasing capacity");
		int num = 5000;
		for (int i = 0; i < num; i++)
		{
			_movingItemIndexes.Enqueue(_maxMovingItemCount + i);
		}
		BoundingSphere[] array = new BoundingSphere[_maxMovingItemCount + num];
		for (int j = 0; j < _movingSpheres.Length; j++)
		{
			array[j] = _movingSpheres[j];
		}
		_movingSpheres = array;
		_movingItemsCullingGroup.SetBoundingSpheres(_movingSpheres);
		_movingItemsCullingGroup.SetBoundingSphereCount(_maxMovingItemCount + num);
		_maxMovingItemCount += num;
		return _movingItemIndexes.Dequeue();
	}

	private void UpdateMovingItemsSpherePositions()
	{
		foreach (int key in _movingItems.Keys)
		{
			_movingSpheres[key].position = _movingItems[key].position;
		}
	}

	public bool NeedsVisualFlagFixHack(string processorItemID)
	{
		if (string.IsNullOrEmpty(processorItemID))
		{
			return false;
		}
		if (_brokenVisualFlagItemsToFix == null)
		{
			return false;
		}
		for (int i = 0; i < _brokenVisualFlagItemsToFix.Count; i++)
		{
			if (_brokenVisualFlagItemsToFix[i].itemID == processorItemID)
			{
				return true;
			}
		}
		return false;
	}

	private void OnDrawGizmosSelected()
	{
		if (_cullingController == null)
		{
			return;
		}
		DrawCullingSpheres();
		if (_showSpaceContents)
		{
			foreach (AutomationGridSpace activeSpace in _system.Grid.ActiveSpaces)
			{
				ShowSpaceGizmos(activeSpace);
			}
			foreach (AutomationGridSpace sleepingSpace in _system.Grid.SleepingSpaces)
			{
				ShowSpaceGizmos(sleepingSpace);
			}
		}
		if (_showMovingItemSpheres)
		{
			foreach (int key in _movingItems.Keys)
			{
				Gizmos.color = _movingItemSphereColor;
				Gizmos.DrawWireSphere(_movingSpheres[key].position, _movingSpheres[key].radius);
				Gizmos.DrawSphere(_movingSpheres[key].position, 0.5f);
			}
		}
		if (DrawTree)
		{
			DrawGridTree();
		}
	}

	private void ShowSpaceGizmos(AutomationGridSpace space)
	{
		Vector3 vector = space.position + Constants.GRID_CENTERING_OFFSET;
		if (space.itemProcessor != null)
		{
			Gizmos.color = _processorColor;
			Gizmos.DrawCube(vector, Vector3.one * 0.8f);
			if (space.itemProcessor is IDirectionalItem directionalItem)
			{
				Gizmos.DrawRay(vector, directionalItem.GetDirection());
			}
		}
		if (space.ActiveItem != null)
		{
			Gizmos.color = _coreItemColor;
			Gizmos.DrawSphere(vector, 0.35f);
		}
		if (space.Resource != null)
		{
			Gizmos.color = _resourceColor;
			Gizmos.DrawSphere(vector + Vector3.up * 0.15f, 0.35f);
		}
		if (space.Powered)
		{
			Gizmos.color = _poweredColor;
			Gizmos.DrawSphere(vector - Constants.GRID_CENTERING_OFFSET * 0.5f, 0.15f);
		}
		if (space.IsEmpty())
		{
			Gizmos.color = Color.black;
			Gizmos.DrawCube(vector, Vector3.one * 0.8f);
		}
	}

	private void DrawCullingSpheres()
	{
		if (!_showStaticCullingSpheres && !_showCullingGridBounds)
		{
			return;
		}
		_ = new Vector3[100];
		for (int i = 0; i < _cullingController.Spheres.Length; i++)
		{
			bool flag = _cullingController.CullingGroup.IsVisible(i);
			Gizmos.color = (flag ? _staticCullingSphereVisibleColor : _staticCullingSphereHIddenColor);
			if (_showStaticCullingSpheres)
			{
				Gizmos.DrawWireSphere(_cullingController.Spheres[i].position, _cullingController.Spheres[i].radius);
			}
			if (_showCullingGridBounds)
			{
				Gizmos.DrawWireCube(_cullingController.Spheres[i].position, new Vector3(_cullingController.CullingAreaGridDiameter, 1f, _cullingController.CullingAreaGridDiameter));
			}
			_ = _showCullingIndex & flag;
		}
	}

	private void DrawGridTree()
	{
		Gizmos.color = gridTreeColor;
		DrawQuad(_system.Tree);
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(new Vector3((float)(topLeftSearch.x + botRightSearch.x) / 2f, 0f, (float)(topLeftSearch.z + botRightSearch.z) / 2f), new Vector3(botRightSearch.x - topLeftSearch.x, 0.1f, topLeftSearch.z - botRightSearch.z));
	}

	private void DrawQuad(AutomationQuad quad)
	{
		if (quad != null)
		{
			Gizmos.DrawWireCube(new Vector3((float)(quad.topLeftX + quad.botRightX) / 2f, 0f, (float)(quad.topLeftZ + quad.botRightZ) / 2f), new Vector3(quad.botRightX - quad.topLeftX, 0.1f, quad.topLeftZ - quad.botRightZ));
			if (quad.node != null)
			{
				Gizmos.DrawSphere(quad.node.position, 0.4f);
			}
			DrawQuad(quad.topLeftTree);
			DrawQuad(quad.topRightTree);
			DrawQuad(quad.botLeftTree);
			DrawQuad(quad.botRightTree);
		}
	}

	[ContextMenu("Search Area")]
	public void SearchArea()
	{
		List<QuadTreeNode> list = _system.Tree.Search(topLeftSearch, botRightSearch);
		for (int i = 0; i < list.Count; i++)
		{
			Debug.Log($"Node {i}: {list[i].position}");
		}
		Debug.Log("Total Nodes: " + list.Count);
	}

	public void OnDataLoadComplete()
	{
		_dataLoadComplete = true;
		RefreshVisibleItems();
	}
}
