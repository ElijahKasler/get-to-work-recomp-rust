using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerPeerToPeerRequirements
{
	public ulong LatencyMaximum { get; }

	public ulong BandwidthMinimumInKbps { get; }

	internal XblMultiplayerPeerToPeerRequirements(Unity.XGamingRuntime.Interop.XblMultiplayerPeerToPeerRequirements interopStruct)
	{
		LatencyMaximum = interopStruct.LatencyMaximum;
		BandwidthMinimumInKbps = interopStruct.BandwidthMinimumInKbps;
	}
}
