using System;

namespace Unity.XGamingRuntime;

public class XTaskQueuePortHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	public XTaskQueuePortHandle(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		SetHandle(IntPtr.Zero);
		return true;
	}
}
