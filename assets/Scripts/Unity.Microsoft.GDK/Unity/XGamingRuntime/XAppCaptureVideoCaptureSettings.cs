using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XAppCaptureVideoCaptureSettings
{
	internal Unity.XGamingRuntime.Interop.XAppCaptureVideoCaptureSettings interop;

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

	public ulong MaxRecordTimespanDurationInMs
	{
		get
		{
			return interop.maxRecordTimespanDurationInMs;
		}
		set
		{
			interop.maxRecordTimespanDurationInMs = value;
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

	public XAppCaptureVideoColorFormat ColorFormat
	{
		get
		{
			return interop.colorFormat;
		}
		set
		{
			interop.colorFormat = value;
		}
	}

	public bool IsCaptureByGamesAllowed
	{
		get
		{
			return interop.isCaptureByGamesAllowed;
		}
		set
		{
			interop.isCaptureByGamesAllowed = value;
		}
	}

	internal XAppCaptureVideoCaptureSettings(Unity.XGamingRuntime.Interop.XAppCaptureVideoCaptureSettings interop)
	{
		this.interop = interop;
	}

	public XAppCaptureVideoCaptureSettings()
	{
		interop = default;
	}
}
