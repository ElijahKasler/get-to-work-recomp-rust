using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionMember
{
	public uint MemberId { get; }

	public string TeamId { get; }

	public string InitialTeam { get; }

	public XblTournamentArbitrationStatus ArbitrationStatus { get; }

	public ulong Xuid { get; }

	public string CustomConstantsJson { get; }

	public string SecureDeviceBaseAddress64 { get; }

	public XblMultiplayerSessionMemberRole[] Roles { get; }

	public string CustomPropertiesJson { get; }

	public string Gamertag { get; }

	public XblMultiplayerSessionMemberStatus Status { get; }

	public bool IsTurnAvailable { get; }

	public bool IsCurrentUser { get; }

	public bool InitializeRequested { get; }

	public string MatchmakingResultServerMeasurementsJson { get; }

	public string ServerMeasurementsJson { get; }

	public uint[] MembersInGroupIds { get; }

	public string QosMeasurementsJson { get; }

	public XblDeviceToken DeviceToken { get; }

	public XblNetworkAddressTranslationSetting Nat { get; }

	public uint ActiveTitleId { get; }

	public uint InitializationEpisode { get; }

	public DateTime JoinTime { get; }

	public XblMultiplayerMeasurementFailure InitializationFailureCause { get; }

	public string[] Groups { get; }

	public string[] Encounters { get; }

	public XblMultiplayerSessionReference TournamentTeamSessionReference { get; }

	internal Unity.XGamingRuntime.Interop.XblMultiplayerSessionMember InteropHandle { get; }

	internal XblMultiplayerSessionMember(Unity.XGamingRuntime.Interop.XblMultiplayerSessionMember interopHandle)
	{
		InteropHandle = interopHandle;
		MemberId = interopHandle.MemberId;
		TeamId = interopHandle.TeamId.GetString();
		InitialTeam = interopHandle.InitialTeam.GetString();
		ArbitrationStatus = interopHandle.ArbitrationStatus;
		Xuid = interopHandle.Xuid;
		CustomConstantsJson = interopHandle.CustomConstantsJson.GetString();
		SecureDeviceBaseAddress64 = interopHandle.SecureDeviceBaseAddress64.GetString();
		Roles = interopHandle.GetRoles((Unity.XGamingRuntime.Interop.XblMultiplayerSessionMemberRole r) => new XblMultiplayerSessionMemberRole(r));
		CustomPropertiesJson = interopHandle.CustomPropertiesJson.GetString();
		Gamertag = interopHandle.GetGamertag();
		Status = interopHandle.Status;
		IsTurnAvailable = interopHandle.IsTurnAvailable;
		IsCurrentUser = interopHandle.IsCurrentUser;
		InitializeRequested = interopHandle.InitializeRequested;
		MatchmakingResultServerMeasurementsJson = interopHandle.MatchmakingResultServerMeasurementsJson.GetString();
		ServerMeasurementsJson = interopHandle.ServerMeasurementsJson.GetString();
		MembersInGroupIds = interopHandle.GetMembersInGroupIds((uint x) => x);
		QosMeasurementsJson = interopHandle.QosMeasurementsJson.GetString();
		DeviceToken = new XblDeviceToken(interopHandle.DeviceToken);
		Nat = interopHandle.Nat;
		ActiveTitleId = interopHandle.ActiveTitleId;
		InitializationEpisode = interopHandle.InitializationEpisode;
		JoinTime = interopHandle.JoinTime.DateTime;
		InitializationFailureCause = interopHandle.InitializationFailureCause;
		Groups = interopHandle.GetGroups();
		Encounters = interopHandle.GetEncounters();
		TournamentTeamSessionReference = new XblMultiplayerSessionReference(interopHandle.TournamentTeamSessionReference);
	}
}
