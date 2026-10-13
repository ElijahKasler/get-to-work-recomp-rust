using System;
using System.Runtime.CompilerServices;

internal struct qoOWiZqPpnSBsOKdtaYQjUxNlfod
{
	private int AGCmOvYERqhHvPRWdJMMtBXcbaRr;

	private long TJCGJZTlkAYdbieUHuuUufIemtym;

	private static readonly bool gfGmvrrUGNoxrunPKuythaybFdZJA;

	public static readonly int RhetJcTiXwQioOWfaEQfXQHXfGCKA;

	static qoOWiZqPpnSBsOKdtaYQjUxNlfod()
	{
		gfGmvrrUGNoxrunPKuythaybFdZJA = IntPtr.Size == 8;
		RhetJcTiXwQioOWfaEQfXQHXfGCKA = (gfGmvrrUGNoxrunPKuythaybFdZJA ? 8 : 4);
	}

	public static qoOWiZqPpnSBsOKdtaYQjUxNlfod HMPmeUVsJuHknAqUyMBBrIapPmqt(byte[] P_0, int P_1)
	{
		qoOWiZqPpnSBsOKdtaYQjUxNlfod result = default;
		if (gfGmvrrUGNoxrunPKuythaybFdZJA)
		{
			result.TJCGJZTlkAYdbieUHuuUufIemtym = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.AGCmOvYERqhHvPRWdJMMtBXcbaRr = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int OMSpJLBqXdbpDBTdoNojgtCCfTXtb(qoOWiZqPpnSBsOKdtaYQjUxNlfod P_0)
	{
		if (gfGmvrrUGNoxrunPKuythaybFdZJA)
		{
			return (int)P_0.TJCGJZTlkAYdbieUHuuUufIemtym;
		}
		return P_0.AGCmOvYERqhHvPRWdJMMtBXcbaRr;
	}

	[SpecialName]
	public static long OMSpJLBqXdbpDBTdoNojgtCCfTXtb(qoOWiZqPpnSBsOKdtaYQjUxNlfod P_0)
	{
		if (gfGmvrrUGNoxrunPKuythaybFdZJA)
		{
			return P_0.TJCGJZTlkAYdbieUHuuUufIemtym;
		}
		return P_0.AGCmOvYERqhHvPRWdJMMtBXcbaRr;
	}

	public string NsjGCadojhRqoSYGbddLZlIOYxvk()
	{
		if (gfGmvrrUGNoxrunPKuythaybFdZJA)
		{
			return TJCGJZTlkAYdbieUHuuUufIemtym.ToString();
		}
		return AGCmOvYERqhHvPRWdJMMtBXcbaRr.ToString();
	}
}
