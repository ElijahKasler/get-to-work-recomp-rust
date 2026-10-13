using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class vTYhnXwiNkTvneUJSffQLPiizuoL : IDisposable
{
	private readonly byte[] PRqEGPpjIOmhkTvNdYjmiHgYmSCC;

	public readonly int ZGqrqMMVDzsKpGenPmfmYgVgrBDV;

	private GCHandle FOSUZknwPTFfLzZKPTdTvOwwwYPS;

	private bool USMCLmivRpfTWQFCFxeXoyfAbrTGA;

	public bool MgvDBwepisHZrDhcnmyGRPDrcQjF => PiuepnssscbklKFGhIGwdsQKnJFX();

	// C# has no syntax for parameterized property 'PwpUmiMFYTnDtkjPFaJKhmeegcyq'.
	public byte get_PwpUmiMFYTnDtkjPFaJKhmeegcyq(int P_0)
	{
		return wUJabqVudrAEKZIkMYzvfRHgcZid(P_0);
	}

	public void set_PwpUmiMFYTnDtkjPFaJKhmeegcyq(int P_0, byte P_1)
	{
		FaHYeVBklFigrAjLYncunrwrAzHT(num, b);
	}

	public bool PiuepnssscbklKFGhIGwdsQKnJFX()
	{
		return FOSUZknwPTFfLzZKPTdTvOwwwYPS.IsAllocated;
	}

	public byte wUJabqVudrAEKZIkMYzvfRHgcZid(int P_0)
	{
		return PRqEGPpjIOmhkTvNdYjmiHgYmSCC[P_0];
	}

	public void FaHYeVBklFigrAjLYncunrwrAzHT(int P_0, byte P_1)
	{
		PRqEGPpjIOmhkTvNdYjmiHgYmSCC[P_0] = P_1;
	}

	public vTYhnXwiNkTvneUJSffQLPiizuoL(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size must be > 0");
		}
		ZGqrqMMVDzsKpGenPmfmYgVgrBDV = P_0;
		PRqEGPpjIOmhkTvNdYjmiHgYmSCC = new byte[P_0];
	}

	public IntPtr FIACEjBoZIuEliEkORiTUFuPljeCb()
	{
		if (FOSUZknwPTFfLzZKPTdTvOwwwYPS.IsAllocated)
		{
			return FOSUZknwPTFfLzZKPTdTvOwwwYPS.AddrOfPinnedObject();
		}
		FOSUZknwPTFfLzZKPTdTvOwwwYPS = GCHandle.Alloc(PRqEGPpjIOmhkTvNdYjmiHgYmSCC, GCHandleType.Pinned);
		return FOSUZknwPTFfLzZKPTdTvOwwwYPS.AddrOfPinnedObject();
	}

	public void jxYNfGzSGbDVYKnxpyJKByQGbvD()
	{
		if (FOSUZknwPTFfLzZKPTdTvOwwwYPS.IsAllocated)
		{
			FOSUZknwPTFfLzZKPTdTvOwwwYPS.Free();
		}
	}

	public string OxQfRUsnKpgYpyCzdWBFTmNRnMas()
	{
		string text = "";
		for (int i = 0; i < ZGqrqMMVDzsKpGenPmfmYgVgrBDV; i++)
		{
			text = text + PRqEGPpjIOmhkTvNdYjmiHgYmSCC[i].ToString("x2") + " ";
		}
		return text;
	}

	public bool YxZbakfpWQeQflBbQQcRCcOyqIASA(int P_0, byte P_1)
	{
		if (1 + P_0 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (PRqEGPpjIOmhkTvNdYjmiHgYmSCC[P_0] & (1 << (int)P_1)) != 0;
	}

	public byte XebrOCbtTebUtdirRFXmpFhKidLzA(int P_0)
	{
		if (1 + P_0 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return PRqEGPpjIOmhkTvNdYjmiHgYmSCC[P_0];
	}

	public unsafe short PNxAvPDBcssyocnVffVMkbVYTRLJ(int P_0)
	{
		if (2 + P_0 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* pRqEGPpjIOmhkTvNdYjmiHgYmSCC = PRqEGPpjIOmhkTvNdYjmiHgYmSCC)
		{
			return *(short*)(pRqEGPpjIOmhkTvNdYjmiHgYmSCC + P_0);
		}
	}

	public unsafe ushort epUhKnTMBZLiKhmiLaqzfNoMkNWO(int P_0)
	{
		if (2 + P_0 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* pRqEGPpjIOmhkTvNdYjmiHgYmSCC = PRqEGPpjIOmhkTvNdYjmiHgYmSCC)
		{
			return *(ushort*)(pRqEGPpjIOmhkTvNdYjmiHgYmSCC + P_0);
		}
	}

	public unsafe int TptMWgjCvDDtTjzzRiUGcSfvqSP(int P_0)
	{
		if (4 + P_0 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* pRqEGPpjIOmhkTvNdYjmiHgYmSCC = PRqEGPpjIOmhkTvNdYjmiHgYmSCC)
		{
			return *(int*)(pRqEGPpjIOmhkTvNdYjmiHgYmSCC + P_0);
		}
	}

	public unsafe uint FCQUsVxxBAwcUvCGPJPcHiCrbPLw(int P_0)
	{
		if (4 + P_0 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* pRqEGPpjIOmhkTvNdYjmiHgYmSCC = PRqEGPpjIOmhkTvNdYjmiHgYmSCC)
		{
			return *(uint*)(pRqEGPpjIOmhkTvNdYjmiHgYmSCC + P_0);
		}
	}

	public unsafe long LOPQfdyLUBCTzZyWvIShuogmFvmq(int P_0)
	{
		if (8 + P_0 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* pRqEGPpjIOmhkTvNdYjmiHgYmSCC = PRqEGPpjIOmhkTvNdYjmiHgYmSCC)
		{
			return *(long*)(pRqEGPpjIOmhkTvNdYjmiHgYmSCC + P_0);
		}
	}

	public unsafe ulong IucobsuXNDQeGWMdJmhoTSYElgkJ(int P_0)
	{
		if (8 + P_0 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* pRqEGPpjIOmhkTvNdYjmiHgYmSCC = PRqEGPpjIOmhkTvNdYjmiHgYmSCC)
		{
			return *(ulong*)(pRqEGPpjIOmhkTvNdYjmiHgYmSCC + P_0);
		}
	}

	public void FahHMXzgyQDUbRyGIfGlJBLVCEef(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
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
		if (P_2 >= ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
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
		if (P_1 + P_2 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		Array.Copy(PRqEGPpjIOmhkTvNdYjmiHgYmSCC, P_2, P_0, P_3, P_1);
	}

	public void ioBbPkdQYYEVMgGUtmNEVmJaAPwW(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
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
		if (P_2 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
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
		if (P_3 >= ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
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
		if (P_2 + P_3 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(PRqEGPpjIOmhkTvNdYjmiHgYmSCC, P_0, P_3, P_4, P_2);
	}

	public int eVABrOJggumzYBzPViueMfCmShQxA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
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
		if (P_2 + P_1 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
		{
			P_1 = ZGqrqMMVDzsKpGenPmfmYgVgrBDV - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		Array.Copy(PRqEGPpjIOmhkTvNdYjmiHgYmSCC, P_2, P_0, P_3, P_1);
		return P_1;
	}

	public int DTFYMKKOlJDKIQtDuAZqBRZLisusA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
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
		if (P_3 + P_2 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
		{
			P_2 = ZGqrqMMVDzsKpGenPmfmYgVgrBDV - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		NativeTools.CopyMemory(PRqEGPpjIOmhkTvNdYjmiHgYmSCC, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public void cbAshWGWkgNuNsChhCeyRnPbIJtGA(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			PRqEGPpjIOmhkTvNdYjmiHgYmSCC[P_0] |= (byte)(1 << (int)P_1);
		}
		else
		{
			PRqEGPpjIOmhkTvNdYjmiHgYmSCC[P_0] &= (byte)(~(1 << (int)P_1));
		}
	}

	public void EMXJretukBiQvGKQhBCQJXBLKPSU(byte P_0, int P_1)
	{
		if (1 + P_1 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		PRqEGPpjIOmhkTvNdYjmiHgYmSCC[P_1] = P_0;
	}

	public unsafe void VDVJWOrkNBRwiDSNArDyUqkncMJGA(short P_0, int P_1)
	{
		if (2 + P_1 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* pRqEGPpjIOmhkTvNdYjmiHgYmSCC = PRqEGPpjIOmhkTvNdYjmiHgYmSCC)
		{
			*(short*)(pRqEGPpjIOmhkTvNdYjmiHgYmSCC + P_1) = P_0;
		}
	}

	public unsafe void LKFyuANCcLhmUGPRKIRActACCFkvb(ushort P_0, int P_1)
	{
		if (2 + P_1 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* pRqEGPpjIOmhkTvNdYjmiHgYmSCC = PRqEGPpjIOmhkTvNdYjmiHgYmSCC)
		{
			*(ushort*)(pRqEGPpjIOmhkTvNdYjmiHgYmSCC + P_1) = P_0;
		}
	}

	public unsafe void zNFmJinFBMLGPjBRTBxrqHyRBByHA(int P_0, int P_1)
	{
		if (4 + P_1 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* pRqEGPpjIOmhkTvNdYjmiHgYmSCC = PRqEGPpjIOmhkTvNdYjmiHgYmSCC)
		{
			*(int*)(pRqEGPpjIOmhkTvNdYjmiHgYmSCC + P_1) = P_0;
		}
	}

	public unsafe void gJqCpoJBYwqnHODlsISOKCGEhrLhA(uint P_0, int P_1)
	{
		if (4 + P_1 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* pRqEGPpjIOmhkTvNdYjmiHgYmSCC = PRqEGPpjIOmhkTvNdYjmiHgYmSCC)
		{
			*(uint*)(pRqEGPpjIOmhkTvNdYjmiHgYmSCC + P_1) = P_0;
		}
	}

	public unsafe void MZcOZBDgvfaWTpTYsCtqFuZrOtHp(long P_0, int P_1)
	{
		if (8 + P_1 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* pRqEGPpjIOmhkTvNdYjmiHgYmSCC = PRqEGPpjIOmhkTvNdYjmiHgYmSCC)
		{
			*(long*)(pRqEGPpjIOmhkTvNdYjmiHgYmSCC + P_1) = P_0;
		}
	}

	public unsafe void veIYajTvWWrNsjiHMOIgMxiFQlXN(ulong P_0, int P_1)
	{
		if (8 + P_1 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		fixed (byte* pRqEGPpjIOmhkTvNdYjmiHgYmSCC = PRqEGPpjIOmhkTvNdYjmiHgYmSCC)
		{
			*(ulong*)(pRqEGPpjIOmhkTvNdYjmiHgYmSCC + P_1) = P_0;
		}
	}

	public void yBUNyQDXqsnGLdvkOVWrRWzwABqr(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
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
		if (P_2 >= ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
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
		if (P_1 + P_2 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		Array.Copy(P_0, P_3, PRqEGPpjIOmhkTvNdYjmiHgYmSCC, P_2, P_1);
	}

	public void iwnMvFIljxSZIjcIBGhxjkhcLdxD(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
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
		if (P_2 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
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
		if (P_3 >= ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
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
		if (P_2 + P_3 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, PRqEGPpjIOmhkTvNdYjmiHgYmSCC, P_4, P_3, P_2);
	}

	public int YRBKmnCjaPGAhSKcufzqaklPlxkWA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
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
		if (P_1 + P_2 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
		{
			P_1 = ZGqrqMMVDzsKpGenPmfmYgVgrBDV - P_2;
		}
		Array.Copy(P_0, P_3, PRqEGPpjIOmhkTvNdYjmiHgYmSCC, P_2, P_1);
		return P_1;
	}

	public int exqnWhqDbusMFWsQiwIepnFZFLuL(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
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
		if (P_2 + P_3 > ZGqrqMMVDzsKpGenPmfmYgVgrBDV)
		{
			P_2 = ZGqrqMMVDzsKpGenPmfmYgVgrBDV - P_3;
		}
		NativeTools.CopyMemory(P_0, PRqEGPpjIOmhkTvNdYjmiHgYmSCC, P_4, P_3, P_2);
		return P_2;
	}

	public void fZnnBhtFiOauomBPrPWuPApJMbnQ()
	{
		Array.Clear(PRqEGPpjIOmhkTvNdYjmiHgYmSCC, 0, ZGqrqMMVDzsKpGenPmfmYgVgrBDV);
	}

	public virtual string SNyqZqxjVmrhrBFyNHsCKbNEoEbN()
	{
		string text = "";
		for (int i = 0; i < ZGqrqMMVDzsKpGenPmfmYgVgrBDV; i++)
		{
			text = text + wUJabqVudrAEKZIkMYzvfRHgcZid(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		plswyfoywflbRfKmcgZXhynXxrqx(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void LfShGkcdQVxqNRIjqIFVLasnmTPuA()
	{
		try
		{
			plswyfoywflbRfKmcgZXhynXxrqx(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void plswyfoywflbRfKmcgZXhynXxrqx(bool P_0)
	{
		if (!USMCLmivRpfTWQFCFxeXoyfAbrTGA)
		{
			if (FOSUZknwPTFfLzZKPTdTvOwwwYPS.IsAllocated)
			{
				FOSUZknwPTFfLzZKPTdTvOwwwYPS.Free();
			}
			USMCLmivRpfTWQFCFxeXoyfAbrTGA = true;
		}
	}

	public static void BfXzhFGJjGLpVUGFmijTEodnsTIl(vTYhnXwiNkTvneUJSffQLPiizuoL P_0, vTYhnXwiNkTvneUJSffQLPiizuoL P_1, int P_2)
	{
		Array.Copy(P_0.PRqEGPpjIOmhkTvNdYjmiHgYmSCC, P_1.PRqEGPpjIOmhkTvNdYjmiHgYmSCC, P_2);
	}

	public static void trxEpWXWvgJdXKOinrQIPCkgXMct(vTYhnXwiNkTvneUJSffQLPiizuoL P_0, int P_1, vTYhnXwiNkTvneUJSffQLPiizuoL P_2, int P_3, int P_4)
	{
		Array.Copy(P_0.PRqEGPpjIOmhkTvNdYjmiHgYmSCC, P_1, P_2.PRqEGPpjIOmhkTvNdYjmiHgYmSCC, P_3, P_4);
	}
}
