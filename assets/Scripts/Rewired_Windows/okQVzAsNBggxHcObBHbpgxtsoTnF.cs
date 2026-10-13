using System;
using System.Runtime.CompilerServices;

internal struct okQVzAsNBggxHcObBHbpgxtsoTnF
{
	private uint iWaGGtYXTeIaZtVMgUXTPmrxHgaA;

	private ulong UuPlIJjdMFDPGeVoGbfRNLgORWlx;

	private static readonly bool DqgCpidABHeupRElAXpDVEgPZBJfA;

	public static readonly int zQhhRUGBEDiNOOeekRgwsHHrSdXv;

	static okQVzAsNBggxHcObBHbpgxtsoTnF()
	{
		DqgCpidABHeupRElAXpDVEgPZBJfA = IntPtr.Size == 8;
		zQhhRUGBEDiNOOeekRgwsHHrSdXv = (DqgCpidABHeupRElAXpDVEgPZBJfA ? 8 : 4);
	}

	public static okQVzAsNBggxHcObBHbpgxtsoTnF ZxzcOxOgAYOffaGMajZavizmWRtt(byte[] P_0, int P_1)
	{
		okQVzAsNBggxHcObBHbpgxtsoTnF result = default;
		if (DqgCpidABHeupRElAXpDVEgPZBJfA)
		{
			result.UuPlIJjdMFDPGeVoGbfRNLgORWlx = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.iWaGGtYXTeIaZtVMgUXTPmrxHgaA = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint nraHtabZlqqbfgSRvFETKRhNDHHI(okQVzAsNBggxHcObBHbpgxtsoTnF P_0)
	{
		if (DqgCpidABHeupRElAXpDVEgPZBJfA)
		{
			return (uint)P_0.UuPlIJjdMFDPGeVoGbfRNLgORWlx;
		}
		return P_0.iWaGGtYXTeIaZtVMgUXTPmrxHgaA;
	}

	[SpecialName]
	public static ulong nraHtabZlqqbfgSRvFETKRhNDHHI(okQVzAsNBggxHcObBHbpgxtsoTnF P_0)
	{
		if (DqgCpidABHeupRElAXpDVEgPZBJfA)
		{
			return P_0.UuPlIJjdMFDPGeVoGbfRNLgORWlx;
		}
		return P_0.iWaGGtYXTeIaZtVMgUXTPmrxHgaA;
	}

	public string KQeSlAXaFRMjDfJlFAHJjHvzjtosA()
	{
		if (DqgCpidABHeupRElAXpDVEgPZBJfA)
		{
			return UuPlIJjdMFDPGeVoGbfRNLgORWlx.ToString();
		}
		return iWaGGtYXTeIaZtVMgUXTPmrxHgaA.ToString();
	}
}
