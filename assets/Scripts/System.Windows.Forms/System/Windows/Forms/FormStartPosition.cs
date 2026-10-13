using System.Runtime.InteropServices;

namespace System.Windows.Forms;

[ComVisible(true)]
public enum FormStartPosition
{
	Manual = 0,
	CenterScreen = 1,
	WindowsDefaultLocation = 2,
	WindowsDefaultBounds = 3,
	CenterParent = 4
}
