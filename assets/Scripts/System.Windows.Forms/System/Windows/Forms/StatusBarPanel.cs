using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace System.Windows.Forms;

[DesignTimeVisible(false)]
[DefaultProperty("Text")]
[ToolboxItem(false)]
public class StatusBarPanel : Component, ISupportInitialize
{
	private StatusBar parent;

	private bool initializing;

	private string text = string.Empty;

	private string tool_tip_text = string.Empty;

	private Icon icon;

	private HorizontalAlignment alignment;

	private StatusBarPanelAutoSize auto_size = StatusBarPanelAutoSize.None;

	private StatusBarPanelBorderStyle border_style = StatusBarPanelBorderStyle.Sunken;

	private StatusBarPanelStyle style = StatusBarPanelStyle.Text;

	private int width = 100;

	private int min_width = 10;

	internal int X;

	private string name;

	private object tag;

	private static object UIATextChangedEvent = new object();

	[DefaultValue(HorizontalAlignment.Left)]
	[Localizable(true)]
	public HorizontalAlignment Alignment
	{
		get
		{
			return alignment;
		}
		set
		{
			alignment = value;
			InvalidateContents();
		}
	}

	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(StatusBarPanelAutoSize.None)]
	public StatusBarPanelAutoSize AutoSize
	{
		get
		{
			return auto_size;
		}
		set
		{
			auto_size = value;
			Invalidate();
		}
	}

	[DispId(-504)]
	[DefaultValue(StatusBarPanelBorderStyle.Sunken)]
	public StatusBarPanelBorderStyle BorderStyle
	{
		get
		{
			return border_style;
		}
		set
		{
			border_style = value;
			Invalidate();
		}
	}

	[DefaultValue(null)]
	[Localizable(true)]
	public Icon Icon
	{
		get
		{
			return icon;
		}
		set
		{
			icon = value;
			InvalidateContents();
		}
	}

	[DefaultValue(10)]
	[Localizable(true)]
	[RefreshProperties(RefreshProperties.All)]
	public int MinWidth
	{
		get
		{
			return min_width;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			min_width = value;
			if (min_width > width)
			{
				width = min_width;
			}
			Invalidate();
		}
	}

	[Localizable(true)]
	public string Name
	{
		get
		{
			if (name == null)
			{
				return string.Empty;
			}
			return name;
		}
		set
		{
			name = value;
		}
	}

	[Localizable(true)]
	[DefaultValue(100)]
	public int Width
	{
		get
		{
			return width;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentException("value");
			}
			if (initializing)
			{
				width = value;
			}
			else
			{
				SetWidth(value);
			}
			Invalidate();
		}
	}

	[DefaultValue(StatusBarPanelStyle.Text)]
	public StatusBarPanelStyle Style
	{
		get
		{
			return style;
		}
		set
		{
			style = value;
			Invalidate();
		}
	}

	[TypeConverter(typeof(StringConverter))]
	[Localizable(false)]
	[Bindable(true)]
	[DefaultValue(null)]
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
	[DefaultValue("")]
	public string Text
	{
		get
		{
			return text;
		}
		set
		{
			text = value;
			InvalidateContents();
			OnUIATextChanged(EventArgs.Empty);
		}
	}

	[DefaultValue("")]
	[Localizable(true)]
	public string ToolTipText
	{
		get
		{
			return tool_tip_text;
		}
		set
		{
			tool_tip_text = value;
		}
	}

	[Browsable(false)]
	public StatusBar Parent => parent;

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

	internal void OnUIATextChanged(EventArgs e)
	{
		((EventHandler)base.Events[UIATextChangedEvent])?.Invoke(this, e);
	}

	private void Invalidate()
	{
		if (parent != null)
		{
			parent.UpdatePanel(this);
		}
	}

	private void InvalidateContents()
	{
		if (parent != null)
		{
			parent.UpdatePanelContents(this);
		}
	}

	internal void SetParent(StatusBar parent)
	{
		this.parent = parent;
	}

	internal void SetWidth(int width)
	{
		this.width = width;
		if (min_width > this.width)
		{
			this.width = min_width;
		}
	}

	public override string ToString()
	{
		return "StatusBarPanel: {" + Text + "}";
	}

	protected override void Dispose(bool disposing)
	{
	}

	public void BeginInit()
	{
		initializing = true;
	}

	public void EndInit()
	{
		if (initializing)
		{
			if (min_width > width)
			{
				width = min_width;
			}
			initializing = false;
		}
	}
}
