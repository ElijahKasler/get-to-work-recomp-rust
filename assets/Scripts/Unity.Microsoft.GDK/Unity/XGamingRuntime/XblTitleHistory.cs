using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblTitleHistory
{
	public bool HasUserPlayed { get; private set; }

	public DateTime LastTimeUserPlayed { get; private set; }

	internal XblTitleHistory(Unity.XGamingRuntime.Interop.XblTitleHistory interopTitleHistory)
	{
		HasUserPlayed = interopTitleHistory.hasUserPlayed;
		LastTimeUserPlayed = interopTitleHistory.lastTimeUserPlayed.DateTime;
	}
}
