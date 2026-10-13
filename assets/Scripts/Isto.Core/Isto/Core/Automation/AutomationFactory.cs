using System;
using System.Collections.Generic;
using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationFactory : IItemProcessor, IDirectionalItem, IAutomationGridSpaceUser, IAutomationInventory, IAutomationActionOnRemoved
{
	public class Factory : PlaceholderFactory<AutomationFactoryParams, AutomationFactory>
	{
	}

	public static int FACTORY_PILE_COUNT = 10;

	public static int FACTORY_PILE_SIZE = 99;

	public static readonly Vector3[] FACTORY_FOOTPRINT = new Vector3[7]
	{
		new Vector3(0f, 0f, -1f),
		new Vector3(1f, 0f, 0f),
		new Vector3(-1f, 0f, 0f),
		new Vector3(1f, 0f, 1f),
		new Vector3(1f, 0f, -1f),
		new Vector3(-1f, 0f, 1f),
		new Vector3(-1f, 0f, -1f)
	};

	public static readonly Vector3[] DEER_FACTORY_FOOTPRINT_NE = new Vector3[3]
	{
		new Vector3(0f, 0f, 0f),
		new Vector3(-1f, 0f, 0f),
		new Vector3(-1f, 0f, -1f)
	};

	public static readonly Vector3[] DEER_FACTORY_FOOTPRINT_SW = new Vector3[3]
	{
		new Vector3(0f, 0f, 0f),
		new Vector3(-1f, 0f, 0f),
		new Vector3(-1f, 0f, 1f)
	};

	public static readonly Vector3[] DEER_FACTORY_FOOTPRINT_SE = new Vector3[3]
	{
		new Vector3(0f, 0f, 0f),
		new Vector3(0f, 0f, 1f),
		new Vector3(-1f, 0f, 1f)
	};

	public static readonly Vector3[] DEER_FACTORY_FOOTPRINT_NW = new Vector3[3]
	{
		new Vector3(0f, 0f, 0f),
		new Vector3(0f, 0f, 1f),
		new Vector3(1f, 0f, 1f)
	};

	[Inject]
	private MasterItemList _masterItemList;

	[Inject]
	private AutomationSystem _system;

	[Inject]
	private AutomationCoreItem.Factory _itemFactory;

	private AutomationGridSpace _space;

	private AutomationGridSpace _proxySpace;

	private Vector3 _forward = Vector3.right;

	private RigidInventory _inventory;

	private Recipe _recipe;

	private AutomationCoreItem _outputItem;

	private float _currentCookingTime;

	private Vector3Int _entranceOffset;

	private bool _allowIntakeWhileCooking;

	private bool _createDisplayItemOnOutput;

	private AutomationCoreItem _targetItem;

	private bool _pullFromSpaceInfront;

	private Vector3[] _footprint;

	public Recipe Recipe => _recipe;

	public bool Cooking { get; private set; }

	public bool WaitingToDropItem => _outputItem != null;

	public float CookingPercent
	{
		get
		{
			if (!(_recipe == null))
			{
				return _currentCookingTime / _recipe.cookTime;
			}
			return 0f;
		}
	}

	public string ProcessorID { get; private set; }

	public bool Visible => true;

	public event EventHandler<AutomationItemEventArgs> ItemCreated;

	public event EventHandler<FactoryPickedUpItemArgs> ItemPickedUp;

	public AutomationFactory(AutomationFactoryParams factoryParams)
	{
		_inventory = new RigidInventory((factoryParams.recipe == null) ? 1 : factoryParams.recipe.inputs.Count, factoryParams.pileSize);
		SetRecipe(factoryParams.recipe);
		ProcessorID = factoryParams.Id;
		_entranceOffset = factoryParams.entranceOffset;
		_allowIntakeWhileCooking = factoryParams.allowIntakeWhileCooking;
		_createDisplayItemOnOutput = factoryParams.createDisplayItemOnOutput;
		_pullFromSpaceInfront = factoryParams.pullFromSpaceInfront;
		_footprint = factoryParams.footPrint?.ToArray();
	}

	public void SetRecipe(Recipe recipe)
	{
		if (recipe == _recipe)
		{
			return;
		}
		if (Cooking && recipe != _recipe)
		{
			Cooking = false;
			_currentCookingTime = 0f;
			_outputItem = null;
		}
		if (recipe != null)
		{
			_inventory.SetPileCount(recipe.inputs.Count);
			for (int i = 0; i < recipe.inputs.Count; i++)
			{
				_inventory.SetItemConstraintForPile(i, recipe.inputs[i].item);
			}
		}
		else
		{
			_inventory.SetPileCount(1);
			_inventory.SetItemConstraintForPile(0, null);
		}
		_recipe = recipe;
	}

	public Vector3 GetDirection()
	{
		return _forward;
	}

	public int IsAvailable(AutomationCoreItem item)
	{
		if (!_space.Powered)
		{
			return 0;
		}
		AutomationCoreItem automationCoreItem = ((_proxySpace != null) ? _proxySpace.ActiveItem : _space.ActiveItem);
		if ((!_allowIntakeWhileCooking && Cooking) || (!_allowIntakeWhileCooking && automationCoreItem != null))
		{
			return 0;
		}
		int result;
		if (Recipe != null && Recipe.IsIngredient(item.ID))
		{
			int num = int.MaxValue;
			for (int i = 0; i < Recipe.inputs.Count; i++)
			{
				if (Recipe.inputs[i].item != null && Recipe.inputs[i].item.itemID.Equals(item.ID))
				{
					num = Recipe.inputs[i].count;
				}
			}
			int countOfItem = _inventory.GetCountOfItem(item.ID);
			result = Mathf.Clamp(_inventory.GetSpaceAvailable(item.ID), 0, num - countOfItem);
		}
		else
		{
			result = 0;
		}
		if (automationCoreItem != null)
		{
			return 0;
		}
		return result;
	}

	public void SetForwardDirection(Vector3 forward)
	{
		_forward = forward;
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		_space = space;
		CreateProxyProcessor();
		CreateBlockers();
	}

	private void CreateProxyProcessor()
	{
		if (_entranceOffset != Vector3Int.zero)
		{
			_proxySpace = _system.GetOrCreateGridSpace(_space.position + _entranceOffset);
			_proxySpace.itemProcessor = new AutomationProcessorProxy(this);
		}
	}

	private void CreateBlockers()
	{
		if (_entranceOffset == Vector3Int.zero)
		{
			_system.GetOrCreateGridSpace(_space.position + Vector3.back + Vector3.left).itemProcessor = new AutomationProcessorBlockedSpace(this);
			_system.GetOrCreateGridSpace(_space.position + Vector3.back + Vector3.right).itemProcessor = new AutomationProcessorBlockedSpace(this);
			_system.GetOrCreateGridSpace(_space.position + Vector3.forward + Vector3.left).itemProcessor = new AutomationProcessorBlockedSpace(this);
			_system.GetOrCreateGridSpace(_space.position + Vector3.forward + Vector3.right).itemProcessor = new AutomationProcessorBlockedSpace(this);
			return;
		}
		for (int i = 0; i < _footprint.Length; i++)
		{
			AutomationGridSpace orCreateGridSpace = _system.GetOrCreateGridSpace(_space.position + _footprint[i]);
			if (orCreateGridSpace.itemProcessor == null)
			{
				orCreateGridSpace.itemProcessor = new AutomationProcessorBlockedSpace(this);
			}
		}
	}

	public void Removed()
	{
		if (_entranceOffset != Vector3Int.zero)
		{
			_system.TryRemoveProcessor(_space.position + _entranceOffset);
			for (int i = 0; i < _footprint.Length; i++)
			{
				if (!(_footprint[i] == Vector3.zero))
				{
					_system.TryRemoveProcessor(_space.position + _footprint[i]);
				}
			}
		}
		else
		{
			_system.TryRemoveProcessor(_space.position + Vector3.back + Vector3.left);
			_system.TryRemoveProcessor(_space.position + Vector3.back + Vector3.right);
			_system.TryRemoveProcessor(_space.position + Vector3.forward + Vector3.left);
			_system.TryRemoveProcessor(_space.position + Vector3.forward + Vector3.right);
		}
	}

	public void AbortCooking()
	{
		if (_recipe == null || !Cooking)
		{
			return;
		}
		if (_currentCookingTime >= _recipe.cookTime)
		{
			AutomationCoreItem automationCoreItem = _itemFactory.Create(new CoreItemParams(_recipe.outputs[0].item.itemID, _recipe.outputs[0].count, _space.position));
			if (!_system.TryAddCoreItemToSpace(_space.position, automationCoreItem, autoCollectItem: true))
			{
				Debug.LogError($"Factory tried to dump recipe output {automationCoreItem.ID} to space at {_space.position} but could not.");
			}
		}
		else
		{
			foreach (ItemPile input in _recipe.inputs)
			{
				AutomationCoreItem automationCoreItem2 = _itemFactory.Create(new CoreItemParams(input.item.itemID, input.count, _space.position));
				if (!_system.TryAddCoreItemToSpace(_space.position, automationCoreItem2, autoCollectItem: true))
				{
					Debug.LogError($"Factory tried to return ingredient {automationCoreItem2.ID} to space at {_space.position} but could not.");
				}
			}
		}
		_currentCookingTime = 0f;
		Cooking = false;
	}

	public void Tick(float deltaTime)
	{
		if (!_space.Powered)
		{
			return;
		}
		if (_pullFromSpaceInfront && !WaitingToDropItem)
		{
			CheckToPullItemFromAdjacentSpaces();
		}
		AutomationGridSpace automationGridSpace = ((_proxySpace != null) ? _proxySpace : _space);
		AutomationCoreItem automationCoreItem = automationGridSpace?.ActiveItem;
		if (automationCoreItem != null && !automationCoreItem.IsMoving && !automationCoreItem.IsReserved && !automationCoreItem.IsConsumed)
		{
			CoreItem itemByID = _masterItemList.GetItemByID<CoreItem>(automationCoreItem.ID);
			int num = _inventory.Add(itemByID, automationCoreItem.count);
			if (num == automationCoreItem.count)
			{
				CoreItem itemByID2 = _masterItemList.GetItemByID<CoreItem>(automationCoreItem.ID);
				ItemPickedUp?.Invoke(this, new FactoryPickedUpItemArgs
				{
					item = itemByID2,
					position = automationCoreItem.position,
					moveType = automationCoreItem.MoveType
				});
				_system.DeleteCoreItem(automationCoreItem);
			}
			else if (num != 0)
			{
				automationGridSpace.ActiveItem.count -= num;
			}
			else
			{
				AutomationGridSpace orCreateGridSpace = _system.GetOrCreateGridSpace(_space.position + _forward);
				if (_system.CanMoveItemToGridSpace(orCreateGridSpace, automationCoreItem, out var _) && orCreateGridSpace.TrySetItem(automationCoreItem))
				{
					automationGridSpace.ClearItem(automationCoreItem);
					orCreateGridSpace.MoveItemToSpace(new AutomationLinearMove(automationCoreItem, orCreateGridSpace.position, _system.ItemMoveTime));
				}
			}
		}
		CheckForStuckItems();
		ProcessCooking(deltaTime);
	}

	private void CheckToPullItemFromAdjacentSpaces()
	{
		Vector3 position = ((_proxySpace != null) ? _proxySpace.position : _space.position) - _forward;
		if (!_system.TryGetExistingGridSpace(position, out var space))
		{
			return;
		}
		bool num = space.ActiveItem != null;
		bool flag = _proxySpace.ActiveItem == null && _space.ActiveItem == null;
		if ((num && _inventory.GetSpaceAvailable(_masterItemList.GetItemByID<CoreItem>(space.ActiveItem.ID)) > 0) & flag)
		{
			if (space.ActiveItem.IsMoving)
			{
				_targetItem = space.ActiveItem;
				_targetItem.MoveComplete += OnIncomingMoveComplete;
			}
			else
			{
				StartPullOfItem(space.ActiveItem);
			}
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
		AutomationGridSpace nextSpace = ((_proxySpace != null) ? _proxySpace : _space);
		int spaceAvailable = _inventory.GetSpaceAvailable(item.ID);
		AutomationItemMover.TryItemMove(item, gridSpace, nextSpace, spaceAvailable, _system, GetMover, out var _);
		item.IsReserved = false;
	}

	public IItemMoveType GetMover(AutomationCoreItem item, Vector3 destination, AutomationGridSpace nextSpace)
	{
		return new AutomationLinearMove(item, destination, _system.ItemMoveTime);
	}

	private void CheckForStuckItems()
	{
		AutomationGridSpace automationGridSpace = ((_proxySpace != null) ? _proxySpace : _space);
		if (_footprint == null || automationGridSpace.ActiveItem != null)
		{
			return;
		}
		for (int i = 0; i < _footprint.Length; i++)
		{
			if (_system.TryGetExistingGridSpace(_space.position + _footprint[i], out var space) && space?.ActiveItem != null && !space.ActiveItem.IsMoving && !space.ActiveItem.IsReserved && !space.ActiveItem.IsConsumed)
			{
				AutomationCoreItem activeItem = space.ActiveItem;
				if (ShouldItemBeDiscarded(space) && automationGridSpace.TrySetItem(activeItem, ignoreProcessor: true))
				{
					space.ClearItem(activeItem);
					automationGridSpace.MoveItemToSpace(new AutomationLinearMove(activeItem, automationGridSpace.position, _system.ItemMoveTime * 0.5f));
					activeItem.SetGridSpace(automationGridSpace);
					break;
				}
			}
		}
	}

	private bool ShouldItemBeDiscarded(AutomationGridSpace itemTile)
	{
		bool result = false;
		if (itemTile.itemProcessor is AutomationProcessorBlockedSpace)
		{
			result = true;
		}
		else if (itemTile == _space && _proxySpace != null)
		{
			result = true;
		}
		else if (Recipe == null || !Recipe.IsIngredient(itemTile.ActiveItem.ID))
		{
			result = true;
		}
		return result;
	}

	private void ProcessCooking(float deltaTime)
	{
		if (_recipe == null)
		{
			return;
		}
		if (Cooking)
		{
			_currentCookingTime = Mathf.Clamp(_currentCookingTime + deltaTime, 0f, _recipe.cookTime);
			if (_currentCookingTime >= _recipe.cookTime)
			{
				CookingComplete();
			}
		}
		else if (_recipe != null && _inventory.HasAllInputs(_recipe))
		{
			TryToCook();
		}
	}

	private void TryToCook()
	{
		if (!Cooking && _inventory.HasAllInputs(_recipe))
		{
			Cooking = true;
			_currentCookingTime = 0f;
			for (int i = 0; i < _recipe.inputs.Count; i++)
			{
				_inventory.Remove(_recipe.inputs[i].item, _recipe.inputs[i].count);
			}
		}
	}

	private void CookingComplete()
	{
		if (_recipe.outputs.Count > 0)
		{
			if (!WaitingToDropItem)
			{
				_outputItem = _itemFactory.Create(new CoreItemParams(_recipe.outputs[0].item.itemID, _recipe.outputs[0].count, _space.position));
			}
			if (TryDropItem())
			{
				_currentCookingTime = 0f;
				Cooking = false;
			}
		}
		else
		{
			_currentCookingTime = 0f;
			Cooking = false;
		}
	}

	private bool TryDropItem()
	{
		AutomationGridSpace orCreateGridSpace = _system.GetOrCreateGridSpace(_space.position + _forward);
		if (_system.CanMoveItemToGridSpace(orCreateGridSpace, _outputItem, out var _))
		{
			ItemCreated?.Invoke(this, new AutomationItemEventArgs(_outputItem, _recipe.outputs[0].item));
			_system.TryAddCoreItemToSpace(orCreateGridSpace.position, _outputItem, autoCollectItem: false, _createDisplayItemOnOutput);
			orCreateGridSpace.MoveItemToSpace(new AutomationLinearMove(_outputItem, orCreateGridSpace.position, _system.ItemMoveTime));
			_outputItem = null;
			return true;
		}
		return false;
	}

	public IInventory GetInventory()
	{
		return _inventory;
	}

	public void CreateDisplayPrefabWhenItemCreated(bool createPrefab)
	{
		_createDisplayItemOnOutput = createPrefab;
	}

	public override string ToString()
	{
		return "Factory.  Recipe: " + _recipe?.name;
	}

	public AutomationProcessorData GetSaveData()
	{
		return new AutomationFactoryData
		{
			direction = _forward,
			recipeItemId = ((Recipe != null) ? Recipe.outputs[0].item.itemID : ""),
			cookingPercent = CookingPercent,
			itemWaitingForOutput = ((_outputItem == null) ? null : new ItemData(_outputItem.ID, "", _outputItem.count)),
			inventory = ItemData.ConvertItemPileList(_inventory.Items),
			typeId = ProcessorID,
			entranceOffset = _entranceOffset,
			pullFromSpaceInfront = _pullFromSpaceInfront
		};
	}

	public void LoadData(AutomationProcessorData data)
	{
		AutomationFactoryData automationFactoryData = data as AutomationFactoryData;
		ProcessorID = automationFactoryData.typeId;
		_entranceOffset = Vector3Int.RoundToInt(automationFactoryData.entranceOffset);
		_pullFromSpaceInfront = automationFactoryData.pullFromSpaceInfront;
		SetForwardDirection(data.direction);
		bool flag = ProcessorID.Contains("MiniDeerCaptured");
		SetRecipe(_masterItemList.GetItemByID<CoreItem>(automationFactoryData.recipeItemId)?.GetRecipe(flag));
		ItemData.LoadItemsIntoInventory(automationFactoryData.inventory.ToArray(), _inventory, _masterItemList);
		if (automationFactoryData.cookingPercent != 0f)
		{
			_currentCookingTime = _recipe.cookTime * automationFactoryData.cookingPercent;
			Cooking = true;
		}
		if (automationFactoryData.itemWaitingForOutput != null)
		{
			_outputItem = _itemFactory.Create(new CoreItemParams(automationFactoryData.itemWaitingForOutput.id, automationFactoryData.itemWaitingForOutput.count, automationFactoryData.position));
		}
		if (flag)
		{
			_entranceOffset = -Vector3Int.RoundToInt(data.direction);
		}
		_createDisplayItemOnOutput = true;
	}

	public static void GetFootprint(Vector3 direction, ref List<Vector3> footprintTilePositions)
	{
		footprintTilePositions.Clear();
		footprintTilePositions.AddRange(FACTORY_FOOTPRINT);
		float angleRotationFromDefaultDirection = GetAngleRotationFromDefaultDirection(direction);
		for (int i = 0; i < footprintTilePositions.Count; i++)
		{
			footprintTilePositions[i] = (Quaternion.Euler(0f, angleRotationFromDefaultDirection, 0f) * footprintTilePositions[i]).GetSnappedPosition(1f);
		}
	}

	private static float GetAngleRotationFromDefaultDirection(Vector3 currentDropDirection)
	{
		if (currentDropDirection.x == 1f)
		{
			return 90f;
		}
		if (currentDropDirection.z == -1f)
		{
			return 180f;
		}
		if (currentDropDirection.x == -1f)
		{
			return 270f;
		}
		return 0f;
	}

	public static void GetMiniDeerFootprint(Vector3 direction, ref List<Vector3> footprintTilePositions)
	{
		footprintTilePositions.Clear();
		if (direction.z == 1f)
		{
			footprintTilePositions.AddRange(DEER_FACTORY_FOOTPRINT_NE);
		}
		else if (direction.z == -1f)
		{
			footprintTilePositions.AddRange(DEER_FACTORY_FOOTPRINT_SW);
		}
		else if (direction.x == 1f)
		{
			footprintTilePositions.AddRange(DEER_FACTORY_FOOTPRINT_SE);
		}
		else if (direction.x == -1f)
		{
			footprintTilePositions.AddRange(DEER_FACTORY_FOOTPRINT_NW);
		}
	}
}
