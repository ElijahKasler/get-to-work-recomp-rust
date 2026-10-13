using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerPeerToHostRequirements
{
	public ulong LatencyMaximum { get; }

	public ulong BandwidthDownMinimumInKbps { get; }

	public ulong BandwidthUpMinimumInKbps { get; }

	public XblMultiplayerMetrics HostSelectionMetric { get; }

	internal XblMultiplayerPeerToHostRequirements(Unity.XGamingRuntime.Interop.XblMultiplayerPeerToHostRequirements interopStruct)
	{
		LatencyMaximum = interopStruct.LatencyMaximum;
		BandwidthDownMinimumInKbps = interopStruct.BandwidthDownMinimumInKbps;
		BandwidthUpMinimumInKbps = interopStruct.BandwidthUpMinimumInKbps;
		HostSelectionMetric = interopStruct.HostSelectionMetric;
	}
}
