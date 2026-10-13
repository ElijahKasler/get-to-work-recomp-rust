using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices;

namespace System.Windows.Forms;

[Designer("System.Windows.Forms.Design.UserControlDocumentDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(IRootDesigner))]
[ComVisible(true)]
[DefaultEvent("Load")]
[Designer("System.Windows.Forms.Design.ControlDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.IDesigner")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[DesignerCategory("UserControl")]
public class UserControl : ContainerControl
{
	private static object LoadEvent = new object();

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
	[Localizable(true)]
	[DefaultValue(AutoSizeMode.GrowOnly)]
	public AutoSizeMode AutoSizeMode
	{
		get
		{
			return GetAutoSizeMode();
		}
		set
		{
			if (GetAutoSizeMode() != value)
			{
				SetAutoSizeMode(value);
			}
		}
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public override AutoValidate AutoValidate
	{
		get
		{
			return base.AutoValidate;
		}
		set
		{
			base.AutoValidate = value;
		}
	}

	protected override Size DefaultSize => new Size(150, 150);

	[Bindable(false)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
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

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			createParams.Style |= 65536;
			createParams.ExStyle |= 65536;
			return createParams;
		}
	}

	[Browsable(true)]
	[DefaultValue(BorderStyle.None)]
	[EditorBrowsable(EditorBrowsableState.Always)]
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

	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	public new event EventHandler AutoValidateChanged
	{
		add
		{
			base.AutoValidateChanged += value;
		}
		remove
		{
			base.AutoValidateChanged -= value;
		}
	}

	public event EventHandler Load
	{
		add
		{
			base.Events.AddHandler(LoadEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(LoadEvent, value);
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

	public UserControl()
	{
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public override bool ValidateChildren()
	{
		return base.ValidateChildren();
	}

	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public override bool ValidateChildren(ValidationConstraints validationConstraints)
	{
		return base.ValidateChildren(validationConstraints);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override void OnCreateControl()
	{
		base.OnCreateControl();
		OnLoad(EventArgs.Empty);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected virtual void OnLoad(EventArgs e)
	{
		((EventHandler)base.Events[LoadEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override void OnMouseDown(MouseEventArgs e)
	{
		base.OnMouseDown(e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override void WndProc(ref Message m)
	{
		if (m.Msg == 7)
		{
			if (base.ActiveControl == null)
			{
				SelectNextControl(null, forward: true, tabStopOnly: true, nested: true, wrap: false);
			}
			base.WndProc(ref m);
		}
		else
		{
			base.WndProc(ref m);
		}
	}
}
