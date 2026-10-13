namespace System.Windows.Forms;

[Flags]
internal enum FormatSpecified
{
	None = 0,
	BackColor = 2,
	Font = 4,
	Color = 8,
	TextPosition = 0x10,
	CharOffset = 0x20,
	Visibility = 0x40,
	All = BackColor | Font | Color | TextPosition | CharOffset | Visibility
}
