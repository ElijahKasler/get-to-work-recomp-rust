using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblStatistic
{
	public string StatisticName { get; private set; }

	public string StatisticType { get; private set; }

	public string Value { get; private set; }

	internal XblStatistic(XblStatisticInternal interopStatistic)
	{
		StatisticName = interopStatistic.statisticName.GetString();
		StatisticType = interopStatistic.statisticType.GetString();
		Value = interopStatistic.value.GetString();
	}

	internal unsafe XblStatistic(Unity.XGamingRuntime.Interop.XblStatistic interopStatistic)
	{
		StatisticName = Converters.NullTerminatedBytePointerToString((byte*)interopStatistic.statisticName);
		StatisticType = Converters.NullTerminatedBytePointerToString((byte*)interopStatistic.statisticType);
		Value = Converters.NullTerminatedBytePointerToString((byte*)interopStatistic.value);
	}
}
