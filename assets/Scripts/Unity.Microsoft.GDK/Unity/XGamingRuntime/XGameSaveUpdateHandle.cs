using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XGameSaveUpdateHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	public XGameSaveUpdateHandle(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		NativeMethods.XGameSaveCloseUpdate(base.Handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
