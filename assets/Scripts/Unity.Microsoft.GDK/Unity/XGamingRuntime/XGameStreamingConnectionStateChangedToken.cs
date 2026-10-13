using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XGameStreamingConnectionStateChangedToken
{
	internal Unity.XGamingRuntime.Interop.XGameStreamingConnectionStateChangedToken interop { get; private set; }

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

	internal XGameStreamingConnectionStateChangedToken(Unity.XGamingRuntime.Interop.XGameStreamingConnectionStateChangedCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XGameStreamingConnectionStateChangedToken(callback, context);
	}

	public bool Unregister(bool wait)
	{
		return interop.Unregister(wait);
	}
}
