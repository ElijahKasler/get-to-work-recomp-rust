using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XGameSaveContainerInfo
{
	[MarshalAs(UnmanagedType.LPStr)]
	internal string name;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string displayName;

	internal uint blobCount;

	internal ulong totalSize;

	internal long lastModifiedTime;

	[MarshalAs(UnmanagedType.I1)]
	internal bool needsSync;
}
