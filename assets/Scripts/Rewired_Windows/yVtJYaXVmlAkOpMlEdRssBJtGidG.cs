using System;
using Rewired.Utils.Classes.Data;

internal class yVtJYaXVmlAkOpMlEdRssBJtGidG : xRwbEhgwfqETGQkYCofyzWNojclTA
{
	public enum smSjXVnxVROmxzZQYqZrhORbaWgT
	{
		Default = 0,
		Custom = 1
	}

	public int EcAGAlDLxBGWlSSdJRGPahGHEDpjc;

	public double bjEqhBebiAvOmcVJYyyGesTCczj;

	public readonly int iVOAJBDiRTYYNpptvQtqiyqlTyOkA;

	public readonly int RuBEShDihxwkKicTTcYXXbZtbIqFA;

	public readonly smSjXVnxVROmxzZQYqZrhORbaWgT jGMMlKsanttfMpKVCCNXfAWzeAVEb;

	private Func<int, int> jNwVkoNRBooDFppTfOAxpGnvTuwM;

	public yVtJYaXVmlAkOpMlEdRssBJtGidG(byte P_0, HIDInfo P_1, smSjXVnxVROmxzZQYqZrhORbaWgT P_2)
		: base(P_0, P_1)
	{
		jGMMlKsanttfMpKVCCNXfAWzeAVEb = P_2;
		iVOAJBDiRTYYNpptvQtqiyqlTyOkA = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		RuBEShDihxwkKicTTcYXXbZtbIqFA = P_1.dataIndex;
	}

	public yVtJYaXVmlAkOpMlEdRssBJtGidG(byte P_0, HIDInfo P_1, Func<int, int> P_2)
		: this(P_0, P_1, smSjXVnxVROmxzZQYqZrhORbaWgT.Custom)
	{
		jNwVkoNRBooDFppTfOAxpGnvTuwM = P_2;
	}

	public virtual void NWzMgBcatRtRDzKIhQwdRduPltic(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != XQJfIVDejXjKZacOcIRDbWrSMhxzb)
		{
			return;
		}
		bjEqhBebiAvOmcVJYyyGesTCczj = P_1;
		if (iVOAJBDiRTYYNpptvQtqiyqlTyOkA == 1)
		{
			EcAGAlDLxBGWlSSdJRGPahGHEDpjc = P_0[RuBEShDihxwkKicTTcYXXbZtbIqFA];
		}
		else
		{
			EcAGAlDLxBGWlSSdJRGPahGHEDpjc = 0;
			for (int i = 0; i < iVOAJBDiRTYYNpptvQtqiyqlTyOkA; i++)
			{
				EcAGAlDLxBGWlSSdJRGPahGHEDpjc |= P_0[RuBEShDihxwkKicTTcYXXbZtbIqFA + i] << 8 * i;
			}
		}
		if (jGMMlKsanttfMpKVCCNXfAWzeAVEb == smSjXVnxVROmxzZQYqZrhORbaWgT.Custom && jNwVkoNRBooDFppTfOAxpGnvTuwM != null)
		{
			EcAGAlDLxBGWlSSdJRGPahGHEDpjc = jNwVkoNRBooDFppTfOAxpGnvTuwM(EcAGAlDLxBGWlSSdJRGPahGHEDpjc);
		}
	}
}
