using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XNetworkingConnectivityCostHint : uint
{
	Unknown = 0u,
	Unrestricted = 1u,
	Fixed = 2u,
	Variable = 3u
}
