namespace Isto.Core.Audio;

public class GameSoundEnum : SoundEventEnum
{
	public static readonly GameSoundEnum NO_SOUND = new GameSoundEnum(0, "NO_SOUND");

	public GameSoundEnum(int value, string name)
		: base(value, name)
	{
	}
}
