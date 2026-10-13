using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XUserGetTokenAndSignatureHttpHeader
{
	[MarshalAs(UnmanagedType.LPStr)]
	internal string name;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string value;
}
