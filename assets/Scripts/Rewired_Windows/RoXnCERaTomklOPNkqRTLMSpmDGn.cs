using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

internal class RoXnCERaTomklOPNkqRTLMSpmDGn : PlatformInputManager
{
	private class zxwyluHITgqyxtCvnCdvGZWCunpK : IInputManagerJoystick, IInputManagerJoystickPublic, IDisposable
	{
		private int nsmtMUrJdvWBXELXLKPzJSVBLPqH;

		private int dTyNtjfWFzcOloEdAjwAzxgRMkOp;

		public Guid puNjnpmfZMrUXhpXetFTNbMLqnsN;

		public string qgeQuOljAhyeWykcqyiEsPVRfaeBA;

		public gmzcmYbFSNucJXQyYRMseSdXxgyb hmbLRptVDQpyXIqPZmGqffqbINZn;

		public string vaFZzEyAotphaBCOfGdKtYuTfHHj;

		public string YxeceAxGshiAhWGXYcoEecTtThLKA;

		public Guid fWDlgznFFpxukkfasIGRzXLdYzWo;

		public PidVid MBxgcTBytNuVXNFnxoNuHHmFfZgoB;

		public Guid aOqKAcNnkZNSPxfwlqFnshtLmDdr;

		public int gybRdKpAJwQUfRJlGpcuVOllfdCHA;

		public int eRlestibqXQhrVRnvvBEnGrTFfRVA;

		public int YGIoTnymCBeaBxdzXDBSOvFgODh;

		public int ntXfLbDUoccgpUFvlsONumkrVAbF;

		public int NlnadAdlHFsKoxVmNrTKBgGdNRJc;

		public int iKxbZQXqRzCeFnhmYaOAAxVzqbmsA;

		public bool aOrdMAhcAYptcCdMyvRoICwQdqrh;

		public int pYkALoKgbTJkEivkEvJmPCaFBZyub;

		private float[] qtOYaUcIByelmgmWjCFCLjcHkybv;

		private float[] sooXDLLNJWiZkMKhlSyzixQJYglG;

		private bool[] HHLTDMczvaoGULnOJuPZwvNfGHiI;

		private HardwareJoystickMap_InputManager TClNllSNLXURMCDGnewfasllsAodA;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> exrujPrkEvIQCtEYEDHlHQWdxKWj;

		private bool emRYwsZMDsEooDFICtnoNKwemxzU;

		private bool WgmeDbeKGWwkgGSuYMgnXdtUyjKDA;

		[CompilerGenerated]
		private Controller.Extension ogMdsaKZkQjxEGFCXoBkLgxpgVaMA;

		private bool uGgUTxGlvBPBEZdNStSSSuJESpAT;

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.rewiredId
		{
			get
			{
				return get_rewiredId();
			}
			set
			{
				set_rewiredId(value);
			}
		}

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.inputManagerId
		{
			get
			{
				return get_inputManagerId();
			}
			set
			{
				set_inputManagerId(value);
			}
		}

		[CustomObfuscation(rename = false)]
		string IInputManagerJoystickPublic.name => get_name();

		[CustomObfuscation(rename = false)]
		long? IInputManagerJoystickPublic.systemId => get_systemId();

		[CustomObfuscation(rename = false)]
		int IInputManagerJoystickPublic.unityId => get_unityId();

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.instanceGuid => get_instanceGuid();

		[CustomObfuscation(rename = false)]
		Guid IInputManagerJoystickPublic.persistentGuid => get_persistentGuid();

		[CustomObfuscation(rename = false)]
		Controller.Extension IInputManagerJoystickPublic.extension
		{
			get
			{
				return get_extension();
			}
			set
			{
				set_extension(value);
			}
		}

		public int get_rewiredId()
		{
			return nsmtMUrJdvWBXELXLKPzJSVBLPqH;
		}

		public void set_rewiredId(int value)
		{
			nsmtMUrJdvWBXELXLKPzJSVBLPqH = value;
		}

		public int get_inputManagerId()
		{
			return dTyNtjfWFzcOloEdAjwAzxgRMkOp;
		}

		public void set_inputManagerId(int value)
		{
			dTyNtjfWFzcOloEdAjwAzxgRMkOp = value;
		}

		public string get_name()
		{
			if (!(qgeQuOljAhyeWykcqyiEsPVRfaeBA != "Unknown Controller"))
			{
				return YxeceAxGshiAhWGXYcoEecTtThLKA;
			}
			return qgeQuOljAhyeWykcqyiEsPVRfaeBA;
		}

		public long? get_systemId()
		{
			if (dTyNtjfWFzcOloEdAjwAzxgRMkOp < 0)
			{
				return null;
			}
			return dTyNtjfWFzcOloEdAjwAzxgRMkOp;
		}

		public int get_unityId()
		{
			return 0;
		}

		public Guid get_instanceGuid()
		{
			return fWDlgznFFpxukkfasIGRzXLdYzWo;
		}

		public Guid get_persistentGuid()
		{
			if (hmbLRptVDQpyXIqPZmGqffqbINZn == null)
			{
				return Guid.Empty;
			}
			return hmbLRptVDQpyXIqPZmGqffqbINZn.szwdzAdgBDnblVtMcMlNxxiJfiKv();
		}

		public Controller.Extension get_extension()
		{
			return ogMdsaKZkQjxEGFCXoBkLgxpgVaMA;
		}

		public void set_extension(Controller.Extension value)
		{
			ogMdsaKZkQjxEGFCXoBkLgxpgVaMA = value;
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			if (aOrdMAhcAYptcCdMyvRoICwQdqrh)
			{
				hmbLRptVDQpyXIqPZmGqffqbINZn.SrrBTGJIIXcgdBrOcLUYVBIlDnTuB(motorIndex, amount, false);
			}
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			if (aOrdMAhcAYptcCdMyvRoICwQdqrh)
			{
				hmbLRptVDQpyXIqPZmGqffqbINZn.SUxyEGqnLgWXCVkGQoEBZLPxZLLl();
			}
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public zxwyluHITgqyxtCvnCdvGZWCunpK(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			exrujPrkEvIQCtEYEDHlHQWdxKWj = P_0;
			dTyNtjfWFzcOloEdAjwAzxgRMkOp = -1;
			nsmtMUrJdvWBXELXLKPzJSVBLPqH = -1;
		}

		public void EfVAHwFxISjeScTaTCpBBlHIfCWFb()
		{
			aOqKAcNnkZNSPxfwlqFnshtLmDdr = MiscTools.CreateGuidHashSHA1(YxeceAxGshiAhWGXYcoEecTtThLKA + MBxgcTBytNuVXNFnxoNuHHmFfZgoB.ToProductGuid().ToString());
			eRlestibqXQhrVRnvvBEnGrTFfRVA = ntXfLbDUoccgpUFvlsONumkrVAbF;
			YGIoTnymCBeaBxdzXDBSOvFgODh = NlnadAdlHFsKoxVmNrTKBgGdNRJc + iKxbZQXqRzCeFnhmYaOAAxVzqbmsA * 8;
			fJpwvybVmWmSSFrkFqRuqcFjAFlg();
			puNjnpmfZMrUXhpXetFTNbMLqnsN = TClNllSNLXURMCDGnewfasllsAodA.hardwareMapIdentifier.guid;
			qgeQuOljAhyeWykcqyiEsPVRfaeBA = TClNllSNLXURMCDGnewfasllsAodA.controllerName;
			emRYwsZMDsEooDFICtnoNKwemxzU = ((puNjnpmfZMrUXhpXetFTNbMLqnsN == Guid.Empty) ? true : false);
			qtOYaUcIByelmgmWjCFCLjcHkybv = new float[eRlestibqXQhrVRnvvBEnGrTFfRVA];
			sooXDLLNJWiZkMKhlSyzixQJYglG = new float[YGIoTnymCBeaBxdzXDBSOvFgODh];
			HHLTDMczvaoGULnOJuPZwvNfGHiI = new bool[YGIoTnymCBeaBxdzXDBSOvFgODh];
			if (YGIoTnymCBeaBxdzXDBSOvFgODh > 0)
			{
				HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)TClNllSNLXURMCDGnewfasllsAodA.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						HHLTDMczvaoGULnOJuPZwvNfGHiI[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
					}
				}
			}
			Update();
		}

		public void ZPGlWSsCAwfBjjgRSCEkzvUkdVJBb(zxwyluHITgqyxtCvnCdvGZWCunpK P_0)
		{
			if (P_0 != null)
			{
				dTyNtjfWFzcOloEdAjwAzxgRMkOp = P_0.dTyNtjfWFzcOloEdAjwAzxgRMkOp;
				nsmtMUrJdvWBXELXLKPzJSVBLPqH = P_0.nsmtMUrJdvWBXELXLKPzJSVBLPqH;
				for (int i = 0; i < MathTools.Min(sooXDLLNJWiZkMKhlSyzixQJYglG.Length, P_0.sooXDLLNJWiZkMKhlSyzixQJYglG.Length); i++)
				{
					sooXDLLNJWiZkMKhlSyzixQJYglG[i] = P_0.sooXDLLNJWiZkMKhlSyzixQJYglG[i];
				}
				for (int j = 0; j < MathTools.Min(HHLTDMczvaoGULnOJuPZwvNfGHiI.Length, P_0.HHLTDMczvaoGULnOJuPZwvNfGHiI.Length); j++)
				{
					HHLTDMczvaoGULnOJuPZwvNfGHiI[j] = P_0.HHLTDMczvaoGULnOJuPZwvNfGHiI[j];
				}
				for (int k = 0; k < MathTools.Min(qtOYaUcIByelmgmWjCFCLjcHkybv.Length, P_0.qtOYaUcIByelmgmWjCFCLjcHkybv.Length); k++)
				{
					qtOYaUcIByelmgmWjCFCLjcHkybv[k] = P_0.qtOYaUcIByelmgmWjCFCLjcHkybv[k];
				}
				WgmeDbeKGWwkgGSuYMgnXdtUyjKDA = P_0.WgmeDbeKGWwkgGSuYMgnXdtUyjKDA;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			VfAYoSeSeXUjLQmHzELeblJyQvEK();
			VoIelePMrikxUdcXbabNdhCpHjwhA();
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (eRlestibqXQhrVRnvvBEnGrTFfRVA != dataUpdater.axisCount || YGIoTnymCBeaBxdzXDBSOvFgODh != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < eRlestibqXQhrVRnvvBEnGrTFfRVA; i++)
			{
				dataUpdater.axisValues[i] = qtOYaUcIByelmgmWjCFCLjcHkybv[i];
			}
			for (int j = 0; j < YGIoTnymCBeaBxdzXDBSOvFgODh; j++)
			{
				if (HHLTDMczvaoGULnOJuPZwvNfGHiI[j])
				{
					dataUpdater.buttonPressureValues[j] = sooXDLLNJWiZkMKhlSyzixQJYglG[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = sooXDLLNJWiZkMKhlSyzixQJYglG[j] > 0f;
				}
			}
			if (WgmeDbeKGWwkgGSuYMgnXdtUyjKDA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public int POrwpSXGrunJFWDrxbBKCIufFTAGA(zxwyluHITgqyxtCvnCdvGZWCunpK P_0)
		{
			if (P_0.nsmtMUrJdvWBXELXLKPzJSVBLPqH == nsmtMUrJdvWBXELXLKPzJSVBLPqH)
			{
				return 2;
			}
			if (ntXfLbDUoccgpUFvlsONumkrVAbF != P_0.ntXfLbDUoccgpUFvlsONumkrVAbF)
			{
				return 0;
			}
			if (NlnadAdlHFsKoxVmNrTKBgGdNRJc != P_0.NlnadAdlHFsKoxVmNrTKBgGdNRJc)
			{
				return 0;
			}
			if (iKxbZQXqRzCeFnhmYaOAAxVzqbmsA != P_0.iKxbZQXqRzCeFnhmYaOAAxVzqbmsA)
			{
				return 0;
			}
			if (P_0.fWDlgznFFpxukkfasIGRzXLdYzWo == fWDlgznFFpxukkfasIGRzXLdYzWo)
			{
				return 2;
			}
			if (P_0.aOqKAcNnkZNSPxfwlqFnshtLmDdr == aOqKAcNnkZNSPxfwlqFnshtLmDdr)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo ILAFJygJPwObOvZfhozTicyLAUqKA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			KMOMiFCZrQAMlvGNERYdmGqpJSyH(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			bFuKxJfRvCeyLgtLDaFIMabEwxau(bridgedController);
			return bridgedController;
		}

		BridgedController IInputManagerJoystick.ToBridgedController()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToBridgedController
			return this.ToBridgedController();
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(nsmtMUrJdvWBXELXLKPzJSVBLPqH);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void VfAYoSeSeXUjLQmHzELeblJyQvEK()
		{
			if (eRlestibqXQhrVRnvvBEnGrTFfRVA <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)TClNllSNLXURMCDGnewfasllsAodA.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					JgHbZghrvrDYrEJanhrZYGGzMrtJA(axes_orig[i], i);
				}
			}
		}

		private void VoIelePMrikxUdcXbabNdhCpHjwhA()
		{
			if (YGIoTnymCBeaBxdzXDBSOvFgODh <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)TClNllSNLXURMCDGnewfasllsAodA.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					ANmsyiEoZHUKBADfxcuCBlFJuaPK(buttons_orig[i], i);
				}
			}
		}

		private void JgHbZghrvrDYrEJanhrZYGGzMrtJA(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0, int P_1)
		{
			if (P_1 >= eRlestibqXQhrVRnvvBEnGrTFfRVA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			qtOYaUcIByelmgmWjCFCLjcHkybv[P_1] = ActFgfWdhGxZotxHWsGjRZmPokVI(P_0);
			if (!WgmeDbeKGWwkgGSuYMgnXdtUyjKDA && qtOYaUcIByelmgmWjCFCLjcHkybv[P_1] != 0f)
			{
				WgmeDbeKGWwkgGSuYMgnXdtUyjKDA = true;
			}
		}

		private void ANmsyiEoZHUKBADfxcuCBlFJuaPK(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0, int P_1)
		{
			if (P_1 >= YGIoTnymCBeaBxdzXDBSOvFgODh)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			sooXDLLNJWiZkMKhlSyzixQJYglG[P_1] = KqjszPIVpcRpBqVYQQcXTfDgOmbi(P_0);
			if (!WgmeDbeKGWwkgGSuYMgnXdtUyjKDA && sooXDLLNJWiZkMKhlSyzixQJYglG[P_1] != 0f)
			{
				WgmeDbeKGWwkgGSuYMgnXdtUyjKDA = true;
			}
		}

		private float ActFgfWdhGxZotxHWsGjRZmPokVI(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				return tCvdSGzhIVavFjZJDOxJGETMKNZj(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= NlnadAdlHFsKoxVmNrTKBgGdNRJc || sourceButton >= 256)
				{
					return 0f;
				}
				if (!hmbLRptVDQpyXIqPZmGqffqbINZn.GnbwfcucWaKKiAuCJahZUbTHosRN(sourceButton))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= iKxbZQXqRzCeFnhmYaOAAxVzqbmsA || sourceHat >= 4)
				{
					return 0f;
				}
				int num = hmbLRptVDQpyXIqPZmGqffqbINZn.NpWNXdXiiiREyyiIpKbBHWMiPrCP(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = WeeAFxUsIrWJmyurgvNVnXXNgwDK(num, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num2 = WeeAFxUsIrWJmyurgvNVnXXNgwDK(num, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				if (P_0.invert)
				{
					num2 *= -1f;
				}
				return num2;
			}
			return 0f;
		}

		private float tCvdSGzhIVavFjZJDOxJGETMKNZj(int P_0)
		{
			if (P_0 < 0 || P_0 >= hmbLRptVDQpyXIqPZmGqffqbINZn.fftWaBPxOaUmlXCeUhZVtPVZotqI())
			{
				return 0f;
			}
			return hmbLRptVDQpyXIqPZmGqffqbINZn.gvUyyMddcqKXjxdwwuGwPpjaljGP(P_0);
		}

		private float KqjszPIVpcRpBqVYQQcXTfDgOmbi(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0)
		{
			if (P_0.sourceType == 0)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (hmbLRptVDQpyXIqPZmGqffqbINZn.GnbwfcucWaKKiAuCJahZUbTHosRN(P_0.ignoreIfButtonsActiveButtons[i]))
						{
							return 0f;
						}
					}
				}
				if (P_0.requireMultipleButtons)
				{
					bool flag = false;
					for (int j = 0; j < P_0.requiredButtons.Length; j++)
					{
						if (!hmbLRptVDQpyXIqPZmGqffqbINZn.GnbwfcucWaKKiAuCJahZUbTHosRN(P_0.requiredButtons[j]))
						{
							return 0f;
						}
						flag = true;
					}
					if (flag)
					{
						return 1f;
					}
					return 0f;
				}
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= NlnadAdlHFsKoxVmNrTKBgGdNRJc || sourceButton >= 256)
				{
					return 0f;
				}
				if (!hmbLRptVDQpyXIqPZmGqffqbINZn.GnbwfcucWaKKiAuCJahZUbTHosRN(sourceButton))
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				float num = tCvdSGzhIVavFjZJDOxJGETMKNZj(sourceAxis);
				float num2 = MathTools.Abs(num);
				if (num2 <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return 0f;
					}
				}
				else if (num > 0f)
				{
					return 0f;
				}
				return num2;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= iKxbZQXqRzCeFnhmYaOAAxVzqbmsA || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return uEmJCosOBPcorbERxsQODJfXcsPZ(hmbLRptVDQpyXIqPZmGqffqbINZn.NpWNXdXiiiREyyiIpKbBHWMiPrCP(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return uEmJCosOBPcorbERxsQODJfXcsPZ(hmbLRptVDQpyXIqPZmGqffqbINZn.NpWNXdXiiiREyyiIpKbBHWMiPrCP(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return uEmJCosOBPcorbERxsQODJfXcsPZ(hmbLRptVDQpyXIqPZmGqffqbINZn.NpWNXdXiiiREyyiIpKbBHWMiPrCP(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return uEmJCosOBPcorbERxsQODJfXcsPZ(hmbLRptVDQpyXIqPZmGqffqbINZn.NpWNXdXiiiREyyiIpKbBHWMiPrCP(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return uEmJCosOBPcorbERxsQODJfXcsPZ(hmbLRptVDQpyXIqPZmGqffqbINZn.NpWNXdXiiiREyyiIpKbBHWMiPrCP(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return uEmJCosOBPcorbERxsQODJfXcsPZ(hmbLRptVDQpyXIqPZmGqffqbINZn.NpWNXdXiiiREyyiIpKbBHWMiPrCP(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return uEmJCosOBPcorbERxsQODJfXcsPZ(hmbLRptVDQpyXIqPZmGqffqbINZn.NpWNXdXiiiREyyiIpKbBHWMiPrCP(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return uEmJCosOBPcorbERxsQODJfXcsPZ(hmbLRptVDQpyXIqPZmGqffqbINZn.NpWNXdXiiiREyyiIpKbBHWMiPrCP(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return 0f;
		}

		private float uEmJCosOBPcorbERxsQODJfXcsPZ(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (TClNllSNLXURMCDGnewfasllsAodA.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return 0f;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return 0f;
			}
			int num2;
			int num3;
			if (P_2 == HatType.EightWay)
			{
				num2 = 31500;
				num3 = 4500;
			}
			else
			{
				num2 = 27000;
				num3 = 9000;
			}
			if (P_1 == 0 && P_0 > num2)
			{
				P_0 -= 36000;
			}
			if (P_0 < num + num3 && P_0 > num - num3)
			{
				return 1f;
			}
			return 0f;
		}

		private float WeeAFxUsIrWJmyurgvNVnXXNgwDK(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 > 27000 || P_0 < 9000)
				{
					return 1f;
				}
				if (P_0 < 27000 && P_0 > 9000)
				{
					return -1f;
				}
				return 0f;
			}
			if (P_0 > 0 && P_0 < 18000)
			{
				return 1f;
			}
			if (P_0 > 18000)
			{
				return -1f;
			}
			return 0f;
		}

		private void fJpwvybVmWmSSFrkFqRuqcFjAFlg()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = ILAFJygJPwObOvZfhozTicyLAUqKA();
			TClNllSNLXURMCDGnewfasllsAodA = exrujPrkEvIQCtEYEDHlHQWdxKWj(bridgedControllerHWInfo);
			bool flag = false;
			bool flag2 = false;
			if (TClNllSNLXURMCDGnewfasllsAodA == null || TClNllSNLXURMCDGnewfasllsAodA.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
			{
				if (hmbLRptVDQpyXIqPZmGqffqbINZn.TAASLlaeKtyyBjLUMQmhYXdNbFph())
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(4607, 10462);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					TClNllSNLXURMCDGnewfasllsAodA = exrujPrkEvIQCtEYEDHlHQWdxKWj(bridgedControllerHWInfo);
					flag2 = true;
				}
				if (TClNllSNLXURMCDGnewfasllsAodA == null || TClNllSNLXURMCDGnewfasllsAodA.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(736, 1118);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					bridgedControllerHWInfo.definitionMatchTag = string.Empty;
					TClNllSNLXURMCDGnewfasllsAodA = exrujPrkEvIQCtEYEDHlHQWdxKWj(bridgedControllerHWInfo);
					flag = true;
				}
			}
			if (TClNllSNLXURMCDGnewfasllsAodA == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (flag)
			{
				string text = string.Format("{0}:{1}", hmbLRptVDQpyXIqPZmGqffqbINZn.hHlgCDjMNCWLvUrtCbYKwUcrWpcn().vendorId.ToString("x4"), hmbLRptVDQpyXIqPZmGqffqbINZn.hHlgCDjMNCWLvUrtCbYKwUcrWpcn().productId.ToString("x4"));
				string key = LocalizationManager.AppendToKeyAsPath("windows_gaming_input_gamepad", text);
				TClNllSNLXURMCDGnewfasllsAodA.deviceLocalizationInfo.InsertParentKey(0, key);
				TClNllSNLXURMCDGnewfasllsAodA.deviceLocalizationInfo.InsertParentKey(1, "windows_gaming_input_gamepad");
				TClNllSNLXURMCDGnewfasllsAodA.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text}]";
			}
			else if (hmbLRptVDQpyXIqPZmGqffqbINZn.TAASLlaeKtyyBjLUMQmhYXdNbFph() && (flag2 || TClNllSNLXURMCDGnewfasllsAodA.hardwareMapIdentifier.guid == Consts.joystickGuid_steamController))
			{
				string text2 = string.Format("{0}:{1}", hmbLRptVDQpyXIqPZmGqffqbINZn.hHlgCDjMNCWLvUrtCbYKwUcrWpcn().vendorId.ToString("x4"), hmbLRptVDQpyXIqPZmGqffqbINZn.hHlgCDjMNCWLvUrtCbYKwUcrWpcn().productId.ToString("x4"));
				string key2 = LocalizationManager.AppendToKeyAsPath((TClNllSNLXURMCDGnewfasllsAodA.deviceLocalizationInfo.parentKeys.get_Count() > 0 && !string.IsNullOrEmpty(TClNllSNLXURMCDGnewfasllsAodA.deviceLocalizationInfo.parentKeys.get_Item(0))) ? TClNllSNLXURMCDGnewfasllsAodA.deviceLocalizationInfo.parentKeys.get_Item(0) : "steam_controller", text2);
				TClNllSNLXURMCDGnewfasllsAodA.deviceLocalizationInfo.InsertParentKey(0, key2);
				TClNllSNLXURMCDGnewfasllsAodA.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
			}
			eRlestibqXQhrVRnvvBEnGrTFfRVA = TClNllSNLXURMCDGnewfasllsAodA.axisCount;
			YGIoTnymCBeaBxdzXDBSOvFgODh = TClNllSNLXURMCDGnewfasllsAodA.buttonCount;
		}

		private string jqRALeyVObkRdbUIUmXFqswThYtm()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.WindowsGamingInput}{hmbLRptVDQpyXIqPZmGqffqbINZn.KRRKBFVIVgyjSpRuqlaaKloYnnWr()}{YxeceAxGshiAhWGXYcoEecTtThLKA}{MBxgcTBytNuVXNFnxoNuHHmFfZgoB.ToString()}");
		}

		private void KMOMiFCZrQAMlvGNERYdmGqpJSyH(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.WindowsGamingInput;
			P_0.inputSource = hmbLRptVDQpyXIqPZmGqffqbINZn.yqTEOtVSVvsbwLsvQJMYOJAeKzNR();
			P_0.deviceType = (ControlDeviceType)hmbLRptVDQpyXIqPZmGqffqbINZn.KRRKBFVIVgyjSpRuqlaaKloYnnWr();
			P_0.hardwareIdentifier = jqRALeyVObkRdbUIUmXFqswThYtm();
			P_0.hardwareAxisCount = ntXfLbDUoccgpUFvlsONumkrVAbF;
			P_0.hardwareButtonCount = NlnadAdlHFsKoxVmNrTKBgGdNRJc;
			P_0.hardwareHatCount = iKxbZQXqRzCeFnhmYaOAAxVzqbmsA;
			if (hmbLRptVDQpyXIqPZmGqffqbINZn.TAASLlaeKtyyBjLUMQmhYXdNbFph())
			{
				P_0.definitionMatchTag = "[STEAMCONFIGURED]";
			}
			P_0.hw_productName = YxeceAxGshiAhWGXYcoEecTtThLKA;
			P_0.hw_deviceGuid = fWDlgznFFpxukkfasIGRzXLdYzWo;
			P_0.hw_productId = MBxgcTBytNuVXNFnxoNuHHmFfZgoB.productId;
			P_0.hw_vendorId = MBxgcTBytNuVXNFnxoNuHHmFfZgoB.vendorId;
			P_0.hw_pidVid = MBxgcTBytNuVXNFnxoNuHHmFfZgoB;
			P_0.hw_isBluetoothDevice = false;
			P_0.hw_bluetoothDeviceName = YxeceAxGshiAhWGXYcoEecTtThLKA;
			P_0.hw_supportsVibration = aOrdMAhcAYptcCdMyvRoICwQdqrh;
			P_0.hw_localVibrationMotorCount = pYkALoKgbTJkEivkEvJmPCaFBZyub;
		}

		private void bFuKxJfRvCeyLgtLDaFIMabEwxau(BridgedController P_0)
		{
			KMOMiFCZrQAMlvGNERYdmGqpJSyH(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = TClNllSNLXURMCDGnewfasllsAodA.ToGameHardwareControllerMap();
			P_0.instanceName = vaFZzEyAotphaBCOfGdKtYuTfHHj;
			P_0.productName = YxeceAxGshiAhWGXYcoEecTtThLKA;
			P_0.axisCount = eRlestibqXQhrVRnvvBEnGrTFfRVA;
			P_0.buttonCount = YGIoTnymCBeaBxdzXDBSOvFgODh;
			P_0.isButtonPressureSensitive = new bool[YGIoTnymCBeaBxdzXDBSOvFgODh];
			Array.Copy(HHLTDMczvaoGULnOJuPZwvNfGHiI, P_0.isButtonPressureSensitive, YGIoTnymCBeaBxdzXDBSOvFgODh);
			P_0.unknownControllerHats = QybtFXPDhkAfMBLosgkBehoHqAjiB();
			P_0.controllerTypeGuid = puNjnpmfZMrUXhpXetFTNbMLqnsN;
			P_0.controllerExtension = get_extension();
		}

		private void pzADYTHZkoIfxSguiJTgSrajhVNRA()
		{
			for (int i = 0; i < YGIoTnymCBeaBxdzXDBSOvFgODh; i++)
			{
				sooXDLLNJWiZkMKhlSyzixQJYglG[i] = 0f;
			}
			for (int j = 0; j < eRlestibqXQhrVRnvvBEnGrTFfRVA; j++)
			{
				qtOYaUcIByelmgmWjCFCLjcHkybv[j] = 0f;
			}
		}

		private UnknownControllerHat[] QybtFXPDhkAfMBLosgkBehoHqAjiB()
		{
			if (!emRYwsZMDsEooDFICtnoNKwemxzU)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			for (int i = 0; i < 2; i++)
			{
				int num = 128 + i * 8;
				UnknownControllerHat.HatButtons hatButtons = new UnknownControllerHat.HatButtons(new int[8]
				{
					num,
					num + 1,
					num + 2,
					num + 3,
					num + 4,
					num + 5,
					num + 6,
					num + 7
				});
				array[i] = new UnknownControllerHat(hatButtons);
			}
			return array;
		}

		public void Dispose()
		{
			pEIAApowvaIVyxiYdwXmjouMCOjh(true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		protected virtual void eRAHQWpCYIIcveZziCfOJuJQUtPI()
		{
			try
			{
				pEIAApowvaIVyxiYdwXmjouMCOjh(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void pEIAApowvaIVyxiYdwXmjouMCOjh(bool P_0)
		{
			if (!uGgUTxGlvBPBEZdNStSSSuJESpAT)
			{
				if (P_0 && hmbLRptVDQpyXIqPZmGqffqbINZn != null)
				{
					hmbLRptVDQpyXIqPZmGqffqbINZn.Dispose();
				}
				uGgUTxGlvBPBEZdNStSSSuJESpAT = true;
			}
		}

		public static int PDVWuKEkblbguZhZZmcCKUjeIHBN(zxwyluHITgqyxtCvnCdvGZWCunpK P_0, zxwyluHITgqyxtCvnCdvGZWCunpK P_1)
		{
			if (P_0.dTyNtjfWFzcOloEdAjwAzxgRMkOp < P_1.dTyNtjfWFzcOloEdAjwAzxgRMkOp)
			{
				return -1;
			}
			if (P_0.dTyNtjfWFzcOloEdAjwAzxgRMkOp > P_1.dTyNtjfWFzcOloEdAjwAzxgRMkOp)
			{
				return 1;
			}
			return 0;
		}

		public static int cIQooDftINFCXrmpAgvhtKYpRXVR(zxwyluHITgqyxtCvnCdvGZWCunpK P_0, zxwyluHITgqyxtCvnCdvGZWCunpK P_1)
		{
			if (P_0.gybRdKpAJwQUfRJlGpcuVOllfdCHA < P_1.gybRdKpAJwQUfRJlGpcuVOllfdCHA)
			{
				return -1;
			}
			if (P_0.gybRdKpAJwQUfRJlGpcuVOllfdCHA > P_1.gybRdKpAJwQUfRJlGpcuVOllfdCHA)
			{
				return 1;
			}
			return 0;
		}
	}

	private class FNATBfLINfbNNureCHcgYiGhewkAA
	{
		public enum zyZVgDGfYCpAYXZvIqYJMudqSYLh
		{
			Exact = 0,
			Approximate = 1
		}

		public class PKzKyiKQiIOGfaQUlfKeBYyjKdMhA
		{
			public int UfIMVLsVqiNqLdYLlvdXGlZJaOKJA;

			public Guid PPPoohwECFGegwgFuzPiHScXSCUy;

			public Guid bFZULiFgdwIcmHBftVHRNXbtwUQR;

			public int CncxqPSejtEjQedTTqtYwwyHRVfCA;

			public int bRVinUTAxALsIXTgbojBSdGgFPmFA;

			public int XJyBwahnfLkBjCNJRoBxnmehkejB;

			public int iCerYSGqfeUjEurFJTPJrShUVInK;

			public int FKkAoDoDENjclfqVWAUnIHToULuw;

			public int VVeBkJQoCcbijcBlZHBtjnmFYIYyB;

			public bool pUMhumCKlrvxACjmqrefykNLTpZR(zxwyluHITgqyxtCvnCdvGZWCunpK P_0, zyZVgDGfYCpAYXZvIqYJMudqSYLh P_1)
			{
				if (bRVinUTAxALsIXTgbojBSdGgFPmFA != P_0.ntXfLbDUoccgpUFvlsONumkrVAbF)
				{
					return false;
				}
				if (XJyBwahnfLkBjCNJRoBxnmehkejB != P_0.NlnadAdlHFsKoxVmNrTKBgGdNRJc)
				{
					return false;
				}
				if (iCerYSGqfeUjEurFJTPJrShUVInK != P_0.iKxbZQXqRzCeFnhmYaOAAxVzqbmsA)
				{
					return false;
				}
				if (FKkAoDoDENjclfqVWAUnIHToULuw != P_0.YGIoTnymCBeaBxdzXDBSOvFgODh)
				{
					return false;
				}
				if (VVeBkJQoCcbijcBlZHBtjnmFYIYyB != P_0.eRlestibqXQhrVRnvvBEnGrTFfRVA)
				{
					return false;
				}
				if (P_0.get_rewiredId() == UfIMVLsVqiNqLdYLlvdXGlZJaOKJA)
				{
					return true;
				}
				return P_1 switch
				{
					zyZVgDGfYCpAYXZvIqYJMudqSYLh.Exact => PPPoohwECFGegwgFuzPiHScXSCUy == P_0.fWDlgznFFpxukkfasIGRzXLdYzWo, 
					zyZVgDGfYCpAYXZvIqYJMudqSYLh.Approximate => bFZULiFgdwIcmHBftVHRNXbtwUQR == P_0.aOqKAcNnkZNSPxfwlqFnshtLmDdr, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class xYMAwvtYHywfyUwXLYtGGsoxoWv : IEnumerable<PKzKyiKQiIOGfaQUlfKeBYyjKdMhA>, IEnumerable, IEnumerator<PKzKyiKQiIOGfaQUlfKeBYyjKdMhA>, IEnumerator, IDisposable
		{
			private int OmEepAUGLZkGRsdRpoCmumxiVhok;

			private PKzKyiKQiIOGfaQUlfKeBYyjKdMhA nDhYGMqKGnefebdntjudQoLydeFe;

			private int wiMsDmVBYgxANfyKMwvSLZPEZaLd;

			public FNATBfLINfbNNureCHcgYiGhewkAA JnMdQjCuPHlQEMvFUAZuqukTdZZS;

			private zxwyluHITgqyxtCvnCdvGZWCunpK VUPhLyMVgbebmYGqIUZvSZOubdMi;

			public zxwyluHITgqyxtCvnCdvGZWCunpK qJlNDitjZDcusYWdVDtIAxuiyrcp;

			private zyZVgDGfYCpAYXZvIqYJMudqSYLh qJoxgpMXVwuaiVqBzjIIIHIWjwCO;

			public zyZVgDGfYCpAYXZvIqYJMudqSYLh DVlFieUNfkghHLuAwaYpYbEoiEvCA;

			private int XXBDTBvGUZAsedjSvjBLVSSuJATSA;

			private int HxSukISWZpBDULLTugbmHkRfLvFFA;

			PKzKyiKQiIOGfaQUlfKeBYyjKdMhA IEnumerator<PKzKyiKQiIOGfaQUlfKeBYyjKdMhA>.Current
			{
				[DebuggerHidden]
				get
				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRewired_002EPlatforms_002EMicrosoft_002EWindowsGamingInput_002EWGIInputManager_002EJoystickRecords_002ERecord_003E_002Eget_Current();
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return nDhYGMqKGnefebdntjudQoLydeFe;
				}
			}

			[DebuggerHidden]
			public xYMAwvtYHywfyUwXLYtGGsoxoWv(int P_0)
			{
				OmEepAUGLZkGRsdRpoCmumxiVhok = P_0;
				wiMsDmVBYgxANfyKMwvSLZPEZaLd = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int omEepAUGLZkGRsdRpoCmumxiVhok = OmEepAUGLZkGRsdRpoCmumxiVhok;
				FNATBfLINfbNNureCHcgYiGhewkAA jnMdQjCuPHlQEMvFUAZuqukTdZZS = JnMdQjCuPHlQEMvFUAZuqukTdZZS;
				if (omEepAUGLZkGRsdRpoCmumxiVhok != 0)
				{
					if (omEepAUGLZkGRsdRpoCmumxiVhok != 1)
					{
						return false;
					}
					OmEepAUGLZkGRsdRpoCmumxiVhok = -1;
					goto IL_0083;
				}
				OmEepAUGLZkGRsdRpoCmumxiVhok = -1;
				XXBDTBvGUZAsedjSvjBLVSSuJATSA = jnMdQjCuPHlQEMvFUAZuqukTdZZS.jCqRlbEePmNOsHbPJJozMopApOWM.Count;
				HxSukISWZpBDULLTugbmHkRfLvFFA = 0;
				goto IL_0093;
				IL_0083:
				HxSukISWZpBDULLTugbmHkRfLvFFA++;
				goto IL_0093;
				IL_0093:
				if (HxSukISWZpBDULLTugbmHkRfLvFFA < XXBDTBvGUZAsedjSvjBLVSSuJATSA)
				{
					if (jnMdQjCuPHlQEMvFUAZuqukTdZZS.jCqRlbEePmNOsHbPJJozMopApOWM[HxSukISWZpBDULLTugbmHkRfLvFFA].pUMhumCKlrvxACjmqrefykNLTpZR(VUPhLyMVgbebmYGqIUZvSZOubdMi, qJoxgpMXVwuaiVqBzjIIIHIWjwCO))
					{
						nDhYGMqKGnefebdntjudQoLydeFe = jnMdQjCuPHlQEMvFUAZuqukTdZZS.jCqRlbEePmNOsHbPJJozMopApOWM[HxSukISWZpBDULLTugbmHkRfLvFFA];
						OmEepAUGLZkGRsdRpoCmumxiVhok = 1;
						return true;
					}
					goto IL_0083;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private PKzKyiKQiIOGfaQUlfKeBYyjKdMhA System_002ECollections_002EGeneric_002EIEnumerator_003CRewired_002EPlatforms_002EMicrosoft_002EWindowsGamingInput_002EWGIInputManager_002EJoystickRecords_002ERecord_003E_002Eget_Current()
			{
				return nDhYGMqKGnefebdntjudQoLydeFe;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<PKzKyiKQiIOGfaQUlfKeBYyjKdMhA> IEnumerable<PKzKyiKQiIOGfaQUlfKeBYyjKdMhA>.GetEnumerator()
			{
				xYMAwvtYHywfyUwXLYtGGsoxoWv xYMAwvtYHywfyUwXLYtGGsoxoWv2;
				if (OmEepAUGLZkGRsdRpoCmumxiVhok == -2 && wiMsDmVBYgxANfyKMwvSLZPEZaLd == Environment.CurrentManagedThreadId)
				{
					OmEepAUGLZkGRsdRpoCmumxiVhok = 0;
					xYMAwvtYHywfyUwXLYtGGsoxoWv2 = this;
				}
				else
				{
					xYMAwvtYHywfyUwXLYtGGsoxoWv2 = new xYMAwvtYHywfyUwXLYtGGsoxoWv(0);
					xYMAwvtYHywfyUwXLYtGGsoxoWv2.JnMdQjCuPHlQEMvFUAZuqukTdZZS = JnMdQjCuPHlQEMvFUAZuqukTdZZS;
				}
				xYMAwvtYHywfyUwXLYtGGsoxoWv2.VUPhLyMVgbebmYGqIUZvSZOubdMi = qJlNDitjZDcusYWdVDtIAxuiyrcp;
				xYMAwvtYHywfyUwXLYtGGsoxoWv2.qJoxgpMXVwuaiVqBzjIIIHIWjwCO = DVlFieUNfkghHLuAwaYpYbEoiEvCA;
				return xYMAwvtYHywfyUwXLYtGGsoxoWv2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<PKzKyiKQiIOGfaQUlfKeBYyjKdMhA>)this).GetEnumerator();
			}
		}

		private List<PKzKyiKQiIOGfaQUlfKeBYyjKdMhA> jCqRlbEePmNOsHbPJJozMopApOWM;

		public FNATBfLINfbNNureCHcgYiGhewkAA()
		{
			jCqRlbEePmNOsHbPJJozMopApOWM = new List<PKzKyiKQiIOGfaQUlfKeBYyjKdMhA>();
		}

		public void OtyfPNQYEXSswqtQRffeJDITIMrhA(zxwyluHITgqyxtCvnCdvGZWCunpK P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = jCqRlbEePmNOsHbPJJozMopApOWM.Count;
			for (int i = 0; i < count; i++)
			{
				if (jCqRlbEePmNOsHbPJJozMopApOWM[i].pUMhumCKlrvxACjmqrefykNLTpZR(P_0, zyZVgDGfYCpAYXZvIqYJMudqSYLh.Exact))
				{
					jCqRlbEePmNOsHbPJJozMopApOWM[i].UfIMVLsVqiNqLdYLlvdXGlZJaOKJA = P_0.get_rewiredId();
					jCqRlbEePmNOsHbPJJozMopApOWM[i].PPPoohwECFGegwgFuzPiHScXSCUy = P_0.fWDlgznFFpxukkfasIGRzXLdYzWo;
					jCqRlbEePmNOsHbPJJozMopApOWM[i].bFZULiFgdwIcmHBftVHRNXbtwUQR = P_0.aOqKAcNnkZNSPxfwlqFnshtLmDdr;
					jCqRlbEePmNOsHbPJJozMopApOWM[i].CncxqPSejtEjQedTTqtYwwyHRVfCA = P_0.get_inputManagerId();
					jCqRlbEePmNOsHbPJJozMopApOWM[i].bRVinUTAxALsIXTgbojBSdGgFPmFA = P_0.ntXfLbDUoccgpUFvlsONumkrVAbF;
					jCqRlbEePmNOsHbPJJozMopApOWM[i].XJyBwahnfLkBjCNJRoBxnmehkejB = P_0.NlnadAdlHFsKoxVmNrTKBgGdNRJc;
					jCqRlbEePmNOsHbPJJozMopApOWM[i].iCerYSGqfeUjEurFJTPJrShUVInK = P_0.iKxbZQXqRzCeFnhmYaOAAxVzqbmsA;
					jCqRlbEePmNOsHbPJJozMopApOWM[i].FKkAoDoDENjclfqVWAUnIHToULuw = P_0.YGIoTnymCBeaBxdzXDBSOvFgODh;
					jCqRlbEePmNOsHbPJJozMopApOWM[i].VVeBkJQoCcbijcBlZHBtjnmFYIYyB = P_0.eRlestibqXQhrVRnvvBEnGrTFfRVA;
					vDUudRgFtbqBZeOhBgKdIqwhNlZCb(P_0.get_rewiredId(), P_0.fWDlgznFFpxukkfasIGRzXLdYzWo, i);
					return;
				}
			}
			jCqRlbEePmNOsHbPJJozMopApOWM.Add(new PKzKyiKQiIOGfaQUlfKeBYyjKdMhA
			{
				UfIMVLsVqiNqLdYLlvdXGlZJaOKJA = P_0.get_rewiredId(),
				PPPoohwECFGegwgFuzPiHScXSCUy = P_0.fWDlgznFFpxukkfasIGRzXLdYzWo,
				bFZULiFgdwIcmHBftVHRNXbtwUQR = P_0.aOqKAcNnkZNSPxfwlqFnshtLmDdr,
				CncxqPSejtEjQedTTqtYwwyHRVfCA = P_0.get_inputManagerId(),
				bRVinUTAxALsIXTgbojBSdGgFPmFA = P_0.ntXfLbDUoccgpUFvlsONumkrVAbF,
				XJyBwahnfLkBjCNJRoBxnmehkejB = P_0.NlnadAdlHFsKoxVmNrTKBgGdNRJc,
				iCerYSGqfeUjEurFJTPJrShUVInK = P_0.iKxbZQXqRzCeFnhmYaOAAxVzqbmsA,
				FKkAoDoDENjclfqVWAUnIHToULuw = P_0.YGIoTnymCBeaBxdzXDBSOvFgODh,
				VVeBkJQoCcbijcBlZHBtjnmFYIYyB = P_0.eRlestibqXQhrVRnvvBEnGrTFfRVA
			});
			vDUudRgFtbqBZeOhBgKdIqwhNlZCb(P_0.get_rewiredId(), P_0.fWDlgznFFpxukkfasIGRzXLdYzWo, jCqRlbEePmNOsHbPJJozMopApOWM.Count - 1);
		}

		public bool VfkLTcSnXypMbjNzQSqMwRwJESfu(zxwyluHITgqyxtCvnCdvGZWCunpK P_0, zyZVgDGfYCpAYXZvIqYJMudqSYLh P_1)
		{
			int count = jCqRlbEePmNOsHbPJJozMopApOWM.Count;
			for (int i = 0; i < count; i++)
			{
				if (jCqRlbEePmNOsHbPJJozMopApOWM[i].pUMhumCKlrvxACjmqrefykNLTpZR(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(xYMAwvtYHywfyUwXLYtGGsoxoWv))]
		public IEnumerable<PKzKyiKQiIOGfaQUlfKeBYyjKdMhA> VNIUTknAUDtoWmfSzxnbDHQIYYKn(zxwyluHITgqyxtCvnCdvGZWCunpK P_0, zyZVgDGfYCpAYXZvIqYJMudqSYLh P_1)
		{
			return new xYMAwvtYHywfyUwXLYtGGsoxoWv(-2)
			{
				JnMdQjCuPHlQEMvFUAZuqukTdZZS = this,
				qJlNDitjZDcusYWdVDtIAxuiyrcp = P_0,
				DVlFieUNfkghHLuAwaYpYbEoiEvCA = P_1
			};
		}

		private void vDUudRgFtbqBZeOhBgKdIqwhNlZCb(int P_0, Guid P_1, int P_2)
		{
			for (int num = jCqRlbEePmNOsHbPJJozMopApOWM.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (jCqRlbEePmNOsHbPJJozMopApOWM[num].UfIMVLsVqiNqLdYLlvdXGlZJaOKJA == P_0 || jCqRlbEePmNOsHbPJJozMopApOWM[num].PPPoohwECFGegwgFuzPiHScXSCUy == P_1))
				{
					jCqRlbEePmNOsHbPJJozMopApOWM.RemoveAt(num);
				}
			}
		}
	}

	private const bool vULhUNCbDxcjavPLUSRjeoDZvEaN = true;

	private CDFdkvFBdhpJKCvjcfqyKaRxbGbg JGOEatxUyVWjwLPbRHEwtnJGVdSM;

	private List<zxwyluHITgqyxtCvnCdvGZWCunpK> SPvpuJNePVgQPlPlMtDBBHHDtxVo;

	private int GdghqKKKtROnFQMbSMTdhABkkZlQA;

	private FNATBfLINfbNNureCHcgYiGhewkAA ELJEKXGoXBnFdpjYSrOvsbzqwAgs;

	private bool XJbowZhHPavAQMlYerveWgSdbLTZ;

	private ConfigVars aCeKjYkbPCnSFXySBRYPoOhLaivU;

	private Action<int, ControllerDataUpdater> lOfLaxagRepxSsaIRTlBCofpzCEI;

	private PlatformInputManager LwKUdNIHGOhjlaeVEtvqFFmkLKXD;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> jGppkJBMElISdhDZvQuTiuOQwLqJA;

	private readonly Func<int> WPiYKtyxWSoshgGKxVcIoApPBaUf;

	private Func<PidVid, bool> MFWJPWlRwehnBLRmBKoZBcBeZTEY;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => get_deviceCount();

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => get_primaryInputManager();

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => get_inputSource();

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => get_inputSourceType();

	protected CDFdkvFBdhpJKCvjcfqyKaRxbGbg GziOEBZcHWWglqrSmlKQusgylhWC => IyRyYVHjOpgYsOzJtXPUaFJtHeqO();

	public RoXnCERaTomklOPNkqRTLMSpmDGn(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, Func<PidVid, bool> P_3)
	{
		try
		{
			aCeKjYkbPCnSFXySBRYPoOhLaivU = P_0;
			jGppkJBMElISdhDZvQuTiuOQwLqJA = P_1;
			WPiYKtyxWSoshgGKxVcIoApPBaUf = P_2;
			MFWJPWlRwehnBLRmBKoZBcBeZTEY = P_3;
			LwKUdNIHGOhjlaeVEtvqFFmkLKXD = this;
			JGOEatxUyVWjwLPbRHEwtnJGVdSM = new CDFdkvFBdhpJKCvjcfqyKaRxbGbg(P_0, true, false, false);
			JGOEatxUyVWjwLPbRHEwtnJGVdSM.add_DeviceChangedEvent(SystemDeviceConnected);
			lOfLaxagRepxSsaIRTlBCofpzCEI = UpdateControllerData;
		}
		catch (Exception)
		{
			OnDestroy();
			throw;
		}
	}

	public virtual int get_deviceCount()
	{
		return GdghqKKKtROnFQMbSMTdhABkkZlQA;
	}

	public virtual PlatformInputManager get_primaryInputManager()
	{
		return LwKUdNIHGOhjlaeVEtvqFFmkLKXD;
	}

	public virtual IInputSource get_inputSource()
	{
		return JGOEatxUyVWjwLPbRHEwtnJGVdSM;
	}

	public virtual InputSource get_inputSourceType()
	{
		return InputSource.WindowsGamingInput;
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		ELJEKXGoXBnFdpjYSrOvsbzqwAgs = new FNATBfLINfbNNureCHcgYiGhewkAA();
		JGOEatxUyVWjwLPbRHEwtnJGVdSM.BHFphUSqDVtWvQOCItKDuaOqebfCA();
		OwHnOzpydJkKXqNxdFgrElJKStIBA();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (JGOEatxUyVWjwLPbRHEwtnJGVdSM != null)
		{
			JGOEatxUyVWjwLPbRHEwtnJGVdSM.Update();
		}
		if (XJbowZhHPavAQMlYerveWgSdbLTZ)
		{
			REfJCYXCIoPqLGyLYMqLUBvlOtDA();
		}
		if (JGOEatxUyVWjwLPbRHEwtnJGVdSM != null)
		{
			JGOEatxUyVWjwLPbRHEwtnJGVdSM.UpdateDevices(updateLoop);
		}
		WxtEnVHQZydIWAxiJcmQyXInQXiPA();
		if (JGOEatxUyVWjwLPbRHEwtnJGVdSM != null)
		{
			JGOEatxUyVWjwLPbRHEwtnJGVdSM.UpdateFinished();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (SPvpuJNePVgQPlPlMtDBBHHDtxVo != null)
		{
			int count = SPvpuJNePVgQPlPlMtDBBHHDtxVo.Count;
			for (int i = 0; i < count; i++)
			{
				if (SPvpuJNePVgQPlPlMtDBBHHDtxVo[i] != null)
				{
					SPvpuJNePVgQPlPlMtDBBHHDtxVo[i].Dispose();
				}
			}
		}
		if (JGOEatxUyVWjwLPbRHEwtnJGVdSM != null)
		{
			JGOEatxUyVWjwLPbRHEwtnJGVdSM.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return lOfLaxagRepxSsaIRTlBCofpzCEI;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < GdghqKKKtROnFQMbSMTdhABkkZlQA; i++)
		{
			if (SPvpuJNePVgQPlPlMtDBBHHDtxVo[i].get_inputManagerId() == inputManagerId)
			{
				SPvpuJNePVgQPlPlMtDBBHHDtxVo[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		XJbowZhHPavAQMlYerveWgSdbLTZ = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		XJbowZhHPavAQMlYerveWgSdbLTZ = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return JGOEatxUyVWjwLPbRHEwtnJGVdSM.iZMGyRILyHctZxzPCaGjLknkFTPx();
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return JGOEatxUyVWjwLPbRHEwtnJGVdSM.pymenyEzuwwYMpVOeVqjrkEmYGAbA();
	}

	protected bool PrmnuqOvDlXXEpsrIEwntRdRSfle(PidVid P_0)
	{
		return MFWJPWlRwehnBLRmBKoZBcBeZTEY(P_0);
	}

	protected CDFdkvFBdhpJKCvjcfqyKaRxbGbg IyRyYVHjOpgYsOzJtXPUaFJtHeqO()
	{
		return JGOEatxUyVWjwLPbRHEwtnJGVdSM;
	}

	private void OwHnOzpydJkKXqNxdFgrElJKStIBA()
	{
		MqjcNYgpIVAbaaRpEttjkzxWNCzfA(AWVmplKJojBqbkhXKbNxDtqqxgYF());
	}

	private void MqjcNYgpIVAbaaRpEttjkzxWNCzfA(IList<gmzcmYbFSNucJXQyYRMseSdXxgyb> P_0)
	{
		int num = 0;
		List<zxwyluHITgqyxtCvnCdvGZWCunpK> sPvpuJNePVgQPlPlMtDBBHHDtxVo = SPvpuJNePVgQPlPlMtDBBHHDtxVo;
		int gdghqKKKtROnFQMbSMTdhABkkZlQA = GdghqKKKtROnFQMbSMTdhABkkZlQA;
		SPvpuJNePVgQPlPlMtDBBHHDtxVo = new List<zxwyluHITgqyxtCvnCdvGZWCunpK>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				gmzcmYbFSNucJXQyYRMseSdXxgyb gmzcmYbFSNucJXQyYRMseSdXxgyb2 = P_0[i];
				zxwyluHITgqyxtCvnCdvGZWCunpK zxwyluHITgqyxtCvnCdvGZWCunpK2 = new zxwyluHITgqyxtCvnCdvGZWCunpK(jGppkJBMElISdhDZvQuTiuOQwLqJA);
				zxwyluHITgqyxtCvnCdvGZWCunpK2.hmbLRptVDQpyXIqPZmGqffqbINZn = gmzcmYbFSNucJXQyYRMseSdXxgyb2;
				zxwyluHITgqyxtCvnCdvGZWCunpK2.fWDlgznFFpxukkfasIGRzXLdYzWo = gmzcmYbFSNucJXQyYRMseSdXxgyb2.oUZdQCDRbHeXQqUNlgKsyHIQARfu();
				zxwyluHITgqyxtCvnCdvGZWCunpK2.vaFZzEyAotphaBCOfGdKtYuTfHHj = gmzcmYbFSNucJXQyYRMseSdXxgyb2.tHeJWtPcoYzbOKNvRudWvqJzVxBL();
				zxwyluHITgqyxtCvnCdvGZWCunpK2.YxeceAxGshiAhWGXYcoEecTtThLKA = gmzcmYbFSNucJXQyYRMseSdXxgyb2.tHeJWtPcoYzbOKNvRudWvqJzVxBL();
				zxwyluHITgqyxtCvnCdvGZWCunpK2.MBxgcTBytNuVXNFnxoNuHHmFfZgoB = gmzcmYbFSNucJXQyYRMseSdXxgyb2.hHlgCDjMNCWLvUrtCbYKwUcrWpcn();
				zxwyluHITgqyxtCvnCdvGZWCunpK2.gybRdKpAJwQUfRJlGpcuVOllfdCHA = gmzcmYbFSNucJXQyYRMseSdXxgyb2.qwzXRUYHrJWUPIcrxKANCrMKqLRk();
				zxwyluHITgqyxtCvnCdvGZWCunpK2.ntXfLbDUoccgpUFvlsONumkrVAbF = gmzcmYbFSNucJXQyYRMseSdXxgyb2.fftWaBPxOaUmlXCeUhZVtPVZotqI();
				zxwyluHITgqyxtCvnCdvGZWCunpK2.NlnadAdlHFsKoxVmNrTKBgGdNRJc = gmzcmYbFSNucJXQyYRMseSdXxgyb2.hviOUJsKipmmHcsklkVczpEkFEBo();
				zxwyluHITgqyxtCvnCdvGZWCunpK2.iKxbZQXqRzCeFnhmYaOAAxVzqbmsA = gmzcmYbFSNucJXQyYRMseSdXxgyb2.qjBfQZnXjIDSgiXZlwXggkefVspx();
				zxwyluHITgqyxtCvnCdvGZWCunpK2.aOrdMAhcAYptcCdMyvRoICwQdqrh = gmzcmYbFSNucJXQyYRMseSdXxgyb2.CYDGHozFJPnTuXZKQdeDYOIqnKqg();
				zxwyluHITgqyxtCvnCdvGZWCunpK2.pYkALoKgbTJkEivkEvJmPCaFBZyub = gmzcmYbFSNucJXQyYRMseSdXxgyb2.JVqnJSrtWBCUUECuqNbKVlHkgLxS();
				zxwyluHITgqyxtCvnCdvGZWCunpK2.set_extension(gmzcmYbFSNucJXQyYRMseSdXxgyb2.ReysgnIttWOMXCKILaJlMxSebAkS());
				zxwyluHITgqyxtCvnCdvGZWCunpK2.hmbLRptVDQpyXIqPZmGqffqbINZn = gmzcmYbFSNucJXQyYRMseSdXxgyb2;
				zxwyluHITgqyxtCvnCdvGZWCunpK2.EfVAHwFxISjeScTaTCpBBlHIfCWFb();
				SPvpuJNePVgQPlPlMtDBBHHDtxVo.Add(zxwyluHITgqyxtCvnCdvGZWCunpK2);
				num++;
			}
		}
		GdghqKKKtROnFQMbSMTdhABkkZlQA = num;
		XbZqltBKsGRDDlApczaxkwkrIdXT(gdghqKKKtROnFQMbSMTdhABkkZlQA, num, sPvpuJNePVgQPlPlMtDBBHHDtxVo, SPvpuJNePVgQPlPlMtDBBHHDtxVo);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(SPvpuJNePVgQPlPlMtDBBHHDtxVo[j]));
			}
		}
		ocTWLDlXbzpNdfAwkNjecSeLdRjR(sPvpuJNePVgQPlPlMtDBBHHDtxVo, SPvpuJNePVgQPlPlMtDBBHHDtxVo, false);
		ocTWLDlXbzpNdfAwkNjecSeLdRjR(SPvpuJNePVgQPlPlMtDBBHHDtxVo, sPvpuJNePVgQPlPlMtDBBHHDtxVo, true);
	}

	private void WxtEnVHQZydIWAxiJcmQyXInQXiPA()
	{
		for (int i = 0; i < GdghqKKKtROnFQMbSMTdhABkkZlQA; i++)
		{
			SPvpuJNePVgQPlPlMtDBBHHDtxVo[i]?.Update();
		}
	}

	private IList<gmzcmYbFSNucJXQyYRMseSdXxgyb> AWVmplKJojBqbkhXKbNxDtqqxgYF()
	{
		return JGOEatxUyVWjwLPbRHEwtnJGVdSM.GetJoysticks<gmzcmYbFSNucJXQyYRMseSdXxgyb>();
	}

	private void XbZqltBKsGRDDlApczaxkwkrIdXT(int P_0, int P_1, List<zxwyluHITgqyxtCvnCdvGZWCunpK> P_2, List<zxwyluHITgqyxtCvnCdvGZWCunpK> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(zxwyluHITgqyxtCvnCdvGZWCunpK.cIQooDftINFCXrmpAgvhtKYpRXVR);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			GDzDzVJRJKcKIsgfFUZfzFyEzaii(P_1, P_3, P_0, P_2, FNATBfLINfbNNureCHcgYiGhewkAA.zyZVgDGfYCpAYXZvIqYJMudqSYLh.Exact);
			GDzDzVJRJKcKIsgfFUZfzFyEzaii(P_1, P_3, P_0, P_2, FNATBfLINfbNNureCHcgYiGhewkAA.zyZVgDGfYCpAYXZvIqYJMudqSYLh.Approximate);
		}
		bzHdaEeBSDObkZRwlXKrhsWljlYr(P_1, P_3, FNATBfLINfbNNureCHcgYiGhewkAA.zyZVgDGfYCpAYXZvIqYJMudqSYLh.Exact);
		bzHdaEeBSDObkZRwlXKrhsWljlYr(P_1, P_3, FNATBfLINfbNNureCHcgYiGhewkAA.zyZVgDGfYCpAYXZvIqYJMudqSYLh.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			zxwyluHITgqyxtCvnCdvGZWCunpK zxwyluHITgqyxtCvnCdvGZWCunpK2 = P_3[i];
			if (zxwyluHITgqyxtCvnCdvGZWCunpK2 != null && zxwyluHITgqyxtCvnCdvGZWCunpK2.get_inputManagerId() < 0)
			{
				zxwyluHITgqyxtCvnCdvGZWCunpK2.set_inputManagerId(WGBBEXhkBQVNwDTSMaanQBksFgZi(P_3));
				zxwyluHITgqyxtCvnCdvGZWCunpK2.set_rewiredId(WPiYKtyxWSoshgGKxVcIoApPBaUf());
				ELJEKXGoXBnFdpjYSrOvsbzqwAgs.OtyfPNQYEXSswqtQRffeJDITIMrhA(zxwyluHITgqyxtCvnCdvGZWCunpK2);
			}
		}
		P_3.Sort(zxwyluHITgqyxtCvnCdvGZWCunpK.PDVWuKEkblbguZhZZmcCKUjeIHBN);
	}

	private void GfhjRFjVhuvuqHHWgHFsVxwIeQGO(List<zxwyluHITgqyxtCvnCdvGZWCunpK> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (i != P_1 && P_0[i] != null && P_0[i].get_inputManagerId() == P_2)
			{
				P_0[i].set_inputManagerId(-1);
			}
		}
	}

	private bool OcFFXmWAiPXWCHxUYkuxsdjimhym(List<zxwyluHITgqyxtCvnCdvGZWCunpK> P_0, int P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].get_inputManagerId() == P_1)
			{
				return false;
			}
		}
		return true;
	}

	private int WGBBEXhkBQVNwDTSMaanQBksFgZi(List<zxwyluHITgqyxtCvnCdvGZWCunpK> P_0)
	{
		int num = 0;
		while (true)
		{
			bool flag = false;
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && P_0[i].get_inputManagerId() == num)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
			num++;
		}
		return num;
	}

	private bool NjUEolHqqwxKWVFMlOWVJiqAoYYV(List<zxwyluHITgqyxtCvnCdvGZWCunpK> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i].get_rewiredId() == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void GDzDzVJRJKcKIsgfFUZfzFyEzaii(int P_0, List<zxwyluHITgqyxtCvnCdvGZWCunpK> P_1, int P_2, List<zxwyluHITgqyxtCvnCdvGZWCunpK> P_3, FNATBfLINfbNNureCHcgYiGhewkAA.zyZVgDGfYCpAYXZvIqYJMudqSYLh P_4)
	{
		int num = ((P_4 != FNATBfLINfbNNureCHcgYiGhewkAA.zyZVgDGfYCpAYXZvIqYJMudqSYLh.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			zxwyluHITgqyxtCvnCdvGZWCunpK zxwyluHITgqyxtCvnCdvGZWCunpK2 = P_1[i];
			if (zxwyluHITgqyxtCvnCdvGZWCunpK2 == null || zxwyluHITgqyxtCvnCdvGZWCunpK2.get_inputManagerId() >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				zxwyluHITgqyxtCvnCdvGZWCunpK zxwyluHITgqyxtCvnCdvGZWCunpK3 = P_3[j];
				if (zxwyluHITgqyxtCvnCdvGZWCunpK3 != null && !NjUEolHqqwxKWVFMlOWVJiqAoYYV(P_1, zxwyluHITgqyxtCvnCdvGZWCunpK3.get_rewiredId()) && zxwyluHITgqyxtCvnCdvGZWCunpK2.POrwpSXGrunJFWDrxbBKCIufFTAGA(zxwyluHITgqyxtCvnCdvGZWCunpK3) >= num)
				{
					zxwyluHITgqyxtCvnCdvGZWCunpK2.ZPGlWSsCAwfBjjgRSCEkzvUkdVJBb(zxwyluHITgqyxtCvnCdvGZWCunpK3);
					ELJEKXGoXBnFdpjYSrOvsbzqwAgs.OtyfPNQYEXSswqtQRffeJDITIMrhA(zxwyluHITgqyxtCvnCdvGZWCunpK2);
				}
			}
		}
	}

	private void bzHdaEeBSDObkZRwlXKrhsWljlYr(int P_0, List<zxwyluHITgqyxtCvnCdvGZWCunpK> P_1, FNATBfLINfbNNureCHcgYiGhewkAA.zyZVgDGfYCpAYXZvIqYJMudqSYLh P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			zxwyluHITgqyxtCvnCdvGZWCunpK zxwyluHITgqyxtCvnCdvGZWCunpK2 = P_1[i];
			if (zxwyluHITgqyxtCvnCdvGZWCunpK2 == null || zxwyluHITgqyxtCvnCdvGZWCunpK2.get_inputManagerId() >= 0)
			{
				continue;
			}
			FNATBfLINfbNNureCHcgYiGhewkAA.PKzKyiKQiIOGfaQUlfKeBYyjKdMhA pKzKyiKQiIOGfaQUlfKeBYyjKdMhA = null;
			foreach (FNATBfLINfbNNureCHcgYiGhewkAA.PKzKyiKQiIOGfaQUlfKeBYyjKdMhA item in ELJEKXGoXBnFdpjYSrOvsbzqwAgs.VNIUTknAUDtoWmfSzxnbDHQIYYKn(zxwyluHITgqyxtCvnCdvGZWCunpK2, P_2))
			{
				if (!NjUEolHqqwxKWVFMlOWVJiqAoYYV(P_1, item.UfIMVLsVqiNqLdYLlvdXGlZJaOKJA) && item.CncxqPSejtEjQedTTqtYwwyHRVfCA >= 0)
				{
					pKzKyiKQiIOGfaQUlfKeBYyjKdMhA = item;
					break;
				}
			}
			if (pKzKyiKQiIOGfaQUlfKeBYyjKdMhA != null)
			{
				int num = pKzKyiKQiIOGfaQUlfKeBYyjKdMhA.CncxqPSejtEjQedTTqtYwwyHRVfCA;
				if (!OcFFXmWAiPXWCHxUYkuxsdjimhym(P_1, num))
				{
					num = (pKzKyiKQiIOGfaQUlfKeBYyjKdMhA.CncxqPSejtEjQedTTqtYwwyHRVfCA = WGBBEXhkBQVNwDTSMaanQBksFgZi(P_1));
				}
				zxwyluHITgqyxtCvnCdvGZWCunpK2.set_inputManagerId(num);
				zxwyluHITgqyxtCvnCdvGZWCunpK2.set_rewiredId(pKzKyiKQiIOGfaQUlfKeBYyjKdMhA.UfIMVLsVqiNqLdYLlvdXGlZJaOKJA);
				ELJEKXGoXBnFdpjYSrOvsbzqwAgs.OtyfPNQYEXSswqtQRffeJDITIMrhA(zxwyluHITgqyxtCvnCdvGZWCunpK2);
			}
		}
	}

	private void REfJCYXCIoPqLGyLYMqLUBvlOtDA()
	{
		JGOEatxUyVWjwLPbRHEwtnJGVdSM.BHFphUSqDVtWvQOCItKDuaOqebfCA();
		IList<gmzcmYbFSNucJXQyYRMseSdXxgyb> list = AWVmplKJojBqbkhXKbNxDtqqxgYF();
		if (HdxsjEGFwFKQCeRuEGMdersHaGFi(list))
		{
			MqjcNYgpIVAbaaRpEttjkzxWNCzfA(list);
		}
		XJbowZhHPavAQMlYerveWgSdbLTZ = false;
	}

	private bool HdxsjEGFwFKQCeRuEGMdersHaGFi(IList<gmzcmYbFSNucJXQyYRMseSdXxgyb> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !MgwckliZXyahZVsPgpXMlPvtbSel(P_0[i].oUZdQCDRbHeXQqUNlgKsyHIQARfu()))
			{
				return true;
			}
		}
		int count2 = SPvpuJNePVgQPlPlMtDBBHHDtxVo.Count;
		for (int j = 0; j < count2; j++)
		{
			if (SPvpuJNePVgQPlPlMtDBBHHDtxVo[j] != null && !udwTLAXdeQKTWnayxqJVWZDHEVEl(P_0, SPvpuJNePVgQPlPlMtDBBHHDtxVo[j].fWDlgznFFpxukkfasIGRzXLdYzWo))
			{
				return true;
			}
		}
		return false;
	}

	private bool MgwckliZXyahZVsPgpXMlPvtbSel(Guid P_0)
	{
		int count = SPvpuJNePVgQPlPlMtDBBHHDtxVo.Count;
		for (int i = 0; i < count; i++)
		{
			if (SPvpuJNePVgQPlPlMtDBBHHDtxVo[i] != null && SPvpuJNePVgQPlPlMtDBBHHDtxVo[i].fWDlgznFFpxukkfasIGRzXLdYzWo == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool udwTLAXdeQKTWnayxqJVWZDHEVEl(IList<gmzcmYbFSNucJXQyYRMseSdXxgyb> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].oUZdQCDRbHeXQqUNlgKsyHIQARfu() == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void ocTWLDlXbzpNdfAwkNjecSeLdRjR(List<zxwyluHITgqyxtCvnCdvGZWCunpK> P_0, List<zxwyluHITgqyxtCvnCdvGZWCunpK> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			zxwyluHITgqyxtCvnCdvGZWCunpK zxwyluHITgqyxtCvnCdvGZWCunpK2 = P_0[i];
			if (zxwyluHITgqyxtCvnCdvGZWCunpK2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					zxwyluHITgqyxtCvnCdvGZWCunpK zxwyluHITgqyxtCvnCdvGZWCunpK3 = P_1[j];
					if (zxwyluHITgqyxtCvnCdvGZWCunpK3 != null && zxwyluHITgqyxtCvnCdvGZWCunpK2.fWDlgznFFpxukkfasIGRzXLdYzWo == zxwyluHITgqyxtCvnCdvGZWCunpK3.fWDlgznFFpxukkfasIGRzXLdYzWo)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				pRvfUeyxqZFvlZqzhxJYPXpKdvPd(P_0[i], P_2);
			}
		}
	}

	private void pRvfUeyxqZFvlZqzhxJYPXpKdvPd(zxwyluHITgqyxtCvnCdvGZWCunpK P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0.ToBridgedController());
			}
		}
		else if (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
		}
	}
}
