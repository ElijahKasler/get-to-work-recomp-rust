using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XSystemAnalyticsInfo
{
	internal XVersion osVersion;

	internal XVersion hostingOsVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	internal string family;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	internal string form;
}
