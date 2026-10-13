namespace Isto.Core.Automation;

public interface IAutomationItemFilter
{
	bool IsAccepted(AutomationCoreItem item);
}
