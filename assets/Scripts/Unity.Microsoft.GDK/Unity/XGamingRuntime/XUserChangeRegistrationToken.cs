using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XUserChangeRegistrationToken
{
	internal Unity.XGamingRuntime.Interop.XUserChangeRegistrationToken interop;

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

	internal XUserChangeRegistrationToken(Unity.XGamingRuntime.Interop.XUserChangeEventCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XUserChangeRegistrationToken(callback, context);
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
