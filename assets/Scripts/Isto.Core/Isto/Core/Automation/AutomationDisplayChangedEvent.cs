using System;
using UnityEngine;

namespace Isto.Core.Automation;

public class AutomationDisplayChangedEvent : EventArgs
{
	public enum ChangeType
	{
		AddMovingItem = 0
	}

	public ChangeType type;

	public GameObject displayObject;

	public AutomationCoreItem automationItem;

	public AutomationDisplayChangedEvent(ChangeType type, GameObject displayObject, AutomationCoreItem automationItem)
	{
		this.type = type;
		this.displayObject = displayObject;
		this.automationItem = automationItem;
	}
}
