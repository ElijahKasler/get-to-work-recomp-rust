using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XTaskQueueWaiterCallbackHandle
{
	internal Unity.XGamingRuntime.Interop.XTaskQueueWaiterCallbackHandle interop;

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

	internal XTaskQueueWaiterCallbackHandle(XTaskQueueHandle queue, Unity.XGamingRuntime.Interop.XTaskQueueCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XTaskQueueWaiterCallbackHandle(queue, callback, context);
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
