using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XUserAddOptions : uint
{
	None = 0u,
	AddDefaultUserSilently = 1u,
	AllowGuests = 2u,
	AddDefaultUserAllowingUI = 4u
}
