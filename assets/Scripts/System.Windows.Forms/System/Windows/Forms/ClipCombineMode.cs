namespace System.Windows.Forms;

internal enum ClipCombineMode
{
	RGN_AND = 1,
	RGN_OR = 2,
	RGN_XOR = 3,
	RGN_DIFF = 4,
	RGN_COPY = 5,
	RGN_MIN = RGN_AND,
	RGN_MAX = RGN_COPY
}
