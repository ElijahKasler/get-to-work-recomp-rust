using System.Collections.Generic;
using Isto.Core.Items;
using UnityEngine;

namespace Isto.Core.Configuration;

[CreateAssetMenu(fileName = "Scriptables/New Game Setup", menuName = "Scriptables/New Game Setup")]
public class ScenarioSetup : ScriptableObject
{
	[Header("Items and Equipment")]
	public ItemPileList items;

	public ItemList equipped;

	[Header("Upgrades")]
	public List<UpgradeItem> startingUpgrades;
}
