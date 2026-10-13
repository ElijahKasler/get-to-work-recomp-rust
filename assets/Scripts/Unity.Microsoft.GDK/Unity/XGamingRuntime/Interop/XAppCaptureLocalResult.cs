using System;

namespace Unity.XGamingRuntime.Interop;

internal struct XAppCaptureLocalResult
{
	internal IntPtr clipHandle;

	internal ulong fileSizeInBytes;

	internal SYSTEMTIME clipStartTimestamp;

	internal ulong durationInMilliseconds;

	internal uint width;

	internal uint height;

	internal XAppCaptureVideoEncoding encoding;

	internal XAppCaptureVideoColorFormat colorFormat;
}
