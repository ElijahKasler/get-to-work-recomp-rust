using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XDisplayTimeoutDeferralHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	public XDisplayTimeoutDeferralHandle(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		NativeMethods.XDisplayCloseTimeoutDeferralHandle(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
