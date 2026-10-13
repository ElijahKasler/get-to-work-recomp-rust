using UnityEngine;

namespace Isto.Core.Automation;

public class AutomationPlanterParams
{
	public string ID;

	public Recipe recipe;

	public Vector3 worldPosition;

	public Vector3 forward;

	public AutomationPlanterParams(string planterID, Recipe recipe, Vector3 worldPosition, Vector3 forward)
	{
		ID = planterID;
		this.recipe = recipe;
		this.worldPosition = worldPosition;
		this.forward = forward;
	}
}
