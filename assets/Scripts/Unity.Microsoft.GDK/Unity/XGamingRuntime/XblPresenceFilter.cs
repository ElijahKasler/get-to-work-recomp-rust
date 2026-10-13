using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblPresenceFilter : uint
{
	Unknown = 0u,
	TitleOnline = 1u,
	TitleOffline = 2u,
	TitleOnlineOutsideTitle = 3u,
	AllOnline = 4u,
	AllOffline = 5u,
	AllTitle = 6u,
	All = 7u
}
