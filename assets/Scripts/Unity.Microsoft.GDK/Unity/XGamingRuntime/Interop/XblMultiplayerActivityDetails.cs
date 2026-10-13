using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerActivityDetails
{
	internal XblMultiplayerSessionReference SessionReference;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	internal byte[] HandleId;

	internal uint TitleId;

	internal XblMultiplayerSessionVisibility Visibility;

	internal XblMultiplayerSessionRestriction JoinRestriction;

	[MarshalAs(UnmanagedType.U1)]
	internal bool Closed;

	internal ulong OwnerXuid;

	internal uint MaxMembersCount;

	internal uint MembersCount;

	internal UTF8StringPtr CustomSessionPropertiesJson;

	internal unsafe string GetHandleId()
	{
		fixed (byte* handleId = HandleId)
		{
			return Converters.BytePointerToString(handleId, 40);
		}
	}
}
