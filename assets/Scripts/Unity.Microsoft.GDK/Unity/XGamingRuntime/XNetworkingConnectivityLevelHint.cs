using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XNetworkingConnectivityLevelHint : uint
{
	Unknown = 0u,
	None = 1u,
	LocalAccess = 2u,
	InternetAccess = 3u,
	ConstrainedInternetAccess = 4u
}
