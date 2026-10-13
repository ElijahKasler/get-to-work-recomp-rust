using System;
using UnityEngine;

namespace Isto.Core.Automation;

public class PositionEventArgs : EventArgs
{
	public Vector3 position;

	public string itemID;

	public AutomationGridSpace space;

	public PositionEventArgs(Vector3 position, string itemID, AutomationGridSpace space = null)
	{
		this.position = position;
		this.itemID = itemID;
		this.space = space;
	}
}
