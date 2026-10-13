using System;

namespace Isto.Core.Automation;

public class ItemMoveArgs : EventArgs
{
	public IItemMoveType mover;

	public ItemMoveArgs(IItemMoveType mover)
	{
		this.mover = mover;
	}
}
