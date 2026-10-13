using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblPresenceRecordHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	internal XblPresenceRecordHandle(Unity.XGamingRuntime.Interop.XblPresenceRecordHandle interopHandle)
		: base(IntPtr.Zero, ownsHandle: true, interopHandle.intPtr)
	{
	}

	internal static int WrapInteropHandleAndReturnHResult(int hresult, Unity.XGamingRuntime.Interop.XblPresenceRecordHandle interopHandle, out XblPresenceRecordHandle handle)
	{
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(hresult))
		{
			handle = new XblPresenceRecordHandle(interopHandle);
		}
		else
		{
			handle = null;
		}
		return hresult;
	}

	protected override bool ReleaseHandle()
	{
		XblInterop.XblPresenceRecordCloseHandle(base.Handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
