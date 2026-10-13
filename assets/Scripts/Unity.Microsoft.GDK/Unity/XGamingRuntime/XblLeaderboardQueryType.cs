using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblLeaderboardQueryType : uint
{
	UserStatBacked = 0u,
	TitleManagedStatBackedGlobal = 1u,
	TitleManagedStatBackedSocial = 2u
}
