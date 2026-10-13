namespace Isto.Core.Items;

public interface IItemInteractionCallback
{
	void Success(ItemPile interactionItem, int affectedCount);
}
