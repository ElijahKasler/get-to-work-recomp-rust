using System;
using System.Runtime.CompilerServices;

internal struct hFWCDoGYGMCcvIwgvZkWYkjVkwfC
{
	private uint ubkFnbLWSrqczSgAwtivTLySdSJX;

	private ulong PdcMbguYmCIFHJAdbJZzFPUTqFei;

	private static readonly bool NniZulgPwApZmdqxJffDkkDeUvmi;

	public static readonly int nXgiVWnAYPeguEFPGkafmfbHZjMz;

	static hFWCDoGYGMCcvIwgvZkWYkjVkwfC()
	{
		NniZulgPwApZmdqxJffDkkDeUvmi = IntPtr.Size == 8;
		nXgiVWnAYPeguEFPGkafmfbHZjMz = (NniZulgPwApZmdqxJffDkkDeUvmi ? 8 : 4);
	}

	public static hFWCDoGYGMCcvIwgvZkWYkjVkwfC qujGtdbNOYklUChXonbCIizGPSEP(byte[] P_0, int P_1)
	{
		hFWCDoGYGMCcvIwgvZkWYkjVkwfC result = default;
		if (NniZulgPwApZmdqxJffDkkDeUvmi)
		{
			result.PdcMbguYmCIFHJAdbJZzFPUTqFei = BitConverter.ToUInt64(P_0, P_1);
		}
		else
		{
			result.ubkFnbLWSrqczSgAwtivTLySdSJX = BitConverter.ToUInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static uint UxvsOgAFIDxxKsXJEClKJloEHUNGA(hFWCDoGYGMCcvIwgvZkWYkjVkwfC P_0)
	{
		if (NniZulgPwApZmdqxJffDkkDeUvmi)
		{
			return (uint)P_0.PdcMbguYmCIFHJAdbJZzFPUTqFei;
		}
		return P_0.ubkFnbLWSrqczSgAwtivTLySdSJX;
	}

	[SpecialName]
	public static ulong UxvsOgAFIDxxKsXJEClKJloEHUNGA(hFWCDoGYGMCcvIwgvZkWYkjVkwfC P_0)
	{
		if (NniZulgPwApZmdqxJffDkkDeUvmi)
		{
			return P_0.PdcMbguYmCIFHJAdbJZzFPUTqFei;
		}
		return P_0.ubkFnbLWSrqczSgAwtivTLySdSJX;
	}

	public string GAWComcNRtbOLdqfgYRVHMDjMPAT()
	{
		if (NniZulgPwApZmdqxJffDkkDeUvmi)
		{
			return PdcMbguYmCIFHJAdbJZzFPUTqFei.ToString();
		}
		return ubkFnbLWSrqczSgAwtivTLySdSJX.ToString();
	}
}
