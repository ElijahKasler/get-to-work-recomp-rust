using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblAchievementsResultHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	internal XblAchievementsResultHandle(Unity.XGamingRuntime.Interop.XblAchievementsResultHandle interopHandle)
		: base(IntPtr.Zero, ownsHandle: true, interopHandle.handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		XblInterop.XblAchievementsResultCloseHandle(base.Handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
