using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblTitleManagedStatistic
{
	public string StatisticName { get; set; }

	public XblTitleManagedStatType StatisticType { get; set; }

	public double NumberValue { get; set; }

	public string StringValue { get; set; }

	internal XblTitleManagedStatistic(Unity.XGamingRuntime.Interop.XblTitleManagedStatistic interopStruct)
	{
		StatisticName = interopStruct.statisticName.GetString();
		StatisticType = interopStruct.statisticType;
		NumberValue = interopStruct.numberValue;
		StringValue = interopStruct.stringValue.GetString();
	}

	internal XblTitleManagedStatistic(string statisticName, XblTitleManagedStatType statType, string stringValue, double numberValue)
	{
		StatisticName = statisticName;
		StatisticType = statType;
		StringValue = stringValue;
		NumberValue = numberValue;
	}

	public XblTitleManagedStatistic()
	{
	}

	public XblTitleManagedStatistic(string statisticName, string statisticValue)
		: this(statisticName, XblTitleManagedStatType.String, statisticValue, 0.0)
	{
	}

	public XblTitleManagedStatistic(string statisticName, double statisticValue)
		: this(statisticName, XblTitleManagedStatType.Number, null, statisticValue)
	{
	}

	public static int Create(string statisticName, string statisticValue, out XblTitleManagedStatistic titleManagedStatistic)
	{
		titleManagedStatistic = new XblTitleManagedStatistic(statisticName, XblTitleManagedStatType.String, statisticValue, 0.0);
		return 0;
	}

	public static int Create(string statisticName, double statisticValue, out XblTitleManagedStatistic titleManagedStatistic)
	{
		titleManagedStatistic = new XblTitleManagedStatistic(statisticName, XblTitleManagedStatType.Number, null, statisticValue);
		return 0;
	}
}
