using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XVersion
{
	internal Unity.XGamingRuntime.Interop.XVersion interop;

	public ushort Major
	{
		get
		{
			return interop.major;
		}
		set
		{
			interop.major = value;
		}
	}

	public ushort Minor
	{
		get
		{
			return interop.minor;
		}
		set
		{
			interop.minor = value;
		}
	}

	public ushort Build
	{
		get
		{
			return interop.build;
		}
		set
		{
			interop.build = value;
		}
	}

	public ushort Revision
	{
		get
		{
			return interop.revision;
		}
		set
		{
			interop.revision = value;
		}
	}

	public ulong Value
	{
		get
		{
			return interop.Value;
		}
		set
		{
			interop.Value = value;
		}
	}

	internal XVersion(Unity.XGamingRuntime.Interop.XVersion interop)
	{
		this.interop = interop;
	}

	public XVersion()
	{
		interop = default;
	}
}
