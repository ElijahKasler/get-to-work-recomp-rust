using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XTaskQueueWaiterCallbackHandle : XRegistrationToken<XTaskQueueCallback>
{
	private XTaskQueueHandle queue;

	[AOT.MonoPInvokeCallback(typeof(XTaskQueueCallback))]
	private static void OnWaiter(IntPtr context, bool canceled)
	{
		CallbackWrapper<XTaskQueueCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XTaskQueueCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, canceled);
	}

	public XTaskQueueWaiterCallbackHandle(XTaskQueueHandle queue, XTaskQueueCallback callback, IntPtr context)
		: base(callback, context, (XTaskQueueCallback)OnWaiter)
	{
		this.queue = queue;
	}

	public void Unregister(XTaskQueueHandle queue)
	{
		if (Token != 0L)
		{
			NativeMethods.XTaskQueueUnregisterWaiter(queue.Handle, Token);
			Token = 0uL;
		}
	}

	public void Unregister()
	{
		Unregister(queue);
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister();
	}
}
