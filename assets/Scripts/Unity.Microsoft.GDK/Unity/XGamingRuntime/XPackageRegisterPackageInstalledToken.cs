using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XPackageRegisterPackageInstalledToken
{
	internal Unity.XGamingRuntime.Interop.XPackageRegisterPackageInstalledToken interop { get; private set; }

	public ulong Token
	{
		get
		{
			return interop.Token;
		}
		set
		{
			interop.Token = value;
		}
	}

	public bool IsValid => interop.IsValid;

	internal XPackageRegisterPackageInstalledToken(Unity.XGamingRuntime.Interop.XPackageInstalledCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XPackageRegisterPackageInstalledToken(callback, context);
	}

	public bool Unregister(bool wait)
	{
		return interop.Unregister(wait);
	}

	public void Dispose()
	{
		interop.Dispose();
	}
}
