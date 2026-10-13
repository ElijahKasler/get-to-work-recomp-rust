using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Threading;
using UnityEngine;

namespace Rewired.Utils.Classes.Data;

[Serializable]
[DefaultMember("Item")]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal class AList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
{
	[Serializable]
	public struct BTLcZMhJZdBMCqFlCBmCSmTHQiipA : IEnumerator<T>, IEnumerator, IDisposable
	{
		private AList<T> list;

		private int index;

		private int version;

		private T current;

		T IEnumerator<T>.Current => get_Current();

		object IEnumerator.Current
		{
			get
			{
				if (index == 0 || index == list._count + 1)
				{
					throw new InvalidOperationException();
				}
				return get_Current();
			}
		}

		internal BTLcZMhJZdBMCqFlCBmCSmTHQiipA(AList<T> P_0)
		{
			list = P_0;
			index = 0;
			version = P_0.VtZQPOETIDUbuiqpkrrSKoBFahtJA;
			current = default;
		}

		public void Dispose()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		public bool MoveNext()
		{
			AList<T> aList = list;
			if (version == aList.VtZQPOETIDUbuiqpkrrSKoBFahtJA && (uint)index < (uint)aList._count)
			{
				current = aList._items[index];
				index++;
				return true;
			}
			return igaVBLYCPzPspLizxajgYIdetiFb();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private bool igaVBLYCPzPspLizxajgYIdetiFb()
		{
			if (version != list.VtZQPOETIDUbuiqpkrrSKoBFahtJA)
			{
				throw new InvalidOperationException("List was changed.");
			}
			index = list._count + 1;
			current = default;
			return false;
		}

		public T get_Current()
		{
			return current;
		}

		void IEnumerator.Reset()
		{
			if (version != list.VtZQPOETIDUbuiqpkrrSKoBFahtJA)
			{
				throw new InvalidOperationException("List was changed.");
			}
			index = 0;
			current = default;
		}
	}

	private const int uswcPmEGcRHXZmmnhtDGUlrbGaumA = 4;

	private static readonly T[] vDiUzCUJMqIuTyPnsBUdeueHXBNWA = new T[0];

	private IEqualityComparer<T> ExEfiPgjxPjealbEOdudssmvxYLR = EqualityComparerNoAlloc<T>.Default;

	public T[] _items;

	private int WkMaPWOoNQMtXdccbxVeLPJbXnEY;

	public int _count;

	private int LUqgCGMAyxUeeLyZunEjZPXzpZyM;

	private bool thycMcAlEcdhqDaoIOCajBxTvAmfA;

	private readonly int rNjNZOpLAwTrXMCYlMSeumnQFnJI;

	private readonly bool UJLmfDaBwOoCqxjDBkrCJsbpcvLc;

	private int VtZQPOETIDUbuiqpkrrSKoBFahtJA;

	[NonSerialized]
	private object vhDEysgumAMuRfuBCxIRCfABxOSd;

	int ICollection<T>.Count => get_Count();

	public int Capacity => WkMaPWOoNQMtXdccbxVeLPJbXnEY;

	public int FreeSpace => rNjNZOpLAwTrXMCYlMSeumnQFnJI - _count;

	bool IList.IsFixedSize => get_IsFixedSize();

	public IEqualityComparer<T> EqualityComparer
	{
		get
		{
			return ExEfiPgjxPjealbEOdudssmvxYLR;
		}
		set
		{
			if (value == null)
			{
				value = EqualityComparerNoAlloc<T>.Default;
			}
			ExEfiPgjxPjealbEOdudssmvxYLR = value;
		}
	}

	public int Version => VtZQPOETIDUbuiqpkrrSKoBFahtJA;

	T IList<T>.this[int index]
	{
		get
		{
			return get_Item(index);
		}
		set
		{
			set_Item(index, value);
		}
	}

	bool ICollection<T>.IsReadOnly => bNnYmyNIAgCxwdYiaXooAhXVCrrxA();

	bool IList.IsReadOnly => false;

	object IList.this[int index]
	{
		get
		{
			return get_Item(index);
		}
		set
		{
			if (!eZJdISlZGvCLRGazKaPgPLLONllX(value))
			{
				throw new ArgumentException("value is an incompatible type.");
			}
			set_Item(index, (T)value);
		}
	}

	int ICollection.Count => _count;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot
	{
		get
		{
			if (vhDEysgumAMuRfuBCxIRCfABxOSd == null)
			{
				Interlocked.CompareExchange<object>(ref vhDEysgumAMuRfuBCxIRCfABxOSd, new object(), (object)null);
			}
			return vhDEysgumAMuRfuBCxIRCfABxOSd;
		}
	}

	public int get_Count()
	{
		return _count;
	}

	public bool get_IsFixedSize()
	{
		return !UJLmfDaBwOoCqxjDBkrCJsbpcvLc;
	}

	public T get_Item(int index)
	{
		if ((uint)index >= (uint)_count)
		{
			throw new IndexOutOfRangeException();
		}
		return _items[index];
	}

	public void set_Item(int index, T value)
	{
		if ((uint)index >= (uint)_count)
		{
			throw new IndexOutOfRangeException();
		}
		_items[index] = value;
		VtZQPOETIDUbuiqpkrrSKoBFahtJA++;
	}

	public AList()
		: this(0, 0, 0)
	{
	}

	public AList(int P_0)
		: this(P_0, 0, 0)
	{
	}

	public AList(int P_0, int P_1)
		: this(P_0, P_1, 0)
	{
	}

	public AList(int P_0, int P_1, int P_2)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("startingCapacity cannot be a negative value.");
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		if (P_0 > 0 && P_1 > 0 && P_1 < P_0)
		{
			throw new ArgumentOutOfRangeException("maxCapacity must be >= startingCapacity or zero for unlimited.");
		}
		if (P_1 == 0 || P_1 > P_0)
		{
			UJLmfDaBwOoCqxjDBkrCJsbpcvLc = true;
		}
		if (!UJLmfDaBwOoCqxjDBkrCJsbpcvLc && P_0 == 0)
		{
			throw new ArgumentOutOfRangeException("startingCapacity must be > 0 if non-expandable.");
		}
		if (UJLmfDaBwOoCqxjDBkrCJsbpcvLc && P_2 == 0)
		{
			thycMcAlEcdhqDaoIOCajBxTvAmfA = true;
			P_2 = 1;
		}
		LUqgCGMAyxUeeLyZunEjZPXzpZyM = P_2;
		WkMaPWOoNQMtXdccbxVeLPJbXnEY = P_0;
		rNjNZOpLAwTrXMCYlMSeumnQFnJI = ((P_1 == 0) ? int.MaxValue : P_1);
		_count = 0;
		if (WkMaPWOoNQMtXdccbxVeLPJbXnEY == 0)
		{
			_items = vDiUzCUJMqIuTyPnsBUdeueHXBNWA;
		}
		else
		{
			_items = new T[P_0];
		}
	}

	public AList(IEnumerable<T> P_0)
		: this(P_0, 0, 0)
	{
	}

	public AList(IEnumerable<T> P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("collection");
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		T[] array = null;
		if (P_0 is ICollection<T> { Count: var count } collection)
		{
			if (count == 0)
			{
				array = vDiUzCUJMqIuTyPnsBUdeueHXBNWA;
			}
			else
			{
				array = new T[count];
				collection.CopyTo(array, 0);
			}
		}
		else
		{
			using IEnumerator<T> enumerator = P_0.GetEnumerator();
			List<T> list = new List<T>();
			while (enumerator.MoveNext())
			{
				list.Add(enumerator.Current);
			}
			if (list.Count > 0)
			{
				array = list.ToArray();
			}
		}
		int num = ((array != null) ? array.Length : 0);
		if (num > 0 && P_1 > 0 && P_1 < num)
		{
			throw new ArgumentOutOfRangeException("maxCapacity must be >= startingCapacity or zero for unlimited.");
		}
		if (P_1 == 0 || P_1 > num)
		{
			UJLmfDaBwOoCqxjDBkrCJsbpcvLc = true;
		}
		if (!UJLmfDaBwOoCqxjDBkrCJsbpcvLc && num == 0)
		{
			throw new ArgumentOutOfRangeException("startingCapacity must be > 0 if non-expandable.");
		}
		if (UJLmfDaBwOoCqxjDBkrCJsbpcvLc && P_2 == 0)
		{
			thycMcAlEcdhqDaoIOCajBxTvAmfA = true;
			P_2 = 1;
		}
		LUqgCGMAyxUeeLyZunEjZPXzpZyM = P_2;
		WkMaPWOoNQMtXdccbxVeLPJbXnEY = num;
		rNjNZOpLAwTrXMCYlMSeumnQFnJI = ((P_1 == 0) ? int.MaxValue : P_1);
		_items = ((array != null) ? array : vDiUzCUJMqIuTyPnsBUdeueHXBNWA);
		_count = num;
	}

	public T GetRandom()
	{
		if (_count == 0)
		{
			return default;
		}
		return _items[UnityEngine.Random.Range(0, _count)];
	}

	public int Add(T item)
	{
		if (_count == WkMaPWOoNQMtXdccbxVeLPJbXnEY && TdBGZRyOiiTiqxAHRdrQWMJKqLo(LUqgCGMAyxUeeLyZunEjZPXzpZyM) == 0)
		{
			return -1;
		}
		int count = _count;
		_items[count] = item;
		_count++;
		return count;
	}

	public bool Add(T[] items, int count = 0, int startIndex = 0, bool allowPartialAdd = false)
	{
		if (items == null || items.Length == 0)
		{
			return true;
		}
		if ((uint)startIndex >= (uint)items.Length)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		if (count + startIndex > items.Length)
		{
			throw new ArgumentOutOfRangeException("count + startIndex cannot be larger than the array.");
		}
		if (count <= 0)
		{
			count = items.Length - startIndex;
		}
		if (count == 0)
		{
			return true;
		}
		int num = WkMaPWOoNQMtXdccbxVeLPJbXnEY - _count;
		if (count > num)
		{
			int num2 = TdBGZRyOiiTiqxAHRdrQWMJKqLo(Math.Max(num, LUqgCGMAyxUeeLyZunEjZPXzpZyM), true);
			if (num2 == 0)
			{
				return false;
			}
			if (num2 < count && !allowPartialAdd)
			{
				return false;
			}
			count = TdBGZRyOiiTiqxAHRdrQWMJKqLo(Math.Max(num, LUqgCGMAyxUeeLyZunEjZPXzpZyM));
		}
		Array.Copy(items, startIndex, _items, _count, count);
		_count += count;
		VtZQPOETIDUbuiqpkrrSKoBFahtJA++;
		return true;
	}

	public bool Add(AList<T> items, int count = 0, int startIndex = 0, bool allowPartialAdd = false)
	{
		if (items == null || items._count == 0)
		{
			return true;
		}
		if ((uint)startIndex >= (uint)items._count)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		if (count + startIndex > items._count)
		{
			throw new ArgumentOutOfRangeException("count + startIndex cannot be larger than the list.");
		}
		if (count <= 0)
		{
			count = items._count - startIndex;
		}
		if (count == 0)
		{
			return true;
		}
		int num = WkMaPWOoNQMtXdccbxVeLPJbXnEY - _count;
		if (count > num)
		{
			int num2 = TdBGZRyOiiTiqxAHRdrQWMJKqLo(Math.Max(num, LUqgCGMAyxUeeLyZunEjZPXzpZyM), true);
			if (num2 == 0)
			{
				return false;
			}
			if (num2 < count && !allowPartialAdd)
			{
				return false;
			}
			count = TdBGZRyOiiTiqxAHRdrQWMJKqLo(Math.Max(num, LUqgCGMAyxUeeLyZunEjZPXzpZyM));
		}
		Array.Copy(items._items, startIndex, _items, _count, count);
		_count += count;
		VtZQPOETIDUbuiqpkrrSKoBFahtJA++;
		return true;
	}

	public int AddIfUnique(T item)
	{
		int num = IndexOf(item);
		if (num >= 0)
		{
			return num;
		}
		return Add(item);
	}

	public int AddToFirstOpenSpace(T item)
	{
		T y = default;
		for (int i = 0; i < _count; i++)
		{
			if (ExEfiPgjxPjealbEOdudssmvxYLR.Equals(_items[i], y))
			{
				_items[i] = item;
				return i;
			}
		}
		if (_count < rNjNZOpLAwTrXMCYlMSeumnQFnJI)
		{
			return Add(item);
		}
		return -1;
	}

	public int AddToFirstOpenSpace(T item, T openSpaceEquals)
	{
		for (int i = 0; i < _count; i++)
		{
			if (ExEfiPgjxPjealbEOdudssmvxYLR.Equals(_items[i], openSpaceEquals))
			{
				_items[i] = item;
				return i;
			}
		}
		if (_count < rNjNZOpLAwTrXMCYlMSeumnQFnJI)
		{
			return Add(item);
		}
		return -1;
	}

	public bool Insert(int index, T item)
	{
		if (index < 0 || index > _count)
		{
			throw new IndexOutOfRangeException();
		}
		if (_count == WkMaPWOoNQMtXdccbxVeLPJbXnEY && TdBGZRyOiiTiqxAHRdrQWMJKqLo(LUqgCGMAyxUeeLyZunEjZPXzpZyM) == 0)
		{
			return false;
		}
		if (index < _count)
		{
			Array.Copy(_items, index, _items, index + 1, _count - index);
		}
		_items[index] = item;
		_count++;
		VtZQPOETIDUbuiqpkrrSKoBFahtJA++;
		return true;
	}

	public bool Remove(T item)
	{
		int num = IndexOf(item);
		if (num < 0)
		{
			return false;
		}
		RemoveAt(num);
		return true;
	}

	bool ICollection<T>.Remove(T item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Remove
		return this.Remove(item);
	}

	public void RemoveAt(int index)
	{
		if (index < 0 || index >= _count)
		{
			throw new IndexOutOfRangeException();
		}
		_count--;
		if (index < _count)
		{
			Array.Copy(_items, index + 1, _items, index, _count - index);
		}
		_items[_count] = default;
		VtZQPOETIDUbuiqpkrrSKoBFahtJA++;
	}

	void IList<T>.RemoveAt(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in RemoveAt
		this.RemoveAt(index);
	}

	void IList.RemoveAt(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in RemoveAt
		this.RemoveAt(index);
	}

	public bool Contains(T item)
	{
		return Contains(item, ExEfiPgjxPjealbEOdudssmvxYLR);
	}

	bool ICollection<T>.Contains(T item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Contains
		return this.Contains(item);
	}

	public bool Contains(T item, IEqualityComparer<T> comparer)
	{
		if (comparer == null)
		{
			throw new ArgumentNullException("comparer");
		}
		for (int i = 0; i < _count; i++)
		{
			if (comparer.Equals(_items[i], item))
			{
				return true;
			}
		}
		return false;
	}

	public int IndexOf(T item)
	{
		return IndexOf(item, ExEfiPgjxPjealbEOdudssmvxYLR);
	}

	int IList<T>.IndexOf(T item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IndexOf
		return this.IndexOf(item);
	}

	public int IndexOf(T item, int index)
	{
		return IndexOf(item, index, ExEfiPgjxPjealbEOdudssmvxYLR);
	}

	public int IndexOf(T item, int index, int count)
	{
		return IndexOf(item, index, count, ExEfiPgjxPjealbEOdudssmvxYLR);
	}

	public int IndexOf(T item, IEqualityComparer<T> comparer)
	{
		if (comparer == null)
		{
			throw new ArgumentNullException("comparer");
		}
		for (int i = 0; i < _count; i++)
		{
			if (comparer.Equals(_items[i], item))
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOf(T item, int index, IEqualityComparer<T> comparer)
	{
		if (index < 0 || index >= _count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		for (int i = index; i < _count; i++)
		{
			if (comparer.Equals(_items[i], item))
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOf(T item, int index, int count, IEqualityComparer<T> comparer)
	{
		if (index < 0 || index >= _count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (index + count > _count)
		{
			throw new ArgumentOutOfRangeException();
		}
		int num = index + count;
		for (int i = index; i < num; i++)
		{
			if (comparer.Equals(_items[i], item))
			{
				return i;
			}
		}
		return -1;
	}

	public void Reverse()
	{
		Reverse(0, get_Count());
	}

	public void Reverse(int index, int count)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (_count - index < count)
		{
			throw new ArgumentOutOfRangeException();
		}
		Array.Reverse(_items, index, count);
		VtZQPOETIDUbuiqpkrrSKoBFahtJA++;
	}

	public void Sort()
	{
		Sort(0, get_Count(), null);
	}

	public void Sort(IComparer<T> comparer)
	{
		Sort(0, get_Count(), comparer);
	}

	public void Sort(int index, int count, IComparer<T> comparer)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (_count - index < count)
		{
			throw new ArgumentOutOfRangeException();
		}
		Array.Sort(_items, index, count, comparer);
		VtZQPOETIDUbuiqpkrrSKoBFahtJA++;
	}

	public List<T> GetRange(int index, int count)
	{
		if (index < 0 || index >= _count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (_count - index < count)
		{
			throw new ArgumentOutOfRangeException();
		}
		T[] array = new T[count];
		Array.Copy(_items, index, array, 0, count);
		return new List<T>(array);
	}

	public ReadOnlyCollection<T> AsReadOnly()
	{
		return new ReadOnlyCollection<T>(this);
	}

	public bool Exists(Predicate<T> match)
	{
		return FindIndex(match) != -1;
	}

	public T Find(Predicate<T> match)
	{
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		for (int i = 0; i < _count; i++)
		{
			if (match(_items[i]))
			{
				return _items[i];
			}
		}
		return default;
	}

	public List<T> FindAll(Predicate<T> match)
	{
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		List<T> list = new List<T>();
		for (int i = 0; i < _count; i++)
		{
			if (match(_items[i]))
			{
				list.Add(_items[i]);
			}
		}
		return list;
	}

	public int FindIndex(Predicate<T> match)
	{
		return FindIndex(0, _count, match);
	}

	public int FindIndex(int startIndex, Predicate<T> match)
	{
		return FindIndex(startIndex, _count - startIndex, match);
	}

	public int FindIndex(int startIndex, int count, Predicate<T> match)
	{
		if ((uint)startIndex > (uint)_count)
		{
			throw new ArgumentNullException("startIndex");
		}
		if (count < 0 || startIndex > _count - count)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		int num = startIndex + count;
		for (int i = startIndex; i < num; i++)
		{
			if (match(_items[i]))
			{
				return i;
			}
		}
		return -1;
	}

	public T FindLast(Predicate<T> match)
	{
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		for (int num = _count - 1; num >= 0; num--)
		{
			if (match(_items[num]))
			{
				return _items[num];
			}
		}
		return default;
	}

	public int FindLastIndex(Predicate<T> match)
	{
		return FindLastIndex(_count - 1, _count, match);
	}

	public int FindLastIndex(int startIndex, Predicate<T> match)
	{
		return FindLastIndex(startIndex, startIndex + 1, match);
	}

	public int FindLastIndex(int startIndex, int count, Predicate<T> match)
	{
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		if (_count == 0)
		{
			if (startIndex != -1)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
		}
		else if ((uint)startIndex >= (uint)_count)
		{
			throw new ArgumentOutOfRangeException("startIndex");
		}
		if (count < 0 || startIndex - count + 1 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		int num = startIndex - count;
		for (int num2 = startIndex; num2 > num; num2--)
		{
			if (match(_items[num2]))
			{
				return num2;
			}
		}
		return -1;
	}

	public void ForEach(Action<T> action)
	{
		if (_count == 0)
		{
			return;
		}
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		int vtZQPOETIDUbuiqpkrrSKoBFahtJA = VtZQPOETIDUbuiqpkrrSKoBFahtJA;
		for (int i = 0; i < _count; i++)
		{
			if (vtZQPOETIDUbuiqpkrrSKoBFahtJA != VtZQPOETIDUbuiqpkrrSKoBFahtJA)
			{
				break;
			}
			action(_items[i]);
		}
		if (vtZQPOETIDUbuiqpkrrSKoBFahtJA == VtZQPOETIDUbuiqpkrrSKoBFahtJA)
		{
			return;
		}
		throw new Exception("List was changed.");
	}

	public int LastIndexOf(T item)
	{
		if (_count == 0)
		{
			return -1;
		}
		return LastIndexOf(item, _count - 1, _count);
	}

	public int LastIndexOf(T item, int index)
	{
		if (index < 0 || index >= _count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return LastIndexOf(item, index, index + 1);
	}

	public int LastIndexOf(T item, int index, int count)
	{
		if (_count != 0 && index < 0)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (_count != 0 && count < 0)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		if (_count == 0)
		{
			return -1;
		}
		if (index >= _count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (count > index + 1)
		{
			throw new ArgumentOutOfRangeException();
		}
		return Array.LastIndexOf(_items, item, index, count);
	}

	public int RemoveAll(Predicate<T> match)
	{
		if (_count == 0)
		{
			return 0;
		}
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		int i;
		for (i = 0; i < _count && !match(_items[i]); i++)
		{
		}
		if (i >= _count)
		{
			return 0;
		}
		int j = i + 1;
		while (j < _count)
		{
			for (; j < _count && match(_items[j]); j++)
			{
			}
			if (j < _count)
			{
				_items[i++] = _items[j++];
			}
		}
		Array.Clear(_items, i, _count - i);
		int result = _count - i;
		_count = i;
		VtZQPOETIDUbuiqpkrrSKoBFahtJA++;
		return result;
	}

	public bool TrueForAll(Predicate<T> match)
	{
		if (match == null)
		{
			throw new ArgumentNullException("match");
		}
		for (int i = 0; i < _count; i++)
		{
			if (!match(_items[i]))
			{
				return false;
			}
		}
		return true;
	}

	public T[] ToArray()
	{
		T[] array = new T[_count];
		Array.Copy(_items, 0, array, 0, _count);
		return array;
	}

	public void CopyTo(int index, T[] array, int arrayIndex, int count)
	{
		if (_count - index < count)
		{
			throw new ArgumentOutOfRangeException();
		}
		Array.Copy(_items, index, array, arrayIndex, count);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		Array.Copy(_items, 0, array, arrayIndex, _count);
	}

	public void Clear()
	{
		Array.Clear(_items, 0, _count);
		_count = 0;
		VtZQPOETIDUbuiqpkrrSKoBFahtJA++;
	}

	void ICollection<T>.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	void IList.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	public void TrimExcess()
	{
		if (UJLmfDaBwOoCqxjDBkrCJsbpcvLc && _count != WkMaPWOoNQMtXdccbxVeLPJbXnEY)
		{
			jINzeToLOKrFlyPaLjDxGEUosvEjA(_count);
			VtZQPOETIDUbuiqpkrrSKoBFahtJA++;
		}
	}

	private int TdBGZRyOiiTiqxAHRdrQWMJKqLo(int P_0, bool P_1 = false)
	{
		if (!UJLmfDaBwOoCqxjDBkrCJsbpcvLc)
		{
			return 0;
		}
		if (WkMaPWOoNQMtXdccbxVeLPJbXnEY >= rNjNZOpLAwTrXMCYlMSeumnQFnJI)
		{
			return 0;
		}
		if (thycMcAlEcdhqDaoIOCajBxTvAmfA)
		{
			P_0 = tXpmxuPFRiVDdQylmfVrmwbaEkwe(WkMaPWOoNQMtXdccbxVeLPJbXnEY, P_0);
		}
		P_0 = Math.Min(P_0, rNjNZOpLAwTrXMCYlMSeumnQFnJI - WkMaPWOoNQMtXdccbxVeLPJbXnEY);
		if (P_0 <= 0)
		{
			return 0;
		}
		if (!jINzeToLOKrFlyPaLjDxGEUosvEjA(WkMaPWOoNQMtXdccbxVeLPJbXnEY + P_0))
		{
			return 0;
		}
		return P_0;
	}

	private int tXpmxuPFRiVDdQylmfVrmwbaEkwe(int P_0, int P_1)
	{
		int num = P_0 + P_1;
		if (num < 4)
		{
			num = 4;
		}
		uint num2 = MathTools.RoundUpToPowerOf2((uint)num);
		if (num2 > int.MaxValue)
		{
			num2 = 2147483647u;
		}
		return (int)num2 - P_0;
	}

	private bool jINzeToLOKrFlyPaLjDxGEUosvEjA(int P_0, bool P_1 = false)
	{
		if (P_0 < 0)
		{
			P_0 = 0;
		}
		if (P_0 > rNjNZOpLAwTrXMCYlMSeumnQFnJI)
		{
			return false;
		}
		if (P_0 == WkMaPWOoNQMtXdccbxVeLPJbXnEY)
		{
			return true;
		}
		if (P_1)
		{
			return true;
		}
		_ = WkMaPWOoNQMtXdccbxVeLPJbXnEY;
		T[] array = new T[P_0];
		if (P_0 != 0)
		{
			Array.Copy(_items, array, Math.Min(P_0, WkMaPWOoNQMtXdccbxVeLPJbXnEY));
		}
		WkMaPWOoNQMtXdccbxVeLPJbXnEY = P_0;
		if (_count > P_0)
		{
			_count = P_0;
		}
		_items = array;
		return true;
	}

	private void uDOEGUEboMEuhueNZxEjUvImuaAPA(int P_0, T P_1)
	{
		Insert(P_0, P_1);
	}

	void IList<T>.Insert(int P_0, T P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in uDOEGUEboMEuhueNZxEjUvImuaAPA
		this.uDOEGUEboMEuhueNZxEjUvImuaAPA(P_0, P_1);
	}

	private void kqNHTMRZmEKWhlMIZfHeAfiWfcnq(T P_0)
	{
		if (Add(P_0) < 0)
		{
			throw new Exception("List has no more space. Cannot add item.");
		}
	}

	void ICollection<T>.Add(T P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in kqNHTMRZmEKWhlMIZfHeAfiWfcnq
		this.kqNHTMRZmEKWhlMIZfHeAfiWfcnq(P_0);
	}

	private void piCFQazBzxGBVQIOPQKAXIgsctkq(T[] P_0, int P_1)
	{
		if (P_0 != null && P_0.Rank != 1)
		{
			throw new ArgumentException("Multi-dimensional arrays are not supported.");
		}
		Array.Copy(_items, 0, P_0, P_1, _count);
	}

	void ICollection<T>.CopyTo(T[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in piCFQazBzxGBVQIOPQKAXIgsctkq
		this.piCFQazBzxGBVQIOPQKAXIgsctkq(P_0, P_1);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		if (array != null && array.Rank != 1)
		{
			throw new ArgumentException("Multi-dimensional arrays are not supported.");
		}
		try
		{
			Array.Copy(_items, 0, array, index, _count);
		}
		catch (ArrayTypeMismatchException)
		{
			throw new ArgumentException("Invalid array type.");
		}
	}

	private bool bNnYmyNIAgCxwdYiaXooAhXVCrrxA()
	{
		return false;
	}

	private IEnumerator<T> flDqhRYmCbjcumWEybUoHacWwudQA()
	{
		return new BTLcZMhJZdBMCqFlCBmCSmTHQiipA(this);
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in flDqhRYmCbjcumWEybUoHacWwudQA
		return this.flDqhRYmCbjcumWEybUoHacWwudQA();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new BTLcZMhJZdBMCqFlCBmCSmTHQiipA(this);
	}

	int IList.Add(object value)
	{
		if (!eZJdISlZGvCLRGazKaPgPLLONllX(value))
		{
			throw new ArgumentException("value is an incompatible type.");
		}
		return Add((T)value);
	}

	bool IList.Contains(object value)
	{
		if (!eZJdISlZGvCLRGazKaPgPLLONllX(value))
		{
			throw new ArgumentException("value is an incompatible type.");
		}
		return Contains((T)value);
	}

	int IList.IndexOf(object value)
	{
		if (!eZJdISlZGvCLRGazKaPgPLLONllX(value))
		{
			throw new ArgumentException("value is an incompatible type.");
		}
		return IndexOf((T)value);
	}

	void IList.Insert(int index, object value)
	{
		if (!eZJdISlZGvCLRGazKaPgPLLONllX(value))
		{
			throw new ArgumentException("value is an incompatible type.");
		}
		Insert(index, (T)value);
	}

	void IList.Remove(object value)
	{
		if (!eZJdISlZGvCLRGazKaPgPLLONllX(value))
		{
			throw new ArgumentException("value is an incompatible type.");
		}
		Remove((T)value);
	}

	public static AList<T> CreateFixedLengthList(int capacity)
	{
		return new AList<T>(capacity, capacity, 0);
	}

	private static bool eZJdISlZGvCLRGazKaPgPLLONllX(object P_0)
	{
		if (!(P_0 is T))
		{
			if (P_0 == null)
			{
				return default(T) == null;
			}
			return false;
		}
		return true;
	}
}
