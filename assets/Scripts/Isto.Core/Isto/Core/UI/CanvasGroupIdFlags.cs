using Isto.Core.Enums;

namespace Isto.Core.UI;

public class CanvasGroupIdFlags : Int32Flags<CanvasGroupIdFlags>
{
	public static readonly CanvasGroupIdFlags NONE = new CanvasGroupIdFlags(0u, "NONE");

	public static readonly CanvasGroupIdFlags SCENE_BLACKOUT = new CanvasGroupIdFlags(1u, "SCENE_BLACKOUT");

	public static readonly CanvasGroupIdFlags UI_GAMEPLAY = new CanvasGroupIdFlags(32u, "UI_GAMEPLAY");

	public static readonly CanvasGroupIdFlags UI_GAMEPLAY_INDEPENDENT = new CanvasGroupIdFlags(1024u, "UI_GAMEPLAY_INDEPENDENT");

	public static readonly CanvasGroupIdFlags UI_EQUIP_MENU = new CanvasGroupIdFlags(32768u, "UI_EQUIP_MENU");

	public static readonly CanvasGroupIdFlags UI_EQUIP_MENU_ITEMS = new CanvasGroupIdFlags(65536u, "UI_EQUIP_MENU_ITEMS");

	public static readonly CanvasGroupIdFlags ALL = new CanvasGroupIdFlags(uint.MaxValue, "ALL");

	public CanvasGroupIdFlags()
	{
	}

	public CanvasGroupIdFlags(uint value, string name)
		: base(value, name)
	{
	}
}
