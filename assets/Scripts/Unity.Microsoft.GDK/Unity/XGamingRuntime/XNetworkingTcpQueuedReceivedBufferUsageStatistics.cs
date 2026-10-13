using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XNetworkingTcpQueuedReceivedBufferUsageStatistics
{
	internal Unity.XGamingRuntime.Interop.XNetworkingTcpQueuedReceivedBufferUsageStatistics interop;

	public ulong NumBytesCurrentlyQueued
	{
		get
		{
			return interop.numBytesCurrentlyQueued;
		}
		set
		{
			interop.numBytesCurrentlyQueued = value;
		}
	}

	public ulong PeakNumBytesEverQueued
	{
		get
		{
			return interop.peakNumBytesEverQueued;
		}
		set
		{
			interop.peakNumBytesEverQueued = value;
		}
	}

	public ulong TotalNumBytesQueued
	{
		get
		{
			return interop.totalNumBytesQueued;
		}
		set
		{
			interop.totalNumBytesQueued = value;
		}
	}

	public ulong NumBytesDroppedForExceedingConfiguredMax
	{
		get
		{
			return interop.numBytesDroppedForExceedingConfiguredMax;
		}
		set
		{
			interop.numBytesDroppedForExceedingConfiguredMax = value;
		}
	}

	public ulong NumBytesDroppedDueToAnyFailure
	{
		get
		{
			return interop.numBytesDroppedDueToAnyFailure;
		}
		set
		{
			interop.numBytesDroppedDueToAnyFailure = value;
		}
	}

	internal XNetworkingTcpQueuedReceivedBufferUsageStatistics(Unity.XGamingRuntime.Interop.XNetworkingTcpQueuedReceivedBufferUsageStatistics interop)
	{
		this.interop = interop;
	}

	public XNetworkingTcpQueuedReceivedBufferUsageStatistics()
	{
		interop = default;
	}
}
