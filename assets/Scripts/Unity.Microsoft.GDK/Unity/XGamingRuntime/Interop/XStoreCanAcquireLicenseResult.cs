using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStoreCanAcquireLicenseResult
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
	internal string licensableSku;

	internal XStoreCanLicenseStatus status;
}
