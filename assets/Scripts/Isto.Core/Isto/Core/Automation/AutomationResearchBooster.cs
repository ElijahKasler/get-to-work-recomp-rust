using System;
using System.Collections.Generic;
using System.Linq;
using Isto.Core.Beings;
using Isto.Core.Data;
using Isto.Core.Items;
using Isto.Core.Research;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationResearchBooster : IItemProcessor, IAutomationGridSpaceUser, IAutomationInventory, IAutomationActionOnRemoved
{
	public class Factory : PlaceholderFactory<AutomationResearchBoosterParams, AutomationResearchBooster>
	{
	}

	[Inject]
	private MasterItemList _masterItemList;

	[Inject]
	private AutomationSystem _system;

	[Inject]
	private PlayerResearchModule _researchModule;

	[Inject]
	private PlayerInventory _playerInventory;

	private int maxNumberPerItem = 5;

	private IResearcher _researcher;

	private RigidInventory _inventory;

	private List<AutomationGridSpace> _spaces;

	private AutomationResearchBoosterEntrance _otherEntrance;

	private Vector3 _position;

	private Vector3 _otherEntranceOffset = new Vector3(-2f, 0f, 0f);

	private List<ResearchBoosts> _boosts;

	public string ProcessorID { get; private set; }

	public bool Visible => true;

	public bool Cooking { get; private set; }

	public float CookingPercent { get; private set; }

	public float BoostFactor { get; private set; }

	public AutomationResearchBooster(AutomationResearchBoosterParams boosterParams)
	{
		ProcessorID = boosterParams.ID;
		_researcher = boosterParams.researcher;
		_spaces = new List<AutomationGridSpace>();
		List<BoosterItemRate> itemMappings = boosterParams.mappings.itemMappings;
		_inventory = new RigidInventory(itemMappings.Count, maxNumberPerItem);
		_boosts = new List<ResearchBoosts>();
		for (int i = 0; i < itemMappings.Count; i++)
		{
			_inventory.SetItemConstraintForPile(i, itemMappings[i].boosterItem);
			_boosts.Add(new ResearchBoosts(itemMappings[i].boosterItem.itemID, itemMappings[i].boostAmount, itemMappings[i].cookTime, 0f));
		}
	}

	public void Tick(float deltaTime)
	{
		for (int i = 0; i < _spaces.Count; i++)
		{
			AutomationGridSpace automationGridSpace = _spaces[i];
			if (automationGridSpace.ActiveItem != null && !automationGridSpace.ActiveItem.IsMoving)
			{
				CoreItem itemByID = _masterItemList.GetItemByID<CoreItem>(automationGridSpace.ActiveItem.ID);
				if (_inventory.Add(itemByID, automationGridSpace.ActiveItem.count) == automationGridSpace.ActiveItem.count)
				{
					_system.DeleteCoreItem(automationGridSpace.ActiveItem);
					StartCookingItem(itemByID);
				}
				else
				{
					Debug.LogWarning("Unable to deposit item into inventory of research booster.  IsAvailable check shouldve prevented this.  Deleting item");
					_system.DeleteCoreItem(automationGridSpace.ActiveItem);
				}
			}
		}
		ProcessCooking(deltaTime);
	}

	private void StartCookingItem(CoreItem item)
	{
		for (int i = 0; i < _boosts.Count; i++)
		{
			if (_boosts[i].boostItemID.Equals(item.itemID, StringComparison.OrdinalIgnoreCase) && _boosts[i].timeRemaing == 0f)
			{
				_boosts[i].timeRemaing = _boosts[i].cookTime;
				_inventory.Remove(item);
			}
		}
	}

	public void PlayerDepositItem(int juiceNum)
	{
		ResearchBoosts boostAtIndex = GetBoostAtIndex(juiceNum);
		CoreItem itemByID = _masterItemList.GetItemByID<CoreItem>(boostAtIndex.boostItemID);
		for (int i = 0; i < _boosts.Count; i++)
		{
			if (_boosts[i].boostItemID.Equals(itemByID.itemID, StringComparison.OrdinalIgnoreCase) && _boosts[i].timeRemaing == 0f)
			{
				_boosts[i].timeRemaing = _boosts[i].cookTime;
				_playerInventory.Remove(itemByID);
			}
		}
	}

	private void ProcessCooking(float deltaTime)
	{
		if (_researchModule.ResearchComplete)
		{
			return;
		}
		Cooking = _boosts.Exists((ResearchBoosts x) => x.timeRemaing > 0f);
		if (Cooking)
		{
			UpdateCookTimes(deltaTime);
			BoostFactor = GetTotalBoostAmount();
		}
		for (int num = 0; num < _inventory.Items.Count; num++)
		{
			if (_inventory.Items[num].count > 0)
			{
				StartCookingItem(_inventory.Items[num].item);
			}
		}
	}

	private void UpdateCookTimes(float deltaTime)
	{
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < _boosts.Count; i++)
		{
			bool num3 = _boosts[i].timeRemaing > 0f;
			if (num3)
			{
				num += _boosts[i].cookTime;
				num2 += _boosts[i].timeRemaing;
			}
			_boosts[i].timeRemaing = Mathf.Clamp(_boosts[i].timeRemaing - deltaTime, 0f, _boosts[i].cookTime);
			if (num3 && _boosts[i].timeRemaing == 0f && _inventory.Remove(_boosts[i].boostItemID) == 1)
			{
				_boosts[i].timeRemaing = _boosts[i].cookTime;
			}
		}
		CookingPercent = ((num > 0f) ? (1f - num2 / num) : 0f);
	}

	private float GetTotalBoostAmount()
	{
		float num = 0f;
		for (int i = 0; i < _boosts.Count; i++)
		{
			if (_boosts[i].timeRemaing > 0f)
			{
				num += _boosts[i].boost;
			}
		}
		return num;
	}

	public IInventory GetInventory()
	{
		return _inventory;
	}

	public AutomationProcessorData GetSaveData()
	{
		return new AutomationResearchBoosterData
		{
			cookingPercent = CookingPercent,
			inventory = ItemData.ConvertItemPileList(_inventory.Items),
			typeId = ProcessorID,
			boosts = _boosts.ToArray()
		};
	}

	public void LoadData(AutomationProcessorData data)
	{
		if (data is AutomationResearchBoosterData automationResearchBoosterData)
		{
			ProcessorID = automationResearchBoosterData.typeId;
			if (automationResearchBoosterData.boosts != null)
			{
				_boosts = automationResearchBoosterData.boosts.ToList();
			}
			ItemData.LoadItemsIntoInventory(automationResearchBoosterData.inventory.ToArray(), _inventory, _masterItemList);
		}
	}

	public int IsAvailable(AutomationCoreItem movingItem)
	{
		if (!_boosts.Exists((ResearchBoosts x) => x.boostItemID.Equals(movingItem.ID, StringComparison.OrdinalIgnoreCase)))
		{
			return 0;
		}
		int spaceAvailable = _inventory.GetSpaceAvailable(movingItem.ID);
		if (spaceAvailable == 0)
		{
			return 0;
		}
		int num = 0;
		for (int num2 = 0; num2 < _spaces.Count; num2++)
		{
			for (int num3 = 0; num3 < _spaces[num2].AllItemsOnSpace.Count; num3++)
			{
				num += _spaces[num2].GetCountOfItemsIncoming(movingItem.ID);
			}
		}
		return spaceAvailable - num;
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		_position = space.position;
		_spaces.Add(space);
		_otherEntrance = new AutomationResearchBoosterEntrance(this);
		if (_system.TryAddItemProcessor(space.position + _otherEntranceOffset, _otherEntrance))
		{
			_spaces.Add(_system.GetOrCreateGridSpace(space.position + _otherEntranceOffset));
			return;
		}
		Vector3 position = space.position;
		Debug.LogWarning("coudln't add other entrance for Research Booster. Position: " + position.ToString() + _otherEntrance);
	}

	public void Removed()
	{
		_system.TryRemoveProcessor(_position + _otherEntranceOffset);
	}

	public ResearchBoosts GetBoostAtIndex(int index)
	{
		if (index < 0 || index >= _boosts.Count)
		{
			return null;
		}
		return _boosts[index];
	}

	public CoreItem GetBoostItemAtIndex(int index)
	{
		if (index < 0 || index >= _boosts.Count)
		{
			return null;
		}
		return _masterItemList.GetItemByID<CoreItem>(_boosts[index].boostItemID);
	}
}
