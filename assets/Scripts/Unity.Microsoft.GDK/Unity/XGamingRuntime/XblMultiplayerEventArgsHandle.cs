using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerEventArgsHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	internal XblMultiplayerEventArgsHandle(Unity.XGamingRuntime.Interop.XblMultiplayerEventArgsHandle interopHandle)
		: base(IntPtr.Zero, ownsHandle: false, interopHandle.handle)
	{
	}

	internal static int WrapInteropHandleAndReturnHResult(int hresult, Unity.XGamingRuntime.Interop.XblMultiplayerEventArgsHandle interopHandle, out XblMultiplayerEventArgsHandle handle)
	{
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(hresult))
		{
			handle = new XblMultiplayerEventArgsHandle(interopHandle);
		}
		else
		{
			handle = null;
		}
		return hresult;
	}

	protected override bool ReleaseHandle()
	{
		SetHandle(IntPtr.Zero);
		return true;
	}
}
