using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data;

[DefaultMember("Item")]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal sealed class ReadOnlyList<T> : Rewired.Utils.Interfaces.IReadOnlyList<T>, IReadOnlyList, IEnumerable<T>, IEnumerable
{
	private readonly IList<T> OctCJoakTtVXucYZoZxRARqreSWC;

	int IReadOnlyList.Count => get_Count();

	T Rewired.Utils.Interfaces.IReadOnlyList<T>.this[int index] => get_Item(index);

	object IReadOnlyList.this[int P_0] => pNDwLnkgIaJamDJzoRTfVLrPgJd(P_0);

	public int get_Count()
	{
		return OctCJoakTtVXucYZoZxRARqreSWC.Count;
	}

	public ReadOnlyList(IList<T> P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		OctCJoakTtVXucYZoZxRARqreSWC = P_0;
	}

	public ReadOnlyList(ReadOnlyList<T> P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException();
		}
		OctCJoakTtVXucYZoZxRARqreSWC = new List<T>(P_0.OctCJoakTtVXucYZoZxRARqreSWC);
	}

	public T get_Item(int index)
	{
		return OctCJoakTtVXucYZoZxRARqreSWC[index];
	}

	public bool Contains(T value)
	{
		return OctCJoakTtVXucYZoZxRARqreSWC.Contains(value);
	}

	bool Rewired.Utils.Interfaces.IReadOnlyList<T>.Contains(T value)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Contains
		return this.Contains(value);
	}

	public int IndexOf(T value)
	{
		return OctCJoakTtVXucYZoZxRARqreSWC.IndexOf(value);
	}

	int Rewired.Utils.Interfaces.IReadOnlyList<T>.IndexOf(T value)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IndexOf
		return this.IndexOf(value);
	}

	public void CopyTo(IList<T> destination)
	{
		if (destination == null)
		{
			throw new ArgumentNullException();
		}
		for (int i = 0; i < OctCJoakTtVXucYZoZxRARqreSWC.Count; i++)
		{
			destination.Add(OctCJoakTtVXucYZoZxRARqreSWC[i]);
		}
	}

	private object pNDwLnkgIaJamDJzoRTfVLrPgJd(int P_0)
	{
		return (this as IList)[P_0];
	}

	private int LdslANFEusxvQjRxdABYHnAvIFqB(object P_0)
	{
		return (this as IList).IndexOf(P_0);
	}

	int IReadOnlyList.IndexOf(object P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in LdslANFEusxvQjRxdABYHnAvIFqB
		return this.LdslANFEusxvQjRxdABYHnAvIFqB(P_0);
	}

	private bool ULdWBqJGHgGkDCAHcLzyijBeomyB(object P_0)
	{
		return (this as IList).Contains(P_0);
	}

	bool IReadOnlyList.Contains(object P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ULdWBqJGHgGkDCAHcLzyijBeomyB
		return this.ULdWBqJGHgGkDCAHcLzyijBeomyB(P_0);
	}

	private IEnumerator<T> qStwUBvZxfFsmWqhEmDzaYYgbdLk()
	{
		return OctCJoakTtVXucYZoZxRARqreSWC.GetEnumerator();
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in qStwUBvZxfFsmWqhEmDzaYYgbdLk
		return this.qStwUBvZxfFsmWqhEmDzaYYgbdLk();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return OctCJoakTtVXucYZoZxRARqreSWC.GetEnumerator();
	}
}
