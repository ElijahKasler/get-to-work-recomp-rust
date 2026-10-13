using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblHttpCallHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	internal XblHttpCallHandle(Unity.XGamingRuntime.Interop.XblHttpCallHandle interopHandle)
		: base(IntPtr.Zero, ownsHandle: true, interopHandle.handle)
	{
	}

	internal static int WrapInteropHandleAndReturnHResult(int hresult, Unity.XGamingRuntime.Interop.XblHttpCallHandle interopHandle, out XblHttpCallHandle handle)
	{
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(hresult))
		{
			handle = new XblHttpCallHandle(interopHandle);
		}
		else
		{
			handle = null;
		}
		return hresult;
	}

	protected override bool ReleaseHandle()
	{
		XblInterop.XblHttpCallCloseHandle(base.Handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
