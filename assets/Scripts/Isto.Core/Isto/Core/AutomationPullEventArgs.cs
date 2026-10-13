using System;
using UnityEngine;

namespace Isto.Core;

public class AutomationPullEventArgs : EventArgs
{
	public Vector3 directionOfPull;

	public AutomationPullEventArgs(Vector3 pull)
	{
		directionOfPull = pull;
	}
}
