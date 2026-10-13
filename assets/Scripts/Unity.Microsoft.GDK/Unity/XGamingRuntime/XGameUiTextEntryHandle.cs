using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XGameUiTextEntryHandle : EquatableHandle
{
	public override bool IsInvalid => base.Handle == IntPtr.Zero;

	public XGameUiTextEntryHandle(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		NativeMethods.XGameUiTextEntryClose(base.Handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
