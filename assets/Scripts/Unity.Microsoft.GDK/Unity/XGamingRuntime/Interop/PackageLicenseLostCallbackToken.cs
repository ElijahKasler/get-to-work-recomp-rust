using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class PackageLicenseLostCallbackToken : XRegistrationToken<XStorePackageLicenseLostCallback>
{
	private XStoreLicense licenseHandle;

	[AOT.MonoPInvokeCallback(typeof(XStorePackageLicenseLostCallback))]
	private static void OnPackageLicenseLostCallback(IntPtr context)
	{
		CallbackWrapper<XStorePackageLicenseLostCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XStorePackageLicenseLostCallback>;
		callbackWrapper.Callback(callbackWrapper.Context);
	}

	public PackageLicenseLostCallbackToken(XStoreLicense licenseHandle, XStorePackageLicenseLostCallback callback, IntPtr context)
		: base(callback, context, (XStorePackageLicenseLostCallback)OnPackageLicenseLostCallback)
	{
		this.licenseHandle = licenseHandle;
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XStoreUnregisterPackageLicenseLost(licenseHandle.Handle, Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
