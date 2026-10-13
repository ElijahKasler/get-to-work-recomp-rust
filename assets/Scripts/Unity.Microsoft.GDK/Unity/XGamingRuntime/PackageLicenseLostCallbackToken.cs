using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class PackageLicenseLostCallbackToken
{
	internal Unity.XGamingRuntime.Interop.PackageLicenseLostCallbackToken interop { get; private set; }

	public bool IsValid => interop.IsValid;

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

	internal PackageLicenseLostCallbackToken(XStoreLicense licenseHandle, Unity.XGamingRuntime.Interop.XStorePackageLicenseLostCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.PackageLicenseLostCallbackToken(licenseHandle, callback, context);
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
