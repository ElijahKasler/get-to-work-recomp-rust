using System;

namespace Unity.XGamingRuntime.Interop;

internal struct XNetworkingSecurityInformation
{
	internal uint enabledHttpSecurityProtocolFlags;

	internal ulong thumbprintCount;

	internal IntPtr thumbprints;
}
