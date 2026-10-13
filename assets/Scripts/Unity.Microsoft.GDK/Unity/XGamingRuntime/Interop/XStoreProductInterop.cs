using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStoreProductInterop
{
	[MarshalAs(UnmanagedType.LPStr)]
	internal string storeId;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string title;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string description;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string language;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string inAppOfferToken;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string linkUri;

	internal XStoreProductKind productKind;

	internal XStorePrice price;

	[MarshalAs(UnmanagedType.I1)]
	internal bool hasDigitalDownload;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isInUserCollection;

	internal uint keywordsCount;

	internal IntPtr keywords;

	internal uint skusCount;

	internal IntPtr skus;

	internal uint imagesCount;

	internal IntPtr images;

	internal uint videosCount;

	internal IntPtr videos;
}
