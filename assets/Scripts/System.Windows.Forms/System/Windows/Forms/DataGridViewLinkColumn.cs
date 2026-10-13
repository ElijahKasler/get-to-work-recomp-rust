using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

[ToolboxBitmap("")]
public class DataGridViewLinkColumn : DataGridViewColumn
{
	private string text = string.Empty;

	public Color ActiveLinkColor
	{
		get
		{
			return ((CellTemplate as DataGridViewLinkCell) ?? throw new InvalidOperationException("CellTemplate is null when getting this property.")).ActiveLinkColor;
		}
		set
		{
			if (ActiveLinkColor == value)
			{
				return;
			}
			((CellTemplate as DataGridViewLinkCell) ?? throw new InvalidOperationException("CellTemplate is null when getting this property.")).ActiveLinkColor = value;
			if (base.DataGridView == null)
			{
				return;
			}
			foreach (DataGridViewRow item in (IEnumerable)base.DataGridView.Rows)
			{
				if (item.Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
				{
					dataGridViewLinkCell.ActiveLinkColor = value;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override DataGridViewCell CellTemplate
	{
		get
		{
			return base.CellTemplate;
		}
		set
		{
			base.CellTemplate = value as DataGridViewLinkCell;
		}
	}

	[DefaultValue(LinkBehavior.SystemDefault)]
	public LinkBehavior LinkBehavior
	{
		get
		{
			return ((CellTemplate as DataGridViewLinkCell) ?? throw new InvalidOperationException("CellTemplate is null when getting this property.")).LinkBehavior;
		}
		set
		{
			if (LinkBehavior == value)
			{
				return;
			}
			((CellTemplate as DataGridViewLinkCell) ?? throw new InvalidOperationException("CellTemplate is null when getting this property.")).LinkBehavior = value;
			if (base.DataGridView == null)
			{
				return;
			}
			foreach (DataGridViewRow item in (IEnumerable)base.DataGridView.Rows)
			{
				if (item.Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
				{
					dataGridViewLinkCell.LinkBehavior = value;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	public Color LinkColor
	{
		get
		{
			return ((CellTemplate as DataGridViewLinkCell) ?? throw new InvalidOperationException("CellTemplate is null when getting this property.")).LinkColor;
		}
		set
		{
			if (LinkColor == value)
			{
				return;
			}
			((CellTemplate as DataGridViewLinkCell) ?? throw new InvalidOperationException("CellTemplate is null when getting this property.")).LinkColor = value;
			if (base.DataGridView == null)
			{
				return;
			}
			foreach (DataGridViewRow item in (IEnumerable)base.DataGridView.Rows)
			{
				if (item.Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
				{
					dataGridViewLinkCell.LinkColor = value;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[System.MonoInternalNote("")]
	[DefaultValue(null)]
	public string Text
	{
		get
		{
			return text;
		}
		set
		{
			if (Text == value)
			{
				return;
			}
			text = value;
			if (base.DataGridView == null)
			{
				return;
			}
			foreach (DataGridViewRow item in (IEnumerable)base.DataGridView.Rows)
			{
				if (item.Cells[base.Index] is DataGridViewLinkCell { UseColumnTextForLinkValue: not false } dataGridViewLinkCell)
				{
					dataGridViewLinkCell.Value = value;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[DefaultValue(true)]
	public bool TrackVisitedState
	{
		get
		{
			return ((CellTemplate as DataGridViewLinkCell) ?? throw new InvalidOperationException("CellTemplate is null when getting this property.")).TrackVisitedState;
		}
		set
		{
			if (TrackVisitedState == value)
			{
				return;
			}
			((CellTemplate as DataGridViewLinkCell) ?? throw new InvalidOperationException("CellTemplate is null when getting this property.")).TrackVisitedState = value;
			if (base.DataGridView == null)
			{
				return;
			}
			foreach (DataGridViewRow item in (IEnumerable)base.DataGridView.Rows)
			{
				if (item.Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
				{
					dataGridViewLinkCell.TrackVisitedState = value;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	[DefaultValue(false)]
	public bool UseColumnTextForLinkValue
	{
		get
		{
			return ((CellTemplate as DataGridViewLinkCell) ?? throw new InvalidOperationException("CellTemplate is null when getting this property.")).UseColumnTextForLinkValue;
		}
		set
		{
			if (UseColumnTextForLinkValue == value)
			{
				return;
			}
			((CellTemplate as DataGridViewLinkCell) ?? throw new InvalidOperationException("CellTemplate is null when getting this property.")).UseColumnTextForLinkValue = value;
			if (base.DataGridView == null)
			{
				return;
			}
			foreach (DataGridViewRow item in (IEnumerable)base.DataGridView.Rows)
			{
				if (item.Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
				{
					dataGridViewLinkCell.UseColumnTextForLinkValue = value;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	public Color VisitedLinkColor
	{
		get
		{
			return ((CellTemplate as DataGridViewLinkCell) ?? throw new InvalidOperationException("CellTemplate is null when getting this property.")).VisitedLinkColor;
		}
		set
		{
			if (VisitedLinkColor == value)
			{
				return;
			}
			((CellTemplate as DataGridViewLinkCell) ?? throw new InvalidOperationException("CellTemplate is null when getting this property.")).VisitedLinkColor = value;
			if (base.DataGridView == null)
			{
				return;
			}
			foreach (DataGridViewRow item in (IEnumerable)base.DataGridView.Rows)
			{
				if (item.Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
				{
					dataGridViewLinkCell.VisitedLinkColor = value;
				}
			}
			base.DataGridView.InvalidateColumn(base.Index);
		}
	}

	public DataGridViewLinkColumn()
	{
		base.CellTemplate = new DataGridViewLinkCell();
	}

	public override object Clone()
	{
		DataGridViewLinkColumn obj = (DataGridViewLinkColumn)base.Clone();
		obj.CellTemplate = (DataGridViewCell)CellTemplate.Clone();
		return obj;
	}

	public override string ToString()
	{
		return base.ToString();
	}
}
