using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerActivityDetails
{
	public XblMultiplayerSessionReference SessionReference { get; }

	public string HandleId { get; }

	public uint TitleId { get; }

	public XblMultiplayerSessionVisibility Visibility { get; }

	public XblMultiplayerSessionRestriction JoinRestriction { get; }

	public bool Closed { get; }

	public ulong OwnerXuid { get; }

	public uint MaxMembersCount { get; }

	public uint MembersCount { get; }

	public string CustomSessionPropertiesJson { get; }

	internal XblMultiplayerActivityDetails(Unity.XGamingRuntime.Interop.XblMultiplayerActivityDetails interopHandle)
	{
		SessionReference = new XblMultiplayerSessionReference(interopHandle.SessionReference);
		HandleId = interopHandle.GetHandleId();
		TitleId = interopHandle.TitleId;
		Visibility = interopHandle.Visibility;
		JoinRestriction = interopHandle.JoinRestriction;
		Closed = interopHandle.Closed;
		OwnerXuid = interopHandle.OwnerXuid;
		MaxMembersCount = interopHandle.MaxMembersCount;
		MembersCount = interopHandle.MembersCount;
		CustomSessionPropertiesJson = interopHandle.CustomSessionPropertiesJson.GetString();
	}
}
