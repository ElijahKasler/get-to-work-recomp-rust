using System;
using Isto.Core.Power;

namespace Isto.Core;

public class TetherEventArgs : EventArgs
{
	public PowerTethered tethered;

	public TetherEventArgs(PowerTethered tethered)
	{
		this.tethered = tethered;
	}
}
