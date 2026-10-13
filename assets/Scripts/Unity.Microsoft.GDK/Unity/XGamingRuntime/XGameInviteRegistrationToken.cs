using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XGameInviteRegistrationToken
{
	internal Unity.XGamingRuntime.Interop.XGameInviteRegistrationToken interop { get; private set; }

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

	internal XGameInviteRegistrationToken(Unity.XGamingRuntime.Interop.XGameInviteEventCallback callback, IntPtr context)
	{
		interop = new Unity.XGamingRuntime.Interop.XGameInviteRegistrationToken(callback, context);
	}

	public bool Unregister(bool wait)
	{
		return interop.Unregister(wait);
	}
}
