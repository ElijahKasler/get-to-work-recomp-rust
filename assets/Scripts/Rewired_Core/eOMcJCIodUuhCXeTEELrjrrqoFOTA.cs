using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class eOMcJCIodUuhCXeTEELrjrrqoFOTA
{
	public class PRhAOizkpdHSAyssxNNjTdNwPNEr
	{
		public readonly Action<InputActionEventData> VaAXxVoCRMSqzricMPbPZqFrsldN;

		public readonly UpdateLoopType zTCizMQfvLJSzxzExTtyAWlHciTK;

		public readonly InputActionEventType rWlSpDnFrmzNsQdWhGUEBOHclbpBb;

		public readonly int GmcIFfqlrmeDnAdMhZdbEuIpOIAaA;

		public readonly bool LvIzrinWArTruYqlCEJEaOucmagab;

		public float[] ZjMbIhRQDsAXiRqUECMlWefpicgn;

		public PRhAOizkpdHSAyssxNNjTdNwPNEr(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
		{
			zTCizMQfvLJSzxzExTtyAWlHciTK = P_1;
			rWlSpDnFrmzNsQdWhGUEBOHclbpBb = P_2;
			GmcIFfqlrmeDnAdMhZdbEuIpOIAaA = P_3;
			VaAXxVoCRMSqzricMPbPZqFrsldN = P_0;
			qzMLEEKpaHdqVxTSNNQvYIrDAMiG(P_4);
			switch (P_2)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				LvIzrinWArTruYqlCEJEaOucmagab = true;
				break;
			}
		}

		public bool PZYWsTwfqsUzNIgUGniNvXtOLlXH(int P_0, out float P_1)
		{
			if (ZjMbIhRQDsAXiRqUECMlWefpicgn == null || ZjMbIhRQDsAXiRqUECMlWefpicgn.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = ZjMbIhRQDsAXiRqUECMlWefpicgn[P_0];
			return true;
		}

		private void qzMLEEKpaHdqVxTSNNQvYIrDAMiG(object[] P_0)
		{
			switch (rWlSpDnFrmzNsQdWhGUEBOHclbpBb)
			{
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + rWlSpDnFrmzNsQdWhGUEBOHclbpBb.ToString() + "\". 1 required argument: time [float], 1 optional argument: expireIn [float]");
				}
				ZjMbIhRQDsAXiRqUECMlWefpicgn = new float[2];
				if (P_0[0] is float)
				{
					ZjMbIhRQDsAXiRqUECMlWefpicgn[0] = (float)P_0[0];
				}
				else
				{
					if (!(P_0[0] is int))
					{
						throw new Exception("Wrong argument type passed for Input event type \"" + rWlSpDnFrmzNsQdWhGUEBOHclbpBb.ToString() + "\". Argument 0: time [float]");
					}
					ZjMbIhRQDsAXiRqUECMlWefpicgn[0] = (int)P_0[0];
				}
				if (P_0.Length <= 1)
				{
					break;
				}
				if (P_0[1] is float)
				{
					ZjMbIhRQDsAXiRqUECMlWefpicgn[1] = (float)P_0[1];
					break;
				}
				if (P_0[1] is int)
				{
					ZjMbIhRQDsAXiRqUECMlWefpicgn[1] = (int)P_0[1];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + rWlSpDnFrmzNsQdWhGUEBOHclbpBb.ToString() + "\". Argument 1 (optional): expireIn [float]");
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + rWlSpDnFrmzNsQdWhGUEBOHclbpBb.ToString() + "\". Requires 1 argument: time [float]");
				}
				ZjMbIhRQDsAXiRqUECMlWefpicgn = new float[1];
				if (P_0[0] is float)
				{
					ZjMbIhRQDsAXiRqUECMlWefpicgn[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					ZjMbIhRQDsAXiRqUECMlWefpicgn[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + rWlSpDnFrmzNsQdWhGUEBOHclbpBb.ToString() + "\". Argument 0: time [float]");
			case InputActionEventType.ButtonDoublePressed:
			case InputActionEventType.ButtonJustDoublePressed:
			case InputActionEventType.NegativeButtonDoublePressed:
			case InputActionEventType.NegativeButtonJustDoublePressed:
			case InputActionEventType.ButtonDoublePressJustReleased:
			case InputActionEventType.NegativeButtonDoublePressJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					break;
				}
				ZjMbIhRQDsAXiRqUECMlWefpicgn = new float[1];
				if (P_0[0] is float)
				{
					ZjMbIhRQDsAXiRqUECMlWefpicgn[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					ZjMbIhRQDsAXiRqUECMlWefpicgn[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + rWlSpDnFrmzNsQdWhGUEBOHclbpBb.ToString() + "\". Argument 0 (optional): time [float]");
			}
		}
	}

	[Serializable]
	private sealed class KdEjdXhJDFtADqXTcdnaFdVPuFheb
	{
		public static readonly KdEjdXhJDFtADqXTcdnaFdVPuFheb _003C_003E9 = new KdEjdXhJDFtADqXTcdnaFdVPuFheb();

		public static Func<AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>> _003C_003E9__8_0;

		internal AList<PRhAOizkpdHSAyssxNNjTdNwPNEr> ZnMAwLzVVjYWCJEvBYCCynZkiub()
		{
			return new AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>();
		}
	}

	private sealed class ZOjlbefEfYQIWynzYVKsxfEBdjDg
	{
		public Action<InputActionEventData> OmehWBZeTEjTUZyeGPUBNUAmkIxu;

		public Predicate<PRhAOizkpdHSAyssxNNjTdNwPNEr> fEOBNVIuyCBTaAiYgfnwcJHyaIjk;

		internal bool hYmtdLxmTBvGcwQtnIvGGyINVIYM(PRhAOizkpdHSAyssxNNjTdNwPNEr P_0)
		{
			return P_0.VaAXxVoCRMSqzricMPbPZqFrsldN == OmehWBZeTEjTUZyeGPUBNUAmkIxu;
		}
	}

	private sealed class yXeZcNakILfDdrWstWftQpKLKpyr
	{
		public Action<InputActionEventData> TbwYHiICRVbvPAvuSumQOfeyLpJJ;

		public int HVfjbxxGztGWefheIlrKYvAquoAQA;

		public Predicate<PRhAOizkpdHSAyssxNNjTdNwPNEr> hmwbJeFlIabnfFPEbTYwcQfqoXEqc;

		internal bool SOZhwRYuwtsvmypHrcECHHmVHjfKA(PRhAOizkpdHSAyssxNNjTdNwPNEr P_0)
		{
			if (P_0.VaAXxVoCRMSqzricMPbPZqFrsldN == TbwYHiICRVbvPAvuSumQOfeyLpJJ)
			{
				return P_0.GmcIFfqlrmeDnAdMhZdbEuIpOIAaA == HVfjbxxGztGWefheIlrKYvAquoAQA;
			}
			return false;
		}
	}

	private sealed class FgVDYtyFaWSFQJQUPCZlysmdQkrN
	{
		public Action<InputActionEventData> pzCDtXneyhGnicqsuojCggUkFsnHc;

		public UpdateLoopType hViTOuQBioDxzcFfNZUpdqOUmFwz;

		public Predicate<PRhAOizkpdHSAyssxNNjTdNwPNEr> oQBsyPJJvynuINqcSSvDXHndQkYF;

		internal bool BDaFPsKAPhoWUqfhmHTPcYVHTkgbc(PRhAOizkpdHSAyssxNNjTdNwPNEr P_0)
		{
			if (P_0.VaAXxVoCRMSqzricMPbPZqFrsldN == pzCDtXneyhGnicqsuojCggUkFsnHc)
			{
				return P_0.zTCizMQfvLJSzxzExTtyAWlHciTK == hViTOuQBioDxzcFfNZUpdqOUmFwz;
			}
			return false;
		}
	}

	private sealed class HsfNFWOHANJIEfGzYSRzwHfNTbKl
	{
		public Action<InputActionEventData> MhFjsSSkDkrNopEbSZeCWQciyMxR;

		public InputActionEventType oilxTIMyEOVskDAgdfFWMVrMflCo;

		public Predicate<PRhAOizkpdHSAyssxNNjTdNwPNEr> vPToDzYBKihWCDFmBtvYjEoRTZPy;

		internal bool tdUPoUDVvopWSyBychQPGYkqknLLA(PRhAOizkpdHSAyssxNNjTdNwPNEr P_0)
		{
			if (P_0.VaAXxVoCRMSqzricMPbPZqFrsldN == MhFjsSSkDkrNopEbSZeCWQciyMxR)
			{
				return P_0.rWlSpDnFrmzNsQdWhGUEBOHclbpBb == oilxTIMyEOVskDAgdfFWMVrMflCo;
			}
			return false;
		}
	}

	private sealed class JXmHKqKIilxbgmrTPBqAhXdYAkct
	{
		public Action<InputActionEventData> TzXfMDLrGPIzmKfEapKwkwKTcwdK;

		public UpdateLoopType gJRcVMDqCVOHXsXloZjCMAbKsKYqA;

		public int sBIybBIVJMwlgFbxCIqKctJtQtDQ;

		public Predicate<PRhAOizkpdHSAyssxNNjTdNwPNEr> utTEYyQHMENsswIimZETpaecyBvQ;

		internal bool mXBFGZJjfIMMsdDUeZFZDWMZZNwLB(PRhAOizkpdHSAyssxNNjTdNwPNEr P_0)
		{
			if (P_0.VaAXxVoCRMSqzricMPbPZqFrsldN == TzXfMDLrGPIzmKfEapKwkwKTcwdK && P_0.zTCizMQfvLJSzxzExTtyAWlHciTK == gJRcVMDqCVOHXsXloZjCMAbKsKYqA)
			{
				return P_0.GmcIFfqlrmeDnAdMhZdbEuIpOIAaA == sBIybBIVJMwlgFbxCIqKctJtQtDQ;
			}
			return false;
		}
	}

	private sealed class AenawMcmJAdLtsicttOeEgAvogrL
	{
		public Action<InputActionEventData> EQbLtEmbvPVYiJwaaYtqOAcohnLF;

		public UpdateLoopType FgznwxqjCAdnWmnRnkZqmeGIYCCy;

		public int fMFTGSbqXiQlAydqYcgVeSrNuxTx;

		public InputActionEventType GriDSqvGZKHfnbivDlfXKtyJQwPb;

		public Predicate<PRhAOizkpdHSAyssxNNjTdNwPNEr> whZOJLIgGfbYkeYXkxIqwCcuXxHB;

		internal bool IIqKifJECPtAvIPLSxHDzfpsQXIi(PRhAOizkpdHSAyssxNNjTdNwPNEr P_0)
		{
			if (P_0.VaAXxVoCRMSqzricMPbPZqFrsldN == EQbLtEmbvPVYiJwaaYtqOAcohnLF && P_0.zTCizMQfvLJSzxzExTtyAWlHciTK == FgznwxqjCAdnWmnRnkZqmeGIYCCy && P_0.GmcIFfqlrmeDnAdMhZdbEuIpOIAaA == fMFTGSbqXiQlAydqYcgVeSrNuxTx)
			{
				return P_0.rWlSpDnFrmzNsQdWhGUEBOHclbpBb == GriDSqvGZKHfnbivDlfXKtyJQwPb;
			}
			return false;
		}
	}

	private sealed class pNllfmnikwBdjUDJwdTCJWgDnbGA
	{
		public Action<InputActionEventData> MVvetTDilltARWxfDowzbAzisqlB;

		public UpdateLoopType tRWTFHrLNxbrGcqaxlMjfErqtDrZA;

		public InputActionEventType ETXfIDvkSvaIdbKBirIxHblkXMLWB;

		public Predicate<PRhAOizkpdHSAyssxNNjTdNwPNEr> ZkeGvCORWSdroEsSrGtodjqZzHwr;

		internal bool rSDMSTJuvOngohfbOhfGtaIbiscz(PRhAOizkpdHSAyssxNNjTdNwPNEr P_0)
		{
			if (P_0.VaAXxVoCRMSqzricMPbPZqFrsldN == MVvetTDilltARWxfDowzbAzisqlB && P_0.zTCizMQfvLJSzxzExTtyAWlHciTK == tRWTFHrLNxbrGcqaxlMjfErqtDrZA)
			{
				return P_0.rWlSpDnFrmzNsQdWhGUEBOHclbpBb == ETXfIDvkSvaIdbKBirIxHblkXMLWB;
			}
			return false;
		}
	}

	private sealed class UJCdYpBuPoPMgwXaVbhfFUhEHtMGc
	{
		public Action<InputActionEventData> tLmXhYCggyfssxQlrYpaeuHurOFd;

		public int PqjBgGhZRJwDcjMatLFqcPnfpmLM;

		public InputActionEventType AwMLXYpMpZOCzFgxBOlpPsWuRfKc;

		public Predicate<PRhAOizkpdHSAyssxNNjTdNwPNEr> DqAeJqgOovGpIpUZekQSgRrCTUgp;

		internal bool PtefMXUfBcclVhKQuRcBsfhmpkFIA(PRhAOizkpdHSAyssxNNjTdNwPNEr P_0)
		{
			if (P_0.VaAXxVoCRMSqzricMPbPZqFrsldN == tLmXhYCggyfssxQlrYpaeuHurOFd && P_0.GmcIFfqlrmeDnAdMhZdbEuIpOIAaA == PqjBgGhZRJwDcjMatLFqcPnfpmLM)
			{
				return P_0.rWlSpDnFrmzNsQdWhGUEBOHclbpBb == AwMLXYpMpZOCzFgxBOlpPsWuRfKc;
			}
			return false;
		}
	}

	private static PRhAOizkpdHSAyssxNNjTdNwPNEr[] PogcYAJrVGwISmdtphLWWOLFRkHN;

	private bool WrPoVsoeJwhgqgJQdEDzzDbNxDklA;

	private AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>[] YAEYdHAcjtmrkgKmeivooTLKzhjQ;

	private int[] WfZBCUIiucILbwcikRenHSSNPwsY;

	private int eYwMvuMdujPOpAVNyZdcXjQGJvXP;

	public int LaBtRfyqYivCLXprgIvCggAAYmuV;

	static eOMcJCIodUuhCXeTEELrjrrqoFOTA()
	{
		PogcYAJrVGwISmdtphLWWOLFRkHN = new PRhAOizkpdHSAyssxNNjTdNwPNEr[100];
	}

	private void yUfztYLrbzdVRbExqAmqGDicJfpl()
	{
		if (!WrPoVsoeJwhgqgJQdEDzzDbNxDklA)
		{
			IList<InputAction> list = ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.zdxfeLDxzrLnPTHJkaqdCRuxfJBcA();
			int num = list?.Count ?? 0;
			YAEYdHAcjtmrkgKmeivooTLKzhjQ = new AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>[num + 1];
			WfZBCUIiucILbwcikRenHSSNPwsY = new int[ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.XCDLgxDYAKtqdzecZdGKjcMWyPXH() + 1];
			ArrayTools.Populate(YAEYdHAcjtmrkgKmeivooTLKzhjQ, 0, YAEYdHAcjtmrkgKmeivooTLKzhjQ.Length, KdEjdXhJDFtADqXTcdnaFdVPuFheb._003C_003E9.ZnMAwLzVVjYWCJEvBYCCynZkiub);
			for (int i = 0; i < num; i++)
			{
				WfZBCUIiucILbwcikRenHSSNPwsY[list[i].id] = i;
			}
			eYwMvuMdujPOpAVNyZdcXjQGJvXP = num;
			WrPoVsoeJwhgqgJQdEDzzDbNxDklA = true;
		}
	}

	public void YRHUaYIrhHjowZlNbRJsaHJEDUvGA(QZWOxJToNpPZTYJKdjKDNrZDcbAQ P_0, UpdateLoopType P_1)
	{
		AList<PRhAOizkpdHSAyssxNNjTdNwPNEr> aList = YAEYdHAcjtmrkgKmeivooTLKzhjQ[WfZBCUIiucILbwcikRenHSSNPwsY[P_0.TAPCyytwMYgOFrdjuhlBIxGKFLLW]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				aList = YAEYdHAcjtmrkgKmeivooTLKzhjQ[eYwMvuMdujPOpAVNyZdcXjQGJvXP];
			}
			int count = aList._count;
			if (PogcYAJrVGwISmdtphLWWOLFRkHN.Length < count)
			{
				PogcYAJrVGwISmdtphLWWOLFRkHN = new PRhAOizkpdHSAyssxNNjTdNwPNEr[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(aList._items, PogcYAJrVGwISmdtphLWWOLFRkHN, count);
			}
			for (int j = 0; j < count; j++)
			{
				PRhAOizkpdHSAyssxNNjTdNwPNEr pRhAOizkpdHSAyssxNNjTdNwPNEr = PogcYAJrVGwISmdtphLWWOLFRkHN[j];
				if (pRhAOizkpdHSAyssxNNjTdNwPNEr == null || (!P_0.tbcLSwWnhvkNdTwrkLtvuPPeyUwk && !pRhAOizkpdHSAyssxNNjTdNwPNEr.LvIzrinWArTruYqlCEJEaOucmagab) || pRhAOizkpdHSAyssxNNjTdNwPNEr.zTCizMQfvLJSzxzExTtyAWlHciTK != P_1 || (pRhAOizkpdHSAyssxNNjTdNwPNEr.GmcIFfqlrmeDnAdMhZdbEuIpOIAaA >= 0 && pRhAOizkpdHSAyssxNNjTdNwPNEr.GmcIFfqlrmeDnAdMhZdbEuIpOIAaA != P_0.TAPCyytwMYgOFrdjuhlBIxGKFLLW))
				{
					continue;
				}
				bool flag = false;
				switch (pRhAOizkpdHSAyssxNNjTdNwPNEr.rWlSpDnFrmzNsQdWhGUEBOHclbpBb)
				{
				case InputActionEventType.Update:
					flag = true;
					break;
				case InputActionEventType.ButtonPressed:
					if (P_0.xKqYQOpLsGFmaoEFKYQRCnKaaWcQ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonUnpressed:
					if (!P_0.xKqYQOpLsGFmaoEFKYQRCnKaaWcQ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonDoublePressed:
				{
					pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(0, out var num5);
					if (P_0.QsNvsLyEjKJflAGPVqYdaUgqbBtP(num5))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonPressedForTime:
				{
					if (!pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(0, out var num11))
					{
						continue;
					}
					pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(1, out var num12);
					if (P_0.FdRbXuPyMOBrWhPPtLbONRCWRNDF(num11, num12))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressed:
					if (P_0.hSsQhormxBPLsPmcTUQqJowtLVbv())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressed:
					if (P_0.aSXXpPPIRQYKEURuUelgSsXLZrbF())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustPressed:
					if (P_0.SlBphyvwWgvIxeNaguzhFBDTfHoJ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustReleased:
					if (P_0.AfBRHgbDIxDSwAMNQBOuTkhxmJQqA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustDoublePressed:
				{
					pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(0, out var num9);
					if (P_0.TxpFIpCXbAUGsbVTpDsFxkyYzcW(num9))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonDoublePressJustReleased:
				{
					pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(0, out var num6);
					if (P_0.dwHlpMtarpWlenpesLjlxnUTFMUs(num6))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustPressedForTime:
				{
					if (!pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(0, out var num4))
					{
						continue;
					}
					if (P_0.OiNKbcEeqwSpZVHNmRVnqogRDLbe(num4))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustShortPressed:
					if (P_0.beWJzLeKilWrFrbfQEhsbIPicKVTA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustLongPressed:
					if (P_0.YhuZEIfeXBBkEwXAHNwLlIliaSbB())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				{
					if (!pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(0, out var num15))
					{
						continue;
					}
					pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(1, out var num16);
					if (P_0.xHYWeZwAVSdqPEUcyxvqXirtXpaF(num15, num16))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressJustReleased:
					if (P_0.TSceslrzwUjYnpGunBFAMFHVIyNT())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressJustReleased:
					if (P_0.HVQjefdnnZPmDpLqjeASIlsubdmnA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonRepeating:
					if (P_0.BrDddvTgykgmePaGTLJtXINQIFtK())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressed:
					if (P_0.taSMMuYrnbSumUxwpcrTCCyAtuSX())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustSinglePressed:
					if (P_0.tTJcOxzNCiiLiMUKpxjdpmtCQKSJ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressJustReleased:
					if (P_0.poPBIMJHlRUiMXmwfxMlaldXdztT())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressed:
					if (P_0.xTmTABHXjJsoVMuVRKriyrGRgzRH())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonUnpressed:
					if (!P_0.xTmTABHXjJsoVMuVRKriyrGRgzRH())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonDoublePressed:
				{
					pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(0, out var num3);
					if (P_0.hbektbuDvlfxTouCRZgDkkmxTxeL(num3))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonPressedForTime:
				{
					if (!pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(0, out var num))
					{
						continue;
					}
					pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(1, out var num2);
					if (P_0.ziADzwgaBUtBwGHVrdTTRHuRRjVv(num, num2))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressed:
					if (P_0.QlWFjPVnWqModMBeBYnxLikAKDpK())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressed:
					if (P_0.qYurVkNFOBRmWJkExbIOmfDSrXlB())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustPressed:
					if (P_0.jkWaFrQGPlyFMdhMpGwpqkrDEFHI())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustReleased:
					if (P_0.sgYTmFGalnrYFfIBPOUYeCxEwbSH())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustDoublePressed:
				{
					pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(0, out var num14);
					if (P_0.tmopxnyFMesBLwfGALpxzHifBmgJA(num14))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonDoublePressJustReleased:
				{
					pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(0, out var num13);
					if (P_0.BwfldKcyKYMrqJeNqAnbJCnEQlno(num13))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustPressedForTime:
				{
					if (!pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(0, out var num10))
					{
						continue;
					}
					if (P_0.MXpiuUDTKdbHFrOefQLevbJtSLAn(num10))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustShortPressed:
					if (P_0.AfxupzobmupXNHrRGlGIelaZDFwJ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustLongPressed:
					if (P_0.UdkkgdfwCMgOXaDSEbjwMaueXKry())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				{
					if (!pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(0, out var num7))
					{
						continue;
					}
					pRhAOizkpdHSAyssxNNjTdNwPNEr.PZYWsTwfqsUzNIgUGniNvXtOLlXH(1, out var num8);
					if (P_0.thuqLozprJgAEhQQpMrdgxdFaLXHb(num7, num8))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressJustReleased:
					if (P_0.vIAohwnKWdpbfnavFyHTrtDrBpsH())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressJustReleased:
					if (P_0.dOHvDRsAISqcocjczVGkDIoPpjIO())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonRepeating:
					if (P_0.UTcPrzFZoDBChEyJmzoNpyZmvAqk())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressed:
					if (P_0.OLBrnTxTzSPFYiaIRhtvoTtlUkku())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustSinglePressed:
					if (P_0.yeRGNIvOuNmOdrntRledlybJAbWR())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressJustReleased:
					if (P_0.ivrolhhvFjVTtpjOzHpLymGcfxTw())
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActive:
					if (!MathTools.ApproximatelyZero(P_0.lcLDFNWcRGBkJyxvUaCBCdQiMbZEb()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisInactive:
					if (MathTools.ApproximatelyZero(P_0.lcLDFNWcRGBkJyxvUaCBCdQiMbZEb()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActive:
					if (!MathTools.ApproximatelyZero(P_0.cWteTyHrjPGhfmxcPfIvYekmLaOoA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawInactive:
					if (MathTools.ApproximatelyZero(P_0.cWteTyHrjPGhfmxcPfIvYekmLaOoA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.lcLDFNWcRGBkJyxvUaCBCdQiMbZEb()) || !MathTools.ApproximatelyZero(P_0.FomBExaZtEkQRHdfJkkbIXNFXhfm()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.cWteTyHrjPGhfmxcPfIvYekmLaOoA()) || !MathTools.ApproximatelyZero(P_0.xfRmaCvfMrhVhcNUFLrbYbmFBqcw()))
					{
						flag = true;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				try
				{
					if (flag)
					{
						InputActionEventData obj = P_0.twRlVOvbhdjNgGNNxdaAPXCEfbrDb(P_1);
						obj.cnnYhqAFgxVadbCvXhXyJprOBmHI(pRhAOizkpdHSAyssxNNjTdNwPNEr.rWlSpDnFrmzNsQdWhGUEBOHclbpBb);
						pRhAOizkpdHSAyssxNNjTdNwPNEr.VaAXxVoCRMSqzricMPbPZqFrsldN(obj);
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("Player input event callback", exception);
				}
			}
		}
	}

	public void dpxvLRbbnXcLfzYhQvPFeAhSWGTV(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!WrPoVsoeJwhgqgJQdEDzzDbNxDklA)
		{
			yUfztYLrbzdVRbExqAmqGDicJfpl();
		}
		PRhAOizkpdHSAyssxNNjTdNwPNEr item;
		try
		{
			if (P_3 > ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.XCDLgxDYAKtqdzecZdGKjcMWyPXH())
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new PRhAOizkpdHSAyssxNNjTdNwPNEr(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			YAEYdHAcjtmrkgKmeivooTLKzhjQ[eYwMvuMdujPOpAVNyZdcXjQGJvXP].Add(item);
		}
		else
		{
			YAEYdHAcjtmrkgKmeivooTLKzhjQ[WfZBCUIiucILbwcikRenHSSNPwsY[P_3]].Add(item);
		}
		xTMhDpFmxVJtqBTpjaROdKPRDSWh();
	}

	public void FEBcZbkXiTESCIkJazItmlapfendA(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!WrPoVsoeJwhgqgJQdEDzzDbNxDklA)
		{
			yUfztYLrbzdVRbExqAmqGDicJfpl();
		}
		PRhAOizkpdHSAyssxNNjTdNwPNEr item;
		try
		{
			item = new PRhAOizkpdHSAyssxNNjTdNwPNEr(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		YAEYdHAcjtmrkgKmeivooTLKzhjQ[eYwMvuMdujPOpAVNyZdcXjQGJvXP].Add(item);
		xTMhDpFmxVJtqBTpjaROdKPRDSWh();
	}

	public void CfHlHrXglScxffaiOdmnINGFrpai(Action<InputActionEventData> P_0)
	{
		ZOjlbefEfYQIWynzYVKsxfEBdjDg zOjlbefEfYQIWynzYVKsxfEBdjDg = new ZOjlbefEfYQIWynzYVKsxfEBdjDg();
		zOjlbefEfYQIWynzYVKsxfEBdjDg.OmehWBZeTEjTUZyeGPUBNUAmkIxu = P_0;
		if (WrPoVsoeJwhgqgJQdEDzzDbNxDklA)
		{
			AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>[] yAEYdHAcjtmrkgKmeivooTLKzhjQ = YAEYdHAcjtmrkgKmeivooTLKzhjQ;
			for (int i = 0; i < yAEYdHAcjtmrkgKmeivooTLKzhjQ.Length; i++)
			{
				yAEYdHAcjtmrkgKmeivooTLKzhjQ[i].RemoveAll(zOjlbefEfYQIWynzYVKsxfEBdjDg.hYmtdLxmTBvGcwQtnIvGGyINVIYM);
			}
			xTMhDpFmxVJtqBTpjaROdKPRDSWh();
		}
	}

	public void UakGciaDIxJUYGBibsrdZluwrjMpc(Action<InputActionEventData> P_0, int P_1)
	{
		yXeZcNakILfDdrWstWftQpKLKpyr yXeZcNakILfDdrWstWftQpKLKpyr2 = new yXeZcNakILfDdrWstWftQpKLKpyr();
		yXeZcNakILfDdrWstWftQpKLKpyr2.TbwYHiICRVbvPAvuSumQOfeyLpJJ = P_0;
		yXeZcNakILfDdrWstWftQpKLKpyr2.HVfjbxxGztGWefheIlrKYvAquoAQA = P_1;
		if (WrPoVsoeJwhgqgJQdEDzzDbNxDklA && yXeZcNakILfDdrWstWftQpKLKpyr2.HVfjbxxGztGWefheIlrKYvAquoAQA <= ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.XCDLgxDYAKtqdzecZdGKjcMWyPXH())
		{
			AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>[] yAEYdHAcjtmrkgKmeivooTLKzhjQ = YAEYdHAcjtmrkgKmeivooTLKzhjQ;
			for (int i = 0; i < yAEYdHAcjtmrkgKmeivooTLKzhjQ.Length; i++)
			{
				yAEYdHAcjtmrkgKmeivooTLKzhjQ[i].RemoveAll(yXeZcNakILfDdrWstWftQpKLKpyr2.SOZhwRYuwtsvmypHrcECHHmVHjfKA);
			}
			xTMhDpFmxVJtqBTpjaROdKPRDSWh();
		}
	}

	public void KhoaUzgQxvYRLwqngLXoKKpicCog(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		FgVDYtyFaWSFQJQUPCZlysmdQkrN fgVDYtyFaWSFQJQUPCZlysmdQkrN = new FgVDYtyFaWSFQJQUPCZlysmdQkrN();
		fgVDYtyFaWSFQJQUPCZlysmdQkrN.pzCDtXneyhGnicqsuojCggUkFsnHc = P_0;
		fgVDYtyFaWSFQJQUPCZlysmdQkrN.hViTOuQBioDxzcFfNZUpdqOUmFwz = P_1;
		if (WrPoVsoeJwhgqgJQdEDzzDbNxDklA)
		{
			AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>[] yAEYdHAcjtmrkgKmeivooTLKzhjQ = YAEYdHAcjtmrkgKmeivooTLKzhjQ;
			for (int i = 0; i < yAEYdHAcjtmrkgKmeivooTLKzhjQ.Length; i++)
			{
				yAEYdHAcjtmrkgKmeivooTLKzhjQ[i].RemoveAll(fgVDYtyFaWSFQJQUPCZlysmdQkrN.BDaFPsKAPhoWUqfhmHTPcYVHTkgbc);
			}
			xTMhDpFmxVJtqBTpjaROdKPRDSWh();
		}
	}

	public void HFKtXNemLsEbenqpidjWJXHGHqPu(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		HsfNFWOHANJIEfGzYSRzwHfNTbKl hsfNFWOHANJIEfGzYSRzwHfNTbKl = new HsfNFWOHANJIEfGzYSRzwHfNTbKl();
		hsfNFWOHANJIEfGzYSRzwHfNTbKl.MhFjsSSkDkrNopEbSZeCWQciyMxR = P_0;
		hsfNFWOHANJIEfGzYSRzwHfNTbKl.oilxTIMyEOVskDAgdfFWMVrMflCo = P_1;
		if (WrPoVsoeJwhgqgJQdEDzzDbNxDklA)
		{
			AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>[] yAEYdHAcjtmrkgKmeivooTLKzhjQ = YAEYdHAcjtmrkgKmeivooTLKzhjQ;
			for (int i = 0; i < yAEYdHAcjtmrkgKmeivooTLKzhjQ.Length; i++)
			{
				yAEYdHAcjtmrkgKmeivooTLKzhjQ[i].RemoveAll(hsfNFWOHANJIEfGzYSRzwHfNTbKl.tdUPoUDVvopWSyBychQPGYkqknLLA);
			}
			xTMhDpFmxVJtqBTpjaROdKPRDSWh();
		}
	}

	public void ZSMxKhkKYwNbtrubxodqzfzZNvIC(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		JXmHKqKIilxbgmrTPBqAhXdYAkct jXmHKqKIilxbgmrTPBqAhXdYAkct = new JXmHKqKIilxbgmrTPBqAhXdYAkct();
		jXmHKqKIilxbgmrTPBqAhXdYAkct.TzXfMDLrGPIzmKfEapKwkwKTcwdK = P_0;
		jXmHKqKIilxbgmrTPBqAhXdYAkct.gJRcVMDqCVOHXsXloZjCMAbKsKYqA = P_1;
		jXmHKqKIilxbgmrTPBqAhXdYAkct.sBIybBIVJMwlgFbxCIqKctJtQtDQ = P_2;
		if (WrPoVsoeJwhgqgJQdEDzzDbNxDklA && jXmHKqKIilxbgmrTPBqAhXdYAkct.sBIybBIVJMwlgFbxCIqKctJtQtDQ <= ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.XCDLgxDYAKtqdzecZdGKjcMWyPXH())
		{
			AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>[] yAEYdHAcjtmrkgKmeivooTLKzhjQ = YAEYdHAcjtmrkgKmeivooTLKzhjQ;
			for (int i = 0; i < yAEYdHAcjtmrkgKmeivooTLKzhjQ.Length; i++)
			{
				yAEYdHAcjtmrkgKmeivooTLKzhjQ[i].RemoveAll(jXmHKqKIilxbgmrTPBqAhXdYAkct.mXBFGZJjfIMMsdDUeZFZDWMZZNwLB);
			}
			xTMhDpFmxVJtqBTpjaROdKPRDSWh();
		}
	}

	public void TgcMlamNDgixscUEOOcMGDabRovnB(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		AenawMcmJAdLtsicttOeEgAvogrL aenawMcmJAdLtsicttOeEgAvogrL = new AenawMcmJAdLtsicttOeEgAvogrL();
		aenawMcmJAdLtsicttOeEgAvogrL.EQbLtEmbvPVYiJwaaYtqOAcohnLF = P_0;
		aenawMcmJAdLtsicttOeEgAvogrL.FgznwxqjCAdnWmnRnkZqmeGIYCCy = P_1;
		aenawMcmJAdLtsicttOeEgAvogrL.fMFTGSbqXiQlAydqYcgVeSrNuxTx = P_3;
		aenawMcmJAdLtsicttOeEgAvogrL.GriDSqvGZKHfnbivDlfXKtyJQwPb = P_2;
		if (WrPoVsoeJwhgqgJQdEDzzDbNxDklA && aenawMcmJAdLtsicttOeEgAvogrL.fMFTGSbqXiQlAydqYcgVeSrNuxTx <= ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.XCDLgxDYAKtqdzecZdGKjcMWyPXH())
		{
			AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>[] yAEYdHAcjtmrkgKmeivooTLKzhjQ = YAEYdHAcjtmrkgKmeivooTLKzhjQ;
			for (int i = 0; i < yAEYdHAcjtmrkgKmeivooTLKzhjQ.Length; i++)
			{
				yAEYdHAcjtmrkgKmeivooTLKzhjQ[i].RemoveAll(aenawMcmJAdLtsicttOeEgAvogrL.IIqKifJECPtAvIPLSxHDzfpsQXIi);
			}
			xTMhDpFmxVJtqBTpjaROdKPRDSWh();
		}
	}

	public void hGxtqJLfVrHaXpSjqltxVMlofUoA(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		pNllfmnikwBdjUDJwdTCJWgDnbGA pNllfmnikwBdjUDJwdTCJWgDnbGA2 = new pNllfmnikwBdjUDJwdTCJWgDnbGA();
		pNllfmnikwBdjUDJwdTCJWgDnbGA2.MVvetTDilltARWxfDowzbAzisqlB = P_0;
		pNllfmnikwBdjUDJwdTCJWgDnbGA2.tRWTFHrLNxbrGcqaxlMjfErqtDrZA = P_1;
		pNllfmnikwBdjUDJwdTCJWgDnbGA2.ETXfIDvkSvaIdbKBirIxHblkXMLWB = P_2;
		if (WrPoVsoeJwhgqgJQdEDzzDbNxDklA)
		{
			AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>[] yAEYdHAcjtmrkgKmeivooTLKzhjQ = YAEYdHAcjtmrkgKmeivooTLKzhjQ;
			for (int i = 0; i < yAEYdHAcjtmrkgKmeivooTLKzhjQ.Length; i++)
			{
				yAEYdHAcjtmrkgKmeivooTLKzhjQ[i].RemoveAll(pNllfmnikwBdjUDJwdTCJWgDnbGA2.rSDMSTJuvOngohfbOhfGtaIbiscz);
			}
			xTMhDpFmxVJtqBTpjaROdKPRDSWh();
		}
	}

	public void zrbCfNDxCZydSaBcniMDkOCFTrJDA(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		UJCdYpBuPoPMgwXaVbhfFUhEHtMGc uJCdYpBuPoPMgwXaVbhfFUhEHtMGc = new UJCdYpBuPoPMgwXaVbhfFUhEHtMGc();
		uJCdYpBuPoPMgwXaVbhfFUhEHtMGc.tLmXhYCggyfssxQlrYpaeuHurOFd = P_0;
		uJCdYpBuPoPMgwXaVbhfFUhEHtMGc.PqjBgGhZRJwDcjMatLFqcPnfpmLM = P_2;
		uJCdYpBuPoPMgwXaVbhfFUhEHtMGc.AwMLXYpMpZOCzFgxBOlpPsWuRfKc = P_1;
		if (WrPoVsoeJwhgqgJQdEDzzDbNxDklA && uJCdYpBuPoPMgwXaVbhfFUhEHtMGc.PqjBgGhZRJwDcjMatLFqcPnfpmLM <= ReInput.IsSPFehscBAmxtEADWGWuasjDvqf.XCDLgxDYAKtqdzecZdGKjcMWyPXH())
		{
			AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>[] yAEYdHAcjtmrkgKmeivooTLKzhjQ = YAEYdHAcjtmrkgKmeivooTLKzhjQ;
			for (int i = 0; i < yAEYdHAcjtmrkgKmeivooTLKzhjQ.Length; i++)
			{
				yAEYdHAcjtmrkgKmeivooTLKzhjQ[i].RemoveAll(uJCdYpBuPoPMgwXaVbhfFUhEHtMGc.PtefMXUfBcclVhKQuRcBsfhmpkFIA);
			}
			xTMhDpFmxVJtqBTpjaROdKPRDSWh();
		}
	}

	public void caLfklwmPmDEYLrHxotcRQUWWAVv()
	{
		if (WrPoVsoeJwhgqgJQdEDzzDbNxDklA)
		{
			AList<PRhAOizkpdHSAyssxNNjTdNwPNEr>[] yAEYdHAcjtmrkgKmeivooTLKzhjQ = YAEYdHAcjtmrkgKmeivooTLKzhjQ;
			for (int i = 0; i < yAEYdHAcjtmrkgKmeivooTLKzhjQ.Length; i++)
			{
				yAEYdHAcjtmrkgKmeivooTLKzhjQ[i].Clear();
			}
			xTMhDpFmxVJtqBTpjaROdKPRDSWh();
		}
	}

	private void xTMhDpFmxVJtqBTpjaROdKPRDSWh()
	{
		int num = 0;
		for (int i = 0; i < YAEYdHAcjtmrkgKmeivooTLKzhjQ.Length; i++)
		{
			num += YAEYdHAcjtmrkgKmeivooTLKzhjQ[i]._count;
		}
		LaBtRfyqYivCLXprgIvCggAAYmuV = num;
	}
}
