using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStoreSkuInterop
{
	[MarshalAs(UnmanagedType.LPStr)]
	internal string skuId;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string title;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string description;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string language;

	internal XStorePrice price;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isTrial;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isInUserCollection;

	internal XStoreCollectionData collectionData;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isSubscription;

	internal XStoreSubscriptionInfo subscriptionInfo;

	internal uint bundledSkusCount;

	internal IntPtr bundledSkus;

	internal uint imagesCount;

	internal IntPtr images;

	internal uint videosCount;

	internal IntPtr videos;

	internal uint availabilitiesCount;

	internal IntPtr availabilities;
}
