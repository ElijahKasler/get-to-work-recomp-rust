using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XGameInviteRegistrationToken : XRegistrationToken<XGameInviteEventCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XGameInviteEventCallback))]
	private static void OnInvite(IntPtr context, string inviteUri)
	{
		CallbackWrapper<XGameInviteEventCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XGameInviteEventCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, inviteUri);
	}

	internal XGameInviteRegistrationToken(XGameInviteEventCallback callback, IntPtr context)
		: base(callback, context, (XGameInviteEventCallback)OnInvite)
	{
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XGameInviteUnregisterForEvent(Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
