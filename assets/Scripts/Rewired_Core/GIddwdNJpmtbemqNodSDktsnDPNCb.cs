using UnityEngine;

internal static class GIddwdNJpmtbemqNodSDktsnDPNCb
{
	private static int BjzKyoHZexOkSQGnygVnGpNGwxag;

	private static int wIeuoqUJdIGykTPIxNePDtROKdGh;

	private static double[] DpEcTUpeUBVVMMRamUuaHhTAPPpy;

	private static int WueaZNmcudYbtAcoKEAewumhBHdDA;

	private static double ZeHlRSewigInIKcLtxdDKAUmGLIC;

	private static int XsDYyMvIbytwqNgXjJXmauDesLaw;

	public static double WijxYoaaQmvSbwKIuVBcDLqnjmuK => jKPdnUkzqWqGpuCzMcJWaDqXlirDb();

	public static int DMUQkfgDMVlYCsOitlcBxgmRIGEA
	{
		get
		{
			return qhqoAAoutzghllbYSCnvLpxrAAiDA();
		}
		set
		{
			IxSlYvMudrZmFgMFwowWCcApUAHm(num);
		}
	}

	public static double jKPdnUkzqWqGpuCzMcJWaDqXlirDb()
	{
		return ZeHlRSewigInIKcLtxdDKAUmGLIC;
	}

	public static int qhqoAAoutzghllbYSCnvLpxrAAiDA()
	{
		return BjzKyoHZexOkSQGnygVnGpNGwxag;
	}

	public static void IxSlYvMudrZmFgMFwowWCcApUAHm(int P_0)
	{
		if (P_0 <= 0)
		{
			P_0 = 1;
		}
		if (P_0 != BjzKyoHZexOkSQGnygVnGpNGwxag)
		{
			BjzKyoHZexOkSQGnygVnGpNGwxag = P_0;
			DeUMzDjEuoblnBqDlkWTxSKLGPmDb();
		}
	}

	static GIddwdNJpmtbemqNodSDktsnDPNCb()
	{
		BjzKyoHZexOkSQGnygVnGpNGwxag = 30;
		DeUMzDjEuoblnBqDlkWTxSKLGPmDb();
	}

	public static void cgkXQupQdACpNuqUhejBdLECPKmT()
	{
		int frameCount = Time.frameCount;
		if (XsDYyMvIbytwqNgXjJXmauDesLaw < frameCount)
		{
			DpEcTUpeUBVVMMRamUuaHhTAPPpy[wIeuoqUJdIGykTPIxNePDtROKdGh] = Time.deltaTime;
			if (WueaZNmcudYbtAcoKEAewumhBHdDA < BjzKyoHZexOkSQGnygVnGpNGwxag)
			{
				WueaZNmcudYbtAcoKEAewumhBHdDA++;
			}
			double num = 0.0;
			for (int i = 0; i < WueaZNmcudYbtAcoKEAewumhBHdDA; i++)
			{
				num += DpEcTUpeUBVVMMRamUuaHhTAPPpy[i];
			}
			ZeHlRSewigInIKcLtxdDKAUmGLIC = num / (double)WueaZNmcudYbtAcoKEAewumhBHdDA;
			wIeuoqUJdIGykTPIxNePDtROKdGh++;
			if (wIeuoqUJdIGykTPIxNePDtROKdGh >= BjzKyoHZexOkSQGnygVnGpNGwxag)
			{
				wIeuoqUJdIGykTPIxNePDtROKdGh = 0;
			}
			XsDYyMvIbytwqNgXjJXmauDesLaw = frameCount;
		}
	}

	public static void DeUMzDjEuoblnBqDlkWTxSKLGPmDb()
	{
		if (DpEcTUpeUBVVMMRamUuaHhTAPPpy == null || DpEcTUpeUBVVMMRamUuaHhTAPPpy.Length != BjzKyoHZexOkSQGnygVnGpNGwxag)
		{
			DpEcTUpeUBVVMMRamUuaHhTAPPpy = new double[BjzKyoHZexOkSQGnygVnGpNGwxag];
		}
		WueaZNmcudYbtAcoKEAewumhBHdDA = 0;
		wIeuoqUJdIGykTPIxNePDtROKdGh = 0;
		XsDYyMvIbytwqNgXjJXmauDesLaw = 0;
	}
}
