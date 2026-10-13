using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblMultiplayerMeasurementFailure : uint
{
	Unknown = 0u,
	None = 1u,
	Timeout = 2u,
	Latency = 3u,
	BandwidthUp = 4u,
	BandwidthDown = 5u,
	Group = 6u,
	Network = 7u,
	Episode = 8u
}
