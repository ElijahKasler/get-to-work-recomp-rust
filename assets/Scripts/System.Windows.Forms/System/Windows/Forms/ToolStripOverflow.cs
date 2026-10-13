using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms.Layout;

namespace System.Windows.Forms;

[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class ToolStripOverflow : ToolStripDropDown, IComponent, IDisposable, IArrangedContainer, IArrangedElement
{
	private class ToolStripOverflowAccessibleObject : AccessibleObject
	{
	}

	public override ToolStripItemCollection Items => base.Items;

	protected internal override ToolStripItemCollection DisplayedItems => base.DisplayedItems;

	internal ToolStrip ParentToolStrip => base.OwnerItem.Parent;

	ArrangedElementCollection IArrangedContainer.Controls => DisplayedItems;

	bool IArrangedElement.Visible => base.Visible;

	public ToolStripOverflow(ToolStripItem parentItem)
	{
		base.OwnerItem = parentItem;
	}

	public override Size GetPreferredSize(Size constrainingSize)
	{
		constrainingSize.Width = 200;
		return base.GetPreferredSize(constrainingSize);
	}

	protected override AccessibleObject CreateAccessibilityInstance()
	{
		return new ToolStripOverflowAccessibleObject();
	}

	protected override LayoutSettings CreateLayoutSettings(ToolStripLayoutStyle style)
	{
		LayoutSettings layoutSettings = base.CreateLayoutSettings(style);
		if (style == ToolStripLayoutStyle.Flow)
		{
			((FlowLayoutSettings)layoutSettings).FlowDirection = FlowDirection.LeftToRight;
			((FlowLayoutSettings)layoutSettings).WrapContents = true;
		}
		return layoutSettings;
	}

	protected override void SetDisplayedItems()
	{
		displayed_items.ClearInternal();
		if (base.OwnerItem != null && base.OwnerItem.Parent != null)
		{
			foreach (ToolStripItem item in base.OwnerItem.Parent.Items)
			{
				if (item.Placement == ToolStripItemPlacement.Overflow && item.Available && !(item is ToolStripSeparator))
				{
					displayed_items.AddNoOwnerOrLayout(item);
				}
			}
		}
		PerformLayout();
	}
}
