using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XUserPrivilegeDenyReason : uint
{
	None = 0u,
	PurchaseRequired = 1u,
	Restricted = 2u,
	Banned = 3u,
	Unknown = uint.MaxValue
}
