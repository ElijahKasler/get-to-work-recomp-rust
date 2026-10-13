namespace System.Windows.Forms;

internal class LeftTabStop : TabStop
{
	internal LeftTabStop()
	{
	}

	internal LeftTabStop(float position)
	{
		base.Position = position;
	}

	internal override float GetInitialWidth(Line line, int pos)
	{
		return base.Position - line.widths[pos];
	}

	internal override float CalculateRight(Line line, int pos)
	{
		return base.Position;
	}
}
