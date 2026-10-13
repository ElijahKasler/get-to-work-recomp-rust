namespace System.Windows.Forms;

internal enum MsgUIState
{
	UIS_SET = 1,
	UIS_CLEAR = 2,
	UIS_INITIALIZE = 3,
	UISF_HIDEFOCUS = UIS_SET,
	UISF_HIDEACCEL = UIS_CLEAR,
	UISF_ACTIVE = 4
}
