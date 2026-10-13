using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace System.Windows.Forms;

[ComVisible(true)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public class StatusStrip : ToolStrip
{
	private class StatusStripAccessibleObject : AccessibleObject
	{
	}

	private bool sizing_grip;

	[DefaultValue(DockStyle.Bottom)]
	public override DockStyle Dock
	{
		get
		{
			return base.Dock;
		}
		set
		{
			base.Dock = value;
		}
	}

	[DefaultValue(false)]
	[Browsable(false)]
	public new bool CanOverflow
	{
		get
		{
			return base.CanOverflow;
		}
		set
		{
			base.CanOverflow = value;
		}
	}

	[DefaultValue(ToolStripGripStyle.Hidden)]
	public new ToolStripGripStyle GripStyle
	{
		get
		{
			return base.GripStyle;
		}
		set
		{
			base.GripStyle = value;
		}
	}

	[DefaultValue(ToolStripLayoutStyle.Table)]
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

	[Browsable(false)]
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

	[DefaultValue(false)]
	public new bool ShowItemToolTips
	{
		get
		{
			return base.ShowItemToolTips;
		}
		set
		{
			base.ShowItemToolTips = value;
		}
	}

	[Browsable(false)]
	public Rectangle SizeGripBounds => new Rectangle(base.Width - 12, 0, 12, base.Height);

	[DefaultValue(true)]
	public bool SizingGrip
	{
		get
		{
			return sizing_grip;
		}
		set
		{
			sizing_grip = value;
		}
	}

	[DefaultValue(true)]
	public new bool Stretch
	{
		get
		{
			return base.Stretch;
		}
		set
		{
			base.Stretch = value;
		}
	}

	protected override DockStyle DefaultDock => DockStyle.Bottom;

	protected override Padding DefaultPadding
	{
		get
		{
			if (base.Orientation == Orientation.Horizontal)
			{
				return new Padding(1, 0, 14, 0);
			}
			return new Padding(1, 3, 1, 22);
		}
	}

	protected override bool DefaultShowItemToolTips => false;

	protected override Size DefaultSize => new Size(200, 22);

	[Browsable(false)]
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

	public StatusStrip()
	{
		SetStyle(ControlStyles.ResizeRedraw, value: true);
		base.CanOverflow = false;
		GripStyle = ToolStripGripStyle.Hidden;
		base.LayoutStyle = ToolStripLayoutStyle.Table;
		base.RenderMode = ToolStripRenderMode.System;
		sizing_grip = true;
		base.Stretch = true;
	}

	protected override AccessibleObject CreateAccessibilityInstance()
	{
		return new StatusStripAccessibleObject();
	}

	protected internal override ToolStripItem CreateDefaultItem(string text, Image image, EventHandler onClick)
	{
		if (text == "-")
		{
			return new ToolStripSeparator();
		}
		return new ToolStripStatusLabel(text, image, onClick);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected override void OnLayout(LayoutEventArgs levent)
	{
		if (LayoutStyle == ToolStripLayoutStyle.Table)
		{
			OnSpringTableLayoutCore();
		}
		base.OnLayout(levent);
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
		base.OnPaintBackground(e);
		if (sizing_grip)
		{
			base.Renderer.DrawStatusStripSizingGrip(new ToolStripRenderEventArgs(e.Graphics, this, base.Bounds, SystemColors.Control));
		}
	}

	protected virtual void OnSpringTableLayoutCore()
	{
		SuspendLayout();
		TableLayoutSettings tableLayoutSettings = (TableLayoutSettings)base.LayoutSettings;
		tableLayoutSettings.RowCount = 0;
		tableLayoutSettings.ColumnCount = 0;
		tableLayoutSettings.ColumnStyles.Clear();
		tableLayoutSettings.RowStyles.Clear();
		if (base.Orientation == Orientation.Horizontal)
		{
			foreach (ToolStripItem item in Items)
			{
				ColumnStyle columnStyle = new ColumnStyle();
				if (item is ToolStripStatusLabel { Spring: not false })
				{
					columnStyle.SizeType = SizeType.Percent;
					columnStyle.Width = 100f;
					item.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
				}
				else
				{
					item.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
				}
				tableLayoutSettings.ColumnStyles.Add(columnStyle);
			}
			tableLayoutSettings.ColumnStyles.Add(new ColumnStyle());
			tableLayoutSettings.ColumnCount = tableLayoutSettings.ColumnStyles.Count;
		}
		else
		{
			foreach (ToolStripItem item2 in Items)
			{
				RowStyle rowStyle = new RowStyle();
				if (item2 is ToolStripStatusLabel { Spring: not false })
				{
					rowStyle.SizeType = SizeType.Percent;
					rowStyle.Height = 100f;
					item2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
				}
				else
				{
					item2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				}
				tableLayoutSettings.RowStyles.Add(rowStyle);
			}
			tableLayoutSettings.RowStyles.Add(new RowStyle());
			tableLayoutSettings.RowCount = tableLayoutSettings.RowStyles.Count;
		}
		ResumeLayout(performLayout: false);
	}

	protected override void SetDisplayedItems()
	{
		displayed_items.ClearInternal();
		foreach (ToolStripItem item in Items)
		{
			if (item.Placement == ToolStripItemPlacement.Main && item.Available)
			{
				displayed_items.AddNoOwnerOrLayout(item);
				item.Parent = this;
			}
		}
	}

	protected override void WndProc(ref Message m)
	{
		switch ((Msg)m.Msg)
		{
		case Msg.WM_MOUSEMOVE:
			if (Control.FromParamToMouseButtons(m.WParam.ToInt32()) == MouseButtons.None)
			{
				Point pt2 = new Point(Control.LowOrder(m.LParam.ToInt32()), Control.HighOrder(m.LParam.ToInt32()));
				if (SizingGrip && SizeGripBounds.Contains(pt2))
				{
					Cursor = Cursors.SizeNWSE;
					return;
				}
				Cursor = Cursors.Default;
			}
			break;
		case Msg.WM_LBUTTONDOWN:
		{
			Point pt = new Point(Control.LowOrder(m.LParam.ToInt32()), Control.HighOrder(m.LParam.ToInt32()));
			Form form = FindForm();
			if (SizingGrip && SizeGripBounds.Contains(pt))
			{
				if (!form.IsMdiChild)
				{
					XplatUI.BeginMoveResize(form.Handle);
				}
				XplatUI.SendMessage(form.Handle, Msg.WM_NCLBUTTONDOWN, (IntPtr)17, IntPtr.Zero);
				return;
			}
			break;
		}
		}
		base.WndProc(ref m);
	}
}
