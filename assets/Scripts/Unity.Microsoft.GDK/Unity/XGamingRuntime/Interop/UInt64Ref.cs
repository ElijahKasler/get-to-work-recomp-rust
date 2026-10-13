using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

[StructLayout(LayoutKind.Sequential)]
internal class UInt64Ref
{
	internal readonly ulong Value;

	internal UInt64Ref(ulong value)
	{
		Value = value;
	}
}
