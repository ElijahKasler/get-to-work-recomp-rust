using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XUserDefaultAudioEndpointUtf16RegistrationToken : XRegistrationToken<XUserDefaultAudioEndpointUtf16ChangedCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XUserDefaultAudioEndpointUtf16ChangedCallback))]
	private static void OnDefaultAudioEndpointUtf16Changed(IntPtr context, XUserLocalId user, XUserDefaultAudioEndpointKind defaultAudioEndpointKind, string endpointIdUtf16)
	{
		CallbackWrapper<XUserDefaultAudioEndpointUtf16ChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XUserDefaultAudioEndpointUtf16ChangedCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, user, defaultAudioEndpointKind, endpointIdUtf16);
	}

	public XUserDefaultAudioEndpointUtf16RegistrationToken(XUserDefaultAudioEndpointUtf16ChangedCallback callback, IntPtr context)
		: base(callback, context, (XUserDefaultAudioEndpointUtf16ChangedCallback)OnDefaultAudioEndpointUtf16Changed)
	{
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XUserUnregisterForDefaultAudioEndpointUtf16Changed(Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
