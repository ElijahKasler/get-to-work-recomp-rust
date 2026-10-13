using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStoreCollectionData
{
	internal long acquiredDate;

	internal long startDate;

	internal long endDate;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isTrial;

	internal uint trialTimeRemainingInSeconds;

	internal uint quantity;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string campaignId;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string developerOfferId;
}
