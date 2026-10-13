using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms.RTF;

namespace System.Windows.Forms;

[Docking(DockingBehavior.Ask)]
[Designer("System.Windows.Forms.Design.RichTextBoxDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.IDesigner")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class RichTextBox : TextBoxBase
{
	private class RtfSectionStyle : ICloneable
	{
		internal System.Drawing.Color rtf_color;

		internal System.Drawing.Color rtf_back_color;

		internal System.Windows.Forms.RTF.Font rtf_rtffont;

		internal float rtf_rtffont_size;

		internal FontStyle rtf_rtfstyle;

		internal HorizontalAlignment rtf_par_align;

		internal float rtf_par_line_left_indent;

		internal float rtf_par_first_line_indent;

		internal float rtf_par_line_right_indent;

		internal bool rtf_visible;

		internal int rtf_skip_width;

		internal float rtf_par_spacing_after;

		internal float rtf_par_spacing_before;

		internal float rtf_par_line_spacing;

		internal bool rtf_par_line_spacing_multiple;

		internal TextPositioning rtf_text_position;

		internal float rtf_char_offset;

		internal TabStop rtf_par_next_tab_stop;

		internal TabStopCollection rtf_par_tab_stops = new TabStopCollection();

		public object Clone()
		{
			return new RtfSectionStyle
			{
				rtf_color = rtf_color,
				rtf_back_color = rtf_back_color,
				rtf_par_line_left_indent = rtf_par_line_left_indent,
				rtf_par_first_line_indent = rtf_par_first_line_indent,
				rtf_par_line_right_indent = rtf_par_line_right_indent,
				rtf_par_align = rtf_par_align,
				rtf_rtffont = rtf_rtffont,
				rtf_rtffont_size = rtf_rtffont_size,
				rtf_rtfstyle = rtf_rtfstyle,
				rtf_visible = rtf_visible,
				rtf_skip_width = rtf_skip_width,
				rtf_par_spacing_after = rtf_par_spacing_after,
				rtf_par_spacing_before = rtf_par_spacing_before,
				rtf_par_line_spacing = rtf_par_line_spacing,
				rtf_par_line_spacing_multiple = rtf_par_line_spacing_multiple,
				rtf_text_position = rtf_text_position,
				rtf_char_offset = rtf_char_offset,
				rtf_par_tab_stops = rtf_par_tab_stops.Clone()
			};
		}
	}

	internal bool auto_word_select;

	internal int bullet_indent;

	internal bool detect_urls;

	private bool reuse_line;

	internal int margin_right;

	internal float zoom;

	private StringBuilder rtf_line;

	private RtfSectionStyle rtf_style;

	private Stack rtf_section_stack;

	private bool fire_contents_resized;

	private Size existing_contents_size;

	private int rtf_skip_count;

	private int rtf_cursor_x;

	private int rtf_cursor_y;

	private int rtf_chars;

	private bool enable_auto_drag_drop;

	private RichTextBoxLanguageOptions language_option;

	private bool rich_text_shortcuts_enabled;

	private static object ContentsResizedEvent = new object();

	private static object HScrollEvent = new object();

	private static object ImeChangeEvent = new object();

	private static object LinkClickedEvent = new object();

	private static object ProtectedEvent = new object();

	private static object SelectionChangedEvent = new object();

	private static object VScrollEvent = new object();

	private static readonly char[] ReservedRTFChars = new char[3] { '\\', '{', '}' };

	[Browsable(false)]
	public override bool AllowDrop
	{
		get
		{
			return base.AllowDrop;
		}
		set
		{
			base.AllowDrop = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override bool AutoSize
	{
		get
		{
			return auto_size;
		}
		set
		{
			base.AutoSize = value;
		}
	}

	[System.MonoTODO("Value not respected, always true")]
	[DefaultValue(false)]
	public bool AutoWordSelection
	{
		get
		{
			return auto_word_select;
		}
		set
		{
			auto_word_select = value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override Image BackgroundImage
	{
		get
		{
			return base.BackgroundImage;
		}
		set
		{
			base.BackgroundImage = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public override ImageLayout BackgroundImageLayout
	{
		get
		{
			return base.BackgroundImageLayout;
		}
		set
		{
			base.BackgroundImageLayout = value;
		}
	}

	[Localizable(true)]
	[DefaultValue(0)]
	public int BulletIndent
	{
		get
		{
			return bullet_indent;
		}
		set
		{
			bullet_indent = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool CanRedo => document.undo.CanRedo;

	[DefaultValue(true)]
	public bool DetectUrls
	{
		get
		{
			return base.EnableLinks;
		}
		set
		{
			base.EnableLinks = value;
		}
	}

	[System.MonoTODO("Stub, does nothing")]
	[DefaultValue(false)]
	public bool EnableAutoDragDrop
	{
		get
		{
			return enable_auto_drag_drop;
		}
		set
		{
			enable_auto_drag_drop = value;
		}
	}

	public override System.Drawing.Font Font
	{
		get
		{
			return base.Font;
		}
		set
		{
			if (font != value)
			{
				if (auto_size && base.PreferredHeight != base.Height)
				{
					base.Height = base.PreferredHeight;
				}
				base.Font = value;
				Line line = document.GetLine(1);
				Line line2 = document.GetLine(document.Lines);
				document.FormatText(line, 1, line2, line2.text.Length + 1, base.Font, System.Drawing.Color.Empty, System.Drawing.Color.Empty, FormatSpecified.Font);
			}
		}
	}

	public override System.Drawing.Color ForeColor
	{
		get
		{
			return base.ForeColor;
		}
		set
		{
			base.ForeColor = value;
		}
	}

	[System.MonoTODO("Stub, does nothing")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RichTextBoxLanguageOptions LanguageOption
	{
		get
		{
			return language_option;
		}
		set
		{
			language_option = value;
		}
	}

	[DefaultValue(int.MaxValue)]
	public override int MaxLength
	{
		get
		{
			return base.MaxLength;
		}
		set
		{
			base.MaxLength = value;
		}
	}

	[DefaultValue(true)]
	public override bool Multiline
	{
		get
		{
			return base.Multiline;
		}
		set
		{
			base.Multiline = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string RedoActionName => document.undo.RedoActionName;

	[System.MonoTODO("Stub, does nothing")]
	[Browsable(false)]
	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool RichTextShortcutsEnabled
	{
		get
		{
			return rich_text_shortcuts_enabled;
		}
		set
		{
			rich_text_shortcuts_enabled = value;
		}
	}

	[System.MonoInternalNote("Teach TextControl.RecalculateLine to consider the right margin as well")]
	[System.MonoTODO("Stub, does nothing")]
	[DefaultValue(0)]
	[Localizable(true)]
	public int RightMargin
	{
		get
		{
			return margin_right;
		}
		set
		{
			margin_right = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[RefreshProperties(RefreshProperties.All)]
	public string Rtf
	{
		get
		{
			Line line = document.GetLine(1);
			Line line2 = document.GetLine(document.Lines);
			return GenerateRTF(line, 0, line2, line2.text.Length).ToString();
		}
		set
		{
			fire_contents_resized = false;
			existing_contents_size = new Size(document.Width, document.Height);
			document.Empty();
			MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(value), writable: false);
			InsertRTFFromStream(memoryStream, 0, 1);
			Line line = document.GetLine(1);
			document.SetSelection(line, 0);
			document.PositionCaret(line, 0);
			memoryStream.Close();
			Invalidate();
			fire_contents_resized = true;
			ContentSizeChanged();
			existing_contents_size = Size.Empty;
		}
	}

	[DefaultValue(RichTextBoxScrollBars.Both)]
	[Localizable(true)]
	public RichTextBoxScrollBars ScrollBars
	{
		get
		{
			return scrollbars;
		}
		set
		{
			if (!Enum.IsDefined(typeof(RichTextBoxScrollBars), value))
			{
				throw new InvalidEnumArgumentException("value", (int)value, typeof(RichTextBoxScrollBars));
			}
			if (value != scrollbars)
			{
				scrollbars = value;
				CalculateDocument();
			}
		}
	}

	[Browsable(false)]
	[DefaultValue("")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SelectedRtf
	{
		get
		{
			return GenerateRTF(document.selection_start.line, document.selection_start.pos, document.selection_end.line, document.selection_end.pos).ToString();
		}
		set
		{
			fire_contents_resized = false;
			existing_contents_size = new Size(document.Width, document.Height);
			document.SuspendRecalc();
			if (document.selection_visible)
			{
				document.ReplaceSelection("", select_new: false);
			}
			int pos = document.LineTagToCharIndex(document.selection_start.line, document.selection_start.pos);
			MemoryStream memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(value), writable: false);
			int pos2 = document.selection_start.pos;
			int line_no = document.selection_start.line.line_no;
			if (pos2 == 0)
			{
				reuse_line = true;
			}
			InsertRTFFromStream(memoryStream, pos2, line_no, out var _, out var to_y, out var chars);
			memoryStream.Close();
			int num = document.LineEndingLength(XplatUI.RunningOnUnix ? LineEnding.Rich : LineEnding.Hard);
			document.CharIndexToLineTag(pos + chars + (to_y - document.selection_start.line.line_no) * num, out var line_out, out var _, out pos);
			if (pos > line_out.text.Length)
			{
				pos = line_out.text.Length;
			}
			document.SetSelection(line_out, pos);
			document.PositionCaret(line_out, pos);
			document.ResumeRecalc(immediate_update: true);
			document.DisplayCaret();
			ScrollToCaret();
			OnTextChanged(EventArgs.Empty);
			fire_contents_resized = true;
			ContentSizeChanged();
			existing_contents_size = Size.Empty;
		}
	}

	[DefaultValue("")]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override string SelectedText
	{
		get
		{
			return base.SelectedText;
		}
		set
		{
			base.Modified = true;
			base.SelectedText = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DefaultValue(HorizontalAlignment.Left)]
	public HorizontalAlignment SelectionAlignment
	{
		get
		{
			Line line = document.ParagraphStart(document.selection_start.line);
			HorizontalAlignment horizontalAlignment = line.alignment;
			Line line2 = document.ParagraphEnd(document.selection_end.line);
			Line line3 = line;
			while (true)
			{
				if (line3.alignment != horizontalAlignment)
				{
					return HorizontalAlignment.Left;
				}
				if (line3 == line2)
				{
					break;
				}
				line3 = document.GetLine(line3.line_no + 1);
			}
			return horizontalAlignment;
		}
		set
		{
			Line line = document.ParagraphStart(document.selection_start.line);
			Line line2 = document.ParagraphEnd(document.selection_end.line);
			Line line3 = line;
			while (true)
			{
				line3.alignment = value;
				if (line3 == line2)
				{
					break;
				}
				line3 = document.GetLine(line3.line_no + 1);
			}
			CalculateDocument();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public System.Drawing.Color SelectionBackColor
	{
		get
		{
			LineTag lineTag = document.selection_start.line.FindTag(document.selection_start.pos);
			LineTag lineTag2 = ((SelectionLength <= 0) ? lineTag : document.selection_start.line.FindTag(document.selection_end.pos - 1));
			System.Drawing.Color backColor = lineTag.BackColor;
			for (LineTag lineTag3 = lineTag; lineTag3 != null; lineTag3 = document.NextTag(lineTag3))
			{
				if (backColor != lineTag3.BackColor)
				{
					return System.Drawing.Color.Empty;
				}
				if (lineTag3 == lineTag2)
				{
					break;
				}
			}
			return backColor;
		}
		set
		{
			int index = document.LineTagToCharIndex(document.selection_start.line, document.selection_start.pos);
			int index2 = document.LineTagToCharIndex(document.selection_end.line, document.selection_end.pos);
			document.FormatText(document.selection_start.line, document.selection_start.pos + 1, document.selection_end.line, document.selection_end.pos + 1, null, System.Drawing.Color.Empty, value, FormatSpecified.BackColor);
			document.CharIndexToLineTag(index, out document.selection_start.line, out document.selection_start.tag, out document.selection_start.pos);
			document.CharIndexToLineTag(index2, out document.selection_end.line, out document.selection_end.tag, out document.selection_end.pos);
			document.UpdateView(document.selection_start.line, 0);
			base.Document.AlignCaret(changeCaretTag: false);
		}
	}

	[Browsable(false)]
	[DefaultValue(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[System.MonoTODO("Stub, does nothing")]
	public bool SelectionBullet
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[Browsable(false)]
	[DefaultValue(0)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionCharOffset
	{
		get
		{
			LineTag lineTag = document.selection_start.line.FindTag(document.selection_start.pos);
			LineTag lineTag2 = ((SelectionLength <= 0) ? lineTag : document.selection_start.line.FindTag(document.selection_end.pos - 1));
			float charOffset = lineTag.CharOffset;
			for (LineTag lineTag3 = lineTag; lineTag3 != null; lineTag3 = document.NextTag(lineTag3))
			{
				if ((double)Math.Abs(charOffset - lineTag3.CharOffset) > 0.01)
				{
					return 0;
				}
				if (lineTag3 == lineTag2)
				{
					break;
				}
			}
			return (int)charOffset;
		}
		set
		{
			int index = document.LineTagToCharIndex(document.selection_start.line, document.selection_start.pos);
			int index2 = document.LineTagToCharIndex(document.selection_end.line, document.selection_end.pos);
			document.FormatText(document.selection_start.line, document.selection_start.pos + 1, document.selection_end.line, document.selection_end.pos + 1, null, System.Drawing.Color.Empty, System.Drawing.Color.Empty, TextPositioning.Normal, value, visible: true, FormatSpecified.CharOffset);
			document.CharIndexToLineTag(index, out document.selection_start.line, out document.selection_start.tag, out document.selection_start.pos);
			document.CharIndexToLineTag(index2, out document.selection_end.line, out document.selection_end.tag, out document.selection_end.pos);
			document.UpdateView(document.selection_start.line, 0);
			base.Document.AlignCaret(changeCaretTag: false);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public System.Drawing.Color SelectionColor
	{
		get
		{
			LineTag lineTag = document.selection_start.line.FindTag(document.selection_start.pos);
			LineTag lineTag2 = ((SelectionLength <= 0) ? lineTag : document.selection_start.line.FindTag(document.selection_end.pos - 1));
			System.Drawing.Color color = lineTag.Color;
			for (LineTag lineTag3 = lineTag; lineTag3 != null; lineTag3 = document.NextTag(lineTag3))
			{
				if (!color.Equals(lineTag3.Color))
				{
					return System.Drawing.Color.Empty;
				}
				if (lineTag3 == lineTag2)
				{
					break;
				}
			}
			return color;
		}
		set
		{
			if (value == System.Drawing.Color.Empty)
			{
				value = Control.DefaultForeColor;
			}
			int index = document.LineTagToCharIndex(document.selection_start.line, document.selection_start.pos);
			int index2 = document.LineTagToCharIndex(document.selection_end.line, document.selection_end.pos);
			document.FormatText(document.selection_start.line, document.selection_start.pos + 1, document.selection_end.line, document.selection_end.pos + 1, null, value, System.Drawing.Color.Empty, FormatSpecified.Color);
			document.CharIndexToLineTag(index, out document.selection_start.line, out document.selection_start.tag, out document.selection_start.pos);
			document.CharIndexToLineTag(index2, out document.selection_end.line, out document.selection_end.tag, out document.selection_end.pos);
			document.UpdateView(document.selection_start.line, 0);
			document.AlignCaret(changeCaretTag: false);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public System.Drawing.Font SelectionFont
	{
		get
		{
			LineTag lineTag = document.selection_start.line.FindTag(document.selection_start.pos);
			LineTag lineTag2 = ((SelectionLength <= 0) ? lineTag : document.selection_start.line.FindTag(document.selection_end.pos - 1));
			System.Drawing.Font font = lineTag.Font;
			if (SelectionLength > 1)
			{
				for (LineTag lineTag3 = lineTag; lineTag3 != null; lineTag3 = document.NextTag(lineTag3))
				{
					if (!font.Equals(lineTag3.Font))
					{
						return null;
					}
					if (lineTag3 == lineTag2)
					{
						break;
					}
				}
			}
			return font;
		}
		set
		{
			int index = document.LineTagToCharIndex(document.selection_start.line, document.selection_start.pos);
			int index2 = document.LineTagToCharIndex(document.selection_end.line, document.selection_end.pos);
			document.FormatText(document.selection_start.line, document.selection_start.pos + 1, document.selection_end.line, document.selection_end.pos + 1, value, System.Drawing.Color.Empty, System.Drawing.Color.Empty, FormatSpecified.Font);
			document.CharIndexToLineTag(index, out document.selection_start.line, out document.selection_start.tag, out document.selection_start.pos);
			document.CharIndexToLineTag(index2, out document.selection_end.line, out document.selection_end.tag, out document.selection_end.pos);
			document.UpdateView(document.selection_start.line, 0);
			base.Document.AlignCaret(changeCaretTag: false);
		}
	}

	[Browsable(false)]
	[DefaultValue(0)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionHangingIndent
	{
		get
		{
			Line line = document.ParagraphStart(document.selection_start.line);
			int num = (int)line.hanging_indent;
			Line line2 = document.ParagraphEnd(document.selection_end.line);
			Line line3 = line;
			while (true)
			{
				if ((int)line3.hanging_indent != num)
				{
					return 0;
				}
				if (line3 == line2)
				{
					break;
				}
				line3 = document.GetLine(line3.line_no + 1);
			}
			return num;
		}
		set
		{
			Line line = document.ParagraphStart(document.selection_start.line);
			Line line2 = document.ParagraphEnd(document.selection_end.line);
			Line line3 = line;
			while (true)
			{
				line3.HangingIndent = value;
				if (line3 == line2)
				{
					break;
				}
				line3 = document.GetLine(line3.line_no + 1);
			}
			CalculateDocument();
		}
	}

	[Browsable(false)]
	[DefaultValue(0)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionIndent
	{
		get
		{
			Line line = document.ParagraphStart(document.selection_start.line);
			int num = (int)line.indent;
			Line line2 = document.ParagraphEnd(document.selection_end.line);
			Line line3 = line;
			while (true)
			{
				if ((int)line3.indent != num)
				{
					return 0;
				}
				if (line3 == line2)
				{
					break;
				}
				line3 = document.GetLine(line3.line_no + 1);
			}
			return num;
		}
		set
		{
			Line line = document.ParagraphStart(document.selection_start.line);
			Line line2 = document.ParagraphEnd(document.selection_end.line);
			Line line3 = line;
			while (true)
			{
				line3.Indent = value;
				if (line3 == line2)
				{
					break;
				}
				line3 = document.GetLine(line3.line_no + 1);
			}
			CalculateDocument();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override int SelectionLength
	{
		get
		{
			return base.SelectionLength;
		}
		set
		{
			base.SelectionLength = value;
		}
	}

	[Browsable(false)]
	[DefaultValue(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[System.MonoTODO("Stub, does nothing")]
	public bool SelectionProtected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[DefaultValue(0)]
	public int SelectionRightIndent
	{
		get
		{
			Line line = document.ParagraphStart(document.selection_start.line);
			int num = (int)line.right_indent;
			Line line2 = document.ParagraphEnd(document.selection_end.line);
			Line line3 = line;
			while (true)
			{
				if ((int)line3.right_indent != num)
				{
					return 0;
				}
				if (line3 == line2)
				{
					break;
				}
				line3 = document.GetLine(line3.line_no + 1);
			}
			return num;
		}
		set
		{
			Line line = document.ParagraphStart(document.selection_start.line);
			Line line2 = document.ParagraphEnd(document.selection_end.line);
			Line line3 = line;
			while (true)
			{
				line3.RightIndent = value;
				if (line3 == line2)
				{
					break;
				}
				line3 = document.GetLine(line3.line_no + 1);
			}
			CalculateDocument();
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public int[] SelectionTabs
	{
		get
		{
			Line line = document.ParagraphStart(document.selection_start.line);
			TabStopCollection tabStops = line.TabStops;
			Line line2 = document.ParagraphEnd(document.selection_end.line);
			Line line3 = line;
			while (true)
			{
				if (!line3.TabStops.Equals(tabStops))
				{
					return new int[0];
				}
				if (line3 == line2)
				{
					break;
				}
				line3 = document.GetLine(line3.line_no + 1);
			}
			return tabStops.ToPosArray();
		}
		set
		{
			Line line = document.ParagraphStart(document.selection_start.line);
			Line line2 = document.ParagraphEnd(document.selection_end.line);
			Line line3 = line;
			while (true)
			{
				line3.TabStops.Clear();
				foreach (int num in value)
				{
					line3.TabStops.Add(new LeftTabStop(num));
				}
				if (line3 == line2)
				{
					break;
				}
				line3 = document.GetLine(line3.line_no + 1);
			}
			CalculateDocument();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RichTextBoxSelectionTypes SelectionType
	{
		get
		{
			if (document.selection_start == document.selection_end)
			{
				return RichTextBoxSelectionTypes.Empty;
			}
			if (SelectedText.Length > 1)
			{
				return RichTextBoxSelectionTypes.Text | RichTextBoxSelectionTypes.MultiChar;
			}
			return RichTextBoxSelectionTypes.Text;
		}
	}

	[DefaultValue(false)]
	[System.MonoTODO("Stub, does nothing")]
	public bool ShowSelectionMargin
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[Localizable(true)]
	[RefreshProperties(RefreshProperties.All)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			base.Text = value;
		}
	}

	[Browsable(false)]
	public override int TextLength => base.TextLength;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string UndoActionName => document.undo.UndoActionName;

	[Localizable(true)]
	[DefaultValue(1)]
	public float ZoomFactor
	{
		get
		{
			return zoom;
		}
		set
		{
			zoom = value;
		}
	}

	protected override CreateParams CreateParams => base.CreateParams;

	protected override Size DefaultSize => new Size(100, 96);

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public new event EventHandler BackgroundImageChanged
	{
		add
		{
			base.BackgroundImageChanged += value;
		}
		remove
		{
			base.BackgroundImageChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler BackgroundImageLayoutChanged
	{
		add
		{
			base.BackgroundImageLayoutChanged += value;
		}
		remove
		{
			base.BackgroundImageLayoutChanged -= value;
		}
	}

	public event ContentsResizedEventHandler ContentsResized
	{
		add
		{
			base.Events.AddHandler(ContentsResizedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ContentsResizedEvent, value);
		}
	}

	[Browsable(false)]
	public new event DragEventHandler DragDrop
	{
		add
		{
			base.DragDrop += value;
		}
		remove
		{
			base.DragDrop -= value;
		}
	}

	[Browsable(false)]
	public new event DragEventHandler DragEnter
	{
		add
		{
			base.DragEnter += value;
		}
		remove
		{
			base.DragEnter -= value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public new event EventHandler DragLeave
	{
		add
		{
			base.DragLeave += value;
		}
		remove
		{
			base.DragLeave -= value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public new event DragEventHandler DragOver
	{
		add
		{
			base.DragOver += value;
		}
		remove
		{
			base.DragOver -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event GiveFeedbackEventHandler GiveFeedback
	{
		add
		{
			base.GiveFeedback += value;
		}
		remove
		{
			base.GiveFeedback -= value;
		}
	}

	public event EventHandler HScroll
	{
		add
		{
			base.Events.AddHandler(HScrollEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(HScrollEvent, value);
		}
	}

	public event EventHandler ImeChange
	{
		add
		{
			base.Events.AddHandler(ImeChangeEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ImeChangeEvent, value);
		}
	}

	public event LinkClickedEventHandler LinkClicked
	{
		add
		{
			base.Events.AddHandler(LinkClickedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(LinkClickedEvent, value);
		}
	}

	public event EventHandler Protected
	{
		add
		{
			base.Events.AddHandler(ProtectedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ProtectedEvent, value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event QueryContinueDragEventHandler QueryContinueDrag
	{
		add
		{
			base.QueryContinueDrag += value;
		}
		remove
		{
			base.QueryContinueDrag -= value;
		}
	}

	[System.MonoTODO("Event never raised")]
	public event EventHandler SelectionChanged
	{
		add
		{
			base.Events.AddHandler(SelectionChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(SelectionChangedEvent, value);
		}
	}

	public event EventHandler VScroll
	{
		add
		{
			base.Events.AddHandler(VScrollEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(VScrollEvent, value);
		}
	}

	public RichTextBox()
	{
		accepts_return = true;
		auto_size = false;
		auto_word_select = false;
		bullet_indent = 0;
		base.MaxLength = int.MaxValue;
		margin_right = 0;
		zoom = 1f;
		base.Multiline = true;
		document.CRLFSize = 1;
		shortcuts_enabled = true;
		base.EnableLinks = true;
		richtext = true;
		rtf_style = new RtfSectionStyle();
		rtf_section_stack = null;
		fire_contents_resized = true;
		scrollbars = RichTextBoxScrollBars.Both;
		alignment = HorizontalAlignment.Left;
		document.SizeChanged += ContentSizeChanged;
		base.LostFocus += RichTextBox_LostFocus;
		base.GotFocus += RichTextBox_GotFocus;
		BackColor = ThemeEngine.Current.ColorWindow;
		backcolor_set = false;
		language_option = RichTextBoxLanguageOptions.AutoFontSizeAdjust;
		rich_text_shortcuts_enabled = true;
		ForeColor = ThemeEngine.Current.ColorWindowText;
		base.HScrolled += RichTextBox_HScrolled;
		base.VScrolled += RichTextBox_VScrolled;
		SetStyle(ControlStyles.StandardDoubleClick, value: false);
	}

	internal override void HandleLinkClicked(LinkRectangle link)
	{
		OnLinkClicked(new LinkClickedEventArgs(link.LinkTag.LinkText));
	}

	internal override System.Drawing.Color ChangeBackColor(System.Drawing.Color backColor)
	{
		if (backColor == System.Drawing.Color.Empty)
		{
			backcolor_set = false;
			if (!base.ReadOnly)
			{
				backColor = SystemColors.Window;
			}
		}
		return backColor;
	}

	internal override void RaiseSelectionChanged()
	{
		OnSelectionChanged(EventArgs.Empty);
	}

	private void RichTextBox_LostFocus(object sender, EventArgs e)
	{
		Invalidate();
	}

	private void RichTextBox_GotFocus(object sender, EventArgs e)
	{
		Invalidate();
	}

	private void ContentSizeChanged(object sender, Document.SizeChangedEventArgs e)
	{
		ContentSizeChanged();
	}

	private void ContentSizeChanged()
	{
		if (fire_contents_resized && (existing_contents_size.IsEmpty || existing_contents_size.Height != document.Height || existing_contents_size.Width != document.Width))
		{
			int height = document.Height + document.top_margin * 2 + base.Height - base.ClientRectangle.Height;
			ContentsResizedEventArgs e = new ContentsResizedEventArgs(new Rectangle(width: (!Multiline) ? (document.Width + document.left_margin + document.right_margin + base.Width - base.ClientRectangle.Width) : base.Width, x: base.Left, y: base.Top, height: height));
			OnContentsResized(e);
		}
	}

	public bool CanPaste(DataFormats.Format clipFormat)
	{
		if (clipFormat.Name == DataFormats.Rtf || clipFormat.Name == DataFormats.Text || clipFormat.Name == DataFormats.UnicodeText)
		{
			return true;
		}
		return false;
	}

	public int Find(char[] characterSet)
	{
		return Find(characterSet, -1, -1);
	}

	public int Find(char[] characterSet, int start)
	{
		return Find(characterSet, start, -1);
	}

	public int Find(char[] characterSet, int start, int end)
	{
		Document.Marker mark;
		if (start == -1)
		{
			document.GetMarker(out mark, start: true);
		}
		else
		{
			mark = default;
			document.CharIndexToLineTag(start, out var line_out, out var tag_out, out var pos);
			mark.line = line_out;
			mark.tag = tag_out;
			mark.pos = pos;
		}
		Document.Marker mark2;
		if (end == -1)
		{
			document.GetMarker(out mark2, start: false);
		}
		else
		{
			mark2 = default;
			document.CharIndexToLineTag(end, out var line_out2, out var tag_out2, out var pos2);
			mark2.line = line_out2;
			mark2.tag = tag_out2;
			mark2.pos = pos2;
		}
		if (document.FindChars(characterSet, mark, mark2, out var result))
		{
			return document.LineTagToCharIndex(result.line, result.pos);
		}
		return -1;
	}

	public int Find(string str)
	{
		return Find(str, -1, -1, RichTextBoxFinds.None);
	}

	public int Find(string str, int start, int end, RichTextBoxFinds options)
	{
		Document.Marker mark;
		if (start == -1)
		{
			document.GetMarker(out mark, start: true);
		}
		else
		{
			mark = default;
			document.CharIndexToLineTag(start, out var line_out, out var tag_out, out var pos);
			mark.line = line_out;
			mark.tag = tag_out;
			mark.pos = pos;
		}
		Document.Marker mark2;
		if (end == -1)
		{
			document.GetMarker(out mark2, start: false);
		}
		else
		{
			mark2 = default;
			document.CharIndexToLineTag(end, out var line_out2, out var tag_out2, out var pos2);
			mark2.line = line_out2;
			mark2.tag = tag_out2;
			mark2.pos = pos2;
		}
		if (document.Find(str, mark, mark2, out var result, options))
		{
			return document.LineTagToCharIndex(result.line, result.pos);
		}
		return -1;
	}

	public int Find(string str, int start, RichTextBoxFinds options)
	{
		return Find(str, start, -1, options);
	}

	public int Find(string str, RichTextBoxFinds options)
	{
		return Find(str, -1, -1, options);
	}

	internal override char GetCharFromPositionInternal(Point p)
	{
		PointToTagPos(p, out var tag, out var pos);
		if (pos >= tag.Line.text.Length)
		{
			return '\n';
		}
		return tag.Line.text[pos];
	}

	public override int GetCharIndexFromPosition(Point pt)
	{
		PointToTagPos(pt, out var tag, out var pos);
		return document.LineTagToCharIndex(tag.Line, pos);
	}

	public override int GetLineFromCharIndex(int index)
	{
		document.CharIndexToLineTag(index, out var line_out, out var _, out var _);
		return line_out.LineNo - 1;
	}

	public override Point GetPositionFromCharIndex(int index)
	{
		document.CharIndexToLineTag(index, out var line_out, out var _, out var pos);
		return new Point(line_out.X + (int)line_out.widths[pos] + document.OffsetX - document.ViewPortX, line_out.Y + document.OffsetY - document.ViewPortY);
	}

	public void LoadFile(Stream data, RichTextBoxStreamType fileType)
	{
		document.Empty();
		if (fileType == RichTextBoxStreamType.PlainText)
		{
			StringBuilder stringBuilder;
			char[] array;
			try
			{
				stringBuilder = new StringBuilder((int)data.Length);
				array = new char[1024];
			}
			catch
			{
				throw new IOException("Not enough memory to load document");
			}
			StreamReader streamReader = new StreamReader(data, Encoding.Default, detectEncodingFromByteOrderMarks: true);
			for (int num = streamReader.Read(array, 0, array.Length); num > 0; num = streamReader.Read(array, 0, array.Length))
			{
				stringBuilder.Append(array, 0, num);
			}
			if (stringBuilder.Length > 0 && stringBuilder[stringBuilder.Length - 1] == '\n')
			{
				stringBuilder.Remove(stringBuilder.Length - 1, 1);
			}
			base.Text = stringBuilder.ToString();
		}
		else
		{
			InsertRTFFromStream(data, 0, 1);
			document.PositionCaret(document.GetLine(1), 0);
			document.SetSelectionToCaret(start: true);
			ScrollToCaret();
		}
	}

	public void LoadFile(string path)
	{
		LoadFile(path, RichTextBoxStreamType.RichText);
	}

	public void LoadFile(string path, RichTextBoxStreamType fileType)
	{
		FileStream fileStream = null;
		try
		{
			fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 1024);
			LoadFile(fileStream, fileType);
		}
		catch (Exception innerException)
		{
			throw new IOException("Could not open file " + path, innerException);
		}
		finally
		{
			fileStream?.Close();
		}
	}

	public void Paste(DataFormats.Format clipFormat)
	{
		Paste(Clipboard.GetDataObject(), clipFormat, obey_length: false);
	}

	public void Redo()
	{
		if (document.undo.Redo())
		{
			OnTextChanged(EventArgs.Empty);
		}
	}

	public void SaveFile(Stream data, RichTextBoxStreamType fileType)
	{
		Encoding encoding = ((fileType != RichTextBoxStreamType.UnicodePlainText) ? Encoding.ASCII : Encoding.Unicode);
		byte[] bytes;
		if (fileType == RichTextBoxStreamType.PlainText || (uint)(fileType - 3) <= 1u)
		{
			if (!Multiline)
			{
				bytes = encoding.GetBytes(document.Root.text.ToString());
				data.Write(bytes, 0, bytes.Length);
				return;
			}
			for (int i = 1; i < document.Lines; i++)
			{
				string s = document.GetLine(i).TextWithoutEnding() + Environment.NewLine;
				bytes = encoding.GetBytes(s);
				data.Write(bytes, 0, bytes.Length);
			}
			bytes = encoding.GetBytes(document.GetLine(document.Lines).text.ToString());
			data.Write(bytes, 0, bytes.Length);
			return;
		}
		Line line = document.GetLine(1);
		Line line2 = document.GetLine(document.Lines);
		StringBuilder stringBuilder = GenerateRTF(line, 0, line2, line2.text.Length);
		int length = stringBuilder.Length;
		bytes = new byte[4096];
		for (int i = 0; i < length; i += 1024)
		{
			int bytes2;
			if (i + 1024 < length)
			{
				bytes2 = encoding.GetBytes(stringBuilder.ToString(i, 1024), 0, 1024, bytes, 0);
			}
			else
			{
				bytes2 = length - i;
				bytes2 = encoding.GetBytes(stringBuilder.ToString(i, bytes2), 0, bytes2, bytes, 0);
			}
			data.Write(bytes, 0, bytes2);
		}
	}

	public void SaveFile(string path)
	{
		if (path.EndsWith(".rtf"))
		{
			SaveFile(path, RichTextBoxStreamType.RichText);
		}
		else
		{
			SaveFile(path, RichTextBoxStreamType.PlainText);
		}
	}

	public void SaveFile(string path, RichTextBoxStreamType fileType)
	{
		FileStream fileStream = null;
		fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024, useAsync: false);
		SaveFile(fileStream, fileType);
		fileStream?.Close();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new void DrawToBitmap(Bitmap bitmap, Rectangle targetBounds)
	{
		using Graphics g = Graphics.FromImage(bitmap);
		Draw(g, targetBounds);
	}

	protected virtual object CreateRichEditOleCallback()
	{
		throw new NotImplementedException();
	}

	protected override void OnBackColorChanged(EventArgs e)
	{
		base.OnBackColorChanged(e);
	}

	protected virtual void OnContentsResized(ContentsResizedEventArgs e)
	{
		((ContentsResizedEventHandler)base.Events[ContentsResizedEvent])?.Invoke(this, e);
	}

	protected override void OnContextMenuChanged(EventArgs e)
	{
		base.OnContextMenuChanged(e);
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
	}

	protected override void OnHandleDestroyed(EventArgs e)
	{
		base.OnHandleDestroyed(e);
	}

	protected virtual void OnHScroll(EventArgs e)
	{
		((EventHandler)base.Events[HScrollEvent])?.Invoke(this, e);
	}

	[System.MonoTODO("Stub, never called")]
	protected virtual void OnImeChange(EventArgs e)
	{
		((EventHandler)base.Events[ImeChangeEvent])?.Invoke(this, e);
	}

	protected virtual void OnLinkClicked(LinkClickedEventArgs e)
	{
		((LinkClickedEventHandler)base.Events[LinkClickedEvent])?.Invoke(this, e);
	}

	protected virtual void OnProtected(EventArgs e)
	{
		((EventHandler)base.Events[ProtectedEvent])?.Invoke(this, e);
	}

	protected override void OnRightToLeftChanged(EventArgs e)
	{
		base.OnRightToLeftChanged(e);
	}

	protected virtual void OnSelectionChanged(EventArgs e)
	{
		((EventHandler)base.Events[SelectionChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnVScroll(EventArgs e)
	{
		((EventHandler)base.Events[VScrollEvent])?.Invoke(this, e);
	}

	protected override void WndProc(ref Message m)
	{
		base.WndProc(ref m);
	}

	protected override bool ProcessCmdKey(ref Message m, Keys keyData)
	{
		return base.ProcessCmdKey(ref m, keyData);
	}

	internal override void SelectWord()
	{
		document.ExpandSelection(CaretSelection.Word, to_caret: false);
	}

	private void HandleGroup(System.Windows.Forms.RTF.RTF rtf)
	{
		if (rtf_section_stack == null)
		{
			rtf_section_stack = new Stack();
		}
		if (rtf.Major == Major.BeginGroup)
		{
			rtf_section_stack.Push(rtf_style.Clone());
			rtf_skip_count = 0;
		}
		else if (rtf.Major == Major.EndGroup && rtf_section_stack.Count > 0)
		{
			FlushText(rtf, newline: false);
			rtf_style = (RtfSectionStyle)rtf_section_stack.Pop();
		}
	}

	[System.MonoInternalNote("Add QuadJust support for justified alignment")]
	private void HandleControl(System.Windows.Forms.RTF.RTF rtf)
	{
		switch (rtf.Major)
		{
		case Major.Unicode:
			switch (rtf.Minor)
			{
			case Minor.UnicodeCharBytes:
				rtf_style.rtf_skip_width = rtf.Param;
				break;
			case Minor.UnicodeChar:
				FlushText(rtf, newline: false);
				rtf_skip_count += rtf_style.rtf_skip_width;
				rtf_line.Append((char)rtf.Param);
				break;
			}
			break;
		case Major.Destination:
			rtf.SkipGroup();
			break;
		case Major.PictAttr:
			if (rtf.Picture != null && rtf.Picture.IsValid())
			{
				FlushText(rtf, newline: false, force: true);
				Line line = document.GetLine(rtf_cursor_y);
				document.InsertPicture(line, rtf_cursor_x++, rtf.Picture);
				rtf.Picture = null;
			}
			break;
		case Major.CharAttr:
			switch (rtf.Minor)
			{
			case Minor.ForeColor:
			{
				System.Windows.Forms.RTF.Color color2 = System.Windows.Forms.RTF.Color.GetColor(rtf, rtf.Param);
				if (color2 != null)
				{
					FlushText(rtf, newline: false);
					if (color2.Red == -1 && color2.Green == -1 && color2.Blue == -1)
					{
						rtf_style.rtf_color = ForeColor;
					}
					else
					{
						rtf_style.rtf_color = System.Drawing.Color.FromArgb(color2.Red, color2.Green, color2.Blue);
					}
					FlushText(rtf, newline: false);
				}
				break;
			}
			case Minor.BackColor:
			{
				System.Windows.Forms.RTF.Color color = System.Windows.Forms.RTF.Color.GetColor(rtf, rtf.Param);
				if (color != null)
				{
					FlushText(rtf, newline: false);
					if (color.Red == -1 && color.Green == -1 && color.Blue == -1)
					{
						rtf_style.rtf_back_color = BackColor;
					}
					else
					{
						rtf_style.rtf_back_color = System.Drawing.Color.FromArgb(color.Red, color.Green, color.Blue);
					}
					FlushText(rtf, newline: false);
				}
				break;
			}
			case Minor.FontSize:
				FlushText(rtf, newline: false);
				rtf_style.rtf_rtffont_size = (float)rtf.Param / 2f;
				break;
			case Minor.FontNum:
			{
				System.Windows.Forms.RTF.Font font = System.Windows.Forms.RTF.Font.GetFont(rtf, rtf.Param);
				if (font != null)
				{
					FlushText(rtf, newline: false);
					rtf_style.rtf_rtffont = font;
				}
				break;
			}
			case Minor.Plain:
				FlushText(rtf, newline: false);
				rtf_style.rtf_rtfstyle = FontStyle.Regular;
				break;
			case Minor.Bold:
				FlushText(rtf, newline: false);
				if (rtf.Param == -1000000)
				{
					rtf_style.rtf_rtfstyle |= FontStyle.Bold;
				}
				else
				{
					rtf_style.rtf_rtfstyle &= ~FontStyle.Bold;
				}
				break;
			case Minor.Italic:
				FlushText(rtf, newline: false);
				if (rtf.Param == -1000000)
				{
					rtf_style.rtf_rtfstyle |= FontStyle.Italic;
				}
				else
				{
					rtf_style.rtf_rtfstyle &= ~FontStyle.Italic;
				}
				break;
			case Minor.StrikeThru:
				FlushText(rtf, newline: false);
				if (rtf.Param == -1000000)
				{
					rtf_style.rtf_rtfstyle |= FontStyle.Strikeout;
				}
				else
				{
					rtf_style.rtf_rtfstyle &= ~FontStyle.Strikeout;
				}
				break;
			case Minor.Underline:
				FlushText(rtf, newline: false);
				if (rtf.Param == -1000000)
				{
					rtf_style.rtf_rtfstyle |= FontStyle.Underline;
				}
				else
				{
					rtf_style.rtf_rtfstyle &= ~FontStyle.Underline;
				}
				break;
			case Minor.Invisible:
				FlushText(rtf, newline: false);
				rtf_style.rtf_visible = rtf.Param != -1000000;
				break;
			case Minor.NoUnderline:
				FlushText(rtf, newline: false);
				rtf_style.rtf_rtfstyle &= ~FontStyle.Underline;
				break;
			case Minor.SuperScrShrink:
				FlushText(rtf, newline: false);
				rtf_style.rtf_text_position = TextPositioning.Superscript;
				break;
			case Minor.SubScrShrink:
				FlushText(rtf, newline: false);
				rtf_style.rtf_text_position = TextPositioning.Subscript;
				break;
			case Minor.NoSuperSub:
				FlushText(rtf, newline: false);
				rtf_style.rtf_text_position = TextPositioning.Normal;
				break;
			case Minor.SuperScript:
				FlushText(rtf, newline: false);
				rtf_style.rtf_char_offset = (float)rtf.Param / 144f * document.Dpi;
				break;
			case Minor.SubScript:
				FlushText(rtf, newline: false);
				rtf_style.rtf_char_offset = (0f - (float)rtf.Param / 144f) * document.Dpi;
				break;
			case Minor.AllCaps:
			case Minor.Deleted:
			case Minor.Expand:
			case Minor.ExpandTwips:
			case Minor.Kerning:
			case Minor.Outline:
			case Minor.Revised:
			case Minor.RevAuthor:
			case Minor.RevDTTM:
			case Minor.SmallCaps:
			case Minor.Shadow:
			case Minor.DotUnderline:
			case Minor.DbUnderline:
			case Minor.WordUnderline:
				break;
			}
			break;
		case Major.ParAttr:
			switch (rtf.Minor)
			{
			case Minor.ParDef:
				FlushText(rtf, newline: false);
				rtf_style.rtf_par_line_left_indent = 0f;
				rtf_style.rtf_par_first_line_indent = 0f;
				rtf_style.rtf_par_line_right_indent = 0f;
				rtf_style.rtf_par_spacing_after = 0f;
				rtf_style.rtf_par_spacing_before = 0f;
				rtf_style.rtf_par_line_spacing = 0f;
				rtf_style.rtf_par_line_spacing_multiple = false;
				rtf_style.rtf_par_align = HorizontalAlignment.Left;
				rtf_style.rtf_par_next_tab_stop = null;
				rtf_style.rtf_par_tab_stops.Clear();
				break;
			case Minor.TabLeft:
				rtf_style.rtf_par_next_tab_stop = new LeftTabStop();
				break;
			case Minor.TabCenter:
				rtf_style.rtf_par_next_tab_stop = new CentredTabStop();
				break;
			case Minor.TabRight:
				rtf_style.rtf_par_next_tab_stop = new RightTabStop();
				break;
			case Minor.TabDecimal:
				rtf_style.rtf_par_next_tab_stop = new DecimalTabStop();
				break;
			case Minor.TabPos:
			{
				float position = (float)rtf.Param / 1440f * document.Dpi;
				if (rtf_style.rtf_par_next_tab_stop != null)
				{
					rtf_style.rtf_par_next_tab_stop.Position = position;
					rtf_style.rtf_par_tab_stops.Add(rtf_style.rtf_par_next_tab_stop);
					rtf_style.rtf_par_next_tab_stop = null;
				}
				else
				{
					rtf_style.rtf_par_tab_stops.Add(new LeftTabStop(position));
				}
				break;
			}
			case Minor.LeftIndent:
				rtf_style.rtf_par_line_left_indent = (float)rtf.Param / 1440f * document.Dpi;
				break;
			case Minor.FirstIndent:
				rtf_style.rtf_par_first_line_indent = (float)rtf.Param / 1440f * document.Dpi;
				break;
			case Minor.RightIndent:
				rtf_style.rtf_par_line_right_indent = (float)rtf.Param / 1440f * document.Dpi;
				break;
			case Minor.QuadCenter:
				FlushText(rtf, newline: false);
				rtf_style.rtf_par_align = HorizontalAlignment.Center;
				break;
			case Minor.QuadJust:
				FlushText(rtf, newline: false);
				rtf_style.rtf_par_align = HorizontalAlignment.Left;
				break;
			case Minor.QuadLeft:
				FlushText(rtf, newline: false);
				rtf_style.rtf_par_align = HorizontalAlignment.Left;
				break;
			case Minor.QuadRight:
				FlushText(rtf, newline: false);
				rtf_style.rtf_par_align = HorizontalAlignment.Right;
				break;
			case Minor.SpaceAfter:
				rtf_style.rtf_par_spacing_after = (float)rtf.Param / 1440f * document.Dpi;
				break;
			case Minor.SpaceBefore:
				rtf_style.rtf_par_spacing_before = (float)rtf.Param / 1440f * document.Dpi;
				break;
			case Minor.SpaceBetween:
				rtf_style.rtf_par_line_spacing = (float)rtf.Param / 1440f * document.Dpi;
				break;
			case Minor.SpaceMultiply:
				rtf_style.rtf_par_line_spacing_multiple = rtf.Param == 1;
				break;
			case Minor.StyleNum:
			case Minor.Hyphenate:
			case Minor.InTable:
			case Minor.Keep:
			case Minor.NoWidowControl:
			case Minor.KeepNext:
			case Minor.OutlineLevel:
			case Minor.NoLineNum:
			case Minor.PBBefore:
			case Minor.SideBySide:
			case Minor.SubDocument:
			case Minor.RTLPar:
			case Minor.LTRPar:
				break;
			}
			break;
		case Major.SpecialChar:
			SpecialChar(rtf);
			break;
		}
	}

	private void SpecialChar(System.Windows.Forms.RTF.RTF rtf)
	{
		switch (rtf.Minor)
		{
		default:
			_ = 205;
			break;
		case Minor.Row:
		case Minor.Par:
		case Minor.Sect:
		case Minor.Page:
		case Minor.Line:
			if (Multiline)
			{
				FlushText(rtf, newline: true);
			}
			break;
		case Minor.Cell:
			Console.Write(" ");
			break;
		case Minor.NoBrkSpace:
			Console.Write(" ");
			break;
		case Minor.Tab:
			rtf_line.Append("\t");
			break;
		case Minor.NoReqHyphen:
		case Minor.NoBrkHyphen:
			rtf_line.Append("-");
			break;
		case Minor.Bullet:
			Console.WriteLine("*");
			break;
		case Minor.EmDash:
			rtf_line.Append("—");
			break;
		case Minor.EnDash:
			rtf_line.Append("–");
			break;
		case Minor.LQuote:
			rtf_line.Append("‘");
			break;
		case Minor.RQuote:
			rtf_line.Append("’");
			break;
		case Minor.LDblQuote:
			rtf_line.Append("“");
			break;
		case Minor.RDblQuote:
			rtf_line.Append("”");
			break;
		case Minor.Column:
		case Minor.SoftPage:
		case Minor.SoftColumn:
		case Minor.SoftLine:
		case Minor.SoftLineHt:
		case Minor.EmSpace:
		case Minor.EnSpace:
		case Minor.Formula:
			break;
		}
	}

	private void HandleText(System.Windows.Forms.RTF.RTF rtf)
	{
		string text = rtf.EncodedText;
		if (rtf_skip_count > 0 && text.Length > 0)
		{
			int num = Math.Min(rtf_skip_count, text.Length);
			text = text.Substring(num);
			rtf_skip_count -= num;
		}
		rtf_line.Append(text);
	}

	private void FlushText(System.Windows.Forms.RTF.RTF rtf, bool newline)
	{
		FlushText(rtf, newline, force: false);
	}

	private void FlushText(System.Windows.Forms.RTF.RTF rtf, bool newline, bool force)
	{
		int length = rtf_line.Length;
		if (!newline && length == 0 && !force)
		{
			return;
		}
		if (rtf_style.rtf_rtffont == null)
		{
			rtf_style.rtf_rtffont = System.Windows.Forms.RTF.Font.GetFont(rtf, 0);
		}
		System.Drawing.Font font = new System.Drawing.Font(rtf_style.rtf_rtffont.Name, rtf_style.rtf_rtffont_size, rtf_style.rtf_rtfstyle);
		if (font.Name != rtf_style.rtf_rtffont.Name && !string.IsNullOrEmpty(rtf_style.rtf_rtffont.AltName))
		{
			font = new System.Drawing.Font(rtf_style.rtf_rtffont.AltName, rtf_style.rtf_rtffont_size, rtf_style.rtf_rtfstyle);
		}
		float num = 0f - rtf_style.rtf_par_first_line_indent;
		float num2 = rtf_style.rtf_par_line_left_indent - num;
		if (rtf_style.rtf_color == System.Drawing.Color.Empty)
		{
			System.Windows.Forms.RTF.Color color = System.Windows.Forms.RTF.Color.GetColor(rtf, 0);
			if (color == null || (color.Red == -1 && color.Green == -1 && color.Blue == -1))
			{
				rtf_style.rtf_color = ForeColor;
			}
			else
			{
				rtf_style.rtf_color = System.Drawing.Color.FromArgb(color.Red, color.Green, color.Blue);
			}
		}
		rtf_chars += rtf_line.Length;
		if (rtf_cursor_x == 0 && !reuse_line)
		{
			if (newline && !rtf_line.ToString().EndsWith(Environment.NewLine))
			{
				rtf_line.Append(Environment.NewLine);
			}
			document.Add(rtf_cursor_y, rtf_line.ToString(), rtf_style.rtf_par_align, font, rtf_style.rtf_color, rtf_style.rtf_back_color, rtf_style.rtf_text_position, rtf_style.rtf_char_offset, num2, num, rtf_style.rtf_par_line_right_indent, rtf_style.rtf_par_spacing_before, rtf_style.rtf_par_spacing_after, rtf_style.rtf_par_line_spacing, rtf_style.rtf_par_line_spacing_multiple, rtf_style.rtf_par_tab_stops.Clone(), rtf_style.rtf_visible, newline ? LineEnding.Rich : LineEnding.None);
		}
		else
		{
			Line line = document.GetLine(rtf_cursor_y);
			if (newline)
			{
				if (rtf_cursor_x < line.text.Length)
				{
					document.Split(line, rtf_cursor_x);
				}
				line.ending = LineEnding.Rich;
			}
			line.indent = num2;
			line.HangingIndent = num;
			line.right_indent = rtf_style.rtf_par_line_right_indent;
			line.spacing_after = rtf_style.rtf_par_spacing_after;
			line.spacing_before = rtf_style.rtf_par_spacing_before;
			line.line_spacing = rtf_style.rtf_par_line_spacing;
			line.line_spacing_multiple = rtf_style.rtf_par_line_spacing_multiple;
			line.alignment = rtf_style.rtf_par_align;
			if (rtf_line.Length > 0)
			{
				document.InsertString(line, rtf_cursor_x, rtf_line.ToString());
				document.FormatText(line, rtf_cursor_x + 1, line, rtf_cursor_x + 1 + length, font, rtf_style.rtf_color, rtf_style.rtf_back_color, rtf_style.rtf_text_position, rtf_style.rtf_char_offset, rtf_style.rtf_visible, FormatSpecified.All);
			}
			if (newline && !line.Text.EndsWith(Environment.NewLine))
			{
				line.Text += Environment.NewLine;
			}
			reuse_line = false;
		}
		if (newline)
		{
			rtf_cursor_x = 0;
			rtf_cursor_y++;
		}
		else
		{
			rtf_cursor_x += length;
		}
		rtf_line.Length = 0;
	}

	private void InsertRTFFromStream(Stream data, int cursor_x, int cursor_y)
	{
		InsertRTFFromStream(data, cursor_x, cursor_y, out var _, out var _, out var _);
	}

	private void InsertRTFFromStream(Stream data, int cursor_x, int cursor_y, out int to_x, out int to_y, out int chars)
	{
		System.Windows.Forms.RTF.RTF rTF = new System.Windows.Forms.RTF.RTF(data);
		rTF.ClassCallback[TokenClass.Text] = HandleText;
		rTF.ClassCallback[TokenClass.Control] = HandleControl;
		rTF.ClassCallback[TokenClass.Group] = HandleGroup;
		rtf_skip_count = 0;
		rtf_line = new StringBuilder();
		rtf_style.rtf_color = System.Drawing.Color.Empty;
		rtf_style.rtf_back_color = System.Drawing.Color.Empty;
		rtf_style.rtf_rtffont_size = (int)Font.Size;
		rtf_style.rtf_par_align = HorizontalAlignment.Left;
		rtf_style.rtf_rtfstyle = FontStyle.Regular;
		rtf_style.rtf_text_position = TextPositioning.Normal;
		rtf_style.rtf_par_spacing_after = 0f;
		rtf_style.rtf_par_spacing_before = 0f;
		rtf_style.rtf_par_line_spacing = 0f;
		rtf_style.rtf_par_line_spacing_multiple = false;
		rtf_style.rtf_par_line_left_indent = 0f;
		rtf_style.rtf_par_first_line_indent = 0f;
		rtf_style.rtf_par_line_right_indent = 0f;
		rtf_style.rtf_par_tab_stops.Clear();
		rtf_style.rtf_char_offset = 0f;
		rtf_style.rtf_rtffont = null;
		rtf_style.rtf_visible = true;
		rtf_style.rtf_skip_width = 1;
		rtf_cursor_x = cursor_x;
		rtf_cursor_y = cursor_y;
		rtf_chars = 0;
		rTF.DefaultFont(Font.Name);
		document.SuspendRecalc();
		try
		{
			rTF.Read();
			FlushText(rTF, newline: false);
			if (document.Lines > 1)
			{
				Line line = document.GetLine(document.Lines);
				if (line.text.Length == 0)
				{
					document.Delete(line);
				}
			}
		}
		catch (RTFException ex)
		{
			Console.WriteLine("RTF Parsing failure: {0}", ex.Message);
		}
		to_x = rtf_cursor_x;
		to_y = rtf_cursor_y;
		chars = rtf_chars;
		if (rtf_section_stack != null)
		{
			rtf_section_stack.Clear();
		}
		if (base.IsHandleCreated)
		{
			CalculateScrollBars();
			using (Graphics g = CreateGraphics())
			{
				document.RecalculateDocument(g, cursor_y, document.Lines, optimize: false);
			}
			document.ResumeRecalc(immediate_update: true);
			document.InvalidateLinesAfter(document.GetLine(cursor_y));
		}
		else
		{
			document.ResumeRecalc(immediate_update: false);
		}
	}

	private void RichTextBox_HScrolled(object sender, EventArgs e)
	{
		OnHScroll(e);
	}

	private void RichTextBox_VScrolled(object sender, EventArgs e)
	{
		OnVScroll(e);
	}

	private void PointToTagPos(Point pt, out LineTag tag, out int pos)
	{
		Point point = pt;
		if (point.X >= document.ViewPortWidth)
		{
			point.X = document.ViewPortWidth - 1;
		}
		else if (point.X < 0)
		{
			point.X = 0;
		}
		if (point.Y >= document.ViewPortHeight)
		{
			point.Y = document.ViewPortHeight - 1;
		}
		else if (point.Y < 0)
		{
			point.Y = 0;
		}
		tag = document.FindCursor(point.X + document.ViewPortX, point.Y + document.ViewPortY, out pos);
	}

	private void EmitRTFFontProperties(StringBuilder rtf, int prev_index, int font_index, System.Drawing.Font prev_font, System.Drawing.Font font)
	{
		if (prev_index != font_index)
		{
			rtf.Append($"\\f{font_index}");
		}
		if (prev_font == null || (double)Math.Abs(prev_font.Size - font.Size) > 0.01)
		{
			rtf.Append($"\\fs{(int)(font.Size * 2f)}");
		}
		if (prev_font == null || font.Bold != prev_font.Bold)
		{
			if (font.Bold)
			{
				rtf.Append("\\b");
			}
			else if (prev_font != null)
			{
				rtf.Append("\\b0");
			}
		}
		if (prev_font == null || font.Italic != prev_font.Italic)
		{
			if (font.Italic)
			{
				rtf.Append("\\i");
			}
			else if (prev_font != null)
			{
				rtf.Append("\\i0");
			}
		}
		if (prev_font == null || font.Strikeout != prev_font.Strikeout)
		{
			if (font.Strikeout)
			{
				rtf.Append("\\strike");
			}
			else if (prev_font != null)
			{
				rtf.Append("\\strike0");
			}
		}
		if (prev_font == null || font.Underline != prev_font.Underline)
		{
			if (font.Underline)
			{
				rtf.Append("\\ul");
			}
			else if (prev_font != null)
			{
				rtf.Append("\\ul0");
			}
		}
	}

	private void EmitRTFText(StringBuilder rtf, string text)
	{
		_ = rtf.Length;
		_ = text.Length;
		if (text.IndexOfAny(ReservedRTFChars) > -1)
		{
			StringBuilder stringBuilder = new StringBuilder(text);
			stringBuilder.Replace("\\", "\\\\");
			stringBuilder.Replace("{", "\\{");
			stringBuilder.Replace("}", "\\}");
			text = stringBuilder.ToString();
		}
		EmitEscapedUnicode(rtf, text);
	}

	private void EmitEscapedUnicode(StringBuilder sb, string text)
	{
		int num = 0;
		int num2;
		while ((num2 = IndexOfNonAscii(text, num)) > -1)
		{
			sb.Append(text, num, num2 - num);
			short num3 = (short)text[num2];
			sb.Append("\\u");
			sb.Append(num3.ToString());
			sb.Append("?");
			num = num2 + 1;
		}
		if (num < text.Length)
		{
			sb.Append(text, num, text.Length - num);
		}
	}

	private int IndexOfNonAscii(string text, int startIndex)
	{
		for (int i = startIndex; i < text.Length; i++)
		{
			int num = text[i];
			if (num < 0 || num >= 128)
			{
				return i;
			}
		}
		return -1;
	}

	private static char[] GetHexChars(byte[] bytes, int length)
	{
		if (length > bytes.Length)
		{
			throw new ArgumentOutOfRangeException("length");
		}
		char[] array = new char[length * 2];
		for (int i = 0; i < length; i++)
		{
			int num = bytes[i] >> 4;
			array[i * 2] = (char)(55 + num + ((num - 10 >> 31) & -7));
			num = bytes[i] & 0xF;
			array[i * 2 + 1] = (char)(55 + num + ((num - 10 >> 31) & -7));
		}
		return array;
	}

	private void EmitRtfPicture(PictureTag picture, StringBuilder sb)
	{
		if (picture.picture.IsValid())
		{
			int num = (int)(picture.picture.Width / document.Dpi * 1440f);
			int num2 = (int)(picture.picture.Height / document.Dpi * 1440f);
			string arg = "";
			switch (picture.picture.ImageType)
			{
			case Minor.WinMetafile:
				arg = "wmetafile1";
				break;
			case Minor.EnhancedMetafile:
				arg = "emfblip";
				break;
			case Minor.PngBlip:
				arg = "pngblip";
				break;
			case Minor.JpegBlip:
				arg = "jpegblip";
				break;
			}
			sb.AppendFormat("{{\\pict\\{0}\\picwgoal{1}\\pichgoal{2} ", arg, num, num2);
			MemoryStream data = picture.picture.Data;
			data.Position = 0L;
			if (sb.Capacity - sb.Length < data.Length)
			{
				sb.Capacity += (int)data.Length * 2;
			}
			byte[] array = new byte[39];
			int length;
			while ((length = data.Read(array, 0, array.Length)) > 0)
			{
				sb.AppendLine().Append(GetHexChars(array, length));
			}
			sb.Append("}");
		}
	}

	private void EmitTabStops(StringBuilder sb, TabStopCollection tabs)
	{
		foreach (TabStop tab in tabs)
		{
			if (tab is DecimalTabStop)
			{
				sb.Append("\\tqdec");
			}
			else if (tab is CentredTabStop)
			{
				sb.Append("\\tqc");
			}
			else if (tab is RightTabStop)
			{
				sb.Append("\\tqr");
			}
			sb.Append("\\tx");
			sb.Append(Int(tab.Position / document.Dpi * 1440f));
		}
	}

	private void EmitPard(StringBuilder sb, ArrayList fonts, Line line, LineTag tag, TabStopCollection tabs, float ppt)
	{
		float num = 0f - line.HangingIndent;
		float num2 = line.Indent - num;
		float rightIndent = line.RightIndent;
		sb.Append("\\pard");
		switch (line.alignment)
		{
		case HorizontalAlignment.Left:
			sb.Append("\\ql");
			break;
		case HorizontalAlignment.Center:
			sb.Append("\\qc");
			break;
		case HorizontalAlignment.Right:
			sb.Append("\\qr");
			break;
		}
		if (Math.Abs(line.spacing_after) > ppt)
		{
			sb.Append("\\sa");
			sb.Append(Int(line.spacing_after / ppt));
		}
		if (Math.Abs(line.spacing_before) > ppt)
		{
			sb.Append("\\sb");
			sb.Append(Int(line.spacing_before / ppt));
		}
		if (Math.Abs(line.line_spacing) > ppt)
		{
			sb.Append("\\sl");
			sb.Append(Int(line.line_spacing / ppt));
			sb.Append("\\slmult");
			sb.Append(line.line_spacing_multiple ? "1" : "0");
		}
		if (Math.Abs(num2) > ppt)
		{
			sb.Append("\\li");
			sb.Append(Int(num2 / ppt));
		}
		if (Math.Abs(num) > ppt)
		{
			sb.Append("\\fi");
			sb.Append(Int(num / ppt));
		}
		if (Math.Abs(rightIndent) > ppt)
		{
			sb.Append("\\ri");
			sb.Append(Int(rightIndent / ppt));
		}
		if (tabs.Count > 0)
		{
			EmitTabStops(sb, tabs);
		}
	}

	private static void LoadParaSettings(Line line, out HorizontalAlignment line_alignment, out float spacing_after, out float spacing_before, out float line_spacing, out bool line_spacing_multiple, out float left_indent, out float prev_left_indent, out float first_line_indent, out float prev_first_line_indent, out float right_indent, out TabStopCollection tabs)
	{
		spacing_after = line.spacing_after;
		spacing_before = line.spacing_before;
		line_spacing = line.line_spacing;
		line_spacing_multiple = line.line_spacing_multiple;
		line_alignment = line.alignment;
		first_line_indent = 0f - line.HangingIndent;
		left_indent = line.Indent - first_line_indent;
		prev_first_line_indent = first_line_indent;
		prev_left_indent = left_indent;
		right_indent = line.RightIndent;
		tabs = line.TabStops;
	}

	private StringBuilder GenerateRTF(Line start_line, int start_pos, Line end_line, int end_pos)
	{
		float num = document.Dpi / 1440f;
		bool flag = false;
		StringBuilder stringBuilder = new StringBuilder();
		ArrayList arrayList = new ArrayList(10);
		ArrayList arrayList2 = new ArrayList(10);
		TabStopCollection tabStopCollection = new TabStopCollection();
		Line line = start_line;
		int i = start_line.line_no;
		int num2 = start_pos;
		LineTag lineTag = LineTag.FindTag(start_line, num2);
		System.Drawing.Font font = lineTag.Font;
		System.Drawing.Color color = lineTag.Color;
		System.Drawing.Color color2 = System.Drawing.Color.Empty;
		arrayList.Add(font.Name);
		arrayList2.Add(color);
		for (; i <= end_line.line_no; i++)
		{
			line = document.GetLine(i);
			lineTag = LineTag.FindTag(line, num2);
			int num3 = ((i == end_line.line_no) ? end_pos : line.text.Length);
			while (num2 < num3)
			{
				if (lineTag.Font.Name != font.Name)
				{
					font = lineTag.Font;
					if (!arrayList.Contains(font.Name))
					{
						arrayList.Add(font.Name);
					}
				}
				if (lineTag.Color != color)
				{
					color = lineTag.Color;
					if (color != System.Drawing.Color.Empty && !arrayList2.Contains(color))
					{
						arrayList2.Add(color);
					}
				}
				if (lineTag.BackColor != color2)
				{
					color2 = lineTag.BackColor;
					if (color2 != System.Drawing.Color.Empty && !arrayList2.Contains(color2))
					{
						arrayList2.Add(color2);
					}
				}
				num2 = lineTag.Start + lineTag.Length - 1;
				lineTag = lineTag.Next;
			}
			num2 = 0;
		}
		stringBuilder.Append("{\\rtf1\\ansi");
		stringBuilder.Append("\\ansicpg1252");
		stringBuilder.Append($"\\deff{arrayList.IndexOf(Font.Name)}");
		stringBuilder.Append("\\deflang1033" + Environment.NewLine);
		stringBuilder.Append("{\\fonttbl");
		for (int j = 0; j < arrayList.Count; j++)
		{
			stringBuilder.Append($"{{\\f{j}");
			stringBuilder.Append("\\fnil");
			stringBuilder.Append("\\fcharset0 ");
			stringBuilder.Append((string)arrayList[j]);
			stringBuilder.Append(";}");
		}
		stringBuilder.Append("}");
		stringBuilder.Append(Environment.NewLine);
		if (arrayList2.Count > 1 || ((System.Drawing.Color)arrayList2[0]).R != ForeColor.R || ((System.Drawing.Color)arrayList2[0]).G != ForeColor.G || ((System.Drawing.Color)arrayList2[0]).B != ForeColor.B)
		{
			stringBuilder.Append("{\\colortbl;");
			for (int j = 0; j < arrayList2.Count; j++)
			{
				stringBuilder.Append($"\\red{((System.Drawing.Color)arrayList2[j]).R}");
				stringBuilder.Append($"\\green{((System.Drawing.Color)arrayList2[j]).G}");
				stringBuilder.Append($"\\blue{((System.Drawing.Color)arrayList2[j]).B}");
				stringBuilder.Append(";");
			}
			stringBuilder.Append("}");
			stringBuilder.Append(Environment.NewLine);
		}
		stringBuilder.Append("{\\*\\generator Mono RichTextBox;}");
		lineTag = LineTag.FindTag(start_line, start_pos);
		font = lineTag.Font;
		color = System.Drawing.Color.Empty;
		color2 = System.Drawing.Color.Empty;
		TextPositioning textPositioning = TextPositioning.Normal;
		float num4 = 0f;
		bool flag2 = true;
		line = start_line;
		i = start_line.line_no;
		num2 = start_pos;
		LoadParaSettings(line, out var line_alignment, out var spacing_after, out var spacing_before, out var line_spacing, out var line_spacing_multiple, out var left_indent, out var prev_left_indent, out var first_line_indent, out var prev_first_line_indent, out var right_indent, out var tabs);
		EmitPard(stringBuilder, arrayList, line, lineTag, tabs, num);
		EmitRTFFontProperties(stringBuilder, -1, arrayList.IndexOf(lineTag.Font.Name), null, lineTag.Font);
		stringBuilder.Append(" ");
		for (; i <= end_line.line_no; i++)
		{
			line = document.GetLine(i);
			lineTag = LineTag.FindTag(line, num2);
			int num3 = ((i == end_line.line_no) ? end_pos : line.text.Length);
			int j = 0;
			int num5 = 0;
			tabStopCollection.Clear();
			flag = line.TabStops.Count < tabs.Count;
			while (!flag && j < tabs.Count && num5 < line.TabStops.Count)
			{
				if (tabs[j].Equals(line.TabStops[num5]))
				{
					j++;
					num5++;
				}
				else if (tabs[j].Position - num > line.TabStops[num5].Position)
				{
					tabStopCollection.Add(line.TabStops[num5]);
					num5++;
				}
				else
				{
					flag = true;
				}
			}
			if (j < tabs.Count)
			{
				flag = true;
			}
			while (!flag && num5 < line.TabStops.Count)
			{
				tabStopCollection.Add(line.TabStops[num5]);
				num5++;
			}
			tabs = line.TabStops;
			if (!flag)
			{
				int length = stringBuilder.Length;
				if (line.Alignment != line_alignment)
				{
					line_alignment = line.Alignment;
					switch (line_alignment)
					{
					case HorizontalAlignment.Left:
						stringBuilder.Append("\\ql");
						break;
					case HorizontalAlignment.Center:
						stringBuilder.Append("\\qc");
						break;
					case HorizontalAlignment.Right:
						stringBuilder.Append("\\qr");
						break;
					}
				}
				if (Math.Abs(line.spacing_after - spacing_after) > num)
				{
					spacing_after = line.spacing_after;
					stringBuilder.Append("\\sa");
					stringBuilder.Append(Int(spacing_after / num));
				}
				if (Math.Abs(line.spacing_before - spacing_before) > num)
				{
					spacing_before = line.spacing_before;
					stringBuilder.Append("\\sb");
					stringBuilder.Append(Int(spacing_before / num));
				}
				if (Math.Abs(line.line_spacing - line_spacing) > num)
				{
					line_spacing = line.line_spacing;
					stringBuilder.Append("\\sl");
					stringBuilder.Append(Int(line.line_spacing / num));
				}
				if (line.line_spacing_multiple != line_spacing_multiple)
				{
					line_spacing_multiple = line.line_spacing_multiple;
					stringBuilder.Append("\\slmult");
					stringBuilder.Append(line.line_spacing_multiple ? "1" : "0");
				}
				first_line_indent = 0f - line.HangingIndent;
				left_indent = line.Indent - first_line_indent;
				if (Math.Abs(prev_left_indent - left_indent) > num)
				{
					prev_left_indent = left_indent;
					stringBuilder.Append("\\li");
					stringBuilder.Append(Int(left_indent / num));
				}
				if (Math.Abs(prev_first_line_indent - first_line_indent) > num)
				{
					prev_first_line_indent = first_line_indent;
					stringBuilder.Append("\\fi");
					stringBuilder.Append(Int(first_line_indent / num));
				}
				if (Math.Abs(line.right_indent - right_indent) > num)
				{
					right_indent = line.right_indent;
					stringBuilder.Append("\\ri");
					stringBuilder.Append(Int(right_indent / num));
				}
				if (tabStopCollection.Count > 0)
				{
					EmitTabStops(stringBuilder, tabStopCollection);
				}
				if (length != stringBuilder.Length)
				{
					stringBuilder.Append(" ");
				}
			}
			else
			{
				EmitPard(stringBuilder, arrayList, line, lineTag, tabs, num);
				stringBuilder.Append(" ");
				LoadParaSettings(line, out line_alignment, out spacing_after, out spacing_before, out line_spacing, out line_spacing_multiple, out left_indent, out prev_left_indent, out first_line_indent, out prev_first_line_indent, out right_indent, out tabs);
			}
			while (num2 < num3 && lineTag != null)
			{
				int length = stringBuilder.Length;
				if (lineTag.Font != font)
				{
					EmitRTFFontProperties(stringBuilder, arrayList.IndexOf(font.Name), arrayList.IndexOf(lineTag.Font.Name), font, lineTag.Font);
					font = lineTag.Font;
				}
				if (lineTag.Color != color)
				{
					color = lineTag.Color;
					if (color != System.Drawing.Color.Empty)
					{
						stringBuilder.Append($"\\cf{arrayList2.IndexOf(color) + 1}");
					}
					else
					{
						stringBuilder.Append("\\cf0");
					}
				}
				if (lineTag.BackColor != color2)
				{
					color2 = lineTag.BackColor;
					if (color2 != System.Drawing.Color.Empty)
					{
						stringBuilder.Append($"\\cb{arrayList2.IndexOf(color2) + 1}");
					}
					else
					{
						stringBuilder.Append("\\cb0");
					}
				}
				if (lineTag.TextPosition != textPositioning)
				{
					if (textPositioning != TextPositioning.Normal && lineTag.TextPosition != TextPositioning.Normal)
					{
						stringBuilder.Append("\\nosupersub");
					}
					textPositioning = lineTag.TextPosition;
					switch (lineTag.TextPosition)
					{
					case TextPositioning.Normal:
						stringBuilder.Append("\\nosupersub");
						break;
					case TextPositioning.Subscript:
						stringBuilder.Append("\\sub");
						break;
					case TextPositioning.Superscript:
						stringBuilder.Append("\\super");
						break;
					}
				}
				if (lineTag.CharOffset != num4)
				{
					num4 = lineTag.CharOffset;
					if (num4 >= 0f)
					{
						stringBuilder.Append("\\up");
						stringBuilder.Append(Int(num4 / document.Dpi * 144f));
					}
					else
					{
						stringBuilder.Append("\\dn");
						stringBuilder.Append(-Int(num4 / document.Dpi * 144f));
					}
				}
				if (lineTag.Visible != flag2)
				{
					flag2 = lineTag.Visible;
					if (flag2)
					{
						stringBuilder.Append("\\v0");
					}
					else
					{
						stringBuilder.Append("\\v");
					}
				}
				if (length != stringBuilder.Length)
				{
					stringBuilder.Append(" ");
				}
				if (lineTag is PictureTag)
				{
					EmitRtfPicture((PictureTag)lineTag, stringBuilder);
				}
				else if (i != end_line.line_no)
				{
					EmitRTFText(stringBuilder, lineTag.Line.text.ToString(num2, lineTag.Start + lineTag.Length - num2 - 1));
				}
				else if (end_pos < lineTag.Start + lineTag.Length - 1)
				{
					EmitRTFText(stringBuilder, lineTag.Line.text.ToString(num2, end_pos - num2));
				}
				else
				{
					EmitRTFText(stringBuilder, lineTag.Line.text.ToString(num2, lineTag.Start + lineTag.Length - num2 - 1));
				}
				num2 = lineTag.Start + lineTag.Length - 1;
				do
				{
					lineTag = lineTag.Next;
				}
				while (lineTag != null && lineTag.IsTextTag && lineTag.Length == 0);
			}
			if (num2 >= line.text.Length && line.ending != LineEnding.Wrap)
			{
				if (i != end_line.line_no || num2 <= end_pos)
				{
					stringBuilder.Append("\\par");
				}
				stringBuilder.Append(Environment.NewLine);
			}
			num2 = 0;
		}
		stringBuilder.Append("}");
		stringBuilder.Append(Environment.NewLine);
		return stringBuilder;
	}

	private int Int(float f)
	{
		return (int)(f + 0.5f);
	}
}
