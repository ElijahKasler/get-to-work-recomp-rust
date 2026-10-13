using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct koCuNclHbmFkvdKYFTAxiYZNnDUl
{
	[FieldOffset(0)]
	private int gmELVMyVWBIBmobQAiYbdzcmEisR;

	[FieldOffset(0)]
	private long zzzfYiszRKCeaEJkwhqwrJmTyJjA;

	[FieldOffset(0)]
	private IntPtr GjsGOiTCxRIRbvwTbuYuHHUtKkqd;

	private static readonly bool NoyOtzBPbzjGBxeQKiQvHGEQlvHT;

	public static readonly int wCtKDKxaCCIEwjnuZTgmRthnYslqA;

	static koCuNclHbmFkvdKYFTAxiYZNnDUl()
	{
		wCtKDKxaCCIEwjnuZTgmRthnYslqA = IntPtr.Size;
		NoyOtzBPbzjGBxeQKiQvHGEQlvHT = wCtKDKxaCCIEwjnuZTgmRthnYslqA == 8;
	}

	public static koCuNclHbmFkvdKYFTAxiYZNnDUl DdkCLlMMLoZPVuGfhpWHKxSPSsge(byte[] P_0, int P_1)
	{
		koCuNclHbmFkvdKYFTAxiYZNnDUl result = default;
		if (NoyOtzBPbzjGBxeQKiQvHGEQlvHT)
		{
			result.zzzfYiszRKCeaEJkwhqwrJmTyJjA = BitConverter.ToInt64(P_0, P_1);
			result.GjsGOiTCxRIRbvwTbuYuHHUtKkqd = new IntPtr(result.zzzfYiszRKCeaEJkwhqwrJmTyJjA);
		}
		else
		{
			result.gmELVMyVWBIBmobQAiYbdzcmEisR = BitConverter.ToInt32(P_0, P_1);
			result.GjsGOiTCxRIRbvwTbuYuHHUtKkqd = new IntPtr(result.gmELVMyVWBIBmobQAiYbdzcmEisR);
		}
		return result;
	}

	[SpecialName]
	public static koCuNclHbmFkvdKYFTAxiYZNnDUl MiXgrCPvkdWTEeppHHIfIdlkaUSr(IntPtr P_0)
	{
		koCuNclHbmFkvdKYFTAxiYZNnDUl result = new koCuNclHbmFkvdKYFTAxiYZNnDUl
		{
			GjsGOiTCxRIRbvwTbuYuHHUtKkqd = P_0
		};
		if (NoyOtzBPbzjGBxeQKiQvHGEQlvHT)
		{
			result.zzzfYiszRKCeaEJkwhqwrJmTyJjA = P_0.ToInt64();
		}
		else
		{
			result.gmELVMyVWBIBmobQAiYbdzcmEisR = P_0.ToInt32();
		}
		return result;
	}

	[SpecialName]
	public static IntPtr WligOvACaqidkPgygAWPyXtfnpPUA(koCuNclHbmFkvdKYFTAxiYZNnDUl P_0)
	{
		return P_0.GjsGOiTCxRIRbvwTbuYuHHUtKkqd;
	}

	public string ipDAQcGiERXKvVYDunYLxfFAtTOV()
	{
		if (NoyOtzBPbzjGBxeQKiQvHGEQlvHT)
		{
			return zzzfYiszRKCeaEJkwhqwrJmTyJjA.ToString();
		}
		return gmELVMyVWBIBmobQAiYbdzcmEisR.ToString();
	}
}
