using System.Collections.Generic;
using System.Drawing;

namespace System.Windows.Forms.Layout;

internal class FlowLayout : LayoutEngine
{
	internal static readonly FlowLayout Instance = new FlowLayout();

	private static FlowLayoutSettings default_settings = new FlowLayoutSettings();

	private FlowLayout()
	{
	}

	public override void InitLayout(object child, BoundsSpecified specified)
	{
		base.InitLayout(child, specified);
	}

	private static FlowLayoutSettings GetLayoutSettings(IArrangedContainer container)
	{
		if (container is FlowLayoutPanel flowLayoutPanel)
		{
			return flowLayoutPanel.LayoutSettings;
		}
		if (container is ToolStrip toolStrip)
		{
			return (FlowLayoutSettings)toolStrip.LayoutSettings;
		}
		return default_settings;
	}

	public override bool Layout(object container, LayoutEventArgs args)
	{
		if (container is ToolStripPanel)
		{
			return false;
		}
		IArrangedContainer arrangedContainer = (IArrangedContainer)container;
		if (arrangedContainer.Controls.Count == 0)
		{
			return false;
		}
		FlowLayoutSettings layoutSettings = GetLayoutSettings(arrangedContainer);
		Rectangle displayRectangle = arrangedContainer.DisplayRectangle;
		Point point = layoutSettings.FlowDirection switch
		{
			FlowDirection.BottomUp => new Point(displayRectangle.Left, displayRectangle.Bottom), 
			FlowDirection.RightToLeft => new Point(displayRectangle.Right, displayRectangle.Top), 
			_ => displayRectangle.Location, 
		};
		bool flag = false;
		List<IArrangedElement> list = new List<IArrangedElement>();
		foreach (IArrangedElement control in arrangedContainer.Controls)
		{
			if (!control.Visible)
			{
				continue;
			}
			if (control.AutoSize)
			{
				Size proposedSize = new Size(int.MaxValue, Math.Max(1, displayRectangle.Height - control.Margin.Vertical));
				if (point.X == displayRectangle.Left)
				{
					proposedSize.Width = Math.Max(1, displayRectangle.Width - control.Margin.Horizontal);
				}
				Size preferredSize = control.GetPreferredSize(proposedSize);
				control.SetBounds(control.Bounds.Left, control.Bounds.Top, preferredSize.Width, preferredSize.Height, BoundsSpecified.None);
			}
			switch (layoutSettings.FlowDirection)
			{
			case FlowDirection.BottomUp:
				if (layoutSettings.WrapContents && ((point.Y < control.Bounds.Height + control.Margin.Top + control.Margin.Bottom) | flag))
				{
					point.X = FinishColumn(list);
					point.Y = displayRectangle.Bottom;
					flag = false;
					list.Clear();
				}
				point.Offset(0, control.Margin.Bottom * -1);
				control.SetBounds(point.X + control.Margin.Left, point.Y - control.Bounds.Height, control.Bounds.Width, control.Bounds.Height, BoundsSpecified.None);
				point.Y -= control.Bounds.Height + control.Margin.Top;
				break;
			default:
				if (layoutSettings.WrapContents && !(arrangedContainer is ToolStripPanel) && ((displayRectangle.Width + displayRectangle.Left - point.X < control.Bounds.Width + control.Margin.Left + control.Margin.Right) | flag))
				{
					point.Y = FinishRow(list);
					point.X = displayRectangle.Left;
					flag = false;
					list.Clear();
				}
				point.Offset(control.Margin.Left, 0);
				control.SetBounds(point.X, point.Y + control.Margin.Top, control.Bounds.Width, control.Bounds.Height, BoundsSpecified.None);
				point.X += control.Bounds.Width + control.Margin.Right;
				break;
			case FlowDirection.RightToLeft:
				if (layoutSettings.WrapContents && ((point.X < control.Bounds.Width + control.Margin.Left + control.Margin.Right) | flag))
				{
					point.Y = FinishRow(list);
					point.X = displayRectangle.Right;
					flag = false;
					list.Clear();
				}
				point.Offset(control.Margin.Right * -1, 0);
				control.SetBounds(point.X - control.Bounds.Width, point.Y + control.Margin.Top, control.Bounds.Width, control.Bounds.Height, BoundsSpecified.None);
				point.X -= control.Bounds.Width + control.Margin.Left;
				break;
			case FlowDirection.TopDown:
				if (layoutSettings.WrapContents && ((displayRectangle.Height + displayRectangle.Top - point.Y < control.Bounds.Height + control.Margin.Top + control.Margin.Bottom) | flag))
				{
					point.X = FinishColumn(list);
					point.Y = displayRectangle.Top;
					flag = false;
					list.Clear();
				}
				point.Offset(0, control.Margin.Top);
				control.SetBounds(point.X + control.Margin.Left, point.Y, control.Bounds.Width, control.Bounds.Height, BoundsSpecified.None);
				point.Y += control.Bounds.Height + control.Margin.Bottom;
				break;
			}
			list.Add(control);
			if (layoutSettings.GetFlowBreak(control))
			{
				flag = true;
			}
		}
		if (layoutSettings.FlowDirection == FlowDirection.LeftToRight || layoutSettings.FlowDirection == FlowDirection.RightToLeft)
		{
			FinishRow(list);
		}
		else
		{
			FinishColumn(list);
		}
		return arrangedContainer.AutoSize;
	}

	internal override Size GetPreferredSize(object container, Size proposedSize)
	{
		IArrangedContainer arrangedContainer = (IArrangedContainer)container;
		FlowLayoutSettings layoutSettings = GetLayoutSettings(arrangedContainer);
		int num = 0;
		int num2 = 0;
		bool flag = layoutSettings.FlowDirection == FlowDirection.LeftToRight || layoutSettings.FlowDirection == FlowDirection.RightToLeft;
		int num3 = 0;
		int num4 = 0;
		new Size(0, 0);
		bool flag2 = false;
		bool wrapContents = layoutSettings.WrapContents;
		foreach (IArrangedElement control in arrangedContainer.Controls)
		{
			if (!control.Visible)
			{
				continue;
			}
			Size size;
			if (control.AutoSize)
			{
				Size proposedSize2 = new Size(int.MaxValue, Math.Max(1, proposedSize.Height - control.Margin.Vertical));
				if (num3 == 0)
				{
					proposedSize2.Width = Math.Max(1, proposedSize.Width - control.Margin.Horizontal);
				}
				size = control.GetPreferredSize(proposedSize2);
			}
			else
			{
				size = control.ExplicitBounds.Size;
				if ((control.Anchor & (AnchorStyles.Top | AnchorStyles.Bottom)) == (AnchorStyles.Top | AnchorStyles.Bottom))
				{
					size.Height = control.MinimumSize.Height;
				}
			}
			Padding margin = control.Margin;
			if (flag)
			{
				int num5 = size.Width + margin.Horizontal;
				if (wrapContents && ((proposedSize.Width > 0 && num3 != 0 && num3 + num5 >= proposedSize.Width) | flag2))
				{
					num = Math.Max(num, num3);
					num3 = 0;
					num2 += num4;
					num4 = 0;
				}
				num3 += num5;
				num4 = Math.Max(num4, size.Height + margin.Vertical);
			}
			else
			{
				int num5 = size.Height + margin.Vertical;
				if (wrapContents && ((proposedSize.Height > 0 && num3 != 0 && num3 + num5 >= proposedSize.Height) | flag2))
				{
					num2 = Math.Max(num2, num3);
					num3 = 0;
					num += num4;
					num4 = 0;
				}
				num3 += num5;
				num4 = Math.Max(num4, size.Width + margin.Horizontal);
			}
			if (arrangedContainer != null)
			{
				flag2 = layoutSettings.GetFlowBreak(control);
			}
		}
		if (flag)
		{
			num = Math.Max(num, num3);
			num2 += num4;
		}
		else
		{
			num2 = Math.Max(num2, num3);
			num += num4;
		}
		return new Size(num, num2);
	}

	private int FinishRow(List<IArrangedElement> row)
	{
		if (row.Count == 0)
		{
			return 0;
		}
		int num = int.MaxValue;
		int num2 = 0;
		bool flag = true;
		bool flag2 = true;
		foreach (IArrangedElement item in row)
		{
			if (item.Dock != DockStyle.Fill && ((item.Anchor & AnchorStyles.Top) != AnchorStyles.Top || (item.Anchor & AnchorStyles.Bottom) != AnchorStyles.Bottom))
			{
				flag = false;
			}
			if (item.AutoSize)
			{
				flag2 = false;
			}
		}
		foreach (IArrangedElement item2 in row)
		{
			if (item2.Dock != DockStyle.Fill && ((item2.Anchor & AnchorStyles.Top) != AnchorStyles.Top || (item2.Anchor & AnchorStyles.Bottom) != AnchorStyles.Bottom || item2.AutoSize))
			{
				num2 = Math.Max(num2, item2.Bounds.Bottom + item2.Margin.Bottom);
			}
			num = Math.Min(num, item2.Bounds.Top - item2.Margin.Top);
		}
		if (num2 == 0)
		{
			foreach (IArrangedElement item3 in row)
			{
				if (item3.Dock != DockStyle.Fill && item3.AutoSize)
				{
					num2 = Math.Max(num2, item3.Bounds.Bottom + item3.Margin.Bottom);
				}
			}
		}
		if (num2 == 0)
		{
			foreach (IArrangedElement item4 in row)
			{
				if (item4.Dock == DockStyle.Fill)
				{
					num2 = Math.Max(num2, item4.Bounds.Bottom + item4.Margin.Bottom);
				}
			}
		}
		foreach (IArrangedElement item5 in row)
		{
			if (flag & flag2)
			{
				item5.SetBounds(item5.Bounds.Left, item5.Bounds.Top, item5.Bounds.Width, 0, BoundsSpecified.None);
			}
			else if (item5.Dock == DockStyle.Fill || ((item5.Anchor & AnchorStyles.Top) == AnchorStyles.Top && (item5.Anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom))
			{
				item5.SetBounds(item5.Bounds.Left, item5.Bounds.Top, item5.Bounds.Width, num2 - item5.Bounds.Top - item5.Margin.Bottom, BoundsSpecified.None);
			}
			else if (item5.Dock == DockStyle.Bottom || (item5.Anchor & AnchorStyles.Bottom) == AnchorStyles.Bottom)
			{
				item5.SetBounds(item5.Bounds.Left, num2 - item5.Margin.Bottom - item5.Bounds.Height, item5.Bounds.Width, item5.Bounds.Height, BoundsSpecified.None);
			}
			else if (item5.Dock != DockStyle.Top && (item5.Anchor & AnchorStyles.Top) != AnchorStyles.Top)
			{
				item5.SetBounds(item5.Bounds.Left, (num2 - num) / 2 - item5.Bounds.Height / 2 + (int)Math.Floor((double)(item5.Margin.Top - item5.Margin.Bottom) / 2.0) + num, item5.Bounds.Width, item5.Bounds.Height, BoundsSpecified.None);
			}
		}
		if (num2 == 0)
		{
			return num;
		}
		return num2;
	}

	private int FinishColumn(List<IArrangedElement> col)
	{
		if (col.Count == 0)
		{
			return 0;
		}
		int num = int.MaxValue;
		int num2 = 0;
		bool flag = true;
		bool flag2 = true;
		foreach (IArrangedElement item in col)
		{
			if (item.Dock != DockStyle.Fill && ((item.Anchor & AnchorStyles.Left) != AnchorStyles.Left || (item.Anchor & AnchorStyles.Right) != AnchorStyles.Right))
			{
				flag = false;
			}
			if (item.AutoSize)
			{
				flag2 = false;
			}
		}
		foreach (IArrangedElement item2 in col)
		{
			if (item2.Dock != DockStyle.Fill && ((item2.Anchor & AnchorStyles.Left) != AnchorStyles.Left || (item2.Anchor & AnchorStyles.Right) != AnchorStyles.Right || item2.AutoSize))
			{
				num2 = Math.Max(num2, item2.Bounds.Right + item2.Margin.Right);
			}
			num = Math.Min(num, item2.Bounds.Left - item2.Margin.Left);
		}
		if (num2 == 0)
		{
			foreach (IArrangedElement item3 in col)
			{
				if (item3.Dock != DockStyle.Fill && item3.AutoSize)
				{
					num2 = Math.Max(num2, item3.Bounds.Right + item3.Margin.Right);
				}
			}
		}
		if (num2 == 0)
		{
			foreach (IArrangedElement item4 in col)
			{
				if (item4.Dock == DockStyle.Fill)
				{
					num2 = Math.Max(num2, item4.Bounds.Right + item4.Margin.Right);
				}
			}
		}
		foreach (IArrangedElement item5 in col)
		{
			if (flag & flag2)
			{
				item5.SetBounds(item5.Bounds.Left, item5.Bounds.Top, 0, item5.Bounds.Height, BoundsSpecified.None);
			}
			else if (item5.Dock == DockStyle.Fill || ((item5.Anchor & AnchorStyles.Left) == AnchorStyles.Left && (item5.Anchor & AnchorStyles.Right) == AnchorStyles.Right))
			{
				item5.SetBounds(item5.Bounds.Left, item5.Bounds.Top, num2 - item5.Bounds.Left - item5.Margin.Right, item5.Bounds.Height, BoundsSpecified.None);
			}
			else if (item5.Dock == DockStyle.Right || (item5.Anchor & AnchorStyles.Right) == AnchorStyles.Right)
			{
				item5.SetBounds(num2 - item5.Margin.Right - item5.Bounds.Width, item5.Bounds.Top, item5.Bounds.Width, item5.Bounds.Height, BoundsSpecified.None);
			}
			else if (item5.Dock != DockStyle.Left && (item5.Anchor & AnchorStyles.Left) != AnchorStyles.Left)
			{
				item5.SetBounds((num2 - num) / 2 - item5.Bounds.Width / 2 + (int)Math.Floor((double)(item5.Margin.Left - item5.Margin.Right) / 2.0) + num, item5.Bounds.Top, item5.Bounds.Width, item5.Bounds.Height, BoundsSpecified.None);
			}
		}
		if (num2 == 0)
		{
			return num;
		}
		return num2;
	}
}
