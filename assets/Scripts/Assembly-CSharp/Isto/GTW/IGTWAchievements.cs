using Isto.Core.Achievements;

namespace Isto.GTW;

public interface IGTWAchievements : IAchievements
{
	public class GTWAchievementsEnum : CoreAchievementsEnum
	{
		public static readonly GTWAchievementsEnum PARTICIPATION = new GTWAchievementsEnum(1, "PARTICIPATION");

		public static readonly GTWAchievementsEnum GET_TO_WORK = new GTWAchievementsEnum(2, "GET_TO_WORK");

		public static readonly GTWAchievementsEnum RICHEST_MAN = new GTWAchievementsEnum(3, "RICHEST_MAN");

		public static readonly GTWAchievementsEnum DUNCE_1 = new GTWAchievementsEnum(4, "DUNCE_1");

		public static readonly GTWAchievementsEnum DUNCE_2 = new GTWAchievementsEnum(5, "DUNCE_2");

		public static readonly GTWAchievementsEnum PLEASE = new GTWAchievementsEnum(6, "PLEASE");

		public static readonly GTWAchievementsEnum HANDSHAKE = new GTWAchievementsEnum(7, "HANDSHAKE");

		public static readonly GTWAchievementsEnum GRINDSET_1 = new GTWAchievementsEnum(8, "GRINDSET_1");

		public static readonly GTWAchievementsEnum GRINDSET_2 = new GTWAchievementsEnum(9, "GRINDSET_2");

		public static readonly GTWAchievementsEnum GRINDSET_3 = new GTWAchievementsEnum(10, "GRINDSET_3");

		public static readonly GTWAchievementsEnum SPEEDRUNNER_1 = new GTWAchievementsEnum(11, "SPEEDRUNNER_1");

		public static readonly GTWAchievementsEnum SPEEDRUNNER_2 = new GTWAchievementsEnum(12, "SPEEDRUNNER_2");

		public static readonly GTWAchievementsEnum SPEEDRUNNER_3 = new GTWAchievementsEnum(13, "SPEEDRUNNER_3");

		public static readonly GTWAchievementsEnum WAIT_SERIOUSLY = new GTWAchievementsEnum(14, "WAIT_SERIOUSLY");

		public static readonly GTWAchievementsEnum QUITTER = new GTWAchievementsEnum(15, "QUITTER");

		public static readonly GTWAchievementsEnum REAL_QUITTER = new GTWAchievementsEnum(16, "REAL_QUITTER");

		public static readonly GTWAchievementsEnum DOINKLER_PORTFOLIO = new GTWAchievementsEnum(17, "DOINKLER_PORTFOLIO");

		public static readonly GTWAchievementsEnum DOINKLER_SPECIAL = new GTWAchievementsEnum(18, "DOINKLER_SPECIAL");

		public GTWAchievementsEnum(int value, string name)
			: base(value, name)
		{
		}
	}

	static readonly int GRINDSET_1_COUNT;

	static readonly int GRINDSET_2_COUNT;

	static readonly float SPEEDRUNNER_1_TIME;

	static readonly float SPEEDRUNNER_2_TIME;

	static readonly float SPEEDRUNNER_3_TIME;

	static readonly float WAIT_SERIOUSLY_TIME;

	static readonly float REAL_QUITTER_TIME;

	static IGTWAchievements()
	{
		GRINDSET_1_COUNT = 5;
		GRINDSET_2_COUNT = 10;
		SPEEDRUNNER_1_TIME = 7200f;
		SPEEDRUNNER_2_TIME = 3600f;
		SPEEDRUNNER_3_TIME = 2700f;
		WAIT_SERIOUSLY_TIME = 1800f;
		REAL_QUITTER_TIME = 60f;
	}
}
