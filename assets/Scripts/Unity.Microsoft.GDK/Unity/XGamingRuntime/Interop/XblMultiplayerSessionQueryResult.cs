using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerSessionQueryResult
{
	internal TimeT StartTime;

	internal XblMultiplayerSessionReference SessionReference;

	internal XblMultiplayerSessionStatus Status;

	internal XblMultiplayerSessionVisibility Visibility;

	[MarshalAs(UnmanagedType.U1)]
	internal bool IsMyTurn;

	internal ulong Xuid;

	internal uint AcceptedMemberCount;

	internal XblMultiplayerSessionRestriction JoinRestriction;
}
