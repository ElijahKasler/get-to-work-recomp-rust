using System;

namespace Unity.XGamingRuntime.Interop;

internal struct XNetworkingThumbprint
{
	internal XNetworkingThumbprintType thumbprintType;

	internal ulong thumbprintBufferByteCount;

	internal IntPtr thumbprintBuffer;
}
