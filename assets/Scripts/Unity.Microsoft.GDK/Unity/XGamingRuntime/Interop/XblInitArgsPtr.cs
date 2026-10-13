using System;

namespace Unity.XGamingRuntime.Interop;

internal struct XblInitArgsPtr
{
	internal readonly IntPtr IntPtr;

	internal XblInitArgsPtr(IntPtr intPtr)
	{
		IntPtr = intPtr;
	}
}
