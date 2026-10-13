using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblLeaderboardResult
{
	public uint TotalRowCount { get; private set; }

	public XblLeaderboardColumn[] Columns { get; private set; }

	public XblLeaderboardRow[] Rows { get; private set; }

	public bool HasNext { get; private set; }

	public XblLeaderboardQuery NextQuery { get; private set; }

	internal XblLeaderboardResult(Unity.XGamingRuntime.Interop.XblLeaderboardResult interopResult)
	{
		TotalRowCount = interopResult.totalRowCount;
		Columns = interopResult.GetColumns((Unity.XGamingRuntime.Interop.XblLeaderboardColumn c) => new XblLeaderboardColumn(c));
		Rows = interopResult.GetRows((Unity.XGamingRuntime.Interop.XblLeaderboardRow r) => new XblLeaderboardRow(r));
		HasNext = interopResult.hasNext.Value;
		NextQuery = new XblLeaderboardQuery(interopResult.nextQuery);
	}
}
