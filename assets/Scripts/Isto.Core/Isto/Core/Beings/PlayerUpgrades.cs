using System;
using System.Collections.Generic;
using Isto.Core.Automation;
using Isto.Core.Configuration;
using Isto.Core.Game;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Beings;

public class PlayerUpgrades : MonoBehaviour
{
	private GameState _gameState;

	private AutomationPlayerController _player;

	private CraftingQueue _craftingQueue;

	private PlayerInventory _playerInventory;

	private List<UpgradeItem> _startingUpgrades = new List<UpgradeItem>();

	private List<UpgradeItem> _activeUpgrades = new List<UpgradeItem>();

	public bool AutoCollectEnabled { get; set; }

	public float TorchDurationIncrease { get; set; }

	[Inject]
	public void Inject(GameplaySettings gameplaySettings, GameState gameData, AutomationPlayerController playerController, CraftingQueue craftingQueue, PlayerInventory playerInventory)
	{
		_gameState = gameData;
		_player = playerController;
		_craftingQueue = craftingQueue;
		_playerInventory = playerInventory;
		ScenarioSetup startingSetup = gameplaySettings.GetStartingSetup();
		_startingUpgrades = startingSetup.startingUpgrades;
	}

	private void Start()
	{
		InstallStartingUpgrades();
		_playerInventory.LoadStartingItemsAndEquipment();
	}

	private void OnEnable()
	{
		RegisterEvents();
	}

	private void OnDisable()
	{
		UnregisterEvents();
	}

	private void RegisterEvents()
	{
		_craftingQueue.ItemCrafted += OnItemCrafted;
		_gameState.LoadComplete += OnLoadComplete;
	}

	private void UnregisterEvents()
	{
		_craftingQueue.ItemCrafted -= OnItemCrafted;
		_gameState.LoadComplete -= OnLoadComplete;
	}

	private void OnLoadComplete(object sender, EventArgs e)
	{
		InstallStartingUpgrades();
	}

	private void OnItemCrafted(object sender, ItemEventArgs e)
	{
		if (e.item.GetType() == typeof(UpgradeItem))
		{
			UpgradeItem upgrade = e.item as UpgradeItem;
			InstallUpgrade(upgrade);
		}
	}

	public List<UpgradeItem> GetActiveUpgrades()
	{
		return _activeUpgrades;
	}

	public void InstallStartingUpgrades()
	{
		InstallUpgrades(_startingUpgrades);
	}

	public void InstallUpgrades(List<UpgradeItem> upgrades)
	{
		for (int i = 0; i < upgrades.Count; i++)
		{
			UpgradeItem upgrade = upgrades[i];
			InstallUpgrade(upgrade);
		}
	}

	public void InstallUpgrade(UpgradeItem upgrade)
	{
		if (!(upgrade == null) && !_activeUpgrades.Contains(upgrade))
		{
			_activeUpgrades.Add(upgrade);
			for (int i = 0; i < upgrade.effects.Count; i++)
			{
				upgrade.effects[i].ActivateEffect(_player);
			}
		}
	}

	public void UninstallAllUpgrades()
	{
		for (int num = _activeUpgrades.Count - 1; num >= 0; num--)
		{
			UpgradeItem upgradeItem = _activeUpgrades[num];
			for (int num2 = upgradeItem.effects.Count - 1; num2 >= 0; num2--)
			{
				upgradeItem.effects[num2].DeactivateEffect(_player);
			}
		}
		_activeUpgrades.Clear();
	}
}
