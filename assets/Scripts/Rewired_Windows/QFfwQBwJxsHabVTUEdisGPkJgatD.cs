using System;
using System.Runtime.CompilerServices;

internal struct QFfwQBwJxsHabVTUEdisGPkJgatD(int P_0, int P_1) : IEquatable<QFfwQBwJxsHabVTUEdisGPkJgatD>
{
	public static readonly QFfwQBwJxsHabVTUEdisGPkJgatD ssBdxcWIlmjuIJRtcZdwFGkZljGs = new QFfwQBwJxsHabVTUEdisGPkJgatD(0, 0);

	public int GkDThOUjXFJjJuskFhmmzKBcYLWA = P_0;

	public int VOJxfUNkOVCSUJBDjqmoYuMKiseu = P_1;

	public bool Equals(QFfwQBwJxsHabVTUEdisGPkJgatD other)
	{
		if (other.GkDThOUjXFJjJuskFhmmzKBcYLWA == GkDThOUjXFJjJuskFhmmzKBcYLWA)
		{
			return other.VOJxfUNkOVCSUJBDjqmoYuMKiseu == VOJxfUNkOVCSUJBDjqmoYuMKiseu;
		}
		return false;
	}

	bool IEquatable<QFfwQBwJxsHabVTUEdisGPkJgatD>.Equals(QFfwQBwJxsHabVTUEdisGPkJgatD other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool uGbptzdIlFkpGYMYhgUPDbruyMkh(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(QFfwQBwJxsHabVTUEdisGPkJgatD))
		{
			return false;
		}
		return Equals((QFfwQBwJxsHabVTUEdisGPkJgatD)P_0);
	}

	public int RqwEOIkrpsWcxClqSlLZVFwSXTMN()
	{
		return (GkDThOUjXFJjJuskFhmmzKBcYLWA * 397) ^ VOJxfUNkOVCSUJBDjqmoYuMKiseu;
	}

	[SpecialName]
	public static bool TTJATRfJDLGzcMGiFzuFImCUscvk(QFfwQBwJxsHabVTUEdisGPkJgatD P_0, QFfwQBwJxsHabVTUEdisGPkJgatD P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool rMFNXnMpsatwHUAGQoKtJrBwkmsH(QFfwQBwJxsHabVTUEdisGPkJgatD P_0, QFfwQBwJxsHabVTUEdisGPkJgatD P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string GGDRVPXboBAkrDdPEgSpdYngthvjb()
	{
		return $"({GkDThOUjXFJjJuskFhmmzKBcYLWA},{VOJxfUNkOVCSUJBDjqmoYuMKiseu})";
	}
}
