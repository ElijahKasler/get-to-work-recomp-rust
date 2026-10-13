namespace System.Windows.Forms.RTF;

internal enum TokenClass
{
	None = -1,
	Unknown = 0,
	Group = 1,
	Text = 2,
	Control = 3,
	EOF = 4,
	MaxClass = 5
}
