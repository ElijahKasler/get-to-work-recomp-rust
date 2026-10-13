using System;
using System.Runtime.CompilerServices;
using Rewired;

internal struct MqBJzUTLlffrODmQGvspYGoVdWtO(KeyboardKeyCode P_0, ModifierKey P_1, ModifierKey P_2, ModifierKey P_3) : IEquatable<MqBJzUTLlffrODmQGvspYGoVdWtO>
{
	public KeyboardKeyCode eqUPpnlOXMXRSlVCRGskzVAZiYLk = P_0;

	public ModifierKey leUtAUYDCkBXltWVbaeesqSpYlrc = P_1;

	public ModifierKey nPNsRpWnGsmzIxoGjxToiajWWqsU = P_2;

	public ModifierKey zMeQASaXwcgvksjfnVRBkWYpibPS = P_3;

	public void UXHrZzeahotJnjqUOJLhvWeYMzQQ()
	{
		if (eqUPpnlOXMXRSlVCRGskzVAZiYLk != KeyboardKeyCode.None)
		{
			eqUPpnlOXMXRSlVCRGskzVAZiYLk = KeyboardKeyCode.None;
		}
		if (leUtAUYDCkBXltWVbaeesqSpYlrc != ModifierKey.None)
		{
			leUtAUYDCkBXltWVbaeesqSpYlrc = ModifierKey.None;
		}
		if (nPNsRpWnGsmzIxoGjxToiajWWqsU != ModifierKey.None)
		{
			nPNsRpWnGsmzIxoGjxToiajWWqsU = ModifierKey.None;
		}
		if (zMeQASaXwcgvksjfnVRBkWYpibPS != ModifierKey.None)
		{
			zMeQASaXwcgvksjfnVRBkWYpibPS = ModifierKey.None;
		}
	}

	public bool Equals(MqBJzUTLlffrODmQGvspYGoVdWtO other)
	{
		if (eqUPpnlOXMXRSlVCRGskzVAZiYLk == other.eqUPpnlOXMXRSlVCRGskzVAZiYLk && leUtAUYDCkBXltWVbaeesqSpYlrc == other.leUtAUYDCkBXltWVbaeesqSpYlrc && nPNsRpWnGsmzIxoGjxToiajWWqsU == other.nPNsRpWnGsmzIxoGjxToiajWWqsU)
		{
			return zMeQASaXwcgvksjfnVRBkWYpibPS == other.zMeQASaXwcgvksjfnVRBkWYpibPS;
		}
		return false;
	}

	bool IEquatable<MqBJzUTLlffrODmQGvspYGoVdWtO>.Equals(MqBJzUTLlffrODmQGvspYGoVdWtO other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool LeZQspxXZarNqXDryEyZhyZhHeNz(object P_0)
	{
		if (P_0 == null || !(P_0 is MqBJzUTLlffrODmQGvspYGoVdWtO))
		{
			return false;
		}
		return Equals((MqBJzUTLlffrODmQGvspYGoVdWtO)P_0);
	}

	public int OabWSarLdHzWgZmrXrDaDjZTUyAp()
	{
		return (((17 * 29 + eqUPpnlOXMXRSlVCRGskzVAZiYLk.GetHashCode()) * 29 + leUtAUYDCkBXltWVbaeesqSpYlrc.GetHashCode()) * 29 + nPNsRpWnGsmzIxoGjxToiajWWqsU.GetHashCode()) * 29 + zMeQASaXwcgvksjfnVRBkWYpibPS.GetHashCode();
	}

	[SpecialName]
	public static bool IwNgCWDCOsDDtnhRLpGyhYeluaaB(MqBJzUTLlffrODmQGvspYGoVdWtO P_0, MqBJzUTLlffrODmQGvspYGoVdWtO P_1)
	{
		if (P_0.eqUPpnlOXMXRSlVCRGskzVAZiYLk == P_1.eqUPpnlOXMXRSlVCRGskzVAZiYLk && P_0.leUtAUYDCkBXltWVbaeesqSpYlrc == P_1.leUtAUYDCkBXltWVbaeesqSpYlrc && P_0.nPNsRpWnGsmzIxoGjxToiajWWqsU == P_1.nPNsRpWnGsmzIxoGjxToiajWWqsU)
		{
			return P_0.zMeQASaXwcgvksjfnVRBkWYpibPS == P_1.zMeQASaXwcgvksjfnVRBkWYpibPS;
		}
		return false;
	}

	[SpecialName]
	public static bool EZvgdssWWTfIjImIqIxfoxvzNCUlA(MqBJzUTLlffrODmQGvspYGoVdWtO P_0, MqBJzUTLlffrODmQGvspYGoVdWtO P_1)
	{
		return !IwNgCWDCOsDDtnhRLpGyhYeluaaB(P_0, P_1);
	}
}
