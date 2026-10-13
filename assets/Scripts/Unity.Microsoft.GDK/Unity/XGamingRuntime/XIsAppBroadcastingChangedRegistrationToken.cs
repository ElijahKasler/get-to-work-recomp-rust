using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XIsAppBroadcastingChangedRegistrationToken
{
	internal Unity.XGamingRuntime.Interop.XIsAppBroadcastingChangedRegistrationToken interop { get; private set; }

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

	public bool IsValid => interop.IsValid;

	internal XIsAppBroadcastingChangedRegistrationToken(Unity.XGamingRuntime.Interop.XAppBroadcastMonitorCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XIsAppBroadcastingChangedRegistrationToken(callback, context);
	}

	public bool Unregister(bool wait)
	{
		return interop.Unregister(wait);
	}
}
