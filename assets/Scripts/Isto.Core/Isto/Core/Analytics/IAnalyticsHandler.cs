using System.Collections.Generic;
using Isto.Core.Configuration;
using Isto.Core.Enums;
using UnityEngine;

namespace Isto.Core.Analytics;

public interface IAnalyticsHandler
{
	public class CoreAnalyticsEnum : Int32Enum<CoreAnalyticsEnum>
	{
		public static readonly CoreAnalyticsEnum TEST = new CoreAnalyticsEnum(0, "TEST");

		public static readonly CoreAnalyticsEnum GAME_START = new CoreAnalyticsEnum(1, "GAME_START");

		public static readonly CoreAnalyticsEnum THEME_CHANGE = new CoreAnalyticsEnum(2, "THEME_CHANGE");

		public static readonly CoreAnalyticsEnum MENU_PAGE_VISIT = new CoreAnalyticsEnum(3, "MENU_PAGE_VISIT");

		public static readonly CoreAnalyticsEnum GAME_MODE_SELECT = new CoreAnalyticsEnum(4, "GAME_MODE_SELECT");

		public static readonly CoreAnalyticsEnum GAME_PROGRESS = new CoreAnalyticsEnum(5, "GAME_PROGRESS");

		public static readonly CoreAnalyticsEnum UPGRADE_STEP_SKIP = new CoreAnalyticsEnum(6, "UPGRADE_STEP_SKIP");

		public static readonly CoreAnalyticsEnum DIALOGUE_SKIP = new CoreAnalyticsEnum(7, "DIALOGUE_SKIP");

		public static readonly CoreAnalyticsEnum CINEMATIC_SKIP = new CoreAnalyticsEnum(8, "CINEMATIC_SKIP");

		public static readonly CoreAnalyticsEnum DEVELOPER_CONSOLE_OPEN = new CoreAnalyticsEnum(9, "DEVELOPER_CONSOLE_OPEN");

		public static readonly CoreAnalyticsEnum CHEAT_ACTIVE = new CoreAnalyticsEnum(10, "CHEAT_ACTIVE");

		public static readonly CoreAnalyticsEnum SECRET_CHEAT_ACTIVE = new CoreAnalyticsEnum(11, "SECRET_CHEAT_ACTIVE");

		public static readonly CoreAnalyticsEnum PLAYER_DEATH = new CoreAnalyticsEnum(12, "PLAYER_DEATH");

		public static readonly CoreAnalyticsEnum RESEARCH_UNLOCK = new CoreAnalyticsEnum(13, "RESEARCH_UNLOCK");

		public static readonly CoreAnalyticsEnum RESEARCH_LEVEL_UP = new CoreAnalyticsEnum(14, "RESEARCH_LEVEL_UP");

		public static readonly CoreAnalyticsEnum PLACEHOLDER = new CoreAnalyticsEnum(15, "PLACEHOLDER");

		public static readonly CoreAnalyticsEnum TITLE_SCREEN_SUBMENU_OPEN = new CoreAnalyticsEnum(16, "TITLE_SCREEN_SUBMENU_OPEN");

		public static readonly CoreAnalyticsEnum SAVE_SLOT_SELECT = new CoreAnalyticsEnum(17, "SAVE_SLOT_SELECT");

		public static readonly CoreAnalyticsEnum BUILDING_INTERACT = new CoreAnalyticsEnum(18, "BUILDING_INTERACT");

		public static readonly CoreAnalyticsEnum EASTER_EGG_GET = new CoreAnalyticsEnum(19, "EASTER_EGG_GET");

		public CoreAnalyticsEnum(int value, string name)
			: base(value, name)
		{
		}
	}

	public enum AnalyticsEvent
	{
		Test = 0,
		GameStart = 1,
		ThemeChanged = 2,
		MenuPageVisited = 3,
		GameModeSelected = 4,
		GameLevelProgress = 5,
		UpgradeStepSkipped = 6,
		DialogueSkipped = 7,
		CinematicSkipped = 8,
		DeveloperConsoleOpened = 9,
		CheatActivated = 10,
		SecretCheatActivated = 11,
		PlayerDeath = 12,
		ResearchUnlocked = 13,
		ResearchCenterLevelUp = 14,
		CircuitJuiceUnlocked = 15,
		TitleScreenMenuVisited = 16,
		SaveSlotSelected = 17,
		BuildingInteracted = 18,
		EasterEggFound = 19
	}

	public class AnalyticsDataKeys
	{
		public static readonly string GAMESTART_BUILD_TYPE = "build_type";

		public static readonly string GAMESTART_BUILD_DATE = "build_date";

		public static readonly string GAMESTART_BUILD_DATE_DEFAULT = "2021-06-09";

		public static readonly string GAMESTART_BUILD_NUMBER = "build_number";

		public static readonly string GAMESTART_BUILD_NUMBER_FORMAT = "v{0}";

		public static readonly string GAMESTART_BUILD_NUMBER_DEFAULT = "0.0";

		public static readonly string THEMECHANGED_NAME = "internal_name";

		public static readonly string MENUPAGEVISIT_ID = "page_name";

		public static readonly string GAMEMODESELECTED_NAME = "internal_name";

		public static readonly string GAMEPROGRESS_LEVEL = "level_number";

		public static readonly string GAMEPROGRESS_FIRST_EVER = "first_ever";

		public static readonly string GAMEPROGRESS_LEVEL_TIME = "level_time";

		public static readonly string GAMEPROGRESS_TOTAL_GAME_TIME = "total_game_time";

		public static readonly string DIALOGUESKIP_LEVEL_NUMBER = "level_number";

		public static readonly string CHEATACTIVATED_NAME = "dev_action_name";

		public static readonly string CHEATACTIVATED_LEVEL_NUMBER = "level_number";

		public static readonly string CHEATACTIVATED_LEVEL_TIME = "level_time";

		public static readonly string CHEATACTIVATED_TOTAL_GAME_TIME = "total_game_time";

		public static readonly string SECRETCHEATACTIVATED_NAME = "cheat_name";

		public static readonly string PLAYERDEATH_AREA = "area";

		public static readonly string PLAYERDEATH_POS = "position";

		public static readonly string PLAYERDEATH_DAMAGE_SOURCE = "damage_source";

		public static readonly string PLAYERDEATH_LEVEL_NUMBER = "level_number";

		public static readonly string PLAYERDEATH_LEVEL_TIME = "level_time";

		public static readonly string PLAYERDEATH_TOTAL_GAME_TIME = "total_game_time";

		public static readonly string RESEARCHUNLOCKED_NAME = "research_name";

		public static readonly string RESEARCHUNLOCKED_LEVEL_NUMBER = "level_number";

		public static readonly string RESEARCHUNLOCKED_LEVEL_TIME = "level_time";

		public static readonly string RESEARCHUNLOCKED_TOTAL_GAME_TIME = "total_game_time";

		public static readonly string RESEARCHUPGRADED_LEVEL = "researchupgrade_level";

		public static readonly string RESEARCHUPGRADED_LEVEL_NUMBER = "level_number";

		public static readonly string RESEARCHUPGRADED_LEVEL_TIME = "level_time";

		public static readonly string RESEARCHUPGRADED_TOTAL_GAME_TIME = "total_game_time";
	}

	bool RegisterApplicationStarted();

	bool RegisterThemeChanged(string internalThemeName);

	bool RegisterMenuPageVisited(string uniqueMenuPageName);

	bool RegisterGameModeSelected(GameModeDefinition mode);

	bool RegisterGameProgress(int level, float gameSecondsSinceLastLevel, float gameSecondsSinceStart);

	bool RegisterDialogueSkipUsed();

	bool RegisterCinematicSkipUsed();

	bool RegisterPlayerDeath(string areaName, Vector3 pos, List<string> recentDamageSourceNames);

	bool RegisterResearchUnlocked(string researchName);

	bool RegisterResearchCenterLevelUp(int level);

	bool RegisterDeveloperConsoleOpened();

	bool RegisterSecretCheatActivated(string cheatName);

	bool RegisterCheatActivated(string cheatName);

	bool TriggerEvent(AnalyticsEvent e, Dictionary<string, object> data = null);
}
