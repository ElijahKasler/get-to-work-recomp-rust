using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class NHaXdADzcpEBVOTeihzYSIZTkQhR : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr gDVzoRURUCPEqvpPycUJGKXWyZzhA(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct XvzlvrqEfToCdzKqpSpsoOKiWGKt
	{
		public uint qtpWFJbaWhRcVfJtSZXsRiEETnue;

		public IntPtr ICNmkIKbltXawkIQWQMhndduDdVGA;

		public int AwsLtLTmfBCHRnSjulSzDUqpkzMq;

		public int ScJkKfvPJgggxifsBZuSopBhiPeHA;

		public IntPtr repSUaXCIRGddgYYCOnWzHUDWjFb;

		public IntPtr cUnyltqtCROfUppcrbKaJLxWaigGb;

		public IntPtr CepSiZwlFmcydWBwcWrHHwoJMEGs;

		public IntPtr gvXHHERiGghIhZGhDUbQCmieVcMu;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string aLgXXUJnCQBwBppqDrefADRyEhai;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string deGrPhnkkBYuzEtOXclvtkeYlzaK;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct sOtemhjkMSGMXYLEaHFBiKhBamKjA
	{
		public IntPtr KntXemOwQWZNnYcUUEsobQKjGYlCA;

		public IntPtr PehTAMGfddRErTJpTwRbGtOrkCeC;

		public IntPtr sHNVmetCMgbapZLSHfrSYvsSTdyG;

		public IntPtr MthstoQCjTaNGIYdtUdgMyPDRspHA;

		public int HwZTFODRAECIDDmJenertfmGAjRgA;

		public int eHxXxoMGebMvIOdVqwTHDEDoZluK;

		public int ZvjlHIBacndhvwMZvEBhrintJERm;

		public int isfvtkduvJOOAOzLrlDfiouWbIdbA;

		public int ivNvXWnJytizIrSMnBJlktveXYND;

		public IntPtr jDnWVKGyWHLfbXWINGwpAyUSJpIk;

		public IntPtr aLWMiwACwOJpFDHsMTKVXgIQgVMs;

		public uint hWddsABkNghJYlvodgJgirQCPizD;
	}

	private const int VLqmTsySuGBTrUYiehHFKcvZBOuZ = 20;

	private const int JMOUOYlkhtumnPulakKTqjEUTAqr = 1410;

	private readonly ushort eAKjiUXNYpGkTFgYcOkuZjGdrXWtA;

	private readonly string bxjhquKKTZKBALbFehuihRjCxMVFA;

	private bool VrTqFPTHmcClAexPUJqYSGMmTZWrA;

	private IntPtr uARPOUxQpeeHxsbyHtJSfLdAajIz;

	private int NLtotNQETTHZTGZUniOVxzxBAXzc;

	private uint XDGlbqclHxageCXNTdHQzbvbyyLcA;

	private gDVzoRURUCPEqvpPycUJGKXWyZzhA ELBrSTBhDxhHspEXXUUxZffZlDKH;

	private gDVzoRURUCPEqvpPycUJGKXWyZzhA XhHBICFHuBoIwVzgJBMPARdPQzaCb;

	public IntPtr WdZgYAipflPpdGqTAomKeDZnhZTaB => EAqkhgkPqusiHIKkIFbdvNfmiPKc();

	public uint cBapTIfVbFbagOcWvLvpxInQUfJh => jUyKqhQfCDvDNVIShHSWEclVoNLj();

	public bool wrZpjnzdaTxeGdIKAXypKWKhWsGl => ZKTKyGkgkSHWLEYmkvEFOyQaHLhb();

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort wnisKcpwmgSkXdmwACcQDnwFslVFA([In] ref XvzlvrqEfToCdzKqpSpsoOKiWGKt P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool YyLgCpluqYGDDbtVBXVcPECprNJgb([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr aiLsDJAMsFGEGhHJucbjaBzHXWVtB(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr gwxEGAKHSeZAGTKhhqqtYNHcLIZe(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool aWJEtrcKXDplYldLvTekoKgYRkNGA(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool pgSAVealtrzDEMvzNwXFxQyRGsvl(IntPtr P_0);

	public IntPtr EAqkhgkPqusiHIKkIFbdvNfmiPKc()
	{
		return uARPOUxQpeeHxsbyHtJSfLdAajIz;
	}

	public uint jUyKqhQfCDvDNVIShHSWEclVoNLj()
	{
		return XDGlbqclHxageCXNTdHQzbvbyyLcA;
	}

	public bool ZKTKyGkgkSHWLEYmkvEFOyQaHLhb()
	{
		if (!(uARPOUxQpeeHxsbyHtJSfLdAajIz != IntPtr.Zero))
		{
			return false;
		}
		return pgSAVealtrzDEMvzNwXFxQyRGsvl(uARPOUxQpeeHxsbyHtJSfLdAajIz);
	}

	public void Dispose()
	{
		EAXOBUighEHIvCSYpwHwlqWMdBZGb(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void nuDWTwcLydobCRLchcFbCtWVYAgl()
	{
		try
		{
			EAXOBUighEHIvCSYpwHwlqWMdBZGb(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void EAXOBUighEHIvCSYpwHwlqWMdBZGb(bool P_0)
	{
		if (!VrTqFPTHmcClAexPUJqYSGMmTZWrA)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(XDGlbqclHxageCXNTdHQzbvbyyLcA);
			}
			if (uARPOUxQpeeHxsbyHtJSfLdAajIz != IntPtr.Zero)
			{
				aWJEtrcKXDplYldLvTekoKgYRkNGA(uARPOUxQpeeHxsbyHtJSfLdAajIz);
				uARPOUxQpeeHxsbyHtJSfLdAajIz = IntPtr.Zero;
			}
			if (eAKjiUXNYpGkTFgYcOkuZjGdrXWtA != 0 && !string.IsNullOrEmpty(bxjhquKKTZKBALbFehuihRjCxMVFA))
			{
				YyLgCpluqYGDDbtVBXVcPECprNJgb(bxjhquKKTZKBALbFehuihRjCxMVFA, IntPtr.Zero);
			}
			VrTqFPTHmcClAexPUJqYSGMmTZWrA = true;
		}
	}

	public NHaXdADzcpEBVOTeihzYSIZTkQhR(string P_0, bool P_1, gDVzoRURUCPEqvpPycUJGKXWyZzhA P_2)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("className");
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		XDGlbqclHxageCXNTdHQzbvbyyLcA = ObjectInstanceTracker.Default.Register(this);
		bxjhquKKTZKBALbFehuihRjCxMVFA = P_0;
		ELBrSTBhDxhHspEXXUUxZffZlDKH = xJBfnSdEozKCEBIigpGTiiOBlESE;
		XhHBICFHuBoIwVzgJBMPARdPQzaCb = P_2;
		NLtotNQETTHZTGZUniOVxzxBAXzc = 0;
		XvzlvrqEfToCdzKqpSpsoOKiWGKt xvzlvrqEfToCdzKqpSpsoOKiWGKt = new XvzlvrqEfToCdzKqpSpsoOKiWGKt
		{
			ICNmkIKbltXawkIQWQMhndduDdVGA = Marshal.GetFunctionPointerForDelegate(ELBrSTBhDxhHspEXXUUxZffZlDKH)
		};
		while (eAKjiUXNYpGkTFgYcOkuZjGdrXWtA == 0 && NLtotNQETTHZTGZUniOVxzxBAXzc < 20)
		{
			xvzlvrqEfToCdzKqpSpsoOKiWGKt.deGrPhnkkBYuzEtOXclvtkeYlzaK = P_0;
			eAKjiUXNYpGkTFgYcOkuZjGdrXWtA = wnisKcpwmgSkXdmwACcQDnwFslVFA(ref xvzlvrqEfToCdzKqpSpsoOKiWGKt);
			if (eAKjiUXNYpGkTFgYcOkuZjGdrXWtA != 0)
			{
				break;
			}
			NLtotNQETTHZTGZUniOVxzxBAXzc++;
			P_0 = bxjhquKKTZKBALbFehuihRjCxMVFA + NLtotNQETTHZTGZUniOVxzxBAXzc;
		}
		if (eAKjiUXNYpGkTFgYcOkuZjGdrXWtA == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (bxjhquKKTZKBALbFehuihRjCxMVFA != P_0)
		{
			bxjhquKKTZKBALbFehuihRjCxMVFA = P_0;
		}
		if (P_1)
		{
			uARPOUxQpeeHxsbyHtJSfLdAajIz = cNbHDcSSsOrryibjsoUeAOgSIrMq(P_0, new IntPtr((int)XDGlbqclHxageCXNTdHQzbvbyyLcA));
		}
		else
		{
			uARPOUxQpeeHxsbyHtJSfLdAajIz = rHWcFezQKwGhxzwZzEpAglytetMdb(P_0, new IntPtr((int)XDGlbqclHxageCXNTdHQzbvbyyLcA));
		}
	}

	private IntPtr rHWcFezQKwGhxzwZzEpAglytetMdb(string P_0, IntPtr P_1)
	{
		return aiLsDJAMsFGEGhHJucbjaBzHXWVtB(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr cNbHDcSSsOrryibjsoUeAOgSIrMq(string P_0, IntPtr P_1)
	{
		return aiLsDJAMsFGEGhHJucbjaBzHXWVtB(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, WEJzDPEhNQNZrfcPrLAlSuuEoShk.IhQLOfFSOrZdzSbOtgRcHtarkRRnA, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(gDVzoRURUCPEqvpPycUJGKXWyZzhA))]
	private unsafe static IntPtr xJBfnSdEozKCEBIigpGTiiOBlESE(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			return gwxEGAKHSeZAGTKhhqqtYNHcLIZe(P_0, P_1, P_2, P_3);
		}
		bool flag = false;
		uint instanceId = 0u;
		if (P_1 == 1)
		{
			sOtemhjkMSGMXYLEaHFBiKhBamKjA* ptr = (sOtemhjkMSGMXYLEaHFBiKhBamKjA*)(void*)P_3;
			if (ptr->KntXemOwQWZNnYcUUEsobQKjGYlCA != IntPtr.Zero)
			{
				iZtZloELsoaMBDRDTiszzpwtPjDd.IQyiaepMIpAUzuUjfEtCBzAjRQbaA(P_0, -21, ptr->KntXemOwQWZNnYcUUEsobQKjGYlCA);
			}
		}
		else
		{
			instanceId = (uint)iZtZloELsoaMBDRDTiszzpwtPjDd.VHhhdrwvXdMYfGOaVZvPTAZOrdoi(P_0, -21).ToInt32();
			flag = true;
		}
		if (flag && ObjectInstanceTracker.Default.TryGetInstance<NHaXdADzcpEBVOTeihzYSIZTkQhR>(instanceId, out var instance))
		{
			instance.XhHBICFHuBoIwVzgJBMPARdPQzaCb(P_0, P_1, P_2, P_3);
		}
		return gwxEGAKHSeZAGTKhhqqtYNHcLIZe(P_0, P_1, P_2, P_3);
	}

	public void gfbYDRNkLnIJkSInZVYcWoUoxcmG(gDVzoRURUCPEqvpPycUJGKXWyZzhA P_0)
	{
		XhHBICFHuBoIwVzgJBMPARdPQzaCb = P_0;
	}
}
