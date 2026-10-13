namespace Isto.Core.Audio;

public class SettingsSoundEnum : SoundEventEnum
{
	public static readonly SettingsSoundEnum MASTER_VOLUME_SOUND = new SettingsSoundEnum(2000, "MASTER_VOLUME_SOUND");

	public static readonly SettingsSoundEnum MUSIC_VOLUME_SOUND = new SettingsSoundEnum(2100, "MUSIC_VOLUME_SOUND");

	public static readonly SettingsSoundEnum SFX_VOLUME_SOUND = new SettingsSoundEnum(2200, "SFX_VOLUME_SOUND");

	public static readonly SettingsSoundEnum DIALOGUE_VOLUME_SOUND = new SettingsSoundEnum(2300, "DIALOGUE_VOLUME_SOUND");

	public static readonly SettingsSoundEnum AMBIENT_VOLUME_SOUND = new SettingsSoundEnum(2400, "AMBIENT_VOLUME_SOUND");

	public SettingsSoundEnum(int value, string name)
		: base(value, name)
	{
	}
}
