using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public struct XblStatisticChangeEventArgs
{
	public ulong xboxUserId;

	public string serviceConfigurationId;

	public XblStatistic latestStatistic;

	internal unsafe XblStatisticChangeEventArgs(Unity.XGamingRuntime.Interop.XblStatisticChangeEventArgs interopStruct)
	{
		xboxUserId = interopStruct.xboxUserId;
		serviceConfigurationId = new string(interopStruct.serviceConfigurationId);
		latestStatistic = new XblStatistic(interopStruct.latestStatistic);
	}
}
