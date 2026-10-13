using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XUserGetTokenAndSignatureUtf16HttpHeader
{
	[MarshalAs(UnmanagedType.LPWStr)]
	internal string name;

	[MarshalAs(UnmanagedType.LPWStr)]
	internal string value;
}
