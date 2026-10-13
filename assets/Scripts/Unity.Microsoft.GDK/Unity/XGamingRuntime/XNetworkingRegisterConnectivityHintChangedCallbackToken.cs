using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XNetworkingRegisterConnectivityHintChangedCallbackToken
{
	internal Unity.XGamingRuntime.Interop.XNetworkingRegisterConnectivityHintChangedCallbackToken interop;

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

	internal XNetworkingRegisterConnectivityHintChangedCallbackToken(Unity.XGamingRuntime.Interop.XNetworkingConnectivityHintChangedCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XNetworkingRegisterConnectivityHintChangedCallbackToken(callback, context);
	}

	public bool Unregister(bool wait)
	{
		return interop.Unregister(wait);
	}

	public void Dispose()
	{
		interop.Dispose();
	}
}
