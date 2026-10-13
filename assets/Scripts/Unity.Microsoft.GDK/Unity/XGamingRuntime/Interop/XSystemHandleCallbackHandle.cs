using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XSystemHandleCallbackHandle : XRegistrationToken<XSystemHandleCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XSystemHandleCallback))]
	private static void OnHandle(IntPtr handle, XSystemHandleType type, XSystemHandleCallbackReason reason, IntPtr context)
	{
		CallbackWrapper<XSystemHandleCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XSystemHandleCallback>;
		callbackWrapper.Callback(handle, type, reason, callbackWrapper.Context);
	}

	public XSystemHandleCallbackHandle(XSystemHandleCallback callback, IntPtr context)
		: base(callback, context, (XSystemHandleCallback)OnHandle)
	{
	}

	public void Unregister()
	{
		NativeMethods.XSystemHandleTrack(null, IntPtr.Zero);
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister();
	}
}
