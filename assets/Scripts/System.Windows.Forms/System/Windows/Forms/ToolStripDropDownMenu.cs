using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms.Layout;

namespace System.Windows.Forms;

[Designer("System.Windows.Forms.Design.ToolStripDropDownDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.IDesigner")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class ToolStripDropDownMenu : ToolStripDropDown
{
	private bool show_check_margin;

	private bool show_image_margin;

	public override Rectangle DisplayRectangle => base.DisplayRectangle;

	public override LayoutEngine LayoutEngine => base.LayoutEngine;

	[DefaultValue(ToolStripLayoutStyle.Flow)]
	public new ToolStripLayoutStyle LayoutStyle
	{
		get
		{
			return base.LayoutStyle;
		}
		set
		{
			base.LayoutStyle = value;
		}
	}

	[DefaultValue(false)]
	public bool ShowCheckMargin
	{
		get
		{
			return show_check_margin;
		}
		set
		{
			if (show_check_margin != value)
			{
				show_check_margin = value;
				PerformLayout(this, "ShowCheckMargin");
			}
		}
	}

	[DefaultValue(true)]
	public bool ShowImageMargin
	{
		get
		{
			return show_image_margin;
		}
		set
		{
			if (show_image_margin != value)
			{
				show_image_margin = value;
				PerformLayout(this, "ShowImageMargin");
			}
		}
	}

	protected override Padding DefaultPadding => base.DefaultPadding;

	protected internal override Size MaxItemSize => base.Size;

	public ToolStripDropDownMenu()
	{
		base.LayoutStyle = ToolStripLayoutStyle.Flow;
		show_image_margin = true;
	}

	protected internal override ToolStripItem CreateDefaultItem(string text, Image image, EventHandler onClick)
	{
		return base.CreateDefaultItem(text, image, onClick);
	}

	protected override void OnFontChanged(EventArgs e)
	{
		base.OnFontChanged(e);
	}

	protected override void OnLayout(LayoutEventArgs e)
	{
		int num = 0;
		foreach (ToolStripItem item in Items)
		{
			if (item.Available)
			{
				item.SetPlacement(ToolStripItemPlacement.Main);
				num = Math.Max(num, item.GetPreferredSize(Size.Empty).Width);
			}
		}
		int left = base.Padding.Left;
		num = ((!show_check_margin && !show_image_margin) ? (num + (47 - base.Padding.Horizontal)) : (num + (68 - base.Padding.Horizontal)));
		int num2 = base.Padding.Top;
		foreach (ToolStripItem item2 in Items)
		{
			if (item2.Available)
			{
				num2 += item2.Margin.Top;
				int num3 = 0;
				Size preferredSize = item2.GetPreferredSize(Size.Empty);
				num3 = ((preferredSize.Height > 22) ? preferredSize.Height : ((!(item2 is ToolStripSeparator)) ? 22 : 7));
				item2.SetBounds(new Rectangle(left, num2, num, num3));
				num2 += num3 + item2.Margin.Bottom;
			}
		}
		base.Size = new Size(num + base.Padding.Horizontal, num2 + base.Padding.Bottom);
		SetDisplayedItems();
		OnLayoutCompleted(EventArgs.Empty);
		Invalidate();
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
		ToolStripRenderEventArgs e2 = new ToolStripRenderEventArgs(affectedBounds: new Rectangle(Point.Empty, base.Size), g: e.Graphics, toolStrip: this, backColor: SystemColors.Control);
		e2.InternalConnectedArea = CalculateConnectedArea();
		base.Renderer.DrawToolStripBackground(e2);
		if (ShowCheckMargin || ShowImageMargin)
		{
			e2 = new ToolStripRenderEventArgs(e.Graphics, this, new Rectangle(e2.AffectedBounds.Location, new Size(25, e2.AffectedBounds.Height)), SystemColors.Control);
			base.Renderer.DrawImageMargin(e2);
		}
	}

	protected override void SetDisplayedItems()
	{
		base.SetDisplayedItems();
	}

	internal override Rectangle CalculateConnectedArea()
	{
		if (base.OwnerItem != null && !base.OwnerItem.IsOnDropDown && !(base.OwnerItem is MdiControlStrip.SystemMenuItem))
		{
			return new Rectangle(base.OwnerItem.GetCurrentParent().PointToScreen(base.OwnerItem.Location).X - base.Left, 0, base.OwnerItem.Width - 1, 2);
		}
		return base.CalculateConnectedArea();
	}
}
