using System;

namespace Rewired;

public sealed class ControllerAssignmentChangedEventArgs : EventArgs
{
	private bool VuHspjtKuXMlmjkvoCnzJilvgdQIA;

	private int oZyNGHDOaNVfXQMjqmObExUPJthA;

	private int XuuDLYDAEhjPJAsWrcMmGvGtvrQe;

	private ControllerType qydgDIIrpDNjSkoelIXbobAhJIfb;

	public bool state => VuHspjtKuXMlmjkvoCnzJilvgdQIA;

	public Controller controller
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			return ReInput.controllers.GetController(qydgDIIrpDNjSkoelIXbobAhJIfb, XuuDLYDAEhjPJAsWrcMmGvGtvrQe);
		}
	}

	public Player player
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			return ReInput.players.GetPlayer(oZyNGHDOaNVfXQMjqmObExUPJthA);
		}
	}

	internal ControllerAssignmentChangedEventArgs(int P_0, int P_1, ControllerType P_2, bool P_3)
	{
		VuHspjtKuXMlmjkvoCnzJilvgdQIA = P_3;
		oZyNGHDOaNVfXQMjqmObExUPJthA = P_0;
		XuuDLYDAEhjPJAsWrcMmGvGtvrQe = P_1;
		qydgDIIrpDNjSkoelIXbobAhJIfb = P_2;
	}
}
