using System.Collections;
using System.Drawing;
using System.Text;

namespace System.Windows.Forms;

internal class Line : ICloneable, IComparable
{
	internal Document document;

	internal StringBuilder text;

	internal float[] widths;

	internal int space;

	internal int line_no;

	internal LineTag tags;

	internal int offset;

	internal int height;

	private int textHeight;

	internal int ascent;

	internal HorizontalAlignment alignment;

	internal int align_shift;

	internal float indent;

	internal float hanging_indent;

	internal float right_indent;

	internal LineEnding ending;

	internal float spacing_before;

	internal float spacing_after;

	internal float line_spacing;

	internal bool line_spacing_multiple;

	internal TabStopCollection tab_stops;

	internal Line parent;

	internal Line left;

	internal Line right;

	internal LineColor color;

	private static int DEFAULT_TEXT_LEN = 0;

	internal bool recalc;

	private static Hashtable kerning_fonts = new Hashtable();

	internal HorizontalAlignment Alignment
	{
		get
		{
			return alignment;
		}
		set
		{
			if (alignment != value)
			{
				alignment = value;
				recalc = true;
			}
		}
	}

	internal float HangingIndent
	{
		get
		{
			return hanging_indent;
		}
		set
		{
			hanging_indent = value;
			recalc = true;
		}
	}

	internal int Height
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

	internal int TextHeight => textHeight;

	internal TabStopCollection TabStops
	{
		get
		{
			return tab_stops;
		}
		set
		{
			tab_stops = value;
		}
	}

	internal float TotalParagraphSpacing => SpacingBefore + SpacingAfter;

	internal float LineSpacing
	{
		get
		{
			if (textHeight == 0)
			{
				throw new InvalidOperationException("Can't get LineSpacing when the line height isn't calculated!");
			}
			if (line_spacing < 0f)
			{
				return 0f - line_spacing;
			}
			if (line_spacing_multiple)
			{
				return line_spacing * (float)textHeight * 6f / document.Dpi;
			}
			return Math.Max(line_spacing, textHeight);
		}
	}

	internal float SpacingBefore
	{
		get
		{
			bool flag = true;
			if (line_no > 1)
			{
				Line line = document.GetLine(line_no - 1);
				if (line != null && (line.ending == LineEnding.Wrap || line.ending == LineEnding.None))
				{
					flag = false;
				}
			}
			if (flag)
			{
				return spacing_before;
			}
			return 0f;
		}
	}

	internal float SpacingAfter
	{
		get
		{
			if (ending == LineEnding.Wrap)
			{
				return 0f;
			}
			return spacing_after;
		}
	}

	internal float Indent
	{
		get
		{
			return indent;
		}
		set
		{
			indent = value;
			recalc = true;
		}
	}

	internal int LineNo
	{
		get
		{
			return line_no;
		}
		set
		{
			line_no = value;
		}
	}

	internal float RightIndent
	{
		get
		{
			return right_indent;
		}
		set
		{
			right_indent = value;
			recalc = true;
		}
	}

	internal int Width => (int)widths[text.Length];

	internal string Text
	{
		get
		{
			return text.ToString();
		}
		set
		{
			int length = text.Length;
			text = new StringBuilder(value, (value.Length > DEFAULT_TEXT_LEN) ? (value.Length + 1) : DEFAULT_TEXT_LEN);
			if (text.Length > length)
			{
				Grow(text.Length - length);
			}
		}
	}

	internal int X
	{
		get
		{
			if (document.multiline)
			{
				return align_shift;
			}
			return offset + align_shift;
		}
	}

	internal int Y
	{
		get
		{
			if (!document.multiline)
			{
				return document.top_margin;
			}
			return document.top_margin + offset;
		}
	}

	internal Line(Document document, LineEnding ending)
	{
		this.document = document;
		color = LineColor.Red;
		left = null;
		right = null;
		parent = null;
		text = null;
		recalc = true;
		alignment = document.alignment;
		this.ending = ending;
	}

	internal Line(Document document, int LineNo, string Text, Font font, Color color, LineEnding ending)
		: this(document, ending)
	{
		space = ((Text.Length > DEFAULT_TEXT_LEN) ? (Text.Length + 1) : DEFAULT_TEXT_LEN);
		text = new StringBuilder(Text, space);
		line_no = LineNo;
		this.ending = ending;
		tab_stops = new TabStopCollection();
		widths = new float[space + 1];
		tags = new LineTag(this, 1);
		tags.Font = font;
		tags.Color = color;
	}

	internal Line(Document document, int LineNo, string Text, HorizontalAlignment align, Font font, Color color, LineEnding ending)
		: this(document, ending)
	{
		space = ((Text.Length > DEFAULT_TEXT_LEN) ? (Text.Length + 1) : DEFAULT_TEXT_LEN);
		text = new StringBuilder(Text, space);
		line_no = LineNo;
		this.ending = ending;
		alignment = align;
		tab_stops = new TabStopCollection();
		widths = new float[space + 1];
		tags = new LineTag(this, 1);
		tags.Font = font;
		tags.Color = color;
	}

	internal Line(Document document, int LineNo, string Text, HorizontalAlignment align, Font font, Color color, Color back_color, TextPositioning text_position, float char_offset, float left_indent, float hanging_indent, float right_indent, float spacing_before, float spacing_after, float line_spacing, bool line_spacing_multiple, TabStopCollection tab_stops, bool visible, LineEnding ending)
		: this(document, ending)
	{
		space = ((Text.Length > DEFAULT_TEXT_LEN) ? (Text.Length + 1) : DEFAULT_TEXT_LEN);
		text = new StringBuilder(Text, space);
		line_no = LineNo;
		this.ending = ending;
		alignment = align;
		indent = left_indent;
		HangingIndent = hanging_indent;
		this.right_indent = right_indent;
		this.spacing_before = spacing_before;
		this.spacing_after = spacing_after;
		this.tab_stops = tab_stops;
		this.line_spacing = line_spacing;
		this.line_spacing_multiple = line_spacing_multiple;
		widths = new float[space + 1];
		tags = new LineTag(this, 1);
		tags.Font = font;
		tags.Color = color;
		tags.BackColor = back_color;
		tags.TextPosition = text_position;
		tags.CharOffset = char_offset;
		tags.Visible = visible;
	}

	internal Line(Document document, int LineNo, string Text, LineTag tag, LineEnding ending)
		: this(document, ending)
	{
		space = ((Text.Length > DEFAULT_TEXT_LEN) ? (Text.Length + 1) : DEFAULT_TEXT_LEN);
		text = new StringBuilder(Text, space);
		this.ending = ending;
		line_no = LineNo;
		widths = new float[space + 1];
		tags = tag;
	}

	internal void LinkRecord(StringBuilder linkRecord)
	{
		for (LineTag next = tags; next != null; next = next.Next)
		{
			if (next.IsLink)
			{
				linkRecord.Append("L");
			}
			else
			{
				linkRecord.Append("N");
			}
		}
	}

	internal void ClearLinks()
	{
		for (LineTag next = tags; next != null; next = next.Next)
		{
			next.IsLink = false;
		}
	}

	public void DeleteCharacters(int pos, int count)
	{
		bool flag = false;
		if (pos >= text.Length)
		{
			return;
		}
		LineTag lineTag = FindTag(pos);
		text.Remove(pos, count);
		if (lineTag == null)
		{
			return;
		}
		if (pos + count > lineTag.Start + lineTag.Length - 1)
		{
			flag = true;
			int num = count;
			num -= lineTag.Start + lineTag.Length - pos - 1;
			while (lineTag.Next != null && num > 0)
			{
				lineTag = lineTag.Next;
				int length = lineTag.Length;
				lineTag.Start -= count - num;
				num = ((length <= num) ? (num - length) : 0);
			}
		}
		else if (lineTag.Length == 0)
		{
			flag = true;
		}
		LineTag lineTag2 = lineTag;
		if (lineTag != null)
		{
			for (lineTag = lineTag.Next; lineTag != null; lineTag = lineTag.Next)
			{
				lineTag.Start -= count;
			}
		}
		while (lineTag2 != null && lineTag2.Next != null && lineTag2.Next.Length == 0)
		{
			LineTag previous = lineTag2;
			lineTag2.Next = lineTag2.Next.Next;
			if (lineTag2.Next != null)
			{
				lineTag2.Next.Previous = previous;
			}
			lineTag2 = lineTag2.Next;
		}
		recalc = true;
		if (flag)
		{
			Streamline(document.Lines);
		}
	}

	internal void DrawEnding(Graphics dc, float y)
	{
		if (!document.multiline)
		{
			LineTag next = tags;
			while (next.Next != null)
			{
				next = next.Next;
			}
			string text = null;
			switch (document.LineEndingLength(ending))
			{
			case 0:
				return;
			case 1:
				text = "\u0013";
				break;
			case 2:
				text = "\u0013\u0013";
				break;
			case 3:
				text = "\u0013\u0013\u0013";
				break;
			}
			TextBoxTextRenderer.DrawText(dc, text, next.Font, next.Color, (float)X + widths[TextLengthWithoutEnding()] - (float)document.viewport_x + (float)document.OffsetX, y, showNonPrint: true);
		}
	}

	internal LineTag FindTag(int pos)
	{
		if (pos == 0)
		{
			return tags;
		}
		LineTag next = tags;
		if (pos >= text.Length)
		{
			pos = text.Length - 1;
		}
		while (next != null)
		{
			if (next.Start - 1 <= pos && pos < next.Start + next.Length - 1)
			{
				return LineTag.GetFinalTag(next);
			}
			next = next.Next;
		}
		return null;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public LineTag GetTag(int x)
	{
		LineTag next = tags;
		if ((float)x < next.X)
		{
			return LineTag.GetFinalTag(next);
		}
		while (true)
		{
			if ((float)x >= next.X && (float)x < next.X + next.Width)
			{
				return next;
			}
			if (next.Next == null)
			{
				break;
			}
			next = next.Next;
		}
		return LineTag.GetFinalTag(next);
	}

	internal void Grow(int minimum)
	{
		int length = text.Length;
		if (length + minimum > space)
		{
			float[] array;
			if (length + minimum > space * 2)
			{
				array = new float[length + minimum * 2 + 1];
				space = length + minimum * 2;
			}
			else
			{
				array = new float[space * 2 + 1];
				space *= 2;
			}
			widths.CopyTo(array, 0);
			widths = array;
		}
	}

	public void InsertString(int pos, string s)
	{
		InsertString(pos, s, FindTag(pos));
	}

	public void InsertString(int pos, string s, LineTag tag)
	{
		int length = s.Length;
		text.Insert(pos, s);
		for (LineTag next = tags; next != null; next = next.Next)
		{
			if (next.Start - 1 <= pos && (pos < next.End - 1 || (pos == next.End - 1 && next.Length == 0)))
			{
				bool flag = false;
				while (pos < next.Start + next.Length - 1)
				{
					if (next == tag)
					{
						flag = true;
						break;
					}
					if (next.Next == null)
					{
						break;
					}
					next = next.Next;
				}
				if (!flag)
				{
					tag = ((pos >= next.Start + next.Length - 1) ? next : next.Previous);
				}
				break;
			}
		}
		for (tag = tag.Next; tag != null; tag = tag.Next)
		{
			tag.Start += length;
		}
		Grow(length);
		recalc = true;
	}

	internal bool RecalculateLine(Graphics g, Document doc)
	{
		int num = 0;
		int length = text.Length;
		Font fontToDisplay = tags.FontToDisplay;
		int num2 = 0;
		LineTag lineTag = tags;
		int num3 = offset;
		int num4 = height;
		int num5 = ascent;
		float spacingBefore = SpacingBefore;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		TabStop tabStop = null;
		int tab_pos = 0;
		height = 0;
		ascent = 0;
		lineTag.Shift = 0;
		Math.Max(right_indent, 0f);
		bool flag;
		if (line_no > 0)
		{
			Line line = doc.GetLine(LineNo - 1);
			flag = line != null && line.ending != LineEnding.Wrap;
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			widths[0] = indent;
		}
		else
		{
			widths[0] = indent + hanging_indent;
		}
		if (widths[0] < 0f)
		{
			widths[0] = 0f;
		}
		widths[0] += document.left_margin;
		recalc = false;
		bool result = false;
		bool flag2 = false;
		int i = 0;
		int num10 = 0;
		bool flag3 = kerning_fonts.ContainsKey(fontToDisplay.GetHashCode());
		while (num < length)
		{
			while (lineTag.Length == 0)
			{
				lineTag.Shift = lineTag.Line.ascent - lineTag.Ascent;
				lineTag = lineTag.Next;
				if (lineTag.Length != 0 && lineTag.FontToDisplay != fontToDisplay)
				{
					CheckKerning(g, fontToDisplay, num2, num - num2);
					fontToDisplay = lineTag.FontToDisplay;
					num2 = num;
					flag3 = kerning_fonts.ContainsKey(fontToDisplay.GetHashCode());
				}
			}
			char c = text[num];
			float num11;
			if (flag3 && !char.IsWhiteSpace(text[num]))
			{
				SizeF sizeF = TextBoxTextRenderer.MeasureText(g, text.ToString(num2, num + 1 - num2), fontToDisplay);
				num11 = widths[num2] + sizeF.Width;
			}
			else if (c != '\t')
			{
				float width = lineTag.SizeOfPosition(g, num).Width;
				num11 = widths[num] + width;
			}
			else
			{
				CheckKerning(g, fontToDisplay, num2, num - num2);
				num2 = num + 1;
				if (tabStop != null)
				{
					ProcessLastTab(tabStop, tab_pos, num);
					tabStop = null;
				}
				float num12 = widths[num];
				float width = -1f;
				for (int j = 0; j < tab_stops.Count; j++)
				{
					if (tab_stops[j].Position > num12)
					{
						tabStop = tab_stops[j];
						tab_pos = num;
						width = tabStop.GetInitialWidth(this, num);
						break;
					}
				}
				if (width < 0f)
				{
					width = lineTag.SizeOfPosition(g, num).Width;
				}
				num11 = widths[num] + width;
			}
			if (doc.Wrap)
			{
				if (i <= num && ((char.IsWhiteSpace(c) && c != '\u00a0') || c == '-' || c == '–' || c == '—'))
				{
					num10 = i;
					i = ((c != '\t') ? (num + 1) : num);
				}
				if (num11 > (float)doc.viewport_width - right_indent)
				{
					LineTag lineTag2 = null;
					if (i > 0)
					{
						widths[num + 1] = num11;
						if (char.IsWhiteSpace(c))
						{
							if (i > num)
							{
								for (; i < text.Length && char.IsWhiteSpace(text[i]) && text[i] != '\t'; i++)
								{
								}
								num++;
								flag2 = true;
							}
							else
							{
								lineTag2 = lineTag;
							}
						}
						else
						{
							if (i > num && num > 0)
							{
								i = ((num10 > 0) ? num10 : num);
							}
							lineTag2 = lineTag;
							num = i;
						}
					}
					else if (num > 0)
					{
						widths[num + 1] = num11;
						lineTag2 = lineTag;
					}
					if (lineTag2 != null)
					{
						if (tabStop != null)
						{
							ProcessLastTab(tabStop, tab_pos, num);
							tabStop = null;
						}
						while (num < lineTag2.Start)
						{
							lineTag2 = lineTag2.Previous;
						}
						doc.Split(this, lineTag2, num);
						ending = LineEnding.Wrap;
						length = text.Length;
						result = true;
						flag2 = true;
					}
				}
			}
			if (!flag2)
			{
				num++;
				widths[num] = num11;
				if (num == length)
				{
					Line line = doc.GetLine(line_no + 1);
					do
					{
						if (line != null && (ending == LineEnding.Wrap || ending == LineEnding.None) && (widths[num] < (float)doc.viewport_width - right_indent || line.text.Length == 0))
						{
							int num13 = height;
							doc.Combine(this, line);
							height = num13;
							lineTag = FindTag(num - 1);
							length = text.Length;
							line = doc.GetLine(line_no + 1);
							result = true;
						}
					}
					while ((ending == LineEnding.Wrap || ending == LineEnding.None) && line != null && line.text.Length == 0);
				}
			}
			if (num != lineTag.Start - 1 + lineTag.Length)
			{
				continue;
			}
			lineTag.Height = lineTag.MaxHeight();
			num8 = lineTag.Ascent + (int)lineTag.CharOffset;
			num9 = lineTag.Descent - (int)lineTag.CharOffset;
			if (num8 > num6)
			{
				int num14 = num8 - num6;
				num6 = num8;
				LineTag next = tags;
				while (next != null && next != lineTag)
				{
					next.Shift += num14;
					next = next.Next;
				}
				lineTag.Shift = (int)lineTag.CharOffset;
				ascent = num6;
			}
			else
			{
				lineTag.Shift = ascent - lineTag.Ascent;
			}
			if (num9 > num7)
			{
				num7 = num9;
			}
			if (height < num6 + num7 + lineTag.Height - lineTag.Ascent - lineTag.Descent)
			{
				height = num6 + num7 + lineTag.Height - lineTag.Ascent - lineTag.Descent;
			}
			lineTag = lineTag.Next;
			if (lineTag != null)
			{
				if (lineTag.Length != 0 && lineTag.FontToDisplay != fontToDisplay)
				{
					CheckKerning(g, fontToDisplay, num2, num - num2);
					fontToDisplay = lineTag.FontToDisplay;
					num2 = num;
					flag3 = kerning_fonts.ContainsKey(fontToDisplay.GetHashCode());
				}
				lineTag.Shift = 0;
			}
		}
		if (num != num2)
		{
			CheckKerning(g, fontToDisplay, num2, num - num2);
		}
		if (tabStop != null)
		{
			ProcessLastTab(tabStop, tab_pos, num);
			tabStop = null;
		}
		while (lineTag != null)
		{
			lineTag.Shift = lineTag.Line.ascent - lineTag.Ascent;
			lineTag = lineTag.Next;
		}
		if (height == 0)
		{
			height = tags.Font.Height;
			tags.Height = height;
			tags.Shift = 0;
		}
		textHeight = height;
		height = (int)(LineSpacing + TotalParagraphSpacing);
		if (num3 != offset || num4 != height || num5 != ascent || Math.Abs(spacingBefore - SpacingBefore) > document.Dpi / 1440f)
		{
			result = true;
		}
		return result;
	}

	private void ProcessLastTab(TabStop tab, int tab_pos, int pos)
	{
		float num = widths[tab_pos + 1];
		float num2 = tab.CalculateRight(this, tab_pos) - num;
		for (int i = tab_pos + 1; i <= pos; i++)
		{
			widths[i] += num2;
		}
	}

	private void CheckKerning(Graphics g, Font font, int start, int length)
	{
		if (length > 1 && !kerning_fonts.ContainsKey(font.GetHashCode()))
		{
			string text = this.text.ToString(start, length);
			float num = TextBoxTextRenderer.MeasureText(g, text, font).Width + widths[start + 1];
			int length2 = text.TrimEnd().Length;
			float num2 = widths[length2 + start + 1];
			if (num != num2)
			{
				kerning_fonts.Add(font.GetHashCode(), true);
			}
		}
	}

	internal bool RecalculatePasswordLine(Graphics g, Document doc)
	{
		int num = 0;
		int length = text.Length;
		LineTag lineTag = tags;
		ascent = 0;
		lineTag.Shift = 0;
		recalc = false;
		widths[0] = (float)document.left_margin + indent;
		float width = TextBoxTextRenderer.MeasureText(g, doc.password_char, tags.Font).Width;
		bool result = ((textHeight != lineTag.Font.Height) ? true : false);
		textHeight = lineTag.Font.Height;
		lineTag.Height = textHeight;
		height = (int)(LineSpacing + TotalParagraphSpacing);
		ascent = lineTag.Ascent;
		while (num < length)
		{
			num++;
			widths[num] = widths[num - 1] + width;
		}
		return result;
	}

	internal void CalculateAlignment()
	{
		int num = document.ViewPortWidth - document.left_margin - document.right_margin;
		int alignmentLineWidth = GetAlignmentLineWidth();
		switch (alignment)
		{
		case HorizontalAlignment.Left:
			align_shift = 0;
			break;
		case HorizontalAlignment.Center:
			align_shift = (num - alignmentLineWidth) / 2;
			break;
		case HorizontalAlignment.Right:
			align_shift = num - alignmentLineWidth;
			break;
		}
		align_shift = Math.Max(align_shift, 0);
	}

	private int GetAlignmentLineWidth()
	{
		int num = text.Length - 1;
		if (num < 0)
		{
			return 0;
		}
		char c = text[num];
		while (num > 0 && char.IsWhiteSpace(c) && c != '\t' && c != '\u00a0')
		{
			c = text[--num];
		}
		return (int)(widths[num + 1] - (float)document.left_margin + Math.Max(right_indent, 0f));
	}

	internal void Streamline(int lines)
	{
		LineTag lineTag = tags;
		LineTag next = lineTag.Next;
		while (lineTag.Length == 0 && next != null && next.IsTextTag)
		{
			tags = next;
			tags.Previous = null;
			lineTag = next;
			next = lineTag.Next;
		}
		if (next == null)
		{
			return;
		}
		while (next != null)
		{
			if (lineTag.IsTextTag && next.Length == 0 && next.IsTextTag && (next.Next != null || line_no != lines))
			{
				lineTag.Next = next.Next;
				if (lineTag.Next != null)
				{
					lineTag.Next.Previous = lineTag;
				}
				next = lineTag.Next;
			}
			else if (lineTag.Combine(next))
			{
				next = lineTag.Next;
			}
			else
			{
				lineTag = lineTag.Next;
				next = lineTag.Next;
			}
		}
	}

	internal int TextLengthWithoutEnding()
	{
		return text.Length - document.LineEndingLength(ending);
	}

	internal string TextWithoutEnding()
	{
		return text.ToString(0, text.Length - document.LineEndingLength(ending));
	}

	public object Clone()
	{
		Line line = new Line(document, ending);
		line.text = text;
		if (left != null)
		{
			line.left = (Line)left.Clone();
		}
		if (left != null)
		{
			line.left = (Line)left.Clone();
		}
		return line;
	}

	internal object CloneLine()
	{
		return new Line(document, ending)
		{
			text = text
		};
	}

	public int CompareTo(object obj)
	{
		if (obj == null)
		{
			return 1;
		}
		if (!(obj is Line))
		{
			throw new ArgumentException("Object is not of type Line", "obj");
		}
		if (line_no < ((Line)obj).line_no)
		{
			return -1;
		}
		if (line_no > ((Line)obj).line_no)
		{
			return 1;
		}
		return 0;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (!(obj is Line))
		{
			return false;
		}
		if (obj == this)
		{
			return true;
		}
		if (line_no == ((Line)obj).line_no)
		{
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return $"Line {line_no}";
	}
}
