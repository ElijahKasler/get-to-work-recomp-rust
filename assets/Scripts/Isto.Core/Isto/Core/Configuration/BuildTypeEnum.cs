using Isto.Core.Enums;

namespace Isto.Core.Configuration;

public class BuildTypeEnum : Int32Enum<BuildTypeEnum>
{
	public static readonly BuildTypeEnum UNKNOWN = new BuildTypeEnum("UNKNOWN");

	public static readonly BuildTypeEnum DEVELOPER = new BuildTypeEnum("DEVELOPER");

	public static readonly BuildTypeEnum PLAYTEST = new BuildTypeEnum("PLAYTEST");

	public static readonly BuildTypeEnum DEMO = new BuildTypeEnum("DEMO");

	public static readonly BuildTypeEnum EARLYACCESS = new BuildTypeEnum("EARLYACCESS");

	public static readonly BuildTypeEnum RELEASE = new BuildTypeEnum("RELEASE");

	public BuildTypeEnum(string name)
		: base(name)
	{
	}
}
