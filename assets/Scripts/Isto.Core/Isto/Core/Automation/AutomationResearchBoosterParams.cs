using Isto.Core.Research;

namespace Isto.Core.Automation;

public class AutomationResearchBoosterParams
{
	public string ID;

	public IResearcher researcher;

	public ResearchBoosterItemMappings mappings;

	public AutomationResearchBoosterParams(string ID, IResearcher researcher, ResearchBoosterItemMappings mappings)
	{
		this.ID = ID;
		this.researcher = researcher;
		this.mappings = mappings;
	}
}
