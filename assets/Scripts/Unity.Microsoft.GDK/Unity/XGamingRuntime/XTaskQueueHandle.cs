using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XTaskQueueHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	public XTaskQueueHandle(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		NativeMethods.XTaskQueueCloseHandle(base.Handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
