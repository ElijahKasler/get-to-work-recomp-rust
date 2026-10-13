using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct APP_LOCAL_DEVICE_ID
{
	public const int APP_LOCAL_DEVICE_ID_SIZE = 32;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] value;
}
