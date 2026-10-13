using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XAppCaptureRecordClipResult
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	internal string path;

	internal long fileSize;

	internal long startTime;

	internal uint durationInMs;

	internal uint width;

	internal uint height;

	internal XAppCaptureVideoEncoding encoding;

	internal uint startTimePreciseOffsetHns;
}
