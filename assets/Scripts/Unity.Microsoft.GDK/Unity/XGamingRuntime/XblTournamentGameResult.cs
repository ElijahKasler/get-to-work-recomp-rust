using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblTournamentGameResult : uint
{
	NoContest = 0u,
	Win = 1u,
	Loss = 2u,
	Draw = 3u,
	Rank = 4u,
	NoShow = 5u
}
