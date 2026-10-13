using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XGameSaveContainerInfo
{
	internal Unity.XGamingRuntime.Interop.XGameSaveContainerInfo interop;

	public string Name
	{
		get
		{
			return interop.name;
		}
		set
		{
			interop.name = value;
		}
	}

	public string DisplayName
	{
		get
		{
			return interop.displayName;
		}
		set
		{
			interop.displayName = value;
		}
	}

	public uint BlobCount
	{
		get
		{
			return interop.blobCount;
		}
		set
		{
			interop.blobCount = value;
		}
	}

	public ulong TotalSize
	{
		get
		{
			return interop.totalSize;
		}
		set
		{
			interop.totalSize = value;
		}
	}

	public long LastModifiedTime
	{
		get
		{
			return interop.lastModifiedTime;
		}
		set
		{
			interop.lastModifiedTime = value;
		}
	}

	public bool NeedsSync
	{
		get
		{
			return interop.needsSync;
		}
		set
		{
			interop.needsSync = value;
		}
	}

	internal XGameSaveContainerInfo(Unity.XGamingRuntime.Interop.XGameSaveContainerInfo interop)
	{
		this.interop = interop;
	}

	public XGameSaveContainerInfo()
	{
		interop = default;
	}
}
