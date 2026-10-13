using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XTaskQueueTerminateCallbackHandle : XRegistrationToken<XTaskQueueTerminatedCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XTaskQueueTerminatedCallback))]
	private static void OnTerminate(IntPtr context)
	{
		CallbackWrapper<XTaskQueueTerminatedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XTaskQueueTerminatedCallback>;
		callbackWrapper.Callback(callbackWrapper.Context);
	}

	public XTaskQueueTerminateCallbackHandle(XTaskQueueTerminatedCallback callback, IntPtr context)
		: base(callback, context, (XTaskQueueTerminatedCallback)OnTerminate)
	{
	}

	protected override void DisposeInternal(bool disposing)
	{
	}
}
