using System.ComponentModel;
using System.Runtime.InteropServices;

namespace System.Windows.Forms;

[ComVisible(true)]
[DefaultEvent("Opening")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public class ContextMenuStrip : ToolStripDropDownMenu
{
	internal Control AssociatedControl;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Control SourceControl { get; protected set; }

	public ContextMenuStrip()
	{
	}

	public ContextMenuStrip(IContainer container)
		: this()
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected override void SetVisibleCore(bool visible)
	{
		base.SetVisibleCore(visible);
		if (visible)
		{
			XplatUI.SetTopmost(base.Handle, Enabled: true);
		}
	}

	protected override void SetOwnerControl(Control control)
	{
		base.SetOwnerControl(control);
		SourceControl = control;
	}
}
