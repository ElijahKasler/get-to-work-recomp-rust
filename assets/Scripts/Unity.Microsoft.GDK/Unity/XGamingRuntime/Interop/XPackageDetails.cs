using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XPackageDetails
{
	[MarshalAs(UnmanagedType.LPStr)]
	internal string packageIdentifier;

	internal XVersion version;

	internal XPackageKind kind;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string displayName;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string description;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string publisher;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string storeId;

	[MarshalAs(UnmanagedType.I1)]
	internal bool installing;
}
