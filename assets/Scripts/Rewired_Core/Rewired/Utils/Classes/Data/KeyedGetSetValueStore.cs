using System;
using System.Collections;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;

namespace Rewired.Utils.Classes.Data;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
internal sealed class KeyedGetSetValueStore<TKey> : IDictionary<TKey, object>, ICollection<KeyValuePair<TKey, object>>, IEnumerable<KeyValuePair<TKey, object>>, IEnumerable
{
	private readonly Dictionary<TKey, object> AahnlkvRUBLlaSXGwuSjghlItSth;

	private readonly bool VriFOrJYTrAZTSjWghgkMNiGNDisA;

	public int Count => AahnlkvRUBLlaSXGwuSjghlItSth.Count;

	public bool isReadOnlyCollection => VriFOrJYTrAZTSjWghgkMNiGNDisA;

	ICollection<TKey> IDictionary<TKey, object>.Keys => WhSHBRZDKhrSTndVHJSiGmWahWlQ();

	ICollection<object> IDictionary<TKey, object>.Values => OGkVdPedXgEdWZKnKbjvXKDYkjiX();

	object IDictionary<TKey, object>.this[TKey P_0]
	{
		get
		{
			return sjDQEBeLUQJKeVXMrBKThWsBdkjG(P_0);
		}
		set
		{
			EoLyfhbkWsCkaabAzYJqLeJMjNIGA(val, obj);
		}
	}

	int ICollection<KeyValuePair<TKey, object>>.Count => faNrlpmmVHYYZDBsHAgYdUngqrHH();

	bool ICollection<KeyValuePair<TKey, object>>.IsReadOnly => UCRxCQflObllYPACsBqAlGdESeqD();

	public KeyedGetSetValueStore(Dictionary<TKey, object> P_0, bool P_1)
	{
		AahnlkvRUBLlaSXGwuSjghlItSth = P_0;
		VriFOrJYTrAZTSjWghgkMNiGNDisA = P_1;
	}

	public KeyedGetSetValueStore(bool P_0)
	{
		VriFOrJYTrAZTSjWghgkMNiGNDisA = P_0;
		AahnlkvRUBLlaSXGwuSjghlItSth = new Dictionary<TKey, object>();
	}

	public void AddItem<TValue>(TKey key, IGetSetValue<TValue> item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		IjWeddDBUREvkELSUbMPAhoeKNHoA();
		AahnlkvRUBLlaSXGwuSjghlItSth.Add(key, item);
	}

	public IGetSetValue<TValue> GetItem<TValue>(TKey key)
	{
		if (!AahnlkvRUBLlaSXGwuSjghlItSth.TryGetValue(key, out var value) || !(value is IGetSetValue<TValue> result))
		{
			aNsZmoCBBvRZdLtHYVDgfMzObRPd(key, typeof(TValue));
			return null;
		}
		return result;
	}

	public bool RemoveItem<TValue>(TKey key)
	{
		IjWeddDBUREvkELSUbMPAhoeKNHoA();
		return AahnlkvRUBLlaSXGwuSjghlItSth.Remove(key);
	}

	public bool ContainsKey(TKey key)
	{
		return AahnlkvRUBLlaSXGwuSjghlItSth.ContainsKey(key);
	}

	public void Clear()
	{
		IjWeddDBUREvkELSUbMPAhoeKNHoA();
		AahnlkvRUBLlaSXGwuSjghlItSth.Clear();
	}

	public bool ContainsValue<TValue>(TKey key)
	{
		if (AahnlkvRUBLlaSXGwuSjghlItSth.TryGetValue(key, out var value))
		{
			return value is IGetSetValue<TValue>;
		}
		return false;
	}

	public TValue GetValue<TValue>(TKey key)
	{
		if (!TryGetValue<TValue>(key, out var value))
		{
			aNsZmoCBBvRZdLtHYVDgfMzObRPd(key, typeof(TValue));
		}
		return value;
	}

	public void SetValue<TValue>(TKey key, TValue value)
	{
		if (!TrySetValue(key, value))
		{
			aNsZmoCBBvRZdLtHYVDgfMzObRPd(key, typeof(TValue));
		}
	}

	public bool TryGetValue<TValue>(TKey key, out TValue value)
	{
		if (!AahnlkvRUBLlaSXGwuSjghlItSth.TryGetValue(key, out var value2) || !(value2 is IGetValue<TValue> getValue))
		{
			value = default;
			Logger.LogError(lFyxnUaWrfCmVJarqDnFKSxJrENPA(key, typeof(TValue)), requiredThreadSafety: true);
			return false;
		}
		value = getValue.GetValue();
		return true;
	}

	public bool TrySetValue<TValue>(TKey key, TValue value)
	{
		ISetValue<TValue> setValue;
		if (!AahnlkvRUBLlaSXGwuSjghlItSth.TryGetValue(key, out var value2) || (setValue = value2 as GetSetValue<TValue>) == null)
		{
			Logger.LogError(lFyxnUaWrfCmVJarqDnFKSxJrENPA(key, typeof(TValue)), requiredThreadSafety: true);
			return false;
		}
		setValue.SetValue(value);
		return true;
	}

	private void IjWeddDBUREvkELSUbMPAhoeKNHoA()
	{
		if (VriFOrJYTrAZTSjWghgkMNiGNDisA)
		{
			throw new Exception("The collection is read-only.");
		}
	}

	private static void aNsZmoCBBvRZdLtHYVDgfMzObRPd(TKey P_0, Type P_1)
	{
		throw new Exception(lFyxnUaWrfCmVJarqDnFKSxJrENPA(P_0, P_1));
	}

	private static string lFyxnUaWrfCmVJarqDnFKSxJrENPA(TKey P_0, Type P_1)
	{
		string[] obj = new string[5] { "Value with key ", null, null, null, null };
		TKey val = P_0;
		obj[1] = val?.ToString();
		obj[2] = " of type ";
		obj[3] = P_1?.ToString();
		obj[4] = " not found.";
		return string.Concat(obj);
	}

	private void vtHxMgoaNiydMatYlaTuKDDkrhff(TKey P_0, object P_1)
	{
		IjWeddDBUREvkELSUbMPAhoeKNHoA();
		AahnlkvRUBLlaSXGwuSjghlItSth.Add(P_0, P_1);
	}

	void IDictionary<TKey, object>.Add(TKey P_0, object P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in vtHxMgoaNiydMatYlaTuKDDkrhff
		this.vtHxMgoaNiydMatYlaTuKDDkrhff(P_0, P_1);
	}

	private bool GcFyJhlZOdlgnBrvrhiOrbbfEVap(TKey P_0)
	{
		return ContainsKey(P_0);
	}

	bool IDictionary<TKey, object>.ContainsKey(TKey P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GcFyJhlZOdlgnBrvrhiOrbbfEVap
		return this.GcFyJhlZOdlgnBrvrhiOrbbfEVap(P_0);
	}

	private ICollection<TKey> WhSHBRZDKhrSTndVHJSiGmWahWlQ()
	{
		return AahnlkvRUBLlaSXGwuSjghlItSth.Keys;
	}

	private bool JPffHWDvMDEZUAkXGHhYjlagJTzMc(TKey P_0)
	{
		IjWeddDBUREvkELSUbMPAhoeKNHoA();
		return AahnlkvRUBLlaSXGwuSjghlItSth.Remove(P_0);
	}

	bool IDictionary<TKey, object>.Remove(TKey P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in JPffHWDvMDEZUAkXGHhYjlagJTzMc
		return this.JPffHWDvMDEZUAkXGHhYjlagJTzMc(P_0);
	}

	private bool FtzFAeevspfwTOeoaPCRyYvajhwQA(TKey P_0, out object P_1)
	{
		return AahnlkvRUBLlaSXGwuSjghlItSth.TryGetValue(P_0, out P_1);
	}

	bool IDictionary<TKey, object>.TryGetValue(TKey P_0, out object P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in FtzFAeevspfwTOeoaPCRyYvajhwQA
		return this.FtzFAeevspfwTOeoaPCRyYvajhwQA(P_0, out P_1);
	}

	private ICollection<object> OGkVdPedXgEdWZKnKbjvXKDYkjiX()
	{
		return AahnlkvRUBLlaSXGwuSjghlItSth.Values;
	}

	private object sjDQEBeLUQJKeVXMrBKThWsBdkjG(TKey P_0)
	{
		return AahnlkvRUBLlaSXGwuSjghlItSth[P_0];
	}

	private void EoLyfhbkWsCkaabAzYJqLeJMjNIGA(TKey P_0, object P_1)
	{
		IjWeddDBUREvkELSUbMPAhoeKNHoA();
		AahnlkvRUBLlaSXGwuSjghlItSth[P_0] = P_1;
	}

	private void VWPVVDXwEjRJoOpaJQqnTmfPlNNB(KeyValuePair<TKey, object> P_0)
	{
		IjWeddDBUREvkELSUbMPAhoeKNHoA();
		((ICollection<KeyValuePair<TKey, object>>)AahnlkvRUBLlaSXGwuSjghlItSth).Add(P_0);
	}

	void ICollection<KeyValuePair<TKey, object>>.Add(KeyValuePair<TKey, object> P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in VWPVVDXwEjRJoOpaJQqnTmfPlNNB
		this.VWPVVDXwEjRJoOpaJQqnTmfPlNNB(P_0);
	}

	private void rJWfHkeiLqXtiyQLeOIOTLFtcPhK()
	{
		IjWeddDBUREvkELSUbMPAhoeKNHoA();
		((ICollection<KeyValuePair<TKey, object>>)AahnlkvRUBLlaSXGwuSjghlItSth).Clear();
	}

	void ICollection<KeyValuePair<TKey, object>>.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in rJWfHkeiLqXtiyQLeOIOTLFtcPhK
		this.rJWfHkeiLqXtiyQLeOIOTLFtcPhK();
	}

	private bool GgFgLAFXDdVcfeiSEGaTTYHkVMEr(KeyValuePair<TKey, object> P_0)
	{
		return ((ICollection<KeyValuePair<TKey, object>>)AahnlkvRUBLlaSXGwuSjghlItSth).Contains(P_0);
	}

	bool ICollection<KeyValuePair<TKey, object>>.Contains(KeyValuePair<TKey, object> P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GgFgLAFXDdVcfeiSEGaTTYHkVMEr
		return this.GgFgLAFXDdVcfeiSEGaTTYHkVMEr(P_0);
	}

	private void xGEVrSQrJIqULnVvWdfNpuNfmILH(KeyValuePair<TKey, object>[] P_0, int P_1)
	{
		((ICollection<KeyValuePair<TKey, object>>)AahnlkvRUBLlaSXGwuSjghlItSth).CopyTo(P_0, P_1);
	}

	void ICollection<KeyValuePair<TKey, object>>.CopyTo(KeyValuePair<TKey, object>[] P_0, int P_1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in xGEVrSQrJIqULnVvWdfNpuNfmILH
		this.xGEVrSQrJIqULnVvWdfNpuNfmILH(P_0, P_1);
	}

	private int faNrlpmmVHYYZDBsHAgYdUngqrHH()
	{
		return AahnlkvRUBLlaSXGwuSjghlItSth.Count;
	}

	private bool UCRxCQflObllYPACsBqAlGdESeqD()
	{
		return VriFOrJYTrAZTSjWghgkMNiGNDisA;
	}

	private bool aklXqcyjegAibRqbPJluEnShPGkj(KeyValuePair<TKey, object> P_0)
	{
		IjWeddDBUREvkELSUbMPAhoeKNHoA();
		return ((ICollection<KeyValuePair<TKey, object>>)AahnlkvRUBLlaSXGwuSjghlItSth).Remove(P_0);
	}

	bool ICollection<KeyValuePair<TKey, object>>.Remove(KeyValuePair<TKey, object> P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in aklXqcyjegAibRqbPJluEnShPGkj
		return this.aklXqcyjegAibRqbPJluEnShPGkj(P_0);
	}

	private IEnumerator<KeyValuePair<TKey, object>> zNlyhqikZiZaWSbUDmhLRJABKoSR()
	{
		return AahnlkvRUBLlaSXGwuSjghlItSth.GetEnumerator();
	}

	IEnumerator<KeyValuePair<TKey, object>> IEnumerable<KeyValuePair<TKey, object>>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in zNlyhqikZiZaWSbUDmhLRJABKoSR
		return this.zNlyhqikZiZaWSbUDmhLRJABKoSR();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return AahnlkvRUBLlaSXGwuSjghlItSth.GetEnumerator();
	}
}
