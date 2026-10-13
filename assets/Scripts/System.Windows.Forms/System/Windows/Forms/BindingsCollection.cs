using System.Collections;
using System.ComponentModel;

namespace System.Windows.Forms;

[DefaultEvent("CollectionChanged")]
public class BindingsCollection : BaseCollection
{
	public override int Count => base.Count;

	public Binding this[int index] => (Binding)base.List[index];

	protected override ArrayList List => base.List;

	public event CollectionChangeEventHandler CollectionChanged;

	public event CollectionChangeEventHandler CollectionChanging;

	internal BindingsCollection()
	{
	}

	protected internal void Add(Binding binding)
	{
		AddCore(binding);
	}

	protected virtual void AddCore(Binding dataBinding)
	{
		CollectionChangeEventArgs e = new CollectionChangeEventArgs(CollectionChangeAction.Add, dataBinding);
		OnCollectionChanging(e);
		base.List.Add(dataBinding);
		OnCollectionChanged(e);
	}

	protected internal void Clear()
	{
		ClearCore();
	}

	protected virtual void ClearCore()
	{
		CollectionChangeEventArgs e = new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null);
		OnCollectionChanging(e);
		base.List.Clear();
		OnCollectionChanged(e);
	}

	protected virtual void OnCollectionChanged(CollectionChangeEventArgs ccevent)
	{
		if (CollectionChanged != null)
		{
			CollectionChanged(this, ccevent);
		}
	}

	protected virtual void OnCollectionChanging(CollectionChangeEventArgs e)
	{
		if (CollectionChanging != null)
		{
			CollectionChanging(this, e);
		}
	}

	protected internal void Remove(Binding binding)
	{
		RemoveCore(binding);
	}

	protected internal void RemoveAt(int index)
	{
		base.List.RemoveAt(index);
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, base.List));
	}

	protected virtual void RemoveCore(Binding dataBinding)
	{
		CollectionChangeEventArgs e = new CollectionChangeEventArgs(CollectionChangeAction.Remove, dataBinding);
		OnCollectionChanging(e);
		base.List.Remove(dataBinding);
		OnCollectionChanged(e);
	}

	protected internal bool ShouldSerializeMyAll()
	{
		if (Count > 0)
		{
			return true;
		}
		return false;
	}

	internal bool Contains(Binding binding)
	{
		return List.Contains(binding);
	}
}
