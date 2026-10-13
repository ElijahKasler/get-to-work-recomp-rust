using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data;

[DefaultMember("Item")]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal class ADictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal struct Entry
	{
		public int hashCode;

		public int next;

		public TKey key;

		public TValue value;
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
	{
		private ADictionary<TKey, TValue> gBgcMNEWZAehBFnQJlKvAcpArvKuC;

		private int xmRBkWbNXDcTQsdPeaehdjITavRS;

		private int nquAAxALYITIibPNBzomBIpKeZvkA;

		private KeyValuePair<TKey, TValue> yJbSrDemEtYaqGpIiiVlBaGUeajsA;

		private int hoTkymLKNFUStkwOzPwlSoQmOHOK;

		internal const int DictEntry = 1;

		internal const int KeyValuePair = 2;

		KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => get_Current();

		object IEnumerator.Current
		{
			get
			{
				if (nquAAxALYITIibPNBzomBIpKeZvkA == 0 || nquAAxALYITIibPNBzomBIpKeZvkA == gBgcMNEWZAehBFnQJlKvAcpArvKuC._count + 1)
				{
					throw new Exception();
				}
				if (hoTkymLKNFUStkwOzPwlSoQmOHOK == 1)
				{
					return new DictionaryEntry(yJbSrDemEtYaqGpIiiVlBaGUeajsA.Key, yJbSrDemEtYaqGpIiiVlBaGUeajsA.Value);
				}
				return new KeyValuePair<TKey, TValue>(yJbSrDemEtYaqGpIiiVlBaGUeajsA.Key, yJbSrDemEtYaqGpIiiVlBaGUeajsA.Value);
			}
		}

		DictionaryEntry IDictionaryEnumerator.Entry
		{
			get
			{
				if (nquAAxALYITIibPNBzomBIpKeZvkA == 0 || nquAAxALYITIibPNBzomBIpKeZvkA == gBgcMNEWZAehBFnQJlKvAcpArvKuC._count + 1)
				{
					throw new Exception();
				}
				return new DictionaryEntry(yJbSrDemEtYaqGpIiiVlBaGUeajsA.Key, yJbSrDemEtYaqGpIiiVlBaGUeajsA.Value);
			}
		}

		object IDictionaryEnumerator.Key
		{
			get
			{
				if (nquAAxALYITIibPNBzomBIpKeZvkA == 0 || nquAAxALYITIibPNBzomBIpKeZvkA == gBgcMNEWZAehBFnQJlKvAcpArvKuC._count + 1)
				{
					throw new Exception();
				}
				return yJbSrDemEtYaqGpIiiVlBaGUeajsA.Key;
			}
		}

		object IDictionaryEnumerator.Value
		{
			get
			{
				if (nquAAxALYITIibPNBzomBIpKeZvkA == 0 || nquAAxALYITIibPNBzomBIpKeZvkA == gBgcMNEWZAehBFnQJlKvAcpArvKuC._count + 1)
				{
					throw new Exception();
				}
				return yJbSrDemEtYaqGpIiiVlBaGUeajsA.Value;
			}
		}

		internal Enumerator(ADictionary<TKey, TValue> P_0, int P_1)
		{
			gBgcMNEWZAehBFnQJlKvAcpArvKuC = P_0;
			xmRBkWbNXDcTQsdPeaehdjITavRS = P_0.FOagSzgIEXUXdvDxmAYsNAdzczvDA;
			nquAAxALYITIibPNBzomBIpKeZvkA = 0;
			hoTkymLKNFUStkwOzPwlSoQmOHOK = P_1;
			yJbSrDemEtYaqGpIiiVlBaGUeajsA = default;
		}

		public bool MoveNext()
		{
			if (xmRBkWbNXDcTQsdPeaehdjITavRS != gBgcMNEWZAehBFnQJlKvAcpArvKuC.FOagSzgIEXUXdvDxmAYsNAdzczvDA)
			{
				throw new Exception();
			}
			while ((uint)nquAAxALYITIibPNBzomBIpKeZvkA < (uint)gBgcMNEWZAehBFnQJlKvAcpArvKuC._count)
			{
				if (gBgcMNEWZAehBFnQJlKvAcpArvKuC._entries[nquAAxALYITIibPNBzomBIpKeZvkA].hashCode >= 0)
				{
					yJbSrDemEtYaqGpIiiVlBaGUeajsA = new KeyValuePair<TKey, TValue>(gBgcMNEWZAehBFnQJlKvAcpArvKuC._entries[nquAAxALYITIibPNBzomBIpKeZvkA].key, gBgcMNEWZAehBFnQJlKvAcpArvKuC._entries[nquAAxALYITIibPNBzomBIpKeZvkA].value);
					nquAAxALYITIibPNBzomBIpKeZvkA++;
					return true;
				}
				nquAAxALYITIibPNBzomBIpKeZvkA++;
			}
			nquAAxALYITIibPNBzomBIpKeZvkA = gBgcMNEWZAehBFnQJlKvAcpArvKuC._count + 1;
			yJbSrDemEtYaqGpIiiVlBaGUeajsA = default;
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		public KeyValuePair<TKey, TValue> get_Current()
		{
			return yJbSrDemEtYaqGpIiiVlBaGUeajsA;
		}

		public void Dispose()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		void IEnumerator.Reset()
		{
			if (xmRBkWbNXDcTQsdPeaehdjITavRS != gBgcMNEWZAehBFnQJlKvAcpArvKuC.FOagSzgIEXUXdvDxmAYsNAdzczvDA)
			{
				throw new Exception();
			}
			nquAAxALYITIibPNBzomBIpKeZvkA = 0;
			yJbSrDemEtYaqGpIiiVlBaGUeajsA = default;
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, ICollection
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<TKey>, IEnumerator, IDisposable
		{
			private ADictionary<TKey, TValue> blGhUhJbLcYrdxRIARjEcUZyHqHC;

			private int jFUAWICrBYdUoCNDnVWSxXYzPSMT;

			private int WAjjIbdlnAyLBuMrXhgGdpjKTiuIA;

			private TKey npdYGSuKphYtNsJkcahZUEQmfxTe;

			TKey IEnumerator<TKey>.Current => get_Current();

			object IEnumerator.Current
			{
				get
				{
					if (jFUAWICrBYdUoCNDnVWSxXYzPSMT == 0 || jFUAWICrBYdUoCNDnVWSxXYzPSMT == blGhUhJbLcYrdxRIARjEcUZyHqHC._count + 1)
					{
						throw new Exception();
					}
					return npdYGSuKphYtNsJkcahZUEQmfxTe;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> P_0)
			{
				blGhUhJbLcYrdxRIARjEcUZyHqHC = P_0;
				WAjjIbdlnAyLBuMrXhgGdpjKTiuIA = P_0.FOagSzgIEXUXdvDxmAYsNAdzczvDA;
				jFUAWICrBYdUoCNDnVWSxXYzPSMT = 0;
				npdYGSuKphYtNsJkcahZUEQmfxTe = default;
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
				if (WAjjIbdlnAyLBuMrXhgGdpjKTiuIA != blGhUhJbLcYrdxRIARjEcUZyHqHC.FOagSzgIEXUXdvDxmAYsNAdzczvDA)
				{
					throw new Exception();
				}
				while ((uint)jFUAWICrBYdUoCNDnVWSxXYzPSMT < (uint)blGhUhJbLcYrdxRIARjEcUZyHqHC._count)
				{
					if (blGhUhJbLcYrdxRIARjEcUZyHqHC._entries[jFUAWICrBYdUoCNDnVWSxXYzPSMT].hashCode >= 0)
					{
						npdYGSuKphYtNsJkcahZUEQmfxTe = blGhUhJbLcYrdxRIARjEcUZyHqHC._entries[jFUAWICrBYdUoCNDnVWSxXYzPSMT].key;
						jFUAWICrBYdUoCNDnVWSxXYzPSMT++;
						return true;
					}
					jFUAWICrBYdUoCNDnVWSxXYzPSMT++;
				}
				jFUAWICrBYdUoCNDnVWSxXYzPSMT = blGhUhJbLcYrdxRIARjEcUZyHqHC._count + 1;
				npdYGSuKphYtNsJkcahZUEQmfxTe = default;
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			public TKey get_Current()
			{
				return npdYGSuKphYtNsJkcahZUEQmfxTe;
			}

			void IEnumerator.Reset()
			{
				if (WAjjIbdlnAyLBuMrXhgGdpjKTiuIA != blGhUhJbLcYrdxRIARjEcUZyHqHC.FOagSzgIEXUXdvDxmAYsNAdzczvDA)
				{
					throw new Exception();
				}
				jFUAWICrBYdUoCNDnVWSxXYzPSMT = 0;
				npdYGSuKphYtNsJkcahZUEQmfxTe = default;
			}
		}

		private ADictionary<TKey, TValue> KEqmSkBQXhRappiQIqMheLRLKhoq;

		int ICollection<TKey>.Count => get_Count();

		bool ICollection<TKey>.IsReadOnly => OUMXgmQFHyfmKXZDOEjwPtijsjof();

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ((ICollection)KEqmSkBQXhRappiQIqMheLRLKhoq).SyncRoot;

		public KeyCollection(ADictionary<TKey, TValue> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			KEqmSkBQXhRappiQIqMheLRLKhoq = P_0;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(KEqmSkBQXhRappiQIqMheLRLKhoq);
		}

		public void CopyTo(TKey[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (array.Length - index < KEqmSkBQXhRappiQIqMheLRLKhoq.get_Count())
			{
				throw new Exception();
			}
			int count = KEqmSkBQXhRappiQIqMheLRLKhoq._count;
			Entry[] entries = KEqmSkBQXhRappiQIqMheLRLKhoq._entries;
			for (int i = 0; i < count; i++)
			{
				if (entries[i].hashCode >= 0)
				{
					array[index++] = entries[i].key;
				}
			}
		}

		void ICollection<TKey>.CopyTo(TKey[] array, int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CopyTo
			this.CopyTo(array, index);
		}

		public int get_Count()
		{
			return KEqmSkBQXhRappiQIqMheLRLKhoq.get_Count();
		}

		private bool OUMXgmQFHyfmKXZDOEjwPtijsjof()
		{
			return true;
		}

		private void UupnHEANvadrXFBwDAzaAxuFlvwM(TKey P_0)
		{
			throw new Exception();
		}

		void ICollection<TKey>.Add(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UupnHEANvadrXFBwDAzaAxuFlvwM
			this.UupnHEANvadrXFBwDAzaAxuFlvwM(P_0);
		}

		private void FDeIDpFKwKjOgDaadLLCGgUZrTKQA()
		{
			throw new Exception();
		}

		void ICollection<TKey>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in FDeIDpFKwKjOgDaadLLCGgUZrTKQA
			this.FDeIDpFKwKjOgDaadLLCGgUZrTKQA();
		}

		private bool ZcWuJlcTPoCFTznKHgryFXtZJohA(TKey P_0)
		{
			return KEqmSkBQXhRappiQIqMheLRLKhoq.ContainsKey(P_0);
		}

		bool ICollection<TKey>.Contains(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ZcWuJlcTPoCFTznKHgryFXtZJohA
			return this.ZcWuJlcTPoCFTznKHgryFXtZJohA(P_0);
		}

		private bool QpPELplsaKeJDfStZNjIPUaxkcbB(TKey P_0)
		{
			throw new Exception();
		}

		bool ICollection<TKey>.Remove(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QpPELplsaKeJDfStZNjIPUaxkcbB
			return this.QpPELplsaKeJDfStZNjIPUaxkcbB(P_0);
		}

		private IEnumerator<TKey> xwuvZOlqkztokSkjMVYZyWJnXjjK()
		{
			return new Enumerator(KEqmSkBQXhRappiQIqMheLRLKhoq);
		}

		IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in xwuvZOlqkztokSkjMVYZyWJnXjjK
			return this.xwuvZOlqkztokSkjMVYZyWJnXjjK();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(KEqmSkBQXhRappiQIqMheLRLKhoq);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new Exception();
			}
			if (array.GetLowerBound(0) != 0)
			{
				throw new Exception();
			}
			if (index < 0 || index > array.Length)
			{
				throw new Exception();
			}
			if (array.Length - index < KEqmSkBQXhRappiQIqMheLRLKhoq.get_Count())
			{
				throw new Exception();
			}
			if (array is TKey[] array2)
			{
				CopyTo(array2, index);
				return;
			}
			if (!(array is object[] array3))
			{
				throw new Exception();
			}
			int count = KEqmSkBQXhRappiQIqMheLRLKhoq._count;
			Entry[] entries = KEqmSkBQXhRappiQIqMheLRLKhoq._entries;
			try
			{
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array3[index++] = entries[i].key;
					}
				}
			}
			catch (ArrayTypeMismatchException)
			{
				throw new Exception();
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		[CustomObfuscation(rename = false)]
		public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
		{
			private ADictionary<TKey, TValue> orAnONNesQGDHCtjzoVyPGtneAGIb;

			private int diBdGNPBhkKmMeMdZdOrejSTPsqo;

			private int OMfZnYrEnJpMuGTfjfRjRIqmlCbb;

			private TValue ClIYaoWgTNIPawfDbYozBxTpCVAJ;

			TValue IEnumerator<TValue>.Current => get_Current();

			object IEnumerator.Current
			{
				get
				{
					if (diBdGNPBhkKmMeMdZdOrejSTPsqo == 0 || diBdGNPBhkKmMeMdZdOrejSTPsqo == orAnONNesQGDHCtjzoVyPGtneAGIb._count + 1)
					{
						throw new Exception();
					}
					return ClIYaoWgTNIPawfDbYozBxTpCVAJ;
				}
			}

			internal Enumerator(ADictionary<TKey, TValue> P_0)
			{
				orAnONNesQGDHCtjzoVyPGtneAGIb = P_0;
				OMfZnYrEnJpMuGTfjfRjRIqmlCbb = P_0.FOagSzgIEXUXdvDxmAYsNAdzczvDA;
				diBdGNPBhkKmMeMdZdOrejSTPsqo = 0;
				ClIYaoWgTNIPawfDbYozBxTpCVAJ = default;
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
				if (OMfZnYrEnJpMuGTfjfRjRIqmlCbb != orAnONNesQGDHCtjzoVyPGtneAGIb.FOagSzgIEXUXdvDxmAYsNAdzczvDA)
				{
					throw new Exception();
				}
				while ((uint)diBdGNPBhkKmMeMdZdOrejSTPsqo < (uint)orAnONNesQGDHCtjzoVyPGtneAGIb._count)
				{
					if (orAnONNesQGDHCtjzoVyPGtneAGIb._entries[diBdGNPBhkKmMeMdZdOrejSTPsqo].hashCode >= 0)
					{
						ClIYaoWgTNIPawfDbYozBxTpCVAJ = orAnONNesQGDHCtjzoVyPGtneAGIb._entries[diBdGNPBhkKmMeMdZdOrejSTPsqo].value;
						diBdGNPBhkKmMeMdZdOrejSTPsqo++;
						return true;
					}
					diBdGNPBhkKmMeMdZdOrejSTPsqo++;
				}
				diBdGNPBhkKmMeMdZdOrejSTPsqo = orAnONNesQGDHCtjzoVyPGtneAGIb._count + 1;
				ClIYaoWgTNIPawfDbYozBxTpCVAJ = default;
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			public TValue get_Current()
			{
				return ClIYaoWgTNIPawfDbYozBxTpCVAJ;
			}

			void IEnumerator.Reset()
			{
				if (OMfZnYrEnJpMuGTfjfRjRIqmlCbb != orAnONNesQGDHCtjzoVyPGtneAGIb.FOagSzgIEXUXdvDxmAYsNAdzczvDA)
				{
					throw new Exception();
				}
				diBdGNPBhkKmMeMdZdOrejSTPsqo = 0;
				ClIYaoWgTNIPawfDbYozBxTpCVAJ = default;
			}
		}

		private ADictionary<TKey, TValue> RGUAjcOAcHaNUMwTyNhFgHMytAuS;

		int ICollection<TValue>.Count => get_Count();

		bool ICollection<TValue>.IsReadOnly => sexdMFpgacewhDJsVDNSkSPGPsKXA();

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ((ICollection)RGUAjcOAcHaNUMwTyNhFgHMytAuS).SyncRoot;

		public ValueCollection(ADictionary<TKey, TValue> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			RGUAjcOAcHaNUMwTyNhFgHMytAuS = P_0;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(RGUAjcOAcHaNUMwTyNhFgHMytAuS);
		}

		public void CopyTo(TValue[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0 || index > array.Length)
			{
				throw new Exception();
			}
			if (array.Length - index < RGUAjcOAcHaNUMwTyNhFgHMytAuS.get_Count())
			{
				throw new Exception();
			}
			int count = RGUAjcOAcHaNUMwTyNhFgHMytAuS._count;
			Entry[] entries = RGUAjcOAcHaNUMwTyNhFgHMytAuS._entries;
			for (int i = 0; i < count; i++)
			{
				if (entries[i].hashCode >= 0)
				{
					array[index++] = entries[i].value;
				}
			}
		}

		void ICollection<TValue>.CopyTo(TValue[] array, int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CopyTo
			this.CopyTo(array, index);
		}

		public int get_Count()
		{
			return RGUAjcOAcHaNUMwTyNhFgHMytAuS.get_Count();
		}

		private bool sexdMFpgacewhDJsVDNSkSPGPsKXA()
		{
			return true;
		}

		private void uhrPTobbCOqvWJNpKabiQdGYLfrG(TValue P_0)
		{
			throw new Exception();
		}

		void ICollection<TValue>.Add(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in uhrPTobbCOqvWJNpKabiQdGYLfrG
			this.uhrPTobbCOqvWJNpKabiQdGYLfrG(P_0);
		}

		private bool raHBcUeVrvNhbtyqjCQsUJMXhFaHA(TValue P_0)
		{
			throw new Exception();
		}

		bool ICollection<TValue>.Remove(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in raHBcUeVrvNhbtyqjCQsUJMXhFaHA
			return this.raHBcUeVrvNhbtyqjCQsUJMXhFaHA(P_0);
		}

		private void LpxBAtdYroeByYfHIalhiOhxuPdB()
		{
			throw new Exception();
		}

		void ICollection<TValue>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in LpxBAtdYroeByYfHIalhiOhxuPdB
			this.LpxBAtdYroeByYfHIalhiOhxuPdB();
		}

		private bool hJRbdtZsOJdsbekKJXdlKtIKWIGn(TValue P_0)
		{
			return RGUAjcOAcHaNUMwTyNhFgHMytAuS.ContainsValue(P_0);
		}

		bool ICollection<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hJRbdtZsOJdsbekKJXdlKtIKWIGn
			return this.hJRbdtZsOJdsbekKJXdlKtIKWIGn(P_0);
		}

		private IEnumerator<TValue> rOtxmIudzvmsPJlewyJXpVVmQGnL()
		{
			return new Enumerator(RGUAjcOAcHaNUMwTyNhFgHMytAuS);
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in rOtxmIudzvmsPJlewyJXpVVmQGnL
			return this.rOtxmIudzvmsPJlewyJXpVVmQGnL();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(RGUAjcOAcHaNUMwTyNhFgHMytAuS);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new Exception();
			}
			if (array.GetLowerBound(0) != 0)
			{
				throw new Exception();
			}
			if (index < 0 || index > array.Length)
			{
				throw new Exception();
			}
			if (array.Length - index < RGUAjcOAcHaNUMwTyNhFgHMytAuS.get_Count())
			{
				throw new Exception();
			}
			if (array is TValue[] array2)
			{
				CopyTo(array2, index);
				return;
			}
			if (!(array is object[] array3))
			{
				throw new Exception();
			}
			int count = RGUAjcOAcHaNUMwTyNhFgHMytAuS._count;
			Entry[] entries = RGUAjcOAcHaNUMwTyNhFgHMytAuS._entries;
			try
			{
				for (int i = 0; i < count; i++)
				{
					if (entries[i].hashCode >= 0)
					{
						array3[index++] = entries[i].value;
					}
				}
			}
			catch (ArrayTypeMismatchException)
			{
				throw new Exception();
			}
		}
	}

	private int[] NVsrrSGDUfPFklGHnfuLiiEBIpWR;

	internal Entry[] _entries;

	internal int _count;

	private int FOagSzgIEXUXdvDxmAYsNAdzczvDA;

	private int OMfWplGZFTkpPEgwjenfCAmAEQPc;

	private int YAYcveHlsBGgaJtjArfYMNAGKhcjc;

	private int WJBswhMkwazaRpbBlXTWJbgiakqk;

	private IEqualityComparer<TKey> PhqNlwyLIsTVdQibVZvtqtQrOIxA;

	private IEqualityComparer<TValue> ddmmMFHShCJliWOSFMXsqLgQtPlx;

	private KeyCollection nxTvvMTudlLMnBEUgpqXRBGqeKHN;

	private ValueCollection sMAMoHwTdEYGlqBIIHFNiNiRemZY;

	private readonly object tLikjVpUgJBguMPWbVTUXAxcslli = new object();

	private static readonly bool tJcSnLLmatvStLTPNUuaqNrloWJE = ReflectionTools.IsValueType(typeof(TKey));

	private static readonly bool XDbVtzybQxwySEkOEdroiHpRQdWC = ReflectionTools.IsValueType(typeof(TValue));

	private const string wQEpxgPdtnhwENeHgzWDJNbVfUat = "Version";

	private const string sItwVGgNavFSNEfWbRQpcJtSpATjb = "HashSize";

	private const string hOCWhsmtFXgIZfsFnsBeiDERiRXr = "KeyValuePairs";

	private const string LtZZjcPVBbsAiYvgXNhnFNCYIhsN = "Comparer";

	int ICollection.Count => get_Count();

	public int TotalCount => _count;

	public KeyCollection Keys
	{
		get
		{
			if (nxTvvMTudlLMnBEUgpqXRBGqeKHN == null)
			{
				nxTvvMTudlLMnBEUgpqXRBGqeKHN = new KeyCollection(this);
			}
			return nxTvvMTudlLMnBEUgpqXRBGqeKHN;
		}
	}

	public ValueCollection Values
	{
		get
		{
			if (sMAMoHwTdEYGlqBIIHFNiNiRemZY == null)
			{
				sMAMoHwTdEYGlqBIIHFNiNiRemZY = new ValueCollection(this);
			}
			return sMAMoHwTdEYGlqBIIHFNiNiRemZY;
		}
	}

	public IEqualityComparer<TKey> KeyComparer
	{
		get
		{
			return PhqNlwyLIsTVdQibVZvtqtQrOIxA;
		}
		set
		{
			if (value == null)
			{
				value = EqualityComparerNoAlloc<TKey>.Default;
			}
			PhqNlwyLIsTVdQibVZvtqtQrOIxA = value;
		}
	}

	public IEqualityComparer<TValue> ValueComparer
	{
		get
		{
			return ddmmMFHShCJliWOSFMXsqLgQtPlx;
		}
		set
		{
			if (value == null)
			{
				value = EqualityComparerNoAlloc<TValue>.Default;
			}
			ddmmMFHShCJliWOSFMXsqLgQtPlx = value;
		}
	}

	TValue IDictionary<TKey, TValue>.this[TKey key]
	{
		get
		{
			return get_Item(key);
		}
		set
		{
			set_Item(key, value);
		}
	}

	public int IndexOfFirst
	{
		get
		{
			for (int i = 0; i < _count; i++)
			{
				if (_entries[i].hashCode >= 0)
				{
					return i;
				}
			}
			return -1;
		}
	}

	public int IndexOfLast
	{
		get
		{
			for (int num = _count - 1; num >= 0; num--)
			{
				if (_entries[num].hashCode >= 0)
				{
					return num;
				}
			}
			return -1;
		}
	}

	ICollection<TKey> IDictionary<TKey, TValue>.Keys => dBIsFazBXMvUibWrCuvbSwxMfanU();

	ICollection<TValue> IDictionary<TKey, TValue>.Values => cnJISsEgDUbNPNijinoulhgqFKbJ();

	bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => aSqFQauTvhLhaZRiQLCOGtmOVHcj();

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => tLikjVpUgJBguMPWbVTUXAxcslli;

	bool IDictionary.IsFixedSize => false;

	bool IDictionary.IsReadOnly => false;

	ICollection IDictionary.Keys => Keys;

	ICollection IDictionary.Values => Values;

	object IDictionary.this[object key]
	{
		get
		{
			if (DBofYBjgFFNvUIDxsbTmIrftnHPoA(key))
			{
				int num = IndexOfKey((TKey)key);
				if (num >= 0)
				{
					return _entries[num].value;
				}
			}
			return null;
		}
		set
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			PgJSgSehVaaidDuSgrVDacMwUEdvA<TValue>(value, "value");
			try
			{
				TKey key2 = (TKey)key;
				try
				{
					set_Item(key2, (TValue)value);
				}
				catch (InvalidCastException)
				{
					throw new Exception();
				}
			}
			catch (InvalidCastException)
			{
				throw new Exception();
			}
		}
	}

	ICollection<TKey> Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.Keys => oJguCuFTBIPeNjqVSKeBxkZIQedj();

	ICollection<TValue> Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.Values => jCjQyKSVMZgCpAYYXSQkdYrjsjab();

	public int get_Count()
	{
		return _count - WJBswhMkwazaRpbBlXTWJbgiakqk;
	}

	public TValue get_Item(TKey key)
	{
		int num = IndexOfKey(key);
		if (num < 0)
		{
			TKey val = key;
			throw new KeyNotFoundException("Key \"" + val?.ToString() + " does not exist.");
		}
		return _entries[num].value;
	}

	public void set_Item(TKey key, TValue value)
	{
		feUihZPtmRnrLDrgflXLlErKClss(key, value, false);
	}

	public ADictionary()
		: this(0, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
	{
	}

	public ADictionary(IEqualityComparer<TKey> P_0)
		: this(0, P_0, (IEqualityComparer<TValue>)null)
	{
	}

	public ADictionary(IEqualityComparer<TKey> P_0, IEqualityComparer<TValue> P_1)
		: this(0, P_0, P_1)
	{
	}

	public ADictionary(int P_0)
		: this(P_0, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
	{
	}

	public ADictionary(int P_0, IEqualityComparer<TKey> P_1)
		: this(P_0, P_1, (IEqualityComparer<TValue>)null)
	{
	}

	public ADictionary(int P_0, IEqualityComparer<TKey> P_1, IEqualityComparer<TValue> P_2)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		if (P_0 > 0)
		{
			ayQletTtuYGUSCqaGjCLkHUGDIgm(P_0);
		}
		PhqNlwyLIsTVdQibVZvtqtQrOIxA = P_1 ?? EqualityComparerNoAlloc<TKey>.Default;
		ddmmMFHShCJliWOSFMXsqLgQtPlx = P_2 ?? EqualityComparerNoAlloc<TValue>.Default;
	}

	public ADictionary(IDictionary<TKey, TValue> P_0)
		: this(P_0, (IEqualityComparer<TKey>)null, (IEqualityComparer<TValue>)null)
	{
	}

	public ADictionary(IDictionary<TKey, TValue> P_0, IEqualityComparer<TKey> P_1)
		: this(P_0, P_1, (IEqualityComparer<TValue>)null)
	{
	}

	public ADictionary(IDictionary<TKey, TValue> P_0, IEqualityComparer<TKey> P_1, IEqualityComparer<TValue> P_2)
		: this(P_0?.Count ?? 0, P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		foreach (KeyValuePair<TKey, TValue> item in P_0)
		{
			Add(item.Key, item.Value);
		}
	}

	public void Add(TKey key, TValue value)
	{
		feUihZPtmRnrLDrgflXLlErKClss(key, value, true);
	}

	void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Add
		this.Add(key, value);
	}

	public void Clear()
	{
		if (_count > 0)
		{
			for (int i = 0; i < NVsrrSGDUfPFklGHnfuLiiEBIpWR.Length; i++)
			{
				NVsrrSGDUfPFklGHnfuLiiEBIpWR[i] = -1;
			}
			Array.Clear(_entries, 0, _count);
			YAYcveHlsBGgaJtjArfYMNAGKhcjc = -1;
			_count = 0;
			WJBswhMkwazaRpbBlXTWJbgiakqk = 0;
			FOagSzgIEXUXdvDxmAYsNAdzczvDA++;
			OMfWplGZFTkpPEgwjenfCAmAEQPc++;
		}
	}

	void ICollection<KeyValuePair<TKey, TValue>>.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	void IDictionary.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	public bool ContainsKey(TKey key)
	{
		return IndexOfKey(key) >= 0;
	}

	bool IDictionary<TKey, TValue>.ContainsKey(TKey key)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ContainsKey
		return this.ContainsKey(key);
	}

	bool Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.ContainsKey(TKey key)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ContainsKey
		return this.ContainsKey(key);
	}

	public bool ContainsValue(TValue value)
	{
		return IndexOfValue(value) >= 0;
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this, 2);
	}

	public bool Remove(TKey key)
	{
		if (!tJcSnLLmatvStLTPNUuaqNrloWJE && key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (NVsrrSGDUfPFklGHnfuLiiEBIpWR != null)
		{
			int num = PhqNlwyLIsTVdQibVZvtqtQrOIxA.GetHashCode(key) & 0x7FFFFFFF;
			int num2 = num % NVsrrSGDUfPFklGHnfuLiiEBIpWR.Length;
			int num3 = -1;
			for (int num4 = NVsrrSGDUfPFklGHnfuLiiEBIpWR[num2]; num4 >= 0; num4 = _entries[num4].next)
			{
				if (_entries[num4].hashCode == num && PhqNlwyLIsTVdQibVZvtqtQrOIxA.Equals(_entries[num4].key, key))
				{
					if (num3 < 0)
					{
						NVsrrSGDUfPFklGHnfuLiiEBIpWR[num2] = _entries[num4].next;
					}
					else
					{
						_entries[num3].next = _entries[num4].next;
					}
					_entries[num4].hashCode = -1;
					_entries[num4].next = YAYcveHlsBGgaJtjArfYMNAGKhcjc;
					_entries[num4].key = default;
					_entries[num4].value = default;
					YAYcveHlsBGgaJtjArfYMNAGKhcjc = num4;
					WJBswhMkwazaRpbBlXTWJbgiakqk++;
					FOagSzgIEXUXdvDxmAYsNAdzczvDA++;
					return true;
				}
				num3 = num4;
			}
		}
		return false;
	}

	bool IDictionary<TKey, TValue>.Remove(TKey key)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Remove
		return this.Remove(key);
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		int num = IndexOfKey(key);
		if (num >= 0)
		{
			value = _entries[num].value;
			return true;
		}
		value = default;
		return false;
	}

	bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
	{
		//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
		return this.TryGetValue(key, out value);
	}

	bool Rewired.Utils.Interfaces.IReadOnlyDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
	{
		//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
		return this.TryGetValue(key, out value);
	}

	public TValue GetValueSafe(TKey key)
	{
		int num = IndexOfKey(key);
		if (num >= 0)
		{
			return _entries[num].value;
		}
		return default;
	}

	public int IndexOfKey(TKey key)
	{
		if (!tJcSnLLmatvStLTPNUuaqNrloWJE && key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (NVsrrSGDUfPFklGHnfuLiiEBIpWR != null)
		{
			int num = PhqNlwyLIsTVdQibVZvtqtQrOIxA.GetHashCode(key) & 0x7FFFFFFF;
			for (int num2 = NVsrrSGDUfPFklGHnfuLiiEBIpWR[num % NVsrrSGDUfPFklGHnfuLiiEBIpWR.Length]; num2 >= 0; num2 = _entries[num2].next)
			{
				if (_entries[num2].hashCode == num && PhqNlwyLIsTVdQibVZvtqtQrOIxA.Equals(_entries[num2].key, key))
				{
					return num2;
				}
			}
		}
		return -1;
	}

	public int IndexOfValue(TValue value)
	{
		Entry[] entries = _entries;
		if (!XDbVtzybQxwySEkOEdroiHpRQdWC && value == null)
		{
			for (int i = 0; i < _count; i++)
			{
				if (entries[i].hashCode >= 0 && entries[i].value == null)
				{
					return i;
				}
			}
		}
		else
		{
			IEqualityComparer<TValue> equalityComparer = ddmmMFHShCJliWOSFMXsqLgQtPlx;
			for (int j = 0; j < _count; j++)
			{
				if (entries[j].hashCode >= 0 && equalityComparer.Equals(entries[j].value, value))
				{
					return j;
				}
			}
		}
		return -1;
	}

	public bool IsValidAt(int index)
	{
		if ((uint)index >= (uint)_count)
		{
			return false;
		}
		return _entries[index].hashCode >= 0;
	}

	public TKey GetKeyAt(int index)
	{
		if ((uint)index >= (uint)_count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (_entries[index].hashCode < 0)
		{
			throw new ArgumentException("index points to an invalid entry.");
		}
		return _entries[index].key;
	}

	public TValue GetValueAt(int index)
	{
		if ((uint)index >= (uint)_count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (_entries[index].hashCode < 0)
		{
			throw new ArgumentException("index points to an invalid entry.");
		}
		return _entries[index].value;
	}

	public KeyValuePair<TKey, TValue> GetEntryAt(int index)
	{
		if ((uint)index >= (uint)_count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (_entries[index].hashCode < 0)
		{
			throw new ArgumentException("index points to an invalid entry.");
		}
		return new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
	}

	public bool TryGetKeyAt(int index, out TKey key)
	{
		if ((uint)index >= (uint)_count || _entries[index].hashCode < 0)
		{
			key = default;
			return false;
		}
		key = _entries[index].key;
		return true;
	}

	public bool TryGetValueAt(int index, out TValue value)
	{
		if ((uint)index >= (uint)_count || _entries[index].hashCode < 0)
		{
			value = default;
			return false;
		}
		value = _entries[index].value;
		return true;
	}

	public bool TryGetEntryAt(int index, out KeyValuePair<TKey, TValue> entry)
	{
		if ((uint)index >= (uint)_count || _entries[index].hashCode < 0)
		{
			entry = default;
			return false;
		}
		entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
		return true;
	}

	public bool GetNextIndex(ref int index)
	{
		index++;
		if ((uint)index >= (uint)_count)
		{
			return false;
		}
		while (index < _count)
		{
			if (_entries[index].hashCode >= 0)
			{
				return true;
			}
			index++;
		}
		return false;
	}

	public int GetNextIndex(int index)
	{
		index++;
		if ((uint)index >= (uint)_count)
		{
			return -1;
		}
		while (index < _count)
		{
			if (_entries[index].hashCode >= 0)
			{
				return index;
			}
			index++;
		}
		return -1;
	}

	public bool GetNextKey(ref int index, out TKey key)
	{
		index++;
		if ((uint)index >= (uint)_count)
		{
			key = default;
			return false;
		}
		while (index < _count)
		{
			if (_entries[index].hashCode >= 0)
			{
				key = _entries[index].key;
				return true;
			}
			index++;
		}
		key = default;
		return false;
	}

	public bool GetNextValue(ref int index, out TValue value)
	{
		index++;
		if ((uint)index >= (uint)_count)
		{
			value = default;
			return false;
		}
		while (index < _count)
		{
			if (_entries[index].hashCode >= 0)
			{
				value = _entries[index].value;
				return true;
			}
			index++;
		}
		value = default;
		return false;
	}

	public bool GetNextEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
	{
		index++;
		if ((uint)index >= (uint)_count)
		{
			entry = default;
			return false;
		}
		while (index < _count)
		{
			if (_entries[index].hashCode >= 0)
			{
				entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
				return true;
			}
			index++;
		}
		entry = default;
		return false;
	}

	public bool GetPreviousIndex(ref int index)
	{
		index--;
		if ((uint)index >= (uint)_count)
		{
			return false;
		}
		while (index >= 0)
		{
			if (_entries[index].hashCode >= 0)
			{
				return true;
			}
			index--;
		}
		return false;
	}

	public int GetPreviousIndex(int index)
	{
		index--;
		if ((uint)index >= (uint)_count)
		{
			return -1;
		}
		while (index >= 0)
		{
			if (_entries[index].hashCode >= 0)
			{
				return index;
			}
			index--;
		}
		return -1;
	}

	public bool GetPreviousKey(ref int index, out TKey key)
	{
		index--;
		if ((uint)index >= (uint)_count)
		{
			key = default;
			return false;
		}
		while (index >= 0)
		{
			if (_entries[index].hashCode >= 0)
			{
				key = _entries[index].key;
				return true;
			}
			index--;
		}
		key = default;
		return false;
	}

	public bool GetPreviousValue(ref int index, out TValue value)
	{
		index--;
		if ((uint)index >= (uint)_count)
		{
			value = default;
			return false;
		}
		while (index >= 0)
		{
			if (_entries[index].hashCode >= 0)
			{
				value = _entries[index].value;
				return true;
			}
			index--;
		}
		value = default;
		return false;
	}

	public bool GetPreviousEntry(ref int index, out KeyValuePair<TKey, TValue> entry)
	{
		index--;
		if ((uint)index >= (uint)_count)
		{
			entry = default;
			return false;
		}
		while (index >= 0)
		{
			if (_entries[index].hashCode >= 0)
			{
				entry = new KeyValuePair<TKey, TValue>(_entries[index].key, _entries[index].value);
				return true;
			}
			index--;
		}
		entry = default;
		return false;
	}

	public bool RemoveAt(int index)
	{
		if ((uint)index >= (uint)_count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (_entries[index].hashCode < 0)
		{
			return false;
		}
		Remove(_entries[index].key);
		return true;
	}

	private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (index < 0 || index > array.Length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (array.Length - index < get_Count())
		{
			throw new Exception();
		}
		int count = _count;
		Entry[] entries = _entries;
		for (int i = 0; i < count; i++)
		{
			if (entries[i].hashCode >= 0)
			{
				array[index++] = new KeyValuePair<TKey, TValue>(entries[i].key, entries[i].value);
			}
		}
	}

	private void ayQletTtuYGUSCqaGjCLkHUGDIgm(int P_0)
	{
		int num = zCPBqShmWGKhiRotsBcoaPmhiQqXb.stmSmhCRsoCHZdkgSTaiKfYhnjQS(P_0);
		NVsrrSGDUfPFklGHnfuLiiEBIpWR = new int[num];
		for (int i = 0; i < NVsrrSGDUfPFklGHnfuLiiEBIpWR.Length; i++)
		{
			NVsrrSGDUfPFklGHnfuLiiEBIpWR[i] = -1;
		}
		_entries = new Entry[num];
		YAYcveHlsBGgaJtjArfYMNAGKhcjc = -1;
	}

	private void feUihZPtmRnrLDrgflXLlErKClss(TKey P_0, TValue P_1, bool P_2)
	{
		if (!tJcSnLLmatvStLTPNUuaqNrloWJE && P_0 == null)
		{
			throw new ArgumentNullException("key");
		}
		if (NVsrrSGDUfPFklGHnfuLiiEBIpWR == null)
		{
			ayQletTtuYGUSCqaGjCLkHUGDIgm(0);
		}
		int num = PhqNlwyLIsTVdQibVZvtqtQrOIxA.GetHashCode(P_0) & 0x7FFFFFFF;
		int num2 = num % NVsrrSGDUfPFklGHnfuLiiEBIpWR.Length;
		for (int num3 = NVsrrSGDUfPFklGHnfuLiiEBIpWR[num2]; num3 >= 0; num3 = _entries[num3].next)
		{
			if (_entries[num3].hashCode == num && PhqNlwyLIsTVdQibVZvtqtQrOIxA.Equals(_entries[num3].key, P_0))
			{
				if (P_2)
				{
					throw new ArgumentException("An element with the same key already exists in the dictionary.");
				}
				_entries[num3].value = P_1;
				FOagSzgIEXUXdvDxmAYsNAdzczvDA++;
				return;
			}
		}
		int num4;
		if (WJBswhMkwazaRpbBlXTWJbgiakqk > 0)
		{
			num4 = YAYcveHlsBGgaJtjArfYMNAGKhcjc;
			YAYcveHlsBGgaJtjArfYMNAGKhcjc = _entries[num4].next;
			WJBswhMkwazaRpbBlXTWJbgiakqk--;
		}
		else
		{
			if (_count == _entries.Length)
			{
				ldQxqNBvbuuhWGsRFJCnDQzEtNbg();
				num2 = num % NVsrrSGDUfPFklGHnfuLiiEBIpWR.Length;
			}
			num4 = _count;
			_count++;
		}
		_entries[num4].hashCode = num;
		_entries[num4].next = NVsrrSGDUfPFklGHnfuLiiEBIpWR[num2];
		_entries[num4].key = P_0;
		_entries[num4].value = P_1;
		NVsrrSGDUfPFklGHnfuLiiEBIpWR[num2] = num4;
		FOagSzgIEXUXdvDxmAYsNAdzczvDA++;
		OMfWplGZFTkpPEgwjenfCAmAEQPc++;
	}

	private void ldQxqNBvbuuhWGsRFJCnDQzEtNbg()
	{
		dalJfrngOnTKDJqZqmcMSfcspiIN(zCPBqShmWGKhiRotsBcoaPmhiQqXb.KBHuOTwCGxSrErkszuQDdhBPSKAN(_count), false);
	}

	private void dalJfrngOnTKDJqZqmcMSfcspiIN(int P_0, bool P_1)
	{
		int[] array = new int[P_0];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = -1;
		}
		Entry[] array2 = new Entry[P_0];
		Array.Copy(_entries, 0, array2, 0, _count);
		if (P_1)
		{
			for (int j = 0; j < _count; j++)
			{
				if (array2[j].hashCode != -1)
				{
					array2[j].hashCode = PhqNlwyLIsTVdQibVZvtqtQrOIxA.GetHashCode(array2[j].key) & 0x7FFFFFFF;
				}
			}
		}
		for (int k = 0; k < _count; k++)
		{
			if (array2[k].hashCode >= 0)
			{
				int num = array2[k].hashCode % P_0;
				array2[k].next = array[num];
				array[num] = k;
			}
		}
		NVsrrSGDUfPFklGHnfuLiiEBIpWR = array;
		_entries = array2;
	}

	private ICollection<TKey> dBIsFazBXMvUibWrCuvbSwxMfanU()
	{
		if (nxTvvMTudlLMnBEUgpqXRBGqeKHN == null)
		{
			nxTvvMTudlLMnBEUgpqXRBGqeKHN = new KeyCollection(this);
		}
		return nxTvvMTudlLMnBEUgpqXRBGqeKHN;
	}

	private ICollection<TValue> cnJISsEgDUbNPNijinoulhgqFKbJ()
	{
		if (sMAMoHwTdEYGlqBIIHFNiNiRemZY == null)
		{
			sMAMoHwTdEYGlqBIIHFNiNiRemZY = new ValueCollection(this);
		}
		return sMAMoHwTdEYGlqBIIHFNiNiRemZY;
	}

	private IEnumerator<KeyValuePair<TKey, TValue>> hQdBhRgnGealjIXgAyPdQMgGZonBb()
	{
		return new Enumerator(this, 2);
	}

	IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in hQdBhRgnGealjIXgAyPdQMgGZonBb
		return this.hQdBhRgnGealjIXgAyPdQMgGZonBb();
	}

	private void dDZOjnMNxIsXmkZRvlQmXoCAgLvy(KeyValuePair<TKey, TValue> P_0)
	{
		Add(P_0.Key, P_0.Value);
	}

	void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in dDZOjnMNxIsXmkZRvlQmXoCAgLvy
		this.dDZOjnMNxIsXmkZRvlQmXoCAgLvy(P_0);
	}

	private bool bRaUZIVwYCtkOBPkNEGRLhKoEgHP(KeyValuePair<TKey, TValue> P_0)
	{
		int num = IndexOfKey(P_0.Key);
		if (num >= 0 && ddmmMFHShCJliWOSFMXsqLgQtPlx.Equals(_entries[num].value, P_0.Value))
		{
			return true;
		}
		return false;
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in bRaUZIVwYCtkOBPkNEGRLhKoEgHP
		return this.bRaUZIVwYCtkOBPkNEGRLhKoEgHP(P_0);
	}

	private bool dihxQRixUtLKRudHQqDUJglZdnrAA(KeyValuePair<TKey, TValue> P_0)
	{
		int num = IndexOfKey(P_0.Key);
		if (num >= 0 && ddmmMFHShCJliWOSFMXsqLgQtPlx.Equals(_entries[num].value, P_0.Value))
		{
			Remove(P_0.Key);
			return true;
		}
		return false;
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in dihxQRixUtLKRudHQqDUJglZdnrAA
		return this.dihxQRixUtLKRudHQqDUJglZdnrAA(P_0);
	}

	private bool aSqFQauTvhLhaZRiQLCOGtmOVHcj()
	{
		return false;
	}

	private void AAZCBrCCyTDtriWBUsqKAyGzSprt(KeyValuePair<TKey, TValue>[] P_0, int P_1)
	{
		CopyTo(P_0, P_1);
	}

	void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in AAZCBrCCyTDtriWBUsqKAyGzSprt
		this.AAZCBrCCyTDtriWBUsqKAyGzSprt(P_0, P_1);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (array.Rank != 1)
		{
			throw new Exception();
		}
		if (array.GetLowerBound(0) != 0)
		{
			throw new Exception();
		}
		if (index < 0 || index > array.Length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (array.Length - index < get_Count())
		{
			throw new Exception();
		}
		if (array is KeyValuePair<TKey, TValue>[] array2)
		{
			CopyTo(array2, index);
			return;
		}
		if (array is DictionaryEntry[])
		{
			DictionaryEntry[] array3 = array as DictionaryEntry[];
			Entry[] entries = _entries;
			for (int i = 0; i < _count; i++)
			{
				if (entries[i].hashCode >= 0)
				{
					array3[index++] = new DictionaryEntry(entries[i].key, entries[i].value);
				}
			}
			return;
		}
		if (!(array is object[] array4))
		{
			throw new Exception();
		}
		try
		{
			int count = _count;
			Entry[] entries2 = _entries;
			for (int j = 0; j < count; j++)
			{
				if (entries2[j].hashCode >= 0)
				{
					array4[index++] = new KeyValuePair<TKey, TValue>(entries2[j].key, entries2[j].value);
				}
			}
		}
		catch (ArrayTypeMismatchException)
		{
			throw new Exception();
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(this, 2);
	}

	void IDictionary.Add(object key, object value)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		PgJSgSehVaaidDuSgrVDacMwUEdvA<TValue>(value, "value");
		try
		{
			TKey key2 = (TKey)key;
			try
			{
				Add(key2, (TValue)value);
			}
			catch (InvalidCastException)
			{
				throw new Exception();
			}
		}
		catch (InvalidCastException)
		{
			throw new Exception();
		}
	}

	bool IDictionary.Contains(object key)
	{
		if (DBofYBjgFFNvUIDxsbTmIrftnHPoA(key))
		{
			return ContainsKey((TKey)key);
		}
		return false;
	}

	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		return new Enumerator(this, 1);
	}

	void IDictionary.Remove(object key)
	{
		if (DBofYBjgFFNvUIDxsbTmIrftnHPoA(key))
		{
			Remove((TKey)key);
		}
	}

	private ICollection<TKey> oJguCuFTBIPeNjqVSKeBxkZIQedj()
	{
		return Keys;
	}

	private ICollection<TValue> jCjQyKSVMZgCpAYYXSQkdYrjsjab()
	{
		return Values;
	}

	private static bool DBofYBjgFFNvUIDxsbTmIrftnHPoA(object P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("key");
		}
		return P_0 is TKey;
	}

	private static void PgJSgSehVaaidDuSgrVDacMwUEdvA<_0001>(object P_0, string P_1)
	{
		if (P_0 == null && default(_0001) != null)
		{
			throw new ArgumentNullException(P_1);
		}
	}
}
