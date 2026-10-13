using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Libraries.SharpDX.RawInput;
using Rewired.Libraries.SharpDX.Windows.Forms;
using Rewired.Utils;
using UnityEngine;

internal class DzHkyRvcjRMROCmuvZImYocGJtow : IUnifiedKeyboardSource, IGetSetEnabled, IDisposable
{
	private class upEBIXgeZAShAiBxOnEsEAAjvhPYb
	{
		private enum TuaMfCgcCpdhYzvTAGXiCejBAkYgb
		{
			None = 0,
			Down = 1,
			Up = 2
		}

		private const int yOQAvEQSYDrHAwZrXNRCebKjRqbq = 2;

		private static readonly KeyCode[] GmPdlbBkgXzisHWOeHqNzyVTenDQ = new KeyCode[2];

		private readonly UpdateLoopType QzohyNCpRfaAkZfCLhOAzutspvdj;

		private bool[] YSCIkwJFHlYbsHavALKmnwErbYcO;

		private bool[] FnFgvHmxwdLkcpudYfNmpqhaRSbB;

		private uint LaAPQgfGWCKwjqIAYwWdDxgOsAIl;

		public upEBIXgeZAShAiBxOnEsEAAjvhPYb(UpdateLoopType P_0)
		{
			QzohyNCpRfaAkZfCLhOAzutspvdj = P_0;
			YSCIkwJFHlYbsHavALKmnwErbYcO = new bool[132];
			FnFgvHmxwdLkcpudYfNmpqhaRSbB = new bool[132];
		}

		public void ldUwhDYxkirYkiEwIUKluMAnmHZx(KKlYAAqMhcakVhcbZIDCRIejgIYkA P_0)
		{
			int num = ywSayWewZEnKkMtXtMOFbPmsILTm(P_0, GmPdlbBkgXzisHWOeHqNzyVTenDQ);
			for (int i = 0; i < num; i++)
			{
				int num2 = (int)GmPdlbBkgXzisHWOeHqNzyVTenDQ[i];
				if (num2 >= 0 && num2 < gZZMANXbINvSiLZExwZEGfQTXLlX.Length)
				{
					KeyState tqxMAErGyDSGvwiAcVpImIApLVOE = P_0.tqxMAErGyDSGvwiAcVpImIApLVOE;
					bool flag = ((tqxMAErGyDSGvwiAcVpImIApLVOE == KeyState.KeyFirst || tqxMAErGyDSGvwiAcVpImIApLVOE == KeyState.SystemKeyDown) ? true : false);
					int num3 = gZZMANXbINvSiLZExwZEGfQTXLlX[num2];
					bool num4 = YSCIkwJFHlYbsHavALKmnwErbYcO[num3];
					YSCIkwJFHlYbsHavALKmnwErbYcO[num3] = flag;
					if (!num4 & flag)
					{
						FnFgvHmxwdLkcpudYfNmpqhaRSbB[num3] = true;
					}
				}
			}
		}

		public void gpDAMnUwBMfauoBltLXIUtvJHGav(ControllerDataUpdater P_0)
		{
			bool[] buttonValues = P_0.buttonValues;
			for (int i = 0; i < 132; i++)
			{
				buttonValues[i] = YSCIkwJFHlYbsHavALKmnwErbYcO[i] || FnFgvHmxwdLkcpudYfNmpqhaRSbB[i];
			}
			wjgrOEALzhFAfheTxciaBSkOVMUcA();
		}

		public void njVaYiZdAKebVQqlbaOtjXHEFhwW()
		{
			wjgrOEALzhFAfheTxciaBSkOVMUcA();
		}

		private void wjgrOEALzhFAfheTxciaBSkOVMUcA()
		{
			if (LaAPQgfGWCKwjqIAYwWdDxgOsAIl != ReInput.absFrame)
			{
				WRsOREHdSzfJfsWMsCEQJjumakhM();
				LaAPQgfGWCKwjqIAYwWdDxgOsAIl = ReInput.absFrame;
			}
		}

		public void WRsOREHdSzfJfsWMsCEQJjumakhM()
		{
			Array.Clear(FnFgvHmxwdLkcpudYfNmpqhaRSbB, 0, 132);
		}

		public void ZpUbXSghCQQKWiAkaycCNePAHzftB()
		{
			Array.Clear(YSCIkwJFHlYbsHavALKmnwErbYcO, 0, 132);
			Array.Clear(FnFgvHmxwdLkcpudYfNmpqhaRSbB, 0, 132);
		}
	}

	private const int hAPNspxtgWouolNvWvcRoabUSTo = 132;

	private const int ilBOrqJgYDNJBalZEewLiaLDLHubb = 256;

	private readonly object BIlcPZFdLNVsQxtQLlCPTExAvLiL = new object();

	private UpdateLoopDataSet<upEBIXgeZAShAiBxOnEsEAAjvhPYb> lKjTxslzxSKUcJnxtPOjlFxZrOaK;

	private HardwareControllerMap_Game OEKLicbXmGKlWcdlWsNoTWHRJShF;

	private bool JkPfGpBnyrseyiqPmvRykpNApFkFb;

	private int qRYphzoYWVHNHXYzwUBfKWLAefRi;

	private bool[] aNGCXIGOAojJlvvUUNDaGQFBmaFlB = new bool[256];

	private readonly KKlYAAqMhcakVhcbZIDCRIejgIYkA LCjxJFVZZfKVWxpcwbROxuodUNMg = new KKlYAAqMhcakVhcbZIDCRIejgIYkA();

	private bool FPOdRkBxHzeQLzWtMKeCcvGpXsTg;

	private static readonly int[] gZZMANXbINvSiLZExwZEGfQTXLlX;

	private static readonly int HuEseGTGkRRLfEAQBckYrifOGBxo;

	private bool NrskHlzQcHSxdUyDyLmHbdlnEMuN;

	private static IntPtr sGBrwRgzXMTniiXAuOylNZBsWQKL;

	private static WEJzDPEhNQNZrfcPrLAlSuuEoShk.SRUMTQcQFYWQUHASVIKCpKcHnwgR vspJGvjZjIKNDCmtVsRuqdisuzeG;

	private static readonly int[] ssFHLsUHARPMPETKgkhKyRUCenjq;

	private static Dictionary<int, Dictionary<int, KeyCode>> QGgdgdbsaEtrdEyiZNREhrXtxuFLA;

	private static readonly int[] gkjzJLeaoXVNwZkeceVjNTIwXfCi;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return get_enabled();
		}
		set
		{
			set_enabled(value);
		}
	}

	InputSource IUnifiedKeyboardSource.inputSource => get_inputSource();

	HardwareControllerMap_Game IUnifiedKeyboardSource.hardwareMap => get_hardwareMap();

	int IUnifiedKeyboardSource.buttonCount => get_buttonCount();

	Controller.Extension IUnifiedKeyboardSource.controllerExtension => get_controllerExtension();

	static DzHkyRvcjRMROCmuvZImYocGJtow()
	{
		vspJGvjZjIKNDCmtVsRuqdisuzeG = WEJzDPEhNQNZrfcPrLAlSuuEoShk.SRUMTQcQFYWQUHASVIKCpKcHnwgR.United_States_English;
		ssFHLsUHARPMPETKgkhKyRUCenjq = (int[])Enum.GetValues(typeof(WEJzDPEhNQNZrfcPrLAlSuuEoShk.SRUMTQcQFYWQUHASVIKCpKcHnwgR));
		QGgdgdbsaEtrdEyiZNREhrXtxuFLA = new Dictionary<int, Dictionary<int, KeyCode>>
		{
			{
				1033,
				new Dictionary<int, KeyCode>
				{
					{
						222,
						KeyCode.Quote
					},
					{
						188,
						KeyCode.Comma
					},
					{
						189,
						KeyCode.Minus
					},
					{
						190,
						KeyCode.Period
					},
					{
						191,
						KeyCode.Slash
					},
					{
						186,
						KeyCode.Semicolon
					},
					{
						187,
						KeyCode.Equals
					},
					{
						219,
						KeyCode.LeftBracket
					},
					{
						220,
						KeyCode.Backslash
					},
					{
						221,
						KeyCode.RightBracket
					},
					{
						192,
						KeyCode.BackQuote
					},
					{
						223,
						KeyCode.BackQuote
					}
				}
			},
			{
				2057,
				new Dictionary<int, KeyCode>
				{
					{
						223,
						KeyCode.BackQuote
					},
					{
						192,
						KeyCode.Quote
					}
				}
			},
			{
				1106,
				new Dictionary<int, KeyCode>
				{
					{
						223,
						KeyCode.BackQuote
					},
					{
						192,
						KeyCode.Quote
					}
				}
			},
			{
				1031,
				new Dictionary<int, KeyCode>
				{
					{
						219,
						KeyCode.Backslash
					},
					{
						221,
						KeyCode.BackQuote
					}
				}
			}
		};
		gkjzJLeaoXVNwZkeceVjNTIwXfCi = new int[22]
		{
			186, 191, 192, 219, 220, 221, 222, 223, 226, 226,
			254, 221, 188, 189, 219, 190, 220, 187, 191, 222,
			186, 192
		};
		int[] keyboardKeyValues = Consts._keyboardKeyValues;
		int num = keyboardKeyValues.Length;
		for (int i = 0; i < num; i++)
		{
			if (keyboardKeyValues[i] > HuEseGTGkRRLfEAQBckYrifOGBxo)
			{
				HuEseGTGkRRLfEAQBckYrifOGBxo = keyboardKeyValues[i];
			}
		}
		gZZMANXbINvSiLZExwZEGfQTXLlX = new int[HuEseGTGkRRLfEAQBckYrifOGBxo + 1];
		ArrayTools.Fill(gZZMANXbINvSiLZExwZEGfQTXLlX, -1);
		for (int j = 0; j < num; j++)
		{
			gZZMANXbINvSiLZExwZEGfQTXLlX[keyboardKeyValues[j]] = j;
		}
	}

	public DzHkyRvcjRMROCmuvZImYocGJtow(UpdateLoopSetting P_0)
	{
		XofDRosSJcOMdIkBGExPEMBMKsKy();
		lKjTxslzxSKUcJnxtPOjlFxZrOaK = new UpdateLoopDataSet<upEBIXgeZAShAiBxOnEsEAAjvhPYb>(P_0);
		using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tList.list;
			EnumConverter.ToUpdateLoopTypes(P_0, list);
			for (int i = 0; i < list.Count; i++)
			{
				lKjTxslzxSKUcJnxtPOjlFxZrOaK[i] = new upEBIXgeZAShAiBxOnEsEAAjvhPYb(list[i]);
			}
		}
		JkPfGpBnyrseyiqPmvRykpNApFkFb = ReInput.IsInputAllowed(ControllerType.Keyboard);
		set_enabled(value: true);
		ReInput.ApplicationFocusChangedEvent += AAPbtRjjdebVAqtqspFSpoIJmnbDA;
		ReInput.ApplicationPauseChangedEvent += eimaOYHjseTrSuOrTaCTdZTCtnwlb;
		ReInput.EditorPauseChangedEvent += BWavhcsLpcdLqNhmwZVQXjLlCrIf;
		ReInput.UpdateEndedEvent += gQxIbkNBdEGOQgVEyjVKMZbhorbQ;
		ReInput.TimeScalePauseChangedEvent += fhbBReiHcoQkNtegDgeWGbJRPIjg;
	}

	public unsafe void xtjcUWOYaXBjWeMxgSKeOobZUzKF(UpdateLoopType P_0)
	{
		lKjTxslzxSKUcJnxtPOjlFxZrOaK.SetUpdateLoop(P_0);
		JkPfGpBnyrseyiqPmvRykpNApFkFb = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (BIlcPZFdLNVsQxtQLlCPTExAvLiL)
		{
			try
			{
				byte* ptr = stackalloc byte[256];
				if (!iZtZloELsoaMBDRDTiszzpwtPjDd.trFPpFjavMojFPgnyjYUTxYrIHYi((IntPtr)ptr))
				{
					return;
				}
				for (int i = 0; i < 256; i++)
				{
					switch (i)
					{
					case 1:
					case 2:
					case 4:
					case 5:
					case 6:
					case 16:
					case 17:
					case 18:
					case 65536:
					case 131072:
						continue;
					}
					if ((ptr[i] & 0x80) == 0)
					{
						if (aNGCXIGOAojJlvvUUNDaGQFBmaFlB[i])
						{
							LCjxJFVZZfKVWxpcwbROxuodUNMg.cDWVrTNfHNDHQSOxZdcUIAtDBAnkA();
							LCjxJFVZZfKVWxpcwbROxuodUNMg.TckBIuCfdqwfJfxSjctmCedReYlS = ReInput.realTime;
							LCjxJFVZZfKVWxpcwbROxuodUNMg.saejTTsyfVBCpPoSdjDDrAvmddEW = IntPtr.Zero;
							LCjxJFVZZfKVWxpcwbROxuodUNMg.cJfGnqVzrgkuwoSIPqnIcJIWaSWn = (Keys)i;
							LCjxJFVZZfKVWxpcwbROxuodUNMg.WtpuiSvmtTVHghMUeEIZXrAGyRWS = 0;
							LCjxJFVZZfKVWxpcwbROxuodUNMg.ZIbbmWjLCAsfodkAHsDvJAefRMqs = ScanCodeFlags.Break;
							LCjxJFVZZfKVWxpcwbROxuodUNMg.tqxMAErGyDSGvwiAcVpImIApLVOE = KeyState.KeyUp;
							LCjxJFVZZfKVWxpcwbROxuodUNMg.LHkvLjuIRQvKqPIvjRKLwCkELdiG = 0;
							PsuYSWUIODCdwAJIzbLpkjwMGeztA(LCjxJFVZZfKVWxpcwbROxuodUNMg);
						}
					}
					else if (!aNGCXIGOAojJlvvUUNDaGQFBmaFlB[i])
					{
						LCjxJFVZZfKVWxpcwbROxuodUNMg.cDWVrTNfHNDHQSOxZdcUIAtDBAnkA();
						LCjxJFVZZfKVWxpcwbROxuodUNMg.TckBIuCfdqwfJfxSjctmCedReYlS = ReInput.realTime;
						LCjxJFVZZfKVWxpcwbROxuodUNMg.saejTTsyfVBCpPoSdjDDrAvmddEW = IntPtr.Zero;
						LCjxJFVZZfKVWxpcwbROxuodUNMg.cJfGnqVzrgkuwoSIPqnIcJIWaSWn = (Keys)i;
						LCjxJFVZZfKVWxpcwbROxuodUNMg.WtpuiSvmtTVHghMUeEIZXrAGyRWS = 0;
						LCjxJFVZZfKVWxpcwbROxuodUNMg.ZIbbmWjLCAsfodkAHsDvJAefRMqs = ScanCodeFlags.Make;
						LCjxJFVZZfKVWxpcwbROxuodUNMg.tqxMAErGyDSGvwiAcVpImIApLVOE = KeyState.KeyFirst;
						LCjxJFVZZfKVWxpcwbROxuodUNMg.LHkvLjuIRQvKqPIvjRKLwCkELdiG = 0;
						PsuYSWUIODCdwAJIzbLpkjwMGeztA(LCjxJFVZZfKVWxpcwbROxuodUNMg);
					}
				}
			}
			catch
			{
			}
		}
	}

	public void PsuYSWUIODCdwAJIzbLpkjwMGeztA(KKlYAAqMhcakVhcbZIDCRIejgIYkA P_0)
	{
		if (!JkPfGpBnyrseyiqPmvRykpNApFkFb)
		{
			return;
		}
		switch (P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn)
		{
		case Keys.ControlKey:
		{
			Keys keys = (Keys)iZtZloELsoaMBDRDTiszzpwtPjDd.iIDLNpZYIpfRDsnSnPxLNWiSDeEO((uint)P_0.WtpuiSvmtTVHghMUeEIZXrAGyRWS, WEJzDPEhNQNZrfcPrLAlSuuEoShk.vbvHokDzMpkIQPmfBtdYEgGGMrVGB);
			if (keys != Keys.LControlKey && keys != Keys.RControlKey)
			{
				return;
			}
			P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn = (((P_0.ZIbbmWjLCAsfodkAHsDvJAefRMqs & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RControlKey : Keys.LControlKey);
			break;
		}
		case Keys.Menu:
			P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn = (((P_0.ZIbbmWjLCAsfodkAHsDvJAefRMqs & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RMenu : Keys.LMenu);
			break;
		case Keys.ShiftKey:
		{
			P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn = (Keys)iZtZloELsoaMBDRDTiszzpwtPjDd.iIDLNpZYIpfRDsnSnPxLNWiSDeEO((uint)P_0.WtpuiSvmtTVHghMUeEIZXrAGyRWS, WEJzDPEhNQNZrfcPrLAlSuuEoShk.vbvHokDzMpkIQPmfBtdYEgGGMrVGB);
			if (P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn == Keys.LShiftKey || P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn == Keys.RShiftKey)
			{
				break;
			}
			KeyState tqxMAErGyDSGvwiAcVpImIApLVOE = P_0.tqxMAErGyDSGvwiAcVpImIApLVOE;
			bool flag = ((tqxMAErGyDSGvwiAcVpImIApLVOE == KeyState.KeyFirst || tqxMAErGyDSGvwiAcVpImIApLVOE == KeyState.SystemKeyDown || tqxMAErGyDSGvwiAcVpImIApLVOE == KeyState.KeyLast) ? true : false);
			bool flag2 = (iZtZloELsoaMBDRDTiszzpwtPjDd.YcQtqcLlVmEQWxHUUbeCSoWjUVns(160) & 0x8000) != 0;
			bool flag3 = (iZtZloELsoaMBDRDTiszzpwtPjDd.YcQtqcLlVmEQWxHUUbeCSoWjUVns(161) & 0x8000) != 0;
			if (flag)
			{
				bool num = (iZtZloELsoaMBDRDTiszzpwtPjDd.DLQSTlMqxEMkxqBIPsXWMrIkpQiq(160) & 0x8000) != 0;
				bool flag4 = (iZtZloELsoaMBDRDTiszzpwtPjDd.DLQSTlMqxEMkxqBIPsXWMrIkpQiq(161) & 0x8000) != 0;
				if (num)
				{
					P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn = Keys.LShiftKey;
					PsuYSWUIODCdwAJIzbLpkjwMGeztA(P_0);
				}
				if (flag4)
				{
					P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn = Keys.RShiftKey;
					PsuYSWUIODCdwAJIzbLpkjwMGeztA(P_0);
				}
				return;
			}
			if (flag2 & flag3)
			{
				return;
			}
			if (flag2)
			{
				P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn = Keys.LShiftKey;
				break;
			}
			if (flag3)
			{
				P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn = Keys.RShiftKey;
				break;
			}
			P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn = Keys.LShiftKey;
			PsuYSWUIODCdwAJIzbLpkjwMGeztA(P_0);
			P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn = Keys.RShiftKey;
			PsuYSWUIODCdwAJIzbLpkjwMGeztA(P_0);
			return;
		}
		}
		lock (BIlcPZFdLNVsQxtQLlCPTExAvLiL)
		{
			KeyState tqxMAErGyDSGvwiAcVpImIApLVOE = P_0.tqxMAErGyDSGvwiAcVpImIApLVOE;
			if (tqxMAErGyDSGvwiAcVpImIApLVOE == KeyState.KeyFirst || tqxMAErGyDSGvwiAcVpImIApLVOE == KeyState.SystemKeyDown)
			{
				aNGCXIGOAojJlvvUUNDaGQFBmaFlB[(int)P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn] = true;
			}
			else
			{
				aNGCXIGOAojJlvvUUNDaGQFBmaFlB[(int)P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn] = false;
			}
			int count = lKjTxslzxSKUcJnxtPOjlFxZrOaK.Count;
			for (int i = 0; i < count; i++)
			{
				lKjTxslzxSKUcJnxtPOjlFxZrOaK[i].ldUwhDYxkirYkiEwIUKluMAnmHZx(P_0);
			}
		}
	}

	public void UYjVewBmHzcklgNMaGYGNnOZUeMHA(bool P_0)
	{
		MwCYgHnNRaCydawntrLPFqlNXzxAA();
	}

	public void SebWxGKqxzoifpLBcewcNEancciW(bool P_0)
	{
		if (XofDRosSJcOMdIkBGExPEMBMKsKy() < 0)
		{
			MwCYgHnNRaCydawntrLPFqlNXzxAA();
		}
	}

	private int XofDRosSJcOMdIkBGExPEMBMKsKy()
	{
		int num = qRYphzoYWVHNHXYzwUBfKWLAefRi;
		if (ojlzQfWcOYdhEdoUtpjHLTuXXVeX.PrhQPfZPCSnABdKWTATcEZPQTiwJ(KMtSgETdNvgXUrUlDrAtelwyuiPp.Keyboard, out var num2))
		{
			qRYphzoYWVHNHXYzwUBfKWLAefRi = num2;
		}
		else
		{
			qRYphzoYWVHNHXYzwUBfKWLAefRi = 1;
		}
		return qRYphzoYWVHNHXYzwUBfKWLAefRi - num;
	}

	private void AAPbtRjjdebVAqtqspFSpoIJmnbDA(bool P_0)
	{
		JkPfGpBnyrseyiqPmvRykpNApFkFb = ReInput.IsInputAllowed(ControllerType.Keyboard);
		if (!P_0 && !JkPfGpBnyrseyiqPmvRykpNApFkFb)
		{
			MwCYgHnNRaCydawntrLPFqlNXzxAA();
		}
	}

	private void eimaOYHjseTrSuOrTaCTdZTCtnwlb(bool P_0)
	{
		JkPfGpBnyrseyiqPmvRykpNApFkFb = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!JkPfGpBnyrseyiqPmvRykpNApFkFb)
		{
			MwCYgHnNRaCydawntrLPFqlNXzxAA();
		}
	}

	private void BWavhcsLpcdLqNhmwZVQXjLlCrIf(bool P_0)
	{
	}

	private void fhbBReiHcoQkNtegDgeWGbJRPIjg(bool P_0)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == 0)
		{
			return;
		}
		JkPfGpBnyrseyiqPmvRykpNApFkFb = ReInput.IsInputAllowed(ControllerType.Keyboard);
		lock (BIlcPZFdLNVsQxtQLlCPTExAvLiL)
		{
			lKjTxslzxSKUcJnxtPOjlFxZrOaK[lKjTxslzxSKUcJnxtPOjlFxZrOaK.fixedUpdateSetIndex].WRsOREHdSzfJfsWMsCEQJjumakhM();
		}
	}

	private void gQxIbkNBdEGOQgVEyjVKMZbhorbQ(UpdateLoopType P_0)
	{
		lock (BIlcPZFdLNVsQxtQLlCPTExAvLiL)
		{
			lKjTxslzxSKUcJnxtPOjlFxZrOaK.Get(P_0).njVaYiZdAKebVQqlbaOtjXHEFhwW();
		}
	}

	private void MwCYgHnNRaCydawntrLPFqlNXzxAA()
	{
		lock (BIlcPZFdLNVsQxtQLlCPTExAvLiL)
		{
			int count = lKjTxslzxSKUcJnxtPOjlFxZrOaK.Count;
			for (int i = 0; i < count; i++)
			{
				lKjTxslzxSKUcJnxtPOjlFxZrOaK[i].ZpUbXSghCQQKWiAkaycCNePAHzftB();
			}
		}
	}

	public bool get_enabled()
	{
		return FPOdRkBxHzeQLzWtMKeCcvGpXsTg;
	}

	public void set_enabled(bool value)
	{
		if (FPOdRkBxHzeQLzWtMKeCcvGpXsTg != value)
		{
			FPOdRkBxHzeQLzWtMKeCcvGpXsTg = value;
		}
	}

	public InputSource get_inputSource()
	{
		return InputSource.RawInput;
	}

	public HardwareControllerMap_Game get_hardwareMap()
	{
		if (OEKLicbXmGKlWcdlWsNoTWHRJShF == null)
		{
			OEKLicbXmGKlWcdlWsNoTWHRJShF = XkdyoduGidpLVRUNETSDGGYDiHNU();
		}
		return OEKLicbXmGKlWcdlWsNoTWHRJShF;
	}

	public int get_buttonCount()
	{
		return 132;
	}

	public Controller.Extension get_controllerExtension()
	{
		return null;
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		lKjTxslzxSKUcJnxtPOjlFxZrOaK.Current.gpDAMnUwBMfauoBltLXIUtvJHGav(dataUpdater);
	}

	void IUnifiedKeyboardSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		MwCYgHnNRaCydawntrLPFqlNXzxAA();
	}

	void IUnifiedKeyboardSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private static HardwareControllerMap_Game XkdyoduGidpLVRUNETSDGGYDiHNU()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(i, Consts.keyboardKeyNames[i], Consts.keyboardKeyNames[i], string.Empty, ControllerElementType.Button, true);
		}
		int[] array2 = new int[132];
		for (int j = 0; j < 132; j++)
		{
			array2[j] = array[j].get_id();
		}
		HardwareButtonInfo[] array3 = new HardwareButtonInfo[132];
		for (int k = 0; k < 132; k++)
		{
			array3[k] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Keyboard", default, array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
	}

	public void Dispose()
	{
		OZuAHzthkGuyBVnchFTOgalVEbvq(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void hTvUAVXwXfHsANqxNAlIGRBYVIqOA()
	{
		try
		{
			OZuAHzthkGuyBVnchFTOgalVEbvq(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void OZuAHzthkGuyBVnchFTOgalVEbvq(bool P_0)
	{
		if (!NrskHlzQcHSxdUyDyLmHbdlnEMuN)
		{
			ReInput.ApplicationFocusChangedEvent -= AAPbtRjjdebVAqtqspFSpoIJmnbDA;
			ReInput.ApplicationPauseChangedEvent -= eimaOYHjseTrSuOrTaCTdZTCtnwlb;
			ReInput.EditorPauseChangedEvent -= BWavhcsLpcdLqNhmwZVQXjLlCrIf;
			ReInput.UpdateEndedEvent -= gQxIbkNBdEGOQgVEyjVKMZbhorbQ;
			ReInput.TimeScalePauseChangedEvent -= fhbBReiHcoQkNtegDgeWGbJRPIjg;
			NrskHlzQcHSxdUyDyLmHbdlnEMuN = true;
		}
	}

	public static int ywSayWewZEnKkMtXtMOFbPmsILTm(KKlYAAqMhcakVhcbZIDCRIejgIYkA P_0, KeyCode[] P_1)
	{
		Keys cJfGnqVzrgkuwoSIPqnIcJIWaSWn = P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn;
		int result = 0;
		WEJzDPEhNQNZrfcPrLAlSuuEoShk.SRUMTQcQFYWQUHASVIKCpKcHnwgR sRUMTQcQFYWQUHASVIKCpKcHnwgR = iKkXTdYeLMobUCPTGIvOHEKKmbzK();
		_ = sGBrwRgzXMTniiXAuOylNZBsWQKL;
		iZtZloELsoaMBDRDTiszzpwtPjDd.iIDLNpZYIpfRDsnSnPxLNWiSDeEO((uint)P_0.cJfGnqVzrgkuwoSIPqnIcJIWaSWn, WEJzDPEhNQNZrfcPrLAlSuuEoShk.SWTcDbdPifYKGIYvXqRIHFAZFLCN);
		if (zrDapLPKWBKEOrsbpQCeSbSmHINT(cJfGnqVzrgkuwoSIPqnIcJIWaSWn))
		{
			if (sRwOFFUmBvNMmBMDAsuUyWDOxiCK(cJfGnqVzrgkuwoSIPqnIcJIWaSWn, sRUMTQcQFYWQUHASVIKCpKcHnwgR, out var keyCode))
			{
				P_1[result++] = keyCode;
			}
		}
		else
		{
			switch (cJfGnqVzrgkuwoSIPqnIcJIWaSWn)
			{
			case Keys.None:
				P_1[result++] = KeyCode.None;
				break;
			case Keys.A:
				P_1[result++] = KeyCode.A;
				break;
			case Keys.B:
				P_1[result++] = KeyCode.B;
				break;
			case Keys.C:
				P_1[result++] = KeyCode.C;
				break;
			case Keys.D:
				P_1[result++] = KeyCode.D;
				break;
			case Keys.E:
				P_1[result++] = KeyCode.E;
				break;
			case Keys.F:
				P_1[result++] = KeyCode.F;
				break;
			case Keys.G:
				P_1[result++] = KeyCode.G;
				break;
			case Keys.H:
				P_1[result++] = KeyCode.H;
				break;
			case Keys.I:
				P_1[result++] = KeyCode.I;
				break;
			case Keys.J:
				P_1[result++] = KeyCode.J;
				break;
			case Keys.K:
				P_1[result++] = KeyCode.K;
				break;
			case Keys.L:
				P_1[result++] = KeyCode.L;
				break;
			case Keys.M:
				P_1[result++] = KeyCode.M;
				break;
			case Keys.N:
				P_1[result++] = KeyCode.N;
				break;
			case Keys.O:
				P_1[result++] = KeyCode.O;
				break;
			case Keys.P:
				P_1[result++] = KeyCode.P;
				break;
			case Keys.Q:
				P_1[result++] = KeyCode.Q;
				break;
			case Keys.R:
				P_1[result++] = KeyCode.R;
				break;
			case Keys.S:
				P_1[result++] = KeyCode.S;
				break;
			case Keys.T:
				P_1[result++] = KeyCode.T;
				break;
			case Keys.U:
				P_1[result++] = KeyCode.U;
				break;
			case Keys.V:
				P_1[result++] = KeyCode.V;
				break;
			case Keys.W:
				P_1[result++] = KeyCode.W;
				break;
			case Keys.X:
				P_1[result++] = KeyCode.X;
				break;
			case Keys.Y:
				P_1[result++] = KeyCode.Y;
				break;
			case Keys.Z:
				P_1[result++] = KeyCode.Z;
				break;
			case Keys.D0:
				P_1[result++] = KeyCode.Alpha0;
				break;
			case Keys.D1:
				P_1[result++] = KeyCode.Alpha1;
				break;
			case Keys.D2:
				P_1[result++] = KeyCode.Alpha2;
				break;
			case Keys.D3:
				P_1[result++] = KeyCode.Alpha3;
				break;
			case Keys.D4:
				P_1[result++] = KeyCode.Alpha4;
				break;
			case Keys.D5:
				P_1[result++] = KeyCode.Alpha5;
				break;
			case Keys.D6:
				P_1[result++] = KeyCode.Alpha6;
				break;
			case Keys.D7:
				P_1[result++] = KeyCode.Alpha7;
				break;
			case Keys.D8:
				P_1[result++] = KeyCode.Alpha8;
				break;
			case Keys.D9:
				P_1[result++] = KeyCode.Alpha9;
				break;
			case Keys.NumPad0:
				P_1[result++] = KeyCode.Keypad0;
				break;
			case Keys.NumPad1:
				P_1[result++] = KeyCode.Keypad1;
				break;
			case Keys.NumPad2:
				P_1[result++] = KeyCode.Keypad2;
				break;
			case Keys.NumPad3:
				P_1[result++] = KeyCode.Keypad3;
				break;
			case Keys.NumPad4:
				P_1[result++] = KeyCode.Keypad4;
				break;
			case Keys.NumPad5:
				P_1[result++] = KeyCode.Keypad5;
				break;
			case Keys.NumPad6:
				P_1[result++] = KeyCode.Keypad6;
				break;
			case Keys.NumPad7:
				P_1[result++] = KeyCode.Keypad7;
				break;
			case Keys.NumPad8:
				P_1[result++] = KeyCode.Keypad8;
				break;
			case Keys.NumPad9:
				P_1[result++] = KeyCode.Keypad9;
				break;
			case Keys.Decimal:
				P_1[result++] = KeyCode.KeypadPeriod;
				break;
			case Keys.Divide:
				P_1[result++] = KeyCode.KeypadDivide;
				break;
			case Keys.Multiply:
				P_1[result++] = KeyCode.KeypadMultiply;
				break;
			case Keys.Subtract:
				P_1[result++] = KeyCode.KeypadMinus;
				break;
			case Keys.Add:
				P_1[result++] = KeyCode.KeypadPlus;
				break;
			case Keys.Return:
				if ((P_0.ZIbbmWjLCAsfodkAHsDvJAefRMqs & ScanCodeFlags.E0) != ScanCodeFlags.Make)
				{
					P_1[result++] = KeyCode.KeypadEnter;
				}
				else
				{
					P_1[result++] = KeyCode.Return;
				}
				break;
			case Keys.Back:
				P_1[result++] = KeyCode.Backspace;
				break;
			case Keys.Tab:
				P_1[result++] = KeyCode.Tab;
				break;
			case Keys.Clear:
				P_1[result++] = KeyCode.Clear;
				break;
			case Keys.Pause:
				P_1[result++] = KeyCode.Pause;
				break;
			case Keys.Escape:
				P_1[result++] = KeyCode.Escape;
				break;
			case Keys.Space:
				P_1[result++] = KeyCode.Space;
				break;
			case Keys.Delete:
				P_1[result++] = KeyCode.Delete;
				break;
			case Keys.Up:
				P_1[result++] = KeyCode.UpArrow;
				break;
			case Keys.Down:
				P_1[result++] = KeyCode.DownArrow;
				break;
			case Keys.Right:
				P_1[result++] = KeyCode.RightArrow;
				break;
			case Keys.Left:
				P_1[result++] = KeyCode.LeftArrow;
				break;
			case Keys.Insert:
				P_1[result++] = KeyCode.Insert;
				break;
			case Keys.Home:
				P_1[result++] = KeyCode.Home;
				break;
			case Keys.End:
				P_1[result++] = KeyCode.End;
				break;
			case Keys.Prior:
				P_1[result++] = KeyCode.PageUp;
				break;
			case Keys.Next:
				P_1[result++] = KeyCode.PageDown;
				break;
			case Keys.F1:
				P_1[result++] = KeyCode.F1;
				break;
			case Keys.F2:
				P_1[result++] = KeyCode.F2;
				break;
			case Keys.F3:
				P_1[result++] = KeyCode.F3;
				break;
			case Keys.F4:
				P_1[result++] = KeyCode.F4;
				break;
			case Keys.F5:
				P_1[result++] = KeyCode.F5;
				break;
			case Keys.F6:
				P_1[result++] = KeyCode.F6;
				break;
			case Keys.F7:
				P_1[result++] = KeyCode.F7;
				break;
			case Keys.F8:
				P_1[result++] = KeyCode.F8;
				break;
			case Keys.F9:
				P_1[result++] = KeyCode.F9;
				break;
			case Keys.F10:
				P_1[result++] = KeyCode.F10;
				break;
			case Keys.F11:
				P_1[result++] = KeyCode.F11;
				break;
			case Keys.F12:
				P_1[result++] = KeyCode.F12;
				break;
			case Keys.F13:
				P_1[result++] = KeyCode.F13;
				break;
			case Keys.F14:
				P_1[result++] = KeyCode.F14;
				break;
			case Keys.F15:
				P_1[result++] = KeyCode.F15;
				break;
			case Keys.NumLock:
				P_1[result++] = KeyCode.Numlock;
				break;
			case Keys.Capital:
				P_1[result++] = KeyCode.CapsLock;
				break;
			case Keys.Scroll:
				P_1[result++] = KeyCode.ScrollLock;
				break;
			case Keys.RShiftKey:
				P_1[result++] = KeyCode.RightShift;
				break;
			case Keys.LShiftKey:
				P_1[result++] = KeyCode.LeftShift;
				break;
			case Keys.RControlKey:
				P_1[result++] = KeyCode.RightControl;
				break;
			case Keys.LControlKey:
				P_1[result++] = KeyCode.LeftControl;
				break;
			case Keys.RMenu:
				P_1[result++] = KeyCode.AltGr;
				P_1[result++] = KeyCode.RightAlt;
				break;
			case Keys.LMenu:
				P_1[result++] = KeyCode.LeftAlt;
				break;
			case Keys.RWin:
				P_1[result++] = KeyCode.RightMeta;
				break;
			case Keys.LWin:
				P_1[result++] = KeyCode.LeftMeta;
				break;
			case Keys.Help:
				P_1[result++] = KeyCode.Help;
				break;
			case Keys.Print:
				P_1[result++] = KeyCode.Print;
				break;
			case Keys.Apps:
				P_1[result++] = KeyCode.Menu;
				break;
			}
		}
		return result;
	}

	private unsafe static WEJzDPEhNQNZrfcPrLAlSuuEoShk.SRUMTQcQFYWQUHASVIKCpKcHnwgR iKkXTdYeLMobUCPTGIvOHEKKmbzK()
	{
		IntPtr intPtr = iZtZloELsoaMBDRDTiszzpwtPjDd.RjoXDcMjCNublPPbGDlXcFARuaxmA(0);
		if (intPtr == sGBrwRgzXMTniiXAuOylNZBsWQKL)
		{
			return vspJGvjZjIKNDCmtVsRuqdisuzeG;
		}
		WEJzDPEhNQNZrfcPrLAlSuuEoShk.SRUMTQcQFYWQUHASVIKCpKcHnwgR result = WEJzDPEhNQNZrfcPrLAlSuuEoShk.SRUMTQcQFYWQUHASVIKCpKcHnwgR.United_States_English;
		byte* intPtr2 = stackalloc byte[128];
		iZtZloELsoaMBDRDTiszzpwtPjDd.LSiDqlpxPIaijfxmjpcuRSCVBCluA((IntPtr)intPtr2);
		if (int.TryParse(Marshal.PtrToStringUni((IntPtr)intPtr2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result2))
		{
			int num = ArrayTools.IndexOf(ssFHLsUHARPMPETKgkhKyRUCenjq, result2);
			if (num >= 0)
			{
				result = (WEJzDPEhNQNZrfcPrLAlSuuEoShk.SRUMTQcQFYWQUHASVIKCpKcHnwgR)ssFHLsUHARPMPETKgkhKyRUCenjq[num];
			}
		}
		sGBrwRgzXMTniiXAuOylNZBsWQKL = intPtr;
		vspJGvjZjIKNDCmtVsRuqdisuzeG = result;
		return result;
	}

	private static bool sRwOFFUmBvNMmBMDAsuUyWDOxiCK(Keys P_0, WEJzDPEhNQNZrfcPrLAlSuuEoShk.SRUMTQcQFYWQUHASVIKCpKcHnwgR P_1, out KeyCode P_2)
	{
		P_2 = KeyCode.None;
		if (!QGgdgdbsaEtrdEyiZNREhrXtxuFLA.TryGetValue((int)P_1, out var value))
		{
			value = QGgdgdbsaEtrdEyiZNREhrXtxuFLA[1033];
		}
		bool flag = value.TryGetValue((int)P_0, out P_2);
		if (!flag && P_1 != WEJzDPEhNQNZrfcPrLAlSuuEoShk.SRUMTQcQFYWQUHASVIKCpKcHnwgR.United_States_English)
		{
			value = QGgdgdbsaEtrdEyiZNREhrXtxuFLA[1033];
			flag = value.TryGetValue((int)P_0, out P_2);
		}
		return flag;
	}

	private static bool zrDapLPKWBKEOrsbpQCeSbSmHINT(Keys P_0)
	{
		return ArrayTools.Contains(gkjzJLeaoXVNwZkeceVjNTIwXfCi, (int)P_0);
	}
}
