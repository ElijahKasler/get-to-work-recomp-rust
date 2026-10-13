using System;
using System.Runtime.CompilerServices;

internal struct ZURtiJVykEAGXPPxTKxYDmMXhRKW(int P_0, int P_1) : IEquatable<ZURtiJVykEAGXPPxTKxYDmMXhRKW>
{
	public static readonly ZURtiJVykEAGXPPxTKxYDmMXhRKW pmbPhTBBqqJxtsxplZYceTbZNTcE = new ZURtiJVykEAGXPPxTKxYDmMXhRKW(0, 0);

	public static readonly ZURtiJVykEAGXPPxTKxYDmMXhRKW XWetqNZmPeNQYoiPOnSSBUwrBDIQ = pmbPhTBBqqJxtsxplZYceTbZNTcE;

	public int zDtcwlffaAYqieOchjsGsIQwgjSE = P_0;

	public int OnVSYdhHnCfklZcoWdObUdASUdMw = P_1;

	public bool Equals(ZURtiJVykEAGXPPxTKxYDmMXhRKW other)
	{
		if (other.zDtcwlffaAYqieOchjsGsIQwgjSE == zDtcwlffaAYqieOchjsGsIQwgjSE)
		{
			return other.OnVSYdhHnCfklZcoWdObUdASUdMw == OnVSYdhHnCfklZcoWdObUdASUdMw;
		}
		return false;
	}

	bool IEquatable<ZURtiJVykEAGXPPxTKxYDmMXhRKW>.Equals(ZURtiJVykEAGXPPxTKxYDmMXhRKW other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool ZispTFLyGdutVpaAQDzCNGyBxOrM(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(ZURtiJVykEAGXPPxTKxYDmMXhRKW))
		{
			return false;
		}
		return Equals((ZURtiJVykEAGXPPxTKxYDmMXhRKW)P_0);
	}

	public int lIKKIGxSdDUKGCIWoDZrhCDiFKXj()
	{
		return (zDtcwlffaAYqieOchjsGsIQwgjSE * 397) ^ OnVSYdhHnCfklZcoWdObUdASUdMw;
	}

	[SpecialName]
	public static bool gknWCvZleUdlNwojPKIMBPhpLhXw(ZURtiJVykEAGXPPxTKxYDmMXhRKW P_0, ZURtiJVykEAGXPPxTKxYDmMXhRKW P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool fRGbRaWYtpviymtqtQtgCsnTeFWC(ZURtiJVykEAGXPPxTKxYDmMXhRKW P_0, ZURtiJVykEAGXPPxTKxYDmMXhRKW P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string nMFdsTHNbHEhIehNcTXTElbfbObKb()
	{
		return $"({zDtcwlffaAYqieOchjsGsIQwgjSE},{OnVSYdhHnCfklZcoWdObUdASUdMw})";
	}
}
