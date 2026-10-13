using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblMultiplayerSessionType : uint
{
	Unknown = 0u,
	LobbySession = 1u,
	GameSession = 2u,
	MatchSession = 3u
}
