using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	internal XblMultiplayerSessionHandle(Unity.XGamingRuntime.Interop.XblMultiplayerSessionHandle interopHandle)
		: base(IntPtr.Zero, ownsHandle: true, interopHandle.intPtr)
	{
	}

	internal static int WrapInteropHandleAndReturnHResult(int hresult, Unity.XGamingRuntime.Interop.XblMultiplayerSessionHandle interopHandle, out XblMultiplayerSessionHandle sessionHandle)
	{
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(hresult))
		{
			sessionHandle = new XblMultiplayerSessionHandle(interopHandle);
		}
		else
		{
			sessionHandle = null;
		}
		return hresult;
	}

	protected override bool ReleaseHandle()
	{
		XblInterop.XblMultiplayerSessionCloseHandle(base.Handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
