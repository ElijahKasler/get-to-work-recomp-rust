using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XAppCaptureLocalResult
{
	internal XAppCaptureLocalStreamHandle _clipHandle;

	internal SYSTEMTIME _clipStartTimestamp;

	internal Unity.XGamingRuntime.Interop.XAppCaptureLocalResult interop;

	public XAppCaptureLocalStreamHandle ClipHandle
	{
		get
		{
			return _clipHandle;
		}
		set
		{
			_clipHandle = value;
		}
	}

	public ulong FileSizeInBytes
	{
		get
		{
			return interop.fileSizeInBytes;
		}
		set
		{
			interop.fileSizeInBytes = value;
		}
	}

	public SYSTEMTIME ClipStartTimestamp
	{
		get
		{
			return _clipStartTimestamp;
		}
		set
		{
			_clipStartTimestamp = value;
		}
	}

	public ulong DurationInMilliseconds
	{
		get
		{
			return interop.durationInMilliseconds;
		}
		set
		{
			interop.durationInMilliseconds = value;
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

	internal XAppCaptureLocalResult(Unity.XGamingRuntime.Interop.XAppCaptureLocalResult interop)
	{
		_clipHandle = new XAppCaptureLocalStreamHandle(interop.clipHandle);
		_clipStartTimestamp = new SYSTEMTIME(interop.clipStartTimestamp);
		this.interop = interop;
	}
}
