using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XUserGetTokenAndSignatureData
{
	internal ulong tokenSize;

	internal ulong signatureSize;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string token;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string signature;
}
