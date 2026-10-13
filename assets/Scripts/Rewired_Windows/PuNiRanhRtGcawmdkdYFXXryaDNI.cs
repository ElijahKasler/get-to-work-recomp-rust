using System;
using Rewired.Utils.Classes.Data;

internal class PuNiRanhRtGcawmdkdYFXXryaDNI : xRwbEhgwfqETGQkYCofyzWNojclTA
{
	public readonly float[] kHKNsnXlXktGYBPiLEFMIeDjXJlhA;

	public double opCaVDphEzjYehoOtMPPOhUEltpmA;

	public readonly int lqrjHOrYQIwCeTxhjbjUgPeLGwOh;

	private readonly byte[] XxXhBhErUYiOGQKLEblekokUHcIKA;

	private readonly int JoqAQQJAVOHJDYmYHqMozhPkdqRc;

	private readonly int THreYSgDuMzxWimbTMCyPhAlVRTp;

	private readonly Action<byte[], float[]> tLJrFgRvDJtqGIlTqTeDmYNHBHcf;

	public PuNiRanhRtGcawmdkdYFXXryaDNI(byte P_0, HIDInfo P_1, int P_2, Action<byte[], float[]> P_3)
		: base(P_0, P_1)
	{
		lqrjHOrYQIwCeTxhjbjUgPeLGwOh = P_2;
		tLJrFgRvDJtqGIlTqTeDmYNHBHcf = P_3;
		JoqAQQJAVOHJDYmYHqMozhPkdqRc = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		THreYSgDuMzxWimbTMCyPhAlVRTp = P_1.dataIndex;
		XxXhBhErUYiOGQKLEblekokUHcIKA = new byte[JoqAQQJAVOHJDYmYHqMozhPkdqRc];
		kHKNsnXlXktGYBPiLEFMIeDjXJlhA = new float[P_2];
	}

	public virtual void zogBFZdjwobnSMaamiIqUyqAbQfjA(NativeBuffer P_0, double P_1)
	{
		if (P_0 != null && P_0[0] == XQJfIVDejXjKZacOcIRDbWrSMhxzb)
		{
			opCaVDphEzjYehoOtMPPOhUEltpmA = P_1;
			for (int i = 0; i < JoqAQQJAVOHJDYmYHqMozhPkdqRc; i++)
			{
				XxXhBhErUYiOGQKLEblekokUHcIKA[i] = P_0[THreYSgDuMzxWimbTMCyPhAlVRTp + i];
			}
			if (tLJrFgRvDJtqGIlTqTeDmYNHBHcf != null)
			{
				tLJrFgRvDJtqGIlTqTeDmYNHBHcf(XxXhBhErUYiOGQKLEblekokUHcIKA, kHKNsnXlXktGYBPiLEFMIeDjXJlhA);
			}
		}
	}

	public void RYvLVpEbNYQMZmewQToPqZmvRcBp(float[] P_0, double P_1)
	{
		opCaVDphEzjYehoOtMPPOhUEltpmA = P_1;
		for (int i = 0; i < lqrjHOrYQIwCeTxhjbjUgPeLGwOh; i++)
		{
			kHKNsnXlXktGYBPiLEFMIeDjXJlhA[i] = P_0[i];
		}
	}
}
