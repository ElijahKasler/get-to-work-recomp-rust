using System.Collections.Generic;
using Isto.Core.Automation;
using Isto.Core.Items;

namespace Isto.Core.Data;

public class AutomationPlanterData : AutomationProcessorData, IInventoryData
{
	public string recipeID;

	public List<ItemData> inventory;

	public static AutomationPlanterParams GetParamsFromData(MasterItemList masterItemList, AutomationPlanterData data)
	{
		if (masterItemList.TryGetItemByID<CoreItem>(data.recipeID, out var item))
		{
			return new AutomationPlanterParams(data.typeId, item.GetRecipe(), data.position, data.direction);
		}
		return null;
	}

	public List<ItemData> GetInventoryData()
	{
		return inventory;
	}
}
