using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XGameStreamingRegisterClientPropertiesChangedToken
{
	internal Unity.XGamingRuntime.Interop.XGameStreamingRegisterClientPropertiesChangedToken interop { get; private set; }

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

	internal XGameStreamingRegisterClientPropertiesChangedToken(XGameStreamingClientId clientId, Unity.XGamingRuntime.Interop.XGameStreamingClientPropertiesChangedCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XGameStreamingRegisterClientPropertiesChangedToken(clientId.data, callback, context);
	}

	public bool Unregister(XGameStreamingClientId clientId, bool wait)
	{
		return interop.Unregister(clientId.data, wait);
	}
}
