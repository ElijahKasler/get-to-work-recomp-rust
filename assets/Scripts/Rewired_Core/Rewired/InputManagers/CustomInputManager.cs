using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Utils;

namespace Rewired.InputManagers;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class CustomInputManager : PlatformInputManager
{
	private class CNcBBhnfeXiduGMhSVPCQJTfbUKA : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName
	{
		private readonly InputSource iGKngnZVPVSDaYRkyImBujSNDDKn;

		private readonly CustomInputSource qfnaZGbUWguSxbYDObXXSOWSuCYkA;

		private readonly Controller.Extension NfbVukbEyetgOjWjuTPkkCrtsDAn;

		private int lnNYkdmQiMMueeGIvKJfOZiHozrR;

		private int LBGWlRiNUsZlrNfdzbbDdjEysTfDb;

		private long? FwDaHdgFWOFmDWPgZvLHTmHTqIlLA;

		private int bZlzTLIEbGWRNmCcLeiQxDbgoSLT;

		public Guid PkvVHtoZRyGuDDkdNzGMCHDNPVgH;

		public string gMDKovBhttjdKWrBvPSLKAWsCbZDA;

		public string phnTHICrHxGeWimtKbcYLLhlJAXR;

		private int GxLQasQUhKRGThKKyGNEWAnFilZo;

		private int iVLyWMcNwzbHZuiXDggEgvMtqDkv;

		private float[] CFnxhOgwbxjLzPbwhHdiuncRsdRr;

		private bool[] PETbNhIWqysBTGmwObuMogcYvSZG;

		private float[] TvonGVdVjJCoZtnFMahsJHiNujIT;

		private bool[] BEGCzbNxoYAsPbsKzTFKhFKDAiywA;

		private HardwareJoystickMap_InputManager QVzvFcqCMABeopVJdGaLcohieJMb;

		public CustomInputSource.Joystick uFJnMxyrNWGxypWxJsaIFJQgDKiL;

		private bool vYLvvxqUAhIapOFvTFSIzhBVHWLy;

		private readonly bool jHzenPGQyzXGgvHaMFrOTsLmqWZTA;

		private readonly LocalizedString LHFilcLAyGFcQOrdYAeUmfcUfHEhA;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ZeEsIuEXaXamdDfvlgCOBFFQdDpM;

		public int rUKHupsBqzzCraYYYRSHxHlWLgTO => WhcgnAGNeozNDWYhEtRiwxJAXXvJA();

		public int xqueYJWbFEiLSCknFXtRZLAyUmvH => sljKCOvrfPtFYnGNtixOEudlTYTF();

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
		Controller.Extension IInputManagerJoystickPublic.extension => get_extension();

		public int WhcgnAGNeozNDWYhEtRiwxJAXXvJA()
		{
			if (uFJnMxyrNWGxypWxJsaIFJQgDKiL == null)
			{
				return 0;
			}
			return uFJnMxyrNWGxypWxJsaIFJQgDKiL.buttonCount;
		}

		public int sljKCOvrfPtFYnGNtixOEudlTYTF()
		{
			if (uFJnMxyrNWGxypWxJsaIFJQgDKiL == null)
			{
				return 0;
			}
			return uFJnMxyrNWGxypWxJsaIFJQgDKiL.axisCount;
		}

		public int get_rewiredId()
		{
			return lnNYkdmQiMMueeGIvKJfOZiHozrR;
		}

		public void set_rewiredId(int value)
		{
			lnNYkdmQiMMueeGIvKJfOZiHozrR = value;
		}

		public int get_inputManagerId()
		{
			return LBGWlRiNUsZlrNfdzbbDdjEysTfDb;
		}

		public void set_inputManagerId(int value)
		{
			LBGWlRiNUsZlrNfdzbbDdjEysTfDb = value;
		}

		public string get_name()
		{
			string text = ((!string.IsNullOrEmpty(uFJnMxyrNWGxypWxJsaIFJQgDKiL.customName)) ? uFJnMxyrNWGxypWxJsaIFJQgDKiL.customName : gMDKovBhttjdKWrBvPSLKAWsCbZDA);
			if (text == "Unknown Controller")
			{
				text = phnTHICrHxGeWimtKbcYLLhlJAXR;
			}
			return text;
		}

		public long? get_systemId()
		{
			return FwDaHdgFWOFmDWPgZvLHTmHTqIlLA;
		}

		public int get_unityId()
		{
			return bZlzTLIEbGWRNmCcLeiQxDbgoSLT;
		}

		public Guid get_instanceGuid()
		{
			if (!FwDaHdgFWOFmDWPgZvLHTmHTqIlLA.HasValue)
			{
				return Guid.Empty;
			}
			return MiscTools.CreateGuidHashSHA1(get_name() + "_" + FwDaHdgFWOFmDWPgZvLHTmHTqIlLA);
		}

		public Guid get_persistentGuid()
		{
			if (!(uFJnMxyrNWGxypWxJsaIFJQgDKiL.deviceInstanceGuid != Guid.Empty))
			{
				return get_instanceGuid();
			}
			return uFJnMxyrNWGxypWxJsaIFJQgDKiL.deviceInstanceGuid;
		}

		public Controller.Extension get_extension()
		{
			return NfbVukbEyetgOjWjuTPkkCrtsDAn;
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		void IInputManagerJoystickPublic.SetVibration(float amount, int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		void IInputManagerJoystickPublic.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public CNcBBhnfeXiduGMhSVPCQJTfbUKA(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, Controller.Extension P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
		{
			jHzenPGQyzXGgvHaMFrOTsLmqWZTA = P_0.mLNIopHNHCrePmiGorNqaDbovQKH() == InputSource.PS4 || P_0.mLNIopHNHCrePmiGorNqaDbovQKH() == InputSource.PS5;
			LHFilcLAyGFcQOrdYAeUmfcUfHEhA = new LocalizedString();
			qfnaZGbUWguSxbYDObXXSOWSuCYkA = P_0;
			iGKngnZVPVSDaYRkyImBujSNDDKn = P_4;
			FwDaHdgFWOFmDWPgZvLHTmHTqIlLA = P_1;
			uFJnMxyrNWGxypWxJsaIFJQgDKiL = P_3;
			bZlzTLIEbGWRNmCcLeiQxDbgoSLT = P_2;
			NfbVukbEyetgOjWjuTPkkCrtsDAn = P_5;
			ZeEsIuEXaXamdDfvlgCOBFFQdDpM = P_6;
			LBGWlRiNUsZlrNfdzbbDdjEysTfDb = -1;
			lnNYkdmQiMMueeGIvKJfOZiHozrR = -1;
			KUyvromajolFhGcMtEIHwJvIugDn();
			tOmjNAUJFmKLkMgXnrxYzBkpYqJc();
			PkvVHtoZRyGuDDkdNzGMCHDNPVgH = QVzvFcqCMABeopVJdGaLcohieJMb.hardwareMapIdentifier.guid;
			gMDKovBhttjdKWrBvPSLKAWsCbZDA = QVzvFcqCMABeopVJdGaLcohieJMb.controllerName;
			CFnxhOgwbxjLzPbwhHdiuncRsdRr = new float[GxLQasQUhKRGThKKyGNEWAnFilZo];
			PETbNhIWqysBTGmwObuMogcYvSZG = new bool[iVLyWMcNwzbHZuiXDggEgvMtqDkv];
			TvonGVdVjJCoZtnFMahsJHiNujIT = new float[iVLyWMcNwzbHZuiXDggEgvMtqDkv];
			BEGCzbNxoYAsPbsKzTFKhFKDAiywA = new bool[iVLyWMcNwzbHZuiXDggEgvMtqDkv];
			HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)QVzvFcqCMABeopVJdGaLcohieJMb.map).Buttons;
			if (buttons != null)
			{
				int num = MathTools.Min(buttons.Length, iVLyWMcNwzbHZuiXDggEgvMtqDkv);
				for (int i = 0; i < num; i++)
				{
					if (buttons[i] != null && buttons[i].buttonInfo != null)
					{
						BEGCzbNxoYAsPbsKzTFKhFKDAiywA[i] = buttons[i].buttonInfo.isPressureSensitive;
					}
				}
			}
			Update();
		}

		public void KUyvromajolFhGcMtEIHwJvIugDn()
		{
			phnTHICrHxGeWimtKbcYLLhlJAXR = uFJnMxyrNWGxypWxJsaIFJQgDKiL.deviceName;
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (uFJnMxyrNWGxypWxJsaIFJQgDKiL.isConnected)
			{
				HiGOEeGsUnVTBRTsuIvQqqXNMUxs();
				KVQPkpIOUOYkYjhGMFeGxqVKfkQdA();
			}
		}

		void IInputManagerJoystick.Update()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Update
			this.Update();
		}

		public int RKSfFfbpOBhWYWkibaRNYgzgmnuu(CNcBBhnfeXiduGMhSVPCQJTfbUKA P_0)
		{
			if (P_0.phnTHICrHxGeWimtKbcYLLhlJAXR == phnTHICrHxGeWimtKbcYLLhlJAXR && P_0.FwDaHdgFWOFmDWPgZvLHTmHTqIlLA == FwDaHdgFWOFmDWPgZvLHTmHTqIlLA)
			{
				return 2;
			}
			if (P_0.phnTHICrHxGeWimtKbcYLLhlJAXR == phnTHICrHxGeWimtKbcYLLhlJAXR)
			{
				return 1;
			}
			return 0;
		}

		private void uuNycxcdvnJePsQqElWlmqFxKkRB(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = iGKngnZVPVSDaYRkyImBujSNDDKn;
			P_0.inputSource = iGKngnZVPVSDaYRkyImBujSNDDKn;
			P_0.hardwareIdentifier = UGuvYhdbtrWxCSCmGQesVOieUZSf();
			P_0.hardwareAxisCount = GxLQasQUhKRGThKKyGNEWAnFilZo;
			P_0.hardwareButtonCount = iVLyWMcNwzbHZuiXDggEgvMtqDkv;
			P_0.hardwareHatCount = 0;
			P_0.hw_productName = phnTHICrHxGeWimtKbcYLLhlJAXR;
			P_0.hw_supportsVibration = uFJnMxyrNWGxypWxJsaIFJQgDKiL.supportsVibration;
			P_0.userCustomIdentifier = uFJnMxyrNWGxypWxJsaIFJQgDKiL.customIdentifier;
		}

		private void lJCXGesCRxjmaTBJavScBYrpHQlr(BridgedController P_0)
		{
			uuNycxcdvnJePsQqElWlmqFxKkRB(P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = QVzvFcqCMABeopVJdGaLcohieJMb.ToGameHardwareControllerMap();
			P_0.instanceName = phnTHICrHxGeWimtKbcYLLhlJAXR;
			P_0.productName = phnTHICrHxGeWimtKbcYLLhlJAXR;
			P_0.isXInputDevice = false;
			P_0.axisCount = GxLQasQUhKRGThKKyGNEWAnFilZo;
			P_0.buttonCount = iVLyWMcNwzbHZuiXDggEgvMtqDkv;
			P_0.controllerTypeGuid = PkvVHtoZRyGuDDkdNzGMCHDNPVgH;
			P_0.customInputSource = qfnaZGbUWguSxbYDObXXSOWSuCYkA;
			P_0.controllerExtension = NfbVukbEyetgOjWjuTPkkCrtsDAn;
			P_0.isButtonPressureSensitive = new bool[BEGCzbNxoYAsPbsKzTFKhFKDAiywA.Length];
			for (int i = 0; i < BEGCzbNxoYAsPbsKzTFKhFKDAiywA.Length; i++)
			{
				P_0.isButtonPressureSensitive[i] = BEGCzbNxoYAsPbsKzTFKhFKDAiywA[i];
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (GxLQasQUhKRGThKKyGNEWAnFilZo != dataUpdater.axisCount || iVLyWMcNwzbHZuiXDggEgvMtqDkv != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < GxLQasQUhKRGThKKyGNEWAnFilZo; i++)
			{
				dataUpdater.axisValues[i] = CFnxhOgwbxjLzPbwhHdiuncRsdRr[i];
			}
			for (int j = 0; j < iVLyWMcNwzbHZuiXDggEgvMtqDkv; j++)
			{
				if (BEGCzbNxoYAsPbsKzTFKhFKDAiywA[j])
				{
					dataUpdater.buttonPressureValues[j] = TvonGVdVjJCoZtnFMahsJHiNujIT[j];
				}
				dataUpdater.buttonValues[j] = PETbNhIWqysBTGmwObuMogcYvSZG[j];
			}
			if (vYLvvxqUAhIapOFvTFSIzhBVHWLy && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		void IInputManagerJoystick.FillData(ControllerDataUpdater dataUpdater)
		{
			//ILSpy generated this explicit interface implementation from .override directive in FillData
			this.FillData(dataUpdater);
		}

		public BridgedControllerHWInfo vFEHYBUGTIQGwxTpjHhShjMVpjhQ()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			uuNycxcdvnJePsQqElWlmqFxKkRB(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			lJCXGesCRxjmaTBJavScBYrpHQlr(bridgedController);
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
			return new ControllerDisconnectedEventArgs(lnNYkdmQiMMueeGIvKJfOZiHozrR);
		}

		ControllerDisconnectedEventArgs IInputManagerJoystick.ToControllerDisconnectedEventArgs()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ToControllerDisconnectedEventArgs
			return this.ToControllerDisconnectedEventArgs();
		}

		private void HiGOEeGsUnVTBRTsuIvQqqXNMUxs()
		{
			HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)QVzvFcqCMABeopVJdGaLcohieJMb.map).Axes;
			if (axes == null)
			{
				return;
			}
			for (int i = 0; i < axes.Length; i++)
			{
				if (axes[i] != null)
				{
					if (i >= GxLQasQUhKRGThKKyGNEWAnFilZo)
					{
						throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
					}
					CFnxhOgwbxjLzPbwhHdiuncRsdRr[i] = JAWCmsXQsjLWxxrRCiCllwEErjlb(axes[i]);
					if (!vYLvvxqUAhIapOFvTFSIzhBVHWLy && CFnxhOgwbxjLzPbwhHdiuncRsdRr[i] != 0f)
					{
						vYLvvxqUAhIapOFvTFSIzhBVHWLy = true;
					}
				}
			}
		}

		private void KVQPkpIOUOYkYjhGMFeGxqVKfkQdA()
		{
			HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)QVzvFcqCMABeopVJdGaLcohieJMb.map).Buttons;
			if (buttons == null)
			{
				return;
			}
			for (int i = 0; i < buttons.Length; i++)
			{
				if (i >= iVLyWMcNwzbHZuiXDggEgvMtqDkv)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				PETbNhIWqysBTGmwObuMogcYvSZG[i] = ohTdWTfxVWoLVdkDuWGJrAMKvBpr(buttons[i], out TvonGVdVjJCoZtnFMahsJHiNujIT[i]);
				if (!vYLvvxqUAhIapOFvTFSIzhBVHWLy && (PETbNhIWqysBTGmwObuMogcYvSZG[i] || (BEGCzbNxoYAsPbsKzTFKhFKDAiywA[i] && TvonGVdVjJCoZtnFMahsJHiNujIT[i] != 0f)))
				{
					vYLvvxqUAhIapOFvTFSIzhBVHWLy = true;
				}
			}
		}

		private bool ohTdWTfxVWoLVdkDuWGJrAMKvBpr(HardwareJoystickMap.Platform_Custom.Button P_0, out float P_1)
		{
			if (P_0.sourceType == 0)
			{
				bool result = LtBUgDNScHbAvmuRpfPuzSqaSpSi(P_0.sourceButton, out P_1);
				if (MathTools.Abs(P_1) <= P_0.axisDeadZone)
				{
					P_1 = 0f;
				}
				return result;
			}
			if (P_0.sourceType == 1)
			{
				P_1 = 0f;
				float num = ddXWVRDHaiwfeUsPzcnIeRTUlAzT(P_0.sourceAxis);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Positive && num < 0f)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Negative && num > 0f)
				{
					return false;
				}
				if (num < 0f)
				{
					num *= -1f;
				}
				if (num > 1f)
				{
					num = 1f;
				}
				P_1 = num;
				return true;
			}
			P_1 = 0f;
			return false;
		}

		private bool siQdzNHWVELswbMVjGLRajdJFfBkA(float P_0, float P_1)
		{
			return MathTools.IsNear(P_1, P_0, 0.1f);
		}

		private float JAWCmsXQsjLWxxrRCiCllwEErjlb(HardwareJoystickMap.Platform_Custom.Axis P_0)
		{
			if (P_0.sourceType == 1)
			{
				return ddXWVRDHaiwfeUsPzcnIeRTUlAzT(P_0.sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				if (!LtBUgDNScHbAvmuRpfPuzSqaSpSi(P_0.sourceButton, out var _))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			throw new NotImplementedException();
		}

		private float ddXWVRDHaiwfeUsPzcnIeRTUlAzT(int P_0)
		{
			return uFJnMxyrNWGxypWxJsaIFJQgDKiL.GetAxisValue(P_0);
		}

		private bool LtBUgDNScHbAvmuRpfPuzSqaSpSi(int P_0, out float P_1)
		{
			uFJnMxyrNWGxypWxJsaIFJQgDKiL.BeyEkyjAUifZSySZdAgvzQouIXYL(P_0, out var result, out P_1);
			return result;
		}

		private void tOmjNAUJFmKLkMgXnrxYzBkpYqJc()
		{
			QVzvFcqCMABeopVJdGaLcohieJMb = ZeEsIuEXaXamdDfvlgCOBFFQdDpM(vFEHYBUGTIQGwxTpjHhShjMVpjhQ());
			if (QVzvFcqCMABeopVJdGaLcohieJMb == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (uFJnMxyrNWGxypWxJsaIFJQgDKiL is IInputManagerHardwareJoystickMapHandler)
			{
				try
				{
					((IInputManagerHardwareJoystickMapHandler)uFJnMxyrNWGxypWxJsaIFJQgDKiL).InitializeHardwareJoystickMap(QVzvFcqCMABeopVJdGaLcohieJMb);
				}
				catch
				{
				}
			}
			GxLQasQUhKRGThKKyGNEWAnFilZo = QVzvFcqCMABeopVJdGaLcohieJMb.axisCount;
			iVLyWMcNwzbHZuiXDggEgvMtqDkv = QVzvFcqCMABeopVJdGaLcohieJMb.buttonCount;
		}

		private void HFKGTuQVeQxMwddnOsxKzQPLFpQg()
		{
			Array.Clear(PETbNhIWqysBTGmwObuMogcYvSZG, 0, PETbNhIWqysBTGmwObuMogcYvSZG.Length);
			Array.Clear(TvonGVdVjJCoZtnFMahsJHiNujIT, 0, TvonGVdVjJCoZtnFMahsJHiNujIT.Length);
			Array.Clear(CFnxhOgwbxjLzPbwhHdiuncRsdRr, 0, CFnxhOgwbxjLzPbwhHdiuncRsdRr.Length);
		}

		private string UGuvYhdbtrWxCSCmGQesVOieUZSf()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{iGKngnZVPVSDaYRkyImBujSNDDKn.ToString()}{phnTHICrHxGeWimtKbcYLLhlJAXR}");
			}
			if (DYXEicTUvpxnVFlTbwIfiujTNpTs.ZCGrnntEgTOKZdITtdptDPSiYsuz())
			{
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{DYXEicTUvpxnVFlTbwIfiujTNpTs.tIRBAzhSdLNekUgHfQQffxwfWBLY()}{phnTHICrHxGeWimtKbcYLLhlJAXR}");
			}
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{iGKngnZVPVSDaYRkyImBujSNDDKn.ToString()}{phnTHICrHxGeWimtKbcYLLhlJAXR}");
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if (!(uFJnMxyrNWGxypWxJsaIFJQgDKiL is ITryGetLocalizedName))
			{
				if (jHzenPGQyzXGgvHaMFrOTsLmqWZTA)
				{
					if ((LocalizationManager.GetAndUpdateLocalizedString(LHFilcLAyGFcQOrdYAeUmfcUfHEhA, QVzvFcqCMABeopVJdGaLcohieJMb.deviceLocalizationInfo.parentKeys, "controller", get_name(), out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
					{
						string text = get_name();
						string text2 = null;
						MatchCollection matchCollection = Regex.Matches(text, "^(.*) ([0-9]+)$");
						if (matchCollection.Count > 0 && matchCollection[0].Groups != null && matchCollection[0].Groups.Count > 2)
						{
							text = matchCollection[0].Groups[1].Value;
							text2 = matchCollection[0].Groups[2].Value;
						}
						if (!string.IsNullOrEmpty(text2))
						{
							value = $"{text} {text2}";
						}
						LHFilcLAyGFcQOrdYAeUmfcUfHEhA.cachedValue = value;
					}
					return true;
				}
				value = null;
				return false;
			}
			return ((ITryGetLocalizedName)uFJnMxyrNWGxypWxJsaIFJQgDKiL).TryGetLocalizedName(out value);
		}

		public static int fCeBFuuXlovncyqjqfBBBiTZUGgrA(CNcBBhnfeXiduGMhSVPCQJTfbUKA P_0, CNcBBhnfeXiduGMhSVPCQJTfbUKA P_1)
		{
			if (P_0.LBGWlRiNUsZlrNfdzbbDdjEysTfDb < P_1.LBGWlRiNUsZlrNfdzbbDdjEysTfDb)
			{
				return -1;
			}
			if (P_0.LBGWlRiNUsZlrNfdzbbDdjEysTfDb > P_1.LBGWlRiNUsZlrNfdzbbDdjEysTfDb)
			{
				return 1;
			}
			return 0;
		}

		public static int HBUGUEwOjgAWqefICDypLWHLAGRAA(CNcBBhnfeXiduGMhSVPCQJTfbUKA P_0, CNcBBhnfeXiduGMhSVPCQJTfbUKA P_1)
		{
			if (P_0.FwDaHdgFWOFmDWPgZvLHTmHTqIlLA < P_1.FwDaHdgFWOFmDWPgZvLHTmHTqIlLA)
			{
				return -1;
			}
			if (P_0.FwDaHdgFWOFmDWPgZvLHTmHTqIlLA > P_1.FwDaHdgFWOFmDWPgZvLHTmHTqIlLA)
			{
				return 1;
			}
			return 0;
		}
	}

	private class iwKsrmbOBwLCpZnBOxDrCCmihGFB
	{
		public enum JjtsJZwiHhPQIDNeDsQgppKPVDQx
		{
			Exact = 0,
			Approximate = 1
		}

		public class MKMWoWLmartvwUKtjaFpQwQVLpXp
		{
			public int eeiIHNtQJPFgnTevoCUHauTGfAwib;

			public long? iztBmvNUrqkvFnLcNJFJsyzURZnU;

			public string yTtFaceNnZSwoiEUWsbecwHuLlJkA;

			public int NpbjOZOcrheOqZVZVPtcmElDqPGU;

			public int YDVCxZuRuJvSIaZZEiiGmLGmYHvs;

			public int JfIwjgwPVndhBOxeUAcBQJmkGabr;

			public MKMWoWLmartvwUKtjaFpQwQVLpXp(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
			{
				eeiIHNtQJPFgnTevoCUHauTGfAwib = P_0;
				iztBmvNUrqkvFnLcNJFJsyzURZnU = P_1;
				yTtFaceNnZSwoiEUWsbecwHuLlJkA = P_2;
				NpbjOZOcrheOqZVZVPtcmElDqPGU = P_3;
				YDVCxZuRuJvSIaZZEiiGmLGmYHvs = P_4;
				JfIwjgwPVndhBOxeUAcBQJmkGabr = P_5;
			}

			public bool mOPJEBDyUDIUyLvpbleKhPVSRfLL(CNcBBhnfeXiduGMhSVPCQJTfbUKA P_0, JjtsJZwiHhPQIDNeDsQgppKPVDQx P_1)
			{
				if (P_0.get_rewiredId() == eeiIHNtQJPFgnTevoCUHauTGfAwib)
				{
					return true;
				}
				if (P_0.WhcgnAGNeozNDWYhEtRiwxJAXXvJA() != YDVCxZuRuJvSIaZZEiiGmLGmYHvs)
				{
					return false;
				}
				if (P_0.sljKCOvrfPtFYnGNtixOEudlTYTF() != JfIwjgwPVndhBOxeUAcBQJmkGabr)
				{
					return false;
				}
				switch (P_1)
				{
				case JjtsJZwiHhPQIDNeDsQgppKPVDQx.Exact:
					if (iztBmvNUrqkvFnLcNJFJsyzURZnU == P_0.get_systemId())
					{
						return yTtFaceNnZSwoiEUWsbecwHuLlJkA == P_0.phnTHICrHxGeWimtKbcYLLhlJAXR;
					}
					return false;
				case JjtsJZwiHhPQIDNeDsQgppKPVDQx.Approximate:
					return yTtFaceNnZSwoiEUWsbecwHuLlJkA == P_0.phnTHICrHxGeWimtKbcYLLhlJAXR;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class DWLXSdQfpePNRhmuvoXmSHxcoQxQ : IEnumerable<MKMWoWLmartvwUKtjaFpQwQVLpXp>, IEnumerable, IEnumerator<MKMWoWLmartvwUKtjaFpQwQVLpXp>, IEnumerator, IDisposable
		{
			private int kdUhuFiyQSWkpTSfWJZedKmMisup;

			private MKMWoWLmartvwUKtjaFpQwQVLpXp eRblJrPFOaqWRoghwOrxayTnpBy;

			private int NNWnbbvuHRmjaLmrrOgoSDnPawop;

			public iwKsrmbOBwLCpZnBOxDrCCmihGFB pEmYoFaNEbCHelSnHHlaawKSzRPEA;

			private CNcBBhnfeXiduGMhSVPCQJTfbUKA arSvXkjqFJdiDtnjerIFbeTpXjys;

			public CNcBBhnfeXiduGMhSVPCQJTfbUKA MfvVmqOhqOYtWhlCtwTCAxPbtddB;

			private JjtsJZwiHhPQIDNeDsQgppKPVDQx ykAEULQWTaxUbtMrDsWPIsCOCZCT;

			public JjtsJZwiHhPQIDNeDsQgppKPVDQx oxrxaMWUzfgrpRtXkLqTLkaXARFN;

			private int zcjSXDmxPHUziMaazqeRquYnCdRT;

			private int UklFYNbPkqGoVyFntnApKErDCIjFA;

			MKMWoWLmartvwUKtjaFpQwQVLpXp IEnumerator<MKMWoWLmartvwUKtjaFpQwQVLpXp>.Current
			{
				[DebuggerHidden]
				get
				{
					return System_002ECollections_002EGeneric_002EIEnumerator_003CRewired_002EInputManagers_002ECustomInputManager_002EJoystickRecords_002ERecord_003E_002Eget_Current();
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return eRblJrPFOaqWRoghwOrxayTnpBy;
				}
			}

			[DebuggerHidden]
			public DWLXSdQfpePNRhmuvoXmSHxcoQxQ(int P_0)
			{
				kdUhuFiyQSWkpTSfWJZedKmMisup = P_0;
				NNWnbbvuHRmjaLmrrOgoSDnPawop = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = kdUhuFiyQSWkpTSfWJZedKmMisup;
				iwKsrmbOBwLCpZnBOxDrCCmihGFB iwKsrmbOBwLCpZnBOxDrCCmihGFB2 = pEmYoFaNEbCHelSnHHlaawKSzRPEA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					kdUhuFiyQSWkpTSfWJZedKmMisup = -1;
					goto IL_0083;
				}
				kdUhuFiyQSWkpTSfWJZedKmMisup = -1;
				zcjSXDmxPHUziMaazqeRquYnCdRT = iwKsrmbOBwLCpZnBOxDrCCmihGFB2.miqGAZpQaDdzaxnlignZkTxDDvEQ.Count;
				UklFYNbPkqGoVyFntnApKErDCIjFA = 0;
				goto IL_0093;
				IL_0083:
				UklFYNbPkqGoVyFntnApKErDCIjFA++;
				goto IL_0093;
				IL_0093:
				if (UklFYNbPkqGoVyFntnApKErDCIjFA < zcjSXDmxPHUziMaazqeRquYnCdRT)
				{
					if (iwKsrmbOBwLCpZnBOxDrCCmihGFB2.miqGAZpQaDdzaxnlignZkTxDDvEQ[UklFYNbPkqGoVyFntnApKErDCIjFA].mOPJEBDyUDIUyLvpbleKhPVSRfLL(arSvXkjqFJdiDtnjerIFbeTpXjys, ykAEULQWTaxUbtMrDsWPIsCOCZCT))
					{
						eRblJrPFOaqWRoghwOrxayTnpBy = iwKsrmbOBwLCpZnBOxDrCCmihGFB2.miqGAZpQaDdzaxnlignZkTxDDvEQ[UklFYNbPkqGoVyFntnApKErDCIjFA];
						kdUhuFiyQSWkpTSfWJZedKmMisup = 1;
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
			private MKMWoWLmartvwUKtjaFpQwQVLpXp System_002ECollections_002EGeneric_002EIEnumerator_003CRewired_002EInputManagers_002ECustomInputManager_002EJoystickRecords_002ERecord_003E_002Eget_Current()
			{
				return eRblJrPFOaqWRoghwOrxayTnpBy;
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<MKMWoWLmartvwUKtjaFpQwQVLpXp> IEnumerable<MKMWoWLmartvwUKtjaFpQwQVLpXp>.GetEnumerator()
			{
				DWLXSdQfpePNRhmuvoXmSHxcoQxQ dWLXSdQfpePNRhmuvoXmSHxcoQxQ;
				if (kdUhuFiyQSWkpTSfWJZedKmMisup == -2 && NNWnbbvuHRmjaLmrrOgoSDnPawop == Environment.CurrentManagedThreadId)
				{
					kdUhuFiyQSWkpTSfWJZedKmMisup = 0;
					dWLXSdQfpePNRhmuvoXmSHxcoQxQ = this;
				}
				else
				{
					dWLXSdQfpePNRhmuvoXmSHxcoQxQ = new DWLXSdQfpePNRhmuvoXmSHxcoQxQ(0);
					dWLXSdQfpePNRhmuvoXmSHxcoQxQ.pEmYoFaNEbCHelSnHHlaawKSzRPEA = pEmYoFaNEbCHelSnHHlaawKSzRPEA;
				}
				dWLXSdQfpePNRhmuvoXmSHxcoQxQ.arSvXkjqFJdiDtnjerIFbeTpXjys = MfvVmqOhqOYtWhlCtwTCAxPbtddB;
				dWLXSdQfpePNRhmuvoXmSHxcoQxQ.ykAEULQWTaxUbtMrDsWPIsCOCZCT = oxrxaMWUzfgrpRtXkLqTLkaXARFN;
				return dWLXSdQfpePNRhmuvoXmSHxcoQxQ;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<MKMWoWLmartvwUKtjaFpQwQVLpXp>)this).GetEnumerator();
			}
		}

		private List<MKMWoWLmartvwUKtjaFpQwQVLpXp> miqGAZpQaDdzaxnlignZkTxDDvEQ;

		public int hPLMJcqJNoIUXDMvGbqbhUSBNKBS => XvjvJizbTJuoByTruxZAZZoGPBf();

		public iwKsrmbOBwLCpZnBOxDrCCmihGFB()
		{
			miqGAZpQaDdzaxnlignZkTxDDvEQ = new List<MKMWoWLmartvwUKtjaFpQwQVLpXp>();
		}

		public int XvjvJizbTJuoByTruxZAZZoGPBf()
		{
			return miqGAZpQaDdzaxnlignZkTxDDvEQ.Count;
		}

		public void fIDBkChNDeBEMySoSLSMuVlSmxVO(CNcBBhnfeXiduGMhSVPCQJTfbUKA P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = miqGAZpQaDdzaxnlignZkTxDDvEQ.Count;
			for (int i = 0; i < count; i++)
			{
				if (miqGAZpQaDdzaxnlignZkTxDDvEQ[i].mOPJEBDyUDIUyLvpbleKhPVSRfLL(P_0, JjtsJZwiHhPQIDNeDsQgppKPVDQx.Exact))
				{
					miqGAZpQaDdzaxnlignZkTxDDvEQ[i].eeiIHNtQJPFgnTevoCUHauTGfAwib = P_0.get_rewiredId();
					miqGAZpQaDdzaxnlignZkTxDDvEQ[i].iztBmvNUrqkvFnLcNJFJsyzURZnU = P_0.get_systemId();
					miqGAZpQaDdzaxnlignZkTxDDvEQ[i].yTtFaceNnZSwoiEUWsbecwHuLlJkA = P_0.phnTHICrHxGeWimtKbcYLLhlJAXR;
					miqGAZpQaDdzaxnlignZkTxDDvEQ[i].NpbjOZOcrheOqZVZVPtcmElDqPGU = P_0.get_inputManagerId();
					miqGAZpQaDdzaxnlignZkTxDDvEQ[i].YDVCxZuRuJvSIaZZEiiGmLGmYHvs = P_0.WhcgnAGNeozNDWYhEtRiwxJAXXvJA();
					miqGAZpQaDdzaxnlignZkTxDDvEQ[i].JfIwjgwPVndhBOxeUAcBQJmkGabr = P_0.sljKCOvrfPtFYnGNtixOEudlTYTF();
					fjJkwtyAuefgsJkAxfCzkgCWJZVd(P_0.get_rewiredId(), i);
					return;
				}
			}
			miqGAZpQaDdzaxnlignZkTxDDvEQ.Add(new MKMWoWLmartvwUKtjaFpQwQVLpXp(P_0.get_rewiredId(), P_0.get_systemId(), P_0.phnTHICrHxGeWimtKbcYLLhlJAXR, P_0.get_inputManagerId(), P_0.WhcgnAGNeozNDWYhEtRiwxJAXXvJA(), P_0.sljKCOvrfPtFYnGNtixOEudlTYTF()));
			fjJkwtyAuefgsJkAxfCzkgCWJZVd(P_0.get_rewiredId(), miqGAZpQaDdzaxnlignZkTxDDvEQ.Count - 1);
		}

		public bool CSeaaKsWvkUBhSahbJFzfNtmGoLP(CNcBBhnfeXiduGMhSVPCQJTfbUKA P_0, JjtsJZwiHhPQIDNeDsQgppKPVDQx P_1)
		{
			int count = miqGAZpQaDdzaxnlignZkTxDDvEQ.Count;
			for (int i = 0; i < count; i++)
			{
				if (miqGAZpQaDdzaxnlignZkTxDDvEQ[i].mOPJEBDyUDIUyLvpbleKhPVSRfLL(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(DWLXSdQfpePNRhmuvoXmSHxcoQxQ))]
		public IEnumerable<MKMWoWLmartvwUKtjaFpQwQVLpXp> NcPDJHVZLnNpqLjixyDXLnGjoAMV(CNcBBhnfeXiduGMhSVPCQJTfbUKA P_0, JjtsJZwiHhPQIDNeDsQgppKPVDQx P_1)
		{
			return new DWLXSdQfpePNRhmuvoXmSHxcoQxQ(-2)
			{
				pEmYoFaNEbCHelSnHHlaawKSzRPEA = this,
				MfvVmqOhqOYtWhlCtwTCAxPbtddB = P_0,
				oxrxaMWUzfgrpRtXkLqTLkaXARFN = P_1
			};
		}

		public int wXjCdvqgqCjslNitzinsRBtSdKbn(MKMWoWLmartvwUKtjaFpQwQVLpXp P_0)
		{
			int count = miqGAZpQaDdzaxnlignZkTxDDvEQ.Count;
			for (int i = 0; i < count; i++)
			{
				if (miqGAZpQaDdzaxnlignZkTxDDvEQ[i] == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private void fjJkwtyAuefgsJkAxfCzkgCWJZVd(int P_0, int P_1)
		{
			for (int num = miqGAZpQaDdzaxnlignZkTxDDvEQ.Count - 1; num >= 0; num--)
			{
				if (num != P_1 && miqGAZpQaDdzaxnlignZkTxDDvEQ[num].eeiIHNtQJPFgnTevoCUHauTGfAwib == P_0)
				{
					miqGAZpQaDdzaxnlignZkTxDDvEQ.RemoveAt(num);
				}
			}
		}
	}

	private List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> ABVaThwQiXZmXViFeAjNfyCEqnsDA;

	private int XRvmEWnBGafIWCrzbPpCXBEIoTPn;

	private iwKsrmbOBwLCpZnBOxDrCCmihGFB azyaCCitnkbFfWwCMNhnTAOgqhXoA;

	private UpdateLoopType KgtPSMZjPXHOsunnUsPzhEOfJfbS;

	private Action<int, ControllerDataUpdater> ahcNkZyHbDwEkhTLJwsJFqwQNhyd;

	private PlatformInputManager EyoPiCFxvXpDRAAyspLRrnmvchjo;

	private CustomInputSource QrmpqvUwfgAYllQXfWHHuBgnOkBg;

	private bool GAnyFkhukDjjZJUyYAQjkwTTcNHE;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> yQbFXIgBVGQIZOAMjIcclFaQdJpL;

	private Func<int> oMQEHivOVdJCEcGvlUijHqbQEJax;

	[CustomObfuscation(rename = false)]
	int PlatformInputManager.deviceCount => get_deviceCount();

	[CustomObfuscation(rename = false)]
	PlatformInputManager PlatformInputManager.primaryInputManager => get_primaryInputManager();

	[CustomObfuscation(rename = false)]
	IInputSource PlatformInputManager.inputSource => get_inputSource();

	[CustomObfuscation(rename = false)]
	InputSource PlatformInputManager.inputSourceType => get_inputSourceType();

	public CustomInputManager(CustomInputSource P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
	{
		QrmpqvUwfgAYllQXfWHHuBgnOkBg = P_0;
		yQbFXIgBVGQIZOAMjIcclFaQdJpL = P_2;
		oMQEHivOVdJCEcGvlUijHqbQEJax = P_3;
		EyoPiCFxvXpDRAAyspLRrnmvchjo = this;
		try
		{
			ahcNkZyHbDwEkhTLJwsJFqwQNhyd = UpdateControllerData;
			P_0.OJNEWbVCjzctaktWYaxaXdNJNQAw(SystemDeviceConnected);
			P_0.xxHOhxeWWeIvNpXlXFCqMVdJjaPU(SystemDeviceDisconnected);
		}
		catch (Exception)
		{
			OnDestroy();
			throw;
		}
	}

	public virtual int get_deviceCount()
	{
		return XRvmEWnBGafIWCrzbPpCXBEIoTPn;
	}

	public virtual PlatformInputManager get_primaryInputManager()
	{
		return EyoPiCFxvXpDRAAyspLRrnmvchjo;
	}

	public virtual IInputSource get_inputSource()
	{
		return null;
	}

	public virtual InputSource get_inputSourceType()
	{
		return QrmpqvUwfgAYllQXfWHHuBgnOkBg.mLNIopHNHCrePmiGorNqaDbovQKH();
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		azyaCCitnkbFfWwCMNhnTAOgqhXoA = new iwKsrmbOBwLCpZnBOxDrCCmihGFB();
		ABVaThwQiXZmXViFeAjNfyCEqnsDA = new List<CNcBBhnfeXiduGMhSVPCQJTfbUKA>();
		GAnyFkhukDjjZJUyYAQjkwTTcNHE = true;
		QrmpqvUwfgAYllQXfWHHuBgnOkBg.vLobTBkoHLkWgGTJFbSLORdclPkfc();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		KgtPSMZjPXHOsunnUsPzhEOfJfbS = updateLoop;
		if (QrmpqvUwfgAYllQXfWHHuBgnOkBg.isReady)
		{
			QrmpqvUwfgAYllQXfWHHuBgnOkBg.Update();
			QrmpqvUwfgAYllQXfWHHuBgnOkBg.TiyPlhubPjCWsikbKViAwLnzFcUaA();
			if (GAnyFkhukDjjZJUyYAQjkwTTcNHE)
			{
				XQMLDMLbJimUXyFZEEjPrerhrqfq();
			}
			gYHqknlCsmSozuZMJSweViGVmdvm();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (QrmpqvUwfgAYllQXfWHHuBgnOkBg != null)
		{
			QrmpqvUwfgAYllQXfWHHuBgnOkBg.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return ahcNkZyHbDwEkhTLJwsJFqwQNhyd;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < XRvmEWnBGafIWCrzbPpCXBEIoTPn; i++)
		{
			if (ABVaThwQiXZmXViFeAjNfyCEqnsDA[i].get_inputManagerId() == inputManagerId)
			{
				ABVaThwQiXZmXViFeAjNfyCEqnsDA[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		GAnyFkhukDjjZJUyYAQjkwTTcNHE = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		GAnyFkhukDjjZJUyYAQjkwTTcNHE = true;
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickIndex)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return QrmpqvUwfgAYllQXfWHHuBgnOkBg.zbsTkGFlyWYPVbaeiZAucrajmamK();
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return QrmpqvUwfgAYllQXfWHHuBgnOkBg.yrusJnycTryufNRnTDYdTOocFolh();
	}

	private void jfcmjmPwqNMNQwhaalofwClnMZSf(CustomInputSource.Joystick[] P_0)
	{
		int num = 0;
		List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> aBVaThwQiXZmXViFeAjNfyCEqnsDA = ABVaThwQiXZmXViFeAjNfyCEqnsDA;
		int xRvmEWnBGafIWCrzbPpCXBEIoTPn = XRvmEWnBGafIWCrzbPpCXBEIoTPn;
		ABVaThwQiXZmXViFeAjNfyCEqnsDA = new List<CNcBBhnfeXiduGMhSVPCQJTfbUKA>();
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i] != null)
			{
				CNcBBhnfeXiduGMhSVPCQJTfbUKA item = new CNcBBhnfeXiduGMhSVPCQJTfbUKA(QrmpqvUwfgAYllQXfWHHuBgnOkBg, P_0[i].systemId, P_0[i].unityId, P_0[i], QrmpqvUwfgAYllQXfWHHuBgnOkBg.mLNIopHNHCrePmiGorNqaDbovQKH(), P_0[i].extension, yQbFXIgBVGQIZOAMjIcclFaQdJpL);
				ABVaThwQiXZmXViFeAjNfyCEqnsDA.Add(item);
				num++;
			}
		}
		XRvmEWnBGafIWCrzbPpCXBEIoTPn = num;
		XoxNnrwEcDrKpEDFTGKGiOZCMFpoA(xRvmEWnBGafIWCrzbPpCXBEIoTPn, num, aBVaThwQiXZmXViFeAjNfyCEqnsDA, ABVaThwQiXZmXViFeAjNfyCEqnsDA);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(ABVaThwQiXZmXViFeAjNfyCEqnsDA[j]));
			}
		}
		wsBQlFjtXflCoBefXCjfXpywPFgG(aBVaThwQiXZmXViFeAjNfyCEqnsDA, ABVaThwQiXZmXViFeAjNfyCEqnsDA, false);
		wsBQlFjtXflCoBefXCjfXpywPFgG(ABVaThwQiXZmXViFeAjNfyCEqnsDA, aBVaThwQiXZmXViFeAjNfyCEqnsDA, true);
	}

	private void gYHqknlCsmSozuZMJSweViGVmdvm()
	{
		for (int i = 0; i < XRvmEWnBGafIWCrzbPpCXBEIoTPn; i++)
		{
			ABVaThwQiXZmXViFeAjNfyCEqnsDA[i].Update();
		}
	}

	private void XoxNnrwEcDrKpEDFTGKGiOZCMFpoA(int P_0, int P_1, List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> P_2, List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(CNcBBhnfeXiduGMhSVPCQJTfbUKA.HBUGUEwOjgAWqefICDypLWHLAGRAA);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			lUkSawBXddAdKwiZpcLSEsIQwjjb(P_1, P_3, P_0, P_2, iwKsrmbOBwLCpZnBOxDrCCmihGFB.JjtsJZwiHhPQIDNeDsQgppKPVDQx.Exact);
			if (QrmpqvUwfgAYllQXfWHHuBgnOkBg.useApproximateMatching)
			{
				lUkSawBXddAdKwiZpcLSEsIQwjjb(P_1, P_3, P_0, P_2, iwKsrmbOBwLCpZnBOxDrCCmihGFB.JjtsJZwiHhPQIDNeDsQgppKPVDQx.Approximate);
			}
		}
		GYfiktMLsgGIRfhAeqYPrgfjqYgdb(P_1, P_3, iwKsrmbOBwLCpZnBOxDrCCmihGFB.JjtsJZwiHhPQIDNeDsQgppKPVDQx.Exact);
		if (QrmpqvUwfgAYllQXfWHHuBgnOkBg.useApproximateMatching)
		{
			GYfiktMLsgGIRfhAeqYPrgfjqYgdb(P_1, P_3, iwKsrmbOBwLCpZnBOxDrCCmihGFB.JjtsJZwiHhPQIDNeDsQgppKPVDQx.Approximate);
		}
		for (int i = 0; i < P_1; i++)
		{
			CNcBBhnfeXiduGMhSVPCQJTfbUKA cNcBBhnfeXiduGMhSVPCQJTfbUKA = P_3[i];
			if (cNcBBhnfeXiduGMhSVPCQJTfbUKA != null && cNcBBhnfeXiduGMhSVPCQJTfbUKA.get_inputManagerId() < 0)
			{
				cNcBBhnfeXiduGMhSVPCQJTfbUKA.set_inputManagerId(TgaDIuIHTdCBMMamDacMMcJNdFsK(P_3));
				cNcBBhnfeXiduGMhSVPCQJTfbUKA.set_rewiredId(ReInput.GetNewJoystickId());
				azyaCCitnkbFfWwCMNhnTAOgqhXoA.fIDBkChNDeBEMySoSLSMuVlSmxVO(cNcBBhnfeXiduGMhSVPCQJTfbUKA);
			}
		}
		P_3.Sort(CNcBBhnfeXiduGMhSVPCQJTfbUKA.fCeBFuuXlovncyqjqfBBBiTZUGgrA);
	}

	private void QrcbdyGEOfZzmowJiZHtPGaNglFlA(List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> P_0, int P_1, int P_2)
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

	private bool OcscKLHAhgZWQJOgbhVtGniTtKSEA(List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> P_0, int P_1)
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

	private int TgaDIuIHTdCBMMamDacMMcJNdFsK(List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> P_0)
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

	private bool QuGgTycuscNHVxroejmDtcRotHto(List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> P_0, int P_1)
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

	private void lUkSawBXddAdKwiZpcLSEsIQwjjb(int P_0, List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> P_1, int P_2, List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> P_3, iwKsrmbOBwLCpZnBOxDrCCmihGFB.JjtsJZwiHhPQIDNeDsQgppKPVDQx P_4)
	{
		int num = ((P_4 != iwKsrmbOBwLCpZnBOxDrCCmihGFB.JjtsJZwiHhPQIDNeDsQgppKPVDQx.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			CNcBBhnfeXiduGMhSVPCQJTfbUKA cNcBBhnfeXiduGMhSVPCQJTfbUKA = P_1[i];
			if (cNcBBhnfeXiduGMhSVPCQJTfbUKA == null || cNcBBhnfeXiduGMhSVPCQJTfbUKA.get_inputManagerId() >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				CNcBBhnfeXiduGMhSVPCQJTfbUKA cNcBBhnfeXiduGMhSVPCQJTfbUKA2 = P_3[j];
				if (cNcBBhnfeXiduGMhSVPCQJTfbUKA2 != null && !QuGgTycuscNHVxroejmDtcRotHto(P_1, cNcBBhnfeXiduGMhSVPCQJTfbUKA2.get_rewiredId()) && cNcBBhnfeXiduGMhSVPCQJTfbUKA.RKSfFfbpOBhWYWkibaRNYgzgmnuu(cNcBBhnfeXiduGMhSVPCQJTfbUKA2) >= num)
				{
					cNcBBhnfeXiduGMhSVPCQJTfbUKA.set_inputManagerId(cNcBBhnfeXiduGMhSVPCQJTfbUKA2.get_inputManagerId());
					cNcBBhnfeXiduGMhSVPCQJTfbUKA.set_rewiredId(cNcBBhnfeXiduGMhSVPCQJTfbUKA2.get_rewiredId());
					azyaCCitnkbFfWwCMNhnTAOgqhXoA.fIDBkChNDeBEMySoSLSMuVlSmxVO(cNcBBhnfeXiduGMhSVPCQJTfbUKA);
				}
			}
		}
	}

	private void GYfiktMLsgGIRfhAeqYPrgfjqYgdb(int P_0, List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> P_1, iwKsrmbOBwLCpZnBOxDrCCmihGFB.JjtsJZwiHhPQIDNeDsQgppKPVDQx P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			CNcBBhnfeXiduGMhSVPCQJTfbUKA cNcBBhnfeXiduGMhSVPCQJTfbUKA = P_1[i];
			if (cNcBBhnfeXiduGMhSVPCQJTfbUKA == null || cNcBBhnfeXiduGMhSVPCQJTfbUKA.get_inputManagerId() >= 0)
			{
				continue;
			}
			iwKsrmbOBwLCpZnBOxDrCCmihGFB.MKMWoWLmartvwUKtjaFpQwQVLpXp mKMWoWLmartvwUKtjaFpQwQVLpXp = null;
			foreach (iwKsrmbOBwLCpZnBOxDrCCmihGFB.MKMWoWLmartvwUKtjaFpQwQVLpXp item in azyaCCitnkbFfWwCMNhnTAOgqhXoA.NcPDJHVZLnNpqLjixyDXLnGjoAMV(cNcBBhnfeXiduGMhSVPCQJTfbUKA, P_2))
			{
				if (!QuGgTycuscNHVxroejmDtcRotHto(P_1, item.eeiIHNtQJPFgnTevoCUHauTGfAwib) && item.NpbjOZOcrheOqZVZVPtcmElDqPGU >= 0)
				{
					mKMWoWLmartvwUKtjaFpQwQVLpXp = item;
					break;
				}
			}
			if (mKMWoWLmartvwUKtjaFpQwQVLpXp != null)
			{
				int num = mKMWoWLmartvwUKtjaFpQwQVLpXp.NpbjOZOcrheOqZVZVPtcmElDqPGU;
				if (!OcscKLHAhgZWQJOgbhVtGniTtKSEA(P_1, num))
				{
					num = (mKMWoWLmartvwUKtjaFpQwQVLpXp.NpbjOZOcrheOqZVZVPtcmElDqPGU = TgaDIuIHTdCBMMamDacMMcJNdFsK(P_1));
				}
				cNcBBhnfeXiduGMhSVPCQJTfbUKA.set_inputManagerId(num);
				cNcBBhnfeXiduGMhSVPCQJTfbUKA.set_rewiredId(mKMWoWLmartvwUKtjaFpQwQVLpXp.eeiIHNtQJPFgnTevoCUHauTGfAwib);
				azyaCCitnkbFfWwCMNhnTAOgqhXoA.fIDBkChNDeBEMySoSLSMuVlSmxVO(cNcBBhnfeXiduGMhSVPCQJTfbUKA);
			}
		}
	}

	private void XQMLDMLbJimUXyFZEEjPrerhrqfq()
	{
		CustomInputSource.Joystick[] array = QrmpqvUwfgAYllQXfWHHuBgnOkBg.auexoLLSFsCquZmtpUTenKRgFIiCA();
		if (srJfKLAAlEdJPDlmVePFerJKgwEGc(array))
		{
			jfcmjmPwqNMNQwhaalofwClnMZSf(array);
		}
		GAnyFkhukDjjZJUyYAQjkwTTcNHE = false;
	}

	private bool srJfKLAAlEdJPDlmVePFerJKgwEGc(CustomInputSource.Joystick[] P_0)
	{
		int num = P_0.Length;
		int count = ABVaThwQiXZmXViFeAjNfyCEqnsDA.Count;
		if (num != count)
		{
			return true;
		}
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] == null)
			{
				continue;
			}
			long? systemId = P_0[i].systemId;
			bool flag = false;
			for (int j = 0; j < count; j++)
			{
				if (ABVaThwQiXZmXViFeAjNfyCEqnsDA[j] != null && systemId == ABVaThwQiXZmXViFeAjNfyCEqnsDA[j].get_systemId())
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return true;
			}
		}
		for (int k = 0; k < count; k++)
		{
			if (ABVaThwQiXZmXViFeAjNfyCEqnsDA[k] == null)
			{
				continue;
			}
			long? systemId2 = ABVaThwQiXZmXViFeAjNfyCEqnsDA[k].get_systemId();
			bool flag2 = false;
			for (int l = 0; l < num; l++)
			{
				if (P_0[l] != null && systemId2 == P_0[l].systemId)
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2)
			{
				return true;
			}
		}
		return false;
	}

	private void wsBQlFjtXflCoBefXCjfXpywPFgG(List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> P_0, List<CNcBBhnfeXiduGMhSVPCQJTfbUKA> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			CNcBBhnfeXiduGMhSVPCQJTfbUKA cNcBBhnfeXiduGMhSVPCQJTfbUKA = P_0[i];
			if (cNcBBhnfeXiduGMhSVPCQJTfbUKA == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					CNcBBhnfeXiduGMhSVPCQJTfbUKA cNcBBhnfeXiduGMhSVPCQJTfbUKA2 = P_1[j];
					if (cNcBBhnfeXiduGMhSVPCQJTfbUKA2 != null && cNcBBhnfeXiduGMhSVPCQJTfbUKA.get_rewiredId() == cNcBBhnfeXiduGMhSVPCQJTfbUKA2.get_rewiredId())
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				RwxveGhBDTDWMNblmNHCTMHMIvwk(P_0[i], P_2);
			}
		}
	}

	private void RwxveGhBDTDWMNblmNHCTMHMIvwk(CNcBBhnfeXiduGMhSVPCQJTfbUKA P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.KUyvromajolFhGcMtEIHwJvIugDn();
		}
		xKxDcOETRMhTsXGyAPgRkBCEJlNvA(P_0, P_1);
	}

	private void xKxDcOETRMhTsXGyAPgRkBCEJlNvA(CNcBBhnfeXiduGMhSVPCQJTfbUKA P_0, bool P_1)
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
