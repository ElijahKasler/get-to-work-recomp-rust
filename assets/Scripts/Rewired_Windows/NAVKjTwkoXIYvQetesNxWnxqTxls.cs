using System.Collections.Generic;
using Rewired.Utils;

internal class NAVKjTwkoXIYvQetesNxWnxqTxls : jfiYOmiCliAgpTQDaXNSlqZHTnCm
{
	private List<aXZARczpoiPkbwslxZFFTdHzcIyo> bGKIajFLoqilXtiSqEzxHKOOkdQL;

	private aXZARczpoiPkbwslxZFFTdHzcIyo[] RbIOUxHzxbxonKMDYKeGGCRKvbog;

	private bool JAaMGFrfNmccPZLxvCcUGINMnLtmA;

	public NAVKjTwkoXIYvQetesNxWnxqTxls()
	{
		bGKIajFLoqilXtiSqEzxHKOOkdQL = new List<aXZARczpoiPkbwslxZFFTdHzcIyo>();
	}

	public virtual void xzWBuOCHtyJVuFsXKnzKuLtZcCUh(aXZARczpoiPkbwslxZFFTdHzcIyo P_0)
	{
		bGKIajFLoqilXtiSqEzxHKOOkdQL.Add(P_0);
	}

	public float eRlHXvAvTlOnQwIaNelFvRYqPthR(int P_0)
	{
		if (P_0 < 0 || P_0 >= RbIOUxHzxbxonKMDYKeGGCRKvbog.Length)
		{
			return 0f;
		}
		return JuRfaUUiWMMEiUTuDPpgmzowaeTm(RbIOUxHzxbxonKMDYKeGGCRKvbog[P_0].AcgXDGYYCtgoFNqAqoRlsCggLNLG());
	}

	public int NRXaxuCHNrJeVwbLCzhzXJsmCZLu(int P_0)
	{
		if (P_0 < 0 || P_0 >= RbIOUxHzxbxonKMDYKeGGCRKvbog.Length)
		{
			return 0;
		}
		return (int)RbIOUxHzxbxonKMDYKeGGCRKvbog[P_0].UvImJlslbyBQFjsWokWSYbKOCvY;
	}

	public virtual void uNWXMTDBZbWKwJnMoeNokulUTLGV()
	{
		if (!JAaMGFrfNmccPZLxvCcUGINMnLtmA)
		{
			JAaMGFrfNmccPZLxvCcUGINMnLtmA = true;
			RbIOUxHzxbxonKMDYKeGGCRKvbog = bGKIajFLoqilXtiSqEzxHKOOkdQL.ToArray();
			bGKIajFLoqilXtiSqEzxHKOOkdQL = null;
		}
	}

	private static float JuRfaUUiWMMEiUTuDPpgmzowaeTm(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
