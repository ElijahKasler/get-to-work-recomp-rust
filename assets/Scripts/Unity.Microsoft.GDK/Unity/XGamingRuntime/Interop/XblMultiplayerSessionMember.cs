using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal struct XblMultiplayerSessionMember
{
	internal uint MemberId;

	internal UTF8StringPtr TeamId;

	internal UTF8StringPtr InitialTeam;

	internal XblTournamentArbitrationStatus ArbitrationStatus;

	internal ulong Xuid;

	internal UTF8StringPtr CustomConstantsJson;

	internal UTF8StringPtr SecureDeviceBaseAddress64;

	private readonly IntPtr Roles;

	private readonly SizeT RolesCount;

	internal UTF8StringPtr CustomPropertiesJson;

	private unsafe fixed byte Gamertag[48];

	internal XblMultiplayerSessionMemberStatus Status;

	[MarshalAs(UnmanagedType.U1)]
	internal bool IsTurnAvailable;

	[MarshalAs(UnmanagedType.U1)]
	internal bool IsCurrentUser;

	[MarshalAs(UnmanagedType.U1)]
	internal bool InitializeRequested;

	internal UTF8StringPtr MatchmakingResultServerMeasurementsJson;

	internal UTF8StringPtr ServerMeasurementsJson;

	private readonly IntPtr MembersInGroupIds;

	private readonly SizeT MembersInGroupCount;

	internal UTF8StringPtr QosMeasurementsJson;

	internal XblDeviceToken DeviceToken;

	internal XblNetworkAddressTranslationSetting Nat;

	internal uint ActiveTitleId;

	internal uint InitializationEpisode;

	internal TimeT JoinTime;

	internal XblMultiplayerMeasurementFailure InitializationFailureCause;

	private readonly IntPtr Groups;

	private readonly SizeT GroupsCount;

	private readonly IntPtr Encounters;

	private readonly SizeT EncountersCount;

	internal XblMultiplayerSessionReference TournamentTeamSessionReference;

	internal readonly IntPtr Internal;

	internal unsafe string GetGamertag()
	{
		fixed (byte* gamertag = Gamertag)
		{
			return Converters.BytePointerToString(gamertag, 97);
		}
	}

	internal T[] GetRoles<T>(Func<XblMultiplayerSessionMemberRole, T> ctor)
	{
		return Converters.PtrToClassArray(Roles, RolesCount, ctor);
	}

	internal T[] GetMembersInGroupIds<T>(Func<uint, T> ctor)
	{
		return Converters.PtrToClassArray(MembersInGroupIds, MembersInGroupCount, ctor);
	}

	internal string[] GetGroups()
	{
		return Converters.PtrToClassArray(Groups, GroupsCount, (UTF8StringPtr s) => s.GetString());
	}

	internal string[] GetEncounters()
	{
		return Converters.PtrToClassArray(Encounters, EncountersCount, (UTF8StringPtr s) => s.GetString());
	}
}
