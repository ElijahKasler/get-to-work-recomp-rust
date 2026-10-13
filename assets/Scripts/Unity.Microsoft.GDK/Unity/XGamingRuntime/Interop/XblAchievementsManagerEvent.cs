namespace Unity.XGamingRuntime.Interop;

internal struct XblAchievementsManagerEvent
{
	internal XblAchievementProgressChangeEntry progressInfo;

	internal ulong xboxUserId;

	internal XblAchievementsManagerEventType eventType;
}
