using System;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions;

[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
public sealed class DualShock4Extension : Controller.Extension, IControllerVibrator, IDualShock4Extension, IHIDControllerExtension
{
	private class zcZQQpKbrpsrWJfTpaENWrwGUtis : IControllerExtensionSource
	{
		public readonly IDriver_DualShock4 pTyjtCsAAazEaLbxkBBykzSdmgcqA;

		public readonly bool kCguKQMEWEgQCoBADaSZahTSSamBA;

		public readonly int SedyQjiIzEIIlSIrDCJWfgwlhJLiA;

		public zcZQQpKbrpsrWJfTpaENWrwGUtis(IDriver_DualShock4 P_0, bool P_1, int P_2)
		{
			pTyjtCsAAazEaLbxkBBykzSdmgcqA = P_0;
			kCguKQMEWEgQCoBADaSZahTSSamBA = P_1;
			SedyQjiIzEIIlSIrDCJWfgwlhJLiA = P_2;
		}
	}

	private zcZQQpKbrpsrWJfTpaENWrwGUtis ZKccYFCbVdlDddwAwBotvRhScWSgA;

	private bool pqPUdsZcVFtJkxQDUtVKEYlorDOF;

	private TimerAbs[] hMZNaZucORfZhxvJTiYiEFMhEAywA;

	private Joystick joystick => XJskpHbOKQYbjXKTwKqNaQxINkiv();

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
			if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled)
			{
				return 0f;
			}
			return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorR;
		}
		set
		{
			if (pqPUdsZcVFtJkxQDUtVKEYlorDOF)
			{
				ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorR = value;
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
			if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled)
			{
				return 0f;
			}
			return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorG;
		}
		set
		{
			if (pqPUdsZcVFtJkxQDUtVKEYlorDOF)
			{
				ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorG = value;
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
			if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled)
			{
				return 0f;
			}
			return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorB;
		}
		set
		{
			if (pqPUdsZcVFtJkxQDUtVKEYlorDOF)
			{
				ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorB = value;
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
			if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF)
			{
				return 0f;
			}
			return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.BatteryLevel;
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
			if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF)
			{
				return false;
			}
			return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.BatteryCharging;
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
			return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.vendorId;
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
			return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.productId;
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
			return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.productName;
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
			return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.manufacturer;
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
			return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.usagePage;
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
			return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.usage;
		}
	}

	private Joystick XJskpHbOKQYbjXKTwKqNaQxINkiv()
	{
		return GetController<Joystick>();
	}

	internal DualShock4Extension(IDriver_DualShock4 P_0)
		: base(new zcZQQpKbrpsrWJfTpaENWrwGUtis(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
	{
		hMZNaZucORfZhxvJTiYiEFMhEAywA = new TimerAbs[P_0.VibrationMotorCount];
		ArrayTools.Populate(hMZNaZucORfZhxvJTiYiEFMhEAywA, 0, hMZNaZucORfZhxvJTiYiEFMhEAywA.Length);
	}

	private DualShock4Extension(DualShock4Extension P_0)
		: base(P_0)
	{
		try
		{
			hMZNaZucORfZhxvJTiYiEFMhEAywA = new TimerAbs[P_0.get_vibrationMotorCount()];
		}
		catch
		{
			hMZNaZucORfZhxvJTiYiEFMhEAywA = new TimerAbs[0];
		}
		ArrayTools.Populate(hMZNaZucORfZhxvJTiYiEFMhEAywA, 0, hMZNaZucORfZhxvJTiYiEFMhEAywA.Length);
	}

	public int get_vibrationMotorCount()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF)
		{
			return 0;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.SedyQjiIzEIIlSIrDCJWfgwlhJLiA;
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
		else if (pqPUdsZcVFtJkxQDUtVKEYlorDOF && base.enabled && motorIndex >= 0 && motorIndex < ZKccYFCbVdlDddwAwBotvRhScWSgA.SedyQjiIzEIIlSIrDCJWfgwlhJLiA)
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
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled)
		{
			return 0f;
		}
		if (!ZKccYFCbVdlDddwAwBotvRhScWSgA.kCguKQMEWEgQCoBADaSZahTSSamBA)
		{
			return 0f;
		}
		return motorIndex switch
		{
			0 => ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LeftMotor, 
			1 => ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.RightMotor, 
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
		else if (pqPUdsZcVFtJkxQDUtVKEYlorDOF && base.enabled && ZKccYFCbVdlDddwAwBotvRhScWSgA.kCguKQMEWEgQCoBADaSZahTSSamBA)
		{
			for (int i = 0; i < ZKccYFCbVdlDddwAwBotvRhScWSgA.SedyQjiIzEIIlSIrDCJWfgwlhJLiA; i++)
			{
				hMZNaZucORfZhxvJTiYiEFMhEAywA[i].Clear();
			}
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.StopVibration();
		}
	}

	void IControllerVibrator.StopVibration()
	{
		//ILSpy generated this explicit interface implementation from .override directive in StopVibration
		this.StopVibration();
	}

	public float GetVibration(DualShock4MotorType motor)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0f;
		}
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled)
		{
			return 0f;
		}
		if (!ZKccYFCbVdlDddwAwBotvRhScWSgA.kCguKQMEWEgQCoBADaSZahTSSamBA)
		{
			return 0f;
		}
		return (int)motor switch
		{
			0 => ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LeftMotor, 
			1 => ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.RightMotor, 
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
			if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ZKccYFCbVdlDddwAwBotvRhScWSgA.kCguKQMEWEgQCoBADaSZahTSSamBA)
			{
				return;
			}
			if (stopOtherMotors)
			{
				for (int i = 0; i < ZKccYFCbVdlDddwAwBotvRhScWSgA.SedyQjiIzEIIlSIrDCJWfgwlhJLiA; i++)
				{
					hMZNaZucORfZhxvJTiYiEFMhEAywA[i].Clear();
				}
				ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.StopVibration();
			}
			motorLevel = MathTools.Clamp01(motorLevel);
			switch ((int)motor)
			{
			case 0:
				ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LeftMotor = motorLevel;
				break;
			case 1:
				ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.RightMotor = motorLevel;
				break;
			default:
				throw new NotImplementedException();
			}
			ZWUhBOjjNhtdCXAJknJaUjzIxKJH(motor, motorLevel, duration);
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
		else if (pqPUdsZcVFtJkxQDUtVKEYlorDOF && base.enabled && ZKccYFCbVdlDddwAwBotvRhScWSgA.kCguKQMEWEgQCoBADaSZahTSSamBA)
		{
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LeftMotor = MathTools.Clamp01(leftMotorLevel);
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.RightMotor = MathTools.Clamp01(rightMotorLevel);
			ZWUhBOjjNhtdCXAJknJaUjzIxKJH(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
			ZWUhBOjjNhtdCXAJknJaUjzIxKJH(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
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
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF)
		{
			return default;
		}
		return new Color(ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorR, ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorG, ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorB, 1f);
	}

	public void SetLightColor(Color color)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (pqPUdsZcVFtJkxQDUtVKEYlorDOF && base.enabled)
		{
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorR = color.r * color.a;
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorG = color.g * color.a;
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorB = color.b * color.a;
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
		else if (pqPUdsZcVFtJkxQDUtVKEYlorDOF && base.enabled)
		{
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorR = red * intensity;
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorG = green * intensity;
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightColorB = blue * intensity;
		}
	}

	void IDualShock4Extension.SetLightColor(float red, float green, float blue, float intensity)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetLightColor
		this.SetLightColor(red, green, blue, intensity);
	}

	public void SetLightFlash(float onDuration, float offDuration)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (pqPUdsZcVFtJkxQDUtVKEYlorDOF && base.enabled)
		{
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightFlashOnDuration = onDuration;
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LightFlashOffDuration = offDuration;
		}
	}

	public void StopLightFlash()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (pqPUdsZcVFtJkxQDUtVKEYlorDOF && base.enabled)
		{
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.StopLightFlash();
		}
	}

	public Vector3 GetAccelerometerValueRaw()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Vector3.zero;
		}
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return Vector3.zero;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.AccelerometerValueRaw;
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
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return Vector3.zero;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.AccelerometerValue;
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
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return Vector3.zero;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LastGyroscopeValueRaw;
	}

	public Vector3 GetLastGyroscopeValue()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Vector3.zero;
		}
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return Vector3.zero;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.LastGyroscopeValue;
	}

	public Vector3 GetGyroscopeValueRaw()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Vector3.zero;
		}
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return Vector3.zero;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.GyroscopeValueRaw;
	}

	public Vector3 GetGyroscopeValue()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Vector3.zero;
		}
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return Vector3.zero;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.GyroscopeValue;
	}

	public Quaternion GetOrientation()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Quaternion.identity;
		}
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return default;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.Orientation;
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
		else if (pqPUdsZcVFtJkxQDUtVKEYlorDOF)
		{
			ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.ResetOrientation();
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
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF)
		{
			return 0;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.MaxTouches;
	}

	public int get_touchCount()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.GetTouchCount();
	}

	public int GetTouchId(int index)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return -1;
		}
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return -1;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.GetTouchIdAtIndex(index);
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
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			position = Vector2.zero;
			return false;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.GetTouchPositionByIndex(index, out position);
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
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			position = Vector2.zero;
			return false;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.GetTouchPositionByTouchId(touchId, out position);
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
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			position = Vector2.zero;
			return false;
		}
		bool touchPositionAbsoluteByIndex = ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.GetTouchPositionAbsoluteByIndex(index, out var positionX, out var positionY);
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
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			position = Vector2.zero;
			return false;
		}
		bool touchPositionAbsoluteByTouchId = ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.GetTouchPositionAbsoluteByTouchId(touchId, out var positionX, out var positionY);
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
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return false;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.IsTouchingAtIndex(index);
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
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
		{
			return false;
		}
		return ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA.IsTouchingAtTouchId(touchId);
	}

	bool IDualShock4Extension.IsTouchingByTouchId(int touchId)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsTouchingByTouchId
		return this.IsTouchingByTouchId(touchId);
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
		if (pqPUdsZcVFtJkxQDUtVKEYlorDOF && base.enabled)
		{
			RfHDPDjcPUlkRMYWucxyVhminilDb();
		}
	}

	internal override void SourceUpdated(IControllerExtensionSource source)
	{
		ZKccYFCbVdlDddwAwBotvRhScWSgA = source as zcZQQpKbrpsrWJfTpaENWrwGUtis;
		pqPUdsZcVFtJkxQDUtVKEYlorDOF = ZKccYFCbVdlDddwAwBotvRhScWSgA != null && ZKccYFCbVdlDddwAwBotvRhScWSgA.pTyjtCsAAazEaLbxkBBykzSdmgcqA != null;
	}

	internal override Controller.Extension Clone()
	{
		return new DualShock4Extension(this);
	}

	private void RfHDPDjcPUlkRMYWucxyVhminilDb()
	{
		if (!pqPUdsZcVFtJkxQDUtVKEYlorDOF || !ZKccYFCbVdlDddwAwBotvRhScWSgA.kCguKQMEWEgQCoBADaSZahTSSamBA)
		{
			return;
		}
		for (int i = 0; i < ZKccYFCbVdlDddwAwBotvRhScWSgA.SedyQjiIzEIIlSIrDCJWfgwlhJLiA; i++)
		{
			if (hMZNaZucORfZhxvJTiYiEFMhEAywA[i].Update())
			{
				SetVibration(i, 0f, stopOtherMotors: false);
			}
		}
	}

	private void ZWUhBOjjNhtdCXAJknJaUjzIxKJH(DualShock4MotorType P_0, float P_1, float P_2)
	{
		int num = P_0 switch
		{
			DualShock4MotorType.LeftMotor => 0, 
			DualShock4MotorType.RightMotor => 1, 
			_ => throw new NotImplementedException(), 
		};
		if (P_1 <= 0f || P_2 <= 0f)
		{
			hMZNaZucORfZhxvJTiYiEFMhEAywA[num].Clear();
		}
		else
		{
			hMZNaZucORfZhxvJTiYiEFMhEAywA[num].Start(P_2);
		}
	}
}
