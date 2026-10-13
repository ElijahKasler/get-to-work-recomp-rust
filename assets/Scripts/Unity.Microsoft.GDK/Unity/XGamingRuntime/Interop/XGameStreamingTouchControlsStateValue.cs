using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[StructLayout(LayoutKind.Explicit)]
internal struct XGameStreamingTouchControlsStateValue
{
	[FieldOffset(0)]
	internal XGameStreamingTouchControlsStateValueKind valueKind;

	[FieldOffset(8)]
	internal IntPtr stringValue;

	[FieldOffset(8)]
	internal double doubleValue;

	[FieldOffset(8)]
	internal bool boolValue;

	[FieldOffset(8)]
	internal uint integerValue;
}
