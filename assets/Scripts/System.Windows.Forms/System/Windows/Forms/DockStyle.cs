using System.ComponentModel;
using System.Drawing.Design;

namespace System.Windows.Forms;

[Editor("System.Windows.Forms.Design.DockEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
public enum DockStyle
{
	None = 0,
	Top = 1,
	Bottom = 2,
	Left = 3,
	Right = 4,
	Fill = 5
}
