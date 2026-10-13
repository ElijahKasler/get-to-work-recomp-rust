namespace Unity.XGamingRuntime.Interop;

internal struct XblAchievementProgressChangeEntry
{
	internal UTF8StringPtr achievementId;

	internal XblAchievementProgressState progressState;

	internal XblAchievementProgression progression;
}
