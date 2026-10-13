using System.Drawing;

namespace System.Windows.Forms;

internal struct POINT(int x, int y)
{
	public int x = x;

	public int y = y;

	public Point ToPoint()
	{
		return new Point(x, y);
	}

	public override string ToString()
	{
		return "Point {" + x + ", " + y + "}";
	}
}
