using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblLeaderboardColumn
{
	public string StatName { get; private set; }

	public XblLeaderboardStatType StatType { get; private set; }

	internal XblLeaderboardColumn(Unity.XGamingRuntime.Interop.XblLeaderboardColumn interopColumn)
	{
		StatName = interopColumn.statName.GetString();
		StatType = interopColumn.statType;
	}
}
