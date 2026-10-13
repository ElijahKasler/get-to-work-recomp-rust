using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblTitleStorageBlobMetadata
{
	internal Unity.XGamingRuntime.Interop.XblTitleStorageBlobMetadata interop;

	public string BlobPath
	{
		get
		{
			return interop.blobPath;
		}
		set
		{
			interop.blobPath = value;
		}
	}

	public XblTitleStorageBlobType BlobType
	{
		get
		{
			return interop.blobType;
		}
		set
		{
			interop.blobType = value;
		}
	}

	public XblTitleStorageType StorageType
	{
		get
		{
			return interop.storageType;
		}
		set
		{
			interop.storageType = value;
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

	public string ETag
	{
		get
		{
			return interop.eTag;
		}
		set
		{
			interop.eTag = value;
		}
	}

	public DateTime ClientTimestamp
	{
		get
		{
			return interop.clientTimestamp.DateTime;
		}
		set
		{
			interop.clientTimestamp = new TimeT(value);
		}
	}

	public ulong Length
	{
		get
		{
			return interop.length.ToUInt64();
		}
		set
		{
			interop.length = new SizeT(value);
		}
	}

	public string ServiceConfigurationId
	{
		get
		{
			return interop.serviceConfigurationId;
		}
		set
		{
			interop.serviceConfigurationId = value;
		}
	}

	public ulong XboxUserId
	{
		get
		{
			return interop.xboxUserId;
		}
		set
		{
			interop.xboxUserId = value;
		}
	}

	internal XblTitleStorageBlobMetadata(Unity.XGamingRuntime.Interop.XblTitleStorageBlobMetadata interopHandle)
	{
		interop = interopHandle;
	}

	public XblTitleStorageBlobMetadata()
	{
		interop = default;
	}
}
