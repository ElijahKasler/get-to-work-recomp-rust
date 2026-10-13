using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XGameSaveContainerHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	public XGameSaveContainerHandle(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		NativeMethods.XGameSaveCloseContainer(base.Handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
