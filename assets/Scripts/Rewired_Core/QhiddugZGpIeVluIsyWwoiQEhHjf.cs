using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

internal class QhiddugZGpIeVluIsyWwoiQEhHjf
{
	private class HKNpPMcDRvjrWjLIDGjvGlEGbdctA
	{
		private class ZhBdLrxVhaDjFIhPaohczZUexJGP
		{
			private int jsVgsRFhPbvlbbJLEiANiGOqSSIQ;

			private XwHwMktEhYXiYLmcUfwRTkYQYgAU[] GmrRSzfpbYgwAdrZOBciebkIaKYJb;

			private WNUAsAtXkBsDkcrXVNFLvtgmCfuS[] XSEiDNioKVgQbcBUbkWrDaCAgDYxA;

			public ZhBdLrxVhaDjFIhPaohczZUexJGP(int P_0)
			{
				jsVgsRFhPbvlbbJLEiANiGOqSSIQ = P_0;
				GmrRSzfpbYgwAdrZOBciebkIaKYJb = new XwHwMktEhYXiYLmcUfwRTkYQYgAU[20];
				for (int i = 0; i < GmrRSzfpbYgwAdrZOBciebkIaKYJb.Length; i++)
				{
					GmrRSzfpbYgwAdrZOBciebkIaKYJb[i] = new XwHwMktEhYXiYLmcUfwRTkYQYgAU();
				}
				XSEiDNioKVgQbcBUbkWrDaCAgDYxA = new WNUAsAtXkBsDkcrXVNFLvtgmCfuS[29];
				for (int j = 0; j < XSEiDNioKVgQbcBUbkWrDaCAgDYxA.Length; j++)
				{
					XSEiDNioKVgQbcBUbkWrDaCAgDYxA[j] = new WNUAsAtXkBsDkcrXVNFLvtgmCfuS(j);
				}
			}

			public void rQPJaiAtDOoitIioBVZPSRmOQdTW()
			{
				for (int i = 0; i < GmrRSzfpbYgwAdrZOBciebkIaKYJb.Length; i++)
				{
					bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(jsVgsRFhPbvlbbJLEiANiGOqSSIQ, i);
					GmrRSzfpbYgwAdrZOBciebkIaKYJb[i].vuLurnSlATlgimyKMxrmNLVXORqJ(joystickButtonValueByJoystickIndex);
				}
				for (int j = 0; j < XSEiDNioKVgQbcBUbkWrDaCAgDYxA.Length; j++)
				{
					float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(jsVgsRFhPbvlbbJLEiANiGOqSSIQ, j);
					XSEiDNioKVgQbcBUbkWrDaCAgDYxA[j].FYZbrtdSVlzpATPIIFYqIqGlNHEn(joystickAxisRawValueByJoystickIndex);
				}
			}

			public void VOYpUURCKSbMeApEmcOUhswfPuysA()
			{
				for (int i = 0; i < GmrRSzfpbYgwAdrZOBciebkIaKYJb.Length; i++)
				{
					GmrRSzfpbYgwAdrZOBciebkIaKYJb[i].pzFfOrBUMmdgQjHLYBIFkASBkPIu(UnityInputHelper.GetJoystickButtonValueByJoystickIndex(jsVgsRFhPbvlbbJLEiANiGOqSSIQ, i));
				}
				for (int j = 0; j < XSEiDNioKVgQbcBUbkWrDaCAgDYxA.Length; j++)
				{
					XSEiDNioKVgQbcBUbkWrDaCAgDYxA[j].PDrTRbQuOQwSyuLpNLrOapPomtAi(UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(jsVgsRFhPbvlbbJLEiANiGOqSSIQ, j));
				}
			}

			public bool HuVOiSTswZAHcHjlnWFyTjnByTtf(int P_0)
			{
				if (P_0 < 0 || P_0 >= GmrRSzfpbYgwAdrZOBciebkIaKYJb.Length)
				{
					return false;
				}
				return GmrRSzfpbYgwAdrZOBciebkIaKYJb[P_0].aFJVqJRWbSkjnYFhXqGpqGmdCKKAA();
			}

			public bool atercahVlGvPsikfvZAHYcbEuNgE(int P_0)
			{
				if (P_0 < 0 || P_0 >= GmrRSzfpbYgwAdrZOBciebkIaKYJb.Length)
				{
					return false;
				}
				return GmrRSzfpbYgwAdrZOBciebkIaKYJb[P_0].LoLPMMNcYfBfEyKGljhphgyXEpWD();
			}

			public bool UaHadpdPHmytHsWxifcvmPWHljZEb(int P_0)
			{
				if (P_0 < 0 || P_0 >= GmrRSzfpbYgwAdrZOBciebkIaKYJb.Length)
				{
					return false;
				}
				return GmrRSzfpbYgwAdrZOBciebkIaKYJb[P_0].cIypZAVISLkXgoYUXRPGHAxuSGnU();
			}

			public float lHzFikhEPnsEGXsrtCSxkZTKSvAOA(int P_0)
			{
				if (P_0 < 0 || P_0 >= XSEiDNioKVgQbcBUbkWrDaCAgDYxA.Length)
				{
					return 0f;
				}
				return XSEiDNioKVgQbcBUbkWrDaCAgDYxA[P_0].AGZwPldleHdVLgyYMMiYqDLNjzUEA();
			}

			public bool WQGXFCIMendmhanjmpFadoqHpnBrB(int P_0, bool P_1)
			{
				if (P_0 < 0 || P_0 >= XSEiDNioKVgQbcBUbkWrDaCAgDYxA.Length)
				{
					return false;
				}
				return XSEiDNioKVgQbcBUbkWrDaCAgDYxA[P_0].XUsXPEmkFBmiavPJbkesQeOHGqRAA(P_1);
			}

			public void QTdUfEhDTQdAZWOHYrpjqdMichVBA()
			{
				for (int i = 0; i < GmrRSzfpbYgwAdrZOBciebkIaKYJb.Length; i++)
				{
					GmrRSzfpbYgwAdrZOBciebkIaKYJb[i].GgTDnggGapgzeQaZvtusknSWQcGFA();
				}
				for (int j = 0; j < XSEiDNioKVgQbcBUbkWrDaCAgDYxA.Length; j++)
				{
					XSEiDNioKVgQbcBUbkWrDaCAgDYxA[j].FMEwvAaGxuTaFSqrnJZdjlmyQQSA();
				}
			}
		}

		private class UNdMPHhBSKcmLlyQILcjFdzDGyIEA
		{
			private XwHwMktEhYXiYLmcUfwRTkYQYgAU[] hhZohgytNqRiUczQcIuHgJVnDoyAA;

			public UNdMPHhBSKcmLlyQILcjFdzDGyIEA()
			{
				hhZohgytNqRiUczQcIuHgJVnDoyAA = new XwHwMktEhYXiYLmcUfwRTkYQYgAU[7];
				for (int i = 0; i < hhZohgytNqRiUczQcIuHgJVnDoyAA.Length; i++)
				{
					hhZohgytNqRiUczQcIuHgJVnDoyAA[i] = new XwHwMktEhYXiYLmcUfwRTkYQYgAU();
				}
			}

			public void BJxJSMZcJAIQFDJUSZmXOwWMBeLJA()
			{
				for (int i = 0; i < hhZohgytNqRiUczQcIuHgJVnDoyAA.Length; i++)
				{
					hhZohgytNqRiUczQcIuHgJVnDoyAA[i].pzFfOrBUMmdgQjHLYBIFkASBkPIu(Input.GetButton("MouseButton" + i));
				}
			}

			public bool HTnltozhOziiCeLLOvoDwXwDeJKuA(int P_0)
			{
				if (P_0 < 0 || P_0 >= hhZohgytNqRiUczQcIuHgJVnDoyAA.Length)
				{
					return false;
				}
				return hhZohgytNqRiUczQcIuHgJVnDoyAA[P_0].aFJVqJRWbSkjnYFhXqGpqGmdCKKAA();
			}

			public bool dKvsSTehDSIdgXfjjtLYLMJYGCLt(int P_0)
			{
				if (P_0 < 0 || P_0 >= hhZohgytNqRiUczQcIuHgJVnDoyAA.Length)
				{
					return false;
				}
				return hhZohgytNqRiUczQcIuHgJVnDoyAA[P_0].LoLPMMNcYfBfEyKGljhphgyXEpWD();
			}

			public bool EGqRpECiLKmDeTrMGAXAeaQJpjTvA(int P_0)
			{
				if (P_0 < 0 || P_0 >= hhZohgytNqRiUczQcIuHgJVnDoyAA.Length)
				{
					return false;
				}
				return hhZohgytNqRiUczQcIuHgJVnDoyAA[P_0].cIypZAVISLkXgoYUXRPGHAxuSGnU();
			}

			public void NWikeLduhiLNBUMMjRQwaArTFWXd()
			{
				for (int i = 0; i < hhZohgytNqRiUczQcIuHgJVnDoyAA.Length; i++)
				{
					hhZohgytNqRiUczQcIuHgJVnDoyAA[i].GgTDnggGapgzeQaZvtusknSWQcGFA();
				}
			}
		}

		private class XwHwMktEhYXiYLmcUfwRTkYQYgAU
		{
			private bool wZOaJzbSVqfowBUOgkXPaxqDyKCkb;

			private bool KctnmLPixJfENTouMXkSLMAVaPcCA;

			public bool nBwUltKjSXAmdWeqQHjTwrkXjwbw
			{
				get
				{
					return aFJVqJRWbSkjnYFhXqGpqGmdCKKAA();
				}
				set
				{
					pzFfOrBUMmdgQjHLYBIFkASBkPIu(flag);
				}
			}

			public bool ogMbrdSkgCMFRJaEXZqZyXSYSHAN => LoLPMMNcYfBfEyKGljhphgyXEpWD();

			public bool XCxYjYguCRoKGCGJBOWcMOTBkMNV => cIypZAVISLkXgoYUXRPGHAxuSGnU();

			public bool aFJVqJRWbSkjnYFhXqGpqGmdCKKAA()
			{
				return wZOaJzbSVqfowBUOgkXPaxqDyKCkb;
			}

			public void pzFfOrBUMmdgQjHLYBIFkASBkPIu(bool P_0)
			{
				KctnmLPixJfENTouMXkSLMAVaPcCA = wZOaJzbSVqfowBUOgkXPaxqDyKCkb;
				wZOaJzbSVqfowBUOgkXPaxqDyKCkb = P_0;
			}

			public bool LoLPMMNcYfBfEyKGljhphgyXEpWD()
			{
				if (wZOaJzbSVqfowBUOgkXPaxqDyKCkb)
				{
					return !KctnmLPixJfENTouMXkSLMAVaPcCA;
				}
				return false;
			}

			public bool cIypZAVISLkXgoYUXRPGHAxuSGnU()
			{
				if (KctnmLPixJfENTouMXkSLMAVaPcCA)
				{
					return !wZOaJzbSVqfowBUOgkXPaxqDyKCkb;
				}
				return false;
			}

			public void vuLurnSlATlgimyKMxrmNLVXORqJ(bool P_0)
			{
				wZOaJzbSVqfowBUOgkXPaxqDyKCkb = P_0;
				KctnmLPixJfENTouMXkSLMAVaPcCA = P_0;
			}

			public void GgTDnggGapgzeQaZvtusknSWQcGFA()
			{
				wZOaJzbSVqfowBUOgkXPaxqDyKCkb = false;
				KctnmLPixJfENTouMXkSLMAVaPcCA = false;
			}
		}

		private class WNUAsAtXkBsDkcrXVNFLvtgmCfuS
		{
			private int XdmUSIQSVifQPQyTDTXxHBhkiJwh;

			private float YSFUOJdmSHaQJCVfrdBuprLebjdGA;

			private float wNthwStvBPWXIzZYdonxGiRKPahf;

			public float rVvSErwNiosXqcleixnHbaoScBiFA
			{
				get
				{
					return AGZwPldleHdVLgyYMMiYqDLNjzUEA();
				}
				set
				{
					PDrTRbQuOQwSyuLpNLrOapPomtAi(num);
				}
			}

			public float AGZwPldleHdVLgyYMMiYqDLNjzUEA()
			{
				return YSFUOJdmSHaQJCVfrdBuprLebjdGA;
			}

			public void PDrTRbQuOQwSyuLpNLrOapPomtAi(float P_0)
			{
				YSFUOJdmSHaQJCVfrdBuprLebjdGA = P_0;
			}

			public WNUAsAtXkBsDkcrXVNFLvtgmCfuS(int P_0)
			{
				XdmUSIQSVifQPQyTDTXxHBhkiJwh = P_0;
			}

			public void FYZbrtdSVlzpATPIIFYqIqGlNHEn(float P_0)
			{
				wNthwStvBPWXIzZYdonxGiRKPahf = P_0;
				YSFUOJdmSHaQJCVfrdBuprLebjdGA = P_0;
			}

			public bool XUsXPEmkFBmiavPJbkesQeOHGqRAA(bool P_0)
			{
				float num = YSFUOJdmSHaQJCVfrdBuprLebjdGA - wNthwStvBPWXIzZYdonxGiRKPahf;
				if (P_0 && num < 0f)
				{
					return false;
				}
				if (MathTools.Abs(num) > 0.7f)
				{
					return true;
				}
				return false;
			}

			public void FMEwvAaGxuTaFSqrnJZdjlmyQQSA()
			{
				YSFUOJdmSHaQJCVfrdBuprLebjdGA = 0f;
				wNthwStvBPWXIzZYdonxGiRKPahf = 0f;
			}
		}

		private ZhBdLrxVhaDjFIhPaohczZUexJGP[] tgOQitqyXiNRAyUfmQwFcFWXkrmM;

		private UNdMPHhBSKcmLlyQILcjFdzDGyIEA PIyRCgHcTxQcIIjhyJepjMNFInkDA;

		public HKNpPMcDRvjrWjLIDGjvGlEGbdctA()
		{
			tgOQitqyXiNRAyUfmQwFcFWXkrmM = new ZhBdLrxVhaDjFIhPaohczZUexJGP[16];
			for (int i = 0; i < tgOQitqyXiNRAyUfmQwFcFWXkrmM.Length; i++)
			{
				tgOQitqyXiNRAyUfmQwFcFWXkrmM[i] = new ZhBdLrxVhaDjFIhPaohczZUexJGP(i);
			}
			PIyRCgHcTxQcIIjhyJepjMNFInkDA = new UNdMPHhBSKcmLlyQILcjFdzDGyIEA();
		}

		public void XCGYrBOdiRqNqVdhJVQwXNltBCmL()
		{
			for (int i = 0; i < tgOQitqyXiNRAyUfmQwFcFWXkrmM.Length; i++)
			{
				tgOQitqyXiNRAyUfmQwFcFWXkrmM[i].rQPJaiAtDOoitIioBVZPSRmOQdTW();
			}
		}

		public void adivfQVYbLVxZePZOLzaULeyMbWL()
		{
			for (int i = 0; i < tgOQitqyXiNRAyUfmQwFcFWXkrmM.Length; i++)
			{
				tgOQitqyXiNRAyUfmQwFcFWXkrmM[i].VOYpUURCKSbMeApEmcOUhswfPuysA();
			}
			PIyRCgHcTxQcIIjhyJepjMNFInkDA.BJxJSMZcJAIQFDJUSZmXOwWMBeLJA();
		}

		public bool UnVgcvXhUIAAEnpbWuzrzuVOiaoU(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= tgOQitqyXiNRAyUfmQwFcFWXkrmM.Length)
			{
				return false;
			}
			return tgOQitqyXiNRAyUfmQwFcFWXkrmM[P_0].HuVOiSTswZAHcHjlnWFyTjnByTtf(P_1);
		}

		public bool KgxKRSJwiQobHoqiDHUSIMfzqQVI(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= tgOQitqyXiNRAyUfmQwFcFWXkrmM.Length)
			{
				return false;
			}
			return tgOQitqyXiNRAyUfmQwFcFWXkrmM[P_0].atercahVlGvPsikfvZAHYcbEuNgE(P_1);
		}

		public bool BbwoRZcEAalIMHbpFhRzJCfYwNwrA(int P_0, int P_1)
		{
			if (P_0 < 0 || P_0 >= tgOQitqyXiNRAyUfmQwFcFWXkrmM.Length)
			{
				return false;
			}
			return tgOQitqyXiNRAyUfmQwFcFWXkrmM[P_0].UaHadpdPHmytHsWxifcvmPWHljZEb(P_1);
		}

		public bool PqmiphQhSBgHvzTyXVuUHHmstUYq(int P_0, int P_1, bool P_2)
		{
			if (P_0 < 0 || P_0 >= tgOQitqyXiNRAyUfmQwFcFWXkrmM.Length)
			{
				return false;
			}
			return tgOQitqyXiNRAyUfmQwFcFWXkrmM[P_0].WQGXFCIMendmhanjmpFadoqHpnBrB(P_1, P_2);
		}

		public bool uOuCcWcVUzRwitwXribfFWTGMwMgA(int P_0)
		{
			return PIyRCgHcTxQcIIjhyJepjMNFInkDA.HTnltozhOziiCeLLOvoDwXwDeJKuA(P_0);
		}

		public bool DbofQkBLFYJJaRXuekZGMJWBllzRA(int P_0)
		{
			return PIyRCgHcTxQcIIjhyJepjMNFInkDA.dKvsSTehDSIdgXfjjtLYLMJYGCLt(P_0);
		}

		public bool pYiCGLgUojuSSdiEpYWKmNyUnfDN(int P_0)
		{
			return PIyRCgHcTxQcIIjhyJepjMNFInkDA.EGqRpECiLKmDeTrMGAXAeaQJpjTvA(P_0);
		}

		public void mXkaHDgzaoDTwaahVJfhdMafTaIy()
		{
			for (int i = 0; i < tgOQitqyXiNRAyUfmQwFcFWXkrmM.Length; i++)
			{
				tgOQitqyXiNRAyUfmQwFcFWXkrmM[i].QTdUfEhDTQdAZWOHYrpjqdMichVBA();
			}
			PIyRCgHcTxQcIIjhyJepjMNFInkDA.NWikeLduhiLNBUMMjRQwaArTFWXd();
		}
	}

	private UpdateLoopType orgfCheUnSZcFcRQWoJBcZxcrMswB;

	private HKNpPMcDRvjrWjLIDGjvGlEGbdctA HyespWuSkKMfpMyEBNyVNgPaKocg;

	private IndexedDictionary<int, HKNpPMcDRvjrWjLIDGjvGlEGbdctA> bVIOCEWGtZEcqIeWwYMcMouWFFew;

	public QhiddugZGpIeVluIsyWwoiQEhHjf(UpdateLoopSetting P_0)
	{
		bVIOCEWGtZEcqIeWwYMcMouWFFew = new IndexedDictionary<int, HKNpPMcDRvjrWjLIDGjvGlEGbdctA>();
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				bVIOCEWGtZEcqIeWwYMcMouWFFew.Add((int)list[i], new HKNpPMcDRvjrWjLIDGjvGlEGbdctA());
			}
		}
		orgfCheUnSZcFcRQWoJBcZxcrMswB = UpdateLoopType.Update;
		HyespWuSkKMfpMyEBNyVNgPaKocg = bVIOCEWGtZEcqIeWwYMcMouWFFew.GetValue(0);
	}

	public void vvPfzvENYdNkqDBVkNqhGlctjiZnA()
	{
		UEYtuEmwhcptLxjEEhXFYkcFZkRy(ReInput.currentUpdateLoop);
		HyespWuSkKMfpMyEBNyVNgPaKocg.XCGYrBOdiRqNqVdhJVQwXNltBCmL();
	}

	public void VbmBgDTmQTqNOOXfOvBohFlNvqVo(UpdateLoopType P_0)
	{
		UEYtuEmwhcptLxjEEhXFYkcFZkRy(P_0);
		HyespWuSkKMfpMyEBNyVNgPaKocg.adivfQVYbLVxZePZOLzaULeyMbWL();
	}

	public bool OgdBIVctEhTaKIIfQoPJsihAtDdJA(int P_0, int P_1)
	{
		return HyespWuSkKMfpMyEBNyVNgPaKocg.UnVgcvXhUIAAEnpbWuzrzuVOiaoU(P_0, P_1);
	}

	public bool QwcakpxQrGbeKklsXCHumQBnIXyBb(int P_0, int P_1)
	{
		return HyespWuSkKMfpMyEBNyVNgPaKocg.KgxKRSJwiQobHoqiDHUSIMfzqQVI(P_0, P_1);
	}

	public bool tOighefECLdguPljTkBzdiXCViYKc(int P_0, int P_1)
	{
		return HyespWuSkKMfpMyEBNyVNgPaKocg.BbwoRZcEAalIMHbpFhRzJCfYwNwrA(P_0, P_1);
	}

	public bool kSXIcavTFqEOGTiKlNkRSDzrRnjX(int P_0, int P_1, bool P_2)
	{
		return HyespWuSkKMfpMyEBNyVNgPaKocg.PqmiphQhSBgHvzTyXVuUHHmstUYq(P_0, P_1, P_2);
	}

	public bool JHAwmXRWRYlKtqOBpyAGdQawjYRs(int P_0)
	{
		return HyespWuSkKMfpMyEBNyVNgPaKocg.uOuCcWcVUzRwitwXribfFWTGMwMgA(P_0);
	}

	public bool JVbEEGzzLobwQAIpzrvKTZXapGXB(int P_0)
	{
		return HyespWuSkKMfpMyEBNyVNgPaKocg.DbofQkBLFYJJaRXuekZGMJWBllzRA(P_0);
	}

	public bool SkGTZYzWjYCGkPZdToBGFKPrKznA(int P_0)
	{
		return HyespWuSkKMfpMyEBNyVNgPaKocg.pYiCGLgUojuSSdiEpYWKmNyUnfDN(P_0);
	}

	public void VsotHYncrJgIVwOfIxRoXbfNdrSN()
	{
		for (int i = 0; i < bVIOCEWGtZEcqIeWwYMcMouWFFew.get_Count(); i++)
		{
			bVIOCEWGtZEcqIeWwYMcMouWFFew[i].mXkaHDgzaoDTwaahVJfhdMafTaIy();
		}
	}

	private void UEYtuEmwhcptLxjEEhXFYkcFZkRy(UpdateLoopType P_0)
	{
		if (orgfCheUnSZcFcRQWoJBcZxcrMswB != P_0)
		{
			orgfCheUnSZcFcRQWoJBcZxcrMswB = P_0;
			HyespWuSkKMfpMyEBNyVNgPaKocg = bVIOCEWGtZEcqIeWwYMcMouWFFew.GetValue((int)P_0);
		}
	}
}
