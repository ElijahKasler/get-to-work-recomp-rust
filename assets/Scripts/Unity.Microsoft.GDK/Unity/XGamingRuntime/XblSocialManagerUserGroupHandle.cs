using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblSocialManagerUserGroupHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	internal XblSocialManagerUserGroupHandle(Unity.XGamingRuntime.Interop.XblSocialManagerUserGroupHandle interopHandle)
		: base(IntPtr.Zero, ownsHandle: true, interopHandle.Handle)
	{
	}

	internal static int WrapAndReturnHResult(int hresult, Unity.XGamingRuntime.Interop.XblSocialManagerUserGroupHandle interopHandle, out XblSocialManagerUserGroupHandle handle)
	{
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(hresult))
		{
			handle = new XblSocialManagerUserGroupHandle(interopHandle);
		}
		else
		{
			handle = null;
		}
		return hresult;
	}

	protected override bool ReleaseHandle()
	{
		return true;
	}
}
