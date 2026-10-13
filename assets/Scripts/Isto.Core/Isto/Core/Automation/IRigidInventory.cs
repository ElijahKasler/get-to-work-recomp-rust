namespace Isto.Core.Automation;

public interface IRigidInventory : IInventory
{
	void SetItemConstraintForPile(int index, CoreItem item);

	bool HasItemsSetOnPiles();
}
