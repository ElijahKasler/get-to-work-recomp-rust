using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XGameStreamingRegisterClientPropertiesChangedToken : XRegistrationToken<XGameStreamingClientPropertiesChangedCallback>
{
	private XGameStreamingClientId clientId;

	[AOT.MonoPInvokeCallback(typeof(XGameStreamingClientPropertiesChangedCallback))]
	private static void OnClientPropertiesChanged(IntPtr context, XGameStreamingClientId client, uint updatedPropertiesCount, XGameStreamingClientProperty[] updatedProperties)
	{
		CallbackWrapper<XGameStreamingClientPropertiesChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XGameStreamingClientPropertiesChangedCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, client, updatedPropertiesCount, updatedProperties);
	}

	public XGameStreamingRegisterClientPropertiesChangedToken(XGameStreamingClientId clientId, XGameStreamingClientPropertiesChangedCallback callback, IntPtr context)
		: base(callback, context, (XGameStreamingClientPropertiesChangedCallback)OnClientPropertiesChanged)
	{
		this.clientId = clientId;
	}

	public bool Unregister(XGameStreamingClientId clientId, bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XGameStreamingUnregisterClientPropertiesChanged(clientId, Token, wait);
			Token = 0uL;
		}
		return result;
	}

	public bool Unregister(bool wait)
	{
		return Unregister(clientId, wait);
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
