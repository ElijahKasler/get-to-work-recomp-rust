namespace System.Windows.Forms;

[Flags]
public enum UICues
{
	None = 0,
	ShowFocus = 1,
	ShowKeyboard = 2,
	Shown = ShowFocus | ShowKeyboard,
	ChangeFocus = 4,
	ChangeKeyboard = 8,
	Changed = ChangeFocus | ChangeKeyboard
}
