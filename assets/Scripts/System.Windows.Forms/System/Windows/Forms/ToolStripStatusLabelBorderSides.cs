using System.ComponentModel;
using System.Runtime.InteropServices;

namespace System.Windows.Forms;

[ComVisible(true)]
[Editor("System.Windows.Forms.Design.BorderSidesEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[Flags]
public enum ToolStripStatusLabelBorderSides
{
	None = 0,
	Left = 1,
	Top = 2,
	Right = 4,
	Bottom = 8,
	All = Left | Top | Right | Bottom
}
