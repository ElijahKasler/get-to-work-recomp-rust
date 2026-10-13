using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore.Interop")]
public class XSystemAnalyticsInfo
{
	internal Unity.XGamingRuntime.Interop.XSystemAnalyticsInfo interop;

	private XVersion _osVersion;

	private XVersion _hostingOsVersion;

	public XVersion OsVersion
	{
		get
		{
			return _osVersion;
		}
		set
		{
			_osVersion = value;
		}
	}

	public XVersion HostingOsVersion
	{
		get
		{
			return _hostingOsVersion;
		}
		set
		{
			_hostingOsVersion = value;
		}
	}

	public string Family
	{
		get
		{
			return interop.family;
		}
		set
		{
			interop.family = value;
		}
	}

	public string Form
	{
		get
		{
			return interop.form;
		}
		set
		{
			interop.form = value;
		}
	}

	internal XSystemAnalyticsInfo(Unity.XGamingRuntime.Interop.XSystemAnalyticsInfo interop)
	{
		this.interop = interop;
		_osVersion = new XVersion(this.interop.osVersion);
		_hostingOsVersion = new XVersion(this.interop.hostingOsVersion);
	}

	public XSystemAnalyticsInfo()
	{
		interop = default;
		_osVersion = new XVersion();
		_hostingOsVersion = new XVersion();
	}
}
