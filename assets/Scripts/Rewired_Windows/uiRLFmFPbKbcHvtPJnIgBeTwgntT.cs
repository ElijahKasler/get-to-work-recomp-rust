using System.Collections;
using System.Collections.Generic;
using System.Reflection;

[DefaultMember("Item")]
internal sealed class uiRLFmFPbKbcHvtPJnIgBeTwgntT<_0001> : global::AyfjHuTLAYhaxiEixiOJZonRanlDb<_0001>, IEnumerable<_0001>, IEnumerable, global::JJwlhDQYTsrKmbxehHhBWHyJYkvN<_0001>
{
	private readonly List<_0001> STYjlbOOxrkxtlswNaMfONIsdiOD;

	// C# has no syntax for parameterized property 'AyfjHuTLAYhaxiEixiOJZonRanlDb<>.OilWnmyPqjXEYOaoXwDIIQINdGIn'.
	_0001 global::AyfjHuTLAYhaxiEixiOJZonRanlDb<_0001>.get_OilWnmyPqjXEYOaoXwDIIQINdGIn(int P_0)
	{
		return OilWnmyPqjXEYOaoXwDIIQINdGIn(P_0);
	}

	int global::JJwlhDQYTsrKmbxehHhBWHyJYkvN<_0001>.Count => get_Count();

	public uiRLFmFPbKbcHvtPJnIgBeTwgntT()
	{
		STYjlbOOxrkxtlswNaMfONIsdiOD = new List<_0001>();
	}

	public uiRLFmFPbKbcHvtPJnIgBeTwgntT(int P_0)
	{
		STYjlbOOxrkxtlswNaMfONIsdiOD = new List<_0001>(P_0);
	}

	public uiRLFmFPbKbcHvtPJnIgBeTwgntT(ICollection<_0001> P_0)
	{
		STYjlbOOxrkxtlswNaMfONIsdiOD = new List<_0001>(P_0);
	}

	public _0001 OilWnmyPqjXEYOaoXwDIIQINdGIn(int P_0)
	{
		return STYjlbOOxrkxtlswNaMfONIsdiOD[P_0];
	}

	public IEnumerator<_0001> GetEnumerator()
	{
		return STYjlbOOxrkxtlswNaMfONIsdiOD.GetEnumerator();
	}

	IEnumerator<_0001> IEnumerable<_0001>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return STYjlbOOxrkxtlswNaMfONIsdiOD.GetEnumerator();
	}

	public int get_Count()
	{
		return STYjlbOOxrkxtlswNaMfONIsdiOD.Count;
	}
}
