namespace System.Windows.Forms;

internal class CentredTabStop : TabStop
{
	internal override float CalculateRight(Line line, int pos)
	{
		int num = line.Text.IndexOfAny(new char[3] { '\t', '\n', '\r' }, pos + 1);
		if (num < 0)
		{
			num = line.text.Length;
		}
		float num2 = line.widths[num] - line.widths[pos + 1];
		return Math.Max(base.Position - num2 / 2f, line.widths[pos]);
	}
}
