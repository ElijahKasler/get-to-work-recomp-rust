using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XAppCaptureTakeScreenshotResult
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 250)]
	internal string localId;

	internal XAppCaptureScreenshotFormatFlag availableScreenshotFormats;
}
