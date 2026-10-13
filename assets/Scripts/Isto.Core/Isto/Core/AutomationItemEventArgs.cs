using System;
using Isto.Core.Automation;

namespace Isto.Core;

public class AutomationItemEventArgs : EventArgs
{
	public AutomationCoreItem automationItem;

	public CoreItem coreItem;

	public AutomationItemEventArgs(AutomationCoreItem item, CoreItem coreItem)
	{
		automationItem = item;
		this.coreItem = coreItem;
	}
}
