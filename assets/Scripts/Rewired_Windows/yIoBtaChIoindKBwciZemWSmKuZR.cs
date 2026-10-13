using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct yIoBtaChIoindKBwciZemWSmKuZR(bool P_0) : IEquatable<yIoBtaChIoindKBwciZemWSmKuZR>
{
	private int MrzFQiMaONivAaXxYLaHnRBEUwKN = (P_0 ? 1 : 0);

	public bool Equals(yIoBtaChIoindKBwciZemWSmKuZR other)
	{
		return MrzFQiMaONivAaXxYLaHnRBEUwKN == other.MrzFQiMaONivAaXxYLaHnRBEUwKN;
	}

	bool IEquatable<yIoBtaChIoindKBwciZemWSmKuZR>.Equals(yIoBtaChIoindKBwciZemWSmKuZR other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool AIlPuqeMKWIttBQqFPBypzbxEYzEb(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0 is yIoBtaChIoindKBwciZemWSmKuZR)
		{
			return Equals((yIoBtaChIoindKBwciZemWSmKuZR)P_0);
		}
		return false;
	}

	public int lWAShKQcPyChygkvaVzVemQTPuwe()
	{
		return MrzFQiMaONivAaXxYLaHnRBEUwKN;
	}

	[SpecialName]
	public static bool IjymXLVwYkioDDOvuENJJuWmfZNl(yIoBtaChIoindKBwciZemWSmKuZR P_0, yIoBtaChIoindKBwciZemWSmKuZR P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool seWJVaUNQOfJoFsfyFfVzzWcoLwTA(yIoBtaChIoindKBwciZemWSmKuZR P_0, yIoBtaChIoindKBwciZemWSmKuZR P_1)
	{
		return !P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool BzreFzuIelyaCyZZuhMwJqOQcszbA(yIoBtaChIoindKBwciZemWSmKuZR P_0)
	{
		return P_0.MrzFQiMaONivAaXxYLaHnRBEUwKN != 0;
	}

	[SpecialName]
	public static yIoBtaChIoindKBwciZemWSmKuZR YYTXemMMVUKpApdbyBuvFUxMKfrn(bool P_0)
	{
		return new yIoBtaChIoindKBwciZemWSmKuZR(P_0);
	}

	public string BnrtzmXPXVuhcxAWGaaUrdFnQozs()
	{
		return $"{MrzFQiMaONivAaXxYLaHnRBEUwKN != 0}";
	}
}
