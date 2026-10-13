using System.Collections.Generic;
using System.Linq;

namespace Isto.Core.Data;

public class AutomationItemContainerData : AutomationProcessorData, IInventoryData
{
	public int inventoryPileSize;

	public int inventoryPileCount;

	public ItemData[] inventory;

	public bool isRigidInventory;

	public bool pullsItemsFromNeighbors;

	public List<ItemData> GetInventoryData()
	{
		return inventory.ToList();
	}
}
