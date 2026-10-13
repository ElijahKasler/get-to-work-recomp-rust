using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStoreAddonLicense
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
	internal string skuStoreId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	internal string inAppOfferToken;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isActive;

	internal long expirationDate;
}
