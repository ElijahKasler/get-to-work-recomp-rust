namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerPeerToPeerRequirements
{
	internal readonly ulong LatencyMaximum;

	internal readonly ulong BandwidthMinimumInKbps;

	internal XblMultiplayerPeerToPeerRequirements(Unity.XGamingRuntime.XblMultiplayerPeerToPeerRequirements publicObject)
	{
		LatencyMaximum = publicObject.LatencyMaximum;
		BandwidthMinimumInKbps = publicObject.BandwidthMinimumInKbps;
	}
}
