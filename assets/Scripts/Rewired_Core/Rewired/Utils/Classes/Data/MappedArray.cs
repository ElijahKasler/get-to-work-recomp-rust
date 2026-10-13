using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Rewired.Utils.Classes.Data;

[Serializable]
[DefaultMember("Item")]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal sealed class MappedArray<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
{
	[Serializable]
	public struct EKFyylFAcrxogKogfIQochoGPYxu : IEnumerator<T>, IEnumerator, IDisposable
	{
		private MappedArray<T> array;

		private int index;

		private int version;

		private T current;

		T IEnumerator<T>.Current => get_Current();

		object IEnumerator.Current
		{
			get
			{
				if (index == 0 || index == array.Length + 1)
				{
					throw new InvalidOperationException();
				}
				return get_Current();
			}
		}

		internal EKFyylFAcrxogKogfIQochoGPYxu(MappedArray<T> P_0)
		{
			array = P_0;
			index = 0;
			version = P_0.CWQdyWiJnqeSjspRwqNRYnrDvFIg;
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
			MappedArray<T> mappedArray = array;
			if (version == mappedArray.CWQdyWiJnqeSjspRwqNRYnrDvFIg && (uint)index < (uint)mappedArray.Length)
			{
				current = mappedArray.cDetZzJWowaXtXqBNIjHISfNaSov[mappedArray.PwfIjtefTAStpuuTBunSHMTaUPhA(index)];
				index++;
				return true;
			}
			return piErRuZAgPmiatUNmKaBGGBwvYER();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private bool piErRuZAgPmiatUNmKaBGGBwvYER()
		{
			if (version != array.CWQdyWiJnqeSjspRwqNRYnrDvFIg)
			{
				throw new InvalidOperationException("List was changed.");
			}
			index = array.Length + 1;
			current = default;
			return false;
		}

		public T get_Current()
		{
			return current;
		}

		void IEnumerator.Reset()
		{
			if (version != array.CWQdyWiJnqeSjspRwqNRYnrDvFIg)
			{
				throw new InvalidOperationException("List was changed.");
			}
			index = 0;
			current = default;
		}
	}

	private T[] cDetZzJWowaXtXqBNIjHISfNaSov;

	private int CWQdyWiJnqeSjspRwqNRYnrDvFIg;

	private Func<int, int> wGCOzykrXvEKvtGgcjmgBKOrbXzzA;

	public Func<int, int> indexMap
	{
		get
		{
			return wGCOzykrXvEKvtGgcjmgBKOrbXzzA;
		}
		set
		{
			wGCOzykrXvEKvtGgcjmgBKOrbXzzA = value;
			CWQdyWiJnqeSjspRwqNRYnrDvFIg++;
		}
	}

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

	public int Length => cDetZzJWowaXtXqBNIjHISfNaSov.Length;

	int ICollection<T>.Count => NxBKETNDnDqwoMBmTUUjxIIofFxR();

	bool IList.IsReadOnly => get_IsReadOnly();

	object IList.this[int index]
	{
		get
		{
			return ((IList)cDetZzJWowaXtXqBNIjHISfNaSov)[PwfIjtefTAStpuuTBunSHMTaUPhA(index)];
		}
		set
		{
			((IList)cDetZzJWowaXtXqBNIjHISfNaSov)[PwfIjtefTAStpuuTBunSHMTaUPhA(index)] = value;
		}
	}

	int ICollection.Count => cDetZzJWowaXtXqBNIjHISfNaSov.Length;

	bool IList.IsFixedSize => ((IList)cDetZzJWowaXtXqBNIjHISfNaSov).IsFixedSize;

	object ICollection.SyncRoot => ((ICollection)cDetZzJWowaXtXqBNIjHISfNaSov).SyncRoot;

	bool ICollection.IsSynchronized => ((ICollection)cDetZzJWowaXtXqBNIjHISfNaSov).IsSynchronized;

	public MappedArray(T[] P_0, Func<int, int> P_1)
	{
		cDetZzJWowaXtXqBNIjHISfNaSov = P_0;
		wGCOzykrXvEKvtGgcjmgBKOrbXzzA = P_1;
	}

	public T get_Item(int index)
	{
		return cDetZzJWowaXtXqBNIjHISfNaSov[PwfIjtefTAStpuuTBunSHMTaUPhA(index)];
	}

	public void set_Item(int index, T value)
	{
		cDetZzJWowaXtXqBNIjHISfNaSov[PwfIjtefTAStpuuTBunSHMTaUPhA(index)] = value;
	}

	private int NxBKETNDnDqwoMBmTUUjxIIofFxR()
	{
		return cDetZzJWowaXtXqBNIjHISfNaSov.Length;
	}

	public bool get_IsReadOnly()
	{
		return ((ICollection<T>)cDetZzJWowaXtXqBNIjHISfNaSov).IsReadOnly;
	}

	public void Add(T item)
	{
		throw new NotImplementedException();
	}

	void ICollection<T>.Add(T item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Add
		this.Add(item);
	}

	public void Clear()
	{
		Array.Clear(cDetZzJWowaXtXqBNIjHISfNaSov, 0, cDetZzJWowaXtXqBNIjHISfNaSov.Length);
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

	public bool Contains(T item)
	{
		return cDetZzJWowaXtXqBNIjHISfNaSov.Contains(item);
	}

	bool ICollection<T>.Contains(T item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Contains
		return this.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		cDetZzJWowaXtXqBNIjHISfNaSov.CopyTo(array, arrayIndex);
	}

	void ICollection<T>.CopyTo(T[] array, int arrayIndex)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CopyTo
		this.CopyTo(array, arrayIndex);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return new EKFyylFAcrxogKogfIQochoGPYxu(this);
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	public int IndexOf(T item)
	{
		return PwfIjtefTAStpuuTBunSHMTaUPhA(((IList<T>)cDetZzJWowaXtXqBNIjHISfNaSov).IndexOf(item));
	}

	int IList<T>.IndexOf(T item)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IndexOf
		return this.IndexOf(item);
	}

	private void rDhePVSVcVFcEgSTjeBhyInZrCEE(int P_0, T P_1)
	{
		throw new NotImplementedException();
	}

	void IList<T>.Insert(int P_0, T P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in rDhePVSVcVFcEgSTjeBhyInZrCEE
		this.rDhePVSVcVFcEgSTjeBhyInZrCEE(P_0, P_1);
	}

	private bool UhlCqCCVNUyYpsmhxNDpkYwAwyRKA(T P_0)
	{
		throw new NotImplementedException();
	}

	bool ICollection<T>.Remove(T P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UhlCqCCVNUyYpsmhxNDpkYwAwyRKA
		return this.UhlCqCCVNUyYpsmhxNDpkYwAwyRKA(P_0);
	}

	private void LdzHWJaYuiTMEQoVKUOuqijJNyQg(int P_0)
	{
		throw new NotImplementedException();
	}

	void IList<T>.RemoveAt(int P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in LdzHWJaYuiTMEQoVKUOuqijJNyQg
		this.LdzHWJaYuiTMEQoVKUOuqijJNyQg(P_0);
	}

	int IList.Add(object value)
	{
		throw new NotImplementedException();
	}

	bool IList.Contains(object value)
	{
		return ((IList)cDetZzJWowaXtXqBNIjHISfNaSov).Contains(value);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		cDetZzJWowaXtXqBNIjHISfNaSov.CopyTo(array, index);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new EKFyylFAcrxogKogfIQochoGPYxu(this);
	}

	int IList.IndexOf(object value)
	{
		return ((IList)cDetZzJWowaXtXqBNIjHISfNaSov).IndexOf(value);
	}

	void IList.Insert(int index, object value)
	{
		throw new NotImplementedException();
	}

	void IList.Remove(object value)
	{
		throw new NotImplementedException();
	}

	void IList.RemoveAt(int index)
	{
		throw new NotImplementedException();
	}

	private int PwfIjtefTAStpuuTBunSHMTaUPhA(int P_0)
	{
		if (wGCOzykrXvEKvtGgcjmgBKOrbXzzA == null)
		{
			return P_0;
		}
		if (P_0 < 0 || P_0 >= cDetZzJWowaXtXqBNIjHISfNaSov.Length)
		{
			return P_0;
		}
		return wGCOzykrXvEKvtGgcjmgBKOrbXzzA(P_0);
	}
}
