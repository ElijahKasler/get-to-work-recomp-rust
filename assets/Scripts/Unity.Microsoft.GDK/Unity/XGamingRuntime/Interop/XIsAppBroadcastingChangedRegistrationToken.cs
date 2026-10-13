using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XIsAppBroadcastingChangedRegistrationToken : XRegistrationToken<XAppBroadcastMonitorCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XAppBroadcastMonitorCallback))]
	private static void OnIsAppBroadcastingChanged(IntPtr context)
	{
		CallbackWrapper<XAppBroadcastMonitorCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XAppBroadcastMonitorCallback>;
		callbackWrapper.Callback(callbackWrapper.Context);
	}

	public XIsAppBroadcastingChangedRegistrationToken(XAppBroadcastMonitorCallback callback, IntPtr context)
		: base(callback, context, (XAppBroadcastMonitorCallback)OnIsAppBroadcastingChanged)
	{
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XAppBroadcastUnregisterIsAppBroadcastingChanged(Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
