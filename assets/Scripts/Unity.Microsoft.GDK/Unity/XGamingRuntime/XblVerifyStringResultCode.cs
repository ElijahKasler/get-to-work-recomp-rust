using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblVerifyStringResultCode : uint
{
	Success = 0u,
	Offensive = 1u,
	TooLong = 2u,
	UnknownError = 3u
}
