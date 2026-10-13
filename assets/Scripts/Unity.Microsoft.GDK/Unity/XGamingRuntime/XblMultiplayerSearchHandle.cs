using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSearchHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	internal XblMultiplayerSearchHandle(Unity.XGamingRuntime.Interop.XblMultiplayerSearchHandle interopHandle)
		: base(IntPtr.Zero, ownsHandle: true, interopHandle.Ptr)
	{
	}

	internal static int WrapInteropHandleAndReturnHResult(int hresult, Unity.XGamingRuntime.Interop.XblMultiplayerSearchHandle interopHandle, out XblMultiplayerSearchHandle userHandle)
	{
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(hresult))
		{
			userHandle = new XblMultiplayerSearchHandle(interopHandle);
		}
		else
		{
			userHandle = null;
		}
		return hresult;
	}

	protected override bool ReleaseHandle()
	{
		XblInterop.XblMultiplayerSearchHandleCloseHandle(base.Handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
