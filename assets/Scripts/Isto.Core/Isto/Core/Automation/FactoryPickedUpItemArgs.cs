using System;
using UnityEngine;

namespace Isto.Core.Automation;

public class FactoryPickedUpItemArgs : EventArgs
{
	public CoreItem item;

	public Vector3 position;

	public IItemMoveType moveType;
}
