using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XStorePrice
{
	internal float basePrice;

	internal float price;

	internal float recurrencePrice;

	[MarshalAs(UnmanagedType.LPStr)]
	internal string currencyCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	internal string formattedBasePrice;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	internal string formattedPrice;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	internal string formattedRecurrencePrice;

	[MarshalAs(UnmanagedType.I1)]
	internal bool isOnSale;

	internal long saleEndDate;
}
