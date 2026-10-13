using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblAchievementProgressChangeEntry
{
	public string AchievementId { get; }

	public XblAchievementProgressState ProgressState { get; }

	public XblAchievementProgression Progression { get; }

	internal XblAchievementProgressChangeEntry(Unity.XGamingRuntime.Interop.XblAchievementProgressChangeEntry interopStruct)
	{
		AchievementId = interopStruct.achievementId.GetString();
		ProgressState = interopStruct.progressState;
		Progression = new XblAchievementProgression(interopStruct.progression);
	}
}
