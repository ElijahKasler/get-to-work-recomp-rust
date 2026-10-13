using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XPersistentLocalStorageSpaceInfo
{
	internal Unity.XGamingRuntime.Interop.XPersistentLocalStorageSpaceInfo interop;

	public ulong AvailableFreeBytes
	{
		get
		{
			return interop.availableFreeBytes;
		}
		set
		{
			interop.availableFreeBytes = value;
		}
	}

	public ulong TotalFreeBytes
	{
		get
		{
			return interop.totalFreeBytes;
		}
		set
		{
			interop.totalFreeBytes = value;
		}
	}

	public ulong UsedBytes
	{
		get
		{
			return interop.usedBytes;
		}
		set
		{
			interop.usedBytes = value;
		}
	}

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

	internal XPersistentLocalStorageSpaceInfo(Unity.XGamingRuntime.Interop.XPersistentLocalStorageSpaceInfo interop)
	{
		this.interop = interop;
	}

	public XPersistentLocalStorageSpaceInfo()
	{
		interop = default;
	}
}
