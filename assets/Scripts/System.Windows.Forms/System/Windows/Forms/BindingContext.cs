using System.Collections;
using System.ComponentModel;

namespace System.Windows.Forms;

[DefaultEvent("CollectionChanged")]
public class BindingContext : ICollection, IEnumerable
{
	private class HashKey
	{
		public object source;

		public string member;

		public HashKey(object source, string member)
		{
			this.source = source;
			this.member = member;
		}

		public override int GetHashCode()
		{
			return source.GetHashCode() ^ member.GetHashCode();
		}

		public override bool Equals(object o)
		{
			if (!(o is HashKey hashKey))
			{
				return false;
			}
			if (hashKey.source == source)
			{
				return hashKey.member == member;
			}
			return false;
		}
	}

	private Hashtable managers;

	private EventHandler onCollectionChangedHandler;

	public bool IsReadOnly => false;

	public BindingManagerBase this[object dataSource] => this[dataSource, string.Empty];

	public BindingManagerBase this[object dataSource, string dataMember]
	{
		get
		{
			if (dataSource == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			if (dataMember == null)
			{
				dataMember = string.Empty;
			}
			if (dataSource is ICurrencyManagerProvider currencyManagerProvider)
			{
				if (dataMember.Length == 0)
				{
					return currencyManagerProvider.CurrencyManager;
				}
				return currencyManagerProvider.GetRelatedCurrencyManager(dataMember);
			}
			HashKey key = new HashKey(dataSource, dataMember);
			if (managers[key] is BindingManagerBase result)
			{
				return result;
			}
			BindingManagerBase bindingManagerBase = CreateBindingManager(dataSource, dataMember);
			if (bindingManagerBase == null)
			{
				return null;
			}
			managers[key] = bindingManagerBase;
			return bindingManagerBase;
		}
	}

	int ICollection.Count => managers.Count;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => null;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event CollectionChangeEventHandler CollectionChanged
	{
		add
		{
			throw new NotImplementedException();
		}
		remove
		{
		}
	}

	public BindingContext()
	{
		managers = new Hashtable();
		onCollectionChangedHandler = null;
	}

	private BindingManagerBase CreateBindingManager(object data_source, string data_member)
	{
		if (data_member == "")
		{
			if (IsListType(data_source.GetType()))
			{
				return new CurrencyManager(data_source);
			}
			return new PropertyManager(data_source);
		}
		BindingMemberInfo bindingMemberInfo = new BindingMemberInfo(data_member);
		BindingManagerBase bindingManagerBase = this[data_source, bindingMemberInfo.BindingPath];
		PropertyDescriptor propertyDescriptor = bindingManagerBase?.GetItemProperties().Find(bindingMemberInfo.BindingField, ignoreCase: true);
		if (propertyDescriptor == null)
		{
			throw new ArgumentException($"Cannot create a child list for field {bindingMemberInfo.BindingField}.");
		}
		if (IsListType(propertyDescriptor.PropertyType))
		{
			return new RelatedCurrencyManager(bindingManagerBase, propertyDescriptor);
		}
		return new RelatedPropertyManager(bindingManagerBase, bindingMemberInfo.BindingField);
	}

	private bool IsListType(Type t)
	{
		if (!typeof(IList).IsAssignableFrom(t))
		{
			return typeof(IListSource).IsAssignableFrom(t);
		}
		return true;
	}

	public bool Contains(object dataSource)
	{
		return Contains(dataSource, string.Empty);
	}

	public bool Contains(object dataSource, string dataMember)
	{
		if (dataSource == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		if (dataMember == null)
		{
			dataMember = string.Empty;
		}
		HashKey key = new HashKey(dataSource, dataMember);
		return managers[key] != null;
	}

	protected internal void Add(object dataSource, BindingManagerBase listManager)
	{
		AddCore(dataSource, listManager);
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, dataSource));
	}

	protected virtual void AddCore(object dataSource, BindingManagerBase listManager)
	{
		if (dataSource == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		if (listManager == null)
		{
			throw new ArgumentNullException("listManager");
		}
		HashKey key = new HashKey(dataSource, string.Empty);
		managers[key] = listManager;
	}

	protected internal void Clear()
	{
		ClearCore();
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
	}

	protected virtual void ClearCore()
	{
		managers.Clear();
	}

	protected virtual void OnCollectionChanged(CollectionChangeEventArgs ccevent)
	{
		if (onCollectionChangedHandler != null)
		{
			onCollectionChangedHandler(this, ccevent);
		}
	}

	protected internal void Remove(object dataSource)
	{
		if (dataSource == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		RemoveCore(dataSource);
		OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, dataSource));
	}

	protected virtual void RemoveCore(object dataSource)
	{
		HashKey[] array = new HashKey[managers.Keys.Count];
		managers.Keys.CopyTo(array, 0);
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].source == dataSource)
			{
				managers.Remove(array[i]);
			}
		}
	}

	[System.MonoTODO("Stub, does nothing")]
	public static void UpdateBinding(BindingContext newBindingContext, Binding binding)
	{
	}

	void ICollection.CopyTo(Array ar, int index)
	{
		managers.CopyTo(ar, index);
	}

	[System.MonoInternalNote("our enumerator is slightly different.  in MS's implementation the Values are WeakReferences to the managers.")]
	IEnumerator IEnumerable.GetEnumerator()
	{
		return managers.GetEnumerator();
	}
}
