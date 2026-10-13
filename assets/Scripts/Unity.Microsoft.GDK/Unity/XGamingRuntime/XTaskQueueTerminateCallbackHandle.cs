using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XTaskQueueTerminateCallbackHandle
{
	internal Unity.XGamingRuntime.Interop.XTaskQueueTerminateCallbackHandle interop;

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

	internal XTaskQueueTerminateCallbackHandle(Unity.XGamingRuntime.Interop.XTaskQueueTerminatedCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XTaskQueueTerminateCallbackHandle(callback, context);
	}

	public void Dispose()
	{
		interop.Dispose();
	}
}
