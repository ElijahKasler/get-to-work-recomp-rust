using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity;

namespace System.Windows.Forms;

[ListBindable(false)]
public class DataGridViewColumnCollection : BaseCollection, IList, ICollection, IEnumerable
{
	private class ColumnDisplayIndexComparator : IComparer<DataGridViewColumn>
	{
		public int Compare(DataGridViewColumn o1, DataGridViewColumn o2)
		{
			return o1.DisplayIndex.CompareTo(o2.DisplayIndex);
		}
	}

	private DataGridView dataGridView;

	private List<DataGridViewColumn> display_index_sorted;

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

	public DataGridViewColumn this[int index] => (DataGridViewColumn)base.List[index];

	public DataGridViewColumn this[string columnName]
	{
		get
		{
			foreach (DataGridViewColumn item in base.List)
			{
				if (item.Name == columnName)
				{
					return item;
				}
			}
			return null;
		}
	}

	protected DataGridView DataGridView => dataGridView;

	protected override ArrayList List => base.List;

	internal List<DataGridViewColumn> ColumnDisplayIndexSortedArrayList => display_index_sorted;

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

	public event CollectionChangeEventHandler CollectionChanged;

	public DataGridViewColumnCollection(DataGridView dataGridView)
	{
		this.dataGridView = dataGridView;
		RegenerateSortedList();
	}

	int IList.Add(object value)
	{
		return Add(value as DataGridViewColumn);
	}

	public virtual int Add(DataGridViewColumn dataGridViewColumn)
	{
		int num = base.List.Add(dataGridViewColumn);
		if (dataGridViewColumn.DisplayIndex == -1)
		{
			dataGridViewColumn.DisplayIndexInternal = num;
		}
		dataGridViewColumn.SetIndex(num);
		dataGridViewColumn.SetDataGridView(dataGridView);
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, dataGridViewColumn));
		return num;
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual int Add(string columnName, string headerText)
	{
		DataGridViewColumn dataGridViewColumn = new DataGridViewTextBoxColumn();
		dataGridViewColumn.Name = columnName;
		dataGridViewColumn.HeaderText = headerText;
		return Add(dataGridViewColumn);
	}

	public virtual void AddRange(params DataGridViewColumn[] dataGridViewColumns)
	{
		foreach (DataGridViewColumn dataGridViewColumn in dataGridViewColumns)
		{
			Add(dataGridViewColumn);
		}
	}

	public virtual void Clear()
	{
		base.List.Clear();
		dataGridView.Rows.Clear();
		dataGridView.RemoveEditingRow();
		RegenerateSortedList();
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
	}

	bool IList.Contains(object value)
	{
		return Contains(value as DataGridViewColumn);
	}

	public virtual bool Contains(DataGridViewColumn dataGridViewColumn)
	{
		return base.List.Contains(dataGridViewColumn);
	}

	public virtual bool Contains(string columnName)
	{
		foreach (DataGridViewColumn item in base.List)
		{
			if (item.Name == columnName)
			{
				return true;
			}
		}
		return false;
	}

	public void CopyTo(DataGridViewColumn[] array, int index)
	{
		base.List.CopyTo(array, index);
	}

	public int GetColumnCount(DataGridViewElementStates includeFilter)
	{
		return 0;
	}

	public int GetColumnsWidth(DataGridViewElementStates includeFilter)
	{
		return 0;
	}

	public DataGridViewColumn GetFirstColumn(DataGridViewElementStates includeFilter)
	{
		return null;
	}

	public DataGridViewColumn GetFirstColumn(DataGridViewElementStates includeFilter, DataGridViewElementStates excludeFilter)
	{
		return null;
	}

	public DataGridViewColumn GetLastColumn(DataGridViewElementStates includeFilter, DataGridViewElementStates excludeFilter)
	{
		return null;
	}

	public DataGridViewColumn GetNextColumn(DataGridViewColumn dataGridViewColumnStart, DataGridViewElementStates includeFilter, DataGridViewElementStates excludeFilter)
	{
		return null;
	}

	public DataGridViewColumn GetPreviousColumn(DataGridViewColumn dataGridViewColumnStart, DataGridViewElementStates includeFilter, DataGridViewElementStates excludeFilter)
	{
		return null;
	}

	int IList.IndexOf(object value)
	{
		return IndexOf(value as DataGridViewColumn);
	}

	public int IndexOf(DataGridViewColumn dataGridViewColumn)
	{
		return base.List.IndexOf(dataGridViewColumn);
	}

	void IList.Insert(int index, object value)
	{
		Insert(index, value as DataGridViewColumn);
	}

	public virtual void Insert(int columnIndex, DataGridViewColumn dataGridViewColumn)
	{
		base.List.Insert(columnIndex, dataGridViewColumn);
		if (dataGridViewColumn.DisplayIndex == -1)
		{
			dataGridViewColumn.DisplayIndexInternal = columnIndex;
		}
		dataGridViewColumn.SetIndex(columnIndex);
		dataGridViewColumn.SetDataGridView(dataGridView);
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, dataGridViewColumn));
	}

	void IList.Remove(object value)
	{
		Remove(value as DataGridViewColumn);
	}

	public virtual void Remove(DataGridViewColumn dataGridViewColumn)
	{
		DataGridView.OnColumnPreRemovedInternal(new DataGridViewColumnEventArgs(dataGridViewColumn));
		base.List.Remove(dataGridViewColumn);
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, dataGridViewColumn));
	}

	public virtual void Remove(string columnName)
	{
		foreach (DataGridViewColumn item in base.List)
		{
			if (item.Name == columnName)
			{
				Remove(item);
				break;
			}
		}
	}

	public virtual void RemoveAt(int index)
	{
		DataGridViewColumn dataGridViewColumn = this[index];
		Remove(dataGridViewColumn);
	}

	protected virtual void OnCollectionChanged(CollectionChangeEventArgs e)
	{
		RegenerateIndexes();
		RegenerateSortedList();
		if (CollectionChanged != null)
		{
			CollectionChanged(this, e);
		}
	}

	private void RegenerateIndexes()
	{
		for (int i = 0; i < Count; i++)
		{
			this[i].SetIndex(i);
		}
	}

	internal void RegenerateSortedList()
	{
		List<DataGridViewColumn> list = new List<DataGridViewColumn>((DataGridViewColumn[])base.List.ToArray(typeof(DataGridViewColumn)));
		list.Sort(new ColumnDisplayIndexComparator());
		for (int i = 0; i < list.Count; i++)
		{
			list[i].DisplayIndexInternal = i;
		}
		display_index_sorted = list;
	}

	internal void ClearAutoGeneratedColumns()
	{
		for (int num = list.Count - 1; num >= 0; num--)
		{
			if ((list[num] as DataGridViewColumn).AutoGenerated)
			{
				RemoveAt(num);
			}
		}
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
