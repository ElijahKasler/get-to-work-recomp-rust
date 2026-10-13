using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired;

public class ControllerTemplateMap
{
	private readonly int eKrmsiGuZCuNeAmEtigOYcQTaElDA;

	private readonly int SmAKOyhOjFOvSKOxlfFCvXajTkNL;

	private readonly Guid AZiGZXVtvvgHuvZhRuLvGGpKjruc;

	private readonly List<ControllerTemplateActionElementMap> FIhQvLClIzNBYvgObtRpKoEGdDlB;

	private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> CimVkwVHVZxdhglUhoShdNdDtEor;

	private bool mQmkTaInDEdRBjvNOFArMJWUcquj;

	private int qnWZRpvBkdXBAGGEaWgHabPErqNb;

	private int hNdZLFuqZRzZpxFVVEVCTJWoePmU;

	private int ipBetyZODYfzViGaFnRptlTmCyeJA = -1;

	private static int OIArImktPgxDDwYFfhmIUrrqgcdl;

	public int id
	{
		get
		{
			if (ReInput._id != eKrmsiGuZCuNeAmEtigOYcQTaElDA)
			{
				ReInput.CheckInitialized(eKrmsiGuZCuNeAmEtigOYcQTaElDA);
				return -1;
			}
			return SmAKOyhOjFOvSKOxlfFCvXajTkNL;
		}
	}

	public Guid templateTypeGuid
	{
		get
		{
			if (ReInput._id != eKrmsiGuZCuNeAmEtigOYcQTaElDA)
			{
				ReInput.CheckInitialized(eKrmsiGuZCuNeAmEtigOYcQTaElDA);
				return Guid.Empty;
			}
			return AZiGZXVtvvgHuvZhRuLvGGpKjruc;
		}
	}

	public bool enabled
	{
		get
		{
			if (ReInput._id != eKrmsiGuZCuNeAmEtigOYcQTaElDA)
			{
				ReInput.CheckInitialized(eKrmsiGuZCuNeAmEtigOYcQTaElDA);
				return false;
			}
			return mQmkTaInDEdRBjvNOFArMJWUcquj;
		}
		set
		{
			mQmkTaInDEdRBjvNOFArMJWUcquj = value;
		}
	}

	public int categoryId
	{
		get
		{
			if (ReInput._id != eKrmsiGuZCuNeAmEtigOYcQTaElDA)
			{
				ReInput.CheckInitialized(eKrmsiGuZCuNeAmEtigOYcQTaElDA);
				return -1;
			}
			return qnWZRpvBkdXBAGGEaWgHabPErqNb;
		}
		internal set
		{
			FviaWUNImDVVQKcDDOsRHFIuHyLh(num);
		}
	}

	public int layoutId
	{
		get
		{
			if (ReInput._id != eKrmsiGuZCuNeAmEtigOYcQTaElDA)
			{
				ReInput.CheckInitialized(eKrmsiGuZCuNeAmEtigOYcQTaElDA);
				return -1;
			}
			return hNdZLFuqZRzZpxFVVEVCTJWoePmU;
		}
		internal set
		{
			VjJnqfNuggsVbvslVhxTXFGRRiWq(num);
		}
	}

	public IList<ControllerTemplateActionElementMap> ElementMaps
	{
		get
		{
			if (ReInput._id != eKrmsiGuZCuNeAmEtigOYcQTaElDA)
			{
				ReInput.CheckInitialized(eKrmsiGuZCuNeAmEtigOYcQTaElDA);
				return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
			}
			return CimVkwVHVZxdhglUhoShdNdDtEor;
		}
	}

	internal ControllerTemplateMap(Guid P_0)
	{
		SmAKOyhOjFOvSKOxlfFCvXajTkNL = OIArImktPgxDDwYFfhmIUrrqgcdl++;
		eKrmsiGuZCuNeAmEtigOYcQTaElDA = ReInput._id;
		AZiGZXVtvvgHuvZhRuLvGGpKjruc = P_0;
		FIhQvLClIzNBYvgObtRpKoEGdDlB = new List<ControllerTemplateActionElementMap>();
		CimVkwVHVZxdhglUhoShdNdDtEor = new ReadOnlyCollection<ControllerTemplateActionElementMap>(FIhQvLClIzNBYvgObtRpKoEGdDlB);
		mQmkTaInDEdRBjvNOFArMJWUcquj = true;
	}

	internal ControllerTemplateMap(Guid P_0, int P_1, int P_2, int P_3)
		: this(P_0)
	{
		qnWZRpvBkdXBAGGEaWgHabPErqNb = P_1;
		hNdZLFuqZRzZpxFVVEVCTJWoePmU = P_2;
		ipBetyZODYfzViGaFnRptlTmCyeJA = P_3;
	}

	internal void FviaWUNImDVVQKcDDOsRHFIuHyLh(int P_0)
	{
		qnWZRpvBkdXBAGGEaWgHabPErqNb = P_0;
	}

	internal void VjJnqfNuggsVbvslVhxTXFGRRiWq(int P_0)
	{
		hNdZLFuqZRzZpxFVVEVCTJWoePmU = P_0;
	}

	public string ToXmlString()
	{
		if (ReInput._id != eKrmsiGuZCuNeAmEtigOYcQTaElDA)
		{
			ReInput.CheckInitialized(eKrmsiGuZCuNeAmEtigOYcQTaElDA);
			return string.Empty;
		}
		try
		{
			return LVxxdEQLKHIMGNzvGmMGirbbKnyU().ToXmlString(writeDocumentTag: true);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
			return string.Empty;
		}
	}

	public string ToJsonString()
	{
		if (ReInput._id != eKrmsiGuZCuNeAmEtigOYcQTaElDA)
		{
			ReInput.CheckInitialized(eKrmsiGuZCuNeAmEtigOYcQTaElDA);
			return string.Empty;
		}
		try
		{
			return LVxxdEQLKHIMGNzvGmMGirbbKnyU().ToJsonString();
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
			return string.Empty;
		}
	}

	public ControllerMap ToControllerMap(Controller controller)
	{
		if (ReInput._id != eKrmsiGuZCuNeAmEtigOYcQTaElDA)
		{
			ReInput.CheckInitialized(eKrmsiGuZCuNeAmEtigOYcQTaElDA);
			return null;
		}
		if (controller == null)
		{
			throw new ArgumentNullException("controller");
		}
		IControllerTemplate template = controller.GetTemplate(AZiGZXVtvvgHuvZhRuLvGGpKjruc);
		if (template == null)
		{
			Logger.LogError("The Controller does not implement the expected Controller Template.");
			return null;
		}
		ControllerMap controllerMap = ControllerMap.DzOeBfwddcwwENIIeCxWFIebOvPE(controller.type);
		controllerMap.hdVcseJAMUIVzNShcxnTQtiYhLhaA(qnWZRpvBkdXBAGGEaWgHabPErqNb);
		controllerMap.SJAGFjjphrIzvKECmGTWpnbeduqo(hNdZLFuqZRzZpxFVVEVCTJWoePmU);
		if (ipBetyZODYfzViGaFnRptlTmCyeJA >= 0)
		{
			controllerMap.MbMmassluZIHjVGbBjKxGpevPuGz(ipBetyZODYfzViGaFnRptlTmCyeJA);
		}
		controllerMap.SOeQiFehSinWlJovdrhlQBwRceWF(controller.id);
		controllerMap.enabled = mQmkTaInDEdRBjvNOFArMJWUcquj;
		controllerMap.lVdqrgFjWeEhzHZkzHqpOWGoTKWrA(controller.TlKwqXsIXURetJtusBGjLpbJxFcf);
		using TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>();
		List<ActionElementMap> list = tList.list;
		for (int i = 0; i < FIhQvLClIzNBYvgObtRpKoEGdDlB.Count; i++)
		{
			FIhQvLClIzNBYvgObtRpKoEGdDlB[i].XRxoUsuvuhKWgnpLtrkhpHOMvjAf(template, list, false);
			for (int j = 0; j < list.Count; j++)
			{
				controllerMap.gJwAODjSUWHoAFipcrtCuEWnsrOyb(list[j]);
			}
		}
		return controllerMap;
	}

	internal virtual void dtyARuGcxFrHYOsbNvzBOEpjlAIaA(SerializedObject P_0)
	{
		if (P_0.xmlInfo == null)
		{
			P_0.xmlInfo = new SerializedObject.XmlInfo();
		}
		P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
		P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "dataVersion",
			TGWZwlpMZfNRNCdsoptLnolSpctw = 1.ToString()
		});
		P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "templateTypeGuid",
			TGWZwlpMZfNRNCdsoptLnolSpctw = AZiGZXVtvvgHuvZhRuLvGGpKjruc.ToString()
		});
		P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			lzZvWcSBFLIaPeQCcDYWrLhMPUfsA = "xmlns",
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "xsi",
			afJFISBmEARIUnwOMVvxEtRhSwGz = null,
			TGWZwlpMZfNRNCdsoptLnolSpctw = "http://www.w3.org/2001/XMLSchema-instance"
		});
		P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			lzZvWcSBFLIaPeQCcDYWrLhMPUfsA = "xsi",
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "schemaLocation",
			afJFISBmEARIUnwOMVvxEtRhSwGz = null,
			TGWZwlpMZfNRNCdsoptLnolSpctw = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
		});
		P_0.Add("templateTypeGuid", AZiGZXVtvvgHuvZhRuLvGGpKjruc);
		P_0.Add("enabled", mQmkTaInDEdRBjvNOFArMJWUcquj);
		P_0.Add("categoryId", qnWZRpvBkdXBAGGEaWgHabPErqNb);
		P_0.Add("layoutId", hNdZLFuqZRzZpxFVVEVCTJWoePmU);
		P_0.Add("sourceMapId", ipBetyZODYfzViGaFnRptlTmCyeJA);
		int count = FIhQvLClIzNBYvgObtRpKoEGdDlB.Count;
		List<object> list = new List<object>();
		P_0.Add("elementMaps", list);
		for (int i = 0; i < count; i++)
		{
			if (FIhQvLClIzNBYvgObtRpKoEGdDlB[i] != null)
			{
				list.Add(FIhQvLClIzNBYvgObtRpKoEGdDlB[i].YzuKnKCDuUAMiMTyTmehTdQMWTzM());
			}
		}
	}

	internal virtual void nGYgmurcCczzoTnayfMgtZNokJfF(SerializedObject P_0)
	{
		HptRilwlGKMiKEkdnaYabrENkdcc();
		P_0.TryGetDeserializedValueByRef("enabled", ref mQmkTaInDEdRBjvNOFArMJWUcquj);
		P_0.TryGetDeserializedValueByRef("categoryId", ref qnWZRpvBkdXBAGGEaWgHabPErqNb);
		P_0.TryGetDeserializedValueByRef("layoutId", ref hNdZLFuqZRzZpxFVVEVCTJWoePmU);
		P_0.TryGetDeserializedValueByRef("sourceMapId", ref ipBetyZODYfzViGaFnRptlTmCyeJA);
		SerializedObject value = null;
		if (!P_0.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
		{
			return;
		}
		for (int i = 0; i < value.count; i++)
		{
			if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
			{
				ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.nbNdASjorFchTWCBuyNoiFVtFvSG(value2);
				if (controllerTemplateActionElementMap != null)
				{
					SKGkgEhCDfJVMaYTZOUcWMeGXKBG(controllerTemplateActionElementMap);
				}
			}
		}
	}

	private void HptRilwlGKMiKEkdnaYabrENkdcc()
	{
		mQmkTaInDEdRBjvNOFArMJWUcquj = true;
		qnWZRpvBkdXBAGGEaWgHabPErqNb = -1;
		hNdZLFuqZRzZpxFVVEVCTJWoePmU = -1;
		ipBetyZODYfzViGaFnRptlTmCyeJA = -1;
		FIhQvLClIzNBYvgObtRpKoEGdDlB.Clear();
	}

	private SerializedObject LVxxdEQLKHIMGNzvGmMGirbbKnyU()
	{
		SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
		dtyARuGcxFrHYOsbNvzBOEpjlAIaA(serializedObject);
		return serializedObject;
	}

	internal void SKGkgEhCDfJVMaYTZOUcWMeGXKBG(ControllerTemplateActionElementMap P_0)
	{
		if (P_0 != null)
		{
			FIhQvLClIzNBYvgObtRpKoEGdDlB.Add(P_0);
		}
	}

	internal static ControllerTemplateMap CjBzsfUiVEzUcOKspuVkWojfQfmr(IControllerTemplate P_0, ControllerMap P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("controllerMap");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("controllerTemplate");
		}
		if (!ReInput.isReady)
		{
			throw new Exception("Rewired is not initialized.");
		}
		Controller controller = ReInput.controllers.GetController(P_1.controllerType, P_1.controllerId);
		if (controller == null)
		{
			Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
			return null;
		}
		if (!controller.ImplementsTemplate(P_0.typeGuid))
		{
			Logger.LogError("The Controller does not implement the Controller Template.", requiredThreadSafety: true);
			return null;
		}
		ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(P_0.typeGuid);
		controllerTemplateMap.mQmkTaInDEdRBjvNOFArMJWUcquj = P_1.enabled;
		controllerTemplateMap.qnWZRpvBkdXBAGGEaWgHabPErqNb = P_1.categoryId;
		controllerTemplateMap.hNdZLFuqZRzZpxFVVEVCTJWoePmU = P_1.layoutId;
		controllerTemplateMap.ipBetyZODYfzViGaFnRptlTmCyeJA = P_1.sourceMapId;
		using TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>();
		List<ControllerTemplateElementTarget> list = tList.list;
		foreach (ActionElementMap allMap in P_1.AllMaps)
		{
			if (P_0.GetElementTargets(allMap, list) > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					controllerTemplateMap.SKGkgEhCDfJVMaYTZOUcWMeGXKBG(ControllerTemplateActionElementMap.jfcWEiqUjrSdULdKAmqQqxICKEac(list[i], allMap));
				}
			}
		}
		return controllerTemplateMap;
	}

	public static ControllerTemplateMap FromXml(string xmlString)
	{
		try
		{
			return xNvEzmDSdxvlkfFymriXzENDLfhF(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
		}
		catch (Exception ex)
		{
			Logger.LogError("Error creating ControllerTemplateMap from XML! " + ex.Message);
			return null;
		}
	}

	public static ControllerTemplateMap FromJson(string jsonString)
	{
		try
		{
			return xNvEzmDSdxvlkfFymriXzENDLfhF(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
		}
		catch (Exception ex)
		{
			Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
			return null;
		}
	}

	private static ControllerTemplateMap xNvEzmDSdxvlkfFymriXzENDLfhF(SerializedObject P_0)
	{
		if (!P_0.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
		{
			throw new Exception();
		}
		ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
		controllerTemplateMap.nGYgmurcCczzoTnayfMgtZNokJfF(P_0);
		return controllerTemplateMap;
	}
}
