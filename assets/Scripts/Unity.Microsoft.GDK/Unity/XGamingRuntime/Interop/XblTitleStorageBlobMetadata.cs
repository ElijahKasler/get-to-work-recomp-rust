using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XblTitleStorageBlobMetadata
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 771)]
	internal string blobPath;

	internal XblTitleStorageBlobType blobType;

	internal XblTitleStorageType storageType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 387)]
	internal string displayName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 54)]
	internal string eTag;

	internal TimeT clientTimestamp;

	internal SizeT length;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
	internal string serviceConfigurationId;

	internal ulong xboxUserId;
}
