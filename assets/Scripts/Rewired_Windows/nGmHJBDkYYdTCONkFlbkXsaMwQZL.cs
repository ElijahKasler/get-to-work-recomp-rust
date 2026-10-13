using System;
using Rewired.Utils;

internal class nGmHJBDkYYdTCONkFlbkXsaMwQZL : IDisposable
{
	private readonly zPYtRvRddGYtyjvCeSHFiOzocDBi DstPQghBFMGxVpNkmaNcIBmcyouI;

	private readonly int qRefxGDsRSqNaJUgAHhgScdRYmuBB;

	private long CDaNgwWbRqvOdaoHAuRwEZixhojj;

	private long cUlkKkODJGmvZFQPVcCTjBAnCrqy;

	private int wNZILRWZEBgpSyviLfLqWlPbqhsK;

	private bool zidYUgdFlqBgmYCcHoDFZgkeExRGA;

	private uint CKMESHfKnxVWOoHVYmFhDFYekYbOB;

	private bool fDIqDPwJsebiMMpvRxmatUBabxXs;

	public int CnKzCALyRBCzGpybitzklwmUQdll => rXELIYYdMUQZWksaSOZXrJxQmRei();

	public int TKUXBgkGKRmuvESiNWFzcBfLddVm => CyWrbQnYwjPzUdluNXqRtAFJxigj();

	public bool FTPDqvJREhGfGBhiFMEEOfikVpOub => ljRhQsUKtsFNMfmnRnChfMLOgkZzA();

	public int rXELIYYdMUQZWksaSOZXrJxQmRei()
	{
		return qRefxGDsRSqNaJUgAHhgScdRYmuBB;
	}

	public int CyWrbQnYwjPzUdluNXqRtAFJxigj()
	{
		return wNZILRWZEBgpSyviLfLqWlPbqhsK;
	}

	public bool ljRhQsUKtsFNMfmnRnChfMLOgkZzA()
	{
		return zidYUgdFlqBgmYCcHoDFZgkeExRGA;
	}

	public nGmHJBDkYYdTCONkFlbkXsaMwQZL(int P_0)
	{
		qRefxGDsRSqNaJUgAHhgScdRYmuBB = P_0;
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		DstPQghBFMGxVpNkmaNcIBmcyouI = new zPYtRvRddGYtyjvCeSHFiOzocDBi(P_0);
	}

	public unsafe int PwlgRXEpacEUsEUMaqUzwZLnrgIeA(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)CDaNgwWbRqvOdaoHAuRwEZixhojj;
		P_4 = CKMESHfKnxVWOoHVYmFhDFYekYbOB;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = DstPQghBFMGxVpNkmaNcIBmcyouI.IIkAeSaofDdvuByIEyylurokRgVr(P_0, P_1, P_2, (int)CDaNgwWbRqvOdaoHAuRwEZixhojj);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += DstPQghBFMGxVpNkmaNcIBmcyouI.IIkAeSaofDdvuByIEyylurokRgVr(P_0 + num, P_1 - num, P_2 - num);
		}
		DOGBKhjeYhKMJpapIjgHGgCpRfKq(num);
		return num;
	}

	public unsafe int FomBOTHmImlYokfXwCyGltvEemEiA(IntPtr P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			P_3 = (int)CDaNgwWbRqvOdaoHAuRwEZixhojj;
			P_4 = CKMESHfKnxVWOoHVYmFhDFYekYbOB;
			return 0;
		}
		return PwlgRXEpacEUsEUMaqUzwZLnrgIeA((byte*)(void*)P_0, P_1, P_2, out P_3, out P_4);
	}

	public unsafe int vwoHzLNJDtJrsZgGPwQBgHkKdxNv(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)CDaNgwWbRqvOdaoHAuRwEZixhojj;
			P_3 = CKMESHfKnxVWOoHVYmFhDFYekYbOB;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return PwlgRXEpacEUsEUMaqUzwZLnrgIeA(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public unsafe int XdVBDZckyhSNIahNmYGTHkfbUCtK(byte* P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return PwlgRXEpacEUsEUMaqUzwZLnrgIeA(P_0, P_1, P_2, out num, out num2);
	}

	public int vkadXybQZHqsTANzltfpmCXyomOIb(IntPtr P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return FomBOTHmImlYokfXwCyGltvEemEiA(P_0, P_1, P_2, out num, out num2);
	}

	public int LbszLhUpnAnONEtQIPlrvdunBzxs(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return vwoHzLNJDtJrsZgGPwQBgHkKdxNv(P_0, P_1, out num, out num2);
	}

	public unsafe int VYgCfDNiAbOUCnVrJXzImWaJyQmg(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || wNZILRWZEBgpSyviLfLqWlPbqhsK == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > wNZILRWZEBgpSyviLfLqWlPbqhsK)
		{
			P_2 = wNZILRWZEBgpSyviLfLqWlPbqhsK;
		}
		int num = DstPQghBFMGxVpNkmaNcIBmcyouI.UlFOkBSefuDEDCslxnxMHxEGtanS(P_0, P_1, P_2, (int)cUlkKkODJGmvZFQPVcCTjBAnCrqy);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += DstPQghBFMGxVpNkmaNcIBmcyouI.UlFOkBSefuDEDCslxnxMHxEGtanS(P_0 + num, P_1 - num, P_2 - num);
		}
		YoDauiOdRmhFcgqDhTCmNgtBHgrk(num);
		return num;
	}

	public unsafe int KsudtZUdFWGblDebnuXMTcJsdkejA(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return VYgCfDNiAbOUCnVrJXzImWaJyQmg(ptr, P_0.Length, P_1);
		}
	}

	public unsafe int SPuFPtcMUlMWVCCAequgvLewwBbVb(IntPtr P_0, int P_1, int P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		return VYgCfDNiAbOUCnVrJXzImWaJyQmg((byte*)(void*)P_0, P_1, P_2);
	}

	public unsafe int zXrCHSEuFcvNWPWVZYYBHxamQAuc(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || wNZILRWZEBgpSyviLfLqWlPbqhsK == 0 || P_3 < 0 || P_3 >= qRefxGDsRSqNaJUgAHhgScdRYmuBB)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > wNZILRWZEBgpSyviLfLqWlPbqhsK)
		{
			P_2 = wNZILRWZEBgpSyviLfLqWlPbqhsK;
		}
		int num = DstPQghBFMGxVpNkmaNcIBmcyouI.UlFOkBSefuDEDCslxnxMHxEGtanS(P_0, P_1, P_2, P_3);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += DstPQghBFMGxVpNkmaNcIBmcyouI.UlFOkBSefuDEDCslxnxMHxEGtanS(P_0 + num, P_1 - num, P_2 - num);
		}
		return num;
	}

	public unsafe int cVwgflQATcKeloAxILJABotKymrx(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return zXrCHSEuFcvNWPWVZYYBHxamQAuc(ptr, P_0.Length, P_1, P_2);
		}
	}

	public unsafe int heFoxyYDbroOdLblbjlnFxJMWhlVA(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_3 <= 0)
		{
			return 0;
		}
		return zXrCHSEuFcvNWPWVZYYBHxamQAuc((byte*)(void*)P_0, P_1, P_2, P_3);
	}

	public bool ETcZJjzSMLfRDnMNOrNknOSXXQrh(int P_0, uint P_1)
	{
		if (P_0 < 0 || P_0 >= qRefxGDsRSqNaJUgAHhgScdRYmuBB)
		{
			return false;
		}
		if (P_0 < CDaNgwWbRqvOdaoHAuRwEZixhojj)
		{
			if (P_1 == CKMESHfKnxVWOoHVYmFhDFYekYbOB)
			{
				return true;
			}
		}
		else if (P_0 >= CDaNgwWbRqvOdaoHAuRwEZixhojj)
		{
			if (CKMESHfKnxVWOoHVYmFhDFYekYbOB == 0)
			{
				return false;
			}
			if (CKMESHfKnxVWOoHVYmFhDFYekYbOB - 1 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public void vzRCzJdTZSLzBZQvWuOGrGQmpvwF()
	{
		CDaNgwWbRqvOdaoHAuRwEZixhojj = 0L;
		cUlkKkODJGmvZFQPVcCTjBAnCrqy = 0L;
		wNZILRWZEBgpSyviLfLqWlPbqhsK = 0;
		zidYUgdFlqBgmYCcHoDFZgkeExRGA = false;
		CKMESHfKnxVWOoHVYmFhDFYekYbOB = 0u;
	}

	private void DOGBKhjeYhKMJpapIjgHGgCpRfKq(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)CDaNgwWbRqvOdaoHAuRwEZixhojj;
		CDaNgwWbRqvOdaoHAuRwEZixhojj += P_0;
		bool flag = false;
		if (num < cUlkKkODJGmvZFQPVcCTjBAnCrqy)
		{
			if (CDaNgwWbRqvOdaoHAuRwEZixhojj > cUlkKkODJGmvZFQPVcCTjBAnCrqy)
			{
				flag = true;
			}
		}
		else if (num > cUlkKkODJGmvZFQPVcCTjBAnCrqy)
		{
			if (CDaNgwWbRqvOdaoHAuRwEZixhojj - qRefxGDsRSqNaJUgAHhgScdRYmuBB > cUlkKkODJGmvZFQPVcCTjBAnCrqy)
			{
				flag = true;
			}
		}
		else if (wNZILRWZEBgpSyviLfLqWlPbqhsK > 0)
		{
			flag = true;
		}
		if (flag)
		{
			zidYUgdFlqBgmYCcHoDFZgkeExRGA = true;
			cUlkKkODJGmvZFQPVcCTjBAnCrqy = CDaNgwWbRqvOdaoHAuRwEZixhojj;
			if (cUlkKkODJGmvZFQPVcCTjBAnCrqy >= qRefxGDsRSqNaJUgAHhgScdRYmuBB)
			{
				cUlkKkODJGmvZFQPVcCTjBAnCrqy -= qRefxGDsRSqNaJUgAHhgScdRYmuBB;
			}
		}
		if (CDaNgwWbRqvOdaoHAuRwEZixhojj >= qRefxGDsRSqNaJUgAHhgScdRYmuBB)
		{
			CDaNgwWbRqvOdaoHAuRwEZixhojj -= qRefxGDsRSqNaJUgAHhgScdRYmuBB;
			WFCFHXZXIADkcfFFCoseJcwNdPrDb();
		}
		wNZILRWZEBgpSyviLfLqWlPbqhsK = (int)MathTools.Clamp((long)wNZILRWZEBgpSyviLfLqWlPbqhsK + (long)P_0, 0L, qRefxGDsRSqNaJUgAHhgScdRYmuBB);
	}

	private void YoDauiOdRmhFcgqDhTCmNgtBHgrk(int P_0)
	{
		if (P_0 > 0)
		{
			if (zidYUgdFlqBgmYCcHoDFZgkeExRGA)
			{
				zidYUgdFlqBgmYCcHoDFZgkeExRGA = false;
			}
			cUlkKkODJGmvZFQPVcCTjBAnCrqy += P_0;
			if (cUlkKkODJGmvZFQPVcCTjBAnCrqy >= qRefxGDsRSqNaJUgAHhgScdRYmuBB)
			{
				cUlkKkODJGmvZFQPVcCTjBAnCrqy -= qRefxGDsRSqNaJUgAHhgScdRYmuBB;
			}
			long num = (long)wNZILRWZEBgpSyviLfLqWlPbqhsK - (long)P_0;
			wNZILRWZEBgpSyviLfLqWlPbqhsK = (int)((num >= 0) ? num : 0);
		}
	}

	private void WFCFHXZXIADkcfFFCoseJcwNdPrDb()
	{
		if (CKMESHfKnxVWOoHVYmFhDFYekYbOB == uint.MaxValue)
		{
			CKMESHfKnxVWOoHVYmFhDFYekYbOB = 0u;
		}
		else
		{
			CKMESHfKnxVWOoHVYmFhDFYekYbOB++;
		}
	}

	public void Dispose()
	{
		ICQrSEAfAtQwaPMPoivZPFfnspOg(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void ljlZegATgaaGGeLAQhOUhnZEQjYfb()
	{
		try
		{
			ICQrSEAfAtQwaPMPoivZPFfnspOg(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void ICQrSEAfAtQwaPMPoivZPFfnspOg(bool P_0)
	{
		if (!fDIqDPwJsebiMMpvRxmatUBabxXs)
		{
			if (P_0 && DstPQghBFMGxVpNkmaNcIBmcyouI != null)
			{
				DstPQghBFMGxVpNkmaNcIBmcyouI.Dispose();
			}
			fDIqDPwJsebiMMpvRxmatUBabxXs = true;
		}
	}
}
