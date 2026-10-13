using System;
using Rewired;
using Rewired.Platforms.Custom;

internal abstract class tLXHXtPkzoCxWTdhCCBPKJGccMByA : IDisposable
{
	protected readonly CustomPlatformUnifiedControllerSource oGRItHPlzGEUEGrPQvSxGRRVzixMA;

	private readonly HardwareControllerMap_Game uPXftDzuRtTWVQJRVJRMVYlGlAau;

	private bool dEheZIAMuYhbwwCbrddBsgkZfUTYA;

	private bool oAObpvrRLzaYkechjhsRdyRiXgoEb;

	public InputSource apaFaFBolAYUuoDLFkaJOudXHYLlA => get_inputSource();

	public HardwareControllerMap_Game kobhVXAAmABAZqLNzHaOCsyaecgS => get_hardwareMap();

	public int CXVdsKhuXJIiGwzPfsiHxSUXPADbb => get_axisCount();

	public int mqBfKcBhbfWtwmpPpfTbUUNTxduE => get_buttonCount();

	public Controller.Extension xaZSlhEwqirXHCbEVbvUUgbpsuRD => get_controllerExtension();

	public tLXHXtPkzoCxWTdhCCBPKJGccMByA(CustomPlatformUnifiedControllerSource P_0, HardwareControllerMap_Game P_1)
	{
		oGRItHPlzGEUEGrPQvSxGRRVzixMA = P_0;
		uPXftDzuRtTWVQJRVJRMVYlGlAau = P_1;
	}

	public InputSource get_inputSource()
	{
		return InputSource.Custom;
	}

	public HardwareControllerMap_Game get_hardwareMap()
	{
		return uPXftDzuRtTWVQJRVJRMVYlGlAau;
	}

	public int get_axisCount()
	{
		return oGRItHPlzGEUEGrPQvSxGRRVzixMA.axisCount;
	}

	public int get_buttonCount()
	{
		return oGRItHPlzGEUEGrPQvSxGRRVzixMA.buttonCount;
	}

	public Controller.Extension get_controllerExtension()
	{
		return oGRItHPlzGEUEGrPQvSxGRRVzixMA.controllerExtension;
	}

	public void Clear()
	{
		oGRItHPlzGEUEGrPQvSxGRRVzixMA.MeUgFkXZAlycSFvmTxRNpIlSKSRF();
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		oGRItHPlzGEUEGrPQvSxGRRVzixMA.rHAWMmxSortmYtGdceLvpokwFEVhA(dataUpdater);
	}

	public void ZuUHEcedBdXtXALgOKADgkVVQEZP()
	{
		oGRItHPlzGEUEGrPQvSxGRRVzixMA.XyasLKfyJSVTMaSEMGkouYJUdNFI();
	}

	protected virtual void fdlfKZOYlNvmXKuMJtQCsiIjckRH(bool P_0)
	{
		if (!oAObpvrRLzaYkechjhsRdyRiXgoEb)
		{
			if (P_0 && oGRItHPlzGEUEGrPQvSxGRRVzixMA != null)
			{
				((IDisposable)oGRItHPlzGEUEGrPQvSxGRRVzixMA).Dispose();
			}
			oAObpvrRLzaYkechjhsRdyRiXgoEb = true;
		}
	}

	void IDisposable.Dispose()
	{
		fdlfKZOYlNvmXKuMJtQCsiIjckRH(true);
		GC.SuppressFinalize(this);
	}
}
