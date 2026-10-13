using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XUserChangeRegistrationToken : XRegistrationToken<XUserChangeEventCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XUserChangeEventCallback))]
	private static void OnChangeEvent(IntPtr context, XUserLocalId userLocalId, XUserChangeEvent changeEvent)
	{
		CallbackWrapper<XUserChangeEventCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XUserChangeEventCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, userLocalId, changeEvent);
	}

	public XUserChangeRegistrationToken(XUserChangeEventCallback callback, IntPtr context)
		: base(callback, context, (XUserChangeEventCallback)OnChangeEvent)
	{
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XUserUnregisterForChangeEvent(Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
