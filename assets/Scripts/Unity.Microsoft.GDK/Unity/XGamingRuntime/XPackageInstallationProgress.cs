using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XPackageInstallationProgress
{
	internal Unity.XGamingRuntime.Interop.XPackageInstallationProgress interop;

	public ulong TotalBytes
	{
		get
		{
			return interop.totalBytes;
		}
		set
		{
			interop.totalBytes = value;
		}
	}

	public ulong InstalledBytes
	{
		get
		{
			return interop.installedBytes;
		}
		set
		{
			interop.installedBytes = value;
		}
	}

	public ulong LaunchBytes
	{
		get
		{
			return interop.launchBytes;
		}
		set
		{
			interop.launchBytes = value;
		}
	}

	public bool Launchable
	{
		get
		{
			return interop.launchable;
		}
		set
		{
			interop.launchable = value;
		}
	}

	public bool Completed
	{
		get
		{
			return interop.completed;
		}
		set
		{
			interop.completed = value;
		}
	}

	internal XPackageInstallationProgress(Unity.XGamingRuntime.Interop.XPackageInstallationProgress interop)
	{
		this.interop = interop;
	}

	public XPackageInstallationProgress()
	{
		interop = default;
	}
}
