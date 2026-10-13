namespace Unity.XGamingRuntime.Interop;

internal struct XNetworkingTcpQueuedReceivedBufferUsageStatistics
{
	internal ulong numBytesCurrentlyQueued;

	internal ulong peakNumBytesEverQueued;

	internal ulong totalNumBytesQueued;

	internal ulong numBytesDroppedForExceedingConfiguredMax;

	internal ulong numBytesDroppedDueToAnyFailure;
}
