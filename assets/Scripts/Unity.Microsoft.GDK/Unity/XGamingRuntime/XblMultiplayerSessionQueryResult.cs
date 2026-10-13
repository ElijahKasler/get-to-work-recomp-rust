using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionQueryResult
{
	public DateTime StartTime { get; }

	public XblMultiplayerSessionReference SessionReference { get; }

	public XblMultiplayerSessionStatus Status { get; }

	public XblMultiplayerSessionVisibility Visibility { get; }

	public bool IsMyTurn { get; }

	public ulong Xuid { get; }

	public uint AcceptedMemberCount { get; }

	public XblMultiplayerSessionRestriction JoinRestriction { get; }

	internal XblMultiplayerSessionQueryResult(Unity.XGamingRuntime.Interop.XblMultiplayerSessionQueryResult interopHandle)
	{
		StartTime = interopHandle.StartTime.DateTime;
		SessionReference = new XblMultiplayerSessionReference(interopHandle.SessionReference);
		Status = interopHandle.Status;
		Visibility = interopHandle.Visibility;
		IsMyTurn = interopHandle.IsMyTurn;
		Xuid = interopHandle.Xuid;
		AcceptedMemberCount = interopHandle.AcceptedMemberCount;
		JoinRestriction = interopHandle.JoinRestriction;
	}
}
