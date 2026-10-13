using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XStoreProductQuery : EquatableHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public XStoreProductQuery(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		NativeMethods.XStoreCloseProductsQueryHandle(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
