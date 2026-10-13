namespace Unity.XGamingRuntime.Interop;

internal struct XblMatchTicketDetailsResponse
{
	internal XblTicketStatus matchStatus;

	internal long estimatedWaitTime;

	internal XblPreserveSessionMode preserveSession;

	internal XblMultiplayerSessionReference ticketSession;

	internal XblMultiplayerSessionReference targetSession;

	internal readonly UTF8StringPtr ticketAttributes;
}
