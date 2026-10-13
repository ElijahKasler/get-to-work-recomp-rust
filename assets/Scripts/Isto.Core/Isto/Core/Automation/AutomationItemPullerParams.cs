using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Automation;

public class AutomationItemPullerParams
{
	public string ID;

	public List<string> validResources = new List<string>();

	public Vector3 forward;

	public bool pullWhenPlaced;

	public int pullDistance = 5;
}
