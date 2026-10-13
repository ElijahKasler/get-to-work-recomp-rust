using System;

internal class RZjcQypUKPYidkfEEPMrbuFTsFlL : IDisposable
{
	private readonly zPYtRvRddGYtyjvCeSHFiOzocDBi auLLatItMvuUiEJjVEOTKbzTfpqMA;

	private bool[] OxRexheLHtjBBdUdXTsEFlMsBNFg;

	protected readonly int cjYzRxXfewmFBSRCmOgsGXJOCaWv;

	protected readonly int gukUszPUqLwKCiISeSgkTsppRAis;

	private bool NFUJQULoXDaDlwCxXAlPDgdWYyLJA;

	public int AxjbkUwUnYXlGohgzhimkOhOkYdkA => vcLiGHSzAWtoXfBJlBHnTRgGufiM();

	public int XQwUDemoUZjRLYLIiFgxFtRAzhlz => nfBTuxeqtDvjNncZpqQzorPCZVA();

	public bool[] ROOeMjbAwHqNlBpNauzhpkAKYLvB => ajoAoEqplsAMgEllSOBgZAKPPSTe();

	public int vcLiGHSzAWtoXfBJlBHnTRgGufiM()
	{
		return cjYzRxXfewmFBSRCmOgsGXJOCaWv;
	}

	public int nfBTuxeqtDvjNncZpqQzorPCZVA()
	{
		return gukUszPUqLwKCiISeSgkTsppRAis;
	}

	public bool[] ajoAoEqplsAMgEllSOBgZAKPPSTe()
	{
		return OxRexheLHtjBBdUdXTsEFlMsBNFg ?? (OxRexheLHtjBBdUdXTsEFlMsBNFg = new bool[cjYzRxXfewmFBSRCmOgsGXJOCaWv]);
	}

	public RZjcQypUKPYidkfEEPMrbuFTsFlL(int P_0, int P_1)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		if (P_1 <= 0)
		{
			throw new ArgumentOutOfRangeException("entryBitSize");
		}
		gukUszPUqLwKCiISeSgkTsppRAis = P_0;
		cjYzRxXfewmFBSRCmOgsGXJOCaWv = P_1;
		int num = P_0 * P_1;
		auLLatItMvuUiEJjVEOTKbzTfpqMA = new zPYtRvRddGYtyjvCeSHFiOzocDBi(num / 8 + ((num % 8 != 0) ? 1 : 0));
	}

	public unsafe void gKmQSrfLDDxfkZaUSbkaxgIcZOMj(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= gukUszPUqLwKCiISeSgkTsppRAis)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 < cjYzRxXfewmFBSRCmOgsGXJOCaWv)
		{
			int num = cjYzRxXfewmFBSRCmOgsGXJOCaWv;
			throw new Exception("Buffer is too small to hold the data. Must be at least " + num + " bits.");
		}
		int num2 = 0;
		int num3 = 0;
		for (int i = 0; i < cjYzRxXfewmFBSRCmOgsGXJOCaWv; i++)
		{
			GUZwrGcZSQQFlqcigVzOAEVxTUEo(P_0, i, out var num4, out var b);
			P_1[i] = (auLLatItMvuUiEJjVEOTKbzTfpqMA.ZvaCxIsSnvPgvVACPBURvfPkePIH(num4, b) ? ((byte)(P_1[num2] | (1 << num3))) : ((byte)(P_1[num2] & ~(1 << num3))));
			num3++;
			if (num3 >= 8)
			{
				num2++;
				num3 = 0;
			}
		}
	}

	public unsafe void FKUaOLDjpWIWhQrlaFYfVYKxtKydA(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		gKmQSrfLDDxfkZaUSbkaxgIcZOMj(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void AFvagAHWuvqrMpUKJklOmOIDYJnN(int P_0, out byte P_1)
	{
		byte b = 0;
		byte* ptr = &b;
		gKmQSrfLDDxfkZaUSbkaxgIcZOMj(P_0, ptr, 64);
		P_1 = b;
	}

	public void XVwbLYGzZHFrDwiqAsdtJkjykzydA(int P_0, out sbyte P_1)
	{
		AFvagAHWuvqrMpUKJklOmOIDYJnN(P_0, out var b);
		P_1 = (sbyte)b;
	}

	public unsafe void WLCOJmjUNFdRcWxNIuoakRMCfEkP(int P_0, out short P_1)
	{
		short num = 0;
		byte* ptr = (byte*)(&num);
		gKmQSrfLDDxfkZaUSbkaxgIcZOMj(P_0, ptr, 64);
		P_1 = num;
	}

	public void DUSBzOdXJETqaHeLAfFXtcbbLeqY(int P_0, out ushort P_1)
	{
		WLCOJmjUNFdRcWxNIuoakRMCfEkP(P_0, out var num);
		P_1 = (ushort)num;
	}

	public unsafe void iFBDgpFbYsgQdefceiNBvRAwgBTzb(int P_0, out int P_1)
	{
		int num = 0;
		byte* ptr = (byte*)(&num);
		gKmQSrfLDDxfkZaUSbkaxgIcZOMj(P_0, ptr, 64);
		P_1 = num;
	}

	public void kLRtXwcCEADozAurHeEWOolWOsHq(int P_0, out uint P_1)
	{
		iFBDgpFbYsgQdefceiNBvRAwgBTzb(P_0, out var num);
		P_1 = (uint)num;
	}

	public unsafe void InWVVOeVmBKjtMAsueFbIYklFcwg(int P_0, out long P_1)
	{
		long num = 0L;
		byte* ptr = (byte*)(&num);
		gKmQSrfLDDxfkZaUSbkaxgIcZOMj(P_0, ptr, 64);
		P_1 = num;
	}

	public void clvwsiEUqZdPZVRbsiSLNjgBFXBu(int P_0, out ulong P_1)
	{
		InWVVOeVmBKjtMAsueFbIYklFcwg(P_0, out var num);
		P_1 = (ulong)num;
	}

	public void WdVyfdByfOsiOdoAMAwVqaCAxmTO(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= gukUszPUqLwKCiISeSgkTsppRAis)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < cjYzRxXfewmFBSRCmOgsGXJOCaWv)
		{
			int num = cjYzRxXfewmFBSRCmOgsGXJOCaWv;
			throw new Exception("valueBuffer.Length must be >= " + num);
		}
		for (int i = 0; i < cjYzRxXfewmFBSRCmOgsGXJOCaWv; i++)
		{
			GUZwrGcZSQQFlqcigVzOAEVxTUEo(P_0, i, out var num2, out var b);
			P_1[i] = auLLatItMvuUiEJjVEOTKbzTfpqMA.ZvaCxIsSnvPgvVACPBURvfPkePIH(num2, b);
		}
	}

	public unsafe void RTPNVqrpHHZkZnminPvnidjQFLcfA(int P_0, byte* P_1, int P_2)
	{
		if (P_0 < 0 || P_0 >= gukUszPUqLwKCiISeSgkTsppRAis)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_2 <= 0)
		{
			throw new Exception("bufferSize must be >= 0");
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < cjYzRxXfewmFBSRCmOgsGXJOCaWv; i++)
		{
			GUZwrGcZSQQFlqcigVzOAEVxTUEo(P_0, i, out var num3, out var b);
			bool flag = i < P_2 && (flag = (P_1[num] & (1 << num2)) != 0);
			auLLatItMvuUiEJjVEOTKbzTfpqMA.BLHeNqCuuQUIjfjMFfqHZkpeWXni(num3, b, flag);
			num2++;
			if (num2 >= 8)
			{
				num++;
				num2 = 0;
			}
		}
	}

	public unsafe void llnlybGsBiHcxIkhLEPeUyiHJYyg(int P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new ArgumentNullException("buffer");
		}
		RTPNVqrpHHZkZnminPvnidjQFLcfA(P_0, (byte*)(void*)P_1, P_2);
	}

	public unsafe void vmJmwCUMYPvIoQyJXubBsTrDRDxB(int P_0, byte P_1)
	{
		byte* ptr = &P_1;
		RTPNVqrpHHZkZnminPvnidjQFLcfA(P_0, ptr, 8);
	}

	public void NtufflKbdGvHzlhoPkrxCUgGijOvb(int P_0, sbyte P_1)
	{
		vmJmwCUMYPvIoQyJXubBsTrDRDxB(P_0, (byte)P_1);
	}

	public unsafe void rZPErcNQDWDGxOksBNYapbqfjlYM(int P_0, short P_1)
	{
		byte* ptr = (byte*)(&P_1);
		RTPNVqrpHHZkZnminPvnidjQFLcfA(P_0, ptr, 16);
	}

	public void UPcnsnZgvjnplGbIPfekMKQinfdG(int P_0, ushort P_1)
	{
		rZPErcNQDWDGxOksBNYapbqfjlYM(P_0, (short)P_1);
	}

	public unsafe void DuyjqfZmeEBLhibwYCizvKINKPfPA(int P_0, int P_1)
	{
		byte* ptr = (byte*)(&P_1);
		RTPNVqrpHHZkZnminPvnidjQFLcfA(P_0, ptr, 32);
	}

	public void vYDQISoNKVdujbeSYEpDqOzdhvxw(int P_0, uint P_1)
	{
		DuyjqfZmeEBLhibwYCizvKINKPfPA(P_0, (int)P_1);
	}

	public unsafe void wbrzMbphcAaNxZNHgLBObLxvvgMe(int P_0, long P_1)
	{
		byte* ptr = (byte*)(&P_1);
		RTPNVqrpHHZkZnminPvnidjQFLcfA(P_0, ptr, 64);
	}

	public void rotaIMTDXCAbmRWKRvHdtxkZeuCg(int P_0, ulong P_1)
	{
		wbrzMbphcAaNxZNHgLBObLxvvgMe(P_0, (long)P_1);
	}

	public void jlAyMHmEYZwUxfaYqbLgenvjcdvk(int P_0, bool[] P_1)
	{
		if (P_0 < 0 || P_0 >= gukUszPUqLwKCiISeSgkTsppRAis)
		{
			throw new IndexOutOfRangeException("index");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("valueBuffer");
		}
		if (P_1.Length < cjYzRxXfewmFBSRCmOgsGXJOCaWv)
		{
			int num = cjYzRxXfewmFBSRCmOgsGXJOCaWv;
			throw new Exception("valueBuffer.Length must be >= " + num);
		}
		for (int i = 0; i < cjYzRxXfewmFBSRCmOgsGXJOCaWv; i++)
		{
			GUZwrGcZSQQFlqcigVzOAEVxTUEo(P_0, i, out var num2, out var b);
			auLLatItMvuUiEJjVEOTKbzTfpqMA.BLHeNqCuuQUIjfjMFfqHZkpeWXni(num2, b, P_1[i]);
		}
	}

	private void GUZwrGcZSQQFlqcigVzOAEVxTUEo(int P_0, int P_1, out int P_2, out byte P_3)
	{
		if (P_0 < 0 || P_0 >= gukUszPUqLwKCiISeSgkTsppRAis)
		{
			throw new IndexOutOfRangeException("entryIndex");
		}
		if (P_1 < 0 || P_1 >= cjYzRxXfewmFBSRCmOgsGXJOCaWv)
		{
			throw new ArgumentOutOfRangeException("bitOffset");
		}
		int num = P_0 * cjYzRxXfewmFBSRCmOgsGXJOCaWv + P_1;
		P_2 = num / cjYzRxXfewmFBSRCmOgsGXJOCaWv;
		P_3 = (byte)(num - P_2 * cjYzRxXfewmFBSRCmOgsGXJOCaWv);
	}

	private int QaUxLpFtuGUdJmBbhoIlgxAIxgUg(int P_0, out byte P_1)
	{
		if (P_0 < 0 || P_0 >= gukUszPUqLwKCiISeSgkTsppRAis * cjYzRxXfewmFBSRCmOgsGXJOCaWv)
		{
			throw new IndexOutOfRangeException("bitIndex");
		}
		int num = P_0 / cjYzRxXfewmFBSRCmOgsGXJOCaWv;
		P_1 = (byte)(P_0 - num * cjYzRxXfewmFBSRCmOgsGXJOCaWv);
		return num;
	}

	public void Dispose()
	{
		qoQGGLIsJxlJzsRkzWmGRUcdxLqv(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void kbpKyXWvmYUhpPxITVVUGTInHUhe()
	{
		try
		{
			qoQGGLIsJxlJzsRkzWmGRUcdxLqv(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void qoQGGLIsJxlJzsRkzWmGRUcdxLqv(bool P_0)
	{
		if (!NFUJQULoXDaDlwCxXAlPDgdWYyLJA)
		{
			if (P_0 && auLLatItMvuUiEJjVEOTKbzTfpqMA != null)
			{
				auLLatItMvuUiEJjVEOTKbzTfpqMA.Dispose();
			}
			NFUJQULoXDaDlwCxXAlPDgdWYyLJA = true;
		}
	}
}
