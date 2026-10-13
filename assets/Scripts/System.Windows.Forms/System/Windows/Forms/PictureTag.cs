using System.Drawing;
using System.Windows.Forms.RTF;

namespace System.Windows.Forms;

internal class PictureTag : LineTag
{
	internal Picture picture;

	public override bool IsTextTag => false;

	internal PictureTag(Line line, int start, Picture picture)
		: base(line, start)
	{
		this.picture = picture;
	}

	public override SizeF SizeOfPosition(Graphics dc, int pos)
	{
		if (base.Visible)
		{
			return picture.Size;
		}
		return SizeF.Empty;
	}

	internal override int MaxHeight()
	{
		return (int)(picture.Height + 0.5f);
	}

	public override void Draw(Graphics dc, System.Drawing.Color color, float xoff, float y, int start, int end)
	{
		if (base.Visible)
		{
			picture.DrawImage(dc, xoff + base.Line.widths[start], y, selected: false);
		}
	}

	public override void Draw(Graphics dc, System.Drawing.Color color, float xoff, float y, int start, int end, string text)
	{
		Draw(dc, color, xoff, y, start, end);
	}

	public override void Draw(Graphics dc, System.Drawing.Color color, float xoff, float y, int start, int end, string text, out Rectangle measuredText, bool measureText)
	{
		Draw(dc, color, xoff, y, start, end);
		if (measureText && base.Visible)
		{
			measuredText = new Rectangle(Point.Round(new PointF(xoff + base.Line.widths[start], y)), Size.Round(picture.Size));
		}
		else
		{
			measuredText = default;
		}
	}

	public override string Text()
	{
		return "I";
	}
}
