using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal class IndexedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, Rewired.Utils.Interfaces.IReadOnlyList<TValue>, IReadOnlyList
{
	private struct zOdCKvIKwtSgzNzgWagEAwWtlYSDA(TKey P_0, TValue P_1)
	{
		public TKey ukHDOuOtICNfIBOXXozMAeKYtzNO = P_0;

		public TValue cmwKyYDYlKEySGiXFfKlmZkVLGYk = P_1;

		public KeyValuePair<TKey, TValue> UyqmLpcRMacooskMMfypBQarSdJNA()
		{
			return new KeyValuePair<TKey, TValue>(ukHDOuOtICNfIBOXXozMAeKYtzNO, cmwKyYDYlKEySGiXFfKlmZkVLGYk);
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
	{
		private IndexedDictionary<TKey, TValue> UDPbcHausxFrJqMugrMKiHNIGtliA;

		private int sNSvVIfohszXZqAQXhtCwgXjjUNo;

		private int ordODTxRXOLbuRIbNuBQmkWHhajc;

		private KeyValuePair<TKey, TValue> wCHelUztOFeQlsJuyDPpGGnjDbiIA;

		private int iPZnaCaWfecDiUkIDQIYREXDhCeGA;

		internal const int DictEntry = 1;

		internal const int KeyValuePair = 2;

		KeyValuePair<TKey, TValue> IEnumerator<KeyValuePair<TKey, TValue>>.Current => get_Current();

		object IEnumerator.Current
		{
			get
			{
				if (ordODTxRXOLbuRIbNuBQmkWHhajc == 0 || ordODTxRXOLbuRIbNuBQmkWHhajc == UDPbcHausxFrJqMugrMKiHNIGtliA.lXxewtswoAiEVqoagQhSzbohAmOQ._count + 1)
				{
					throw new Exception();
				}
				if (iPZnaCaWfecDiUkIDQIYREXDhCeGA == 1)
				{
					return new DictionaryEntry(wCHelUztOFeQlsJuyDPpGGnjDbiIA.Key, wCHelUztOFeQlsJuyDPpGGnjDbiIA.Value);
				}
				return new KeyValuePair<TKey, TValue>(wCHelUztOFeQlsJuyDPpGGnjDbiIA.Key, wCHelUztOFeQlsJuyDPpGGnjDbiIA.Value);
			}
		}

		DictionaryEntry IDictionaryEnumerator.Entry
		{
			get
			{
				if (ordODTxRXOLbuRIbNuBQmkWHhajc == 0 || ordODTxRXOLbuRIbNuBQmkWHhajc == UDPbcHausxFrJqMugrMKiHNIGtliA.lXxewtswoAiEVqoagQhSzbohAmOQ._count + 1)
				{
					throw new Exception();
				}
				return new DictionaryEntry(wCHelUztOFeQlsJuyDPpGGnjDbiIA.Key, wCHelUztOFeQlsJuyDPpGGnjDbiIA.Value);
			}
		}

		object IDictionaryEnumerator.Key
		{
			get
			{
				if (ordODTxRXOLbuRIbNuBQmkWHhajc == 0 || ordODTxRXOLbuRIbNuBQmkWHhajc == UDPbcHausxFrJqMugrMKiHNIGtliA.lXxewtswoAiEVqoagQhSzbohAmOQ._count + 1)
				{
					throw new Exception();
				}
				return wCHelUztOFeQlsJuyDPpGGnjDbiIA.Key;
			}
		}

		object IDictionaryEnumerator.Value
		{
			get
			{
				if (ordODTxRXOLbuRIbNuBQmkWHhajc == 0 || ordODTxRXOLbuRIbNuBQmkWHhajc == UDPbcHausxFrJqMugrMKiHNIGtliA.lXxewtswoAiEVqoagQhSzbohAmOQ._count + 1)
				{
					throw new Exception();
				}
				return wCHelUztOFeQlsJuyDPpGGnjDbiIA.Value;
			}
		}

		internal Enumerator(IndexedDictionary<TKey, TValue> P_0, int P_1)
		{
			UDPbcHausxFrJqMugrMKiHNIGtliA = P_0;
			sNSvVIfohszXZqAQXhtCwgXjjUNo = P_0.lXxewtswoAiEVqoagQhSzbohAmOQ.Version;
			ordODTxRXOLbuRIbNuBQmkWHhajc = 0;
			iPZnaCaWfecDiUkIDQIYREXDhCeGA = P_1;
			wCHelUztOFeQlsJuyDPpGGnjDbiIA = default;
		}

		public bool MoveNext()
		{
			if (sNSvVIfohszXZqAQXhtCwgXjjUNo != UDPbcHausxFrJqMugrMKiHNIGtliA.lXxewtswoAiEVqoagQhSzbohAmOQ.Version)
			{
				throw new Exception();
			}
			if ((uint)ordODTxRXOLbuRIbNuBQmkWHhajc < (uint)UDPbcHausxFrJqMugrMKiHNIGtliA.lXxewtswoAiEVqoagQhSzbohAmOQ._count)
			{
				wCHelUztOFeQlsJuyDPpGGnjDbiIA = new KeyValuePair<TKey, TValue>(UDPbcHausxFrJqMugrMKiHNIGtliA.lXxewtswoAiEVqoagQhSzbohAmOQ._items[ordODTxRXOLbuRIbNuBQmkWHhajc].ukHDOuOtICNfIBOXXozMAeKYtzNO, UDPbcHausxFrJqMugrMKiHNIGtliA.lXxewtswoAiEVqoagQhSzbohAmOQ._items[ordODTxRXOLbuRIbNuBQmkWHhajc].cmwKyYDYlKEySGiXFfKlmZkVLGYk);
				ordODTxRXOLbuRIbNuBQmkWHhajc++;
				return true;
			}
			ordODTxRXOLbuRIbNuBQmkWHhajc = UDPbcHausxFrJqMugrMKiHNIGtliA.lXxewtswoAiEVqoagQhSzbohAmOQ._count + 1;
			wCHelUztOFeQlsJuyDPpGGnjDbiIA = default;
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		public KeyValuePair<TKey, TValue> get_Current()
		{
			return wCHelUztOFeQlsJuyDPpGGnjDbiIA;
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
			if (sNSvVIfohszXZqAQXhtCwgXjjUNo != UDPbcHausxFrJqMugrMKiHNIGtliA.lXxewtswoAiEVqoagQhSzbohAmOQ.Version)
			{
				throw new Exception();
			}
			ordODTxRXOLbuRIbNuBQmkWHhajc = 0;
			wCHelUztOFeQlsJuyDPpGGnjDbiIA = default;
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
			private IndexedDictionary<TKey, TValue> BshEWTbAGHOtMuGPEPTSJSjXhTwd;

			private int CDiKCkUvBUSrdrUYyosNlMAPsWfR;

			private int zcxHYYwrqbIOzWPgmjgScRjfyYiN;

			private TKey MYQZoWJXKBGmFycGkGUzpTYtAHJX;

			TKey IEnumerator<TKey>.Current => get_Current();

			object IEnumerator.Current
			{
				get
				{
					if (CDiKCkUvBUSrdrUYyosNlMAPsWfR == 0 || CDiKCkUvBUSrdrUYyosNlMAPsWfR == BshEWTbAGHOtMuGPEPTSJSjXhTwd.lXxewtswoAiEVqoagQhSzbohAmOQ._count + 1)
					{
						throw new Exception();
					}
					return MYQZoWJXKBGmFycGkGUzpTYtAHJX;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
			{
				BshEWTbAGHOtMuGPEPTSJSjXhTwd = P_0;
				zcxHYYwrqbIOzWPgmjgScRjfyYiN = P_0.lXxewtswoAiEVqoagQhSzbohAmOQ.Version;
				CDiKCkUvBUSrdrUYyosNlMAPsWfR = 0;
				MYQZoWJXKBGmFycGkGUzpTYtAHJX = default;
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
				if (zcxHYYwrqbIOzWPgmjgScRjfyYiN != BshEWTbAGHOtMuGPEPTSJSjXhTwd.lXxewtswoAiEVqoagQhSzbohAmOQ.Version)
				{
					throw new Exception();
				}
				if ((uint)CDiKCkUvBUSrdrUYyosNlMAPsWfR < (uint)BshEWTbAGHOtMuGPEPTSJSjXhTwd.lXxewtswoAiEVqoagQhSzbohAmOQ._count)
				{
					MYQZoWJXKBGmFycGkGUzpTYtAHJX = BshEWTbAGHOtMuGPEPTSJSjXhTwd.lXxewtswoAiEVqoagQhSzbohAmOQ._items[CDiKCkUvBUSrdrUYyosNlMAPsWfR].ukHDOuOtICNfIBOXXozMAeKYtzNO;
					CDiKCkUvBUSrdrUYyosNlMAPsWfR++;
					return true;
				}
				CDiKCkUvBUSrdrUYyosNlMAPsWfR = BshEWTbAGHOtMuGPEPTSJSjXhTwd.lXxewtswoAiEVqoagQhSzbohAmOQ._count + 1;
				MYQZoWJXKBGmFycGkGUzpTYtAHJX = default;
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			public TKey get_Current()
			{
				return MYQZoWJXKBGmFycGkGUzpTYtAHJX;
			}

			void IEnumerator.Reset()
			{
				if (zcxHYYwrqbIOzWPgmjgScRjfyYiN != BshEWTbAGHOtMuGPEPTSJSjXhTwd.lXxewtswoAiEVqoagQhSzbohAmOQ.Version)
				{
					throw new Exception();
				}
				CDiKCkUvBUSrdrUYyosNlMAPsWfR = 0;
				MYQZoWJXKBGmFycGkGUzpTYtAHJX = default;
			}
		}

		private IndexedDictionary<TKey, TValue> cZkzzSRxazSjOnLbTRUnjRnYGgjS;

		int ICollection<TKey>.Count => get_Count();

		bool ICollection<TKey>.IsReadOnly => AKCzglCYQVybKnwkYxBEBzXSDIOB();

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ((ICollection)cZkzzSRxazSjOnLbTRUnjRnYGgjS).SyncRoot;

		public KeyCollection(IndexedDictionary<TKey, TValue> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			cZkzzSRxazSjOnLbTRUnjRnYGgjS = P_0;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(cZkzzSRxazSjOnLbTRUnjRnYGgjS);
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
			if (array.Length - index < cZkzzSRxazSjOnLbTRUnjRnYGgjS.get_Count())
			{
				throw new Exception();
			}
			int count = cZkzzSRxazSjOnLbTRUnjRnYGgjS.lXxewtswoAiEVqoagQhSzbohAmOQ._count;
			zOdCKvIKwtSgzNzgWagEAwWtlYSDA[] items = cZkzzSRxazSjOnLbTRUnjRnYGgjS.lXxewtswoAiEVqoagQhSzbohAmOQ._items;
			for (int i = 0; i < count; i++)
			{
				array[index++] = items[i].ukHDOuOtICNfIBOXXozMAeKYtzNO;
			}
		}

		void ICollection<TKey>.CopyTo(TKey[] array, int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CopyTo
			this.CopyTo(array, index);
		}

		public int get_Count()
		{
			return cZkzzSRxazSjOnLbTRUnjRnYGgjS.get_Count();
		}

		private bool AKCzglCYQVybKnwkYxBEBzXSDIOB()
		{
			return true;
		}

		private void KTWRlkDLqLEUIIGrFlwZNmIdVlWb(TKey P_0)
		{
			throw new Exception();
		}

		void ICollection<TKey>.Add(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in KTWRlkDLqLEUIIGrFlwZNmIdVlWb
			this.KTWRlkDLqLEUIIGrFlwZNmIdVlWb(P_0);
		}

		private void uAhjptcTDnZjqfrLIhXEAthClzfaB()
		{
			throw new Exception();
		}

		void ICollection<TKey>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in uAhjptcTDnZjqfrLIhXEAthClzfaB
			this.uAhjptcTDnZjqfrLIhXEAthClzfaB();
		}

		private bool SFQNeygtHtTtLnXXfQfYqwpiqEzN(TKey P_0)
		{
			return cZkzzSRxazSjOnLbTRUnjRnYGgjS.ContainsKey(P_0);
		}

		bool ICollection<TKey>.Contains(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SFQNeygtHtTtLnXXfQfYqwpiqEzN
			return this.SFQNeygtHtTtLnXXfQfYqwpiqEzN(P_0);
		}

		private bool JrBrwgCjTgLfRtIsiPQwKoaVeaUc(TKey P_0)
		{
			throw new Exception();
		}

		bool ICollection<TKey>.Remove(TKey P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in JrBrwgCjTgLfRtIsiPQwKoaVeaUc
			return this.JrBrwgCjTgLfRtIsiPQwKoaVeaUc(P_0);
		}

		private IEnumerator<TKey> bguoRGaeuJbsCkWcYAOWODVKCvTMA()
		{
			return new Enumerator(cZkzzSRxazSjOnLbTRUnjRnYGgjS);
		}

		IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in bguoRGaeuJbsCkWcYAOWODVKCvTMA
			return this.bguoRGaeuJbsCkWcYAOWODVKCvTMA();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(cZkzzSRxazSjOnLbTRUnjRnYGgjS);
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
			if (array.Length - index < cZkzzSRxazSjOnLbTRUnjRnYGgjS.get_Count())
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
			int count = cZkzzSRxazSjOnLbTRUnjRnYGgjS.lXxewtswoAiEVqoagQhSzbohAmOQ._count;
			zOdCKvIKwtSgzNzgWagEAwWtlYSDA[] items = cZkzzSRxazSjOnLbTRUnjRnYGgjS.lXxewtswoAiEVqoagQhSzbohAmOQ._items;
			try
			{
				for (int i = 0; i < count; i++)
				{
					array3[index++] = items[i].ukHDOuOtICNfIBOXXozMAeKYtzNO;
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
			private IndexedDictionary<TKey, TValue> WaHQsbBtZikbyKAdoLLluXmFxfsE;

			private int VMMbtGZzkFpiDVqucqdCvODmgCZCA;

			private int cHipTwOpArzmICqWzZaaXFPvaZYP;

			private TValue FLSRAIoImKpRoibmSzWlzCLDUtgQ;

			TValue IEnumerator<TValue>.Current => get_Current();

			object IEnumerator.Current
			{
				get
				{
					if (VMMbtGZzkFpiDVqucqdCvODmgCZCA == 0 || VMMbtGZzkFpiDVqucqdCvODmgCZCA == WaHQsbBtZikbyKAdoLLluXmFxfsE.lXxewtswoAiEVqoagQhSzbohAmOQ._count + 1)
					{
						throw new Exception();
					}
					return FLSRAIoImKpRoibmSzWlzCLDUtgQ;
				}
			}

			internal Enumerator(IndexedDictionary<TKey, TValue> P_0)
			{
				WaHQsbBtZikbyKAdoLLluXmFxfsE = P_0;
				cHipTwOpArzmICqWzZaaXFPvaZYP = P_0.lXxewtswoAiEVqoagQhSzbohAmOQ.Version;
				VMMbtGZzkFpiDVqucqdCvODmgCZCA = 0;
				FLSRAIoImKpRoibmSzWlzCLDUtgQ = default;
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
				if (cHipTwOpArzmICqWzZaaXFPvaZYP != WaHQsbBtZikbyKAdoLLluXmFxfsE.lXxewtswoAiEVqoagQhSzbohAmOQ.Version)
				{
					throw new Exception();
				}
				if ((uint)VMMbtGZzkFpiDVqucqdCvODmgCZCA < (uint)WaHQsbBtZikbyKAdoLLluXmFxfsE.lXxewtswoAiEVqoagQhSzbohAmOQ._count)
				{
					FLSRAIoImKpRoibmSzWlzCLDUtgQ = WaHQsbBtZikbyKAdoLLluXmFxfsE.lXxewtswoAiEVqoagQhSzbohAmOQ._items[VMMbtGZzkFpiDVqucqdCvODmgCZCA].cmwKyYDYlKEySGiXFfKlmZkVLGYk;
					VMMbtGZzkFpiDVqucqdCvODmgCZCA++;
					return true;
				}
				VMMbtGZzkFpiDVqucqdCvODmgCZCA = WaHQsbBtZikbyKAdoLLluXmFxfsE.lXxewtswoAiEVqoagQhSzbohAmOQ._count + 1;
				FLSRAIoImKpRoibmSzWlzCLDUtgQ = default;
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			public TValue get_Current()
			{
				return FLSRAIoImKpRoibmSzWlzCLDUtgQ;
			}

			void IEnumerator.Reset()
			{
				if (cHipTwOpArzmICqWzZaaXFPvaZYP != WaHQsbBtZikbyKAdoLLluXmFxfsE.lXxewtswoAiEVqoagQhSzbohAmOQ.Version)
				{
					throw new Exception();
				}
				VMMbtGZzkFpiDVqucqdCvODmgCZCA = 0;
				FLSRAIoImKpRoibmSzWlzCLDUtgQ = default;
			}
		}

		private IndexedDictionary<TKey, TValue> JwCVReTVHYmFShMnvcsXDGjuiLHt;

		int ICollection<TValue>.Count => get_Count();

		bool ICollection<TValue>.IsReadOnly => scwEvCqVZPnghcsPyHFIWrYUjAmg();

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ((ICollection)JwCVReTVHYmFShMnvcsXDGjuiLHt).SyncRoot;

		public ValueCollection(IndexedDictionary<TKey, TValue> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			JwCVReTVHYmFShMnvcsXDGjuiLHt = P_0;
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(JwCVReTVHYmFShMnvcsXDGjuiLHt);
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
			if (array.Length - index < JwCVReTVHYmFShMnvcsXDGjuiLHt.get_Count())
			{
				throw new Exception();
			}
			int count = JwCVReTVHYmFShMnvcsXDGjuiLHt.lXxewtswoAiEVqoagQhSzbohAmOQ._count;
			zOdCKvIKwtSgzNzgWagEAwWtlYSDA[] items = JwCVReTVHYmFShMnvcsXDGjuiLHt.lXxewtswoAiEVqoagQhSzbohAmOQ._items;
			for (int i = 0; i < count; i++)
			{
				array[index++] = items[i].cmwKyYDYlKEySGiXFfKlmZkVLGYk;
			}
		}

		void ICollection<TValue>.CopyTo(TValue[] array, int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CopyTo
			this.CopyTo(array, index);
		}

		public int get_Count()
		{
			return JwCVReTVHYmFShMnvcsXDGjuiLHt.get_Count();
		}

		private bool scwEvCqVZPnghcsPyHFIWrYUjAmg()
		{
			return true;
		}

		private void fprBFHFSoTMvNjbIXxpAPjvesiApA(TValue P_0)
		{
			throw new Exception();
		}

		void ICollection<TValue>.Add(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in fprBFHFSoTMvNjbIXxpAPjvesiApA
			this.fprBFHFSoTMvNjbIXxpAPjvesiApA(P_0);
		}

		private bool sfvgXlCaHQCqwXJeOzFdIMqMVZpdA(TValue P_0)
		{
			throw new Exception();
		}

		bool ICollection<TValue>.Remove(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in sfvgXlCaHQCqwXJeOzFdIMqMVZpdA
			return this.sfvgXlCaHQCqwXJeOzFdIMqMVZpdA(P_0);
		}

		private void erlbwFvTxiuTXayeEeqZyxoPmsZV()
		{
			throw new Exception();
		}

		void ICollection<TValue>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in erlbwFvTxiuTXayeEeqZyxoPmsZV
			this.erlbwFvTxiuTXayeEeqZyxoPmsZV();
		}

		private bool DEIndInFotgUSgiVxLVETBkcGRSr(TValue P_0)
		{
			return JwCVReTVHYmFShMnvcsXDGjuiLHt.ContainsValue(P_0);
		}

		bool ICollection<TValue>.Contains(TValue P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DEIndInFotgUSgiVxLVETBkcGRSr
			return this.DEIndInFotgUSgiVxLVETBkcGRSr(P_0);
		}

		private IEnumerator<TValue> DkbdTEJaywFNGgiFEhGeFlpvpKWyA()
		{
			return new Enumerator(JwCVReTVHYmFShMnvcsXDGjuiLHt);
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DkbdTEJaywFNGgiFEhGeFlpvpKWyA
			return this.DkbdTEJaywFNGgiFEhGeFlpvpKWyA();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(JwCVReTVHYmFShMnvcsXDGjuiLHt);
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
			if (array.Length - index < JwCVReTVHYmFShMnvcsXDGjuiLHt.get_Count())
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
			int count = JwCVReTVHYmFShMnvcsXDGjuiLHt.lXxewtswoAiEVqoagQhSzbohAmOQ._count;
			zOdCKvIKwtSgzNzgWagEAwWtlYSDA[] items = JwCVReTVHYmFShMnvcsXDGjuiLHt.lXxewtswoAiEVqoagQhSzbohAmOQ._items;
			try
			{
				for (int i = 0; i < count; i++)
				{
					array3[index++] = items[i].cmwKyYDYlKEySGiXFfKlmZkVLGYk;
				}
			}
			catch (ArrayTypeMismatchException)
			{
				throw new Exception();
			}
		}
	}

	private static readonly bool qYOZWSncKyAhhYodpXTxJoWmAKBbA = ReflectionTools.IsValueType(typeof(TKey));

	private static readonly bool KDOTHWutkFjwzHJGCvBkCNoiciXdA = ReflectionTools.IsValueType(typeof(TValue));

	private IEqualityComparer<TKey> FKpMaHNmHqJLVkElNCpwnRSPraxo = EqualityComparerNoAlloc<TKey>.Default;

	private IEqualityComparer<TValue> djeDABxQdBSTDIIikWqKtuxYSoyk = EqualityComparerNoAlloc<TValue>.Default;

	private readonly AList<zOdCKvIKwtSgzNzgWagEAwWtlYSDA> lXxewtswoAiEVqoagQhSzbohAmOQ;

	private readonly ADictionary<TKey, int> RLKbheczHHYKsTiJiesOFkCaFJUdA;

	private bool lGnNIOUyosMiuHXRxuOIImVSqtZC;

	int ICollection<KeyValuePair<TKey, TValue>>.Count => get_Count();

	public bool ContainsDuplicateKeys
	{
		get
		{
			if (!lGnNIOUyosMiuHXRxuOIImVSqtZC)
			{
				return false;
			}
			return RLKbheczHHYKsTiJiesOFkCaFJUdA._count < lXxewtswoAiEVqoagQhSzbohAmOQ._count;
		}
	}

	public bool AllowDuplicateKeys
	{
		get
		{
			return lGnNIOUyosMiuHXRxuOIImVSqtZC;
		}
		set
		{
			if (lGnNIOUyosMiuHXRxuOIImVSqtZC != value)
			{
				lGnNIOUyosMiuHXRxuOIImVSqtZC = value;
				if (!value && ContainsDuplicateKeys)
				{
					throw new Exception("The dictionary contains duplicate keys and cannot be changed unless the keys are removed.");
				}
			}
		}
	}

	public TValue this[int index]
	{
		get
		{
			if ((uint)index >= (uint)lXxewtswoAiEVqoagQhSzbohAmOQ._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return lXxewtswoAiEVqoagQhSzbohAmOQ._items[index].cmwKyYDYlKEySGiXFfKlmZkVLGYk;
		}
		set
		{
			if ((uint)index >= (uint)lXxewtswoAiEVqoagQhSzbohAmOQ._count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			lXxewtswoAiEVqoagQhSzbohAmOQ._items[index].cmwKyYDYlKEySGiXFfKlmZkVLGYk = value;
		}
	}

	public IEqualityComparer<TKey> KeyComparer
	{
		get
		{
			return FKpMaHNmHqJLVkElNCpwnRSPraxo;
		}
		set
		{
			if (value == null)
			{
				value = EqualityComparerNoAlloc<TKey>.Default;
			}
			FKpMaHNmHqJLVkElNCpwnRSPraxo = value;
		}
	}

	public IEqualityComparer<TValue> ValueComparer
	{
		get
		{
			return djeDABxQdBSTDIIikWqKtuxYSoyk;
		}
		set
		{
			if (value == null)
			{
				value = EqualityComparerNoAlloc<TValue>.Default;
			}
			djeDABxQdBSTDIIikWqKtuxYSoyk = value;
		}
	}

	ICollection<TKey> IDictionary<TKey, TValue>.Keys => get_Keys();

	ICollection<TValue> IDictionary<TKey, TValue>.Values => get_Values();

	bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => KeFuOUfKeoWQimfPArNVHnCtaQWd();

	TValue IDictionary<TKey, TValue>.this[TKey P_0]
	{
		get
		{
			return QelBrsfCoFVaHwsGSVvaUAUdZUcM(P_0);
		}
		set
		{
			acGcTzBvZEEGbrSKMfQFLvvyafjJ(val, val2);
		}
	}

	bool IDictionary.IsFixedSize => false;

	bool IDictionary.IsReadOnly => false;

	ICollection IDictionary.Keys => new KeyCollection(this);

	ICollection IDictionary.Values => new ValueCollection(this);

	object IDictionary.this[object key]
	{
		get
		{
			return ((IDictionary<TKey, TValue>)this)[(TKey)key];
		}
		set
		{
			((IDictionary<TKey, TValue>)this)[(TKey)key] = (TValue)value;
		}
	}

	bool ICollection.IsSynchronized => ((ICollection)lXxewtswoAiEVqoagQhSzbohAmOQ).IsSynchronized;

	object ICollection.SyncRoot => ((ICollection)lXxewtswoAiEVqoagQhSzbohAmOQ).SyncRoot;

	TValue Rewired.Utils.Interfaces.IReadOnlyList<TValue>.this[int P_0] => QFlDgEuuqaBlLSfxeVRACYnQHLMt(P_0);

	int IReadOnlyList.Count => iUaylDohxGWMyeccCQvYXtAoOJOr();

	object IReadOnlyList.this[int P_0] => PdNGSghZsOlDuvaDUOKjPCXHlaxOA(P_0);

	public int get_Count()
	{
		return lXxewtswoAiEVqoagQhSzbohAmOQ._count;
	}

	public IndexedDictionary()
		: this(0, false)
	{
	}

	public IndexedDictionary(int P_0)
		: this(P_0, false)
	{
	}

	public IndexedDictionary(bool P_0)
		: this(0, P_0)
	{
	}

	public IndexedDictionary(int P_0, bool P_1)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		lGnNIOUyosMiuHXRxuOIImVSqtZC = P_1;
		lXxewtswoAiEVqoagQhSzbohAmOQ = new AList<zOdCKvIKwtSgzNzgWagEAwWtlYSDA>(P_0);
		RLKbheczHHYKsTiJiesOFkCaFJUdA = new ADictionary<TKey, int>(P_0);
	}

	public IndexedDictionary(IDictionary<TKey, TValue> P_0)
		: this(P_0, false)
	{
	}

	public IndexedDictionary(IDictionary<TKey, TValue> P_0, bool P_1)
		: this(0, P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		if (ReflectionTools.DoesTypeImplement(P_0.GetType(), typeof(IndexedDictionary<TKey, TValue>)))
		{
			IndexedDictionary<TKey, TValue> indexedDictionary = (IndexedDictionary<TKey, TValue>)P_0;
			for (int i = 0; i < indexedDictionary.lXxewtswoAiEVqoagQhSzbohAmOQ._count; i++)
			{
				Add(indexedDictionary.lXxewtswoAiEVqoagQhSzbohAmOQ._items[i].ukHDOuOtICNfIBOXXozMAeKYtzNO, indexedDictionary.lXxewtswoAiEVqoagQhSzbohAmOQ._items[i].cmwKyYDYlKEySGiXFfKlmZkVLGYk);
			}
			return;
		}
		foreach (KeyValuePair<TKey, TValue> item in P_0)
		{
			Add(item.Key, item.Value);
		}
	}

	public TValue GetValue(TKey key)
	{
		return lXxewtswoAiEVqoagQhSzbohAmOQ._items[RLKbheczHHYKsTiJiesOFkCaFJUdA.get_Item(key)].cmwKyYDYlKEySGiXFfKlmZkVLGYk;
	}

	public bool TryGetValue(TKey key, out TValue value)
	{
		if (!RLKbheczHHYKsTiJiesOFkCaFJUdA.TryGetValue(key, out var value2))
		{
			value = default;
			return false;
		}
		value = lXxewtswoAiEVqoagQhSzbohAmOQ._items[value2].cmwKyYDYlKEySGiXFfKlmZkVLGYk;
		return true;
	}

	bool IDictionary<TKey, TValue>.TryGetValue(TKey key, out TValue value)
	{
		//ILSpy generated this explicit interface implementation from .override directive in TryGetValue
		return this.TryGetValue(key, out value);
	}

	public TKey GetKeyAt(int index)
	{
		if ((uint)index >= (uint)lXxewtswoAiEVqoagQhSzbohAmOQ._count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return lXxewtswoAiEVqoagQhSzbohAmOQ.get_Item(index).ukHDOuOtICNfIBOXXozMAeKYtzNO;
	}

	public KeyValuePair<TKey, TValue> GetEntry(TKey key)
	{
		return lXxewtswoAiEVqoagQhSzbohAmOQ.get_Item(RLKbheczHHYKsTiJiesOFkCaFJUdA.get_Item(key)).UyqmLpcRMacooskMMfypBQarSdJNA();
	}

	public KeyValuePair<TKey, TValue> GetEntryAt(int index)
	{
		if ((uint)index >= (uint)lXxewtswoAiEVqoagQhSzbohAmOQ._count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		return lXxewtswoAiEVqoagQhSzbohAmOQ.get_Item(index).UyqmLpcRMacooskMMfypBQarSdJNA();
	}

	public bool TryGetEntry(TKey key, out KeyValuePair<TKey, TValue> entry)
	{
		if (!RLKbheczHHYKsTiJiesOFkCaFJUdA.TryGetValue(key, out var value))
		{
			entry = default;
			return false;
		}
		entry = lXxewtswoAiEVqoagQhSzbohAmOQ.get_Item(value).UyqmLpcRMacooskMMfypBQarSdJNA();
		return true;
	}

	public void Add(TKey key, TValue value)
	{
		bool num = RLKbheczHHYKsTiJiesOFkCaFJUdA.ContainsKey(key);
		if (num && !lGnNIOUyosMiuHXRxuOIImVSqtZC)
		{
			TKey val = key;
			throw new ArgumentException("Key \"" + val?.ToString() + "\" is already in use.");
		}
		int value2 = lXxewtswoAiEVqoagQhSzbohAmOQ.Add(new zOdCKvIKwtSgzNzgWagEAwWtlYSDA(key, value));
		if (num)
		{
			RLKbheczHHYKsTiJiesOFkCaFJUdA.set_Item(key, value2);
		}
		else
		{
			RLKbheczHHYKsTiJiesOFkCaFJUdA.Add(key, value2);
		}
	}

	void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Add
		this.Add(key, value);
	}

	public void SetValue(TKey key, TValue value)
	{
		if (RLKbheczHHYKsTiJiesOFkCaFJUdA.TryGetValue(key, out var value2))
		{
			lXxewtswoAiEVqoagQhSzbohAmOQ._items[value2].cmwKyYDYlKEySGiXFfKlmZkVLGYk = value;
			RLKbheczHHYKsTiJiesOFkCaFJUdA.set_Item(key, value2);
		}
		else
		{
			Add(key, value);
		}
	}

	public bool Remove(TKey key)
	{
		RLKbheczHHYKsTiJiesOFkCaFJUdA.Remove(key);
		if (lGnNIOUyosMiuHXRxuOIImVSqtZC)
		{
			bool result = false;
			for (int num = lXxewtswoAiEVqoagQhSzbohAmOQ._count - 1; num >= 0; num--)
			{
				if (FKpMaHNmHqJLVkElNCpwnRSPraxo.Equals(lXxewtswoAiEVqoagQhSzbohAmOQ._items[num].ukHDOuOtICNfIBOXXozMAeKYtzNO, key))
				{
					lXxewtswoAiEVqoagQhSzbohAmOQ.RemoveAt(num);
					result = true;
				}
			}
			return result;
		}
		int num2 = IndexOfKey(key);
		if (num2 < 0)
		{
			return false;
		}
		RemoveAt(num2);
		return true;
	}

	bool IDictionary<TKey, TValue>.Remove(TKey key)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Remove
		return this.Remove(key);
	}

	public void RemoveAt(int index)
	{
		if ((uint)index >= (uint)lXxewtswoAiEVqoagQhSzbohAmOQ._count)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		TKey ukHDOuOtICNfIBOXXozMAeKYtzNO = lXxewtswoAiEVqoagQhSzbohAmOQ._items[index].ukHDOuOtICNfIBOXXozMAeKYtzNO;
		if (index < lXxewtswoAiEVqoagQhSzbohAmOQ._count - 1)
		{
			for (int i = index + 1; i < lXxewtswoAiEVqoagQhSzbohAmOQ.get_Count(); i++)
			{
				RLKbheczHHYKsTiJiesOFkCaFJUdA.set_Item(lXxewtswoAiEVqoagQhSzbohAmOQ._items[i].ukHDOuOtICNfIBOXXozMAeKYtzNO, i - 1);
			}
		}
		lXxewtswoAiEVqoagQhSzbohAmOQ.RemoveAt(index);
		RLKbheczHHYKsTiJiesOFkCaFJUdA.Remove(ukHDOuOtICNfIBOXXozMAeKYtzNO);
	}

	public void RemoveValue(TValue value)
	{
		int num = IndexOfValue(value);
		if (num >= 0)
		{
			_ = ref lXxewtswoAiEVqoagQhSzbohAmOQ._items[num];
			RemoveAt(num);
		}
	}

	public int RemoveAll(TValue value)
	{
		int num = 0;
		for (int num2 = lXxewtswoAiEVqoagQhSzbohAmOQ._count - 1; num2 >= 0; num2--)
		{
			_ = ref lXxewtswoAiEVqoagQhSzbohAmOQ._items[num2];
			if (djeDABxQdBSTDIIikWqKtuxYSoyk.Equals(lXxewtswoAiEVqoagQhSzbohAmOQ._items[num2].cmwKyYDYlKEySGiXFfKlmZkVLGYk, value))
			{
				RemoveAt(num2);
				num++;
			}
		}
		return num;
	}

	public int IndexOfKey(TKey key)
	{
		if (!qYOZWSncKyAhhYodpXTxJoWmAKBbA && key == null)
		{
			throw new ArgumentNullException("key");
		}
		int count = lXxewtswoAiEVqoagQhSzbohAmOQ._count;
		for (int i = 0; i < count; i++)
		{
			if (FKpMaHNmHqJLVkElNCpwnRSPraxo.Equals(lXxewtswoAiEVqoagQhSzbohAmOQ._items[i].ukHDOuOtICNfIBOXXozMAeKYtzNO, key))
			{
				return i;
			}
		}
		return -1;
	}

	public int IndexOfValue(TValue value)
	{
		int count = lXxewtswoAiEVqoagQhSzbohAmOQ._count;
		for (int i = 0; i < count; i++)
		{
			if (djeDABxQdBSTDIIikWqKtuxYSoyk.Equals(lXxewtswoAiEVqoagQhSzbohAmOQ._items[i].cmwKyYDYlKEySGiXFfKlmZkVLGYk, value))
			{
				return i;
			}
		}
		return -1;
	}

	public bool ContainsKey(TKey key)
	{
		return RLKbheczHHYKsTiJiesOFkCaFJUdA.ContainsKey(key);
	}

	bool IDictionary<TKey, TValue>.ContainsKey(TKey key)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ContainsKey
		return this.ContainsKey(key);
	}

	public bool ContainsValue(TValue value)
	{
		return IndexOfValue(value) >= 0;
	}

	public void Clear()
	{
		lXxewtswoAiEVqoagQhSzbohAmOQ.Clear();
		RLKbheczHHYKsTiJiesOFkCaFJUdA.Clear();
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

	public void TrimExcess()
	{
		lXxewtswoAiEVqoagQhSzbohAmOQ.TrimExcess();
	}

	public ICollection<TKey> get_Keys()
	{
		return new KeyCollection(this);
	}

	public ICollection<TValue> get_Values()
	{
		return new ValueCollection(this);
	}

	private void dClIXfVetCRUEXOwRscPlKBHNCcu(KeyValuePair<TKey, TValue> P_0)
	{
		Add(P_0.Key, P_0.Value);
	}

	void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in dClIXfVetCRUEXOwRscPlKBHNCcu
		this.dClIXfVetCRUEXOwRscPlKBHNCcu(P_0);
	}

	private bool PzSupLJktZhjxZCLJyCrMXFMMWwg(KeyValuePair<TKey, TValue> P_0)
	{
		int num = IndexOfKey(P_0.Key);
		if (num < 0)
		{
			return false;
		}
		zOdCKvIKwtSgzNzgWagEAwWtlYSDA zOdCKvIKwtSgzNzgWagEAwWtlYSDA2 = lXxewtswoAiEVqoagQhSzbohAmOQ._items[num];
		return djeDABxQdBSTDIIikWqKtuxYSoyk.Equals(P_0.Value, zOdCKvIKwtSgzNzgWagEAwWtlYSDA2.cmwKyYDYlKEySGiXFfKlmZkVLGYk);
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in PzSupLJktZhjxZCLJyCrMXFMMWwg
		return this.PzSupLJktZhjxZCLJyCrMXFMMWwg(P_0);
	}

	private void qfNzNAJigmNNIeyoJjKCWFLrdPWb(KeyValuePair<TKey, TValue>[] P_0, int P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("array");
		}
		if (P_1 < 0 || P_1 > P_0.Length)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (P_0.Length - P_1 < get_Count())
		{
			throw new Exception();
		}
		int count = lXxewtswoAiEVqoagQhSzbohAmOQ._count;
		for (int i = 0; i < count; i++)
		{
			P_0[P_1++] = new KeyValuePair<TKey, TValue>(lXxewtswoAiEVqoagQhSzbohAmOQ._items[i].ukHDOuOtICNfIBOXXozMAeKYtzNO, lXxewtswoAiEVqoagQhSzbohAmOQ._items[i].cmwKyYDYlKEySGiXFfKlmZkVLGYk);
		}
	}

	void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in qfNzNAJigmNNIeyoJjKCWFLrdPWb
		this.qfNzNAJigmNNIeyoJjKCWFLrdPWb(P_0, P_1);
	}

	private bool KeFuOUfKeoWQimfPArNVHnCtaQWd()
	{
		return false;
	}

	private bool YebJbgNVvnzbLyIAPUBkivdzLSTO(KeyValuePair<TKey, TValue> P_0)
	{
		if (lGnNIOUyosMiuHXRxuOIImVSqtZC)
		{
			bool result = false;
			for (int num = lXxewtswoAiEVqoagQhSzbohAmOQ._count - 1; num >= 0; num--)
			{
				zOdCKvIKwtSgzNzgWagEAwWtlYSDA zOdCKvIKwtSgzNzgWagEAwWtlYSDA2 = lXxewtswoAiEVqoagQhSzbohAmOQ._items[num];
				if (djeDABxQdBSTDIIikWqKtuxYSoyk.Equals(P_0.Value, zOdCKvIKwtSgzNzgWagEAwWtlYSDA2.cmwKyYDYlKEySGiXFfKlmZkVLGYk))
				{
					lXxewtswoAiEVqoagQhSzbohAmOQ.RemoveAt(num);
					result = true;
				}
			}
			return result;
		}
		int num2 = IndexOfKey(P_0.Key);
		if (num2 < 0)
		{
			return false;
		}
		zOdCKvIKwtSgzNzgWagEAwWtlYSDA zOdCKvIKwtSgzNzgWagEAwWtlYSDA3 = lXxewtswoAiEVqoagQhSzbohAmOQ._items[num2];
		if (!djeDABxQdBSTDIIikWqKtuxYSoyk.Equals(P_0.Value, zOdCKvIKwtSgzNzgWagEAwWtlYSDA3.cmwKyYDYlKEySGiXFfKlmZkVLGYk))
		{
			return false;
		}
		RemoveAt(num2);
		return true;
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in YebJbgNVvnzbLyIAPUBkivdzLSTO
		return this.YebJbgNVvnzbLyIAPUBkivdzLSTO(P_0);
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return new Enumerator(this, 1);
	}

	IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(this, 1);
	}

	private TValue QelBrsfCoFVaHwsGSVvaUAUdZUcM(TKey P_0)
	{
		int num = IndexOfKey(P_0);
		if (num < 0)
		{
			TKey val = P_0;
			throw new KeyNotFoundException("Key \"" + val?.ToString() + "\" does not exist.");
		}
		return lXxewtswoAiEVqoagQhSzbohAmOQ._items[num].cmwKyYDYlKEySGiXFfKlmZkVLGYk;
	}

	private void acGcTzBvZEEGbrSKMfQFLvvyafjJ(TKey P_0, TValue P_1)
	{
		SetValue(P_0, P_1);
	}

	void IDictionary.Add(object key, object value)
	{
		Add((TKey)key, (TValue)value);
	}

	bool IDictionary.Contains(object key)
	{
		return ContainsKey((TKey)key);
	}

	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		return new Enumerator(this, 2);
	}

	void IDictionary.Remove(object key)
	{
		Remove((TKey)key);
	}

	void ICollection.CopyTo(Array array, int index)
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
		int count = lXxewtswoAiEVqoagQhSzbohAmOQ._count;
		for (int i = 0; i < count; i++)
		{
			array.SetValue(new KeyValuePair<TKey, TValue>(lXxewtswoAiEVqoagQhSzbohAmOQ._items[i].ukHDOuOtICNfIBOXXozMAeKYtzNO, lXxewtswoAiEVqoagQhSzbohAmOQ._items[i].cmwKyYDYlKEySGiXFfKlmZkVLGYk), index++);
		}
	}

	private TValue QFlDgEuuqaBlLSfxeVRACYnQHLMt(int P_0)
	{
		return this[P_0];
	}

	private int XYRHLFDbPmdBDLIEfDPPAscnWBFLA(TValue P_0)
	{
		return IndexOfValue(P_0);
	}

	int Rewired.Utils.Interfaces.IReadOnlyList<TValue>.IndexOf(TValue P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in XYRHLFDbPmdBDLIEfDPPAscnWBFLA
		return this.XYRHLFDbPmdBDLIEfDPPAscnWBFLA(P_0);
	}

	private bool GFCqWFFyfDWUXorHfZzkqUKehqQb(TValue P_0)
	{
		return ContainsValue(P_0);
	}

	bool Rewired.Utils.Interfaces.IReadOnlyList<TValue>.Contains(TValue P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GFCqWFFyfDWUXorHfZzkqUKehqQb
		return this.GFCqWFFyfDWUXorHfZzkqUKehqQb(P_0);
	}

	private int iUaylDohxGWMyeccCQvYXtAoOJOr()
	{
		return get_Count();
	}

	private object PdNGSghZsOlDuvaDUOKjPCXHlaxOA(int P_0)
	{
		return this[P_0];
	}

	private int LzyDZCPXkcCGJndTVyFImPQsmNfR(object P_0)
	{
		return IndexOfValue((TValue)P_0);
	}

	int IReadOnlyList.IndexOf(object P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in LzyDZCPXkcCGJndTVyFImPQsmNfR
		return this.LzyDZCPXkcCGJndTVyFImPQsmNfR(P_0);
	}

	private bool bNTgWEGOpYegKHMEAtdVEHuySxDUA(object P_0)
	{
		return ContainsValue((TValue)P_0);
	}

	bool IReadOnlyList.Contains(object P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in bNTgWEGOpYegKHMEAtdVEHuySxDUA
		return this.bNTgWEGOpYegKHMEAtdVEHuySxDUA(P_0);
	}
}
