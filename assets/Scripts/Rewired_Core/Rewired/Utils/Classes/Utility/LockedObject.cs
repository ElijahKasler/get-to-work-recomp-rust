using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class LockedObject<T> : IDisposable
{
	public T item;

	private readonly object NvGptqkFZOKdTLRBlPneFsPYPdZ;

	private bool eBIAbczYxwMKIiYwZtdRuhZRJAEc;

	public LockedObject()
	{
		NvGptqkFZOKdTLRBlPneFsPYPdZ = new object();
	}

	public LockedObject(object P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("lockObject");
		}
		NvGptqkFZOKdTLRBlPneFsPYPdZ = P_0;
	}

	public void Lock()
	{
		if (eBIAbczYxwMKIiYwZtdRuhZRJAEc)
		{
			throw new Exception("Already locked. Dispose must be called before Lock can be called again.");
		}
		Monitor.Enter(NvGptqkFZOKdTLRBlPneFsPYPdZ);
		eBIAbczYxwMKIiYwZtdRuhZRJAEc = true;
	}

	public void Unlock()
	{
		if (!eBIAbczYxwMKIiYwZtdRuhZRJAEc)
		{
			throw new Exception("Not locked. Lock must be called before Dispose.");
		}
		Monitor.Exit(NvGptqkFZOKdTLRBlPneFsPYPdZ);
		eBIAbczYxwMKIiYwZtdRuhZRJAEc = false;
	}

	void IDisposable.Dispose()
	{
		Unlock();
	}
}
