using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class GameLicenseChangedCallbackToken : XRegistrationToken<XStoreGameLicenseChangedCallback>
{
	private XStoreContext storeContext;

	[AOT.MonoPInvokeCallback(typeof(XStoreGameLicenseChangedCallback))]
	private static void OnGameLicenseChanged(IntPtr context)
	{
		CallbackWrapper<XStoreGameLicenseChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XStoreGameLicenseChangedCallback>;
		callbackWrapper.Callback(callbackWrapper.Context);
	}

	public GameLicenseChangedCallbackToken(XStoreContext storeContext, XStoreGameLicenseChangedCallback callback, IntPtr context)
		: base(callback, context, (XStoreGameLicenseChangedCallback)OnGameLicenseChanged)
	{
		this.storeContext = storeContext;
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XStoreUnregisterGameLicenseChanged(storeContext.Handle, Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
