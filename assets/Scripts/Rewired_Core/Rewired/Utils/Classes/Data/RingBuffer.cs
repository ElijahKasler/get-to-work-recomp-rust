using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Data;

[Serializable]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal sealed class RingBuffer<T> : ICollection<T>, IEnumerable<T>, IEnumerable
{
	[Serializable]
	public struct EuMJvipvKXwfqVPXJFtkepqSydSdA : IEnumerator<T>, IEnumerator, IDisposable
	{
		private RingBuffer<T> buffer;

		private int index;

		private int version;

		private T current;

		T IEnumerator<T>.Current => get_Current();

		object IEnumerator.Current
		{
			get
			{
				if (index == 0 || index == buffer.tOWcovaecGAfsjfFwiYTGlZuQbul + 1)
				{
					throw new InvalidOperationException();
				}
				return get_Current();
			}
		}

		internal EuMJvipvKXwfqVPXJFtkepqSydSdA(RingBuffer<T> P_0)
		{
			buffer = P_0;
			index = 0;
			version = P_0.DBKpRZAdvGxJPNNMtggBaQPvsSAcA;
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
			if (version == buffer.DBKpRZAdvGxJPNNMtggBaQPvsSAcA && (uint)index < (uint)buffer.tOWcovaecGAfsjfFwiYTGlZuQbul)
			{
				current = buffer[index];
				index++;
				return true;
			}
			return SIZTBHBqSLcJLjHVSonaRaiGQzvO();
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private bool SIZTBHBqSLcJLjHVSonaRaiGQzvO()
		{
			if (version != buffer.DBKpRZAdvGxJPNNMtggBaQPvsSAcA)
			{
				throw new InvalidOperationException("RingBuffer was changed.");
			}
			index = buffer.tOWcovaecGAfsjfFwiYTGlZuQbul + 1;
			current = default;
			return false;
		}

		public T get_Current()
		{
			return current;
		}

		void IEnumerator.Reset()
		{
			if (version != buffer.DBKpRZAdvGxJPNNMtggBaQPvsSAcA)
			{
				throw new InvalidOperationException("RingBuffer was changed.");
			}
			index = 0;
			current = default;
		}
	}

	private readonly T[] dxjMsvJWyIvHXONCsZDDuoNAqqoH;

	private readonly int XjnPdZtmEKFDUhocpcwjzsaIMaZAA;

	private int RqDDAOCwQjzyctlFJDeWBXSjipHgb;

	private int zSOyjXtcxbMycEGEbfnAOMkPDELf;

	private int tOWcovaecGAfsjfFwiYTGlZuQbul;

	private int XRzXarJHxjyHNwBoKCVGLSbiHJed;

	private int DBKpRZAdvGxJPNNMtggBaQPvsSAcA;

	private IEqualityComparer<T> iEJLiIjUosxOuWpWDPaHUOVrsLTF = EqualityComparerNoAlloc<T>.Default;

	public int Count => tOWcovaecGAfsjfFwiYTGlZuQbul;

	public int Capacity => XjnPdZtmEKFDUhocpcwjzsaIMaZAA;

	public int OverrunCount => XRzXarJHxjyHNwBoKCVGLSbiHJed;

	public IEqualityComparer<T> EqualityComparer
	{
		get
		{
			return iEJLiIjUosxOuWpWDPaHUOVrsLTF;
		}
		set
		{
			if (value == null)
			{
				value = EqualityComparerNoAlloc<T>.Default;
			}
			iEJLiIjUosxOuWpWDPaHUOVrsLTF = value;
		}
	}

	public T this[int index]
	{
		get
		{
			int num = RsagGjfuTUiBdsFUdhhKINgYQafNA(index);
			if (!yydHDEWTWPzoDJfzpKLuAGNQIjqU(num))
			{
				throw new IndexOutOfRangeException();
			}
			return dxjMsvJWyIvHXONCsZDDuoNAqqoH[num];
		}
		set
		{
			int num = RsagGjfuTUiBdsFUdhhKINgYQafNA(index);
			if (!yydHDEWTWPzoDJfzpKLuAGNQIjqU(num))
			{
				throw new IndexOutOfRangeException();
			}
			dxjMsvJWyIvHXONCsZDDuoNAqqoH[num] = value;
		}
	}

	int ICollection<T>.Count => DgOahzQvdbRVRYfXcsGVjSPotpCf();

	bool ICollection<T>.IsReadOnly => yxcBEMTFJoFPpowzzOAMeHircVRm();

	public RingBuffer(int P_0)
	{
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity must be > 0.");
		}
		dxjMsvJWyIvHXONCsZDDuoNAqqoH = new T[P_0];
		XjnPdZtmEKFDUhocpcwjzsaIMaZAA = P_0;
		Clear();
	}

	public void Enqueue(T item)
	{
		RqDDAOCwQjzyctlFJDeWBXSjipHgb = ((RqDDAOCwQjzyctlFJDeWBXSjipHgb < XjnPdZtmEKFDUhocpcwjzsaIMaZAA - 1) ? (RqDDAOCwQjzyctlFJDeWBXSjipHgb + 1) : 0);
		if (tOWcovaecGAfsjfFwiYTGlZuQbul == 0)
		{
			zSOyjXtcxbMycEGEbfnAOMkPDELf = 0;
		}
		else if (RqDDAOCwQjzyctlFJDeWBXSjipHgb == zSOyjXtcxbMycEGEbfnAOMkPDELf)
		{
			zSOyjXtcxbMycEGEbfnAOMkPDELf = ((zSOyjXtcxbMycEGEbfnAOMkPDELf < XjnPdZtmEKFDUhocpcwjzsaIMaZAA - 1) ? (zSOyjXtcxbMycEGEbfnAOMkPDELf + 1) : 0);
			XRzXarJHxjyHNwBoKCVGLSbiHJed++;
		}
		dxjMsvJWyIvHXONCsZDDuoNAqqoH[RqDDAOCwQjzyctlFJDeWBXSjipHgb] = item;
		if (tOWcovaecGAfsjfFwiYTGlZuQbul < XjnPdZtmEKFDUhocpcwjzsaIMaZAA)
		{
			tOWcovaecGAfsjfFwiYTGlZuQbul++;
		}
	}

	public bool EnqueueIfUnique(T item)
	{
		if (Contains(item))
		{
			return false;
		}
		Enqueue(item);
		return true;
	}

	public T Dequeue()
	{
		if (tOWcovaecGAfsjfFwiYTGlZuQbul == 0)
		{
			throw new Exception("There are no items in the buffer.");
		}
		T result = dxjMsvJWyIvHXONCsZDDuoNAqqoH[zSOyjXtcxbMycEGEbfnAOMkPDELf];
		if (zSOyjXtcxbMycEGEbfnAOMkPDELf == RqDDAOCwQjzyctlFJDeWBXSjipHgb)
		{
			Clear();
			return result;
		}
		dxjMsvJWyIvHXONCsZDDuoNAqqoH[zSOyjXtcxbMycEGEbfnAOMkPDELf] = default;
		zSOyjXtcxbMycEGEbfnAOMkPDELf = ((zSOyjXtcxbMycEGEbfnAOMkPDELf < XjnPdZtmEKFDUhocpcwjzsaIMaZAA - 1) ? (zSOyjXtcxbMycEGEbfnAOMkPDELf + 1) : 0);
		XRzXarJHxjyHNwBoKCVGLSbiHJed = 0;
		tOWcovaecGAfsjfFwiYTGlZuQbul--;
		DBKpRZAdvGxJPNNMtggBaQPvsSAcA++;
		return result;
	}

	public T Peek()
	{
		if (RqDDAOCwQjzyctlFJDeWBXSjipHgb < 0)
		{
			throw new Exception("There are no items in the buffer.");
		}
		return dxjMsvJWyIvHXONCsZDDuoNAqqoH[zSOyjXtcxbMycEGEbfnAOMkPDELf];
	}

	public bool Contains(T item)
	{
		return AvbPGAHhaRSAlgADKKiDcVuZVScF(item, iEJLiIjUosxOuWpWDPaHUOVrsLTF) >= 0;
	}

	public bool Contains(T item, IEqualityComparer<T> comparer)
	{
		return AvbPGAHhaRSAlgADKKiDcVuZVScF(item, comparer) >= 0;
	}

	public int IndexOf(T item)
	{
		return IndexOf(item, iEJLiIjUosxOuWpWDPaHUOVrsLTF);
	}

	public int IndexOf(T item, IEqualityComparer<T> comparer)
	{
		return FDamuYkVDEiqYKlDzWkPZjHLLvBb(AvbPGAHhaRSAlgADKKiDcVuZVScF(item, comparer));
	}

	public bool Remove(T item)
	{
		return Remove(item, iEJLiIjUosxOuWpWDPaHUOVrsLTF);
	}

	public bool Remove(T item, IEqualityComparer<T> comparer)
	{
		if (comparer == null)
		{
			throw new ArgumentNullException("comparer");
		}
		if (Count == 0)
		{
			return false;
		}
		int num = AvbPGAHhaRSAlgADKKiDcVuZVScF(item, comparer);
		if (num < 0)
		{
			return false;
		}
		cHgPrpmGYrRStuAOGfDcxLTVUAvP(num);
		return true;
	}

	public void RemoveAt(int index)
	{
		cHgPrpmGYrRStuAOGfDcxLTVUAvP(RsagGjfuTUiBdsFUdhhKINgYQafNA(index));
	}

	public int RemoveAll(T item)
	{
		return RemoveAll(item, iEJLiIjUosxOuWpWDPaHUOVrsLTF);
	}

	public int RemoveAll(T item, IEqualityComparer<T> comparer)
	{
		if (comparer == null)
		{
			throw new ArgumentNullException("comparer");
		}
		int num = 0;
		for (int num2 = Count - 1; num2 >= 0; num2--)
		{
			if (comparer.Equals(this[num2], item))
			{
				RemoveAt(num2);
				num++;
			}
		}
		return num;
	}

	public void Clear()
	{
		if (tOWcovaecGAfsjfFwiYTGlZuQbul > 0)
		{
			if (RqDDAOCwQjzyctlFJDeWBXSjipHgb >= zSOyjXtcxbMycEGEbfnAOMkPDELf)
			{
				Array.Clear(dxjMsvJWyIvHXONCsZDDuoNAqqoH, zSOyjXtcxbMycEGEbfnAOMkPDELf, RqDDAOCwQjzyctlFJDeWBXSjipHgb - zSOyjXtcxbMycEGEbfnAOMkPDELf + 1);
			}
			else
			{
				Array.Clear(dxjMsvJWyIvHXONCsZDDuoNAqqoH, 0, RqDDAOCwQjzyctlFJDeWBXSjipHgb + 1);
				Array.Clear(dxjMsvJWyIvHXONCsZDDuoNAqqoH, zSOyjXtcxbMycEGEbfnAOMkPDELf, XjnPdZtmEKFDUhocpcwjzsaIMaZAA - zSOyjXtcxbMycEGEbfnAOMkPDELf);
			}
			tOWcovaecGAfsjfFwiYTGlZuQbul = 0;
		}
		RqDDAOCwQjzyctlFJDeWBXSjipHgb = -1;
		zSOyjXtcxbMycEGEbfnAOMkPDELf = -1;
		XRzXarJHxjyHNwBoKCVGLSbiHJed = 0;
		DBKpRZAdvGxJPNNMtggBaQPvsSAcA++;
	}

	private int AJvPSBYRpdsdfrGktIEDuOvnGDygA(T P_0)
	{
		return AvbPGAHhaRSAlgADKKiDcVuZVScF(P_0, iEJLiIjUosxOuWpWDPaHUOVrsLTF);
	}

	private int AvbPGAHhaRSAlgADKKiDcVuZVScF(T P_0, IEqualityComparer<T> P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("comparer");
		}
		if (tOWcovaecGAfsjfFwiYTGlZuQbul == 0)
		{
			return -1;
		}
		if (RqDDAOCwQjzyctlFJDeWBXSjipHgb >= zSOyjXtcxbMycEGEbfnAOMkPDELf)
		{
			for (int i = zSOyjXtcxbMycEGEbfnAOMkPDELf; i <= RqDDAOCwQjzyctlFJDeWBXSjipHgb; i++)
			{
				if (P_1.Equals(dxjMsvJWyIvHXONCsZDDuoNAqqoH[i], P_0))
				{
					return i;
				}
			}
		}
		else
		{
			for (int j = 0; j <= RqDDAOCwQjzyctlFJDeWBXSjipHgb; j++)
			{
				if (P_1.Equals(dxjMsvJWyIvHXONCsZDDuoNAqqoH[j], P_0))
				{
					return j;
				}
			}
			for (int k = zSOyjXtcxbMycEGEbfnAOMkPDELf; k < XjnPdZtmEKFDUhocpcwjzsaIMaZAA; k++)
			{
				if (P_1.Equals(dxjMsvJWyIvHXONCsZDDuoNAqqoH[k], P_0))
				{
					return k;
				}
			}
		}
		return -1;
	}

	private void cHgPrpmGYrRStuAOGfDcxLTVUAvP(int P_0)
	{
		if (!yydHDEWTWPzoDJfzpKLuAGNQIjqU(P_0))
		{
			throw new IndexOutOfRangeException();
		}
		if (P_0 == zSOyjXtcxbMycEGEbfnAOMkPDELf)
		{
			Dequeue();
			return;
		}
		if (P_0 != RqDDAOCwQjzyctlFJDeWBXSjipHgb)
		{
			if (RqDDAOCwQjzyctlFJDeWBXSjipHgb > zSOyjXtcxbMycEGEbfnAOMkPDELf)
			{
				Array.Copy(dxjMsvJWyIvHXONCsZDDuoNAqqoH, P_0 + 1, dxjMsvJWyIvHXONCsZDDuoNAqqoH, P_0, RqDDAOCwQjzyctlFJDeWBXSjipHgb - P_0);
			}
			else if (P_0 < RqDDAOCwQjzyctlFJDeWBXSjipHgb)
			{
				Array.Copy(dxjMsvJWyIvHXONCsZDDuoNAqqoH, P_0 + 1, dxjMsvJWyIvHXONCsZDDuoNAqqoH, P_0, RqDDAOCwQjzyctlFJDeWBXSjipHgb - P_0);
			}
			else
			{
				Array.Copy(dxjMsvJWyIvHXONCsZDDuoNAqqoH, P_0 + 1, dxjMsvJWyIvHXONCsZDDuoNAqqoH, P_0, XjnPdZtmEKFDUhocpcwjzsaIMaZAA - P_0 - 1);
				dxjMsvJWyIvHXONCsZDDuoNAqqoH[XjnPdZtmEKFDUhocpcwjzsaIMaZAA - 1] = dxjMsvJWyIvHXONCsZDDuoNAqqoH[0];
				if (RqDDAOCwQjzyctlFJDeWBXSjipHgb > 0)
				{
					Array.Copy(dxjMsvJWyIvHXONCsZDDuoNAqqoH, 1, dxjMsvJWyIvHXONCsZDDuoNAqqoH, 0, RqDDAOCwQjzyctlFJDeWBXSjipHgb);
				}
			}
		}
		dxjMsvJWyIvHXONCsZDDuoNAqqoH[RqDDAOCwQjzyctlFJDeWBXSjipHgb] = default;
		RqDDAOCwQjzyctlFJDeWBXSjipHgb = ((RqDDAOCwQjzyctlFJDeWBXSjipHgb > 0) ? (RqDDAOCwQjzyctlFJDeWBXSjipHgb - 1) : (XjnPdZtmEKFDUhocpcwjzsaIMaZAA - 1));
		DBKpRZAdvGxJPNNMtggBaQPvsSAcA++;
		tOWcovaecGAfsjfFwiYTGlZuQbul--;
	}

	private bool yydHDEWTWPzoDJfzpKLuAGNQIjqU(int P_0)
	{
		if (tOWcovaecGAfsjfFwiYTGlZuQbul == 0)
		{
			return false;
		}
		if (RqDDAOCwQjzyctlFJDeWBXSjipHgb >= zSOyjXtcxbMycEGEbfnAOMkPDELf)
		{
			if (P_0 >= zSOyjXtcxbMycEGEbfnAOMkPDELf)
			{
				return P_0 <= RqDDAOCwQjzyctlFJDeWBXSjipHgb;
			}
			return false;
		}
		if (P_0 < zSOyjXtcxbMycEGEbfnAOMkPDELf)
		{
			return P_0 <= RqDDAOCwQjzyctlFJDeWBXSjipHgb;
		}
		return true;
	}

	private int FDamuYkVDEiqYKlDzWkPZjHLLvBb(int P_0)
	{
		if ((uint)P_0 >= (uint)XjnPdZtmEKFDUhocpcwjzsaIMaZAA)
		{
			return -1;
		}
		if (!yydHDEWTWPzoDJfzpKLuAGNQIjqU(P_0))
		{
			return -1;
		}
		if (P_0 >= zSOyjXtcxbMycEGEbfnAOMkPDELf)
		{
			return P_0 - zSOyjXtcxbMycEGEbfnAOMkPDELf;
		}
		return P_0 + XjnPdZtmEKFDUhocpcwjzsaIMaZAA - zSOyjXtcxbMycEGEbfnAOMkPDELf;
	}

	private int RsagGjfuTUiBdsFUdhhKINgYQafNA(int P_0)
	{
		if ((uint)P_0 >= (uint)tOWcovaecGAfsjfFwiYTGlZuQbul)
		{
			return -1;
		}
		P_0 = zSOyjXtcxbMycEGEbfnAOMkPDELf + P_0;
		if (P_0 >= XjnPdZtmEKFDUhocpcwjzsaIMaZAA)
		{
			P_0 -= XjnPdZtmEKFDUhocpcwjzsaIMaZAA;
		}
		return P_0;
	}

	private void ROeuLeKRmwSlurucxOMcqnPvmWPn(T P_0)
	{
		Enqueue(P_0);
	}

	void ICollection<T>.Add(T P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ROeuLeKRmwSlurucxOMcqnPvmWPn
		this.ROeuLeKRmwSlurucxOMcqnPvmWPn(P_0);
	}

	private void pvqaTpaVaxZpgwuVXgXFHejWWrIfA()
	{
		Clear();
	}

	void ICollection<T>.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in pvqaTpaVaxZpgwuVXgXFHejWWrIfA
		this.pvqaTpaVaxZpgwuVXgXFHejWWrIfA();
	}

	private bool jVIRJWylnozWLlRnTUSJoNlacJEEA(T P_0)
	{
		return Contains(P_0);
	}

	bool ICollection<T>.Contains(T P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in jVIRJWylnozWLlRnTUSJoNlacJEEA
		return this.jVIRJWylnozWLlRnTUSJoNlacJEEA(P_0);
	}

	private void BWKoRSzuazSXeKpdkTbijJJjtVmf(T[] P_0, int P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (P_1 < 0 || P_1 + Count > P_0.Length)
		{
			throw new ArgumentException("array is too small to hold the collection.");
		}
		int count = Count;
		for (int i = 0; i < count; i++)
		{
			P_0[P_1 + i] = this[i];
		}
	}

	void ICollection<T>.CopyTo(T[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in BWKoRSzuazSXeKpdkTbijJJjtVmf
		this.BWKoRSzuazSXeKpdkTbijJJjtVmf(P_0, P_1);
	}

	private int DgOahzQvdbRVRYfXcsGVjSPotpCf()
	{
		return Count;
	}

	private bool yxcBEMTFJoFPpowzzOAMeHircVRm()
	{
		return false;
	}

	private bool WTeuGVpXTzFpGqfPqHsPIBnpRHaz(T P_0)
	{
		return Remove(P_0);
	}

	bool ICollection<T>.Remove(T P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in WTeuGVpXTzFpGqfPqHsPIBnpRHaz
		return this.WTeuGVpXTzFpGqfPqHsPIBnpRHaz(P_0);
	}

	private IEnumerator<T> RjhlydFIlYHEqWVDZPtlKQWMseUn()
	{
		return new EuMJvipvKXwfqVPXJFtkepqSydSdA(this);
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RjhlydFIlYHEqWVDZPtlKQWMseUn
		return this.RjhlydFIlYHEqWVDZPtlKQWMseUn();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new EuMJvipvKXwfqVPXJFtkepqSydSdA(this);
	}
}
