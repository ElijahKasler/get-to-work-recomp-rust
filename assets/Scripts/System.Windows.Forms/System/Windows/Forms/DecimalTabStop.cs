namespace System.Windows.Forms;

internal class DecimalTabStop : RightTabStop
{
	internal override float CalculateRight(Line line, int pos)
	{
		int endIndex = line.Text.IndexOfAny(new char[4] { '\t', '\n', '\r', '.' }, pos + 1);
		return calcWidth(line, pos, endIndex);
	}
}
