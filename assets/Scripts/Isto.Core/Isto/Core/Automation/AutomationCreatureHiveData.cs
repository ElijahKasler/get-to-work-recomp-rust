using System.Collections.Generic;
using Isto.Core.Data;
using UnityEngine;

namespace Isto.Core.Automation;

public class AutomationCreatureHiveData : AutomationProcessorData, IInventoryData
{
	public int creatureCount;

	public string creatureAssetGUID;

	public string stockpiledItemID;

	public int inventoryPileSize;

	public int inventoryPileCount;

	public List<ItemData> inventory;

	public int maxCreatureCount;

	public float timePerSapwn;

	public Vector3 creatureRange;

	public Vector3 itemDroppingPosition;

	public AutomationCreatureHiveCreatureData[] currentCreaturesData;

	public List<ItemData> GetInventoryData()
	{
		return inventory;
	}
}
