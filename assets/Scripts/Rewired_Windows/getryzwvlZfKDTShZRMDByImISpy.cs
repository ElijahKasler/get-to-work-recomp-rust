using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

[DefaultMember("Item")]
internal class getryzwvlZfKDTShZRMDByImISpy<_0001> : weIOGHMeHzZYmDxvMaPHACkAuUVv, ICollection<_0001>, IEnumerable<_0001>, IEnumerable, global::AyfjHuTLAYhaxiEixiOJZonRanlDb<_0001>, global::JJwlhDQYTsrKmbxehHhBWHyJYkvN<_0001> where _0001 : jXvqCPffNunnFSUKumhMtKdivnAg
{
	public struct GvkhHWLALqmIprbiBfIwfRIhsvci : IEnumerator<_0001>, IEnumerator, IDisposable
	{
		private global::getryzwvlZfKDTShZRMDByImISpy<_0001> IQhYhcCHokKUErhPhOCtqxdramDU;

		private int haJILehfljSQlsdKnLiyUgFMeUVCb;

		private _0001 agdOdjKBWNsZaWkGXETgjyInwPmK;

		_0001 IEnumerator<_0001>.Current => get_Current();

		object IEnumerator.Current
		{
			get
			{
				if (haJILehfljSQlsdKnLiyUgFMeUVCb == 0 || haJILehfljSQlsdKnLiyUgFMeUVCb == IQhYhcCHokKUErhPhOCtqxdramDU.get_Count() + 1)
				{
					throw new InvalidOperationException();
				}
				return get_Current();
			}
		}

		internal GvkhHWLALqmIprbiBfIwfRIhsvci(global::getryzwvlZfKDTShZRMDByImISpy<_0001> P_0)
		{
			IQhYhcCHokKUErhPhOCtqxdramDU = P_0;
			haJILehfljSQlsdKnLiyUgFMeUVCb = 0;
			agdOdjKBWNsZaWkGXETgjyInwPmK = default;
		}

		public void Dispose()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		public bool MoveNext()
		{
			global::getryzwvlZfKDTShZRMDByImISpy<_0001> iQhYhcCHokKUErhPhOCtqxdramDU = IQhYhcCHokKUErhPhOCtqxdramDU;
			if ((uint)haJILehfljSQlsdKnLiyUgFMeUVCb < (uint)iQhYhcCHokKUErhPhOCtqxdramDU.get_Count())
			{
				agdOdjKBWNsZaWkGXETgjyInwPmK = iQhYhcCHokKUErhPhOCtqxdramDU.OilWnmyPqjXEYOaoXwDIIQINdGIn(haJILehfljSQlsdKnLiyUgFMeUVCb);
				haJILehfljSQlsdKnLiyUgFMeUVCb++;
				return true;
			}
			return XPrdzDHxLdGoHRQLomOlBggJJaPU();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private bool XPrdzDHxLdGoHRQLomOlBggJJaPU()
		{
			haJILehfljSQlsdKnLiyUgFMeUVCb = IQhYhcCHokKUErhPhOCtqxdramDU.get_Count() + 1;
			agdOdjKBWNsZaWkGXETgjyInwPmK = default;
			return false;
		}

		public _0001 get_Current()
		{
			return agdOdjKBWNsZaWkGXETgjyInwPmK;
		}

		void IEnumerator.Reset()
		{
			haJILehfljSQlsdKnLiyUgFMeUVCb = 0;
			agdOdjKBWNsZaWkGXETgjyInwPmK = default;
		}
	}

	private Func<IntPtr, uint> pXcshIdTxpnjOxxOdjlavjrRzmBu;

	private Func<IntPtr, uint, _0001> edCausHavHEyWZntTmskVPcgfjtC;

	int global::JJwlhDQYTsrKmbxehHhBWHyJYkvN<_0001>.Count => get_Count();

	bool ICollection<_0001>.IsReadOnly => get_IsReadOnly();

	// C# has no syntax for parameterized property 'AyfjHuTLAYhaxiEixiOJZonRanlDb<>.OilWnmyPqjXEYOaoXwDIIQINdGIn'.
	_0001 global::AyfjHuTLAYhaxiEixiOJZonRanlDb<_0001>.get_OilWnmyPqjXEYOaoXwDIIQINdGIn(int P_0)
	{
		return OilWnmyPqjXEYOaoXwDIIQINdGIn(P_0);
	}

	public void AyfjHuTLAYhaxiEixiOJZonRanlDb_003C_0001_003E_002Eset_OilWnmyPqjXEYOaoXwDIIQINdGIn(int P_0, _0001 P_1)
	{
		hccIAvelTRHGzdOqUSpkJVvNArFd(num, val);
	}

	public getryzwvlZfKDTShZRMDByImISpy(OiIxXJaWHgywcVCbFIsRHGrTvjHG P_0, Func<IntPtr, uint> P_1, Func<IntPtr, uint, _0001> P_2)
		: base(P_0)
	{
		pXcshIdTxpnjOxxOdjlavjrRzmBu = P_1;
		edCausHavHEyWZntTmskVPcgfjtC = P_2;
	}

	public int bOmbdjSCKNkOvlifNjYVANRGHhxu(_0001 P_0)
	{
		int count = get_Count();
		for (int i = 0; i < count; i++)
		{
			_0001 x = OilWnmyPqjXEYOaoXwDIIQINdGIn(i);
			bool num = EqualityComparer<_0001>.Default.Equals(x, P_0);
			x.MgjjQDgztetiXAtlDTtQCqsvoxAm();
			if (num)
			{
				return i;
			}
		}
		return -1;
	}

	public void Add(_0001 item)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	void ICollection<_0001>.Add(_0001 item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Add
		this.Add(item);
	}

	public void Clear()
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	void ICollection<_0001>.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	public bool Contains(_0001 item)
	{
		return bOmbdjSCKNkOvlifNjYVANRGHhxu(item) >= 0;
	}

	bool ICollection<_0001>.Contains(_0001 item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Contains
		return this.Contains(item);
	}

	public void CopyTo(_0001[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex < 0 || arrayIndex >= array.Length)
		{
			throw new ArgumentOutOfRangeException("arrayIndex");
		}
		int count = get_Count();
		for (int i = 0; i < count; i++)
		{
			array[i + arrayIndex] = OilWnmyPqjXEYOaoXwDIIQINdGIn(i);
		}
	}

	void ICollection<_0001>.CopyTo(_0001[] array, int arrayIndex)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CopyTo
		this.CopyTo(array, arrayIndex);
	}

	public int get_Count()
	{
		if (!XOXDzYbqhLEISedrquQcDVFBFTnEb.HilwYkrLgNPPlOpcXLoimAPdNwXg())
		{
			return 0;
		}
		return (int)pXcshIdTxpnjOxxOdjlavjrRzmBu(XOXDzYbqhLEISedrquQcDVFBFTnEb.vdYeCXIyOnISRLZwtXmDMQAkNMDUA);
	}

	public bool get_IsReadOnly()
	{
		return true;
	}

	public bool Remove(_0001 item)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	bool ICollection<_0001>.Remove(_0001 item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Remove
		return this.Remove(item);
	}

	public IEnumerator<_0001> GetEnumerator()
	{
		return new GvkhHWLALqmIprbiBfIwfRIhsvci(this);
	}

	IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void MsZYstDwZUHMGuCpTwuaxRYcriXt(int P_0, _0001 P_1)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	public void hkiGXbEicGendjucfxBdVCtrhMKhB(int P_0)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	public _0001 OilWnmyPqjXEYOaoXwDIIQINdGIn(int P_0)
	{
		if (P_0 < 0 || P_0 >= get_Count())
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (!XOXDzYbqhLEISedrquQcDVFBFTnEb.HilwYkrLgNPPlOpcXLoimAPdNwXg())
		{
			return default;
		}
		return edCausHavHEyWZntTmskVPcgfjtC(XOXDzYbqhLEISedrquQcDVFBFTnEb.vdYeCXIyOnISRLZwtXmDMQAkNMDUA, (uint)P_0);
	}

	public void hccIAvelTRHGzdOqUSpkJVvNArFd(int P_0, _0001 P_1)
	{
		throw new NotImplementedException("Collection is read-only!");
	}
}
