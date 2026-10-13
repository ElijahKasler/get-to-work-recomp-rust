using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct pAUvFzSdLOnVbevHysnEIlbHhQvR
{
	[FieldOffset(0)]
	private uint kRUOSPmQukUYxRLsTNOvUtwfpdYc;

	[FieldOffset(0)]
	private ulong tCnASTjXHVkPSKVzGUHzjDgAqkID;

	[FieldOffset(0)]
	private IntPtr UfYheYyRhEnFuwiAsVaBDGvCvOoQ;

	private static readonly bool wHjWwYWuPqvjgapjwynEiDHoESef;

	public static readonly int VxparQtdwLOgaAoqOoAqfgzdUvQC;

	static pAUvFzSdLOnVbevHysnEIlbHhQvR()
	{
		VxparQtdwLOgaAoqOoAqfgzdUvQC = IntPtr.Size;
		wHjWwYWuPqvjgapjwynEiDHoESef = VxparQtdwLOgaAoqOoAqfgzdUvQC == 8;
	}

	public static pAUvFzSdLOnVbevHysnEIlbHhQvR cONfOlFBruRRezuAueAYdyiFnOCnA(byte[] P_0, int P_1)
	{
		pAUvFzSdLOnVbevHysnEIlbHhQvR result = default;
		if (wHjWwYWuPqvjgapjwynEiDHoESef)
		{
			result.tCnASTjXHVkPSKVzGUHzjDgAqkID = BitConverter.ToUInt64(P_0, P_1);
			result.UfYheYyRhEnFuwiAsVaBDGvCvOoQ = new IntPtr((long)result.tCnASTjXHVkPSKVzGUHzjDgAqkID);
		}
		else
		{
			result.kRUOSPmQukUYxRLsTNOvUtwfpdYc = BitConverter.ToUInt32(P_0, P_1);
			result.UfYheYyRhEnFuwiAsVaBDGvCvOoQ = new IntPtr((int)result.kRUOSPmQukUYxRLsTNOvUtwfpdYc);
		}
		return result;
	}

	[SpecialName]
	public static IntPtr ZvEPgFvcMARrqoNruBgBOVWNnEYW(pAUvFzSdLOnVbevHysnEIlbHhQvR P_0)
	{
		return P_0.UfYheYyRhEnFuwiAsVaBDGvCvOoQ;
	}

	[SpecialName]
	public static pAUvFzSdLOnVbevHysnEIlbHhQvR kFtnUfoVkfEDhtNemdyZxjJrIKVIA(IntPtr P_0)
	{
		pAUvFzSdLOnVbevHysnEIlbHhQvR result = new pAUvFzSdLOnVbevHysnEIlbHhQvR
		{
			UfYheYyRhEnFuwiAsVaBDGvCvOoQ = P_0
		};
		if (wHjWwYWuPqvjgapjwynEiDHoESef)
		{
			result.tCnASTjXHVkPSKVzGUHzjDgAqkID = (ulong)P_0.ToInt64();
		}
		else
		{
			result.kRUOSPmQukUYxRLsTNOvUtwfpdYc = (uint)P_0.ToInt32();
		}
		return result;
	}

	public string gZTGZvdpHZEOTjlsemxLctWtbLgAB()
	{
		if (wHjWwYWuPqvjgapjwynEiDHoESef)
		{
			return tCnASTjXHVkPSKVzGUHzjDgAqkID.ToString();
		}
		return kRUOSPmQukUYxRLsTNOvUtwfpdYc.ToString();
	}

	public int aRCxvwbJtKvVJDjbnFaDHxjQQCwd()
	{
		if (wHjWwYWuPqvjgapjwynEiDHoESef)
		{
			return (int)tCnASTjXHVkPSKVzGUHzjDgAqkID;
		}
		return (int)kRUOSPmQukUYxRLsTNOvUtwfpdYc;
	}
}
