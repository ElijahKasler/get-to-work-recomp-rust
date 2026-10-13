using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace System.Windows.Forms;

[Designer("System.Windows.Forms.Design.PanelDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.IDesigner")]
[DefaultProperty("BorderStyle")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[DefaultEvent("Paint")]
[Docking(DockingBehavior.Ask)]
public class Panel : ScrollableControl
{
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public override bool AutoSize
	{
		get
		{
			return base.AutoSize;
		}
		set
		{
			base.AutoSize = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(AutoSizeMode.GrowOnly)]
	[Localizable(true)]
	public virtual AutoSizeMode AutoSizeMode
	{
		get
		{
			return GetAutoSizeMode();
		}
		set
		{
			SetAutoSizeMode(value);
		}
	}

	[DefaultValue(BorderStyle.None)]
	[DispId(-504)]
	public BorderStyle BorderStyle
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

	[DefaultValue(false)]
	public new bool TabStop
	{
		get
		{
			return base.TabStop;
		}
		set
		{
			if (value != TabStop)
			{
				base.TabStop = value;
			}
		}
	}

	[Bindable(false)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
			if (!(value == Text))
			{
				base.Text = value;
				Refresh();
			}
		}
	}

	protected override CreateParams CreateParams => base.CreateParams;

	protected override Size DefaultSize => ThemeEngine.Current.PanelDefaultSize;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	public new event EventHandler AutoSizeChanged
	{
		add
		{
			base.AutoSizeChanged += value;
		}
		remove
		{
			base.AutoSizeChanged -= value;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
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

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
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
	public new event EventHandler TextChanged
	{
		add
		{
			base.TextChanged += value;
		}
		remove
		{
			base.TextChanged -= value;
		}
	}

	public Panel()
	{
		base.TabStop = false;
		SetStyle(ControlStyles.Selectable, value: false);
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
		can_cache_preferred_size = true;
	}

	public override string ToString()
	{
		return base.ToString() + ", BorderStyle: " + BorderStyle;
	}

	protected override void OnResize(EventArgs eventargs)
	{
		base.OnResize(eventargs);
		Invalidate(invalidateChildren: true);
	}

	internal override Size GetPreferredSizeCore(Size proposedSize)
	{
		Size size = SizeFromClientSize(Size.Empty) + base.Padding.Size;
		return LayoutEngine.GetPreferredSize(this, proposedSize - size) + size;
	}
}
