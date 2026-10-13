using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired;

public sealed class ControllerTemplateActionAxisMap : ControllerTemplateActionElementMap
{
	private AxisRange LpyCIoubnxjbaZKAHIsCiiYNlPEPA;

	private Pole wMfCTideusWfSesMwEMxSgLICARI;

	private bool RrcvhqBShnCENSeFsCeiaLPMlhZeb;

	public AxisRange axisRange => LpyCIoubnxjbaZKAHIsCiiYNlPEPA;

	public Pole axisContribution => wMfCTideusWfSesMwEMxSgLICARI;

	public bool invert => RrcvhqBShnCENSeFsCeiaLPMlhZeb;

	internal ControllerTemplateActionAxisMap(SerializedObject P_0)
		: base(ControllerTemplateElementType.Axis)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("serializedObject");
		}
		DkJFOdFkPEwWvPuDZHaMwYrElRnx(P_0);
	}

	internal ControllerTemplateActionAxisMap(int P_0, AxisRange P_1, ActionElementMap P_2)
		: base(ControllerTemplateElementType.Axis, P_0, P_2)
	{
		LpyCIoubnxjbaZKAHIsCiiYNlPEPA = P_1;
		wMfCTideusWfSesMwEMxSgLICARI = P_2.axisContribution;
		RrcvhqBShnCENSeFsCeiaLPMlhZeb = P_2._invert;
	}

	internal ControllerTemplateActionAxisMap(int P_0, int P_1, AxisRange P_2, Pole P_3, bool P_4, bool P_5)
		: base(ControllerTemplateElementType.Axis, P_0, P_1, P_5)
	{
		LpyCIoubnxjbaZKAHIsCiiYNlPEPA = P_2;
		wMfCTideusWfSesMwEMxSgLICARI = P_3;
		RrcvhqBShnCENSeFsCeiaLPMlhZeb = P_4;
	}

	internal void ZkaFZnEOmDdwSubRBWEnyQXwprXc(SerializedObject P_0)
	{
		base.EJqhEWvzQKOYcFeOcaUpkIcHJLXe(P_0);
		P_0.Add("axisContribution", wMfCTideusWfSesMwEMxSgLICARI);
		P_0.Add("axisRange", LpyCIoubnxjbaZKAHIsCiiYNlPEPA);
		P_0.Add("invert", RrcvhqBShnCENSeFsCeiaLPMlhZeb);
	}

	internal void NaaCiVFcXQosbLbiotMQPbDYAEbjb(SerializedObject P_0)
	{
		base.DkJFOdFkPEwWvPuDZHaMwYrElRnx(P_0);
		P_0.TryGetDeserializedValueByRef("axisContribution", ref wMfCTideusWfSesMwEMxSgLICARI);
		P_0.TryGetDeserializedValueByRef("axisRange", ref LpyCIoubnxjbaZKAHIsCiiYNlPEPA);
		P_0.TryGetDeserializedValueByRef("invert", ref RrcvhqBShnCENSeFsCeiaLPMlhZeb);
	}

	internal void BaxCmkdvPasMZRtzDUYDAUBZjMldb()
	{
		LpyCIoubnxjbaZKAHIsCiiYNlPEPA = AxisRange.Full;
		wMfCTideusWfSesMwEMxSgLICARI = Pole.Positive;
		RrcvhqBShnCENSeFsCeiaLPMlhZeb = false;
	}

	internal int jxZBDtgoyRlilfZaaJUlaBcXjWqnc(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2)
	{
		if (!(P_0 is IControllerTemplateAxisSource controllerTemplateAxisSource))
		{
			return 0;
		}
		int num = 0;
		if (LpyCIoubnxjbaZKAHIsCiiYNlPEPA == AxisRange.Full)
		{
			if (controllerTemplateAxisSource.splitAxis)
			{
				ActionElementMap actionElementMap = ysAKYMcHRQesFRtUZdIOacYHlxos(controllerTemplateAxisSource.positiveTarget, (!RrcvhqBShnCENSeFsCeiaLPMlhZeb) ? AxisRange.Positive : AxisRange.Negative, wMfCTideusWfSesMwEMxSgLICARI);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
				actionElementMap = ysAKYMcHRQesFRtUZdIOacYHlxos(controllerTemplateAxisSource.negativeTarget, RrcvhqBShnCENSeFsCeiaLPMlhZeb ? AxisRange.Positive : AxisRange.Negative, wMfCTideusWfSesMwEMxSgLICARI);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
			else
			{
				ActionElementMap actionElementMap = ysAKYMcHRQesFRtUZdIOacYHlxos(controllerTemplateAxisSource.fullTarget, AxisRange.Full, wMfCTideusWfSesMwEMxSgLICARI);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
		}
		else if (controllerTemplateAxisSource.splitAxis)
		{
			if (LpyCIoubnxjbaZKAHIsCiiYNlPEPA == AxisRange.Positive)
			{
				ActionElementMap actionElementMap = dtNVfbWYIUQwdigsIRDZemdjSKpr(controllerTemplateAxisSource.positiveTarget, Pole.Positive, wMfCTideusWfSesMwEMxSgLICARI);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
			else
			{
				ActionElementMap actionElementMap = dtNVfbWYIUQwdigsIRDZemdjSKpr(controllerTemplateAxisSource.negativeTarget, Pole.Negative, wMfCTideusWfSesMwEMxSgLICARI);
				if (actionElementMap != null)
				{
					P_1.Add(actionElementMap);
					num++;
				}
			}
		}
		else
		{
			ActionElementMap actionElementMap = dtNVfbWYIUQwdigsIRDZemdjSKpr(controllerTemplateAxisSource.fullTarget, (LpyCIoubnxjbaZKAHIsCiiYNlPEPA == AxisRange.Negative) ? Pole.Negative : Pole.Positive, wMfCTideusWfSesMwEMxSgLICARI);
			if (actionElementMap != null)
			{
				P_1.Add(actionElementMap);
				num++;
			}
		}
		return num;
	}

	private ActionElementMap ysAKYMcHRQesFRtUZdIOacYHlxos(IControllerElementTarget P_0, AxisRange P_1, Pole P_2)
	{
		if (P_0 == null || P_0.element == null)
		{
			return null;
		}
		ControllerElementType controllerElementType = P_0.elementType;
		AxisRange axisRange = P_0.axisRange;
		ActionElementMap actionElementMap = new ActionElementMap();
		actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
		actionElementMap._elementType = controllerElementType;
		actionElementMap._axisRange = axisRange;
		if (axisRange == AxisRange.Full)
		{
			switch (controllerElementType)
			{
			case ControllerElementType.Axis:
				actionElementMap._invert = RrcvhqBShnCENSeFsCeiaLPMlhZeb;
				break;
			case ControllerElementType.Button:
				actionElementMap._axisContribution = P_2;
				break;
			}
		}
		else if (controllerElementType == ControllerElementType.Axis || controllerElementType == ControllerElementType.Button)
		{
			Pole pole = ((P_1 == AxisRange.Negative) ? Pole.Negative : Pole.Positive);
			actionElementMap._axisContribution = pole;
		}
		return actionElementMap;
	}

	private ActionElementMap dtNVfbWYIUQwdigsIRDZemdjSKpr(IControllerElementTarget P_0, Pole P_1, Pole P_2)
	{
		if (P_0 == null || P_0.element == null)
		{
			return null;
		}
		ControllerElementType controllerElementType = P_0.elementType;
		AxisRange axisRange = P_0.axisRange;
		ActionElementMap actionElementMap = new ActionElementMap();
		actionElementMap._elementIdentifierId = P_0.elementIdentifierId;
		actionElementMap._elementType = controllerElementType;
		actionElementMap._axisRange = axisRange;
		if (controllerElementType == ControllerElementType.Axis && axisRange == AxisRange.Full)
		{
			actionElementMap._axisRange = ((P_1 == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative);
			actionElementMap._axisContribution = P_2;
		}
		else if (controllerElementType == ControllerElementType.Axis || controllerElementType == ControllerElementType.Button)
		{
			actionElementMap._axisContribution = P_2;
		}
		return actionElementMap;
	}
}
