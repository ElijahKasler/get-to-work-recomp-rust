using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblTournamentTeamResult
{
	public string Team { get; }

	public XblTournamentGameResultWithRank GameResult { get; }

	internal XblTournamentTeamResult(Unity.XGamingRuntime.Interop.XblTournamentTeamResult interopStruct)
	{
		Team = interopStruct.Team.GetString();
		GameResult = new XblTournamentGameResultWithRank(interopStruct.GameResult);
	}
}
