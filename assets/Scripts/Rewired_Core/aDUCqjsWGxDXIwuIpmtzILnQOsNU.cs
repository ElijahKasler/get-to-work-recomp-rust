using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal class aDUCqjsWGxDXIwuIpmtzILnQOsNU
{
	private class bNKHCrWhGwogwYYOBCNPoJzvbXYu
	{
		private ButtonStateFlags mijDIsTMYtnRbNBGIgQljNtsbwGI;

		private ButtonStateFlags fAKPWLpSOERlbTQcaxcdNceDzFod;

		private ButtonStateFlags hsNfygcFTtwIdEAKvOipdxbhuEV;

		private ButtonStateFlags dCWAamUfDOYuYmPQyfqDGMpaHwgOA;

		private uint TIHNlpRgRiwQbsUuNztLiWzOUOVg;

		private bool GsMBeXkeJGDjqIBqDDhnhQpdsOAXd;

		private bool fdOWFmimZcaMfyUvOjbrkYayQSjt;

		private bool iXNndHBdskGbWmisPevbVyBgjvgf;

		private QqSgYOWdZnQFGGSkquHvzqsuZNsj BEgySftwfHGbflWVDGoIqvwOzeV;

		public bool BGxkfyaUqjFFEsMfyYZawNskeiOV => zpKzujYAnBAnZLFWUWwhjEiaZRpg();

		public bool KlWLZUBgjdAaLCYgxNUHuJFWYIXd
		{
			get
			{
				return BSFBsmdAHjbPQLScvnpWhncJEOlgc();
			}
			set
			{
				ZOWoaBjagPVOSDxRIsYutMsvpgxd(flag);
			}
		}

		public bool zpKzujYAnBAnZLFWUWwhjEiaZRpg()
		{
			return GsMBeXkeJGDjqIBqDDhnhQpdsOAXd;
		}

		public bool BSFBsmdAHjbPQLScvnpWhncJEOlgc()
		{
			return fdOWFmimZcaMfyUvOjbrkYayQSjt;
		}

		public void ZOWoaBjagPVOSDxRIsYutMsvpgxd(bool P_0)
		{
			fdOWFmimZcaMfyUvOjbrkYayQSjt = P_0;
		}

		public ButtonStateFlags hMQggXZIMtlQfvsUILQCYGfsBWtG(bool P_0)
		{
			bool flag;
			bool flag2;
			ButtonStateFlags buttonStateFlags;
			if (P_0)
			{
				flag = (mijDIsTMYtnRbNBGIgQljNtsbwGI & ButtonStateFlags.On) != 0;
				flag2 = (fAKPWLpSOERlbTQcaxcdNceDzFod & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!fdOWFmimZcaMfyUvOjbrkYayQSjt) ? mijDIsTMYtnRbNBGIgQljNtsbwGI : ButtonStateFlags.Off);
			}
			else
			{
				flag = (hsNfygcFTtwIdEAKvOipdxbhuEV & ButtonStateFlags.On) != 0;
				flag2 = (dCWAamUfDOYuYmPQyfqDGMpaHwgOA & ButtonStateFlags.On) != 0;
				buttonStateFlags = ((!fdOWFmimZcaMfyUvOjbrkYayQSjt) ? hsNfygcFTtwIdEAKvOipdxbhuEV : ButtonStateFlags.Off);
			}
			if (flag)
			{
				if (fdOWFmimZcaMfyUvOjbrkYayQSjt)
				{
					if (flag2 && !iXNndHBdskGbWmisPevbVyBgjvgf && BEgySftwfHGbflWVDGoIqvwOzeV.ibFCRyhghkARJpZnLBpjSRhOjoVRA)
					{
						buttonStateFlags = ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
				if (iXNndHBdskGbWmisPevbVyBgjvgf && BEgySftwfHGbflWVDGoIqvwOzeV.ibFCRyhghkARJpZnLBpjSRhOjoVRA)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
				if (!flag2)
				{
					buttonStateFlags |= ButtonStateFlags.Down;
				}
			}
			else if (flag2 && !fdOWFmimZcaMfyUvOjbrkYayQSjt && !iXNndHBdskGbWmisPevbVyBgjvgf)
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		public void sWKMoUYaBJqAsXtPskiVToAEAOAI()
		{
			fAKPWLpSOERlbTQcaxcdNceDzFod = mijDIsTMYtnRbNBGIgQljNtsbwGI;
			dCWAamUfDOYuYmPQyfqDGMpaHwgOA = hsNfygcFTtwIdEAKvOipdxbhuEV;
			iXNndHBdskGbWmisPevbVyBgjvgf = fdOWFmimZcaMfyUvOjbrkYayQSjt;
			mijDIsTMYtnRbNBGIgQljNtsbwGI = ButtonStateFlags.Off;
			hsNfygcFTtwIdEAKvOipdxbhuEV = ButtonStateFlags.Off;
		}

		public void euNFLvDDInKgYGEkKDuiGSNdiEJkA(uint P_0)
		{
			if (TIHNlpRgRiwQbsUuNztLiWzOUOVg < P_0 - 1)
			{
				GsMBeXkeJGDjqIBqDDhnhQpdsOAXd = false;
			}
		}

		public void SMNcYRCLfkCFnIniBiRppFcmTEdDc(bool P_0)
		{
			HvfcWIDfRXpGsuaeeMcvTOTgpwgL((P_0 ? mijDIsTMYtnRbNBGIgQljNtsbwGI : hsNfygcFTtwIdEAKvOipdxbhuEV) | ButtonStateFlags.On, P_0);
		}

		public void HvfcWIDfRXpGsuaeeMcvTOTgpwgL(ButtonStateFlags P_0, bool P_1)
		{
			if (P_1)
			{
				mijDIsTMYtnRbNBGIgQljNtsbwGI = P_0;
			}
			else
			{
				hsNfygcFTtwIdEAKvOipdxbhuEV = P_0;
			}
			TIHNlpRgRiwQbsUuNztLiWzOUOVg = ReInput.currentFrame;
			if (!GsMBeXkeJGDjqIBqDDhnhQpdsOAXd)
			{
				GsMBeXkeJGDjqIBqDDhnhQpdsOAXd = true;
			}
		}

		public void elDdldoCpNEnjPlWoHmogCGcgQux(ref QqSgYOWdZnQFGGSkquHvzqsuZNsj P_0)
		{
			BEgySftwfHGbflWVDGoIqvwOzeV = P_0;
			fdOWFmimZcaMfyUvOjbrkYayQSjt = P_0.zuRCwOuZzjOIuFFNEgzifviEJDhl;
			iXNndHBdskGbWmisPevbVyBgjvgf = P_0.zuRCwOuZzjOIuFFNEgzifviEJDhl;
		}

		public void kUbWbnBYReXKAgblLaDlrnicSFcn()
		{
			mijDIsTMYtnRbNBGIgQljNtsbwGI = ButtonStateFlags.Off;
			fAKPWLpSOERlbTQcaxcdNceDzFod = ButtonStateFlags.Off;
			hsNfygcFTtwIdEAKvOipdxbhuEV = ButtonStateFlags.Off;
			dCWAamUfDOYuYmPQyfqDGMpaHwgOA = ButtonStateFlags.Off;
			TIHNlpRgRiwQbsUuNztLiWzOUOVg = 0u;
			GsMBeXkeJGDjqIBqDDhnhQpdsOAXd = false;
			fdOWFmimZcaMfyUvOjbrkYayQSjt = false;
			iXNndHBdskGbWmisPevbVyBgjvgf = false;
		}
	}

	public struct QqSgYOWdZnQFGGSkquHvzqsuZNsj
	{
		public bool ibFCRyhghkARJpZnLBpjSRhOjoVRA;

		public bool zuRCwOuZzjOIuFFNEgzifviEJDhl;

		public static QqSgYOWdZnQFGGSkquHvzqsuZNsj PrgQdwGPYqbBHlCofcErpBihlPOE => bzFREUGAOGwTgWakaIPKWOvjnJoA();

		public static QqSgYOWdZnQFGGSkquHvzqsuZNsj bzFREUGAOGwTgWakaIPKWOvjnJoA()
		{
			return default;
		}
	}

	[Serializable]
	private sealed class kvKbqFCQydQzedMvPGarOOWoKkiS
	{
		public static readonly kvKbqFCQydQzedMvPGarOOWoKkiS _003C_003E9 = new kvKbqFCQydQzedMvPGarOOWoKkiS();

		public static Func<bNKHCrWhGwogwYYOBCNPoJzvbXYu> _003C_003E9__22_0;

		internal aDUCqjsWGxDXIwuIpmtzILnQOsNU yEmgxIJPhRgqQIymMbzlyiQOTPdVA()
		{
			return new aDUCqjsWGxDXIwuIpmtzILnQOsNU();
		}

		internal void ISDpkhodiwFkdyFaUfVqRLLSwgxO(aDUCqjsWGxDXIwuIpmtzILnQOsNU P_0)
		{
			P_0.xgzZaAJIptIjyejETDbUzAvoQnZp();
		}

		internal bNKHCrWhGwogwYYOBCNPoJzvbXYu TyEFrOrdJbwCKFoQjBzhGFVhQwOaA()
		{
			return new bNKHCrWhGwogwYYOBCNPoJzvbXYu();
		}
	}

	private const int NSPsSWViADufCobSVfWtQBwNSjCb = 20;

	private const int qHxEqOdvvubFXTdVSdzANhMPBxqn = 10;

	private static ObjectPool<aDUCqjsWGxDXIwuIpmtzILnQOsNU> JeRCTFvFOHjKgrAFuRnWSAAVaixEA;

	private static aDUCqjsWGxDXIwuIpmtzILnQOsNU[] ZqvCaTDgVfHBAMvFJvctfxHPMvEEA;

	private static int GDTWArdnocmAgYJQiEsptfPSHxTJ;

	public int gPATQIAALxdYpMXXAAGJlgTJAmvjA;

	private UpdateLoopDataSet<bNKHCrWhGwogwYYOBCNPoJzvbXYu> VsmbUHgrBiZBQGIkWqApgLklnQnP;

	public bool BqkyXQWNLcJjNRBphAhEAZPTVgZX => ohOZkWqRjAzXTCTxHVLRCMiwymyG();

	public bool EcBDRocKjOckfePxGMNqeazamPEPD
	{
		get
		{
			return qhruBetsZzXDDpBJqWNwtuuNwXeb();
		}
		set
		{
			mcsbuZcCdaJYsSbHaCsJDLJBvxQNB(flag);
		}
	}

	static aDUCqjsWGxDXIwuIpmtzILnQOsNU()
	{
		JeRCTFvFOHjKgrAFuRnWSAAVaixEA = new ObjectPool<aDUCqjsWGxDXIwuIpmtzILnQOsNU>(20, kvKbqFCQydQzedMvPGarOOWoKkiS._003C_003E9.yEmgxIJPhRgqQIymMbzlyiQOTPdVA, kvKbqFCQydQzedMvPGarOOWoKkiS._003C_003E9.ISDpkhodiwFkdyFaUfVqRLLSwgxO);
		ZqvCaTDgVfHBAMvFJvctfxHPMvEEA = new aDUCqjsWGxDXIwuIpmtzILnQOsNU[20];
	}

	public static void ehpRDIFFjLggLXgPiiCqHwXXiTuP()
	{
		GDTWArdnocmAgYJQiEsptfPSHxTJ = 0;
		Array.Clear(ZqvCaTDgVfHBAMvFJvctfxHPMvEEA, 0, ZqvCaTDgVfHBAMvFJvctfxHPMvEEA.Length);
		JeRCTFvFOHjKgrAFuRnWSAAVaixEA.Clear();
	}

	public static aDUCqjsWGxDXIwuIpmtzILnQOsNU XwRyTksJzqYYxmCPxRSBhVUpgmdr(int P_0)
	{
		for (int i = 0; i < GDTWArdnocmAgYJQiEsptfPSHxTJ; i++)
		{
			if (ZqvCaTDgVfHBAMvFJvctfxHPMvEEA[i] != null && ZqvCaTDgVfHBAMvFJvctfxHPMvEEA[i].gPATQIAALxdYpMXXAAGJlgTJAmvjA == P_0)
			{
				return ZqvCaTDgVfHBAMvFJvctfxHPMvEEA[i];
			}
		}
		return null;
	}

	public static aDUCqjsWGxDXIwuIpmtzILnQOsNU jINDQHrRKJzHKYFAuIzfWuflMMYt(int P_0, QqSgYOWdZnQFGGSkquHvzqsuZNsj P_1)
	{
		aDUCqjsWGxDXIwuIpmtzILnQOsNU aDUCqjsWGxDXIwuIpmtzILnQOsNU2 = XwRyTksJzqYYxmCPxRSBhVUpgmdr(P_0);
		if (aDUCqjsWGxDXIwuIpmtzILnQOsNU2 != null)
		{
			return aDUCqjsWGxDXIwuIpmtzILnQOsNU2;
		}
		aDUCqjsWGxDXIwuIpmtzILnQOsNU2 = JeRCTFvFOHjKgrAFuRnWSAAVaixEA.Get();
		aDUCqjsWGxDXIwuIpmtzILnQOsNU2.lszqNukBTtcaiShXRQXiWydSwdUe(P_0);
		aDUCqjsWGxDXIwuIpmtzILnQOsNU2.PhbOWVqlLxhTgqOiwKXHZJrPObrh(ref P_1);
		aDUCqjsWGxDXIwuIpmtzILnQOsNU2.VsmbUHgrBiZBQGIkWqApgLklnQnP.SetUpdateLoop(ReInput.currentUpdateLoop);
		SBAoJUlJxGvQxmihQtKiEpcIRUwI(aDUCqjsWGxDXIwuIpmtzILnQOsNU2);
		return aDUCqjsWGxDXIwuIpmtzILnQOsNU2;
	}

	public static void xggZiVEAkgrxjxEQESKEagoiJQzq(UpdateLoopType P_0)
	{
		for (int i = 0; i < GDTWArdnocmAgYJQiEsptfPSHxTJ; i++)
		{
			if (ZqvCaTDgVfHBAMvFJvctfxHPMvEEA[i] != null)
			{
				ZqvCaTDgVfHBAMvFJvctfxHPMvEEA[i].gcKXEItTFiPCmNRwKNWmIfzHVnbj(P_0);
			}
		}
	}

	public static void dKVhHtzJibGYJaTbVmBVNUnvZeeT(UpdateLoopType P_0, uint P_1)
	{
		for (int num = GDTWArdnocmAgYJQiEsptfPSHxTJ - 1; num >= 0; num--)
		{
			if (ZqvCaTDgVfHBAMvFJvctfxHPMvEEA[num] == null)
			{
				if (num == GDTWArdnocmAgYJQiEsptfPSHxTJ - 1)
				{
					GDTWArdnocmAgYJQiEsptfPSHxTJ--;
				}
			}
			else
			{
				ZqvCaTDgVfHBAMvFJvctfxHPMvEEA[num].AXhoUIqbucgyCyGpQXzcXgfrRLUb(P_1);
				if (!ZqvCaTDgVfHBAMvFJvctfxHPMvEEA[num].ohOZkWqRjAzXTCTxHVLRCMiwymyG())
				{
					THqwllXcjfxopxhsFEGfobCKvEnR(num);
				}
			}
		}
	}

	private static void SBAoJUlJxGvQxmihQtKiEpcIRUwI(aDUCqjsWGxDXIwuIpmtzILnQOsNU P_0)
	{
		int num = fCQAeiHIczQuxbhZvVbQAaAbhUzPA();
		if (num < 0)
		{
			if (GDTWArdnocmAgYJQiEsptfPSHxTJ == ZqvCaTDgVfHBAMvFJvctfxHPMvEEA.Length)
			{
				aDUCqjsWGxDXIwuIpmtzILnQOsNU[] zqvCaTDgVfHBAMvFJvctfxHPMvEEA = ZqvCaTDgVfHBAMvFJvctfxHPMvEEA;
				ZqvCaTDgVfHBAMvFJvctfxHPMvEEA = new aDUCqjsWGxDXIwuIpmtzILnQOsNU[ZqvCaTDgVfHBAMvFJvctfxHPMvEEA.Length + 10];
				Array.Copy(zqvCaTDgVfHBAMvFJvctfxHPMvEEA, ZqvCaTDgVfHBAMvFJvctfxHPMvEEA, zqvCaTDgVfHBAMvFJvctfxHPMvEEA.Length);
			}
			num = GDTWArdnocmAgYJQiEsptfPSHxTJ;
			GDTWArdnocmAgYJQiEsptfPSHxTJ++;
		}
		ZqvCaTDgVfHBAMvFJvctfxHPMvEEA[num] = P_0;
	}

	private static void THqwllXcjfxopxhsFEGfobCKvEnR(int P_0)
	{
		if (P_0 >= 0 && P_0 < GDTWArdnocmAgYJQiEsptfPSHxTJ)
		{
			aDUCqjsWGxDXIwuIpmtzILnQOsNU aDUCqjsWGxDXIwuIpmtzILnQOsNU2 = ZqvCaTDgVfHBAMvFJvctfxHPMvEEA[P_0];
			if (aDUCqjsWGxDXIwuIpmtzILnQOsNU2 != null)
			{
				JeRCTFvFOHjKgrAFuRnWSAAVaixEA.Return(aDUCqjsWGxDXIwuIpmtzILnQOsNU2);
				ZqvCaTDgVfHBAMvFJvctfxHPMvEEA[P_0] = null;
			}
			if (P_0 == GDTWArdnocmAgYJQiEsptfPSHxTJ - 1)
			{
				GDTWArdnocmAgYJQiEsptfPSHxTJ--;
			}
		}
	}

	private static int fCQAeiHIczQuxbhZvVbQAaAbhUzPA()
	{
		for (int i = 0; i < GDTWArdnocmAgYJQiEsptfPSHxTJ; i++)
		{
			if (ZqvCaTDgVfHBAMvFJvctfxHPMvEEA[i] == null)
			{
				return i;
			}
		}
		if (GDTWArdnocmAgYJQiEsptfPSHxTJ >= ZqvCaTDgVfHBAMvFJvctfxHPMvEEA.Length)
		{
			return -1;
		}
		int gDTWArdnocmAgYJQiEsptfPSHxTJ = GDTWArdnocmAgYJQiEsptfPSHxTJ;
		GDTWArdnocmAgYJQiEsptfPSHxTJ++;
		return gDTWArdnocmAgYJQiEsptfPSHxTJ;
	}

	public bool ohOZkWqRjAzXTCTxHVLRCMiwymyG()
	{
		int count = VsmbUHgrBiZBQGIkWqApgLklnQnP.Count;
		for (int i = 0; i < count; i++)
		{
			if (VsmbUHgrBiZBQGIkWqApgLklnQnP[i].zpKzujYAnBAnZLFWUWwhjEiaZRpg())
			{
				return true;
			}
		}
		return false;
	}

	public bool qhruBetsZzXDDpBJqWNwtuuNwXeb()
	{
		return VsmbUHgrBiZBQGIkWqApgLklnQnP.Current.BSFBsmdAHjbPQLScvnpWhncJEOlgc();
	}

	public void mcsbuZcCdaJYsSbHaCsJDLJBvxQNB(bool P_0)
	{
		VsmbUHgrBiZBQGIkWqApgLklnQnP.Current.ZOWoaBjagPVOSDxRIsYutMsvpgxd(P_0);
	}

	public ButtonStateFlags ZQsbdMorGuRtmeFmXBrsodfTimOg(bool P_0)
	{
		return VsmbUHgrBiZBQGIkWqApgLklnQnP.Current.hMQggXZIMtlQfvsUILQCYGfsBWtG(P_0);
	}

	public aDUCqjsWGxDXIwuIpmtzILnQOsNU()
	{
		VsmbUHgrBiZBQGIkWqApgLklnQnP = new UpdateLoopDataSet<bNKHCrWhGwogwYYOBCNPoJzvbXYu>(ReInput.UserData.ConfigVars.updateLoop, kvKbqFCQydQzedMvPGarOOWoKkiS._003C_003E9.TyEFrOrdJbwCKFoQjBzhGFVhQwOaA);
		xgzZaAJIptIjyejETDbUzAvoQnZp();
	}

	public void gcKXEItTFiPCmNRwKNWmIfzHVnbj(UpdateLoopType P_0)
	{
		VsmbUHgrBiZBQGIkWqApgLklnQnP.SetUpdateLoop(P_0);
		VsmbUHgrBiZBQGIkWqApgLklnQnP.Current.sWKMoUYaBJqAsXtPskiVToAEAOAI();
	}

	public void AXhoUIqbucgyCyGpQXzcXgfrRLUb(uint P_0)
	{
		VsmbUHgrBiZBQGIkWqApgLklnQnP.Current.euNFLvDDInKgYGEkKDuiGSNdiEJkA(P_0);
	}

	public void oUSIzBHVpVfPhueavwGeuAVwhNmb(UpdateLoopType P_0, bool P_1)
	{
		VsmbUHgrBiZBQGIkWqApgLklnQnP.Current.SMNcYRCLfkCFnIniBiRppFcmTEdDc(P_1);
	}

	public void vCNTahVJpmsRyMVMqQQEksdVewhQ(UpdateLoopType P_0, ButtonStateFlags P_1, bool P_2)
	{
		VsmbUHgrBiZBQGIkWqApgLklnQnP.Current.HvfcWIDfRXpGsuaeeMcvTOTgpwgL(P_1, P_2);
	}

	private void PhbOWVqlLxhTgqOiwKXHZJrPObrh(ref QqSgYOWdZnQFGGSkquHvzqsuZNsj P_0)
	{
		int count = VsmbUHgrBiZBQGIkWqApgLklnQnP.Count;
		for (int i = 0; i < count; i++)
		{
			VsmbUHgrBiZBQGIkWqApgLklnQnP[i].elDdldoCpNEnjPlWoHmogCGcgQux(ref P_0);
		}
	}

	private void lszqNukBTtcaiShXRQXiWydSwdUe(int P_0)
	{
		gPATQIAALxdYpMXXAAGJlgTJAmvjA = P_0;
	}

	private void xgzZaAJIptIjyejETDbUzAvoQnZp()
	{
		gPATQIAALxdYpMXXAAGJlgTJAmvjA = -1;
		int count = VsmbUHgrBiZBQGIkWqApgLklnQnP.Count;
		for (int i = 0; i < count; i++)
		{
			VsmbUHgrBiZBQGIkWqApgLklnQnP[i].kUbWbnBYReXKAgblLaDlrnicSFcn();
		}
	}
}
