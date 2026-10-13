using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

[TypeConverter(typeof(ColumnHeaderConverter))]
[ToolboxItem(false)]
[DesignTimeVisible(false)]
[DefaultProperty("Text")]
public class ColumnHeader : Component, ICloneable
{
	private StringFormat format = new StringFormat();

	private string text = "ColumnHeader";

	private HorizontalAlignment text_alignment;

	private int width = ThemeEngine.Current.ListViewDefaultColumnWidth;

	private int image_index = -1;

	private string image_key = string.Empty;

	private string name = string.Empty;

	private object tag;

	private int display_index = -1;

	private Rectangle column_rect = Rectangle.Empty;

	private bool pressed;

	private ListView owner;

	private static object UIATextChangedEvent = new object();

	internal bool Pressed
	{
		get
		{
			return pressed;
		}
		set
		{
			pressed = value;
		}
	}

	internal int X
	{
		get
		{
			return column_rect.X;
		}
		set
		{
			column_rect.X = value;
		}
	}

	internal int Y
	{
		get
		{
			return column_rect.Y;
		}
		set
		{
			column_rect.Y = value;
		}
	}

	internal int Wd
	{
		get
		{
			return column_rect.Width;
		}
		set
		{
			column_rect.Width = value;
		}
	}

	internal int Ht
	{
		get
		{
			return column_rect.Height;
		}
		set
		{
			column_rect.Height = value;
		}
	}

	internal Rectangle Rect
	{
		get
		{
			return column_rect;
		}
		set
		{
			column_rect = value;
		}
	}

	internal StringFormat Format => format;

	internal int InternalDisplayIndex
	{
		get
		{
			return display_index;
		}
		set
		{
			display_index = value;
		}
	}

	[RefreshProperties(RefreshProperties.Repaint)]
	[Localizable(true)]
	public int DisplayIndex
	{
		get
		{
			if (owner == null)
			{
				return display_index;
			}
			return owner.GetReorderedColumnIndex(this);
		}
		set
		{
			if (owner == null)
			{
				display_index = value;
				return;
			}
			if (value < 0 || value >= owner.Columns.Count)
			{
				throw new ArgumentOutOfRangeException("DisplayIndex");
			}
			owner.ReorderColumn(this, value, fireEvent: false);
		}
	}

	[TypeConverter(typeof(ImageIndexConverter))]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DefaultValue(-1)]
	[RefreshProperties(RefreshProperties.Repaint)]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public int ImageIndex
	{
		get
		{
			return image_index;
		}
		set
		{
			if (value < -1)
			{
				throw new ArgumentOutOfRangeException("ImageIndex");
			}
			image_index = value;
			image_key = string.Empty;
			if (owner != null)
			{
				owner.header_control.Invalidate();
			}
		}
	}

	[RefreshProperties(RefreshProperties.Repaint)]
	[Editor("System.Windows.Forms.Design.ImageIndexEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DefaultValue("")]
	[TypeConverter(typeof(ImageKeyConverter))]
	public string ImageKey
	{
		get
		{
			return image_key;
		}
		set
		{
			image_key = ((value == null) ? string.Empty : value);
			image_index = -1;
			if (owner != null)
			{
				owner.header_control.Invalidate();
			}
		}
	}

	[Browsable(false)]
	public ImageList ImageList
	{
		get
		{
			if (owner == null)
			{
				return null;
			}
			return owner.SmallImageList;
		}
	}

	[Browsable(false)]
	public int Index
	{
		get
		{
			if (owner != null)
			{
				return owner.Columns.IndexOf(this);
			}
			return -1;
		}
	}

	[Browsable(false)]
	public ListView ListView => owner;

	[Browsable(false)]
	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = ((value == null) ? string.Empty : value);
		}
	}

	[DefaultValue(null)]
	[Bindable(true)]
	[Localizable(false)]
	[TypeConverter(typeof(StringConverter))]
	public object Tag
	{
		get
		{
			return tag;
		}
		set
		{
			tag = value;
		}
	}

	[Localizable(true)]
	public string Text
	{
		get
		{
			return text;
		}
		set
		{
			if (text != value)
			{
				text = value;
				if (owner != null)
				{
					owner.Redraw(recalculate: true);
				}
				OnUIATextChanged();
			}
		}
	}

	[Localizable(true)]
	[DefaultValue(HorizontalAlignment.Left)]
	public HorizontalAlignment TextAlign
	{
		get
		{
			return text_alignment;
		}
		set
		{
			text_alignment = value;
			if (owner != null)
			{
				owner.Redraw(recalculate: true);
			}
		}
	}

	[Localizable(true)]
	[DefaultValue(60)]
	public int Width
	{
		get
		{
			return width;
		}
		set
		{
			if (width != value)
			{
				width = value;
				if (owner != null)
				{
					owner.Redraw(recalculate: true);
					owner.RaiseColumnWidthChanged(this);
				}
			}
		}
	}

	internal event EventHandler UIATextChanged
	{
		add
		{
			base.Events.AddHandler(UIATextChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(UIATextChangedEvent, value);
		}
	}

	internal ColumnHeader(ListView owner, string text, HorizontalAlignment alignment, int width)
	{
		this.owner = owner;
		this.text = text;
		this.width = width;
		text_alignment = alignment;
		CalcColumnHeader();
	}

	internal ColumnHeader(string key, string text, int width, HorizontalAlignment textAlign)
	{
		Name = key;
		Text = text;
		this.width = width;
		text_alignment = textAlign;
		CalcColumnHeader();
	}

	public ColumnHeader()
	{
	}

	public ColumnHeader(int imageIndex)
	{
		ImageIndex = imageIndex;
	}

	public ColumnHeader(string imageKey)
	{
		ImageKey = imageKey;
	}

	internal void CalcColumnHeader()
	{
		if (text_alignment == HorizontalAlignment.Center)
		{
			format.Alignment = StringAlignment.Center;
		}
		else if (text_alignment == HorizontalAlignment.Right)
		{
			format.Alignment = StringAlignment.Far;
		}
		else
		{
			format.Alignment = StringAlignment.Near;
		}
		format.LineAlignment = StringAlignment.Center;
		format.Trimming = StringTrimming.EllipsisCharacter;
		format.FormatFlags = StringFormatFlags.NoWrap;
		if (owner != null)
		{
			column_rect.Height = ThemeEngine.Current.ListViewGetHeaderHeight(owner, owner.Font);
		}
		else
		{
			column_rect.Height = ThemeEngine.Current.ListViewGetHeaderHeight(null, ThemeEngine.Current.DefaultFont);
		}
		column_rect.Width = 0;
		if (width >= 0)
		{
			column_rect.Width = width;
		}
		else
		{
			if (Index == -1)
			{
				return;
			}
			bool num = Index == owner.Columns.Count - 1 && width == -2;
			Rectangle clientRectangle = owner.ClientRectangle;
			column_rect.Width = owner.GetChildColumnSize(Index).Width;
			width = column_rect.Width;
			if (num && column_rect.X + column_rect.Width < clientRectangle.Width)
			{
				width = clientRectangle.Width - column_rect.X;
				if (owner.v_scroll.Visible)
				{
					width -= owner.v_scroll.Width;
				}
				column_rect.Width = width;
			}
		}
	}

	internal void SetListView(ListView list_view)
	{
		owner = list_view;
	}

	public void AutoResize(ColumnHeaderAutoResizeStyle headerAutoResize)
	{
		switch (headerAutoResize)
		{
		case ColumnHeaderAutoResizeStyle.ColumnContent:
			Width = -1;
			break;
		case ColumnHeaderAutoResizeStyle.HeaderSize:
			Width = -2;
			break;
		default:
			throw new InvalidEnumArgumentException("headerAutoResize", (int)headerAutoResize, typeof(ColumnHeaderAutoResizeStyle));
		case ColumnHeaderAutoResizeStyle.None:
			break;
		}
	}

	public object Clone()
	{
		return new ColumnHeader
		{
			text = text,
			text_alignment = text_alignment,
			width = width,
			owner = owner,
			format = (StringFormat)Format.Clone(),
			column_rect = Rectangle.Empty
		};
	}

	public override string ToString()
	{
		return $"ColumnHeader: Text: {text}";
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	private void OnUIATextChanged()
	{
		((EventHandler)base.Events[UIATextChangedEvent])?.Invoke(this, EventArgs.Empty);
	}
}
