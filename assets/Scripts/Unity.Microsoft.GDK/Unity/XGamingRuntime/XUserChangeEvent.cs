using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XUserChangeEvent : uint
{
	SignedInAgain = 0u,
	SigningOut = 1u,
	SignedOut = 2u,
	Gamertag = 3u,
	GamerPicture = 4u,
	Privileges = 5u
}
