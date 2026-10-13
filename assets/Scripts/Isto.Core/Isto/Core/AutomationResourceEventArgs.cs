using System;

namespace Isto.Core;

public class AutomationResourceEventArgs : EventArgs
{
	public enum EventType
	{
		FullyHarvested = 0,
		Deleted = 1,
		FullyGrown = 2
	}

	public EventType eventType;

	public AutomationResourceEventArgs(EventType type)
	{
		eventType = type;
	}
}
