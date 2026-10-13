using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblHopperStatisticsResponse
{
	public string HopperName { get; set; }

	public long EstimatedWaitTime { get; set; }

	public uint PlayersWaitingToMatch { get; set; }

	internal XblHopperStatisticsResponse()
	{
		HopperName = "";
		EstimatedWaitTime = 0L;
		PlayersWaitingToMatch = 0u;
	}

	internal XblHopperStatisticsResponse(Unity.XGamingRuntime.Interop.XblHopperStatisticsResponse interopHandle)
	{
		HopperName = interopHandle.hopperName.GetString();
		EstimatedWaitTime = interopHandle.estimatedWaitTime;
		PlayersWaitingToMatch = interopHandle.playersWaitingToMatch;
	}
}
