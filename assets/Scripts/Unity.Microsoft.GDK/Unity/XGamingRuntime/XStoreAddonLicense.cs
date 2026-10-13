using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreAddonLicense
{
	internal Unity.XGamingRuntime.Interop.XStoreAddonLicense interop;

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

	public string InAppOfferToken
	{
		get
		{
			return interop.inAppOfferToken;
		}
		set
		{
			interop.inAppOfferToken = value;
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

	internal XStoreAddonLicense(Unity.XGamingRuntime.Interop.XStoreAddonLicense interop)
	{
		this.interop = interop;
	}

	public XStoreAddonLicense()
	{
		interop = default;
	}
}
