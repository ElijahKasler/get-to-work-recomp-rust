namespace System.Windows.Forms;

[Flags]
public enum ButtonState
{
	Normal = 0,
	Inactive = 0x100,
	Pushed = 0x200,
	Checked = 0x400,
	Flat = 0x4000,
	All = Inactive | Pushed | Checked | Flat
}
