using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreCollectionData
{
	internal Unity.XGamingRuntime.Interop.XStoreCollectionData interop;

	public long AcquiredDate
	{
		get
		{
			return interop.acquiredDate;
		}
		set
		{
			interop.acquiredDate = value;
		}
	}

	public long StartDate
	{
		get
		{
			return interop.startDate;
		}
		set
		{
			interop.startDate = value;
		}
	}

	public long EndDate
	{
		get
		{
			return interop.endDate;
		}
		set
		{
			interop.endDate = value;
		}
	}

	public bool IsTrial
	{
		get
		{
			return interop.isTrial;
		}
		set
		{
			interop.isTrial = value;
		}
	}

	public uint TrialTimeRemainingInSeconds
	{
		get
		{
			return interop.trialTimeRemainingInSeconds;
		}
		set
		{
			interop.trialTimeRemainingInSeconds = value;
		}
	}

	public uint Quantity
	{
		get
		{
			return interop.quantity;
		}
		set
		{
			interop.quantity = value;
		}
	}

	public string CampaignId
	{
		get
		{
			return interop.campaignId;
		}
		set
		{
			interop.campaignId = value;
		}
	}

	public string DeveloperOfferId
	{
		get
		{
			return interop.developerOfferId;
		}
		set
		{
			interop.developerOfferId = value;
		}
	}

	internal XStoreCollectionData(Unity.XGamingRuntime.Interop.XStoreCollectionData interop)
	{
		this.interop = interop;
	}

	public XStoreCollectionData()
	{
		interop = default;
	}
}
