namespace System.Windows.Forms.CarbonInternal;

internal struct HIRect(int x, int y, int w, int h)
{
	public CGPoint origin = new CGPoint(x, y);

	public CGSize size = new CGSize(w, h);
}
