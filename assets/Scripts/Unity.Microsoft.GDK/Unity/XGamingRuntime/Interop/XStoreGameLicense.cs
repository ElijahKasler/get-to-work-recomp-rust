using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStoreGameLicense
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
	internal string skuStoreId;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isActive;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isTrialOwnedByThisUser;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isDiscLicense;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isTrial;

	internal uint trialTimeRemainingInSeconds;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	internal string trialUniqueId;

	internal long expirationDate;
}
