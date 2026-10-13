using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMatchTicketDetailsResponse
{
	public XblTicketStatus MatchStatus { get; }

	public long EstimatedWaitTime { get; }

	public XblPreserveSessionMode PreserveSession { get; }

	public XblMultiplayerSessionReference TicketSession { get; }

	public XblMultiplayerSessionReference TargetSession { get; }

	public string TicketAttributes { get; }

	internal XblMatchTicketDetailsResponse(Unity.XGamingRuntime.Interop.XblMatchTicketDetailsResponse interopHandle)
	{
		MatchStatus = interopHandle.matchStatus;
		EstimatedWaitTime = interopHandle.estimatedWaitTime;
		PreserveSession = interopHandle.preserveSession;
		TicketSession = new XblMultiplayerSessionReference(interopHandle.ticketSession);
		TargetSession = new XblMultiplayerSessionReference(interopHandle.targetSession);
		TicketAttributes = interopHandle.ticketAttributes.GetString();
	}
}
