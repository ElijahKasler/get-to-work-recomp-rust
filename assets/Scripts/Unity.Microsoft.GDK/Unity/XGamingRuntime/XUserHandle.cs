using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XUserHandle : EquatableHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	internal XUserHandle(IntPtr interopHandle)
		: base(IntPtr.Zero, ownsHandle: true, interopHandle)
	{
	}

	internal XUserHandle(IntPtr interopHandle, bool ownsHandle)
		: base(IntPtr.Zero, ownsHandle, interopHandle)
	{
	}

	internal static int WrapAndReturnHResult(int hresult, IntPtr interopHandle, out XUserHandle handle)
	{
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(hresult) && interopHandle != IntPtr.Zero)
		{
			handle = new XUserHandle(interopHandle);
		}
		else
		{
			handle = null;
		}
		return hresult;
	}

	protected override bool ReleaseHandle()
	{
		NativeMethods.XUserCloseHandle(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
