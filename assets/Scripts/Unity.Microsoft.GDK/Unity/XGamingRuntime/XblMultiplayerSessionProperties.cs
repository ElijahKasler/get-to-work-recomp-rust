using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionProperties
{
	public string[] Keywords { get; }

	public XblMultiplayerSessionRestriction JoinRestriction { get; }

	public XblMultiplayerSessionRestriction ReadRestriction { get; }

	public uint[] TurnCollection { get; }

	public string MatchmakingTargetSessionConstantsJson { get; }

	public string SessionCustomPropertiesJson { get; }

	public string MatchmakingServerConnectionString { get; }

	public string[] ServerConnectionStringCandidates { get; }

	public uint[] SessionOwnerMemberIds { get; }

	public XblDeviceToken HostDeviceToken { get; }

	public bool Closed { get; }

	public bool Locked { get; }

	public bool AllocateCloudCompute { get; }

	public bool MatchmakingResubmit { get; }

	internal Unity.XGamingRuntime.Interop.XblMultiplayerSessionProperties InteropHandle { get; }

	internal XblMultiplayerSessionProperties(Unity.XGamingRuntime.Interop.XblMultiplayerSessionProperties interopHandle)
	{
		InteropHandle = interopHandle;
		Keywords = interopHandle.GetKeywords();
		JoinRestriction = interopHandle.JoinRestriction;
		ReadRestriction = interopHandle.ReadRestriction;
		TurnCollection = interopHandle.GetTurnCollection((uint x) => x);
		MatchmakingTargetSessionConstantsJson = interopHandle.MatchmakingTargetSessionConstantsJson.GetString();
		SessionCustomPropertiesJson = interopHandle.SessionCustomPropertiesJson.GetString();
		MatchmakingServerConnectionString = interopHandle.MatchmakingServerConnectionString.GetString();
		ServerConnectionStringCandidates = interopHandle.GetServerConnectionStringCandidates();
		SessionOwnerMemberIds = interopHandle.GetSessionOwnerMemberIds((uint x) => x);
		HostDeviceToken = new XblDeviceToken(interopHandle.HostDeviceToken);
		Closed = interopHandle.Closed;
		Locked = interopHandle.Locked;
		AllocateCloudCompute = interopHandle.AllocateCloudCompute;
		MatchmakingResubmit = interopHandle.MatchmakingResubmit;
	}
}
