using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreLicense : EquatableHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public XStoreLicense(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		NativeMethods.XStoreCloseLicenseHandle(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
