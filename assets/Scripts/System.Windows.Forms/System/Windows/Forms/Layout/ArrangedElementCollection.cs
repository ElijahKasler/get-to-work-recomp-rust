using System.Collections;

namespace System.Windows.Forms.Layout;

public class ArrangedElementCollection : IList, ICollection, IEnumerable
{
	internal ArrayList list;

	public virtual int Count => list.Count;

	public virtual bool IsReadOnly => list.IsReadOnly;

	bool IList.IsFixedSize => IsFixedSize;

	internal bool IsFixedSize => list.IsFixedSize;

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			this[index] = value;
		}
	}

	internal object this[int index]
	{
		get
		{
			return list[index];
		}
		set
		{
			list[index] = value;
		}
	}

	bool ICollection.IsSynchronized => list.IsSynchronized;

	object ICollection.SyncRoot => list.IsSynchronized;

	internal ArrangedElementCollection()
	{
		list = new ArrayList();
	}

	public void CopyTo(Array array, int index)
	{
		list.CopyTo(array, index);
	}

	public override bool Equals(object obj)
	{
		if (obj is ArrangedElementCollection && this == obj)
		{
			return true;
		}
		return false;
	}

	public virtual IEnumerator GetEnumerator()
	{
		return list.GetEnumerator();
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	int IList.Add(object value)
	{
		return Add(value);
	}

	internal int Add(object value)
	{
		return list.Add(value);
	}

	void IList.Clear()
	{
		Clear();
	}

	internal void Clear()
	{
		list.Clear();
	}

	bool IList.Contains(object value)
	{
		return Contains(value);
	}

	internal bool Contains(object value)
	{
		return list.Contains(value);
	}

	int IList.IndexOf(object value)
	{
		return IndexOf(value);
	}

	internal int IndexOf(object value)
	{
		return list.IndexOf(value);
	}

	void IList.Insert(int index, object value)
	{
		throw new NotSupportedException();
	}

	internal void Insert(int index, object value)
	{
		list.Insert(index, value);
	}

	void IList.Remove(object value)
	{
		Remove(value);
	}

	internal void Remove(object value)
	{
		list.Remove(value);
	}

	void IList.RemoveAt(int index)
	{
		list.RemoveAt(index);
	}

	internal void InternalRemoveAt(int index)
	{
		list.RemoveAt(index);
	}
}
