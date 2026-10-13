using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal struct MpPkpgyafyHBSObUgIkdXfsjYFIA : IDisposable
{
	private unsafe byte* hZdBqOgPvMURdukZunjgOxlIeAKo = null;

	private int xiWTVWLIjMhkVJbWWSENLaqpRAMp = 0;

	private bool wPAGuwfPXfbsBBplgxaDaDzhFvtTB = false;

	public unsafe byte* MkaWdvOvlpMNssQgfAMBFqzJdxWj => IViupSVsHEqChIedKghjKagofkTJA();

	public IntPtr XMSWYDbORCjNposxULcniaUInbFH => xdOaqtbkOuyElIpuSmghrkKoSflIA();

	public int zHIKlqLNdpLyKEAFhHXGlifwtxAJ => AQjAcYJfgdRcJBijisMrIHIhVACVA();

	// C# has no syntax for parameterized property 'IDMOSGFjzKeRHffNItQudedUpbTH'.
	public byte get_IDMOSGFjzKeRHffNItQudedUpbTH(int P_0)
	{
		return wxHCxOsZTfQtoBHasqhCzKbFgzRs(P_0);
	}

	public void set_IDMOSGFjzKeRHffNItQudedUpbTH(int P_0, byte P_1)
	{
		SEPBDOVMlQGItFYxNETuCIsZqIOdb(num, b);
	}

	public unsafe byte* IViupSVsHEqChIedKghjKagofkTJA()
	{
		return hZdBqOgPvMURdukZunjgOxlIeAKo;
	}

	public unsafe IntPtr xdOaqtbkOuyElIpuSmghrkKoSflIA()
	{
		return (IntPtr)hZdBqOgPvMURdukZunjgOxlIeAKo;
	}

	public int AQjAcYJfgdRcJBijisMrIHIhVACVA()
	{
		return xiWTVWLIjMhkVJbWWSENLaqpRAMp;
	}

	public unsafe byte wxHCxOsZTfQtoBHasqhCzKbFgzRs(int P_0)
	{
		if (P_0 < 0 || P_0 >= xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new IndexOutOfRangeException();
		}
		return hZdBqOgPvMURdukZunjgOxlIeAKo[P_0];
	}

	public unsafe void SEPBDOVMlQGItFYxNETuCIsZqIOdb(int P_0, byte P_1)
	{
		if (P_0 < 0 || P_0 >= xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new IndexOutOfRangeException();
		}
		hZdBqOgPvMURdukZunjgOxlIeAKo[P_0] = P_1;
	}

	public unsafe MpPkpgyafyHBSObUgIkdXfsjYFIA(int P_0)
	{
		qLGjiivpfqKrYARtDTyEjwzthGcD(P_0);
	}

	public unsafe IntPtr qINCGkGLEzCXLviSRRmTlKReBwstA(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)hZdBqOgPvMURdukZunjgOxlIeAKo;
		}
		if (P_0 < 0 || P_0 >= xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_0);
	}

	public unsafe string xbUJlkiaIdSgSQgqvtjugyyXqNYI()
	{
		string text = "";
		for (int i = 0; i < xiWTVWLIjMhkVJbWWSENLaqpRAMp; i++)
		{
			text = text + hZdBqOgPvMURdukZunjgOxlIeAKo[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool cRARLubBqiRqukiDZqZycHwxNFcg(int P_0, byte P_1)
	{
		if (1 + P_0 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (hZdBqOgPvMURdukZunjgOxlIeAKo[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte MCgxKaBupobiXBIigHPDclsUZtqhA(int P_0)
	{
		if (1 + P_0 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return hZdBqOgPvMURdukZunjgOxlIeAKo[P_0];
	}

	public unsafe short hHmiJQojzAdLhKVfVWWJyiGPNhuU(int P_0)
	{
		if (2 + P_0 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_0);
	}

	public unsafe ushort IObWFvakkrPRNNJbkyXJaaGidzfk(int P_0)
	{
		if (2 + P_0 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_0);
	}

	public unsafe int pQaIvhyPySbFzFHhaiCDVvLeMknh(int P_0)
	{
		if (4 + P_0 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_0);
	}

	public unsafe uint CvCjiFactsBqPTqArFXIAwTGJCksA(int P_0)
	{
		if (4 + P_0 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_0);
	}

	public unsafe long AbgZwTqViLZJSOAkTiwXjUSsyfZE(int P_0)
	{
		if (8 + P_0 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_0);
	}

	public unsafe ulong zFisQhFhteAjVHVsJylBMEBmmZAFA(int P_0)
	{
		if (8 + P_0 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_0);
	}

	public unsafe void iEXEXXALMccJgotgyIrBhGlpkDADb(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int num = P_0.Length;
		if (num <= 0)
		{
			throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
		}
		if (P_1 > num)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
		}
		if (P_1 > xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
		}
		if (P_3 >= num)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_2 >= xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
		}
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_3 + P_1 > num)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
		}
		if (P_1 + P_2 > xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)hZdBqOgPvMURdukZunjgOxlIeAKo, P_0, P_2, P_3, P_1);
	}

	public unsafe void DsIxgTKVyNbHCfuCmdPnOkKPwKgm(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
		}
		if (P_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be > 0");
		}
		if (P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= bufferLength.");
		}
		if (P_2 > xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead must be <= Length.");
		}
		if (P_4 >= P_1)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < bufferLength.");
		}
		if (P_4 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_3 >= xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < Length.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_4 + P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex + numBytesToRead must be < bufferLength.");
		}
		if (P_2 + P_3 > xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(hZdBqOgPvMURdukZunjgOxlIeAKo, P_0, P_3, P_4, P_2);
	}

	public unsafe void fXkGtYBQzSACiCVMHxwoPePKQDKjA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		DsIxgTKVyNbHCfuCmdPnOkKPwKgm((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int JBFlAnuPnlUVyXAIickmOrnnqrIu(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0)
		{
			return 0;
		}
		if (P_2 >= xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			return 0;
		}
		if (P_3 >= num)
		{
			return 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_2 + P_1 > xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			P_1 = xiWTVWLIjMhkVJbWWSENLaqpRAMp - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)hZdBqOgPvMURdukZunjgOxlIeAKo, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int zXqUDSFYJIyKlxHYbtrAiEgkuqPg(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			return 0;
		}
		if (P_4 >= P_1)
		{
			return 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 < 0)
		{
			P_4 = 0;
		}
		if (P_3 + P_2 > xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			P_2 = xiWTVWLIjMhkVJbWWSENLaqpRAMp - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(hZdBqOgPvMURdukZunjgOxlIeAKo, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int qxggzTDYZsFNBAChsxWkBbuGZtJH(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return zXqUDSFYJIyKlxHYbtrAiEgkuqPg((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void zwrPPWbkxlvkcDdflkUxRBSIWbzc(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = hZdBqOgPvMURdukZunjgOxlIeAKo + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = hZdBqOgPvMURdukZunjgOxlIeAKo + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void AmTZXGfaJqpMxpNwxsuMkznLQbyR(byte P_0, int P_1)
	{
		if (1 + P_1 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		hZdBqOgPvMURdukZunjgOxlIeAKo[P_1] = P_0;
	}

	public unsafe void IvcctvCVqTbCNEBEwEdLqnSkhJpgb(short P_0, int P_1)
	{
		if (2 + P_1 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_1) = P_0;
	}

	public unsafe void DmzPCeYnViieQFteyoBAEgGtgpbHA(ushort P_0, int P_1)
	{
		if (2 + P_1 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_1) = P_0;
	}

	public unsafe void dNEgBLOxqwpHetyIcwyKSivEzWfH(int P_0, int P_1)
	{
		if (4 + P_1 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_1) = P_0;
	}

	public unsafe void XXdpUOClNlVaylRQswQzekRFgvbH(uint P_0, int P_1)
	{
		if (4 + P_1 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_1) = P_0;
	}

	public unsafe void EEDLVLXSbWnoqTdkYdjFaRXibqtf(long P_0, int P_1)
	{
		if (8 + P_1 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_1) = P_0;
	}

	public unsafe void PUiNrIdXPKUaexSvVTOxYXhPfIAh(ulong P_0, int P_1)
	{
		if (8 + P_1 > xiWTVWLIjMhkVJbWWSENLaqpRAMp || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(hZdBqOgPvMURdukZunjgOxlIeAKo + P_1) = P_0;
	}

	public unsafe void AVfRwslZgLQwVMWJUgxNrcXClhGT(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int num = P_0.Length;
		if (num <= 0)
		{
			throw new ArgumentOutOfRangeException("bytes.Length must be > 0.");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
		}
		if (P_1 > num)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
		}
		if (P_1 > xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
		}
		if (P_3 >= num)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_2 >= xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
		}
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_3 + P_1 > num)
		{
			throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
		}
		if (P_1 + P_2 > xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)hZdBqOgPvMURdukZunjgOxlIeAKo, P_3, P_2, P_1);
	}

	public unsafe void DEDpUESrwJGKtHQEMOhZcGKAbkykB(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("bufferLength must be > 0.");
		}
		if (P_2 <= 0)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be > 0");
		}
		if (P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= bufferLength.");
		}
		if (P_2 > xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite must be <= Length.");
		}
		if (P_4 >= P_1)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be < bufferLength.");
		}
		if (P_4 < 0)
		{
			throw new ArgumentOutOfRangeException("readStartIndex must be >= 0.");
		}
		if (P_3 >= xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be < Length.");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("writeStartIndex must be >= 0.");
		}
		if (P_4 + P_2 > P_1)
		{
			throw new ArgumentOutOfRangeException("readStartIndex + numBytesToWrite must be < bufferLength.");
		}
		if (P_2 + P_3 > xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(P_0, hZdBqOgPvMURdukZunjgOxlIeAKo, P_4, P_3, P_2);
	}

	public unsafe void leccWmgEFKzHuQDNrNyUNDDIDzdu(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		DEDpUESrwJGKtHQEMOhZcGKAbkykB((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int NfKAFecSIdJMpAqaxLHCIrVKSvPH(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			return 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 + P_2 > xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			P_1 = xiWTVWLIjMhkVJbWWSENLaqpRAMp - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)hZdBqOgPvMURdukZunjgOxlIeAKo, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int APEYMGZkAVdNXyImuZNxXyzptYEi(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			return 0;
		}
		if (P_4 < 0)
		{
			P_4 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		if (P_2 + P_3 > xiWTVWLIjMhkVJbWWSENLaqpRAMp)
		{
			P_2 = xiWTVWLIjMhkVJbWWSENLaqpRAMp - P_3;
		}
		nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(P_0, hZdBqOgPvMURdukZunjgOxlIeAKo, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int OCUxNvzqhVdtdHmDFVIrStJzZsiuA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return APEYMGZkAVdNXyImuZNxXyzptYEi((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool qLGjiivpfqKrYARtDTyEjwzthGcD(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (xiWTVWLIjMhkVJbWWSENLaqpRAMp == P_0)
		{
			return true;
		}
		VNqwvdJXZtCECtCjNfCJDmyPpfEcA();
		if (P_0 == 0)
		{
			return true;
		}
		xiWTVWLIjMhkVJbWWSENLaqpRAMp = P_0;
		hZdBqOgPvMURdukZunjgOxlIeAKo = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		rzHzwUKJNeSnuJUEbMzBggEriBigA();
		return true;
	}

	public unsafe void rzHzwUKJNeSnuJUEbMzBggEriBigA()
	{
		if (xiWTVWLIjMhkVJbWWSENLaqpRAMp != 0)
		{
			nszCkLYuchMjpmuavlajKXkkRecO.KhJYDYMLwtrMmSUfniSvlDNTVNwe(hZdBqOgPvMURdukZunjgOxlIeAKo, xiWTVWLIjMhkVJbWWSENLaqpRAMp);
		}
	}

	public unsafe void VNqwvdJXZtCECtCjNfCJDmyPpfEcA()
	{
		if (xiWTVWLIjMhkVJbWWSENLaqpRAMp == 0)
		{
			return;
		}
		try
		{
			if (hZdBqOgPvMURdukZunjgOxlIeAKo != null)
			{
				Marshal.FreeHGlobal(xdOaqtbkOuyElIpuSmghrkKoSflIA());
			}
		}
		catch
		{
		}
		hZdBqOgPvMURdukZunjgOxlIeAKo = null;
		xiWTVWLIjMhkVJbWWSENLaqpRAMp = 0;
	}

	public string rqdBfxNLFjiZJuWfeZMFveiMeCdC()
	{
		string text = "";
		for (int i = 0; i < xiWTVWLIjMhkVJbWWSENLaqpRAMp; i++)
		{
			text = text + MCgxKaBupobiXBIigHPDclsUZtqhA(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		sqszAwDujaQZkjhNmCwEkSPzMvuI(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void sqszAwDujaQZkjhNmCwEkSPzMvuI(bool P_0)
	{
		if (!wPAGuwfPXfbsBBplgxaDaDzhFvtTB)
		{
			VNqwvdJXZtCECtCjNfCJDmyPpfEcA();
			wPAGuwfPXfbsBBplgxaDaDzhFvtTB = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr mXrfcwJyAEptoeUyiKASfXotiSDC(MpPkpgyafyHBSObUgIkdXfsjYFIA P_0)
	{
		return (IntPtr)P_0.hZdBqOgPvMURdukZunjgOxlIeAKo;
	}

	[SpecialName]
	public unsafe static void* mXrfcwJyAEptoeUyiKASfXotiSDC(MpPkpgyafyHBSObUgIkdXfsjYFIA P_0)
	{
		return P_0.hZdBqOgPvMURdukZunjgOxlIeAKo;
	}

	public unsafe static bool LqhFVDGKvuWiRcVZtZYdQdbgnqGNA(MpPkpgyafyHBSObUgIkdXfsjYFIA P_0, MpPkpgyafyHBSObUgIkdXfsjYFIA P_1)
	{
		if (P_0.xiWTVWLIjMhkVJbWWSENLaqpRAMp == 0)
		{
			P_1.VNqwvdJXZtCECtCjNfCJDmyPpfEcA();
			return true;
		}
		if (P_1.qLGjiivpfqKrYARtDTyEjwzthGcD(P_0.xiWTVWLIjMhkVJbWWSENLaqpRAMp))
		{
			P_1.DEDpUESrwJGKtHQEMOhZcGKAbkykB(P_0.hZdBqOgPvMURdukZunjgOxlIeAKo, P_0.xiWTVWLIjMhkVJbWWSENLaqpRAMp, P_0.xiWTVWLIjMhkVJbWWSENLaqpRAMp);
			return true;
		}
		return false;
	}
}
