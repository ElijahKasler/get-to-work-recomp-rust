using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStoreRateAndReviewResult
{
	[MarshalAs(UnmanagedType.I1)]
	internal bool wasUpdated;
}
