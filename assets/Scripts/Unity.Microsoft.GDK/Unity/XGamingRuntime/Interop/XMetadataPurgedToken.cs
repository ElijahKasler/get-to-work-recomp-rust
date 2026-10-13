using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XMetadataPurgedToken : XRegistrationToken<XAppCaptureMetadataPurgedCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XAppCaptureMetadataPurgedCallback))]
	private static void OnXMetadataPurged(IntPtr context)
	{
		CallbackWrapper<XAppCaptureMetadataPurgedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XAppCaptureMetadataPurgedCallback>;
		callbackWrapper.Callback(callbackWrapper.Context);
	}

	public XMetadataPurgedToken(XAppCaptureMetadataPurgedCallback callback, IntPtr context)
		: base(callback, context, (XAppCaptureMetadataPurgedCallback)OnXMetadataPurged)
	{
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XAppCaptureUnRegisterMetadataPurged(Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
