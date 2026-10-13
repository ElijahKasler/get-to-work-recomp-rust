using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreContext : EquatableHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public XStoreContext(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		NativeMethods.XStoreCloseContextHandle(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
