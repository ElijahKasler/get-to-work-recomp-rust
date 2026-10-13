namespace System.Windows.Forms;

internal class RightTabStop : TabStop
{
	internal override float CalculateRight(Line line, int pos)
	{
		int endIndex = line.Text.IndexOfAny(new char[3] { '\t', '\n', '\r' }, pos + 1);
		return calcWidth(line, pos, endIndex);
	}

	protected float calcWidth(Line line, int pos, int endIndex)
	{
		if (endIndex < 0)
		{
			endIndex = line.text.Length;
		}
		float num = line.widths[endIndex] - line.widths[pos + 1];
		return Math.Max(base.Position - num, line.widths[pos]);
	}
}
