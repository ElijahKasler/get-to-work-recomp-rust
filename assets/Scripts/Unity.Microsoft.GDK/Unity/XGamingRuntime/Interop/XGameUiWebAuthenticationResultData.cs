using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XGameUiWebAuthenticationResultData
{
	internal uint responseStatus;

	internal ulong responseCompletionUriSize;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string responseCompletionUri;
}
