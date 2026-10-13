using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XSystemRuntimeInfo
{
	internal XVersion _runtimeVersion;

	internal XVersion _availableVersion;

	public XVersion RuntimeVersion
	{
		get
		{
			return _runtimeVersion;
		}
		set
		{
			_runtimeVersion = value;
		}
	}

	public XVersion AvailableVersion
	{
		get
		{
			return _availableVersion;
		}
		set
		{
			_availableVersion = value;
		}
	}

	internal XSystemRuntimeInfo(Unity.XGamingRuntime.Interop.XSystemRuntimeInfo interop)
	{
		_runtimeVersion = new XVersion(interop.runtimeVersion);
		_availableVersion = new XVersion(interop.availableVersion);
	}

	public XSystemRuntimeInfo()
	{
		_runtimeVersion = new XVersion();
		_availableVersion = new XVersion();
	}
}
