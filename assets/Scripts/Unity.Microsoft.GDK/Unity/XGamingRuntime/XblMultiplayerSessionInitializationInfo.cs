using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerSessionInitializationInfo
{
	public XblMultiplayerInitializationStage Stage { get; }

	public DateTime StageStartTime { get; }

	public uint Episode { get; }

	internal XblMultiplayerSessionInitializationInfo(Unity.XGamingRuntime.Interop.XblMultiplayerSessionInitializationInfo interopHandle)
	{
		Stage = interopHandle.Stage;
		StageStartTime = interopHandle.StageStartTime.DateTime;
		Episode = interopHandle.Episode;
	}
}
