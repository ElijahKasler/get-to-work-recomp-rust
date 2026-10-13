using System.Collections;
using System.Drawing;

namespace System.Windows.Forms.Layout;

internal class DefaultLayout : LayoutEngine
{
	internal static readonly DefaultLayout Instance = new DefaultLayout();

	private DefaultLayout()
	{
	}

	public override void InitLayout(object child, BoundsSpecified specified)
	{
		IArrangedElement arrangedElement = (IArrangedElement)child;
		IArrangedElement parent = arrangedElement.Parent;
		if (parent != null)
		{
			Rectangle bounds = arrangedElement.Bounds;
			if ((specified & (BoundsSpecified.X | BoundsSpecified.Width)) != BoundsSpecified.None)
			{
				arrangedElement.DistanceRight = parent.DisplayRectangle.Right - bounds.X - bounds.Width;
			}
			if ((specified & (BoundsSpecified.Y | BoundsSpecified.Height)) != BoundsSpecified.None)
			{
				arrangedElement.DistanceBottom = parent.DisplayRectangle.Bottom - bounds.Y - bounds.Height;
			}
		}
	}

	private static void LayoutDockedChildren(IArrangedElement parent, IList controls)
	{
		Rectangle displayRectangle = parent.DisplayRectangle;
		IArrangedElement arrangedElement = null;
		for (int num = controls.Count - 1; num >= 0; num--)
		{
			IArrangedElement arrangedElement2 = (IArrangedElement)controls[num];
			Size size = arrangedElement2.Bounds.Size;
			if (arrangedElement2.Visible && arrangedElement2.Dock != DockStyle.None)
			{
				if (arrangedElement2 is MdiClient)
				{
					arrangedElement = arrangedElement2;
				}
				else
				{
					switch (arrangedElement2.Dock)
					{
					case DockStyle.Left:
						if (arrangedElement2.AutoSize)
						{
							size = arrangedElement2.GetPreferredSize(new Size(0, displayRectangle.Height));
						}
						arrangedElement2.SetBounds(displayRectangle.Left, displayRectangle.Y, size.Width, displayRectangle.Height, BoundsSpecified.None);
						displayRectangle.X += size.Width;
						displayRectangle.Width -= size.Width;
						break;
					case DockStyle.Top:
						if (arrangedElement2.AutoSize)
						{
							size = arrangedElement2.GetPreferredSize(new Size(displayRectangle.Width, 0));
						}
						arrangedElement2.SetBounds(displayRectangle.Left, displayRectangle.Y, displayRectangle.Width, size.Height, BoundsSpecified.None);
						displayRectangle.Y += size.Height;
						displayRectangle.Height -= size.Height;
						break;
					case DockStyle.Right:
						if (arrangedElement2.AutoSize)
						{
							size = arrangedElement2.GetPreferredSize(new Size(0, displayRectangle.Height));
						}
						arrangedElement2.SetBounds(displayRectangle.Right - size.Width, displayRectangle.Y, size.Width, displayRectangle.Height, BoundsSpecified.None);
						displayRectangle.Width -= size.Width;
						break;
					case DockStyle.Bottom:
						if (arrangedElement2.AutoSize)
						{
							size = arrangedElement2.GetPreferredSize(new Size(displayRectangle.Width, 0));
						}
						arrangedElement2.SetBounds(displayRectangle.Left, displayRectangle.Bottom - size.Height, displayRectangle.Width, size.Height, BoundsSpecified.None);
						displayRectangle.Height -= size.Height;
						break;
					case DockStyle.Fill:
						arrangedElement2.SetBounds(displayRectangle.Left, displayRectangle.Top, displayRectangle.Width, displayRectangle.Height, BoundsSpecified.None);
						break;
					}
				}
			}
		}
		arrangedElement?.SetBounds(displayRectangle.Left, displayRectangle.Top, displayRectangle.Width, displayRectangle.Height, BoundsSpecified.None);
	}

	private static void LayoutAnchoredChildren(IArrangedElement parent, IList controls)
	{
		Rectangle displayRectangle = parent.DisplayRectangle;
		foreach (IArrangedElement control in controls)
		{
			if (!control.Visible || control.Dock != DockStyle.None)
			{
				continue;
			}
			AnchorStyles anchor = control.Anchor;
			Rectangle bounds = control.Bounds;
			int num = bounds.Left;
			int num2 = bounds.Top;
			int num3 = bounds.Width;
			int num4 = bounds.Height;
			if ((anchor & AnchorStyles.Right) != AnchorStyles.None)
			{
				if ((anchor & AnchorStyles.Left) != AnchorStyles.None)
				{
					num3 = displayRectangle.Right - control.DistanceRight - num;
				}
				else
				{
					num = displayRectangle.Right - control.DistanceRight - num3;
				}
			}
			else if ((anchor & AnchorStyles.Left) == 0)
			{
				num += (displayRectangle.Width - (num + num3 + control.DistanceRight)) / 2;
				control.DistanceRight = displayRectangle.Width - (num + num3);
			}
			if ((anchor & AnchorStyles.Bottom) != AnchorStyles.None)
			{
				if ((anchor & AnchorStyles.Top) != AnchorStyles.None)
				{
					num4 = displayRectangle.Bottom - control.DistanceBottom - num2;
				}
				else
				{
					num2 = displayRectangle.Bottom - control.DistanceBottom - num4;
				}
			}
			else if ((anchor & AnchorStyles.Top) == 0)
			{
				num2 += (displayRectangle.Height - (num2 + num4 + control.DistanceBottom)) / 2;
				control.DistanceBottom = displayRectangle.Height - (num2 + num4);
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			if (control.AutoSize)
			{
				Size empty = Size.Empty;
				if ((anchor & (AnchorStyles.Left | AnchorStyles.Right)) == (AnchorStyles.Left | AnchorStyles.Right))
				{
					empty.Width = num3;
				}
				if ((anchor & (AnchorStyles.Top | AnchorStyles.Bottom)) == (AnchorStyles.Top | AnchorStyles.Bottom))
				{
					empty.Height = num4;
				}
				Size preferredControlSize = GetPreferredControlSize(control, empty);
				if ((anchor & (AnchorStyles.Left | AnchorStyles.Right)) != AnchorStyles.Right)
				{
					control.DistanceRight += num3 - preferredControlSize.Width;
				}
				else
				{
					num += num3 - preferredControlSize.Width;
				}
				if ((anchor & (AnchorStyles.Top | AnchorStyles.Bottom)) != AnchorStyles.Bottom)
				{
					control.DistanceBottom += num4 - preferredControlSize.Height;
				}
				else
				{
					num2 += num4 - preferredControlSize.Height;
				}
				control.SetBounds(num, num2, preferredControlSize.Width, preferredControlSize.Height, BoundsSpecified.None);
			}
			else
			{
				control.SetBounds(num, num2, num3, num4, BoundsSpecified.None);
			}
		}
	}

	public override bool Layout(object container, LayoutEventArgs args)
	{
		IArrangedContainer arrangedContainer = (IArrangedContainer)container;
		if (arrangedContainer.Controls is Control.ControlCollection controlCollection)
		{
			LayoutDockedChildren(arrangedContainer, controlCollection.GetAllControls());
			LayoutAnchoredChildren(arrangedContainer, controlCollection.GetAllControls());
		}
		else
		{
			LayoutDockedChildren(arrangedContainer, arrangedContainer.Controls);
			LayoutAnchoredChildren(arrangedContainer, arrangedContainer.Controls);
		}
		return arrangedContainer.AutoSize;
	}

	private static Size GetPreferredControlSize(IArrangedElement child, Size proposed)
	{
		Size preferredSize = child.GetPreferredSize(proposed);
		int width;
		int height;
		if (child.GetAutoSizeMode() == AutoSizeMode.GrowAndShrink)
		{
			width = preferredSize.Width;
			height = preferredSize.Height;
		}
		else
		{
			width = child.ExplicitBounds.Width;
			height = child.ExplicitBounds.Height;
			if (preferredSize.Width > width)
			{
				width = preferredSize.Width;
			}
			if (preferredSize.Height > height)
			{
				height = preferredSize.Height;
			}
		}
		return new Size(width, height);
	}

	internal override Size GetPreferredSize(object container, Size proposedConstraints)
	{
		IArrangedContainer arrangedContainer = (IArrangedContainer)container;
		IList controls = arrangedContainer.Controls;
		Size empty = Size.Empty;
		for (int num = controls.Count - 1; num >= 0; num--)
		{
			IArrangedElement arrangedElement = (IArrangedElement)controls[num];
			if (arrangedElement.Visible && arrangedElement.Dock != DockStyle.None)
			{
				if (arrangedElement.Dock == DockStyle.Left || arrangedElement.Dock == DockStyle.Right)
				{
					Size size = (arrangedElement.AutoSize ? arrangedElement.GetPreferredSize(new Size(0, proposedConstraints.Height)) : arrangedElement.Bounds.Size);
					empty.Width += size.Width;
				}
				else if (arrangedElement.Dock == DockStyle.Top || arrangedElement.Dock == DockStyle.Bottom)
				{
					Size size2 = (arrangedElement.AutoSize ? arrangedElement.GetPreferredSize(new Size(proposedConstraints.Width, 0)) : arrangedElement.Bounds.Size);
					empty.Height += size2.Height;
				}
				else if (arrangedElement.Dock == DockStyle.Fill && arrangedElement.AutoSize)
				{
					Size preferredSize = arrangedElement.GetPreferredSize(proposedConstraints);
					empty += preferredSize;
				}
			}
		}
		foreach (IArrangedElement control in arrangedContainer.Controls)
		{
			if (!control.Visible || control.Dock != DockStyle.None || (control.Anchor & (AnchorStyles.Top | AnchorStyles.Bottom)) == AnchorStyles.Bottom || (control.Anchor & (AnchorStyles.Left | AnchorStyles.Right)) == AnchorStyles.Right)
			{
				continue;
			}
			Rectangle rectangle = control.Bounds;
			if (control.AutoSize)
			{
				Size empty2 = Size.Empty;
				if ((control.Anchor & (AnchorStyles.Left | AnchorStyles.Right)) == (AnchorStyles.Left | AnchorStyles.Right))
				{
					empty2.Width = proposedConstraints.Width - control.DistanceRight - (rectangle.Left - arrangedContainer.DisplayRectangle.Left);
				}
				if ((control.Anchor & (AnchorStyles.Top | AnchorStyles.Bottom)) == (AnchorStyles.Top | AnchorStyles.Bottom))
				{
					empty2.Height = proposedConstraints.Height - control.DistanceBottom - (rectangle.Top - arrangedContainer.DisplayRectangle.Top);
				}
				Size preferredControlSize = GetPreferredControlSize(control, empty2);
				rectangle = new Rectangle(rectangle.Location, preferredControlSize);
			}
			empty.Width = Math.Max(empty.Width, rectangle.Right - arrangedContainer.Padding.Left + control.Margin.Right);
			empty.Height = Math.Max(empty.Height, rectangle.Bottom - arrangedContainer.Padding.Top + control.Margin.Bottom);
		}
		return empty;
	}
}
