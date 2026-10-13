using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XGameStreamingConnectionStateChangedToken : XRegistrationToken<XGameStreamingConnectionStateChangedCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XGameStreamingConnectionStateChangedCallback))]
	private static void OnConnectionStateChanged(IntPtr context, XGameStreamingClientId client, XGameStreamingConnectionState state)
	{
		CallbackWrapper<XGameStreamingConnectionStateChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XGameStreamingConnectionStateChangedCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, client, state);
	}

	public XGameStreamingConnectionStateChangedToken(XGameStreamingConnectionStateChangedCallback callback, IntPtr context)
		: base(callback, context, (XGameStreamingConnectionStateChangedCallback)OnConnectionStateChanged)
	{
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XGameStreamingUnregisterConnectionStateChanged(Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
