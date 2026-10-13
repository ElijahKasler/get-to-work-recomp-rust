using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal sealed class lVvaRWFpPRDdIEUiIKNGBOwxeQgw<_0001> where _0001 : class
{
	private const float TlsilhyrsjToeyapYcjMGLTtoQHjA = 60f;

	private readonly IndexedDictionary<Bytes20, List<WeakReference>> tFNCIuCTCKoAmBZoFpJzaQvOqmyiB;

	private float fNgrLGSxOBGuBzqMwEUCBEkfhdLdb;

	private double bvtBEKyjcHlhwFyGKiHmtHkRfUer;

	private Func<_0001, _0001, bool> RPGcftbrEKSlcbRtIdonLlyLNDNDB;

	public float GnBXJeaDmzUVitGKTnouQarzxPej
	{
		get
		{
			return wKmuOXTKsbaNJHPbezytEZHDIOvV();
		}
		set
		{
			cJnAwhvKlMoBhKlrxgqBEsqqzHEhA(num);
		}
	}

	public float wKmuOXTKsbaNJHPbezytEZHDIOvV()
	{
		return fNgrLGSxOBGuBzqMwEUCBEkfhdLdb;
	}

	public void cJnAwhvKlMoBhKlrxgqBEsqqzHEhA(float P_0)
	{
		if (P_0 < 0f)
		{
			P_0 = 0f;
		}
		fNgrLGSxOBGuBzqMwEUCBEkfhdLdb = P_0;
	}

	public lVvaRWFpPRDdIEUiIKNGBOwxeQgw(Func<_0001, _0001, bool> P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		RPGcftbrEKSlcbRtIdonLlyLNDNDB = P_0;
		fNgrLGSxOBGuBzqMwEUCBEkfhdLdb = 60f;
		tFNCIuCTCKoAmBZoFpJzaQvOqmyiB = new IndexedDictionary<Bytes20, List<WeakReference>>();
		tFNCIuCTCKoAmBZoFpJzaQvOqmyiB.KeyComparer = EqualityComparerNoAlloc<Bytes20>.Default;
	}

	public _0001 KfGfCFQYIBUUThUqDQAwAPjENAiG(Bytes20 P_0, _0001 P_1)
	{
		if (elHbnypVRYAnmLgDxxneJfNHjcbfA(P_0, P_1, out var result))
		{
			return result;
		}
		RHHrLiuKFpjNWsGCNIVkgVcHmmlzA(P_0, P_1);
		return P_1;
	}

	public bool elHbnypVRYAnmLgDxxneJfNHjcbfA(Bytes20 P_0, _0001 P_1, out _0001 P_2)
	{
		if (P_1 == null)
		{
			P_2 = null;
			return false;
		}
		LAyaZjixHaeWbvGQwfIpEBGnJyFnA();
		if (!tFNCIuCTCKoAmBZoFpJzaQvOqmyiB.TryGetValue(P_0, out var value))
		{
			P_2 = null;
			return false;
		}
		for (int num = value.Count - 1; num >= 0; num--)
		{
			if (!(value[num].Target is _0001 val))
			{
				value.RemoveAt(num);
			}
			else if (RPGcftbrEKSlcbRtIdonLlyLNDNDB(P_1, val))
			{
				P_2 = val;
				return true;
			}
		}
		P_2 = null;
		return false;
	}

	public void RHHrLiuKFpjNWsGCNIVkgVcHmmlzA(Bytes20 P_0, _0001 P_1)
	{
		if (P_1 != null)
		{
			LAyaZjixHaeWbvGQwfIpEBGnJyFnA();
			if (!tFNCIuCTCKoAmBZoFpJzaQvOqmyiB.TryGetValue(P_0, out var value))
			{
				value = new List<WeakReference>();
				tFNCIuCTCKoAmBZoFpJzaQvOqmyiB.Add(P_0, value);
			}
			value.Add(new WeakReference(P_1, trackResurrection: false));
		}
	}

	public void lMHHUDaFiwCJxRZQUrMtyMeXmOCQ()
	{
		for (int num = tFNCIuCTCKoAmBZoFpJzaQvOqmyiB.get_Count() - 1; num >= 0; num--)
		{
			List<WeakReference> list = tFNCIuCTCKoAmBZoFpJzaQvOqmyiB[num];
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				if (!list[num2].IsAlive)
				{
					list.RemoveAt(num2);
				}
			}
			if (list.Count == 0)
			{
				tFNCIuCTCKoAmBZoFpJzaQvOqmyiB.RemoveAt(num);
			}
		}
		bvtBEKyjcHlhwFyGKiHmtHkRfUer = ReInput.unscaledTime + (double)wKmuOXTKsbaNJHPbezytEZHDIOvV();
	}

	private void LAyaZjixHaeWbvGQwfIpEBGnJyFnA()
	{
		if (fNgrLGSxOBGuBzqMwEUCBEkfhdLdb != 0f && !(ReInput.unscaledTime < bvtBEKyjcHlhwFyGKiHmtHkRfUer))
		{
			lMHHUDaFiwCJxRZQUrMtyMeXmOCQ();
		}
	}
}
