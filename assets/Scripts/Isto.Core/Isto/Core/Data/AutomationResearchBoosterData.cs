using System.Collections.Generic;
using Isto.Core.Automation;

namespace Isto.Core.Data;

public class AutomationResearchBoosterData : AutomationProcessorData, IInventoryData
{
	public float cookingPercent;

	public List<ItemData> inventory;

	public ResearchBoosts[] boosts;

	public List<ItemData> GetInventoryData()
	{
		return inventory;
	}
}
