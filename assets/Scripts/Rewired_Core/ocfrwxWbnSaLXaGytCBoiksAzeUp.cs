using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Rewired;

[DefaultMember("Item")]
internal struct ocfrwxWbnSaLXaGytCBoiksAzeUp : IEquatable<ocfrwxWbnSaLXaGytCBoiksAzeUp>
{
	public ModifierKey xDgQhPfegHAVfGakqTqMUJrQfHRiA;

	public ModifierKey YZFdBqXgyFXHWssASMlsAAJSBPDFA;

	public ModifierKey jZGXhmUoslJRSDvkzPBGQEmgNqcE;

	// C# has no syntax for parameterized property 'aVgBteIfncBbrHtFvJqQGRougOo'.
	private ModifierKey get_aVgBteIfncBbrHtFvJqQGRougOo(int P_0)
	{
		return bpomcvNBDMeQHeCuIsShfcbhrTdjA(P_0);
	}

	private void set_aVgBteIfncBbrHtFvJqQGRougOo(int P_0, ModifierKey P_1)
	{
		mePhYALyTIiKOwbsqzAFYtdwaNqg(num, modifierKey);
	}

	private ModifierKey bpomcvNBDMeQHeCuIsShfcbhrTdjA(int P_0)
	{
		if (P_0 <= 0)
		{
			return xDgQhPfegHAVfGakqTqMUJrQfHRiA;
		}
		if (P_0 == 1)
		{
			return YZFdBqXgyFXHWssASMlsAAJSBPDFA;
		}
		if (P_0 >= 2)
		{
			return jZGXhmUoslJRSDvkzPBGQEmgNqcE;
		}
		return xDgQhPfegHAVfGakqTqMUJrQfHRiA;
	}

	private void mePhYALyTIiKOwbsqzAFYtdwaNqg(int P_0, ModifierKey P_1)
	{
		if (P_0 <= 0)
		{
			xDgQhPfegHAVfGakqTqMUJrQfHRiA = P_1;
		}
		if (P_0 == 1)
		{
			YZFdBqXgyFXHWssASMlsAAJSBPDFA = P_1;
		}
		if (P_0 >= 2)
		{
			jZGXhmUoslJRSDvkzPBGQEmgNqcE = P_1;
		}
	}

	public ocfrwxWbnSaLXaGytCBoiksAzeUp(ModifierKey P_0, ModifierKey P_1, ModifierKey P_2)
	{
		xDgQhPfegHAVfGakqTqMUJrQfHRiA = P_0;
		YZFdBqXgyFXHWssASMlsAAJSBPDFA = P_1;
		jZGXhmUoslJRSDvkzPBGQEmgNqcE = P_2;
	}

	public void KkZwgIBoOmgNSPEnaSlgiqhmIqrfA()
	{
		if (xDgQhPfegHAVfGakqTqMUJrQfHRiA != ModifierKey.None)
		{
			xDgQhPfegHAVfGakqTqMUJrQfHRiA = ModifierKey.None;
		}
		if (YZFdBqXgyFXHWssASMlsAAJSBPDFA != ModifierKey.None)
		{
			YZFdBqXgyFXHWssASMlsAAJSBPDFA = ModifierKey.None;
		}
		if (jZGXhmUoslJRSDvkzPBGQEmgNqcE != ModifierKey.None)
		{
			jZGXhmUoslJRSDvkzPBGQEmgNqcE = ModifierKey.None;
		}
	}

	public static ocfrwxWbnSaLXaGytCBoiksAzeUp zweiqmUGMTpdJvZBdjaHWVsAsLpN(ModifierKeyFlags P_0)
	{
		ocfrwxWbnSaLXaGytCBoiksAzeUp result = default;
		int num = 0;
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Control))
		{
			result.mePhYALyTIiKOwbsqzAFYtdwaNqg(num++, ModifierKey.Control);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Command))
		{
			result.mePhYALyTIiKOwbsqzAFYtdwaNqg(num++, ModifierKey.Command);
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Alt))
		{
			result.mePhYALyTIiKOwbsqzAFYtdwaNqg(num++, ModifierKey.Alt);
		}
		if (num >= 3)
		{
			return result;
		}
		if (Keyboard.ModifierKeyFlagsContain(P_0, ModifierKey.Shift))
		{
			result.mePhYALyTIiKOwbsqzAFYtdwaNqg(num++, ModifierKey.Shift);
		}
		return result;
	}

	public bool Equals(ocfrwxWbnSaLXaGytCBoiksAzeUp other)
	{
		if (xDgQhPfegHAVfGakqTqMUJrQfHRiA == other.xDgQhPfegHAVfGakqTqMUJrQfHRiA && YZFdBqXgyFXHWssASMlsAAJSBPDFA == other.YZFdBqXgyFXHWssASMlsAAJSBPDFA)
		{
			return jZGXhmUoslJRSDvkzPBGQEmgNqcE == other.jZGXhmUoslJRSDvkzPBGQEmgNqcE;
		}
		return false;
	}

	bool IEquatable<ocfrwxWbnSaLXaGytCBoiksAzeUp>.Equals(ocfrwxWbnSaLXaGytCBoiksAzeUp other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool wtaLcziGCDXmzfQFBISUhgQDHbTQ(object P_0)
	{
		if (P_0 == null || !(P_0 is ocfrwxWbnSaLXaGytCBoiksAzeUp))
		{
			return false;
		}
		return Equals((ocfrwxWbnSaLXaGytCBoiksAzeUp)P_0);
	}

	public int UNTXiEKNfdcsZEotzDDhySOWhmYC()
	{
		return ((17 * 29 + xDgQhPfegHAVfGakqTqMUJrQfHRiA.GetHashCode()) * 29 + YZFdBqXgyFXHWssASMlsAAJSBPDFA.GetHashCode()) * 29 + jZGXhmUoslJRSDvkzPBGQEmgNqcE.GetHashCode();
	}

	[SpecialName]
	public static bool crNQTTOLUsJvRkabsjsLwrZKJWAh(ocfrwxWbnSaLXaGytCBoiksAzeUp P_0, ocfrwxWbnSaLXaGytCBoiksAzeUp P_1)
	{
		if (P_0.xDgQhPfegHAVfGakqTqMUJrQfHRiA == P_1.xDgQhPfegHAVfGakqTqMUJrQfHRiA && P_0.YZFdBqXgyFXHWssASMlsAAJSBPDFA == P_1.YZFdBqXgyFXHWssASMlsAAJSBPDFA)
		{
			return P_0.jZGXhmUoslJRSDvkzPBGQEmgNqcE == P_1.jZGXhmUoslJRSDvkzPBGQEmgNqcE;
		}
		return false;
	}

	[SpecialName]
	public static bool JPvgBsAabAcMuDuWlwbrutLYkoDn(ocfrwxWbnSaLXaGytCBoiksAzeUp P_0, ocfrwxWbnSaLXaGytCBoiksAzeUp P_1)
	{
		return !crNQTTOLUsJvRkabsjsLwrZKJWAh(P_0, P_1);
	}
}
