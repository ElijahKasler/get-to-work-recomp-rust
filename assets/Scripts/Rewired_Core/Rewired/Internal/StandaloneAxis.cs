using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Internal;

[Serializable]
[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal sealed class StandaloneAxis
{
	[CustomObfuscation(rename = false)]
	public delegate void AxisValueChangedEventHandler(float value);

	[CustomObfuscation(rename = false)]
	public delegate void ButtonValueChangedEventHandler(bool value);

	[CustomObfuscation(rename = false)]
	public delegate void ButtonDownEventHandler();

	[CustomObfuscation(rename = false)]
	public delegate void ButtonUpEventHandler();

	[Tooltip("The axis value at or above which the buttonValue property will return True. This will also return true for negative values below the inverse of this threshold.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Range(0f, 1f)]
	private float _buttonActivationThreshold = 0.5f;

	[Tooltip("Contains calibration settings for the axis.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private AxisCalibration _calibration = new AxisCalibration();

	[CustomObfuscation(rename = false)]
	private float _valueRaw;

	[CustomObfuscation(rename = false)]
	private float _valueRawPrev;

	[CompilerGenerated]
	private AxisValueChangedEventHandler cqRhNHryOOJtHITlEECHGouoXZPK;

	[CompilerGenerated]
	private AxisValueChangedEventHandler jKozyqbpDJZOACbzEsUzKaTpToWD;

	[CompilerGenerated]
	private ButtonDownEventHandler AWpdIXwSbveWudjkqdSuzSaFRuSZ;

	[CompilerGenerated]
	private ButtonUpEventHandler mJdeLLUIhnCYAApVZqqyIijHwyulA;

	[CompilerGenerated]
	private ButtonValueChangedEventHandler JQPBvIjjscKTETmTYWstRfAfXNTi;

	[CompilerGenerated]
	private ButtonDownEventHandler RtVzLXdAcRWwraAOqZdpycpCNGui;

	[CompilerGenerated]
	private ButtonUpEventHandler TmMNLcWBwDfJCcKchmuxVPsQGmbHb;

	[CompilerGenerated]
	private ButtonValueChangedEventHandler QCeXZRaTYMcWsqbnhhknLlFvEKwS;

	public float buttonActivationThreshold
	{
		get
		{
			return _buttonActivationThreshold;
		}
		set
		{
			if (value != _buttonActivationThreshold)
			{
				_buttonActivationThreshold = MathTools.Abs(value);
			}
		}
	}

	public AxisCalibration calibration
	{
		get
		{
			return _calibration;
		}
		private set
		{
			sSHMIzueaceFwwmVeaavCBWjrDAd(axisCalibration);
		}
	}

	public float valueRaw
	{
		get
		{
			return _valueRaw;
		}
		private set
		{
			PtEGUQjePRCRjpwuYalTkDTwylsvA(num);
		}
	}

	public float valueRawPrev
	{
		get
		{
			return _valueRawPrev;
		}
		private set
		{
			dDwiwHagsVujMucsehGQGLKFDIEyB(num);
		}
	}

	public float valueRawDelta => _valueRaw - _valueRawPrev;

	public float value
	{
		get
		{
			if (_calibration == null)
			{
				return _valueRaw;
			}
			return _calibration.GetCalibratedValue(_valueRaw);
		}
	}

	public float valuePrev
	{
		get
		{
			if (_calibration == null)
			{
				return _valueRawPrev;
			}
			return _calibration.GetCalibratedValue(_valueRawPrev);
		}
	}

	public float valueDelta
	{
		get
		{
			if (_calibration == null)
			{
				return valueRawDelta;
			}
			return _calibration.GetCalibratedValue(_valueRaw) - _calibration.GetCalibratedValue(_valueRawPrev);
		}
	}

	public bool rawButtonValue => _valueRaw >= _buttonActivationThreshold;

	public bool rawButtonValuePrev => _valueRawPrev >= _buttonActivationThreshold;

	public bool buttonValue => MathTools.Abs(_calibration.GetCalibratedValue(value)) >= _buttonActivationThreshold;

	public bool buttonValuePrev => MathTools.Abs(_calibration.GetCalibratedValue(valuePrev)) >= _buttonActivationThreshold;

	internal float rawMin
	{
		get
		{
			if (_calibration == null)
			{
				return -1f;
			}
			if (!_calibration.applyRangeCalibration)
			{
				return float.NegativeInfinity;
			}
			return _calibration.calibratedMin;
		}
	}

	internal float rawMax
	{
		get
		{
			if (_calibration == null)
			{
				return 1f;
			}
			if (!_calibration.applyRangeCalibration)
			{
				return float.PositiveInfinity;
			}
			return _calibration.calibratedMax;
		}
	}

	internal float rawZero
	{
		get
		{
			if (_calibration == null)
			{
				return 0f;
			}
			if (!_calibration.applyRangeCalibration)
			{
				return 0f;
			}
			return _calibration.calibratedZero;
		}
	}

	private event AxisValueChangedEventHandler _AxisValueChangedEvent
	{
		add
		{
			vFcDhhRkwEltAbQzijiDDKcCtNXe(axisValueChangedEventHandler);
		}
		remove
		{
			fnZdrWgJnRRxFFRCclWGGuNcBkJWA(axisValueChangedEventHandler);
		}
	}

	public event AxisValueChangedEventHandler AxisValueChangedEvent
	{
		add
		{
			vFcDhhRkwEltAbQzijiDDKcCtNXe(value);
		}
		remove
		{
			fnZdrWgJnRRxFFRCclWGGuNcBkJWA(value);
		}
	}

	private event AxisValueChangedEventHandler _RawAxisValueChangedEvent
	{
		add
		{
			NBKueCrzCCnefMWfDFyaygowqtoD(axisValueChangedEventHandler);
		}
		remove
		{
			BqfGFdIXBWZrpcgPfutjOWvFeTVF(axisValueChangedEventHandler);
		}
	}

	public event AxisValueChangedEventHandler RawAxisValueChangedEvent
	{
		add
		{
			NBKueCrzCCnefMWfDFyaygowqtoD(value);
		}
		remove
		{
			BqfGFdIXBWZrpcgPfutjOWvFeTVF(value);
		}
	}

	private event ButtonDownEventHandler _ButtonDownEvent
	{
		add
		{
			IlFcPCYAGPNGuiJfqckCeJpYKJML(buttonDownEventHandler);
		}
		remove
		{
			iMiPOolgTtBDbbJwVpbneMzBZGWIB(buttonDownEventHandler);
		}
	}

	public event ButtonDownEventHandler ButtonDownEvent
	{
		add
		{
			IlFcPCYAGPNGuiJfqckCeJpYKJML(value);
		}
		remove
		{
			iMiPOolgTtBDbbJwVpbneMzBZGWIB(value);
		}
	}

	private event ButtonUpEventHandler _ButtonUpEvent
	{
		add
		{
			qYMLKLKDItmTepGsEQgyvlpoeFJO(buttonUpEventHandler);
		}
		remove
		{
			RdcLncvsxoDNtFVLgYlnWCRCrRcF(buttonUpEventHandler);
		}
	}

	public event ButtonUpEventHandler ButtonUpEvent
	{
		add
		{
			qYMLKLKDItmTepGsEQgyvlpoeFJO(value);
		}
		remove
		{
			RdcLncvsxoDNtFVLgYlnWCRCrRcF(value);
		}
	}

	private event ButtonValueChangedEventHandler _ButtonValueChangedEvent
	{
		add
		{
			kZhHGGIAXMxXHODGWYBwullvglmo(buttonValueChangedEventHandler);
		}
		remove
		{
			rpHmQXgEoZzyhUdNYgIncJAiEdly(buttonValueChangedEventHandler);
		}
	}

	public event ButtonValueChangedEventHandler ButtonValueChangedEvent
	{
		add
		{
			kZhHGGIAXMxXHODGWYBwullvglmo(value);
		}
		remove
		{
			rpHmQXgEoZzyhUdNYgIncJAiEdly(value);
		}
	}

	private event ButtonDownEventHandler _RawButtonDownEvent
	{
		add
		{
			VEvcZcDHVoCnkdmGfgANGgeqPQZTB(buttonDownEventHandler);
		}
		remove
		{
			vsVlFvVojXmaYdhVEoeHZDXuqoNe(buttonDownEventHandler);
		}
	}

	public event ButtonDownEventHandler RawButtonDownEvent
	{
		add
		{
			VEvcZcDHVoCnkdmGfgANGgeqPQZTB(value);
		}
		remove
		{
			vsVlFvVojXmaYdhVEoeHZDXuqoNe(value);
		}
	}

	private event ButtonUpEventHandler _RawButtonUpEvent
	{
		add
		{
			enRTfnVviEftBygBfvMviNjvLxoM(buttonUpEventHandler);
		}
		remove
		{
			LnuQnPEMIQBUcPuZBcYNDAnrTTZJ(buttonUpEventHandler);
		}
	}

	public event ButtonUpEventHandler RawButtonUpEvent
	{
		add
		{
			enRTfnVviEftBygBfvMviNjvLxoM(value);
		}
		remove
		{
			LnuQnPEMIQBUcPuZBcYNDAnrTTZJ(value);
		}
	}

	private event ButtonValueChangedEventHandler _RawButtonValueChangedEvent
	{
		add
		{
			IWMgVFfdRLcikAzMFHkuHPbVmPLFc(buttonValueChangedEventHandler);
		}
		remove
		{
			OGTLhoTtaOEKMYWuLnDCjbXCLBvH(buttonValueChangedEventHandler);
		}
	}

	public event ButtonValueChangedEventHandler RawButtonValueChangedEvent
	{
		add
		{
			IWMgVFfdRLcikAzMFHkuHPbVmPLFc(value);
		}
		remove
		{
			OGTLhoTtaOEKMYWuLnDCjbXCLBvH(value);
		}
	}

	private void sSHMIzueaceFwwmVeaavCBWjrDAd(AxisCalibration P_0)
	{
		if (P_0 != _calibration)
		{
			_calibration = P_0;
		}
	}

	private void PtEGUQjePRCRjpwuYalTkDTwylsvA(float P_0)
	{
		if (P_0 != _valueRaw)
		{
			_valueRaw = P_0;
		}
	}

	private void dDwiwHagsVujMucsehGQGLKFDIEyB(float P_0)
	{
		if (P_0 != _valueRawPrev)
		{
			_valueRawPrev = P_0;
		}
	}

	private void vFcDhhRkwEltAbQzijiDDKcCtNXe(AxisValueChangedEventHandler P_0)
	{
		AxisValueChangedEventHandler axisValueChangedEventHandler = cqRhNHryOOJtHITlEECHGouoXZPK;
		AxisValueChangedEventHandler axisValueChangedEventHandler2;
		do
		{
			axisValueChangedEventHandler2 = axisValueChangedEventHandler;
			AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler2, P_0);
			axisValueChangedEventHandler = Interlocked.CompareExchange(ref cqRhNHryOOJtHITlEECHGouoXZPK, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
		}
		while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
	}

	private void fnZdrWgJnRRxFFRCclWGGuNcBkJWA(AxisValueChangedEventHandler P_0)
	{
		AxisValueChangedEventHandler axisValueChangedEventHandler = cqRhNHryOOJtHITlEECHGouoXZPK;
		AxisValueChangedEventHandler axisValueChangedEventHandler2;
		do
		{
			axisValueChangedEventHandler2 = axisValueChangedEventHandler;
			AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler2, P_0);
			axisValueChangedEventHandler = Interlocked.CompareExchange(ref cqRhNHryOOJtHITlEECHGouoXZPK, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
		}
		while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
	}

	private void NBKueCrzCCnefMWfDFyaygowqtoD(AxisValueChangedEventHandler P_0)
	{
		AxisValueChangedEventHandler axisValueChangedEventHandler = jKozyqbpDJZOACbzEsUzKaTpToWD;
		AxisValueChangedEventHandler axisValueChangedEventHandler2;
		do
		{
			axisValueChangedEventHandler2 = axisValueChangedEventHandler;
			AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Combine(axisValueChangedEventHandler2, P_0);
			axisValueChangedEventHandler = Interlocked.CompareExchange(ref jKozyqbpDJZOACbzEsUzKaTpToWD, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
		}
		while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
	}

	private void BqfGFdIXBWZrpcgPfutjOWvFeTVF(AxisValueChangedEventHandler P_0)
	{
		AxisValueChangedEventHandler axisValueChangedEventHandler = jKozyqbpDJZOACbzEsUzKaTpToWD;
		AxisValueChangedEventHandler axisValueChangedEventHandler2;
		do
		{
			axisValueChangedEventHandler2 = axisValueChangedEventHandler;
			AxisValueChangedEventHandler axisValueChangedEventHandler3 = (AxisValueChangedEventHandler)Delegate.Remove(axisValueChangedEventHandler2, P_0);
			axisValueChangedEventHandler = Interlocked.CompareExchange(ref jKozyqbpDJZOACbzEsUzKaTpToWD, axisValueChangedEventHandler3, axisValueChangedEventHandler2);
		}
		while ((object)axisValueChangedEventHandler != axisValueChangedEventHandler2);
	}

	private void IlFcPCYAGPNGuiJfqckCeJpYKJML(ButtonDownEventHandler P_0)
	{
		ButtonDownEventHandler buttonDownEventHandler = AWpdIXwSbveWudjkqdSuzSaFRuSZ;
		ButtonDownEventHandler buttonDownEventHandler2;
		do
		{
			buttonDownEventHandler2 = buttonDownEventHandler;
			ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, P_0);
			buttonDownEventHandler = Interlocked.CompareExchange(ref AWpdIXwSbveWudjkqdSuzSaFRuSZ, buttonDownEventHandler3, buttonDownEventHandler2);
		}
		while ((object)buttonDownEventHandler != buttonDownEventHandler2);
	}

	private void iMiPOolgTtBDbbJwVpbneMzBZGWIB(ButtonDownEventHandler P_0)
	{
		ButtonDownEventHandler buttonDownEventHandler = AWpdIXwSbveWudjkqdSuzSaFRuSZ;
		ButtonDownEventHandler buttonDownEventHandler2;
		do
		{
			buttonDownEventHandler2 = buttonDownEventHandler;
			ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, P_0);
			buttonDownEventHandler = Interlocked.CompareExchange(ref AWpdIXwSbveWudjkqdSuzSaFRuSZ, buttonDownEventHandler3, buttonDownEventHandler2);
		}
		while ((object)buttonDownEventHandler != buttonDownEventHandler2);
	}

	private void qYMLKLKDItmTepGsEQgyvlpoeFJO(ButtonUpEventHandler P_0)
	{
		ButtonUpEventHandler buttonUpEventHandler = mJdeLLUIhnCYAApVZqqyIijHwyulA;
		ButtonUpEventHandler buttonUpEventHandler2;
		do
		{
			buttonUpEventHandler2 = buttonUpEventHandler;
			ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, P_0);
			buttonUpEventHandler = Interlocked.CompareExchange(ref mJdeLLUIhnCYAApVZqqyIijHwyulA, buttonUpEventHandler3, buttonUpEventHandler2);
		}
		while ((object)buttonUpEventHandler != buttonUpEventHandler2);
	}

	private void RdcLncvsxoDNtFVLgYlnWCRCrRcF(ButtonUpEventHandler P_0)
	{
		ButtonUpEventHandler buttonUpEventHandler = mJdeLLUIhnCYAApVZqqyIijHwyulA;
		ButtonUpEventHandler buttonUpEventHandler2;
		do
		{
			buttonUpEventHandler2 = buttonUpEventHandler;
			ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, P_0);
			buttonUpEventHandler = Interlocked.CompareExchange(ref mJdeLLUIhnCYAApVZqqyIijHwyulA, buttonUpEventHandler3, buttonUpEventHandler2);
		}
		while ((object)buttonUpEventHandler != buttonUpEventHandler2);
	}

	private void kZhHGGIAXMxXHODGWYBwullvglmo(ButtonValueChangedEventHandler P_0)
	{
		ButtonValueChangedEventHandler buttonValueChangedEventHandler = JQPBvIjjscKTETmTYWstRfAfXNTi;
		ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
		do
		{
			buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
			ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, P_0);
			buttonValueChangedEventHandler = Interlocked.CompareExchange(ref JQPBvIjjscKTETmTYWstRfAfXNTi, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
		}
		while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
	}

	private void rpHmQXgEoZzyhUdNYgIncJAiEdly(ButtonValueChangedEventHandler P_0)
	{
		ButtonValueChangedEventHandler buttonValueChangedEventHandler = JQPBvIjjscKTETmTYWstRfAfXNTi;
		ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
		do
		{
			buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
			ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, P_0);
			buttonValueChangedEventHandler = Interlocked.CompareExchange(ref JQPBvIjjscKTETmTYWstRfAfXNTi, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
		}
		while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
	}

	private void VEvcZcDHVoCnkdmGfgANGgeqPQZTB(ButtonDownEventHandler P_0)
	{
		ButtonDownEventHandler buttonDownEventHandler = RtVzLXdAcRWwraAOqZdpycpCNGui;
		ButtonDownEventHandler buttonDownEventHandler2;
		do
		{
			buttonDownEventHandler2 = buttonDownEventHandler;
			ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Combine(buttonDownEventHandler2, P_0);
			buttonDownEventHandler = Interlocked.CompareExchange(ref RtVzLXdAcRWwraAOqZdpycpCNGui, buttonDownEventHandler3, buttonDownEventHandler2);
		}
		while ((object)buttonDownEventHandler != buttonDownEventHandler2);
	}

	private void vsVlFvVojXmaYdhVEoeHZDXuqoNe(ButtonDownEventHandler P_0)
	{
		ButtonDownEventHandler buttonDownEventHandler = RtVzLXdAcRWwraAOqZdpycpCNGui;
		ButtonDownEventHandler buttonDownEventHandler2;
		do
		{
			buttonDownEventHandler2 = buttonDownEventHandler;
			ButtonDownEventHandler buttonDownEventHandler3 = (ButtonDownEventHandler)Delegate.Remove(buttonDownEventHandler2, P_0);
			buttonDownEventHandler = Interlocked.CompareExchange(ref RtVzLXdAcRWwraAOqZdpycpCNGui, buttonDownEventHandler3, buttonDownEventHandler2);
		}
		while ((object)buttonDownEventHandler != buttonDownEventHandler2);
	}

	private void enRTfnVviEftBygBfvMviNjvLxoM(ButtonUpEventHandler P_0)
	{
		ButtonUpEventHandler buttonUpEventHandler = TmMNLcWBwDfJCcKchmuxVPsQGmbHb;
		ButtonUpEventHandler buttonUpEventHandler2;
		do
		{
			buttonUpEventHandler2 = buttonUpEventHandler;
			ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Combine(buttonUpEventHandler2, P_0);
			buttonUpEventHandler = Interlocked.CompareExchange(ref TmMNLcWBwDfJCcKchmuxVPsQGmbHb, buttonUpEventHandler3, buttonUpEventHandler2);
		}
		while ((object)buttonUpEventHandler != buttonUpEventHandler2);
	}

	private void LnuQnPEMIQBUcPuZBcYNDAnrTTZJ(ButtonUpEventHandler P_0)
	{
		ButtonUpEventHandler buttonUpEventHandler = TmMNLcWBwDfJCcKchmuxVPsQGmbHb;
		ButtonUpEventHandler buttonUpEventHandler2;
		do
		{
			buttonUpEventHandler2 = buttonUpEventHandler;
			ButtonUpEventHandler buttonUpEventHandler3 = (ButtonUpEventHandler)Delegate.Remove(buttonUpEventHandler2, P_0);
			buttonUpEventHandler = Interlocked.CompareExchange(ref TmMNLcWBwDfJCcKchmuxVPsQGmbHb, buttonUpEventHandler3, buttonUpEventHandler2);
		}
		while ((object)buttonUpEventHandler != buttonUpEventHandler2);
	}

	private void IWMgVFfdRLcikAzMFHkuHPbVmPLFc(ButtonValueChangedEventHandler P_0)
	{
		ButtonValueChangedEventHandler buttonValueChangedEventHandler = QCeXZRaTYMcWsqbnhhknLlFvEKwS;
		ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
		do
		{
			buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
			ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Combine(buttonValueChangedEventHandler2, P_0);
			buttonValueChangedEventHandler = Interlocked.CompareExchange(ref QCeXZRaTYMcWsqbnhhknLlFvEKwS, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
		}
		while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
	}

	private void OGTLhoTtaOEKMYWuLnDCjbXCLBvH(ButtonValueChangedEventHandler P_0)
	{
		ButtonValueChangedEventHandler buttonValueChangedEventHandler = QCeXZRaTYMcWsqbnhhknLlFvEKwS;
		ButtonValueChangedEventHandler buttonValueChangedEventHandler2;
		do
		{
			buttonValueChangedEventHandler2 = buttonValueChangedEventHandler;
			ButtonValueChangedEventHandler buttonValueChangedEventHandler3 = (ButtonValueChangedEventHandler)Delegate.Remove(buttonValueChangedEventHandler2, P_0);
			buttonValueChangedEventHandler = Interlocked.CompareExchange(ref QCeXZRaTYMcWsqbnhhknLlFvEKwS, buttonValueChangedEventHandler3, buttonValueChangedEventHandler2);
		}
		while ((object)buttonValueChangedEventHandler != buttonValueChangedEventHandler2);
	}

	internal StandaloneAxis()
	{
	}

	public void SetRawValue(float value)
	{
		_valueRawPrev = _valueRaw;
		_valueRaw = value;
		if (value == _valueRawPrev)
		{
			return;
		}
		if (jKozyqbpDJZOACbzEsUzKaTpToWD != null && _valueRaw != _valueRawPrev)
		{
			jKozyqbpDJZOACbzEsUzKaTpToWD(_valueRaw);
		}
		if (cqRhNHryOOJtHITlEECHGouoXZPK != null)
		{
			float num = this.value;
			if (num != valuePrev)
			{
				cqRhNHryOOJtHITlEECHGouoXZPK(num);
			}
		}
		if (QCeXZRaTYMcWsqbnhhknLlFvEKwS != null)
		{
			bool flag = rawButtonValue;
			if (flag != rawButtonValuePrev)
			{
				QCeXZRaTYMcWsqbnhhknLlFvEKwS(flag);
			}
		}
		if (RtVzLXdAcRWwraAOqZdpycpCNGui != null && rawButtonValue && !rawButtonValuePrev)
		{
			RtVzLXdAcRWwraAOqZdpycpCNGui();
		}
		if (TmMNLcWBwDfJCcKchmuxVPsQGmbHb != null && !rawButtonValue && rawButtonValuePrev)
		{
			TmMNLcWBwDfJCcKchmuxVPsQGmbHb();
		}
		if (JQPBvIjjscKTETmTYWstRfAfXNTi != null)
		{
			bool flag2 = buttonValue;
			if (flag2 != buttonValuePrev)
			{
				JQPBvIjjscKTETmTYWstRfAfXNTi(flag2);
			}
		}
		if (AWpdIXwSbveWudjkqdSuzSaFRuSZ != null && buttonValue && !buttonValuePrev)
		{
			AWpdIXwSbveWudjkqdSuzSaFRuSZ();
		}
		if (mJdeLLUIhnCYAApVZqqyIijHwyulA != null && !buttonValue && buttonValuePrev)
		{
			mJdeLLUIhnCYAApVZqqyIijHwyulA();
		}
	}

	public void Clear()
	{
		SetRawValue(rawZero);
	}

	[CustomObfuscation(rename = false)]
	internal static StandaloneAxis CreateRelative()
	{
		return new StandaloneAxis
		{
			_calibration = AxisCalibration.CreateRelative()
		};
	}
}
