namespace Isto.Core.Automation;

public struct AutomationHarvesterParams(float harvestDps, string harvesterID, bool destroyOnHarvestComplete = false)
{
	public float harvestDps = harvestDps;

	public string harvesterID = harvesterID;

	public bool destroyOnHarvestComplete = destroyOnHarvestComplete;
}
