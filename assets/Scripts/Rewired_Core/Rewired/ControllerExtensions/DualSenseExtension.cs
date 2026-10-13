using System;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions;

[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
public sealed class DualSenseExtension : Controller.Extension, IControllerVibrator, IDualShock4Extension, IDualSenseExtension, IHIDControllerExtension
{
	private class zAtNGMcGoiZbgzeVCYhxuhrHavNz : IControllerExtensionSource
	{
		public readonly IDriver_DualSense ZZVAziEFlsmCJEupQkHQPYFkxiRAA;

		public readonly bool iNeecqAJOQcLOKhluPbaUudQeIAt;

		public readonly int mnNMgSILWZJVdEhJePHRwvEJoDTo;

		public zAtNGMcGoiZbgzeVCYhxuhrHavNz(IDriver_DualSense P_0, bool P_1, int P_2)
		{
			ZZVAziEFlsmCJEupQkHQPYFkxiRAA = P_0;
			iNeecqAJOQcLOKhluPbaUudQeIAt = P_1;
			mnNMgSILWZJVdEhJePHRwvEJoDTo = P_2;
		}
	}

	private zAtNGMcGoiZbgzeVCYhxuhrHavNz lyBitQjEmxYhzUTDFlyVFyHPIbOQ;

	private bool xyPrBbMWmFTJtAMjsvgCBbgcurpK;

	private TimerAbs[] uXuegOxnrvEhtMeZQTBhrIopzADM;

	private Joystick joystick => cfxJhQqUHQWqQkTpWFzcPMsRFcBP();

	int IControllerVibrator.vibrationMotorCount => get_vibrationMotorCount();

	public float lightColorRed
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled)
			{
				return 0f;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorR;
		}
		set
		{
			if (xyPrBbMWmFTJtAMjsvgCBbgcurpK)
			{
				lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorR = value;
			}
		}
	}

	public float lightColorGreen
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled)
			{
				return 0f;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorG;
		}
		set
		{
			if (xyPrBbMWmFTJtAMjsvgCBbgcurpK)
			{
				lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorG = value;
			}
		}
	}

	public float lightColorBlue
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled)
			{
				return 0f;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorB;
		}
		set
		{
			if (xyPrBbMWmFTJtAMjsvgCBbgcurpK)
			{
				lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorB = value;
			}
		}
	}

	public DualSenseMicrophoneLightMode microphoneLightMode
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return DualSenseMicrophoneLightMode.Off;
			}
			if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled)
			{
				return DualSenseMicrophoneLightMode.Off;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.microphoneLightMode;
		}
		set
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (xyPrBbMWmFTJtAMjsvgCBbgcurpK && base.enabled)
			{
				lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.microphoneLightMode = value;
			}
		}
	}

	public DualSenseOtherLightBrightness otherLightBrightness
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return DualSenseOtherLightBrightness.High;
			}
			if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled)
			{
				return DualSenseOtherLightBrightness.High;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.otherLightBrightness;
		}
		set
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (xyPrBbMWmFTJtAMjsvgCBbgcurpK && base.enabled)
			{
				lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.otherLightBrightness = value;
			}
		}
	}

	public DualSensePlayerLightFlags playerLights
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return DualSensePlayerLightFlags.None;
			}
			if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled)
			{
				return DualSensePlayerLightFlags.None;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.playerLights;
		}
		set
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (xyPrBbMWmFTJtAMjsvgCBbgcurpK && base.enabled)
			{
				lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.playerLights = value;
			}
		}
	}

	int IDualShock4Extension.maxTouches => get_maxTouches();

	int IDualShock4Extension.touchCount => get_touchCount();

	public float batteryLevel
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK)
			{
				return 0f;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.BatteryLevel;
		}
	}

	public bool batteryCharging
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK)
			{
				return false;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.BatteryCharging;
		}
	}

	ushort IHIDControllerExtension.vendorId
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.vendorId;
		}
	}

	ushort IHIDControllerExtension.productId
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.productId;
		}
	}

	string IHIDControllerExtension.productName
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.productName;
		}
	}

	string IHIDControllerExtension.manufacturer
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.manufacturer;
		}
	}

	ushort IHIDControllerExtension.usagePage
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.usagePage;
		}
	}

	ushort IHIDControllerExtension.usage
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0;
			}
			return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.usage;
		}
	}

	private Joystick cfxJhQqUHQWqQkTpWFzcPMsRFcBP()
	{
		return GetController<Joystick>();
	}

	internal DualSenseExtension(IDriver_DualSense P_0)
		: base(new zAtNGMcGoiZbgzeVCYhxuhrHavNz(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
	{
		uXuegOxnrvEhtMeZQTBhrIopzADM = new TimerAbs[P_0.VibrationMotorCount];
		ArrayTools.Populate(uXuegOxnrvEhtMeZQTBhrIopzADM, 0, uXuegOxnrvEhtMeZQTBhrIopzADM.Length);
	}

	private DualSenseExtension(DualSenseExtension P_0)
		: base(P_0)
	{
		try
		{
			uXuegOxnrvEhtMeZQTBhrIopzADM = new TimerAbs[P_0.get_vibrationMotorCount()];
		}
		catch
		{
			uXuegOxnrvEhtMeZQTBhrIopzADM = new TimerAbs[0];
		}
		ArrayTools.Populate(uXuegOxnrvEhtMeZQTBhrIopzADM, 0, uXuegOxnrvEhtMeZQTBhrIopzADM.Length);
	}

	public int get_vibrationMotorCount()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK)
		{
			return 0;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.mnNMgSILWZJVdEhJePHRwvEJoDTo;
	}

	public void SetVibration(int motorIndex, float motorLevel)
	{
		SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
	}

	void IControllerVibrator.SetVibration(int motorIndex, float motorLevel)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetVibration
		this.SetVibration(motorIndex, motorLevel);
	}

	public void SetVibration(int motorIndex, float motorLevel, float duration)
	{
		SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
	}

	void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetVibration
		this.SetVibration(motorIndex, motorLevel, duration);
	}

	public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
	{
		SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
	}

	void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetVibration
		this.SetVibration(motorIndex, motorLevel, stopOtherMotors);
	}

	public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (xyPrBbMWmFTJtAMjsvgCBbgcurpK && base.enabled && motorIndex >= 0 && motorIndex < lyBitQjEmxYhzUTDFlyVFyHPIbOQ.mnNMgSILWZJVdEhJePHRwvEJoDTo)
		{
			SetVibration(motorIndex switch
			{
				0 => DualShock4MotorType.LeftMotor, 
				1 => DualShock4MotorType.RightMotor, 
				_ => throw new NotImplementedException(), 
			}, motorLevel, duration, stopOtherMotors);
		}
	}

	void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetVibration
		this.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
	}

	public float GetVibration(int motorIndex)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0f;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled)
		{
			return 0f;
		}
		if (!lyBitQjEmxYhzUTDFlyVFyHPIbOQ.iNeecqAJOQcLOKhluPbaUudQeIAt)
		{
			return 0f;
		}
		return motorIndex switch
		{
			0 => lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LeftMotor, 
			1 => lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.RightMotor, 
			_ => 0f, 
		};
	}

	float IControllerVibrator.GetVibration(int motorIndex)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetVibration
		return this.GetVibration(motorIndex);
	}

	public void StopVibration()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (xyPrBbMWmFTJtAMjsvgCBbgcurpK && base.enabled && lyBitQjEmxYhzUTDFlyVFyHPIbOQ.iNeecqAJOQcLOKhluPbaUudQeIAt)
		{
			for (int i = 0; i < lyBitQjEmxYhzUTDFlyVFyHPIbOQ.mnNMgSILWZJVdEhJePHRwvEJoDTo; i++)
			{
				uXuegOxnrvEhtMeZQTBhrIopzADM[i].Clear();
			}
			lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.StopVibration();
		}
	}

	void IControllerVibrator.StopVibration()
	{
		//ILSpy generated this explicit interface implementation from .override directive in StopVibration
		this.StopVibration();
	}

	public DualSenseVibrationMode GetVibrationMode()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return DualSenseVibrationMode.Compatible2;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.vibrationMode;
	}

	public void SetVibrationMode(DualSenseVibrationMode mode)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else
		{
			lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.vibrationMode = mode;
		}
	}

	public float GetVibration(DualShock4MotorType motor)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0f;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled)
		{
			return 0f;
		}
		if (!lyBitQjEmxYhzUTDFlyVFyHPIbOQ.iNeecqAJOQcLOKhluPbaUudQeIAt)
		{
			return 0f;
		}
		return (int)motor switch
		{
			0 => lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LeftMotor, 
			1 => lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.RightMotor, 
			_ => throw new NotImplementedException(), 
		};
	}

	public void SetVibration(DualShock4MotorType motor, float motorLevel)
	{
		SetVibration(motor, motorLevel, 0f, stopOtherMotors: false);
	}

	public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration)
	{
		SetVibration(motor, motorLevel, duration, stopOtherMotors: false);
	}

	public void SetVibration(DualShock4MotorType motor, float motorLevel, bool stopOtherMotors)
	{
		SetVibration(motor, motorLevel, 0f, stopOtherMotors);
	}

	public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration, bool stopOtherMotors)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else
		{
			if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !lyBitQjEmxYhzUTDFlyVFyHPIbOQ.iNeecqAJOQcLOKhluPbaUudQeIAt)
			{
				return;
			}
			if (stopOtherMotors)
			{
				for (int i = 0; i < lyBitQjEmxYhzUTDFlyVFyHPIbOQ.mnNMgSILWZJVdEhJePHRwvEJoDTo; i++)
				{
					uXuegOxnrvEhtMeZQTBhrIopzADM[i].Clear();
				}
				lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.StopVibration();
			}
			motorLevel = MathTools.Clamp01(motorLevel);
			switch ((int)motor)
			{
			case 0:
				lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LeftMotor = motorLevel;
				break;
			case 1:
				lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.RightMotor = motorLevel;
				break;
			default:
				throw new NotImplementedException();
			}
			XAlCmdGSRzonLhrMMSZLxGWDBLvzA(motor, motorLevel, duration);
		}
	}

	public void SetVibration(float leftMotorLevel, float rightMotorLevel)
	{
		SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
	}

	void IDualShock4Extension.SetVibration(float leftMotorLevel, float rightMotorLevel)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetVibration
		this.SetVibration(leftMotorLevel, rightMotorLevel);
	}

	public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (xyPrBbMWmFTJtAMjsvgCBbgcurpK && base.enabled && lyBitQjEmxYhzUTDFlyVFyHPIbOQ.iNeecqAJOQcLOKhluPbaUudQeIAt)
		{
			lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LeftMotor = MathTools.Clamp01(leftMotorLevel);
			lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.RightMotor = MathTools.Clamp01(rightMotorLevel);
			XAlCmdGSRzonLhrMMSZLxGWDBLvzA(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
			XAlCmdGSRzonLhrMMSZLxGWDBLvzA(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
		}
	}

	void IDualShock4Extension.SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetVibration
		this.SetVibration(leftMotorLevel, rightMotorLevel, leftMotorDuration, rightMotorDuration);
	}

	public Color GetLightColor()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return default;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK)
		{
			return default;
		}
		return new Color(lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorR, lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorG, lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorB, 1f);
	}

	public void SetLightColor(Color color)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (xyPrBbMWmFTJtAMjsvgCBbgcurpK && base.enabled)
		{
			lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorR = color.r * color.a;
			lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorG = color.g * color.a;
			lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorB = color.b * color.a;
		}
	}

	void IDualShock4Extension.SetLightColor(Color color)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetLightColor
		this.SetLightColor(color);
	}

	public void SetLightColor(float red, float green, float blue)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else
		{
			SetLightColor(red, green, blue, 1f);
		}
	}

	void IDualShock4Extension.SetLightColor(float red, float green, float blue)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetLightColor
		this.SetLightColor(red, green, blue);
	}

	public void SetLightColor(float red, float green, float blue, float intensity)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (xyPrBbMWmFTJtAMjsvgCBbgcurpK && base.enabled)
		{
			lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorR = red * intensity;
			lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorG = green * intensity;
			lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LightColorB = blue * intensity;
		}
	}

	void IDualShock4Extension.SetLightColor(float red, float green, float blue, float intensity)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetLightColor
		this.SetLightColor(red, green, blue, intensity);
	}

	public Vector3 GetAccelerometerValueRaw()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Vector3.zero;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return Vector3.zero;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.AccelerometerValueRaw;
	}

	Vector3 IDualShock4Extension.GetAccelerometerValueRaw()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAccelerometerValueRaw
		return this.GetAccelerometerValueRaw();
	}

	public Vector3 GetAccelerometerValue()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Vector3.zero;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return Vector3.zero;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.AccelerometerValue;
	}

	Vector3 IDualShock4Extension.GetAccelerometerValue()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAccelerometerValue
		return this.GetAccelerometerValue();
	}

	public Vector3 GetLastGyroscopeValueRaw()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Vector3.zero;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return Vector3.zero;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LastGyroscopeValueRaw;
	}

	public Vector3 GetLastGyroscopeValue()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Vector3.zero;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return Vector3.zero;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.LastGyroscopeValue;
	}

	public Vector3 GetGyroscopeValueRaw()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Vector3.zero;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return Vector3.zero;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.GyroscopeValueRaw;
	}

	public Vector3 GetGyroscopeValue()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Vector3.zero;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return Vector3.zero;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.GyroscopeValue;
	}

	public Quaternion GetOrientation()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Quaternion.identity;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return default;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.Orientation;
	}

	Quaternion IDualShock4Extension.GetOrientation()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetOrientation
		return this.GetOrientation();
	}

	public void ResetOrientation()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (xyPrBbMWmFTJtAMjsvgCBbgcurpK)
		{
			lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.ResetOrientation();
		}
	}

	void IDualShock4Extension.ResetOrientation()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ResetOrientation
		this.ResetOrientation();
	}

	public int get_maxTouches()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK)
		{
			return 0;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.MaxTouches;
	}

	public int get_touchCount()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.GetTouchCount();
	}

	public int GetTouchId(int index)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return -1;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return -1;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.GetTouchIdAtIndex(index);
	}

	int IDualShock4Extension.GetTouchId(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchId
		return this.GetTouchId(index);
	}

	public bool GetTouchPosition(int index, out Vector2 position)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			position = Vector2.zero;
			return false;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			position = Vector2.zero;
			return false;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.GetTouchPositionByIndex(index, out position);
	}

	bool IDualShock4Extension.GetTouchPosition(int index, out Vector2 position)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchPosition
		return this.GetTouchPosition(index, out position);
	}

	public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			position = Vector2.zero;
			return false;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			position = Vector2.zero;
			return false;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.GetTouchPositionByTouchId(touchId, out position);
	}

	bool IDualShock4Extension.GetTouchPositionByTouchId(int touchId, out Vector2 position)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByTouchId
		return this.GetTouchPositionByTouchId(touchId, out position);
	}

	public bool GetTouchPositionAbsolute(int index, out Vector2 position)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			position = Vector2.zero;
			return false;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			position = Vector2.zero;
			return false;
		}
		bool touchPositionAbsoluteByIndex = lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.GetTouchPositionAbsoluteByIndex(index, out var positionX, out var positionY);
		position = new Vector2(positionX, positionY);
		return touchPositionAbsoluteByIndex;
	}

	public bool GetTouchPositionAbsoluteByTouchId(int touchId, out Vector2 position)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			position = Vector2.zero;
			return false;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			position = Vector2.zero;
			return false;
		}
		bool touchPositionAbsoluteByTouchId = lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.GetTouchPositionAbsoluteByTouchId(touchId, out var positionX, out var positionY);
		position = new Vector2(positionX, positionY);
		return touchPositionAbsoluteByTouchId;
	}

	public bool IsTouching(int index)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return false;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return false;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.IsTouchingAtIndex(index);
	}

	bool IDualShock4Extension.IsTouching(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsTouching
		return this.IsTouching(index);
	}

	public bool IsTouchingByTouchId(int touchId)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return false;
		}
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return false;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.IsTouchingAtTouchId(touchId);
	}

	bool IDualShock4Extension.IsTouchingByTouchId(int touchId)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsTouchingByTouchId
		return this.IsTouchingByTouchId(touchId);
	}

	public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return false;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.SetTriggerEffect(trigger, effect);
	}

	bool IDualSenseExtension.SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetTriggerEffect
		return this.SetTriggerEffect(trigger, effect);
	}

	public DualSenseTriggerEffectStates GetTriggerEffectStates()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return default;
		}
		return lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA.GetTriggerEffectStates();
	}

	DualSenseTriggerEffectStates IDualSenseExtension.GetTriggerEffectStates()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTriggerEffectStates
		return this.GetTriggerEffectStates();
	}

	Vector3 IDualShock4Extension.GetGyroscopeValue()
	{
		return GetGyroscopeValue();
	}

	Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
	{
		return GetGyroscopeValueRaw();
	}

	internal override void UpdateData(UpdateLoopType updateLoop)
	{
		if (xyPrBbMWmFTJtAMjsvgCBbgcurpK && base.enabled)
		{
			ErYBqjdKGQxrqilKHmauenZNqqiQA();
		}
	}

	internal override void SourceUpdated(IControllerExtensionSource source)
	{
		lyBitQjEmxYhzUTDFlyVFyHPIbOQ = source as zAtNGMcGoiZbgzeVCYhxuhrHavNz;
		xyPrBbMWmFTJtAMjsvgCBbgcurpK = lyBitQjEmxYhzUTDFlyVFyHPIbOQ != null && lyBitQjEmxYhzUTDFlyVFyHPIbOQ.ZZVAziEFlsmCJEupQkHQPYFkxiRAA != null;
	}

	internal override Controller.Extension Clone()
	{
		return new DualSenseExtension(this);
	}

	private void ErYBqjdKGQxrqilKHmauenZNqqiQA()
	{
		if (!xyPrBbMWmFTJtAMjsvgCBbgcurpK || !lyBitQjEmxYhzUTDFlyVFyHPIbOQ.iNeecqAJOQcLOKhluPbaUudQeIAt)
		{
			return;
		}
		for (int i = 0; i < lyBitQjEmxYhzUTDFlyVFyHPIbOQ.mnNMgSILWZJVdEhJePHRwvEJoDTo; i++)
		{
			if (uXuegOxnrvEhtMeZQTBhrIopzADM[i].Update())
			{
				SetVibration(i, 0f, stopOtherMotors: false);
			}
		}
	}

	private void XAlCmdGSRzonLhrMMSZLxGWDBLvzA(DualShock4MotorType P_0, float P_1, float P_2)
	{
		int num = P_0 switch
		{
			DualShock4MotorType.LeftMotor => 0, 
			DualShock4MotorType.RightMotor => 1, 
			_ => throw new NotImplementedException(), 
		};
		if (P_1 <= 0f || P_2 <= 0f)
		{
			uXuegOxnrvEhtMeZQTBhrIopzADM[num].Clear();
		}
		else
		{
			uXuegOxnrvEhtMeZQTBhrIopzADM[num].Start(P_2);
		}
	}
}
