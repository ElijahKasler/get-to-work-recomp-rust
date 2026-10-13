using System;
using Isto.Core.Automation;
using Isto.Core.Items;

namespace Isto.Core;

public class ItemEventArgs : EventArgs
{
	public CoreItem item;

	public int count;

	public IInventory container;

	public ItemPlacementController placement;

	public ItemEventArgs(IInventory container, CoreItem item, int count = 1, ItemPlacementController placement = null)
	{
		this.item = item;
		this.count = count;
		this.container = container;
		this.placement = placement;
	}
}
