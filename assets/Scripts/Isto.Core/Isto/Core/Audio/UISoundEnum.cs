namespace Isto.Core.Audio;

public class UISoundEnum : SoundEventEnum
{
	public static readonly UISoundEnum NO_SOUND = new UISoundEnum(0, "NO_SOUND");

	public static readonly UISoundEnum BUTTON_HOVER = new UISoundEnum(1, "BUTTON_HOVER");

	public static readonly UISoundEnum BUTTON_CLICK = new UISoundEnum(2, "BUTTON_CLICK");

	public static readonly UISoundEnum BUTTON_ERROR = new UISoundEnum(3, "BUTTON_ERROR");

	public UISoundEnum(int value, string name)
		: base(value, name)
	{
	}
}
