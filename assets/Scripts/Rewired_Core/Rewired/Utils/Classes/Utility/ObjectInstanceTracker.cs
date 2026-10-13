using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class ObjectInstanceTracker : IDisposable
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class Wrapper<T> : IDisposable where T : class
	{
		public readonly T instance;

		public readonly uint instanceId;

		private readonly ObjectInstanceTracker zeiyKVFNKVSuXHtLlVSVggwLTgIf;

		private bool vxvPjtAxoVahpHwUOFyzPwnGGCaH;

		public Wrapper(T P_0)
			: this(P_0, Default)
		{
		}

		public Wrapper(T P_0, ObjectInstanceTracker P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("tracker");
			}
			instance = P_0;
			zeiyKVFNKVSuXHtLlVSVggwLTgIf = P_1;
			instanceId = P_1.Register(P_0);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~Wrapper()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!vxvPjtAxoVahpHwUOFyzPwnGGCaH)
			{
				if (zeiyKVFNKVSuXHtLlVSVggwLTgIf != null)
				{
					zeiyKVFNKVSuXHtLlVSVggwLTgIf.Unregister(instanceId);
				}
				vxvPjtAxoVahpHwUOFyzPwnGGCaH = true;
			}
		}
	}

	private static ObjectInstanceTracker DwwlFuOigZjIHEUUNggrNQmCdqNg;

	private readonly Dictionary<uint, object> zxfhSRxCIwfqFYutaHooeboTaKIhA = new Dictionary<uint, object>();

	private readonly object pnmGFfkzPrxHmVhsIewVrWVJahnC = new object();

	private uint OuZiYpGjjIsRVMVCqmTxbKXlCEaH;

	private int jwQjIwUlzqcKSRLlMlHoPfougUdQ;

	private bool XRaTaouzNHPTvguGohwrGtbzsfRT;

	public static ObjectInstanceTracker Default => DwwlFuOigZjIHEUUNggrNQmCdqNg ?? (DwwlFuOigZjIHEUUNggrNQmCdqNg = new ObjectInstanceTracker());

	public uint Register(object instance)
	{
		if (instance == null)
		{
			throw new ArgumentNullException("instance");
		}
		jwQjIwUlzqcKSRLlMlHoPfougUdQ++;
		uint num = OuZiYpGjjIsRVMVCqmTxbKXlCEaH++;
		zxfhSRxCIwfqFYutaHooeboTaKIhA.Add(num, instance);
		return num;
	}

	public void Unregister(uint instanceId)
	{
		jwQjIwUlzqcKSRLlMlHoPfougUdQ--;
		if (jwQjIwUlzqcKSRLlMlHoPfougUdQ < 0)
		{
			jwQjIwUlzqcKSRLlMlHoPfougUdQ = 0;
		}
		lock (pnmGFfkzPrxHmVhsIewVrWVJahnC)
		{
			zxfhSRxCIwfqFYutaHooeboTaKIhA.Remove(instanceId);
		}
	}

	public bool TryGetInstance<T>(uint instanceId, out T instance) where T : class
	{
		lock (pnmGFfkzPrxHmVhsIewVrWVJahnC)
		{
			if (!zxfhSRxCIwfqFYutaHooeboTaKIhA.TryGetValue(instanceId, out var value))
			{
				instance = null;
				return false;
			}
			if (value is T)
			{
				instance = (T)value;
				return true;
			}
			instance = null;
			return false;
		}
	}

	public void Dispose()
	{
		CcRQkLTLKGfsiQmdwpIfPImLUsz(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void CcRQkLTLKGfsiQmdwpIfPImLUsz(bool P_0)
	{
		if (!XRaTaouzNHPTvguGohwrGtbzsfRT)
		{
			if (this == DwwlFuOigZjIHEUUNggrNQmCdqNg)
			{
				DwwlFuOigZjIHEUUNggrNQmCdqNg = null;
			}
			XRaTaouzNHPTvguGohwrGtbzsfRT = true;
		}
	}

	~ObjectInstanceTracker()
	{
		CcRQkLTLKGfsiQmdwpIfPImLUsz(false);
	}
}
