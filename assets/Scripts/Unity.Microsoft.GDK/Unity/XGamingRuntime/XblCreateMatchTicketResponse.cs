using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblCreateMatchTicketResponse
{
	public string MatchTicketId { get; }

	public long EstimatedWaitTime { get; }

	internal XblCreateMatchTicketResponse(Unity.XGamingRuntime.Interop.XblCreateMatchTicketResponse interopHandle)
	{
		MatchTicketId = Converters.ByteArrayToString(interopHandle.matchTicketId);
		EstimatedWaitTime = interopHandle.estimatedWaitTime;
	}
}
