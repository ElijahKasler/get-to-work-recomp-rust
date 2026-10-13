namespace Unity.XGamingRuntime.Interop;

internal struct XblHopperStatisticsResponse
{
	internal UTF8StringPtr hopperName;

	internal long estimatedWaitTime;

	internal uint playersWaitingToMatch;
}
