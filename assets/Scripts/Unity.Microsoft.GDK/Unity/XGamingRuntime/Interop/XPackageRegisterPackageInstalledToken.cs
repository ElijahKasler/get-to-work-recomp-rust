using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XPackageRegisterPackageInstalledToken : XRegistrationToken<XPackageInstalledCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XPackageInstalledCallback))]
	private static void OnPackageInstalled(IntPtr context, XPackageDetails details)
	{
		CallbackWrapper<XPackageInstalledCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XPackageInstalledCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, details);
	}

	public XPackageRegisterPackageInstalledToken(XPackageInstalledCallback callback, IntPtr context)
		: base(callback, context, (XPackageInstalledCallback)OnPackageInstalled)
	{
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XPackageUnregisterPackageInstalled(Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
