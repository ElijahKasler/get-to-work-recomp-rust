using Isto.Core.Enums;

namespace Isto.Core.Achievements;

public interface IAchievements
{
	public class CoreAchievementsEnum : Int32Enum<CoreAchievementsEnum>
	{
		public CoreAchievementsEnum(int value, string name)
			: base(value, name)
		{
		}
	}

	void Initialize();

	void Cleanup();

	void TriggerAchievement(CoreAchievementsEnum achievement);

	void RecordAchievementProgress(CoreAchievementsEnum achievement, int progress, float completionPercentage);

	void BeginBatchMode();

	void EndBatchMode();
}
