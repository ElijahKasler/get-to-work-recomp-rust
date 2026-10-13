using System;

namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerSessionInitArgs
{
	internal readonly uint MaxMembersInSession;

	internal readonly XblMultiplayerSessionVisibility Visibility;

	private readonly IntPtr InitiatorXuids;

	internal readonly SizeT InitiatorXuidsCount;

	internal readonly UTF8StringPtr CustomJson;

	internal XblMultiplayerSessionInitArgs(Unity.XGamingRuntime.XblMultiplayerSessionInitArgs publicObject, DisposableCollection disposableCollection)
	{
		MaxMembersInSession = publicObject.MaxMembersInSession;
		Visibility = publicObject.Visibility;
		InitiatorXuids = Converters.ClassArrayToPtr(publicObject.InitiatorXuids, (ulong x, DisposableCollection dc) => x, disposableCollection, out InitiatorXuidsCount);
		CustomJson = new UTF8StringPtr(publicObject.CustomJson, disposableCollection);
	}
}
