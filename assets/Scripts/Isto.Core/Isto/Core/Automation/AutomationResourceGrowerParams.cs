using UnityEngine;

namespace Isto.Core.Automation;

public class AutomationResourceGrowerParams
{
	public float growthRate;

	public float growthRequired;

	public string seedItemID;

	public string readyItemID;

	public Vector3 worldPosition;

	public AutomationResourceGrowerParams(float growthRate, float growthRequired, string readyItemID, string seedItemID, Vector3 worldPosition)
	{
		this.growthRate = growthRate;
		this.growthRequired = growthRequired;
		this.readyItemID = readyItemID;
		this.worldPosition = worldPosition;
		this.seedItemID = seedItemID;
	}
}
