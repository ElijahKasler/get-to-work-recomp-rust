using Isto.Core.Enums;

namespace Isto.Core.UI;

public class MenusEnum : Int32Enum<MenusEnum>
{
	public static readonly MenusEnum CLOSED = new MenusEnum(8, "CLOSED");

	public MenusEnum(string name)
		: base(name)
	{
	}

	public MenusEnum(int value, string name)
		: base(value, name)
	{
	}
}
