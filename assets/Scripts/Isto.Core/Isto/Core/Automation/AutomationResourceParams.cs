using Isto.Core.Items;

namespace Isto.Core.Automation;

public struct AutomationResourceParams(HarvestableItem item, float currentHealth, float currentGrowthPercent, bool infiniteResource = false)
{
	public HarvestableItem item = item;

	public float currentHealth = currentHealth;

	public float currentGrowthPercent = currentGrowthPercent;

	public bool harvestableWhileGrowing = false;

	public bool infiniteResource = infiniteResource;
}
