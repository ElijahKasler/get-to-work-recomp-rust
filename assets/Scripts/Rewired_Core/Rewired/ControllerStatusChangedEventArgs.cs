using System;

namespace Rewired;

public sealed class ControllerStatusChangedEventArgs : EventArgs
{
	private string cyqELZltnapVdXmTdCmheGnKXQcm;

	private int CuCPfIriAnMjUaPxEQwLYGqlixNN;

	private ControllerType dSJhIQhMmnLhatkSMYmiCDGgqJqV;

	public string name => cyqELZltnapVdXmTdCmheGnKXQcm;

	public int controllerId => CuCPfIriAnMjUaPxEQwLYGqlixNN;

	public ControllerType controllerType => dSJhIQhMmnLhatkSMYmiCDGgqJqV;

	public Controller controller
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			return ReInput.controllers.GetController(dSJhIQhMmnLhatkSMYmiCDGgqJqV, CuCPfIriAnMjUaPxEQwLYGqlixNN);
		}
	}

	public ControllerStatusChangedEventArgs(string P_0, int P_1, ControllerType P_2)
	{
		cyqELZltnapVdXmTdCmheGnKXQcm = P_0;
		CuCPfIriAnMjUaPxEQwLYGqlixNN = P_1;
		dSJhIQhMmnLhatkSMYmiCDGgqJqV = P_2;
	}
}
