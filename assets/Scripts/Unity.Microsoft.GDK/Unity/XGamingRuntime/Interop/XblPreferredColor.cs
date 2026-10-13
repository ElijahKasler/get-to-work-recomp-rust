using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XblPreferredColor
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
	internal readonly byte[] primaryColor;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
	internal readonly byte[] secondaryColor;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
	internal readonly byte[] tertiaryColor;
}
