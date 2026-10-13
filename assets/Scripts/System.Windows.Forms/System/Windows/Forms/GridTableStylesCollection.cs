using System.Collections;
using System.ComponentModel;
using Unity;

namespace System.Windows.Forms;

[ListBindable(false)]
public class GridTableStylesCollection : BaseCollection, IList, ICollection, IEnumerable
{
	private ArrayList items;

	private DataGrid owner;

	public DataGridTableStyle this[string tableName]
	{
		get
		{
			int num = FromTableNameToIndex(tableName);
			if (num != -1)
			{
				return this[num];
			}
			return null;
		}
	}

	public DataGridTableStyle this[int index] => (DataGridTableStyle)items[index];

	protected override ArrayList List => items;

	int ICollection.Count => items.Count;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	bool IList.IsFixedSize => false;

	bool IList.IsReadOnly => false;

	object IList.this[int index]
	{
		get
		{
			return items[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public event CollectionChangeEventHandler CollectionChanged;

	internal GridTableStylesCollection(DataGrid grid)
	{
		items = new ArrayList();
		owner = grid;
	}

	public virtual int Add(DataGridTableStyle table)
	{
		int result = AddInternal(table);
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, table));
		return result;
	}

	public virtual void AddRange(DataGridTableStyle[] tables)
	{
		foreach (DataGridTableStyle table in tables)
		{
			AddInternal(table);
		}
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
	}

	public void Clear()
	{
		items.Clear();
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
	}

	public bool Contains(DataGridTableStyle table)
	{
		return FromTableNameToIndex(table.MappingName) != -1;
	}

	public bool Contains(string name)
	{
		return FromTableNameToIndex(name) != -1;
	}

	void ICollection.CopyTo(Array array, int index)
	{
		items.CopyTo(array, index);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return items.GetEnumerator();
	}

	int IList.Add(object value)
	{
		return Add((DataGridTableStyle)value);
	}

	void IList.Clear()
	{
		Clear();
	}

	bool IList.Contains(object value)
	{
		return Contains((DataGridTableStyle)value);
	}

	int IList.IndexOf(object value)
	{
		return items.IndexOf(value);
	}

	void IList.Insert(int index, object value)
	{
		throw new NotSupportedException();
	}

	void IList.Remove(object value)
	{
		Remove((DataGridTableStyle)value);
	}

	void IList.RemoveAt(int index)
	{
		RemoveAt(index);
	}

	protected void OnCollectionChanged(CollectionChangeEventArgs e)
	{
		if (CollectionChanged != null)
		{
			CollectionChanged(this, e);
		}
	}

	public void Remove(DataGridTableStyle table)
	{
		items.Remove(table);
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, table));
	}

	private void MappingNameChanged(object sender, EventArgs args)
	{
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
	}

	public void RemoveAt(int index)
	{
		DataGridTableStyle dataGridTableStyle = (DataGridTableStyle)items[index];
		items.RemoveAt(index);
		dataGridTableStyle.MappingNameChanged -= MappingNameChanged;
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, dataGridTableStyle));
	}

	private int AddInternal(DataGridTableStyle table)
	{
		if (FromTableNameToIndex(table.MappingName) != -1)
		{
			throw new ArgumentException("The TableStyles collection already has a TableStyle with this mapping name");
		}
		table.MappingNameChanged += MappingNameChanged;
		table.DataGrid = owner;
		return items.Add(table);
	}

	private int FromTableNameToIndex(string tableName)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (string.Compare(((DataGridTableStyle)items[i]).MappingName, tableName, ignoreCase: true) == 0)
			{
				return i;
			}
		}
		return -1;
	}

	internal GridTableStylesCollection()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
