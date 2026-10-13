using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblTitleStorageBlobMetadataResultHandle : EquatableHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	internal XblTitleStorageBlobMetadataResultHandle(Unity.XGamingRuntime.Interop.XblTitleStorageBlobMetadataResultHandle interopHandle)
		: base(IntPtr.Zero, ownsHandle: true, interopHandle.intPtr)
	{
	}

	protected override bool ReleaseHandle()
	{
		XblInterop.XblTitleStorageBlobMetadataResultCloseHandle(base.Handle);
		SetHandle(handle);
		return true;
	}
}
