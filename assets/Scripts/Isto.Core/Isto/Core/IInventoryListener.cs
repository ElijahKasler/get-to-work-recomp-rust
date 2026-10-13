namespace Isto.Core;

public interface IInventoryListener
{
	void InventoryChanged();

	void InventoryFull();
}
