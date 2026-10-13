using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken
{
	internal Unity.XGamingRuntime.Interop.XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken interop;

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

	internal XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken(Unity.XGamingRuntime.Interop.XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken(callback, context);
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
