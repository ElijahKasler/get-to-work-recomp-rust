using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Text;
using Unity;

namespace System.Windows.Forms;

[ComVisible(true)]
[DefaultBindingProperty("Text")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[DefaultEvent("TextChanged")]
[Designer("System.Windows.Forms.Design.TextBoxBaseDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
public abstract class TextBoxBase : Control
{
	internal class LinkRectangle
	{
		private Rectangle link_area_rectangle;

		private LineTag link_tag;

		public Rectangle LinkAreaRectangle
		{
			get
			{
				return link_area_rectangle;
			}
			set
			{
				link_area_rectangle = value;
			}
		}

		public LineTag LinkTag
		{
			get
			{
				return link_tag;
			}
			set
			{
				link_tag = value;
			}
		}

		public LinkRectangle(Rectangle rect)
		{
			link_tag = null;
			link_area_rectangle = rect;
		}

		public void Scroll(int x_change, int y_change)
		{
			link_area_rectangle.X += x_change;
			link_area_rectangle.Y += y_change;
		}
	}

	internal HorizontalAlignment alignment;

	internal bool accepts_tab;

	internal bool accepts_return;

	internal bool auto_size;

	internal bool backcolor_set;

	internal CharacterCasing character_casing;

	internal bool hide_selection;

	private int max_length;

	internal bool modified;

	internal char password_char;

	internal bool read_only;

	internal bool word_wrap;

	internal Document document;

	internal LineTag caret_tag;

	internal int caret_pos;

	internal ImplicitHScrollBar hscroll;

	internal ImplicitVScrollBar vscroll;

	internal RichTextBoxScrollBars scrollbars;

	internal Timer scroll_timer;

	internal bool richtext;

	internal bool show_selection;

	internal ArrayList list_links;

	private LinkRectangle current_link;

	private bool enable_links;

	internal bool has_been_focused;

	private bool delayed_font_or_color_change;

	private int requested_height;

	internal int selection_length = -1;

	internal bool show_caret_w_selection;

	internal int canvas_width;

	internal int canvas_height;

	internal static int track_width = 2;

	internal static int track_border = 5;

	internal DateTime click_last;

	internal int click_point_x;

	internal int click_point_y;

	internal CaretSelection click_mode;

	internal BorderStyle actual_border_style = BorderStyle.Fixed3D;

	internal bool shortcuts_enabled = true;

	private static object AcceptsTabChangedEvent = new object();

	private static object AutoSizeChangedEvent = new object();

	private static object BorderStyleChangedEvent = new object();

	private static object HideSelectionChangedEvent = new object();

	private static object ModifiedChangedEvent = new object();

	private static object MultilineChangedEvent = new object();

	private static object ReadOnlyChangedEvent = new object();

	private static object HScrolledEvent = new object();

	private static object VScrolledEvent = new object();

	[MWFCategory("Behavior")]
	[DefaultValue(false)]
	public bool AcceptsTab
	{
		get
		{
			return accepts_tab;
		}
		set
		{
			if (value != accepts_tab)
			{
				accepts_tab = value;
				OnAcceptsTabChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DefaultValue(true)]
	[Localizable(true)]
	[RefreshProperties(RefreshProperties.Repaint)]
	[MWFCategory("Behavior")]
	public override bool AutoSize
	{
		get
		{
			return auto_size;
		}
		set
		{
			if (value != auto_size)
			{
				auto_size = value;
				if (auto_size && PreferredHeight != base.Height)
				{
					base.Height = PreferredHeight;
				}
			}
		}
	}

	[DispId(-501)]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			backcolor_set = true;
			base.BackColor = ChangeBackColor(value);
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

	[MWFCategory("Appearance")]
	[DefaultValue(BorderStyle.Fixed3D)]
	[DispId(-504)]
	public BorderStyle BorderStyle
	{
		get
		{
			return actual_border_style;
		}
		set
		{
			if (value != actual_border_style)
			{
				Invalidate();
				actual_border_style = value;
				document.UpdateMargins();
				if (value != BorderStyle.Fixed3D)
				{
					value = BorderStyle.None;
				}
				base.InternalBorderStyle = value;
				OnBorderStyleChanged(EventArgs.Empty);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool CanUndo => document.undo.CanUndo;

	[DispId(-513)]
	public override Color ForeColor
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

	[DefaultValue(true)]
	[MWFCategory("Behavior")]
	public bool HideSelection
	{
		get
		{
			return hide_selection;
		}
		set
		{
			if (value != hide_selection)
			{
				hide_selection = value;
				OnHideSelectionChanged(EventArgs.Empty);
			}
			document.selection_visible = !hide_selection;
			document.InvalidateSelectionArea();
		}
	}

	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Editor("System.Windows.Forms.Design.StringArrayEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[Localizable(true)]
	[MWFCategory("Appearance")]
	public string[] Lines
	{
		get
		{
			int lines = document.Lines;
			if (lines == 1 && document.GetLine(1).text.Length == 0)
			{
				return new string[0];
			}
			ArrayList arrayList = new ArrayList();
			int num = 1;
			while (num <= lines)
			{
				StringBuilder stringBuilder = new StringBuilder();
				Line line;
				do
				{
					line = document.GetLine(num++);
					stringBuilder.Append(line.TextWithoutEnding());
				}
				while (line.ending == LineEnding.Wrap && num <= lines);
				arrayList.Add(stringBuilder.ToString());
			}
			return (string[])arrayList.ToArray(typeof(string));
		}
		set
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < value.Length && (i != value.Length - 1 || value[i].Length != 0); i++)
			{
				stringBuilder.Append(value[i] + Environment.NewLine);
			}
			int length = Environment.NewLine.Length;
			if (stringBuilder.Length >= length)
			{
				stringBuilder.Remove(stringBuilder.Length - length, length);
			}
			Text = stringBuilder.ToString();
		}
	}

	[Localizable(true)]
	[DefaultValue(32767)]
	[MWFCategory("Behavior")]
	public virtual int MaxLength
	{
		get
		{
			if (max_length == 2147483646)
			{
				return 0;
			}
			return max_length;
		}
		set
		{
			if (value != max_length)
			{
				if (value == 0)
				{
					value = 2147483646;
				}
				max_length = value;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public bool Modified
	{
		get
		{
			return modified;
		}
		set
		{
			if (value != modified)
			{
				modified = value;
				OnModifiedChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(false)]
	[Localizable(true)]
	[RefreshProperties(RefreshProperties.All)]
	[MWFCategory("Behavior")]
	public virtual bool Multiline
	{
		get
		{
			return document.multiline;
		}
		set
		{
			if (value != document.multiline)
			{
				document.multiline = value;
				SetStyle(ControlStyles.FixedHeight, !value);
				FixupHeight();
				if (base.Parent != null)
				{
					base.Parent.PerformLayout();
				}
				OnMultilineChanged(EventArgs.Empty);
			}
			if (document.multiline)
			{
				document.Wrap = word_wrap;
				document.PasswordChar = "";
			}
			else
			{
				document.Wrap = false;
				if (password_char != 0)
				{
					if (this is TextBox)
					{
						document.PasswordChar = (this as TextBox).PasswordChar.ToString();
					}
				}
				else
				{
					document.PasswordChar = "";
				}
			}
			CalculateDocument();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public int PreferredHeight
	{
		get
		{
			int num = base.FontHeight;
			if (BorderStyle != BorderStyle.None)
			{
				num += 7;
			}
			return num;
		}
	}

	[RefreshProperties(RefreshProperties.Repaint)]
	[MWFCategory("Behavior")]
	[DefaultValue(false)]
	public bool ReadOnly
	{
		get
		{
			return read_only;
		}
		set
		{
			if (value == read_only)
			{
				return;
			}
			read_only = value;
			if (!backcolor_set)
			{
				if (read_only)
				{
					background_color = SystemColors.Control;
				}
				else
				{
					background_color = SystemColors.Window;
				}
			}
			OnReadOnlyChanged(EventArgs.Empty);
			Invalidate();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual string SelectedText
	{
		get
		{
			return document.GetSelection();
		}
		set
		{
			if (value == null)
			{
				value = string.Empty;
			}
			document.ReplaceSelection(CaseAdjust(value), select_new: false);
			ScrollToCaret();
			OnTextChanged(EventArgs.Empty);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual int SelectionLength
	{
		get
		{
			return document.SelectionLength();
		}
		set
		{
			if (value < 0)
			{
				string message = $"'{value}' is not a valid value for 'SelectionLength'";
				throw new ArgumentOutOfRangeException("SelectionLength", message);
			}
			document.InvalidateSelectionArea();
			if (value != 0)
			{
				selection_length = value;
				int num = document.LineTagToCharIndex(document.selection_start.line, document.selection_start.pos);
				document.CharIndexToLineTag(num + value, out var line_out, out var _, out var pos);
				document.SetSelectionEnd(line_out, pos, invalidate: true);
				document.PositionCaret(line_out, pos);
			}
			else
			{
				selection_length = -1;
				document.SetSelectionEnd(document.selection_start.line, document.selection_start.pos, invalidate: true);
				document.PositionCaret(document.selection_start.line, document.selection_start.pos);
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int SelectionStart
	{
		get
		{
			return document.LineTagToCharIndex(document.selection_start.line, document.selection_start.pos);
		}
		set
		{
			if (value < 0)
			{
				string message = $"'{value}' is not a valid value for 'SelectionStart'";
				throw new ArgumentOutOfRangeException("SelectionStart", message);
			}
			has_been_focused = true;
			document.InvalidateSelectionArea();
			document.SetSelectionStart(value, invalidate: false);
			if (selection_length > -1)
			{
				document.SetSelectionEnd(value + selection_length, invalidate: true);
			}
			else
			{
				document.SetSelectionEnd(value, invalidate: true);
			}
			document.PositionCaret(document.selection_start.line, document.selection_start.pos);
			ScrollToCaret();
		}
	}

	[DefaultValue(true)]
	public virtual bool ShortcutsEnabled
	{
		get
		{
			return shortcuts_enabled;
		}
		set
		{
			shortcuts_enabled = value;
		}
	}

	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[Localizable(true)]
	public override string Text
	{
		get
		{
			if (document == null || document.Root == null || document.Root.text == null)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			Line line = null;
			for (int i = 1; i <= document.Lines; i++)
			{
				line = document.GetLine(i);
				if (i == document.Lines)
				{
					stringBuilder.Append(line.TextWithoutEnding());
				}
				else
				{
					stringBuilder.Append(line.text.ToString());
				}
			}
			return stringBuilder.ToString();
		}
		set
		{
			has_been_focused = false;
			if (!(value == Text))
			{
				document.Empty();
				if (value != null && value != "")
				{
					document.Insert(document.GetLine(1), 0, update_caret: false, value);
				}
				else if (base.IsHandleCreated)
				{
					document.SetSelectionToCaret(start: true);
					CalculateDocument();
				}
				document.PositionCaret(document.GetLine(1), 0);
				document.SetSelectionToCaret(start: true);
				ScrollToCaret();
				OnTextChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(false)]
	public virtual int TextLength
	{
		get
		{
			if (document == null || document.Root == null || document.Root.text == null)
			{
				return 0;
			}
			return Text.Length;
		}
	}

	[DefaultValue(true)]
	[Localizable(true)]
	[MWFCategory("Behavior")]
	public bool WordWrap
	{
		get
		{
			return word_wrap;
		}
		set
		{
			if (value != word_wrap)
			{
				if (document.multiline)
				{
					word_wrap = value;
					document.Wrap = value;
				}
				CalculateDocument();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
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

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Padding Padding
	{
		get
		{
			return base.Padding;
		}
		set
		{
			base.Padding = value;
		}
	}

	protected override Cursor DefaultCursor => Cursors.IBeam;

	protected override bool CanEnableIme
	{
		get
		{
			if (ReadOnly || password_char != 0)
			{
				return false;
			}
			return true;
		}
	}

	protected override CreateParams CreateParams => base.CreateParams;

	protected override Size DefaultSize => new Size(100, PreferredHeight);

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override bool DoubleBuffered
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	internal Document Document
	{
		get
		{
			return document;
		}
		set
		{
			document = value;
		}
	}

	internal bool EnableLinks
	{
		get
		{
			return enable_links;
		}
		set
		{
			enable_links = value;
			document.EnableLinks = value;
		}
	}

	internal override bool ScaleChildrenInternal => false;

	internal bool ShowSelection
	{
		get
		{
			if (show_selection || !hide_selection)
			{
				return true;
			}
			return has_focus;
		}
		set
		{
			if (show_selection != value)
			{
				show_selection = value;
				document.InvalidateSelectionArea();
			}
		}
	}

	internal int TopMargin
	{
		get
		{
			if (document != null)
			{
				return document.top_margin;
			}
			return 0;
		}
		set
		{
			document.top_margin = value;
		}
	}

	internal ScrollBar UIAHScrollBar => hscroll;

	internal ScrollBar UIAVScrollBar => vscroll;

	protected override ImeMode ImeModeBase
	{
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default;
		}
		set
		{
			Unity.ThrowStub.ThrowNotSupportedException();
		}
	}

	public event EventHandler AcceptsTabChanged
	{
		add
		{
			base.Events.AddHandler(AcceptsTabChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AcceptsTabChangedEvent, value);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler AutoSizeChanged
	{
		add
		{
			base.Events.AddHandler(AutoSizeChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(AutoSizeChangedEvent, value);
		}
	}

	public event EventHandler BorderStyleChanged
	{
		add
		{
			base.Events.AddHandler(BorderStyleChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(BorderStyleChangedEvent, value);
		}
	}

	public event EventHandler HideSelectionChanged
	{
		add
		{
			base.Events.AddHandler(HideSelectionChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(HideSelectionChangedEvent, value);
		}
	}

	public event EventHandler ModifiedChanged
	{
		add
		{
			base.Events.AddHandler(ModifiedChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ModifiedChangedEvent, value);
		}
	}

	public event EventHandler MultilineChanged
	{
		add
		{
			base.Events.AddHandler(MultilineChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MultilineChangedEvent, value);
		}
	}

	public event EventHandler ReadOnlyChanged
	{
		add
		{
			base.Events.AddHandler(ReadOnlyChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ReadOnlyChangedEvent, value);
		}
	}

	internal event EventHandler HScrolled
	{
		add
		{
			base.Events.AddHandler(HScrolledEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(HScrolledEvent, value);
		}
	}

	internal event EventHandler VScrolled
	{
		add
		{
			base.Events.AddHandler(VScrolledEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(VScrolledEvent, value);
		}
	}

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

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public new event MouseEventHandler MouseClick
	{
		add
		{
			base.MouseClick += value;
		}
		remove
		{
			base.MouseClick -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new event EventHandler PaddingChanged
	{
		add
		{
			base.PaddingChanged += value;
		}
		remove
		{
			base.PaddingChanged -= value;
		}
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public new event EventHandler Click
	{
		add
		{
			base.Click += value;
		}
		remove
		{
			base.Click -= value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[System.MonoTODO]
	[Browsable(false)]
	public new event PaintEventHandler Paint;

	internal TextBoxBase()
	{
		alignment = HorizontalAlignment.Left;
		accepts_return = false;
		accepts_tab = false;
		auto_size = true;
		base.InternalBorderStyle = BorderStyle.Fixed3D;
		character_casing = CharacterCasing.Normal;
		hide_selection = true;
		max_length = 32767;
		password_char = '\0';
		read_only = false;
		word_wrap = true;
		richtext = false;
		show_selection = false;
		enable_links = false;
		list_links = new ArrayList();
		current_link = null;
		show_caret_w_selection = this is TextBox;
		document = new Document(this);
		document.SizeChanged += document_SizeChanged;
		document.Wrap = false;
		click_last = DateTime.Now;
		click_mode = CaretSelection.Position;
		base.MouseDown += TextBoxBase_MouseDown;
		base.MouseUp += TextBoxBase_MouseUp;
		base.MouseMove += TextBoxBase_MouseMove;
		base.SizeChanged += TextBoxBase_SizeChanged;
		base.FontChanged += TextBoxBase_FontOrColorChanged;
		base.ForeColorChanged += TextBoxBase_FontOrColorChanged;
		base.MouseWheel += TextBoxBase_MouseWheel;
		base.RightToLeftChanged += TextBoxBase_RightToLeftChanged;
		scrollbars = RichTextBoxScrollBars.None;
		hscroll = new ImplicitHScrollBar();
		hscroll.ValueChanged += hscroll_ValueChanged;
		hscroll.SetStyle(ControlStyles.Selectable, value: false);
		hscroll.Enabled = false;
		hscroll.Visible = false;
		hscroll.Maximum = int.MaxValue;
		vscroll = new ImplicitVScrollBar();
		vscroll.ValueChanged += vscroll_ValueChanged;
		vscroll.SetStyle(ControlStyles.Selectable, value: false);
		vscroll.Enabled = false;
		vscroll.Visible = false;
		vscroll.Maximum = int.MaxValue;
		SuspendLayout();
		base.Controls.AddImplicit(hscroll);
		base.Controls.AddImplicit(vscroll);
		ResumeLayout();
		SetStyle(ControlStyles.UserPaint | ControlStyles.StandardClick, value: false);
		SetStyle(ControlStyles.UseTextForAccessibility, value: false);
		SetStyle(ControlStyles.FixedHeight, value: true);
		canvas_width = base.ClientSize.Width;
		canvas_height = base.ClientSize.Height;
		document.ViewPortWidth = canvas_width;
		document.ViewPortHeight = canvas_height;
		Cursor = Cursors.IBeam;
		requested_height = base.Height;
		can_cache_preferred_size = true;
	}

	internal string CaseAdjust(string s)
	{
		if (character_casing == CharacterCasing.Normal)
		{
			return s;
		}
		if (character_casing == CharacterCasing.Lower)
		{
			return s.ToLower();
		}
		return s.ToUpper();
	}

	internal override Size GetPreferredSizeCore(Size proposedSize)
	{
		Size size = SizeFromClientSize(Size.Empty) + Padding.Size;
		if (BorderStyle != BorderStyle.None)
		{
			size += new Size(0, 7);
		}
		proposedSize -= size;
		TextFormatFlags textFormatFlags = TextFormatFlags.NoPrefix;
		if (!Multiline)
		{
			textFormatFlags |= TextFormatFlags.SingleLine;
		}
		else if (WordWrap)
		{
			textFormatFlags |= TextFormatFlags.WordBreak;
		}
		Size size2 = TextRenderer.MeasureText(Text, Font, proposedSize, textFormatFlags);
		size2.Height = Math.Max(size2.Height, base.FontHeight);
		return size2 + size;
	}

	internal override void HandleClick(int clicks, MouseEventArgs me)
	{
		bool style = GetStyle(ControlStyles.StandardClick);
		bool style2 = GetStyle(ControlStyles.StandardDoubleClick);
		SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, value: true);
		base.HandleClick(clicks, me);
		if (!style)
		{
			SetStyle(ControlStyles.StandardClick, value: false);
		}
		if (!style2)
		{
			SetStyle(ControlStyles.StandardDoubleClick, value: false);
		}
	}

	internal override void PaintControlBackground(PaintEventArgs pevent)
	{
		if (ThemeEngine.Current.TextBoxBaseShouldPaintBackground(this))
		{
			base.PaintControlBackground(pevent);
		}
	}

	public void AppendText(string text)
	{
		bool num = document.Lines == 1 && Text == string.Empty;
		if (document.caret.line.line_no != document.Lines || document.caret.pos != document.caret.line.TextLengthWithoutEnding())
		{
			document.MoveCaret(CaretDirection.CtrlEnd);
		}
		document.Insert(document.caret.line, document.caret.pos, update_caret: false, text, document.CaretTag);
		document.MoveCaret(CaretDirection.CtrlEnd);
		document.SetSelectionToCaret(start: true);
		if (!num)
		{
			ScrollToCaret();
		}
		has_been_focused = true;
		Modified = false;
		OnTextChanged(EventArgs.Empty);
	}

	public void Clear()
	{
		Modified = false;
		Text = string.Empty;
	}

	public void ClearUndo()
	{
		document.undo.Clear();
	}

	public void Copy()
	{
		DataObject dataObject = new DataObject(DataFormats.Text, SelectedText);
		if (this is RichTextBox)
		{
			dataObject.SetData(DataFormats.Rtf, ((RichTextBox)this).SelectedRtf);
		}
		Clipboard.SetDataObject(dataObject);
	}

	public void Cut()
	{
		DataObject dataObject = new DataObject(DataFormats.Text, SelectedText);
		if (this is RichTextBox)
		{
			dataObject.SetData(DataFormats.Rtf, ((RichTextBox)this).SelectedRtf);
		}
		Clipboard.SetDataObject(dataObject);
		document.undo.BeginUserAction(Locale.GetText("Cut"));
		document.ReplaceSelection(string.Empty, select_new: false);
		document.undo.EndUserAction();
		Modified = true;
		OnTextChanged(EventArgs.Empty);
	}

	public void Paste()
	{
		Paste(Clipboard.GetDataObject(), null, obey_length: false);
	}

	public void ScrollToCaret()
	{
		if (base.IsHandleCreated)
		{
			CaretMoved(this, EventArgs.Empty);
		}
	}

	public void Select(int start, int length)
	{
		SelectionStart = start;
		SelectionLength = length;
	}

	public void SelectAll()
	{
		Line line = document.GetLine(document.Lines);
		document.SetSelectionStart(document.GetLine(1), 0, invalidate: false);
		document.SetSelectionEnd(line, line.text.Length, invalidate: true);
		document.PositionCaret(document.selection_end.line, document.selection_end.pos);
		selection_length = -1;
		CaretMoved(this, null);
		document.DisplayCaret();
	}

	internal void SelectAllNoScroll()
	{
		Line line = document.GetLine(document.Lines);
		document.SetSelectionStart(document.GetLine(1), 0, invalidate: false);
		document.SetSelectionEnd(line, line.text.Length, invalidate: false);
		document.PositionCaret(document.selection_end.line, document.selection_end.pos);
		selection_length = -1;
		document.DisplayCaret();
	}

	public override string ToString()
	{
		return base.ToString() + ", Text: " + Text;
	}

	[System.MonoInternalNote("Deleting is classed as Typing, instead of its own Undo event")]
	public void Undo()
	{
		if (document.undo.Undo())
		{
			Modified = true;
			OnTextChanged(EventArgs.Empty);
		}
	}

	public void DeselectAll()
	{
		SelectionLength = 0;
	}

	public virtual char GetCharFromPosition(Point pt)
	{
		return GetCharFromPositionInternal(pt);
	}

	internal virtual char GetCharFromPositionInternal(Point p)
	{
		LineTag lineTag = document.FindCursor(p.X, p.Y, out var index);
		if (lineTag == null)
		{
			return '\0';
		}
		if (index >= lineTag.Line.text.Length)
		{
			if (lineTag.Line.ending == LineEnding.Wrap)
			{
				Line line = document.GetLine(lineTag.Line.line_no + 1);
				if (line != null)
				{
					return line.text[0];
				}
			}
			if (lineTag.Line.line_no == document.Lines)
			{
				return lineTag.Line.text[lineTag.Line.text.Length - 1];
			}
			return '\0';
		}
		return lineTag.Line.text[index];
	}

	public virtual int GetCharIndexFromPosition(Point pt)
	{
		LineTag lineTag = document.FindCursor(pt.X, pt.Y, out var index);
		if (lineTag == null)
		{
			return 0;
		}
		if (index >= lineTag.Line.text.Length)
		{
			if (lineTag.Line.ending == LineEnding.Wrap)
			{
				Line line = document.GetLine(lineTag.Line.line_no + 1);
				if (line != null)
				{
					return document.LineTagToCharIndex(line, 0);
				}
			}
			if (lineTag.Line.line_no == document.Lines)
			{
				return document.LineTagToCharIndex(lineTag.Line, lineTag.Line.text.Length - 1);
			}
			return 0;
		}
		return document.LineTagToCharIndex(lineTag.Line, index);
	}

	public virtual Point GetPositionFromCharIndex(int index)
	{
		document.CharIndexToLineTag(index, out var line_out, out var tag_out, out var pos);
		return new Point((int)(line_out.widths[pos] + (float)line_out.X + (float)document.viewport_x), line_out.Y + document.viewport_y + tag_out.Shift);
	}

	public int GetFirstCharIndexFromLine(int lineNumber)
	{
		Line line = document.GetLine(lineNumber + 1);
		if (line == null)
		{
			return -1;
		}
		return document.LineTagToCharIndex(line, 0);
	}

	public int GetFirstCharIndexOfCurrentLine()
	{
		return document.LineTagToCharIndex(document.caret.line, 0);
	}

	protected override void CreateHandle()
	{
		CalculateDocument();
		base.CreateHandle();
		document.AlignCaret();
		ScrollToCaret();
	}

	internal virtual void HandleLinkClicked(LinkRectangle link_clicked)
	{
	}

	protected override bool IsInputKey(Keys keyData)
	{
		if ((keyData & Keys.Alt) != Keys.None)
		{
			return base.IsInputKey(keyData);
		}
		switch (keyData & Keys.KeyCode)
		{
		case Keys.Return:
			if (accepts_return)
			{
				return document.multiline;
			}
			return false;
		case Keys.Tab:
			if (accepts_tab && document.multiline && (keyData & Keys.Control) == 0)
			{
				return true;
			}
			return false;
		case Keys.Back:
		case Keys.PageUp:
		case Keys.PageDown:
		case Keys.End:
		case Keys.Home:
		case Keys.Left:
		case Keys.Up:
		case Keys.Right:
		case Keys.Down:
			return true;
		default:
			return false;
		}
	}

	protected virtual void OnAcceptsTabChanged(EventArgs e)
	{
		((EventHandler)base.Events[AcceptsTabChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnBorderStyleChanged(EventArgs e)
	{
		((EventHandler)base.Events[BorderStyleChangedEvent])?.Invoke(this, e);
	}

	protected override void OnFontChanged(EventArgs e)
	{
		base.OnFontChanged(e);
		FixupHeight();
	}

	protected override void OnHandleCreated(EventArgs e)
	{
		base.OnHandleCreated(e);
		if (delayed_font_or_color_change)
		{
			TextBoxBase_FontOrColorChanged(this, e);
		}
		FixupHeight();
	}

	protected override void OnHandleDestroyed(EventArgs e)
	{
		base.OnHandleDestroyed(e);
	}

	protected virtual void OnHideSelectionChanged(EventArgs e)
	{
		((EventHandler)base.Events[HideSelectionChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnModifiedChanged(EventArgs e)
	{
		((EventHandler)base.Events[ModifiedChangedEvent])?.Invoke(this, e);
	}

	protected virtual void OnMultilineChanged(EventArgs e)
	{
		((EventHandler)base.Events[MultilineChangedEvent])?.Invoke(this, e);
	}

	protected override void OnPaddingChanged(EventArgs e)
	{
		base.OnPaddingChanged(e);
	}

	protected virtual void OnReadOnlyChanged(EventArgs e)
	{
		((EventHandler)base.Events[ReadOnlyChangedEvent])?.Invoke(this, e);
	}

	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
	{
		return base.ProcessCmdKey(ref msg, keyData);
	}

	protected override bool ProcessDialogKey(Keys keyData)
	{
		if (accepts_tab && (keyData & (Keys.Tab | Keys.Control)) == (Keys.Tab | Keys.Control))
		{
			keyData ^= Keys.Control;
		}
		return base.ProcessDialogKey(keyData);
	}

	private bool ProcessKey(Keys keyData)
	{
		bool flag = (Control.ModifierKeys & Keys.Control) != 0;
		bool flag2 = (Control.ModifierKeys & Keys.Shift) != 0;
		if (shortcuts_enabled)
		{
			switch (keyData & Keys.KeyCode)
			{
			case Keys.X:
				if (flag && !read_only)
				{
					Cut();
					return true;
				}
				return false;
			case Keys.C:
				if (flag)
				{
					Copy();
					return true;
				}
				return false;
			case Keys.V:
				if (flag && !read_only)
				{
					return Paste(Clipboard.GetDataObject(), null, obey_length: true);
				}
				return false;
			case Keys.Z:
				if (flag && !read_only)
				{
					Undo();
					return true;
				}
				return false;
			case Keys.A:
				if (flag)
				{
					SelectAll();
					return true;
				}
				return false;
			case Keys.Insert:
				if (!read_only)
				{
					if (flag2)
					{
						Paste(Clipboard.GetDataObject(), null, obey_length: true);
						return true;
					}
					if (flag)
					{
						Copy();
						return true;
					}
				}
				return false;
			case Keys.Delete:
				if (read_only)
				{
					break;
				}
				if (flag2 && !read_only)
				{
					Cut();
					return true;
				}
				if (document.selection_visible)
				{
					document.ReplaceSelection("", select_new: false);
				}
				else if (document.CaretPosition >= document.CaretLine.TextLengthWithoutEnding())
				{
					if (document.CaretLine.LineNo < document.Lines)
					{
						Line line = document.GetLine(document.CaretLine.LineNo + 1);
						document.Invalidate(line, 0, line, line.text.Length);
						document.Combine(document.CaretLine, line);
						document.UpdateView(document.CaretLine, document.Lines, 0);
					}
				}
				else if (!flag)
				{
					document.DeleteChar(document.CaretTag.Line, document.CaretPosition, forward: true);
				}
				else
				{
					int i;
					for (i = document.CaretPosition; i < document.CaretLine.Text.Length && !Document.IsWordSeparator(document.CaretLine.Text[i]); i++)
					{
					}
					if (i < document.CaretLine.Text.Length)
					{
						i++;
					}
					document.DeleteChars(document.CaretTag.Line, document.CaretPosition, i - document.CaretPosition);
				}
				document.AlignCaret();
				document.UpdateCaret();
				CaretMoved(this, null);
				Modified = true;
				OnTextChanged(EventArgs.Empty);
				return true;
			}
		}
		switch (keyData & Keys.KeyCode)
		{
		case Keys.Left:
			if (flag)
			{
				document.MoveCaret(CaretDirection.WordBack);
			}
			else if (!document.selection_visible | flag2)
			{
				document.MoveCaret(CaretDirection.CharBack);
			}
			else
			{
				document.MoveCaret(CaretDirection.SelectionStart);
			}
			if (!flag2)
			{
				document.SetSelectionToCaret(start: true);
			}
			else
			{
				document.SetSelectionToCaret(start: false);
			}
			CaretMoved(this, null);
			return true;
		case Keys.Right:
			if (flag)
			{
				document.MoveCaret(CaretDirection.WordForward);
			}
			else if (!document.selection_visible | flag2)
			{
				document.MoveCaret(CaretDirection.CharForward);
			}
			else
			{
				document.MoveCaret(CaretDirection.SelectionEnd);
			}
			if (!flag2)
			{
				document.SetSelectionToCaret(start: true);
			}
			else
			{
				document.SetSelectionToCaret(start: false);
			}
			CaretMoved(this, null);
			return true;
		case Keys.Up:
			if (flag)
			{
				if (document.CaretPosition == 0)
				{
					document.MoveCaret(CaretDirection.LineUp);
				}
				else
				{
					document.MoveCaret(CaretDirection.Home);
				}
			}
			else
			{
				document.MoveCaret(CaretDirection.LineUp);
			}
			if ((Control.ModifierKeys & Keys.Shift) == 0)
			{
				document.SetSelectionToCaret(start: true);
			}
			else
			{
				document.SetSelectionToCaret(start: false);
			}
			CaretMoved(this, null);
			return true;
		case Keys.Down:
			if (flag)
			{
				if (document.CaretPosition == document.CaretLine.Text.Length)
				{
					document.MoveCaret(CaretDirection.LineDown);
				}
				else
				{
					document.MoveCaret(CaretDirection.End);
				}
			}
			else
			{
				document.MoveCaret(CaretDirection.LineDown);
			}
			if ((Control.ModifierKeys & Keys.Shift) == 0)
			{
				document.SetSelectionToCaret(start: true);
			}
			else
			{
				document.SetSelectionToCaret(start: false);
			}
			CaretMoved(this, null);
			return true;
		case Keys.Home:
			if ((Control.ModifierKeys & Keys.Control) != Keys.None)
			{
				document.MoveCaret(CaretDirection.CtrlHome);
			}
			else
			{
				document.MoveCaret(CaretDirection.Home);
			}
			if ((Control.ModifierKeys & Keys.Shift) == 0)
			{
				document.SetSelectionToCaret(start: true);
			}
			else
			{
				document.SetSelectionToCaret(start: false);
			}
			CaretMoved(this, null);
			return true;
		case Keys.End:
			if ((Control.ModifierKeys & Keys.Control) != Keys.None)
			{
				document.MoveCaret(CaretDirection.CtrlEnd);
			}
			else
			{
				document.MoveCaret(CaretDirection.End);
			}
			if ((Control.ModifierKeys & Keys.Shift) == 0)
			{
				document.SetSelectionToCaret(start: true);
			}
			else
			{
				document.SetSelectionToCaret(start: false);
			}
			CaretMoved(this, null);
			return true;
		case Keys.Tab:
			if (!read_only && accepts_tab && document.multiline)
			{
				document.InsertCharAtCaret('\t', move_caret: true);
				CaretMoved(this, null);
				Modified = true;
				OnTextChanged(EventArgs.Empty);
				return true;
			}
			break;
		case Keys.PageUp:
			if ((Control.ModifierKeys & Keys.Control) != Keys.None)
			{
				document.MoveCaret(CaretDirection.CtrlPgUp);
			}
			else
			{
				document.MoveCaret(CaretDirection.PgUp);
			}
			document.DisplayCaret();
			return true;
		case Keys.PageDown:
			if ((Control.ModifierKeys & Keys.Control) != Keys.None)
			{
				document.MoveCaret(CaretDirection.CtrlPgDn);
			}
			else
			{
				document.MoveCaret(CaretDirection.PgDn);
			}
			document.DisplayCaret();
			return true;
		}
		return false;
	}

	internal virtual void RaiseSelectionChanged()
	{
	}

	private void HandleBackspace(bool control)
	{
		bool flag = false;
		if (document.selection_visible)
		{
			document.undo.BeginUserAction(Locale.GetText("Delete"));
			document.ReplaceSelection("", select_new: false);
			document.undo.EndUserAction();
			flag = true;
			document.SetSelectionToCaret(start: true);
		}
		else
		{
			document.SetSelectionToCaret(start: true);
			if (document.CaretPosition == 0)
			{
				if (document.CaretLine.LineNo > 1)
				{
					Line line = document.GetLine(document.CaretLine.LineNo - 1);
					int pos = line.TextLengthWithoutEnding();
					document.Invalidate(line, 0, line, line.text.Length);
					document.Combine(line, document.CaretLine);
					document.UpdateView(line, document.Lines - line.LineNo, 0);
					document.PositionCaret(line, pos);
					document.SetSelectionToCaret(start: true);
					document.UpdateCaret();
					flag = true;
				}
			}
			else
			{
				if (!control || document.CaretPosition == 0)
				{
					LineTag caretTag = document.CaretTag;
					int caretPosition = document.CaretPosition;
					document.MoveCaret(CaretDirection.CharBack);
					document.DeleteChar(caretTag.Line, caretPosition, forward: false);
					document.SetSelectionToCaret(start: true);
				}
				else
				{
					int num = document.CaretPosition - 1;
					while (num > 0 && !Document.IsWordSeparator(document.CaretLine.Text[num - 1]))
					{
						num--;
					}
					document.undo.BeginUserAction(Locale.GetText("Delete"));
					document.DeleteChars(document.CaretTag.Line, num, document.CaretPosition - num);
					document.undo.EndUserAction();
					document.PositionCaret(document.CaretLine, num);
					document.SetSelectionToCaret(start: true);
				}
				document.UpdateCaret();
				flag = true;
			}
		}
		CaretMoved(this, null);
		if (flag)
		{
			Modified = true;
			OnTextChanged(EventArgs.Empty);
		}
	}

	private void HandleEnter()
	{
		if (!read_only && document.multiline && (accepts_return || (FindForm() != null && FindForm().AcceptButton == null) || (Control.ModifierKeys & Keys.Control) != Keys.None))
		{
			if (document.selection_visible)
			{
				document.ReplaceSelection("", select_new: false);
			}
			Line caretLine = document.CaretLine;
			document.Split(document.CaretLine, document.CaretTag, document.CaretPosition);
			caretLine.ending = document.StringToLineEnding(Environment.NewLine);
			document.InsertString(caretLine, caretLine.text.Length, document.LineEndingToString(caretLine.ending));
			document.UpdateView(caretLine, document.Lines - caretLine.line_no, 0);
			CaretMoved(this, null);
			Modified = true;
			OnTextChanged(EventArgs.Empty);
		}
	}

	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
		if ((specified & BoundsSpecified.Height) != BoundsSpecified.None)
		{
			requested_height = height;
		}
		if (!richtext && !document.multiline)
		{
			height = PreferredHeight;
		}
		base.SetBoundsCore(x, y, width, height, specified);
	}

	protected override void WndProc(ref Message m)
	{
		switch ((Msg)m.Msg)
		{
		case Msg.WM_KEYDOWN:
			if (ProcessKeyMessage(ref m) || ProcessKey((Keys)(m.WParam.ToInt32() | (int)XplatUI.State.ModifierKeys)))
			{
				m.Result = IntPtr.Zero;
			}
			else
			{
				DefWndProc(ref m);
			}
			break;
		case Msg.WM_CHAR:
			if (ProcessKeyMessage(ref m))
			{
				m.Result = IntPtr.Zero;
			}
			else
			{
				if (read_only)
				{
					break;
				}
				m.Result = IntPtr.Zero;
				int num = m.WParam.ToInt32();
				if (num == 127)
				{
					HandleBackspace(control: true);
				}
				else if (num >= 32)
				{
					if (document.selection_visible)
					{
						document.ReplaceSelection("", select_new: false);
					}
					char ch = (char)(int)m.WParam;
					switch (character_casing)
					{
					case CharacterCasing.Upper:
						ch = char.ToUpper((char)(int)m.WParam);
						break;
					case CharacterCasing.Lower:
						ch = char.ToLower((char)(int)m.WParam);
						break;
					}
					if (document.Length < max_length)
					{
						document.InsertCharAtCaret(ch, move_caret: true);
						OnTextUpdate();
						CaretMoved(this, null);
						Modified = true;
						OnTextChanged(EventArgs.Empty);
					}
					else
					{
						XplatUI.AudibleAlert(AlertType.Default);
					}
				}
				else
				{
					switch (num)
					{
					case 8:
						HandleBackspace(control: false);
						break;
					case 13:
						HandleEnter();
						break;
					}
				}
			}
			break;
		case Msg.WM_SETFOCUS:
			base.WndProc(ref m);
			document.CaretHasFocus();
			break;
		case Msg.WM_KILLFOCUS:
			base.WndProc(ref m);
			document.CaretLostFocus();
			break;
		case Msg.WM_NCPAINT:
			if (!ThemeEngine.Current.TextBoxBaseHandleWmNcPaint(this, ref m))
			{
				base.WndProc(ref m);
			}
			break;
		default:
			base.WndProc(ref m);
			break;
		}
	}

	internal override void OnPaintInternal(PaintEventArgs pevent)
	{
		Draw(pevent.Graphics, pevent.ClipRectangle);
		pevent.Handled = true;
	}

	internal void Draw(Graphics g, Rectangle clippingArea)
	{
		ThemeEngine.Current.TextBoxBaseFillBackground(this, g, clippingArea);
		document.Draw(g, clippingArea);
	}

	private void FixupHeight()
	{
		if (richtext)
		{
			return;
		}
		int num = requested_height;
		if (!document.multiline)
		{
			if (PreferredHeight != base.Height)
			{
				SetBoundsCore(base.Left, base.Top, base.Width, PreferredHeight, BoundsSpecified.Height);
			}
		}
		else
		{
			SetBoundsCore(base.Left, base.Top, base.Width, Math.Max(PreferredHeight, requested_height), BoundsSpecified.Height);
		}
		requested_height = num;
	}

	private bool IsDoubleClick(MouseEventArgs e)
	{
		if ((DateTime.Now - click_last).TotalMilliseconds > (double)SystemInformation.DoubleClickTime)
		{
			return false;
		}
		Size doubleClickSize = SystemInformation.DoubleClickSize;
		if (e.X < click_point_x - doubleClickSize.Width / 2 || e.X > click_point_x + doubleClickSize.Width / 2)
		{
			return false;
		}
		if (e.Y < click_point_y - doubleClickSize.Height / 2 || e.Y > click_point_y + doubleClickSize.Height / 2)
		{
			return false;
		}
		return true;
	}

	private void TextBoxBase_MouseDown(object sender, MouseEventArgs e)
	{
		bool flag = false;
		if (e.Button == MouseButtons.Left)
		{
			if ((Control.ModifierKeys & Keys.Shift) > Keys.None)
			{
				document.PositionCaret(e.X + document.ViewPortX, e.Y + document.ViewPortY);
				document.SetSelectionToCaret(start: false);
				document.DisplayCaret();
				return;
			}
			flag = IsDoubleClick(e);
			if (current_link != null)
			{
				HandleLinkClicked(current_link);
				return;
			}
			if (document.selection_visible && !flag)
			{
				document.SetSelectionToCaret(start: true);
				click_mode = CaretSelection.Position;
			}
			document.PositionCaret(e.X + document.ViewPortX, e.Y + document.ViewPortY);
			document.DisplayCaret();
			if (flag)
			{
				switch (click_mode)
				{
				case CaretSelection.Position:
					SelectWord();
					click_mode = CaretSelection.Word;
					break;
				case CaretSelection.Word:
					if (this is TextBox)
					{
						document.SetSelectionToCaret(start: true);
						click_mode = CaretSelection.Position;
					}
					else
					{
						document.ExpandSelection(CaretSelection.Line, to_caret: false);
						click_mode = CaretSelection.Line;
					}
					break;
				case CaretSelection.Line:
					document.SetSelectionToCaret(start: true);
					SelectWord();
					click_mode = CaretSelection.Word;
					break;
				}
			}
			else
			{
				document.SetSelectionToCaret(start: true);
				click_mode = CaretSelection.Position;
			}
			click_point_x = e.X;
			click_point_y = e.Y;
			click_last = DateTime.Now;
		}
		if (e.Button == MouseButtons.Middle && XplatUI.RunningOnUnix)
		{
			Document.Marker marker = default;
			marker.tag = document.FindCursor(e.X + document.ViewPortX, e.Y + document.ViewPortY, out marker.pos);
			marker.line = marker.tag.Line;
			marker.height = marker.tag.Height;
			document.SetSelection(marker.line, marker.pos, marker.line, marker.pos);
			Paste(Clipboard.GetDataObject(primary_selection: true), null, obey_length: true);
		}
	}

	private void TextBoxBase_MouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button != MouseButtons.Left)
		{
			return;
		}
		if (click_mode == CaretSelection.Position)
		{
			document.SetSelectionToCaret(start: false);
			document.DisplayCaret();
			if (Text.Length > 0)
			{
				RaiseSelectionChanged();
			}
		}
		if (scroll_timer != null)
		{
			scroll_timer.Enabled = false;
		}
	}

	private void SizeControls()
	{
		if (hscroll.Visible)
		{
			canvas_height = base.ClientSize.Height - hscroll.Height;
		}
		else
		{
			canvas_height = base.ClientSize.Height;
		}
		if (vscroll.Visible)
		{
			canvas_width = base.ClientSize.Width - vscroll.Width;
			if (GetInheritedRtoL() == RightToLeft.Yes)
			{
				document.OffsetX = vscroll.Width;
			}
			else
			{
				document.OffsetX = 0;
			}
		}
		else
		{
			canvas_width = base.ClientSize.Width;
			document.OffsetX = 0;
		}
		document.ViewPortWidth = canvas_width;
		document.ViewPortHeight = canvas_height;
	}

	private void PositionControls()
	{
		if (canvas_height >= 1 && canvas_width >= 1)
		{
			int num = (vscroll.Visible ? vscroll.Width : 0);
			int num2 = (hscroll.Visible ? hscroll.Height : 0);
			if (GetInheritedRtoL() == RightToLeft.Yes)
			{
				hscroll.Bounds = new Rectangle(base.ClientRectangle.Left + num, Math.Max(0, base.ClientRectangle.Height - hscroll.Height), base.ClientSize.Width, hscroll.Height);
				vscroll.Bounds = new Rectangle(base.ClientRectangle.Left, base.ClientRectangle.Top, vscroll.Width, Math.Max(0, base.ClientSize.Height - num2));
			}
			else
			{
				hscroll.Bounds = new Rectangle(base.ClientRectangle.Left, Math.Max(0, base.ClientRectangle.Height - hscroll.Height), Math.Max(0, base.ClientSize.Width - num), hscroll.Height);
				vscroll.Bounds = new Rectangle(Math.Max(0, base.ClientRectangle.Right - vscroll.Width), base.ClientRectangle.Top, vscroll.Width, Math.Max(0, base.ClientSize.Height - num2));
			}
		}
	}

	internal RightToLeft GetInheritedRtoL()
	{
		for (Control control = this; control != null; control = control.Parent)
		{
			if (control.RightToLeft != RightToLeft.Inherit)
			{
				return control.RightToLeft;
			}
		}
		return RightToLeft.No;
	}

	private void TextBoxBase_SizeChanged(object sender, EventArgs e)
	{
		CalculateDocument();
	}

	private void TextBoxBase_RightToLeftChanged(object o, EventArgs e)
	{
		CalculateDocument();
	}

	private void TextBoxBase_MouseWheel(object sender, MouseEventArgs e)
	{
		if (vscroll.Enabled)
		{
			if (e.Delta < 0)
			{
				vscroll.Value = Math.Min(vscroll.Value + SystemInformation.MouseWheelScrollLines * 5, Math.Max(0, vscroll.Maximum - document.ViewPortHeight + 1));
			}
			else
			{
				vscroll.Value = Math.Max(0, vscroll.Value - SystemInformation.MouseWheelScrollLines * 5);
			}
		}
	}

	internal virtual void SelectWord()
	{
		StringBuilder stringBuilder = document.caret.line.text;
		int num = document.caret.pos;
		int i = document.caret.pos;
		if (stringBuilder.Length < 1)
		{
			if (document.caret.line.line_no < document.Lines)
			{
				Line line = document.GetLine(document.caret.line.line_no + 1);
				document.PositionCaret(line, 0);
			}
			return;
		}
		if (num > 0)
		{
			num--;
			i--;
		}
		while (num > 0 && stringBuilder[num] == ' ')
		{
			num--;
		}
		if (num > 0)
		{
			while (num > 0 && stringBuilder[num] != ' ')
			{
				num--;
			}
			if (stringBuilder[num] == ' ')
			{
				num++;
			}
		}
		if (stringBuilder[i] == ' ')
		{
			for (; i < stringBuilder.Length && stringBuilder[i] == ' '; i++)
			{
			}
		}
		else
		{
			for (; i < stringBuilder.Length && stringBuilder[i] != ' '; i++)
			{
			}
			for (; i < stringBuilder.Length && stringBuilder[i] == ' '; i++)
			{
			}
		}
		document.SetSelection(document.caret.line, num, document.caret.line, i);
		document.PositionCaret(document.selection_end.line, document.selection_end.pos);
		document.DisplayCaret();
	}

	internal void CalculateDocument()
	{
		if (base.IsHandleCreated)
		{
			CalculateScrollBars();
			using (Graphics g = CreateGraphics())
			{
				document.RecalculateDocument(g);
			}
			if (document.caret.line != null && document.caret.line.Y < document.ViewPortHeight)
			{
				vscroll.Value = 0;
			}
			Invalidate();
		}
	}

	internal bool CalculateScrollBars()
	{
		int num = canvas_width;
		SizeControls();
		if (document.Width > document.ViewPortWidth)
		{
			hscroll.SetValues(0, Math.Max(1, document.Width), -1, (document.ViewPortWidth >= 0) ? document.ViewPortWidth : 0);
			if (document.multiline)
			{
				hscroll.Enabled = true;
			}
		}
		else
		{
			hscroll.Enabled = false;
			hscroll.Value = hscroll.Minimum;
			hscroll.Maximum = document.ViewPortWidth;
		}
		if (document.Height > document.ViewPortHeight)
		{
			vscroll.SetValues(0, Math.Max(1, document.Height), -1, (document.ViewPortHeight >= 0) ? document.ViewPortHeight : 0);
			if (document.multiline)
			{
				vscroll.Enabled = true;
			}
		}
		else
		{
			vscroll.Enabled = false;
			vscroll.Maximum = document.ViewPortHeight;
		}
		if (!WordWrap)
		{
			switch (scrollbars)
			{
			case RichTextBoxScrollBars.Horizontal:
			case RichTextBoxScrollBars.Both:
				if (richtext)
				{
					hscroll.Visible = hscroll.Enabled;
				}
				else
				{
					hscroll.Visible = Multiline;
				}
				break;
			case RichTextBoxScrollBars.ForcedHorizontal:
			case RichTextBoxScrollBars.ForcedBoth:
				hscroll.Visible = true;
				break;
			default:
				hscroll.Visible = false;
				break;
			}
		}
		else
		{
			hscroll.Visible = false;
		}
		switch (scrollbars)
		{
		case RichTextBoxScrollBars.Vertical:
		case RichTextBoxScrollBars.Both:
			if (richtext)
			{
				vscroll.Visible = vscroll.Enabled;
			}
			else
			{
				vscroll.Visible = Multiline;
			}
			break;
		case RichTextBoxScrollBars.ForcedVertical:
		case RichTextBoxScrollBars.ForcedBoth:
			vscroll.Visible = true;
			break;
		default:
			vscroll.Visible = false;
			break;
		}
		PositionControls();
		SizeControls();
		return canvas_width != num;
	}

	private void document_SizeChanged(object sender, Document.SizeChangedEventArgs e)
	{
		bool flag = CalculateScrollBars();
		if (e.HeightChanged & flag)
		{
			CalculateDocument();
		}
	}

	private void ScrollLinks(int xChange, int yChange)
	{
		foreach (LinkRectangle list_link in list_links)
		{
			list_link.Scroll(xChange, yChange);
		}
	}

	private void hscroll_ValueChanged(object sender, EventArgs e)
	{
		int viewPortX = document.ViewPortX;
		document.ViewPortX = hscroll.Value;
		if (Focused)
		{
			document.CaretLostFocus();
		}
		if (vscroll.Visible)
		{
			if (GetInheritedRtoL() == RightToLeft.Yes)
			{
				XplatUI.ScrollWindow(base.Handle, new Rectangle(vscroll.Width, 0, base.ClientSize.Width - vscroll.Width, base.ClientSize.Height), viewPortX - hscroll.Value, 0, with_children: false);
			}
			else
			{
				XplatUI.ScrollWindow(base.Handle, new Rectangle(0, 0, base.ClientSize.Width - vscroll.Width, base.ClientSize.Height), viewPortX - hscroll.Value, 0, with_children: false);
			}
		}
		else
		{
			XplatUI.ScrollWindow(base.Handle, base.ClientRectangle, viewPortX - hscroll.Value, 0, with_children: false);
		}
		ScrollLinks(viewPortX - hscroll.Value, 0);
		if (Focused)
		{
			document.CaretHasFocus();
		}
		((EventHandler)base.Events[HScrolledEvent])?.Invoke(this, EventArgs.Empty);
	}

	private void vscroll_ValueChanged(object sender, EventArgs e)
	{
		int viewPortY = document.ViewPortY;
		document.ViewPortY = vscroll.Value;
		if (Focused)
		{
			document.CaretLostFocus();
		}
		if (hscroll.Visible)
		{
			XplatUI.ScrollWindow(base.Handle, new Rectangle(0, 0, base.ClientSize.Width, base.ClientSize.Height - hscroll.Height), 0, viewPortY - vscroll.Value, with_children: false);
		}
		else
		{
			XplatUI.ScrollWindow(base.Handle, base.ClientRectangle, 0, viewPortY - vscroll.Value, with_children: false);
		}
		ScrollLinks(0, viewPortY - vscroll.Value);
		if (Focused)
		{
			document.CaretHasFocus();
		}
		((EventHandler)base.Events[VScrolledEvent])?.Invoke(this, EventArgs.Empty);
	}

	private void TextBoxBase_MouseMove(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left && base.Capture)
		{
			if (!base.ClientRectangle.Contains(e.X, e.Y))
			{
				if (scroll_timer == null)
				{
					scroll_timer = new Timer();
					scroll_timer.Interval = 100;
					scroll_timer.Tick += ScrollTimerTickHandler;
				}
				if (!scroll_timer.Enabled)
				{
					scroll_timer.Start();
					ScrollTimerTickHandler(null, EventArgs.Empty);
				}
			}
			document.PositionCaret(e.X + document.ViewPortX, e.Y + document.ViewPortY);
			if (click_mode == CaretSelection.Position)
			{
				document.SetSelectionToCaret(start: false);
				document.DisplayCaret();
			}
		}
		bool flag = false;
		foreach (LinkRectangle list_link in list_links)
		{
			if (list_link.LinkAreaRectangle.Contains(e.X, e.Y))
			{
				XplatUI.SetCursor(window.Handle, Cursors.Hand.handle);
				flag = true;
				current_link = list_link;
				break;
			}
		}
		if (!flag)
		{
			XplatUI.SetCursor(window.Handle, DefaultCursor.handle);
			current_link = null;
		}
	}

	private void TextBoxBase_FontOrColorChanged(object sender, EventArgs e)
	{
		if (!base.IsHandleCreated)
		{
			delayed_font_or_color_change = true;
			return;
		}
		document.SuspendRecalc();
		for (int i = 1; i <= document.Lines; i++)
		{
			Line line = document.GetLine(i);
			if (LineTag.FormatText(line, 1, line.text.Length, Font, ForeColor, Color.Empty, FormatSpecified.Font | FormatSpecified.Color))
			{
				using Graphics g = CreateGraphics();
				document.RecalculateDocument(g, line.LineNo, line.LineNo, optimize: false);
			}
		}
		document.ResumeRecalc(immediate_update: false);
		document.AlignCaret();
	}

	private void ScrollTimerTickHandler(object sender, EventArgs e)
	{
		Point position = Cursor.Position;
		position = PointToClient(position);
		if (position.X < base.ClientRectangle.Left)
		{
			document.MoveCaret(CaretDirection.CharBackNoWrap);
			document.SetSelectionToCaret(start: false);
			CaretMoved(this, null);
		}
		else if (position.X > base.ClientRectangle.Right)
		{
			document.MoveCaret(CaretDirection.CharForwardNoWrap);
			document.SetSelectionToCaret(start: false);
			CaretMoved(this, null);
		}
		else if (position.Y > base.ClientRectangle.Bottom)
		{
			document.MoveCaret(CaretDirection.LineDown);
			document.SetSelectionToCaret(start: false);
			CaretMoved(this, null);
		}
		else if (position.Y < base.ClientRectangle.Top)
		{
			document.MoveCaret(CaretDirection.LineUp);
			document.SetSelectionToCaret(start: false);
			CaretMoved(this, null);
		}
	}

	internal void CaretMoved(object sender, EventArgs e)
	{
		if (!base.IsHandleCreated || canvas_width < 1 || canvas_height < 1)
		{
			return;
		}
		document.MoveCaretToTextTag();
		Point caret = document.Caret;
		if (caret.X < document.ViewPortX)
		{
			do
			{
				int num = hscroll.Value - document.ViewPortWidth / 3 - 1;
				if (num >= hscroll.Minimum)
				{
					hscroll.SafeValueSet(num);
				}
				else
				{
					hscroll.Value = hscroll.Minimum;
				}
			}
			while (hscroll.Value > caret.X);
		}
		if (caret.X >= document.ViewPortWidth + document.ViewPortX && hscroll.Value != hscroll.Maximum)
		{
			int num2 = ((!Multiline) ? (caret.X - document.ViewPortWidth * 2 / 3 + 1) : (caret.X - document.ViewPortWidth + 1));
			if (num2 <= hscroll.Maximum - document.ViewPortWidth + 1)
			{
				if (num2 >= 0)
				{
					hscroll.SafeValueSet(num2);
				}
				else
				{
					hscroll.Value = 0;
				}
			}
			else
			{
				hscroll.Value = hscroll.Maximum - document.ViewPortWidth + 1;
			}
		}
		if (Text.Length > 0)
		{
			RaiseSelectionChanged();
		}
		if (document.multiline)
		{
			int num3 = document.CaretLine.Height;
			if (document.CaretLine.line_no < document.Lines)
			{
				num3++;
			}
			if (caret.Y < document.ViewPortY)
			{
				vscroll.SafeValueSet(caret.Y);
			}
			if (caret.Y + num3 > document.ViewPortY + canvas_height)
			{
				vscroll.Value = Math.Min(vscroll.Maximum, caret.Y - canvas_height + num3);
			}
		}
	}

	internal bool Paste(IDataObject clip, DataFormats.Format format, bool obey_length)
	{
		if (clip == null)
		{
			return false;
		}
		if (format == null)
		{
			if (this is RichTextBox && clip.GetDataPresent(DataFormats.Rtf))
			{
				format = DataFormats.GetFormat(DataFormats.Rtf);
			}
			else if (this is RichTextBox && clip.GetDataPresent(DataFormats.Bitmap))
			{
				format = DataFormats.GetFormat(DataFormats.Bitmap);
			}
			else if (clip.GetDataPresent(DataFormats.UnicodeText))
			{
				format = DataFormats.GetFormat(DataFormats.UnicodeText);
			}
			else
			{
				if (!clip.GetDataPresent(DataFormats.Text))
				{
					return false;
				}
				format = DataFormats.GetFormat(DataFormats.Text);
			}
		}
		else
		{
			if (format.Name == DataFormats.Rtf && !(this is RichTextBox))
			{
				return false;
			}
			if (!clip.GetDataPresent(format.Name))
			{
				return false;
			}
		}
		if (format.Name == DataFormats.Rtf)
		{
			document.undo.BeginUserAction(Locale.GetText("Paste"));
			((RichTextBox)this).SelectedRtf = (string)clip.GetData(DataFormats.Rtf);
			document.undo.EndUserAction();
			Modified = true;
			return true;
		}
		if (format.Name == DataFormats.Bitmap)
		{
			document.undo.BeginUserAction(Locale.GetText("Paste"));
			document.MoveCaret(CaretDirection.CharForward);
			document.undo.EndUserAction();
			return true;
		}
		string text;
		if (format.Name == DataFormats.UnicodeText)
		{
			text = (string)clip.GetData(DataFormats.UnicodeText);
		}
		else
		{
			if (!(format.Name == DataFormats.Text))
			{
				return false;
			}
			text = (string)clip.GetData(DataFormats.Text);
		}
		if (!obey_length)
		{
			document.undo.BeginUserAction(Locale.GetText("Paste"));
			SelectedText = text;
			document.undo.EndUserAction();
		}
		else if (text.Length + (document.Length - SelectedText.Length) < max_length)
		{
			document.undo.BeginUserAction(Locale.GetText("Paste"));
			SelectedText = text;
			document.undo.EndUserAction();
		}
		else if (document.Length - SelectedText.Length < max_length)
		{
			document.undo.BeginUserAction(Locale.GetText("Paste"));
			SelectedText = text.Substring(0, max_length - (document.Length - SelectedText.Length));
			document.undo.EndUserAction();
		}
		Modified = true;
		return true;
	}

	internal virtual Color ChangeBackColor(Color backColor)
	{
		return backColor;
	}

	internal override bool IsInputCharInternal(char charCode)
	{
		return true;
	}

	internal virtual void OnTextUpdate()
	{
	}

	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
	}

	public virtual int GetLineFromCharIndex(int index)
	{
		document.CharIndexToLineTag(index, out var line_out, out var _, out var _);
		return line_out.LineNo;
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
	}
}
