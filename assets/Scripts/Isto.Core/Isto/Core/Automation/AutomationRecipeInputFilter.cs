namespace Isto.Core.Automation;

public class AutomationRecipeInputFilter : IAutomationItemFilter
{
	private AutomationFactory _linkedFactory;

	public AutomationRecipeInputFilter(AutomationFactory factory)
	{
		_linkedFactory = factory;
	}

	bool IAutomationItemFilter.IsAccepted(AutomationCoreItem item)
	{
		if (_linkedFactory == null)
		{
			return false;
		}
		return _linkedFactory.IsAvailable(item) > 0;
	}
}
