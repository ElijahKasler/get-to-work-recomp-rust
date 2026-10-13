using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms.Layout;

internal interface IArrangedElement : IComponent, IDisposable
{
	bool Visible { get; }

	bool AutoSize { get; }

	Rectangle Bounds { get; }

	Rectangle ExplicitBounds { get; }

	Padding Padding { get; }

	Padding Margin { get; }

	Size MinimumSize { get; }

	AnchorStyles Anchor { get; }

	DockStyle Dock { get; }

	Rectangle DisplayRectangle { get; }

	IArrangedContainer Parent { get; }

	string Name { get; }

	int DistanceRight { get; set; }

	int DistanceBottom { get; set; }

	AutoSizeMode GetAutoSizeMode();

	void SetBounds(int x, int y, int width, int height, BoundsSpecified specified);

	Size GetPreferredSize(Size proposedSize);
}
