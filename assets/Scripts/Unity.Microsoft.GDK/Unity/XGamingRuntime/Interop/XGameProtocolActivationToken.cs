using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XGameProtocolActivationToken : XRegistrationToken<XGameProtocolActivationCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XGameProtocolActivationCallback))]
	private static void OnProtocolActivation(IntPtr context, string protocolUri)
	{
		CallbackWrapper<XGameProtocolActivationCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XGameProtocolActivationCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, protocolUri);
	}

	public XGameProtocolActivationToken(XGameProtocolActivationCallback callback, IntPtr context)
		: base(callback, context, (XGameProtocolActivationCallback)OnProtocolActivation)
	{
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XGameProtocolUnregisterForActivation(Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
