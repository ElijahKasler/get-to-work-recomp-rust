using Isto.Core.Enums;

namespace Isto.Core.Inputs;

public class UserActions : StringEnum<UserActions>
{
	public static readonly UserActions NONE = new UserActions("None", "NONE");

	public static readonly UserActions DISMANTLE = new UserActions("Dismantle", "DISMANTLE");

	public static readonly UserActions INTERACT = new UserActions("Interact", "INTERACT");

	public static readonly UserActions USEITEM = new UserActions("UseItem", "USEITEM");

	public static readonly UserActions USEEQUIPPEDITEM1 = new UserActions("UseEquippedItem1", "USEEQUIPPEDITEM1");

	public static readonly UserActions USEEQUIPPEDITEM2 = new UserActions("UseEquippedItem2", "USEEQUIPPEDITEM2");

	public static readonly UserActions USEEQUIPPEDITEM3 = new UserActions("UseEquippedItem3", "USEEQUIPPEDITEM3");

	public static readonly UserActions USEEQUIPPEDITEM4 = new UserActions("UseEquippedItem4", "USEEQUIPPEDITEM4");

	public static readonly UserActions USEEQUIPPEDITEM5 = new UserActions("UseEquippedItem5", "USEEQUIPPEDITEM5");

	public static readonly UserActions USEEQUIPPEDITEM6 = new UserActions("UseEquippedItem6", "USEEQUIPPEDITEM6");

	public static readonly UserActions USEEQUIPPEDITEM7 = new UserActions("UseEquippedItem7", "USEEQUIPPEDITEM7");

	public static readonly UserActions USEEQUIPPEDITEM8 = new UserActions("UseEquippedItem8", "USEEQUIPPEDITEM8");

	public static readonly UserActions USEMAINEQUIPPEDITEM = new UserActions("UseMainEquippedItem", "USEMAINEQUIPPEDITEM");

	public static readonly UserActions USESECONDARYEQUIPPEDITEM = new UserActions("UseSecondaryEquippedItem", "USESECONDARYEQUIPPEDITEM");

	public static readonly UserActions DROPITEM = new UserActions("DropItem", "DROPITEM");

	public static readonly UserActions GIVEITEM = new UserActions("GiveItem", "GIVEITEM");

	public static readonly UserActions TOGGLEGAMEMENU = new UserActions("ToggleGameMenu", "TOGGLEGAMEMENU");

	public static readonly UserActions TOGGLEBUGREPORTER = new UserActions("ToggleBugReporter", "TOGGLEBUGREPORTER");

	public static readonly UserActions ROTATELEFT = new UserActions("RotateLeft", "ROTATELEFT");

	public static readonly UserActions ROTATERIGHT = new UserActions("RotateRight", "ROTATERIGHT");

	public static readonly UserActions CANCELBUILDING = new UserActions("CancelBuilding", "CANCELBUILDING");

	public static readonly UserActions CANCELDISMANTLING = new UserActions("CancelDismantling", "CANCELDISMANTLING");

	public static readonly UserActions UIHORIZONTAL = new UserActions("UIHorizontal", "UIHORIZONTAL");

	public static readonly UserActions UIVERTICAL = new UserActions("UIVertical", "UIVERTICAL");

	public static readonly UserActions UISUBMIT = new UserActions("UISubmit", "UISUBMIT");

	public static readonly UserActions UICANCEL = new UserActions("UICancel", "UICANCEL");

	public static readonly UserActions UITABLEFT = new UserActions("UITabLeft", "UITABLEFT");

	public static readonly UserActions UITABRIGHT = new UserActions("UITabRight", "UITABRIGHT");

	public static readonly UserActions UIMODIFIERACTION = new UserActions("UIModifierAction", "UIMODIFIERACTION");

	public static readonly UserActions UISETTINGSRESETALLTODEFAULTS = new UserActions("UISettingsResetAllToDefaults", "UISETTINGSRESETALLTODEFAULTS");

	public static readonly UserActions PAUSE = new UserActions("Pause", "PAUSE");

	public static readonly UserActions TOGGLEDEVCONSOLE = new UserActions("ToggleDevConsole", "TOGGLEDEVCONSOLE");

	public static readonly UserActions FORCEGC = new UserActions("ForceGC", "FORCEGC");

	protected internal UserActions(string value, string name)
		: base(value, name)
	{
	}
}
