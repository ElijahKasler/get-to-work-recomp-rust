using System;
using System.Collections.Generic;
using Rewired.Internal;
using Rewired.Internal.Localization;
using Rewired.Platforms.Custom;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Platforms.XboxOne;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal sealed class XboxOneInputSource : CustomInputSource, IXboxOneInputSource
{
	[CustomObfuscation(rename = false)]
	private enum BadConnectionReason
	{
		[CustomObfuscation(rename = false)]
		None = 0,
		[CustomObfuscation(rename = false)]
		GamepadNotActive = 1,
		[CustomObfuscation(rename = false)]
		InvalidName = 2
	}

	private struct KZmSzFsDfIvnREXcRkraYlHLiasD(uint P_0, uint P_1)
	{
		public uint iGSgZUCpbNZMWQyuIfBARwBXNIZI = P_0;

		public uint wfuMgfxuWtrrUCXxKDuHyhRwKwbG = P_1;
	}

	private class oenyAjMYzHbsEkLjjxroOzlAgLas : Joystick, ITryGetLocalizedName, IInputManagerHardwareJoystickMapHandler
	{
		private const int RcUDHXDtHWmMrxzHDeSJuNYHGMQs = 6;

		private const int RGfTCqmZfrdNeMmvnvdTgYWDbyxd = 14;

		private const string vJKDuWZBDRSydFAhLgOjHrwOAwsh = "Xbox One Controller";

		private const string ExxysJRBJrMVghWmlNEymiRBBXSJ = "Controller";

		private const int ZrfQQvWrMeiGhWyMNhmQNLUAJZBR = 0;

		private const int echQhXhJADjPGvwzBbYbudiLrYhS = 1;

		private const int JUMvOrjXSdPafNXlXlYJHqhSWnIA = 2;

		private const int RDzOEbGxiRDrTJAXptdPscNjcSjdA = 3;

		private const int REogfFXjmgCLZaABKGITTAnHXNTCA = 4;

		private const int PYykYvgbMpCXKQYRjXneZljCcfmG = 5;

		private const int QPDtuODMCKMOhAlIdSvTEuhvrlth = 6;

		private const int GYHDJaMLzVgjuhinpKjnPlotMyee = 7;

		private const int QWrpeQIBxSHvpabuzbAishBYLCcl = 8;

		private const int mGLquUzVmYFFxjlujDdUhUksreAE = 9;

		private const int nQIXRDadOMMHYvCRTfzcUhvZOkPJ = 12;

		private const int YlNsGEbJzfCPZyZexlSsiEoeucBT = 13;

		private const int nBSwUzRwLNdmFKsTBelwpcRjzJhV = 14;

		private const int oElAYFantrTNCZAdmxkHMgEYJHPp = 15;

		private const int smIgkSHVDvNeKytdmgHJRljANGeo = 0;

		private const int zndUtlGJgybYXruZqoANPOzOpspb = 1;

		private const int tXhuSUfTHwmDmjAVCnmMGNdlBEXr = 3;

		private const int PmlWGZsAefYYEJJyjlFOPsJZhGCR = 4;

		private const int NOAMVtAWdURuUfLByARkdgWoqljf = 8;

		private const int PowBptMlSGphxrenNMADnoEXbiBIA = 9;

		private readonly IXboxOneInputSource zwhrZvZsxTIybvlyCLMIgDzcUjEs;

		private int KdINtEItttFVwHMnNhoZJzGoTfXo;

		private ulong lvXCpxYyHDwMJFpiOdHBbYaFEjVAb;

		private string[] QPhnmScCDcEQVJTiRwQydEhGNtwtA;

		private HardwareJoystickMap_InputManager PjAntDRhlNevAldegxEnBozbwYYe;

		private readonly LocalizedString iufuAcQPlPnciaQMrMRsDnzzFyCB;

		public ulong hFrkZFhfPSnoHiJEdmGFuAQNdXiu => uYlyTCrHcDYLmCzfAzmfUPYZSRhC();

		public ulong uYlyTCrHcDYLmCzfAzmfUPYZSRhC()
		{
			return lvXCpxYyHDwMJFpiOdHBbYaFEjVAb;
		}

		public oenyAjMYzHbsEkLjjxroOzlAgLas(IXboxOneInputSource P_0, ulong P_1, int P_2, bool P_3)
			: base(P_3 ? UnityTools.externalTools.XboxOneInput_GetControllerType(P_1) : "Xbox One Controller", (long)P_1, P_2, 6, 14)
		{
			zwhrZvZsxTIybvlyCLMIgDzcUjEs = P_0;
			KdINtEItttFVwHMnNhoZJzGoTfXo = P_2 - 1;
			QPhnmScCDcEQVJTiRwQydEhGNtwtA = new string[6];
			AwrGKSSxmKUJvxcmeULVxIvVMgpl();
			iufuAcQPlPnciaQMrMRsDnzzFyCB = new LocalizedString();
			base.extension = new XboxOneGamepadExtension(true, P_0);
			_isConnected = P_3;
			if (_isConnected)
			{
				ZTyHWyhParoaSCThdbbvldDCtAoe(P_1);
			}
			else
			{
				lvXCpxYyHDwMJFpiOdHBbYaFEjVAb = P_1;
			}
		}

		public virtual void lxhjppEDQbduHrIuQnzUydFawhOB()
		{
			if (_isConnected)
			{
				IList<Button> buttons = base.Buttons;
				buttons[0].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(0);
				buttons[1].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(1);
				buttons[2].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(2);
				buttons[3].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(3);
				buttons[4].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(4);
				buttons[5].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(5);
				buttons[6].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(6);
				buttons[7].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(7);
				buttons[8].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(8);
				buttons[9].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(9);
				buttons[10].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(12);
				buttons[11].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(15);
				buttons[12].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(13);
				buttons[13].boolValue = XiMZEGRLfovrXhlRrKIfxEZDaTxL(14);
				IList<Axis> axes = base.Axes;
				axes[0].value = Input.GetAxisRaw(QPhnmScCDcEQVJTiRwQydEhGNtwtA[0]);
				axes[1].value = Input.GetAxisRaw(QPhnmScCDcEQVJTiRwQydEhGNtwtA[1]);
				axes[2].value = Input.GetAxisRaw(QPhnmScCDcEQVJTiRwQydEhGNtwtA[2]);
				axes[3].value = Input.GetAxisRaw(QPhnmScCDcEQVJTiRwQydEhGNtwtA[3]);
				axes[4].value = Input.GetAxisRaw(QPhnmScCDcEQVJTiRwQydEhGNtwtA[4]);
				axes[5].value = Input.GetAxisRaw(QPhnmScCDcEQVJTiRwQydEhGNtwtA[5]);
			}
		}

		public void ZTyHWyhParoaSCThdbbvldDCtAoe(ulong P_0)
		{
			if (!_isConnected)
			{
				_isConnected = true;
				lvXCpxYyHDwMJFpiOdHBbYaFEjVAb = P_0;
				base.systemId = (long)P_0;
				if (UnityTools.externalTools.XboxOneInput_GetJoystickId(P_0) != (uint)base.unityId)
				{
					Logger.LogError("Unity joystick id does not match expected id!");
					_isConnected = false;
				}
				else
				{
					ChZdnkdSSOPEddSHQwtcGJYloTpC();
				}
			}
		}

		private void ChZdnkdSSOPEddSHQwtcGJYloTpC()
		{
			if (_isConnected)
			{
				_deviceName = UnityTools.externalTools.XboxOneInput_GetControllerType(lvXCpxYyHDwMJFpiOdHBbYaFEjVAb);
			}
			_customName = string.Format("{0} {1}", "Controller", base.unityId);
			iufuAcQPlPnciaQMrMRsDnzzFyCB.Clear();
		}

		private bool XiMZEGRLfovrXhlRrKIfxEZDaTxL(int P_0)
		{
			return Input.GetKey((KeyCode)(350 + P_0 + KdINtEItttFVwHMnNhoZJzGoTfXo * 20));
		}

		private void AwrGKSSxmKUJvxcmeULVxIvVMgpl()
		{
			QPhnmScCDcEQVJTiRwQydEhGNtwtA[0] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 0);
			QPhnmScCDcEQVJTiRwQydEhGNtwtA[1] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 1);
			QPhnmScCDcEQVJTiRwQydEhGNtwtA[2] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 3);
			QPhnmScCDcEQVJTiRwQydEhGNtwtA[3] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 4);
			QPhnmScCDcEQVJTiRwQydEhGNtwtA[4] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 8);
			QPhnmScCDcEQVJTiRwQydEhGNtwtA[5] = UnityTools.GetUnityInputAxisNameByJoystickId(base.unityId, 9);
		}

		void IInputManagerHardwareJoystickMapHandler.InitializeHardwareJoystickMap(HardwareJoystickMap_InputManager hardwareMap)
		{
			PjAntDRhlNevAldegxEnBozbwYYe = hardwareMap;
		}

		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if (PjAntDRhlNevAldegxEnBozbwYYe == null)
			{
				value = null;
				return false;
			}
			if ((LocalizationManager.GetAndUpdateLocalizedString(iufuAcQPlPnciaQMrMRsDnzzFyCB, PjAntDRhlNevAldegxEnBozbwYYe.deviceLocalizationInfo.parentKeys, "controller", "Controller", out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				value = $"{value} {base.unityId}";
				iufuAcQPlPnciaQMrMRsDnzzFyCB.cachedValue = value;
			}
			return true;
		}
	}

	private const int TGeGtNfVErqmSuEVytzEGZJXmTYHA = 8;

	private readonly bool kSLNYWeAHXdYbMZhmMSjaPXISegB;

	private bool ZvdhLPtxXYLzTdNRHkijVFAXbpQH;

	private Queue<KZmSzFsDfIvnREXcRkraYlHLiasD> OVGapsEJknsuEfdvAFfNhhfTwyDOA;

	private bool OKfQfmUZdJwkCIjQbBchaNzXVLEp;

	bool CustomInputSource.isReady => get_isReady();

	public bool get_isReady()
	{
		return kSLNYWeAHXdYbMZhmMSjaPXISegB;
	}

	public XboxOneInputSource()
		: base(21)
	{
		try
		{
			OVGapsEJknsuEfdvAFfNhhfTwyDOA = new Queue<KZmSzFsDfIvnREXcRkraYlHLiasD>();
			base.useApproximateMatching = false;
			for (int i = 0; i < 8; i++)
			{
				int num = i + 1;
				bool flag = UwlKnEznxzwubksnItdxAmWrTdlr((uint)num, true, out var _);
				ulong num2 = (flag ? UnityTools.externalTools.XboxOneInput_GetControllerId((uint)num) : 0);
				AddJoystick(new oenyAjMYzHbsEkLjjxroOzlAgLas(this, num2, num, flag)
				{
					supportsVibration = true
				});
			}
			UnityTools.externalTools.XboxOneInput_OnGamepadStateChange += GONbpfYITgQNLUIMpPAKScBQYbqT;
			kSLNYWeAHXdYbMZhmMSjaPXISegB = true;
		}
		catch
		{
		}
	}

	public override void Update()
	{
		if (kSLNYWeAHXdYbMZhmMSjaPXISegB)
		{
			FyRfQPkYANPTagosYnggAydBswrh();
			UnityTools.externalTools.XboxOne_Gamepad_UpdatePlugin();
			IList<Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				joysticks[i].Update();
			}
		}
	}

	private void GONbpfYITgQNLUIMpPAKScBQYbqT(uint P_0, bool P_1)
	{
		if (!kSLNYWeAHXdYbMZhmMSjaPXISegB)
		{
			return;
		}
		if (P_0 == 0)
		{
			Logger.LogError("Invalid unity joystick id");
		}
		else if (P_1)
		{
			if (UwlKnEznxzwubksnItdxAmWrTdlr(P_0, true, out var _))
			{
				OHjGLPIwNfkhQqHGGOSlMmUzaxiaA(P_0, true);
			}
		}
		else
		{
			int index = (int)(P_0 - 1);
			(GetJoysticks()[index] as oenyAjMYzHbsEkLjjxroOzlAgLas).Disconnect();
			OnJoystickDisconnected();
		}
	}

	private void OHjGLPIwNfkhQqHGGOSlMmUzaxiaA(uint P_0, bool P_1)
	{
		int index = (int)(P_0 - 1);
		oenyAjMYzHbsEkLjjxroOzlAgLas obj = GetJoysticks()[index] as oenyAjMYzHbsEkLjjxroOzlAgLas;
		ulong num = UnityTools.externalTools.XboxOneInput_GetControllerId(P_0);
		obj.ZTyHWyhParoaSCThdbbvldDCtAoe(num);
		if (P_1)
		{
			OnJoystickConnected();
		}
	}

	private void FyRfQPkYANPTagosYnggAydBswrh()
	{
		int num = OVGapsEJknsuEfdvAFfNhhfTwyDOA.Count;
		if (num == 0)
		{
			return;
		}
		bool flag = false;
		uint currentFrame = ReInput.time.currentFrame;
		while (num > 0)
		{
			KZmSzFsDfIvnREXcRkraYlHLiasD item = OVGapsEJknsuEfdvAFfNhhfTwyDOA.Dequeue();
			if (currentFrame >= item.wfuMgfxuWtrrUCXxKDuHyhRwKwbG + 1)
			{
				if (UwlKnEznxzwubksnItdxAmWrTdlr(item.iGSgZUCpbNZMWQyuIfBARwBXNIZI, true, out var _))
				{
					OHjGLPIwNfkhQqHGGOSlMmUzaxiaA(item.iGSgZUCpbNZMWQyuIfBARwBXNIZI, false);
					flag = true;
				}
			}
			else
			{
				OVGapsEJknsuEfdvAFfNhhfTwyDOA.Enqueue(item);
			}
			num--;
		}
		if (flag)
		{
			OnJoystickConnected();
		}
	}

	private bool UwlKnEznxzwubksnItdxAmWrTdlr(uint P_0, bool P_1, out BadConnectionReason P_2)
	{
		if (!UnityTools.externalTools.XboxOneInput_IsGamepadActive(P_0))
		{
			P_2 = BadConnectionReason.GamepadNotActive;
			return false;
		}
		string text = UnityTools.externalTools.XboxOneInput_GetControllerType(UnityTools.externalTools.XboxOneInput_GetControllerId(P_0));
		if (string.IsNullOrEmpty(text) || text == " ")
		{
			if (P_1)
			{
				OVGapsEJknsuEfdvAFfNhhfTwyDOA.Enqueue(new KZmSzFsDfIvnREXcRkraYlHLiasD(P_0, ReInput.time.currentFrame));
			}
			P_2 = BadConnectionReason.InvalidName;
			return false;
		}
		P_2 = BadConnectionReason.None;
		return true;
	}

	private void zmQSrAjonxPRkyIDdVanSIHOIlYA()
	{
		if (!ZvdhLPtxXYLzTdNRHkijVFAXbpQH)
		{
			ZvdhLPtxXYLzTdNRHkijVFAXbpQH = true;
			Logger.LogError("A required native library is missing! See documentation for Xbox One installation instructions.");
		}
	}

	public int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
	{
		if (!kSLNYWeAHXdYbMZhmMSjaPXISegB)
		{
			return -1;
		}
		return UnityTools.externalTools.XboxOneInput_GetUserIdForGamepad((uint)unityJoystickId);
	}

	int IXboxOneInputSource.GetXboxOneUserIdFromUnityJoystick(int unityJoystickId)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetXboxOneUserIdFromUnityJoystick
		return this.GetXboxOneUserIdFromUnityJoystick(unityJoystickId);
	}

	public void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
	{
		if (kSLNYWeAHXdYbMZhmMSjaPXISegB)
		{
			ulong durationMS = (ulong)(duration * 1000f);
			UnityTools.externalTools.XboxOne_Gamepad_PulseVibrateMotor(xboxOneJoystickId, (int)motor, startLevel, endLevel, durationMS);
		}
	}

	void IXboxOneInputSource.PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
	{
		//ILSpy generated this explicit interface implementation from .override directive in PulseVibrateMotor
		this.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
	}

	public bool SetXboxOneVibration(ulong xboxOneJoystickId, ScRkIYlonjqaoTPfnDTZtxVVYNnp vibration)
	{
		if (!kSLNYWeAHXdYbMZhmMSjaPXISegB)
		{
			return false;
		}
		return UnityTools.externalTools.XboxOne_Gamepad_SetGamepadVibration(xboxOneJoystickId, vibration.ESlMuLkgKQnsAiPybXNJByaVwZDJ, vibration.VefzwrGRWKTsFgECSEzSpAidmpPs, vibration.BcRJsscedBhCNKgzjQHIEGwWvJUoA, vibration.dbAJcQXqVdfEbCdsadMccSNgOvCmc);
	}

	bool IXboxOneInputSource.SetXboxOneVibration(ulong xboxOneJoystickId, ScRkIYlonjqaoTPfnDTZtxVVYNnp vibration)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetXboxOneVibration
		return this.SetXboxOneVibration(xboxOneJoystickId, vibration);
	}

	public override void Dispose()
	{
		base.Dispose();
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	~XboxOneInputSource()
	{
		Dispose(disposing: false);
	}

	protected override void Dispose(bool disposing)
	{
		if (!OKfQfmUZdJwkCIjQbBchaNzXVLEp)
		{
			if (disposing)
			{
				UnityTools.externalTools.XboxOneInput_OnGamepadStateChange -= GONbpfYITgQNLUIMpPAKScBQYbqT;
			}
			OKfQfmUZdJwkCIjQbBchaNzXVLEp = true;
		}
	}
}
