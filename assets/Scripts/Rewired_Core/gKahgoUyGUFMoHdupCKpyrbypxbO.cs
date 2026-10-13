using System;
using System.Collections.Generic;
using Rewired.Utils;
using UnityEngine;
using UnityEngine.UI;

internal class gKahgoUyGUFMoHdupCKpyrbypxbO
{
	[Flags]
	public enum WEBBpFjzpIzAYuWCSIdKAqytmKkT
	{
		None = 0,
		Self = 1,
		Children = 2
	}

	private class eklgCFCRHJlwlkPvpmTnyDCbvEpt
	{
		public bool gYqYnPowzKUekiYuViSalqpzYOGl;

		public bool XVeTBrlWSsoZTDyVMnIKOHkmETwhA;

		public bool tOhcnHdKMkxkuJAnFEKFIbtpWWBl;
	}

	private Dictionary<int, eklgCFCRHJlwlkPvpmTnyDCbvEpt> srvGgyvpdeMlkcEHWGdHIEAfnBNe;

	public WEBBpFjzpIzAYuWCSIdKAqytmKkT sybELHsGsTggTEnKltaQNEWJfEGr;

	private bool numYChxDtVJGHvAdoBfdjBRIiBTc => bnuzQptQYiDKkuWOzhzeueJnARFq();

	private bool bnuzQptQYiDKkuWOzhzeueJnARFq()
	{
		return UnityTools.supportsUnityUIGraphicRaycastTarget;
	}

	public gKahgoUyGUFMoHdupCKpyrbypxbO()
		: this(WEBBpFjzpIzAYuWCSIdKAqytmKkT.Self | WEBBpFjzpIzAYuWCSIdKAqytmKkT.Children)
	{
	}

	public gKahgoUyGUFMoHdupCKpyrbypxbO(WEBBpFjzpIzAYuWCSIdKAqytmKkT P_0)
	{
		sybELHsGsTggTEnKltaQNEWJfEGr = P_0;
		srvGgyvpdeMlkcEHWGdHIEAfnBNe = new Dictionary<int, eklgCFCRHJlwlkPvpmTnyDCbvEpt>();
	}

	public void HNgQfMITEkAnTxRwkMrIubiErhfO(Transform P_0, bool P_1)
	{
		if (!bnuzQptQYiDKkuWOzhzeueJnARFq())
		{
			return;
		}
		if ((sybELHsGsTggTEnKltaQNEWJfEGr & WEBBpFjzpIzAYuWCSIdKAqytmKkT.Self) != WEBBpFjzpIzAYuWCSIdKAqytmKkT.None)
		{
			if ((sybELHsGsTggTEnKltaQNEWJfEGr & WEBBpFjzpIzAYuWCSIdKAqytmKkT.Children) != WEBBpFjzpIzAYuWCSIdKAqytmKkT.None)
			{
				hddjvdjSktaXiMLPAWbfRBhSAQho(P_0, P_1, srvGgyvpdeMlkcEHWGdHIEAfnBNe);
			}
			else
			{
				VRLnRpkuiKRDJGFFPerhGspDkfxs(P_0, P_1, srvGgyvpdeMlkcEHWGdHIEAfnBNe);
			}
		}
		else if ((sybELHsGsTggTEnKltaQNEWJfEGr & WEBBpFjzpIzAYuWCSIdKAqytmKkT.Children) != WEBBpFjzpIzAYuWCSIdKAqytmKkT.None)
		{
			TnchzRLlGMISSBeEyTZjgwGXtamVA(P_0, P_1, srvGgyvpdeMlkcEHWGdHIEAfnBNe);
		}
	}

	public void ylsfmpHjfEYWwRkBDCpgaEeOLhpw()
	{
		if (bnuzQptQYiDKkuWOzhzeueJnARFq())
		{
			srvGgyvpdeMlkcEHWGdHIEAfnBNe.Clear();
		}
	}

	private static void hddjvdjSktaXiMLPAWbfRBhSAQho(Transform P_0, bool P_1, Dictionary<int, eklgCFCRHJlwlkPvpmTnyDCbvEpt> P_2)
	{
		if (!(P_0 == null))
		{
			VRLnRpkuiKRDJGFFPerhGspDkfxs(P_0, P_1, P_2);
			TnchzRLlGMISSBeEyTZjgwGXtamVA(P_0, P_1, P_2);
		}
	}

	private static void TnchzRLlGMISSBeEyTZjgwGXtamVA(Transform P_0, bool P_1, Dictionary<int, eklgCFCRHJlwlkPvpmTnyDCbvEpt> P_2)
	{
		if (!(P_0 == null))
		{
			int childCount = P_0.childCount;
			for (int i = 0; i < childCount; i++)
			{
				hddjvdjSktaXiMLPAWbfRBhSAQho(P_0.GetChild(i), P_1, P_2);
			}
		}
	}

	private static void VRLnRpkuiKRDJGFFPerhGspDkfxs(Transform P_0, bool P_1, Dictionary<int, eklgCFCRHJlwlkPvpmTnyDCbvEpt> P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		Graphic component = P_0.GetComponent<Graphic>();
		if (component == null)
		{
			return;
		}
		bool flag = UnityTools.externalTools.UnityUI_Graphic_GetRaycastTarget(component);
		int instanceID = component.GetInstanceID();
		if (!P_2.TryGetValue(instanceID, out var value))
		{
			if (!flag)
			{
				return;
			}
			value = new eklgCFCRHJlwlkPvpmTnyDCbvEpt();
			value.gYqYnPowzKUekiYuViSalqpzYOGl = flag;
			P_2.Add(instanceID, value);
		}
		if ((value.XVeTBrlWSsoZTDyVMnIKOHkmETwhA && flag == value.gYqYnPowzKUekiYuViSalqpzYOGl) || (!value.XVeTBrlWSsoZTDyVMnIKOHkmETwhA && flag != value.gYqYnPowzKUekiYuViSalqpzYOGl))
		{
			value.XVeTBrlWSsoZTDyVMnIKOHkmETwhA = false;
			value.tOhcnHdKMkxkuJAnFEKFIbtpWWBl = false;
			value.gYqYnPowzKUekiYuViSalqpzYOGl = flag;
			if (!flag)
			{
				P_2.Remove(instanceID);
				return;
			}
		}
		if (P_1 != flag && value.gYqYnPowzKUekiYuViSalqpzYOGl)
		{
			if (value.gYqYnPowzKUekiYuViSalqpzYOGl == P_1)
			{
				value.XVeTBrlWSsoZTDyVMnIKOHkmETwhA = false;
				value.tOhcnHdKMkxkuJAnFEKFIbtpWWBl = false;
			}
			else
			{
				value.XVeTBrlWSsoZTDyVMnIKOHkmETwhA = true;
				value.tOhcnHdKMkxkuJAnFEKFIbtpWWBl = P_1;
			}
			UnityTools.externalTools.UnityUI_Graphic_SetRaycastTarget(component, P_1);
		}
	}
}
