using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XblTitleHistory
{
	[MarshalAs(UnmanagedType.U1)]
	internal readonly bool hasUserPlayed;

	internal readonly TimeT lastTimeUserPlayed;
}
