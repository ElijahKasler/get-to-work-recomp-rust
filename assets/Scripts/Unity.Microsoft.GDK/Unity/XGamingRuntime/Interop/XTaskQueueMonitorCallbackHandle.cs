using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XTaskQueueMonitorCallbackHandle : XRegistrationToken<XTaskQueueMonitorCallback>
{
	private XTaskQueueHandle queue;

	[AOT.MonoPInvokeCallback(typeof(XTaskQueueMonitorCallback))]
	private static void OnMonitor(IntPtr context, IntPtr queue, XTaskQueuePort port)
	{
		CallbackWrapper<XTaskQueueMonitorCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XTaskQueueMonitorCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, queue, port);
	}

	public XTaskQueueMonitorCallbackHandle(XTaskQueueHandle queue, XTaskQueueMonitorCallback callback, IntPtr context)
		: base(callback, context, (XTaskQueueMonitorCallback)OnMonitor)
	{
		this.queue = queue;
	}

	public void Unregister(XTaskQueueHandle queue)
	{
		if (Token != 0L)
		{
			NativeMethods.XTaskQueueUnregisterMonitor(queue.Handle, Token);
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
