using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblAchievementsManagerResultHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	internal XblAchievementsManagerResultHandle(Unity.XGamingRuntime.Interop.XblAchievementsManagerResultHandle interopHandle)
		: base(IntPtr.Zero, ownsHandle: true, interopHandle.Ptr)
	{
	}

	internal static int WrapAndReturnHResult(int hresult, Unity.XGamingRuntime.Interop.XblAchievementsManagerResultHandle interopHandle, out XblAchievementsManagerResultHandle handle)
	{
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(hresult))
		{
			handle = new XblAchievementsManagerResultHandle(interopHandle);
		}
		else
		{
			handle = null;
		}
		return hresult;
	}

	public override bool Equals(object obj)
	{
		if (obj is XblAchievementsManagerResultHandle xblAchievementsManagerResultHandle)
		{
			return base.Handle == xblAchievementsManagerResultHandle.Handle;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.Handle.GetHashCode();
	}

	protected override bool ReleaseHandle()
	{
		XblInterop.XblAchievementsManagerResultCloseHandle(base.Handle);
		SetHandle(IntPtr.Zero);
		return true;
	}

	public static bool operator ==(XblAchievementsManagerResultHandle handle1, XblAchievementsManagerResultHandle handle2)
	{
		return handle1?.Equals(handle2) ?? ((object)handle2 == null);
	}

	public static bool operator !=(XblAchievementsManagerResultHandle handle1, XblAchievementsManagerResultHandle handle2)
	{
		return !(handle1 == handle2);
	}
}
