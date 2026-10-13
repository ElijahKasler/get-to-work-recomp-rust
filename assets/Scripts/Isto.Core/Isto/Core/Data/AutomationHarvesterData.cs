using System.Collections.Generic;

namespace Isto.Core.Data;

public class AutomationHarvesterData : AutomationProcessorData, IInventoryData
{
	public float harvesterDPS;

	public bool destroyOnHarvestComplete;

	public List<ItemData> itemsQueue;

	public AutomationHarvesterData()
	{
		itemsQueue = new List<ItemData>();
	}

	public List<ItemData> GetInventoryData()
	{
		return itemsQueue;
	}
}
