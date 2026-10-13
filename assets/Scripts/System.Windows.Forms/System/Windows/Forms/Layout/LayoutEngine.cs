using System.Drawing;

namespace System.Windows.Forms.Layout;

public abstract class LayoutEngine
{
	public virtual void InitLayout(object child, BoundsSpecified specified)
	{
	}

	public virtual bool Layout(object container, LayoutEventArgs layoutEventArgs)
	{
		return false;
	}

	internal virtual Size GetPreferredSize(object container, Size proposedSize)
	{
		return Size.Empty;
	}
}
