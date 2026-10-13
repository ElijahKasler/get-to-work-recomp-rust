using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerSessionHandleId
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	internal byte[] value;

	internal unsafe string GetValue()
	{
		fixed (byte* bytePointer = value)
		{
			return Converters.BytePointerToString(bytePointer, 40);
		}
	}
}
