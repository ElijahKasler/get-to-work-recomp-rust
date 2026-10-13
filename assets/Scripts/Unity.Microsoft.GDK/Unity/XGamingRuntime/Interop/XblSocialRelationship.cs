using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XblSocialRelationship
{
	internal readonly ulong xboxUserId;

	[MarshalAs(UnmanagedType.U1)]
	internal readonly bool isFavorite;

	[MarshalAs(UnmanagedType.U1)]
	internal readonly bool isFollowingCaller;

	internal readonly IntPtr socialNetworks;

	internal readonly SizeT socialNetworksCount;

	internal string[] GetSocialNetworks()
	{
		return Converters.PtrToClassArray(socialNetworks, socialNetworksCount, (UTF8StringPtr s) => s.GetString());
	}
}
