using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XUserState : uint
{
	SignedIn = 0u,
	SigningOut = 1u,
	SignedOut = 2u
}
