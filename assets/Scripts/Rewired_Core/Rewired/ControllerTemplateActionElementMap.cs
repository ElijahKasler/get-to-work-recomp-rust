using System;
using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired;

public abstract class ControllerTemplateActionElementMap
{
	private readonly int qPpeyLysgGGWKVifcMuGqUEdNVhV;

	private readonly ControllerTemplateElementType BhzAOTBSyMGdMxyzdqzCjmqHpQKbb;

	private bool WBOBGRTtDOGcQfWNqmxBDcfVfcCWA;

	private int SOzsfoYyhAwnBEDOOpvowpGMUxYE;

	private int cNaIrOwCIjizAfgwXZKflPDbbfhE;

	private static int EnQJsdWJgJhEKblPpGFQQhQkRJqoA;

	public int id => qPpeyLysgGGWKVifcMuGqUEdNVhV;

	public ControllerTemplateElementType elementType => BhzAOTBSyMGdMxyzdqzCjmqHpQKbb;

	public bool enabled
	{
		get
		{
			return WBOBGRTtDOGcQfWNqmxBDcfVfcCWA;
		}
		set
		{
			WBOBGRTtDOGcQfWNqmxBDcfVfcCWA = value;
		}
	}

	public int actionId
	{
		get
		{
			return SOzsfoYyhAwnBEDOOpvowpGMUxYE;
		}
		set
		{
			SOzsfoYyhAwnBEDOOpvowpGMUxYE = value;
		}
	}

	public int elementIdentifierId
	{
		get
		{
			return cNaIrOwCIjizAfgwXZKflPDbbfhE;
		}
		set
		{
			cNaIrOwCIjizAfgwXZKflPDbbfhE = value;
		}
	}

	internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0)
	{
		if (!InputTools.IsMappableType(P_0))
		{
			throw new ArgumentException(P_0.ToString() + " is not a supported mappable Controller Template element type.");
		}
		BhzAOTBSyMGdMxyzdqzCjmqHpQKbb = P_0;
		qPpeyLysgGGWKVifcMuGqUEdNVhV = EnQJsdWJgJhEKblPpGFQQhQkRJqoA++;
	}

	internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, ActionElementMap P_2)
		: this(P_0)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("actionElementMap");
		}
		SOzsfoYyhAwnBEDOOpvowpGMUxYE = P_2._actionId;
		cNaIrOwCIjizAfgwXZKflPDbbfhE = P_1;
		WBOBGRTtDOGcQfWNqmxBDcfVfcCWA = P_2.YbgQyWQdQcTTSlKYNScpqBbjmQQo;
	}

	internal ControllerTemplateActionElementMap(ControllerTemplateElementType P_0, int P_1, int P_2, bool P_3)
		: this(P_0)
	{
		SOzsfoYyhAwnBEDOOpvowpGMUxYE = P_2;
		cNaIrOwCIjizAfgwXZKflPDbbfhE = P_1;
		WBOBGRTtDOGcQfWNqmxBDcfVfcCWA = P_3;
	}

	protected ControllerTemplateActionElementMap(ActionElementMap P_0)
	{
	}

	internal int XRxoUsuvuhKWgnpLtrkhpHOMvjAf(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("controllerTemplate");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (!P_2)
		{
			P_1.Clear();
		}
		int num = rRHHtlMbCGQXNzBwVwmSqicOwuHx(P_0, P_1, P_2);
		if (num == 0)
		{
			return 0;
		}
		int num2 = P_1.Count - num;
		for (int i = 0; i < num; i++)
		{
			int index = num2 + i;
			P_1[index].YbgQyWQdQcTTSlKYNScpqBbjmQQo = WBOBGRTtDOGcQfWNqmxBDcfVfcCWA;
			P_1[index]._actionId = SOzsfoYyhAwnBEDOOpvowpGMUxYE;
		}
		return num;
	}

	internal SerializedObject YzuKnKCDuUAMiMTyTmehTdQMWTzM()
	{
		SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
		EJqhEWvzQKOYcFeOcaUpkIcHJLXe(serializedObject);
		return serializedObject;
	}

	internal virtual void EJqhEWvzQKOYcFeOcaUpkIcHJLXe(SerializedObject P_0)
	{
		P_0.Add("elementType", BhzAOTBSyMGdMxyzdqzCjmqHpQKbb);
		P_0.Add("enabled", WBOBGRTtDOGcQfWNqmxBDcfVfcCWA);
		P_0.Add("elementIdentifierId", cNaIrOwCIjizAfgwXZKflPDbbfhE);
		P_0.Add("actionId", SOzsfoYyhAwnBEDOOpvowpGMUxYE);
	}

	internal virtual void DkJFOdFkPEwWvPuDZHaMwYrElRnx(SerializedObject P_0)
	{
		UexJxXdnYAUtZtAMTbzosMxatBtw();
		P_0.TryGetDeserializedValueByRef("enabled", ref WBOBGRTtDOGcQfWNqmxBDcfVfcCWA);
		P_0.TryGetDeserializedValueByRef("elementIdentifierId", ref cNaIrOwCIjizAfgwXZKflPDbbfhE);
		P_0.TryGetDeserializedValueByRef("actionId", ref SOzsfoYyhAwnBEDOOpvowpGMUxYE);
	}

	internal virtual void UexJxXdnYAUtZtAMTbzosMxatBtw()
	{
		WBOBGRTtDOGcQfWNqmxBDcfVfcCWA = true;
		cNaIrOwCIjizAfgwXZKflPDbbfhE = -1;
		SOzsfoYyhAwnBEDOOpvowpGMUxYE = -1;
	}

	internal abstract int yFMiynFdbuAEiXHGxnEXfodLELpe(IControllerTemplateElementSource P_0, List<ActionElementMap> P_1, bool P_2);

	private int rRHHtlMbCGQXNzBwVwmSqicOwuHx(IControllerTemplate P_0, List<ActionElementMap> P_1, bool P_2)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (!P_2)
		{
			P_1.Clear();
		}
		IControllerTemplateElement element = P_0.GetElement(cNaIrOwCIjizAfgwXZKflPDbbfhE);
		if (element == null)
		{
			return 0;
		}
		IControllerTemplateElementSource source = element.source;
		if (source == null)
		{
			return 0;
		}
		return yFMiynFdbuAEiXHGxnEXfodLELpe(source, P_1, P_2);
	}

	internal static ControllerTemplateActionElementMap nbNdASjorFchTWCBuyNoiFVtFvSG(SerializedObject P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		if (!P_0.TryGetDeserializedValue<ControllerTemplateElementType>("elementType", out var value))
		{
			return null;
		}
		return value switch
		{
			ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0), 
			ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0), 
			_ => throw new NotImplementedException(), 
		};
	}

	internal static ControllerTemplateActionElementMap jfcWEiqUjrSdULdKAmqQqxICKEac(ControllerTemplateElementTarget P_0, ActionElementMap P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("actionElementMap");
		}
		if (P_0.elementType == ControllerTemplateElementType.Axis)
		{
			return new ControllerTemplateActionAxisMap(P_0.element.id, P_0.axisRange, P_1);
		}
		if (P_0.elementType == ControllerTemplateElementType.Button)
		{
			return new ControllerTemplateActionButtonMap(P_0.element.id, P_1);
		}
		throw new NotImplementedException();
	}

	internal static ControllerTemplateActionElementMap NZHeNRmOmaiajDRLulWGVUTCMfiu(ActionElementMap P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("actionElementMap");
		}
		ControllerTemplateElementType controllerTemplateElementType = IyPmashUlRgIygDiHFyDZHZmauql.eGqDSPZMtIsYDZSRiGZwmuiVsjTk(P_0._elementType, false);
		if (!InputTools.IsMappableType(controllerTemplateElementType))
		{
			return null;
		}
		return controllerTemplateElementType switch
		{
			ControllerTemplateElementType.Axis => new ControllerTemplateActionAxisMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisRange, P_0._axisContribution, P_0._invert, P_0.YbgQyWQdQcTTSlKYNScpqBbjmQQo), 
			ControllerTemplateElementType.Button => new ControllerTemplateActionButtonMap(P_0._elementIdentifierId, P_0._actionId, P_0._axisContribution, P_0.YbgQyWQdQcTTSlKYNScpqBbjmQQo), 
			_ => throw new NotImplementedException(), 
		};
	}
}
