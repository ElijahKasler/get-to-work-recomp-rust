using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblLeaderboardStatType : uint
{
	Uint64 = 0u,
	Boolean = 1u,
	Double = 2u,
	String = 3u,
	Other = 4u
}
