using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace System.Windows.Forms;

[DesignerSerializer("System.Windows.Forms.Design.TableLayoutControlCollectionCodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[ListBindable(false)]
public class TableLayoutControlCollection : Control.ControlCollection
{
	private TableLayoutPanel panel;

	public TableLayoutPanel Container => panel;

	public TableLayoutControlCollection(TableLayoutPanel container)
		: base(container)
	{
		panel = container;
	}

	public virtual void Add(Control control, int column, int row)
	{
		if (column < -1)
		{
			throw new ArgumentException("column");
		}
		if (row < -1)
		{
			throw new ArgumentException("row");
		}
		base.Add(control);
		panel.SetCellPosition(control, new TableLayoutPanelCellPosition(column, row));
	}
}
