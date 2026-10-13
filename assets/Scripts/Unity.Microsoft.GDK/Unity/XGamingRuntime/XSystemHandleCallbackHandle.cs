using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XSystemHandleCallbackHandle
{
	internal Unity.XGamingRuntime.Interop.XSystemHandleCallbackHandle interop;

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

	internal XSystemHandleCallbackHandle(Unity.XGamingRuntime.Interop.XSystemHandleCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XSystemHandleCallbackHandle(callback, context);
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
