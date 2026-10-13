using System;
using System.Collections.Generic;
using Rewired.Utils.Classes.Data;

namespace Rewired.Platforms.Custom;

public abstract class CustomPlatformUnifiedKeyboardSource : CustomPlatformUnifiedControllerSource
{
	public sealed class KeyPropertyMap
	{
		public struct Key
		{
			public KeyboardKeyCode keyCode;

			public string label;
		}

		private IndexedDictionary<int, string> hDLYxJSBkEddcBLEqWDAORWxdRnw;

		private bool ehXZAADeOjGXsdmeJSXNbjGhCjzVB;

		internal bool KkQdnQbZJUmpVDiovUqPiIZXuQybA
		{
			get
			{
				return VhdeJmPhJeLMtngkoiGsCZgEDFEzA();
			}
			set
			{
				OohBMamYbpWfvYLRlPIovqMRbsMX(flag);
			}
		}

		internal bool VhdeJmPhJeLMtngkoiGsCZgEDFEzA()
		{
			return ehXZAADeOjGXsdmeJSXNbjGhCjzVB;
		}

		internal void OohBMamYbpWfvYLRlPIovqMRbsMX(bool P_0)
		{
			ehXZAADeOjGXsdmeJSXNbjGhCjzVB = P_0;
		}

		public KeyPropertyMap()
		{
			hDLYxJSBkEddcBLEqWDAORWxdRnw = new IndexedDictionary<int, string>();
			IList<int> keyboardKeyValues = Consts.keyboardKeyValues;
			IList<string> keyboardKeyNames = Consts.keyboardKeyNames;
			for (int i = 0; i < 132; i++)
			{
				hDLYxJSBkEddcBLEqWDAORWxdRnw.Add(keyboardKeyValues[i], keyboardKeyNames[i]);
			}
			ehXZAADeOjGXsdmeJSXNbjGhCjzVB = true;
		}

		public KeyPropertyMap(KeyPropertyMap P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("other");
			}
			hDLYxJSBkEddcBLEqWDAORWxdRnw = new IndexedDictionary<int, string>(P_0.hDLYxJSBkEddcBLEqWDAORWxdRnw);
			ehXZAADeOjGXsdmeJSXNbjGhCjzVB = true;
		}

		public Key Get(KeyboardKeyCode keyCode)
		{
			if (!hDLYxJSBkEddcBLEqWDAORWxdRnw.TryGetValue((int)keyCode, out var value))
			{
				return default;
			}
			return new Key
			{
				keyCode = keyCode,
				label = value
			};
		}

		public void Set(Key key)
		{
			hDLYxJSBkEddcBLEqWDAORWxdRnw.SetValue((int)key.keyCode, key.label);
			ehXZAADeOjGXsdmeJSXNbjGhCjzVB = true;
		}

		public Key[] Get()
		{
			Key[] array = new Key[hDLYxJSBkEddcBLEqWDAORWxdRnw.get_Count()];
			int count = hDLYxJSBkEddcBLEqWDAORWxdRnw.get_Count();
			for (int i = 0; i < count; i++)
			{
				array[i] = new Key
				{
					keyCode = (KeyboardKeyCode)hDLYxJSBkEddcBLEqWDAORWxdRnw.GetKeyAt(i),
					label = hDLYxJSBkEddcBLEqWDAORWxdRnw[i]
				};
			}
			return array;
		}

		public void Set(ICollection<Key> keys)
		{
			if (keys == null)
			{
				throw new ArgumentNullException("keys");
			}
			foreach (Key key in keys)
			{
				hDLYxJSBkEddcBLEqWDAORWxdRnw.SetValue((int)key.keyCode, key.label);
			}
			ehXZAADeOjGXsdmeJSXNbjGhCjzVB = true;
		}
	}

	private KeyPropertyMap eQZDHeysrLFKHqVAGknrcUCRjVpJ;

	public KeyPropertyMap keyPropertyMap
	{
		get
		{
			if (eQZDHeysrLFKHqVAGknrcUCRjVpJ == null)
			{
				eQZDHeysrLFKHqVAGknrcUCRjVpJ = new KeyPropertyMap();
			}
			return eQZDHeysrLFKHqVAGknrcUCRjVpJ;
		}
		set
		{
			if (value == null)
			{
				value = new KeyPropertyMap();
			}
			eQZDHeysrLFKHqVAGknrcUCRjVpJ = value;
			tYKqDkVjRyMTmqDUUpNAqCENFuGk();
		}
	}

	public CustomPlatformUnifiedKeyboardSource()
		: base(0, Consts._keyboardKeyValues.Length)
	{
	}

	protected void SetKeyValue(KeyboardKeyCode keyCode, bool value)
	{
		int buttonIndex = ReInput.controllers.Keyboard.GetButtonIndex(keyCode);
		if (buttonIndex >= 0)
		{
			SetButtonValue(buttonIndex, value);
		}
	}

	internal virtual void jAHLPNVnvaTGuaIRqCeJfyoVNytB()
	{
		base.VgVAtSmMniPvCujcBMNWPuINwWsK();
		if (eQZDHeysrLFKHqVAGknrcUCRjVpJ != null && eQZDHeysrLFKHqVAGknrcUCRjVpJ.VhdeJmPhJeLMtngkoiGsCZgEDFEzA())
		{
			tYKqDkVjRyMTmqDUUpNAqCENFuGk();
		}
	}

	private void tYKqDkVjRyMTmqDUUpNAqCENFuGk()
	{
		HardwareControllerMap_Game aHJMAWzbypGgwCcRCqDEaoqVGwfA = ReInput.controllers.Keyboard.aHJMAWzbypGgwCcRCqDEaoqVGwfA;
		int totalCount = aHJMAWzbypGgwCcRCqDEaoqVGwfA.elementIdentifiers.TotalCount;
		for (int i = 0; i < totalCount; i++)
		{
			if (aHJMAWzbypGgwCcRCqDEaoqVGwfA.elementIdentifiers.TryGetValueAt(i, out var value))
			{
				KeyboardKeyCode keyCode = (KeyboardKeyCode)Consts.keyboardKeyValues[value.get_id()];
				string label = eQZDHeysrLFKHqVAGknrcUCRjVpJ.Get(keyCode).label;
				if (!string.Equals(value.get_name(), label))
				{
					value.set_name(label);
				}
			}
		}
		eQZDHeysrLFKHqVAGknrcUCRjVpJ.OohBMamYbpWfvYLRlPIovqMRbsMX(false);
	}
}
