using System;

namespace Rewired;

public struct ControllerTemplateElementTarget
{
	private IControllerTemplateElement wyqAaQOTOPWLLeKNIGuyCnDDDpFbb;

	private AxisRange idEcEvEgSEtlwUELchjNQHXqhnLGA;

	public AxisRange axisRange
	{
		get
		{
			return idEcEvEgSEtlwUELchjNQHXqhnLGA;
		}
		set
		{
			idEcEvEgSEtlwUELchjNQHXqhnLGA = value;
		}
	}

	public ControllerTemplateElementType elementType
	{
		get
		{
			if (wyqAaQOTOPWLLeKNIGuyCnDDDpFbb == null)
			{
				return ControllerTemplateElementType.Axis;
			}
			return wyqAaQOTOPWLLeKNIGuyCnDDDpFbb.type;
		}
	}

	public string descriptiveName
	{
		get
		{
			if (wyqAaQOTOPWLLeKNIGuyCnDDDpFbb == null)
			{
				return string.Empty;
			}
			return wyqAaQOTOPWLLeKNIGuyCnDDDpFbb.type switch
			{
				ControllerTemplateElementType.Axis => ((IControllerTemplateAxis)wyqAaQOTOPWLLeKNIGuyCnDDDpFbb).GetDescriptiveName(idEcEvEgSEtlwUELchjNQHXqhnLGA), 
				ControllerTemplateElementType.Button => ((IControllerTemplateButton)wyqAaQOTOPWLLeKNIGuyCnDDDpFbb).descriptiveName, 
				_ => wyqAaQOTOPWLLeKNIGuyCnDDDpFbb.descriptiveName, 
			};
		}
	}

	public IControllerTemplateElement element
	{
		get
		{
			return wyqAaQOTOPWLLeKNIGuyCnDDDpFbb;
		}
		set
		{
			wyqAaQOTOPWLLeKNIGuyCnDDDpFbb = value;
		}
	}

	public IControllerTemplate template
	{
		get
		{
			if (wyqAaQOTOPWLLeKNIGuyCnDDDpFbb == null)
			{
				return null;
			}
			return (wyqAaQOTOPWLLeKNIGuyCnDDDpFbb as IControllerTemplateElement_Internal).parent;
		}
	}

	public bool hasTarget => wyqAaQOTOPWLLeKNIGuyCnDDDpFbb != null;

	internal ControllerTemplateElementTarget(IControllerTemplateElement P_0, AxisRange P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("element");
		}
		wyqAaQOTOPWLLeKNIGuyCnDDDpFbb = P_0;
		idEcEvEgSEtlwUELchjNQHXqhnLGA = P_1;
	}

	public ControllerTemplateElementTarget(ControllerTemplateElementTarget P_0)
	{
		wyqAaQOTOPWLLeKNIGuyCnDDDpFbb = P_0.wyqAaQOTOPWLLeKNIGuyCnDDDpFbb;
		idEcEvEgSEtlwUELchjNQHXqhnLGA = P_0.idEcEvEgSEtlwUELchjNQHXqhnLGA;
	}
}
