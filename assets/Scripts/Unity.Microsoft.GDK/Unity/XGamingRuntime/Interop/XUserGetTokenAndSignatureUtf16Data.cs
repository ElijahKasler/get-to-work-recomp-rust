using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XUserGetTokenAndSignatureUtf16Data
{
	internal ulong tokenSize;

	internal ulong signatureSize;

	[MarshalAs(UnmanagedType.LPWStr)]
	internal string token;

	[MarshalAs(UnmanagedType.LPWStr)]
	internal string signature;
}
