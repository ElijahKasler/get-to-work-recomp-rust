using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class GameLicenseChangedCallbackToken
{
	internal Unity.XGamingRuntime.Interop.GameLicenseChangedCallbackToken interop { get; private set; }

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

	internal GameLicenseChangedCallbackToken(XStoreContext storeContext, Unity.XGamingRuntime.Interop.XStoreGameLicenseChangedCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.GameLicenseChangedCallbackToken(storeContext, callback, context);
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
