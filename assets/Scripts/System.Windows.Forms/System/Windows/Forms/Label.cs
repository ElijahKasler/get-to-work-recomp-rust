using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms.Automation;
using System.Windows.Forms.Layout;
using System.Windows.Forms.Theming;
using Unity;

namespace System.Windows.Forms;

[ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[DefaultBindingProperty("Text")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[Designer("System.Windows.Forms.Design.LabelDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.IDesigner")]
[DefaultProperty("Text")]
public class Label : Control, IAutomationLiveRegion
{
	private bool autosize;

	private bool auto_ellipsis;

	private Image image;

	private bool render_transparent;

	private FlatStyle flat_style;

	private bool use_mnemonic;

	private int image_index = -1;

	private string image_key = string.Empty;

	private ImageList image_list;

	internal ContentAlignment image_align;

	internal StringFormat string_format;

	internal ContentAlignment text_align;

	private static object AutoSizeChangedEvent = new object();

	private static object TextAlignChangedEvent = new object();

	[DefaultValue(false)]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public bool AutoEllipsis
	{
		get
		{
			return auto_ellipsis;
		}
		set
		{
			if (auto_ellipsis != value)
			{
				auto_ellipsis = value;
				if (auto_ellipsis)
				{
					string_format.Trimming = StringTrimming.EllipsisCharacter;
				}
				else
				{
					string_format.Trimming = StringTrimming.Character;
				}
				if (base.Parent != null)
				{
					base.Parent.PerformLayout(this, "AutoEllipsis");
				}
				Invalidate();
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[RefreshProperties(RefreshProperties.All)]
	[Localizable(true)]
	[DefaultValue(false)]
	[Browsable(true)]
	public override bool AutoSize
	{
		get
		{
			return autosize;
		}
		set
		{
			if (autosize != value)
			{
				SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
				base.AutoSize = value;
				autosize = value;
				CalcAutoSize();
				Invalidate();
				OnAutoSizeChanged(EventArgs.Empty);
			}
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override Image BackgroundImage
	{
		get
		{
			return base.BackgroundImage;
		}
		set
		{
			base.BackgroundImage = value;
			Invalidate();
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

	[DispId(-504)]
	[DefaultValue(BorderStyle.None)]
	public virtual BorderStyle BorderStyle
	{
		get
		{
			return base.InternalBorderStyle;
		}
		set
		{
			base.InternalBorderStyle = value;
		}
	}

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			if (BorderStyle != BorderStyle.Fixed3D)
			{
				return createParams;
			}
			createParams.ExStyle &= -513;
			createParams.ExStyle |= 131072;
			return createParams;
		}
	}

	protected override ImeMode DefaultImeMode => ImeMode.Disable;

	protected override Padding DefaultMargin => new Padding(3, 0, 3, 0);

	protected override Size DefaultSize => ThemeElements.LabelPainter.DefaultSize;

	[DefaultValue(FlatStyle.Standard)]
	public FlatStyle FlatStyle
	{
		get
		{
			return flat_style;
		}
		set
		{
			if (!Enum.IsDefined(typeof(FlatStyle), value))
			{
				throw new InvalidEnumArgumentException($"Enum argument value '{value}' is not valid for FlatStyle");
			}
			if (flat_style != value)
			{
				flat_style = value;
				if (base.Parent != null)
				{
					base.Parent.PerformLayout(this, "FlatStyle");
				}
				Invalidate();
			}
		}
	}

	[Localizable(true)]
	public Image Image
	{
		get
		{
			if (image != null)
			{
				return image;
			}
			if (image_index >= 0 && image_list != null)
			{
				return image_list.Images[image_index];
			}
			if (!string.IsNullOrEmpty(image_key) && image_list != null)
			{
				return image_list.Images[image_key];
			}
			return null;
		}
		set
		{
			if (image != value)
			{
				image = value;
				image_index = -1;
				image_key = string.Empty;
				image_list = null;
				if (AutoSize && base.Parent != null)
				{
					base.Parent.PerformLayout(this, "Image");
				}
				Invalidate();
			}
		}
	}

	[DefaultValue(ContentAlignment.MiddleCenter)]
	[Localizable(true)]
	public ContentAlignment ImageAlign
	{
		get
		{
			return image_align;
		}
		set
		{
			if (!Enum.IsDefined(typeof(ContentAlignment), value))
			{
				throw new InvalidEnumArgumentException($"Enum argument value '{value}' is not valid for ContentAlignment");
			}
			if (image_align != value)
			{
				image_align = value;
				Invalidate();
			}
		}
	}

	[RefreshProperties(RefreshProperties.Repaint)]
	[TypeConverter(typeof(ImageIndexConverter))]
	[DefaultValue(-1)]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[Localizable(true)]
	public int ImageIndex
	{
		get
		{
			if (ImageList == null)
			{
				return -1;
			}
			if (image_index >= image_list.Images.Count)
			{
				return image_list.Images.Count - 1;
			}
			return image_index;
		}
		set
		{
			if (value < -1)
			{
				throw new ArgumentException();
			}
			if (image_index != value)
			{
				image_index = value;
				image = null;
				image_key = string.Empty;
				Invalidate();
			}
		}
	}

	[TypeConverter(typeof(ImageKeyConverter))]
	[RefreshProperties(RefreshProperties.Repaint)]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[Localizable(true)]
	[DefaultValue("")]
	public string ImageKey
	{
		get
		{
			return image_key;
		}
		set
		{
			if (image_key != value)
			{
				image = null;
				image_index = -1;
				image_key = value;
				Invalidate();
			}
		}
	}

	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue(null)]
	public ImageList ImageList
	{
		get
		{
			return image_list;
		}
		set
		{
			if (image_list != value)
			{
				image_list = value;
				if (image_list != null && image_index != -1)
				{
					Image = null;
				}
				Invalidate();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new ImeMode ImeMode
	{
		get
		{
			return base.ImeMode;
		}
		set
		{
			base.ImeMode = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public virtual int PreferredHeight => GetPreferredSizeCore(Size.Empty).Height;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual int PreferredWidth => GetPreferredSizeCore(Size.Empty).Width;

	[Obsolete("This property has been deprecated.  Use BackColor instead.")]
	protected virtual bool RenderTransparent
	{
		get
		{
			return render_transparent;
		}
		set
		{
			render_transparent = value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[DefaultValue(false)]
	public new bool TabStop
	{
		get
		{
			return base.TabStop;
		}
		set
		{
			base.TabStop = value;
		}
	}

	[DefaultValue(ContentAlignment.TopLeft)]
	[Localizable(true)]
	public virtual ContentAlignment TextAlign
	{
		get
		{
			return text_align;
		}
		set
		{
			if (!Enum.IsDefined(typeof(ContentAlignment), value))
			{
				throw new InvalidEnumArgumentException($"Enum argument value '{value}' is not valid for ContentAlignment");
			}
			if (text_align != value)
			{
				text_align = value;
				switch (value)
				{
				case ContentAlignment.BottomLeft:
					string_format.LineAlignment = StringAlignment.Far;
					string_format.Alignment = StringAlignment.Near;
					break;
				case ContentAlignment.BottomCenter:
					string_format.LineAlignment = StringAlignment.Far;
					string_format.Alignment = StringAlignment.Center;
					break;
				case ContentAlignment.BottomRight:
					string_format.LineAlignment = StringAlignment.Far;
					string_format.Alignment = StringAlignment.Far;
					break;
				case ContentAlignment.TopLeft:
					string_format.LineAlignment = StringAlignment.Near;
					string_format.Alignment = StringAlignment.Near;
					break;
				case ContentAlignment.TopCenter:
					string_format.LineAlignment = StringAlignment.Near;
					string_format.Alignment = StringAlignment.Center;
					break;
				case ContentAlignment.TopRight:
					string_format.LineAlignment = StringAlignment.Near;
					string_format.Alignment = StringAlignment.Far;
					break;
				case ContentAlignment.MiddleLeft:
					string_format.LineAlignment = StringAlignment.Center;
					string_format.Alignment = StringAlignment.Near;
					break;
				case ContentAlignment.MiddleRight:
					string_format.LineAlignment = StringAlignment.Center;
					string_format.Alignment = StringAlignment.Far;
					break;
				case ContentAlignment.MiddleCenter:
					string_format.LineAlignment = StringAlignment.Center;
					string_format.Alignment = StringAlignment.Center;
					break;
				}
				OnTextAlignChanged(EventArgs.Empty);
				Invalidate();
			}
		}
	}

	[DefaultValue(true)]
	public bool UseMnemonic
	{
		get
		{
			return use_mnemonic;
		}
		set
		{
			if (use_mnemonic != value)
			{
				use_mnemonic = value;
				SetUseMnemonic(use_mnemonic);
				Invalidate();
			}
		}
	}

	private bool SelfSizing
	{
		get
		{
			if (AutoSize && base.Parent != null)
			{
				return base.Parent.LayoutEngine is DefaultLayout;
			}
			return false;
		}
	}

	[DefaultValue(false)]
	public bool UseCompatibleTextRendering
	{
		get
		{
			return use_compatible_text_rendering;
		}
		set
		{
			use_compatible_text_rendering = value;
		}
	}

	[SettingsBindable(true)]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
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

	public AutomationLiveSetting LiveSetting
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

	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
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

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event EventHandler ImeModeChanged
	{
		add
		{
			base.ImeModeChanged += value;
		}
		remove
		{
			base.ImeModeChanged -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event KeyEventHandler KeyDown
	{
		add
		{
			base.KeyDown += value;
		}
		remove
		{
			base.KeyDown -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event KeyPressEventHandler KeyPress
	{
		add
		{
			base.KeyPress += value;
		}
		remove
		{
			base.KeyPress -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new event KeyEventHandler KeyUp
	{
		add
		{
			base.KeyUp += value;
		}
		remove
		{
			base.KeyUp -= value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public new event EventHandler TabStopChanged
	{
		add
		{
			base.TabStopChanged += value;
		}
		remove
		{
			base.TabStopChanged -= value;
		}
	}

	public event EventHandler TextAlignChanged
	{
		add
		{
			base.Events.AddHandler(TextAlignChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(TextAlignChangedEvent, value);
		}
	}

	public Label()
	{
		autosize = false;
		TabStop = false;
		string_format = new StringFormat();
		string_format.FormatFlags = StringFormatFlags.LineLimit;
		TextAlign = ContentAlignment.TopLeft;
		image = null;
		UseMnemonic = true;
		image_list = null;
		image_align = ContentAlignment.MiddleCenter;
		SetUseMnemonic(UseMnemonic);
		flat_style = FlatStyle.Standard;
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		can_cache_preferred_size = true;
	}

	internal override Size GetPreferredSizeCore(Size proposed)
	{
		Size size = new Size(base.Padding.Horizontal, base.Padding.Vertical);
		if (use_compatible_text_rendering)
		{
			size.Height += ((border_style == BorderStyle.None) ? 3 : 6);
		}
		Size size2;
		if (Text == string.Empty)
		{
			size2 = new Size(0, Font.Height);
		}
		else
		{
			int width = ((proposed.Width <= 1) ? int.MaxValue : (proposed.Width - size.Width));
			size2 = Size.Ceiling(TextRenderer.MeasureString(Text, Font, width, string_format));
			size2.Width += 3;
		}
		return size2 + size;
	}

	public override Size GetPreferredSize(Size proposedSize)
	{
		if (proposedSize.Width == 1)
		{
			proposedSize.Width = 0;
		}
		return base.GetPreferredSize(proposedSize);
	}

	protected Rectangle CalcImageRenderBounds(Image image, Rectangle r, ContentAlignment align)
	{
		Rectangle result = r;
		result.Inflate(-2, -2);
		int num = r.X;
		int num2 = r.Y;
		switch (align)
		{
		case ContentAlignment.TopCenter:
		case ContentAlignment.MiddleCenter:
		case ContentAlignment.BottomCenter:
			num += (r.Width - image.Width) / 2;
			break;
		case ContentAlignment.TopRight:
		case ContentAlignment.MiddleRight:
		case ContentAlignment.BottomRight:
			num += r.Width - image.Width;
			break;
		}
		switch (align)
		{
		case ContentAlignment.BottomLeft:
		case ContentAlignment.BottomCenter:
		case ContentAlignment.BottomRight:
			num2 += r.Height - image.Height;
			break;
		case ContentAlignment.MiddleLeft:
		case ContentAlignment.MiddleCenter:
		case ContentAlignment.MiddleRight:
			num2 += (r.Height - image.Height) / 2;
			break;
		}
		result.X = num;
		result.Y = num2;
		result.Width = image.Width;
		result.Height = image.Height;
		return result;
	}

	protected override AccessibleObject CreateAccessibilityInstance()
	{
		return base.CreateAccessibilityInstance();
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (disposing)
		{
			string_format.Dispose();
		}
	}

	protected internal void DrawImage(Graphics g, Image image, Rectangle r, ContentAlignment align)
	{
		if (image != null && g != null)
		{
			Rectangle rectangle = CalcImageRenderBounds(image, r, align);
			if (base.Enabled)
			{
				g.DrawImage(image, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
			}
			else
			{
				ControlPaint.DrawImageDisabled(g, image, rectangle.X, rectangle.Y, BackColor);
			}
		}
	}

	protected override void OnEnabledChanged(EventArgs e)
	{
		base.OnEnabledChanged(e);
	}

	protected override void OnFontChanged(EventArgs e)
	{
		base.OnFontChanged(e);
		if (SelfSizing)
		{
			CalcAutoSize();
		}
		Invalidate();
	}

	protected override void OnPaddingChanged(EventArgs e)
	{
		base.OnPaddingChanged(e);
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		ThemeElements.LabelPainter.Draw(e.Graphics, base.ClientRectangle, this);
		base.OnPaint(e);
	}

	protected override void OnParentChanged(EventArgs e)
	{
		base.OnParentChanged(e);
		if (SelfSizing)
		{
			CalcAutoSize();
		}
	}

	protected override void OnRightToLeftChanged(EventArgs e)
	{
		base.OnRightToLeftChanged(e);
	}

	protected virtual void OnTextAlignChanged(EventArgs e)
	{
		((EventHandler)base.Events[TextAlignChangedEvent])?.Invoke(this, e);
	}

	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
		if (SelfSizing)
		{
			CalcAutoSize();
		}
		else if (base.Parent != null)
		{
			base.Parent.PerformLayout(this, "Text");
		}
		Invalidate();
	}

	protected override void OnVisibleChanged(EventArgs e)
	{
		base.OnVisibleChanged(e);
	}

	protected override bool ProcessMnemonic(char charCode)
	{
		if (Control.IsMnemonic(charCode, Text))
		{
			if (base.Parent != null)
			{
				base.Parent.SelectNextControl(this, forward: true, tabStopOnly: false, nested: false, wrap: false);
			}
			return true;
		}
		return base.ProcessMnemonic(charCode);
	}

	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
		if (SelfSizing)
		{
			Size preferredSize = base.PreferredSize;
			width = preferredSize.Width;
			height = preferredSize.Height;
		}
		base.SetBoundsCore(x, y, width, height, specified);
	}

	public override string ToString()
	{
		return base.ToString() + ", Text: " + Text;
	}

	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 43)
		{
			m.Result = (IntPtr)1;
		}
		else
		{
			base.WndProc(ref m);
		}
	}

	private void CalcAutoSize()
	{
		if (AutoSize)
		{
			cached_preferred_size = Size.Empty;
			Size preferredSize = base.PreferredSize;
			SetBounds(base.Left, base.Top, preferredSize.Width, preferredSize.Height, BoundsSpecified.Size);
		}
	}

	private void SetUseMnemonic(bool use)
	{
		if (use)
		{
			string_format.HotkeyPrefix = HotkeyPrefix.Show;
		}
		else
		{
			string_format.HotkeyPrefix = HotkeyPrefix.None;
		}
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
	}

	protected override void OnHandleDestroyed(EventArgs e)
	{
		base.OnHandleDestroyed(e);
	}

	protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
