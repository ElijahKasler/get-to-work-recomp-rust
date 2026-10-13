namespace Isto.Core.UI;

public class GameMenusEnum : MenusEnum
{
	public enum GameMenus
	{
		Crafting = 0,
		Game = 1,
		Factory = 2,
		Equip = 3,
		Storage = 4,
		HeartboxUpgrade = 5,
		HeartBoxRefuel = 6,
		Scanner = 7,
		Closed = 8,
		Death = 9,
		CircuitJuiceDeath = 10,
		SceneStart = 11,
		HeartBox = 12,
		PlayerResearch = 13,
		FastTravel = 14,
		MiniMap = 15
	}

	public static readonly GameMenusEnum CRAFTING = new GameMenusEnum(0, "CRAFTING");

	public static readonly GameMenusEnum GAME = new GameMenusEnum(1, "GAME");

	public static readonly GameMenusEnum FACTORY = new GameMenusEnum(2, "FACTORY");

	public static readonly GameMenusEnum EQUIP = new GameMenusEnum(3, "EQUIP");

	public static readonly GameMenusEnum STORAGE = new GameMenusEnum(4, "STORAGE");

	public static readonly GameMenusEnum DEATH = new GameMenusEnum(9, "DEATH");

	public static readonly GameMenusEnum SCENE_START = new GameMenusEnum(11, "SCENE_START");

	public static readonly GameMenusEnum PLAYER_RESEARCH = new GameMenusEnum(13, "PLAYER_RESEARCH");

	public static readonly GameMenusEnum CHEATER = new GameMenusEnum("CHEATER");

	public static readonly GameMenusEnum BACKPACK = new GameMenusEnum("BACKPACK");

	public GameMenusEnum(string name)
		: base(name)
	{
	}

	public GameMenusEnum(int value, string name)
		: base(value, name)
	{
	}
}
