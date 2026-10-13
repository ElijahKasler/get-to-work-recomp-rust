using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XPackageChunkAvailability : uint
{
	Ready = 0u,
	Pending = 1u,
	Installable = 2u,
	Unavailable = 3u
}
