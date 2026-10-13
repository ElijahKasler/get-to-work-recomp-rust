using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStoreAvailability
{
	[MarshalAs(UnmanagedType.LPStr)]
	internal string availabilityId;

	internal XStorePrice price;

	internal long endDate;
}
