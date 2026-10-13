using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Rewired.ControllerExtensions;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal abstract class NintendoSwitchGamepadDriver : HIDDeviceDriver, IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IDisposable
{
	protected enum eBJeJyFgStXbLxxnXTUKFCvncgku
	{
		ProController = 0,
		JoyConLeft = 1,
		JoyConRight = 2
	}

	protected class EqMxffVpNcyevpCyVGSsdOHINCZHb
	{
		private UJKgOyiCpkBVwnefNmaagmCQWRFGb zoihjEeaTQvlOhqKoIEsBFIOgtkGA;

		private IxaPhFYamiJcEhspVhvZxdUuZarl CTFoBOFjMresmFVNCOturLEiRksVA;

		private float QseSeaLnULBuECGhpnsTYMsXiPRyA;

		private double QsveoaFjmBICAyajbjhyXTNtSxRJA;

		public IxaPhFYamiJcEhspVhvZxdUuZarl rBIGbGRZsJKXHnXpwlOksoZlwFil => NIdOuZJfSdhPTXXRYFJQnuTPZild();

		public IxaPhFYamiJcEhspVhvZxdUuZarl NIdOuZJfSdhPTXXRYFJQnuTPZild()
		{
			return CTFoBOFjMresmFVNCOturLEiRksVA;
		}

		public EqMxffVpNcyevpCyVGSsdOHINCZHb(UJKgOyiCpkBVwnefNmaagmCQWRFGb P_0)
		{
			zoihjEeaTQvlOhqKoIEsBFIOgtkGA = P_0;
			ISHcmdaXQNImznWqRlEBRKLoLURFb();
		}

		public void DgDiHjKmZmmCPfoRPRWWgHLasmmv(float P_0, float P_1, float P_2, float P_3, float P_4)
		{
			if (P_4 < 0f)
			{
				P_4 = 0f;
			}
			QseSeaLnULBuECGhpnsTYMsXiPRyA = P_4;
			CTFoBOFjMresmFVNCOturLEiRksVA.mXxnoytxpEvsnDJIjKKRxQfKdSwL = MathTools.Clamp01(P_0);
			CTFoBOFjMresmFVNCOturLEiRksVA.TMEBxhrTlUEFEpdEcOPhgQKVEbxM = MathTools.Clamp(P_1, 40.875885f, 626.28613f);
			CTFoBOFjMresmFVNCOturLEiRksVA.BQCjvYYJvHROoEpWwFqQcDMykPuuA = MathTools.Clamp01(P_2);
			CTFoBOFjMresmFVNCOturLEiRksVA.gBYCQpigiqPSQeAaXAHsEIvjkdGSc = MathTools.Clamp(P_3, 81.75177f, 1252.5723f);
			zoihjEeaTQvlOhqKoIEsBFIOgtkGA.PpwdGZtDTfEXYRzvADURwiBhyEjQ(Math.Max(CTFoBOFjMresmFVNCOturLEiRksVA.mXxnoytxpEvsnDJIjKKRxQfKdSwL, CTFoBOFjMresmFVNCOturLEiRksVA.BQCjvYYJvHROoEpWwFqQcDMykPuuA));
			QsveoaFjmBICAyajbjhyXTNtSxRJA = ReInput.realTime;
		}

		public void BIJwWnGRqlLuaeYeNFhxPhtnhCtF(double P_0)
		{
			if ((CTFoBOFjMresmFVNCOturLEiRksVA.mXxnoytxpEvsnDJIjKKRxQfKdSwL > 0f || CTFoBOFjMresmFVNCOturLEiRksVA.BQCjvYYJvHROoEpWwFqQcDMykPuuA > 0f) && QseSeaLnULBuECGhpnsTYMsXiPRyA > 0f && P_0 >= QsveoaFjmBICAyajbjhyXTNtSxRJA + (double)QseSeaLnULBuECGhpnsTYMsXiPRyA)
			{
				YtNTRYdQfWbqEacrAtIOVqkiZggn();
			}
		}

		public void YtNTRYdQfWbqEacrAtIOVqkiZggn()
		{
			CTFoBOFjMresmFVNCOturLEiRksVA.BQCjvYYJvHROoEpWwFqQcDMykPuuA = 0f;
			CTFoBOFjMresmFVNCOturLEiRksVA.mXxnoytxpEvsnDJIjKKRxQfKdSwL = 0f;
			zoihjEeaTQvlOhqKoIEsBFIOgtkGA.ZzeucWTvdVBzsUkrmxpdrFxcbvgG(0);
			QseSeaLnULBuECGhpnsTYMsXiPRyA = 0f;
			QsveoaFjmBICAyajbjhyXTNtSxRJA = ReInput.realTime;
		}

		public void ISHcmdaXQNImznWqRlEBRKLoLURFb()
		{
			CTFoBOFjMresmFVNCOturLEiRksVA = IxaPhFYamiJcEhspVhvZxdUuZarl.IGlErBynIxWZvuayRpaGiIaIrkQb();
			zoihjEeaTQvlOhqKoIEsBFIOgtkGA.ZzeucWTvdVBzsUkrmxpdrFxcbvgG(0);
			QseSeaLnULBuECGhpnsTYMsXiPRyA = 0f;
			QsveoaFjmBICAyajbjhyXTNtSxRJA = 0.0;
		}
	}

	protected struct IxaPhFYamiJcEhspVhvZxdUuZarl
	{
		public const int kVZMQEnGwYFzbdONqWeTfTQrbolj = 160;

		public const int TfAubTnPopQssYgNNJTMtpAFKTyv = 320;

		public float mXxnoytxpEvsnDJIjKKRxQfKdSwL;

		public float TMEBxhrTlUEFEpdEcOPhgQKVEbxM;

		public float BQCjvYYJvHROoEpWwFqQcDMykPuuA;

		public float gBYCQpigiqPSQeAaXAHsEIvjkdGSc;

		internal IxaPhFYamiJcEhspVhvZxdUuZarl(float P_0, float P_1, float P_2, float P_3)
		{
			if (P_0 < 0f)
			{
				P_0 = 0f;
			}
			if (P_0 > 1f)
			{
				P_0 = 1f;
			}
			if (P_1 < 0f)
			{
				P_1 = 0f;
			}
			if (P_2 < 0f)
			{
				P_2 = 0f;
			}
			if (P_2 > 1f)
			{
				P_2 = 1f;
			}
			if (P_3 < 0f)
			{
				P_3 = 0f;
			}
			mXxnoytxpEvsnDJIjKKRxQfKdSwL = P_0;
			TMEBxhrTlUEFEpdEcOPhgQKVEbxM = P_1;
			BQCjvYYJvHROoEpWwFqQcDMykPuuA = P_2;
			gBYCQpigiqPSQeAaXAHsEIvjkdGSc = P_3;
		}

		public static IxaPhFYamiJcEhspVhvZxdUuZarl IGlErBynIxWZvuayRpaGiIaIrkQb()
		{
			return new IxaPhFYamiJcEhspVhvZxdUuZarl(0f, 160f, 0f, 320f);
		}

		public string LcQFgFglTlZXXTvMpoyRDJWJjMPFb()
		{
			return "amplitudeLow: " + mXxnoytxpEvsnDJIjKKRxQfKdSwL + ", frequencyLow: " + TMEBxhrTlUEFEpdEcOPhgQKVEbxM + ", amplitudeHigh: " + BQCjvYYJvHROoEpWwFqQcDMykPuuA + ", frequencyHigh: " + gBYCQpigiqPSQeAaXAHsEIvjkdGSc;
		}
	}

	private struct lzvvVHoRtiHCGQOzxSxjdnvjlWUq(byte P_0, byte[] P_1, int P_2)
	{
		public byte meWphLYIsFmGOelfVDvnnInlttfJ = P_0;

		public byte[] xmHOLlztrNvmcXasgevaYVOggyln = P_1;

		public int xwOnLWoPGfyplSlQUEZtdNfUgZOA = P_2;
	}

	protected class dgskCNnyEMRGYOKbhcRAWCtfXHNO
	{
		public ushort QWxxcDIxDOFRzNTqWlckLnOoWPfW;

		public ushort CysLVzeaAGLIcAOeVWEhyfVDWAIW;

		public ushort paoGVlrAgPANDNMyTGfAamLihFAXA;

		public ushort YlilqyacAZXbuBtpInUAsHAMxZeV;

		public virtual string ZQehLYskzaTzylFpDavuBYGdDbue()
		{
			return "min: " + QWxxcDIxDOFRzNTqWlckLnOoWPfW + ", max: " + CysLVzeaAGLIcAOeVWEhyfVDWAIW + ", zero: " + paoGVlrAgPANDNMyTGfAamLihFAXA + ", deadzone: " + YlilqyacAZXbuBtpInUAsHAMxZeV;
		}
	}

	protected const byte INPUT_REPORT_ID = 33;

	protected const byte OUTPUT_REPORT_COMMAND_GET_INPUT = 31;

	protected const byte OUTPUT_RUMBLE_AND_SUBCMD = 1;

	protected const byte OUTPUT_FW_UPDATE_PKT = 3;

	protected const byte OUTPUT_RUMBLE_ONLY = 16;

	protected const byte OUTPUT_MCU_DATA = 17;

	protected const byte OUTPUT_USB_CMD = 128;

	protected const byte SUBCMD_STATE = 0;

	protected const byte SUBCMD_MANUAL_BT_PAIRING = 1;

	protected const byte SUBCMD_REQ_DEV_INFO = 2;

	protected const byte SUBCMD_SET_REPORT_MODE = 3;

	protected const byte SUBCMD_TRIGGERS_ELAPSED = 4;

	protected const byte SUBCMD_GET_PAGE_LIST_STATE = 5;

	protected const byte SUBCMD_SET_HCI_STATE = 6;

	protected const byte SUBCMD_RESET_PAIRING_INFO = 7;

	protected const byte SUBCMD_LOW_POWER_MODE = 8;

	protected const byte SUBCMD_SPI_FLASH_READ = 16;

	protected const byte SUBCMD_SPI_FLASH_WRITE = 17;

	protected const byte SUBCMD_RESET_MCU = 32;

	protected const byte SUBCMD_SET_MCU_CONFIG = 33;

	protected const byte SUBCMD_SET_MCU_STATE = 34;

	protected const byte SUBCMD_SET_PLAYER_LIGHTS = 48;

	protected const byte SUBCMD_GET_PLAYER_LIGHTS = 49;

	protected const byte SUBCMD_SET_HOME_LIGHT = 56;

	protected const byte SUBCMD_ENABLE_IMU = 64;

	protected const byte SUBCMD_SET_IMU_SENSITIVITY = 65;

	protected const byte SUBCMD_WRITE_IMU_REG = 66;

	protected const byte SUBCMD_READ_IMU_REG = 67;

	protected const byte SUBCMD_ENABLE_VIBRATION = 72;

	protected const byte SUBCMD_GET_REGULATED_VOLTAGE = 80;

	protected const byte INPUT_BUTTON_EVENT = 63;

	protected const byte INPUT_SUBCMD_REPLY = 33;

	protected const byte INPUT_IMU_DATA = 48;

	protected const byte INPUT_MCU_DATA = 49;

	protected const byte INPUT_USB_RESPONSE = 129;

	protected const byte FEATURE_LAST_SUBCMD = 2;

	protected const byte FEATURE_OTA_FW_UPGRADE = 112;

	protected const byte FEATURE_SETUP_MEM_READ = 113;

	protected const byte FEATURE_MEM_READ = 114;

	protected const byte FEATURE_ERASE_MEM_SECTOR = 115;

	protected const byte FEATURE_MEM_WRITE = 116;

	protected const byte FEATURE_LAUNCH = 117;

	protected const byte USB_CMD_CONN_STATUS = 1;

	protected const byte USB_CMD_HANDSHAKE = 2;

	protected const byte USB_CMD_BAUDRATE_3M = 3;

	protected const byte USB_CMD_NO_TIMEOUT = 4;

	protected const byte USB_CMD_EN_TIMEOUT = 5;

	protected const byte USB_RESET = 6;

	protected const byte USB_PRE_HANDSHAKE = 145;

	protected const byte USB_SEND_UART = 146;

	protected const ushort CAL_DATA_START = 24637;

	protected const ushort CAL_DATA_END = 24654;

	protected const ushort CAL_DATA_SIZE = 18;

	protected const int MIN_INPUT_REPORT_SIZE = 49;

	protected const int SUBCOMMAND_INPUT_REPORT_SIZE = 49;

	protected const float VIBRATION_FREQUENCY_LOW_MIN = 40.875885f;

	protected const float VIBRATION_FREQUENCY_LOW_MAX = 626.28613f;

	protected const float VIBRATION_FREQUENCY_HIGH_MIN = 81.75177f;

	protected const float VIBRATION_FREQUENCY_HIGH_MAX = 1252.5723f;

	protected const float NOINPUTREPORT_REINIT_HACK_TIMEOUT_SEC = 1f;

	protected const int DEVICE_POLL_RATE_HZ = 66;

	protected const int HID_AXIS_MIN_VALUE = 0;

	protected const int HID_AXIS_MAX_VALUE = 65535;

	protected const int HID_AXIS_ZERO_VALUE = 32767;

	protected const int HID_AXIS_BITS = 16;

	protected const int HID_AXIS_BYTES = 2;

	protected readonly eBJeJyFgStXbLxxnXTUKFCvncgku _controllerType;

	protected readonly int _buttonCount;

	protected readonly int _axisCount;

	protected readonly int _vibrationMotorCount;

	private readonly IHIDDevice VdCYEUKBWPXIeubViuwJKndEwkAI;

	private readonly HIDProperties RgVgfWkRbFAOJoCVIaKWrjZtPPFBA;

	private readonly bool SgkqxACuLdCPxeOGIinRAnVVOjAoA;

	private readonly NativeBuffer JylGWydzqHreYkEBoIEoyvABumLC;

	private readonly NativeBuffer BbCLoSXMjEvqojSkcBaUVaOfBtjo;

	private readonly NativeBuffer PeFowWDdPaHOJgtyGcTpChaRragQ;

	private readonly byte[] qeisXpyOFFGjHplEgzvmzIACHmLF;

	private readonly NativeBuffer yBkvFgdrZROVDncWvuoBOJHKjTrIA;

	private readonly NativeBuffer jZcLaBVYTqYQnwBCWgEkOtwTeMEs;

	private YgqnhctsoyAiZixKeAsniiZNPqQeA rfOVUxQLnsAuhFwuTdNpFOHSfArzA;

	private double OjwnqMpVWNpItymevqprYVpIVIKv;

	private byte UuBLbdHYyaaUQMjvfUqMlTBTWXXS;

	private double HyZKKYxHjMfzXfxtUPzLmBZQQFnUA;

	private bool cJMFnfofTisddwrSwcVtAjXQZsSEA;

	private bool rEmImDYWqidMtmJEIjfTOvoOljFg;

	private EqMxffVpNcyevpCyVGSsdOHINCZHb[] xWZrwnnMqVTLbUkKWfIFGhxOqyeV;

	private dgskCNnyEMRGYOKbhcRAWCtfXHNO[] gClVdaHmcrGlOXpziPikExYwSTzS;

	private static readonly byte[] mSxlABhlzLQlXMmHaAhEFzoIRBZR = new byte[8] { 0, 1, 64, 64, 0, 1, 64, 64 };

	int IDriver_NintendoSwitchController.vibrationMotorCount => get_vibrationMotorCount();

	ushort IHIDControllerExtension.vendorId => RgVgfWkRbFAOJoCVIaKWrjZtPPFBA.vendorId;

	ushort IHIDControllerExtension.productId => RgVgfWkRbFAOJoCVIaKWrjZtPPFBA.productId;

	string IHIDControllerExtension.productName => RgVgfWkRbFAOJoCVIaKWrjZtPPFBA.productName;

	string IHIDControllerExtension.manufacturer => RgVgfWkRbFAOJoCVIaKWrjZtPPFBA.manufacturer;

	ushort IHIDControllerExtension.usagePage => RgVgfWkRbFAOJoCVIaKWrjZtPPFBA.usagePage;

	ushort IHIDControllerExtension.usage => RgVgfWkRbFAOJoCVIaKWrjZtPPFBA.usage;

	public int get_vibrationMotorCount()
	{
		return _vibrationMotorCount;
	}

	public void GetVibration(int motorIndex, out float amplitudeLow, out float frequencyLow, out float amplitudeHigh, out float frequencyHigh)
	{
		if (motorIndex < 0 || motorIndex >= _vibrationMotorCount)
		{
			amplitudeLow = 0f;
			frequencyLow = 0f;
			amplitudeHigh = 0f;
			frequencyHigh = 0f;
		}
		else
		{
			IxaPhFYamiJcEhspVhvZxdUuZarl ixaPhFYamiJcEhspVhvZxdUuZarl = xWZrwnnMqVTLbUkKWfIFGhxOqyeV[motorIndex].NIdOuZJfSdhPTXXRYFJQnuTPZild();
			amplitudeLow = ixaPhFYamiJcEhspVhvZxdUuZarl.mXxnoytxpEvsnDJIjKKRxQfKdSwL;
			frequencyLow = ixaPhFYamiJcEhspVhvZxdUuZarl.TMEBxhrTlUEFEpdEcOPhgQKVEbxM;
			amplitudeHigh = ixaPhFYamiJcEhspVhvZxdUuZarl.BQCjvYYJvHROoEpWwFqQcDMykPuuA;
			frequencyHigh = ixaPhFYamiJcEhspVhvZxdUuZarl.gBYCQpigiqPSQeAaXAHsEIvjkdGSc;
		}
	}

	void IDriver_NintendoSwitchController.GetVibration(int motorIndex, out float amplitudeLow, out float frequencyLow, out float amplitudeHigh, out float frequencyHigh)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetVibration
		this.GetVibration(motorIndex, out amplitudeLow, out frequencyLow, out amplitudeHigh, out frequencyHigh);
	}

	public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
	{
		SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, 0f, stopOtherMotors: false);
	}

	void IDriver_NintendoSwitchController.SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetVibration
		this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh);
	}

	public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
	{
		SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, 0f, stopOtherMotors);
	}

	void IDriver_NintendoSwitchController.SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetVibration
		this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, stopOtherMotors);
	}

	public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
	{
		SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration, stopOtherMotors: false);
	}

	void IDriver_NintendoSwitchController.SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetVibration
		this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
	}

	public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
	{
		if (motorIndex >= 0 && motorIndex < _vibrationMotorCount)
		{
			if (stopOtherMotors)
			{
				eVECGMTrHsHNwzJShbSHrWKkYABb(motorIndex);
			}
			xWZrwnnMqVTLbUkKWfIFGhxOqyeV[motorIndex].DgDiHjKmZmmCPfoRPRWWgHLasmmv(amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
		}
	}

	void IDriver_NintendoSwitchController.SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetVibration
		this.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration, stopOtherMotors);
	}

	public void StopVibration(int motorIndex)
	{
		if (motorIndex >= 0 && motorIndex < _vibrationMotorCount)
		{
			xWZrwnnMqVTLbUkKWfIFGhxOqyeV[motorIndex].YtNTRYdQfWbqEacrAtIOVqkiZggn();
		}
	}

	void IDriver_NintendoSwitchController.StopVibration(int motorIndex)
	{
		//ILSpy generated this explicit interface implementation from .override directive in StopVibration
		this.StopVibration(motorIndex);
	}

	public void StopVibration()
	{
		for (int i = 0; i < _vibrationMotorCount; i++)
		{
			xWZrwnnMqVTLbUkKWfIFGhxOqyeV[i].YtNTRYdQfWbqEacrAtIOVqkiZggn();
		}
	}

	void IDriver_NintendoSwitchController.StopVibration()
	{
		//ILSpy generated this explicit interface implementation from .override directive in StopVibration
		this.StopVibration();
	}

	private void eVECGMTrHsHNwzJShbSHrWKkYABb(int P_0)
	{
		for (int i = 0; i < xWZrwnnMqVTLbUkKWfIFGhxOqyeV.Length; i++)
		{
			if (i != P_0)
			{
				xWZrwnnMqVTLbUkKWfIFGhxOqyeV[i].YtNTRYdQfWbqEacrAtIOVqkiZggn();
			}
		}
	}

	protected NintendoSwitchGamepadDriver(InitArgs P_0, eBJeJyFgStXbLxxnXTUKFCvncgku P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("initArgs");
		}
		_controllerType = P_1;
		_buttonCount = P_2;
		_axisCount = P_3;
		_vibrationMotorCount = P_4;
		VdCYEUKBWPXIeubViuwJKndEwkAI = P_0.hidDevice;
		RgVgfWkRbFAOJoCVIaKWrjZtPPFBA = P_0.hidDevice.properties;
		SgkqxACuLdCPxeOGIinRAnVVOjAoA = P_0.connectionType == mcGCOmKmWTEVYWVKfxUduOlekNVWA.Bluetooth;
		JylGWydzqHreYkEBoIEoyvABumLC = new NativeBuffer(RgVgfWkRbFAOJoCVIaKWrjZtPPFBA.maxInputReportLength);
		BbCLoSXMjEvqojSkcBaUVaOfBtjo = new NativeBuffer(RgVgfWkRbFAOJoCVIaKWrjZtPPFBA.maxOutputReportLength);
		PeFowWDdPaHOJgtyGcTpChaRragQ = new NativeBuffer(32);
		qeisXpyOFFGjHplEgzvmzIACHmLF = new byte[RgVgfWkRbFAOJoCVIaKWrjZtPPFBA.maxInputReportLength];
		yBkvFgdrZROVDncWvuoBOJHKjTrIA = new NativeBuffer(RgVgfWkRbFAOJoCVIaKWrjZtPPFBA.maxOutputReportLength);
		jZcLaBVYTqYQnwBCWgEkOtwTeMEs = new NativeBuffer(49);
		if (RgVgfWkRbFAOJoCVIaKWrjZtPPFBA.maxOutputReportLength < 2)
		{
			throw new ArgumentException("Output report buffer is too small.");
		}
		rfOVUxQLnsAuhFwuTdNpFOHSfArzA = new YgqnhctsoyAiZixKeAsniiZNPqQeA(BbCLoSXMjEvqojSkcBaUVaOfBtjo.Pointer, BbCLoSXMjEvqojSkcBaUVaOfBtjo.Length, BbCLoSXMjEvqojSkcBaUVaOfBtjo.Length);
		cJMFnfofTisddwrSwcVtAjXQZsSEA = !SgkqxACuLdCPxeOGIinRAnVVOjAoA && UnityTools.effectivePlatform == Platform.Windows;
		ReInput.ApplicationPauseChangedEvent += usnkvQwkxdTRqUlTXDTANLBgFZaB;
		buttons = new zcGvJvonyWXVMOLIHiTlBSzzCQP[P_2];
		for (int i = 0; i < P_2; i++)
		{
			buttons[i] = new zcGvJvonyWXVMOLIHiTlBSzzCQP(33, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 9,
				usage = (ushort)i
			});
		}
		gClVdaHmcrGlOXpziPikExYwSTzS = new dgskCNnyEMRGYOKbhcRAWCtfXHNO[_axisCount];
		vibrationMotors = new UJKgOyiCpkBVwnefNmaagmCQWRFGb[P_4];
		for (int j = 0; j < vibrationMotors.Length; j++)
		{
			vibrationMotors[j] = new UJKgOyiCpkBVwnefNmaagmCQWRFGb(0, 255);
		}
		xWZrwnnMqVTLbUkKWfIFGhxOqyeV = new EqMxffVpNcyevpCyVGSsdOHINCZHb[P_4];
		for (int k = 0; k < xWZrwnnMqVTLbUkKWfIFGhxOqyeV.Length; k++)
		{
			xWZrwnnMqVTLbUkKWfIFGhxOqyeV[k] = new EqMxffVpNcyevpCyVGSsdOHINCZHb(vibrationMotors[k]);
		}
	}

	protected void Initialize()
	{
		rEmImDYWqidMtmJEIjfTOvoOljFg = false;
		BbCLoSXMjEvqojSkcBaUVaOfBtjo.Clear();
		if (!SgkqxACuLdCPxeOGIinRAnVVOjAoA)
		{
			NativeBuffer bbCLoSXMjEvqojSkcBaUVaOfBtjo = BbCLoSXMjEvqojSkcBaUVaOfBtjo;
			bbCLoSXMjEvqojSkcBaUVaOfBtjo[0] = 128;
			bbCLoSXMjEvqojSkcBaUVaOfBtjo[1] = 1;
			if (!qjopNouFVXFEqVNZtFDAhpyYpObyA(lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous))
			{
				Logger.LogError("Failed to write output report to device: USB connection status.", requiredThreadSafety: true);
				throw new Exception();
			}
			bbCLoSXMjEvqojSkcBaUVaOfBtjo[0] = 128;
			bbCLoSXMjEvqojSkcBaUVaOfBtjo[1] = 2;
			if (!qjopNouFVXFEqVNZtFDAhpyYpObyA(lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous))
			{
				Logger.LogError("Failed to write output report to device: USB handshake 1.", requiredThreadSafety: true);
				throw new Exception();
			}
			bbCLoSXMjEvqojSkcBaUVaOfBtjo[0] = 128;
			bbCLoSXMjEvqojSkcBaUVaOfBtjo[1] = 3;
			if (!qjopNouFVXFEqVNZtFDAhpyYpObyA(lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous))
			{
				Logger.LogError("Failed to write output report to device: USB set baudrate.", requiredThreadSafety: true);
				throw new Exception();
			}
			bbCLoSXMjEvqojSkcBaUVaOfBtjo[0] = 128;
			bbCLoSXMjEvqojSkcBaUVaOfBtjo[1] = 2;
			if (!qjopNouFVXFEqVNZtFDAhpyYpObyA(lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous))
			{
				Logger.LogError("Failed to write output report to device: USB handshake 2.", requiredThreadSafety: true);
				throw new Exception();
			}
			bbCLoSXMjEvqojSkcBaUVaOfBtjo[0] = 128;
			bbCLoSXMjEvqojSkcBaUVaOfBtjo[1] = 4;
			if (!qjopNouFVXFEqVNZtFDAhpyYpObyA(lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous))
			{
				Logger.LogError("Failed to write output report to device: USB prevent hid timeout.", requiredThreadSafety: true);
				throw new Exception();
			}
		}
		if (!JXaaKpebLAcsfCmxUhfAuXEACySQ(new lzvvVHoRtiHCGQOzxSxjdnvjlWUq(72, new byte[1] { 1 }, 1), qeisXpyOFFGjHplEgzvmzIACHmLF))
		{
			throw new Exception();
		}
		if (!JXaaKpebLAcsfCmxUhfAuXEACySQ(new lzvvVHoRtiHCGQOzxSxjdnvjlWUq(3, new byte[1] { 48 }, 1), qeisXpyOFFGjHplEgzvmzIACHmLF))
		{
			throw new Exception();
		}
		IpoHbVqOPjeLTcuVSKvmwBoYFhbXA();
		if (!BwLmYSsgBtXtUtGsnFDQAcQVBfmG())
		{
			throw new Exception();
		}
		if (cJMFnfofTisddwrSwcVtAjXQZsSEA)
		{
			HyZKKYxHjMfzXfxtUPzLmBZQQFnUA = ReInput.realTime;
		}
		rEmImDYWqidMtmJEIjfTOvoOljFg = true;
	}

	public override void Update(UpdateLoopType updateLoop)
	{
		double realTime = ReInput.realTime;
		if (cJMFnfofTisddwrSwcVtAjXQZsSEA && realTime >= HyZKKYxHjMfzXfxtUPzLmBZQQFnUA + 1.0)
		{
			try
			{
				Initialize();
			}
			catch
			{
				Logger.LogWarning("Error re-initializing Nintendo Switch Pro Controller. Will retry.");
				HyZKKYxHjMfzXfxtUPzLmBZQQFnUA = realTime;
			}
		}
		for (int i = 0; i < xWZrwnnMqVTLbUkKWfIFGhxOqyeV.Length; i++)
		{
			xWZrwnnMqVTLbUkKWfIFGhxOqyeV[i].BIJwWnGRqlLuaeYeNFhxPhtnhCtF(realTime);
		}
		if (realTime >= OjwnqMpVWNpItymevqprYVpIVIKv + 0.01515151560306549)
		{
			OjwnqMpVWNpItymevqprYVpIVIKv = realTime;
			RWSrJnEMFcZNVojVzYtZlmkZfZLG(BbCLoSXMjEvqojSkcBaUVaOfBtjo);
			qjopNouFVXFEqVNZtFDAhpyYpObyA(lZZYSzlENjVckJKEzwKsVotVgXhb.Asynchronous);
		}
	}

	public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
	{
		if (!rEmImDYWqidMtmJEIjfTOvoOljFg)
		{
			return false;
		}
		if (inputReportPtr == IntPtr.Zero)
		{
			return false;
		}
		if (JylGWydzqHreYkEBoIEoyvABumLC.Length < 49)
		{
			return false;
		}
		if (Marshal.ReadByte(inputReportPtr, 0) != 33)
		{
			return false;
		}
		if (cJMFnfofTisddwrSwcVtAjXQZsSEA)
		{
			HyZKKYxHjMfzXfxtUPzLmBZQQFnUA = ReInput.realTime;
		}
		int numBytesToWrite = Math.Min(inputReportLength, JylGWydzqHreYkEBoIEoyvABumLC.Length);
		JylGWydzqHreYkEBoIEoyvABumLC.Write(inputReportPtr, inputReportLength, numBytesToWrite);
		UpdateButtons(JylGWydzqHreYkEBoIEoyvABumLC, timestamp);
		xRwbEhgwfqETGQkYCofyzWNojclTA[] elements = axes;
		UpdateElements(elements, JylGWydzqHreYkEBoIEoyvABumLC, timestamp);
		return true;
	}

	protected abstract void UpdateButtons(NativeBuffer inputReport, double timestamp);

	protected abstract void UpdateElements(xRwbEhgwfqETGQkYCofyzWNojclTA[] elements, NativeBuffer inputReport, double timestamp);

	private bool JXaaKpebLAcsfCmxUhfAuXEACySQ(lzvvVHoRtiHCGQOzxSxjdnvjlWUq P_0, byte[] P_1)
	{
		try
		{
			if (P_0.xmHOLlztrNvmcXasgevaYVOggyln.Length + 11 > yBkvFgdrZROVDncWvuoBOJHKjTrIA.Length)
			{
				return false;
			}
			RWSrJnEMFcZNVojVzYtZlmkZfZLG(yBkvFgdrZROVDncWvuoBOJHKjTrIA);
			yBkvFgdrZROVDncWvuoBOJHKjTrIA[10] = P_0.meWphLYIsFmGOelfVDvnnInlttfJ;
			yBkvFgdrZROVDncWvuoBOJHKjTrIA.TryWriteBytes(P_0.xmHOLlztrNvmcXasgevaYVOggyln, P_0.xwOnLWoPGfyplSlQUEZtdNfUgZOA, 11);
			int num = 2;
			bool flag = false;
			int num2 = 0;
			double num3 = 0.0;
			while (VdCYEUKBWPXIeubViuwJKndEwkAI.ReadSync(jZcLaBVYTqYQnwBCWgEkOtwTeMEs, jZcLaBVYTqYQnwBCWgEkOtwTeMEs.Length, 1))
			{
			}
			for (int i = 0; i < num; i++)
			{
				Array.Clear(P_1, 0, P_1.Length);
				jZcLaBVYTqYQnwBCWgEkOtwTeMEs.Clear();
				xsJblPeXmlvHelALdZYWgSSyTnBNA(yBkvFgdrZROVDncWvuoBOJHKjTrIA, P_0.meWphLYIsFmGOelfVDvnnInlttfJ);
				num3 = ReInput.realTime;
				if (i == 0)
				{
					_ = ReInput.realTime;
				}
				int num4 = 0;
				while (!(ReInput.realTime >= num3 + 0.5))
				{
					if (VdCYEUKBWPXIeubViuwJKndEwkAI.ReadSync(jZcLaBVYTqYQnwBCWgEkOtwTeMEs, jZcLaBVYTqYQnwBCWgEkOtwTeMEs.Length, 200) && jZcLaBVYTqYQnwBCWgEkOtwTeMEs[0] == 33)
					{
						if (jZcLaBVYTqYQnwBCWgEkOtwTeMEs[14] == P_0.meWphLYIsFmGOelfVDvnnInlttfJ)
						{
							flag = true;
							_ = ReInput.realTime;
							break;
						}
						num4++;
						num2++;
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				jZcLaBVYTqYQnwBCWgEkOtwTeMEs.Read(P_1, jZcLaBVYTqYQnwBCWgEkOtwTeMEs.Length);
			}
			return flag;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private bool xsJblPeXmlvHelALdZYWgSSyTnBNA(NativeBuffer P_0, byte P_1)
	{
		if (!VdCYEUKBWPXIeubViuwJKndEwkAI.WriteSync(new YgqnhctsoyAiZixKeAsniiZNPqQeA(P_0, P_0.Length, P_0.Length), 1000))
		{
			return false;
		}
		return true;
	}

	private void ZVCUoxpvknEonfEZVfijCMcvQyNv(byte P_0)
	{
		BbCLoSXMjEvqojSkcBaUVaOfBtjo.Clear();
		BbCLoSXMjEvqojSkcBaUVaOfBtjo[0] = 128;
		BbCLoSXMjEvqojSkcBaUVaOfBtjo[1] = 146;
		BbCLoSXMjEvqojSkcBaUVaOfBtjo[2] = 0;
		BbCLoSXMjEvqojSkcBaUVaOfBtjo[3] = 49;
		BbCLoSXMjEvqojSkcBaUVaOfBtjo[8] = P_0;
	}

	private void xgYxkrJHuaAtsHnBZTUWPZnSEgMt(byte P_0, NativeBuffer P_1, int P_2, lZZYSzlENjVckJKEzwKsVotVgXhb P_3)
	{
		ZVCUoxpvknEonfEZVfijCMcvQyNv(P_0);
		if (P_2 > 0)
		{
			BbCLoSXMjEvqojSkcBaUVaOfBtjo.Write(P_1, P_2, 9);
		}
	}

	private void RWSrJnEMFcZNVojVzYtZlmkZfZLG(NativeBuffer P_0)
	{
		P_0.Clear();
		P_0[0] = 1;
		P_0[1] = aSobjMuobdFOsapnEWSYhZUiuOoW();
		YQeTulYyaoKGhpPkUBlaonTrPcQm(P_0, 2);
	}

	private void YQeTulYyaoKGhpPkUBlaonTrPcQm(NativeBuffer P_0, int P_1)
	{
		if (_controllerType == eBJeJyFgStXbLxxnXTUKFCvncgku.JoyConRight)
		{
			P_1 += 4;
		}
		for (int i = 0; i < xWZrwnnMqVTLbUkKWfIFGhxOqyeV.Length; i++)
		{
			sQVdIMcnDsGtzCKbConBctRRAyGCB(P_0, P_1, xWZrwnnMqVTLbUkKWfIFGhxOqyeV[i].NIdOuZJfSdhPTXXRYFJQnuTPZild());
			P_1 += 4;
		}
	}

	private static void sQVdIMcnDsGtzCKbConBctRRAyGCB(NativeBuffer P_0, int P_1, IxaPhFYamiJcEhspVhvZxdUuZarl P_2)
	{
		if (P_2.mXxnoytxpEvsnDJIjKKRxQfKdSwL == 0f && P_2.BQCjvYYJvHROoEpWwFqQcDMykPuuA == 0f)
		{
			P_0[P_1] = 0;
			P_0[1 + P_1] = 1;
			P_0[2 + P_1] = 64;
			P_0[3 + P_1] = 64;
			return;
		}
		ushort num = (ushort)((Math.Round(32.0 * Math.Log(P_2.gBYCQpigiqPSQeAaXAHsEIvjkdGSc * 0.1f, 2.0)) - 96.0) * 4.0);
		byte b = (byte)(Math.Round(32.0 * Math.Log(P_2.TMEBxhrTlUEFEpdEcOPhgQKVEbxM * 0.1f, 2.0)) - 64.0);
		byte b2 = mhoSjjFUjIaLHbQhpYZZngopuNWc(P_2.BQCjvYYJvHROoEpWwFqQcDMykPuuA);
		ushort num2 = (ushort)(Math.Round((double)(int)mhoSjjFUjIaLHbQhpYZZngopuNWc(P_2.mXxnoytxpEvsnDJIjKKRxQfKdSwL)) * 0.5);
		byte num3 = (byte)(num2 % 2);
		if (num3 > 0)
		{
			num2--;
		}
		num2 >>= 1;
		num2 += 64;
		if (num3 > 0)
		{
			num2 |= 0x8000;
		}
		b2 = (byte)(b2 - b2 % 2);
		P_0[P_1] = (byte)(num & 0xFF);
		P_0[1 + P_1] = (byte)(((num >> 8) & 0xFF) + b2);
		P_0[2 + P_1] = (byte)(((num2 >> 8) & 0xFF) + b);
		P_0[3 + P_1] = (byte)(num2 & 0xFF);
	}

	private static byte mhoSjjFUjIaLHbQhpYZZngopuNWc(float P_0)
	{
		if (P_0 < 0.01f)
		{
			return 0;
		}
		if ((double)P_0 < 0.117)
		{
			return (byte)((Math.Log(P_0 * 1000f, 2.0) * 32.0 - 96.0) / (5.0 - Math.Pow(P_0, 2.0)) - 1.0);
		}
		if ((double)P_0 < 0.23)
		{
			return (byte)(Math.Log(P_0 * 1000f, 2.0) * 32.0 - 96.0 - 92.0);
		}
		return (byte)((Math.Log(P_0 * 1000f, 2.0) * 32.0 - 96.0) * 2.0 - 246.0);
	}

	private void XqCGiZJNMqutaEmJThLqglYBNrVe(lZZYSzlENjVckJKEzwKsVotVgXhb P_0)
	{
		NativeBuffer peFowWDdPaHOJgtyGcTpChaRragQ = PeFowWDdPaHOJgtyGcTpChaRragQ;
		peFowWDdPaHOJgtyGcTpChaRragQ[0] = aSobjMuobdFOsapnEWSYhZUiuOoW();
		YQeTulYyaoKGhpPkUBlaonTrPcQm(peFowWDdPaHOJgtyGcTpChaRragQ, 1);
		xgYxkrJHuaAtsHnBZTUWPZnSEgMt(16, peFowWDdPaHOJgtyGcTpChaRragQ, 9, P_0);
		qjopNouFVXFEqVNZtFDAhpyYpObyA(P_0);
	}

	private bool IpoHbVqOPjeLTcuVSKvmwBoYFhbXA()
	{
		byte[] array = new byte[25];
		ArrayTools.Fill(array, byte.MaxValue);
		array[0] = 24;
		array[1] = 1;
		return JXaaKpebLAcsfCmxUhfAuXEACySQ(new lzvvVHoRtiHCGQOzxSxjdnvjlWUq(56, array, 25), qeisXpyOFFGjHplEgzvmzIACHmLF);
	}

	private bool QEVYDXjkaUdxUsthMKFTXBmFdqNGA(bool P_0)
	{
		byte[] array = new byte[25];
		ArrayTools.Fill(array, byte.MaxValue);
		if (P_0)
		{
			array[0] = 31;
			array[1] = 240;
		}
		else
		{
			array[0] = 16;
			array[1] = 1;
		}
		return JXaaKpebLAcsfCmxUhfAuXEACySQ(new lzvvVHoRtiHCGQOzxSxjdnvjlWUq(56, array, 25), qeisXpyOFFGjHplEgzvmzIACHmLF);
	}

	private bool qHQjyqGBWlCoPfDSjuRKqQYqJJuPA(byte P_0, byte P_1, byte P_2, byte[] P_3)
	{
		byte[] array = new byte[5] { P_1, P_0, 0, 0, P_2 };
		bool flag = false;
		for (int i = 0; i < 10; i++)
		{
			if (JXaaKpebLAcsfCmxUhfAuXEACySQ(new lzvvVHoRtiHCGQOzxSxjdnvjlWUq(16, array, array.Length), P_3) && P_3[15] == P_1 && P_3[16] == P_0)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return false;
		}
		Array.Copy(P_3, 20, P_3, 0, P_2);
		ArrayTools.Fill(P_3, (byte)0, (int)P_2, P_3.Length - P_2);
		return true;
	}

	private bool qjopNouFVXFEqVNZtFDAhpyYpObyA(lZZYSzlENjVckJKEzwKsVotVgXhb P_0)
	{
		switch (P_0)
		{
		case lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous:
			return VdCYEUKBWPXIeubViuwJKndEwkAI.WriteSync(rfOVUxQLnsAuhFwuTdNpFOHSfArzA, 0);
		case lZZYSzlENjVckJKEzwKsVotVgXhb.Asynchronous:
			VdCYEUKBWPXIeubViuwJKndEwkAI.WriteAsync(rfOVUxQLnsAuhFwuTdNpFOHSfArzA, 1000);
			return true;
		default:
			throw new NotImplementedException();
		}
	}

	private byte aSobjMuobdFOsapnEWSYhZUiuOoW()
	{
		if (UuBLbdHYyaaUQMjvfUqMlTBTWXXS == 15)
		{
			UuBLbdHYyaaUQMjvfUqMlTBTWXXS = 0;
		}
		else
		{
			UuBLbdHYyaaUQMjvfUqMlTBTWXXS++;
		}
		return UuBLbdHYyaaUQMjvfUqMlTBTWXXS;
	}

	private bool BwLmYSsgBtXtUtGsnFDQAcQVBfmG()
	{
		bool flag = false;
		bool flag2 = _controllerType == eBJeJyFgStXbLxxnXTUKFCvncgku.JoyConLeft || _controllerType == eBJeJyFgStXbLxxnXTUKFCvncgku.ProController;
		Array.Clear(gClVdaHmcrGlOXpziPikExYwSTzS, 0, gClVdaHmcrGlOXpziPikExYwSTzS.Length);
		bool flag3 = false;
		if (qHQjyqGBWlCoPfDSjuRKqQYqJJuPA(128, (byte)(flag2 ? 18 : 29), 9, qeisXpyOFFGjHplEgzvmzIACHmLF))
		{
			for (int i = 0; i < 9; i++)
			{
				if (qeisXpyOFFGjHplEgzvmzIACHmLF[i] != byte.MaxValue)
				{
					flag3 = true;
				}
			}
		}
		if (!flag3 && qHQjyqGBWlCoPfDSjuRKqQYqJJuPA(96, (byte)(flag2 ? 61 : 70), 9, qeisXpyOFFGjHplEgzvmzIACHmLF))
		{
			flag3 = true;
		}
		if (flag3)
		{
			dgskCNnyEMRGYOKbhcRAWCtfXHNO dgskCNnyEMRGYOKbhcRAWCtfXHNO2 = new dgskCNnyEMRGYOKbhcRAWCtfXHNO();
			dgskCNnyEMRGYOKbhcRAWCtfXHNO dgskCNnyEMRGYOKbhcRAWCtfXHNO3 = new dgskCNnyEMRGYOKbhcRAWCtfXHNO();
			QdDTUOgZUdiwHGRKnCqRCXrptmLg(qeisXpyOFFGjHplEgzvmzIACHmLF, dgskCNnyEMRGYOKbhcRAWCtfXHNO2, dgskCNnyEMRGYOKbhcRAWCtfXHNO3, flag2);
			gClVdaHmcrGlOXpziPikExYwSTzS[0] = dgskCNnyEMRGYOKbhcRAWCtfXHNO2;
			gClVdaHmcrGlOXpziPikExYwSTzS[1] = dgskCNnyEMRGYOKbhcRAWCtfXHNO3;
			flag = true;
			if (qHQjyqGBWlCoPfDSjuRKqQYqJJuPA(96, (byte)(flag2 ? 134 : 152), 16, qeisXpyOFFGjHplEgzvmzIACHmLF))
			{
				oLIjZFfTfyIoHbsweVLoDoRnAbCd(qeisXpyOFFGjHplEgzvmzIACHmLF, dgskCNnyEMRGYOKbhcRAWCtfXHNO2, dgskCNnyEMRGYOKbhcRAWCtfXHNO3);
			}
		}
		else
		{
			flag = false;
		}
		if (_controllerType == eBJeJyFgStXbLxxnXTUKFCvncgku.ProController)
		{
			bool flag4 = false;
			if (qHQjyqGBWlCoPfDSjuRKqQYqJJuPA(128, (byte)((!flag2) ? 18 : 29), 9, qeisXpyOFFGjHplEgzvmzIACHmLF))
			{
				for (int j = 0; j < 9; j++)
				{
					if (qeisXpyOFFGjHplEgzvmzIACHmLF[j] != byte.MaxValue)
					{
						flag4 = true;
					}
				}
			}
			if (!flag4 && qHQjyqGBWlCoPfDSjuRKqQYqJJuPA(96, (byte)((!flag2) ? 61 : 70), 9, qeisXpyOFFGjHplEgzvmzIACHmLF))
			{
				flag4 = true;
			}
			if (flag4)
			{
				dgskCNnyEMRGYOKbhcRAWCtfXHNO dgskCNnyEMRGYOKbhcRAWCtfXHNO4 = new dgskCNnyEMRGYOKbhcRAWCtfXHNO();
				dgskCNnyEMRGYOKbhcRAWCtfXHNO dgskCNnyEMRGYOKbhcRAWCtfXHNO5 = new dgskCNnyEMRGYOKbhcRAWCtfXHNO();
				QdDTUOgZUdiwHGRKnCqRCXrptmLg(qeisXpyOFFGjHplEgzvmzIACHmLF, dgskCNnyEMRGYOKbhcRAWCtfXHNO4, dgskCNnyEMRGYOKbhcRAWCtfXHNO5, !flag2);
				gClVdaHmcrGlOXpziPikExYwSTzS[2] = dgskCNnyEMRGYOKbhcRAWCtfXHNO4;
				gClVdaHmcrGlOXpziPikExYwSTzS[3] = dgskCNnyEMRGYOKbhcRAWCtfXHNO5;
				flag = true;
				if (qHQjyqGBWlCoPfDSjuRKqQYqJJuPA(96, (byte)((!flag2) ? 134 : 152), 16, qeisXpyOFFGjHplEgzvmzIACHmLF))
				{
					oLIjZFfTfyIoHbsweVLoDoRnAbCd(qeisXpyOFFGjHplEgzvmzIACHmLF, dgskCNnyEMRGYOKbhcRAWCtfXHNO4, dgskCNnyEMRGYOKbhcRAWCtfXHNO5);
				}
			}
			else
			{
				flag = false;
			}
		}
		return flag;
	}

	private static void QdDTUOgZUdiwHGRKnCqRCXrptmLg(byte[] P_0, dgskCNnyEMRGYOKbhcRAWCtfXHNO P_1, dgskCNnyEMRGYOKbhcRAWCtfXHNO P_2, bool P_3)
	{
		ushort num = (ushort)(((P_0[1] << 8) & 0xF00) | P_0[0]);
		ushort num2 = (ushort)((P_0[2] << 4) | (P_0[1] >> 4));
		ushort num3 = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
		ushort num4 = (ushort)((P_0[5] << 4) | (P_0[4] >> 4));
		ushort num5 = (ushort)(((P_0[7] << 8) & 0xF00) | P_0[6]);
		ushort num6 = (ushort)((P_0[8] << 4) | (P_0[7] >> 4));
		if (P_3)
		{
			P_1.CysLVzeaAGLIcAOeVWEhyfVDWAIW = num;
			P_2.CysLVzeaAGLIcAOeVWEhyfVDWAIW = num2;
			P_1.paoGVlrAgPANDNMyTGfAamLihFAXA = num3;
			P_2.paoGVlrAgPANDNMyTGfAamLihFAXA = num4;
			P_1.QWxxcDIxDOFRzNTqWlckLnOoWPfW = num5;
			P_2.QWxxcDIxDOFRzNTqWlckLnOoWPfW = num6;
		}
		else
		{
			P_1.paoGVlrAgPANDNMyTGfAamLihFAXA = num;
			P_2.paoGVlrAgPANDNMyTGfAamLihFAXA = num2;
			P_1.QWxxcDIxDOFRzNTqWlckLnOoWPfW = num3;
			P_2.QWxxcDIxDOFRzNTqWlckLnOoWPfW = num4;
			P_1.CysLVzeaAGLIcAOeVWEhyfVDWAIW = num5;
			P_2.CysLVzeaAGLIcAOeVWEhyfVDWAIW = num6;
		}
	}

	private static void oLIjZFfTfyIoHbsweVLoDoRnAbCd(byte[] P_0, dgskCNnyEMRGYOKbhcRAWCtfXHNO P_1, dgskCNnyEMRGYOKbhcRAWCtfXHNO P_2)
	{
		P_1.YlilqyacAZXbuBtpInUAsHAMxZeV = (ushort)(((P_0[4] << 8) & 0xF00) | P_0[3]);
		P_2.YlilqyacAZXbuBtpInUAsHAMxZeV = P_1.YlilqyacAZXbuBtpInUAsHAMxZeV;
	}

	protected bool GetCalibratedStickValue(ushort valueX, ushort valueY, dgskCNnyEMRGYOKbhcRAWCtfXHNO calX, dgskCNnyEMRGYOKbhcRAWCtfXHNO calY, out ushort calibratedX, out ushort calibratedY)
	{
		calibratedX = 32767;
		calibratedY = 32767;
		if (calX == null || calY == null)
		{
			return false;
		}
		ushort ylilqyacAZXbuBtpInUAsHAMxZeV = calX.YlilqyacAZXbuBtpInUAsHAMxZeV;
		float num = valueX - calX.paoGVlrAgPANDNMyTGfAamLihFAXA;
		float num2 = valueY - calY.paoGVlrAgPANDNMyTGfAamLihFAXA;
		if (Math.Abs(num * num + num2 * num2) < (float)(ylilqyacAZXbuBtpInUAsHAMxZeV * ylilqyacAZXbuBtpInUAsHAMxZeV))
		{
			return false;
		}
		calibratedX = (ushort)MathTools.ValueInNewRange(MathTools.Clamp(num / (float)(int)((num > 0f) ? calX.CysLVzeaAGLIcAOeVWEhyfVDWAIW : calX.QWxxcDIxDOFRzNTqWlckLnOoWPfW), -0.95f, 0.95f), -0.95f, 0.95f, 0f, 65535f);
		calibratedY = (ushort)MathTools.ValueInNewRange(MathTools.Clamp(num2 / (float)(int)((num2 > 0f) ? calY.CysLVzeaAGLIcAOeVWEhyfVDWAIW : calY.QWxxcDIxDOFRzNTqWlckLnOoWPfW), -0.95f, 0.95f), -0.95f, 0.95f, 0f, 65535f);
		return true;
	}

	protected dgskCNnyEMRGYOKbhcRAWCtfXHNO GetAxisCalibration(int index)
	{
		return gClVdaHmcrGlOXpziPikExYwSTzS[index];
	}

	private void usnkvQwkxdTRqUlTXDTANLBgFZaB(bool P_0)
	{
		if (cJMFnfofTisddwrSwcVtAjXQZsSEA && !P_0)
		{
			HyZKKYxHjMfzXfxtUPzLmBZQQFnUA = ReInput.realTime;
		}
	}

	~NintendoSwitchGamepadDriver()
	{
		Dispose(disposing: false);
	}

	protected override void Dispose(bool disposing)
	{
		if (base.disposed)
		{
			return;
		}
		if (disposing)
		{
			ReInput.ApplicationPauseChangedEvent -= usnkvQwkxdTRqUlTXDTANLBgFZaB;
			if (!SgkqxACuLdCPxeOGIinRAnVVOjAoA && BbCLoSXMjEvqojSkcBaUVaOfBtjo != null)
			{
				BbCLoSXMjEvqojSkcBaUVaOfBtjo.Clear();
				BbCLoSXMjEvqojSkcBaUVaOfBtjo[0] = 128;
				BbCLoSXMjEvqojSkcBaUVaOfBtjo[1] = 5;
				try
				{
					VdCYEUKBWPXIeubViuwJKndEwkAI.WriteSync(rfOVUxQLnsAuhFwuTdNpFOHSfArzA, 0);
				}
				catch
				{
				}
				BbCLoSXMjEvqojSkcBaUVaOfBtjo.Clear();
				BbCLoSXMjEvqojSkcBaUVaOfBtjo[0] = 128;
				BbCLoSXMjEvqojSkcBaUVaOfBtjo[1] = 6;
				try
				{
					VdCYEUKBWPXIeubViuwJKndEwkAI.WriteSync(rfOVUxQLnsAuhFwuTdNpFOHSfArzA, 0);
				}
				catch
				{
				}
			}
			if (JylGWydzqHreYkEBoIEoyvABumLC != null)
			{
				JylGWydzqHreYkEBoIEoyvABumLC.Dispose();
			}
			if (BbCLoSXMjEvqojSkcBaUVaOfBtjo != null)
			{
				BbCLoSXMjEvqojSkcBaUVaOfBtjo.Dispose();
			}
			if (yBkvFgdrZROVDncWvuoBOJHKjTrIA != null)
			{
				yBkvFgdrZROVDncWvuoBOJHKjTrIA.Dispose();
			}
			if (jZcLaBVYTqYQnwBCWgEkOtwTeMEs != null)
			{
				jZcLaBVYTqYQnwBCWgEkOtwTeMEs.Dispose();
			}
			if (PeFowWDdPaHOJgtyGcTpChaRragQ == null)
			{
				PeFowWDdPaHOJgtyGcTpChaRragQ.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	private static void jZUeFvsXUVmFgAxtNjSpKsazPKWn(NativeBuffer P_0, int P_1)
	{
		P_0.TryWriteBytes(mSxlABhlzLQlXMmHaAhEFzoIRBZR, mSxlABhlzLQlXMmHaAhEFzoIRBZR.Length, P_1);
	}

	private static void OOrHygdxoPUNzkTzYgEHLQVeLpAS(byte[] P_0, int P_1)
	{
		Array.Copy(mSxlABhlzLQlXMmHaAhEFzoIRBZR, 0, P_0, P_1, mSxlABhlzLQlXMmHaAhEFzoIRBZR.Length);
	}

	[Conditional("DEBUG_THIS")]
	protected static void DLog(object msg)
	{
		if (msg != null)
		{
			Logger.Log("SwitchGamepadDriverBase: " + msg);
		}
	}
}
