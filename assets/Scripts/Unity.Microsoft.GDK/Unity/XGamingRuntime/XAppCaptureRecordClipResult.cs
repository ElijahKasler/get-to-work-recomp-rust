using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XAppCaptureRecordClipResult
{
	internal Unity.XGamingRuntime.Interop.XAppCaptureRecordClipResult interop;

	public string Path
	{
		get
		{
			return interop.path;
		}
		set
		{
			interop.path = value;
		}
	}

	public long FileSize
	{
		get
		{
			return interop.fileSize;
		}
		set
		{
			interop.fileSize = value;
		}
	}

	public long StartTime
	{
		get
		{
			return interop.startTime;
		}
		set
		{
			interop.startTime = value;
		}
	}

	public uint DurationInMs
	{
		get
		{
			return interop.durationInMs;
		}
		set
		{
			interop.durationInMs = value;
		}
	}

	public uint Width
	{
		get
		{
			return interop.width;
		}
		set
		{
			interop.width = value;
		}
	}

	public uint Height
	{
		get
		{
			return interop.height;
		}
		set
		{
			interop.height = value;
		}
	}

	public XAppCaptureVideoEncoding Encoding
	{
		get
		{
			return interop.encoding;
		}
		set
		{
			interop.encoding = value;
		}
	}

	public uint StartTimePreciseOffsetHns
	{
		get
		{
			return interop.startTimePreciseOffsetHns;
		}
		set
		{
			interop.startTimePreciseOffsetHns = value;
		}
	}

	[Obsolete("Please use Path instead, (UnityUpgradable) -> Path", true)]
	public string path
	{
		get
		{
			return interop.path;
		}
		set
		{
			interop.path = value;
		}
	}

	[Obsolete("Please use FileSize instead, (UnityUpgradable) -> FileSize", true)]
	public long fileSize
	{
		get
		{
			return interop.fileSize;
		}
		set
		{
			interop.fileSize = value;
		}
	}

	[Obsolete("Please use StartTime instead, (UnityUpgradable) -> StartTime", true)]
	public long startTime
	{
		get
		{
			return interop.startTime;
		}
		set
		{
			interop.startTime = value;
		}
	}

	[Obsolete("Please use DurationInMs instead, (UnityUpgradable) -> DurationInMs", true)]
	public uint durationInMs
	{
		get
		{
			return interop.durationInMs;
		}
		set
		{
			interop.durationInMs = value;
		}
	}

	[Obsolete("Please use Width instead, (UnityUpgradable) -> Width", true)]
	public uint width
	{
		get
		{
			return interop.width;
		}
		set
		{
			interop.width = value;
		}
	}

	[Obsolete("Please use Height instead, (UnityUpgradable) -> Height", true)]
	public uint height
	{
		get
		{
			return interop.height;
		}
		set
		{
			interop.height = value;
		}
	}

	[Obsolete("Please use Encoding instead, (UnityUpgradable) -> Encoding", true)]
	public XAppCaptureVideoEncoding encoding
	{
		get
		{
			return interop.encoding;
		}
		set
		{
			interop.encoding = value;
		}
	}

	[Obsolete("Please use StartTimePreciseOffsetHns instead, (UnityUpgradable) -> StartTimePreciseOffsetHns", true)]
	public uint startTimePreciseOffsetHns
	{
		get
		{
			return interop.startTimePreciseOffsetHns;
		}
		set
		{
			interop.startTimePreciseOffsetHns = value;
		}
	}

	internal XAppCaptureRecordClipResult(Unity.XGamingRuntime.Interop.XAppCaptureRecordClipResult interop)
	{
		this.interop = interop;
	}

	public XAppCaptureRecordClipResult()
	{
		interop = default;
	}
}
