using System;

namespace Rewired;

public struct ControllerElementTarget
{
	private Controller.Element nknTstvWJBSzdNXBdzoUzbbNPFRB;

	private AxisRange jwahlnEpQBzwkztSgtdFscaFhOFiA;

	public int elementIdentifierId
	{
		get
		{
			if (nknTstvWJBSzdNXBdzoUzbbNPFRB == null)
			{
				return -1;
			}
			return nknTstvWJBSzdNXBdzoUzbbNPFRB.id;
		}
	}

	public AxisRange axisRange
	{
		get
		{
			return jwahlnEpQBzwkztSgtdFscaFhOFiA;
		}
		set
		{
			jwahlnEpQBzwkztSgtdFscaFhOFiA = value;
		}
	}

	public bool hasTarget => nknTstvWJBSzdNXBdzoUzbbNPFRB != null;

	public ControllerElementType elementType
	{
		get
		{
			if (nknTstvWJBSzdNXBdzoUzbbNPFRB == null)
			{
				return ControllerElementType.Axis;
			}
			return nknTstvWJBSzdNXBdzoUzbbNPFRB.type;
		}
	}

	public string descriptiveName
	{
		get
		{
			if (nknTstvWJBSzdNXBdzoUzbbNPFRB == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifier = nknTstvWJBSzdNXBdzoUzbbNPFRB.elementIdentifier;
			if (elementIdentifier == null)
			{
				return string.Empty;
			}
			return elementIdentifier.GetDisplayName(nknTstvWJBSzdNXBdzoUzbbNPFRB.type, jwahlnEpQBzwkztSgtdFscaFhOFiA);
		}
	}

	public Controller controller
	{
		get
		{
			if (nknTstvWJBSzdNXBdzoUzbbNPFRB == null)
			{
				return null;
			}
			return nknTstvWJBSzdNXBdzoUzbbNPFRB.bezPiJCxxPkpUZEbBjMGmhxFjvjD;
		}
	}

	public Controller.Element element
	{
		get
		{
			return nknTstvWJBSzdNXBdzoUzbbNPFRB;
		}
		set
		{
			nknTstvWJBSzdNXBdzoUzbbNPFRB = value;
		}
	}

	public ControllerElementTarget(ActionElementMap P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("actionElementMap");
		}
		if (P_0.jFlCvaOSkDuykzqnwdtFNKIeuDmW != null)
		{
			Controller controller = ReInput.jCkgZLcnXoMycBxzcMXWvnUfSROEb.qLXmBGgOrsBKkXyijYLMvlwfrnKd(P_0.jFlCvaOSkDuykzqnwdtFNKIeuDmW.controllerType, P_0.jFlCvaOSkDuykzqnwdtFNKIeuDmW.controllerId);
			nknTstvWJBSzdNXBdzoUzbbNPFRB = controller.GetElementById(P_0._elementIdentifierId);
		}
		else
		{
			nknTstvWJBSzdNXBdzoUzbbNPFRB = null;
		}
		jwahlnEpQBzwkztSgtdFscaFhOFiA = P_0._axisRange;
	}

	public ControllerElementTarget(ControllerElementTarget P_0)
	{
		nknTstvWJBSzdNXBdzoUzbbNPFRB = P_0.nknTstvWJBSzdNXBdzoUzbbNPFRB;
		jwahlnEpQBzwkztSgtdFscaFhOFiA = P_0.jwahlnEpQBzwkztSgtdFscaFhOFiA;
	}

	public ControllerElementTarget(IControllerElementTarget P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("other");
		}
		nknTstvWJBSzdNXBdzoUzbbNPFRB = P_0.element;
		jwahlnEpQBzwkztSgtdFscaFhOFiA = P_0.axisRange;
	}

	public static implicit operator ControllerElementTarget(ActionElementMap actionElementMap)
	{
		if (actionElementMap == null)
		{
			return default;
		}
		return new ControllerElementTarget(actionElementMap);
	}
}
