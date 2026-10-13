using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStorePackageIdentifierInterop
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
	internal string Data;
}
