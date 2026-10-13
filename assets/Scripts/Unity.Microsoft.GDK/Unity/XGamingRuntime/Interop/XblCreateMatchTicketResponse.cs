using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XblCreateMatchTicketResponse
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	internal byte[] matchTicketId;

	internal long estimatedWaitTime;
}
