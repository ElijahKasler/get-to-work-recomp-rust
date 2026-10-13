using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblAchievementProgressState : uint
{
	Unknown = 0u,
	Achieved = 1u,
	NotStarted = 2u,
	InProgress = 3u
}
