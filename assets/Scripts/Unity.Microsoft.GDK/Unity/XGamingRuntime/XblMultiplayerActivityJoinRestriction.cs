using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblMultiplayerActivityJoinRestriction : uint
{
	Public = 0u,
	InviteOnly = 1u,
	Followed = 2u
}
