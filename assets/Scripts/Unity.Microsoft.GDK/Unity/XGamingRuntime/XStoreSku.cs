using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreSku
{
	public string SkuId { get; }

	public string Title { get; }

	public string Description { get; }

	public string Language { get; }

	public XStorePrice Price { get; }

	public bool IsTrial { get; }

	public bool IsInUserCollection { get; }

	public XStoreCollectionData CollectionData { get; }

	public bool IsSubscription { get; }

	public XStoreSubscriptionInfo SubscriptionInfo { get; }

	public string[] BundledSkus { get; }

	public XStoreImage[] Images { get; }

	public XStoreVideo[] Videos { get; }

	public XStoreAvailability[] Availabilities { get; }

	internal XStoreSku(ref XStoreSkuInterop interop)
	{
		SkuId = interop.skuId;
		Title = interop.title;
		Description = interop.description;
		Language = interop.language;
		Price = new XStorePrice(interop.price);
		IsTrial = interop.isTrial;
		IsInUserCollection = interop.isInUserCollection;
		CollectionData = new XStoreCollectionData(interop.collectionData);
		IsSubscription = interop.isSubscription;
		SubscriptionInfo = new XStoreSubscriptionInfo(interop.subscriptionInfo);
		BundledSkus = InteropHelpers.MarshalStringArrayAnsi(interop.bundledSkus, interop.bundledSkusCount);
		Images = InteropHelpers.MarshalArray(interop.images, interop.imagesCount, (Unity.XGamingRuntime.Interop.XStoreImage imageInterop) => new XStoreImage(imageInterop));
		Videos = InteropHelpers.MarshalArray(interop.videos, interop.videosCount, (Unity.XGamingRuntime.Interop.XStoreVideo videoInterop) => new XStoreVideo(videoInterop));
		Availabilities = InteropHelpers.MarshalArray(interop.availabilities, interop.availabilitiesCount, (Unity.XGamingRuntime.Interop.XStoreAvailability availabilityInterop) => new XStoreAvailability(availabilityInterop));
	}
}
