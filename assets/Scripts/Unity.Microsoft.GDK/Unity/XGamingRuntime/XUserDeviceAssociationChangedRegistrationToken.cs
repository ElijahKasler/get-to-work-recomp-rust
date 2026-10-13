using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XUserDeviceAssociationChangedRegistrationToken
{
	internal Unity.XGamingRuntime.Interop.XUserDeviceAssociationChangedRegistrationToken interop;

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

	internal XUserDeviceAssociationChangedRegistrationToken(Unity.XGamingRuntime.Interop.XUserDeviceAssociationChangedCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XUserDeviceAssociationChangedRegistrationToken(callback, context);
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
