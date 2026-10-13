using System.Collections;
using System.ComponentModel;
using Unity;

namespace System.Windows.Forms;

[ListBindable(false)]
public class DataGridViewSelectedCellCollection : BaseCollection, IList, ICollection, IEnumerable
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
			throw new NotSupportedException();
		}
	}

	public DataGridViewCell this[int index] => (DataGridViewCell)base.List[index];

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

	internal DataGridViewSelectedCellCollection()
	{
	}

	int IList.Add(object value)
	{
		throw new NotSupportedException();
	}

	void IList.Clear()
	{
		Clear();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void Clear()
	{
		throw new NotSupportedException("Cannot clear this base.List");
	}

	bool IList.Contains(object value)
	{
		return Contains(value as DataGridViewCell);
	}

	public bool Contains(DataGridViewCell dataGridViewCell)
	{
		return base.List.Contains(dataGridViewCell);
	}

	public void CopyTo(DataGridViewCell[] array, int index)
	{
		base.List.CopyTo(array, index);
	}

	int IList.IndexOf(object value)
	{
		return base.List.IndexOf(value as DataGridViewCell);
	}

	void IList.Insert(int index, object value)
	{
		Insert(index, value as DataGridViewCell);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public void Insert(int index, DataGridViewCell dataGridViewCell)
	{
		throw new NotSupportedException("Can't insert to selected cell base.List");
	}

	void IList.Remove(object value)
	{
		throw new NotSupportedException("Can't remove elements of selected cell base.List.");
	}

	void IList.RemoveAt(int index)
	{
		throw new NotSupportedException("Can't remove elements of selected cell base.List.");
	}

	internal void InternalAdd(DataGridViewCell dataGridViewCell)
	{
		base.List.Add(dataGridViewCell);
	}

	internal void InternalRemove(DataGridViewCell dataGridViewCell)
	{
		base.List.Remove(dataGridViewCell);
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
