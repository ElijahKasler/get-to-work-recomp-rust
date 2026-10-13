using System.Collections.Generic;

namespace Isto.Core.Data;

public class AutomationItemDispenserData : AutomationProcessorData, IInventoryData
{
	public int inventoryPileSize;

	public int inventoryPileCount;

	public List<ItemData> inventory;

	public float timePerDrop;

	public float timeToNextDrop;

	public List<ItemData> GetInventoryData()
	{
		return inventory;
	}
}
