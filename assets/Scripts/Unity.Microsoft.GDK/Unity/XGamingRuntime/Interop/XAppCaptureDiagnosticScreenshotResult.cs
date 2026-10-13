using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XAppCaptureDiagnosticScreenshotResult
{
	internal long fileCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	internal XAppCaptureScreenshotFile[] files;
}
