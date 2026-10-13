using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XNetworkingStatisticsBuffer
{
	internal Unity.XGamingRuntime.Interop.XNetworkingStatisticsBuffer _interop;

	internal XNetworkingTcpQueuedReceivedBufferUsageStatistics _tcpQueuedReceivedBufferUsageStatistics;

	internal Unity.XGamingRuntime.Interop.XNetworkingStatisticsBuffer interop
	{
		get
		{
			_interop.tcpQueuedReceiveBufferUsage = _tcpQueuedReceivedBufferUsageStatistics.interop;
			return _interop;
		}
	}

	public XNetworkingTcpQueuedReceivedBufferUsageStatistics TcpQueuedReceiveBufferUsage
	{
		get
		{
			return _tcpQueuedReceivedBufferUsageStatistics;
		}
		set
		{
			_tcpQueuedReceivedBufferUsageStatistics = value;
		}
	}

	internal XNetworkingStatisticsBuffer(Unity.XGamingRuntime.Interop.XNetworkingStatisticsBuffer interop)
	{
		_interop = interop;
		_tcpQueuedReceivedBufferUsageStatistics = new XNetworkingTcpQueuedReceivedBufferUsageStatistics(interop.tcpQueuedReceiveBufferUsage);
	}

	public XNetworkingStatisticsBuffer()
	{
		_interop = default;
	}
}
