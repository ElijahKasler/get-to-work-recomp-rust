using Isto.Core.Achievements;

namespace Isto.Core.Platforms.Xbox;

public class XboxAchievements : IAchievements
{
	private static readonly int ACHIEVEMENT_PROGRESS_COMPLETE = 0;

	private static readonly float ACHIEVEMENT_COMPLETION_FULL = 1f;

	private bool _batchMode;

	private string GetAchievementID(IAchievements.CoreAchievementsEnum achievement)
	{
		return achievement.Value.ToString();
	}

	public void TriggerAchievement(IAchievements.CoreAchievementsEnum achievement)
	{
		RecordAchievementProgress(achievement, ACHIEVEMENT_PROGRESS_COMPLETE, ACHIEVEMENT_COMPLETION_FULL);
	}

	public void RecordAchievementProgress(IAchievements.CoreAchievementsEnum achievement, int progress, float completionPercentage)
	{
	}

	public virtual void Initialize()
	{
	}

	public virtual void Cleanup()
	{
	}

	public void BeginBatchMode()
	{
		_batchMode = true;
	}

	public void EndBatchMode()
	{
		_batchMode = false;
	}
}
