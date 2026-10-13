using System;
using Rewired;
using Rewired.Utils.Classes.Data;

internal sealed class ryIhzsVlAEsLECaOCXNjQXaqFkgN<_0001> where _0001 : class
{
	private readonly IndexedDictionary<uint, WeakReference> dorpbowEXUGEImMWKcHPMjPNzjrH;

	private Id wNTxcUfheHDAPgExRpBgugragdvJA;

	private double hrHCVGJwFTPJgRZiGHmGdSHqJjic;

	private float wwAdDFQaRDJHWYAlFoZeBSohgkkV;

	public ryIhzsVlAEsLECaOCXNjQXaqFkgN()
	{
		dorpbowEXUGEImMWKcHPMjPNzjrH = new IndexedDictionary<uint, WeakReference>();
		wNTxcUfheHDAPgExRpBgugragdvJA = 1u;
	}

	public ryIhzsVlAEsLECaOCXNjQXaqFkgN(float P_0)
		: this()
	{
		wwAdDFQaRDJHWYAlFoZeBSohgkkV = P_0;
	}

	public bool dHgfrzYUERDHsxwsTZnyxLBijFvIA(uint P_0, out _0001 P_1)
	{
		if (!dorpbowEXUGEImMWKcHPMjPNzjrH.TryGetValue(P_0, out var value))
		{
			P_1 = null;
			return false;
		}
		if (!(value.Target is _0001 val))
		{
			dorpbowEXUGEImMWKcHPMjPNzjrH.Remove(P_0);
			P_1 = null;
			return false;
		}
		P_1 = val;
		return true;
	}

	public uint CdQZufWqAaySgdITWKgIsAFgeFnC(_0001 P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		wqwptnYMgjaLxSjOkeUJfINHkhSDA();
		dorpbowEXUGEImMWKcHPMjPNzjrH.SetValue(wNTxcUfheHDAPgExRpBgugragdvJA.id, new WeakReference(P_0, trackResurrection: false));
		wNTxcUfheHDAPgExRpBgugragdvJA.Increment();
		return wNTxcUfheHDAPgExRpBgugragdvJA.id;
	}

	public bool XYjegXfbbJnPwpUsUjiFhfTEYDxgB(uint P_0)
	{
		wqwptnYMgjaLxSjOkeUJfINHkhSDA();
		return dorpbowEXUGEImMWKcHPMjPNzjrH.Remove(P_0);
	}

	public void dPkGFrUOlaXtNURVumddsygcZGBF()
	{
		for (int num = dorpbowEXUGEImMWKcHPMjPNzjrH.get_Count() - 1; num >= 0; num--)
		{
			if (!dorpbowEXUGEImMWKcHPMjPNzjrH[num].IsAlive)
			{
				dorpbowEXUGEImMWKcHPMjPNzjrH.RemoveAt(num);
			}
		}
		hrHCVGJwFTPJgRZiGHmGdSHqJjic = ReInput.unscaledTime + (double)wwAdDFQaRDJHWYAlFoZeBSohgkkV;
	}

	public void ZTfkwBcCbmWdTftlvIeaWRYDhlLDA(Action<_0001> P_0)
	{
		for (int num = dorpbowEXUGEImMWKcHPMjPNzjrH.get_Count() - 1; num >= 0; num--)
		{
			if (!(dorpbowEXUGEImMWKcHPMjPNzjrH[num].Target is _0001 obj))
			{
				dorpbowEXUGEImMWKcHPMjPNzjrH.RemoveAt(num);
			}
			else
			{
				P_0(obj);
			}
		}
		hrHCVGJwFTPJgRZiGHmGdSHqJjic = ReInput.unscaledTime + (double)wwAdDFQaRDJHWYAlFoZeBSohgkkV;
	}

	private void wqwptnYMgjaLxSjOkeUJfINHkhSDA()
	{
		if (!(wwAdDFQaRDJHWYAlFoZeBSohgkkV <= 0f) && ReInput.unscaledTime > hrHCVGJwFTPJgRZiGHmGdSHqJjic)
		{
			dPkGFrUOlaXtNURVumddsygcZGBF();
		}
	}
}
