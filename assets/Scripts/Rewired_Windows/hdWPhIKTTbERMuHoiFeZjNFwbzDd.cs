using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class hdWPhIKTTbERMuHoiFeZjNFwbzDd : xFzHDFSyNbPwIvMoVIGdIBQQcGBbA
{
	[CompilerGenerated]
	private HnxtVRnCvjVmbaqoGdOjbvZkvWiMA[] daIIpuWPAnaHeEBYFminMKGbVCasA;

	public HnxtVRnCvjVmbaqoGdOjbvZkvWiMA[] mIPPDASFFpaBnKvMZwFkRRmltUEv
	{
		get
		{
			return KlVkqHcWDBICySSYGEMdbKuCuWvI();
		}
		set
		{
			EFJzrEroMxRLnAYIHvyrhuksfgCT(array);
		}
	}

	int JDRFJgfEmiRFDHfzBcOxhNzICAZiB => JDRFJgfEmiRFDHfzBcOxhNzICAZiB();

	protected unsafe virtual xFzHDFSyNbPwIvMoVIGdIBQQcGBbA IUOhFHDaLrAmPdyHrpGpVwSwthie(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(HnxtVRnCvjVmbaqoGdOjbvZkvWiMA) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(HnxtVRnCvjVmbaqoGdOjbvZkvWiMA);
		EFJzrEroMxRLnAYIHvyrhuksfgCT(new HnxtVRnCvjVmbaqoGdOjbvZkvWiMA[num]);
		fixed (HnxtVRnCvjVmbaqoGdOjbvZkvWiMA* ptr = KlVkqHcWDBICySSYGEMdbKuCuWvI())
		{
			RhoSDdlPwZIYTHXfVerjMzvHNyu.dWlelPvDnffEDkNcpycixCsIwBxD((IntPtr)ptr, P_1, RhoSDdlPwZIYTHXfVerjMzvHNyu.KXTeKHRDKCkKHTFGjDajCuUiyxEgA<HnxtVRnCvjVmbaqoGdOjbvZkvWiMA>() * KlVkqHcWDBICySSYGEMdbKuCuWvI().Length);
		}
		return this;
	}

	internal unsafe virtual IntPtr JZXCSLyeCIEcjDDudKzTpYRjadJg()
	{
		if (JDRFJgfEmiRFDHfzBcOxhNzICAZiB() == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(JDRFJgfEmiRFDHfzBcOxhNzICAZiB());
		fixed (HnxtVRnCvjVmbaqoGdOjbvZkvWiMA* ptr = KlVkqHcWDBICySSYGEMdbKuCuWvI())
		{
			RhoSDdlPwZIYTHXfVerjMzvHNyu.dWlelPvDnffEDkNcpycixCsIwBxD(intPtr, (IntPtr)ptr, RhoSDdlPwZIYTHXfVerjMzvHNyu.KXTeKHRDKCkKHTFGjDajCuUiyxEgA<HnxtVRnCvjVmbaqoGdOjbvZkvWiMA>() * KlVkqHcWDBICySSYGEMdbKuCuWvI().Length);
		}
		return intPtr;
	}

	public HnxtVRnCvjVmbaqoGdOjbvZkvWiMA[] KlVkqHcWDBICySSYGEMdbKuCuWvI()
	{
		return daIIpuWPAnaHeEBYFminMKGbVCasA;
	}

	public void EFJzrEroMxRLnAYIHvyrhuksfgCT(HnxtVRnCvjVmbaqoGdOjbvZkvWiMA[] P_0)
	{
		daIIpuWPAnaHeEBYFminMKGbVCasA = P_0;
	}

	public unsafe override int JDRFJgfEmiRFDHfzBcOxhNzICAZiB()
	{
		if (KlVkqHcWDBICySSYGEMdbKuCuWvI() == null)
		{
			return 0;
		}
		return KlVkqHcWDBICySSYGEMdbKuCuWvI().Length * sizeof(HnxtVRnCvjVmbaqoGdOjbvZkvWiMA);
	}
}
