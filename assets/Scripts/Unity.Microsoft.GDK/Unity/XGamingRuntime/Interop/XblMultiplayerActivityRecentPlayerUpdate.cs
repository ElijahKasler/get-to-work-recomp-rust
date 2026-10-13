namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerActivityRecentPlayerUpdate
{
	internal readonly ulong xuid;

	internal readonly XblMultiplayerActivityEncounterType encounterType;

	internal XblMultiplayerActivityRecentPlayerUpdate(Unity.XGamingRuntime.XblMultiplayerActivityRecentPlayerUpdate publicObject)
	{
		xuid = publicObject.Xuid;
		encounterType = publicObject.EncounterType;
	}
}
