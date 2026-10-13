using System.Collections.Generic;
using I2.Loc;
using Isto.Core.Localization;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Research Item", menuName = "Scriptables/Research/Research Item")]
public class ResearchItem : ScriptableObject
{
	public string ID = "NO ID SET";

	[Header("Research Requirements")]
	public int buildingLevel;

	public float researchTime = 120f;

	[Header("Research Description")]
	public LocalizedString itemNameLoc;

	public LocalizedString descriptionLoc;

	public LocalizedString activetedTextLoc;

	public Sprite icon;

	[Header("Research Complete")]
	public List<CoreItem> itemUnlocks;

	public List<UpgradeItem> upgradeUnlocks;

	public string itemName => Loc.Get(itemNameLoc);

	public string description => Loc.Get(descriptionLoc);

	public string activateText => Loc.Get(activetedTextLoc);
}
