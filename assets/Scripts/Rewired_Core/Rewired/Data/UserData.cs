using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired.Data;

[Serializable]
public sealed class UserData
{
	private static class ndJLjuhPVrNKUeZBueilZdwWDuMX
	{
		[DefaultMember("Item")]
		private class EMTBqctKQkjktmumnmGMHbxhhuVB
		{
			public enum qxaFOZwsZXIbrBMkxDFeDaVYJfWxA
			{
				origId = 0,
				otherId = 1,
				finalId = 2
			}

			public int SlmJYeBAtkEhjvxNOdmTIIvNEoHGA;

			public int FeHDIJJjflqdaqABjwCBjPNOxqjI;

			public int EZzutRppqaDjFBdxSrXzucaXHiVnA;

			// C# has no syntax for parameterized property 'qrFloCDwSNRHCCMnDfbsOjwxbpGH'.
			public int get_qrFloCDwSNRHCCMnDfbsOjwxbpGH(qxaFOZwsZXIbrBMkxDFeDaVYJfWxA P_0)
			{
				return PZweCeEkmWmseGUbERKfuedIrEJoA(P_0);
			}

			public void set_qrFloCDwSNRHCCMnDfbsOjwxbpGH(qxaFOZwsZXIbrBMkxDFeDaVYJfWxA P_0, int P_1)
			{
				JvzKWcCZmdrkfbrqNrdAzdLGGrSP(qxaFOZwsZXIbrBMkxDFeDaVYJfWxA2, num);
			}

			public int PZweCeEkmWmseGUbERKfuedIrEJoA(qxaFOZwsZXIbrBMkxDFeDaVYJfWxA P_0)
			{
				return P_0 switch
				{
					qxaFOZwsZXIbrBMkxDFeDaVYJfWxA.origId => SlmJYeBAtkEhjvxNOdmTIIvNEoHGA, 
					qxaFOZwsZXIbrBMkxDFeDaVYJfWxA.otherId => FeHDIJJjflqdaqABjwCBjPNOxqjI, 
					qxaFOZwsZXIbrBMkxDFeDaVYJfWxA.finalId => EZzutRppqaDjFBdxSrXzucaXHiVnA, 
					_ => throw new NotImplementedException(), 
				};
			}

			public void JvzKWcCZmdrkfbrqNrdAzdLGGrSP(qxaFOZwsZXIbrBMkxDFeDaVYJfWxA P_0, int P_1)
			{
				switch (P_0)
				{
				case qxaFOZwsZXIbrBMkxDFeDaVYJfWxA.origId:
					SlmJYeBAtkEhjvxNOdmTIIvNEoHGA = P_1;
					break;
				case qxaFOZwsZXIbrBMkxDFeDaVYJfWxA.otherId:
					FeHDIJJjflqdaqABjwCBjPNOxqjI = P_1;
					break;
				case qxaFOZwsZXIbrBMkxDFeDaVYJfWxA.finalId:
					EZzutRppqaDjFBdxSrXzucaXHiVnA = P_1;
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public EMTBqctKQkjktmumnmGMHbxhhuVB(int P_0, int P_1, int P_2)
			{
				SlmJYeBAtkEhjvxNOdmTIIvNEoHGA = P_0;
				FeHDIJJjflqdaqABjwCBjPNOxqjI = P_1;
				EZzutRppqaDjFBdxSrXzucaXHiVnA = P_2;
			}

			public virtual string niWCQJaqPfHlqQcWnEioqensEnWiA()
			{
				return string.Concat(string.Concat("" + StringTools.WriteVar("origId", SlmJYeBAtkEhjvxNOdmTIIvNEoHGA), StringTools.WriteVar("otherId", FeHDIJJjflqdaqABjwCBjPNOxqjI)), StringTools.WriteVar("finalId", EZzutRppqaDjFBdxSrXzucaXHiVnA));
			}
		}

		private class AkUCLhNIDBBTJcQEscdxfsqfImGV<_0001>
		{
			public _0001 pDHbWPaGiefJBNdhahtQmfpkZJQFA;

			public _0001 LPMFKBtBpONOjBeMYHflRRHyVOHm;

			public EMTBqctKQkjktmumnmGMHbxhhuVB.qxaFOZwsZXIbrBMkxDFeDaVYJfWxA pRCMTxKbnAIkbSRJednqlinGSSeK;

			public IList<_0001> NpFvwtIiyVYtkSGjcyGFDSoCiurb;

			public bool DdmyTHXsSVJyYojGImhBYgErEfXbA;

			public AkUCLhNIDBBTJcQEscdxfsqfImGV(_0001 P_0, _0001 P_1, EMTBqctKQkjktmumnmGMHbxhhuVB.qxaFOZwsZXIbrBMkxDFeDaVYJfWxA P_2, IList<_0001> P_3, bool P_4)
			{
				pDHbWPaGiefJBNdhahtQmfpkZJQFA = P_0;
				LPMFKBtBpONOjBeMYHflRRHyVOHm = P_1;
				pRCMTxKbnAIkbSRJednqlinGSSeK = P_2;
				NpFvwtIiyVYtkSGjcyGFDSoCiurb = P_3;
				DdmyTHXsSVJyYojGImhBYgErEfXbA = P_4;
			}
		}

		[Serializable]
		private sealed class IYonyLtWmadQRRrxhrTCfNOMKMZN
		{
			public static readonly IYonyLtWmadQRRrxhrTCfNOMKMZN _003C_003E9 = new IYonyLtWmadQRRrxhrTCfNOMKMZN();

			public static Func<InputActionCategory, int> _003C_003E9__0_0;

			public static Func<InputActionCategory, string> _003C_003E9__0_1;

			public static Func<InputActionCategory, IList<InputActionCategory>, int> _003C_003E9__0_2;

			public static Func<InputBehavior, int> _003C_003E9__0_4;

			public static Func<InputBehavior, string> _003C_003E9__0_5;

			public static Func<InputBehavior, IList<InputBehavior>, int> _003C_003E9__0_6;

			public static Func<InputAction, int> _003C_003E9__0_8;

			public static Func<InputAction, string> _003C_003E9__0_9;

			public static Func<InputAction, IList<InputAction>, int> _003C_003E9__0_10;

			public static Func<InputMapCategory, int> _003C_003E9__0_47;

			public static Func<InputMapCategory, string> _003C_003E9__0_48;

			public static Func<InputMapCategory, IList<InputMapCategory>, int> _003C_003E9__0_49;

			public static Func<InputLayout, int> _003C_003E9__0_12;

			public static Func<InputLayout, string> _003C_003E9__0_13;

			public static Func<InputLayout, IList<InputLayout>, int> _003C_003E9__0_14;

			public static Func<InputLayout, int> _003C_003E9__0_16;

			public static Func<InputLayout, string> _003C_003E9__0_17;

			public static Func<InputLayout, IList<InputLayout>, int> _003C_003E9__0_18;

			public static Func<InputLayout, int> _003C_003E9__0_20;

			public static Func<InputLayout, string> _003C_003E9__0_21;

			public static Func<InputLayout, IList<InputLayout>, int> _003C_003E9__0_22;

			public static Func<InputLayout, int> _003C_003E9__0_24;

			public static Func<InputLayout, string> _003C_003E9__0_25;

			public static Func<InputLayout, IList<InputLayout>, int> _003C_003E9__0_26;

			public static Func<CustomController_Editor, int> _003C_003E9__0_29;

			public static Func<CustomController_Editor, string> _003C_003E9__0_30;

			public static Func<CustomController_Editor, IList<CustomController_Editor>, int> _003C_003E9__0_31;

			public static Func<ControllerMapLayoutManager_RuleSet_Editor, int> _003C_003E9__0_33;

			public static Func<ControllerMapLayoutManager_RuleSet_Editor, string> _003C_003E9__0_34;

			public static Func<ControllerMapLayoutManager_RuleSet_Editor, IList<ControllerMapLayoutManager_RuleSet_Editor>, int> _003C_003E9__0_35;

			public static Func<ControllerMapEnabler_RuleSet_Editor, int> _003C_003E9__0_37;

			public static Func<ControllerMapEnabler_RuleSet_Editor, string> _003C_003E9__0_38;

			public static Func<ControllerMapEnabler_RuleSet_Editor, IList<ControllerMapEnabler_RuleSet_Editor>, int> _003C_003E9__0_39;

			public static Func<Player_Editor, int> _003C_003E9__0_41;

			public static Func<Player_Editor, string> _003C_003E9__0_42;

			public static Func<Player_Editor, IList<Player_Editor>, int> _003C_003E9__0_43;

			public static Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> _003C_003E9__0_64;

			public static Func<Player_Editor.CreateControllerInfo, IList<Player_Editor.CreateControllerInfo>, int> _003C_003E9__0_65;

			public static Func<ControllerMap_Editor, int> _003C_003E9__0_66;

			public static Func<ControllerMap_Editor, string> _003C_003E9__0_67;

			public static Func<ActionElementMap, IList<ActionElementMap>, int> _003C_003E9__0_75;

			public static Func<ControllerMap_Editor, int> _003C_003E9__0_76;

			public static Func<ControllerMap_Editor, string> _003C_003E9__0_77;

			public static Func<ActionElementMap, IList<ActionElementMap>, int> _003C_003E9__0_85;

			public static Func<ControllerMap_Editor, int> _003C_003E9__0_86;

			public static Func<ControllerMap_Editor, string> _003C_003E9__0_87;

			public static Func<ActionElementMap, IList<ActionElementMap>, int> _003C_003E9__0_95;

			public static Func<ControllerMap_Editor, int> _003C_003E9__0_96;

			public static Func<ControllerMap_Editor, string> _003C_003E9__0_97;

			public static Func<ActionElementMap, IList<ActionElementMap>, int> _003C_003E9__0_107;

			internal int FynhcjEniIVgTwZJVIWgrRjbDYoe(InputActionCategory P_0)
			{
				return P_0.id;
			}

			internal string uvoSoNbFIBJhSVQhgbEJwRkVmYyf(InputActionCategory P_0)
			{
				return P_0.name;
			}

			internal int HhdkRwibxwQQvUbtazNTgCSqdNuEA(InputActionCategory P_0, IList<InputActionCategory> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			internal int JfFOhyyrSsFaiOoTsqHywntDzrgr(InputBehavior P_0)
			{
				return P_0.id;
			}

			internal string pXKxurKzUwunAFKVNzWSjnPorhhE(InputBehavior P_0)
			{
				return P_0.name;
			}

			internal int weiUSmiRtCwtbXnvrsLCyuVwoIId(InputBehavior P_0, IList<InputBehavior> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			internal int QwXxxdWnVgOsTEUsYfatVcEMgVru(InputAction P_0)
			{
				return P_0.id;
			}

			internal string hCGIXipkBzuECkgdzKkRhDMTdwTm(InputAction P_0)
			{
				return P_0.name;
			}

			internal int qxHEZAagbIpFamEFBcaPGpbJeIPt(InputAction P_0, IList<InputAction> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			internal int BnnRVOGzfOGahEntzkyiuiKHBIvn(InputMapCategory P_0)
			{
				return P_0.id;
			}

			internal string XZOgmjpAgLbITpfIIaiAzjJgKVrX(InputMapCategory P_0)
			{
				return P_0.name;
			}

			internal int AqYHVrPjUktOtekdcUrLbdkZKpiq(InputMapCategory P_0, IList<InputMapCategory> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			internal int alzdzjnRVafwBOROTgRTIuLJmjRab(InputLayout P_0)
			{
				return P_0.id;
			}

			internal string eAfqQClgddgMaDUSdnVCadTBFybYb(InputLayout P_0)
			{
				return P_0.name;
			}

			internal int rkxmZVpRkrHNaOQmGGXrdjtqwXHy(InputLayout P_0, IList<InputLayout> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			internal int QcMtVzowoedXZCpuNstOlpnrNXdG(InputLayout P_0)
			{
				return P_0.id;
			}

			internal string KgjiOkgoPVFZTEdMiVnAuSatVxThA(InputLayout P_0)
			{
				return P_0.name;
			}

			internal int oyMOUWFObuOVcpJWWDDDzOUxQduR(InputLayout P_0, IList<InputLayout> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			internal int XwCNhFMyvKYizfdTehrrDegORQTv(InputLayout P_0)
			{
				return P_0.id;
			}

			internal string JCaHuZFAujAQtUOblMXuFZgfpFYCB(InputLayout P_0)
			{
				return P_0.name;
			}

			internal int yjXRqkIPfKexjeFpaiSgIsDqgOdeA(InputLayout P_0, IList<InputLayout> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			internal int tuhgqIIMRaoLFvFbzHXmLcBEnuxE(InputLayout P_0)
			{
				return P_0.id;
			}

			internal string NZuesRdsrGEvtcKHEOgmbJcgLNLTb(InputLayout P_0)
			{
				return P_0.name;
			}

			internal int XJPcvJEZWgzvVDiKkqhgaeyJxlJwb(InputLayout P_0, IList<InputLayout> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			internal int JdyNWtskEqMXHPlOQKVyWfeawhGs(CustomController_Editor P_0)
			{
				return P_0.id;
			}

			internal string QFgHHHuVHNPUXdaKHnhHslqFgSdS(CustomController_Editor P_0)
			{
				return P_0.name;
			}

			internal int FOEBSMXuMMPtpYLFNHWaGWVLerlq(CustomController_Editor P_0, IList<CustomController_Editor> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			internal int aphgLItVNLubHsJUHPzQmrmZkFfb(ControllerMapLayoutManager_RuleSet_Editor P_0)
			{
				return P_0.id;
			}

			internal string GLlYLxfDgfRaIBZZbcpmdfckcVkO(ControllerMapLayoutManager_RuleSet_Editor P_0)
			{
				return P_0.name;
			}

			internal int uJsFrEKfZaKdEXEksXLmEJOGpfixA(ControllerMapLayoutManager_RuleSet_Editor P_0, IList<ControllerMapLayoutManager_RuleSet_Editor> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			internal int zBcUmRHqNQcbRHNxWXCkxlqAxIJlA(ControllerMapEnabler_RuleSet_Editor P_0)
			{
				return P_0.id;
			}

			internal string RWUyDQYeWheZNDRgbmOPZjymyXPZ(ControllerMapEnabler_RuleSet_Editor P_0)
			{
				return P_0.name;
			}

			internal int UjlcmmdaNUjQYWGKmruSRdVJQnWIA(ControllerMapEnabler_RuleSet_Editor P_0, IList<ControllerMapEnabler_RuleSet_Editor> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			internal int QjCsCtVkCilwkdgYsBlwEiuHhpbh(Player_Editor P_0)
			{
				return P_0.id;
			}

			internal string yMPrHOEYiJaxMiaFmmtzAGRANpXI(Player_Editor P_0)
			{
				return P_0.name;
			}

			internal int bYifIedoFHdryQHWcqGVhpkkzDDW(Player_Editor P_0, IList<Player_Editor> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (string.Equals(P_0.name, P_1[i].name, StringComparison.OrdinalIgnoreCase))
					{
						return i;
					}
				}
				return -1;
			}

			internal int lxMTRmvhmtIDcLbMHCQdkgPfrjLZ(Player_Editor.Mapping P_0, IList<Player_Editor.Mapping> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (P_1[i].categoryId == P_0.categoryId && P_1[i].layoutId == P_0.layoutId)
					{
						return i;
					}
				}
				return -1;
			}

			internal int UOhfPbIEhshIYGMUKpTcRwKHixrlb(Player_Editor.CreateControllerInfo P_0, IList<Player_Editor.CreateControllerInfo> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (P_1[i].sourceId == P_0.sourceId)
					{
						return i;
					}
				}
				return -1;
			}

			internal int qnAyDrTREcvkhDZyLkpkYrbZJRsw(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			internal string SGFOtAwJymtBBmUBQMoUVUSYPowr(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			internal int SMYqwEluamhgcTkFqraAkLCaoexW(ActionElementMap P_0, IList<ActionElementMap> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (P_1[i]._keyboardKeyCode == P_0._keyboardKeyCode && P_1[i]._modifierKey1 == P_0._modifierKey1 && P_1[i]._modifierKey2 == P_0._modifierKey2 && P_1[i]._modifierKey3 == P_0._modifierKey3 && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
					{
						return i;
					}
				}
				return -1;
			}

			internal int QpxdFPAszhfhGFrnOcGMdtzIhaqKc(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			internal string zaHBbcvkcVAXGpSvfASnnRGpMYvp(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			internal int LUFJwAEzaWVgbReronSENpiDZkrT(ActionElementMap P_0, IList<ActionElementMap> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (P_1[i]._elementIdentifierId == P_0._elementIdentifierId && P_1[i]._axisRange == P_0._axisRange && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
					{
						return i;
					}
				}
				return -1;
			}

			internal int QnzYOqEkAkaplwxnqfKbpWRsPIoO(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			internal string DsDgItDafBeNyKilYUOaKuuCCSXAb(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			internal int glauRXbygyJlMaFtiRsiomKxZEvy(ActionElementMap P_0, IList<ActionElementMap> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (P_1[i]._elementIdentifierId == P_0._elementIdentifierId && P_1[i]._axisRange == P_0._axisRange && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
					{
						return i;
					}
				}
				return -1;
			}

			internal int bWbjDCETbVAUINceOekKKBWvEwkM(ControllerMap_Editor P_0)
			{
				return P_0.id;
			}

			internal string XNLBuypvCzBRWrDHlDXGVcoPbcCp(ControllerMap_Editor P_0)
			{
				return P_0.name;
			}

			internal int cSHeAvFZXzZlgHQjTqwwPYwIXMsz(ActionElementMap P_0, IList<ActionElementMap> P_1)
			{
				for (int i = 0; i < P_1.Count; i++)
				{
					if (P_1[i]._elementIdentifierId == P_0._elementIdentifierId && P_1[i]._axisRange == P_0._axisRange && P_1[i]._axisContribution == P_0._axisContribution && P_1[i]._actionId == P_0._actionId)
					{
						return i;
					}
				}
				return -1;
			}
		}

		private sealed class JMcNoNUevsttVnZhhGoSIcKGNRAs
		{
			public UserData tHuuaeTNzrtjbJrtiEmGPeEvRWfs;

			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> XEvKzRYoyepdvRWzOnXmgBaixqMQ;

			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> rHtcXyEogAJCrTHZMhCkUwdSJZQp;

			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> abRejiKhxnSmcDXWmvjlMIWZMYtzA;

			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> TIHXWIcAitnVWFRHmrLaQIAdjdFFA;

			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> DXdlihKZrJOArYbsHFpYbkZDRKVb;

			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> nLOCbBYVpkosnPuvaAbcRlCpEObb;

			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> MTZZliHTrJQQduZTvpnBiDxlaVav;

			public Func<ControllerType, List<EMTBqctKQkjktmumnmGMHbxhhuVB>> oQVtYxuSBnRavhCtKWKxSSyvhHwT;

			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> dyjAYwazNzDKGDoVBkwaIHTGnCIf;

			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> ZabIizXYkiPraonIdHkDJUInBkAb;

			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> pxreVVFhXOggZpKgVzaHjZWunsZbA;

			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> mvvFNHaGmFwbgTCIDDkcqyvwISSy;

			internal InputActionCategory CYZnAnbtXmUOaNPXrCGQGfTuDjUhA(AkUCLhNIDBBTJcQEscdxfsqfImGV<InputActionCategory> P_0)
			{
				InputActionCategory inputActionCategory = JsonTools.Clone(P_0.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				InputActionCategory inputActionCategory2;
				if (P_0.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					inputActionCategory2 = P_0.LPMFKBtBpONOjBeMYHflRRHyVOHm;
				}
				else
				{
					tHuuaeTNzrtjbJrtiEmGPeEvRWfs.AddActionCategory();
					inputActionCategory2 = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				inputActionCategory.DxydIQkdpBgpQxBGxBhzaNsKYkjEb(inputActionCategory2.id);
				int index = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(inputActionCategory2);
				P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = inputActionCategory;
				return inputActionCategory;
			}

			internal InputBehavior QsShzyChmRdwQmNdLNCFDVLikEtw(AkUCLhNIDBBTJcQEscdxfsqfImGV<InputBehavior> P_0)
			{
				InputBehavior inputBehavior = JsonTools.Clone(P_0.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				InputBehavior inputBehavior2;
				if (P_0.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					inputBehavior2 = P_0.LPMFKBtBpONOjBeMYHflRRHyVOHm;
				}
				else
				{
					tHuuaeTNzrtjbJrtiEmGPeEvRWfs.AddInputBehavior();
					inputBehavior2 = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				inputBehavior.PvvzgovLhWQeTzjOCClzdPKHgnSCA(inputBehavior2.id);
				int index = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(inputBehavior2);
				P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = inputBehavior;
				return inputBehavior;
			}

			internal InputAction rllCqwDklbGqhrRgQFPsfpNBOLRH(AkUCLhNIDBBTJcQEscdxfsqfImGV<InputAction> P_0)
			{
				bKpwnidZQRSOqqmUrLGXCqwwmbxI bKpwnidZQRSOqqmUrLGXCqwwmbxI2 = new bKpwnidZQRSOqqmUrLGXCqwwmbxI();
				bKpwnidZQRSOqqmUrLGXCqwwmbxI2.ucEBrfaStEyfcfTigHUruuHzGjtab = P_0;
				InputAction inputAction = JsonTools.Clone(bKpwnidZQRSOqqmUrLGXCqwwmbxI2.ucEBrfaStEyfcfTigHUruuHzGjtab.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				int num = XEvKzRYoyepdvRWzOnXmgBaixqMQ.Find(bKpwnidZQRSOqqmUrLGXCqwwmbxI2.NoOyAqHBCXZDbkyEBNHoESBZEfqi)?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? 0;
				InputAction inputAction2;
				if (bKpwnidZQRSOqqmUrLGXCqwwmbxI2.ucEBrfaStEyfcfTigHUruuHzGjtab.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					inputAction2 = bKpwnidZQRSOqqmUrLGXCqwwmbxI2.ucEBrfaStEyfcfTigHUruuHzGjtab.LPMFKBtBpONOjBeMYHflRRHyVOHm;
				}
				else
				{
					tHuuaeTNzrtjbJrtiEmGPeEvRWfs.AddAction(num);
					inputAction2 = bKpwnidZQRSOqqmUrLGXCqwwmbxI2.ucEBrfaStEyfcfTigHUruuHzGjtab.NpFvwtIiyVYtkSGjcyGFDSoCiurb[bKpwnidZQRSOqqmUrLGXCqwwmbxI2.ucEBrfaStEyfcfTigHUruuHzGjtab.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				int num2 = rHtcXyEogAJCrTHZMhCkUwdSJZQp.Find(bKpwnidZQRSOqqmUrLGXCqwwmbxI2.msNCahIFERjmvvKgCCRkhSMDbVI)?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? 0;
				inputAction.AMAIZfInlMSYYmanVNuUfsJDsYjb(inputAction2.id);
				if (num != inputAction2.categoryId)
				{
					tHuuaeTNzrtjbJrtiEmGPeEvRWfs.ChangeActionCategory(inputAction2.id, num);
				}
				inputAction.lqxUlhffEKUJrRHeHYZDDZrcIOVq(num);
				inputAction.PiUFsDNerYNrnOuphGYyaUCZBwQk(num2);
				int index = bKpwnidZQRSOqqmUrLGXCqwwmbxI2.ucEBrfaStEyfcfTigHUruuHzGjtab.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(inputAction2);
				bKpwnidZQRSOqqmUrLGXCqwwmbxI2.ucEBrfaStEyfcfTigHUruuHzGjtab.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = inputAction;
				return inputAction;
			}

			internal InputLayout QApURsXNoXdIGAiqbCFkYQGfMkQEA(AkUCLhNIDBBTJcQEscdxfsqfImGV<InputLayout> P_0)
			{
				InputLayout inputLayout = JsonTools.Clone(P_0.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				InputLayout inputLayout2;
				if (P_0.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					inputLayout2 = P_0.LPMFKBtBpONOjBeMYHflRRHyVOHm;
				}
				else
				{
					tHuuaeTNzrtjbJrtiEmGPeEvRWfs.AddKeyboardLayout();
					inputLayout2 = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				inputLayout.rSjyzIcdJPGZvBbKrSRkLscLlslcA(inputLayout2.id);
				int index = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(inputLayout2);
				P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = inputLayout;
				return inputLayout;
			}

			internal InputLayout eRSyHZneeYFqWLcoGKnCTPHdefRC(AkUCLhNIDBBTJcQEscdxfsqfImGV<InputLayout> P_0)
			{
				InputLayout inputLayout = JsonTools.Clone(P_0.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				InputLayout inputLayout2;
				if (P_0.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					inputLayout2 = P_0.LPMFKBtBpONOjBeMYHflRRHyVOHm;
				}
				else
				{
					tHuuaeTNzrtjbJrtiEmGPeEvRWfs.AddMouseLayout();
					inputLayout2 = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				inputLayout.rSjyzIcdJPGZvBbKrSRkLscLlslcA(inputLayout2.id);
				int index = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(inputLayout2);
				P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = inputLayout;
				return inputLayout;
			}

			internal InputLayout cVgCacqBestOLsJpEIDremTspBez(AkUCLhNIDBBTJcQEscdxfsqfImGV<InputLayout> P_0)
			{
				InputLayout inputLayout = JsonTools.Clone(P_0.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				InputLayout inputLayout2;
				if (P_0.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					inputLayout2 = P_0.LPMFKBtBpONOjBeMYHflRRHyVOHm;
				}
				else
				{
					tHuuaeTNzrtjbJrtiEmGPeEvRWfs.AddJoystickLayout();
					inputLayout2 = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				inputLayout.rSjyzIcdJPGZvBbKrSRkLscLlslcA(inputLayout2.id);
				int index = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(inputLayout2);
				P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = inputLayout;
				return inputLayout;
			}

			internal InputLayout AvvIBoAYgLWHZHEOelswqjhgBeIIA(AkUCLhNIDBBTJcQEscdxfsqfImGV<InputLayout> P_0)
			{
				InputLayout inputLayout = JsonTools.Clone(P_0.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				InputLayout inputLayout2;
				if (P_0.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					inputLayout2 = P_0.LPMFKBtBpONOjBeMYHflRRHyVOHm;
				}
				else
				{
					tHuuaeTNzrtjbJrtiEmGPeEvRWfs.AddCustomControllerLayout();
					inputLayout2 = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				inputLayout.rSjyzIcdJPGZvBbKrSRkLscLlslcA(inputLayout2.id);
				int index = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(inputLayout2);
				P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = inputLayout;
				return inputLayout;
			}

			internal List<EMTBqctKQkjktmumnmGMHbxhhuVB> SuwKtozqUDKxRLKShlJjsTdbwzM(ControllerType P_0)
			{
				return P_0 switch
				{
					ControllerType.Keyboard => abRejiKhxnSmcDXWmvjlMIWZMYtzA, 
					ControllerType.Mouse => TIHXWIcAitnVWFRHmrLaQIAdjdFFA, 
					ControllerType.Joystick => DXdlihKZrJOArYbsHFpYbkZDRKVb, 
					ControllerType.Custom => nLOCbBYVpkosnPuvaAbcRlCpEObb, 
					_ => throw new NotImplementedException(), 
				};
			}

			internal CustomController_Editor KQJUMLLdEGijfObnableZaEZIRzP(AkUCLhNIDBBTJcQEscdxfsqfImGV<CustomController_Editor> P_0)
			{
				CustomController_Editor customController_Editor = JsonTools.Clone(P_0.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				CustomController_Editor customController_Editor2;
				if (P_0.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					customController_Editor2 = P_0.LPMFKBtBpONOjBeMYHflRRHyVOHm;
				}
				else
				{
					tHuuaeTNzrtjbJrtiEmGPeEvRWfs.AddCustomController(Guid.Empty);
					customController_Editor2 = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				customController_Editor.id = customController_Editor2.id;
				int index = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(customController_Editor2);
				P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = customController_Editor;
				return customController_Editor;
			}

			internal ControllerMapLayoutManager_RuleSet_Editor QCxuAoNJnJPOigHUyamxADFQSCVeA(AkUCLhNIDBBTJcQEscdxfsqfImGV<ControllerMapLayoutManager_RuleSet_Editor> P_0)
			{
				AbpihfGNGfBEFJmSvupgowdJAwLoA abpihfGNGfBEFJmSvupgowdJAwLoA = new AbpihfGNGfBEFJmSvupgowdJAwLoA();
				abpihfGNGfBEFJmSvupgowdJAwLoA.KBhEXCxnZNprxtvJqJvHTRvokoDm = P_0;
				ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = JsonTools.Clone(abpihfGNGfBEFJmSvupgowdJAwLoA.KBhEXCxnZNprxtvJqJvHTRvokoDm.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				int num = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
				for (int i = 0; i < num; i++)
				{
					ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor = controllerMapLayoutManager_RuleSet_Editor.rules[i];
					if (controllerMapLayoutManager_Rule_Editor == null || controllerMapLayoutManager_Rule_Editor.categoryIds == null)
					{
						continue;
					}
					List<int> list = new List<int>();
					int num2 = ((controllerMapLayoutManager_Rule_Editor.categoryIds != null) ? controllerMapLayoutManager_Rule_Editor.categoryIds.Count : 0);
					for (int j = 0; j < num2; j++)
					{
						xsClRsQcxVmEeAGYspLKOSFMfrkD xsClRsQcxVmEeAGYspLKOSFMfrkD2 = new xsClRsQcxVmEeAGYspLKOSFMfrkD();
						xsClRsQcxVmEeAGYspLKOSFMfrkD2.njCXUOINnTNrRPLMLawMqeNceCqv = abpihfGNGfBEFJmSvupgowdJAwLoA;
						xsClRsQcxVmEeAGYspLKOSFMfrkD2.BUTnZBdfXQFAJkWKJDgmoWpTLMRkA = controllerMapLayoutManager_Rule_Editor.categoryIds[j];
						EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = MTZZliHTrJQQduZTvpnBiDxlaVav.Find(xsClRsQcxVmEeAGYspLKOSFMfrkD2.PJveFqOOwukCCnjXEcGeFMKzSYBs);
						if (eMTBqctKQkjktmumnmGMHbxhhuVB == null)
						{
							Logger.LogError("No new Map Category Id found for old id: " + xsClRsQcxVmEeAGYspLKOSFMfrkD2.BUTnZBdfXQFAJkWKJDgmoWpTLMRkA);
						}
						else
						{
							list.Add(eMTBqctKQkjktmumnmGMHbxhhuVB.EZzutRppqaDjFBdxSrXzucaXHiVnA);
						}
					}
					controllerMapLayoutManager_Rule_Editor.categoryIds = list;
				}
				int num3 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
				for (int k = 0; k < num3; k++)
				{
					LIWsGEfiuoeMiGgOjoVjPQNzCJfhb lIWsGEfiuoeMiGgOjoVjPQNzCJfhb = new LIWsGEfiuoeMiGgOjoVjPQNzCJfhb();
					lIWsGEfiuoeMiGgOjoVjPQNzCJfhb.KemxRXuuafrioIAUVPpofykPCvfr = abpihfGNGfBEFJmSvupgowdJAwLoA;
					ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor2 = controllerMapLayoutManager_RuleSet_Editor.rules[k];
					if (controllerMapLayoutManager_Rule_Editor2 != null && controllerMapLayoutManager_Rule_Editor2.layoutId > 0)
					{
						ControllerType controllerType = controllerMapLayoutManager_Rule_Editor2.controllerSetSelector.controllerType;
						List<EMTBqctKQkjktmumnmGMHbxhhuVB> list2 = oQVtYxuSBnRavhCtKWKxSSyvhHwT(controllerType);
						lIWsGEfiuoeMiGgOjoVjPQNzCJfhb.LzlFCyBoOcGrLSbDfjQIaFreYlgGb = controllerMapLayoutManager_Rule_Editor2.layoutId;
						EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB2 = list2.Find(lIWsGEfiuoeMiGgOjoVjPQNzCJfhb.iWFhkmmlNCFQLKLqFSdhZDaPjSdt);
						if (eMTBqctKQkjktmumnmGMHbxhhuVB2 == null)
						{
							controllerMapLayoutManager_Rule_Editor2.layoutId = -1;
							Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + lIWsGEfiuoeMiGgOjoVjPQNzCJfhb.LzlFCyBoOcGrLSbDfjQIaFreYlgGb);
						}
						else
						{
							controllerMapLayoutManager_Rule_Editor2.layoutId = eMTBqctKQkjktmumnmGMHbxhhuVB2.EZzutRppqaDjFBdxSrXzucaXHiVnA;
						}
					}
				}
				int num4 = ((controllerMapLayoutManager_RuleSet_Editor.rules != null) ? controllerMapLayoutManager_RuleSet_Editor.rules.Count : 0);
				for (int l = 0; l < num4; l++)
				{
					ControllerMapLayoutManager_Rule_Editor controllerMapLayoutManager_Rule_Editor3 = controllerMapLayoutManager_RuleSet_Editor.rules[l];
					if (controllerMapLayoutManager_Rule_Editor3 != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector != null && controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
					{
						CgFDjYxQpONHyrumCkGVWrriEnOf cgFDjYxQpONHyrumCkGVWrriEnOf = new CgFDjYxQpONHyrumCkGVWrriEnOf();
						cgFDjYxQpONHyrumCkGVWrriEnOf.WxqSNHvzHXJpuXzyZtAVSGmYdCzR = abpihfGNGfBEFJmSvupgowdJAwLoA;
						List<EMTBqctKQkjktmumnmGMHbxhhuVB> list3 = dyjAYwazNzDKGDoVBkwaIHTGnCIf;
						cgFDjYxQpONHyrumCkGVWrriEnOf.ueDoqFHhdAhtAcVlBpBaxIUaHXor = controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId;
						EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB3 = list3.Find(cgFDjYxQpONHyrumCkGVWrriEnOf.XwRdNfYNPgELiorCHkGAHDJYbkMs);
						if (eMTBqctKQkjktmumnmGMHbxhhuVB3 == null)
						{
							controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
							Logger.LogError("No new Custom Controller found for old id: " + cgFDjYxQpONHyrumCkGVWrriEnOf.ueDoqFHhdAhtAcVlBpBaxIUaHXor);
						}
						else
						{
							controllerMapLayoutManager_Rule_Editor3.controllerSetSelector.customControllerSourceId = eMTBqctKQkjktmumnmGMHbxhhuVB3.EZzutRppqaDjFBdxSrXzucaXHiVnA;
						}
					}
				}
				ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor2;
				if (abpihfGNGfBEFJmSvupgowdJAwLoA.KBhEXCxnZNprxtvJqJvHTRvokoDm.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					controllerMapLayoutManager_RuleSet_Editor2 = abpihfGNGfBEFJmSvupgowdJAwLoA.KBhEXCxnZNprxtvJqJvHTRvokoDm.LPMFKBtBpONOjBeMYHflRRHyVOHm;
				}
				else
				{
					tHuuaeTNzrtjbJrtiEmGPeEvRWfs.AddControllerMapLayoutManagerRuleSet();
					controllerMapLayoutManager_RuleSet_Editor2 = abpihfGNGfBEFJmSvupgowdJAwLoA.KBhEXCxnZNprxtvJqJvHTRvokoDm.NpFvwtIiyVYtkSGjcyGFDSoCiurb[abpihfGNGfBEFJmSvupgowdJAwLoA.KBhEXCxnZNprxtvJqJvHTRvokoDm.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				controllerMapLayoutManager_RuleSet_Editor.id = controllerMapLayoutManager_RuleSet_Editor2.id;
				int index = abpihfGNGfBEFJmSvupgowdJAwLoA.KBhEXCxnZNprxtvJqJvHTRvokoDm.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(controllerMapLayoutManager_RuleSet_Editor2);
				abpihfGNGfBEFJmSvupgowdJAwLoA.KBhEXCxnZNprxtvJqJvHTRvokoDm.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = controllerMapLayoutManager_RuleSet_Editor;
				return controllerMapLayoutManager_RuleSet_Editor;
			}

			internal ControllerMapEnabler_RuleSet_Editor gqcTJKPeeHYQwMvBlDHCwLqhFpcQ(AkUCLhNIDBBTJcQEscdxfsqfImGV<ControllerMapEnabler_RuleSet_Editor> P_0)
			{
				JLTbqdOyhszziQEiUvMPixKcYJik jLTbqdOyhszziQEiUvMPixKcYJik = new JLTbqdOyhszziQEiUvMPixKcYJik();
				jLTbqdOyhszziQEiUvMPixKcYJik.mUdlfbtMrHaUskFKSizuYNIScNrDA = P_0;
				ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = JsonTools.Clone(jLTbqdOyhszziQEiUvMPixKcYJik.mUdlfbtMrHaUskFKSizuYNIScNrDA.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				int num = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
				for (int i = 0; i < num; i++)
				{
					ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor = controllerMapEnabler_RuleSet_Editor.rules[i];
					if (controllerMapEnabler_Rule_Editor == null || controllerMapEnabler_Rule_Editor.categoryIds == null)
					{
						continue;
					}
					List<int> list = new List<int>();
					for (int j = 0; j < controllerMapEnabler_Rule_Editor.categoryIds.Count; j++)
					{
						dWQqMHRKIKUnTDyqqghPcCJzRxdi dWQqMHRKIKUnTDyqqghPcCJzRxdi2 = new dWQqMHRKIKUnTDyqqghPcCJzRxdi();
						dWQqMHRKIKUnTDyqqghPcCJzRxdi2.SuobcYDskgJFfcQQIHwVxMrowbdKb = jLTbqdOyhszziQEiUvMPixKcYJik;
						dWQqMHRKIKUnTDyqqghPcCJzRxdi2.vOZogPMzhaxuuQzACkCZPhZPrdGH = controllerMapEnabler_Rule_Editor.categoryIds[j];
						EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = MTZZliHTrJQQduZTvpnBiDxlaVav.Find(dWQqMHRKIKUnTDyqqghPcCJzRxdi2.XdGJqAwfGVOPwSBBxwxzrWcWamjw);
						if (eMTBqctKQkjktmumnmGMHbxhhuVB == null)
						{
							Logger.LogError("No new Map Category Id found for old id: " + dWQqMHRKIKUnTDyqqghPcCJzRxdi2.vOZogPMzhaxuuQzACkCZPhZPrdGH);
						}
						else
						{
							list.Add(eMTBqctKQkjktmumnmGMHbxhhuVB.EZzutRppqaDjFBdxSrXzucaXHiVnA);
						}
					}
					controllerMapEnabler_Rule_Editor.categoryIds = list;
				}
				int num2 = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
				for (int k = 0; k < num2; k++)
				{
					ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor2 = controllerMapEnabler_RuleSet_Editor.rules[k];
					if (controllerMapEnabler_Rule_Editor2 == null || controllerMapEnabler_Rule_Editor2.layoutIds == null)
					{
						continue;
					}
					ControllerType controllerType = controllerMapEnabler_Rule_Editor2.controllerSetSelector.controllerType;
					List<EMTBqctKQkjktmumnmGMHbxhhuVB> list2 = oQVtYxuSBnRavhCtKWKxSSyvhHwT(controllerType);
					List<int> list3 = new List<int>();
					int num3 = ((controllerMapEnabler_Rule_Editor2.layoutIds != null) ? controllerMapEnabler_Rule_Editor2.layoutIds.Count : 0);
					for (int l = 0; l < num3; l++)
					{
						RlfmHuKRYUJmVOlZCsUZWkMVYalD rlfmHuKRYUJmVOlZCsUZWkMVYalD = new RlfmHuKRYUJmVOlZCsUZWkMVYalD();
						rlfmHuKRYUJmVOlZCsUZWkMVYalD.JfygzcCbGXuRTjBMcFbFZkJSpois = jLTbqdOyhszziQEiUvMPixKcYJik;
						rlfmHuKRYUJmVOlZCsUZWkMVYalD.WuFFWmchPCjXroaCqjYmZvrQDuBT = controllerMapEnabler_Rule_Editor2.layoutIds[l];
						EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB2 = list2.Find(rlfmHuKRYUJmVOlZCsUZWkMVYalD.pioUMZhQXmqhOvWiBLpiHAYvyxtr);
						if (eMTBqctKQkjktmumnmGMHbxhhuVB2 == null)
						{
							Logger.LogError("No new " + controllerType.ToString() + " Layout Id found for old id: " + rlfmHuKRYUJmVOlZCsUZWkMVYalD.WuFFWmchPCjXroaCqjYmZvrQDuBT);
						}
						else
						{
							list3.Add(eMTBqctKQkjktmumnmGMHbxhhuVB2.EZzutRppqaDjFBdxSrXzucaXHiVnA);
						}
					}
					controllerMapEnabler_Rule_Editor2.layoutIds = list3;
				}
				int num4 = ((controllerMapEnabler_RuleSet_Editor.rules != null) ? controllerMapEnabler_RuleSet_Editor.rules.Count : 0);
				for (int m = 0; m < num4; m++)
				{
					ControllerMapEnabler_Rule_Editor controllerMapEnabler_Rule_Editor3 = controllerMapEnabler_RuleSet_Editor.rules[m];
					if (controllerMapEnabler_Rule_Editor3 != null && controllerMapEnabler_Rule_Editor3.controllerSetSelector != null && controllerMapEnabler_Rule_Editor3.controllerSetSelector.controllerType == ControllerType.Custom)
					{
						AkMabRKUQobRRPsmGTgHDvSGGmFcb akMabRKUQobRRPsmGTgHDvSGGmFcb = new AkMabRKUQobRRPsmGTgHDvSGGmFcb();
						akMabRKUQobRRPsmGTgHDvSGGmFcb.zRTmNmYTWiarEAESLCFUFiNhTgQNA = jLTbqdOyhszziQEiUvMPixKcYJik;
						List<EMTBqctKQkjktmumnmGMHbxhhuVB> list4 = dyjAYwazNzDKGDoVBkwaIHTGnCIf;
						akMabRKUQobRRPsmGTgHDvSGGmFcb.ovHECAmRZnehFCJbTDjvkqminWNEb = controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId;
						EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB3 = list4.Find(akMabRKUQobRRPsmGTgHDvSGGmFcb.CwuhNtIWUzdyoNtRXaphCZuBDpAr);
						if (eMTBqctKQkjktmumnmGMHbxhhuVB3 == null)
						{
							controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = -1;
							Logger.LogError("No new Custom Controller found for old id: " + akMabRKUQobRRPsmGTgHDvSGGmFcb.ovHECAmRZnehFCJbTDjvkqminWNEb);
						}
						else
						{
							controllerMapEnabler_Rule_Editor3.controllerSetSelector.customControllerSourceId = eMTBqctKQkjktmumnmGMHbxhhuVB3.EZzutRppqaDjFBdxSrXzucaXHiVnA;
						}
					}
				}
				ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor2;
				if (jLTbqdOyhszziQEiUvMPixKcYJik.mUdlfbtMrHaUskFKSizuYNIScNrDA.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					controllerMapEnabler_RuleSet_Editor2 = jLTbqdOyhszziQEiUvMPixKcYJik.mUdlfbtMrHaUskFKSizuYNIScNrDA.LPMFKBtBpONOjBeMYHflRRHyVOHm;
				}
				else
				{
					tHuuaeTNzrtjbJrtiEmGPeEvRWfs.AddControllerMapEnablerRuleSet();
					controllerMapEnabler_RuleSet_Editor2 = jLTbqdOyhszziQEiUvMPixKcYJik.mUdlfbtMrHaUskFKSizuYNIScNrDA.NpFvwtIiyVYtkSGjcyGFDSoCiurb[jLTbqdOyhszziQEiUvMPixKcYJik.mUdlfbtMrHaUskFKSizuYNIScNrDA.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				controllerMapEnabler_RuleSet_Editor.id = controllerMapEnabler_RuleSet_Editor2.id;
				int index = jLTbqdOyhszziQEiUvMPixKcYJik.mUdlfbtMrHaUskFKSizuYNIScNrDA.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(controllerMapEnabler_RuleSet_Editor2);
				jLTbqdOyhszziQEiUvMPixKcYJik.mUdlfbtMrHaUskFKSizuYNIScNrDA.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = controllerMapEnabler_RuleSet_Editor;
				return controllerMapEnabler_RuleSet_Editor;
			}

			internal Player_Editor NwryMawhgHjNdvdsquFXSNNFZwWk(AkUCLhNIDBBTJcQEscdxfsqfImGV<Player_Editor> P_0)
			{
				gyhwvYNFcaRpLDadOSFGHmEZgRBGA gyhwvYNFcaRpLDadOSFGHmEZgRBGA2 = new gyhwvYNFcaRpLDadOSFGHmEZgRBGA();
				gyhwvYNFcaRpLDadOSFGHmEZgRBGA2.cWvvOiifPSbFPASamIOEfsSAtWKzA = this;
				gyhwvYNFcaRpLDadOSFGHmEZgRBGA2.YyUThSKioieOepdhzckdFdgMHJJo = P_0;
				Player_Editor player_Editor = JsonTools.Clone(gyhwvYNFcaRpLDadOSFGHmEZgRBGA2.YyUThSKioieOepdhzckdFdgMHJJo.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				Action<List<Player_Editor.Mapping>, List<EMTBqctKQkjktmumnmGMHbxhhuVB>> action = gyhwvYNFcaRpLDadOSFGHmEZgRBGA2.UztYkucAWZajYCfZWHzawzmhdvYQA;
				action(player_Editor.defaultKeyboardMaps, abRejiKhxnSmcDXWmvjlMIWZMYtzA);
				action(player_Editor.defaultMouseMaps, TIHXWIcAitnVWFRHmrLaQIAdjdFFA);
				action(player_Editor.defaultJoystickMaps, DXdlihKZrJOArYbsHFpYbkZDRKVb);
				action(player_Editor.defaultCustomControllerMaps, nLOCbBYVpkosnPuvaAbcRlCpEObb);
				for (int i = 0; i < player_Editor.startingCustomControllers.Count; i++)
				{
					XHCrKddyseMiQoblGAyARAdJuYmT xHCrKddyseMiQoblGAyARAdJuYmT = new XHCrKddyseMiQoblGAyARAdJuYmT();
					xHCrKddyseMiQoblGAyARAdJuYmT.mObQCHjAxjFdlfeWJhKKPRIJLkLlA = gyhwvYNFcaRpLDadOSFGHmEZgRBGA2;
					xHCrKddyseMiQoblGAyARAdJuYmT.rSVTrcjlMVWceSkruxWKlzjnBhfq = player_Editor.startingCustomControllers[i];
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = dyjAYwazNzDKGDoVBkwaIHTGnCIf.Find(xHCrKddyseMiQoblGAyARAdJuYmT.eCUiCraGlhfyoPXHswZtTUPjJehE);
					xHCrKddyseMiQoblGAyARAdJuYmT.rSVTrcjlMVWceSkruxWKlzjnBhfq.AjnBGoRuEOvnvabYJgoctyYeltQw(eMTBqctKQkjktmumnmGMHbxhhuVB?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1));
				}
				List<Player_Editor.RuleSetMapping> list = new List<Player_Editor.RuleSetMapping>();
				List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
				for (int j = 0; j < ruleSets.Count; j++)
				{
					XDIxxeOckaiGjRcuWVNKPfTJtCbc xDIxxeOckaiGjRcuWVNKPfTJtCbc = new XDIxxeOckaiGjRcuWVNKPfTJtCbc();
					xDIxxeOckaiGjRcuWVNKPfTJtCbc.OKVanChFusiPhxtIeRLssHgrtItmA = gyhwvYNFcaRpLDadOSFGHmEZgRBGA2;
					Player_Editor.RuleSetMapping ruleSetMapping = ruleSets[j];
					if (ruleSetMapping != null)
					{
						xDIxxeOckaiGjRcuWVNKPfTJtCbc.hTPtDfJjuUMMkVJdCFYghorIshcr = ruleSetMapping.id;
						EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB2 = ZabIizXYkiPraonIdHkDJUInBkAb.Find(xDIxxeOckaiGjRcuWVNKPfTJtCbc.ZQLDONoWeTvsbkRIbDVSQIhfjyqU);
						if (eMTBqctKQkjktmumnmGMHbxhhuVB2 == null)
						{
							Logger.LogError("No new Controller Map Layout Manager Set found for old id: " + xDIxxeOckaiGjRcuWVNKPfTJtCbc.hTPtDfJjuUMMkVJdCFYghorIshcr);
							continue;
						}
						ruleSetMapping = ruleSetMapping.Clone();
						ruleSetMapping.nZfJvvvfBmaXBUroSuztpnAKGbXs(eMTBqctKQkjktmumnmGMHbxhhuVB2.EZzutRppqaDjFBdxSrXzucaXHiVnA);
						list.Add(ruleSetMapping);
					}
				}
				player_Editor.controllerMapLayoutManagerSettings.ruleSets = list;
				List<Player_Editor.RuleSetMapping> list2 = new List<Player_Editor.RuleSetMapping>();
				List<Player_Editor.RuleSetMapping> ruleSets2 = player_Editor.controllerMapEnablerSettings.ruleSets;
				for (int k = 0; k < ruleSets2.Count; k++)
				{
					SNqoPNjoThEMwzGhZbwZhwluuJKq sNqoPNjoThEMwzGhZbwZhwluuJKq = new SNqoPNjoThEMwzGhZbwZhwluuJKq();
					sNqoPNjoThEMwzGhZbwZhwluuJKq.xsMCBVhlfNrDdNYhYAynYyvekvEP = gyhwvYNFcaRpLDadOSFGHmEZgRBGA2;
					Player_Editor.RuleSetMapping ruleSetMapping2 = ruleSets2[k];
					if (ruleSetMapping2 != null)
					{
						sNqoPNjoThEMwzGhZbwZhwluuJKq.gibtbqvfhmciZEuqRPwREUFEyNfyA = ruleSetMapping2.id;
						EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB3 = pxreVVFhXOggZpKgVzaHjZWunsZbA.Find(sNqoPNjoThEMwzGhZbwZhwluuJKq.NKmKmBtabscvfwZbjPMXMomuPAUD);
						if (eMTBqctKQkjktmumnmGMHbxhhuVB3 == null)
						{
							Logger.LogError("No new Controller Map Enabler Set found for old id: " + sNqoPNjoThEMwzGhZbwZhwluuJKq.gibtbqvfhmciZEuqRPwREUFEyNfyA);
							continue;
						}
						ruleSetMapping2 = ruleSetMapping2.Clone();
						ruleSetMapping2.nZfJvvvfBmaXBUroSuztpnAKGbXs(eMTBqctKQkjktmumnmGMHbxhhuVB3.EZzutRppqaDjFBdxSrXzucaXHiVnA);
						list2.Add(ruleSetMapping2);
					}
				}
				player_Editor.controllerMapEnablerSettings.ruleSets = list2;
				Player_Editor player_Editor2;
				if (gyhwvYNFcaRpLDadOSFGHmEZgRBGA2.YyUThSKioieOepdhzckdFdgMHJJo.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					player_Editor2 = gyhwvYNFcaRpLDadOSFGHmEZgRBGA2.YyUThSKioieOepdhzckdFdgMHJJo.LPMFKBtBpONOjBeMYHflRRHyVOHm;
					Player_Editor player_Editor3 = JsonTools.Clone(player_Editor);
					player_Editor3.defaultKeyboardMaps.Clear();
					player_Editor3.defaultMouseMaps.Clear();
					player_Editor3.defaultJoystickMaps.Clear();
					player_Editor3.defaultCustomControllerMaps.Clear();
					player_Editor3.startingCustomControllers.Clear();
					Func<Player_Editor.Mapping, IList<Player_Editor.Mapping>, int> func = IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.lxMTRmvhmtIDcLbMHCQdkgPfrjLZ;
					MvKdbJsGfApzlAhVgTJkOtoVNkGj(player_Editor2.defaultKeyboardMaps, player_Editor.defaultKeyboardMaps, player_Editor3.defaultKeyboardMaps, func);
					MvKdbJsGfApzlAhVgTJkOtoVNkGj(player_Editor2.defaultMouseMaps, player_Editor.defaultMouseMaps, player_Editor3.defaultMouseMaps, func);
					MvKdbJsGfApzlAhVgTJkOtoVNkGj(player_Editor2.defaultJoystickMaps, player_Editor.defaultJoystickMaps, player_Editor3.defaultJoystickMaps, func);
					MvKdbJsGfApzlAhVgTJkOtoVNkGj(player_Editor2.defaultCustomControllerMaps, player_Editor.defaultCustomControllerMaps, player_Editor3.defaultCustomControllerMaps, func);
					MvKdbJsGfApzlAhVgTJkOtoVNkGj(player_Editor2.startingCustomControllers, player_Editor.startingCustomControllers, player_Editor3.startingCustomControllers, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.UOhfPbIEhshIYGMUKpTcRwKHixrlb);
					player_Editor = player_Editor3;
				}
				else
				{
					tHuuaeTNzrtjbJrtiEmGPeEvRWfs.AddPlayer();
					player_Editor2 = gyhwvYNFcaRpLDadOSFGHmEZgRBGA2.YyUThSKioieOepdhzckdFdgMHJJo.NpFvwtIiyVYtkSGjcyGFDSoCiurb[gyhwvYNFcaRpLDadOSFGHmEZgRBGA2.YyUThSKioieOepdhzckdFdgMHJJo.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				player_Editor.mDREmaITLKWbHjKcJKtjszMGmZFlA(player_Editor2.id);
				int index = gyhwvYNFcaRpLDadOSFGHmEZgRBGA2.YyUThSKioieOepdhzckdFdgMHJJo.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(player_Editor2);
				gyhwvYNFcaRpLDadOSFGHmEZgRBGA2.YyUThSKioieOepdhzckdFdgMHJJo.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = player_Editor;
				return player_Editor;
			}
		}

		private sealed class bKpwnidZQRSOqqmUrLGXCqwwmbxI
		{
			public AkUCLhNIDBBTJcQEscdxfsqfImGV<InputAction> ucEBrfaStEyfcfTigHUruuHzGjtab;

			internal bool NoOyAqHBCXZDbkyEBNHoESBZEfqi(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(ucEBrfaStEyfcfTigHUruuHzGjtab.pRCMTxKbnAIkbSRJednqlinGSSeK) == ucEBrfaStEyfcfTigHUruuHzGjtab.pDHbWPaGiefJBNdhahtQmfpkZJQFA.categoryId;
			}

			internal bool msNCahIFERjmvvKgCCRkhSMDbVI(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(ucEBrfaStEyfcfTigHUruuHzGjtab.pRCMTxKbnAIkbSRJednqlinGSSeK) == ucEBrfaStEyfcfTigHUruuHzGjtab.pDHbWPaGiefJBNdhahtQmfpkZJQFA.behaviorId;
			}
		}

		private sealed class RlfmHuKRYUJmVOlZCsUZWkMVYalD
		{
			public int WuFFWmchPCjXroaCqjYmZvrQDuBT;

			public JLTbqdOyhszziQEiUvMPixKcYJik JfygzcCbGXuRTjBMcFbFZkJSpois;

			internal bool pioUMZhQXmqhOvWiBLpiHAYvyxtr(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(JfygzcCbGXuRTjBMcFbFZkJSpois.mUdlfbtMrHaUskFKSizuYNIScNrDA.pRCMTxKbnAIkbSRJednqlinGSSeK) == WuFFWmchPCjXroaCqjYmZvrQDuBT;
			}
		}

		private sealed class AkMabRKUQobRRPsmGTgHDvSGGmFcb
		{
			public int ovHECAmRZnehFCJbTDjvkqminWNEb;

			public JLTbqdOyhszziQEiUvMPixKcYJik zRTmNmYTWiarEAESLCFUFiNhTgQNA;

			internal bool CwuhNtIWUzdyoNtRXaphCZuBDpAr(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(zRTmNmYTWiarEAESLCFUFiNhTgQNA.mUdlfbtMrHaUskFKSizuYNIScNrDA.pRCMTxKbnAIkbSRJednqlinGSSeK) == ovHECAmRZnehFCJbTDjvkqminWNEb;
			}
		}

		private sealed class gyhwvYNFcaRpLDadOSFGHmEZgRBGA
		{
			public AkUCLhNIDBBTJcQEscdxfsqfImGV<Player_Editor> YyUThSKioieOepdhzckdFdgMHJJo;

			public JMcNoNUevsttVnZhhGoSIcKGNRAs cWvvOiifPSbFPASamIOEfsSAtWKzA;

			internal void UztYkucAWZajYCfZWHzawzmhdvYQA(List<Player_Editor.Mapping> P_0, List<EMTBqctKQkjktmumnmGMHbxhhuVB> P_1)
			{
				for (int i = 0; i < P_0.Count; i++)
				{
					psxQblkPFfTEdBiCwFXapgoGuwXC psxQblkPFfTEdBiCwFXapgoGuwXC2 = new psxQblkPFfTEdBiCwFXapgoGuwXC();
					psxQblkPFfTEdBiCwFXapgoGuwXC2.vXpGNTQlPazKKeJqdbyOLsSZDcMS = this;
					psxQblkPFfTEdBiCwFXapgoGuwXC2.fWovTMoRImSKcWkloPniZGvTlyII = P_0[i];
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = cWvvOiifPSbFPASamIOEfsSAtWKzA.MTZZliHTrJQQduZTvpnBiDxlaVav.Find(psxQblkPFfTEdBiCwFXapgoGuwXC2.ctIlfPvBCPmhgoLhtbcKmbisiwDU);
					psxQblkPFfTEdBiCwFXapgoGuwXC2.fWovTMoRImSKcWkloPniZGvTlyII.JXIwQQJpsgIQkefIQSvlGxYIGZin(eMTBqctKQkjktmumnmGMHbxhhuVB?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1));
					eMTBqctKQkjktmumnmGMHbxhhuVB = P_1.Find(psxQblkPFfTEdBiCwFXapgoGuwXC2.sCLSzPAVyZduoPVhAsIjslfhVeHs);
					psxQblkPFfTEdBiCwFXapgoGuwXC2.fWovTMoRImSKcWkloPniZGvTlyII.RbFKkFgUUcERBNhLMyHaZPjrvCrP(eMTBqctKQkjktmumnmGMHbxhhuVB?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1));
				}
			}
		}

		private sealed class psxQblkPFfTEdBiCwFXapgoGuwXC
		{
			public Player_Editor.Mapping fWovTMoRImSKcWkloPniZGvTlyII;

			public gyhwvYNFcaRpLDadOSFGHmEZgRBGA vXpGNTQlPazKKeJqdbyOLsSZDcMS;

			internal bool ctIlfPvBCPmhgoLhtbcKmbisiwDU(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(vXpGNTQlPazKKeJqdbyOLsSZDcMS.YyUThSKioieOepdhzckdFdgMHJJo.pRCMTxKbnAIkbSRJednqlinGSSeK) == fWovTMoRImSKcWkloPniZGvTlyII.categoryId;
			}

			internal bool sCLSzPAVyZduoPVhAsIjslfhVeHs(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(vXpGNTQlPazKKeJqdbyOLsSZDcMS.YyUThSKioieOepdhzckdFdgMHJJo.pRCMTxKbnAIkbSRJednqlinGSSeK) == fWovTMoRImSKcWkloPniZGvTlyII.layoutId;
			}
		}

		private sealed class XHCrKddyseMiQoblGAyARAdJuYmT
		{
			public Player_Editor.CreateControllerInfo rSVTrcjlMVWceSkruxWKlzjnBhfq;

			public gyhwvYNFcaRpLDadOSFGHmEZgRBGA mObQCHjAxjFdlfeWJhKKPRIJLkLlA;

			internal bool eCUiCraGlhfyoPXHswZtTUPjJehE(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(mObQCHjAxjFdlfeWJhKKPRIJLkLlA.YyUThSKioieOepdhzckdFdgMHJJo.pRCMTxKbnAIkbSRJednqlinGSSeK) == rSVTrcjlMVWceSkruxWKlzjnBhfq.sourceId;
			}
		}

		private sealed class XDIxxeOckaiGjRcuWVNKPfTJtCbc
		{
			public int hTPtDfJjuUMMkVJdCFYghorIshcr;

			public gyhwvYNFcaRpLDadOSFGHmEZgRBGA OKVanChFusiPhxtIeRLssHgrtItmA;

			internal bool ZQLDONoWeTvsbkRIbDVSQIhfjyqU(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(OKVanChFusiPhxtIeRLssHgrtItmA.YyUThSKioieOepdhzckdFdgMHJJo.pRCMTxKbnAIkbSRJednqlinGSSeK) == hTPtDfJjuUMMkVJdCFYghorIshcr;
			}
		}

		private sealed class SNqoPNjoThEMwzGhZbwZhwluuJKq
		{
			public int gibtbqvfhmciZEuqRPwREUFEyNfyA;

			public gyhwvYNFcaRpLDadOSFGHmEZgRBGA xsMCBVhlfNrDdNYhYAynYyvekvEP;

			internal bool NKmKmBtabscvfwZbjPMXMomuPAUD(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(xsMCBVhlfNrDdNYhYAynYyvekvEP.YyUThSKioieOepdhzckdFdgMHJJo.pRCMTxKbnAIkbSRJednqlinGSSeK) == gibtbqvfhmciZEuqRPwREUFEyNfyA;
			}
		}

		private sealed class jacWgbFQPvoQIBpuwwChsXiwdfOc
		{
			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> mFMQFXcoUeRtALxgpTBCIsrCLIvv;

			public JMcNoNUevsttVnZhhGoSIcKGNRAs jYyWQiPXPIMKwWfAnKHjQazyAqCk;

			internal int IrKtUMMFZQPtowvRxVYxALzoWFeL(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
			{
				KCzpflscUVhmCuAftsqpDdBQyVis kCzpflscUVhmCuAftsqpDdBQyVis = new KCzpflscUVhmCuAftsqpDdBQyVis();
				kCzpflscUVhmCuAftsqpDdBQyVis.CZRRQlYpdbUPbDPdVfPNJlajHQXWA = P_0;
				for (int i = 0; i < P_1.Count; i++)
				{
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = jYyWQiPXPIMKwWfAnKHjQazyAqCk.MTZZliHTrJQQduZTvpnBiDxlaVav.Find(kCzpflscUVhmCuAftsqpDdBQyVis.zmAoUDYqdMpXejNARLIVABlsAyDu);
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB2 = mFMQFXcoUeRtALxgpTBCIsrCLIvv.Find(kCzpflscUVhmCuAftsqpDdBQyVis.lfSQdowoWGPlDqjavbmSQuaEuNOl);
					if (eMTBqctKQkjktmumnmGMHbxhhuVB != null && eMTBqctKQkjktmumnmGMHbxhhuVB.EZzutRppqaDjFBdxSrXzucaXHiVnA == P_1[i].categoryId && eMTBqctKQkjktmumnmGMHbxhhuVB2 != null && eMTBqctKQkjktmumnmGMHbxhhuVB2.EZzutRppqaDjFBdxSrXzucaXHiVnA == P_1[i].layoutId)
					{
						return i;
					}
				}
				return -1;
			}

			internal ControllerMap_Editor SzwkfdhIhmbKMEIycPsmXTChDkRBb(AkUCLhNIDBBTJcQEscdxfsqfImGV<ControllerMap_Editor> P_0)
			{
				hDlQVIXcOAhtKAcInHWIyIUhDIDIA hDlQVIXcOAhtKAcInHWIyIUhDIDIA2 = new hDlQVIXcOAhtKAcInHWIyIUhDIDIA();
				hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.IczoswoqMbHAbnDCXIKcFJbGPzFeA = P_0;
				hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.LbJzIEWKdmSTQtcoMepGsqkHfCLK = JsonTools.Clone(hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.IczoswoqMbHAbnDCXIKcFJbGPzFeA.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = jYyWQiPXPIMKwWfAnKHjQazyAqCk.MTZZliHTrJQQduZTvpnBiDxlaVav.Find(hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.YYshCztRgPUJjoERbLJcrOVZEiUj);
				EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB2 = mFMQFXcoUeRtALxgpTBCIsrCLIvv.Find(hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.BvLMEyRjYFHuqdnZKjdxFEEDvMyO);
				hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.LbJzIEWKdmSTQtcoMepGsqkHfCLK.categoryId = eMTBqctKQkjktmumnmGMHbxhhuVB?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
				hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.LbJzIEWKdmSTQtcoMepGsqkHfCLK.layoutId = eMTBqctKQkjktmumnmGMHbxhhuVB2?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
				for (int i = 0; i < hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.LbJzIEWKdmSTQtcoMepGsqkHfCLK.actionElementMaps.Count; i++)
				{
					OIgWALYmezquJNtFbcfOXBEVpTQM oIgWALYmezquJNtFbcfOXBEVpTQM = new OIgWALYmezquJNtFbcfOXBEVpTQM();
					oIgWALYmezquJNtFbcfOXBEVpTQM.vTkhqTxUfgVABsLBTfGahmJQvWE = hDlQVIXcOAhtKAcInHWIyIUhDIDIA2;
					oIgWALYmezquJNtFbcfOXBEVpTQM.PNotYWLqINZOUzEJJBNzXBdYfpai = oIgWALYmezquJNtFbcfOXBEVpTQM.vTkhqTxUfgVABsLBTfGahmJQvWE.LbJzIEWKdmSTQtcoMepGsqkHfCLK.actionElementMaps[i];
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB3 = jYyWQiPXPIMKwWfAnKHjQazyAqCk.mvvFNHaGmFwbgTCIDDkcqyvwISSy.Find(oIgWALYmezquJNtFbcfOXBEVpTQM.HMOQTnaQBHrXFygKvFjWHmxadprkA);
					oIgWALYmezquJNtFbcfOXBEVpTQM.PNotYWLqINZOUzEJJBNzXBdYfpai._actionId = eMTBqctKQkjktmumnmGMHbxhhuVB3?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
					oIgWALYmezquJNtFbcfOXBEVpTQM.PNotYWLqINZOUzEJJBNzXBdYfpai._actionCategoryId = ((jYyWQiPXPIMKwWfAnKHjQazyAqCk.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.GetActionById(oIgWALYmezquJNtFbcfOXBEVpTQM.PNotYWLqINZOUzEJJBNzXBdYfpai._actionId) != null) ? jYyWQiPXPIMKwWfAnKHjQazyAqCk.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.GetActionById(oIgWALYmezquJNtFbcfOXBEVpTQM.PNotYWLqINZOUzEJJBNzXBdYfpai._actionId).categoryId : 0);
				}
				ControllerMap_Editor controllerMap_Editor;
				if (hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.IczoswoqMbHAbnDCXIKcFJbGPzFeA.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					controllerMap_Editor = hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.IczoswoqMbHAbnDCXIKcFJbGPzFeA.LPMFKBtBpONOjBeMYHflRRHyVOHm;
					ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.LbJzIEWKdmSTQtcoMepGsqkHfCLK);
					controllerMap_Editor2.actionElementMaps.Clear();
					Func<ActionElementMap, IList<ActionElementMap>, int> func = IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.SMYqwEluamhgcTkFqraAkLCaoexW;
					MvKdbJsGfApzlAhVgTJkOtoVNkGj(controllerMap_Editor.actionElementMaps, hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.LbJzIEWKdmSTQtcoMepGsqkHfCLK.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
					hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.LbJzIEWKdmSTQtcoMepGsqkHfCLK = controllerMap_Editor2;
				}
				else
				{
					jYyWQiPXPIMKwWfAnKHjQazyAqCk.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.CreateKeyboardMap(hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.LbJzIEWKdmSTQtcoMepGsqkHfCLK.categoryId, hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.LbJzIEWKdmSTQtcoMepGsqkHfCLK.layoutId);
					controllerMap_Editor = hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.IczoswoqMbHAbnDCXIKcFJbGPzFeA.NpFvwtIiyVYtkSGjcyGFDSoCiurb[hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.IczoswoqMbHAbnDCXIKcFJbGPzFeA.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.LbJzIEWKdmSTQtcoMepGsqkHfCLK.id = controllerMap_Editor.id;
				int index = hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.IczoswoqMbHAbnDCXIKcFJbGPzFeA.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(controllerMap_Editor);
				hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.IczoswoqMbHAbnDCXIKcFJbGPzFeA.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.LbJzIEWKdmSTQtcoMepGsqkHfCLK;
				return hDlQVIXcOAhtKAcInHWIyIUhDIDIA2.LbJzIEWKdmSTQtcoMepGsqkHfCLK;
			}
		}

		private sealed class KCzpflscUVhmCuAftsqpDdBQyVis
		{
			public ControllerMap_Editor CZRRQlYpdbUPbDPdVfPNJlajHQXWA;

			public Predicate<EMTBqctKQkjktmumnmGMHbxhhuVB> KtqkTZZuuwFsZOuydKGxKKdecaHJA;

			public Predicate<EMTBqctKQkjktmumnmGMHbxhhuVB> prqgCuhlCiFxkbMtBOGBVZrIOqvgA;

			internal bool zmAoUDYqdMpXejNARLIVABlsAyDu(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.FeHDIJJjflqdaqABjwCBjPNOxqjI == CZRRQlYpdbUPbDPdVfPNJlajHQXWA.categoryId;
			}

			internal bool lfSQdowoWGPlDqjavbmSQuaEuNOl(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.FeHDIJJjflqdaqABjwCBjPNOxqjI == CZRRQlYpdbUPbDPdVfPNJlajHQXWA.layoutId;
			}
		}

		private sealed class hDlQVIXcOAhtKAcInHWIyIUhDIDIA
		{
			public AkUCLhNIDBBTJcQEscdxfsqfImGV<ControllerMap_Editor> IczoswoqMbHAbnDCXIKcFJbGPzFeA;

			public ControllerMap_Editor LbJzIEWKdmSTQtcoMepGsqkHfCLK;

			internal bool YYshCztRgPUJjoERbLJcrOVZEiUj(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(IczoswoqMbHAbnDCXIKcFJbGPzFeA.pRCMTxKbnAIkbSRJednqlinGSSeK) == LbJzIEWKdmSTQtcoMepGsqkHfCLK.categoryId;
			}

			internal bool BvLMEyRjYFHuqdnZKjdxFEEDvMyO(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(IczoswoqMbHAbnDCXIKcFJbGPzFeA.pRCMTxKbnAIkbSRJednqlinGSSeK) == LbJzIEWKdmSTQtcoMepGsqkHfCLK.layoutId;
			}
		}

		private sealed class rfPWheAMhBqTCGoVYAIMDAODwCth
		{
			public List<int> czfEDaZZeuUlNQHTjrdhISfxoYpv;

			public JMcNoNUevsttVnZhhGoSIcKGNRAs zUGjAdtraIchbBDCUKZWBFGejFsg;

			internal InputMapCategory TTsPvcGDClzVpyHMAVOZAHGRECmjA(AkUCLhNIDBBTJcQEscdxfsqfImGV<InputMapCategory> P_0)
			{
				InputMapCategory inputMapCategory = JsonTools.Clone(P_0.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				InputMapCategory inputMapCategory2;
				if (P_0.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					inputMapCategory2 = P_0.LPMFKBtBpONOjBeMYHflRRHyVOHm;
				}
				else
				{
					zUGjAdtraIchbBDCUKZWBFGejFsg.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.AddMapCategory();
					inputMapCategory2 = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				int num = P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(inputMapCategory2);
				if (P_0.pRCMTxKbnAIkbSRJednqlinGSSeK == EMTBqctKQkjktmumnmGMHbxhhuVB.qxaFOZwsZXIbrBMkxDFeDaVYJfWxA.otherId)
				{
					czfEDaZZeuUlNQHTjrdhISfxoYpv.Add(num);
				}
				inputMapCategory.DxydIQkdpBgpQxBGxBhzaNsKYkjEb(inputMapCategory2.id);
				P_0.NpFvwtIiyVYtkSGjcyGFDSoCiurb[num] = inputMapCategory;
				return inputMapCategory;
			}
		}

		private sealed class OIgWALYmezquJNtFbcfOXBEVpTQM
		{
			public ActionElementMap PNotYWLqINZOUzEJJBNzXBdYfpai;

			public hDlQVIXcOAhtKAcInHWIyIUhDIDIA vTkhqTxUfgVABsLBTfGahmJQvWE;

			internal bool HMOQTnaQBHrXFygKvFjWHmxadprkA(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(vTkhqTxUfgVABsLBTfGahmJQvWE.IczoswoqMbHAbnDCXIKcFJbGPzFeA.pRCMTxKbnAIkbSRJednqlinGSSeK) == PNotYWLqINZOUzEJJBNzXBdYfpai._actionId;
			}
		}

		private sealed class SKZuOpxIUIbgztCiLsbTBXIxhHiI
		{
			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> caDRQXBVeuSRsctRHKLEgmMDjwdy;

			public JMcNoNUevsttVnZhhGoSIcKGNRAs bDAxmpGxVdKWHRPoVDdWycHaaZrt;

			internal int WDNEoJcDhDIaBBWdbablnEQGoWnoB(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
			{
				ZMTUAZQtnigqjhBUdxzJIHQlUpiX zMTUAZQtnigqjhBUdxzJIHQlUpiX = new ZMTUAZQtnigqjhBUdxzJIHQlUpiX();
				zMTUAZQtnigqjhBUdxzJIHQlUpiX.fnKAcuIgWvfWcfdRcZbmGEquarVhA = P_0;
				for (int i = 0; i < P_1.Count; i++)
				{
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = bDAxmpGxVdKWHRPoVDdWycHaaZrt.MTZZliHTrJQQduZTvpnBiDxlaVav.Find(zMTUAZQtnigqjhBUdxzJIHQlUpiX.TpIvsMBqcOSIndqiXXBjggWDYdbi);
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB2 = caDRQXBVeuSRsctRHKLEgmMDjwdy.Find(zMTUAZQtnigqjhBUdxzJIHQlUpiX.tsZDRqteeNgxrFYkEnCwSjmShWTlA);
					if (eMTBqctKQkjktmumnmGMHbxhhuVB != null && eMTBqctKQkjktmumnmGMHbxhhuVB.EZzutRppqaDjFBdxSrXzucaXHiVnA == P_1[i].categoryId && eMTBqctKQkjktmumnmGMHbxhhuVB2 != null && eMTBqctKQkjktmumnmGMHbxhhuVB2.EZzutRppqaDjFBdxSrXzucaXHiVnA == P_1[i].layoutId)
					{
						return i;
					}
				}
				return -1;
			}

			internal ControllerMap_Editor DGhtvuKLOdkjlkEKulBWVpreAOnf(AkUCLhNIDBBTJcQEscdxfsqfImGV<ControllerMap_Editor> P_0)
			{
				jcgGAYgkcfLmTdJBoGgFGfJyMvWQ jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2 = new jcgGAYgkcfLmTdJBoGgFGfJyMvWQ();
				jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.pGvttKLEHLWSACNtGVNgCuWuZVnd = P_0;
				jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.yhWTprQtpwYueIuhoAoyonZQLYJf = JsonTools.Clone(jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.pGvttKLEHLWSACNtGVNgCuWuZVnd.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = bDAxmpGxVdKWHRPoVDdWycHaaZrt.MTZZliHTrJQQduZTvpnBiDxlaVav.Find(jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.HRiFOMVcvqCaCHhJYXEiZYlvDFQS);
				EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB2 = caDRQXBVeuSRsctRHKLEgmMDjwdy.Find(jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.sIqHXdnrRODCOlaVMuYgUTjqvFSU);
				jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.yhWTprQtpwYueIuhoAoyonZQLYJf.categoryId = eMTBqctKQkjktmumnmGMHbxhhuVB?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
				jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.yhWTprQtpwYueIuhoAoyonZQLYJf.layoutId = eMTBqctKQkjktmumnmGMHbxhhuVB2?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
				for (int i = 0; i < jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.yhWTprQtpwYueIuhoAoyonZQLYJf.actionElementMaps.Count; i++)
				{
					zEeULIeTsrAUmxfAKfHbxOIIYMEk zEeULIeTsrAUmxfAKfHbxOIIYMEk2 = new zEeULIeTsrAUmxfAKfHbxOIIYMEk();
					zEeULIeTsrAUmxfAKfHbxOIIYMEk2.YkMolxYXDPpfvyCBrarpaZsOTcRw = jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2;
					zEeULIeTsrAUmxfAKfHbxOIIYMEk2.UciUyfHGuYebicihZkRAQzWMqABUA = zEeULIeTsrAUmxfAKfHbxOIIYMEk2.YkMolxYXDPpfvyCBrarpaZsOTcRw.yhWTprQtpwYueIuhoAoyonZQLYJf.actionElementMaps[i];
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB3 = bDAxmpGxVdKWHRPoVDdWycHaaZrt.mvvFNHaGmFwbgTCIDDkcqyvwISSy.Find(zEeULIeTsrAUmxfAKfHbxOIIYMEk2.PhtgrSrbfKfOgVKydcaNKIIqhQRrA);
					zEeULIeTsrAUmxfAKfHbxOIIYMEk2.UciUyfHGuYebicihZkRAQzWMqABUA._actionId = eMTBqctKQkjktmumnmGMHbxhhuVB3?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
					zEeULIeTsrAUmxfAKfHbxOIIYMEk2.UciUyfHGuYebicihZkRAQzWMqABUA._actionCategoryId = ((bDAxmpGxVdKWHRPoVDdWycHaaZrt.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.GetActionById(zEeULIeTsrAUmxfAKfHbxOIIYMEk2.UciUyfHGuYebicihZkRAQzWMqABUA._actionId) != null) ? bDAxmpGxVdKWHRPoVDdWycHaaZrt.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.GetActionById(zEeULIeTsrAUmxfAKfHbxOIIYMEk2.UciUyfHGuYebicihZkRAQzWMqABUA._actionId).categoryId : 0);
				}
				ControllerMap_Editor controllerMap_Editor;
				if (jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.pGvttKLEHLWSACNtGVNgCuWuZVnd.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					controllerMap_Editor = jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.pGvttKLEHLWSACNtGVNgCuWuZVnd.LPMFKBtBpONOjBeMYHflRRHyVOHm;
					ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.yhWTprQtpwYueIuhoAoyonZQLYJf);
					controllerMap_Editor2.actionElementMaps.Clear();
					Func<ActionElementMap, IList<ActionElementMap>, int> func = IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.LUFJwAEzaWVgbReronSENpiDZkrT;
					MvKdbJsGfApzlAhVgTJkOtoVNkGj(controllerMap_Editor.actionElementMaps, jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.yhWTprQtpwYueIuhoAoyonZQLYJf.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
					jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.yhWTprQtpwYueIuhoAoyonZQLYJf = controllerMap_Editor2;
				}
				else
				{
					bDAxmpGxVdKWHRPoVDdWycHaaZrt.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.CreateMouseMap(jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.yhWTprQtpwYueIuhoAoyonZQLYJf.categoryId, jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.yhWTprQtpwYueIuhoAoyonZQLYJf.layoutId);
					controllerMap_Editor = jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.pGvttKLEHLWSACNtGVNgCuWuZVnd.NpFvwtIiyVYtkSGjcyGFDSoCiurb[jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.pGvttKLEHLWSACNtGVNgCuWuZVnd.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.yhWTprQtpwYueIuhoAoyonZQLYJf.id = controllerMap_Editor.id;
				int index = jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.pGvttKLEHLWSACNtGVNgCuWuZVnd.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(controllerMap_Editor);
				jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.pGvttKLEHLWSACNtGVNgCuWuZVnd.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.yhWTprQtpwYueIuhoAoyonZQLYJf;
				return jcgGAYgkcfLmTdJBoGgFGfJyMvWQ2.yhWTprQtpwYueIuhoAoyonZQLYJf;
			}
		}

		private sealed class ZMTUAZQtnigqjhBUdxzJIHQlUpiX
		{
			public ControllerMap_Editor fnKAcuIgWvfWcfdRcZbmGEquarVhA;

			public Predicate<EMTBqctKQkjktmumnmGMHbxhhuVB> XubVvSFxeyqcyHKBUMHeigmCeIWA;

			public Predicate<EMTBqctKQkjktmumnmGMHbxhhuVB> pSlgfbednbCdZLfkZtrauZVUOzjjA;

			internal bool TpIvsMBqcOSIndqiXXBjggWDYdbi(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.FeHDIJJjflqdaqABjwCBjPNOxqjI == fnKAcuIgWvfWcfdRcZbmGEquarVhA.categoryId;
			}

			internal bool tsZDRqteeNgxrFYkEnCwSjmShWTlA(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.FeHDIJJjflqdaqABjwCBjPNOxqjI == fnKAcuIgWvfWcfdRcZbmGEquarVhA.layoutId;
			}
		}

		private sealed class jcgGAYgkcfLmTdJBoGgFGfJyMvWQ
		{
			public AkUCLhNIDBBTJcQEscdxfsqfImGV<ControllerMap_Editor> pGvttKLEHLWSACNtGVNgCuWuZVnd;

			public ControllerMap_Editor yhWTprQtpwYueIuhoAoyonZQLYJf;

			internal bool HRiFOMVcvqCaCHhJYXEiZYlvDFQS(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(pGvttKLEHLWSACNtGVNgCuWuZVnd.pRCMTxKbnAIkbSRJednqlinGSSeK) == yhWTprQtpwYueIuhoAoyonZQLYJf.categoryId;
			}

			internal bool sIqHXdnrRODCOlaVMuYgUTjqvFSU(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(pGvttKLEHLWSACNtGVNgCuWuZVnd.pRCMTxKbnAIkbSRJednqlinGSSeK) == yhWTprQtpwYueIuhoAoyonZQLYJf.layoutId;
			}
		}

		private sealed class zEeULIeTsrAUmxfAKfHbxOIIYMEk
		{
			public ActionElementMap UciUyfHGuYebicihZkRAQzWMqABUA;

			public jcgGAYgkcfLmTdJBoGgFGfJyMvWQ YkMolxYXDPpfvyCBrarpaZsOTcRw;

			internal bool PhtgrSrbfKfOgVKydcaNKIIqhQRrA(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(YkMolxYXDPpfvyCBrarpaZsOTcRw.pGvttKLEHLWSACNtGVNgCuWuZVnd.pRCMTxKbnAIkbSRJednqlinGSSeK) == UciUyfHGuYebicihZkRAQzWMqABUA._actionId;
			}
		}

		private sealed class jXsIDUKuTihqxvyXhbRUGIdBRrvW
		{
			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> AMUVrlAYOCfGTvuIyXCLcqmMthvb;

			public JMcNoNUevsttVnZhhGoSIcKGNRAs RVyAUqffxZbQMaTfJvGsgClnMRhHb;

			internal int nfLlPluOgBlyhdsxOgDTVRSKmJtQ(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
			{
				unnsgSAkFOcxMDJMdSZQAFSETbfm unnsgSAkFOcxMDJMdSZQAFSETbfm2 = new unnsgSAkFOcxMDJMdSZQAFSETbfm();
				unnsgSAkFOcxMDJMdSZQAFSETbfm2.cSAVzBQeKihEDMBRykYbEMucGISo = P_0;
				for (int i = 0; i < P_1.Count; i++)
				{
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = RVyAUqffxZbQMaTfJvGsgClnMRhHb.MTZZliHTrJQQduZTvpnBiDxlaVav.Find(unnsgSAkFOcxMDJMdSZQAFSETbfm2.KrmXXEajCuSHqUCLmHRatthRBKrAA);
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB2 = AMUVrlAYOCfGTvuIyXCLcqmMthvb.Find(unnsgSAkFOcxMDJMdSZQAFSETbfm2.kihtIhvcBnhCLjXUwpeKhcgeZIbNA);
					if (unnsgSAkFOcxMDJMdSZQAFSETbfm2.cSAVzBQeKihEDMBRykYbEMucGISo.hardwareGuid == P_1[i].hardwareGuid && eMTBqctKQkjktmumnmGMHbxhhuVB != null && eMTBqctKQkjktmumnmGMHbxhhuVB.EZzutRppqaDjFBdxSrXzucaXHiVnA == P_1[i].categoryId && eMTBqctKQkjktmumnmGMHbxhhuVB2 != null && eMTBqctKQkjktmumnmGMHbxhhuVB2.EZzutRppqaDjFBdxSrXzucaXHiVnA == P_1[i].layoutId)
					{
						return i;
					}
				}
				return -1;
			}

			internal ControllerMap_Editor XztSJxKSOinLUOcbzMIWLCLXlKEy(AkUCLhNIDBBTJcQEscdxfsqfImGV<ControllerMap_Editor> P_0)
			{
				sbsJDUlfEUlecegwpBUtfrkKYhhG sbsJDUlfEUlecegwpBUtfrkKYhhG2 = new sbsJDUlfEUlecegwpBUtfrkKYhhG();
				sbsJDUlfEUlecegwpBUtfrkKYhhG2.BPrKRsyzohcWiXaGHLgsoIcusGvW = P_0;
				sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv = JsonTools.Clone(sbsJDUlfEUlecegwpBUtfrkKYhhG2.BPrKRsyzohcWiXaGHLgsoIcusGvW.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = RVyAUqffxZbQMaTfJvGsgClnMRhHb.MTZZliHTrJQQduZTvpnBiDxlaVav.Find(sbsJDUlfEUlecegwpBUtfrkKYhhG2.TIoywPxuvCuUXUeJZaKjLateeEjO);
				EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB2 = AMUVrlAYOCfGTvuIyXCLcqmMthvb.Find(sbsJDUlfEUlecegwpBUtfrkKYhhG2.TKDdWktaVwmkPctisdtfPdLLugcr);
				sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv.categoryId = eMTBqctKQkjktmumnmGMHbxhhuVB?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
				sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv.layoutId = eMTBqctKQkjktmumnmGMHbxhhuVB2?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
				for (int i = 0; i < sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv.actionElementMaps.Count; i++)
				{
					eBxFvjCxnEHHXDGPFfNRQMdneOZFb eBxFvjCxnEHHXDGPFfNRQMdneOZFb2 = new eBxFvjCxnEHHXDGPFfNRQMdneOZFb();
					eBxFvjCxnEHHXDGPFfNRQMdneOZFb2.jkoXYZVdZZXreaZNhKekKlbNQDjd = sbsJDUlfEUlecegwpBUtfrkKYhhG2;
					eBxFvjCxnEHHXDGPFfNRQMdneOZFb2.wtlDFZEaaFlRXjfSNnYReMjiYlJw = eBxFvjCxnEHHXDGPFfNRQMdneOZFb2.jkoXYZVdZZXreaZNhKekKlbNQDjd.kfgZectRmzLJzdkKopBjCAaRmNNv.actionElementMaps[i];
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB3 = RVyAUqffxZbQMaTfJvGsgClnMRhHb.mvvFNHaGmFwbgTCIDDkcqyvwISSy.Find(eBxFvjCxnEHHXDGPFfNRQMdneOZFb2.pMfSwUZWpDBXulLtnOEFyCOHtUNN);
					eBxFvjCxnEHHXDGPFfNRQMdneOZFb2.wtlDFZEaaFlRXjfSNnYReMjiYlJw._actionId = eMTBqctKQkjktmumnmGMHbxhhuVB3?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
					eBxFvjCxnEHHXDGPFfNRQMdneOZFb2.wtlDFZEaaFlRXjfSNnYReMjiYlJw._actionCategoryId = ((RVyAUqffxZbQMaTfJvGsgClnMRhHb.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.GetActionById(eBxFvjCxnEHHXDGPFfNRQMdneOZFb2.wtlDFZEaaFlRXjfSNnYReMjiYlJw._actionId) != null) ? RVyAUqffxZbQMaTfJvGsgClnMRhHb.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.GetActionById(eBxFvjCxnEHHXDGPFfNRQMdneOZFb2.wtlDFZEaaFlRXjfSNnYReMjiYlJw._actionId).categoryId : 0);
				}
				ControllerMap_Editor controllerMap_Editor;
				if (sbsJDUlfEUlecegwpBUtfrkKYhhG2.BPrKRsyzohcWiXaGHLgsoIcusGvW.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					controllerMap_Editor = sbsJDUlfEUlecegwpBUtfrkKYhhG2.BPrKRsyzohcWiXaGHLgsoIcusGvW.LPMFKBtBpONOjBeMYHflRRHyVOHm;
					ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv);
					controllerMap_Editor2.actionElementMaps.Clear();
					Func<ActionElementMap, IList<ActionElementMap>, int> func = IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.glauRXbygyJlMaFtiRsiomKxZEvy;
					MvKdbJsGfApzlAhVgTJkOtoVNkGj(controllerMap_Editor.actionElementMaps, sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
					sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv = controllerMap_Editor2;
				}
				else
				{
					RVyAUqffxZbQMaTfJvGsgClnMRhHb.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.CreateJoystickMap(sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv.categoryId, sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv.hardwareGuid, sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv.layoutId);
					controllerMap_Editor = sbsJDUlfEUlecegwpBUtfrkKYhhG2.BPrKRsyzohcWiXaGHLgsoIcusGvW.NpFvwtIiyVYtkSGjcyGFDSoCiurb[sbsJDUlfEUlecegwpBUtfrkKYhhG2.BPrKRsyzohcWiXaGHLgsoIcusGvW.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv.id = controllerMap_Editor.id;
				int index = sbsJDUlfEUlecegwpBUtfrkKYhhG2.BPrKRsyzohcWiXaGHLgsoIcusGvW.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(controllerMap_Editor);
				sbsJDUlfEUlecegwpBUtfrkKYhhG2.BPrKRsyzohcWiXaGHLgsoIcusGvW.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv;
				return sbsJDUlfEUlecegwpBUtfrkKYhhG2.kfgZectRmzLJzdkKopBjCAaRmNNv;
			}
		}

		private sealed class unnsgSAkFOcxMDJMdSZQAFSETbfm
		{
			public ControllerMap_Editor cSAVzBQeKihEDMBRykYbEMucGISo;

			public Predicate<EMTBqctKQkjktmumnmGMHbxhhuVB> cXmZUEwLYyENZESGdNmTcEYgMeho;

			public Predicate<EMTBqctKQkjktmumnmGMHbxhhuVB> kEYttoXIbsOKYPOMHORAljjbvsDn;

			internal bool KrmXXEajCuSHqUCLmHRatthRBKrAA(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.FeHDIJJjflqdaqABjwCBjPNOxqjI == cSAVzBQeKihEDMBRykYbEMucGISo.categoryId;
			}

			internal bool kihtIhvcBnhCLjXUwpeKhcgeZIbNA(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.FeHDIJJjflqdaqABjwCBjPNOxqjI == cSAVzBQeKihEDMBRykYbEMucGISo.layoutId;
			}
		}

		private sealed class sbsJDUlfEUlecegwpBUtfrkKYhhG
		{
			public AkUCLhNIDBBTJcQEscdxfsqfImGV<ControllerMap_Editor> BPrKRsyzohcWiXaGHLgsoIcusGvW;

			public ControllerMap_Editor kfgZectRmzLJzdkKopBjCAaRmNNv;

			internal bool TIoywPxuvCuUXUeJZaKjLateeEjO(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(BPrKRsyzohcWiXaGHLgsoIcusGvW.pRCMTxKbnAIkbSRJednqlinGSSeK) == kfgZectRmzLJzdkKopBjCAaRmNNv.categoryId;
			}

			internal bool TKDdWktaVwmkPctisdtfPdLLugcr(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(BPrKRsyzohcWiXaGHLgsoIcusGvW.pRCMTxKbnAIkbSRJednqlinGSSeK) == kfgZectRmzLJzdkKopBjCAaRmNNv.layoutId;
			}
		}

		private sealed class eBxFvjCxnEHHXDGPFfNRQMdneOZFb
		{
			public ActionElementMap wtlDFZEaaFlRXjfSNnYReMjiYlJw;

			public sbsJDUlfEUlecegwpBUtfrkKYhhG jkoXYZVdZZXreaZNhKekKlbNQDjd;

			internal bool pMfSwUZWpDBXulLtnOEFyCOHtUNN(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(jkoXYZVdZZXreaZNhKekKlbNQDjd.BPrKRsyzohcWiXaGHLgsoIcusGvW.pRCMTxKbnAIkbSRJednqlinGSSeK) == wtlDFZEaaFlRXjfSNnYReMjiYlJw._actionId;
			}
		}

		private sealed class uHOVAlBmNZkFqSAhwMqEUEvnpbVQ
		{
			public List<EMTBqctKQkjktmumnmGMHbxhhuVB> mZNpPiWmgebbHgINFjgyGIAjNdmDA;

			public JMcNoNUevsttVnZhhGoSIcKGNRAs WxZFKLuouNyLEOOurgHenaNAlmKM;

			internal int PBUbDVHkDtkElytEPWfCDxdBJdRn(ControllerMap_Editor P_0, IList<ControllerMap_Editor> P_1)
			{
				INKmZQJaCTgdHGWQUJHWghhPoMPHb iNKmZQJaCTgdHGWQUJHWghhPoMPHb = new INKmZQJaCTgdHGWQUJHWghhPoMPHb();
				iNKmZQJaCTgdHGWQUJHWghhPoMPHb.ierKDkKNTvtpsBhjhgzXDARMTqheA = P_0;
				for (int i = 0; i < P_1.Count; i++)
				{
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = WxZFKLuouNyLEOOurgHenaNAlmKM.dyjAYwazNzDKGDoVBkwaIHTGnCIf.Find(iNKmZQJaCTgdHGWQUJHWghhPoMPHb.aLocqOYZZpSbiZYCxeaxNxONUjEU);
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB2 = WxZFKLuouNyLEOOurgHenaNAlmKM.MTZZliHTrJQQduZTvpnBiDxlaVav.Find(iNKmZQJaCTgdHGWQUJHWghhPoMPHb.GIDARvistgynnKqXXIgqTOFcBCwO);
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB3 = mZNpPiWmgebbHgINFjgyGIAjNdmDA.Find(iNKmZQJaCTgdHGWQUJHWghhPoMPHb.XzHerEjwYQvwjifjUsAGtrEAJnNDb);
					if (eMTBqctKQkjktmumnmGMHbxhhuVB != null && eMTBqctKQkjktmumnmGMHbxhhuVB.EZzutRppqaDjFBdxSrXzucaXHiVnA == P_1[i].customControllerUid && eMTBqctKQkjktmumnmGMHbxhhuVB2 != null && eMTBqctKQkjktmumnmGMHbxhhuVB2.EZzutRppqaDjFBdxSrXzucaXHiVnA == P_1[i].categoryId && eMTBqctKQkjktmumnmGMHbxhhuVB3 != null && eMTBqctKQkjktmumnmGMHbxhhuVB3.EZzutRppqaDjFBdxSrXzucaXHiVnA == P_1[i].layoutId)
					{
						return i;
					}
				}
				return -1;
			}

			internal ControllerMap_Editor tiwcxxIuTaTMkshKgNYDtFMaEdgu(AkUCLhNIDBBTJcQEscdxfsqfImGV<ControllerMap_Editor> P_0)
			{
				bpIRIOVuGjMUHUcimoCadslUExBk bpIRIOVuGjMUHUcimoCadslUExBk2 = new bpIRIOVuGjMUHUcimoCadslUExBk();
				bpIRIOVuGjMUHUcimoCadslUExBk2.DixajOCMteEUGCAyGSeQZRXgXBTPA = P_0;
				bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA = JsonTools.Clone(bpIRIOVuGjMUHUcimoCadslUExBk2.DixajOCMteEUGCAyGSeQZRXgXBTPA.pDHbWPaGiefJBNdhahtQmfpkZJQFA);
				EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = WxZFKLuouNyLEOOurgHenaNAlmKM.dyjAYwazNzDKGDoVBkwaIHTGnCIf.Find(bpIRIOVuGjMUHUcimoCadslUExBk2.FouwFsIpqFeGsaqMywUgGklatCmfA);
				EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB2 = WxZFKLuouNyLEOOurgHenaNAlmKM.MTZZliHTrJQQduZTvpnBiDxlaVav.Find(bpIRIOVuGjMUHUcimoCadslUExBk2.HgAiwrlZYRtTpgAWhyFyAzUbpWxf);
				EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB3 = mZNpPiWmgebbHgINFjgyGIAjNdmDA.Find(bpIRIOVuGjMUHUcimoCadslUExBk2.BLVGMFcfDBZbzHNhZcutCrrjbdznb);
				bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA.customControllerUid = eMTBqctKQkjktmumnmGMHbxhhuVB?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
				bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA.categoryId = eMTBqctKQkjktmumnmGMHbxhhuVB2?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
				bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA.layoutId = eMTBqctKQkjktmumnmGMHbxhhuVB3?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
				for (int i = 0; i < bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA.actionElementMaps.Count; i++)
				{
					ktjaksvRkvGSYActKOThEsEjtTqGA ktjaksvRkvGSYActKOThEsEjtTqGA2 = new ktjaksvRkvGSYActKOThEsEjtTqGA();
					ktjaksvRkvGSYActKOThEsEjtTqGA2.dQiDsucguNOcmcDpKaoNSDIpiqZLA = bpIRIOVuGjMUHUcimoCadslUExBk2;
					ktjaksvRkvGSYActKOThEsEjtTqGA2.WqzGtYPAlpuiIXelgtjMsOSzJOeF = ktjaksvRkvGSYActKOThEsEjtTqGA2.dQiDsucguNOcmcDpKaoNSDIpiqZLA.EWacFdchhBkBdQjONnzuGoGNBFrXA.actionElementMaps[i];
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB4 = WxZFKLuouNyLEOOurgHenaNAlmKM.mvvFNHaGmFwbgTCIDDkcqyvwISSy.Find(ktjaksvRkvGSYActKOThEsEjtTqGA2.wJzOpKxjqUlHBerekpSXOOxKoKGi);
					ktjaksvRkvGSYActKOThEsEjtTqGA2.WqzGtYPAlpuiIXelgtjMsOSzJOeF._actionId = eMTBqctKQkjktmumnmGMHbxhhuVB4?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
					ktjaksvRkvGSYActKOThEsEjtTqGA2.WqzGtYPAlpuiIXelgtjMsOSzJOeF._actionCategoryId = ((WxZFKLuouNyLEOOurgHenaNAlmKM.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.GetActionById(ktjaksvRkvGSYActKOThEsEjtTqGA2.WqzGtYPAlpuiIXelgtjMsOSzJOeF._actionId) != null) ? WxZFKLuouNyLEOOurgHenaNAlmKM.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.GetActionById(ktjaksvRkvGSYActKOThEsEjtTqGA2.WqzGtYPAlpuiIXelgtjMsOSzJOeF._actionId).categoryId : 0);
				}
				ControllerMap_Editor controllerMap_Editor;
				if (bpIRIOVuGjMUHUcimoCadslUExBk2.DixajOCMteEUGCAyGSeQZRXgXBTPA.DdmyTHXsSVJyYojGImhBYgErEfXbA)
				{
					controllerMap_Editor = bpIRIOVuGjMUHUcimoCadslUExBk2.DixajOCMteEUGCAyGSeQZRXgXBTPA.LPMFKBtBpONOjBeMYHflRRHyVOHm;
					ControllerMap_Editor controllerMap_Editor2 = JsonTools.Clone(bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA);
					controllerMap_Editor2.actionElementMaps.Clear();
					Func<ActionElementMap, IList<ActionElementMap>, int> func = IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.cSHeAvFZXzZlgHQjTqwwPYwIXMsz;
					MvKdbJsGfApzlAhVgTJkOtoVNkGj(controllerMap_Editor.actionElementMaps, bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA.actionElementMaps, controllerMap_Editor2.actionElementMaps, func);
					bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA = controllerMap_Editor2;
				}
				else
				{
					WxZFKLuouNyLEOOurgHenaNAlmKM.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.CreateCustomControllerMap(bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA.categoryId, bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA.customControllerUid, bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA.layoutId);
					controllerMap_Editor = bpIRIOVuGjMUHUcimoCadslUExBk2.DixajOCMteEUGCAyGSeQZRXgXBTPA.NpFvwtIiyVYtkSGjcyGFDSoCiurb[bpIRIOVuGjMUHUcimoCadslUExBk2.DixajOCMteEUGCAyGSeQZRXgXBTPA.NpFvwtIiyVYtkSGjcyGFDSoCiurb.Count - 1];
				}
				bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA.id = controllerMap_Editor.id;
				int index = bpIRIOVuGjMUHUcimoCadslUExBk2.DixajOCMteEUGCAyGSeQZRXgXBTPA.NpFvwtIiyVYtkSGjcyGFDSoCiurb.IndexOf(controllerMap_Editor);
				bpIRIOVuGjMUHUcimoCadslUExBk2.DixajOCMteEUGCAyGSeQZRXgXBTPA.NpFvwtIiyVYtkSGjcyGFDSoCiurb[index] = bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA;
				return bpIRIOVuGjMUHUcimoCadslUExBk2.EWacFdchhBkBdQjONnzuGoGNBFrXA;
			}
		}

		private sealed class OYrBHiZKTQQczaJuyYugVGnjdCaF
		{
			public int uDvKnFqlzbXySgXkEAStedzFNTil;

			internal bool NsmjtVzJWZiSZImTbbaPkIeqhvjAA(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.FeHDIJJjflqdaqABjwCBjPNOxqjI == uDvKnFqlzbXySgXkEAStedzFNTil;
			}
		}

		private sealed class INKmZQJaCTgdHGWQUJHWghhPoMPHb
		{
			public ControllerMap_Editor ierKDkKNTvtpsBhjhgzXDARMTqheA;

			public Predicate<EMTBqctKQkjktmumnmGMHbxhhuVB> MFqdakiCgONbhhEIDJPrFgLozBloA;

			public Predicate<EMTBqctKQkjktmumnmGMHbxhhuVB> YsRmjpoHiBEXNhHvWfbmfCzvaqUkA;

			public Predicate<EMTBqctKQkjktmumnmGMHbxhhuVB> CPHbHdGfseBMTvTxqbalwXxpmMwkA;

			internal bool aLocqOYZZpSbiZYCxeaxNxONUjEU(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.FeHDIJJjflqdaqABjwCBjPNOxqjI == ierKDkKNTvtpsBhjhgzXDARMTqheA.customControllerUid;
			}

			internal bool GIDARvistgynnKqXXIgqTOFcBCwO(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.FeHDIJJjflqdaqABjwCBjPNOxqjI == ierKDkKNTvtpsBhjhgzXDARMTqheA.categoryId;
			}

			internal bool XzHerEjwYQvwjifjUsAGtrEAJnNDb(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.FeHDIJJjflqdaqABjwCBjPNOxqjI == ierKDkKNTvtpsBhjhgzXDARMTqheA.layoutId;
			}
		}

		private sealed class bpIRIOVuGjMUHUcimoCadslUExBk
		{
			public AkUCLhNIDBBTJcQEscdxfsqfImGV<ControllerMap_Editor> DixajOCMteEUGCAyGSeQZRXgXBTPA;

			public ControllerMap_Editor EWacFdchhBkBdQjONnzuGoGNBFrXA;

			internal bool FouwFsIpqFeGsaqMywUgGklatCmfA(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(DixajOCMteEUGCAyGSeQZRXgXBTPA.pRCMTxKbnAIkbSRJednqlinGSSeK) == EWacFdchhBkBdQjONnzuGoGNBFrXA.customControllerUid;
			}

			internal bool HgAiwrlZYRtTpgAWhyFyAzUbpWxf(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(DixajOCMteEUGCAyGSeQZRXgXBTPA.pRCMTxKbnAIkbSRJednqlinGSSeK) == EWacFdchhBkBdQjONnzuGoGNBFrXA.categoryId;
			}

			internal bool BLVGMFcfDBZbzHNhZcutCrrjbdznb(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(DixajOCMteEUGCAyGSeQZRXgXBTPA.pRCMTxKbnAIkbSRJednqlinGSSeK) == EWacFdchhBkBdQjONnzuGoGNBFrXA.layoutId;
			}
		}

		private sealed class ktjaksvRkvGSYActKOThEsEjtTqGA
		{
			public ActionElementMap WqzGtYPAlpuiIXelgtjMsOSzJOeF;

			public bpIRIOVuGjMUHUcimoCadslUExBk dQiDsucguNOcmcDpKaoNSDIpiqZLA;

			internal bool wJzOpKxjqUlHBerekpSXOOxKoKGi(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(dQiDsucguNOcmcDpKaoNSDIpiqZLA.DixajOCMteEUGCAyGSeQZRXgXBTPA.pRCMTxKbnAIkbSRJednqlinGSSeK) == WqzGtYPAlpuiIXelgtjMsOSzJOeF._actionId;
			}
		}

		private sealed class AbpihfGNGfBEFJmSvupgowdJAwLoA
		{
			public AkUCLhNIDBBTJcQEscdxfsqfImGV<ControllerMapLayoutManager_RuleSet_Editor> KBhEXCxnZNprxtvJqJvHTRvokoDm;
		}

		private sealed class xsClRsQcxVmEeAGYspLKOSFMfrkD
		{
			public int BUTnZBdfXQFAJkWKJDgmoWpTLMRkA;

			public AbpihfGNGfBEFJmSvupgowdJAwLoA njCXUOINnTNrRPLMLawMqeNceCqv;

			internal bool PJveFqOOwukCCnjXEcGeFMKzSYBs(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(njCXUOINnTNrRPLMLawMqeNceCqv.KBhEXCxnZNprxtvJqJvHTRvokoDm.pRCMTxKbnAIkbSRJednqlinGSSeK) == BUTnZBdfXQFAJkWKJDgmoWpTLMRkA;
			}
		}

		private sealed class LIWsGEfiuoeMiGgOjoVjPQNzCJfhb
		{
			public int LzlFCyBoOcGrLSbDfjQIaFreYlgGb;

			public AbpihfGNGfBEFJmSvupgowdJAwLoA KemxRXuuafrioIAUVPpofykPCvfr;

			internal bool iWFhkmmlNCFQLKLqFSdhZDaPjSdt(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(KemxRXuuafrioIAUVPpofykPCvfr.KBhEXCxnZNprxtvJqJvHTRvokoDm.pRCMTxKbnAIkbSRJednqlinGSSeK) == LzlFCyBoOcGrLSbDfjQIaFreYlgGb;
			}
		}

		private sealed class CgFDjYxQpONHyrumCkGVWrriEnOf
		{
			public int ueDoqFHhdAhtAcVlBpBaxIUaHXor;

			public AbpihfGNGfBEFJmSvupgowdJAwLoA WxqSNHvzHXJpuXzyZtAVSGmYdCzR;

			internal bool XwRdNfYNPgELiorCHkGAHDJYbkMs(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(WxqSNHvzHXJpuXzyZtAVSGmYdCzR.KBhEXCxnZNprxtvJqJvHTRvokoDm.pRCMTxKbnAIkbSRJednqlinGSSeK) == ueDoqFHhdAhtAcVlBpBaxIUaHXor;
			}
		}

		private sealed class JLTbqdOyhszziQEiUvMPixKcYJik
		{
			public AkUCLhNIDBBTJcQEscdxfsqfImGV<ControllerMapEnabler_RuleSet_Editor> mUdlfbtMrHaUskFKSizuYNIScNrDA;
		}

		private sealed class dWQqMHRKIKUnTDyqqghPcCJzRxdi
		{
			public int vOZogPMzhaxuuQzACkCZPhZPrdGH;

			public JLTbqdOyhszziQEiUvMPixKcYJik SuobcYDskgJFfcQQIHwVxMrowbdKb;

			internal bool XdGJqAwfGVOPwSBBxwxzrWcWamjw(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.PZweCeEkmWmseGUbERKfuedIrEJoA(SuobcYDskgJFfcQQIHwVxMrowbdKb.mUdlfbtMrHaUskFKSizuYNIScNrDA.pRCMTxKbnAIkbSRJednqlinGSSeK) == vOZogPMzhaxuuQzACkCZPhZPrdGH;
			}
		}

		private sealed class qiFnePLGpfBAyGgFLdRIRgCoMslEA<_0001> where _0001 : class
		{
			public Func<_0001, int> kAnAFGWJiYCGKdFXBBpqzlucxjBB;
		}

		private sealed class QhvUCMlLldvOhRFnkxqebjYpKYvo<_0001> where _0001 : class
		{
			public _0001 UtzgAqHoJEddYHOqYKbFXmRnyoUeA;

			public qiFnePLGpfBAyGgFLdRIRgCoMslEA<_0001> rQHvjmUIfxBIEEAvWOPsADYsRLKEb;

			internal bool fVUTeuDlRIaHItHnhmPLWRaKefXM(EMTBqctKQkjktmumnmGMHbxhhuVB P_0)
			{
				return P_0.EZzutRppqaDjFBdxSrXzucaXHiVnA == rQHvjmUIfxBIEEAvWOPsADYsRLKEb.kAnAFGWJiYCGKdFXBBpqzlucxjBB(UtzgAqHoJEddYHOqYKbFXmRnyoUeA);
			}
		}

		public static UserData bkFtvVgscRHjHNftiQoieYpgFYtp(UserData P_0, UserData P_1, bool P_2)
		{
			JMcNoNUevsttVnZhhGoSIcKGNRAs jMcNoNUevsttVnZhhGoSIcKGNRAs = new JMcNoNUevsttVnZhhGoSIcKGNRAs();
			if (P_0 == null)
			{
				throw new ArgumentNullException("orig");
			}
			P_0 = JsonTools.Clone(P_0);
			P_1 = ((P_1 != null) ? JsonTools.Clone(P_1) : null);
			jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs = (P_2 ? P_0 : new UserData(false));
			if (P_1 != null)
			{
				jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.configVars = JsonTools.Clone(P_1.configVars);
			}
			else
			{
				jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.configVars = JsonTools.Clone(P_0.configVars);
			}
			jMcNoNUevsttVnZhhGoSIcKGNRAs.XEvKzRYoyepdvRWzOnXmgBaixqMQ = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Action Category", P_0.actionCategories, P_1?.actionCategories, jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.actionCategories, P_2, jMcNoNUevsttVnZhhGoSIcKGNRAs.XEvKzRYoyepdvRWzOnXmgBaixqMQ, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.FynhcjEniIVgTwZJVIWgrRjbDYoe, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.uvoSoNbFIBJhSVQhgbEJwRkVmYyf, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.HhdkRwibxwQQvUbtazNTgCSqdNuEA, jMcNoNUevsttVnZhhGoSIcKGNRAs.CYZnAnbtXmUOaNPXrCGQGfTuDjUhA);
			jMcNoNUevsttVnZhhGoSIcKGNRAs.rHtcXyEogAJCrTHZMhCkUwdSJZQp = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Input Behavior", P_0.inputBehaviors, P_1?.inputBehaviors, jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.inputBehaviors, P_2, jMcNoNUevsttVnZhhGoSIcKGNRAs.rHtcXyEogAJCrTHZMhCkUwdSJZQp, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.JfFOhyyrSsFaiOoTsqHywntDzrgr, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.pXKxurKzUwunAFKVNzWSjnPorhhE, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.weiUSmiRtCwtbXnvrsLCyuVwoIId, jMcNoNUevsttVnZhhGoSIcKGNRAs.QsShzyChmRdwQmNdLNCFDVLikEtw);
			jMcNoNUevsttVnZhhGoSIcKGNRAs.mvvFNHaGmFwbgTCIDDkcqyvwISSy = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Action", P_0.NjqoctZbUFKVxEaddNFBUjRNLoQV(), P_1?.NjqoctZbUFKVxEaddNFBUjRNLoQV(), jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.NjqoctZbUFKVxEaddNFBUjRNLoQV(), P_2, jMcNoNUevsttVnZhhGoSIcKGNRAs.mvvFNHaGmFwbgTCIDDkcqyvwISSy, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.QwXxxdWnVgOsTEUsYfatVcEMgVru, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.hCGIXipkBzuECkgdzKkRhDMTdwTm, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.qxHEZAagbIpFamEFBcaPGpbJeIPt, jMcNoNUevsttVnZhhGoSIcKGNRAs.rllCqwDklbGqhrRgQFPsfpNBOLRH);
			jMcNoNUevsttVnZhhGoSIcKGNRAs.MTZZliHTrJQQduZTvpnBiDxlaVav = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			rfPWheAMhBqTCGoVYAIMDAODwCth rfPWheAMhBqTCGoVYAIMDAODwCth2 = new rfPWheAMhBqTCGoVYAIMDAODwCth();
			rfPWheAMhBqTCGoVYAIMDAODwCth2.zUGjAdtraIchbBDCUKZWBFGejFsg = jMcNoNUevsttVnZhhGoSIcKGNRAs;
			rfPWheAMhBqTCGoVYAIMDAODwCth2.czfEDaZZeuUlNQHTjrdhISfxoYpv = new List<int>();
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Map Category", P_0.mapCategories, P_1?.mapCategories, rfPWheAMhBqTCGoVYAIMDAODwCth2.zUGjAdtraIchbBDCUKZWBFGejFsg.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.mapCategories, P_2, rfPWheAMhBqTCGoVYAIMDAODwCth2.zUGjAdtraIchbBDCUKZWBFGejFsg.MTZZliHTrJQQduZTvpnBiDxlaVav, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.BnnRVOGzfOGahEntzkyiuiKHBIvn, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.XZOgmjpAgLbITpfIIaiAzjJgKVrX, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.AqYHVrPjUktOtekdcUrLbdkZKpiq, rfPWheAMhBqTCGoVYAIMDAODwCth2.TTsPvcGDClzVpyHMAVOZAHGRECmjA);
			for (int i = 0; i < rfPWheAMhBqTCGoVYAIMDAODwCth2.czfEDaZZeuUlNQHTjrdhISfxoYpv.Count; i++)
			{
				int index = rfPWheAMhBqTCGoVYAIMDAODwCth2.czfEDaZZeuUlNQHTjrdhISfxoYpv[i];
				InputMapCategory inputMapCategory = rfPWheAMhBqTCGoVYAIMDAODwCth2.zUGjAdtraIchbBDCUKZWBFGejFsg.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.mapCategories[index];
				for (int j = 0; j < inputMapCategory.cRxpYSLLmekrJJbrwZQuGJpPWkqn().Count; j++)
				{
					OYrBHiZKTQQczaJuyYugVGnjdCaF oYrBHiZKTQQczaJuyYugVGnjdCaF = new OYrBHiZKTQQczaJuyYugVGnjdCaF();
					oYrBHiZKTQQczaJuyYugVGnjdCaF.uDvKnFqlzbXySgXkEAStedzFNTil = inputMapCategory.cRxpYSLLmekrJJbrwZQuGJpPWkqn()[j];
					EMTBqctKQkjktmumnmGMHbxhhuVB eMTBqctKQkjktmumnmGMHbxhhuVB = rfPWheAMhBqTCGoVYAIMDAODwCth2.zUGjAdtraIchbBDCUKZWBFGejFsg.MTZZliHTrJQQduZTvpnBiDxlaVav.Find(oYrBHiZKTQQczaJuyYugVGnjdCaF.NsmjtVzJWZiSZImTbbaPkIeqhvjAA);
					inputMapCategory.cRxpYSLLmekrJJbrwZQuGJpPWkqn()[j] = eMTBqctKQkjktmumnmGMHbxhhuVB?.EZzutRppqaDjFBdxSrXzucaXHiVnA ?? (-1);
				}
			}
			jMcNoNUevsttVnZhhGoSIcKGNRAs.abRejiKhxnSmcDXWmvjlMIWZMYtzA = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Keyboard Layout", P_0.keyboardLayouts, P_1?.keyboardLayouts, jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.keyboardLayouts, P_2, jMcNoNUevsttVnZhhGoSIcKGNRAs.abRejiKhxnSmcDXWmvjlMIWZMYtzA, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.alzdzjnRVafwBOROTgRTIuLJmjRab, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.eAfqQClgddgMaDUSdnVCadTBFybYb, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.rkxmZVpRkrHNaOQmGGXrdjtqwXHy, jMcNoNUevsttVnZhhGoSIcKGNRAs.QApURsXNoXdIGAiqbCFkYQGfMkQEA);
			jMcNoNUevsttVnZhhGoSIcKGNRAs.TIHXWIcAitnVWFRHmrLaQIAdjdFFA = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Mouse Layout", P_0.mouseLayouts, P_1?.mouseLayouts, jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.mouseLayouts, P_2, jMcNoNUevsttVnZhhGoSIcKGNRAs.TIHXWIcAitnVWFRHmrLaQIAdjdFFA, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.QcMtVzowoedXZCpuNstOlpnrNXdG, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.KgjiOkgoPVFZTEdMiVnAuSatVxThA, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.oyMOUWFObuOVcpJWWDDDzOUxQduR, jMcNoNUevsttVnZhhGoSIcKGNRAs.eRSyHZneeYFqWLcoGKnCTPHdefRC);
			jMcNoNUevsttVnZhhGoSIcKGNRAs.DXdlihKZrJOArYbsHFpYbkZDRKVb = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Joystick Layout", P_0.joystickLayouts, P_1?.joystickLayouts, jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.joystickLayouts, P_2, jMcNoNUevsttVnZhhGoSIcKGNRAs.DXdlihKZrJOArYbsHFpYbkZDRKVb, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.XwCNhFMyvKYizfdTehrrDegORQTv, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.JCaHuZFAujAQtUOblMXuFZgfpFYCB, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.yjXRqkIPfKexjeFpaiSgIsDqgOdeA, jMcNoNUevsttVnZhhGoSIcKGNRAs.cVgCacqBestOLsJpEIDremTspBez);
			jMcNoNUevsttVnZhhGoSIcKGNRAs.nLOCbBYVpkosnPuvaAbcRlCpEObb = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Custom Controller Layout", P_0.customControllerLayouts, P_1?.customControllerLayouts, jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.customControllerLayouts, P_2, jMcNoNUevsttVnZhhGoSIcKGNRAs.nLOCbBYVpkosnPuvaAbcRlCpEObb, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.tuhgqIIMRaoLFvFbzHXmLcBEnuxE, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.NZuesRdsrGEvtcKHEOgmbJcgLNLTb, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.XJPcvJEZWgzvVDiKkqhgaeyJxlJwb, jMcNoNUevsttVnZhhGoSIcKGNRAs.AvvIBoAYgLWHZHEOelswqjhgBeIIA);
			jMcNoNUevsttVnZhhGoSIcKGNRAs.oQVtYxuSBnRavhCtKWKxSSyvhHwT = jMcNoNUevsttVnZhhGoSIcKGNRAs.SuwKtozqUDKxRLKShlJjsTdbwzM;
			jMcNoNUevsttVnZhhGoSIcKGNRAs.dyjAYwazNzDKGDoVBkwaIHTGnCIf = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Custom Controller", P_0.customControllers, P_1?.customControllers, jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.customControllers, P_2, jMcNoNUevsttVnZhhGoSIcKGNRAs.dyjAYwazNzDKGDoVBkwaIHTGnCIf, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.JdyNWtskEqMXHPlOQKVyWfeawhGs, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.QFgHHHuVHNPUXdaKHnhHslqFgSdS, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.FOEBSMXuMMPtpYLFNHWaGWVLerlq, jMcNoNUevsttVnZhhGoSIcKGNRAs.KQJUMLLdEGijfObnableZaEZIRzP);
			jMcNoNUevsttVnZhhGoSIcKGNRAs.ZabIizXYkiPraonIdHkDJUInBkAb = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Layout Manager Set", P_0.controllerMapLayoutManagerRuleSets, P_1?.controllerMapLayoutManagerRuleSets, jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.controllerMapLayoutManagerRuleSets, P_2, jMcNoNUevsttVnZhhGoSIcKGNRAs.ZabIizXYkiPraonIdHkDJUInBkAb, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.aphgLItVNLubHsJUHPzQmrmZkFfb, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.GLlYLxfDgfRaIBZZbcpmdfckcVkO, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.uJsFrEKfZaKdEXEksXLmEJOGpfixA, jMcNoNUevsttVnZhhGoSIcKGNRAs.QCxuAoNJnJPOigHUyamxADFQSCVeA);
			jMcNoNUevsttVnZhhGoSIcKGNRAs.pxreVVFhXOggZpKgVzaHjZWunsZbA = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Controller Map Enabler Set", P_0.controllerMapEnablerRuleSets, P_1?.controllerMapEnablerRuleSets, jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.controllerMapEnablerRuleSets, P_2, jMcNoNUevsttVnZhhGoSIcKGNRAs.pxreVVFhXOggZpKgVzaHjZWunsZbA, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.zBcUmRHqNQcbRHNxWXCkxlqAxIJlA, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.RWUyDQYeWheZNDRgbmOPZjymyXPZ, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.UjlcmmdaNUjQYWGKmruSRdVJQnWIA, jMcNoNUevsttVnZhhGoSIcKGNRAs.gqcTJKPeeHYQwMvBlDHCwLqhFpcQ);
			List<EMTBqctKQkjktmumnmGMHbxhhuVB> list = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Player", P_0.players, P_1?.players, jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.players, P_2, list, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.QjCsCtVkCilwkdgYsBlwEiuHhpbh, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.yMPrHOEYiJaxMiaFmmtzAGRANpXI, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.bYifIedoFHdryQHWcqGVhpkkzDDW, jMcNoNUevsttVnZhhGoSIcKGNRAs.NwryMawhgHjNdvdsquFXSNNFZwWk);
			List<EMTBqctKQkjktmumnmGMHbxhhuVB> list2 = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			jacWgbFQPvoQIBpuwwChsXiwdfOc jacWgbFQPvoQIBpuwwChsXiwdfOc2 = new jacWgbFQPvoQIBpuwwChsXiwdfOc();
			jacWgbFQPvoQIBpuwwChsXiwdfOc2.jYyWQiPXPIMKwWfAnKHjQazyAqCk = jMcNoNUevsttVnZhhGoSIcKGNRAs;
			jacWgbFQPvoQIBpuwwChsXiwdfOc2.mFMQFXcoUeRtALxgpTBCIsrCLIvv = jacWgbFQPvoQIBpuwwChsXiwdfOc2.jYyWQiPXPIMKwWfAnKHjQazyAqCk.abRejiKhxnSmcDXWmvjlMIWZMYtzA;
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Keyboard Map", P_0.keyboardMaps, P_1?.keyboardMaps, jacWgbFQPvoQIBpuwwChsXiwdfOc2.jYyWQiPXPIMKwWfAnKHjQazyAqCk.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.keyboardMaps, P_2, list2, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.qnAyDrTREcvkhDZyLkpkYrbZJRsw, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.SGFOtAwJymtBBmUBQMoUVUSYPowr, jacWgbFQPvoQIBpuwwChsXiwdfOc2.IrKtUMMFZQPtowvRxVYxALzoWFeL, jacWgbFQPvoQIBpuwwChsXiwdfOc2.SzwkfdhIhmbKMEIycPsmXTChDkRBb);
			List<EMTBqctKQkjktmumnmGMHbxhhuVB> list3 = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			SKZuOpxIUIbgztCiLsbTBXIxhHiI sKZuOpxIUIbgztCiLsbTBXIxhHiI = new SKZuOpxIUIbgztCiLsbTBXIxhHiI();
			sKZuOpxIUIbgztCiLsbTBXIxhHiI.bDAxmpGxVdKWHRPoVDdWycHaaZrt = jMcNoNUevsttVnZhhGoSIcKGNRAs;
			sKZuOpxIUIbgztCiLsbTBXIxhHiI.caDRQXBVeuSRsctRHKLEgmMDjwdy = sKZuOpxIUIbgztCiLsbTBXIxhHiI.bDAxmpGxVdKWHRPoVDdWycHaaZrt.TIHXWIcAitnVWFRHmrLaQIAdjdFFA;
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Mouse Map", P_0.mouseMaps, P_1?.mouseMaps, sKZuOpxIUIbgztCiLsbTBXIxhHiI.bDAxmpGxVdKWHRPoVDdWycHaaZrt.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.mouseMaps, P_2, list3, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.QpxdFPAszhfhGFrnOcGMdtzIhaqKc, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.zaHBbcvkcVAXGpSvfASnnRGpMYvp, sKZuOpxIUIbgztCiLsbTBXIxhHiI.WDNEoJcDhDIaBBWdbablnEQGoWnoB, sKZuOpxIUIbgztCiLsbTBXIxhHiI.DGhtvuKLOdkjlkEKulBWVpreAOnf);
			List<EMTBqctKQkjktmumnmGMHbxhhuVB> list4 = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			jXsIDUKuTihqxvyXhbRUGIdBRrvW jXsIDUKuTihqxvyXhbRUGIdBRrvW2 = new jXsIDUKuTihqxvyXhbRUGIdBRrvW();
			jXsIDUKuTihqxvyXhbRUGIdBRrvW2.RVyAUqffxZbQMaTfJvGsgClnMRhHb = jMcNoNUevsttVnZhhGoSIcKGNRAs;
			jXsIDUKuTihqxvyXhbRUGIdBRrvW2.AMUVrlAYOCfGTvuIyXCLcqmMthvb = jXsIDUKuTihqxvyXhbRUGIdBRrvW2.RVyAUqffxZbQMaTfJvGsgClnMRhHb.DXdlihKZrJOArYbsHFpYbkZDRKVb;
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Joystick Map", P_0.joystickMaps, P_1?.joystickMaps, jXsIDUKuTihqxvyXhbRUGIdBRrvW2.RVyAUqffxZbQMaTfJvGsgClnMRhHb.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.joystickMaps, P_2, list4, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.QnzYOqEkAkaplwxnqfKbpWRsPIoO, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.DsDgItDafBeNyKilYUOaKuuCCSXAb, jXsIDUKuTihqxvyXhbRUGIdBRrvW2.nfLlPluOgBlyhdsxOgDTVRSKmJtQ, jXsIDUKuTihqxvyXhbRUGIdBRrvW2.XztSJxKSOinLUOcbzMIWLCLXlKEy);
			List<EMTBqctKQkjktmumnmGMHbxhhuVB> list5 = new List<EMTBqctKQkjktmumnmGMHbxhhuVB>();
			uHOVAlBmNZkFqSAhwMqEUEvnpbVQ uHOVAlBmNZkFqSAhwMqEUEvnpbVQ2 = new uHOVAlBmNZkFqSAhwMqEUEvnpbVQ();
			uHOVAlBmNZkFqSAhwMqEUEvnpbVQ2.WxZFKLuouNyLEOOurgHenaNAlmKM = jMcNoNUevsttVnZhhGoSIcKGNRAs;
			uHOVAlBmNZkFqSAhwMqEUEvnpbVQ2.mZNpPiWmgebbHgINFjgyGIAjNdmDA = uHOVAlBmNZkFqSAhwMqEUEvnpbVQ2.WxZFKLuouNyLEOOurgHenaNAlmKM.nLOCbBYVpkosnPuvaAbcRlCpEObb;
			OBPlqoqVBOTIoPmHcRfFDkeVdfSi("Custom Controller Map", P_0.customControllerMaps, P_1?.customControllerMaps, uHOVAlBmNZkFqSAhwMqEUEvnpbVQ2.WxZFKLuouNyLEOOurgHenaNAlmKM.tHuuaeTNzrtjbJrtiEmGPeEvRWfs.customControllerMaps, P_2, list5, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.bWbjDCETbVAUINceOekKKBWvEwkM, IYonyLtWmadQRRrxhrTCfNOMKMZN._003C_003E9.XNLBuypvCzBRWrDHlDXGVcoPbcCp, uHOVAlBmNZkFqSAhwMqEUEvnpbVQ2.PBUbDVHkDtkElytEPWfCDxdBJdRn, uHOVAlBmNZkFqSAhwMqEUEvnpbVQ2.tiwcxxIuTaTMkshKgNYDtFMaEdgu);
			return jMcNoNUevsttVnZhhGoSIcKGNRAs.tHuuaeTNzrtjbJrtiEmGPeEvRWfs;
		}

		[Conditional("DEBUG_IMPORT")]
		private static void qOrAzazEMCIGaGiGjbELzEkgRwj(object P_0)
		{
			Logger.Log("[DEBUG_IMPORT] " + P_0);
		}

		private static void MvKdbJsGfApzlAhVgTJkOtoVNkGj<_0001>(IList<_0001> P_0, IList<_0001> P_1, IList<_0001> P_2, Func<_0001, IList<_0001>, int> P_3)
		{
			for (int i = 0; i < P_0.Count; i++)
			{
				P_2.Add(P_0[i]);
			}
			if (P_1 == null)
			{
				return;
			}
			for (int j = 0; j < P_1.Count; j++)
			{
				_0001 val = P_1[j];
				int num = P_3(val, P_2);
				if (num >= 0)
				{
					P_2[num] = val;
				}
				else
				{
					P_2.Add(val);
				}
			}
		}

		private static void OBPlqoqVBOTIoPmHcRfFDkeVdfSi<_0001>(string P_0, IList<_0001> P_1, IList<_0001> P_2, IList<_0001> P_3, bool P_4, List<EMTBqctKQkjktmumnmGMHbxhhuVB> P_5, Func<_0001, int> P_6, Func<_0001, string> P_7, Func<_0001, IList<_0001>, int> P_8, Func<AkUCLhNIDBBTJcQEscdxfsqfImGV<_0001>, _0001> P_9) where _0001 : class
		{
			qiFnePLGpfBAyGgFLdRIRgCoMslEA<_0001> qiFnePLGpfBAyGgFLdRIRgCoMslEA2 = new qiFnePLGpfBAyGgFLdRIRgCoMslEA<_0001>();
			qiFnePLGpfBAyGgFLdRIRgCoMslEA2.kAnAFGWJiYCGKdFXBBpqzlucxjBB = P_6;
			for (int i = 0; i < P_1.Count; i++)
			{
				_0001 val = P_1[i];
				if (P_4)
				{
					P_5.Add(new EMTBqctKQkjktmumnmGMHbxhhuVB(qiFnePLGpfBAyGgFLdRIRgCoMslEA2.kAnAFGWJiYCGKdFXBBpqzlucxjBB(val), -1, qiFnePLGpfBAyGgFLdRIRgCoMslEA2.kAnAFGWJiYCGKdFXBBpqzlucxjBB(val)));
					continue;
				}
				_0001 arg = P_9(new AkUCLhNIDBBTJcQEscdxfsqfImGV<_0001>(val, null, EMTBqctKQkjktmumnmGMHbxhhuVB.qxaFOZwsZXIbrBMkxDFeDaVYJfWxA.origId, P_3, false));
				P_5.Add(new EMTBqctKQkjktmumnmGMHbxhhuVB(qiFnePLGpfBAyGgFLdRIRgCoMslEA2.kAnAFGWJiYCGKdFXBBpqzlucxjBB(val), -1, qiFnePLGpfBAyGgFLdRIRgCoMslEA2.kAnAFGWJiYCGKdFXBBpqzlucxjBB(arg)));
			}
			if (P_2 == null)
			{
				return;
			}
			for (int j = 0; j < P_2.Count; j++)
			{
				_0001 val2 = P_2[j];
				int num = P_8(val2, P_3);
				if (num >= 0)
				{
					QhvUCMlLldvOhRFnkxqebjYpKYvo<_0001> qhvUCMlLldvOhRFnkxqebjYpKYvo = new QhvUCMlLldvOhRFnkxqebjYpKYvo<_0001>();
					qhvUCMlLldvOhRFnkxqebjYpKYvo.rQHvjmUIfxBIEEAvWOPsADYsRLKEb = qiFnePLGpfBAyGgFLdRIRgCoMslEA2;
					_0001 val3 = P_3[num];
					qhvUCMlLldvOhRFnkxqebjYpKYvo.UtzgAqHoJEddYHOqYKbFXmRnyoUeA = P_9(new AkUCLhNIDBBTJcQEscdxfsqfImGV<_0001>(val2, val3, EMTBqctKQkjktmumnmGMHbxhhuVB.qxaFOZwsZXIbrBMkxDFeDaVYJfWxA.otherId, P_3, true));
					P_5.Find(qhvUCMlLldvOhRFnkxqebjYpKYvo.fVUTeuDlRIaHItHnhmPLWRaKefXM).FeHDIJJjflqdaqABjwCBjPNOxqjI = qhvUCMlLldvOhRFnkxqebjYpKYvo.rQHvjmUIfxBIEEAvWOPsADYsRLKEb.kAnAFGWJiYCGKdFXBBpqzlucxjBB(val2);
					string text = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
					Logger.Log(P_0 + ((!string.IsNullOrEmpty(text)) ? (" " + text) : "") + " already exists. Imported data will replace original.");
				}
				else
				{
					_0001 arg2 = P_9(new AkUCLhNIDBBTJcQEscdxfsqfImGV<_0001>(val2, null, EMTBqctKQkjktmumnmGMHbxhhuVB.qxaFOZwsZXIbrBMkxDFeDaVYJfWxA.otherId, P_3, false));
					P_5.Add(new EMTBqctKQkjktmumnmGMHbxhhuVB(-1, qiFnePLGpfBAyGgFLdRIRgCoMslEA2.kAnAFGWJiYCGKdFXBBpqzlucxjBB(val2), qiFnePLGpfBAyGgFLdRIRgCoMslEA2.kAnAFGWJiYCGKdFXBBpqzlucxjBB(arg2)));
					string text2 = ((!string.IsNullOrEmpty(P_7(val2))) ? ("\"" + P_7(val2) + "\"") : "");
					Logger.Log("Imported new " + P_0 + ((!string.IsNullOrEmpty(text2)) ? (" " + text2) : "") + ".");
				}
			}
		}
	}

	[Serializable]
	private sealed class vKpFkbcuYIVXcnMKdGksbTyDNybbb
	{
		public static readonly vKpFkbcuYIVXcnMKdGksbTyDNybbb _003C_003E9 = new vKpFkbcuYIVXcnMKdGksbTyDNybbb();

		public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__199_0;

		public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__217_0;

		public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__233_0;

		public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__249_0;

		public static Action<List<Player_Editor.Mapping>, int> _003C_003E9__265_0;

		internal void vxDhIcJZPdVaXHpgCFOuwfdAEoQn(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			for (int num = P_0.Count - 1; num >= 0; num--)
			{
				if (P_0[num] == null || P_0[num].categoryId == P_1)
				{
					P_0.RemoveAt(num);
				}
			}
		}

		internal void TLgevpKOWjhoRCSkzxLyfDljJMQS(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			for (int num = P_0.Count - 1; num >= 0; num--)
			{
				if (P_0[num] == null || P_0[num].layoutId == P_1)
				{
					P_0.RemoveAt(num);
				}
			}
		}

		internal void JapRMTDOSqvwLJAHnMbSONeAiNpR(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			for (int num = P_0.Count - 1; num >= 0; num--)
			{
				if (P_0[num] == null || P_0[num].layoutId == P_1)
				{
					P_0.RemoveAt(num);
				}
			}
		}

		internal void mRVlOoULjpHIdCOSMpkIcKsvTamu(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			for (int num = P_0.Count - 1; num >= 0; num--)
			{
				if (P_0[num] == null || P_0[num].layoutId == P_1)
				{
					P_0.RemoveAt(num);
				}
			}
		}

		internal void SLZwLYItQxuEYsTOkeOQcJOoieZF(List<Player_Editor.Mapping> P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			for (int num = P_0.Count - 1; num >= 0; num--)
			{
				if (P_0[num] == null || P_0[num].layoutId == P_1)
				{
					P_0.RemoveAt(num);
				}
			}
		}
	}

	private sealed class YhgNrauaXmCGNqXnFepEFVRrWkECA
	{
		public List<InputLayout> NjdsbOWzivSEWESihjaOVzbAylbk;

		internal int lWPoCddtMzYCEOvxnjQvIMDYwerv(ControllerMap_Editor P_0, ControllerMap_Editor P_1)
		{
			QUAYdDDYjpukuoHesrZoyOXasZLQ qUAYdDDYjpukuoHesrZoyOXasZLQ = new QUAYdDDYjpukuoHesrZoyOXasZLQ();
			qUAYdDDYjpukuoHesrZoyOXasZLQ.LOyUnEoZCWpatRszOLjSlOwlLgXh = P_0;
			qUAYdDDYjpukuoHesrZoyOXasZLQ.DittdUqdevtzPjleefEHMhkOTjGo = P_1;
			int num = NjdsbOWzivSEWESihjaOVzbAylbk.FindIndex(qUAYdDDYjpukuoHesrZoyOXasZLQ.fhJVbTuCYYlqtwHqfbvQolwPRaVB);
			int num2 = NjdsbOWzivSEWESihjaOVzbAylbk.FindIndex(qUAYdDDYjpukuoHesrZoyOXasZLQ.plzXfTZrwwYoOHsRjZYLWFxYwYOH);
			if (num > num2)
			{
				return 1;
			}
			if (num < num2)
			{
				return -1;
			}
			return 0;
		}
	}

	private sealed class QUAYdDDYjpukuoHesrZoyOXasZLQ
	{
		public ControllerMap_Editor LOyUnEoZCWpatRszOLjSlOwlLgXh;

		public ControllerMap_Editor DittdUqdevtzPjleefEHMhkOTjGo;

		internal bool fhJVbTuCYYlqtwHqfbvQolwPRaVB(InputLayout P_0)
		{
			return P_0.id == LOyUnEoZCWpatRszOLjSlOwlLgXh.id;
		}

		internal bool plzXfTZrwwYoOHsRjZYLWFxYwYOH(InputLayout P_0)
		{
			return P_0.id == DittdUqdevtzPjleefEHMhkOTjGo.id;
		}
	}

	private sealed class CjfRnglwKjiMGdrYvFGnOVOOWNHb : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
	{
		private int afGAqxyGiYQMyoETWAPzhlCypXar;

		private InputCategory uKFmFwnJwTqXZnNdWPytoPlGImgI;

		private int diIcsUtHmWibgDMRxDkRLcEvHyuG;

		private string nFKqNjSDrejYvWAiuKKAdQwUppTP;

		public string oyqiNNygxUwIHZcnyxuSaXPxmQWk;

		public UserData vLRvRaZiUdbCCAyDwrXxqYOyvImJ;

		private int ThcmRFsIQOEVDarMLwMFpZdyHbMb;

		InputCategory IEnumerator<InputCategory>.Current
		{
			[DebuggerHidden]
			get
			{
				return uKFmFwnJwTqXZnNdWPytoPlGImgI;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return uKFmFwnJwTqXZnNdWPytoPlGImgI;
			}
		}

		[DebuggerHidden]
		public CjfRnglwKjiMGdrYvFGnOVOOWNHb(int P_0)
		{
			afGAqxyGiYQMyoETWAPzhlCypXar = P_0;
			diIcsUtHmWibgDMRxDkRLcEvHyuG = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = afGAqxyGiYQMyoETWAPzhlCypXar;
			UserData userData = vLRvRaZiUdbCCAyDwrXxqYOyvImJ;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				afGAqxyGiYQMyoETWAPzhlCypXar = -1;
				goto IL_0098;
			}
			afGAqxyGiYQMyoETWAPzhlCypXar = -1;
			if (nFKqNjSDrejYvWAiuKKAdQwUppTP == null || nFKqNjSDrejYvWAiuKKAdQwUppTP == string.Empty)
			{
				return false;
			}
			if (userData.actionCategories == null)
			{
				return false;
			}
			ThcmRFsIQOEVDarMLwMFpZdyHbMb = 0;
			goto IL_00a8;
			IL_00a8:
			if (ThcmRFsIQOEVDarMLwMFpZdyHbMb < userData.actionCategories.Count)
			{
				if (userData.actionCategories[ThcmRFsIQOEVDarMLwMFpZdyHbMb].tag.Equals(nFKqNjSDrejYvWAiuKKAdQwUppTP, StringComparison.OrdinalIgnoreCase))
				{
					uKFmFwnJwTqXZnNdWPytoPlGImgI = userData.actionCategories[ThcmRFsIQOEVDarMLwMFpZdyHbMb];
					afGAqxyGiYQMyoETWAPzhlCypXar = 1;
					return true;
				}
				goto IL_0098;
			}
			return false;
			IL_0098:
			ThcmRFsIQOEVDarMLwMFpZdyHbMb++;
			goto IL_00a8;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
		{
			CjfRnglwKjiMGdrYvFGnOVOOWNHb cjfRnglwKjiMGdrYvFGnOVOOWNHb;
			if (afGAqxyGiYQMyoETWAPzhlCypXar == -2 && diIcsUtHmWibgDMRxDkRLcEvHyuG == Environment.CurrentManagedThreadId)
			{
				afGAqxyGiYQMyoETWAPzhlCypXar = 0;
				cjfRnglwKjiMGdrYvFGnOVOOWNHb = this;
			}
			else
			{
				cjfRnglwKjiMGdrYvFGnOVOOWNHb = new CjfRnglwKjiMGdrYvFGnOVOOWNHb(0);
				cjfRnglwKjiMGdrYvFGnOVOOWNHb.vLRvRaZiUdbCCAyDwrXxqYOyvImJ = vLRvRaZiUdbCCAyDwrXxqYOyvImJ;
			}
			cjfRnglwKjiMGdrYvFGnOVOOWNHb.nFKqNjSDrejYvWAiuKKAdQwUppTP = oyqiNNygxUwIHZcnyxuSaXPxmQWk;
			return cjfRnglwKjiMGdrYvFGnOVOOWNHb;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputCategory>)this).GetEnumerator();
		}
	}

	private sealed class fbDejYaMbwAIxegPIFoRgAZDbUGKd : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
	{
		private int JjidQrpAvvIjGZIoOVCrbyXBclJg;

		private InputAction lrzGxzSuUjzQFmfecOqjaPjPlOyI;

		private int aNWYqLuxxOlBSguJEIQkcldLvHPo;

		public UserData JNbZBybgCfGApDnMpdyyEKkeKLjVB;

		private string GmyfcEjJjYLUMEmMcdwUIYpvlhSe;

		public string QwCihzahNbIcvagSDDkOWSvKPTHR;

		private int KGnhPnLXIUHVOdRHiSBqIEweVOPP;

		private int MCzcCtEEkKXPehxHDZKKEakyrntoA;

		private InputCategory unTNfMWfCqeQlBdbysgpEgHPnCkP;

		private int FRuQmdoYhNQjgWeeZdleJejltMtjA;

		InputAction IEnumerator<InputAction>.Current
		{
			[DebuggerHidden]
			get
			{
				return lrzGxzSuUjzQFmfecOqjaPjPlOyI;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return lrzGxzSuUjzQFmfecOqjaPjPlOyI;
			}
		}

		[DebuggerHidden]
		public fbDejYaMbwAIxegPIFoRgAZDbUGKd(int P_0)
		{
			JjidQrpAvvIjGZIoOVCrbyXBclJg = P_0;
			aNWYqLuxxOlBSguJEIQkcldLvHPo = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int jjidQrpAvvIjGZIoOVCrbyXBclJg = JjidQrpAvvIjGZIoOVCrbyXBclJg;
			UserData jNbZBybgCfGApDnMpdyyEKkeKLjVB = JNbZBybgCfGApDnMpdyyEKkeKLjVB;
			if (jjidQrpAvvIjGZIoOVCrbyXBclJg != 0)
			{
				if (jjidQrpAvvIjGZIoOVCrbyXBclJg != 1)
				{
					return false;
				}
				JjidQrpAvvIjGZIoOVCrbyXBclJg = -1;
				goto IL_00fd;
			}
			JjidQrpAvvIjGZIoOVCrbyXBclJg = -1;
			if (jNbZBybgCfGApDnMpdyyEKkeKLjVB.NjqoctZbUFKVxEaddNFBUjRNLoQV() == null || jNbZBybgCfGApDnMpdyyEKkeKLjVB.actionCategories == null)
			{
				return false;
			}
			if (GmyfcEjJjYLUMEmMcdwUIYpvlhSe == null || GmyfcEjJjYLUMEmMcdwUIYpvlhSe == string.Empty)
			{
				return false;
			}
			KGnhPnLXIUHVOdRHiSBqIEweVOPP = jNbZBybgCfGApDnMpdyyEKkeKLjVB.NjqoctZbUFKVxEaddNFBUjRNLoQV().Count;
			MCzcCtEEkKXPehxHDZKKEakyrntoA = 0;
			goto IL_0132;
			IL_0122:
			MCzcCtEEkKXPehxHDZKKEakyrntoA++;
			goto IL_0132;
			IL_00fd:
			FRuQmdoYhNQjgWeeZdleJejltMtjA++;
			goto IL_010d;
			IL_010d:
			if (FRuQmdoYhNQjgWeeZdleJejltMtjA < KGnhPnLXIUHVOdRHiSBqIEweVOPP)
			{
				if (unTNfMWfCqeQlBdbysgpEgHPnCkP.id == jNbZBybgCfGApDnMpdyyEKkeKLjVB.NjqoctZbUFKVxEaddNFBUjRNLoQV()[FRuQmdoYhNQjgWeeZdleJejltMtjA].categoryId)
				{
					lrzGxzSuUjzQFmfecOqjaPjPlOyI = jNbZBybgCfGApDnMpdyyEKkeKLjVB.NjqoctZbUFKVxEaddNFBUjRNLoQV()[FRuQmdoYhNQjgWeeZdleJejltMtjA];
					JjidQrpAvvIjGZIoOVCrbyXBclJg = 1;
					return true;
				}
				goto IL_00fd;
			}
			unTNfMWfCqeQlBdbysgpEgHPnCkP = null;
			goto IL_0122;
			IL_0132:
			if (MCzcCtEEkKXPehxHDZKKEakyrntoA < jNbZBybgCfGApDnMpdyyEKkeKLjVB.actionCategories.Count)
			{
				if (jNbZBybgCfGApDnMpdyyEKkeKLjVB.actionCategories[MCzcCtEEkKXPehxHDZKKEakyrntoA].tag.Equals(GmyfcEjJjYLUMEmMcdwUIYpvlhSe, StringComparison.OrdinalIgnoreCase))
				{
					unTNfMWfCqeQlBdbysgpEgHPnCkP = jNbZBybgCfGApDnMpdyyEKkeKLjVB.actionCategories[MCzcCtEEkKXPehxHDZKKEakyrntoA];
					FRuQmdoYhNQjgWeeZdleJejltMtjA = 0;
					goto IL_010d;
				}
				goto IL_0122;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
		{
			fbDejYaMbwAIxegPIFoRgAZDbUGKd fbDejYaMbwAIxegPIFoRgAZDbUGKd2;
			if (JjidQrpAvvIjGZIoOVCrbyXBclJg == -2 && aNWYqLuxxOlBSguJEIQkcldLvHPo == Environment.CurrentManagedThreadId)
			{
				JjidQrpAvvIjGZIoOVCrbyXBclJg = 0;
				fbDejYaMbwAIxegPIFoRgAZDbUGKd2 = this;
			}
			else
			{
				fbDejYaMbwAIxegPIFoRgAZDbUGKd2 = new fbDejYaMbwAIxegPIFoRgAZDbUGKd(0);
				fbDejYaMbwAIxegPIFoRgAZDbUGKd2.JNbZBybgCfGApDnMpdyyEKkeKLjVB = JNbZBybgCfGApDnMpdyyEKkeKLjVB;
			}
			fbDejYaMbwAIxegPIFoRgAZDbUGKd2.GmyfcEjJjYLUMEmMcdwUIYpvlhSe = QwCihzahNbIcvagSDDkOWSvKPTHR;
			return fbDejYaMbwAIxegPIFoRgAZDbUGKd2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputAction>)this).GetEnumerator();
		}
	}

	private sealed class XLmrlVguGoXlRuMBLNKQHAGKFcPM : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
	{
		private int fikjLDQzKKRqLJPTUBWtfIVRAxRNA;

		private InputAction weeGZVxFgqOeDYKSBrXVJaSjQSVQ;

		private int NbwDJRfKCHbNrFhVvLxLeqTQBmvWA;

		public UserData jHNcLPamosqbHJQjiReflGUaQLaWA;

		private bool MDzDHtcQkopBwtFELdzifYzGMnUe;

		public bool qXkXUCRpIPxVdyNmaPPlRTSilcZP;

		private int EZbBjItaVocwjdVNEqZHmVnuUKLJ;

		public int AjTwZipmuOLuKLmpWuhBQmABAFWt;

		private IEnumerator<int> kaEDqzJzvesDYcKNkKyQEURSkdVZA;

		private int NDMjhVgcardErASlGcruxZMTFBst;

		InputAction IEnumerator<InputAction>.Current
		{
			[DebuggerHidden]
			get
			{
				return weeGZVxFgqOeDYKSBrXVJaSjQSVQ;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return weeGZVxFgqOeDYKSBrXVJaSjQSVQ;
			}
		}

		[DebuggerHidden]
		public XLmrlVguGoXlRuMBLNKQHAGKFcPM(int P_0)
		{
			fikjLDQzKKRqLJPTUBWtfIVRAxRNA = P_0;
			NbwDJRfKCHbNrFhVvLxLeqTQBmvWA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = fikjLDQzKKRqLJPTUBWtfIVRAxRNA;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					mpbkIkavDjXDEFFVIKTnCNtcMqEc();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = fikjLDQzKKRqLJPTUBWtfIVRAxRNA;
				UserData userData = jHNcLPamosqbHJQjiReflGUaQLaWA;
				switch (num)
				{
				default:
					return false;
				case 0:
					fikjLDQzKKRqLJPTUBWtfIVRAxRNA = -1;
					if (userData.NjqoctZbUFKVxEaddNFBUjRNLoQV() == null || userData.actionCategories == null)
					{
						return false;
					}
					if (MDzDHtcQkopBwtFELdzifYzGMnUe)
					{
						kaEDqzJzvesDYcKNkKyQEURSkdVZA = userData.SortedActionIdsInCategory(EZbBjItaVocwjdVNEqZHmVnuUKLJ).GetEnumerator();
						fikjLDQzKKRqLJPTUBWtfIVRAxRNA = -3;
						goto IL_00a5;
					}
					NDMjhVgcardErASlGcruxZMTFBst = 0;
					goto IL_0123;
				case 1:
					fikjLDQzKKRqLJPTUBWtfIVRAxRNA = -3;
					goto IL_00a5;
				case 2:
					{
						fikjLDQzKKRqLJPTUBWtfIVRAxRNA = -1;
						goto IL_0111;
					}
					IL_0123:
					if (NDMjhVgcardErASlGcruxZMTFBst >= userData.NjqoctZbUFKVxEaddNFBUjRNLoQV().Count)
					{
						break;
					}
					if (userData.NjqoctZbUFKVxEaddNFBUjRNLoQV()[NDMjhVgcardErASlGcruxZMTFBst].categoryId == EZbBjItaVocwjdVNEqZHmVnuUKLJ)
					{
						weeGZVxFgqOeDYKSBrXVJaSjQSVQ = userData.NjqoctZbUFKVxEaddNFBUjRNLoQV()[NDMjhVgcardErASlGcruxZMTFBst];
						fikjLDQzKKRqLJPTUBWtfIVRAxRNA = 2;
						return true;
					}
					goto IL_0111;
					IL_0111:
					NDMjhVgcardErASlGcruxZMTFBst++;
					goto IL_0123;
					IL_00a5:
					while (kaEDqzJzvesDYcKNkKyQEURSkdVZA.MoveNext())
					{
						int current = kaEDqzJzvesDYcKNkKyQEURSkdVZA.Current;
						InputAction actionById = userData.GetActionById(current);
						if (actionById != null)
						{
							weeGZVxFgqOeDYKSBrXVJaSjQSVQ = actionById;
							fikjLDQzKKRqLJPTUBWtfIVRAxRNA = 1;
							return true;
						}
					}
					mpbkIkavDjXDEFFVIKTnCNtcMqEc();
					kaEDqzJzvesDYcKNkKyQEURSkdVZA = null;
					break;
				}
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void mpbkIkavDjXDEFFVIKTnCNtcMqEc()
		{
			fikjLDQzKKRqLJPTUBWtfIVRAxRNA = -1;
			if (kaEDqzJzvesDYcKNkKyQEURSkdVZA != null)
			{
				kaEDqzJzvesDYcKNkKyQEURSkdVZA.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
		{
			XLmrlVguGoXlRuMBLNKQHAGKFcPM xLmrlVguGoXlRuMBLNKQHAGKFcPM;
			if (fikjLDQzKKRqLJPTUBWtfIVRAxRNA == -2 && NbwDJRfKCHbNrFhVvLxLeqTQBmvWA == Environment.CurrentManagedThreadId)
			{
				fikjLDQzKKRqLJPTUBWtfIVRAxRNA = 0;
				xLmrlVguGoXlRuMBLNKQHAGKFcPM = this;
			}
			else
			{
				xLmrlVguGoXlRuMBLNKQHAGKFcPM = new XLmrlVguGoXlRuMBLNKQHAGKFcPM(0);
				xLmrlVguGoXlRuMBLNKQHAGKFcPM.jHNcLPamosqbHJQjiReflGUaQLaWA = jHNcLPamosqbHJQjiReflGUaQLaWA;
			}
			xLmrlVguGoXlRuMBLNKQHAGKFcPM.EZbBjItaVocwjdVNEqZHmVnuUKLJ = AjTwZipmuOLuKLmpWuhBQmABAFWt;
			xLmrlVguGoXlRuMBLNKQHAGKFcPM.MDzDHtcQkopBwtFELdzifYzGMnUe = qXkXUCRpIPxVdyNmaPPlRTSilcZP;
			return xLmrlVguGoXlRuMBLNKQHAGKFcPM;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputAction>)this).GetEnumerator();
		}
	}

	private sealed class mXCorOdlCofpbjGFMBXnGFafeLZKc : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
	{
		private int bbdkSDPhoSHzEVmtGAANgvThOKLwA;

		private InputAction sOfEmwDHvbkilIgzjByCtytAusNyA;

		private int hHaQJWxjOntsXKyPtHRXDvlzHIqj;

		public UserData kNekUoCcHmgtciTdFhpfhBBDKPerB;

		private string nbcHfPgvCoyCMMAGgrwpggrztOMBA;

		public string HjkTfllOYzDuBODwIvsNNrBCJTzb;

		private bool WagAggNTEIOfAecJeiMHXoExDPhCA;

		public bool tspBfeqnIJbKOesgQmpxxiwmqmXfb;

		private InputCategory jvQowVEsrbomTCdYaJDBDPIhFCSz;

		private IEnumerator<int> EzJEvPrfaoMXCOWXLuzzJvgVKWJU;

		private int RuzGbpJvlYSnHOUlSySrogiGjLTV;

		InputAction IEnumerator<InputAction>.Current
		{
			[DebuggerHidden]
			get
			{
				return sOfEmwDHvbkilIgzjByCtytAusNyA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return sOfEmwDHvbkilIgzjByCtytAusNyA;
			}
		}

		[DebuggerHidden]
		public mXCorOdlCofpbjGFMBXnGFafeLZKc(int P_0)
		{
			bbdkSDPhoSHzEVmtGAANgvThOKLwA = P_0;
			hHaQJWxjOntsXKyPtHRXDvlzHIqj = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = bbdkSDPhoSHzEVmtGAANgvThOKLwA;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					EsMMKcRqLVhkdngSmlRdKLfkYWlj();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = bbdkSDPhoSHzEVmtGAANgvThOKLwA;
				UserData userData = kNekUoCcHmgtciTdFhpfhBBDKPerB;
				switch (num)
				{
				default:
					return false;
				case 0:
				{
					bbdkSDPhoSHzEVmtGAANgvThOKLwA = -1;
					if (userData.NjqoctZbUFKVxEaddNFBUjRNLoQV() == null || userData.actionCategories == null)
					{
						return false;
					}
					if (nbcHfPgvCoyCMMAGgrwpggrztOMBA == null || nbcHfPgvCoyCMMAGgrwpggrztOMBA == string.Empty)
					{
						return false;
					}
					int num2 = userData.IndexOfActionCategory(nbcHfPgvCoyCMMAGgrwpggrztOMBA);
					if (num2 < 0)
					{
						return false;
					}
					jvQowVEsrbomTCdYaJDBDPIhFCSz = userData.GetActionCategory(num2);
					if (WagAggNTEIOfAecJeiMHXoExDPhCA)
					{
						EzJEvPrfaoMXCOWXLuzzJvgVKWJU = userData.SortedActionIdsInCategory(jvQowVEsrbomTCdYaJDBDPIhFCSz.id).GetEnumerator();
						bbdkSDPhoSHzEVmtGAANgvThOKLwA = -3;
						goto IL_00f2;
					}
					RuzGbpJvlYSnHOUlSySrogiGjLTV = 0;
					goto IL_0175;
				}
				case 1:
					bbdkSDPhoSHzEVmtGAANgvThOKLwA = -3;
					goto IL_00f2;
				case 2:
					{
						bbdkSDPhoSHzEVmtGAANgvThOKLwA = -1;
						goto IL_0163;
					}
					IL_0175:
					if (RuzGbpJvlYSnHOUlSySrogiGjLTV >= userData.NjqoctZbUFKVxEaddNFBUjRNLoQV().Count)
					{
						break;
					}
					if (userData.NjqoctZbUFKVxEaddNFBUjRNLoQV()[RuzGbpJvlYSnHOUlSySrogiGjLTV].categoryId == jvQowVEsrbomTCdYaJDBDPIhFCSz.id)
					{
						sOfEmwDHvbkilIgzjByCtytAusNyA = userData.NjqoctZbUFKVxEaddNFBUjRNLoQV()[RuzGbpJvlYSnHOUlSySrogiGjLTV];
						bbdkSDPhoSHzEVmtGAANgvThOKLwA = 2;
						return true;
					}
					goto IL_0163;
					IL_00f2:
					while (EzJEvPrfaoMXCOWXLuzzJvgVKWJU.MoveNext())
					{
						int current = EzJEvPrfaoMXCOWXLuzzJvgVKWJU.Current;
						InputAction actionById = userData.GetActionById(current);
						if (actionById != null)
						{
							sOfEmwDHvbkilIgzjByCtytAusNyA = actionById;
							bbdkSDPhoSHzEVmtGAANgvThOKLwA = 1;
							return true;
						}
					}
					EsMMKcRqLVhkdngSmlRdKLfkYWlj();
					EzJEvPrfaoMXCOWXLuzzJvgVKWJU = null;
					break;
					IL_0163:
					RuzGbpJvlYSnHOUlSySrogiGjLTV++;
					goto IL_0175;
				}
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void EsMMKcRqLVhkdngSmlRdKLfkYWlj()
		{
			bbdkSDPhoSHzEVmtGAANgvThOKLwA = -1;
			if (EzJEvPrfaoMXCOWXLuzzJvgVKWJU != null)
			{
				EzJEvPrfaoMXCOWXLuzzJvgVKWJU.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
		{
			mXCorOdlCofpbjGFMBXnGFafeLZKc mXCorOdlCofpbjGFMBXnGFafeLZKc2;
			if (bbdkSDPhoSHzEVmtGAANgvThOKLwA == -2 && hHaQJWxjOntsXKyPtHRXDvlzHIqj == Environment.CurrentManagedThreadId)
			{
				bbdkSDPhoSHzEVmtGAANgvThOKLwA = 0;
				mXCorOdlCofpbjGFMBXnGFafeLZKc2 = this;
			}
			else
			{
				mXCorOdlCofpbjGFMBXnGFafeLZKc2 = new mXCorOdlCofpbjGFMBXnGFafeLZKc(0);
				mXCorOdlCofpbjGFMBXnGFafeLZKc2.kNekUoCcHmgtciTdFhpfhBBDKPerB = kNekUoCcHmgtciTdFhpfhBBDKPerB;
			}
			mXCorOdlCofpbjGFMBXnGFafeLZKc2.nbcHfPgvCoyCMMAGgrwpggrztOMBA = HjkTfllOYzDuBODwIvsNNrBCJTzb;
			mXCorOdlCofpbjGFMBXnGFafeLZKc2.WagAggNTEIOfAecJeiMHXoExDPhCA = tspBfeqnIJbKOesgQmpxxiwmqmXfb;
			return mXCorOdlCofpbjGFMBXnGFafeLZKc2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputAction>)this).GetEnumerator();
		}
	}

	private sealed class NDGcbamLuPaYamRAjsFzngAaoLhA : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
	{
		private int sPJEWDYySfjsgQsKFhmOLUDNxfiA;

		private InputMapCategory MVByxCrlZOWzclwXedELDpDxdvLD;

		private int tCTMecgUevHUfQUJkRttkuIdPTEb;

		private string CqCkuPyNoXCqgkWqfsEbHSjsqfptA;

		public string hXDiktsfQGqrsIpDZTgpiihInCyS;

		public UserData pSgWHyMgrPTNRfRCMCHvTCgatvTh;

		private int rEqAAlAOjgMfBtRRlSIJOMdNUAVJ;

		InputMapCategory IEnumerator<InputMapCategory>.Current
		{
			[DebuggerHidden]
			get
			{
				return MVByxCrlZOWzclwXedELDpDxdvLD;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return MVByxCrlZOWzclwXedELDpDxdvLD;
			}
		}

		[DebuggerHidden]
		public NDGcbamLuPaYamRAjsFzngAaoLhA(int P_0)
		{
			sPJEWDYySfjsgQsKFhmOLUDNxfiA = P_0;
			tCTMecgUevHUfQUJkRttkuIdPTEb = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = sPJEWDYySfjsgQsKFhmOLUDNxfiA;
			UserData userData = pSgWHyMgrPTNRfRCMCHvTCgatvTh;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				sPJEWDYySfjsgQsKFhmOLUDNxfiA = -1;
				goto IL_0098;
			}
			sPJEWDYySfjsgQsKFhmOLUDNxfiA = -1;
			if (CqCkuPyNoXCqgkWqfsEbHSjsqfptA == null || CqCkuPyNoXCqgkWqfsEbHSjsqfptA == string.Empty)
			{
				return false;
			}
			if (userData.mapCategories == null)
			{
				return false;
			}
			rEqAAlAOjgMfBtRRlSIJOMdNUAVJ = 0;
			goto IL_00a8;
			IL_00a8:
			if (rEqAAlAOjgMfBtRRlSIJOMdNUAVJ < userData.mapCategories.Count)
			{
				if (userData.mapCategories[rEqAAlAOjgMfBtRRlSIJOMdNUAVJ].tag.Equals(CqCkuPyNoXCqgkWqfsEbHSjsqfptA, StringComparison.OrdinalIgnoreCase))
				{
					MVByxCrlZOWzclwXedELDpDxdvLD = userData.mapCategories[rEqAAlAOjgMfBtRRlSIJOMdNUAVJ];
					sPJEWDYySfjsgQsKFhmOLUDNxfiA = 1;
					return true;
				}
				goto IL_0098;
			}
			return false;
			IL_0098:
			rEqAAlAOjgMfBtRRlSIJOMdNUAVJ++;
			goto IL_00a8;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
		{
			NDGcbamLuPaYamRAjsFzngAaoLhA nDGcbamLuPaYamRAjsFzngAaoLhA;
			if (sPJEWDYySfjsgQsKFhmOLUDNxfiA == -2 && tCTMecgUevHUfQUJkRttkuIdPTEb == Environment.CurrentManagedThreadId)
			{
				sPJEWDYySfjsgQsKFhmOLUDNxfiA = 0;
				nDGcbamLuPaYamRAjsFzngAaoLhA = this;
			}
			else
			{
				nDGcbamLuPaYamRAjsFzngAaoLhA = new NDGcbamLuPaYamRAjsFzngAaoLhA(0);
				nDGcbamLuPaYamRAjsFzngAaoLhA.pSgWHyMgrPTNRfRCMCHvTCgatvTh = pSgWHyMgrPTNRfRCMCHvTCgatvTh;
			}
			nDGcbamLuPaYamRAjsFzngAaoLhA.CqCkuPyNoXCqgkWqfsEbHSjsqfptA = hXDiktsfQGqrsIpDZTgpiihInCyS;
			return nDGcbamLuPaYamRAjsFzngAaoLhA;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
		}
	}

	private sealed class gPOXZePIQTAyvfXbdxkoIMShOTtJ : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int JdKjMwFJeDicquLLrlLeuRBMHmMU;

		private string BktcSLaQRtTzGsXYqMDNAArEDWhgb;

		private int tHmGGIHKWQMoawartmLLZDvVBFtxA;

		public UserData PzBTlZLXTMtyomsLzlqetqNICdKEA;

		private int dMgOSZPwaaTAPvRAIYyRdDSODcOD;

		public int LSTCZCOANqTxkVNMHJWhdMsPdrXM;

		private IEnumerator<int> DGQGqaNVQxyygKlcDyfMSFZEDBRd;

		string IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return BktcSLaQRtTzGsXYqMDNAArEDWhgb;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return BktcSLaQRtTzGsXYqMDNAArEDWhgb;
			}
		}

		[DebuggerHidden]
		public gPOXZePIQTAyvfXbdxkoIMShOTtJ(int P_0)
		{
			JdKjMwFJeDicquLLrlLeuRBMHmMU = P_0;
			tHmGGIHKWQMoawartmLLZDvVBFtxA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int jdKjMwFJeDicquLLrlLeuRBMHmMU = JdKjMwFJeDicquLLrlLeuRBMHmMU;
			if (jdKjMwFJeDicquLLrlLeuRBMHmMU == -3 || jdKjMwFJeDicquLLrlLeuRBMHmMU == 1)
			{
				try
				{
				}
				finally
				{
					HxwbiVdabKJlCGPHCNanYKAfSnZpb();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int jdKjMwFJeDicquLLrlLeuRBMHmMU = JdKjMwFJeDicquLLrlLeuRBMHmMU;
				UserData pzBTlZLXTMtyomsLzlqetqNICdKEA = PzBTlZLXTMtyomsLzlqetqNICdKEA;
				switch (jdKjMwFJeDicquLLrlLeuRBMHmMU)
				{
				default:
					return false;
				case 0:
					JdKjMwFJeDicquLLrlLeuRBMHmMU = -1;
					if (pzBTlZLXTMtyomsLzlqetqNICdKEA.actionCategories == null || pzBTlZLXTMtyomsLzlqetqNICdKEA.NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
					{
						return false;
					}
					DGQGqaNVQxyygKlcDyfMSFZEDBRd = pzBTlZLXTMtyomsLzlqetqNICdKEA.actionCategoryMap.ActionIdsInCategory(dMgOSZPwaaTAPvRAIYyRdDSODcOD).GetEnumerator();
					JdKjMwFJeDicquLLrlLeuRBMHmMU = -3;
					break;
				case 1:
					JdKjMwFJeDicquLLrlLeuRBMHmMU = -3;
					break;
				}
				while (DGQGqaNVQxyygKlcDyfMSFZEDBRd.MoveNext())
				{
					int current = DGQGqaNVQxyygKlcDyfMSFZEDBRd.Current;
					InputAction actionById = pzBTlZLXTMtyomsLzlqetqNICdKEA.GetActionById(current);
					if (actionById != null)
					{
						BktcSLaQRtTzGsXYqMDNAArEDWhgb = actionById.descriptiveName;
						JdKjMwFJeDicquLLrlLeuRBMHmMU = 1;
						return true;
					}
				}
				HxwbiVdabKJlCGPHCNanYKAfSnZpb();
				DGQGqaNVQxyygKlcDyfMSFZEDBRd = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void HxwbiVdabKJlCGPHCNanYKAfSnZpb()
		{
			JdKjMwFJeDicquLLrlLeuRBMHmMU = -1;
			if (DGQGqaNVQxyygKlcDyfMSFZEDBRd != null)
			{
				DGQGqaNVQxyygKlcDyfMSFZEDBRd.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			gPOXZePIQTAyvfXbdxkoIMShOTtJ gPOXZePIQTAyvfXbdxkoIMShOTtJ2;
			if (JdKjMwFJeDicquLLrlLeuRBMHmMU == -2 && tHmGGIHKWQMoawartmLLZDvVBFtxA == Environment.CurrentManagedThreadId)
			{
				JdKjMwFJeDicquLLrlLeuRBMHmMU = 0;
				gPOXZePIQTAyvfXbdxkoIMShOTtJ2 = this;
			}
			else
			{
				gPOXZePIQTAyvfXbdxkoIMShOTtJ2 = new gPOXZePIQTAyvfXbdxkoIMShOTtJ(0);
				gPOXZePIQTAyvfXbdxkoIMShOTtJ2.PzBTlZLXTMtyomsLzlqetqNICdKEA = PzBTlZLXTMtyomsLzlqetqNICdKEA;
			}
			gPOXZePIQTAyvfXbdxkoIMShOTtJ2.dMgOSZPwaaTAPvRAIYyRdDSODcOD = LSTCZCOANqTxkVNMHJWhdMsPdrXM;
			return gPOXZePIQTAyvfXbdxkoIMShOTtJ2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private sealed class yOWNjYWURkdazRmwGCLHcnrGwYpL : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
	{
		private int phfMkfSHWrUoaJgOtEliduoyrMuRA;

		private int gkqncDNEpbqgsnogGbtqgQhDGnoA;

		private int zKisZTOIuidRqIJZjdNofgxNIjlC;

		public UserData RSbQfpqlAhHfJLHvUnwqBCSIrjhu;

		private int kqjplRHKuePYnTJaFKhIlmLENiqG;

		public int STALTdhKflrqHBYgfKzEWquyyGjl;

		private IEnumerator<int> tyKyqFXLWbXmArbPvfIvveYxYrbr;

		int IEnumerator<int>.Current
		{
			[DebuggerHidden]
			get
			{
				return gkqncDNEpbqgsnogGbtqgQhDGnoA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return gkqncDNEpbqgsnogGbtqgQhDGnoA;
			}
		}

		[DebuggerHidden]
		public yOWNjYWURkdazRmwGCLHcnrGwYpL(int P_0)
		{
			phfMkfSHWrUoaJgOtEliduoyrMuRA = P_0;
			zKisZTOIuidRqIJZjdNofgxNIjlC = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = phfMkfSHWrUoaJgOtEliduoyrMuRA;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					WRivuFHgpqdIOhrJjbCkOHwMDQSeA();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = phfMkfSHWrUoaJgOtEliduoyrMuRA;
				UserData rSbQfpqlAhHfJLHvUnwqBCSIrjhu = RSbQfpqlAhHfJLHvUnwqBCSIrjhu;
				switch (num)
				{
				default:
					return false;
				case 0:
					phfMkfSHWrUoaJgOtEliduoyrMuRA = -1;
					if (rSbQfpqlAhHfJLHvUnwqBCSIrjhu.actionCategories == null || rSbQfpqlAhHfJLHvUnwqBCSIrjhu.NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
					{
						return false;
					}
					tyKyqFXLWbXmArbPvfIvveYxYrbr = rSbQfpqlAhHfJLHvUnwqBCSIrjhu.actionCategoryMap.ActionIdsInCategory(kqjplRHKuePYnTJaFKhIlmLENiqG).GetEnumerator();
					phfMkfSHWrUoaJgOtEliduoyrMuRA = -3;
					break;
				case 1:
					phfMkfSHWrUoaJgOtEliduoyrMuRA = -3;
					break;
				}
				if (tyKyqFXLWbXmArbPvfIvveYxYrbr.MoveNext())
				{
					int current = tyKyqFXLWbXmArbPvfIvveYxYrbr.Current;
					gkqncDNEpbqgsnogGbtqgQhDGnoA = current;
					phfMkfSHWrUoaJgOtEliduoyrMuRA = 1;
					return true;
				}
				WRivuFHgpqdIOhrJjbCkOHwMDQSeA();
				tyKyqFXLWbXmArbPvfIvveYxYrbr = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void WRivuFHgpqdIOhrJjbCkOHwMDQSeA()
		{
			phfMkfSHWrUoaJgOtEliduoyrMuRA = -1;
			if (tyKyqFXLWbXmArbPvfIvveYxYrbr != null)
			{
				tyKyqFXLWbXmArbPvfIvveYxYrbr.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<int> IEnumerable<int>.GetEnumerator()
		{
			yOWNjYWURkdazRmwGCLHcnrGwYpL yOWNjYWURkdazRmwGCLHcnrGwYpL2;
			if (phfMkfSHWrUoaJgOtEliduoyrMuRA == -2 && zKisZTOIuidRqIJZjdNofgxNIjlC == Environment.CurrentManagedThreadId)
			{
				phfMkfSHWrUoaJgOtEliduoyrMuRA = 0;
				yOWNjYWURkdazRmwGCLHcnrGwYpL2 = this;
			}
			else
			{
				yOWNjYWURkdazRmwGCLHcnrGwYpL2 = new yOWNjYWURkdazRmwGCLHcnrGwYpL(0);
				yOWNjYWURkdazRmwGCLHcnrGwYpL2.RSbQfpqlAhHfJLHvUnwqBCSIrjhu = RSbQfpqlAhHfJLHvUnwqBCSIrjhu;
			}
			yOWNjYWURkdazRmwGCLHcnrGwYpL2.kqjplRHKuePYnTJaFKhIlmLENiqG = STALTdhKflrqHBYgfKzEWquyyGjl;
			return yOWNjYWURkdazRmwGCLHcnrGwYpL2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<int>)this).GetEnumerator();
		}
	}

	private sealed class gfHNMEUXtNDFGqJOkLzguPsNtqKG : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
	{
		private int UZBFwLXYHNeatNaHkDvpjWPaibUo;

		private string TfRNXyQTHecqVQfrDrVNZKSldiSM;

		private int tibXvHQndbKArKSuhPRtufzsghIFA;

		public UserData mRarecSklqjHMpMXKhAimnAtQBkR;

		private int rbPymXhfnxODSqckucmrcWhmoQFo;

		public int QpayqpDliEjEAhLcubCLQxFtPFyv;

		private IEnumerator<int> FmNYRTaeaXOwTWWKGuaFuIFValKiA;

		string IEnumerator<string>.Current
		{
			[DebuggerHidden]
			get
			{
				return TfRNXyQTHecqVQfrDrVNZKSldiSM;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return TfRNXyQTHecqVQfrDrVNZKSldiSM;
			}
		}

		[DebuggerHidden]
		public gfHNMEUXtNDFGqJOkLzguPsNtqKG(int P_0)
		{
			UZBFwLXYHNeatNaHkDvpjWPaibUo = P_0;
			tibXvHQndbKArKSuhPRtufzsghIFA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int uZBFwLXYHNeatNaHkDvpjWPaibUo = UZBFwLXYHNeatNaHkDvpjWPaibUo;
			if (uZBFwLXYHNeatNaHkDvpjWPaibUo == -3 || uZBFwLXYHNeatNaHkDvpjWPaibUo == 1)
			{
				try
				{
				}
				finally
				{
					mrybXdBHmxfIzOgFTcHNsDWjDwdfA();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int uZBFwLXYHNeatNaHkDvpjWPaibUo = UZBFwLXYHNeatNaHkDvpjWPaibUo;
				UserData userData = mRarecSklqjHMpMXKhAimnAtQBkR;
				switch (uZBFwLXYHNeatNaHkDvpjWPaibUo)
				{
				default:
					return false;
				case 0:
					UZBFwLXYHNeatNaHkDvpjWPaibUo = -1;
					if (userData.actionCategories == null || userData.NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
					{
						return false;
					}
					FmNYRTaeaXOwTWWKGuaFuIFValKiA = userData.actionCategoryMap.ActionIdsInCategory(rbPymXhfnxODSqckucmrcWhmoQFo).GetEnumerator();
					UZBFwLXYHNeatNaHkDvpjWPaibUo = -3;
					break;
				case 1:
					UZBFwLXYHNeatNaHkDvpjWPaibUo = -3;
					break;
				}
				while (FmNYRTaeaXOwTWWKGuaFuIFValKiA.MoveNext())
				{
					int current = FmNYRTaeaXOwTWWKGuaFuIFValKiA.Current;
					InputAction actionById = userData.GetActionById(current);
					if (actionById != null)
					{
						TfRNXyQTHecqVQfrDrVNZKSldiSM = actionById.name;
						UZBFwLXYHNeatNaHkDvpjWPaibUo = 1;
						return true;
					}
				}
				mrybXdBHmxfIzOgFTcHNsDWjDwdfA();
				FmNYRTaeaXOwTWWKGuaFuIFValKiA = null;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void mrybXdBHmxfIzOgFTcHNsDWjDwdfA()
		{
			UZBFwLXYHNeatNaHkDvpjWPaibUo = -1;
			if (FmNYRTaeaXOwTWWKGuaFuIFValKiA != null)
			{
				FmNYRTaeaXOwTWWKGuaFuIFValKiA.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<string> IEnumerable<string>.GetEnumerator()
		{
			gfHNMEUXtNDFGqJOkLzguPsNtqKG gfHNMEUXtNDFGqJOkLzguPsNtqKG2;
			if (UZBFwLXYHNeatNaHkDvpjWPaibUo == -2 && tibXvHQndbKArKSuhPRtufzsghIFA == Environment.CurrentManagedThreadId)
			{
				UZBFwLXYHNeatNaHkDvpjWPaibUo = 0;
				gfHNMEUXtNDFGqJOkLzguPsNtqKG2 = this;
			}
			else
			{
				gfHNMEUXtNDFGqJOkLzguPsNtqKG2 = new gfHNMEUXtNDFGqJOkLzguPsNtqKG(0);
				gfHNMEUXtNDFGqJOkLzguPsNtqKG2.mRarecSklqjHMpMXKhAimnAtQBkR = mRarecSklqjHMpMXKhAimnAtQBkR;
			}
			gfHNMEUXtNDFGqJOkLzguPsNtqKG2.rbPymXhfnxODSqckucmrcWhmoQFo = QpayqpDliEjEAhLcubCLQxFtPFyv;
			return gfHNMEUXtNDFGqJOkLzguPsNtqKG2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<string>)this).GetEnumerator();
		}
	}

	private sealed class QXwriSWRVeFzNJGjlLRRADhzSuFC : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
	{
		private int jOqgFbpwNpBQIRMUYaeeOUjMZfCV;

		private InputCategory MqedbAqsHLehXCgNZUrzDLWDJfHJ;

		private int yNxBROkUvcGyHETlaCCEfRKflLKpc;

		private string FIcyoReqkboGRRBZdtultwsUIQQX;

		public string bKKYbCgSDCsHzLCPoFMsATtsiBbJb;

		public UserData lIFJLhqzzwyrRjaKlHzDAmSBICHC;

		private int hdRUuhBQmlYUGxfPPEiJrtgeLOfy;

		InputCategory IEnumerator<InputCategory>.Current
		{
			[DebuggerHidden]
			get
			{
				return MqedbAqsHLehXCgNZUrzDLWDJfHJ;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return MqedbAqsHLehXCgNZUrzDLWDJfHJ;
			}
		}

		[DebuggerHidden]
		public QXwriSWRVeFzNJGjlLRRADhzSuFC(int P_0)
		{
			jOqgFbpwNpBQIRMUYaeeOUjMZfCV = P_0;
			yNxBROkUvcGyHETlaCCEfRKflLKpc = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = jOqgFbpwNpBQIRMUYaeeOUjMZfCV;
			UserData userData = lIFJLhqzzwyrRjaKlHzDAmSBICHC;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				jOqgFbpwNpBQIRMUYaeeOUjMZfCV = -1;
				goto IL_00b3;
			}
			jOqgFbpwNpBQIRMUYaeeOUjMZfCV = -1;
			if (FIcyoReqkboGRRBZdtultwsUIQQX == null || FIcyoReqkboGRRBZdtultwsUIQQX == string.Empty)
			{
				return false;
			}
			if (userData.actionCategories == null)
			{
				return false;
			}
			hdRUuhBQmlYUGxfPPEiJrtgeLOfy = 0;
			goto IL_00c3;
			IL_00c3:
			if (hdRUuhBQmlYUGxfPPEiJrtgeLOfy < userData.actionCategories.Count)
			{
				if (userData.actionCategories[hdRUuhBQmlYUGxfPPEiJrtgeLOfy].userAssignable && userData.actionCategories[hdRUuhBQmlYUGxfPPEiJrtgeLOfy].tag.Equals(FIcyoReqkboGRRBZdtultwsUIQQX, StringComparison.OrdinalIgnoreCase))
				{
					MqedbAqsHLehXCgNZUrzDLWDJfHJ = userData.actionCategories[hdRUuhBQmlYUGxfPPEiJrtgeLOfy];
					jOqgFbpwNpBQIRMUYaeeOUjMZfCV = 1;
					return true;
				}
				goto IL_00b3;
			}
			return false;
			IL_00b3:
			hdRUuhBQmlYUGxfPPEiJrtgeLOfy++;
			goto IL_00c3;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
		{
			QXwriSWRVeFzNJGjlLRRADhzSuFC qXwriSWRVeFzNJGjlLRRADhzSuFC;
			if (jOqgFbpwNpBQIRMUYaeeOUjMZfCV == -2 && yNxBROkUvcGyHETlaCCEfRKflLKpc == Environment.CurrentManagedThreadId)
			{
				jOqgFbpwNpBQIRMUYaeeOUjMZfCV = 0;
				qXwriSWRVeFzNJGjlLRRADhzSuFC = this;
			}
			else
			{
				qXwriSWRVeFzNJGjlLRRADhzSuFC = new QXwriSWRVeFzNJGjlLRRADhzSuFC(0);
				qXwriSWRVeFzNJGjlLRRADhzSuFC.lIFJLhqzzwyrRjaKlHzDAmSBICHC = lIFJLhqzzwyrRjaKlHzDAmSBICHC;
			}
			qXwriSWRVeFzNJGjlLRRADhzSuFC.FIcyoReqkboGRRBZdtultwsUIQQX = bKKYbCgSDCsHzLCPoFMsATtsiBbJb;
			return qXwriSWRVeFzNJGjlLRRADhzSuFC;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputCategory>)this).GetEnumerator();
		}
	}

	private sealed class fBNjgiinOQrLIeMyKcIErTLbnLMkA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
	{
		private int YcWAjLhipkUHUctVMvjxAsxUZjen;

		private InputAction jPZUlwFzxIhAUHeYbrIOvuOQTqoU;

		private int kTtkgydhWZtwkyJJkxosxFOfoISx;

		public UserData OjotMcsVyZQSLFdSrxWAwxasQCtl;

		private int ztjHUKKpubiBOJPGyzzehiDgLiJM;

		public int pwcUxxNaZyfqgARUUDvfzUbVTmAJ;

		private bool lUiFxCFMKNnzRNfOjJWVIKPEHYWhA;

		public bool ZCBDKWACahlRtStwuJEsAnuexSJB;

		private InputCategory VfTbqAbHOvJHmyBBRvvJILKNhQgwA;

		private IEnumerator<int> lnFHDtYhcfBFzFBXQFVNibZCCsEDb;

		private int LOiVtWdrRmDWtUjSrQMCduNcbVre;

		InputAction IEnumerator<InputAction>.Current
		{
			[DebuggerHidden]
			get
			{
				return jPZUlwFzxIhAUHeYbrIOvuOQTqoU;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return jPZUlwFzxIhAUHeYbrIOvuOQTqoU;
			}
		}

		[DebuggerHidden]
		public fBNjgiinOQrLIeMyKcIErTLbnLMkA(int P_0)
		{
			YcWAjLhipkUHUctVMvjxAsxUZjen = P_0;
			kTtkgydhWZtwkyJJkxosxFOfoISx = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int ycWAjLhipkUHUctVMvjxAsxUZjen = YcWAjLhipkUHUctVMvjxAsxUZjen;
			if (ycWAjLhipkUHUctVMvjxAsxUZjen == -3 || ycWAjLhipkUHUctVMvjxAsxUZjen == 1)
			{
				try
				{
				}
				finally
				{
					zIQlDVbZeNgHLBtmCOfKwitSTrY();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int ycWAjLhipkUHUctVMvjxAsxUZjen = YcWAjLhipkUHUctVMvjxAsxUZjen;
				UserData ojotMcsVyZQSLFdSrxWAwxasQCtl = OjotMcsVyZQSLFdSrxWAwxasQCtl;
				InputAction inputAction;
				switch (ycWAjLhipkUHUctVMvjxAsxUZjen)
				{
				default:
					return false;
				case 0:
					YcWAjLhipkUHUctVMvjxAsxUZjen = -1;
					if (ojotMcsVyZQSLFdSrxWAwxasQCtl.NjqoctZbUFKVxEaddNFBUjRNLoQV() == null || ojotMcsVyZQSLFdSrxWAwxasQCtl.actionCategories == null)
					{
						return false;
					}
					VfTbqAbHOvJHmyBBRvvJILKNhQgwA = ojotMcsVyZQSLFdSrxWAwxasQCtl.GetActionCategoryById(ztjHUKKpubiBOJPGyzzehiDgLiJM);
					if (VfTbqAbHOvJHmyBBRvvJILKNhQgwA == null || !VfTbqAbHOvJHmyBBRvvJILKNhQgwA.userAssignable)
					{
						return false;
					}
					if (lUiFxCFMKNnzRNfOjJWVIKPEHYWhA)
					{
						lnFHDtYhcfBFzFBXQFVNibZCCsEDb = ojotMcsVyZQSLFdSrxWAwxasQCtl.SortedActionIdsInCategory(VfTbqAbHOvJHmyBBRvvJILKNhQgwA.id).GetEnumerator();
						YcWAjLhipkUHUctVMvjxAsxUZjen = -3;
						goto IL_00e4;
					}
					LOiVtWdrRmDWtUjSrQMCduNcbVre = 0;
					goto IL_0165;
				case 1:
					YcWAjLhipkUHUctVMvjxAsxUZjen = -3;
					goto IL_00e4;
				case 2:
					{
						YcWAjLhipkUHUctVMvjxAsxUZjen = -1;
						goto IL_0153;
					}
					IL_00e4:
					while (lnFHDtYhcfBFzFBXQFVNibZCCsEDb.MoveNext())
					{
						int current = lnFHDtYhcfBFzFBXQFVNibZCCsEDb.Current;
						InputAction actionById = ojotMcsVyZQSLFdSrxWAwxasQCtl.GetActionById(current);
						if (actionById != null && actionById.userAssignable)
						{
							jPZUlwFzxIhAUHeYbrIOvuOQTqoU = actionById;
							YcWAjLhipkUHUctVMvjxAsxUZjen = 1;
							return true;
						}
					}
					zIQlDVbZeNgHLBtmCOfKwitSTrY();
					lnFHDtYhcfBFzFBXQFVNibZCCsEDb = null;
					break;
					IL_0153:
					LOiVtWdrRmDWtUjSrQMCduNcbVre++;
					goto IL_0165;
					IL_0165:
					if (LOiVtWdrRmDWtUjSrQMCduNcbVre >= ojotMcsVyZQSLFdSrxWAwxasQCtl.NjqoctZbUFKVxEaddNFBUjRNLoQV().Count)
					{
						break;
					}
					inputAction = ojotMcsVyZQSLFdSrxWAwxasQCtl.NjqoctZbUFKVxEaddNFBUjRNLoQV()[LOiVtWdrRmDWtUjSrQMCduNcbVre];
					if (inputAction.categoryId == VfTbqAbHOvJHmyBBRvvJILKNhQgwA.id && inputAction.userAssignable)
					{
						jPZUlwFzxIhAUHeYbrIOvuOQTqoU = inputAction;
						YcWAjLhipkUHUctVMvjxAsxUZjen = 2;
						return true;
					}
					goto IL_0153;
				}
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void zIQlDVbZeNgHLBtmCOfKwitSTrY()
		{
			YcWAjLhipkUHUctVMvjxAsxUZjen = -1;
			if (lnFHDtYhcfBFzFBXQFVNibZCCsEDb != null)
			{
				lnFHDtYhcfBFzFBXQFVNibZCCsEDb.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
		{
			fBNjgiinOQrLIeMyKcIErTLbnLMkA fBNjgiinOQrLIeMyKcIErTLbnLMkA2;
			if (YcWAjLhipkUHUctVMvjxAsxUZjen == -2 && kTtkgydhWZtwkyJJkxosxFOfoISx == Environment.CurrentManagedThreadId)
			{
				YcWAjLhipkUHUctVMvjxAsxUZjen = 0;
				fBNjgiinOQrLIeMyKcIErTLbnLMkA2 = this;
			}
			else
			{
				fBNjgiinOQrLIeMyKcIErTLbnLMkA2 = new fBNjgiinOQrLIeMyKcIErTLbnLMkA(0);
				fBNjgiinOQrLIeMyKcIErTLbnLMkA2.OjotMcsVyZQSLFdSrxWAwxasQCtl = OjotMcsVyZQSLFdSrxWAwxasQCtl;
			}
			fBNjgiinOQrLIeMyKcIErTLbnLMkA2.ztjHUKKpubiBOJPGyzzehiDgLiJM = pwcUxxNaZyfqgARUUDvfzUbVTmAJ;
			fBNjgiinOQrLIeMyKcIErTLbnLMkA2.lUiFxCFMKNnzRNfOjJWVIKPEHYWhA = ZCBDKWACahlRtStwuJEsAnuexSJB;
			return fBNjgiinOQrLIeMyKcIErTLbnLMkA2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputAction>)this).GetEnumerator();
		}
	}

	private sealed class oXXnWNgCLAOGQDqFTBeWlpnQGEpiA : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
	{
		private int RdniXIuJvpVoQDSSrOqxQugpCJYd;

		private InputAction FrqoWZYXDwsBrurLqGcEICsueoGn;

		private int wYqtnWUiHsOcevxWvDzgAKUgVYkc;

		public UserData LDMoAlAFzPebahvpDmMFJCqkARncb;

		private string puvxHuirIhJQXJxCpjelrdvAbpmiA;

		public string cRceAzBcMRvqlLxqPucreaqasMDDA;

		private bool NKzYoVyJQyDBYHGoChNCoFyewxGfA;

		public bool QcXCNeaIivSpOgTzuhnRibbtpQjj;

		private InputCategory pteNlCseRFoWKHYqUtjEctWkKQLf;

		private IEnumerator<int> mdbsPiNFAjjwxxpuLBMNJBIksNnv;

		private int GdeHwTcqvieOGlWsbfMQKhcOlPey;

		InputAction IEnumerator<InputAction>.Current
		{
			[DebuggerHidden]
			get
			{
				return FrqoWZYXDwsBrurLqGcEICsueoGn;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return FrqoWZYXDwsBrurLqGcEICsueoGn;
			}
		}

		[DebuggerHidden]
		public oXXnWNgCLAOGQDqFTBeWlpnQGEpiA(int P_0)
		{
			RdniXIuJvpVoQDSSrOqxQugpCJYd = P_0;
			wYqtnWUiHsOcevxWvDzgAKUgVYkc = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int rdniXIuJvpVoQDSSrOqxQugpCJYd = RdniXIuJvpVoQDSSrOqxQugpCJYd;
			if (rdniXIuJvpVoQDSSrOqxQugpCJYd == -3 || rdniXIuJvpVoQDSSrOqxQugpCJYd == 1)
			{
				try
				{
				}
				finally
				{
					ObcEGlftSfjEosqjsUjsoNyHySUSA();
				}
			}
		}

		private bool MoveNext()
		{
			try
			{
				int rdniXIuJvpVoQDSSrOqxQugpCJYd = RdniXIuJvpVoQDSSrOqxQugpCJYd;
				UserData lDMoAlAFzPebahvpDmMFJCqkARncb = LDMoAlAFzPebahvpDmMFJCqkARncb;
				InputAction inputAction;
				switch (rdniXIuJvpVoQDSSrOqxQugpCJYd)
				{
				default:
					return false;
				case 0:
					RdniXIuJvpVoQDSSrOqxQugpCJYd = -1;
					if (lDMoAlAFzPebahvpDmMFJCqkARncb.NjqoctZbUFKVxEaddNFBUjRNLoQV() == null || lDMoAlAFzPebahvpDmMFJCqkARncb.actionCategories == null)
					{
						return false;
					}
					pteNlCseRFoWKHYqUtjEctWkKQLf = lDMoAlAFzPebahvpDmMFJCqkARncb.GetActionCategory(puvxHuirIhJQXJxCpjelrdvAbpmiA);
					if (pteNlCseRFoWKHYqUtjEctWkKQLf == null || !pteNlCseRFoWKHYqUtjEctWkKQLf.userAssignable)
					{
						return false;
					}
					if (NKzYoVyJQyDBYHGoChNCoFyewxGfA)
					{
						mdbsPiNFAjjwxxpuLBMNJBIksNnv = lDMoAlAFzPebahvpDmMFJCqkARncb.SortedActionIdsInCategory(pteNlCseRFoWKHYqUtjEctWkKQLf.id).GetEnumerator();
						RdniXIuJvpVoQDSSrOqxQugpCJYd = -3;
						goto IL_00e4;
					}
					GdeHwTcqvieOGlWsbfMQKhcOlPey = 0;
					goto IL_0165;
				case 1:
					RdniXIuJvpVoQDSSrOqxQugpCJYd = -3;
					goto IL_00e4;
				case 2:
					{
						RdniXIuJvpVoQDSSrOqxQugpCJYd = -1;
						goto IL_0153;
					}
					IL_00e4:
					while (mdbsPiNFAjjwxxpuLBMNJBIksNnv.MoveNext())
					{
						int current = mdbsPiNFAjjwxxpuLBMNJBIksNnv.Current;
						InputAction actionById = lDMoAlAFzPebahvpDmMFJCqkARncb.GetActionById(current);
						if (actionById != null && actionById.userAssignable)
						{
							FrqoWZYXDwsBrurLqGcEICsueoGn = actionById;
							RdniXIuJvpVoQDSSrOqxQugpCJYd = 1;
							return true;
						}
					}
					ObcEGlftSfjEosqjsUjsoNyHySUSA();
					mdbsPiNFAjjwxxpuLBMNJBIksNnv = null;
					break;
					IL_0153:
					GdeHwTcqvieOGlWsbfMQKhcOlPey++;
					goto IL_0165;
					IL_0165:
					if (GdeHwTcqvieOGlWsbfMQKhcOlPey >= lDMoAlAFzPebahvpDmMFJCqkARncb.NjqoctZbUFKVxEaddNFBUjRNLoQV().Count)
					{
						break;
					}
					inputAction = lDMoAlAFzPebahvpDmMFJCqkARncb.NjqoctZbUFKVxEaddNFBUjRNLoQV()[GdeHwTcqvieOGlWsbfMQKhcOlPey];
					if (inputAction.categoryId == pteNlCseRFoWKHYqUtjEctWkKQLf.id && inputAction.userAssignable)
					{
						FrqoWZYXDwsBrurLqGcEICsueoGn = inputAction;
						RdniXIuJvpVoQDSSrOqxQugpCJYd = 2;
						return true;
					}
					goto IL_0153;
				}
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void ObcEGlftSfjEosqjsUjsoNyHySUSA()
		{
			RdniXIuJvpVoQDSSrOqxQugpCJYd = -1;
			if (mdbsPiNFAjjwxxpuLBMNJBIksNnv != null)
			{
				mdbsPiNFAjjwxxpuLBMNJBIksNnv.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
		{
			oXXnWNgCLAOGQDqFTBeWlpnQGEpiA oXXnWNgCLAOGQDqFTBeWlpnQGEpiA2;
			if (RdniXIuJvpVoQDSSrOqxQugpCJYd == -2 && wYqtnWUiHsOcevxWvDzgAKUgVYkc == Environment.CurrentManagedThreadId)
			{
				RdniXIuJvpVoQDSSrOqxQugpCJYd = 0;
				oXXnWNgCLAOGQDqFTBeWlpnQGEpiA2 = this;
			}
			else
			{
				oXXnWNgCLAOGQDqFTBeWlpnQGEpiA2 = new oXXnWNgCLAOGQDqFTBeWlpnQGEpiA(0);
				oXXnWNgCLAOGQDqFTBeWlpnQGEpiA2.LDMoAlAFzPebahvpDmMFJCqkARncb = LDMoAlAFzPebahvpDmMFJCqkARncb;
			}
			oXXnWNgCLAOGQDqFTBeWlpnQGEpiA2.puvxHuirIhJQXJxCpjelrdvAbpmiA = cRceAzBcMRvqlLxqPucreaqasMDDA;
			oXXnWNgCLAOGQDqFTBeWlpnQGEpiA2.NKzYoVyJQyDBYHGoChNCoFyewxGfA = QcXCNeaIivSpOgTzuhnRibbtpQjj;
			return oXXnWNgCLAOGQDqFTBeWlpnQGEpiA2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputAction>)this).GetEnumerator();
		}
	}

	private sealed class AKiCZFjQqHdkSgaeMKviclujtpHUA : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
	{
		private int NkpfFFgbwgHAgQCaLggdCkADUopx;

		private InputMapCategory ZZwTKAfsBrVWsMtlosRJYGibwXiM;

		private int iDKbdcGykFlNcVnPICEUOgbUbcBu;

		private string OQJcMqNQlEclkWhbTrThREbEyFYi;

		public string IsiGyBSsdoQGsZHKCHvLCKodlkSW;

		public UserData KOnTNOdKtqjNWWaFDLHXNAiLEzcFA;

		private int EMvQbWkkdeJyFeknJQdktEnneXhp;

		InputMapCategory IEnumerator<InputMapCategory>.Current
		{
			[DebuggerHidden]
			get
			{
				return ZZwTKAfsBrVWsMtlosRJYGibwXiM;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return ZZwTKAfsBrVWsMtlosRJYGibwXiM;
			}
		}

		[DebuggerHidden]
		public AKiCZFjQqHdkSgaeMKviclujtpHUA(int P_0)
		{
			NkpfFFgbwgHAgQCaLggdCkADUopx = P_0;
			iDKbdcGykFlNcVnPICEUOgbUbcBu = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int nkpfFFgbwgHAgQCaLggdCkADUopx = NkpfFFgbwgHAgQCaLggdCkADUopx;
			UserData kOnTNOdKtqjNWWaFDLHXNAiLEzcFA = KOnTNOdKtqjNWWaFDLHXNAiLEzcFA;
			if (nkpfFFgbwgHAgQCaLggdCkADUopx != 0)
			{
				if (nkpfFFgbwgHAgQCaLggdCkADUopx != 1)
				{
					return false;
				}
				NkpfFFgbwgHAgQCaLggdCkADUopx = -1;
				goto IL_00b3;
			}
			NkpfFFgbwgHAgQCaLggdCkADUopx = -1;
			if (OQJcMqNQlEclkWhbTrThREbEyFYi == null || OQJcMqNQlEclkWhbTrThREbEyFYi == string.Empty)
			{
				return false;
			}
			if (kOnTNOdKtqjNWWaFDLHXNAiLEzcFA.mapCategories == null)
			{
				return false;
			}
			EMvQbWkkdeJyFeknJQdktEnneXhp = 0;
			goto IL_00c3;
			IL_00c3:
			if (EMvQbWkkdeJyFeknJQdktEnneXhp < kOnTNOdKtqjNWWaFDLHXNAiLEzcFA.mapCategories.Count)
			{
				if (kOnTNOdKtqjNWWaFDLHXNAiLEzcFA.mapCategories[EMvQbWkkdeJyFeknJQdktEnneXhp].userAssignable && kOnTNOdKtqjNWWaFDLHXNAiLEzcFA.mapCategories[EMvQbWkkdeJyFeknJQdktEnneXhp].tag.Equals(OQJcMqNQlEclkWhbTrThREbEyFYi, StringComparison.OrdinalIgnoreCase))
				{
					ZZwTKAfsBrVWsMtlosRJYGibwXiM = kOnTNOdKtqjNWWaFDLHXNAiLEzcFA.mapCategories[EMvQbWkkdeJyFeknJQdktEnneXhp];
					NkpfFFgbwgHAgQCaLggdCkADUopx = 1;
					return true;
				}
				goto IL_00b3;
			}
			return false;
			IL_00b3:
			EMvQbWkkdeJyFeknJQdktEnneXhp++;
			goto IL_00c3;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
		{
			AKiCZFjQqHdkSgaeMKviclujtpHUA aKiCZFjQqHdkSgaeMKviclujtpHUA;
			if (NkpfFFgbwgHAgQCaLggdCkADUopx == -2 && iDKbdcGykFlNcVnPICEUOgbUbcBu == Environment.CurrentManagedThreadId)
			{
				NkpfFFgbwgHAgQCaLggdCkADUopx = 0;
				aKiCZFjQqHdkSgaeMKviclujtpHUA = this;
			}
			else
			{
				aKiCZFjQqHdkSgaeMKviclujtpHUA = new AKiCZFjQqHdkSgaeMKviclujtpHUA(0);
				aKiCZFjQqHdkSgaeMKviclujtpHUA.KOnTNOdKtqjNWWaFDLHXNAiLEzcFA = KOnTNOdKtqjNWWaFDLHXNAiLEzcFA;
			}
			aKiCZFjQqHdkSgaeMKviclujtpHUA.OQJcMqNQlEclkWhbTrThREbEyFYi = IsiGyBSsdoQGsZHKCHvLCKodlkSW;
			return aKiCZFjQqHdkSgaeMKviclujtpHUA;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
		}
	}

	private sealed class tpVlLnmoYborlBCRwxAMRktWotSR : IEnumerable<InputCategory>, IEnumerable, IEnumerator<InputCategory>, IEnumerator, IDisposable
	{
		private int YkxvoeEBbLIviqcXbACisGmLwyJg;

		private InputCategory IsPfREUIhnEImfcQwnBgDswJFTsAB;

		private int EOsrjZMiTNShqLWkfmRzFAPWKkSl;

		public UserData fllKKzwgzykrnfEcYihZimyGiEtr;

		private int oMbPjUnXeTYXmmAFHkqhcBhiYEor;

		InputCategory IEnumerator<InputCategory>.Current
		{
			[DebuggerHidden]
			get
			{
				return IsPfREUIhnEImfcQwnBgDswJFTsAB;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return IsPfREUIhnEImfcQwnBgDswJFTsAB;
			}
		}

		[DebuggerHidden]
		public tpVlLnmoYborlBCRwxAMRktWotSR(int P_0)
		{
			YkxvoeEBbLIviqcXbACisGmLwyJg = P_0;
			EOsrjZMiTNShqLWkfmRzFAPWKkSl = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int ykxvoeEBbLIviqcXbACisGmLwyJg = YkxvoeEBbLIviqcXbACisGmLwyJg;
			UserData userData = fllKKzwgzykrnfEcYihZimyGiEtr;
			if (ykxvoeEBbLIviqcXbACisGmLwyJg != 0)
			{
				if (ykxvoeEBbLIviqcXbACisGmLwyJg != 1)
				{
					return false;
				}
				YkxvoeEBbLIviqcXbACisGmLwyJg = -1;
				goto IL_0070;
			}
			YkxvoeEBbLIviqcXbACisGmLwyJg = -1;
			if (userData.actionCategories == null)
			{
				return false;
			}
			oMbPjUnXeTYXmmAFHkqhcBhiYEor = 0;
			goto IL_0080;
			IL_0080:
			if (oMbPjUnXeTYXmmAFHkqhcBhiYEor < userData.actionCategories.Count)
			{
				if (userData.actionCategories[oMbPjUnXeTYXmmAFHkqhcBhiYEor].userAssignable)
				{
					IsPfREUIhnEImfcQwnBgDswJFTsAB = userData.actionCategories[oMbPjUnXeTYXmmAFHkqhcBhiYEor];
					YkxvoeEBbLIviqcXbACisGmLwyJg = 1;
					return true;
				}
				goto IL_0070;
			}
			return false;
			IL_0070:
			oMbPjUnXeTYXmmAFHkqhcBhiYEor++;
			goto IL_0080;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputCategory> IEnumerable<InputCategory>.GetEnumerator()
		{
			tpVlLnmoYborlBCRwxAMRktWotSR tpVlLnmoYborlBCRwxAMRktWotSR2;
			if (YkxvoeEBbLIviqcXbACisGmLwyJg == -2 && EOsrjZMiTNShqLWkfmRzFAPWKkSl == Environment.CurrentManagedThreadId)
			{
				YkxvoeEBbLIviqcXbACisGmLwyJg = 0;
				tpVlLnmoYborlBCRwxAMRktWotSR2 = this;
			}
			else
			{
				tpVlLnmoYborlBCRwxAMRktWotSR2 = new tpVlLnmoYborlBCRwxAMRktWotSR(0);
				tpVlLnmoYborlBCRwxAMRktWotSR2.fllKKzwgzykrnfEcYihZimyGiEtr = fllKKzwgzykrnfEcYihZimyGiEtr;
			}
			return tpVlLnmoYborlBCRwxAMRktWotSR2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputCategory>)this).GetEnumerator();
		}
	}

	private sealed class WOBpweSlbyuhPqrwmlcCCfYAHjsX : IEnumerable<InputAction>, IEnumerable, IEnumerator<InputAction>, IEnumerator, IDisposable
	{
		private int EcjkYoPQniYVWaMpsRaAzvlOJnAk;

		private InputAction bbLsWZAfcpwGWclbAIsnWJMSjplkA;

		private int DGBaSasmHIYdDEbZHVNwDWMHIIZf;

		public UserData DmDeqfbwOagYbOeFWqOvvLqMNHAg;

		private int RcZajFCiDnlYJkcvpmDrQqZPgoRGA;

		InputAction IEnumerator<InputAction>.Current
		{
			[DebuggerHidden]
			get
			{
				return bbLsWZAfcpwGWclbAIsnWJMSjplkA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return bbLsWZAfcpwGWclbAIsnWJMSjplkA;
			}
		}

		[DebuggerHidden]
		public WOBpweSlbyuhPqrwmlcCCfYAHjsX(int P_0)
		{
			EcjkYoPQniYVWaMpsRaAzvlOJnAk = P_0;
			DGBaSasmHIYdDEbZHVNwDWMHIIZf = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int ecjkYoPQniYVWaMpsRaAzvlOJnAk = EcjkYoPQniYVWaMpsRaAzvlOJnAk;
			UserData dmDeqfbwOagYbOeFWqOvvLqMNHAg = DmDeqfbwOagYbOeFWqOvvLqMNHAg;
			if (ecjkYoPQniYVWaMpsRaAzvlOJnAk != 0)
			{
				if (ecjkYoPQniYVWaMpsRaAzvlOJnAk != 1)
				{
					return false;
				}
				EcjkYoPQniYVWaMpsRaAzvlOJnAk = -1;
				goto IL_007a;
			}
			EcjkYoPQniYVWaMpsRaAzvlOJnAk = -1;
			if (dmDeqfbwOagYbOeFWqOvvLqMNHAg.NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
			{
				return false;
			}
			RcZajFCiDnlYJkcvpmDrQqZPgoRGA = 0;
			goto IL_008c;
			IL_008c:
			if (RcZajFCiDnlYJkcvpmDrQqZPgoRGA < dmDeqfbwOagYbOeFWqOvvLqMNHAg.NjqoctZbUFKVxEaddNFBUjRNLoQV().Count)
			{
				InputAction inputAction = dmDeqfbwOagYbOeFWqOvvLqMNHAg.NjqoctZbUFKVxEaddNFBUjRNLoQV()[RcZajFCiDnlYJkcvpmDrQqZPgoRGA];
				InputCategory actionCategoryById = dmDeqfbwOagYbOeFWqOvvLqMNHAg.GetActionCategoryById(inputAction.categoryId);
				if (actionCategoryById != null && actionCategoryById.userAssignable && inputAction.userAssignable)
				{
					bbLsWZAfcpwGWclbAIsnWJMSjplkA = inputAction;
					EcjkYoPQniYVWaMpsRaAzvlOJnAk = 1;
					return true;
				}
				goto IL_007a;
			}
			return false;
			IL_007a:
			RcZajFCiDnlYJkcvpmDrQqZPgoRGA++;
			goto IL_008c;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputAction> IEnumerable<InputAction>.GetEnumerator()
		{
			WOBpweSlbyuhPqrwmlcCCfYAHjsX wOBpweSlbyuhPqrwmlcCCfYAHjsX;
			if (EcjkYoPQniYVWaMpsRaAzvlOJnAk == -2 && DGBaSasmHIYdDEbZHVNwDWMHIIZf == Environment.CurrentManagedThreadId)
			{
				EcjkYoPQniYVWaMpsRaAzvlOJnAk = 0;
				wOBpweSlbyuhPqrwmlcCCfYAHjsX = this;
			}
			else
			{
				wOBpweSlbyuhPqrwmlcCCfYAHjsX = new WOBpweSlbyuhPqrwmlcCCfYAHjsX(0);
				wOBpweSlbyuhPqrwmlcCCfYAHjsX.DmDeqfbwOagYbOeFWqOvvLqMNHAg = DmDeqfbwOagYbOeFWqOvvLqMNHAg;
			}
			return wOBpweSlbyuhPqrwmlcCCfYAHjsX;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputAction>)this).GetEnumerator();
		}
	}

	private sealed class EzUfjGiMbUSCKHScWnnyyLMvcCjJA : IEnumerable<InputMapCategory>, IEnumerable, IEnumerator<InputMapCategory>, IEnumerator, IDisposable
	{
		private int zeduGpFjAQRfQuKukApKWTBXdkEkA;

		private InputMapCategory SfxxiIzsFyZCmGeAUbJclptImoMv;

		private int KaJdERKINmjlHwvpJceanTugURiMA;

		public UserData HajMZcAvYSotosqWTtvxwihZRmwv;

		private int uFZwjBbpNbeiMschqHXMuvAFiiMT;

		InputMapCategory IEnumerator<InputMapCategory>.Current
		{
			[DebuggerHidden]
			get
			{
				return SfxxiIzsFyZCmGeAUbJclptImoMv;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return SfxxiIzsFyZCmGeAUbJclptImoMv;
			}
		}

		[DebuggerHidden]
		public EzUfjGiMbUSCKHScWnnyyLMvcCjJA(int P_0)
		{
			zeduGpFjAQRfQuKukApKWTBXdkEkA = P_0;
			KaJdERKINmjlHwvpJceanTugURiMA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = zeduGpFjAQRfQuKukApKWTBXdkEkA;
			UserData hajMZcAvYSotosqWTtvxwihZRmwv = HajMZcAvYSotosqWTtvxwihZRmwv;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				zeduGpFjAQRfQuKukApKWTBXdkEkA = -1;
				goto IL_0070;
			}
			zeduGpFjAQRfQuKukApKWTBXdkEkA = -1;
			if (hajMZcAvYSotosqWTtvxwihZRmwv.mapCategories == null)
			{
				return false;
			}
			uFZwjBbpNbeiMschqHXMuvAFiiMT = 0;
			goto IL_0080;
			IL_0080:
			if (uFZwjBbpNbeiMschqHXMuvAFiiMT < hajMZcAvYSotosqWTtvxwihZRmwv.mapCategories.Count)
			{
				if (hajMZcAvYSotosqWTtvxwihZRmwv.mapCategories[uFZwjBbpNbeiMschqHXMuvAFiiMT].userAssignable)
				{
					SfxxiIzsFyZCmGeAUbJclptImoMv = hajMZcAvYSotosqWTtvxwihZRmwv.mapCategories[uFZwjBbpNbeiMschqHXMuvAFiiMT];
					zeduGpFjAQRfQuKukApKWTBXdkEkA = 1;
					return true;
				}
				goto IL_0070;
			}
			return false;
			IL_0070:
			uFZwjBbpNbeiMschqHXMuvAFiiMT++;
			goto IL_0080;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<InputMapCategory> IEnumerable<InputMapCategory>.GetEnumerator()
		{
			EzUfjGiMbUSCKHScWnnyyLMvcCjJA ezUfjGiMbUSCKHScWnnyyLMvcCjJA;
			if (zeduGpFjAQRfQuKukApKWTBXdkEkA == -2 && KaJdERKINmjlHwvpJceanTugURiMA == Environment.CurrentManagedThreadId)
			{
				zeduGpFjAQRfQuKukApKWTBXdkEkA = 0;
				ezUfjGiMbUSCKHScWnnyyLMvcCjJA = this;
			}
			else
			{
				ezUfjGiMbUSCKHScWnnyyLMvcCjJA = new EzUfjGiMbUSCKHScWnnyyLMvcCjJA(0);
				ezUfjGiMbUSCKHScWnnyyLMvcCjJA.HajMZcAvYSotosqWTtvxwihZRmwv = HajMZcAvYSotosqWTtvxwihZRmwv;
			}
			return ezUfjGiMbUSCKHScWnnyyLMvcCjJA;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<InputMapCategory>)this).GetEnumerator();
		}
	}

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private ConfigVars configVars = new ConfigVars();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<Player_Editor> players = new List<Player_Editor>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<InputAction> actions = new List<InputAction>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<InputActionCategory> actionCategories = new List<InputActionCategory>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private ActionCategoryMap actionCategoryMap = new ActionCategoryMap();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<InputBehavior> inputBehaviors = new List<InputBehavior>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<InputMapCategory> mapCategories = new List<InputMapCategory>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<InputLayout> joystickLayouts = new List<InputLayout>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<InputLayout> keyboardLayouts = new List<InputLayout>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<InputLayout> mouseLayouts = new List<InputLayout>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<InputLayout> customControllerLayouts = new List<InputLayout>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<ControllerMap_Editor> joystickMaps = new List<ControllerMap_Editor>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<ControllerMap_Editor> keyboardMaps = new List<ControllerMap_Editor>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<ControllerMap_Editor> mouseMaps = new List<ControllerMap_Editor>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<ControllerMap_Editor> customControllerMaps = new List<ControllerMap_Editor>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<CustomController_Editor> customControllers = new List<CustomController_Editor>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<ControllerMapLayoutManager_RuleSet_Editor> controllerMapLayoutManagerRuleSets = new List<ControllerMapLayoutManager_RuleSet_Editor>();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<ControllerMapEnabler_RuleSet_Editor> controllerMapEnablerRuleSets = new List<ControllerMapEnabler_RuleSet_Editor>();

	[NonSerialized]
	private List<InputAction> SRozGzlwCSqTEOsLNzRVLjkjMPqG;

	[NonSerialized]
	private bool YKCplrMIOZgGhFWILDBupAzArJxM;

	private IList<Player_Editor> Players_readOnly;

	private IList<InputAction> Actions_readOnly;

	private IList<InputCategory> ActionCategories_readOnly;

	private IList<InputBehavior> InputBehaviors_readOnly;

	private IList<InputMapCategory> MapCategories_readOnly;

	private IList<InputLayout> JoystickLayouts_readOnly;

	private IList<InputLayout> KeyboardLayouts_readOnly;

	private IList<InputLayout> MouseLayouts_readOnly;

	private IList<InputLayout> CustomControllerLayouts_readOnly;

	private IList<ControllerMap_Editor> JoystickMaps_readOnly;

	private IList<ControllerMap_Editor> KeyboardMaps_readOnly;

	private IList<ControllerMap_Editor> MouseMaps_readOnly;

	private IList<ControllerMap_Editor> CustomControllerMaps_readOnly;

	private IList<ControllerMapLayoutManager_RuleSet_Editor> ControllerMapLayoutManagerRuleSets_readOnly;

	private IList<ControllerMapEnabler_RuleSet_Editor> ControllerMapEnablerRuleSets_readOnly;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int playerIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int actionIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int actionCategoryIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int inputBehaviorIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int mapCategoryIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int joystickLayoutIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int keyboardLayoutIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int mouseLayoutIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int customControllerLayoutIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int joystickMapIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int keyboardMapIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int mouseMapIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int customControllerMapIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int customControllerIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int controllerMapLayoutManagerSetIdCounter;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int controllerMapEnablerSetIdCounter;

	private Func<int, bool> containsActionDelegate;

	internal IList<Player_Editor> lGFeIAmLGtgUDhumBCjgcoiJvJysA
	{
		get
		{
			return XSrhHLLZWmMFQNHbTwQlcvQyDugK();
		}
		private set
		{
			EKyQIHiwQPHpJPmlbXKVdAZCZjuc(list);
		}
	}

	internal IList<InputAction> ksmhmzXQkgkaRicdxXlgwSUUDVYp
	{
		get
		{
			return XlpupBEmfXwSqrNAKNgazyyItAel();
		}
		private set
		{
			VFkOveEUXOueRgbprcxkBjlivXlC(list);
		}
	}

	internal IList<InputCategory> mybVXWaIpThoYOecaVmyEPMexFtc
	{
		get
		{
			return dldukEmLnWcHWmmZNAgyZwhPimKt();
		}
		private set
		{
			qtTYNDuOrZNthkDNfIeUPfuJEqziA(list);
		}
	}

	internal IList<InputBehavior> ngLIAzidyUrQagBNuwtgfblMBqXs
	{
		get
		{
			return hcwlUcKhfNVJLMDIrHhfkNDaBNjzA();
		}
		private set
		{
			dVZGiVgUmAsPewNOpxsEnHmNjYkH(list);
		}
	}

	internal IList<InputMapCategory> ZafdgXbyjVKHQRStKYHPhIFXbXZHA
	{
		get
		{
			return KGLCPkjegIYRmxgYDEkcEyIXeWcP();
		}
		private set
		{
			EaZhgXibGTGeVJfxaQDIjrDIbFzQA(list);
		}
	}

	internal IList<InputLayout> LBDoAlaJWPQXsxJUtSQOfgXAeZviA
	{
		get
		{
			return AGGQAALOcCGoeEVYdgGAwuMHjxNIA();
		}
		private set
		{
			SMWlOoFUEoQBQVFpWZLqIDtbXBFp(list);
		}
	}

	internal IList<InputLayout> rToWMjaawNYKEivdubjMLoZgBXEf
	{
		get
		{
			return xiAbwejaFqgDlIbiSFVfGzQleagBb();
		}
		private set
		{
			ZcxAEyxdisfIHAEdvVetFhUAHncB(list);
		}
	}

	internal IList<InputLayout> wtsvrJQoPmAqDbhorUCPLwxbXwwRA
	{
		get
		{
			return uPwNYhKApbdhnmgbIcnffUUEMzMhA();
		}
		private set
		{
			RvxCqLRATchwTvAdgVWFhDvJfQCi(list);
		}
	}

	internal IList<InputLayout> dAdyusOCYZfTVBZfyIyanRxWznuJA
	{
		get
		{
			return NlIeCEqkTYVKlNPaZUFcgbvfIhK();
		}
		private set
		{
			uZVZEexVKHGqUHiPhcNUJLjICLNdb(list);
		}
	}

	internal IList<ControllerMap_Editor> ghKYmSPdSOMAGqrSMeUtJhCXWTmv
	{
		get
		{
			return tJFZKTjuOajNqeaFFvPdKGGitepM();
		}
		private set
		{
			HxadMGAouWsQPOpyWZXunJXDpTQsA(list);
		}
	}

	internal IList<ControllerMap_Editor> UdNDBcByIHmqSUWIiCqoXKpwCgay
	{
		get
		{
			return mVSDiTpiuWsyjgcdcoiLcggfoMff();
		}
		private set
		{
			YchFWjxxkFWwYOnWxpUlqRGlKOv(list);
		}
	}

	internal IList<ControllerMap_Editor> nudfRugYocVoZFpkqqCZOwtnqdkFA
	{
		get
		{
			return FVGeDiyHIVXnNGbXFHHrGTNKCaw();
		}
		private set
		{
			epswncHRNkVpwRxquqtTbECsZKhj(list);
		}
	}

	internal IList<ControllerMap_Editor> jVpmRwFBiVTdkQOpawfCHGasXMrL
	{
		get
		{
			return MfOQYJLoRVdpxyVtOaFOkQeAozfu();
		}
		private set
		{
			hfwTpCxJnUvmgNPzXLzUlpNupEoE(list);
		}
	}

	internal IList<ControllerMapLayoutManager_RuleSet_Editor> ZBBCNcAFJLZuqoEylQkclPrkrBrCA
	{
		get
		{
			return CziqRtvLynciUimKdCHZeVqSQmaqA();
		}
		private set
		{
			thesMBZEMxbesCRGtBjcKOBCvPEbA(list);
		}
	}

	internal IList<ControllerMapEnabler_RuleSet_Editor> uHKnwHGsVjZoDSkjzEnfReEUPjoh
	{
		get
		{
			return PzFXfUleHhHirycPAyXeGoAtobdS();
		}
		private set
		{
			SJSFMVAOLsuyGOKWZVmaiFiPWeMt(list);
		}
	}

	public ConfigVars ConfigVars => configVars;

	internal IEnumerable<InputMapCategory> RhgCUEgmdjsxXDJbZNsiADBKAqONB
	{
		[IteratorStateMachine(typeof(EzUfjGiMbUSCKHScWnnyyLMvcCjJA))]
		get
		{
			return fkYaCXctyuQobnOHiOHTpLvFKhnR();
		}
	}

	internal IEnumerable<InputCategory> vRHOOwwydvTYqBhAXIyjNYhwOdpW
	{
		[IteratorStateMachine(typeof(tpVlLnmoYborlBCRwxAMRktWotSR))]
		get
		{
			return lylgbFHNFybUqvcskVLrtLPYTiaVA();
		}
	}

	internal IEnumerable<InputAction> tWiDeguLjYQoQjhJtdrQKGBjblOHA
	{
		[IteratorStateMachine(typeof(WOBpweSlbyuhPqrwmlcCCfYAHjsX))]
		get
		{
			return aJopemPKhGLrvVcwQwSuNCdkHsIv();
		}
	}

	public int playerCount
	{
		get
		{
			if (players == null)
			{
				return 0;
			}
			return players.Count;
		}
	}

	private List<InputAction> GzxfLtoGtKjJFQktvEqdAlhKTYeGA => NjqoctZbUFKVxEaddNFBUjRNLoQV();

	internal IList<Player_Editor> XSrhHLLZWmMFQNHbTwQlcvQyDugK()
	{
		return Players_readOnly;
	}

	private void EKyQIHiwQPHpJPmlbXKVdAZCZjuc(IList<Player_Editor> P_0)
	{
		Players_readOnly = P_0;
	}

	internal IList<InputAction> XlpupBEmfXwSqrNAKNgazyyItAel()
	{
		return Actions_readOnly;
	}

	private void VFkOveEUXOueRgbprcxkBjlivXlC(IList<InputAction> P_0)
	{
		Actions_readOnly = P_0;
	}

	internal IList<InputCategory> dldukEmLnWcHWmmZNAgyZwhPimKt()
	{
		return ActionCategories_readOnly;
	}

	private void qtTYNDuOrZNthkDNfIeUPfuJEqziA(IList<InputCategory> P_0)
	{
		ActionCategories_readOnly = P_0;
	}

	internal IList<InputBehavior> hcwlUcKhfNVJLMDIrHhfkNDaBNjzA()
	{
		return InputBehaviors_readOnly;
	}

	private void dVZGiVgUmAsPewNOpxsEnHmNjYkH(IList<InputBehavior> P_0)
	{
		InputBehaviors_readOnly = P_0;
	}

	internal IList<InputMapCategory> KGLCPkjegIYRmxgYDEkcEyIXeWcP()
	{
		return MapCategories_readOnly;
	}

	private void EaZhgXibGTGeVJfxaQDIjrDIbFzQA(IList<InputMapCategory> P_0)
	{
		MapCategories_readOnly = P_0;
	}

	internal IList<InputLayout> AGGQAALOcCGoeEVYdgGAwuMHjxNIA()
	{
		return JoystickLayouts_readOnly;
	}

	private void SMWlOoFUEoQBQVFpWZLqIDtbXBFp(IList<InputLayout> P_0)
	{
		JoystickLayouts_readOnly = P_0;
	}

	internal IList<InputLayout> xiAbwejaFqgDlIbiSFVfGzQleagBb()
	{
		return KeyboardLayouts_readOnly;
	}

	private void ZcxAEyxdisfIHAEdvVetFhUAHncB(IList<InputLayout> P_0)
	{
		KeyboardLayouts_readOnly = P_0;
	}

	internal IList<InputLayout> uPwNYhKApbdhnmgbIcnffUUEMzMhA()
	{
		return MouseLayouts_readOnly;
	}

	private void RvxCqLRATchwTvAdgVWFhDvJfQCi(IList<InputLayout> P_0)
	{
		MouseLayouts_readOnly = P_0;
	}

	internal IList<InputLayout> NlIeCEqkTYVKlNPaZUFcgbvfIhK()
	{
		return CustomControllerLayouts_readOnly;
	}

	private void uZVZEexVKHGqUHiPhcNUJLjICLNdb(IList<InputLayout> P_0)
	{
		CustomControllerLayouts_readOnly = P_0;
	}

	internal IList<ControllerMap_Editor> tJFZKTjuOajNqeaFFvPdKGGitepM()
	{
		return JoystickMaps_readOnly;
	}

	private void HxadMGAouWsQPOpyWZXunJXDpTQsA(IList<ControllerMap_Editor> P_0)
	{
		JoystickMaps_readOnly = P_0;
	}

	internal IList<ControllerMap_Editor> mVSDiTpiuWsyjgcdcoiLcggfoMff()
	{
		return KeyboardMaps_readOnly;
	}

	private void YchFWjxxkFWwYOnWxpUlqRGlKOv(IList<ControllerMap_Editor> P_0)
	{
		KeyboardMaps_readOnly = P_0;
	}

	internal IList<ControllerMap_Editor> FVGeDiyHIVXnNGbXFHHrGTNKCaw()
	{
		return MouseMaps_readOnly;
	}

	private void epswncHRNkVpwRxquqtTbECsZKhj(IList<ControllerMap_Editor> P_0)
	{
		MouseMaps_readOnly = P_0;
	}

	internal IList<ControllerMap_Editor> MfOQYJLoRVdpxyVtOaFOkQeAozfu()
	{
		return CustomControllerMaps_readOnly;
	}

	private void hfwTpCxJnUvmgNPzXLzUlpNupEoE(IList<ControllerMap_Editor> P_0)
	{
		CustomControllerMaps_readOnly = P_0;
	}

	internal IList<ControllerMapLayoutManager_RuleSet_Editor> CziqRtvLynciUimKdCHZeVqSQmaqA()
	{
		return ControllerMapLayoutManagerRuleSets_readOnly;
	}

	private void thesMBZEMxbesCRGtBjcKOBCvPEbA(IList<ControllerMapLayoutManager_RuleSet_Editor> P_0)
	{
		ControllerMapLayoutManagerRuleSets_readOnly = P_0;
	}

	internal IList<ControllerMapEnabler_RuleSet_Editor> PzFXfUleHhHirycPAyXeGoAtobdS()
	{
		return ControllerMapEnablerRuleSets_readOnly;
	}

	private void SJSFMVAOLsuyGOKWZVmaiFiPWeMt(IList<ControllerMapEnabler_RuleSet_Editor> P_0)
	{
		ControllerMapEnablerRuleSets_readOnly = P_0;
	}

	[IteratorStateMachine(typeof(NDGcbamLuPaYamRAjsFzngAaoLhA))]
	internal IEnumerable<InputMapCategory> NftGzkrXNJoNomrqElzLEhjbseEQ(string P_0)
	{
		return new NDGcbamLuPaYamRAjsFzngAaoLhA(-2)
		{
			pSgWHyMgrPTNRfRCMCHvTCgatvTh = this,
			hXDiktsfQGqrsIpDZTgpiihInCyS = P_0
		};
	}

	[IteratorStateMachine(typeof(EzUfjGiMbUSCKHScWnnyyLMvcCjJA))]
	internal IEnumerable<InputMapCategory> fkYaCXctyuQobnOHiOHTpLvFKhnR()
	{
		return new EzUfjGiMbUSCKHScWnnyyLMvcCjJA(-2)
		{
			HajMZcAvYSotosqWTtvxwihZRmwv = this
		};
	}

	[IteratorStateMachine(typeof(AKiCZFjQqHdkSgaeMKviclujtpHUA))]
	internal IEnumerable<InputMapCategory> EObBBElaMgCRLbcyuxiwNRJTjfSD(string P_0)
	{
		return new AKiCZFjQqHdkSgaeMKviclujtpHUA(-2)
		{
			KOnTNOdKtqjNWWaFDLHXNAiLEzcFA = this,
			IsiGyBSsdoQGsZHKCHvLCKodlkSW = P_0
		};
	}

	[IteratorStateMachine(typeof(CjfRnglwKjiMGdrYvFGnOVOOWNHb))]
	internal IEnumerable<InputCategory> omZhprCgbSCJaEsuDekUmlbKoyaWA(string P_0)
	{
		return new CjfRnglwKjiMGdrYvFGnOVOOWNHb(-2)
		{
			vLRvRaZiUdbCCAyDwrXxqYOyvImJ = this,
			oyqiNNygxUwIHZcnyxuSaXPxmQWk = P_0
		};
	}

	[IteratorStateMachine(typeof(tpVlLnmoYborlBCRwxAMRktWotSR))]
	internal IEnumerable<InputCategory> lylgbFHNFybUqvcskVLrtLPYTiaVA()
	{
		return new tpVlLnmoYborlBCRwxAMRktWotSR(-2)
		{
			fllKKzwgzykrnfEcYihZimyGiEtr = this
		};
	}

	[IteratorStateMachine(typeof(QXwriSWRVeFzNJGjlLRRADhzSuFC))]
	internal IEnumerable<InputCategory> GJogoheLZfgnRiTZbkhodAYZEfhyA(string P_0)
	{
		return new QXwriSWRVeFzNJGjlLRRADhzSuFC(-2)
		{
			lIFJLhqzzwyrRjaKlHzDAmSBICHC = this,
			bKKYbCgSDCsHzLCPoFMsATtsiBbJb = P_0
		};
	}

	[IteratorStateMachine(typeof(WOBpweSlbyuhPqrwmlcCCfYAHjsX))]
	internal IEnumerable<InputAction> aJopemPKhGLrvVcwQwSuNCdkHsIv()
	{
		return new WOBpweSlbyuhPqrwmlcCCfYAHjsX(-2)
		{
			DmDeqfbwOagYbOeFWqOvvLqMNHAg = this
		};
	}

	[IteratorStateMachine(typeof(XLmrlVguGoXlRuMBLNKQHAGKFcPM))]
	internal IEnumerable<InputAction> SkyggREfKoHWjPoLUZZdEbJuIpDsA(int P_0, bool P_1)
	{
		return new XLmrlVguGoXlRuMBLNKQHAGKFcPM(-2)
		{
			jHNcLPamosqbHJQjiReflGUaQLaWA = this,
			AjTwZipmuOLuKLmpWuhBQmABAFWt = P_0,
			qXkXUCRpIPxVdyNmaPPlRTSilcZP = P_1
		};
	}

	[IteratorStateMachine(typeof(mXCorOdlCofpbjGFMBXnGFafeLZKc))]
	internal IEnumerable<InputAction> iIwmDVLkaAXbcoSoRaTMVPQyqehH(string P_0, bool P_1)
	{
		return new mXCorOdlCofpbjGFMBXnGFafeLZKc(-2)
		{
			kNekUoCcHmgtciTdFhpfhBBDKPerB = this,
			HjkTfllOYzDuBODwIvsNNrBCJTzb = P_0,
			tspBfeqnIJbKOesgQmpxxiwmqmXfb = P_1
		};
	}

	[IteratorStateMachine(typeof(fbDejYaMbwAIxegPIFoRgAZDbUGKd))]
	internal IEnumerable<InputAction> VsUjzpARabWnaSvqyqONRgkChBvBA(string P_0)
	{
		return new fbDejYaMbwAIxegPIFoRgAZDbUGKd(-2)
		{
			JNbZBybgCfGApDnMpdyyEKkeKLjVB = this,
			QwCihzahNbIcvagSDDkOWSvKPTHR = P_0
		};
	}

	[IteratorStateMachine(typeof(fBNjgiinOQrLIeMyKcIErTLbnLMkA))]
	internal IEnumerable<InputAction> fREfkcIHCttPZUmFsaQmQQrsGLZJA(int P_0, bool P_1)
	{
		return new fBNjgiinOQrLIeMyKcIErTLbnLMkA(-2)
		{
			OjotMcsVyZQSLFdSrxWAwxasQCtl = this,
			pwcUxxNaZyfqgARUUDvfzUbVTmAJ = P_0,
			ZCBDKWACahlRtStwuJEsAnuexSJB = P_1
		};
	}

	[IteratorStateMachine(typeof(oXXnWNgCLAOGQDqFTBeWlpnQGEpiA))]
	internal IEnumerable<InputAction> IPOjBIqStJVbKHsakMVgJnnOSPUI(string P_0, bool P_1)
	{
		return new oXXnWNgCLAOGQDqFTBeWlpnQGEpiA(-2)
		{
			LDMoAlAFzPebahvpDmMFJCqkARncb = this,
			cRceAzBcMRvqlLxqPucreaqasMDDA = P_0,
			QcXCNeaIivSpOgTzuhnRibbtpQjj = P_1
		};
	}

	public UserData()
		: this(true)
	{
	}

	private UserData(bool P_0)
	{
		if (P_0)
		{
			configVars.updateLoop = UpdateLoopSetting.Update;
			configVars.defaultJoystickAxis2DDeadZoneType = DeadZone2DType.Radial;
			configVars.defaultJoystickAxis2DSensitivityType = AxisSensitivity2DType.Radial;
			Player_Editor player_Editor = UBthGESgJCfdkyhZGCJQaGjTNmSGb();
			player_Editor.KyoGLIDYzrqHhPbWKTQjJwvLHIfw("System");
			player_Editor.wpfHNsmTODGKuEkbnOqYCNhljisV(player_Editor.name);
			player_Editor.WLyzGklxrlUYhFgqFMLekiWVNfSQ("system_player");
			player_Editor.mDREmaITLKWbHjKcJKtjszMGmZFlA(9999999);
			player_Editor.PsAlYeOGSrojqBSvsNXEjuyrlqsR(true);
			player_Editor.xyrRTPjNRpcemaiPeUDbFOFavfeP(true);
			player_Editor.qhLnGAZPqufldeAscoVpFRexCyyR(true);
			player_Editor.uJRyscLrwjFrTGyvqbvdPcFuUHjB(true);
			players.Add(player_Editor);
			InputActionCategory inputActionCategory = eFgPJrKtJkzWpefNzCQFJrbpZxHw();
			inputActionCategory.tlJsFqUBamvrjluRYovKRvNFnglg("Default");
			inputActionCategory.IXEJvKwUiodJWmBLJURXjxxHugcc(inputActionCategory.name);
			actionCategories.Add(inputActionCategory);
			actionCategoryMap.AddCategory(inputActionCategory.id);
			InputBehavior inputBehavior = DNvNCqzPZhEJAJVplidTvfMyvnUc();
			inputBehavior.JxBAaVKDQgAcHfqQAvJgzWkIqfPfB("Default");
			inputBehaviors.Add(inputBehavior);
			InputMapCategory inputMapCategory = SslxqjATSPRJDoPTWHJQtYMalKoo();
			inputMapCategory.tlJsFqUBamvrjluRYovKRvNFnglg("Default");
			inputMapCategory.IXEJvKwUiodJWmBLJURXjxxHugcc(inputMapCategory.name);
			mapCategories.Add(inputMapCategory);
			InputLayout inputLayout = usSIMfnQpzqZmyDtmKsiJhrZIBBi();
			inputLayout.wKokSbqSezldGNPZMbstdkGhHeHEA("Default");
			inputLayout.UazEMKfRCUbxttLHsJBoJXREqvTlA(inputLayout.name);
			joystickLayouts.Add(inputLayout);
			InputLayout inputLayout2 = ljIQuStGschkKnfBjGdilbgIZcyp();
			inputLayout2.wKokSbqSezldGNPZMbstdkGhHeHEA("Default");
			inputLayout2.UazEMKfRCUbxttLHsJBoJXREqvTlA(inputLayout2.name);
			keyboardLayouts.Add(inputLayout2);
			InputLayout inputLayout3 = ZGALencWQiirUmeHKmzIdSLRajtd();
			inputLayout3.wKokSbqSezldGNPZMbstdkGhHeHEA("Default");
			inputLayout3.UazEMKfRCUbxttLHsJBoJXREqvTlA(inputLayout3.name);
			mouseLayouts.Add(inputLayout3);
			InputLayout inputLayout4 = DWHZcCTvHbLXKUNsGTsRfOJpVWYg();
			inputLayout4.wKokSbqSezldGNPZMbstdkGhHeHEA("Default");
			inputLayout4.UazEMKfRCUbxttLHsJBoJXREqvTlA(inputLayout4.name);
			customControllerLayouts.Add(inputLayout3);
		}
	}

	[CustomObfuscation(rename = false)]
	internal void SetDefaultValuesOnCreation()
	{
		configVars.platformVars_osxStandalone = new ConfigVars.PlatformVars_OSXStandalone();
		configVars.platformVars_osxStandalone.useAppleGameController = true;
		configVars.platformVars_windowsStandalone = new ConfigVars.PlatformVars_WindowsStandalone();
		configVars.platformVars_windowsStandalone.useWindowsGamingInput = true;
		configVars.keyCombinationOverrideMode = KeyCombinationOverrideMode.Cancel;
		configVars.generateKeyEventsOnKeyCombinationOverride = true;
	}

	public List<InputAction> GetActions_Copy()
	{
		List<InputAction> list = new List<InputAction>();
		for (int i = 0; i < NjqoctZbUFKVxEaddNFBUjRNLoQV().Count; i++)
		{
			list.Add(NjqoctZbUFKVxEaddNFBUjRNLoQV()[i]);
		}
		return list;
	}

	public List<InputBehavior> GetInputBehaviors_Copy()
	{
		List<InputBehavior> list = new List<InputBehavior>();
		for (int i = 0; i < inputBehaviors.Count; i++)
		{
			list.Add(inputBehaviors[i].Clone());
		}
		return list;
	}

	public List<KeyboardMap> GetKeyboardMaps_Copy()
	{
		List<KeyboardMap> list = new List<KeyboardMap>();
		for (int i = 0; i < keyboardMaps.Count; i++)
		{
			KeyboardMap item = keyboardMaps[i].ojStMBVqVDmLqdIPBguvcbsiunEY(containsActionDelegate);
			list.Add(item);
		}
		return list;
	}

	public List<MouseMap> GetMouseMaps_Copy()
	{
		List<MouseMap> list = new List<MouseMap>();
		for (int i = 0; i < mouseMaps.Count; i++)
		{
			MouseMap item = mouseMaps[i].iidRkGtUpHnjrLTEetclJpfyHYrf(containsActionDelegate);
			list.Add(item);
		}
		return list;
	}

	public void AddPlayer()
	{
		players.Add(UBthGESgJCfdkyhZGCJQaGjTNmSGb());
	}

	public void InsertPlayer(int index)
	{
		if (index < 0 || index >= players.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		players.Insert(index, UBthGESgJCfdkyhZGCJQaGjTNmSGb());
	}

	public void DeletePlayer(int index)
	{
		if (players == null || index < 0 || index >= players.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		players.RemoveAt(index);
	}

	public bool ReorderPlayer(int index, bool offsetDown, bool offsetNow)
	{
		return ListTools.OffsetAtIndex(players, index, offsetDown, offsetNow);
	}

	public void DuplicatePlayer(int index)
	{
		if (players == null || index < 0 || index >= players.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		Player_Editor player_Editor = players[index].Clone();
		player_Editor.mDREmaITLKWbHjKcJKtjszMGmZFlA(GetNewPlayerId());
		player_Editor.KyoGLIDYzrqHhPbWKTQjJwvLHIfw(StringTools.IterateName(player_Editor.name, -1, GetPlayerNames()));
		player_Editor.xyrRTPjNRpcemaiPeUDbFOFavfeP(false);
		if (index == players.Count - 1)
		{
			players.Add(player_Editor);
		}
		else
		{
			players.Insert(index + 1, player_Editor);
		}
	}

	public string[] GetPlayerNames()
	{
		if (players == null)
		{
			return null;
		}
		string[] array = new string[players.Count];
		for (int i = 0; i < players.Count; i++)
		{
			array[i] = players[i].name;
		}
		return array;
	}

	public int GetPlayerNames(IList<string> results)
	{
		if (results == null)
		{
			throw new ArgumentNullException("results");
		}
		results.Clear();
		if (players == null)
		{
			return 0;
		}
		for (int i = 0; i < players.Count; i++)
		{
			results.Add(players[i].name);
		}
		return results.Count;
	}

	public int[] GetPlayerIds()
	{
		if (players == null)
		{
			return null;
		}
		int[] array = new int[players.Count];
		for (int i = 0; i < players.Count; i++)
		{
			array[i] = players[i].id;
		}
		return array;
	}

	public int[] GetPlayerRuntimeIds()
	{
		if (players == null)
		{
			return null;
		}
		int[] array = new int[players.Count];
		for (int i = 0; i < players.Count; i++)
		{
			if (i == 0)
			{
				array[i] = 9999999;
			}
			else
			{
				array[i] = i - 1;
			}
		}
		return array;
	}

	public int GetPlayerRuntimeIds(IList<int> results)
	{
		if (results == null)
		{
			throw new ArgumentNullException("results");
		}
		results.Clear();
		if (players == null)
		{
			return 0;
		}
		for (int i = 0; i < players.Count; i++)
		{
			if (i == 0)
			{
				results.Add(9999999);
			}
			else
			{
				results.Add(i - 1);
			}
		}
		return results.Count;
	}

	public string GetPlayerNameById(int id)
	{
		if (players == null)
		{
			return string.Empty;
		}
		for (int i = 0; i < players.Count; i++)
		{
			if (players[i].id == id)
			{
				return players[i].name;
			}
		}
		return string.Empty;
	}

	public Player_Editor GetPlayer(int index)
	{
		if (players == null || index < 0 || index >= players.Count)
		{
			return null;
		}
		return players[index];
	}

	public int GetPlayerId(string name)
	{
		if (players == null)
		{
			return -1;
		}
		for (int i = 0; i < players.Count; i++)
		{
			if (players[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return players[i].id;
			}
		}
		return -1;
	}

	public bool IsMouseAssigned()
	{
		if (players == null)
		{
			return false;
		}
		int count = players.Count;
		for (int i = 0; i < count; i++)
		{
			if (players[i].assignMouseOnStart)
			{
				return true;
			}
		}
		return false;
	}

	public void ClearMouseAssignments()
	{
		if (players != null)
		{
			int count = players.Count;
			for (int i = 0; i < count; i++)
			{
				players[i].xyrRTPjNRpcemaiPeUDbFOFavfeP(false);
			}
		}
	}

	public bool IsKeyboardAssigned()
	{
		if (players == null)
		{
			return false;
		}
		int count = players.Count;
		for (int i = 0; i < count; i++)
		{
			if (players[i].assignKeyboardOnStart)
			{
				return true;
			}
		}
		return false;
	}

	public void ClearKeyboardAssignments()
	{
		if (players != null)
		{
			int count = players.Count;
			for (int i = 0; i < count; i++)
			{
				players[i].qhLnGAZPqufldeAscoVpFRexCyyR(false);
			}
		}
	}

	private List<InputAction> NjqoctZbUFKVxEaddNFBUjRNLoQV()
	{
		if (!ReInput.isReady)
		{
			return actions;
		}
		return SRozGzlwCSqTEOsLNzRVLjkjMPqG;
	}

	public void AddAction(int categoryId)
	{
		InputAction inputAction = daOZOoAHaaJdXDHVNpiaWeXZojkYA();
		inputAction.lqxUlhffEKUJrRHeHYZDDZrcIOVq(categoryId);
		NjqoctZbUFKVxEaddNFBUjRNLoQV().Add(inputAction);
		actionCategoryMap.AddAction(categoryId, inputAction.id);
	}

	public void InsertAction(int categoryId, int actionId)
	{
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() != null)
		{
			InputAction inputAction = daOZOoAHaaJdXDHVNpiaWeXZojkYA();
			inputAction.lqxUlhffEKUJrRHeHYZDDZrcIOVq(categoryId);
			NjqoctZbUFKVxEaddNFBUjRNLoQV().Add(inputAction);
			int index = actionCategoryMap.IndexOfAction(categoryId, actionId);
			actionCategoryMap.InsertAction(categoryId, inputAction.id, index);
		}
	}

	public void DeleteAction(int categoryId, int actionId)
	{
		if (IndexOfActionCategory(categoryId) >= 0)
		{
			int num = IndexOfAction(actionId);
			if (num >= 0)
			{
				NjqoctZbUFKVxEaddNFBUjRNLoQV().RemoveAt(num);
				actionCategoryMap.RemoveAction(categoryId, actionId);
			}
		}
	}

	public bool ReorderAction(int categoryId, int actionId, bool offsetDown, bool offsetNow)
	{
		return actionCategoryMap.ReorderAction(categoryId, actionId, offsetDown, offsetNow);
	}

	public int DuplicateAction_FromButton(int categoryId, int actionId)
	{
		if (IndexOfActionCategory(categoryId) < 0)
		{
			return -1;
		}
		int num = IndexOfAction(actionId);
		if (num < 0)
		{
			return -1;
		}
		InputAction actionById = GetActionById(actionId);
		if (actionById == null)
		{
			return -1;
		}
		InputAction inputAction = actionById.Clone();
		inputAction.AMAIZfInlMSYYmanVNuUfsJDsYjb(GetNewActionId());
		inputAction.WUHHsrTAElkhpWiNqDYhmjbqOeWL(StringTools.IterateName(inputAction.name, -1, GetActionNames()));
		if (num == NjqoctZbUFKVxEaddNFBUjRNLoQV().Count - 1)
		{
			NjqoctZbUFKVxEaddNFBUjRNLoQV().Add(inputAction);
			actionCategoryMap.AddAction(categoryId, inputAction.id);
			return NjqoctZbUFKVxEaddNFBUjRNLoQV().Count - 1;
		}
		NjqoctZbUFKVxEaddNFBUjRNLoQV().Insert(num + 1, inputAction);
		int num2 = actionCategoryMap.IndexOfAction(categoryId, actionId);
		actionCategoryMap.InsertAction(categoryId, inputAction.id, num2 + 1);
		return num + 1;
	}

	private int OgYmJlUpAKpvoDaKcyXzehqWlDwD(int P_0, InputAction P_1)
	{
		if (IndexOfActionCategory(P_0) < 0)
		{
			return -1;
		}
		InputAction inputAction = P_1.Clone();
		inputAction.AMAIZfInlMSYYmanVNuUfsJDsYjb(GetNewActionId());
		inputAction.WUHHsrTAElkhpWiNqDYhmjbqOeWL(StringTools.IterateName(inputAction.name, -1, GetActionNames()));
		NjqoctZbUFKVxEaddNFBUjRNLoQV().Add(inputAction);
		return NjqoctZbUFKVxEaddNFBUjRNLoQV().Count - 1;
	}

	public string[] GetActionNames()
	{
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return null;
		}
		string[] array = new string[NjqoctZbUFKVxEaddNFBUjRNLoQV().Count];
		for (int i = 0; i < NjqoctZbUFKVxEaddNFBUjRNLoQV().Count; i++)
		{
			array[i] = NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].name;
		}
		return array;
	}

	public int GetActionNames(IList<string> results)
	{
		if (results == null)
		{
			throw new ArgumentNullException("results");
		}
		results.Clear();
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return 0;
		}
		for (int i = 0; i < NjqoctZbUFKVxEaddNFBUjRNLoQV().Count; i++)
		{
			results.Add(NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].name);
		}
		return results.Count;
	}

	public int[] GetActionIds()
	{
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return null;
		}
		int[] array = new int[NjqoctZbUFKVxEaddNFBUjRNLoQV().Count];
		for (int i = 0; i < NjqoctZbUFKVxEaddNFBUjRNLoQV().Count; i++)
		{
			array[i] = NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].id;
		}
		return array;
	}

	public int GetActionIds(IList<int> results)
	{
		if (results == null)
		{
			throw new ArgumentNullException("results");
		}
		results.Clear();
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return 0;
		}
		for (int i = 0; i < NjqoctZbUFKVxEaddNFBUjRNLoQV().Count; i++)
		{
			results.Add(NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].id);
		}
		return results.Count;
	}

	public string GetActionNameById(int id)
	{
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return string.Empty;
		}
		for (int i = 0; i < NjqoctZbUFKVxEaddNFBUjRNLoQV().Count; i++)
		{
			if (NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].id == id)
			{
				return NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].name;
			}
		}
		return string.Empty;
	}

	public InputAction GetAction(int index)
	{
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() == null || index < 0 || index >= NjqoctZbUFKVxEaddNFBUjRNLoQV().Count)
		{
			return null;
		}
		return NjqoctZbUFKVxEaddNFBUjRNLoQV()[index];
	}

	public InputAction GetAction(string name)
	{
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return null;
		}
		int num = IndexOfAction(name);
		if (num < 0)
		{
			return null;
		}
		return NjqoctZbUFKVxEaddNFBUjRNLoQV()[num];
	}

	public InputAction GetActionById(int id)
	{
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return null;
		}
		for (int i = 0; i < NjqoctZbUFKVxEaddNFBUjRNLoQV().Count; i++)
		{
			if (NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].id == id)
			{
				return NjqoctZbUFKVxEaddNFBUjRNLoQV()[i];
			}
		}
		return null;
	}

	public int GetActionId(string name)
	{
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return -1;
		}
		int num = IndexOfAction(name);
		if (num < 0)
		{
			return -1;
		}
		return NjqoctZbUFKVxEaddNFBUjRNLoQV()[num].id;
	}

	public string[] GetSortedActionNamesInCategory(int id)
	{
		if (actionCategories == null || NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return null;
		}
		List<string> list = new List<string>();
		foreach (int item in actionCategoryMap.ActionIdsInCategory(id))
		{
			InputAction actionById = GetActionById(item);
			if (actionById != null)
			{
				list.Add(actionById.name);
			}
		}
		return list.ToArray();
	}

	[IteratorStateMachine(typeof(gfHNMEUXtNDFGqJOkLzguPsNtqKG))]
	public IEnumerable<string> SortedActionNamesInCategory(int id)
	{
		return new gfHNMEUXtNDFGqJOkLzguPsNtqKG(-2)
		{
			mRarecSklqjHMpMXKhAimnAtQBkR = this,
			QpayqpDliEjEAhLcubCLQxFtPFyv = id
		};
	}

	public string[] GetSortedActionDescriptiveNamesInCategory(int id)
	{
		if (actionCategories == null || NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return null;
		}
		List<string> list = new List<string>();
		foreach (int item in actionCategoryMap.ActionIdsInCategory(id))
		{
			InputAction actionById = GetActionById(item);
			if (actionById != null)
			{
				list.Add(actionById.descriptiveName);
			}
		}
		return list.ToArray();
	}

	[IteratorStateMachine(typeof(gPOXZePIQTAyvfXbdxkoIMShOTtJ))]
	public IEnumerable<string> SortedActionDescriptiveNamesInCategory(int id)
	{
		return new gPOXZePIQTAyvfXbdxkoIMShOTtJ(-2)
		{
			PzBTlZLXTMtyomsLzlqetqNICdKEA = this,
			LSTCZCOANqTxkVNMHJWhdMsPdrXM = id
		};
	}

	public int[] GetSortedActionIdsInCategory(int id)
	{
		if (actionCategories == null || NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return null;
		}
		List<int> list = new List<int>();
		foreach (int item in actionCategoryMap.ActionIdsInCategory(id))
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	[IteratorStateMachine(typeof(yOWNjYWURkdazRmwGCLHcnrGwYpL))]
	public IEnumerable<int> SortedActionIdsInCategory(int id)
	{
		return new yOWNjYWURkdazRmwGCLHcnrGwYpL(-2)
		{
			RSbQfpqlAhHfJLHvUnwqBCSIrjhu = this,
			STALTdhKflrqHBYgfKzEWquyyGjl = id
		};
	}

	public bool ContainsAction(int id)
	{
		return IndexOfAction(id) >= 0;
	}

	public int IndexOfAction(int id)
	{
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return -1;
		}
		for (int i = 0; i < NjqoctZbUFKVxEaddNFBUjRNLoQV().Count; i++)
		{
			if (NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfAction(string name)
	{
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return -1;
		}
		if (name == null || name == string.Empty)
		{
			return -1;
		}
		for (int i = 0; i < NjqoctZbUFKVxEaddNFBUjRNLoQV().Count; i++)
		{
			if (NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return i;
			}
		}
		return -1;
	}

	public void AddActionCategory()
	{
		InputActionCategory inputActionCategory = eFgPJrKtJkzWpefNzCQFJrbpZxHw();
		actionCategories.Add(inputActionCategory);
		actionCategoryMap.AddCategory(inputActionCategory.id);
	}

	public void InsertActionCategory(int index)
	{
		if (index < 0 || index >= actionCategories.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		InputActionCategory inputActionCategory = eFgPJrKtJkzWpefNzCQFJrbpZxHw();
		actionCategories.Insert(index, inputActionCategory);
		actionCategoryMap.AddCategory(inputActionCategory.id);
	}

	public void DeleteActionCategory(int index)
	{
		if (actionCategories == null || index < 0 || index >= actionCategories.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		int id = actionCategories[index].id;
		actionCategoryMap.RemoveCategory(id);
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() != null)
		{
			for (int num = NjqoctZbUFKVxEaddNFBUjRNLoQV().Count - 1; num >= 0; num--)
			{
				if (NjqoctZbUFKVxEaddNFBUjRNLoQV()[num].categoryId == id)
				{
					NjqoctZbUFKVxEaddNFBUjRNLoQV().RemoveAt(num);
				}
			}
		}
		actionCategories.RemoveAt(index);
	}

	public bool ReorderActionCategory(int index, bool offsetDown, bool offsetNow)
	{
		if (index < 0 || index >= actionCategories.Count)
		{
			return false;
		}
		return ListTools.OffsetAtIndex(actionCategories, index, offsetDown, offsetNow);
	}

	public void DuplicateActionCategory(int index, bool duplicateActions)
	{
		if (actionCategories == null || index < 0 || index >= actionCategories.Count)
		{
			return;
		}
		InputActionCategory inputActionCategory = new InputActionCategory(actionCategories[index]);
		inputActionCategory.DxydIQkdpBgpQxBGxBhzaNsKYkjEb(GetNewActionCategoryId());
		inputActionCategory.tlJsFqUBamvrjluRYovKRvNFnglg(StringTools.IterateName(inputActionCategory.name, -1, GetActionCategoryNames()));
		if (index == actionCategories.Count - 1)
		{
			actionCategories.Add(inputActionCategory);
		}
		else
		{
			actionCategories.Insert(index + 1, inputActionCategory);
		}
		actionCategoryMap.AddCategory(inputActionCategory.id);
		if (!duplicateActions || NjqoctZbUFKVxEaddNFBUjRNLoQV() == null)
		{
			return;
		}
		int id = inputActionCategory.id;
		int id2 = actionCategories[index].id;
		List<int> list = new List<int>();
		for (int i = 0; i < NjqoctZbUFKVxEaddNFBUjRNLoQV().Count; i++)
		{
			if (NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].categoryId == id2)
			{
				list.Add(i);
			}
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>(list.Count);
		for (int j = 0; j < list.Count; j++)
		{
			InputAction inputAction = NjqoctZbUFKVxEaddNFBUjRNLoQV()[list[j]];
			int num = OgYmJlUpAKpvoDaKcyXzehqWlDwD(id2, inputAction);
			if (num >= 0)
			{
				InputAction inputAction2 = NjqoctZbUFKVxEaddNFBUjRNLoQV()[num];
				inputAction2.lqxUlhffEKUJrRHeHYZDDZrcIOVq(id);
				dictionary.Add(inputAction.id, inputAction2.id);
			}
		}
		foreach (int item in actionCategoryMap.ActionIdsInCategory(id2))
		{
			if (dictionary.TryGetValue(item, out var value))
			{
				actionCategoryMap.AddAction(id, value);
			}
		}
	}

	public void ChangeActionCategory(int actionId, int newCategoryId)
	{
		int num = IndexOfAction(actionId);
		if (num >= 0 && NjqoctZbUFKVxEaddNFBUjRNLoQV()[num].categoryId != newCategoryId)
		{
			actionCategoryMap.ChangeCategory(actionId, newCategoryId);
			NjqoctZbUFKVxEaddNFBUjRNLoQV()[num].lqxUlhffEKUJrRHeHYZDDZrcIOVq(newCategoryId);
		}
	}

	public int GetActionCategoryCount(int id)
	{
		if (actionCategories == null)
		{
			return 0;
		}
		int num = 0;
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() != null)
		{
			for (int i = 0; i < NjqoctZbUFKVxEaddNFBUjRNLoQV().Count; i++)
			{
				if (NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].categoryId == id)
				{
					num++;
				}
			}
		}
		return num;
	}

	public int GetActionCategoryIndex(int id)
	{
		if (actionCategories == null)
		{
			return 0;
		}
		for (int i = 0; i < actionCategories.Count; i++)
		{
			if (actionCategories[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public string[] GetActionCategoryNames()
	{
		if (actionCategories == null)
		{
			return null;
		}
		string[] array = new string[actionCategories.Count];
		for (int i = 0; i < actionCategories.Count; i++)
		{
			array[i] = actionCategories[i].name;
		}
		return array;
	}

	public int[] GetActionCategoryIds()
	{
		if (actionCategories == null)
		{
			return null;
		}
		int[] array = new int[actionCategories.Count];
		for (int i = 0; i < actionCategories.Count; i++)
		{
			array[i] = actionCategories[i].id;
		}
		return array;
	}

	public InputCategory GetActionCategory(int index)
	{
		if (actionCategories == null || index < 0 || index >= actionCategories.Count)
		{
			return null;
		}
		return actionCategories[index];
	}

	public InputCategory GetActionCategory(string name)
	{
		if (actionCategories == null)
		{
			return null;
		}
		int num = IndexOfActionCategory(name);
		if (num < 0)
		{
			return null;
		}
		return actionCategories[num];
	}

	public InputCategory GetActionCategoryById(int id)
	{
		int num = IndexOfActionCategory(id);
		if (num < 0)
		{
			return null;
		}
		return actionCategories[num];
	}

	public int GetActionCategoryId(string name)
	{
		if (actionCategories == null)
		{
			return -1;
		}
		int num = IndexOfActionCategory(name);
		if (num < 0)
		{
			return -1;
		}
		return actionCategories[num].id;
	}

	public string GetActionCategoryNameById(int id)
	{
		if (actionCategories == null)
		{
			return string.Empty;
		}
		for (int i = 0; i < actionCategories.Count; i++)
		{
			if (actionCategories[i].id == id)
			{
				return actionCategories[i].name;
			}
		}
		return string.Empty;
	}

	public int IndexOfActionCategory(int id)
	{
		if (actionCategories == null)
		{
			return -1;
		}
		for (int i = 0; i < actionCategories.Count; i++)
		{
			if (actionCategories[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfActionCategory(string name)
	{
		if (name == null || name == string.Empty)
		{
			return -1;
		}
		if (actionCategories == null)
		{
			return -1;
		}
		for (int i = 0; i < actionCategories.Count; i++)
		{
			if (actionCategories[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return i;
			}
		}
		return -1;
	}

	public int GetActionCategoryCount()
	{
		if (actionCategories == null)
		{
			return 0;
		}
		return actionCategories.Count;
	}

	public void AddInputBehavior()
	{
		inputBehaviors.Add(DNvNCqzPZhEJAJVplidTvfMyvnUc());
	}

	public void InsertInputBehavior(int index)
	{
		if (index < 0 || index >= inputBehaviors.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		inputBehaviors.Insert(index, DNvNCqzPZhEJAJVplidTvfMyvnUc());
	}

	public void DeleteInputBehavior(int index)
	{
		if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		int id = inputBehaviors[index].id;
		if (NjqoctZbUFKVxEaddNFBUjRNLoQV() != null)
		{
			for (int i = 0; i < NjqoctZbUFKVxEaddNFBUjRNLoQV().Count; i++)
			{
				if (NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].behaviorId == id)
				{
					NjqoctZbUFKVxEaddNFBUjRNLoQV()[i].PiUFsDNerYNrnOuphGYyaUCZBwQk(0);
				}
			}
		}
		inputBehaviors.RemoveAt(index);
	}

	public bool ReorderInputBehavior(int index, bool offsetDown, bool offsetNow)
	{
		return ListTools.OffsetAtIndex(inputBehaviors, index, offsetDown, offsetNow);
	}

	public void DuplicateInputBehavior(int index)
	{
		if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		InputBehavior inputBehavior = inputBehaviors[index].Clone();
		inputBehavior.PvvzgovLhWQeTzjOCClzdPKHgnSCA(GetNewInputBehaviorId());
		inputBehavior.JxBAaVKDQgAcHfqQAvJgzWkIqfPfB(StringTools.IterateName(inputBehavior.name, -1, GetInputBehaviorNames()));
		if (index == inputBehaviors.Count - 1)
		{
			inputBehaviors.Add(inputBehavior);
		}
		else
		{
			inputBehaviors.Insert(index + 1, inputBehavior);
		}
	}

	public string[] GetInputBehaviorNames()
	{
		if (inputBehaviors == null)
		{
			return null;
		}
		string[] array = new string[inputBehaviors.Count];
		for (int i = 0; i < inputBehaviors.Count; i++)
		{
			array[i] = inputBehaviors[i].name;
		}
		return array;
	}

	public int[] GetInputBehaviorIds()
	{
		if (inputBehaviors == null)
		{
			return null;
		}
		int[] array = new int[inputBehaviors.Count];
		for (int i = 0; i < inputBehaviors.Count; i++)
		{
			array[i] = inputBehaviors[i].id;
		}
		return array;
	}

	public InputBehavior GetInputBehavior(int index)
	{
		if (inputBehaviors == null || index < 0 || index >= inputBehaviors.Count)
		{
			return null;
		}
		return inputBehaviors[index];
	}

	public InputBehavior GetInputBehavior(string name)
	{
		if (inputBehaviors == null)
		{
			return null;
		}
		int num = IndexOfInputBehavior(name);
		if (num < 0)
		{
			return null;
		}
		return inputBehaviors[num];
	}

	public InputBehavior GetInputBehaviorById(int id)
	{
		if (inputBehaviors == null)
		{
			return null;
		}
		for (int i = 0; i < inputBehaviors.Count; i++)
		{
			if (inputBehaviors[i].id == id)
			{
				return inputBehaviors[i];
			}
		}
		return null;
	}

	public int GetInputBehaviorId(string name)
	{
		if (inputBehaviors == null)
		{
			return -1;
		}
		int num = IndexOfInputBehavior(name);
		if (num < 0)
		{
			return -1;
		}
		return inputBehaviors[num].id;
	}

	public int IndexOfInputBehavior(int id)
	{
		if (inputBehaviors == null)
		{
			return -1;
		}
		for (int i = 0; i < inputBehaviors.Count; i++)
		{
			if (inputBehaviors[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfInputBehavior(string name)
	{
		if (inputBehaviors == null)
		{
			return -1;
		}
		if (name == null || name == string.Empty)
		{
			return -1;
		}
		for (int i = 0; i < inputBehaviors.Count; i++)
		{
			if (inputBehaviors[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return i;
			}
		}
		return -1;
	}

	public void AddMapCategory()
	{
		mapCategories.Add(SslxqjATSPRJDoPTWHJQtYMalKoo());
	}

	public void InsertMapCategory(int index)
	{
		if (index < 0 || index >= mapCategories.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		mapCategories.Insert(index, SslxqjATSPRJDoPTWHJQtYMalKoo());
	}

	public void DeleteMapCategory(int index)
	{
		if (mapCategories == null || index < 0 || index >= mapCategories.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		int id = mapCategories[index].id;
		if (joystickMaps != null)
		{
			for (int num = joystickMaps.Count - 1; num >= 0; num--)
			{
				if (joystickMaps[num].categoryId == id)
				{
					joystickMaps.RemoveAt(num);
				}
			}
		}
		if (keyboardMaps != null)
		{
			for (int num2 = keyboardMaps.Count - 1; num2 >= 0; num2--)
			{
				if (keyboardMaps[num2].categoryId == id)
				{
					keyboardMaps.RemoveAt(num2);
				}
			}
		}
		if (mouseMaps != null)
		{
			for (int num3 = mouseMaps.Count - 1; num3 >= 0; num3--)
			{
				if (mouseMaps[num3].categoryId == id)
				{
					mouseMaps.RemoveAt(num3);
				}
			}
		}
		if (customControllerMaps != null)
		{
			for (int num4 = customControllerMaps.Count - 1; num4 >= 0; num4--)
			{
				if (customControllerMaps[num4].categoryId == id)
				{
					customControllerMaps.RemoveAt(num4);
				}
			}
		}
		if (mapCategories != null)
		{
			for (int i = 0; i < mapCategories.Count; i++)
			{
				InputMapCategory inputMapCategory = mapCategories[i];
				if (inputMapCategory.checkConflictsCategoryIds == null)
				{
					continue;
				}
				for (int j = 0; j < inputMapCategory.checkConflictsCategoryIds.Count; j++)
				{
					if (inputMapCategory.checkConflictsCategoryIds[j] == id)
					{
						inputMapCategory.checkConflictsCategoryIds.RemoveAt(j);
					}
				}
			}
		}
		if (players != null)
		{
			Action<List<Player_Editor.Mapping>, int> action = vKpFkbcuYIVXcnMKdGksbTyDNybbb._003C_003E9.vxDhIcJZPdVaXHpgCFOuwfdAEoQn;
			for (int k = 0; k < players.Count; k++)
			{
				Player_Editor player_Editor = players[k];
				if (player_Editor != null)
				{
					action(player_Editor.defaultKeyboardMaps, id);
					action(player_Editor.defaultMouseMaps, id);
					action(player_Editor.defaultJoystickMaps, id);
					action(player_Editor.defaultCustomControllerMaps, id);
				}
			}
		}
		mapCategories.RemoveAt(index);
	}

	public bool ReorderMapCategory(int index, bool offsetDown, bool offsetNow)
	{
		return ListTools.OffsetAtIndex(mapCategories, index, offsetDown, offsetNow);
	}

	public void DuplicateMapCategory(int index, bool duplicateMaps)
	{
		if (mapCategories == null || index < 0 || index >= mapCategories.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		InputMapCategory inputMapCategory = new InputMapCategory(mapCategories[index]);
		inputMapCategory.DxydIQkdpBgpQxBGxBhzaNsKYkjEb(GetNewMapCategoryId());
		inputMapCategory.tlJsFqUBamvrjluRYovKRvNFnglg(StringTools.IterateName(inputMapCategory.name, -1, GetMapCategoryNames()));
		if (index == mapCategories.Count - 1)
		{
			mapCategories.Add(inputMapCategory);
		}
		else
		{
			mapCategories.Insert(index + 1, inputMapCategory);
		}
		if (!duplicateMaps)
		{
			return;
		}
		int id = inputMapCategory.id;
		int id2 = mapCategories[index].id;
		if (joystickMaps != null)
		{
			for (int num = joystickMaps.Count - 1; num >= 0; num--)
			{
				if (joystickMaps[num].categoryId == id2)
				{
					int num2 = DuplicateJoystickMap(num);
					if (num2 >= 0)
					{
						joystickMaps[num2].categoryId = id;
					}
				}
			}
		}
		if (keyboardMaps != null)
		{
			for (int num3 = keyboardMaps.Count - 1; num3 >= 0; num3--)
			{
				if (keyboardMaps[num3].categoryId == id2)
				{
					int num4 = DuplicateKeyboardMap(num3);
					if (num4 >= 0)
					{
						keyboardMaps[num4].categoryId = id;
					}
				}
			}
		}
		if (mouseMaps != null)
		{
			for (int num5 = mouseMaps.Count - 1; num5 >= 0; num5--)
			{
				if (mouseMaps[num5].categoryId == id2)
				{
					int num6 = DuplicateMouseMap(num5);
					if (num6 >= 0)
					{
						mouseMaps[num6].categoryId = id;
					}
				}
			}
		}
		if (customControllerMaps == null)
		{
			return;
		}
		for (int num7 = customControllerMaps.Count - 1; num7 >= 0; num7--)
		{
			if (customControllerMaps[num7].categoryId == id2)
			{
				int num8 = DuplicateCustomControllerMap(num7);
				if (num8 >= 0)
				{
					customControllerMaps[num8].categoryId = id;
				}
			}
		}
	}

	public int GetMapCategoryMapCount(int id)
	{
		if (mapCategories == null)
		{
			return 0;
		}
		int num = 0;
		if (joystickMaps != null)
		{
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].categoryId == id)
				{
					num++;
				}
			}
		}
		if (keyboardMaps != null)
		{
			for (int j = 0; j < keyboardMaps.Count; j++)
			{
				if (keyboardMaps[j].categoryId == id)
				{
					num++;
				}
			}
		}
		if (mouseMaps != null)
		{
			for (int k = 0; k < mouseMaps.Count; k++)
			{
				if (mouseMaps[k].categoryId == id)
				{
					num++;
				}
			}
		}
		if (customControllerMaps != null)
		{
			for (int l = 0; l < customControllerMaps.Count; l++)
			{
				if (customControllerMaps[l].categoryId == id)
				{
					num++;
				}
			}
		}
		return num;
	}

	public int GetMapCategoryIndex(int id)
	{
		if (mapCategories == null)
		{
			return 0;
		}
		for (int i = 0; i < mapCategories.Count; i++)
		{
			if (mapCategories[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public string[] GetMapCategoryNames()
	{
		if (mapCategories == null)
		{
			return null;
		}
		string[] array = new string[mapCategories.Count];
		for (int i = 0; i < mapCategories.Count; i++)
		{
			array[i] = mapCategories[i].name;
		}
		return array;
	}

	public int[] GetMapCategoryIds()
	{
		if (mapCategories == null)
		{
			return null;
		}
		int[] array = new int[mapCategories.Count];
		for (int i = 0; i < mapCategories.Count; i++)
		{
			array[i] = mapCategories[i].id;
		}
		return array;
	}

	public InputMapCategory GetMapCategory(int index)
	{
		if (mapCategories == null || index < 0 || index >= mapCategories.Count)
		{
			return null;
		}
		return mapCategories[index];
	}

	public InputMapCategory GetMapCategory(string name)
	{
		if (mapCategories == null)
		{
			return null;
		}
		int num = IndexOfMapCategory(name);
		if (num < 0)
		{
			return null;
		}
		return mapCategories[num];
	}

	public InputMapCategory GetMapCategoryById(int id)
	{
		if (mapCategories == null)
		{
			return null;
		}
		for (int i = 0; i < mapCategories.Count; i++)
		{
			if (mapCategories[i].id == id)
			{
				return mapCategories[i];
			}
		}
		return null;
	}

	public int GetMapCategoryId(string name)
	{
		if (mapCategories == null)
		{
			return -1;
		}
		int num = IndexOfMapCategory(name);
		if (num < 0)
		{
			return -1;
		}
		return mapCategories[num].id;
	}

	public string GetMapCategoryNameById(int id)
	{
		if (mapCategories == null)
		{
			return string.Empty;
		}
		for (int i = 0; i < mapCategories.Count; i++)
		{
			if (mapCategories[i].id == id)
			{
				return mapCategories[i].name;
			}
		}
		return string.Empty;
	}

	public int IndexOfMapCategory(int id)
	{
		if (mapCategories == null)
		{
			return -1;
		}
		for (int i = 0; i < mapCategories.Count; i++)
		{
			if (mapCategories[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfMapCategory(string name)
	{
		if (name == null || name == string.Empty)
		{
			return -1;
		}
		if (mapCategories == null)
		{
			return -1;
		}
		for (int i = 0; i < mapCategories.Count; i++)
		{
			if (mapCategories[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return i;
			}
		}
		return -1;
	}

	public string[] GetLayoutNames(ControllerType controllerType)
	{
		return controllerType switch
		{
			ControllerType.Keyboard => GetKeyboardLayoutNames(), 
			ControllerType.Mouse => GetMouseLayoutNames(), 
			ControllerType.Joystick => GetJoystickLayoutNames(), 
			ControllerType.Custom => GetCustomControllerLayoutNames(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public int[] GetLayoutIds(ControllerType controllerType)
	{
		return controllerType switch
		{
			ControllerType.Keyboard => GetKeyboardLayoutIds(), 
			ControllerType.Mouse => GetMouseLayoutIds(), 
			ControllerType.Joystick => GetJoystickLayoutIds(), 
			ControllerType.Custom => GetCustomControllerLayoutIds(), 
			_ => throw new NotImplementedException(), 
		};
	}

	public void AddJoystickLayout()
	{
		joystickLayouts.Add(usSIMfnQpzqZmyDtmKsiJhrZIBBi());
	}

	public void InsertJoystickLayout(int index)
	{
		if (index < 0 || index >= joystickLayouts.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		joystickLayouts.Insert(index, usSIMfnQpzqZmyDtmKsiJhrZIBBi());
	}

	public void DeleteJoystickLayout(int index)
	{
		if (joystickLayouts == null || index < 0 || index >= joystickLayouts.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		int id = joystickLayouts[index].id;
		if (joystickMaps != null)
		{
			for (int num = joystickMaps.Count - 1; num >= 0; num--)
			{
				if (joystickMaps[num].layoutId == id)
				{
					joystickMaps.RemoveAt(num);
				}
			}
		}
		if (players != null)
		{
			Action<List<Player_Editor.Mapping>, int> action = vKpFkbcuYIVXcnMKdGksbTyDNybbb._003C_003E9.TLgevpKOWjhoRCSkzxLyfDljJMQS;
			for (int i = 0; i < players.Count; i++)
			{
				Player_Editor player_Editor = players[i];
				if (player_Editor != null)
				{
					action(player_Editor.defaultJoystickMaps, id);
				}
			}
		}
		joystickLayouts.RemoveAt(index);
	}

	public bool ReorderJoystickLayout(int index, bool offsetDown, bool offsetNow)
	{
		return ListTools.OffsetAtIndex(joystickLayouts, index, offsetDown, offsetNow);
	}

	public void DuplicateJoystickLayout(int index, bool duplicateMaps)
	{
		if (joystickLayouts == null || index < 0 || index >= joystickLayouts.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		InputLayout inputLayout = joystickLayouts[index].Clone();
		inputLayout.rSjyzIcdJPGZvBbKrSRkLscLlslcA(GetNewJoystickLayoutId());
		inputLayout.wKokSbqSezldGNPZMbstdkGhHeHEA(StringTools.IterateName(inputLayout.name, -1, GetJoystickLayoutNames()));
		if (index == joystickLayouts.Count - 1)
		{
			joystickLayouts.Add(inputLayout);
		}
		else
		{
			joystickLayouts.Insert(index + 1, inputLayout);
		}
		if (!duplicateMaps)
		{
			return;
		}
		int id = inputLayout.id;
		int id2 = joystickLayouts[index].id;
		if (joystickMaps == null)
		{
			return;
		}
		for (int num = joystickMaps.Count - 1; num >= 0; num--)
		{
			if (joystickMaps[num].layoutId == id2)
			{
				int num2 = DuplicateJoystickMap(num);
				if (num2 >= 0)
				{
					joystickMaps[num2].layoutId = id;
				}
			}
		}
	}

	public int GetJoystickLayoutMapCount(int id)
	{
		if (joystickLayouts == null)
		{
			return 0;
		}
		int num = 0;
		if (joystickMaps != null)
		{
			for (int i = 0; i < joystickMaps.Count; i++)
			{
				if (joystickMaps[i].layoutId == id)
				{
					num++;
				}
			}
		}
		return num;
	}

	public int GetJoystickLayoutIndex(int id)
	{
		if (joystickLayouts == null)
		{
			return 0;
		}
		for (int i = 0; i < joystickLayouts.Count; i++)
		{
			if (joystickLayouts[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public string[] GetJoystickLayoutNames()
	{
		if (joystickLayouts == null)
		{
			return null;
		}
		string[] array = new string[joystickLayouts.Count];
		for (int i = 0; i < joystickLayouts.Count; i++)
		{
			array[i] = joystickLayouts[i].name;
		}
		return array;
	}

	public int[] GetJoystickLayoutIds()
	{
		if (joystickLayouts == null)
		{
			return null;
		}
		int[] array = new int[joystickLayouts.Count];
		for (int i = 0; i < joystickLayouts.Count; i++)
		{
			array[i] = joystickLayouts[i].id;
		}
		return array;
	}

	public InputLayout GetJoystickLayout(int index)
	{
		if (joystickLayouts == null || index < 0 || index >= joystickLayouts.Count)
		{
			return null;
		}
		return joystickLayouts[index];
	}

	public InputLayout GetJoystickLayout(string name)
	{
		if (joystickLayouts == null)
		{
			return null;
		}
		int num = IndexOfJoystickLayout(name);
		if (num < 0)
		{
			return null;
		}
		return joystickLayouts[num];
	}

	public InputLayout GetJoystickLayoutById(int id)
	{
		if (joystickLayouts == null)
		{
			return null;
		}
		int num = IndexOfJoystickLayout(id);
		if (num < 0)
		{
			return null;
		}
		return joystickLayouts[num];
	}

	public int GetJoystickLayoutId(string name)
	{
		if (joystickLayouts == null)
		{
			return -1;
		}
		int num = IndexOfJoystickLayout(name);
		if (num < 0)
		{
			return -1;
		}
		return joystickLayouts[num].id;
	}

	public int IndexOfJoystickLayout(int id)
	{
		if (joystickLayouts == null)
		{
			return -1;
		}
		for (int i = 0; i < joystickLayouts.Count; i++)
		{
			if (joystickLayouts[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfJoystickLayout(string name)
	{
		if (name == null || name == string.Empty)
		{
			return -1;
		}
		if (joystickLayouts == null)
		{
			return -1;
		}
		for (int i = 0; i < joystickLayouts.Count; i++)
		{
			if (joystickLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return i;
			}
		}
		return -1;
	}

	public string GetJoystickLayoutNameById(int id)
	{
		if (joystickLayouts != null)
		{
			for (int i = 0; i < joystickLayouts.Count; i++)
			{
				if (joystickLayouts[i].id == id)
				{
					return joystickLayouts[i].name;
				}
			}
		}
		return "Unknown";
	}

	public void AddKeyboardLayout()
	{
		keyboardLayouts.Add(ljIQuStGschkKnfBjGdilbgIZcyp());
	}

	public void InsertKeyboardLayout(int index)
	{
		if (index < 0 || index >= keyboardLayouts.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		keyboardLayouts.Insert(index, ljIQuStGschkKnfBjGdilbgIZcyp());
	}

	public void DeleteKeyboardLayout(int index)
	{
		if (keyboardLayouts == null || index < 0 || index >= keyboardLayouts.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		int id = keyboardLayouts[index].id;
		if (keyboardMaps != null)
		{
			for (int num = keyboardMaps.Count - 1; num >= 0; num--)
			{
				if (keyboardMaps[num].layoutId == id)
				{
					keyboardMaps.RemoveAt(num);
				}
			}
		}
		if (players != null)
		{
			Action<List<Player_Editor.Mapping>, int> action = vKpFkbcuYIVXcnMKdGksbTyDNybbb._003C_003E9.JapRMTDOSqvwLJAHnMbSONeAiNpR;
			for (int i = 0; i < players.Count; i++)
			{
				Player_Editor player_Editor = players[i];
				if (player_Editor != null)
				{
					action(player_Editor.defaultKeyboardMaps, id);
				}
			}
		}
		keyboardLayouts.RemoveAt(index);
	}

	public bool ReorderKeyboardLayout(int index, bool offsetDown, bool offsetNow)
	{
		return ListTools.OffsetAtIndex(keyboardLayouts, index, offsetDown, offsetNow);
	}

	public void DuplicateKeyboardLayout(int index, bool duplicateMaps)
	{
		if (keyboardLayouts == null || index < 0 || index >= keyboardLayouts.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		InputLayout inputLayout = keyboardLayouts[index].Clone();
		inputLayout.rSjyzIcdJPGZvBbKrSRkLscLlslcA(GetNewKeyboardLayoutId());
		inputLayout.wKokSbqSezldGNPZMbstdkGhHeHEA(StringTools.IterateName(inputLayout.name, -1, GetKeyboardLayoutNames()));
		if (index == keyboardLayouts.Count - 1)
		{
			keyboardLayouts.Add(inputLayout);
		}
		else
		{
			keyboardLayouts.Insert(index + 1, inputLayout);
		}
		if (!duplicateMaps)
		{
			return;
		}
		int id = inputLayout.id;
		int id2 = keyboardLayouts[index].id;
		if (keyboardMaps == null)
		{
			return;
		}
		for (int num = keyboardMaps.Count - 1; num >= 0; num--)
		{
			if (keyboardMaps[num].layoutId == id2)
			{
				int num2 = DuplicateKeyboardMap(num);
				if (num2 >= 0)
				{
					keyboardMaps[num2].layoutId = id;
				}
			}
		}
	}

	public int GetKeyboardLayoutMapCount(int id)
	{
		if (keyboardLayouts == null)
		{
			return 0;
		}
		int num = 0;
		if (keyboardMaps != null)
		{
			for (int i = 0; i < keyboardMaps.Count; i++)
			{
				if (keyboardMaps[i].layoutId == id)
				{
					num++;
				}
			}
		}
		return num;
	}

	public int GetKeyboardLayoutIndex(int id)
	{
		if (keyboardLayouts == null)
		{
			return 0;
		}
		for (int i = 0; i < keyboardLayouts.Count; i++)
		{
			if (keyboardLayouts[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public string[] GetKeyboardLayoutNames()
	{
		if (keyboardLayouts == null)
		{
			return null;
		}
		string[] array = new string[keyboardLayouts.Count];
		for (int i = 0; i < keyboardLayouts.Count; i++)
		{
			array[i] = keyboardLayouts[i].name;
		}
		return array;
	}

	public int[] GetKeyboardLayoutIds()
	{
		if (keyboardLayouts == null)
		{
			return null;
		}
		int[] array = new int[keyboardLayouts.Count];
		for (int i = 0; i < keyboardLayouts.Count; i++)
		{
			array[i] = keyboardLayouts[i].id;
		}
		return array;
	}

	public InputLayout GetKeyboardLayout(int index)
	{
		if (keyboardLayouts == null || index < 0 || index >= keyboardLayouts.Count)
		{
			return null;
		}
		return keyboardLayouts[index];
	}

	public InputLayout GetKeyboardLayout(string name)
	{
		if (keyboardLayouts == null)
		{
			return null;
		}
		int num = IndexOfKeyboardLayout(name);
		if (num < 0)
		{
			return null;
		}
		return keyboardLayouts[num];
	}

	public InputLayout GetKeyboardLayoutById(int id)
	{
		if (keyboardLayouts == null)
		{
			return null;
		}
		int num = IndexOfKeyboardLayout(id);
		if (num < 0)
		{
			return null;
		}
		return keyboardLayouts[num];
	}

	public int GetKeyboardLayoutId(string name)
	{
		if (keyboardLayouts == null)
		{
			return -1;
		}
		int num = IndexOfKeyboardLayout(name);
		if (num < 0)
		{
			return -1;
		}
		return keyboardLayouts[num].id;
	}

	public int IndexOfKeyboardLayout(int id)
	{
		if (keyboardLayouts == null)
		{
			return -1;
		}
		for (int i = 0; i < keyboardLayouts.Count; i++)
		{
			if (keyboardLayouts[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfKeyboardLayout(string name)
	{
		if (name == null || name == string.Empty)
		{
			return -1;
		}
		if (keyboardLayouts == null)
		{
			return -1;
		}
		for (int i = 0; i < keyboardLayouts.Count; i++)
		{
			if (keyboardLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return i;
			}
		}
		return -1;
	}

	public string GetKeyboardLayoutNameById(int id)
	{
		if (keyboardLayouts != null)
		{
			for (int i = 0; i < keyboardLayouts.Count; i++)
			{
				if (keyboardLayouts[i].id == id)
				{
					return keyboardLayouts[i].name;
				}
			}
		}
		return "Unknown";
	}

	public void AddMouseLayout()
	{
		mouseLayouts.Add(ZGALencWQiirUmeHKmzIdSLRajtd());
	}

	public void InsertMouseLayout(int index)
	{
		if (index < 0 || index >= mouseLayouts.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		mouseLayouts.Insert(index, ZGALencWQiirUmeHKmzIdSLRajtd());
	}

	public void DeleteMouseLayout(int index)
	{
		if (mouseLayouts == null || index < 0 || index >= mouseLayouts.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		int id = mouseLayouts[index].id;
		if (mouseMaps != null)
		{
			for (int num = mouseMaps.Count - 1; num >= 0; num--)
			{
				if (mouseMaps[num].layoutId == id)
				{
					mouseMaps.RemoveAt(num);
				}
			}
		}
		if (players != null)
		{
			Action<List<Player_Editor.Mapping>, int> action = vKpFkbcuYIVXcnMKdGksbTyDNybbb._003C_003E9.mRVlOoULjpHIdCOSMpkIcKsvTamu;
			for (int i = 0; i < players.Count; i++)
			{
				Player_Editor player_Editor = players[i];
				if (player_Editor != null)
				{
					action(player_Editor.defaultMouseMaps, id);
				}
			}
		}
		mouseLayouts.RemoveAt(index);
	}

	public bool ReorderMouseLayout(int index, bool offsetDown, bool offsetNow)
	{
		return ListTools.OffsetAtIndex(mouseLayouts, index, offsetDown, offsetNow);
	}

	public void DuplicateMouseLayout(int index, bool duplicateMaps)
	{
		if (mouseLayouts == null || index < 0 || index >= mouseLayouts.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		InputLayout inputLayout = mouseLayouts[index].Clone();
		inputLayout.rSjyzIcdJPGZvBbKrSRkLscLlslcA(GetNewMouseLayoutId());
		inputLayout.wKokSbqSezldGNPZMbstdkGhHeHEA(StringTools.IterateName(inputLayout.name, -1, GetMouseLayoutNames()));
		if (index == mouseLayouts.Count - 1)
		{
			mouseLayouts.Add(inputLayout);
		}
		else
		{
			mouseLayouts.Insert(index + 1, inputLayout);
		}
		if (!duplicateMaps)
		{
			return;
		}
		int id = inputLayout.id;
		int id2 = mouseLayouts[index].id;
		if (mouseMaps == null)
		{
			return;
		}
		for (int num = mouseMaps.Count - 1; num >= 0; num--)
		{
			if (mouseMaps[num].layoutId == id2)
			{
				int num2 = DuplicateMouseMap(num);
				if (num2 >= 0)
				{
					mouseMaps[num2].layoutId = id;
				}
			}
		}
	}

	public int GetMouseLayoutMapCount(int id)
	{
		if (mouseLayouts == null)
		{
			return 0;
		}
		int num = 0;
		if (mouseMaps != null)
		{
			for (int i = 0; i < mouseMaps.Count; i++)
			{
				if (mouseMaps[i].layoutId == id)
				{
					num++;
				}
			}
		}
		return num;
	}

	public int GetMouseLayoutIndex(int id)
	{
		if (mouseLayouts == null)
		{
			return 0;
		}
		for (int i = 0; i < mouseLayouts.Count; i++)
		{
			if (mouseLayouts[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public string[] GetMouseLayoutNames()
	{
		if (mouseLayouts == null)
		{
			return null;
		}
		string[] array = new string[mouseLayouts.Count];
		for (int i = 0; i < mouseLayouts.Count; i++)
		{
			array[i] = mouseLayouts[i].name;
		}
		return array;
	}

	public int[] GetMouseLayoutIds()
	{
		if (mouseLayouts == null)
		{
			return null;
		}
		int[] array = new int[mouseLayouts.Count];
		for (int i = 0; i < mouseLayouts.Count; i++)
		{
			array[i] = mouseLayouts[i].id;
		}
		return array;
	}

	public InputLayout GetMouseLayout(int index)
	{
		if (mouseLayouts == null || index < 0 || index >= mouseLayouts.Count)
		{
			return null;
		}
		return mouseLayouts[index];
	}

	public InputLayout GetMouseLayout(string name)
	{
		if (mouseLayouts == null)
		{
			return null;
		}
		int num = IndexOfMouseLayout(name);
		if (num < 0)
		{
			return null;
		}
		return mouseLayouts[num];
	}

	public InputLayout GetMouseLayoutById(int id)
	{
		if (mouseLayouts == null)
		{
			return null;
		}
		int num = IndexOfMouseLayout(id);
		if (num < 0)
		{
			return null;
		}
		return mouseLayouts[num];
	}

	public int GetMouseLayoutId(string name)
	{
		if (mouseLayouts == null)
		{
			return -1;
		}
		int num = IndexOfMouseLayout(name);
		if (num < 0)
		{
			return -1;
		}
		return mouseLayouts[num].id;
	}

	public int IndexOfMouseLayout(int id)
	{
		if (mouseLayouts == null)
		{
			return -1;
		}
		for (int i = 0; i < mouseLayouts.Count; i++)
		{
			if (mouseLayouts[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfMouseLayout(string name)
	{
		if (name == null || name == string.Empty)
		{
			return -1;
		}
		if (mouseLayouts == null)
		{
			return -1;
		}
		for (int i = 0; i < mouseLayouts.Count; i++)
		{
			if (mouseLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return i;
			}
		}
		return -1;
	}

	public string GetMouseLayoutNameById(int id)
	{
		if (mouseLayouts != null)
		{
			for (int i = 0; i < mouseLayouts.Count; i++)
			{
				if (mouseLayouts[i].id == id)
				{
					return mouseLayouts[i].name;
				}
			}
		}
		return "Unknown";
	}

	public void AddCustomControllerLayout()
	{
		customControllerLayouts.Add(DWHZcCTvHbLXKUNsGTsRfOJpVWYg());
	}

	public void InsertCustomControllerLayout(int index)
	{
		if (index < 0 || index >= customControllerLayouts.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		customControllerLayouts.Insert(index, DWHZcCTvHbLXKUNsGTsRfOJpVWYg());
	}

	public void DeleteCustomControllerLayout(int index)
	{
		if (customControllerLayouts == null || index < 0 || index >= customControllerLayouts.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		int id = customControllerLayouts[index].id;
		if (customControllerMaps != null)
		{
			for (int num = customControllerMaps.Count - 1; num >= 0; num--)
			{
				if (customControllerMaps[num].layoutId == id)
				{
					customControllerMaps.RemoveAt(num);
				}
			}
		}
		if (players != null)
		{
			Action<List<Player_Editor.Mapping>, int> action = vKpFkbcuYIVXcnMKdGksbTyDNybbb._003C_003E9.SLZwLYItQxuEYsTOkeOQcJOoieZF;
			for (int i = 0; i < players.Count; i++)
			{
				Player_Editor player_Editor = players[i];
				if (player_Editor != null)
				{
					action(player_Editor.defaultCustomControllerMaps, id);
				}
			}
		}
		customControllerLayouts.RemoveAt(index);
	}

	public bool ReorderCustomControllerLayout(int index, bool offsetDown, bool offsetNow)
	{
		return ListTools.OffsetAtIndex(customControllerLayouts, index, offsetDown, offsetNow);
	}

	public void DuplicateCustomControllerLayout(int index, bool duplicateMaps)
	{
		if (customControllerLayouts == null || index < 0 || index >= customControllerLayouts.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		InputLayout inputLayout = customControllerLayouts[index].Clone();
		inputLayout.rSjyzIcdJPGZvBbKrSRkLscLlslcA(GetNewCustomControllerLayoutId());
		inputLayout.wKokSbqSezldGNPZMbstdkGhHeHEA(StringTools.IterateName(inputLayout.name, -1, GetCustomControllerLayoutNames()));
		if (index == customControllerLayouts.Count - 1)
		{
			customControllerLayouts.Add(inputLayout);
		}
		else
		{
			customControllerLayouts.Insert(index + 1, inputLayout);
		}
		if (!duplicateMaps)
		{
			return;
		}
		int id = inputLayout.id;
		int id2 = customControllerLayouts[index].id;
		if (customControllerMaps == null)
		{
			return;
		}
		for (int num = customControllerMaps.Count - 1; num >= 0; num--)
		{
			if (customControllerMaps[num].layoutId == id2)
			{
				int num2 = DuplicateCustomControllerMap(num);
				if (num2 >= 0)
				{
					customControllerMaps[num2].layoutId = id;
				}
			}
		}
	}

	public int GetCustomControllerLayoutMapCount(int id)
	{
		if (customControllerLayouts == null)
		{
			return 0;
		}
		int num = 0;
		if (customControllerMaps != null)
		{
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].layoutId == id)
				{
					num++;
				}
			}
		}
		return num;
	}

	public int GetCustomControllerLayoutIndex(int id)
	{
		if (customControllerLayouts == null)
		{
			return 0;
		}
		for (int i = 0; i < customControllerLayouts.Count; i++)
		{
			if (customControllerLayouts[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public string[] GetCustomControllerLayoutNames()
	{
		if (customControllerLayouts == null)
		{
			return null;
		}
		string[] array = new string[customControllerLayouts.Count];
		for (int i = 0; i < customControllerLayouts.Count; i++)
		{
			array[i] = customControllerLayouts[i].name;
		}
		return array;
	}

	public int[] GetCustomControllerLayoutIds()
	{
		if (customControllerLayouts == null)
		{
			return null;
		}
		int[] array = new int[customControllerLayouts.Count];
		for (int i = 0; i < customControllerLayouts.Count; i++)
		{
			array[i] = customControllerLayouts[i].id;
		}
		return array;
	}

	public InputLayout GetCustomControllerLayout(int index)
	{
		if (customControllerLayouts == null || index < 0 || index >= customControllerLayouts.Count)
		{
			return null;
		}
		return customControllerLayouts[index];
	}

	public InputLayout GetCustomControllerLayout(string name)
	{
		if (customControllerLayouts == null)
		{
			return null;
		}
		int num = IndexOfCustomControllerLayout(name);
		if (num < 0)
		{
			return null;
		}
		return customControllerLayouts[num];
	}

	public InputLayout GetCustomControllerLayoutById(int id)
	{
		if (customControllerLayouts == null)
		{
			return null;
		}
		int num = IndexOfCustomControllerLayout(id);
		if (num < 0)
		{
			return null;
		}
		return customControllerLayouts[num];
	}

	public int GetCustomControllerLayoutId(string name)
	{
		if (customControllerLayouts == null)
		{
			return -1;
		}
		int num = IndexOfCustomControllerLayout(name);
		if (num < 0)
		{
			return -1;
		}
		return customControllerLayouts[num].id;
	}

	public int IndexOfCustomControllerLayout(int id)
	{
		if (customControllerLayouts == null)
		{
			return -1;
		}
		for (int i = 0; i < customControllerLayouts.Count; i++)
		{
			if (customControllerLayouts[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfCustomControllerLayout(string name)
	{
		if (name == null || name == string.Empty)
		{
			return -1;
		}
		if (customControllerLayouts == null)
		{
			return -1;
		}
		for (int i = 0; i < customControllerLayouts.Count; i++)
		{
			if (customControllerLayouts[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return i;
			}
		}
		return -1;
	}

	public string GetCustomControllerLayoutNameById(int id)
	{
		if (customControllerLayouts != null)
		{
			for (int i = 0; i < customControllerLayouts.Count; i++)
			{
				if (customControllerLayouts[i].id == id)
				{
					return customControllerLayouts[i].name;
				}
			}
		}
		return "Unknown";
	}

	public string GetLayoutNameById(ControllerType controllerType, int id)
	{
		return controllerType switch
		{
			ControllerType.Joystick => GetJoystickLayoutNameById(id), 
			ControllerType.Keyboard => GetKeyboardLayoutNameById(id), 
			ControllerType.Mouse => GetMouseLayoutNameById(id), 
			ControllerType.Custom => GetCustomControllerLayoutNameById(id), 
			_ => throw new NotImplementedException(), 
		};
	}

	internal ControllerMap AHLAGlhKqFwTnTYyhALfOyZwHEfMA(Controller P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return null;
		}
		return P_0.type switch
		{
			ControllerType.Joystick => HSFpDuCYQzabsUTxQTsPcGMueout((Joystick)P_0, P_1, P_2), 
			ControllerType.Keyboard => FindKeyboardMap_Game((Keyboard)P_0, P_1, P_2), 
			ControllerType.Mouse => FindMouseMap_Game((Mouse)P_0, P_1, P_2), 
			ControllerType.Custom => kICgImNyfVCgjcsYESaTqSPMJsfH(P_1, ((CustomController)P_0).sourceControllerId, P_2), 
			_ => throw new NotImplementedException(), 
		};
	}

	public ControllerMap_Editor GetJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
	{
		if (joystickMaps == null)
		{
			return null;
		}
		for (int i = 0; i < joystickMaps.Count; i++)
		{
			if (joystickMaps[i].categoryId == categoryId && joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
			{
				return joystickMaps[i];
			}
		}
		return null;
	}

	public ControllerMap_Editor GetJoystickMapById(int id, out int joystickMapIndex)
	{
		joystickMapIndex = -1;
		if (joystickMaps == null)
		{
			return null;
		}
		for (int i = 0; i < joystickMaps.Count; i++)
		{
			if (joystickMaps[i].id == id)
			{
				joystickMapIndex = i;
				return joystickMaps[i];
			}
		}
		return null;
	}

	public List<ControllerMap_Editor> GetJoystickMaps(Guid hardwareGuid)
	{
		if (joystickMaps == null)
		{
			return null;
		}
		List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
		for (int i = 0; i < joystickMaps.Count; i++)
		{
			if (StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
			{
				list.Add(joystickMaps[i]);
			}
		}
		return list;
	}

	public int GetJoystickMapId(int categoryId, Guid hardwareGuid, int layoutId)
	{
		if (joystickMaps == null)
		{
			return -1;
		}
		for (int i = 0; i < joystickMaps.Count; i++)
		{
			if (joystickMaps[i].categoryId == categoryId && joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
			{
				return joystickMaps[i].id;
			}
		}
		return -1;
	}

	public bool HasJoystickMap(int categoryId, Guid hardwareGuid, int layoutId)
	{
		if (joystickMaps == null)
		{
			return false;
		}
		for (int i = 0; i < joystickMaps.Count; i++)
		{
			if (joystickMaps[i].categoryId == categoryId && joystickMaps[i].layoutId == layoutId && StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasJoystickMap(Guid hardwareGuid)
	{
		if (joystickMaps == null)
		{
			return false;
		}
		for (int i = 0; i < joystickMaps.Count; i++)
		{
			if (StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasJoystickMapInCategory(Guid hardwareGuid, int categoryId)
	{
		if (joystickMaps == null)
		{
			return false;
		}
		for (int i = 0; i < joystickMaps.Count; i++)
		{
			if (StringTools.ToGuid(joystickMaps[i].hardwareGuidString) == hardwareGuid && joystickMaps[i].categoryId == categoryId)
			{
				return true;
			}
		}
		return false;
	}

	public bool CreateJoystickMap(int categoryId, Guid joystickOrTemplateGuid, int layoutId)
	{
		if (joystickMaps == null)
		{
			joystickMaps = new List<ControllerMap_Editor>();
		}
		ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
		controllerMap_Editor.id = GetNewJoystickMapId();
		controllerMap_Editor.categoryId = categoryId;
		controllerMap_Editor.layoutId = layoutId;
		controllerMap_Editor.hardwareGuidString = joystickOrTemplateGuid.ToString();
		joystickMaps.Add(controllerMap_Editor);
		return false;
	}

	public void DeleteJoystickMap(int id)
	{
		if (joystickMaps == null)
		{
			return;
		}
		for (int num = joystickMaps.Count - 1; num >= 0; num--)
		{
			if (joystickMaps[num].id == id)
			{
				joystickMaps.RemoveAt(num);
			}
		}
	}

	public int DuplicateJoystickMap(int index)
	{
		if (joystickMaps == null || index < 0 || index >= joystickMaps.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		ControllerMap_Editor controllerMap_Editor = joystickMaps[index].Clone();
		controllerMap_Editor.id = GetNewJoystickMapId();
		joystickMaps.Add(controllerMap_Editor);
		return joystickMaps.Count - 1;
	}

	internal JoystickMap fhefDsGnvGyvtedaGTaIvgntieZMA(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
	{
		return avLooOTGAljASCtyROTkScrznNGCA(new HardwareControllerMapIdentifier(P_0.guid, P_0.inputSource, P_0.actualInputPlatform, P_0.variantIndex), P_1, P_2);
	}

	internal JoystickMap HSFpDuCYQzabsUTxQTsPcGMueout(Joystick P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return null;
		}
		return avLooOTGAljASCtyROTkScrznNGCA(P_0.dkWkceWksRAnFAbRFfHBYhiZMOMbb(), P_1, P_2);
	}

	private JoystickMap avLooOTGAljASCtyROTkScrznNGCA(HardwareControllerMapIdentifier P_0, int P_1, int P_2)
	{
		Guid guid = P_0.guid;
		HardwareJoystickMap hardwareJoystickMap = ReInput.WXHBrnXMjLJvcVAQCoEWvVAxpHaq(guid);
		ControllerMap_Editor controllerMap_Editor = KacYIgHPfbFfyWvsQtbKBgTmEGqBA(P_1, guid, P_2, false);
		if (controllerMap_Editor != null)
		{
			JoystickMap joystickMap = controllerMap_Editor.dXdCsXJcVQoagscpBsEWDADsNAMB(containsActionDelegate, P_0, hardwareJoystickMap, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
			joystickMap.bktsnxYDWRAeyQQrbZcxEmWsBtuGA(guid, P_1, P_2);
			return joystickMap;
		}
		if (hardwareJoystickMap != null)
		{
			foreach (Guid templateGuid in hardwareJoystickMap.TemplateGuids)
			{
				if (templateGuid == Guid.Empty)
				{
					continue;
				}
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.CJxBKaYlWcxIRqJmrPDwZXxmWcfb(templateGuid);
				if (!(hardwareJoystickTemplateMap != null))
				{
					continue;
				}
				controllerMap_Editor = KacYIgHPfbFfyWvsQtbKBgTmEGqBA(P_1, templateGuid, P_2, false);
				if (controllerMap_Editor != null)
				{
					JoystickMap joystickMap = TeQwsIJgVtMHCVncQobXyuSCDazd(P_0, controllerMap_Editor, hardwareJoystickTemplateMap, hardwareJoystickMap, P_1, P_2);
					if (joystickMap != null)
					{
						joystickMap.bktsnxYDWRAeyQQrbZcxEmWsBtuGA(guid, P_1, P_2);
						return joystickMap;
					}
				}
			}
		}
		if (guid == Guid.Empty || 1 == 0)
		{
			controllerMap_Editor = KacYIgHPfbFfyWvsQtbKBgTmEGqBA(P_1, Guid.Empty, P_2, false);
			if (controllerMap_Editor != null)
			{
				JoystickMap joystickMap = controllerMap_Editor.dXdCsXJcVQoagscpBsEWDADsNAMB(containsActionDelegate, P_0, null, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
				joystickMap.bktsnxYDWRAeyQQrbZcxEmWsBtuGA(guid, P_1, P_2);
				if (joystickMap != null)
				{
					return joystickMap;
				}
			}
		}
		return JoystickMap.tOvGYsbvbFtBBpUsNFknIToZXDoSA(guid, P_1, P_2);
	}

	private ControllerMap_Editor KacYIgHPfbFfyWvsQtbKBgTmEGqBA(int P_0, Guid P_1, int P_2, bool P_3)
	{
		ControllerMap_Editor joystickMap = GetJoystickMap(P_0, P_1, P_2);
		if (joystickMap != null)
		{
			return joystickMap;
		}
		if (P_3)
		{
			joystickMap = vYgovZYjWWQSJahpyiqYaCUaJCZT(P_0, P_1, P_2);
			if (joystickMap != null)
			{
				return joystickMap;
			}
		}
		return null;
	}

	private ControllerMap_Editor vYgovZYjWWQSJahpyiqYaCUaJCZT(int P_0, Guid P_1, int P_2)
	{
		List<ControllerMap_Editor> list = GetJoystickMaps(P_1);
		if (list != null && list.Count > 0)
		{
			AbaBwDdBJkvypKxAWPwPuUzaEDBIA(list, joystickLayouts);
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].categoryId == P_0)
				{
					return list[i];
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].categoryId == 0)
				{
					return list[j];
				}
			}
		}
		return null;
	}

	private JoystickMap TeQwsIJgVtMHCVncQobXyuSCDazd(HardwareControllerMapIdentifier P_0, ControllerMap_Editor P_1, HardwareJoystickTemplateMap P_2, HardwareJoystickMap P_3, int P_4, int P_5)
	{
		if (P_2 == null)
		{
			return null;
		}
		ControllerMap_Editor controllerMap_Editor = P_1.Clone();
		if (!P_2.MuECowcPNWtqoAoOzADeAOsVUJYFb(controllerMap_Editor, P_3, P_0.guid, out var text))
		{
			Logger.LogError("Error remapping joystick template " + P_2.Guid.ToString() + " to joystick " + P_0.guid.ToString() + "\nReason: " + text);
			return null;
		}
		return controllerMap_Editor.dXdCsXJcVQoagscpBsEWDADsNAMB(containsActionDelegate, P_0, P_3, controllerMap_Editor.hardwareGuid == ReInput.defaultHardwareJoystickMapGuid);
	}

	private JoystickMap dUWBEfJwnbwbxorrfzlOHTPDeASEA(JoystickMap P_0, HardwareControllerMapIdentifier P_1)
	{
		if (P_0 == null)
		{
			return null;
		}
		HardwareJoystickMap hardwareJoystickMap = ReInput.WXHBrnXMjLJvcVAQCoEWvVAxpHaq(P_0.hardwareGuid);
		if (hardwareJoystickMap == null)
		{
			return null;
		}
		HardwareJoystickMap hardwareJoystickMap2 = ReInput.WXHBrnXMjLJvcVAQCoEWvVAxpHaq(Guid.Empty);
		if (hardwareJoystickMap2 == null)
		{
			return null;
		}
		hardwareJoystickMap.GetElementIdentifiersForControllerElements(P_1, isDefaultMap: false, out var buttons, out var axes);
		if (buttons == null && axes == null)
		{
			return null;
		}
		bool flag = false;
		List<int> list = new List<int>();
		foreach (ActionElementMap allMap in P_0.AllMaps)
		{
			ControllerElementIdentifier elementIdentifier = hardwareJoystickMap2.GetElementIdentifier(allMap._elementIdentifierId);
			if (elementIdentifier != null)
			{
				string name = elementIdentifier.get_name();
				if (!string.IsNullOrEmpty(name))
				{
					int num = 0;
					int num2 = name.IndexOf("button", 0, StringComparison.OrdinalIgnoreCase);
					if (num2 < 0)
					{
						num2 = name.IndexOf("axis", 0, StringComparison.OrdinalIgnoreCase);
						num = 1;
					}
					if (num2 >= 0 && (num != 0 || buttons != null) && (num != 1 || axes != null))
					{
						string text = Regex.Replace(name, "[^0-9]+", "");
						Logger.Log(text);
						if (int.TryParse(text, out var result))
						{
							if (num == 0)
							{
								if (result < buttons.Length)
								{
									allMap._elementIdentifierId = buttons[result];
									goto IL_011f;
								}
							}
							else if (result < axes.Length)
							{
								allMap._elementIdentifierId = axes[result];
								goto IL_011f;
							}
						}
					}
				}
			}
			list.Add(allMap.LQceMJAxYgRpolrwLwsLBxilJMmNA);
			continue;
			IL_011f:
			flag = true;
		}
		for (int i = 0; i < list.Count; i++)
		{
			P_0.DeleteElementMap(list[i]);
		}
		if (!flag)
		{
			return null;
		}
		return P_0;
	}

	public ControllerMap_Editor GetKeyboardMap(int categoryId, int layoutId)
	{
		if (keyboardMaps == null)
		{
			return null;
		}
		for (int i = 0; i < keyboardMaps.Count; i++)
		{
			if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId)
			{
				return keyboardMaps[i];
			}
		}
		return null;
	}

	public int GetKeyboardMapId(int categoryId, int layoutId)
	{
		if (keyboardMaps == null)
		{
			return -1;
		}
		for (int i = 0; i < keyboardMaps.Count; i++)
		{
			if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId)
			{
				return keyboardMaps[i].id;
			}
		}
		return -1;
	}

	public bool HasKeyboardMap(int categoryId, Guid hardwareGuid, int layoutId)
	{
		if (keyboardMaps == null)
		{
			return false;
		}
		for (int i = 0; i < keyboardMaps.Count; i++)
		{
			if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId && StringTools.ToGuid(keyboardMaps[i].hardwareGuidString) == hardwareGuid)
			{
				return true;
			}
		}
		return false;
	}

	public bool CreateKeyboardMap(int categoryId, int layoutId)
	{
		if (keyboardMaps == null)
		{
			keyboardMaps = new List<ControllerMap_Editor>();
		}
		ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
		controllerMap_Editor.id = GetNewKeyboardMapId();
		controllerMap_Editor.categoryId = categoryId;
		controllerMap_Editor.layoutId = layoutId;
		keyboardMaps.Add(controllerMap_Editor);
		return false;
	}

	public void DeleteKeyboardMap(int id)
	{
		if (keyboardMaps == null)
		{
			return;
		}
		for (int num = keyboardMaps.Count - 1; num >= 0; num--)
		{
			if (keyboardMaps[num].id == id)
			{
				keyboardMaps.RemoveAt(num);
			}
		}
	}

	public int DuplicateKeyboardMap(int index)
	{
		if (keyboardMaps == null || index < 0 || index >= keyboardMaps.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		ControllerMap_Editor controllerMap_Editor = keyboardMaps[index].Clone();
		controllerMap_Editor.id = GetNewKeyboardMapId();
		keyboardMaps.Add(controllerMap_Editor);
		return keyboardMaps.Count - 1;
	}

	public ControllerMap_Editor GetKeyboardMapById(int id, out int keyboardMapIndex)
	{
		keyboardMapIndex = -1;
		if (keyboardMaps == null)
		{
			return null;
		}
		for (int i = 0; i < keyboardMaps.Count; i++)
		{
			if (keyboardMaps[i].id == id)
			{
				keyboardMapIndex = i;
				return keyboardMaps[i];
			}
		}
		return null;
	}

	public KeyboardMap FindKeyboardMap_Game(Keyboard keyboard, int categoryId, int layoutId)
	{
		ControllerMap_Editor controllerMap_Editor = DZSoqgXGxLcjWzYPXAwaTaNJRfKK(keyboardMaps, keyboardLayouts, categoryId, layoutId, false);
		KeyboardMap keyboardMap;
		if (controllerMap_Editor != null)
		{
			keyboardMap = controllerMap_Editor.ojStMBVqVDmLqdIPBguvcbsiunEY(containsActionDelegate);
			keyboardMap.ESYFashxbLqQmYcvUGhXzDkzFxUB(keyboard.TlKwqXsIXURetJtusBGjLpbJxFcf, categoryId, layoutId);
		}
		else
		{
			keyboardMap = KeyboardMap.fRSVATzHkdCdhhcKeooAqWYqhxldA(keyboard.TlKwqXsIXURetJtusBGjLpbJxFcf, categoryId, layoutId);
		}
		return keyboardMap;
	}

	public bool HasKeyboardMapInCategory(int categoryId)
	{
		if (keyboardMaps == null)
		{
			return false;
		}
		for (int i = 0; i < keyboardMaps.Count; i++)
		{
			if (keyboardMaps[i].categoryId == categoryId)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasKeyboardMapInLayout(int categoryId, int layoutId)
	{
		if (keyboardMaps == null)
		{
			return false;
		}
		for (int i = 0; i < keyboardMaps.Count; i++)
		{
			if (keyboardMaps[i].categoryId == categoryId && keyboardMaps[i].layoutId == layoutId)
			{
				return true;
			}
		}
		return false;
	}

	public ControllerMap_Editor GetMouseMap(int categoryId, int layoutId)
	{
		if (mouseMaps == null)
		{
			return null;
		}
		for (int i = 0; i < mouseMaps.Count; i++)
		{
			if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId)
			{
				return mouseMaps[i];
			}
		}
		return null;
	}

	public int GetMouseMapId(int categoryId, int layoutId)
	{
		if (mouseMaps == null)
		{
			return -1;
		}
		for (int i = 0; i < mouseMaps.Count; i++)
		{
			if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId)
			{
				return mouseMaps[i].id;
			}
		}
		return -1;
	}

	public bool HasMouseMap(int categoryId, Guid hardwareGuid, int layoutId)
	{
		if (mouseMaps == null)
		{
			return false;
		}
		for (int i = 0; i < mouseMaps.Count; i++)
		{
			if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId && StringTools.ToGuid(mouseMaps[i].hardwareGuidString) == hardwareGuid)
			{
				return true;
			}
		}
		return false;
	}

	public bool CreateMouseMap(int categoryId, int layoutId)
	{
		if (mouseMaps == null)
		{
			mouseMaps = new List<ControllerMap_Editor>();
		}
		ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
		controllerMap_Editor.id = GetNewMouseMapId();
		controllerMap_Editor.categoryId = categoryId;
		controllerMap_Editor.layoutId = layoutId;
		mouseMaps.Add(controllerMap_Editor);
		return false;
	}

	public void DeleteMouseMap(int id)
	{
		if (mouseMaps == null)
		{
			return;
		}
		for (int num = mouseMaps.Count - 1; num >= 0; num--)
		{
			if (mouseMaps[num].id == id)
			{
				mouseMaps.RemoveAt(num);
			}
		}
	}

	public int DuplicateMouseMap(int index)
	{
		if (mouseMaps == null || index < 0 || index >= mouseMaps.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		ControllerMap_Editor controllerMap_Editor = mouseMaps[index].Clone();
		controllerMap_Editor.id = GetNewMouseMapId();
		mouseMaps.Add(controllerMap_Editor);
		return mouseMaps.Count - 1;
	}

	public ControllerMap_Editor GetMouseMapById(int id, out int mouseMapIndex)
	{
		mouseMapIndex = -1;
		if (mouseMaps == null)
		{
			return null;
		}
		for (int i = 0; i < mouseMaps.Count; i++)
		{
			if (mouseMaps[i].id == id)
			{
				mouseMapIndex = i;
				return mouseMaps[i];
			}
		}
		return null;
	}

	public MouseMap FindMouseMap_Game(Mouse mouse, int categoryId, int layoutId)
	{
		ControllerMap_Editor controllerMap_Editor = DZSoqgXGxLcjWzYPXAwaTaNJRfKK(mouseMaps, mouseLayouts, categoryId, layoutId, false);
		MouseMap mouseMap;
		if (controllerMap_Editor != null)
		{
			mouseMap = controllerMap_Editor.iidRkGtUpHnjrLTEetclJpfyHYrf(containsActionDelegate);
			mouseMap.bNgqelMfUxMejDlsKNTjpKzuyhGD(mouse.TlKwqXsIXURetJtusBGjLpbJxFcf, categoryId, layoutId);
		}
		else
		{
			mouseMap = MouseMap.dcKtXifClTEovMYRHgGHohQtjlSW(mouse.TlKwqXsIXURetJtusBGjLpbJxFcf, categoryId, layoutId);
		}
		return mouseMap;
	}

	public bool HasMouseMapInCategory(int categoryId)
	{
		if (mouseMaps == null)
		{
			return false;
		}
		for (int i = 0; i < mouseMaps.Count; i++)
		{
			if (mouseMaps[i].categoryId == categoryId)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasMouseMapInLayout(int categoryId, int layoutId)
	{
		if (mouseMaps == null)
		{
			return false;
		}
		for (int i = 0; i < mouseMaps.Count; i++)
		{
			if (mouseMaps[i].categoryId == categoryId && mouseMaps[i].layoutId == layoutId)
			{
				return true;
			}
		}
		return false;
	}

	public ControllerMap_Editor GetCustomControllerMap(int categoryId, int controllerUid, int layoutId)
	{
		if (customControllerMaps == null)
		{
			return null;
		}
		for (int i = 0; i < customControllerMaps.Count; i++)
		{
			if (customControllerMaps[i].categoryId == categoryId && customControllerMaps[i].layoutId == layoutId && customControllerMaps[i].customControllerUid == controllerUid)
			{
				return customControllerMaps[i];
			}
		}
		return null;
	}

	public ControllerMap_Editor GetCustomControllerMapById(int mapId, out int customControllerMapIndex)
	{
		customControllerMapIndex = -1;
		if (customControllerMaps == null)
		{
			return null;
		}
		for (int i = 0; i < customControllerMaps.Count; i++)
		{
			if (customControllerMaps[i].id == mapId)
			{
				customControllerMapIndex = i;
				return customControllerMaps[i];
			}
		}
		return null;
	}

	public List<ControllerMap_Editor> GetCustomControllerMaps(int controllerUid)
	{
		if (customControllerMaps == null)
		{
			return null;
		}
		List<ControllerMap_Editor> list = new List<ControllerMap_Editor>();
		for (int i = 0; i < customControllerMaps.Count; i++)
		{
			if (customControllerMaps[i].customControllerUid == controllerUid)
			{
				list.Add(customControllerMaps[i]);
			}
		}
		return list;
	}

	public int GetCustomControllerMapId(int categoryId, int controllerUid, int layoutId)
	{
		if (customControllerMaps == null)
		{
			return -1;
		}
		for (int i = 0; i < customControllerMaps.Count; i++)
		{
			if (customControllerMaps[i].categoryId == categoryId && customControllerMaps[i].layoutId == layoutId && customControllerMaps[i].customControllerUid == controllerUid)
			{
				return customControllerMaps[i].id;
			}
		}
		return -1;
	}

	public bool HasCustomControllerMap(int mapId, int categoryId, int layoutId)
	{
		if (customControllerMaps == null)
		{
			return false;
		}
		for (int i = 0; i < customControllerMaps.Count; i++)
		{
			if (customControllerMaps[i].categoryId == categoryId && customControllerMaps[i].layoutId == layoutId && customControllerMaps[i].id == mapId)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasCustomControllerMap(int mapId)
	{
		if (customControllerMaps == null)
		{
			return false;
		}
		for (int i = 0; i < customControllerMaps.Count; i++)
		{
			if (customControllerMaps[i].id == mapId)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasCustomControllerMapInCategory(int controllerUid, int categoryId)
	{
		if (customControllerMaps == null)
		{
			return false;
		}
		for (int i = 0; i < customControllerMaps.Count; i++)
		{
			if (customControllerMaps[i].customControllerUid == controllerUid && customControllerMaps[i].categoryId == categoryId)
			{
				return true;
			}
		}
		return false;
	}

	public bool CreateCustomControllerMap(int categoryId, int controllerUid, int layoutId)
	{
		if (customControllerMaps == null)
		{
			customControllerMaps = new List<ControllerMap_Editor>();
		}
		ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
		controllerMap_Editor.id = GetNewCustomControllerMapId();
		controllerMap_Editor.categoryId = categoryId;
		controllerMap_Editor.layoutId = layoutId;
		controllerMap_Editor.hardwareGuidString = string.Empty;
		controllerMap_Editor.customControllerUid = controllerUid;
		customControllerMaps.Add(controllerMap_Editor);
		return false;
	}

	public void DeleteCustomControllerMap(int mapId)
	{
		if (customControllerMaps == null)
		{
			return;
		}
		for (int num = customControllerMaps.Count - 1; num >= 0; num--)
		{
			if (customControllerMaps[num].id == mapId)
			{
				customControllerMaps.RemoveAt(num);
			}
		}
	}

	public int DuplicateCustomControllerMap(int index)
	{
		if (customControllerMaps == null || index < 0 || index >= customControllerMaps.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		ControllerMap_Editor controllerMap_Editor = customControllerMaps[index].Clone();
		controllerMap_Editor.id = GetNewCustomControllerMapId();
		customControllerMaps.Add(controllerMap_Editor);
		return customControllerMaps.Count - 1;
	}

	internal CustomControllerMap hbYDQRrxHXJmEhufYerMYJHTEtuB(Guid P_0, int P_1, int P_2)
	{
		return artTyFHAIgqdhBAFKXEStVntmXSb(GetCustomControllerByHardwareTypeGuid(P_0), P_1, P_2);
	}

	internal CustomControllerMap kICgImNyfVCgjcsYESaTqSPMJsfH(int P_0, int P_1, int P_2)
	{
		return artTyFHAIgqdhBAFKXEStVntmXSb(GetCustomControllerById(P_1), P_0, P_2);
	}

	private CustomControllerMap artTyFHAIgqdhBAFKXEStVntmXSb(CustomController_Editor P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return null;
		}
		int id = P_0.id;
		ControllerMap_Editor controllerMap_Editor = HsrYTHAOHKqgHkPiExBmgrynCwJI(P_1, id, P_2, false);
		if (controllerMap_Editor != null)
		{
			CustomControllerMap customControllerMap = controllerMap_Editor.aOaqGSaPBtWGufUgIaRukaldarHf(ContainsAction, P_0);
			customControllerMap.zWyIQqirVOqwnqfjxkYJQdXOgsEo(P_0.typeGuid, id, P_1, P_2);
			return customControllerMap;
		}
		CustomControllerMap customControllerMap2 = CustomControllerMap.eGZluOOwUVDgGSnbBOXNpfAeERvg(P_0.typeGuid, id, P_1, P_2);
		customControllerMap2.zWyIQqirVOqwnqfjxkYJQdXOgsEo(P_0.typeGuid, id, P_1, P_2);
		return customControllerMap2;
	}

	private ControllerMap_Editor HsrYTHAOHKqgHkPiExBmgrynCwJI(int P_0, int P_1, int P_2, bool P_3)
	{
		ControllerMap_Editor customControllerMap = GetCustomControllerMap(P_0, P_1, P_2);
		if (customControllerMap != null)
		{
			return customControllerMap;
		}
		if (P_3)
		{
			customControllerMap = rcEokDvsEEdTEjrVKfFljnneCVRxA(P_0, P_1, P_2);
			if (customControllerMap != null)
			{
				return customControllerMap;
			}
		}
		return null;
	}

	private ControllerMap_Editor rcEokDvsEEdTEjrVKfFljnneCVRxA(int P_0, int P_1, int P_2)
	{
		List<ControllerMap_Editor> list = GetCustomControllerMaps(P_1);
		if (list != null && list.Count > 0)
		{
			AbaBwDdBJkvypKxAWPwPuUzaEDBIA(list, customControllerLayouts);
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].categoryId == P_0)
				{
					return list[i];
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].categoryId == 0)
				{
					return list[j];
				}
			}
		}
		return null;
	}

	public void DeleteControllerMap(ControllerType controllerType, int id)
	{
		switch (controllerType)
		{
		case ControllerType.Joystick:
			DeleteJoystickMap(id);
			break;
		case ControllerType.Keyboard:
			DeleteKeyboardMap(id);
			break;
		case ControllerType.Mouse:
			DeleteMouseMap(id);
			break;
		case ControllerType.Custom:
			DeleteCustomControllerMap(id);
			break;
		default:
			throw new NotImplementedException();
		}
	}

	public ControllerMap_Editor GetControllerMapByIndex(ControllerType controllerType, int index)
	{
		switch (controllerType)
		{
		case ControllerType.Joystick:
			if (joystickMaps == null)
			{
				return null;
			}
			return joystickMaps[index];
		case ControllerType.Keyboard:
			if (keyboardMaps == null)
			{
				return null;
			}
			return keyboardMaps[index];
		case ControllerType.Mouse:
			if (mouseMaps == null)
			{
				return null;
			}
			return mouseMaps[index];
		case ControllerType.Custom:
			if (customControllerMaps == null)
			{
				return null;
			}
			return customControllerMaps[index];
		default:
			throw new NotImplementedException();
		}
	}

	public ControllerMap_Editor GetControllerMapById(ControllerType controllerType, int id, out int controllerMapIndex)
	{
		return controllerType switch
		{
			ControllerType.Joystick => GetJoystickMapById(id, out controllerMapIndex), 
			ControllerType.Keyboard => GetKeyboardMapById(id, out controllerMapIndex), 
			ControllerType.Mouse => GetMouseMapById(id, out controllerMapIndex), 
			ControllerType.Custom => GetCustomControllerMapById(id, out controllerMapIndex), 
			_ => throw new NotImplementedException(), 
		};
	}

	public int DuplicateControllerMap(ControllerType controllerType, int index)
	{
		return controllerType switch
		{
			ControllerType.Joystick => DuplicateJoystickMap(index), 
			ControllerType.Keyboard => DuplicateKeyboardMap(index), 
			ControllerType.Mouse => DuplicateMouseMap(index), 
			ControllerType.Custom => DuplicateCustomControllerMap(index), 
			_ => throw new NotImplementedException(), 
		};
	}

	internal ControllerTemplateMap jxnSWikLAkRaTLercDEykvizZMDw(Guid P_0, int P_1, int P_2)
	{
		return GetJoystickMap(P_1, P_0, P_2)?.pwIDIPctTpZFuDgJIdvdcYFQTNpi();
	}

	[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
	public void AddCustomController()
	{
		AddCustomController(Guid.NewGuid());
	}

	public void AddCustomController(Guid typeGuid)
	{
		if (customControllers == null)
		{
			customControllers = new List<CustomController_Editor>();
		}
		customControllers.Add(AVMQsMdNiDtMJmWmFRvZGbAjsepw(typeGuid));
	}

	[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
	public void InsertCustomController(int index)
	{
		InsertCustomController(index, Guid.NewGuid());
	}

	public void InsertCustomController(int index, Guid typeGuid)
	{
		if (customControllers == null)
		{
			customControllers = new List<CustomController_Editor>();
		}
		if (index < 0 || index >= customControllers.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		customControllers.Insert(index, AVMQsMdNiDtMJmWmFRvZGbAjsepw(typeGuid));
	}

	public void DeleteCustomController(int index)
	{
		if (customControllers == null || index < 0 || index >= customControllers.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		int id = customControllers[index].id;
		if (customControllerMaps != null)
		{
			for (int num = customControllerMaps.Count - 1; num >= 0; num--)
			{
				if (customControllerMaps[num].customControllerUid == id)
				{
					customControllerMaps.RemoveAt(num);
				}
			}
		}
		customControllers.RemoveAt(index);
	}

	public bool ReorderCustomController(int index, bool offsetDown, bool offsetNow)
	{
		return ListTools.OffsetAtIndex(customControllers, index, offsetDown, offsetNow);
	}

	[Obsolete("Does not validate type guid on creation to avoid clashes with other controllers. Use overload with typeGuid argument.", true)]
	public void DuplicateCustomController(int index, bool duplicateMaps)
	{
		DuplicateCustomController(index, duplicateMaps, Guid.NewGuid());
	}

	public void DuplicateCustomController(int index, bool duplicateMaps, Guid typeGuid)
	{
		if (customControllers == null || index < 0 || index >= customControllers.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		CustomController_Editor customController_Editor = customControllers[index].Clone();
		customController_Editor.id = GetNewCustomControllerId();
		customController_Editor.typeGuid = typeGuid;
		customController_Editor.name = StringTools.IterateName(customController_Editor.name, -1, GetCustomControllerNames());
		if (index == customControllers.Count - 1)
		{
			customControllers.Add(customController_Editor);
		}
		else
		{
			customControllers.Insert(index + 1, customController_Editor);
		}
		if (!duplicateMaps)
		{
			return;
		}
		int id = customController_Editor.id;
		int id2 = customControllers[index].id;
		if (customControllerMaps == null)
		{
			return;
		}
		for (int num = customControllerMaps.Count - 1; num >= 0; num--)
		{
			if (customControllerMaps[num].customControllerUid == id2)
			{
				int num2 = DuplicateCustomControllerMap(num);
				if (num2 >= 0)
				{
					customControllerMaps[num2].customControllerUid = id;
				}
			}
		}
	}

	public int GetCustomControllerMapCount(int controllerUid)
	{
		if (customControllers == null)
		{
			return 0;
		}
		int num = 0;
		if (customControllerMaps != null)
		{
			for (int i = 0; i < customControllerMaps.Count; i++)
			{
				if (customControllerMaps[i].customControllerUid == controllerUid)
				{
					num++;
				}
			}
		}
		return num;
	}

	public int GetCustomControllerIndex(int id)
	{
		if (customControllers == null)
		{
			return 0;
		}
		for (int i = 0; i < customControllers.Count; i++)
		{
			if (customControllers[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public string[] GetCustomControllerNames()
	{
		if (customControllers == null)
		{
			return null;
		}
		string[] array = new string[customControllers.Count];
		for (int i = 0; i < customControllers.Count; i++)
		{
			array[i] = customControllers[i].name;
		}
		return array;
	}

	public int[] GetCustomControllerIds()
	{
		if (customControllers == null)
		{
			return null;
		}
		int[] array = new int[customControllers.Count];
		for (int i = 0; i < customControllers.Count; i++)
		{
			array[i] = customControllers[i].id;
		}
		return array;
	}

	public Guid[] GetCustomControllerGuids()
	{
		if (customControllers == null)
		{
			return null;
		}
		Guid[] array = new Guid[customControllers.Count];
		for (int i = 0; i < customControllers.Count; i++)
		{
			array[i] = customControllers[i].typeGuid;
		}
		return array;
	}

	public CustomController_Editor GetCustomController(int index)
	{
		if (customControllers == null || index < 0 || index >= customControllers.Count)
		{
			return null;
		}
		return customControllers[index];
	}

	public CustomController_Editor GetCustomController(string name)
	{
		if (customControllers == null)
		{
			return null;
		}
		int num = IndexOfCustomController(name);
		if (num < 0)
		{
			return null;
		}
		return customControllers[num];
	}

	public CustomController_Editor GetCustomControllerById(int id)
	{
		if (customControllers == null)
		{
			return null;
		}
		int num = IndexOfCustomController(id);
		if (num < 0)
		{
			return null;
		}
		return customControllers[num];
	}

	public CustomController_Editor GetCustomControllerByHardwareTypeGuid(Guid hardwareTypeGuid)
	{
		if (customControllers == null)
		{
			return null;
		}
		int num = IndexOfCustomController(hardwareTypeGuid);
		if (num < 0)
		{
			return null;
		}
		return customControllers[num];
	}

	public int GetCustomControllerId(string name)
	{
		if (customControllers == null)
		{
			return -1;
		}
		int num = IndexOfCustomController(name);
		if (num < 0)
		{
			return -1;
		}
		return customControllers[num].id;
	}

	public int IndexOfCustomController(int id)
	{
		if (customControllers == null)
		{
			return -1;
		}
		for (int i = 0; i < customControllers.Count; i++)
		{
			if (customControllers[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfCustomController(string name)
	{
		if (name == null || name == string.Empty)
		{
			return -1;
		}
		if (customControllers == null)
		{
			return -1;
		}
		for (int i = 0; i < customControllers.Count; i++)
		{
			if (customControllers[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfCustomController(Guid hardwareTypeGuid)
	{
		if (customControllers == null)
		{
			return -1;
		}
		for (int i = 0; i < customControllers.Count; i++)
		{
			if (customControllers[i].typeGuid == hardwareTypeGuid)
			{
				return i;
			}
		}
		return -1;
	}

	public string GetCustomControllerNameById(int id)
	{
		if (customControllers != null)
		{
			for (int i = 0; i < customControllers.Count; i++)
			{
				if (customControllers[i].id == id)
				{
					return customControllers[i].name;
				}
			}
		}
		return "Unknown";
	}

	public void AddControllerMapLayoutManagerRuleSet()
	{
		controllerMapLayoutManagerRuleSets.Add(jBgxohwiYDoOpuVeqmBGrCkOZSEf());
	}

	public void InsertControllerMapLayoutManagerRuleSet(int index)
	{
		if (index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		controllerMapLayoutManagerRuleSets.Insert(index, jBgxohwiYDoOpuVeqmBGrCkOZSEf());
	}

	public void DeleteControllerMapLayoutManagerRuleSet(int index)
	{
		if (controllerMapLayoutManagerRuleSets == null || index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		int id = controllerMapLayoutManagerRuleSets[index].id;
		if (players != null)
		{
			for (int i = 0; i < players.Count; i++)
			{
				Player_Editor player_Editor = players[i];
				if (player_Editor == null)
				{
					continue;
				}
				List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
				if (ruleSets == null)
				{
					continue;
				}
				for (int num = ruleSets.Count - 1; num >= 0; num--)
				{
					if (ruleSets[num] != null && ruleSets[num].id == id)
					{
						ruleSets.RemoveAt(num);
					}
				}
			}
		}
		controllerMapLayoutManagerRuleSets.RemoveAt(index);
	}

	public bool ReorderControllerMapLayoutManagerRuleSet(int index, bool offsetDown, bool offsetNow)
	{
		return ListTools.OffsetAtIndex(controllerMapLayoutManagerRuleSets, index, offsetDown, offsetNow);
	}

	public void DuplicateControllerMapLayoutManagerRuleSet(int index)
	{
		if (controllerMapLayoutManagerRuleSets == null || index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		ControllerMapLayoutManager_RuleSet_Editor controllerMapLayoutManager_RuleSet_Editor = controllerMapLayoutManagerRuleSets[index].Clone();
		controllerMapLayoutManager_RuleSet_Editor.id = GetNewControllerMapLayoutManagerRuleSetId();
		controllerMapLayoutManager_RuleSet_Editor.name = StringTools.IterateName(controllerMapLayoutManager_RuleSet_Editor.name, -1, GetControllerMapLayoutManagerRuleSetNames());
		if (index == controllerMapLayoutManagerRuleSets.Count - 1)
		{
			controllerMapLayoutManagerRuleSets.Add(controllerMapLayoutManager_RuleSet_Editor);
		}
		else
		{
			controllerMapLayoutManagerRuleSets.Insert(index + 1, controllerMapLayoutManager_RuleSet_Editor);
		}
	}

	public int GetControllerMapLayoutManagerRuleSetUsedCount(int id)
	{
		if (controllerMapLayoutManagerRuleSets == null)
		{
			return 0;
		}
		int num = 0;
		if (players != null)
		{
			for (int i = 0; i < players.Count; i++)
			{
				Player_Editor player_Editor = players[i];
				if (player_Editor == null)
				{
					continue;
				}
				List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapLayoutManagerSettings.ruleSets;
				if (ruleSets == null)
				{
					continue;
				}
				for (int num2 = ruleSets.Count - 1; num2 >= 0; num2--)
				{
					if (ruleSets[num2] != null && ruleSets[num2].id == id)
					{
						num++;
					}
				}
			}
		}
		return num;
	}

	public int GetControllerMapLayoutManagerRuleSetIndex(int id)
	{
		if (controllerMapLayoutManagerRuleSets == null)
		{
			return 0;
		}
		for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
		{
			if (controllerMapLayoutManagerRuleSets[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public string[] GetControllerMapLayoutManagerRuleSetNames()
	{
		if (controllerMapLayoutManagerRuleSets == null)
		{
			return null;
		}
		string[] array = new string[controllerMapLayoutManagerRuleSets.Count];
		for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
		{
			array[i] = controllerMapLayoutManagerRuleSets[i].name;
		}
		return array;
	}

	public int[] GetControllerMapLayoutManagerRuleSetIds()
	{
		if (controllerMapLayoutManagerRuleSets == null)
		{
			return null;
		}
		int[] array = new int[controllerMapLayoutManagerRuleSets.Count];
		for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
		{
			array[i] = controllerMapLayoutManagerRuleSets[i].id;
		}
		return array;
	}

	public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(int index)
	{
		if (controllerMapLayoutManagerRuleSets == null || index < 0 || index >= controllerMapLayoutManagerRuleSets.Count)
		{
			return null;
		}
		return controllerMapLayoutManagerRuleSets[index];
	}

	public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSet(string name)
	{
		if (controllerMapLayoutManagerRuleSets == null)
		{
			return null;
		}
		int num = IndexOfControllerMapLayoutManagerRuleSet(name);
		if (num < 0)
		{
			return null;
		}
		return controllerMapLayoutManagerRuleSets[num];
	}

	public ControllerMapLayoutManager_RuleSet_Editor GetControllerMapLayoutManagerRuleSetById(int id)
	{
		if (controllerMapLayoutManagerRuleSets == null)
		{
			return null;
		}
		int num = IndexOfControllerMapLayoutManagerRuleSet(id);
		if (num < 0)
		{
			return null;
		}
		return controllerMapLayoutManagerRuleSets[num];
	}

	public int GetControllerMapLayoutManagerRuleSetId(string name)
	{
		if (controllerMapLayoutManagerRuleSets == null)
		{
			return -1;
		}
		int num = IndexOfControllerMapLayoutManagerRuleSet(name);
		if (num < 0)
		{
			return -1;
		}
		return controllerMapLayoutManagerRuleSets[num].id;
	}

	public int IndexOfControllerMapLayoutManagerRuleSet(int id)
	{
		if (controllerMapLayoutManagerRuleSets == null)
		{
			return -1;
		}
		for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
		{
			if (controllerMapLayoutManagerRuleSets[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfControllerMapLayoutManagerRuleSet(string name)
	{
		if (name == null || name == string.Empty)
		{
			return -1;
		}
		if (controllerMapLayoutManagerRuleSets == null)
		{
			return -1;
		}
		for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
		{
			if (controllerMapLayoutManagerRuleSets[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return i;
			}
		}
		return -1;
	}

	public string GetControllerMapLayoutManagerRuleSetNameById(int id)
	{
		if (controllerMapLayoutManagerRuleSets != null)
		{
			for (int i = 0; i < controllerMapLayoutManagerRuleSets.Count; i++)
			{
				if (controllerMapLayoutManagerRuleSets[i].id == id)
				{
					return controllerMapLayoutManagerRuleSets[i].name;
				}
			}
		}
		return "Unknown";
	}

	public int GetControllerMapLayoutManagerRuleSetCount()
	{
		if (controllerMapLayoutManagerRuleSets == null)
		{
			return 0;
		}
		return controllerMapLayoutManagerRuleSets.Count;
	}

	public void AddControllerMapEnablerRuleSet()
	{
		controllerMapEnablerRuleSets.Add(acAAEjjjotckOLLnEQROdMJQYFSu());
	}

	public void InsertControllerMapEnablerRuleSet(int index)
	{
		if (index < 0 || index >= controllerMapEnablerRuleSets.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		controllerMapEnablerRuleSets.Insert(index, acAAEjjjotckOLLnEQROdMJQYFSu());
	}

	public void DeleteControllerMapEnablerRuleSet(int index)
	{
		if (controllerMapEnablerRuleSets == null || index < 0 || index >= controllerMapEnablerRuleSets.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		int id = controllerMapEnablerRuleSets[index].id;
		if (players != null)
		{
			for (int i = 0; i < players.Count; i++)
			{
				Player_Editor player_Editor = players[i];
				if (player_Editor == null)
				{
					continue;
				}
				List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
				if (ruleSets == null)
				{
					continue;
				}
				for (int num = ruleSets.Count - 1; num >= 0; num--)
				{
					if (ruleSets[num] != null && ruleSets[num].id == id)
					{
						ruleSets.RemoveAt(num);
					}
				}
			}
		}
		controllerMapEnablerRuleSets.RemoveAt(index);
	}

	public bool ReorderControllerMapEnablerRuleSet(int index, bool offsetDown, bool offsetNow)
	{
		return ListTools.OffsetAtIndex(controllerMapEnablerRuleSets, index, offsetDown, offsetNow);
	}

	public void DuplicateControllerMapEnablerRuleSet(int index)
	{
		if (controllerMapEnablerRuleSets == null || index < 0 || index >= controllerMapEnablerRuleSets.Count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		ControllerMapEnabler_RuleSet_Editor controllerMapEnabler_RuleSet_Editor = controllerMapEnablerRuleSets[index].Clone();
		controllerMapEnabler_RuleSet_Editor.id = GetNewControllerMapEnablerRuleSetId();
		controllerMapEnabler_RuleSet_Editor.name = StringTools.IterateName(controllerMapEnabler_RuleSet_Editor.name, -1, GetControllerMapEnablerRuleSetNames());
		if (index == controllerMapEnablerRuleSets.Count - 1)
		{
			controllerMapEnablerRuleSets.Add(controllerMapEnabler_RuleSet_Editor);
		}
		else
		{
			controllerMapEnablerRuleSets.Insert(index + 1, controllerMapEnabler_RuleSet_Editor);
		}
	}

	public int GetControllerMapEnablerRuleSetUsedCount(int id)
	{
		if (controllerMapEnablerRuleSets == null)
		{
			return 0;
		}
		int num = 0;
		if (players != null)
		{
			for (int i = 0; i < players.Count; i++)
			{
				Player_Editor player_Editor = players[i];
				if (player_Editor == null)
				{
					continue;
				}
				List<Player_Editor.RuleSetMapping> ruleSets = player_Editor.controllerMapEnablerSettings.ruleSets;
				if (ruleSets == null)
				{
					continue;
				}
				for (int num2 = ruleSets.Count - 1; num2 >= 0; num2--)
				{
					if (ruleSets[num2] != null && ruleSets[num2].id == id)
					{
						num++;
					}
				}
			}
		}
		return num;
	}

	public int GetControllerMapEnablerRuleSetIndex(int id)
	{
		if (controllerMapEnablerRuleSets == null)
		{
			return 0;
		}
		for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
		{
			if (controllerMapEnablerRuleSets[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public string[] GetControllerMapEnablerRuleSetNames()
	{
		if (controllerMapEnablerRuleSets == null)
		{
			return null;
		}
		string[] array = new string[controllerMapEnablerRuleSets.Count];
		for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
		{
			array[i] = controllerMapEnablerRuleSets[i].name;
		}
		return array;
	}

	public int[] GetControllerMapEnablerRuleSetIds()
	{
		if (controllerMapEnablerRuleSets == null)
		{
			return null;
		}
		int[] array = new int[controllerMapEnablerRuleSets.Count];
		for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
		{
			array[i] = controllerMapEnablerRuleSets[i].id;
		}
		return array;
	}

	public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(int index)
	{
		if (controllerMapEnablerRuleSets == null || index < 0 || index >= controllerMapEnablerRuleSets.Count)
		{
			return null;
		}
		return controllerMapEnablerRuleSets[index];
	}

	public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSet(string name)
	{
		if (controllerMapEnablerRuleSets == null)
		{
			return null;
		}
		int num = IndexOfControllerMapEnablerRuleSet(name);
		if (num < 0)
		{
			return null;
		}
		return controllerMapEnablerRuleSets[num];
	}

	public ControllerMapEnabler_RuleSet_Editor GetControllerMapEnablerRuleSetById(int id)
	{
		if (controllerMapEnablerRuleSets == null)
		{
			return null;
		}
		int num = IndexOfControllerMapEnablerRuleSet(id);
		if (num < 0)
		{
			return null;
		}
		return controllerMapEnablerRuleSets[num];
	}

	public int GetControllerMapEnablerRuleSetId(string name)
	{
		if (controllerMapEnablerRuleSets == null)
		{
			return -1;
		}
		int num = IndexOfControllerMapEnablerRuleSet(name);
		if (num < 0)
		{
			return -1;
		}
		return controllerMapEnablerRuleSets[num].id;
	}

	public int IndexOfControllerMapEnablerRuleSet(int id)
	{
		if (controllerMapEnablerRuleSets == null)
		{
			return -1;
		}
		for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
		{
			if (controllerMapEnablerRuleSets[i].id == id)
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfControllerMapEnablerRuleSet(string name)
	{
		if (name == null || name == string.Empty)
		{
			return -1;
		}
		if (controllerMapEnablerRuleSets == null)
		{
			return -1;
		}
		for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
		{
			if (controllerMapEnablerRuleSets[i].name.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return i;
			}
		}
		return -1;
	}

	public string GetControllerMapEnablerRuleSetNameById(int id)
	{
		if (controllerMapEnablerRuleSets != null)
		{
			for (int i = 0; i < controllerMapEnablerRuleSets.Count; i++)
			{
				if (controllerMapEnablerRuleSets[i].id == id)
				{
					return controllerMapEnablerRuleSets[i].name;
				}
			}
		}
		return "Unknown";
	}

	public int GetControllerMapEnablerRuleSetCount()
	{
		if (controllerMapEnablerRuleSets == null)
		{
			return 0;
		}
		return controllerMapEnablerRuleSets.Count;
	}

	public int GetNewPlayerId()
	{
		int result = playerIdCounter;
		playerIdCounter++;
		return result;
	}

	public int GetNewActionId()
	{
		int result = actionIdCounter;
		actionIdCounter++;
		return result;
	}

	public int GetNewActionCategoryId()
	{
		int result = actionCategoryIdCounter;
		actionCategoryIdCounter++;
		return result;
	}

	public int GetNewInputBehaviorId()
	{
		int result = inputBehaviorIdCounter;
		inputBehaviorIdCounter++;
		return result;
	}

	public int GetNewMapCategoryId()
	{
		int result = mapCategoryIdCounter;
		mapCategoryIdCounter++;
		return result;
	}

	public int GetNewJoystickLayoutId()
	{
		int result = joystickLayoutIdCounter;
		joystickLayoutIdCounter++;
		return result;
	}

	public int GetNewKeyboardLayoutId()
	{
		int result = keyboardLayoutIdCounter;
		keyboardLayoutIdCounter++;
		return result;
	}

	public int GetNewMouseLayoutId()
	{
		int result = mouseLayoutIdCounter;
		mouseLayoutIdCounter++;
		return result;
	}

	public int GetNewCustomControllerLayoutId()
	{
		int result = customControllerLayoutIdCounter;
		customControllerLayoutIdCounter++;
		return result;
	}

	public int GetNewJoystickMapId()
	{
		int result = joystickMapIdCounter;
		joystickMapIdCounter++;
		return result;
	}

	public int GetNewKeyboardMapId()
	{
		int result = keyboardMapIdCounter;
		keyboardMapIdCounter++;
		return result;
	}

	public int GetNewMouseMapId()
	{
		int result = mouseMapIdCounter;
		mouseMapIdCounter++;
		return result;
	}

	public int GetNewCustomControllerMapId()
	{
		int result = customControllerMapIdCounter;
		customControllerMapIdCounter++;
		return result;
	}

	public int GetNewCustomControllerId()
	{
		int result = customControllerIdCounter;
		customControllerIdCounter++;
		return result;
	}

	public int GetNewControllerMapLayoutManagerRuleSetId()
	{
		int result = controllerMapLayoutManagerSetIdCounter;
		controllerMapLayoutManagerSetIdCounter++;
		return result;
	}

	public int GetNewControllerMapEnablerRuleSetId()
	{
		int result = controllerMapEnablerSetIdCounter;
		controllerMapEnablerSetIdCounter++;
		return result;
	}

	private Player_Editor UBthGESgJCfdkyhZGCJQaGjTNmSGb()
	{
		Player_Editor player_Editor = new Player_Editor();
		player_Editor.mDREmaITLKWbHjKcJKtjszMGmZFlA(GetNewPlayerId());
		player_Editor.KyoGLIDYzrqHhPbWKTQjJwvLHIfw(StringTools.IterateName("Player", -1, GetPlayerNames()));
		player_Editor.wpfHNsmTODGKuEkbnOqYCNhljisV(player_Editor.name);
		player_Editor.PsAlYeOGSrojqBSvsNXEjuyrlqsR(true);
		if (players.Count == 1)
		{
			player_Editor.xyrRTPjNRpcemaiPeUDbFOFavfeP(true);
		}
		player_Editor.qhLnGAZPqufldeAscoVpFRexCyyR(true);
		player_Editor.controllerMapEnablerSettings = new Player_Editor.ControllerMapEnablerSettings();
		player_Editor.controllerMapLayoutManagerSettings = new Player_Editor.ControllerMapLayoutManagerSettings();
		return player_Editor;
	}

	private InputAction daOZOoAHaaJdXDHVNpiaWeXZojkYA()
	{
		InputAction inputAction = new InputAction();
		inputAction.AMAIZfInlMSYYmanVNuUfsJDsYjb(GetNewActionId());
		inputAction.WUHHsrTAElkhpWiNqDYhmjbqOeWL(StringTools.IterateName("Action", -1, GetActionNames()));
		inputAction.vOyOrTASWGfRrTkMPhSeLaBoARuhA(inputAction.name);
		inputAction.UhsLadNucvFrEnUMjLPcGIOTrRGJ(InputActionType.Button);
		inputAction.RJRENmwlYMGUXgUeHdFiLvedFNsJ(true);
		inputAction.PiUFsDNerYNrnOuphGYyaUCZBwQk(0);
		return inputAction;
	}

	private InputActionCategory eFgPJrKtJkzWpefNzCQFJrbpZxHw()
	{
		InputActionCategory inputActionCategory = new InputActionCategory();
		inputActionCategory.DxydIQkdpBgpQxBGxBhzaNsKYkjEb(GetNewActionCategoryId());
		inputActionCategory.tlJsFqUBamvrjluRYovKRvNFnglg(StringTools.IterateName("Category", -1, GetActionCategoryNames()));
		inputActionCategory.IXEJvKwUiodJWmBLJURXjxxHugcc(inputActionCategory.name);
		inputActionCategory.fyYgHTFPILsnEEGrEWkaFDYZrAMuA(true);
		return inputActionCategory;
	}

	private InputBehavior DNvNCqzPZhEJAJVplidTvfMyvnUc()
	{
		InputBehavior inputBehavior = new InputBehavior();
		inputBehavior.PvvzgovLhWQeTzjOCClzdPKHgnSCA(GetNewInputBehaviorId());
		inputBehavior.JxBAaVKDQgAcHfqQAvJgzWkIqfPfB(StringTools.IterateName("Behavior", -1, GetInputBehaviorNames()));
		inputBehavior.digitalAxisSimulation = true;
		inputBehavior.digitalAxisSnap = true;
		inputBehavior.digitalAxisInstantReverse = false;
		inputBehavior.digitalAxisGravity = 3f;
		inputBehavior.digitalAxisSensitivity = 3f;
		inputBehavior.mouseXYAxisMode = MouseXYAxisMode.MouseAxis;
		inputBehavior.mouseXYAxisSensitivity = 1f;
		inputBehavior.mouseOtherAxisMode = MouseOtherAxisMode.MouseAxis;
		inputBehavior.mouseOtherAxisSensitivity = 1f;
		inputBehavior.buttonDoublePressSpeed = 0.3f;
		inputBehavior.buttonShortPressTime = 0.25f;
		inputBehavior.buttonShortPressExpiresIn = 0f;
		inputBehavior.buttonLongPressTime = 1f;
		inputBehavior.buttonLongPressExpiresIn = 0f;
		inputBehavior.buttonDeadZone = 0.5f;
		inputBehavior.buttonDownBuffer = 0f;
		return inputBehavior;
	}

	private InputMapCategory SslxqjATSPRJDoPTWHJQtYMalKoo()
	{
		InputMapCategory inputMapCategory = new InputMapCategory();
		inputMapCategory.DxydIQkdpBgpQxBGxBhzaNsKYkjEb(GetNewMapCategoryId());
		inputMapCategory.tlJsFqUBamvrjluRYovKRvNFnglg(StringTools.IterateName("Category", -1, GetMapCategoryNames()));
		inputMapCategory.IXEJvKwUiodJWmBLJURXjxxHugcc(inputMapCategory.name);
		inputMapCategory.fyYgHTFPILsnEEGrEWkaFDYZrAMuA(true);
		inputMapCategory.jfsPfvRGLdBSucaZPLwuaeVJjtNHc(true);
		return inputMapCategory;
	}

	private InputLayout usSIMfnQpzqZmyDtmKsiJhrZIBBi()
	{
		InputLayout inputLayout = new InputLayout();
		inputLayout.rSjyzIcdJPGZvBbKrSRkLscLlslcA(GetNewJoystickLayoutId());
		inputLayout.wKokSbqSezldGNPZMbstdkGhHeHEA(StringTools.IterateName("Layout", -1, GetJoystickLayoutNames()));
		inputLayout.UazEMKfRCUbxttLHsJBoJXREqvTlA(inputLayout.name);
		return inputLayout;
	}

	private InputLayout ljIQuStGschkKnfBjGdilbgIZcyp()
	{
		InputLayout inputLayout = new InputLayout();
		inputLayout.rSjyzIcdJPGZvBbKrSRkLscLlslcA(GetNewKeyboardLayoutId());
		inputLayout.wKokSbqSezldGNPZMbstdkGhHeHEA(StringTools.IterateName("Layout", -1, GetKeyboardLayoutNames()));
		inputLayout.UazEMKfRCUbxttLHsJBoJXREqvTlA(inputLayout.name);
		return inputLayout;
	}

	private InputLayout ZGALencWQiirUmeHKmzIdSLRajtd()
	{
		InputLayout inputLayout = new InputLayout();
		inputLayout.rSjyzIcdJPGZvBbKrSRkLscLlslcA(GetNewMouseLayoutId());
		inputLayout.wKokSbqSezldGNPZMbstdkGhHeHEA(StringTools.IterateName("Layout", -1, GetMouseLayoutNames()));
		inputLayout.UazEMKfRCUbxttLHsJBoJXREqvTlA(inputLayout.name);
		return inputLayout;
	}

	private InputLayout DWHZcCTvHbLXKUNsGTsRfOJpVWYg()
	{
		InputLayout inputLayout = new InputLayout();
		inputLayout.rSjyzIcdJPGZvBbKrSRkLscLlslcA(GetNewCustomControllerLayoutId());
		inputLayout.wKokSbqSezldGNPZMbstdkGhHeHEA(StringTools.IterateName("Layout", -1, GetCustomControllerLayoutNames()));
		inputLayout.UazEMKfRCUbxttLHsJBoJXREqvTlA(inputLayout.name);
		return inputLayout;
	}

	private CustomController_Editor AVMQsMdNiDtMJmWmFRvZGbAjsepw(Guid P_0)
	{
		CustomController_Editor obj = new CustomController_Editor
		{
			id = GetNewCustomControllerId(),
			typeGuid = P_0,
			name = StringTools.IterateName("CustomController", -1, GetCustomControllerNames())
		};
		obj.descriptiveName = obj.name;
		return obj;
	}

	private ControllerMapLayoutManager_RuleSet_Editor jBgxohwiYDoOpuVeqmBGrCkOZSEf()
	{
		return new ControllerMapLayoutManager_RuleSet_Editor
		{
			id = GetNewControllerMapLayoutManagerRuleSetId(),
			name = StringTools.IterateName("RuleSet", -1, GetControllerMapLayoutManagerRuleSetNames())
		};
	}

	private ControllerMapEnabler_RuleSet_Editor acAAEjjjotckOLLnEQROdMJQYFSu()
	{
		return new ControllerMapEnabler_RuleSet_Editor
		{
			id = GetNewControllerMapEnablerRuleSetId(),
			name = StringTools.IterateName("RuleSet", -1, GetControllerMapEnablerRuleSetNames())
		};
	}

	private ControllerMap_Editor WnqpbImjwWgbNWoMwiafGAuVYTbOA(List<ControllerMap_Editor> P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return null;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i].categoryId == P_1 && P_0[i].layoutId == P_2)
			{
				return P_0[i];
			}
		}
		return null;
	}

	private ControllerMap_Editor DZSoqgXGxLcjWzYPXAwaTaNJRfKK(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3, bool P_4)
	{
		ControllerMap_Editor controllerMap_Editor = WnqpbImjwWgbNWoMwiafGAuVYTbOA(P_0, P_2, P_3);
		if (controllerMap_Editor != null)
		{
			return controllerMap_Editor;
		}
		if (P_4)
		{
			controllerMap_Editor = qVgBClqFPJVNjGCUPbXOkzUErGyI(P_0, P_1, P_2, P_3);
			if (controllerMap_Editor != null)
			{
				return controllerMap_Editor;
			}
		}
		return null;
	}

	private ControllerMap_Editor qVgBClqFPJVNjGCUPbXOkzUErGyI(List<ControllerMap_Editor> P_0, List<InputLayout> P_1, int P_2, int P_3)
	{
		List<ControllerMap_Editor> list = ListTools.ShallowCopy(P_0);
		if (list != null && list.Count > 0)
		{
			AbaBwDdBJkvypKxAWPwPuUzaEDBIA(list, P_1);
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].categoryId == P_2)
				{
					return list[i];
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].categoryId == 0)
				{
					return list[j];
				}
			}
		}
		return null;
	}

	private void AbaBwDdBJkvypKxAWPwPuUzaEDBIA(List<ControllerMap_Editor> P_0, List<InputLayout> P_1)
	{
		YhgNrauaXmCGNqXnFepEFVRrWkECA yhgNrauaXmCGNqXnFepEFVRrWkECA = new YhgNrauaXmCGNqXnFepEFVRrWkECA();
		yhgNrauaXmCGNqXnFepEFVRrWkECA.NjdsbOWzivSEWESihjaOVzbAylbk = P_1;
		if (P_0 != null && yhgNrauaXmCGNqXnFepEFVRrWkECA.NjdsbOWzivSEWESihjaOVzbAylbk != null)
		{
			P_0.Sort(yhgNrauaXmCGNqXnFepEFVRrWkECA.lWPoCddtMzYCEOvxnjQvIMDYwerv);
		}
	}

	internal void ELkrLLMwoOMdWIxKlaIpbhKkaISe()
	{
		if (YKCplrMIOZgGhFWILDBupAzArJxM)
		{
			return;
		}
		SRozGzlwCSqTEOsLNzRVLjkjMPqG = new List<InputAction>(actions.Count);
		for (int i = 0; i < actions.Count; i++)
		{
			if (actions[i] == null)
			{
				SRozGzlwCSqTEOsLNzRVLjkjMPqG.Add(null);
			}
			SRozGzlwCSqTEOsLNzRVLjkjMPqG.Add(new InputAction(actions[i]));
		}
		EKyQIHiwQPHpJPmlbXKVdAZCZjuc(new ReadOnlyCollection<Player_Editor>(players));
		VFkOveEUXOueRgbprcxkBjlivXlC(new ReadOnlyCollection<InputAction>(SRozGzlwCSqTEOsLNzRVLjkjMPqG));
		List<InputCategory> list = new List<InputCategory>((actionCategories != null) ? actionCategories.Count : 0);
		for (int j = 0; j < actionCategories.Count; j++)
		{
			list.Add(actionCategories[j]);
		}
		qtTYNDuOrZNthkDNfIeUPfuJEqziA(new ReadOnlyCollection<InputCategory>(list));
		dVZGiVgUmAsPewNOpxsEnHmNjYkH(new ReadOnlyCollection<InputBehavior>(inputBehaviors));
		EaZhgXibGTGeVJfxaQDIjrDIbFzQA(new ReadOnlyCollection<InputMapCategory>(mapCategories));
		SMWlOoFUEoQBQVFpWZLqIDtbXBFp(new ReadOnlyCollection<InputLayout>(joystickLayouts));
		ZcxAEyxdisfIHAEdvVetFhUAHncB(new ReadOnlyCollection<InputLayout>(keyboardLayouts));
		RvxCqLRATchwTvAdgVWFhDvJfQCi(new ReadOnlyCollection<InputLayout>(mouseLayouts));
		uZVZEexVKHGqUHiPhcNUJLjICLNdb(new ReadOnlyCollection<InputLayout>(customControllerLayouts));
		HxadMGAouWsQPOpyWZXunJXDpTQsA(new ReadOnlyCollection<ControllerMap_Editor>(joystickMaps));
		YchFWjxxkFWwYOnWxpUlqRGlKOv(new ReadOnlyCollection<ControllerMap_Editor>(keyboardMaps));
		epswncHRNkVpwRxquqtTbECsZKhj(new ReadOnlyCollection<ControllerMap_Editor>(mouseMaps));
		hfwTpCxJnUvmgNPzXLzUlpNupEoE(new ReadOnlyCollection<ControllerMap_Editor>(customControllerMaps));
		thesMBZEMxbesCRGtBjcKOBCvPEbA(new ReadOnlyCollection<ControllerMapLayoutManager_RuleSet_Editor>(controllerMapLayoutManagerRuleSets));
		SJSFMVAOLsuyGOKWZVmaiFiPWeMt(new ReadOnlyCollection<ControllerMapEnabler_RuleSet_Editor>(controllerMapEnablerRuleSets));
		if (mapCategories != null)
		{
			for (int k = 0; k < mapCategories.Count; k++)
			{
				if (mapCategories[k] != null)
				{
					mapCategories[k].wRAchoXuDDGYINIYyZGdMXMtFbQA();
				}
			}
		}
		if (actionCategories != null)
		{
			for (int l = 0; l < actionCategories.Count; l++)
			{
				if (actionCategories[l] != null)
				{
					actionCategories[l].wRAchoXuDDGYINIYyZGdMXMtFbQA();
				}
			}
		}
		if (joystickLayouts != null)
		{
			for (int m = 0; m < joystickLayouts.Count; m++)
			{
				if (joystickLayouts[m] != null)
				{
					joystickLayouts[m].QmnafSCajgKKnzePNpFiwbBVhieDb();
				}
			}
		}
		if (keyboardLayouts != null)
		{
			for (int n = 0; n < keyboardLayouts.Count; n++)
			{
				if (keyboardLayouts[n] != null)
				{
					keyboardLayouts[n].QmnafSCajgKKnzePNpFiwbBVhieDb();
				}
			}
		}
		if (mouseLayouts != null)
		{
			for (int num = 0; num < mouseLayouts.Count; num++)
			{
				if (mouseLayouts[num] != null)
				{
					mouseLayouts[num].QmnafSCajgKKnzePNpFiwbBVhieDb();
				}
			}
		}
		if (customControllerLayouts != null)
		{
			for (int num2 = 0; num2 < customControllerLayouts.Count; num2++)
			{
				if (customControllerLayouts[num2] != null)
				{
					customControllerLayouts[num2].QmnafSCajgKKnzePNpFiwbBVhieDb();
				}
			}
		}
		if (SRozGzlwCSqTEOsLNzRVLjkjMPqG != null)
		{
			for (int num3 = 0; num3 < SRozGzlwCSqTEOsLNzRVLjkjMPqG.Count; num3++)
			{
				if (SRozGzlwCSqTEOsLNzRVLjkjMPqG[num3] != null)
				{
					SRozGzlwCSqTEOsLNzRVLjkjMPqG[num3].qVwYUHfbXDNqnRRcbywHCtpMBJaK();
				}
			}
		}
		containsActionDelegate = ContainsAction;
		YKCplrMIOZgGhFWILDBupAzArJxM = true;
	}

	internal void tkfgFrbCKnsTJUVjYHeEUkKWNQvS()
	{
		if (!YKCplrMIOZgGhFWILDBupAzArJxM)
		{
			return;
		}
		if (mapCategories != null)
		{
			for (int i = 0; i < mapCategories.Count; i++)
			{
				if (mapCategories[i] != null)
				{
					mapCategories[i].SkkZIQRqVtCXPJovgsaAYArhyqOe();
				}
			}
		}
		if (SRozGzlwCSqTEOsLNzRVLjkjMPqG != null)
		{
			for (int j = 0; j < SRozGzlwCSqTEOsLNzRVLjkjMPqG.Count; j++)
			{
				if (SRozGzlwCSqTEOsLNzRVLjkjMPqG[j] != null)
				{
					SRozGzlwCSqTEOsLNzRVLjkjMPqG[j].FEKktiNBCjXncAwCqgszEAKXrarJ();
				}
			}
		}
		YKCplrMIOZgGhFWILDBupAzArJxM = false;
	}

	[CustomObfuscation(rename = false)]
	internal static UserData Merge(UserData orig, UserData other, bool preserveOrigIds)
	{
		return ndJLjuhPVrNKUeZBueilZdwWDuMX.bkFtvVgscRHjHNftiQoieYpgFYtp(orig, other, preserveOrigIds);
	}

	[CustomObfuscation(rename = false)]
	internal static UserData Compact(UserData orig)
	{
		return ndJLjuhPVrNKUeZBueilZdwWDuMX.bkFtvVgscRHjHNftiQoieYpgFYtp(orig, null, false);
	}
}
