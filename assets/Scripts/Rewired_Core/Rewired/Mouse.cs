using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired;

public sealed class Mouse : ControllerWithAxes
{
	private TimerAbs bOZwKZcEmTTcIEMpQfcaVIinpsKE;

	private float[] KLJCrwpWUfZbOOyzFnlPVkCRmFVe;

	private Vector2 WaohPAweSVohjsXEiRkOUjWTlcHy;

	private Vector2 GuQstZFWChmmOeiZxtXaqTKNFQKq;

	private int qcFtfjgmGgSEtmNEIcPYkcwNOYFmA;

	private readonly IUnifiedMouseSource fBhgNOQxhAnETnyxCifvbLpeQMeP;

	private static Guid QwKIhXMtpScsKslIMOnCZijokpb;

	public Vector2 screenPosition
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return Vector2.zero;
			}
			return WaohPAweSVohjsXEiRkOUjWTlcHy;
		}
	}

	public Vector2 screenPositionPrev
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return Vector2.zero;
			}
			return GuQstZFWChmmOeiZxtXaqTKNFQKq;
		}
	}

	public Vector2 screenPositionDelta
	{
		get
		{
			if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
				return Vector2.zero;
			}
			return WaohPAweSVohjsXEiRkOUjWTlcHy - GuQstZFWChmmOeiZxtXaqTKNFQKq;
		}
	}

	Guid Controller.deviceInstanceGuid => get_deviceInstanceGuid();

	public Guid get_deviceInstanceGuid()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return Guid.Empty;
		}
		return QwKIhXMtpScsKslIMOnCZijokpb;
	}

	internal Mouse(string P_0, IUnifiedMouseSource P_1)
		: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.axisCount, P_1.buttonCount, P_1.hardwareMap, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, P_1.axisCount, P_1.buttonCount, null))
	{
		fBhgNOQxhAnETnyxCifvbLpeQMeP = P_1;
		QwKIhXMtpScsKslIMOnCZijokpb = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
		EMBHjcsxjUDMCsHethyxgQTJtbEg();
	}

	private Mouse(int P_0, InputSource P_1, string P_2, string P_3, int P_4, int P_5, HardwareControllerMap_Game P_6, Extension P_7, ControllerDataUpdater P_8)
		: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, P_4, P_5, null, P_6, P_7, P_8)
	{
	}

	internal void UetrMhxLkscQhbPdOhPxMhNcqeXfA(UpdateLoopType P_0)
	{
		fBhgNOQxhAnETnyxCifvbLpeQMeP.UpdateInputData(KRqNAliDQUoGilZWSpebheoTCzwBA);
		biQoETeEqDdqkhVmbcHhOaDmWZxfA(P_0);
		LdOCTrDBHmbEuZsvoNUseVKzFGhBb();
	}

	protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
	{
		pole = Pole.Positive;
		elementIdentifierId = -1;
		if (KLJCrwpWUfZbOOyzFnlPVkCRmFVe == null)
		{
			KLJCrwpWUfZbOOyzFnlPVkCRmFVe = new float[_axisCount];
		}
		if (bOZwKZcEmTTcIEMpQfcaVIinpsKE == null)
		{
			bOZwKZcEmTTcIEMpQfcaVIinpsKE = new TimerAbs(1.0);
		}
		if (bOZwKZcEmTTcIEMpQfcaVIinpsKE.Update() || !bOZwKZcEmTTcIEMpQfcaVIinpsKE.running)
		{
			bOZwKZcEmTTcIEMpQfcaVIinpsKE.Start();
			Array.Clear(KLJCrwpWUfZbOOyzFnlPVkCRmFVe, 0, KLJCrwpWUfZbOOyzFnlPVkCRmFVe.Length);
		}
		if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
		{
			KLJCrwpWUfZbOOyzFnlPVkCRmFVe[index] += axes[index].valueRaw * 0.5f;
		}
		else
		{
			KLJCrwpWUfZbOOyzFnlPVkCRmFVe[index] += axes[index].valueRaw;
		}
		float num = KLJCrwpWUfZbOOyzFnlPVkCRmFVe[index];
		if (MathTools.Abs(num) <= axes[index].AvbeukGhMeWVdlYXEDPZddcdeFSsA())
		{
			return false;
		}
		pole = ((!(num >= 0f)) ? Pole.Negative : Pole.Positive);
		elementIdentifierId = aHJMAWzbypGgwCcRCqDEaoqVGwfA.axisElementIdentifierIds[index];
		if (elementIdentifierId < 0)
		{
			return false;
		}
		bOZwKZcEmTTcIEMpQfcaVIinpsKE.running = false;
		return true;
	}

	internal void dfRKPtBRdkzUXpuoCLEmJFtFFTTv()
	{
		HZEaHvyGlMIsZbNXPCzRBwmikPyR();
		if (bOZwKZcEmTTcIEMpQfcaVIinpsKE != null)
		{
			bOZwKZcEmTTcIEMpQfcaVIinpsKE.Clear();
		}
		WaohPAweSVohjsXEiRkOUjWTlcHy = Vector2.zero;
		GuQstZFWChmmOeiZxtXaqTKNFQKq = Vector2.zero;
	}

	internal bool VDmtdIlECXUzdZXMfSjnINvLbOlC(bool P_0)
	{
		if (!base.inMOXJxCMugPOHqUhiIifiebgFebc(P_0))
		{
			return false;
		}
		if (fBhgNOQxhAnETnyxCifvbLpeQMeP is IGetSetEnabled)
		{
			(fBhgNOQxhAnETnyxCifvbLpeQMeP as IGetSetEnabled).enabled = P_0;
		}
		if (P_0)
		{
			LdOCTrDBHmbEuZsvoNUseVKzFGhBb();
			GuQstZFWChmmOeiZxtXaqTKNFQKq = screenPosition;
		}
		return true;
	}

	private void LdOCTrDBHmbEuZsvoNUseVKzFGhBb()
	{
		int currentUnityFrame = ReInput.currentUnityFrame;
		if (currentUnityFrame != qcFtfjgmGgSEtmNEIcPYkcwNOYFmA)
		{
			GuQstZFWChmmOeiZxtXaqTKNFQKq = WaohPAweSVohjsXEiRkOUjWTlcHy;
			WaohPAweSVohjsXEiRkOUjWTlcHy = fBhgNOQxhAnETnyxCifvbLpeQMeP.mousePosition;
			qcFtfjgmGgSEtmNEIcPYkcwNOYFmA = currentUnityFrame;
		}
	}
}
