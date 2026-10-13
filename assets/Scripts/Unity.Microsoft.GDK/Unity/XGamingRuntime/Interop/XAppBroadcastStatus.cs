using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XAppBroadcastStatus
{
	[MarshalAs(UnmanagedType.I1)]
	internal bool canStartBroadcast;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isAnyAppBroadcasting;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isCaptureResourceUnavailable;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isGameStreamInProgress;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isGpuConstrained;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isAppInactive;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isBlockedForApp;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isDisabledByUser;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isDisabledBySystem;
}
