using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XNetworkingRegisterConnectivityHintChangedCallbackToken : XRegistrationToken<XNetworkingConnectivityHintChangedCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XNetworkingConnectivityHintChangedCallback))]
	private static void OnConnectivityHintChanged(IntPtr context, XNetworkingConnectivityHint connectivityHint)
	{
		CallbackWrapper<XNetworkingConnectivityHintChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XNetworkingConnectivityHintChangedCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, connectivityHint);
	}

	public XNetworkingRegisterConnectivityHintChangedCallbackToken(XNetworkingConnectivityHintChangedCallback callback, IntPtr context)
		: base(callback, context, (XNetworkingConnectivityHintChangedCallback)OnConnectivityHintChanged)
	{
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XNetworkingUnregisterConnectivityHintChanged(Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
