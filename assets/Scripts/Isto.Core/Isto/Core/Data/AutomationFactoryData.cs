using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Data;

public class AutomationFactoryData : AutomationProcessorData, IItemData, IInventoryData
{
	public string recipeItemId;

	public float cookingPercent;

	public List<ItemData> inventory;

	public ItemData itemWaitingForOutput;

	public Vector3 entranceOffset;

	public bool pullFromSpaceInfront;

	public List<ItemData> GetInventoryData()
	{
		return inventory;
	}

	public ItemData GetItemData()
	{
		return itemWaitingForOutput;
	}
}
