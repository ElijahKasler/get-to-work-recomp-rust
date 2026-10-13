using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XPackageInstallationProgress
{
	internal ulong totalBytes;

	internal ulong installedBytes;

	internal ulong launchBytes;

	[MarshalAs(UnmanagedType.I1)]
	internal bool launchable;

	[MarshalAs(UnmanagedType.I1)]
	internal bool completed;
}
