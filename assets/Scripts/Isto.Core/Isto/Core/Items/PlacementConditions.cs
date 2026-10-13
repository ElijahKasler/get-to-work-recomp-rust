using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Placement Conditions", menuName = "Scriptables/Item/PlacementConditions")]
public class PlacementConditions : ScriptableObject
{
	[TextArea]
	public string description;

	public LayerMask invalidLayers = 0;

	[Tooltip("Advanced items that can have this item placed on a be removed")]
	public List<AdvancedItem> validItemsToReplace;

	[Tooltip("Harvestable items that can have this item palced on and be removed")]
	public List<HarvestableItem> validResourcesToReplace;
}
