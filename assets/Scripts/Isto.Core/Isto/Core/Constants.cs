using UnityEngine;

namespace Isto.Core;

public static class Constants
{
	public const float SECONDS_PER_HOUR = 3600f;

	public const float FIVE_HOURS_IN_SECONDS = 18000f;

	public const float SIX_HOURS_IN_SECONDS = 21600f;

	public const float FIFTEEN_HOURS_IN_SECONDS = 54000f;

	public static readonly Vector3 FORWARD = new Vector3(-1f, 0f, 1f);

	public static readonly Vector3 RIGHT = new Vector3(0.5f, 0f, 0.5f);

	public static readonly Vector3 UP = new Vector3(0f, 1f, 0f);

	public static readonly Vector3 BACKLEFT = Vector3.back + Vector3.left;

	public static readonly Vector3 BACKRIGHT = Vector3.back + Vector3.right;

	public static readonly Vector3 FRONTLEFT = Vector3.forward + Vector3.left;

	public static readonly Vector3 FRONTRIGHT = Vector3.forward + Vector3.right;

	public static readonly Vector3 BACKLEFT_NORMALIZED = BACKLEFT.normalized;

	public static readonly Vector3 BACKRIGHT_NORMALIZED = BACKRIGHT.normalized;

	public static readonly Vector3 FRONTLEFT_NORMALIZED = FRONTLEFT.normalized;

	public static readonly Vector3 FRONTRIGHT_NORMALIZED = FRONTRIGHT.normalized;

	public static readonly Vector3 AUTOMATION_TO_WORLD_OFFSET = new Vector3(-0.5f, 0f, 0.5f);

	public static readonly Vector3 WORLD_TO_AUTOMATION_OFFSET = new Vector3(0.5f, 0f, -0.5f);

	public static readonly Vector3 GRID_CENTERING_OFFSET = new Vector3(-0.5f, 0f, 0.5f);

	public static readonly Vector3 PLAYER_MOUSE_CENTERING_OFFEST = new Vector3(0.75f, 0f, -0.75f);

	public static readonly Vector3 CAMERA_FORWARD = new Vector3(-0.6f, -0.5f, 0.6f);

	public static readonly int INITIAL_EMPLOYEE_NUMBER = 3123;

	public static readonly string LOC_PARAM_TOKEN_SPLITTER = ":";

	public static readonly string INSERT_TOKEN_ACTION_NAME = "ACT";

	public static readonly string INSERT_TOKEN_ACTION_ICON = "AICO";

	public static readonly string TOKEN_PARAM_KEYBOARD = "KB";

	public static readonly string TOKEN_PARAM_JOYSTICK = "JO";

	public static readonly string INSERT_TOKEN_TOTALPLAYTIME = "PLAYTIME";

	public static readonly string INSERT_TOKEN_DEATHCOUNT = "DEATHQTY";

	public static readonly string LOCALIZATION_KEY_NOT_FOUND = "LOCALIZATION KEY NOT SET";

	public static readonly string MAIN_FONT = "Font/Default";

	public static readonly string SECONDS_PREFIX = "Units/Seconds/Prefix";

	public static readonly string SECONDS_SUFFIX = "Units/Seconds/Suffix";

	public static readonly string MINUTES_PREFIX = "Units/Minutes/Prefix";

	public static readonly string MINUTES_SUFFIX = "Units/Minutes/Suffix";

	public static readonly string DIALOGUE_ACTOR_KEY_ROOT = "Dialogue System/Actor/";

	public static readonly string DIALOGUE_ACTOR_KEY_SUFFIX = "/Name";

	public static readonly string MONTH_NAME_KEY_ROOT = "Units/Months/";

	public static readonly string GAMEMODE_ERROR = "GameModes/Error/Name";

	public static readonly string HEARTBOX_DIALOGUE_SKIP = "HeartBoxButtons/SkipDialogue/Title";

	public static readonly string TOOLTIP_DISMANTLING = "ItemInteraction/Dismantle";

	public static readonly string TOOLTIP_INSTRUCTIONS = "ItemInteraction/Instructions";

	public static readonly string USER_ACTION_DISMANTLE = "ItemInteraction/Dismantle";

	public static readonly string USER_ACTION_OREHARVEST = "ItemInteraction/OreHarvest";

	public static readonly string USER_ACTION_ORGANICHARVEST = "ItemInteraction/OrganicHarvest";

	public static readonly string USER_ACTION_COLLECT = "ItemInteraction/Collect";

	public static readonly string USER_ACTION_PICKUP = "ItemInteraction/Pickup";

	public static readonly string USER_ACTION_REMOVE = "ItemInteraction/Remove";

	public static readonly string USER_ACTION_PLACE = "ItemInteractions/Place";

	public static readonly string USER_ACTION_CANCEL = "ItemInteractions/Cancel";

	public static readonly string USER_ACTION_ROTATE = "ItemInteractions/Rotate";

	public static readonly string USER_ACTION_OPEN = "ItemInteractions/Open";

	public static readonly string USER_ACTION_CLOSE = "ItemInteractions/Close";

	public static readonly string USER_ACTION_DROP = "ItemInteractions/Drop";

	public static readonly string USER_ACTION_SETRECIPE = "ItemInteractions/SetRecipe";

	public static readonly string USER_ACTION_ADDSEED = "ItemInteractions/AddSeed";

	public static readonly string USER_ACTION_CAPTURE = "ItemInteractions/Capture";

	public static readonly string USER_ACTION_SPAWN = "ItemInteractions/Spawn";

	public static readonly string USER_ACTION_HIDESSHOWUI = "ItemInteractions/HideShowUI";

	public static readonly string USER_ACTION_REQUIRES_X = "ItemInteractions/Requires";

	public static readonly string USER_ACTION_PET = "ItemInteractions/Pet";

	public static readonly string BUILDING_NAME_AUTOMATIONMODULE = "Buildings/AutomationModule/Name";

	public static readonly string BUILDING_NAME_FUELDEPOT = "Buildings/FuelDepot/Name";

	public static readonly string BUILDING_NAME_ITEMFINDER = "Buildings/ItemFinder/Name";

	public static readonly string BUILDING_NAME_RESEARCHMODULE = "Buildings/ResearchModule/Name";

	public static readonly string BUILDING_NAME_HEARTBOX = "Buildings/HeartBox/Name";

	public static readonly string BUILDING_NAME_PUNKMONK = "Buildings/PunkMonk/Name";

	public static readonly string BUILDING_NAME_IRISSTATION = "Dialogue System/Actor/IrisStation/Name";

	public static readonly string BUILDING_NAME_BULBMAN = "Dialogue System/Actor/BulbMan/Name";

	public static readonly string BUILDING_NAME_DEERSTATION = "Dialogue System/Actor/DeerStation/Name";

	public static readonly string ITEM_NAME_RESEARCHBOOSTER = "Items/ResearchBooster/Name";

	public static readonly string ITEM_NAME_BACKPACK = "Items/Backpack/Name";

	public static readonly string UI_TURRET_FUELNEEDED = "UI/Settings/Off";

	public static readonly string UI_TURRET_ON = "UI/Settings/On";

	public static readonly string UI_EMPLOYEENUMBER = "Cutscene/EmployeeNb";

	public static readonly string SAVE_OUT_OF_DATE_SUFFIX = "UI/SaveLoad/SaveOutOfDate";

	public static readonly string UNCHANGEABLE_MAPPING_SUFFIX = "UI/Settings/KeyMappings/Fixed";

	public static readonly string UI_SETTINGS_MESSAGE_RESET_CURRENT_PAGE = "Settings/Message/ResetCurrentPage";

	public static readonly string UI_SETTINGS_MESSAGE_RESET_ALL_SETTINGS = "Settings/Message/ResetAllSettings";

	public static readonly string UI_SETTINGS_MESSAGE_SAVE_SETTINGS = "Settings/Message/SaveSettingChanges";

	public static readonly string UI_SETTINGS_MESSAGE_KEEP_SETTINGS = "Settings/Message/KeepSettingChanges";

	public static readonly float BUTTON_SPAM_DELAY = 0.1f;

	public static readonly float BUTTON_HOLD_TIME = 0.19f;

	public static readonly float CANVAS_FADE_TIME = 0.15f;

	public static readonly float CANVAS_FADE_TIME_SLOW = 0.5f;

	public static readonly float CANVAS_FADE_TIME_VERY_SLOW = 1.5f;

	public static readonly float DEFAULT_PLAYER_MESSAGE_DISPLAY_TIME = 0.75f;

	public static readonly float DEFAULT_INFO_MESSAGE_DISPLAY_TIME = 2.25f;

	public static readonly float DEFAULT_INFO_MESSAGE_LONG_DISPLAY_TIME = 6f;

	public static readonly float SCROLLING_TEXT_SPEED = 40f;

	public static readonly float SCROLLING_TEXT_WAIT_TIME = 1f;

	public static readonly float DEFAULT_CAMERA_MOVE_TIME = 0.1f;

	public static readonly string IN_GAME_AUDIO_SNAPSHOT_ID = "InGameAudioSnapshot";

	public static readonly string IN_GAME_MENU_AUDIO_SNAPSHOT_ID = "InGameMenuAudioSnapshot";

	public static readonly float CAMERA_VIEW_AREA = 40f;

	public static readonly float CAMERA_HALF_VIEW_AREA = 20f;

	public static readonly float DAY_CYCLE_TRANSITION_TIME = 5f;

	public static readonly Vector3 HARVEST_BEAM_ALIGN_RIGHT = new Vector3(1.3f, 0f, 1.2f);

	public static readonly Vector3 HARVEST_BEAM_ALIGN_LEFT = new Vector3(-1.2f, 0f, -1.3f);

	public static readonly float PLAYER_HARVEST_LOADUP_TIME = 0.1f;

	public static readonly Vector3 ITEM_PICKUP_ALIGN_RIGHT = new Vector3(1f, 0f, 1f);

	public static readonly Vector3 ITEM_PICKUP_ALIGN_LEFT = new Vector3(-1f, 0f, -1f);

	public static readonly float DAMAGE_COOLDOWN_TIME = 0.25f;

	public static readonly float BACKPACK_DROP_MAX_DISTANCE = 10f;

	public static readonly float BACKGROUND_ALPHA_NORMAL = 0.3f;

	public static readonly float BACKGROUND_ALPHA_SELECTED = 0.5f;

	public static readonly float BACKGROUND_ALPHA_PRESSED = 0.15f;

	public static readonly Color NOT_ENOUGH_ITEMS_COLOR = Color.red;

	public static readonly Color ATRIO_PINK_LIGHT = new Color(253f / 255f, 148f / 255f, 148f / 255f);

	public static readonly Color ATRIO_DARK_PINK = new Color(0.15094f, 0.0975f, 0.0975f);

	public static readonly Color ATRIO_RED = new Color(0.749f, 0.333f, 0.412f);

	public static readonly Color ATRIO_BEIGE = new Color(247f / 255f, 243f / 255f, 207f / 255f);

	public static readonly Color ATRIO_DISABLED_GREY1 = new Color(0.227f, 0.227f, 0.227f);

	public static readonly Color ATRIO_DISABLED_GREY2 = new Color(0.26f, 0.26f, 0.26f);

	public static readonly Color ATRIO_DISABLED_GREY3 = new Color(0.38f, 0.38f, 0.38f);

	public static readonly Color ATRIO_NORMAL_TEXT_WHITE = Color.white;

	public static readonly Color ATRIO_GREY_TEXT = new Color(0.333f, 0.333f, 0.333f);

	public static readonly Color ATRIO_LIGHT_GREY_TEXT = new Color32(204, 204, 204, byte.MaxValue);

	public static readonly Color ATRIO_SELECTED_YELLOW = new Color(1f, 0.863f, 0.18f);

	public static readonly Color ATRIO_TITLESCREEN_YELLOW = new Color32(237, 216, 162, byte.MaxValue);

	public static readonly Color ATRIO_GREEN_TEXT = new Color(0.49f, 0.729f, 0.337f);

	public static readonly Color ATRIO_DIALOGUE_DEFAULT_BLUE = new Color32(69, 117, byte.MaxValue, byte.MaxValue);

	public static readonly Color ATRIO_DIALOGUE_NORMAL_BLUE = new Color32(102, 174, byte.MaxValue, byte.MaxValue);

	public static readonly Color ATRIO_DIALOGUE_PRESSED_BLUE = new Color32(0, 120, byte.MaxValue, byte.MaxValue);

	public static readonly Color ATRIO_WARNING = new Color(0.72f, 0.67f, 0.06f);

	public static readonly Color ATRIO_SUCCESS = new Color(0.49f, 0.729f, 0.337f);

	public static readonly Color ATRIO_ERROR = new Color(0.95f, 0.15f, 0.2f);

	public static readonly Color ATRIO_RESEARCHLINE_LOCKED = new Color32(38, 22, 24, byte.MaxValue);

	public static readonly Color ATRIO_RESEARCHLINE_UNLOCKED = new Color32(186, 49, 60, byte.MaxValue);

	public static readonly Color ATRIO_UI_BACKGROUND_GRAY = new Color32(26, 26, 26, byte.MaxValue);

	public static readonly string STORYFAST = "TEST-FAST";

	public static readonly string HEARTBOXANDROID1 = "01-02-UsePickerPal";

	public static readonly string EMPLOYEEORIENTATION0 = "00-ServilityTest";

	public static readonly string PUNKMONKINTRO = "01-PunkMonk-1";

	public static readonly string PUNKMONKBATTERY = "01-PunkMonk-2";

	public static readonly char DEFINES_SPLIT_TOKEN = ';';

	public static readonly string PLATFORM_STEAM_DEFINE = "PLATFORM_STEAM";

	public static readonly string CONTROLLER_INPUT_BLOCKED_DEFINE = "NO_CONTROLLER_SUPPORT";

	public static readonly string CONTROLLER_INPUT_FORCED_DEFINE = "NO_MOUSE_SUPPORT";

	public static readonly string ITEM_PLACEMENT_PROTOTYPE_DEFINE = "ALLOW_PLACEMENT_PROTOTYPE_CODE";

	public static readonly string DEFAULT_THEME_NAME = "Normal";

	public static readonly string CATRIO_THEME_NAME = "Catrio";

	public static readonly string ATRIOC_THEME_NAME = "Atrioc";

	public static readonly string CHRISTMAS_THEME_NAME = "Xmas";

	public static readonly string CUSTOM_THEME_NAME = "Custom";

	public static readonly string DEFAULT_SKIN_NAME = "default";

	public static readonly string DEFAULT_PLAYER_BODY_SKIN_NAME = "SkinSets/regular";

	public static readonly string DEFAULT_PLAYER_HAT_SKIN_NAME = "";

	public static readonly string DEFAULT_SKIN_SET_NAME = "Default Player Skins";

	public static readonly string CUSTOM_SKIN_SET_NAME = "Custom Player Skin Set";

	public static readonly string PROCEDURALLY_GENERATED_SKIN_NAME = "player composite skin";

	public static readonly string TORCH_SKIN_NAME = "torch/torch";

	public static readonly int SMALL_AGENT_ID = 0;

	public static readonly int MEDIUM_AGENT_ID = 1;

	public static readonly int LARGE_AGENT_ID = 2;

	public static readonly string GAME_MODE_STORY = "MainGame";

	public static readonly string GAME_MODE_FREE = "FreePlay";

	public static readonly string GAME_MODE_CREATIVE = "Creative";

	public static readonly string MASTER_BUS_PATH = "bus:/Master";

	public static readonly string MUSIC_BUS_PATH = "bus:/Master/Music";

	public static readonly string SFX_BUS_PATH = "bus:/Master/SFX";

	public static readonly string DIALOGUE_BUS_PATH = "bus:/Master/Dialogue";

	public static readonly string AMBIENT_BUS_PATH = "bus:/Master/Ambient";
}
