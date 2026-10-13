using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreGameLicense
{
	internal Unity.XGamingRuntime.Interop.XStoreGameLicense interop;

	public string SkuStoreId
	{
		get
		{
			return interop.skuStoreId;
		}
		set
		{
			interop.skuStoreId = value;
		}
	}

	public bool IsActive
	{
		get
		{
			return interop.isActive;
		}
		set
		{
			interop.isActive = value;
		}
	}

	public bool IsTrialOwnedByThisUser
	{
		get
		{
			return interop.isTrialOwnedByThisUser;
		}
		set
		{
			interop.isTrialOwnedByThisUser = value;
		}
	}

	public bool IsDiscLicense
	{
		get
		{
			return interop.isDiscLicense;
		}
		set
		{
			interop.isDiscLicense = value;
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

	public string TrialUniqueId
	{
		get
		{
			return interop.trialUniqueId;
		}
		set
		{
			interop.trialUniqueId = value;
		}
	}

	public long ExpirationDate
	{
		get
		{
			return interop.expirationDate;
		}
		set
		{
			interop.expirationDate = value;
		}
	}

	internal XStoreGameLicense(Unity.XGamingRuntime.Interop.XStoreGameLicense interop)
	{
		this.interop = interop;
	}

	public XStoreGameLicense()
	{
		interop = default;
	}
}
