using System;
using Isto.Core.Data;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationPlanter : IItemProcessor, IAutomationGridSpaceUser, IAutomationInventory, IDirectionalItem
{
	public class Factory : PlaceholderFactory<AutomationPlanterParams, AutomationPlanter>
	{
	}

	[Inject]
	private MasterItemList _masterItemList;

	[Inject]
	private AutomationSystem _system;

	private AutomationPlanterParams _params;

	private AutomationGridSpace _space;

	private RigidInventory _rigidInventory;

	private bool _growingComplete;

	private float _pauseBetweenGrowing;

	private AutomationCoreItem _targetItem;

	public string ProcessorID { get; private set; }

	public bool Visible => true;

	public Recipe Recipe { get; private set; }

	public bool Growing
	{
		get
		{
			if (GrowingPercent > 0f)
			{
				return GrowingPercent < 1f;
			}
			return false;
		}
	}

	public float GrowingPercent
	{
		get
		{
			if (_space != null)
			{
				if (_space.Resource != null)
				{
					return _space.Resource.GrowthPercent;
				}
				return 0f;
			}
			return 0f;
		}
	}

	public event EventHandler<ItemMoveArgs> ItemMoved;

	public AutomationPlanter(AutomationPlanterParams planterParams)
	{
		ProcessorID = planterParams.ID;
		_params = planterParams;
		_rigidInventory = new RigidInventory(3, 5);
		SetRecipe(_params.recipe);
	}

	public void Tick(float deltaTime)
	{
		CheckForIncomingItem();
		CheckToPullItemFromAdjacentSpaces();
		if ((_growingComplete || Growing) && _space.Resource == null)
		{
			_growingComplete = false;
		}
		else if (_growingComplete)
		{
			return;
		}
		ProcessGrowing(deltaTime);
	}

	private void ProcessGrowing(float deltaTime)
	{
		if (!(Recipe == null) && _space.Resource == null && _rigidInventory.HasAllInputs(Recipe))
		{
			_pauseBetweenGrowing += deltaTime;
			if (_pauseBetweenGrowing > 1f)
			{
				StartGrowing();
				_pauseBetweenGrowing = 0f;
			}
		}
	}

	public void StartGrowing()
	{
		for (int i = 0; i < Recipe.inputs.Count; i++)
		{
			_rigidInventory.Remove(Recipe.inputs[i].item, Recipe.inputs[i].count);
		}
		if (Recipe.inputs[0].item.harvestableSource != null)
		{
			HarvestableItem harvestableSource = Recipe.outputs[0].item.harvestableSource;
			if (!_system.TryAddResource(_params.worldPosition, harvestableSource))
			{
				Vector3 worldPosition = _params.worldPosition;
				Debug.LogWarning("Unable to add resource onto planter space at " + worldPosition.ToString());
			}
		}
		else
		{
			Debug.LogWarning("Recipe input does not have HarvestableParent setup, should be a seed item");
		}
	}

	private void CheckForIncomingItem()
	{
		if (_space.ActiveItem != null && !_space.ActiveItem.IsMoving && !_space.ActiveItem.IsReserved)
		{
			CoreItem itemByID = _masterItemList.GetItemByID<CoreItem>(_space.ActiveItem.ID);
			int num = _rigidInventory.Add(itemByID, _space.ActiveItem.count);
			if (num == _space.ActiveItem.count)
			{
				_system.DeleteCoreItem(_space.ActiveItem);
			}
			else if (num != 0)
			{
				_space.ActiveItem.count -= num;
			}
		}
	}

	private void CheckToPullItemFromAdjacentSpaces()
	{
		Vector3 position = _params.worldPosition + _params.forward;
		if (_system.TryGetExistingGridSpace(position, out var space) && space.ActiveItem != null && _rigidInventory.GetSpaceAvailable(_masterItemList.GetItemByID<CoreItem>(space.ActiveItem.ID)) > 0 && _space.ActiveItem == null)
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
		if (AutomationItemMover.TryItemMove(item, gridSpace, _space, _rigidInventory.GetSpaceAvailable(item.ID), _system, GetMover, out var createdItemMover))
		{
			ItemMoved?.Invoke(this, new ItemMoveArgs(createdItemMover));
		}
		else
		{
			Debug.LogError("Couldn't move item to expected free space");
		}
		item.IsReserved = false;
	}

	public IItemMoveType GetMover(AutomationCoreItem item, Vector3 destination, AutomationGridSpace nextSpace)
	{
		return new AutomationLinearMove(item, destination, _system.ItemMoveTime);
	}

	public void SetRecipe(Recipe recipe)
	{
		if (recipe != Recipe)
		{
			if (Growing)
			{
				_system.TryRemoveResource(_params.worldPosition);
				for (int i = 0; i < Recipe.inputs.Count; i++)
				{
					_rigidInventory.Add(Recipe.inputs[i]);
				}
				_growingComplete = true;
			}
			_rigidInventory.SetPileCount(recipe.inputs.Count);
			for (int j = 0; j < recipe.inputs.Count; j++)
			{
				if (recipe.inputs[j].item != _rigidInventory.Items[j].item)
				{
					ItemPile itemPile = _rigidInventory.RemoveAt(j);
					if (itemPile.count > 0)
					{
						_system.TryAddCoreItem(_space.position - Constants.FORWARD, itemPile.item, itemPile.count);
					}
					_rigidInventory.SetItemConstraintForPile(j, recipe.inputs[j].item);
				}
			}
		}
		Recipe = recipe;
	}

	public int IsAvailable(AutomationCoreItem movingItem)
	{
		CoreItem itemByID = _masterItemList.GetItemByID<CoreItem>(movingItem.ID);
		if (itemByID != null)
		{
			int countOfItemsIncoming = _space.GetCountOfItemsIncoming(itemByID.itemID);
			return _rigidInventory.GetSpaceAvailable(itemByID) - countOfItemsIncoming;
		}
		return 0;
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		_space = space;
	}

	public IInventory GetInventory()
	{
		return _rigidInventory;
	}

	public AutomationProcessorData GetSaveData()
	{
		return new AutomationPlanterData
		{
			typeId = ProcessorID,
			position = _params.worldPosition,
			recipeID = Recipe.outputs[0].item.itemID,
			inventory = ItemData.ConvertItemPileList(_rigidInventory.Items),
			direction = _params.forward
		};
	}

	public void LoadData(AutomationProcessorData data)
	{
		if (data is AutomationPlanterData automationPlanterData)
		{
			Recipe = _masterItemList.GetItemByID<CoreItem>(automationPlanterData.recipeID)?.GetRecipe();
			ItemData.LoadItemsIntoInventory(automationPlanterData.inventory.ToArray(), _rigidInventory, _masterItemList);
			ProcessorID = data.typeId;
			_params = new AutomationPlanterParams(data.typeId, Recipe, data.position, data.direction);
			SetRecipe(Recipe);
		}
	}

	public void SetForwardDirection(Vector3 forward)
	{
		_params.forward = forward;
	}

	public Vector3 GetDirection()
	{
		return _params.forward;
	}
}
