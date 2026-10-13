using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblTournamentGameResultWithRank
{
	public XblTournamentGameResult Result { get; }

	public ulong Ranking { get; }

	internal XblTournamentGameResultWithRank(Unity.XGamingRuntime.Interop.XblTournamentGameResultWithRank interopStruct)
	{
		Result = interopStruct.Result;
		Ranking = interopStruct.Ranking;
	}
}
