using System;
using System.Runtime.InteropServices;
using AOT;

namespace Unity.XGamingRuntime.Interop;

internal class XUserDeviceAssociationChangedRegistrationToken : XRegistrationToken<XUserDeviceAssociationChangedCallback>
{
	[AOT.MonoPInvokeCallback(typeof(XUserDeviceAssociationChangedCallback))]
	private static void DeviceAssociationChanged(IntPtr context, ref XUserDeviceAssociationChange change)
	{
		CallbackWrapper<XUserDeviceAssociationChangedCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XUserDeviceAssociationChangedCallback>;
		callbackWrapper.Callback(callbackWrapper.Context, ref change);
	}

	public XUserDeviceAssociationChangedRegistrationToken(XUserDeviceAssociationChangedCallback callback, IntPtr context)
		: base(callback, context, (XUserDeviceAssociationChangedCallback)DeviceAssociationChanged)
	{
	}

	public bool Unregister(bool wait)
	{
		bool result = true;
		if (Token != 0L)
		{
			result = NativeMethods.XUserUnregisterForDeviceAssociationChanged(Token, wait);
			Token = 0uL;
		}
		return result;
	}

	protected override void DisposeInternal(bool disposing)
	{
		Unregister(wait: true);
	}
}
