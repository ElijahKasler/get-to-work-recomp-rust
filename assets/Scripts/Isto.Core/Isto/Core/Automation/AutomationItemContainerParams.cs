namespace Isto.Core.Automation;

public struct AutomationItemContainerParams(int pileCount, int pileSize, string typeID, bool isRigidInventory, bool pullsItemsFromNeighbors)
{
	public int pileCount = pileCount;

	public int pileSize = pileSize;

	public string typeID = typeID;

	public bool isRigidInventory = isRigidInventory;

	public bool pullsItemsFromNeighbors = pullsItemsFromNeighbors;
}
