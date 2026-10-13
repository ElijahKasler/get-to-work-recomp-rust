using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XPackageFeature
{
	[MarshalAs(UnmanagedType.LPStr)]
	internal string id;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string displayName;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string tags;

	[MarshalAs(UnmanagedType.I1)]
	internal bool hidden;

	internal uint storeIdCount;

	internal IntPtr storeIds;
}
