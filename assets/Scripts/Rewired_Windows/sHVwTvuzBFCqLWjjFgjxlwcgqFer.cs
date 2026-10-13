using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[DefaultMember("Item")]
internal struct sHVwTvuzBFCqLWjjFgjxlwcgqFer : IEquatable<sHVwTvuzBFCqLWjjFgjxlwcgqFer>, IFormattable
{
	public static readonly int gBhLTupxdajQbaWQlPZGrSeieCJE = Marshal.SizeOf(typeof(sHVwTvuzBFCqLWjjFgjxlwcgqFer));

	public static readonly sHVwTvuzBFCqLWjjFgjxlwcgqFer oeXuzzgALYaKEtoinIagBrwTfbLCb = default;

	public static readonly sHVwTvuzBFCqLWjjFgjxlwcgqFer ZpdCpQZvvlGcQMxvmBtHXtXEQhIr = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(1f, 0f);

	public static readonly sHVwTvuzBFCqLWjjFgjxlwcgqFer WFZuFplcFqXYGJNtJQOUMILtUQjQ = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(0f, 1f);

	public static readonly sHVwTvuzBFCqLWjjFgjxlwcgqFer woxvqjXvWIBMcQZZQhydsnaVoOEG = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(1f, 1f);

	public float CsBnIzHvzwNjjXWIGadThfHMWeiV;

	public float fxUSJUuSDyAySMSEIikbgUGTJvcD;

	public bool PdoAcrbopJguvnxyURHjIpkGWXMZ => otBlTVgzATrBwjopYYsqacmJPcdE();

	public bool LdugtOBEczmHTrBuhrXqiKXwgHxG => PmhGIKrdzdJrFShtYkWYGjdfTcKp();

	// C# has no syntax for parameterized property 'TRQYmpHWNjJfRFjDNhlZZNzClDoo'.
	public float get_TRQYmpHWNjJfRFjDNhlZZNzClDoo(int P_0)
	{
		return rHlnfvchFAlhebLrMqJorNaNBynf(P_0);
	}

	public void set_TRQYmpHWNjJfRFjDNhlZZNzClDoo(int P_0, float P_1)
	{
		zzLAjWxkoYHwrciFLXCDHygDSrsJ(num, num2);
	}

	public sHVwTvuzBFCqLWjjFgjxlwcgqFer(float P_0)
	{
		CsBnIzHvzwNjjXWIGadThfHMWeiV = P_0;
		fxUSJUuSDyAySMSEIikbgUGTJvcD = P_0;
	}

	public sHVwTvuzBFCqLWjjFgjxlwcgqFer(float P_0, float P_1)
	{
		CsBnIzHvzwNjjXWIGadThfHMWeiV = P_0;
		fxUSJUuSDyAySMSEIikbgUGTJvcD = P_1;
	}

	public sHVwTvuzBFCqLWjjFgjxlwcgqFer(float[] P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("values");
		}
		if (P_0.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		CsBnIzHvzwNjjXWIGadThfHMWeiV = P_0[0];
		fxUSJUuSDyAySMSEIikbgUGTJvcD = P_0[1];
	}

	public bool otBlTVgzATrBwjopYYsqacmJPcdE()
	{
		return CHyTxIymRTDKqPmmnvtShKOtmySC.vEjayXFHAdpPSCKytMtddgNmAqEEA(CsBnIzHvzwNjjXWIGadThfHMWeiV * CsBnIzHvzwNjjXWIGadThfHMWeiV + fxUSJUuSDyAySMSEIikbgUGTJvcD * fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public bool PmhGIKrdzdJrFShtYkWYGjdfTcKp()
	{
		if (CsBnIzHvzwNjjXWIGadThfHMWeiV == 0f)
		{
			return fxUSJUuSDyAySMSEIikbgUGTJvcD == 0f;
		}
		return false;
	}

	public float rHlnfvchFAlhebLrMqJorNaNBynf(int P_0)
	{
		return P_0 switch
		{
			0 => CsBnIzHvzwNjjXWIGadThfHMWeiV, 
			1 => fxUSJUuSDyAySMSEIikbgUGTJvcD, 
			_ => throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive."), 
		};
	}

	public void zzLAjWxkoYHwrciFLXCDHygDSrsJ(int P_0, float P_1)
	{
		switch (P_0)
		{
		case 0:
			CsBnIzHvzwNjjXWIGadThfHMWeiV = P_1;
			break;
		case 1:
			fxUSJUuSDyAySMSEIikbgUGTJvcD = P_1;
			break;
		default:
			throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
		}
	}

	public float REDFHHcuYMoHGXDkIsKNvIKsKhqEb()
	{
		return (float)Math.Sqrt(CsBnIzHvzwNjjXWIGadThfHMWeiV * CsBnIzHvzwNjjXWIGadThfHMWeiV + fxUSJUuSDyAySMSEIikbgUGTJvcD * fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public float kERFfDjBOQhFwNsQjSTtrbfRTjfJA()
	{
		return CsBnIzHvzwNjjXWIGadThfHMWeiV * CsBnIzHvzwNjjXWIGadThfHMWeiV + fxUSJUuSDyAySMSEIikbgUGTJvcD * fxUSJUuSDyAySMSEIikbgUGTJvcD;
	}

	public void NguJcWIwffNnbWQANJCLmKNIFpVt()
	{
		float num = REDFHHcuYMoHGXDkIsKNvIKsKhqEb();
		if (!CHyTxIymRTDKqPmmnvtShKOtmySC.XVOsrxubfLpMbfPgGCvNbNYcePYXA(num))
		{
			float num2 = 1f / num;
			CsBnIzHvzwNjjXWIGadThfHMWeiV *= num2;
			fxUSJUuSDyAySMSEIikbgUGTJvcD *= num2;
		}
	}

	public float[] UfHdVwoOmKfxEsfNaqyOTtkpQPJr()
	{
		return new float[2] { CsBnIzHvzwNjjXWIGadThfHMWeiV, fxUSJUuSDyAySMSEIikbgUGTJvcD };
	}

	public static void XhszgQpBswOpnpTngRnxfUissKkI(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		P_2 = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV + P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD + P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer AGAEnnZLqyBgcdpLrpvpCEcXQWPy(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV + P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD + P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static void gPYQXmbWVLURyjxkcnGFFHjuEJtX(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref float P_1, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		P_2 = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV + P_1, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD + P_1);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer QvDRMJtFABvBKNTbqwYxxLchHwxM(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, float P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV + P_1, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD + P_1);
	}

	public static void HAPQEndQQRlnOYVNwNcfHGKsIbnZ(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		P_2 = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer LuFqiGjJrkARsYsJOShuyTGremci(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static void DfnSefVYVylZPCvNLqDhgpsePcJU(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref float P_1, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		P_2 = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_1, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_1);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer WVPthrIbdFbIBAqicgjNpgUoJcScb(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, float P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_1, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_1);
	}

	public static void TOkCxQGuiLNiWSOgUOVmaThknMvq(ref float P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		P_2 = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0 - P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0 - P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer ujcTTBhcutuvvevfmlAugAZLlEMg(float P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0 - P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0 - P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static void wQGBEEksMEnPyONnvcrOOHubsuLE(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, float P_1, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		P_2 = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV * P_1, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD * P_1);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer KmKXzCfjlJWMZUXNKfXkpiTDuxQr(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, float P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV * P_1, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD * P_1);
	}

	public static void tibaIhfpcUPpXNxyOtIckdaPCJPwA(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		P_2 = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV * P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD * P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer qnuOUhVoyBbfKgMQNnNNNpnvkTZvA(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV * P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD * P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static void rzSdEDBsucUEuQQUFvUtdjjBdljDA(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, float P_1, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		P_2 = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV / P_1, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD / P_1);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer tlpxxIPxkFTTCAEIxhsQimvENCJqA(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, float P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV / P_1, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD / P_1);
	}

	public static void IWvHmgruHehKejNsCsrSdNxNDKst(float P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		P_2 = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0 / P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0 / P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer GsiYusOfGQfMjNQzdfDFnCDBgczm(float P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0 / P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0 / P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static void zWBNeQNtNoAETfOebxpXBufvKHHO(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		P_1 = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(0f - P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV, 0f - P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer kVXKJRQaDdkkDQNQAxcHTDpkqxNk(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(0f - P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV, 0f - P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static void AmSRfekChfLXaLfxiEObygbKpOUQ(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2, float P_3, float P_4, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_5)
	{
		P_5 = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV + P_3 * (P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV) + P_4 * (P_2.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV), P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD + P_3 * (P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD) + P_4 * (P_2.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD));
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer ZAoTjUuEWcyQQgEevrPepCEmDiUA(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2, float P_3, float P_4)
	{
		AmSRfekChfLXaLfxiEObygbKpOUQ(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void tqfgfLfjIViiSfsDgIUjyLeCpVvnb(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_3)
	{
		float csBnIzHvzwNjjXWIGadThfHMWeiV = P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV;
		csBnIzHvzwNjjXWIGadThfHMWeiV = ((csBnIzHvzwNjjXWIGadThfHMWeiV > P_2.CsBnIzHvzwNjjXWIGadThfHMWeiV) ? P_2.CsBnIzHvzwNjjXWIGadThfHMWeiV : csBnIzHvzwNjjXWIGadThfHMWeiV);
		csBnIzHvzwNjjXWIGadThfHMWeiV = ((csBnIzHvzwNjjXWIGadThfHMWeiV < P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV) ? P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV : csBnIzHvzwNjjXWIGadThfHMWeiV);
		float num = P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD;
		num = ((num > P_2.fxUSJUuSDyAySMSEIikbgUGTJvcD) ? P_2.fxUSJUuSDyAySMSEIikbgUGTJvcD : num);
		num = ((num < P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD) ? P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD : num);
		P_3 = new sHVwTvuzBFCqLWjjFgjxlwcgqFer(csBnIzHvzwNjjXWIGadThfHMWeiV, num);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer dgwAxYhdeypsOUeqRMajQYZDSSzn(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		tqfgfLfjIViiSfsDgIUjyLeCpVvnb(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void VoOKNrqzGdDJbfeUBsugdQQBmSUM()
	{
		CsBnIzHvzwNjjXWIGadThfHMWeiV = ((CsBnIzHvzwNjjXWIGadThfHMWeiV < 0f) ? 0f : ((CsBnIzHvzwNjjXWIGadThfHMWeiV > 1f) ? 1f : CsBnIzHvzwNjjXWIGadThfHMWeiV));
		fxUSJUuSDyAySMSEIikbgUGTJvcD = ((fxUSJUuSDyAySMSEIikbgUGTJvcD < 0f) ? 0f : ((fxUSJUuSDyAySMSEIikbgUGTJvcD > 1f) ? 1f : fxUSJUuSDyAySMSEIikbgUGTJvcD));
	}

	public static void hLjhRfDvXNwzWUXvRgahNTOTNypC(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, out float P_2)
	{
		float num = P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV;
		float num2 = P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float xrIHAhCNTLSkjPnwAfsDpfGklBMw(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		float num = P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV;
		float num2 = P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void XoCLQutgVqLrooNjTgQCvZEzgATW(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, out float P_2)
	{
		float num = P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV;
		float num2 = P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD;
		P_2 = num * num + num2 * num2;
	}

	public static float KQzhhRxCNKunWqsBMJcQEEVrJeCW(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		float num = P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV;
		float num2 = P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD;
		return num * num + num2 * num2;
	}

	public static void sCkEIgGGTALYCGaqxhxmDGSwUvRcb(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, out float P_2)
	{
		P_2 = P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV * P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV + P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD * P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD;
	}

	public static float TPXNgLynRKEOVZppGhspaCuvdBWzA(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV * P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV + P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD * P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD;
	}

	public static void AQFdmdRSBqHQiHDPLUKFwSIDpjsw(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		P_1 = P_0;
		P_1.NguJcWIwffNnbWQANJCLmKNIFpVt();
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer GqQLVSMDyqHazdlhaKavvoHvEDpu(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0)
	{
		P_0.NguJcWIwffNnbWQANJCLmKNIFpVt();
		return P_0;
	}

	public static void DrnDEeeFIySOXIShnOuYbKgXigUh(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, float P_2, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_3)
	{
		P_3.CsBnIzHvzwNjjXWIGadThfHMWeiV = CHyTxIymRTDKqPmmnvtShKOtmySC.hohJBGQklCOFxjKugZWLQkoBjuQj(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_2);
		P_3.fxUSJUuSDyAySMSEIikbgUGTJvcD = CHyTxIymRTDKqPmmnvtShKOtmySC.hohJBGQklCOFxjKugZWLQkoBjuQj(P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD, P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD, P_2);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer ZWhFhBjkRHyxBagOlQYLunJVQrFw(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, float P_2)
	{
		DrnDEeeFIySOXIShnOuYbKgXigUh(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void lZdCMzqHnmdmcHunUZyAUvCoiaJt(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, float P_2, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_3)
	{
		P_2 = CHyTxIymRTDKqPmmnvtShKOtmySC.BWvOGJAKzgPkOngEejYhYFiYEshiA(P_2);
		DrnDEeeFIySOXIShnOuYbKgXigUh(ref P_0, ref P_1, P_2, out P_3);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer URjSslEHXSgFeJWIxGwkGvEpXVMSA(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, float P_2)
	{
		lZdCMzqHnmdmcHunUZyAUvCoiaJt(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void pXcdoeMUXdTbBdXvfCaYNeoTZrTF(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_3, float P_4, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.CsBnIzHvzwNjjXWIGadThfHMWeiV = P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV * num3 + P_2.CsBnIzHvzwNjjXWIGadThfHMWeiV * num4 + P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV * num5 + P_3.CsBnIzHvzwNjjXWIGadThfHMWeiV * num6;
		P_5.fxUSJUuSDyAySMSEIikbgUGTJvcD = P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD * num3 + P_2.fxUSJUuSDyAySMSEIikbgUGTJvcD * num4 + P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD * num5 + P_3.fxUSJUuSDyAySMSEIikbgUGTJvcD * num6;
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer vrdImOGmGelUYxPylfzsErRMkZCH(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_3, float P_4)
	{
		pXcdoeMUXdTbBdXvfCaYNeoTZrTF(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void GpYGKzGhHrJdPGonBxSAYgGDuWLdb(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_3, float P_4, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.CsBnIzHvzwNjjXWIGadThfHMWeiV = 0.5f * (2f * P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV + (0f - P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV + P_2.CsBnIzHvzwNjjXWIGadThfHMWeiV) * P_4 + (2f * P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV - 5f * P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV + 4f * P_2.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_3.CsBnIzHvzwNjjXWIGadThfHMWeiV) * num + (0f - P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV + 3f * P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV - 3f * P_2.CsBnIzHvzwNjjXWIGadThfHMWeiV + P_3.CsBnIzHvzwNjjXWIGadThfHMWeiV) * num2);
		P_5.fxUSJUuSDyAySMSEIikbgUGTJvcD = 0.5f * (2f * P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD + (0f - P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD + P_2.fxUSJUuSDyAySMSEIikbgUGTJvcD) * P_4 + (2f * P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD - 5f * P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD + 4f * P_2.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_3.fxUSJUuSDyAySMSEIikbgUGTJvcD) * num + (0f - P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD + 3f * P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD - 3f * P_2.fxUSJUuSDyAySMSEIikbgUGTJvcD + P_3.fxUSJUuSDyAySMSEIikbgUGTJvcD) * num2);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer iQndZhxliuNePuePjSRDFXJaVZij(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_3, float P_4)
	{
		GpYGKzGhHrJdPGonBxSAYgGDuWLdb(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void ieVTSfCYdVnBXslDqTqQdPmABnPeA(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		P_2.CsBnIzHvzwNjjXWIGadThfHMWeiV = ((P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV > P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV) ? P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV : P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV);
		P_2.fxUSJUuSDyAySMSEIikbgUGTJvcD = ((P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD > P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD) ? P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD : P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer HretQVKCopLAXjyFLOkDUBYtGRWZ(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		ieVTSfCYdVnBXslDqTqQdPmABnPeA(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void JmOMBKDmHWbXZkLpckkFozizSusS(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		P_2.CsBnIzHvzwNjjXWIGadThfHMWeiV = ((P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV < P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV) ? P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV : P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV);
		P_2.fxUSJUuSDyAySMSEIikbgUGTJvcD = ((P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD < P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD) ? P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD : P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer gDMuXRJTjtDwFjuNlgIxWKoqRPAF(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		JmOMBKDmHWbXZkLpckkFozizSusS(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void pvohnUvJBRTxDWxYTxROsWSDZhiA(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1, out sHVwTvuzBFCqLWjjFgjxlwcgqFer P_2)
	{
		float num = P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV * P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV + P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD * P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD;
		P_2.CsBnIzHvzwNjjXWIGadThfHMWeiV = P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV - 2f * num * P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV;
		P_2.fxUSJUuSDyAySMSEIikbgUGTJvcD = P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD - 2f * num * P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD;
	}

	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer csMAKQjKYGqjefNZjMiObjzqSHYi(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		pvohnUvJBRTxDWxYTxROsWSDZhiA(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void rydyEwrgEJrhYrTXwzoDmOiCiUvE(sHVwTvuzBFCqLWjjFgjxlwcgqFer[] P_0, params sHVwTvuzBFCqLWjjFgjxlwcgqFer[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.Length < P_1.Length)
		{
			throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
		}
		for (int i = 0; i < P_1.Length; i++)
		{
			sHVwTvuzBFCqLWjjFgjxlwcgqFer sHVwTvuzBFCqLWjjFgjxlwcgqFer2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				sHVwTvuzBFCqLWjjFgjxlwcgqFer2 = lyGBwOcGxLTeofFaGSPibXtbeApWB(sHVwTvuzBFCqLWjjFgjxlwcgqFer2, cYdEUUFSOqFYCMwZJXUPevYfFwmEb(TPXNgLynRKEOVZppGhspaCuvdBWzA(P_0[j], sHVwTvuzBFCqLWjjFgjxlwcgqFer2) / TPXNgLynRKEOVZppGhspaCuvdBWzA(P_0[j], P_0[j]), P_0[j]));
			}
			P_0[i] = sHVwTvuzBFCqLWjjFgjxlwcgqFer2;
		}
	}

	public static void YMeexcJfcnMlncbqjaRVuNJKoJCG(sHVwTvuzBFCqLWjjFgjxlwcgqFer[] P_0, params sHVwTvuzBFCqLWjjFgjxlwcgqFer[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.Length < P_1.Length)
		{
			throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
		}
		for (int i = 0; i < P_1.Length; i++)
		{
			sHVwTvuzBFCqLWjjFgjxlwcgqFer sHVwTvuzBFCqLWjjFgjxlwcgqFer2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				sHVwTvuzBFCqLWjjFgjxlwcgqFer2 = lyGBwOcGxLTeofFaGSPibXtbeApWB(sHVwTvuzBFCqLWjjFgjxlwcgqFer2, cYdEUUFSOqFYCMwZJXUPevYfFwmEb(TPXNgLynRKEOVZppGhspaCuvdBWzA(P_0[j], sHVwTvuzBFCqLWjjFgjxlwcgqFer2), P_0[j]));
			}
			sHVwTvuzBFCqLWjjFgjxlwcgqFer2.NguJcWIwffNnbWQANJCLmKNIFpVt();
			P_0[i] = sHVwTvuzBFCqLWjjFgjxlwcgqFer2;
		}
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer HpsLaAGtZefDzocAEeXMxUFdEnvw(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV + P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD + P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer qDGeBWeCvPxvWacLTVtghJSLEhAOA(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV * P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD * P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer VGVjUPBcaYpXPLPMWNGBWzOExpSh(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0)
	{
		return P_0;
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer lyGBwOcGxLTeofFaGSPibXtbeApWB(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer gQPVNOHbvEsOyEZaHSOleUpgTHWd(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(0f - P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV, 0f - P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer cYdEUUFSOqFYCMwZJXUPevYfFwmEb(float P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV * P_0, P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD * P_0);
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer ZaRFCAbhlANJhZaSmJjnClOKurVNb(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, float P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV * P_1, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD * P_1);
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer XRicLldwqBSTfhcDcOPjRxOaDHTZ(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, float P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV / P_1, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD / P_1);
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer LcpEfmBqLiVbrIFijQHBrfbqCcEjb(float P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0 / P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0 / P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer RaoNRRECUuvXtRHSdwFSmvCxMBGD(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV / P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD / P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer UoeQcwLesofvKdpAARAyTxerykAr(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, float P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV + P_1, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD + P_1);
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer MqTEInuiPTWiWHWuoPGMflfCxhwb(float P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0 + P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0 + P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer swTrrdptoLsZBKdQfUlJVrglJIUG(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, float P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV - P_1, P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD - P_1);
	}

	[SpecialName]
	public static sHVwTvuzBFCqLWjjFgjxlwcgqFer JWdguwzwIXBmpyTfhzkBMEuDFJNx(float P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return new sHVwTvuzBFCqLWjjFgjxlwcgqFer(P_0 - P_1.CsBnIzHvzwNjjXWIGadThfHMWeiV, P_0 - P_1.fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	[SpecialName]
	public static bool kZdlTMZmrPnbHObZEPvbZvhRCEYS(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return P_0.KCmJMCRadOGUQBtyJKJaPsvmRLZH(ref P_1);
	}

	[SpecialName]
	public static bool GxuGJHwbXfURGQtYkKHnbPfBYuVt(sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0, sHVwTvuzBFCqLWjjFgjxlwcgqFer P_1)
	{
		return !P_0.KCmJMCRadOGUQBtyJKJaPsvmRLZH(ref P_1);
	}

	public string AVxBXYZFJAqoryHOAGUkdqdwrehvA()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", CsBnIzHvzwNjjXWIGadThfHMWeiV, fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public string OaeSpCtfMuDahAHZPyYcJBRGqFDc(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", CsBnIzHvzwNjjXWIGadThfHMWeiV.ToString(P_0, CultureInfo.CurrentCulture), fxUSJUuSDyAySMSEIikbgUGTJvcD.ToString(P_0, CultureInfo.CurrentCulture));
	}

	public string XBLuCnQKjKcVFDoUGKXyGAMgUktCc(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", CsBnIzHvzwNjjXWIGadThfHMWeiV, fxUSJUuSDyAySMSEIikbgUGTJvcD);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			XBLuCnQKjKcVFDoUGKXyGAMgUktCc(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", CsBnIzHvzwNjjXWIGadThfHMWeiV.ToString(format, formatProvider), fxUSJUuSDyAySMSEIikbgUGTJvcD.ToString(format, formatProvider));
	}

	string IFormattable.ToString(string format, IFormatProvider formatProvider)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ToString
		return this.ToString(format, formatProvider);
	}

	public int xKExkfGuORNpmBrGGTSwtKrlXcZx()
	{
		return (CsBnIzHvzwNjjXWIGadThfHMWeiV.GetHashCode() * 397) ^ fxUSJUuSDyAySMSEIikbgUGTJvcD.GetHashCode();
	}

	public bool KCmJMCRadOGUQBtyJKJaPsvmRLZH(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer P_0)
	{
		if (CHyTxIymRTDKqPmmnvtShKOtmySC.WvYJQOFRwxUoTiZHOINPXAINWGOC(P_0.CsBnIzHvzwNjjXWIGadThfHMWeiV, CsBnIzHvzwNjjXWIGadThfHMWeiV))
		{
			return CHyTxIymRTDKqPmmnvtShKOtmySC.WvYJQOFRwxUoTiZHOINPXAINWGOC(P_0.fxUSJUuSDyAySMSEIikbgUGTJvcD, fxUSJUuSDyAySMSEIikbgUGTJvcD);
		}
		return false;
	}

	public bool Equals(sHVwTvuzBFCqLWjjFgjxlwcgqFer other)
	{
		return KCmJMCRadOGUQBtyJKJaPsvmRLZH(ref other);
	}

	bool IEquatable<sHVwTvuzBFCqLWjjFgjxlwcgqFer>.Equals(sHVwTvuzBFCqLWjjFgjxlwcgqFer other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool FjLxnpXNcKJQWzwbfulhdnZLflVf(object P_0)
	{
		if (!(P_0 is sHVwTvuzBFCqLWjjFgjxlwcgqFer sHVwTvuzBFCqLWjjFgjxlwcgqFer2))
		{
			return false;
		}
		return KCmJMCRadOGUQBtyJKJaPsvmRLZH(ref sHVwTvuzBFCqLWjjFgjxlwcgqFer2);
	}
}
