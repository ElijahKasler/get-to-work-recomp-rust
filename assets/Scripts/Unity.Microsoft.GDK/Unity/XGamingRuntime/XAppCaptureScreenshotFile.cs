using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XAppCaptureScreenshotFile
{
	internal Unity.XGamingRuntime.Interop.XAppCaptureScreenshotFile interop;

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

	internal XAppCaptureScreenshotFile(Unity.XGamingRuntime.Interop.XAppCaptureScreenshotFile interop)
	{
		this.interop = interop;
	}

	internal XAppCaptureScreenshotFile()
	{
		interop = default;
	}
}
