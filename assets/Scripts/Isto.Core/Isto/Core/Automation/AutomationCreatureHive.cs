using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationCreatureHive : IItemProcessor, IAutomationGridSpaceUser, IAutomationInventory, IAutomationActionOnRemoved
{
	public class Factory : PlaceholderFactory<AutomationCreatureHiveParams, AutomationCreatureHive>
	{
	}

	[Inject]
	private MasterItemList _masterItemList;

	private AutomationGridSpace _space;

	private string _stockPiledItemID;

	private Inventory _inventory;

	private int _maxCreatureCount;

	private float _timePerSpawn;

	private float _spawnTimer;

	private AssetReference _creatureRef;

	private Transform _creatureContainer;

	private Vector3 _creatureRange;

	private Vector3 _itemDroppingPosition;

	private Vector3 _hiveDirection;

	private int _pendingSpawns;

	private bool _spawningPaused;

	private AutomationCreatureHiveCreatureData[] _initialCreatureData;

	public string ProcessorID { get; private set; }

	public Transform CreatureContainer => _creatureContainer;

	public string StockPiledItemID
	{
		get
		{
			return _stockPiledItemID;
		}
		set
		{
			_stockPiledItemID = value;
		}
	}

	public bool Visible => true;

	public Vector3 CreatureRange => _creatureRange;

	public Vector3 ItemDroppingPosition => _itemDroppingPosition;

	public Vector3 HiveDirection => _hiveDirection;

	public AutomationCreatureHive(AutomationCreatureHiveParams p)
	{
		ProcessorID = p.ID;
		_timePerSpawn = p.timePerSpawn;
		_maxCreatureCount = p.maxCreatureCount;
		_creatureRef = new AssetReference(p.CreatureAssetGUID);
		_creatureContainer = new GameObject(p.ID + " Creature Container").transform;
		_stockPiledItemID = p.StockPiledItemId;
		_inventory = new Inventory(p.pileCount, p.pileSize);
		_spawnTimer = _timePerSpawn;
		_creatureRange = p.creatureRange;
		_itemDroppingPosition = p.itemDroppingPosition;
		_hiveDirection = p.hiveDirection;
	}

	public void Tick(float deltaTime)
	{
		if (_initialCreatureData != null)
		{
			for (int i = 0; i < _initialCreatureData.Length; i++)
			{
				SpawnCreature(_initialCreatureData[i]);
			}
			_initialCreatureData = null;
		}
		_spawnTimer -= deltaTime;
		if (ShouldSpawnCreature())
		{
			_spawnTimer = _timePerSpawn;
			SpawnCreature();
		}
	}

	public void SpawnInitialCreatures(AutomationCreatureHiveCreatureData[] currentData)
	{
		_initialCreatureData = currentData;
	}

	private void SpawnCreature(AutomationCreatureHiveCreatureData data = null)
	{
		if (!_creatureRef.RuntimeKeyIsValid())
		{
			return;
		}
		_pendingSpawns++;
		AsyncOperationHandle<GameObject> asyncOperationHandle = _creatureRef.InstantiateAsync(_space.position, Quaternion.identity, _creatureContainer);
		asyncOperationHandle.Completed += (AsyncOperationHandle<GameObject> obj) =>
		{
			_pendingSpawns--;
			if (obj.Status == AsyncOperationStatus.Succeeded && obj.Result != null)
			{
				IAutomationGridSpaceDisplay[] components = obj.Result.GetComponents<IAutomationGridSpaceDisplay>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].SetGridSpace(_space);
				}
				if (data != null && data.creatureInventory != null)
				{
					ItemData[] creatureInventory = data.creatureInventory;
					if (obj.Result.TryGetComponent<IAutomationInventory>(out var component))
					{
						IInventory inventory = component.GetInventory();
						for (int j = 0; j < creatureInventory.Length; j++)
						{
							CoreItem itemByID = _masterItemList.GetItemByID<CoreItem>(creatureInventory[j].id);
							inventory.Add(itemByID, creatureInventory[j].count);
						}
					}
				}
			}
		};
	}

	private bool ShouldSpawnCreature()
	{
		if (_spawningPaused)
		{
			return false;
		}
		if (!(_spawnTimer < 0f))
		{
			return false;
		}
		return _creatureContainer.childCount + _pendingSpawns < _maxCreatureCount;
	}

	public IInventory GetInventory()
	{
		return _inventory;
	}

	public int IsAvailable(AutomationCoreItem movingItem)
	{
		return 0;
	}

	void IAutomationActionOnRemoved.Removed()
	{
		if (_creatureContainer != null)
		{
			Object.Destroy(_creatureContainer.gameObject);
		}
	}

	public AutomationProcessorData GetSaveData()
	{
		return new AutomationCreatureHiveData
		{
			typeId = ProcessorID,
			direction = _hiveDirection,
			position = _space.position,
			timePerSapwn = _timePerSpawn,
			maxCreatureCount = _maxCreatureCount,
			creatureAssetGUID = _creatureRef.AssetGUID,
			stockpiledItemID = _stockPiledItemID,
			inventory = ItemData.ConvertItemPileList(_inventory.Items),
			inventoryPileCount = _inventory.PileCount,
			inventoryPileSize = _inventory.PileSize,
			creatureCount = _creatureContainer.childCount,
			creatureRange = _creatureRange,
			itemDroppingPosition = _itemDroppingPosition,
			currentCreaturesData = GetCreaturesData()
		};
	}

	private AutomationCreatureHiveCreatureData[] GetCreaturesData()
	{
		int childCount = _creatureContainer.childCount;
		AutomationCreatureHiveCreatureData[] array = new AutomationCreatureHiveCreatureData[childCount];
		for (int i = 0; i < childCount; i++)
		{
			if (!_creatureContainer.GetChild(i).TryGetComponent<IAutomationInventory>(out var component))
			{
				continue;
			}
			array[i] = new AutomationCreatureHiveCreatureData();
			IInventory inventory = component.GetInventory();
			if (inventory != null)
			{
				int count = inventory.Items.Count;
				array[i].creatureInventory = new ItemData[count];
				for (int j = 0; j < count; j++)
				{
					array[i].creatureInventory[j] = new ItemData(inventory.Items[j]);
				}
			}
		}
		return array;
	}

	public void LoadData(AutomationProcessorData data)
	{
		if (data is AutomationCreatureHiveData automationCreatureHiveData)
		{
			ItemData.LoadItemsIntoInventory(automationCreatureHiveData.inventory.ToArray(), _inventory, _masterItemList);
		}
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		_space = space;
	}

	public bool TryGetPosition(out Vector3 position)
	{
		if (_space != null)
		{
			position = _space.position;
			return true;
		}
		position = Vector3.zero;
		return false;
	}

	public void PauseSpawning()
	{
		_spawningPaused = true;
	}

	public void UnpauseSpawning()
	{
		_spawningPaused = false;
	}

	public bool IsSpawningPaused()
	{
		return _spawningPaused;
	}
}
