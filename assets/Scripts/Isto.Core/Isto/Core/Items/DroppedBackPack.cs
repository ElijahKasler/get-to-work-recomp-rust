using System.Collections.Generic;
using Isto.Core.Automation;
using Isto.Core.Beings;
using Isto.Core.Data;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

public class DroppedBackPack : InteractableItem, IDataLoadCompleteHandler, IAutomationGridSpaceDisplay
{
	public int pileCount = 8;

	public int pileSize = 25;

	[SerializeField]
	private List<ItemPile> _startingItems = new List<ItemPile>();

	private IInventory _container;

	private IUIGameMenu _mainMenu;

	private AutomationSystem _autoSystem;

	private AutomationItemContainer.Factory _containerFactory;

	private AutomationSystemDisplay _autoSystemDisplay;

	private AutomationItemContainer _systemContainer;

	private bool _setupInAutomation;

	public IInventory Container => _container;

	[Inject]
	public void Inject(IUIGameMenu mainMenu, AutomationSystem automationSystem, AutomationItemContainer.Factory containerFactory, AutomationSystemDisplay automationSystemDisplay)
	{
		_mainMenu = mainMenu;
		_autoSystem = automationSystem;
		_containerFactory = containerFactory;
		_autoSystemDisplay = automationSystemDisplay;
	}

	protected override void OnDestroy()
	{
		if (_container != null)
		{
			_container.InventoryChanged -= OnInventoryChanged;
		}
		base.OnDestroy();
	}

	public void OnDataLoadComplete()
	{
		SetupInAutomationSystem();
		Object.Destroy(base.gameObject, 0.1f);
	}

	public override void PlayerInteraction(AutomationPlayerController player, UserActions action)
	{
		if (action.Name == "INTERACT")
		{
			if (Vector3.Distance(player.transform.position, GetInteractionPosition(player.transform.position)) < player.InteractionRange)
			{
				_mainMenu.OpenMenu(GameMenusEnum.BACKPACK, new OpenStorageMenuArgs
				{
					inventory = _container
				});
			}
			else
			{
				player.SetMoveToAndInteractWithItem(this);
			}
		}
	}

	public override string GetItemName()
	{
		return Loc.GetString(Constants.ITEM_NAME_BACKPACK);
	}

	public override string GetToolTip(UserActions action)
	{
		if (action.Name == "INTERACT")
		{
			return Loc.GetString(Constants.USER_ACTION_OPEN);
		}
		Debug.LogWarningFormat("No Tool tip for action {0} on itme {1}", action, base.gameObject.name);
		return "";
	}

	public override List<UserActions> GetValidActions()
	{
		_actionList.Clear();
		_actionList.Add(UserActions.INTERACT);
		return _actionList;
	}

	public void ReceiveContents(List<ItemPile> items, int pileCount, int pileSize)
	{
		this.pileCount = pileCount;
		this.pileSize = pileSize;
		if (_systemContainer != null)
		{
			Debug.LogError("System container already exists when trying to create backpack");
		}
		SetupInAutomationSystem();
		for (int i = 0; i < items.Count; i++)
		{
			_container.Add(items[i]);
		}
	}

	private void OnInventoryChanged(object sender, ItemEventArgs e)
	{
		if (_container.GetTotalNumberOfItems() <= 0)
		{
			if (_setupInAutomation && !_autoSystem.TryRemoveProcessor(base.transform.position))
			{
				Debug.LogError("DroppedBackPack is empty but could not remove itself from automation system");
			}
			Object.Destroy(base.gameObject);
			_mainMenu.CloseMenu();
		}
	}

	private void SetupInAutomationSystem()
	{
		if (base.gameObject.activeInHierarchy)
		{
			_systemContainer = _containerFactory.Create(new AutomationItemContainerParams(pileCount, pileSize, itemPile.item.itemID, isRigidInventory: false, pullsItemsFromNeighbors: false));
			_container = _systemContainer.GetInventory();
			for (int i = 0; i < _startingItems.Count; i++)
			{
				_container.Add(_startingItems[i]);
			}
			_container.InventoryChanged += OnInventoryChanged;
			Vector3? vector = _autoSystem.AddItemProcessorToNearestSpace(base.transform.position, _systemContainer);
			if (vector.HasValue)
			{
				base.transform.position = vector.Value;
				_autoSystemDisplay.AddObjectToAreaDictionary(base.gameObject);
				_setupInAutomation = true;
			}
		}
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		_systemContainer = space.itemProcessor as AutomationItemContainer;
		_container = _systemContainer.GetInventory();
		_container.InventoryChanged += OnInventoryChanged;
		_setupInAutomation = true;
	}
}
