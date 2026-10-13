using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerSessionProperties
{
	internal readonly IntPtr Keywords;

	internal readonly SizeT KeywordCount;

	internal XblMultiplayerSessionRestriction JoinRestriction;

	internal XblMultiplayerSessionRestriction ReadRestriction;

	private readonly IntPtr TurnCollection;

	private readonly SizeT TurnCollectionCount;

	internal readonly UTF8StringPtr MatchmakingTargetSessionConstantsJson;

	internal readonly UTF8StringPtr SessionCustomPropertiesJson;

	internal readonly UTF8StringPtr MatchmakingServerConnectionString;

	private readonly IntPtr ServerConnectionStringCandidates;

	private readonly SizeT ServerConnectionStringCandidatesCount;

	private readonly IntPtr SessionOwnerMemberIds;

	private readonly SizeT SessionOwnerMemberIdsCount;

	internal readonly XblDeviceToken HostDeviceToken;

	[MarshalAs(UnmanagedType.U1)]
	internal bool Closed;

	[MarshalAs(UnmanagedType.U1)]
	internal bool Locked;

	[MarshalAs(UnmanagedType.U1)]
	internal bool AllocateCloudCompute;

	[MarshalAs(UnmanagedType.U1)]
	internal bool MatchmakingResubmit;

	internal string[] GetKeywords()
	{
		return Converters.PtrToClassArray(Keywords, KeywordCount, (UTF8StringPtr s) => s.GetString());
	}

	internal T[] GetTurnCollection<T>(Func<uint, T> ctor)
	{
		return Converters.PtrToClassArray(TurnCollection, TurnCollectionCount, ctor);
	}

	internal string[] GetServerConnectionStringCandidates()
	{
		return Converters.PtrToClassArray(ServerConnectionStringCandidates, ServerConnectionStringCandidatesCount, (UTF8StringPtr s) => s.GetString());
	}

	internal T[] GetSessionOwnerMemberIds<T>(Func<uint, T> ctor)
	{
		return Converters.PtrToClassArray(SessionOwnerMemberIds, SessionOwnerMemberIdsCount, ctor);
	}
}
