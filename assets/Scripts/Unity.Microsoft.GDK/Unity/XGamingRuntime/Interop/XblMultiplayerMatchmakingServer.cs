namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerMatchmakingServer
{
	internal XblMatchmakingStatus Status;

	internal UTF8StringPtr StatusDetails;

	internal uint TypicalWaitInSeconds;

	internal XblMultiplayerSessionReference TargetSessionRef;
}
