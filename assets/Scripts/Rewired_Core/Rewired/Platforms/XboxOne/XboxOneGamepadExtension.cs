using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne;

[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
{
	private class tPkwcrZfkManiAoAmzfAVrovGkKQA : IControllerExtensionSource
	{
		public const int PfKtmavnQsZcEtcMBJeXkrPaHoCeb = 4;

		public ScRkIYlonjqaoTPfnDTZtxVVYNnp fmOJTxSVMdqiJODeiSPNPbyyyDoS;

		public readonly IXboxOneInputSource LnaQNYdakKzqmwedwJKJsWmtGoOv;

		public readonly bool CmnfxDgrCWpNZCfpDVmBXZyeyAkLA;

		public tPkwcrZfkManiAoAmzfAVrovGkKQA(bool P_0, IXboxOneInputSource P_1, ScRkIYlonjqaoTPfnDTZtxVVYNnp P_2)
		{
			fmOJTxSVMdqiJODeiSPNPbyyyDoS = P_2;
			LnaQNYdakKzqmwedwJKJsWmtGoOv = P_1;
			CmnfxDgrCWpNZCfpDVmBXZyeyAkLA = P_0;
		}
	}

	private tPkwcrZfkManiAoAmzfAVrovGkKQA YnjhgkeMomyZKAxNHVNhjrJfCZbr;

	private TimerAbs[] dNMcMuDNZMpeOazPyhoRimSMicVcA;

	private Joystick joystick => gVPEsxXFDDmzjbiAEAvpzHShnQHJ();

	public int xboxOneUserId
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return -1;
			}
			if (YnjhgkeMomyZKAxNHVNhjrJfCZbr.LnaQNYdakKzqmwedwJKJsWmtGoOv == null || gVPEsxXFDDmzjbiAEAvpzHShnQHJ() == null)
			{
				return -1;
			}
			return YnjhgkeMomyZKAxNHVNhjrJfCZbr.LnaQNYdakKzqmwedwJKJsWmtGoOv.GetXboxOneUserIdFromUnityJoystick(gVPEsxXFDDmzjbiAEAvpzHShnQHJ().unityId);
		}
	}

	public ulong xboxOneJoystickId
	{
		get
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0uL;
			}
			if (gVPEsxXFDDmzjbiAEAvpzHShnQHJ() == null)
			{
				return 0uL;
			}
			long? systemId = gVPEsxXFDDmzjbiAEAvpzHShnQHJ().systemId;
			if (!systemId.HasValue)
			{
				return 0uL;
			}
			return (ulong)systemId.Value;
		}
	}

	int IControllerVibrator.vibrationMotorCount => get_vibrationMotorCount();

	private Joystick gVPEsxXFDDmzjbiAEAvpzHShnQHJ()
	{
		return GetController<Joystick>();
	}

	internal XboxOneGamepadExtension(bool P_0, IXboxOneInputSource P_1)
		: base(new tPkwcrZfkManiAoAmzfAVrovGkKQA(P_0, P_1, default))
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("xboxOneInputSource");
		}
		dNMcMuDNZMpeOazPyhoRimSMicVcA = new TimerAbs[4];
		ArrayTools.Populate(dNMcMuDNZMpeOazPyhoRimSMicVcA, 0, dNMcMuDNZMpeOazPyhoRimSMicVcA.Length);
	}

	private XboxOneGamepadExtension(XboxOneGamepadExtension P_0)
		: base(P_0)
	{
		dNMcMuDNZMpeOazPyhoRimSMicVcA = new TimerAbs[4];
		ArrayTools.Populate(dNMcMuDNZMpeOazPyhoRimSMicVcA, 0, dNMcMuDNZMpeOazPyhoRimSMicVcA.Length);
	}

	public int get_vibrationMotorCount()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0;
		}
		return 4;
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
		else if (motorIndex >= 0 && motorIndex < 4)
		{
			SetVibration(motorIndex switch
			{
				0 => XboxOneGamepadMotorType.LeftMotor, 
				1 => XboxOneGamepadMotorType.RightMotor, 
				2 => XboxOneGamepadMotorType.LeftTriggerMotor, 
				3 => XboxOneGamepadMotorType.RightTriggerMotor, 
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
		if (!YnjhgkeMomyZKAxNHVNhjrJfCZbr.CmnfxDgrCWpNZCfpDVmBXZyeyAkLA)
		{
			return 0f;
		}
		return motorIndex switch
		{
			0 => YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.ESlMuLkgKQnsAiPybXNJByaVwZDJ, 
			1 => YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.VefzwrGRWKTsFgECSEzSpAidmpPs, 
			2 => YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.BcRJsscedBhCNKgzjQHIEGwWvJUoA, 
			3 => YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.dbAJcQXqVdfEbCdsadMccSNgOvCmc, 
			_ => 0f, 
		};
	}

	float IControllerVibrator.GetVibration(int motorIndex)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetVibration
		return this.GetVibration(motorIndex);
	}

	public float GetVibration(XboxOneGamepadMotorType motor)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0f;
		}
		if (!YnjhgkeMomyZKAxNHVNhjrJfCZbr.CmnfxDgrCWpNZCfpDVmBXZyeyAkLA)
		{
			return 0f;
		}
		return motor switch
		{
			XboxOneGamepadMotorType.LeftMotor => YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.ESlMuLkgKQnsAiPybXNJByaVwZDJ, 
			XboxOneGamepadMotorType.RightMotor => YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.VefzwrGRWKTsFgECSEzSpAidmpPs, 
			XboxOneGamepadMotorType.LeftTriggerMotor => YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.BcRJsscedBhCNKgzjQHIEGwWvJUoA, 
			XboxOneGamepadMotorType.RightTriggerMotor => YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.dbAJcQXqVdfEbCdsadMccSNgOvCmc, 
			_ => throw new NotImplementedException(), 
		};
	}

	public void StopVibration()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (YnjhgkeMomyZKAxNHVNhjrJfCZbr.CmnfxDgrCWpNZCfpDVmBXZyeyAkLA)
		{
			YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.rOaLnzGnDcwDKqPeOyTQfVKztwIf();
			for (int i = 0; i < 4; i++)
			{
				dNMcMuDNZMpeOazPyhoRimSMicVcA[i].Clear();
			}
			wqwfIstostDojkuyOjdhboMCENXtA();
		}
	}

	void IControllerVibrator.StopVibration()
	{
		//ILSpy generated this explicit interface implementation from .override directive in StopVibration
		this.StopVibration();
	}

	public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel)
	{
		SetVibration(motor, motorLevel, 0f, stopOtherMotors: false);
	}

	public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, float duration)
	{
		SetVibration(motor, motorLevel, duration, stopOtherMotors: false);
	}

	public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, bool stopOtherMotors)
	{
		SetVibration(motor, motorLevel, 0f, stopOtherMotors);
	}

	public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, float duration, bool stopOtherMotors)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else
		{
			if (!YnjhgkeMomyZKAxNHVNhjrJfCZbr.CmnfxDgrCWpNZCfpDVmBXZyeyAkLA)
			{
				return;
			}
			if (stopOtherMotors)
			{
				YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.rOaLnzGnDcwDKqPeOyTQfVKztwIf();
				for (int i = 0; i < 4; i++)
				{
					dNMcMuDNZMpeOazPyhoRimSMicVcA[i].Clear();
				}
			}
			motorLevel = MathTools.Clamp01(motorLevel);
			switch (motor)
			{
			case XboxOneGamepadMotorType.LeftMotor:
				YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.ESlMuLkgKQnsAiPybXNJByaVwZDJ = motorLevel;
				break;
			case XboxOneGamepadMotorType.RightMotor:
				YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.VefzwrGRWKTsFgECSEzSpAidmpPs = motorLevel;
				break;
			case XboxOneGamepadMotorType.LeftTriggerMotor:
				YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.BcRJsscedBhCNKgzjQHIEGwWvJUoA = motorLevel;
				break;
			case XboxOneGamepadMotorType.RightTriggerMotor:
				YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.dbAJcQXqVdfEbCdsadMccSNgOvCmc = motorLevel;
				break;
			default:
				throw new NotImplementedException();
			}
			DXvDrbKIBQFsOJhzfJYYVScvsDKsA(motor, motorLevel, duration);
			wqwfIstostDojkuyOjdhboMCENXtA();
		}
	}

	public void SetVibration(float leftMotorLevel, float rightMotorLevel)
	{
		SetVibration(leftMotorLevel, rightMotorLevel, stopOtherMotors: false);
	}

	public void SetVibration(float leftMotorLevel, float rightMotorLevel, bool stopOtherMotors)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else
		{
			if (!YnjhgkeMomyZKAxNHVNhjrJfCZbr.CmnfxDgrCWpNZCfpDVmBXZyeyAkLA)
			{
				return;
			}
			if (stopOtherMotors)
			{
				YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.rOaLnzGnDcwDKqPeOyTQfVKztwIf();
				for (int i = 0; i < 4; i++)
				{
					dNMcMuDNZMpeOazPyhoRimSMicVcA[i].Clear();
				}
			}
			YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.tOMdnbezHSkZivkAQecHSBhskDVM = xboxOneJoystickId;
			YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.ESlMuLkgKQnsAiPybXNJByaVwZDJ = MathTools.Clamp01(leftMotorLevel);
			YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.VefzwrGRWKTsFgECSEzSpAidmpPs = MathTools.Clamp01(rightMotorLevel);
			dNMcMuDNZMpeOazPyhoRimSMicVcA[0].Clear();
			dNMcMuDNZMpeOazPyhoRimSMicVcA[1].Clear();
			wqwfIstostDojkuyOjdhboMCENXtA();
		}
	}

	public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (YnjhgkeMomyZKAxNHVNhjrJfCZbr.CmnfxDgrCWpNZCfpDVmBXZyeyAkLA)
		{
			YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.tOMdnbezHSkZivkAQecHSBhskDVM = xboxOneJoystickId;
			YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.ESlMuLkgKQnsAiPybXNJByaVwZDJ = MathTools.Clamp01(leftMotorLevel);
			YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.VefzwrGRWKTsFgECSEzSpAidmpPs = MathTools.Clamp01(rightMotorLevel);
			YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.BcRJsscedBhCNKgzjQHIEGwWvJUoA = MathTools.Clamp01(leftTriggerLevel);
			YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS.dbAJcQXqVdfEbCdsadMccSNgOvCmc = MathTools.Clamp01(rightTriggerLevel);
			for (int i = 0; i < 4; i++)
			{
				dNMcMuDNZMpeOazPyhoRimSMicVcA[i].Clear();
			}
			wqwfIstostDojkuyOjdhboMCENXtA();
		}
	}

	public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else if (base.isJoystickConnected && YnjhgkeMomyZKAxNHVNhjrJfCZbr.CmnfxDgrCWpNZCfpDVmBXZyeyAkLA)
		{
			DXvDrbKIBQFsOJhzfJYYVScvsDKsA(motor, 0f, 0f);
			YnjhgkeMomyZKAxNHVNhjrJfCZbr.LnaQNYdakKzqmwedwJKJsWmtGoOv.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
		}
	}

	internal override void UpdateData(UpdateLoopType updateLoop)
	{
		aoPrKqkhIqYbNLhqaEJdIiuhjaxH();
	}

	internal override void SourceUpdated(IControllerExtensionSource source)
	{
		YnjhgkeMomyZKAxNHVNhjrJfCZbr = source as tPkwcrZfkManiAoAmzfAVrovGkKQA;
	}

	internal override Controller.Extension Clone()
	{
		return new XboxOneGamepadExtension(this);
	}

	private void aoPrKqkhIqYbNLhqaEJdIiuhjaxH()
	{
		if (!YnjhgkeMomyZKAxNHVNhjrJfCZbr.CmnfxDgrCWpNZCfpDVmBXZyeyAkLA)
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			if (dNMcMuDNZMpeOazPyhoRimSMicVcA[i].Update())
			{
				SetVibration(i, 0f, stopOtherMotors: false);
			}
		}
	}

	private void DXvDrbKIBQFsOJhzfJYYVScvsDKsA(XboxOneGamepadMotorType P_0, float P_1, float P_2)
	{
		int num = P_0 switch
		{
			XboxOneGamepadMotorType.LeftMotor => 0, 
			XboxOneGamepadMotorType.RightMotor => 1, 
			XboxOneGamepadMotorType.LeftTriggerMotor => 2, 
			XboxOneGamepadMotorType.RightTriggerMotor => 3, 
			_ => throw new NotImplementedException(), 
		};
		if (P_1 <= 0f || P_2 <= 0f)
		{
			dNMcMuDNZMpeOazPyhoRimSMicVcA[num].Clear();
		}
		else
		{
			dNMcMuDNZMpeOazPyhoRimSMicVcA[num].Start(P_2);
		}
	}

	private void wqwfIstostDojkuyOjdhboMCENXtA()
	{
		if (base.isJoystickConnected)
		{
			YnjhgkeMomyZKAxNHVNhjrJfCZbr.LnaQNYdakKzqmwedwJKJsWmtGoOv.SetXboxOneVibration(xboxOneJoystickId, YnjhgkeMomyZKAxNHVNhjrJfCZbr.fmOJTxSVMdqiJODeiSPNPbyyyDoS);
		}
	}
}
