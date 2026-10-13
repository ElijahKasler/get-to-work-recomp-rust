using System;
using Rewired.ComponentControls.Data;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls;

[Serializable]
[DisallowMultipleComponent]
public abstract class CustomControllerControl : ComponentControl
{
	internal CustomController samEKVVJyrlntOMOcWFRwrrKRkZc => VsclIioRziGKoShuiaSyIrqcUiRG();

	bool cGatEfztsIqCLsTucDMygLcPoUUK => cGatEfztsIqCLsTucDMygLcPoUUK();

	internal CustomController VsclIioRziGKoShuiaSyIrqcUiRG()
	{
		return BuIhXAQcFtYVfhAxQBezxvNwKXPV() as CustomController;
	}

	[CustomObfuscation(rename = false)]
	internal CustomControllerControl()
	{
	}

	internal override bool cGatEfztsIqCLsTucDMygLcPoUUK()
	{
		return BuIhXAQcFtYVfhAxQBezxvNwKXPV() as CustomController != null;
	}

	internal virtual void mWLBLrveMMaolVHnoPlWNjIGkOPG()
	{
		base.siYUHuwQhlovaiEnuWgbzvoXFJXv();
		if (cGatEfztsIqCLsTucDMygLcPoUUK())
		{
			UidTQXBpNskLbacEAcaiGQCoRZaEA();
			VsclIioRziGKoShuiaSyIrqcUiRG().InputSourceUpdateEvent += SkiGLMJUhPpTmdyfRuNxgakEhlgGB;
		}
	}

	internal virtual void DQtDAHQvpQLNGcSsvmpJRSyVEqRO()
	{
		base.UidTQXBpNskLbacEAcaiGQCoRZaEA();
		if (cGatEfztsIqCLsTucDMygLcPoUUK())
		{
			VsclIioRziGKoShuiaSyIrqcUiRG().InputSourceUpdateEvent -= SkiGLMJUhPpTmdyfRuNxgakEhlgGB;
		}
	}

	[CustomObfuscation(rename = false)]
	internal override IComponentController FindController()
	{
		return UnityTools.GetComponentInSelfOrParents<CustomController>(base.transform);
	}

	[CustomObfuscation(rename = false)]
	internal override Type GetRequiredControllerType()
	{
		return typeof(CustomController);
	}

	internal void eNqvXoPsNNtXujHQmteeYomcshNn(CustomControllerElementTargetSet P_0, float P_1, float P_2)
	{
		if (!cGatEfztsIqCLsTucDMygLcPoUUK() || P_0 == null)
		{
			return;
		}
		if (P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat)
		{
			if (!customControllerElementTargetSetForFloat.splitValue)
			{
				hXUloBDggYaUJeBsQcuNgWfqqWEfb(customControllerElementTargetSetForFloat.target, P_1, P_2);
				return;
			}
			hXUloBDggYaUJeBsQcuNgWfqqWEfb(customControllerElementTargetSetForFloat.positiveTarget, P_1, P_2);
			hXUloBDggYaUJeBsQcuNgWfqqWEfb(customControllerElementTargetSetForFloat.negativeTarget, P_1, P_2);
		}
		else if (P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean)
		{
			hXUloBDggYaUJeBsQcuNgWfqqWEfb(customControllerElementTargetSetForBoolean.target, P_1, P_2);
		}
	}

	internal void GqWrONBkPaVJOfDRxVZVJmAHexyb(CustomControllerElementTargetSet P_0, bool P_1)
	{
		if (!cGatEfztsIqCLsTucDMygLcPoUUK() || P_0 == null)
		{
			return;
		}
		if (P_0 is CustomControllerElementTargetSetForBoolean customControllerElementTargetSetForBoolean)
		{
			tiYcgyBkRVqRCDTsrhDYFIpctaFub(customControllerElementTargetSetForBoolean.target, P_1);
		}
		else if (P_0 is CustomControllerElementTargetSetForFloat customControllerElementTargetSetForFloat)
		{
			if (!customControllerElementTargetSetForFloat.splitValue)
			{
				tiYcgyBkRVqRCDTsrhDYFIpctaFub(customControllerElementTargetSetForFloat.target, P_1);
				return;
			}
			tiYcgyBkRVqRCDTsrhDYFIpctaFub(customControllerElementTargetSetForFloat.positiveTarget, P_1);
			tiYcgyBkRVqRCDTsrhDYFIpctaFub(customControllerElementTargetSetForFloat.negativeTarget, P_1);
		}
	}

	internal abstract void dBdBHQJnAOwfNjqUszVynuigkiPj();

	private void hXUloBDggYaUJeBsQcuNgWfqqWEfb(CustomControllerElementTarget P_0, float P_1, float P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		switch (P_0.element.elementType)
		{
		case CustomControllerElementSelector.ElementType.Axis:
			switch (P_0.valueRange)
			{
			case CustomControllerElementTarget.ValueRange.Full:
				if (P_0.invert)
				{
					P_1 *= -1f;
				}
				break;
			case CustomControllerElementTarget.ValueRange.Positive:
				if (P_1 < 0f)
				{
					P_1 = 0f;
				}
				if (P_0.valueContribution == Pole.Negative)
				{
					P_1 *= -1f;
				}
				break;
			case CustomControllerElementTarget.ValueRange.Negative:
				if (P_1 > 0f)
				{
					P_1 = 0f;
				}
				if (P_0.valueContribution == Pole.Positive)
				{
					P_1 *= -1f;
				}
				break;
			}
			VsclIioRziGKoShuiaSyIrqcUiRG().SetAxisValue(P_0.element, P_1);
			break;
		case CustomControllerElementSelector.ElementType.Button:
			switch (P_0.valueRange)
			{
			case CustomControllerElementTarget.ValueRange.Positive:
				if (P_1 < 0f)
				{
					P_1 = 0f;
				}
				break;
			case CustomControllerElementTarget.ValueRange.Negative:
				if (P_1 > 0f)
				{
					P_1 = 0f;
				}
				break;
			}
			VsclIioRziGKoShuiaSyIrqcUiRG().SetButtonValue(P_0.element, MathTools.Abs(P_1) >= MathTools.Abs(P_2));
			break;
		default:
			throw new NotImplementedException();
		}
	}

	private void tiYcgyBkRVqRCDTsrhDYFIpctaFub(CustomControllerElementTarget P_0, bool P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		switch (P_0.element.elementType)
		{
		case CustomControllerElementSelector.ElementType.Axis:
		{
			float num = (P_1 ? 1f : 0f);
			if (P_0.valueRange == CustomControllerElementTarget.ValueRange.Full)
			{
				if (P_0.invert)
				{
					num *= -1f;
				}
			}
			else if (P_0.valueContribution == Pole.Negative)
			{
				num *= -1f;
			}
			VsclIioRziGKoShuiaSyIrqcUiRG().SetAxisValue(P_0.element, num);
			break;
		}
		case CustomControllerElementSelector.ElementType.Button:
			VsclIioRziGKoShuiaSyIrqcUiRG().SetButtonValue(P_0.element, P_1);
			break;
		default:
			throw new NotImplementedException();
		}
	}

	private void SkiGLMJUhPpTmdyfRuNxgakEhlgGB()
	{
		if (!NkQXqFgfLsxNEarUJhyeOugCUaYs() && oaeJwcBeZoMZRNVcTgpbqRThFymT())
		{
			dBdBHQJnAOwfNjqUszVynuigkiPj();
		}
	}
}
