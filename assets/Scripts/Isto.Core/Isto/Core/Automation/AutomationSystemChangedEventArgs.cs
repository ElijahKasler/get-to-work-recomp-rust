using System;

namespace Isto.Core.Automation;

public class AutomationSystemChangedEventArgs : EventArgs
{
	public enum Change
	{
		AddResource = 0,
		RemoveResource = 1,
		AddProcessor = 2,
		RemoveProcessor = 3,
		Rotate = 4,
		AddCoreItem = 5,
		RemoveCoreItem = 6
	}

	public enum Source
	{
		Player = 0,
		ItemProcessor = 1
	}

	public Change changeType;

	public Source changeSource;

	public AutomationGridSpace space;

	public AutomationCoreItem changedItem;

	public AutomationSystemChangedEventArgs(AutomationGridSpace space, Change changeType, Source changeSource = Source.ItemProcessor)
	{
		this.space = space;
		this.changeType = changeType;
		this.changeSource = changeSource;
	}

	public AutomationSystemChangedEventArgs(AutomationGridSpace space, AutomationCoreItem item, Change changeType, Source changeSource = Source.ItemProcessor)
	{
		this.space = space;
		changedItem = item;
		this.changeType = changeType;
		this.changeSource = changeSource;
	}
}
