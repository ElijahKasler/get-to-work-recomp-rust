using System.Collections;
using System.ComponentModel;
using Unity;

namespace System.Windows.Forms;

[ListBindable(false)]
public class DataGridViewSelectedColumnCollection : BaseCollection, IList, ICollection, IEnumerable
{
	bool IList.IsFixedSize => base.List.IsFixedSize;

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			throw new NotSupportedException("Can't insert or modify this collection.");
		}
	}

	public DataGridViewColumn this[int index] => (DataGridViewColumn)base.List[index];

	protected override ArrayList List => base.List;

	int ICollection.Count
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default;
		}
	}

	bool ICollection.IsSynchronized
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default;
		}
	}

	object ICollection.SyncRoot
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return null;
		}
	}

	bool IList.IsReadOnly
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default;
		}
	}

	internal DataGridViewSelectedColumnCollection()
	{
	}

	int IList.Add(object value)
	{
		throw new NotSupportedException("Can't add elements to this collection.");
	}

	void IList.Clear()
	{
		Clear();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void Clear()
	{
		throw new NotSupportedException("This collection cannot be cleared.");
	}

	bool IList.Contains(object value)
	{
		return Contains(value as DataGridViewColumn);
	}

	public bool Contains(DataGridViewColumn dataGridViewColumn)
	{
		return base.List.Contains(dataGridViewColumn);
	}

	public void CopyTo(DataGridViewColumn[] array, int index)
	{
		base.List.CopyTo(array, index);
	}

	int IList.IndexOf(object value)
	{
		return base.List.IndexOf(value);
	}

	void IList.Insert(int index, object value)
	{
		Insert(index, value as DataGridViewColumn);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void Insert(int index, DataGridViewColumn dataGridViewColumn)
	{
		throw new NotSupportedException("Insert is not allowed.");
	}

	void IList.Remove(object value)
	{
		throw new NotSupportedException("Can't remove elements of this collection.");
	}

	void IList.RemoveAt(int index)
	{
		throw new NotSupportedException("Can't remove elements of this collection.");
	}

	internal void InternalAdd(DataGridViewColumn dataGridViewColumn)
	{
		base.List.Add(dataGridViewColumn);
	}

	internal void InternalAddRange(DataGridViewSelectedColumnCollection columns)
	{
		if (columns != null)
		{
			for (int num = columns.Count - 1; num >= 0; num--)
			{
				base.List.Add(columns[num]);
			}
		}
	}

	internal void InternalClear()
	{
		List.Clear();
	}

	internal void InternalRemove(DataGridViewColumn dataGridViewColumn)
	{
		base.List.Remove(dataGridViewColumn);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
		return null;
	}
}
