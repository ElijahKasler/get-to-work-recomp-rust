using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XUserDefaultAudioEndpointUtf16RegistrationToken
{
	internal Unity.XGamingRuntime.Interop.XUserDefaultAudioEndpointUtf16RegistrationToken interop;

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

	internal XUserDefaultAudioEndpointUtf16RegistrationToken(Unity.XGamingRuntime.Interop.XUserDefaultAudioEndpointUtf16ChangedCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XUserDefaultAudioEndpointUtf16RegistrationToken(callback, context);
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
