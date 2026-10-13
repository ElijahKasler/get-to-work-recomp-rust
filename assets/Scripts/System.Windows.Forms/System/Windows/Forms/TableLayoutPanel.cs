using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms.Layout;

namespace System.Windows.Forms;

[DefaultProperty("ColumnCount")]
[Docking(DockingBehavior.Never)]
[ProvideProperty("RowSpan", typeof(Control))]
[ProvideProperty("Row", typeof(Control))]
[ProvideProperty("ColumnSpan", typeof(Control))]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ProvideProperty("Column", typeof(Control))]
[Designer("System.Windows.Forms.Design.TableLayoutPanelDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.IDesigner")]
[DesignerSerializer("System.Windows.Forms.Design.TableLayoutPanelCodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[ProvideProperty("CellPosition", typeof(Control))]
[ComVisible(true)]
public class TableLayoutPanel : Panel, IExtenderProvider
{
	private TableLayoutSettings settings;

	private TableLayoutPanelCellBorderStyle cell_border_style;

	internal IArrangedElement[,] actual_positions;

	internal int[] column_widths;

	internal int[] row_heights;

	private static object CellPaintEvent = new object();

	[Localizable(true)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new BorderStyle BorderStyle
	{
		get
		{
			return base.BorderStyle;
		}
		set
		{
			base.BorderStyle = value;
		}
	}

	[Localizable(true)]
	[DefaultValue(TableLayoutPanelCellBorderStyle.None)]
	public TableLayoutPanelCellBorderStyle CellBorderStyle
	{
		get
		{
			return cell_border_style;
		}
		set
		{
			if (cell_border_style != value)
			{
				cell_border_style = value;
				PerformLayout(this, "CellBorderStyle");
				Invalidate();
			}
		}
	}

	[DefaultValue(0)]
	[Localizable(true)]
	public int ColumnCount
	{
		get
		{
			return settings.ColumnCount;
		}
		set
		{
			settings.ColumnCount = value;
		}
	}

	[DisplayName("Columns")]
	[MergableProperty(false)]
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public TableLayoutColumnStyleCollection ColumnStyles => settings.ColumnStyles;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public new TableLayoutControlCollection Controls => (TableLayoutControlCollection)base.Controls;

	[DefaultValue(TableLayoutPanelGrowStyle.AddRows)]
	public TableLayoutPanelGrowStyle GrowStyle
	{
		get
		{
			return settings.GrowStyle;
		}
		set
		{
			settings.GrowStyle = value;
		}
	}

	public override LayoutEngine LayoutEngine => TableLayout.Instance;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public TableLayoutSettings LayoutSettings
	{
		get
		{
			return settings;
		}
		set
		{
			if (value.isSerialized)
			{
				settings = new TableLayoutSettings(this, value);
				settings.ColumnCount = value.ColumnStyles.Count;
				settings.RowCount = value.RowStyles.Count;
				PerformLayout();
				return;
			}
			throw new NotSupportedException("LayoutSettings value cannot be set directly.");
		}
	}

	[Localizable(true)]
	[DefaultValue(0)]
	public int RowCount
	{
		get
		{
			return settings.RowCount;
		}
		set
		{
			settings.RowCount = value;
		}
	}

	[Browsable(false)]
	[DisplayName("Rows")]
	[MergableProperty(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public TableLayoutRowStyleCollection RowStyles => settings.RowStyles;

	public event TableLayoutCellPaintEventHandler CellPaint
	{
		add
		{
			base.Events.AddHandler(CellPaintEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CellPaintEvent, value);
		}
	}

	public TableLayoutPanel()
	{
		settings = new TableLayoutSettings(this);
		cell_border_style = TableLayoutPanelCellBorderStyle.None;
		column_widths = new int[0];
		row_heights = new int[0];
		CreateDockPadding();
	}

	[DefaultValue(-1)]
	[DisplayName("Cell")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public TableLayoutPanelCellPosition GetCellPosition(Control control)
	{
		return settings.GetCellPosition(control);
	}

	[DisplayName("Column")]
	[DefaultValue(-1)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int GetColumn(Control control)
	{
		return settings.GetColumn(control);
	}

	[DisplayName("ColumnSpan")]
	[DefaultValue(1)]
	public int GetColumnSpan(Control control)
	{
		return settings.GetColumnSpan(control);
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int[] GetColumnWidths()
	{
		return column_widths;
	}

	public Control GetControlFromPosition(int column, int row)
	{
		if (column < 0 || row < 0)
		{
			throw new ArgumentException();
		}
		TableLayoutPanelCellPosition tableLayoutPanelCellPosition = new TableLayoutPanelCellPosition(column, row);
		foreach (Control control in Controls)
		{
			if (settings.GetCellPosition(control) == tableLayoutPanelCellPosition)
			{
				return control;
			}
		}
		return null;
	}

	public TableLayoutPanelCellPosition GetPositionFromControl(Control control)
	{
		for (int i = 0; i < actual_positions.GetLength(0); i++)
		{
			for (int j = 0; j < actual_positions.GetLength(1); j++)
			{
				if (actual_positions[i, j] == control)
				{
					return new TableLayoutPanelCellPosition(i, j);
				}
			}
		}
		return new TableLayoutPanelCellPosition(-1, -1);
	}

	[DisplayName("Row")]
	[DefaultValue("-1")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public int GetRow(Control control)
	{
		return settings.GetRow(control);
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public int[] GetRowHeights()
	{
		return row_heights;
	}

	[DefaultValue(1)]
	[DisplayName("RowSpan")]
	public int GetRowSpan(Control control)
	{
		return settings.GetRowSpan(control);
	}

	public void SetCellPosition(Control control, TableLayoutPanelCellPosition position)
	{
		settings.SetCellPosition(control, position);
	}

	public void SetColumn(Control control, int column)
	{
		settings.SetColumn(control, column);
	}

	public void SetColumnSpan(Control control, int value)
	{
		settings.SetColumnSpan(control, value);
	}

	public void SetRow(Control control, int row)
	{
		settings.SetRow(control, row);
	}

	public void SetRowSpan(Control control, int value)
	{
		settings.SetRowSpan(control, value);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override ControlCollection CreateControlsInstance()
	{
		return new TableLayoutControlCollection(this);
	}

	protected virtual void OnCellPaint(TableLayoutCellPaintEventArgs e)
	{
		((TableLayoutCellPaintEventHandler)base.Events[CellPaintEvent])?.Invoke(this, e);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	protected override void OnLayout(LayoutEventArgs levent)
	{
		base.OnLayout(levent);
		Invalidate();
	}

	protected override void OnPaintBackground(PaintEventArgs e)
	{
		base.OnPaintBackground(e);
		DrawCellBorders(e);
		int cellBorderWidth = GetCellBorderWidth(CellBorderStyle);
		int num = cellBorderWidth;
		int num2 = cellBorderWidth;
		for (int i = 0; i < column_widths.Length; i++)
		{
			for (int j = 0; j < row_heights.Length; j++)
			{
				OnCellPaint(new TableLayoutCellPaintEventArgs(e.Graphics, e.ClipRectangle, new Rectangle(num, num2, column_widths[i] + cellBorderWidth, row_heights[j] + cellBorderWidth), i, j));
				num2 += row_heights[j] + cellBorderWidth;
			}
			num += column_widths[i] + cellBorderWidth;
			num2 = cellBorderWidth;
		}
	}

	protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
	{
		base.ScaleControl(factor, specified);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override void ScaleCore(float dx, float dy)
	{
		base.ScaleCore(dx, dy);
	}

	internal static int GetCellBorderWidth(TableLayoutPanelCellBorderStyle style)
	{
		switch (style)
		{
		case TableLayoutPanelCellBorderStyle.Single:
			return 1;
		case TableLayoutPanelCellBorderStyle.Inset:
		case TableLayoutPanelCellBorderStyle.Outset:
			return 2;
		case TableLayoutPanelCellBorderStyle.InsetDouble:
		case TableLayoutPanelCellBorderStyle.OutsetDouble:
		case TableLayoutPanelCellBorderStyle.OutsetPartial:
			return 3;
		default:
			return 0;
		}
	}

	private void DrawCellBorders(PaintEventArgs e)
	{
		Rectangle rect = new Rectangle(Point.Empty, base.Size);
		switch (CellBorderStyle)
		{
		case TableLayoutPanelCellBorderStyle.Single:
			DrawSingleBorder(e.Graphics, rect);
			break;
		case TableLayoutPanelCellBorderStyle.Inset:
			DrawInsetBorder(e.Graphics, rect);
			break;
		case TableLayoutPanelCellBorderStyle.InsetDouble:
			DrawInsetDoubleBorder(e.Graphics, rect);
			break;
		case TableLayoutPanelCellBorderStyle.Outset:
			DrawOutsetBorder(e.Graphics, rect);
			break;
		case TableLayoutPanelCellBorderStyle.OutsetDouble:
		case TableLayoutPanelCellBorderStyle.OutsetPartial:
			DrawOutsetDoubleBorder(e.Graphics, rect);
			break;
		}
	}

	private void DrawSingleBorder(Graphics g, Rectangle rect)
	{
		ControlPaint.DrawBorder(g, rect, SystemColors.ControlDark, ButtonBorderStyle.Solid);
		int num = DisplayRectangle.X;
		int num2 = DisplayRectangle.Y;
		for (int i = 0; i < column_widths.Length - 1; i++)
		{
			num += column_widths[i] + 1;
			g.DrawLine(SystemPens.ControlDark, new Point(num, 1), new Point(num, base.Bottom - 2));
		}
		for (int j = 0; j < row_heights.Length - 1; j++)
		{
			num2 += row_heights[j] + 1;
			g.DrawLine(SystemPens.ControlDark, new Point(1, num2), new Point(base.Right - 2, num2));
		}
	}

	private void DrawInsetBorder(Graphics g, Rectangle rect)
	{
		ControlPaint.DrawBorder3D(g, rect, Border3DStyle.Etched);
		int num = DisplayRectangle.X;
		int num2 = DisplayRectangle.Y;
		for (int i = 0; i < column_widths.Length - 1; i++)
		{
			num += column_widths[i] + 2;
			g.DrawLine(SystemPens.ControlDark, new Point(num, 1), new Point(num, base.Bottom - 3));
			g.DrawLine(Pens.White, new Point(num + 1, 1), new Point(num + 1, base.Bottom - 3));
		}
		for (int j = 0; j < row_heights.Length - 1; j++)
		{
			num2 += row_heights[j] + 2;
			g.DrawLine(SystemPens.ControlDark, new Point(1, num2), new Point(base.Right - 3, num2));
			g.DrawLine(Pens.White, new Point(1, num2 + 1), new Point(base.Right - 3, num2 + 1));
		}
	}

	private void DrawOutsetBorder(Graphics g, Rectangle rect)
	{
		g.DrawRectangle(SystemPens.ControlDark, new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2));
		g.DrawRectangle(Pens.White, new Rectangle(rect.Left, rect.Top, rect.Width - 2, rect.Height - 2));
		int num = DisplayRectangle.X;
		int num2 = DisplayRectangle.Y;
		for (int i = 0; i < column_widths.Length - 1; i++)
		{
			num += column_widths[i] + 2;
			g.DrawLine(Pens.White, new Point(num, 1), new Point(num, base.Bottom - 3));
			g.DrawLine(SystemPens.ControlDark, new Point(num + 1, 1), new Point(num + 1, base.Bottom - 3));
		}
		for (int j = 0; j < row_heights.Length - 1; j++)
		{
			num2 += row_heights[j] + 2;
			g.DrawLine(Pens.White, new Point(1, num2), new Point(base.Right - 3, num2));
			g.DrawLine(SystemPens.ControlDark, new Point(1, num2 + 1), new Point(base.Right - 3, num2 + 1));
		}
	}

	private void DrawOutsetDoubleBorder(Graphics g, Rectangle rect)
	{
		rect.Width--;
		rect.Height--;
		g.DrawRectangle(SystemPens.ControlDark, new Rectangle(rect.Left + 2, rect.Top + 2, rect.Width - 2, rect.Height - 2));
		g.DrawRectangle(Pens.White, new Rectangle(rect.Left, rect.Top, rect.Width - 2, rect.Height - 2));
		int num = DisplayRectangle.X;
		int num2 = DisplayRectangle.Y;
		for (int i = 0; i < column_widths.Length - 1; i++)
		{
			num += column_widths[i] + 3;
			g.DrawLine(Pens.White, new Point(num, 3), new Point(num, base.Bottom - 5));
			g.DrawLine(SystemPens.ControlDark, new Point(num + 2, 3), new Point(num + 2, base.Bottom - 5));
		}
		for (int j = 0; j < row_heights.Length - 1; j++)
		{
			num2 += row_heights[j] + 3;
			g.DrawLine(Pens.White, new Point(3, num2), new Point(base.Right - 4, num2));
			g.DrawLine(SystemPens.ControlDark, new Point(3, num2 + 2), new Point(base.Right - 4, num2 + 2));
		}
		num = DisplayRectangle.X;
		num2 = DisplayRectangle.Y;
		for (int k = 0; k < column_widths.Length - 1; k++)
		{
			num += column_widths[k] + 3;
			g.DrawLine(ThemeEngine.Current.ResPool.GetPen(BackColor), new Point(num + 1, 3), new Point(num + 1, base.Bottom - 5));
		}
		for (int l = 0; l < row_heights.Length - 1; l++)
		{
			num2 += row_heights[l] + 3;
			g.DrawLine(ThemeEngine.Current.ResPool.GetPen(BackColor), new Point(3, num2 + 1), new Point(base.Right - 4, num2 + 1));
		}
	}

	private void DrawInsetDoubleBorder(Graphics g, Rectangle rect)
	{
		rect.Width--;
		rect.Height--;
		g.DrawRectangle(Pens.White, new Rectangle(rect.Left + 2, rect.Top + 2, rect.Width - 2, rect.Height - 2));
		g.DrawRectangle(SystemPens.ControlDark, new Rectangle(rect.Left, rect.Top, rect.Width - 2, rect.Height - 2));
		int num = DisplayRectangle.X;
		int num2 = DisplayRectangle.Y;
		for (int i = 0; i < column_widths.Length - 1; i++)
		{
			num += column_widths[i] + 3;
			g.DrawLine(SystemPens.ControlDark, new Point(num, 3), new Point(num, base.Bottom - 5));
			g.DrawLine(Pens.White, new Point(num + 2, 3), new Point(num + 2, base.Bottom - 5));
		}
		for (int j = 0; j < row_heights.Length - 1; j++)
		{
			num2 += row_heights[j] + 3;
			g.DrawLine(SystemPens.ControlDark, new Point(3, num2), new Point(base.Right - 4, num2));
			g.DrawLine(Pens.White, new Point(3, num2 + 2), new Point(base.Right - 4, num2 + 2));
		}
		num = DisplayRectangle.X;
		num2 = DisplayRectangle.Y;
		for (int k = 0; k < column_widths.Length - 1; k++)
		{
			num += column_widths[k] + 3;
			g.DrawLine(ThemeEngine.Current.ResPool.GetPen(BackColor), new Point(num + 1, 3), new Point(num + 1, base.Bottom - 5));
		}
		for (int l = 0; l < row_heights.Length - 1; l++)
		{
			num2 += row_heights[l] + 3;
			g.DrawLine(ThemeEngine.Current.ResPool.GetPen(BackColor), new Point(3, num2 + 1), new Point(base.Right - 4, num2 + 1));
		}
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
