using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XTaskQueueCallbackHandle
{
	internal Unity.XGamingRuntime.Interop.XTaskQueueCallbackHandle interop;

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

	internal XTaskQueueCallbackHandle(Unity.XGamingRuntime.Interop.XTaskQueueCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XTaskQueueCallbackHandle(callback, context);
	}

	public void Dispose()
	{
		interop.Dispose();
	}
}
