using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblAchievementTimeWindow
{
	public DateTime StartDate { get; private set; }

	public DateTime EndDate { get; private set; }

	internal XblAchievementTimeWindow(Unity.XGamingRuntime.Interop.XblAchievementTimeWindow interopTimeWindow)
	{
		StartDate = interopTimeWindow.startDate.DateTime;
		EndDate = interopTimeWindow.endDate.DateTime;
	}
}
