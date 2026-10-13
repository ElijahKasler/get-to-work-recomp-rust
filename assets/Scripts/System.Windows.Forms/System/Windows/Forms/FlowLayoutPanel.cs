using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms.Layout;

namespace System.Windows.Forms;

[Designer("System.Windows.Forms.Design.FlowLayoutPanelDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.IDesigner")]
[Docking(DockingBehavior.Ask)]
[DefaultProperty("FlowDirection")]
[ProvideProperty("FlowBreak", typeof(Control))]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class FlowLayoutPanel : Panel, IExtenderProvider
{
	private FlowLayoutSettings settings;

	[DefaultValue(FlowDirection.LeftToRight)]
	[Localizable(true)]
	public FlowDirection FlowDirection
	{
		get
		{
			return LayoutSettings.FlowDirection;
		}
		set
		{
			LayoutSettings.FlowDirection = value;
		}
	}

	[Localizable(true)]
	[DefaultValue(true)]
	public bool WrapContents
	{
		get
		{
			return LayoutSettings.WrapContents;
		}
		set
		{
			LayoutSettings.WrapContents = value;
		}
	}

	public override LayoutEngine LayoutEngine => FlowLayout.Instance;

	internal FlowLayoutSettings LayoutSettings
	{
		get
		{
			if (settings == null)
			{
				settings = new FlowLayoutSettings(this);
			}
			return settings;
		}
	}

	public FlowLayoutPanel()
	{
		CreateDockPadding();
	}

	[DisplayName("FlowBreak")]
	[DefaultValue(false)]
	public bool GetFlowBreak(Control control)
	{
		return LayoutSettings.GetFlowBreak(control);
	}

	[DisplayName("FlowBreak")]
	public void SetFlowBreak(Control control, bool value)
	{
		LayoutSettings.SetFlowBreak(control, value);
	}

	bool IExtenderProvider.CanExtend(object obj)
	{
		if (obj is Control && (obj as Control).Parent == this)
		{
			return true;
		}
		return false;
	}
}
