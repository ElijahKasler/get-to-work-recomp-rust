using System.Collections;
using System.Collections.Generic;

namespace System.Windows.Forms;

internal class TabStopCollection : IList<TabStop>, ICollection<TabStop>, IEnumerable<TabStop>, IEnumerable
{
	private SortedList<TabStop, TabStop> tabs = new SortedList<TabStop, TabStop>();

	public TabStop this[int index]
	{
		get
		{
			return tabs.Keys[index];
		}
		set
		{
			throw new NotSupportedException("Not relevant to sorted data!");
		}
	}

	public int Count => tabs.Count;

	bool ICollection<TabStop>.IsReadOnly => false;

	public TabStopCollection Clone()
	{
		TabStopCollection tabStopCollection = new TabStopCollection();
		foreach (TabStop key in tabs.Keys)
		{
			tabStopCollection.tabs.Add(key, null);
		}
		return tabStopCollection;
	}

	public int IndexOf(TabStop tab)
	{
		return tabs.IndexOfKey(tab);
	}

	public void Insert(int index, TabStop item)
	{
		throw new NotSupportedException("Not relevant to sorted data!");
	}

	public void RemoveAt(int index)
	{
		tabs.RemoveAt(index);
	}

	public void Add(TabStop tab)
	{
		tabs.Add(tab, null);
	}

	public void Clear()
	{
		tabs.Clear();
	}

	public bool Contains(TabStop tab)
	{
		return tabs.ContainsKey(tab);
	}

	public void CopyTo(TabStop[] array, int arrayIndex)
	{
		tabs.Keys.CopyTo(array, arrayIndex);
	}

	public TabStop[] ToArray()
	{
		TabStop[] array = new TabStop[Count];
		CopyTo(array, 0);
		return array;
	}

	public int[] ToPosArray()
	{
		int[] array = new int[Count];
		for (int i = 0; i < Count; i++)
		{
			array[i] = (int)this[i].Position;
		}
		return array;
	}

	public bool Remove(TabStop tab)
	{
		return tabs.Remove(tab);
	}

	public IEnumerator<TabStop> GetEnumerator()
	{
		return tabs.Keys.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public override bool Equals(object obj)
	{
		if (!(obj is TabStopCollection tabStopCollection) || tabStopCollection.Count != Count)
		{
			return false;
		}
		for (int i = 0; i < Count; i++)
		{
			if (!tabs.Keys[i].Equals(tabStopCollection.tabs.Keys[i]))
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
