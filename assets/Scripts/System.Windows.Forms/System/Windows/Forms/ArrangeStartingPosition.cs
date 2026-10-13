namespace System.Windows.Forms;

[Flags]
public enum ArrangeStartingPosition
{
	BottomLeft = 0,
	BottomRight = 1,
	TopLeft = 2,
	TopRight = BottomRight | TopLeft,
	Hide = 8
}
