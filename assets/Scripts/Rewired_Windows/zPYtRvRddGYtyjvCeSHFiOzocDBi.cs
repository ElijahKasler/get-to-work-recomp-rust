using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class zPYtRvRddGYtyjvCeSHFiOzocDBi : IDisposable
{
	private unsafe byte* nHXRJBdJSxaYPVwQKpGfZpqycqbj;

	private int yEhCLJenZTaqpEMvVWqbyOQpERBdA;

	private bool YZAMPVUGUmwhpOnGAKotFvwMcXvo;

	public unsafe byte* iWavqJtqpLRFDExwQvVByDJzjHdY => VMafAqkBRXwxcBfVmJwLZcpiddVT();

	public IntPtr tfLDXnOPDQgteFRaWGWwamFYyxGlA => omdFOnGtoXWkZqAnZcVvZMnvFnWb();

	public int VOwGVRVfGGYpWANMsfoaesLDjOBmA => cHgRwMeSVGekrdstECqNJvxwbVBC();

	// C# has no syntax for parameterized property 'nKkaEwsuZDGhgHIUSYzbCdXnSAom'.
	public byte get_nKkaEwsuZDGhgHIUSYzbCdXnSAom(int P_0)
	{
		return KPibuthcHcRuYstFSAkMEECDvRwNb(P_0);
	}

	public void set_nKkaEwsuZDGhgHIUSYzbCdXnSAom(int P_0, byte P_1)
	{
		HCKoIZzdFlgQLvxAVojEPPEsgobR(num, b);
	}

	public unsafe byte* VMafAqkBRXwxcBfVmJwLZcpiddVT()
	{
		return nHXRJBdJSxaYPVwQKpGfZpqycqbj;
	}

	public unsafe IntPtr omdFOnGtoXWkZqAnZcVvZMnvFnWb()
	{
		return (IntPtr)nHXRJBdJSxaYPVwQKpGfZpqycqbj;
	}

	public int cHgRwMeSVGekrdstECqNJvxwbVBC()
	{
		return yEhCLJenZTaqpEMvVWqbyOQpERBdA;
	}

	public unsafe byte KPibuthcHcRuYstFSAkMEECDvRwNb(int P_0)
	{
		if (P_0 < 0 || P_0 >= yEhCLJenZTaqpEMvVWqbyOQpERBdA)
		{
			throw new IndexOutOfRangeException();
		}
		return nHXRJBdJSxaYPVwQKpGfZpqycqbj[P_0];
	}

	public unsafe void HCKoIZzdFlgQLvxAVojEPPEsgobR(int P_0, byte P_1)
	{
		if (P_0 < 0 || P_0 >= yEhCLJenZTaqpEMvVWqbyOQpERBdA)
		{
			throw new IndexOutOfRangeException();
		}
		nHXRJBdJSxaYPVwQKpGfZpqycqbj[P_0] = P_1;
	}

	public zPYtRvRddGYtyjvCeSHFiOzocDBi(int P_0)
	{
		VWFHdoQMtDwKaLLYCPPRribBjmHF(P_0);
	}

	public unsafe IntPtr DVmenhAFcASjwyICztKoPZvWOQge(int P_0 = 0)
	{
		if (P_0 == 0)
		{
			return (IntPtr)nHXRJBdJSxaYPVwQKpGfZpqycqbj;
		}
		if (P_0 < 0 || P_0 >= yEhCLJenZTaqpEMvVWqbyOQpERBdA)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		return (IntPtr)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_0);
	}

	public unsafe string yfoernTGjHnyuXCdnEDisjCPAEfK()
	{
		string text = "";
		for (int i = 0; i < yEhCLJenZTaqpEMvVWqbyOQpERBdA; i++)
		{
			text = text + nHXRJBdJSxaYPVwQKpGfZpqycqbj[i].ToString("x2") + " ";
		}
		return text;
	}

	public unsafe bool ZvaCxIsSnvPgvVACPBURvfPkePIH(int P_0, byte P_1)
	{
		if (1 + P_0 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		return (nHXRJBdJSxaYPVwQKpGfZpqycqbj[P_0] & (1 << (int)P_1)) != 0;
	}

	public unsafe byte CvoFbVBmfJwLyRSuGDQslCAFvLQtA(int P_0)
	{
		if (1 + P_0 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return nHXRJBdJSxaYPVwQKpGfZpqycqbj[P_0];
	}

	public unsafe short cfMfSLNhGUFeubKxGRQwUAIVZzDO(int P_0)
	{
		if (2 + P_0 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(short*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_0);
	}

	public unsafe ushort OtgwBLNGkdkxHpUyMXrFnCTfbPNK(int P_0)
	{
		if (2 + P_0 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ushort*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_0);
	}

	public unsafe int CozUkEkVIiSYSmhVtbiQSQgplmEW(int P_0)
	{
		if (4 + P_0 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(int*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_0);
	}

	public unsafe uint VoIEagizzFeUwJtRvMYCJZGXwrPMA(int P_0)
	{
		if (4 + P_0 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(uint*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_0);
	}

	public unsafe long tRvCLFklzbfmRBynFTbhyZEgPmLkA(int P_0)
	{
		if (8 + P_0 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(long*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_0);
	}

	public unsafe ulong ThAxZyoRakTwQsQUNVcpnABpuoMH(int P_0)
	{
		if (8 + P_0 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(ulong*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_0);
	}

	public unsafe float JwozwKuevnJDMaAfCdSxbxsQvWI(int P_0)
	{
		if (4 + P_0 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(float*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_0);
	}

	public unsafe double IxHdcDFfYzllsbQnCFhEjHokhhCGb(int P_0)
	{
		if (8 + P_0 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		return *(double*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_0);
	}

	public unsafe void LRUiFQLeOhFjOcdKuYIAmzLYSigrA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > yEhCLJenZTaqpEMvVWqbyOQpERBdA)
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
		if (P_2 >= yEhCLJenZTaqpEMvVWqbyOQpERBdA)
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
		if (P_1 + P_2 > yEhCLJenZTaqpEMvVWqbyOQpERBdA)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		NativeTools.CopyMemory((IntPtr)nHXRJBdJSxaYPVwQKpGfZpqycqbj, P_0, P_2, P_3, P_1);
	}

	public unsafe void wJsAizKqrVrSiKDbbRvPsYsWTGyX(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > yEhCLJenZTaqpEMvVWqbyOQpERBdA)
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
		if (P_3 >= yEhCLJenZTaqpEMvVWqbyOQpERBdA)
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
		if (P_2 + P_3 > yEhCLJenZTaqpEMvVWqbyOQpERBdA)
		{
			throw new ArgumentOutOfRangeException("numBytesToRead + readStartIndex must be < Length.");
		}
		nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(nHXRJBdJSxaYPVwQKpGfZpqycqbj, P_0, P_3, P_4, P_2);
	}

	public unsafe void NFAWFgZcdDDPGCLRGRAFJzrDJUdZ(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		wJsAizKqrVrSiKDbbRvPsYsWTGyX((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int xroHnfwoEDtnnULzogUkPaDKfTZh(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_2 >= yEhCLJenZTaqpEMvVWqbyOQpERBdA)
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
		if (P_2 + P_1 > yEhCLJenZTaqpEMvVWqbyOQpERBdA)
		{
			P_1 = yEhCLJenZTaqpEMvVWqbyOQpERBdA - P_2;
		}
		if (P_3 + P_1 > num)
		{
			P_1 = num - P_3;
		}
		if (P_1 == 0)
		{
			return 0;
		}
		NativeTools.CopyMemory((IntPtr)nHXRJBdJSxaYPVwQKpGfZpqycqbj, P_0, P_2, P_3, P_1);
		return P_1;
	}

	public unsafe int UlFOkBSefuDEDCslxnxMHxEGtanS(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_2 <= 0)
		{
			return 0;
		}
		if (P_3 >= yEhCLJenZTaqpEMvVWqbyOQpERBdA)
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
		if (P_3 + P_2 > yEhCLJenZTaqpEMvVWqbyOQpERBdA)
		{
			P_2 = yEhCLJenZTaqpEMvVWqbyOQpERBdA - P_3;
		}
		if (P_4 + P_2 > P_1)
		{
			P_2 = P_1 - P_4;
		}
		nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(nHXRJBdJSxaYPVwQKpGfZpqycqbj, P_0, P_3, P_4, P_2);
		return P_2;
	}

	public unsafe int OzobrIeCpsZsYmSKbGdcPySGzfnE(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == IntPtr.Zero)
		{
			return 0;
		}
		return UlFOkBSefuDEDCslxnxMHxEGtanS((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe void BLHeNqCuuQUIjfjMFfqHZkpeWXni(int P_0, byte P_1, bool P_2)
	{
		if (1 + P_0 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("byteIndex");
		}
		if (P_1 >= 8)
		{
			throw new ArgumentOutOfRangeException("bit");
		}
		if (P_2)
		{
			byte* num = nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_0;
			*num |= (byte)(1 << (int)P_1);
		}
		else
		{
			byte* num2 = nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_0;
			*num2 &= (byte)(~(1 << (int)P_1));
		}
	}

	public unsafe void IGyGPxctPaQrcZxBOLCEnaKaKuTU(byte P_0, int P_1)
	{
		if (1 + P_1 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		nHXRJBdJSxaYPVwQKpGfZpqycqbj[P_1] = P_0;
	}

	public unsafe void DYIirmrHCfJcoPAoPEgPvhGCQZXl(short P_0, int P_1)
	{
		if (2 + P_1 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(short*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_1) = P_0;
	}

	public unsafe void xXMndqbpSVFRgByHuuNcmsLfUsjU(ushort P_0, int P_1)
	{
		if (2 + P_1 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ushort*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_1) = P_0;
	}

	public unsafe void KarKuIyzYKGqVKZizugzXUHOQxFj(int P_0, int P_1)
	{
		if (4 + P_1 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(int*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_1) = P_0;
	}

	public unsafe void kQfGauaLYMUTApWpejLdwREcltys(uint P_0, int P_1)
	{
		if (4 + P_1 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(uint*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_1) = P_0;
	}

	public unsafe void rlzuGoGsaoJQAvWbgxbwQxrSRnLF(long P_0, int P_1)
	{
		if (8 + P_1 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(long*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_1) = P_0;
	}

	public unsafe void aWKGyJUiOUCPQVTuWgfTFrLcqVEnA(ulong P_0, int P_1)
	{
		if (8 + P_1 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(ulong*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_1) = P_0;
	}

	public unsafe void GGobbobDbLUyJGFnhskQviURdPmUA(float P_0, int P_1)
	{
		if (4 + P_1 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(float*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_1) = P_0;
	}

	public unsafe void CKkzEwXOYPqkErKhClRWqzpIbTWl(double P_0, int P_1)
	{
		if (8 + P_1 > yEhCLJenZTaqpEMvVWqbyOQpERBdA || P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		*(double*)(nHXRJBdJSxaYPVwQKpGfZpqycqbj + P_1) = P_0;
	}

	public unsafe void LaOfMfVgWzeHWiBLFCfWnIylJongA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
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
		if (P_1 > yEhCLJenZTaqpEMvVWqbyOQpERBdA)
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
		if (P_2 >= yEhCLJenZTaqpEMvVWqbyOQpERBdA)
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
		if (P_1 + P_2 > yEhCLJenZTaqpEMvVWqbyOQpERBdA)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		NativeTools.CopyMemory(P_0, (IntPtr)nHXRJBdJSxaYPVwQKpGfZpqycqbj, P_3, P_2, P_1);
	}

	public unsafe void LJRgUhGtxtXNtdveRcOgDCXcYPAnb(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
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
		if (P_2 > yEhCLJenZTaqpEMvVWqbyOQpERBdA)
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
		if (P_3 >= yEhCLJenZTaqpEMvVWqbyOQpERBdA)
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
		if (P_2 + P_3 > yEhCLJenZTaqpEMvVWqbyOQpERBdA)
		{
			throw new ArgumentOutOfRangeException("numBytesToWrite + writeStartIndex must be < Length.");
		}
		nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(P_0, nHXRJBdJSxaYPVwQKpGfZpqycqbj, P_4, P_3, P_2);
	}

	public unsafe void erRhbiHZFsWNiKNWBFovAsSiBKhFA(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		LJRgUhGtxtXNtdveRcOgDCXcYPAnb((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe int kQahpqFknYUMEBBOFJSKuFPLcHdNA(byte[] P_0, int P_1, int P_2 = 0, int P_3 = 0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		int num = P_0.Length;
		if (num == 0 || P_1 <= 0 || P_3 >= num || P_2 >= yEhCLJenZTaqpEMvVWqbyOQpERBdA)
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
		if (P_1 + P_2 > yEhCLJenZTaqpEMvVWqbyOQpERBdA)
		{
			P_1 = yEhCLJenZTaqpEMvVWqbyOQpERBdA - P_2;
		}
		NativeTools.CopyMemory(P_0, (IntPtr)nHXRJBdJSxaYPVwQKpGfZpqycqbj, P_3, P_2, P_1);
		return P_1;
	}

	public unsafe int IIkAeSaofDdvuByIEyylurokRgVr(byte* P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || P_4 >= P_1 || P_3 >= yEhCLJenZTaqpEMvVWqbyOQpERBdA)
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
		if (P_2 + P_3 > yEhCLJenZTaqpEMvVWqbyOQpERBdA)
		{
			P_2 = yEhCLJenZTaqpEMvVWqbyOQpERBdA - P_3;
		}
		nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(P_0, nHXRJBdJSxaYPVwQKpGfZpqycqbj, P_4, P_3, P_2);
		return P_2;
	}

	public unsafe int GtwIZzpYGHPYKnwFFduRkKKJKuZM(IntPtr P_0, int P_1, int P_2, int P_3 = 0, int P_4 = 0)
	{
		return IIkAeSaofDdvuByIEyylurokRgVr((byte*)(void*)P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool VWFHdoQMtDwKaLLYCPPRribBjmHF(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("size");
		}
		if (yEhCLJenZTaqpEMvVWqbyOQpERBdA == P_0)
		{
			return true;
		}
		uQTwNRfwPHIxvpwbfOuEjCFpmMME();
		if (P_0 == 0)
		{
			return true;
		}
		yEhCLJenZTaqpEMvVWqbyOQpERBdA = P_0;
		nHXRJBdJSxaYPVwQKpGfZpqycqbj = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		GMqBRTuoSizKirIBVPYJbWkzQIFD();
		return true;
	}

	public unsafe void GMqBRTuoSizKirIBVPYJbWkzQIFD()
	{
		if (yEhCLJenZTaqpEMvVWqbyOQpERBdA != 0)
		{
			nszCkLYuchMjpmuavlajKXkkRecO.KhJYDYMLwtrMmSUfniSvlDNTVNwe(nHXRJBdJSxaYPVwQKpGfZpqycqbj, yEhCLJenZTaqpEMvVWqbyOQpERBdA);
		}
	}

	public unsafe void uQTwNRfwPHIxvpwbfOuEjCFpmMME()
	{
		if (yEhCLJenZTaqpEMvVWqbyOQpERBdA == 0)
		{
			return;
		}
		try
		{
			if (nHXRJBdJSxaYPVwQKpGfZpqycqbj != null)
			{
				Marshal.FreeHGlobal(omdFOnGtoXWkZqAnZcVvZMnvFnWb());
			}
		}
		catch
		{
		}
		nHXRJBdJSxaYPVwQKpGfZpqycqbj = null;
		yEhCLJenZTaqpEMvVWqbyOQpERBdA = 0;
	}

	public virtual string laHIzpAjrtHjPAdKEOTLjcMNmPhOc()
	{
		string text = "";
		for (int i = 0; i < yEhCLJenZTaqpEMvVWqbyOQpERBdA; i++)
		{
			text = text + CvoFbVBmfJwLyRSuGDQslCAFvLQtA(i).ToString("x2") + " ";
		}
		return text;
	}

	public void Dispose()
	{
		TkVFflBffGPLKeFeKjsPCoOHFEjWD(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void cDCOeKsAJsPQTRJgkCbXdZEEDFRs()
	{
		try
		{
			TkVFflBffGPLKeFeKjsPCoOHFEjWD(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void TkVFflBffGPLKeFeKjsPCoOHFEjWD(bool P_0)
	{
		if (!YZAMPVUGUmwhpOnGAKotFvwMcXvo)
		{
			uQTwNRfwPHIxvpwbfOuEjCFpmMME();
			YZAMPVUGUmwhpOnGAKotFvwMcXvo = true;
		}
	}

	[SpecialName]
	public unsafe static IntPtr LBmhHOATglrnrMJyhDckXAWXTXYLA(zPYtRvRddGYtyjvCeSHFiOzocDBi P_0)
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		return (IntPtr)P_0.nHXRJBdJSxaYPVwQKpGfZpqycqbj;
	}

	[SpecialName]
	public unsafe static void* LBmhHOATglrnrMJyhDckXAWXTXYLA(zPYtRvRddGYtyjvCeSHFiOzocDBi P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return P_0.nHXRJBdJSxaYPVwQKpGfZpqycqbj;
	}

	public unsafe static bool ZciCcbeOxCrQnvSNISOWEHJoMHrp(zPYtRvRddGYtyjvCeSHFiOzocDBi P_0, zPYtRvRddGYtyjvCeSHFiOzocDBi P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.yEhCLJenZTaqpEMvVWqbyOQpERBdA == 0)
		{
			P_1.uQTwNRfwPHIxvpwbfOuEjCFpmMME();
			return true;
		}
		if (P_1.VWFHdoQMtDwKaLLYCPPRribBjmHF(P_0.yEhCLJenZTaqpEMvVWqbyOQpERBdA))
		{
			P_1.LJRgUhGtxtXNtdveRcOgDCXcYPAnb(P_0.nHXRJBdJSxaYPVwQKpGfZpqycqbj, P_0.yEhCLJenZTaqpEMvVWqbyOQpERBdA, P_0.yEhCLJenZTaqpEMvVWqbyOQpERBdA);
			return true;
		}
		return false;
	}
}
