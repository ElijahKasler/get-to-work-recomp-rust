using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreSubscriptionInfo
{
	internal Unity.XGamingRuntime.Interop.XStoreSubscriptionInfo interop;

	public bool HasTrialPeriod
	{
		get
		{
			return interop.hasTrialPeriod;
		}
		set
		{
			interop.hasTrialPeriod = value;
		}
	}

	public XStoreDurationUnit TrialPeriodUnit
	{
		get
		{
			return interop.trialPeriodUnit;
		}
		set
		{
			interop.trialPeriodUnit = value;
		}
	}

	public uint TrialPeriod
	{
		get
		{
			return interop.trialPeriod;
		}
		set
		{
			interop.trialPeriod = value;
		}
	}

	public XStoreDurationUnit BillingPeriodUnit
	{
		get
		{
			return interop.billingPeriodUnit;
		}
		set
		{
			interop.billingPeriodUnit = value;
		}
	}

	public uint BillingPeriod
	{
		get
		{
			return interop.billingPeriod;
		}
		set
		{
			interop.billingPeriod = value;
		}
	}

	internal XStoreSubscriptionInfo(Unity.XGamingRuntime.Interop.XStoreSubscriptionInfo interop)
	{
		this.interop = interop;
	}

	public XStoreSubscriptionInfo()
	{
		interop = default;
	}
}
