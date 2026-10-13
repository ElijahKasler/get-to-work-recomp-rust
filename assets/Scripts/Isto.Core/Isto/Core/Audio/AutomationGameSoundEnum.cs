namespace Isto.Core.Audio;

public class AutomationGameSoundEnum : GameSoundEnum
{
	public static readonly AutomationGameSoundEnum ITEM_PICKUP = new AutomationGameSoundEnum(1000, "ITEM_PICKUP");

	public AutomationGameSoundEnum(int value, string name)
		: base(value, name)
	{
	}
}
