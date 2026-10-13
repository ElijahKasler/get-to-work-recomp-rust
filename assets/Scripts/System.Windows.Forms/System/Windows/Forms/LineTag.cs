using System.Drawing;

namespace System.Windows.Forms;

internal class LineTag
{
	private Font font;

	private Color color;

	private Color back_color;

	private Font link_font;

	private bool is_link;

	private string link_text;

	private bool visible;

	private TextPositioning text_position;

	private Font small_font;

	private float char_offset;

	private int start;

	private int height;

	private int ascent;

	private int descent;

	private int shift;

	private Line line;

	private LineTag next;

	private LineTag previous;

	public int Ascent => ascent;

	public Color BackColor
	{
		get
		{
			return back_color;
		}
		set
		{
			back_color = value;
		}
	}

	public Color ColorToDisplay
	{
		get
		{
			if (IsLink)
			{
				return Color.Blue;
			}
			return color;
		}
	}

	public Color Color
	{
		get
		{
			return color;
		}
		set
		{
			color = value;
		}
	}

	public int Descent => descent;

	public int End => start + Length;

	public Font FontToDisplay
	{
		get
		{
			if (IsLink)
			{
				if (link_font == null)
				{
					link_font = new Font(font.FontFamily, font.Size, font.Style | FontStyle.Underline);
				}
				return link_font;
			}
			if (TextPosition != TextPositioning.Normal)
			{
				if (small_font == null)
				{
					small_font = new Font(font.FontFamily, font.Size * 0.583f, font.Style);
				}
				if (IsLink)
				{
					return new Font(small_font, font.Style | FontStyle.Underline);
				}
				return small_font;
			}
			return font;
		}
	}

	public Font Font
	{
		get
		{
			return font;
		}
		set
		{
			if (font != value)
			{
				link_font = null;
				small_font = null;
				font = value;
				height = Font.Height;
				XplatUI.GetFontMetrics(Hwnd.GraphicsContext, Font, out ascent, out descent);
				float num = font.GetHeight() / (float)font.FontFamily.GetLineSpacing(font.Style);
				ascent = (int)Math.Ceiling((float)ascent * num);
				descent = (int)Math.Ceiling((float)descent * num);
				line.recalc = true;
			}
		}
	}

	public TextPositioning TextPosition
	{
		get
		{
			return text_position;
		}
		set
		{
			text_position = value;
		}
	}

	public float CharOffset
	{
		get
		{
			return char_offset;
		}
		set
		{
			char_offset = value;
		}
	}

	public int Height
	{
		get
		{
			return height;
		}
		set
		{
			height = value;
		}
	}

	public int DrawnHeight
	{
		get
		{
			if (text_position != TextPositioning.Normal)
			{
				return (int)((float)height * 0.583f);
			}
			return height;
		}
	}

	public virtual bool IsTextTag => true;

	public int Length
	{
		get
		{
			int num = 0;
			num = ((next == null) ? (line.text.Length - (start - 1)) : (next.start - start));
			if (num <= 0)
			{
				return 0;
			}
			return num;
		}
	}

	public Line Line
	{
		get
		{
			return line;
		}
		set
		{
			line = value;
		}
	}

	public LineTag Next
	{
		get
		{
			return next;
		}
		set
		{
			next = value;
		}
	}

	public LineTag Previous
	{
		get
		{
			return previous;
		}
		set
		{
			previous = value;
		}
	}

	public int Shift
	{
		get
		{
			return shift;
		}
		set
		{
			shift = value;
		}
	}

	public int Start
	{
		get
		{
			return start;
		}
		set
		{
			start = value;
		}
	}

	public int TextEnd => start + TextLength;

	public int TextLength
	{
		get
		{
			int num = 0;
			num = ((next == null) ? (line.TextLengthWithoutEnding() - (start - 1)) : (next.start - start));
			if (num <= 0)
			{
				return 0;
			}
			return num;
		}
	}

	public bool Visible
	{
		get
		{
			return visible;
		}
		set
		{
			visible = value;
		}
	}

	public float Width
	{
		get
		{
			if (Length == 0 || !visible)
			{
				return 0f;
			}
			return line.widths[start + Length - 1] - ((start != 0) ? line.widths[start - 1] : 0f);
		}
	}

	public float X
	{
		get
		{
			if (start == 0)
			{
				return line.X;
			}
			return (float)line.X + line.widths[start - 1];
		}
	}

	public int OffsetY
	{
		get
		{
			if (text_position == TextPositioning.Subscript)
			{
				return (int)((float)height * 0.45f);
			}
			return 0;
		}
	}

	public bool IsLink
	{
		get
		{
			return is_link;
		}
		set
		{
			is_link = value;
		}
	}

	public string LinkText
	{
		get
		{
			return link_text;
		}
		set
		{
			link_text = value;
		}
	}

	public LineTag(Line line, int start)
	{
		this.line = line;
		Start = start;
		link_font = null;
		is_link = false;
		link_text = null;
		visible = true;
	}

	public LineTag Break(int pos)
	{
		LineTag lineTag = new LineTag(line, pos);
		lineTag.CopyFormattingFrom(this);
		lineTag.Next = next;
		Next = lineTag;
		lineTag.previous = this;
		if (lineTag.next != null)
		{
			lineTag.next.previous = lineTag;
		}
		return lineTag;
	}

	public bool Combine(LineTag other)
	{
		if (!Equals(other))
		{
			return false;
		}
		Next = other.next;
		if (next != null)
		{
			next.previous = this;
		}
		return true;
	}

	public void CopyFormattingFrom(LineTag other)
	{
		Font = other.font;
		color = other.color;
		back_color = other.back_color;
		TextPosition = other.text_position;
		CharOffset = other.CharOffset;
		Visible = other.Visible;
	}

	public void Delete()
	{
		if (previous == null && next == null)
		{
			return;
		}
		if (next == null)
		{
			previous.next = null;
			return;
		}
		next.previous = null;
		for (LineTag lineTag = next; lineTag != null; lineTag = lineTag.next)
		{
			lineTag.Start -= Length;
		}
	}

	public virtual void Draw(Graphics dc, Color color, float x, float y, int start, int end)
	{
		if (text_position == TextPositioning.Subscript)
		{
			y += (float)OffsetY;
		}
		TextBoxTextRenderer.DrawText(dc, line.text.ToString(start, end).Replace("\r", string.Empty), FontToDisplay, color, x, y, showNonPrint: false);
	}

	public virtual void Draw(Graphics dc, Color color, float xoff, float y, int start, int end, string text)
	{
		Draw(dc, color, xoff, y, start, end, text, out var _, measureText: false);
	}

	public virtual void Draw(Graphics dc, Color color, float xoff, float y, int drawStart, int drawEnd, string text, out Rectangle measuredText, bool measureText)
	{
		if (!visible)
		{
			measuredText = default;
			return;
		}
		if (text_position == TextPositioning.Subscript)
		{
			y += (float)OffsetY;
		}
		if (measureText)
		{
			int x = (int)line.widths[drawStart] + (int)xoff;
			int width = (int)line.widths[drawEnd] - (int)line.widths[drawStart];
			int y2 = (int)y;
			int num = (int)TextBoxTextRenderer.MeasureText(dc, Text(), FontToDisplay).Height;
			measuredText = new Rectangle(x, y2, width, num);
		}
		else
		{
			measuredText = default;
		}
		while (drawStart < drawEnd)
		{
			int num2 = text.IndexOf("\t", drawStart);
			if (num2 == -1 || num2 > drawEnd)
			{
				num2 = drawEnd;
			}
			TextBoxTextRenderer.DrawText(dc, text.Substring(drawStart, num2 - drawStart).Replace("\r", string.Empty), FontToDisplay, color, xoff + line.widths[drawStart], y, showNonPrint: false);
			if (!line.document.multiline && num2 != drawEnd)
			{
				TextBoxTextRenderer.DrawText(dc, "\u0013", FontToDisplay, color, xoff + line.widths[num2], y, showNonPrint: true);
			}
			drawStart = num2 + 1;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is LineTag))
		{
			return false;
		}
		if (obj == this)
		{
			return true;
		}
		LineTag lineTag = (LineTag)obj;
		if (lineTag.IsTextTag != IsTextTag)
		{
			return false;
		}
		if (IsLink != lineTag.IsLink)
		{
			return false;
		}
		if (LinkText != lineTag.LinkText)
		{
			return false;
		}
		if (TextPosition != lineTag.TextPosition)
		{
			return false;
		}
		if (CharOffset != lineTag.CharOffset)
		{
			return false;
		}
		if (Visible != lineTag.Visible)
		{
			return false;
		}
		if (font.Equals(lineTag.font) && color.Equals(lineTag.color) && back_color.Equals(lineTag.back_color))
		{
			return true;
		}
		return false;
	}

	public static LineTag FindTag(Line line, int pos)
	{
		LineTag tags = line.tags;
		if (pos == 0)
		{
			return tags;
		}
		while (tags != null)
		{
			if (tags.start <= pos && pos < tags.End)
			{
				return GetFinalTag(tags);
			}
			tags = tags.next;
		}
		return null;
	}

	public static bool FormatText(Line line, int formatStart, int length, Font font, Color color, Color backColor, FormatSpecified specified)
	{
		return FormatText(line, formatStart, length, font, color, backColor, TextPositioning.Normal, 0f, visible: true, specified);
	}

	public static bool FormatText(Line line, int formatStart, int length, Font font, Color color, Color backColor, TextPositioning text_position, float char_offset, bool visible, FormatSpecified specified)
	{
		bool result = false;
		if ((FormatSpecified.Font & specified) == FormatSpecified.Font && font.Height != line.TextHeight)
		{
			result = true;
		}
		line.recalc = true;
		if (length > line.text.Length)
		{
			length = line.text.Length;
		}
		LineTag tags = line.tags;
		int num = formatStart + length;
		if (formatStart == 1 && length == tags.Length)
		{
			SetFormat(tags, font, color, backColor, text_position, char_offset, visible, specified);
			return result;
		}
		if (formatStart == 1 && length == 0)
		{
			line.tags.Break(1);
			SetFormat(line.tags, font, color, backColor, text_position, char_offset, visible, specified);
			return result;
		}
		LineTag lineTag = FindTag(line, formatStart - 1);
		if (lineTag.End == formatStart && length == 0 && lineTag.Next != null && lineTag.Next.Length == 0)
		{
			SetFormat(lineTag.Next, font, color, backColor, text_position, char_offset, visible, specified);
			return result;
		}
		while (lineTag.End == formatStart && lineTag.Next != null)
		{
			lineTag = lineTag.Next;
		}
		if (lineTag.Start == formatStart && lineTag.Length == length)
		{
			SetFormat(lineTag, font, color, backColor, text_position, char_offset, visible, specified);
			return result;
		}
		tags = ((lineTag.Start == formatStart) ? lineTag : lineTag.Break(formatStart));
		if (tags.Length == 0)
		{
			SetFormat(tags, font, color, backColor, text_position, char_offset, visible, specified);
			return result;
		}
		if (length == 0)
		{
			tags.Break(formatStart);
			SetFormat(tags, font, color, backColor, text_position, char_offset, visible, specified);
			return result;
		}
		bool flag = false;
		while (tags != null && tags.End <= num)
		{
			SetFormat(tags, font, color, backColor, text_position, char_offset, visible, specified);
			flag |= tags.End == num;
			tags = tags.next;
		}
		if (flag || (tags != null && tags.End == num))
		{
			return result;
		}
		LineTag lineTag2 = FindTag(line, num - 1);
		if (lineTag2 != null)
		{
			lineTag2.Break(num);
			SetFormat(lineTag2, font, color, backColor, text_position, char_offset, visible, specified);
		}
		return result;
	}

	public int GetCharIndex(int x)
	{
		int num = start;
		int num2 = num + Length;
		int num3 = line.TextLengthWithoutEnding();
		if (Length == 0)
		{
			return num - 1;
		}
		if (num3 == 0)
		{
			return 0;
		}
		float num4;
		if ((float)x < line.widths[num])
		{
			num4 = (line.widths[1] + line.widths[0]) / 2f;
			if (num == 1 && (float)x >= num4)
			{
				return num;
			}
			return num - 1;
		}
		if ((float)x > line.widths[num3])
		{
			return num3;
		}
		while (num < num2 - 1)
		{
			int num5 = (num2 + num) / 2;
			if (line.widths[num5] < (float)x)
			{
				num = num5;
			}
			else
			{
				num2 = num5;
			}
		}
		num4 = (line.widths[num2] + line.widths[num]) / 2f;
		if ((float)x >= num4)
		{
			return num2;
		}
		return num;
	}

	public static LineTag GetFinalTag(LineTag tag)
	{
		LineTag lineTag = tag;
		while (lineTag.Length == 0 && lineTag.next != null && lineTag.next.Length == 0)
		{
			lineTag = lineTag.next;
		}
		return lineTag;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	internal virtual int MaxHeight()
	{
		return font.Height;
	}

	private static void SetFormat(LineTag tag, Font font, Color color, Color back_color, FormatSpecified specified)
	{
		SetFormat(tag, font, color, back_color, TextPositioning.Normal, 0f, visible: true, specified);
	}

	private static void SetFormat(LineTag tag, Font font, Color color, Color back_color, TextPositioning text_position, float char_offset, bool visible, FormatSpecified specified)
	{
		if ((FormatSpecified.Font & specified) == FormatSpecified.Font)
		{
			tag.Font = font;
		}
		if ((FormatSpecified.Color & specified) == FormatSpecified.Color)
		{
			tag.color = color;
		}
		if ((FormatSpecified.BackColor & specified) == FormatSpecified.BackColor)
		{
			tag.back_color = back_color;
		}
		if ((FormatSpecified.TextPosition & specified) == FormatSpecified.TextPosition)
		{
			tag.TextPosition = text_position;
		}
		if ((FormatSpecified.CharOffset & specified) == FormatSpecified.CharOffset)
		{
			tag.CharOffset = char_offset;
		}
		if ((FormatSpecified.Visibility & specified) == FormatSpecified.Visibility)
		{
			tag.Visible = visible;
		}
	}

	public virtual SizeF SizeOfPosition(Graphics dc, int pos)
	{
		if ((pos >= line.TextLengthWithoutEnding() && line.document.multiline) || !visible)
		{
			return SizeF.Empty;
		}
		string text = line.text.ToString(pos, 1);
		switch ((int)text[0])
		{
		case 9:
			if (line.document.multiline)
			{
				SizeF result = TextBoxTextRenderer.MeasureText(dc, " ", FontToDisplay);
				float num = line.widths[pos];
				float num2 = -1f;
				TabStopCollection tab_stops = line.tab_stops;
				for (int i = 0; i < tab_stops.Count; i++)
				{
					float position = tab_stops[i].Position;
					if (position >= num)
					{
						if (!(position <= (float)line.document.viewport_width - line.RightIndent))
						{
							num2 = tab_stops[i].CalculateRight(line, pos);
						}
						break;
					}
				}
				if (num2 < 0f)
				{
					float num3 = dc.DpiX / 2f;
					num2 = (float)(Math.Floor(num / num3) + 1.0) * num3;
				}
				result.Width = num2 - num;
				return result;
			}
			goto case 10;
		case 10:
		case 13:
			return TextBoxTextRenderer.MeasureText(dc, "\r", FontToDisplay);
		default:
			return TextBoxTextRenderer.MeasureText(dc, text, FontToDisplay);
		}
	}

	public virtual string Text()
	{
		return line.text.ToString(start - 1, Length);
	}

	public override string ToString()
	{
		if (Length > 0)
		{
			return $"{GetType()} Tag starts at index: {start}, length: {Length}, text: {Text()}, font: {font.ToString()}";
		}
		return $"Zero Length tag at index: {start}";
	}
}
