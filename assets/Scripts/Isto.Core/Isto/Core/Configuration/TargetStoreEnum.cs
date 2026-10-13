using Isto.Core.Enums;

namespace Isto.Core.Configuration;

public class TargetStoreEnum : Int32Enum<TargetStoreEnum>
{
	public static readonly TargetStoreEnum NONE = new TargetStoreEnum(0, "NONE");

	public static readonly TargetStoreEnum STEAM = new TargetStoreEnum(1, "STEAM");

	public static readonly TargetStoreEnum EPIC = new TargetStoreEnum(2, "EPIC");

	public static readonly TargetStoreEnum MICROSOFT = new TargetStoreEnum(3, "MICROSOFT");

	public static readonly TargetStoreEnum XBOX = new TargetStoreEnum(40, "XBOX");

	public static readonly TargetStoreEnum PLAYSTATION = new TargetStoreEnum(50, "PLAYSTATION");

	public static readonly TargetStoreEnum NINTENDO = new TargetStoreEnum(60, "NINTENDO");

	public TargetStoreEnum(int value, string name)
		: base(value, name)
	{
	}
}
