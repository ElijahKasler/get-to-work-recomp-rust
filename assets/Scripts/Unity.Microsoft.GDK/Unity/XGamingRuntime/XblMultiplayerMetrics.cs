using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public enum XblMultiplayerMetrics : uint
{
	Unknown = 0u,
	BandwidthUp = 1u,
	BandwidthDown = 2u,
	Bandwidth = 3u,
	Latency = 4u
}
