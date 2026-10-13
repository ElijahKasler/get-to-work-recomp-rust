using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStorePackageUpdate
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
	internal string packageIdentifier;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isMandatory;
}
