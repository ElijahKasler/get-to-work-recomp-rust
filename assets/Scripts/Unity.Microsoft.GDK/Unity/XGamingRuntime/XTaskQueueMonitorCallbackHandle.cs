using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XTaskQueueMonitorCallbackHandle
{
	internal Unity.XGamingRuntime.Interop.XTaskQueueMonitorCallbackHandle interop;

	public bool IsValid => interop.IsValid;

	public ulong Token
	{
		get
		{
			return interop.Token;
		}
		set
		{
			interop.Token = value;
		}
	}

	internal XTaskQueueMonitorCallbackHandle(XTaskQueueHandle queue, Unity.XGamingRuntime.Interop.XTaskQueueMonitorCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XTaskQueueMonitorCallbackHandle(queue, callback, context);
	}

	public void Unregister(XTaskQueueHandle queue)
	{
		interop.Unregister(queue);
	}

	public void Unregister()
	{
		interop.Unregister();
	}

	public void Dispose()
	{
		interop.Dispose();
	}
}
