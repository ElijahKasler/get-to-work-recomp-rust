using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XAppCaptureScreenshotFile
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	internal string path;

	internal long fileSize;

	internal uint width;

	internal uint height;
}
