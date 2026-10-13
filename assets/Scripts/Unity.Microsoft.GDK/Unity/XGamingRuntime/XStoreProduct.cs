using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XStoreProduct
{
	public string StoreId { get; }

	public string Title { get; }

	public string Description { get; }

	public string Language { get; }

	public string InAppOfferToken { get; }

	public string LinkUri { get; }

	public XStoreProductKind ProductKind { get; }

	public XStorePrice Price { get; }

	public bool HasDigitalDownload { get; }

	public bool IsInUserCollection { get; }

	public string[] Keywords { get; }

	public XStoreSku[] Skus { get; }

	public XStoreImage[] Images { get; }

	public XStoreVideo[] Videos { get; }

	internal XStoreProduct(ref XStoreProductInterop interop)
	{
		StoreId = interop.storeId;
		Title = interop.title;
		Description = interop.description;
		Language = interop.language;
		InAppOfferToken = interop.inAppOfferToken;
		LinkUri = interop.linkUri;
		ProductKind = interop.productKind;
		Price = new XStorePrice(interop.price);
		HasDigitalDownload = interop.hasDigitalDownload;
		IsInUserCollection = interop.isInUserCollection;
		Keywords = InteropHelpers.MarshalStringArrayAnsi(interop.keywords, interop.keywordsCount);
		Skus = InteropHelpers.MarshalArray(interop.skus, interop.skusCount, (XStoreSkuInterop skuInterop) => new XStoreSku(ref skuInterop));
		Images = InteropHelpers.MarshalArray(interop.images, interop.imagesCount, (Unity.XGamingRuntime.Interop.XStoreImage imageInterop) => new XStoreImage(imageInterop));
		Videos = InteropHelpers.MarshalArray(interop.videos, interop.videosCount, (Unity.XGamingRuntime.Interop.XStoreVideo videoInterop) => new XStoreVideo(videoInterop));
	}
}
