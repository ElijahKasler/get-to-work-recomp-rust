using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStoreSubscriptionInfo
{
	[MarshalAs(UnmanagedType.I1)]
	internal bool hasTrialPeriod;

	internal XStoreDurationUnit trialPeriodUnit;

	internal uint trialPeriod;

	internal XStoreDurationUnit billingPeriodUnit;

	internal uint billingPeriod;
}
