using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class lQoAAQNPpFWyUNnFoiTjITGTmsQh
{
	private class thTqmmIsunkOMYprKWQCIziPlzje
	{
		public readonly InputAction hZSCsBhiDXulVMLhHKzGbJanlzaMA;

		public readonly int yylVfeMrpErRpPMMbEnmiWDAdltSA;

		public readonly int tCnVCrXXweJtgsQtLSHbqqvUdwDR;

		public thTqmmIsunkOMYprKWQCIziPlzje(InputAction P_0, int P_1)
		{
			hZSCsBhiDXulVMLhHKzGbJanlzaMA = P_0;
			yylVfeMrpErRpPMMbEnmiWDAdltSA = P_0.id;
			tCnVCrXXweJtgsQtLSHbqqvUdwDR = P_1;
		}
	}

	private InputAction[] RODtymwRpdxlZHTSAqjRwbZxaIkbA;

	private ADictionary<string, thTqmmIsunkOMYprKWQCIziPlzje> aqKCTpduwnmFpfrsvGGHeNEDCPwIc;

	private thTqmmIsunkOMYprKWQCIziPlzje[] HzdZrMdMWlFiOAECBDSwfTutiqpbA;

	private ReadOnlyCollection<InputAction> VYJbHLDNTuNvwtcKakzYQRvPoPafb;

	private int LBMPIfexhfolisFwsmTRbtItbXGI;

	private int gsJMILNKFaWiJWcxlGbDzpSgdxmP;

	private List<string> HQTlvkQgAesPPSuorJQIeNArBzEEA;

	private List<int> mPvVBPmDEbWmfnGvKSNGFCzZFcmr;

	public IList<InputAction> IMVNgjUnVFmihzZWzRoPUNbkyITo => zdxfeLDxzrLnPTHJkaqdCRuxfJBcA();

	public int EQRKmFaqLXqcmkqqlfOyftfrwBpnA => OSSfzqtTCBwONcbrXxdGyIDiCXCB();

	public int JMWreeZaoteNSNYSRGBTalmEkAyT => XCDLgxDYAKtqdzecZdGKjcMWyPXH();

	public IList<InputAction> zdxfeLDxzrLnPTHJkaqdCRuxfJBcA()
	{
		return VYJbHLDNTuNvwtcKakzYQRvPoPafb;
	}

	public int OSSfzqtTCBwONcbrXxdGyIDiCXCB()
	{
		return LBMPIfexhfolisFwsmTRbtItbXGI;
	}

	public int XCDLgxDYAKtqdzecZdGKjcMWyPXH()
	{
		return gsJMILNKFaWiJWcxlGbDzpSgdxmP;
	}

	public lQoAAQNPpFWyUNnFoiTjITGTmsQh(List<InputAction> P_0)
	{
		HQTlvkQgAesPPSuorJQIeNArBzEEA = new List<string>();
		mPvVBPmDEbWmfnGvKSNGFCzZFcmr = new List<int>();
		RODtymwRpdxlZHTSAqjRwbZxaIkbA = P_0.ToArray();
		LBMPIfexhfolisFwsmTRbtItbXGI = RODtymwRpdxlZHTSAqjRwbZxaIkbA.Length;
		int num = -1;
		for (int i = 0; i < LBMPIfexhfolisFwsmTRbtItbXGI; i++)
		{
			int id = RODtymwRpdxlZHTSAqjRwbZxaIkbA[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		gsJMILNKFaWiJWcxlGbDzpSgdxmP = num;
		HzdZrMdMWlFiOAECBDSwfTutiqpbA = new thTqmmIsunkOMYprKWQCIziPlzje[num + 1];
		for (int j = 0; j < LBMPIfexhfolisFwsmTRbtItbXGI; j++)
		{
			InputAction inputAction = RODtymwRpdxlZHTSAqjRwbZxaIkbA[j];
			HzdZrMdMWlFiOAECBDSwfTutiqpbA[inputAction.id] = new thTqmmIsunkOMYprKWQCIziPlzje(inputAction, j);
		}
		aqKCTpduwnmFpfrsvGGHeNEDCPwIc = new ADictionary<string, thTqmmIsunkOMYprKWQCIziPlzje>(LBMPIfexhfolisFwsmTRbtItbXGI, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < LBMPIfexhfolisFwsmTRbtItbXGI; k++)
		{
			InputAction inputAction2 = RODtymwRpdxlZHTSAqjRwbZxaIkbA[k];
			try
			{
				aqKCTpduwnmFpfrsvGGHeNEDCPwIc.Add(inputAction2.name, HzdZrMdMWlFiOAECBDSwfTutiqpbA[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		VYJbHLDNTuNvwtcKakzYQRvPoPafb = new ReadOnlyCollection<InputAction>(RODtymwRpdxlZHTSAqjRwbZxaIkbA);
	}

	public InputAction pxqIwEDqxMKXOCayUJiZFLWEOTiW(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!aqKCTpduwnmFpfrsvGGHeNEDCPwIc.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				qfcBeHwLeeFCEHngSgDCyyEBcanhA(P_0);
			}
			return null;
		}
		return value.hZSCsBhiDXulVMLhHKzGbJanlzaMA;
	}

	public InputAction NRviRUJlZrnMmqLUAtHMJPcPfEOn(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > gsJMILNKFaWiJWcxlGbDzpSgdxmP)
		{
			return null;
		}
		if (HzdZrMdMWlFiOAECBDSwfTutiqpbA[P_0] == null)
		{
			return null;
		}
		return HzdZrMdMWlFiOAECBDSwfTutiqpbA[P_0].hZSCsBhiDXulVMLhHKzGbJanlzaMA;
	}

	public InputAction TyzxFiDXrmXQDwSlqYMfUEgoAVaQ(int P_0)
	{
		if (P_0 < 0 || P_0 >= LBMPIfexhfolisFwsmTRbtItbXGI)
		{
			return null;
		}
		return RODtymwRpdxlZHTSAqjRwbZxaIkbA[P_0];
	}

	public int vCinmjnHPaVfEgIwLuJwdcpFgEfBA(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!aqKCTpduwnmFpfrsvGGHeNEDCPwIc.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				qfcBeHwLeeFCEHngSgDCyyEBcanhA(P_0);
			}
			return -1;
		}
		return value.tCnVCrXXweJtgsQtLSHbqqvUdwDR;
	}

	public int ePMNZIYbjJltQRETydtleyDTFxII(int P_0, bool P_1 = false)
	{
		if (P_0 < 0 || P_0 > gsJMILNKFaWiJWcxlGbDzpSgdxmP)
		{
			if ((P_0 >= 0) & P_1)
			{
				hTUvVXXtriGTAaRXPthvvfizuEcA(P_0);
			}
			return -1;
		}
		thTqmmIsunkOMYprKWQCIziPlzje thTqmmIsunkOMYprKWQCIziPlzje2 = HzdZrMdMWlFiOAECBDSwfTutiqpbA[P_0];
		if (thTqmmIsunkOMYprKWQCIziPlzje2 == null)
		{
			if (P_1)
			{
				hTUvVXXtriGTAaRXPthvvfizuEcA(P_0);
			}
			return -1;
		}
		return thTqmmIsunkOMYprKWQCIziPlzje2.tCnVCrXXweJtgsQtLSHbqqvUdwDR;
	}

	public bool BSeAocTDIxsanMklUJHdXggjRtM(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!aqKCTpduwnmFpfrsvGGHeNEDCPwIc.ContainsKey(P_0))
		{
			if (P_1)
			{
				qfcBeHwLeeFCEHngSgDCyyEBcanhA(P_0);
			}
			return false;
		}
		return true;
	}

	public bool rkIzgHaJhtDYthMxJVuIyUfLWAQe(int P_0)
	{
		if (P_0 < 0 || P_0 > gsJMILNKFaWiJWcxlGbDzpSgdxmP)
		{
			return false;
		}
		return HzdZrMdMWlFiOAECBDSwfTutiqpbA[P_0] != null;
	}

	public int GhVjGDQeDQmOWTnROakHcfdeCdDd(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!aqKCTpduwnmFpfrsvGGHeNEDCPwIc.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				qfcBeHwLeeFCEHngSgDCyyEBcanhA(P_0);
			}
			return -1;
		}
		return value.yylVfeMrpErRpPMMbEnmiWDAdltSA;
	}

	private void qfcBeHwLeeFCEHngSgDCyyEBcanhA(string P_0)
	{
		if (!HQTlvkQgAesPPSuorJQIeNArBzEEA.Contains(P_0))
		{
			HQTlvkQgAesPPSuorJQIeNArBzEEA.Add(P_0);
			Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
		}
	}

	private void hTUvVXXtriGTAaRXPthvvfizuEcA(int P_0)
	{
		if (!mPvVBPmDEbWmfnGvKSNGFCzZFcmr.Contains(P_0))
		{
			mPvVBPmDEbWmfnGvKSNGFCzZFcmr.Add(P_0);
			Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
		}
	}
}
