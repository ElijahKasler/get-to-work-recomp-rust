using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerSessionQuery
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	internal readonly byte[] Scid;

	private uint MaxItems;

	[MarshalAs(UnmanagedType.U1)]
	internal bool IncludePrivateSessions;

	[MarshalAs(UnmanagedType.U1)]
	internal bool IncludeReservations;

	[MarshalAs(UnmanagedType.U1)]
	internal bool IncludeInactiveSessions;

	private readonly IntPtr XuidFilters;

	private SizeT XuidFiltersCount;

	internal UTF8StringPtr KeywordFilter;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
	internal readonly byte[] SessionTemplateNameFilter;

	private XblMultiplayerSessionVisibility VisibilityFilter;

	private uint ContractVersionFilter;

	internal XblMultiplayerSessionQuery(Unity.XGamingRuntime.XblMultiplayerSessionQuery publicObject, DisposableCollection disposableCollection)
	{
		Scid = Converters.StringToNullTerminatedUTF8ByteArray(publicObject.Scid ?? "", 40);
		MaxItems = publicObject.MaxItems;
		IncludePrivateSessions = publicObject.IncludePrivateSessions;
		IncludeReservations = publicObject.IncludeReservations;
		IncludeInactiveSessions = publicObject.IncludeInactiveSessions;
		XuidFilters = Converters.ClassArrayToPtr(publicObject.XuidFilters, (ulong x, DisposableCollection dc) => x, disposableCollection, out XuidFiltersCount);
		KeywordFilter = new UTF8StringPtr(publicObject.KeywordFilter, disposableCollection);
		SessionTemplateNameFilter = Converters.StringToNullTerminatedUTF8ByteArray(publicObject.SessionTemplateNameFilter ?? "", 100);
		VisibilityFilter = publicObject.VisibilityFilter;
		ContractVersionFilter = publicObject.ContractVersionFilter;
	}
}
