using Rewired.Utils.Classes.Data;

internal class CZoMFTjfkBKcdHwbjLAHvGhrFKlm : xRwbEhgwfqETGQkYCofyzWNojclTA
{
	public int dTQHRiEEtveNlbsgUUEvIFKkPFwcb;

	public double aNEeWmeXYOlbEmcgceEhkMzmMxGvA;

	public readonly int nJPRSmwRzRwieUCncJNUUeyFGnpq;

	public readonly int csCDcuMJGfrgZgKANfBjxNZlDQnw;

	public readonly bool jtWSHfInowWtCnlMebgCMNywDHDQ;

	public readonly int XAtGVaGwrtnphnemRzwUJOVMWuax;

	public readonly int MkTApxmoCvhRlGAIuNoLhfTQUaVgA;

	public readonly int GzqrYWsWsfiEWGaOLrSnzKpFzGoG;

	public CZoMFTjfkBKcdHwbjLAHvGhrFKlm(byte P_0, HIDInfo P_1, bool P_2, int P_3)
		: base(P_0, P_1)
	{
		nJPRSmwRzRwieUCncJNUUeyFGnpq = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		csCDcuMJGfrgZgKANfBjxNZlDQnw = P_1.dataIndex;
		jtWSHfInowWtCnlMebgCMNywDHDQ = P_2;
		XAtGVaGwrtnphnemRzwUJOVMWuax = P_1.logicalMin;
		MkTApxmoCvhRlGAIuNoLhfTQUaVgA = P_1.logicalMax;
		GzqrYWsWsfiEWGaOLrSnzKpFzGoG = P_3;
	}

	public virtual void GeEVCiZbuNAEJfLteYjEECXlAusnA(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != XQJfIVDejXjKZacOcIRDbWrSMhxzb)
		{
			return;
		}
		aNEeWmeXYOlbEmcgceEhkMzmMxGvA = P_1;
		int num = 0;
		if (nJPRSmwRzRwieUCncJNUUeyFGnpq > 1)
		{
			for (int i = 0; i < nJPRSmwRzRwieUCncJNUUeyFGnpq; i++)
			{
				num |= P_0[csCDcuMJGfrgZgKANfBjxNZlDQnw + i] << 8 * i;
			}
		}
		else
		{
			num = P_0[csCDcuMJGfrgZgKANfBjxNZlDQnw];
		}
		dTQHRiEEtveNlbsgUUEvIFKkPFwcb = num;
	}
}
