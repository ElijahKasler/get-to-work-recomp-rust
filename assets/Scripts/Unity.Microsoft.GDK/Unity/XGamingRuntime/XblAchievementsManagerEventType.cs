using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblAchievementsManagerEventType : uint
{
	LocalUserInitialStateSynced = 0u,
	AchievementUnlocked = 1u,
	AchievementProgressUpdated = 2u
}
