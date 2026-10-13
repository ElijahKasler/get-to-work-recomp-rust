using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[StructLayout(LayoutKind.Explicit)]
internal struct XVersion
{
	[FieldOffset(0)]
	internal ushort major;

	[FieldOffset(2)]
	internal ushort minor;

	[FieldOffset(4)]
	internal ushort build;

	[FieldOffset(6)]
	internal ushort revision;

	[FieldOffset(0)]
	internal ulong Value;
}
