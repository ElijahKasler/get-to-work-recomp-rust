using Isto.Core.Enums;

namespace Isto.Core.Audio;

public class SoundEventEnum : Int32Enum<SoundEventEnum>
{
	public SoundEventEnum(int value, string name)
		: base(value, name)
	{
	}
}
