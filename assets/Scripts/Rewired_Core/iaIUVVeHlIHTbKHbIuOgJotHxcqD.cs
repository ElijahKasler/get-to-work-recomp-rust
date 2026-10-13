using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class iaIUVVeHlIHTbKHbIuOgJotHxcqD : IHardwareControllerTemplateMap, IHardwareControllerTemplateMap_Internal
{
	private struct pMcgVlMGIabxjYGfJQlrDHXnHKYB(IControllerTemplateMapSpecialElement_Internal P_0) : IControllerTemplateMapSpecialElement_Internal
	{
		private IControllerTemplateMapSpecialElement_Internal sycwbeaHDQbzxAMFsilfrvXhYsMU = P_0;

		public T GetMapping<T>() where T : ControllerTemplateSpecialElementMapping
		{
			return sycwbeaHDQbzxAMFsilfrvXhYsMU.GetMapping<T>();
		}

		T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetMapping
			return this.GetMapping<T>();
		}
	}

	private HardwareJoystickTemplateMap EYUGYNzzxIrliqgylPkqlvDFaTRu;

	private string aDBwehTdSOqcNYTcLgcHadiUYkfj;

	private string fNcskUvuvJcDzkfQjfHnsHEAJStdA;

	private string kLvuLnheFpHFpULofPouQZIOhVMr;

	private readonly Guid WQsmKkWMtwppPnPpVBSfvQRcuUfy;

	private readonly List<HardwareJoystickTemplateMap.Entry> KOLcyNTFQSgSxFkuKhBcVfbcBvaiA;

	private readonly ControllerTemplateElementIdentifier[] htlTIuOkUQUXTHbIIxeLtuEuirEf;

	private readonly DeviceLocalizationInfo lhTKTIcfVSPehDPnTOMsBSXZIslV;

	[NonSerialized]
	private Func<Guid, HardwareJoystickTemplateMap.Entry> FSZwUvSkuHByYjPDuSMDFaFZrmXS;

	public string name => aDBwehTdSOqcNYTcLgcHadiUYkfj;

	public string MBlnbWhBeyopqiKcpIBEHsAGQwQK => KstOxEjzNrBKlglxBqQZWoKoCmqR();

	public string cFvnvPBBZgEFTieNYOhfhtsKNEei => LRKcKfuErsHagGyfjlADPGrTUQyi();

	public Guid cDknvkZlALdaKKCvYIAqbUmeIPweA => VmVQWcbrYhIXbgEtaxgfwAgaIMbkA();

	string IHardwareControllerTemplateMap_Internal.name => aDBwehTdSOqcNYTcLgcHadiUYkfj;

	Guid IHardwareControllerTemplateMap_Internal.typeGuid => WQsmKkWMtwppPnPpVBSfvQRcuUfy;

	string IHardwareControllerTemplateMap_Internal.typeKey => kLvuLnheFpHFpULofPouQZIOhVMr;

	private Func<Guid, HardwareJoystickTemplateMap.Entry> qLNiAhFXLMlpdNBVZcCpOIENrHV => vnVShmvQZSbGQnxobzPSMavviXDe();

	public string KstOxEjzNrBKlglxBqQZWoKoCmqR()
	{
		return fNcskUvuvJcDzkfQjfHnsHEAJStdA;
	}

	public string LRKcKfuErsHagGyfjlADPGrTUQyi()
	{
		return kLvuLnheFpHFpULofPouQZIOhVMr;
	}

	public Guid VmVQWcbrYhIXbgEtaxgfwAgaIMbkA()
	{
		return WQsmKkWMtwppPnPpVBSfvQRcuUfy;
	}

	public iaIUVVeHlIHTbKHbIuOgJotHxcqD(HardwareJoystickTemplateMap P_0, List<HardwareJoystickTemplateMap.Entry> P_1, ControllerTemplateElementIdentifier[] P_2)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException();
		}
		if (P_2 == null)
		{
			throw new ArgumentNullException();
		}
		EYUGYNzzxIrliqgylPkqlvDFaTRu = P_0;
		aDBwehTdSOqcNYTcLgcHadiUYkfj = P_0.name;
		fNcskUvuvJcDzkfQjfHnsHEAJStdA = P_0.ClassName;
		WQsmKkWMtwppPnPpVBSfvQRcuUfy = P_0.Guid;
		kLvuLnheFpHFpULofPouQZIOhVMr = P_0.Key;
		KOLcyNTFQSgSxFkuKhBcVfbcBvaiA = P_1;
		htlTIuOkUQUXTHbIIxeLtuEuirEf = P_2;
		lhTKTIcfVSPehDPnTOMsBSXZIslV = new DeviceLocalizationInfo(ControllerType.Joystick, true, VmVQWcbrYhIXbgEtaxgfwAgaIMbkA(), new AList<string> { kLvuLnheFpHFpULofPouQZIOhVMr }, null);
		lhTKTIcfVSPehDPnTOMsBSXZIslV.FinishRuntimeSetup();
		bool flag = lhTKTIcfVSPehDPnTOMsBSXZIslV.controllerType != ControllerType.Keyboard && lhTKTIcfVSPehDPnTOMsBSXZIslV.controllerType != ControllerType.Mouse;
		for (int i = 0; i < htlTIuOkUQUXTHbIIxeLtuEuirEf.Length; i++)
		{
			if (htlTIuOkUQUXTHbIIxeLtuEuirEf[i] == null)
			{
				continue;
			}
			if (flag)
			{
				if (ControllerTemplateElementIdentifier.yJSKCHSgVArGxOCqeFfXMNhxIytgA.ZIsORwQGXMDiwIvXegfyiggIPWPr(lhTKTIcfVSPehDPnTOMsBSXZIslV, htlTIuOkUQUXTHbIIxeLtuEuirEf[i], out var controllerTemplateElementIdentifier))
				{
					htlTIuOkUQUXTHbIIxeLtuEuirEf[i] = controllerTemplateElementIdentifier;
					continue;
				}
				ControllerTemplateElementIdentifier.yJSKCHSgVArGxOCqeFfXMNhxIytgA.ANQPteaFQlpgNHJCzibqYdVCOdOn(lhTKTIcfVSPehDPnTOMsBSXZIslV, htlTIuOkUQUXTHbIIxeLtuEuirEf[i]);
			}
			htlTIuOkUQUXTHbIIxeLtuEuirEf[i].FinishRuntimeSetup(lhTKTIcfVSPehDPnTOMsBSXZIslV);
		}
	}

	public ControllerTemplateElementIdentifier WwvVysMZawLfTTJpBknUeTRaZPPE(Guid P_0, int P_1)
	{
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return null;
		}
		if (KOLcyNTFQSgSxFkuKhBcVfbcBvaiA == null)
		{
			return null;
		}
		int num = -1;
		int count = KOLcyNTFQSgSxFkuKhBcVfbcBvaiA.Count;
		for (int i = 0; i < count; i++)
		{
			if (KOLcyNTFQSgSxFkuKhBcVfbcBvaiA[i] != null && KOLcyNTFQSgSxFkuKhBcVfbcBvaiA[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return null;
		}
		HardwareJoystickTemplateMap.Entry entry = KOLcyNTFQSgSxFkuKhBcVfbcBvaiA[num];
		if (entry == null)
		{
			return null;
		}
		int templateElementId = entry.GetTemplateElementId(P_1);
		if (templateElementId < 0)
		{
			return null;
		}
		return HardwareJoystickTemplateMap.IvyyZLVerFinWxSVGKGePVqoNzrQ(htlTIuOkUQUXTHbIIxeLtuEuirEf, templateElementId);
	}

	public int gblmEJcPdvFqUgmOkcwgBDMwlrNoA(Guid P_0, int P_1, List<HardwareControllerTemplateMap.PgcfNfWcImnrYkHGMEnMulFOKNwn> P_2)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("results");
		}
		if (P_0 == Guid.Empty || P_1 < 0)
		{
			return 0;
		}
		if (KOLcyNTFQSgSxFkuKhBcVfbcBvaiA == null)
		{
			return 0;
		}
		int num = -1;
		int count = KOLcyNTFQSgSxFkuKhBcVfbcBvaiA.Count;
		for (int i = 0; i < count; i++)
		{
			if (KOLcyNTFQSgSxFkuKhBcVfbcBvaiA[i] != null && KOLcyNTFQSgSxFkuKhBcVfbcBvaiA[i].JoystickGuid == P_0)
			{
				num = i;
				break;
			}
		}
		if (num < 0)
		{
			return 0;
		}
		HardwareJoystickTemplateMap.Entry entry = KOLcyNTFQSgSxFkuKhBcVfbcBvaiA[num];
		if (entry == null)
		{
			return 0;
		}
		int count2 = P_2.Count;
		int num2 = ((entry.elementIdentifierMappings != null) ? entry.elementIdentifierMappings.Count : 0);
		for (int j = 0; j < num2; j++)
		{
			if (entry.elementIdentifierMappings == null)
			{
				continue;
			}
			HardwareJoystickTemplateMap.ElementIdentifierMap elementIdentifierMap = entry.elementIdentifierMappings[j];
			if (elementIdentifierMap == null)
			{
				continue;
			}
			ControllerTemplateElementIdentifier controllerTemplateElementIdentifier = iRkEmAXUCohLzEezUkpykJbcdwODA(htlTIuOkUQUXTHbIIxeLtuEuirEf, elementIdentifierMap.templateId);
			if (controllerTemplateElementIdentifier == null)
			{
				continue;
			}
			if (controllerTemplateElementIdentifier.get_elementType() == ControllerTemplateElementType.Axis)
			{
				if (elementIdentifierMap.splitAxis)
				{
					if (elementIdentifierMap.joystickId != P_1 && elementIdentifierMap.joystickId2 != P_1)
					{
						continue;
					}
				}
				else if (elementIdentifierMap.joystickId != P_1)
				{
					continue;
				}
			}
			else if (elementIdentifierMap.joystickId != P_1)
			{
				continue;
			}
			P_2.Add(new HardwareControllerTemplateMap.PgcfNfWcImnrYkHGMEnMulFOKNwn
			{
				utlKcqldHRRKLpOrqiAMIkKxVvg = elementIdentifierMap.templateId,
				QVKERDqghlgkvevdGJoJjQqdRjcSA = elementIdentifierMap.joystickId,
				VouiqeZlORgyIJLSJGMACtQpWMfN = elementIdentifierMap.joystickId2,
				BJanzbQFjyzEtSuYOhASpVpqvxgH = (controllerTemplateElementIdentifier.get_elementType() == ControllerTemplateElementType.Axis && elementIdentifierMap.splitAxis)
			});
		}
		return P_2.Count - count2;
	}

	private HardwareJoystickTemplateMap.Entry lreXELCqtAeyiAThlntOFHwEMHnC(Guid P_0)
	{
		if (KOLcyNTFQSgSxFkuKhBcVfbcBvaiA == null)
		{
			return null;
		}
		for (int i = 0; i < KOLcyNTFQSgSxFkuKhBcVfbcBvaiA.Count; i++)
		{
			if (KOLcyNTFQSgSxFkuKhBcVfbcBvaiA[i].JoystickGuid == P_0)
			{
				return KOLcyNTFQSgSxFkuKhBcVfbcBvaiA[i];
			}
		}
		return null;
	}

	private static ControllerTemplateElementIdentifier iRkEmAXUCohLzEezUkpykJbcdwODA(ControllerTemplateElementIdentifier[] P_0, int P_1)
	{
		if (P_0 == null)
		{
			return null;
		}
		for (int i = 0; i < P_0.Length; i++)
		{
			if (P_0[i] != null && P_0[i].get_id() == P_1)
			{
				return P_0[i];
			}
		}
		return null;
	}

	int IHardwareControllerTemplateMap_Internal.GetElementIdentifierCount()
	{
		if (htlTIuOkUQUXTHbIIxeLtuEuirEf == null)
		{
			return 0;
		}
		return htlTIuOkUQUXTHbIIxeLtuEuirEf.Length;
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int index)
	{
		if (htlTIuOkUQUXTHbIIxeLtuEuirEf == null)
		{
			return null;
		}
		return htlTIuOkUQUXTHbIIxeLtuEuirEf[index];
	}

	IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.IvyyZLVerFinWxSVGKGePVqoNzrQ(htlTIuOkUQUXTHbIIxeLtuEuirEf, elementIdentifierId);
	}

	IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int id)
	{
		return new pMcgVlMGIabxjYGfJQlrDHXnHKYB(((IHardwareControllerTemplateMap_Internal)EYUGYNzzxIrliqgylPkqlvDFaTRu).GetSpecialTemplateElementByElementIdentifierId(id));
	}

	NxexmFcztmkjMTmmeibTdDSlWuxt IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.dASpLAKITERyNkBPmFaZkOZwYMkZ(this, controller, elementIdentifierId, vnVShmvQZSbGQnxobzPSMavviXDe());
	}

	NxexmFcztmkjMTmmeibTdDSlWuxt IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
	{
		return HardwareJoystickTemplateMap.QmFbFAJyIEoGpmPzoOFHvVtYujkt(this, controller, elementIdentifierId, vnVShmvQZSbGQnxobzPSMavviXDe());
	}

	private Func<Guid, HardwareJoystickTemplateMap.Entry> vnVShmvQZSbGQnxobzPSMavviXDe()
	{
		return lreXELCqtAeyiAThlntOFHwEMHnC;
	}
}
