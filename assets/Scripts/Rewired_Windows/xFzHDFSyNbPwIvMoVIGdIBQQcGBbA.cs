using System;
using System.Runtime.InteropServices;

internal class xFzHDFSyNbPwIvMoVIGdIBQQcGBbA
{
	private int NRNSlsCncXDXOUdojcDbqRKcqOkK;

	private byte[] YqPNGWXghBElkhDZTnpEzzoYigsMA;

	public virtual int LIwNsYvttaKfxGJURorapRrKTdnq => JDRFJgfEmiRFDHfzBcOxhNzICAZiB();

	protected xFzHDFSyNbPwIvMoVIGdIBQQcGBbA()
	{
	}

	internal xFzHDFSyNbPwIvMoVIGdIBQQcGBbA(int P_0, IntPtr P_1)
	{
		SLfPdFqgFzZRbHlZYDEhqUxezrnd(P_0, P_1);
	}

	private unsafe void SLfPdFqgFzZRbHlZYDEhqUxezrnd(int P_0, IntPtr P_1)
	{
		NRNSlsCncXDXOUdojcDbqRKcqOkK = P_0;
		if (NRNSlsCncXDXOUdojcDbqRKcqOkK > 0 && P_1 != IntPtr.Zero)
		{
			YqPNGWXghBElkhDZTnpEzzoYigsMA = new byte[P_0];
			fixed (byte* yqPNGWXghBElkhDZTnpEzzoYigsMA = YqPNGWXghBElkhDZTnpEzzoYigsMA)
			{
				RhoSDdlPwZIYTHXfVerjMzvHNyu.dWlelPvDnffEDkNcpycixCsIwBxD((IntPtr)yqPNGWXghBElkhDZTnpEzzoYigsMA, P_1, NRNSlsCncXDXOUdojcDbqRKcqOkK);
			}
		}
	}

	protected virtual xFzHDFSyNbPwIvMoVIGdIBQQcGBbA SDitLGddAeiBpxpggdGJtsdlnwHN(int P_0, IntPtr P_1)
	{
		SLfPdFqgFzZRbHlZYDEhqUxezrnd(P_0, P_1);
		return this;
	}

	internal virtual void jBARszIfKvtKyrKExrJHDxygLHxn(IntPtr P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(P_0);
		}
	}

	internal unsafe virtual IntPtr GEIkuEIpyMfadVRGMUCplzIzhCMI()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (NRNSlsCncXDXOUdojcDbqRKcqOkK > 0 && YqPNGWXghBElkhDZTnpEzzoYigsMA != null)
		{
			intPtr = Marshal.AllocHGlobal(NRNSlsCncXDXOUdojcDbqRKcqOkK);
			fixed (byte* yqPNGWXghBElkhDZTnpEzzoYigsMA = YqPNGWXghBElkhDZTnpEzzoYigsMA)
			{
				RhoSDdlPwZIYTHXfVerjMzvHNyu.dWlelPvDnffEDkNcpycixCsIwBxD(intPtr, (IntPtr)yqPNGWXghBElkhDZTnpEzzoYigsMA, NRNSlsCncXDXOUdojcDbqRKcqOkK);
			}
		}
		return intPtr;
	}

	public unsafe _0001 YQLuuIneeLXeZLxLnDtTByQSosTQ<_0001>() where _0001 : xFzHDFSyNbPwIvMoVIGdIBQQcGBbA, new()
	{
		if (GetType() == typeof(_0001))
		{
			return (_0001)this;
		}
		if (GetType() == typeof(xFzHDFSyNbPwIvMoVIGdIBQQcGBbA))
		{
			fixed (byte* yqPNGWXghBElkhDZTnpEzzoYigsMA = YqPNGWXghBElkhDZTnpEzzoYigsMA)
			{
				void* ptr = yqPNGWXghBElkhDZTnpEzzoYigsMA;
				return (_0001)new _0001().SDitLGddAeiBpxpggdGJtsdlnwHN(NRNSlsCncXDXOUdojcDbqRKcqOkK, (IntPtr)ptr);
			}
		}
		return null;
	}

	public virtual int JDRFJgfEmiRFDHfzBcOxhNzICAZiB()
	{
		return NRNSlsCncXDXOUdojcDbqRKcqOkK;
	}
}
