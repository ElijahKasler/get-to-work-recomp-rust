using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XNetworkingConnectivityHint
{
	internal XNetworkingConnectivityLevelHint connectivityLevel;

	internal XNetworkingConnectivityCostHint connectivityCost;

	internal uint ianaInterfaceType;

	[MarshalAs(UnmanagedType.I1)]
	internal bool networkInitialized;

	[MarshalAs(UnmanagedType.I1)]
	internal bool approachingDataLimit;

	[MarshalAs(UnmanagedType.I1)]
	internal bool overDataLimit;

	[MarshalAs(UnmanagedType.I1)]
	internal bool roaming;
}
