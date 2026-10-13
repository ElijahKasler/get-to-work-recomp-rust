using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XAppCaptureLocalStreamHandle : EquatableHandle
{
	public int CloseResult { get; private set; }

	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	public XAppCaptureLocalStreamHandle(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		CloseResult = NativeMethods.XAppCaptureCloseLocalStream(base.Handle);
		SetHandle(IntPtr.Zero);
		return Unity.XGamingRuntime.Interop.HR.SUCCEEDED(CloseResult);
	}
}
