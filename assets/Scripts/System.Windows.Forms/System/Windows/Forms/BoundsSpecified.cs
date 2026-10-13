namespace System.Windows.Forms;

[Flags]
public enum BoundsSpecified
{
	None = 0,
	X = 1,
	Y = 2,
	Location = X | Y,
	Width = 4,
	Height = 8,
	Size = Width | Height,
	All = Location | Size
}
