using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XGameProtocolActivationToken
{
	internal Unity.XGamingRuntime.Interop.XGameProtocolActivationToken interop { get; private set; }

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

	public bool IsValid => interop.IsValid;

	internal XGameProtocolActivationToken(Unity.XGamingRuntime.Interop.XGameProtocolActivationCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XGameProtocolActivationToken(callback, context);
	}

	public bool Unregister(bool wait)
	{
		return interop.Unregister(wait);
	}
}
