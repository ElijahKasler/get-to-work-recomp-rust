using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XPackageWriteStats
{
	internal Unity.XGamingRuntime.Interop.XPackageWriteStats interop;

	public ulong Interval
	{
		get
		{
			return interop.interval;
		}
		set
		{
			interop.interval = value;
		}
	}

	public ulong Budget
	{
		get
		{
			return interop.budget;
		}
		set
		{
			interop.budget = value;
		}
	}

	public ulong Elapsed
	{
		get
		{
			return interop.elapsed;
		}
		set
		{
			interop.elapsed = value;
		}
	}

	public ulong BytesWritten
	{
		get
		{
			return interop.bytesWritten;
		}
		set
		{
			interop.bytesWritten = value;
		}
	}

	internal XPackageWriteStats(Unity.XGamingRuntime.Interop.XPackageWriteStats interop)
	{
		this.interop = interop;
	}

	public XPackageWriteStats()
	{
		interop = default;
	}
}
