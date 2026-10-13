using System.Collections.Generic;

namespace Isto.Core.Items;

public class MyComparer : IComparer<ItemPile>
{
	public int Compare(ItemPile x, ItemPile y)
	{
		if (x.item == null)
		{
			return 1;
		}
		if (y.item == null)
		{
			return -1;
		}
		return string.Compare(x.item.itemName, y.item.itemName);
	}
}
