using System;
using System.Runtime.CompilerServices;

internal struct wVrBeahRaXcXzwjLjufKsFgdWIqA(float P_0, float P_1) : IEquatable<wVrBeahRaXcXzwjLjufKsFgdWIqA>
{
	public static readonly wVrBeahRaXcXzwjLjufKsFgdWIqA QamjGjUzNSSNKSsTjmzzHbtcasFAA = new wVrBeahRaXcXzwjLjufKsFgdWIqA(0f, 0f);

	public static readonly wVrBeahRaXcXzwjLjufKsFgdWIqA rzodxSjJvyoxdpiEgCCvjghSgzvA = QamjGjUzNSSNKSsTjmzzHbtcasFAA;

	public float FvzVtjEuSmvDiGSOuVCSYytmTlQC = P_0;

	public float bxsEzYFHNDhbzvNPUftFhtWDdNbO = P_1;

	public bool Equals(wVrBeahRaXcXzwjLjufKsFgdWIqA other)
	{
		if (other.FvzVtjEuSmvDiGSOuVCSYytmTlQC == FvzVtjEuSmvDiGSOuVCSYytmTlQC)
		{
			return other.bxsEzYFHNDhbzvNPUftFhtWDdNbO == bxsEzYFHNDhbzvNPUftFhtWDdNbO;
		}
		return false;
	}

	bool IEquatable<wVrBeahRaXcXzwjLjufKsFgdWIqA>.Equals(wVrBeahRaXcXzwjLjufKsFgdWIqA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool VRQEFFRVnPQmieucAtLKCXXGAeBs(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(wVrBeahRaXcXzwjLjufKsFgdWIqA))
		{
			return false;
		}
		return Equals((wVrBeahRaXcXzwjLjufKsFgdWIqA)P_0);
	}

	public int GGXpFyalfgBWxUXLzQUkaLIeHoZj()
	{
		return (FvzVtjEuSmvDiGSOuVCSYytmTlQC.GetHashCode() * 397) ^ bxsEzYFHNDhbzvNPUftFhtWDdNbO.GetHashCode();
	}

	[SpecialName]
	public static bool dQOfYqvtyNaJIBvoiKjyVQMbDynS(wVrBeahRaXcXzwjLjufKsFgdWIqA P_0, wVrBeahRaXcXzwjLjufKsFgdWIqA P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool hEivpfthTUQoppxlEBukMuwBKTfi(wVrBeahRaXcXzwjLjufKsFgdWIqA P_0, wVrBeahRaXcXzwjLjufKsFgdWIqA P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string NKkCmMIfvNDyisixcMrugxkeNsWBb()
	{
		return $"({FvzVtjEuSmvDiGSOuVCSYytmTlQC},{bxsEzYFHNDhbzvNPUftFhtWDdNbO})";
	}
}
