using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[StructLayout(LayoutKind.Explicit)]
internal struct XColor
{
	[FieldOffset(0)]
	internal ARGB Argb;

	[FieldOffset(0)]
	internal uint Value;
}
