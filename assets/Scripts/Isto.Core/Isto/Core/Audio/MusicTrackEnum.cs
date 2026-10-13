using Isto.Core.Enums;

namespace Isto.Core.Audio;

public class MusicTrackEnum : Int32Enum<MusicTrackEnum>
{
	public static readonly MusicTrackEnum NO_MUSIC = new MusicTrackEnum(0, "NO_MUSIC");

	public static readonly MusicTrackEnum RANDOM = new MusicTrackEnum(1, "RANDOM");

	public static readonly MusicTrackEnum TITLE = new MusicTrackEnum(2, "TITLE");

	public static readonly MusicTrackEnum END_GAME = new MusicTrackEnum(3, "END_GAME");

	public MusicTrackEnum(int value, string name)
		: base(value, name)
	{
	}
}
