using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblAchievementProgression
{
	public XblAchievementRequirement[] Requirements { get; private set; }

	public DateTime TimeUnlocked { get; private set; }

	internal XblAchievementProgression(Unity.XGamingRuntime.Interop.XblAchievementProgression interopProgression)
	{
		Requirements = interopProgression.GetRequirements((Unity.XGamingRuntime.Interop.XblAchievementRequirement r) => new XblAchievementRequirement(r));
		TimeUnlocked = interopProgression.timeUnlocked.DateTime;
	}
}
