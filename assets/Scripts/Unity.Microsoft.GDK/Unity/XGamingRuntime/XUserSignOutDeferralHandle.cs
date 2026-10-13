using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XUserSignOutDeferralHandle : EquatableHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public XUserSignOutDeferralHandle(IntPtr interopHandle)
		: base(IntPtr.Zero, ownsHandle: true, interopHandle)
	{
	}

	protected override bool ReleaseHandle()
	{
		NativeMethods.XUserCloseSignOutDeferralHandle(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
