using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken : XRegistrationToken<XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback))]
	private static void OnPreferredLocalUdpMultiplayerPortChanged(IntPtr context, ushort preferredLocalUdpMultiplayerPort)
	{
		CallbackWrapper<XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, preferredLocalUdpMultiplayerPort);
	}

	public XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken(XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback callback, IntPtr context)
		: base(callback, context, (XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback)OnPreferredLocalUdpMultiplayerPortChanged)
	{
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XNetworkingUnregisterPreferredLocalUdpMultiplayerPortChanged(Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
