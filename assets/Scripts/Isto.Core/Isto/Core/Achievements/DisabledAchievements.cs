using UnityEngine;

namespace Isto.Core.Achievements;

public class DisabledAchievements : IAchievements
{
	public void TriggerAchievement(IAchievements.CoreAchievementsEnum achievement)
	{
		Debug.Log($"Achievement {achievement} was triggered but achievements are disabled.");
	}

	public void RecordAchievementProgress(IAchievements.CoreAchievementsEnum achievement, int progress, float completionPercentage)
	{
		Debug.Log($"Achievement {achievement} progressed for amount={progress} was set to completion={completionPercentage} but achievements are disabled.");
	}

	public void Initialize()
	{
	}

	public void Cleanup()
	{
	}

	public void BeginBatchMode()
	{
	}

	public void EndBatchMode()
	{
	}
}
