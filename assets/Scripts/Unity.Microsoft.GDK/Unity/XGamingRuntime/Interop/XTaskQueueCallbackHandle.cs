using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XTaskQueueCallbackHandle : XRegistrationToken<XTaskQueueCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XTaskQueueCallback))]
	private static void OnCallback(IntPtr context, bool canceled)
	{
		CallbackWrapper<XTaskQueueCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XTaskQueueCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, canceled);
	}

	public XTaskQueueCallbackHandle(XTaskQueueCallback callback, IntPtr context)
		: base(callback, context, (XTaskQueueCallback)OnCallback)
	{
	}

	protected override void DisposeInternal(bool disposing)
	{
	}
}
