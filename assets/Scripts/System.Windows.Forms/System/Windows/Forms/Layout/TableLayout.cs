using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace System.Windows.Forms.Layout;

internal class TableLayout : LayoutEngine
{
	internal static readonly TableLayout Instance = new TableLayout();

	private static Control dummy_control = new Control("Dummy");

	private static ColumnStyle default_column_style = new ColumnStyle();

	private static RowStyle default_row_style = new RowStyle();

	private TableLayout()
	{
	}

	public override void InitLayout(object child, BoundsSpecified specified)
	{
		base.InitLayout(child, specified);
	}

	public override bool Layout(object container, LayoutEventArgs args)
	{
		IArrangedContainer arrangedContainer = (IArrangedContainer)container;
		TableLayoutSettings layoutSettings = GetLayoutSettings(arrangedContainer);
		IArrangedElement[,] actual_positions = CalculateControlPositions(arrangedContainer, Math.Max(layoutSettings.ColumnCount, 1), Math.Max(layoutSettings.RowCount, 1));
		CalculateColumnRowSizes(arrangedContainer, actual_positions, out var column_widths, out var row_heights, arrangedContainer.DisplayRectangle.Size, measureOnly: false);
		if (arrangedContainer is TableLayoutPanel tableLayoutPanel)
		{
			tableLayoutPanel.actual_positions = actual_positions;
			tableLayoutPanel.column_widths = column_widths;
			tableLayoutPanel.row_heights = row_heights;
		}
		LayoutControls(arrangedContainer, actual_positions, column_widths, row_heights);
		return arrangedContainer.AutoSize;
	}

	private static TableLayoutSettings GetLayoutSettings(IArrangedContainer container)
	{
		if (container is TableLayoutPanel tableLayoutPanel)
		{
			return tableLayoutPanel.LayoutSettings;
		}
		if (container is ToolStrip toolStrip)
		{
			return (TableLayoutSettings)toolStrip.LayoutSettings;
		}
		throw new NotSupportedException();
	}

	private IArrangedElement[,] CalculateControlPositions(IArrangedContainer container, int columns, int rows)
	{
		IArrangedElement[,] array = new IArrangedElement[columns, rows];
		TableLayoutSettings layoutSettings = GetLayoutSettings(container);
		foreach (IArrangedElement control in container.Controls)
		{
			int num = layoutSettings.GetColumn(control);
			int num2 = layoutSettings.GetRow(control);
			if (num < 0 || num2 < 0)
			{
				continue;
			}
			if (num >= columns)
			{
				return CalculateControlPositions(container, num + 1, rows);
			}
			if (num2 >= rows)
			{
				return CalculateControlPositions(container, columns, num2 + 1);
			}
			if (array[num, num2] != null)
			{
				continue;
			}
			int num3 = Math.Min(layoutSettings.GetColumnSpan(control), columns);
			int num4 = Math.Min(layoutSettings.GetRowSpan(control), rows);
			if (num + num3 > columns)
			{
				if (num2 + 1 >= rows)
				{
					if (layoutSettings.GrowStyle == TableLayoutPanelGrowStyle.AddColumns)
					{
						return CalculateControlPositions(container, columns + 1, rows);
					}
					throw new ArgumentException();
				}
				array[num, num2] = dummy_control;
				num2++;
				num = 0;
			}
			if (num2 + num4 > rows)
			{
				if (layoutSettings.GrowStyle == TableLayoutPanelGrowStyle.AddRows)
				{
					return CalculateControlPositions(container, columns, rows + 1);
				}
				throw new ArgumentException();
			}
			array[num, num2] = control;
			for (int i = 0; i < num3; i++)
			{
				for (int j = 0; j < num4; j++)
				{
					if (i != 0 || j != 0)
					{
						array[num + i, num2 + j] = dummy_control;
					}
				}
			}
		}
		int num5 = 0;
		foreach (IArrangedElement control2 in container.Controls)
		{
			int column = layoutSettings.GetColumn(control2);
			int row = layoutSettings.GetRow(control2);
			if (column >= 0 && column < columns && row >= 0 && row < rows && (array[column, row] == control2 || array[column, row] == dummy_control))
			{
				continue;
			}
			int num6 = num5;
			int num7;
			int num8;
			int num9;
			while (true)
			{
				if (num6 < rows)
				{
					num5 = num6;
					num7 = 0;
					while (num7 < columns)
					{
						if (array[num7, num6] != null)
						{
							if (layoutSettings.GrowStyle == TableLayoutPanelGrowStyle.AddColumns && layoutSettings.RowCount == 0)
							{
								break;
							}
							num7++;
							continue;
						}
						goto IL_021e;
					}
					goto IL_0313;
				}
				TableLayoutPanelGrowStyle tableLayoutPanelGrowStyle = layoutSettings.GrowStyle;
				if (layoutSettings.GrowStyle == TableLayoutPanelGrowStyle.AddColumns && layoutSettings.RowCount == 0)
				{
					tableLayoutPanelGrowStyle = TableLayoutPanelGrowStyle.AddRows;
				}
				return tableLayoutPanelGrowStyle switch
				{
					TableLayoutPanelGrowStyle.AddColumns => CalculateControlPositions(container, columns + 1, rows), 
					TableLayoutPanelGrowStyle.FixedSize => throw new ArgumentException(), 
					_ => CalculateControlPositions(container, columns, rows + 1), 
				};
				IL_021e:
				num8 = Math.Min(layoutSettings.GetColumnSpan(control2), columns);
				num9 = Math.Min(layoutSettings.GetRowSpan(control2), rows);
				if (num7 + num8 > columns)
				{
					if (num6 + 1 >= rows)
					{
						if (layoutSettings.GrowStyle == TableLayoutPanelGrowStyle.AddColumns)
						{
							return CalculateControlPositions(container, columns + 1, rows);
						}
						throw new ArgumentException();
					}
				}
				else
				{
					if (num6 + num9 <= rows)
					{
						break;
					}
					if (num7 + 1 >= columns)
					{
						if (layoutSettings.GrowStyle == TableLayoutPanelGrowStyle.AddRows)
						{
							return CalculateControlPositions(container, columns, rows + 1);
						}
						throw new ArgumentException();
					}
				}
				goto IL_0313;
				IL_0313:
				num6++;
			}
			array[num7, num6] = control2;
			for (int k = 0; k < num8; k++)
			{
				for (int l = 0; l < num9; l++)
				{
					if (k != 0 || l != 0)
					{
						array[num7 + k, num6 + l] = dummy_control;
					}
				}
			}
		}
		return array;
	}

	private static void CalculateColumnWidths(TableLayoutSettings settings, IArrangedElement[,] actual_positions, int max_colspan, TableLayoutColumnStyleCollection col_styles, bool auto_size, int[] column_widths, bool minimum_sizes)
	{
		Size proposedSize = (minimum_sizes ? new Size(1, 0) : Size.Empty);
		int length = actual_positions.GetLength(1);
		float num = 0f;
		int i = 0;
		foreach (ColumnStyle item in (IEnumerable)col_styles)
		{
			if (i >= column_widths.Length)
			{
				break;
			}
			if (item.SizeType == SizeType.Absolute)
			{
				column_widths[i] = (int)item.Width;
			}
			i++;
		}
		for (; i < column_widths.Length; i++)
		{
			column_widths[i] = 0;
		}
		for (int j = 0; j < max_colspan; j++)
		{
			for (i = j; i < column_widths.Length - j; i++)
			{
				ColumnStyle columnStyle2 = ((i < col_styles.Count) ? col_styles[i] : default_column_style);
				if (columnStyle2.SizeType != SizeType.AutoSize && (!auto_size || columnStyle2.SizeType != SizeType.Percent))
				{
					continue;
				}
				int num2 = column_widths[i];
				for (int k = 0; k < length; k++)
				{
					IArrangedElement arrangedElement = actual_positions[i - j, k];
					if (arrangedElement != null && arrangedElement != dummy_control && arrangedElement.Visible && settings.GetColumnSpan(arrangedElement) == j + 1)
					{
						num2 = Math.Max(num2, GetControlSize(arrangedElement, proposedSize).Width + arrangedElement.Margin.Horizontal);
					}
				}
				if (columnStyle2.SizeType == SizeType.Percent)
				{
					num = Math.Max(num, (float)num2 / columnStyle2.Width);
				}
				for (int l = Math.Max(i - j, 0); l < i; l++)
				{
					num2 -= column_widths[l];
				}
				if (num2 > column_widths[i])
				{
					column_widths[i] = num2;
				}
			}
		}
		for (i = 0; i < col_styles.Count && i < column_widths.Length; i++)
		{
			ColumnStyle columnStyle3 = col_styles[i];
			if (columnStyle3.SizeType == SizeType.Percent)
			{
				column_widths[i] = Math.Max(column_widths[i], (int)Math.Ceiling(num * columnStyle3.Width));
			}
		}
	}

	private static void CalculateRowHeights(TableLayoutSettings settings, IArrangedElement[,] actual_positions, int max_rowspan, TableLayoutRowStyleCollection row_styles, bool auto_size, int[] column_widths, int[] row_heights)
	{
		int length = actual_positions.GetLength(0);
		float num = 0f;
		int i = 0;
		foreach (RowStyle item in (IEnumerable)row_styles)
		{
			if (i >= row_heights.Length)
			{
				break;
			}
			if (item.SizeType == SizeType.Absolute)
			{
				row_heights[i] = (int)item.Height;
			}
			i++;
		}
		for (; i < row_heights.Length; i++)
		{
			row_heights[i] = 0;
		}
		for (int j = 0; j < max_rowspan; j++)
		{
			for (i = j; i < row_heights.Length - j; i++)
			{
				RowStyle rowStyle2 = ((i < row_styles.Count) ? row_styles[i] : default_row_style);
				if (rowStyle2.SizeType != SizeType.AutoSize && (!auto_size || rowStyle2.SizeType != SizeType.Percent))
				{
					continue;
				}
				int num2 = row_heights[i];
				for (int k = 0; k < length; k++)
				{
					IArrangedElement arrangedElement = actual_positions[k, i - j];
					if (arrangedElement != null && arrangedElement != dummy_control && arrangedElement.Visible && settings.GetRowSpan(arrangedElement) == j + 1)
					{
						int num3 = 0;
						int columnSpan = settings.GetColumnSpan(arrangedElement);
						for (int l = k; l < k + columnSpan && l < column_widths.Length; l++)
						{
							num3 += column_widths[l];
						}
						num2 = Math.Max(num2, GetControlSize(arrangedElement, new Size(num3 - arrangedElement.Margin.Horizontal, 0)).Height + arrangedElement.Margin.Vertical);
					}
				}
				if (rowStyle2.SizeType == SizeType.Percent)
				{
					num = Math.Max(num, (float)num2 / rowStyle2.Height);
				}
				for (int m = Math.Max(i - j, 0); m < i; m++)
				{
					num2 -= row_heights[m];
				}
				if (num2 > row_heights[i])
				{
					row_heights[i] = num2;
				}
			}
		}
		for (i = 0; i < row_styles.Count && i < row_heights.Length; i++)
		{
			RowStyle rowStyle3 = row_styles[i];
			if (rowStyle3.SizeType == SizeType.Percent)
			{
				row_heights[i] = Math.Max(row_heights[i], (int)Math.Ceiling(num * rowStyle3.Height));
			}
		}
	}

	private static int RedistributePercents(int overlap, TableLayoutColumnStyleCollection styles, int[] column_widths)
	{
		int num = 0;
		if (overlap > 0)
		{
			float num2 = 0f;
			int num3 = 0;
			foreach (ColumnStyle item in (IEnumerable)styles)
			{
				if (num3 >= column_widths.Length)
				{
					break;
				}
				if (item.SizeType == SizeType.Percent)
				{
					num2 += item.Width;
				}
			}
			num3 = 0;
			foreach (ColumnStyle item2 in (IEnumerable)styles)
			{
				if (num3 >= column_widths.Length)
				{
					break;
				}
				if (item2.SizeType == SizeType.Percent)
				{
					int num4 = (int)(item2.Width / num2 * (float)overlap);
					if (num4 > 0)
					{
						column_widths[num3] += num4;
						num += num4;
					}
				}
				num3++;
			}
		}
		return num;
	}

	private static int RedistributePercents(int overlap, TableLayoutRowStyleCollection styles, int[] row_heights)
	{
		int num = 0;
		if (overlap > 0)
		{
			float num2 = 0f;
			int num3 = 0;
			foreach (RowStyle item in (IEnumerable)styles)
			{
				if (num3 >= row_heights.Length)
				{
					break;
				}
				if (item.SizeType == SizeType.Percent)
				{
					num2 += item.Height;
				}
				num3++;
			}
			num3 = 0;
			foreach (RowStyle item2 in (IEnumerable)styles)
			{
				if (num3 >= row_heights.Length)
				{
					break;
				}
				if (item2.SizeType == SizeType.Percent)
				{
					int num4 = (int)(item2.Height / num2 * (float)overlap);
					if (num4 > 0)
					{
						row_heights[num3] += num4;
						num += num4;
					}
				}
				num3++;
			}
		}
		return num;
	}

	private void CalculateColumnRowSizes(IArrangedContainer panel, IArrangedElement[,] actual_positions, out int[] column_widths, out int[] row_heights, Size size, bool measureOnly)
	{
		TableLayoutPanel tableLayoutPanel = panel as TableLayoutPanel;
		TableLayoutSettings layoutSettings = GetLayoutSettings(panel);
		int length = actual_positions.GetLength(0);
		int length2 = actual_positions.GetLength(1);
		bool auto_size = panel.AutoSize & measureOnly;
		bool flag = !measureOnly;
		column_widths = new int[actual_positions.GetLength(0)];
		row_heights = new int[actual_positions.GetLength(1)];
		if (measureOnly && size.Width > 0 && tableLayoutPanel != null && tableLayoutPanel.Parent != null && tableLayoutPanel.Parent.LayoutEngine is DefaultLayout)
		{
			flag |= panel.Dock == DockStyle.Top || panel.Dock == DockStyle.Bottom || panel.Dock == DockStyle.Fill;
			flag |= (panel.Anchor & (AnchorStyles.Left | AnchorStyles.Right)) == (AnchorStyles.Left | AnchorStyles.Right);
		}
		int num = 0;
		if (tableLayoutPanel != null)
		{
			num = TableLayoutPanel.GetCellBorderWidth(tableLayoutPanel.CellBorderStyle);
		}
		int num2 = 0;
		int num3 = 0;
		foreach (IArrangedElement control in panel.Controls)
		{
			if (control.Visible && control != dummy_control)
			{
				num2 = Math.Max(num2, layoutSettings.GetColumnSpan(control));
				num3 = Math.Max(num3, layoutSettings.GetRowSpan(control));
			}
		}
		CalculateColumnWidths(layoutSettings, actual_positions, num2, layoutSettings.ColumnStyles, auto_size, column_widths, minimum_sizes: false);
		int num4 = ((size.Width < 32767) ? (size.Width - num * (length + 1)) : 0);
		int[] array = column_widths;
		foreach (int num5 in array)
		{
			num4 -= num5;
		}
		if (flag && size.Width > 0 && num4 < 0)
		{
			int[] array2 = new int[column_widths.Length];
			CalculateColumnWidths(layoutSettings, actual_positions, num2, layoutSettings.ColumnStyles, auto_size, array2, minimum_sizes: true);
			num4 += Shrink(column_widths, array2, -num4, num2);
		}
		if (num4 > 0)
		{
			num4 -= RedistributePercents(num4, layoutSettings.ColumnStyles, column_widths);
		}
		if (num4 > 0 && column_widths.Length != 0)
		{
			int num6 = Math.Min(layoutSettings.ColumnStyles.Count, column_widths.Length) - 1;
			while (num6 >= 0 && layoutSettings.ColumnStyles[num6].SizeType == SizeType.Absolute)
			{
				num6--;
			}
			if (num6 < 0)
			{
				num6 = column_widths.Length - 1;
			}
			column_widths[num6] += num4;
		}
		CalculateRowHeights(layoutSettings, actual_positions, num3, layoutSettings.RowStyles, auto_size, column_widths, row_heights);
		int num7 = ((size.Height < 32767) ? (size.Height - num * (length2 + 1)) : 0);
		array = row_heights;
		foreach (int num8 in array)
		{
			num7 -= num8;
		}
		if (num7 > 0)
		{
			num7 -= RedistributePercents(num7, layoutSettings.RowStyles, row_heights);
		}
		if (num7 > 0 && row_heights.Length != 0 && !measureOnly)
		{
			int num9 = Math.Min(layoutSettings.RowStyles.Count, row_heights.Length) - 1;
			while (num9 >= 0 && layoutSettings.RowStyles[num9].SizeType == SizeType.Absolute)
			{
				num9--;
			}
			if (num9 < 0)
			{
				num9 = row_heights.Length - 1;
			}
			row_heights[num9] += num7;
		}
	}

	private static int Shrink(int[] sizes, int[] min_sizes, int overlap, int max_span)
	{
		int num = 0;
		for (int i = 0; i < sizes.Length; i++)
		{
			if (sizes[i] > min_sizes[i])
			{
				num++;
			}
		}
		int num2 = 0;
		if (num != 0)
		{
			int num3 = ((overlap < num) ? 1 : (overlap / num));
			for (int j = 0; j < max_span; j++)
			{
				if (overlap <= 0)
				{
					break;
				}
				for (int k = j; k < sizes.Length - j; k++)
				{
					if (overlap <= 0)
					{
						break;
					}
					int num4 = sizes[k] - min_sizes[k];
					if (num4 > 0 && num4 != int.MaxValue)
					{
						int num5 = ((num3 > num4) ? num4 : num3);
						sizes[k] -= num5;
						overlap -= num5;
						num2 += num5;
					}
				}
			}
		}
		return num2;
	}

	private static Size GetControlSize(IArrangedElement c, Size proposedSize)
	{
		if (c.AutoSize)
		{
			return c.GetPreferredSize(proposedSize);
		}
		return c.ExplicitBounds.Size;
	}

	private void LayoutControls(IArrangedContainer panel, IArrangedElement[,] actual_positions, int[] column_widths, int[] row_heights)
	{
		TableLayoutSettings layoutSettings = GetLayoutSettings(panel);
		int num = 0;
		if (panel is TableLayoutPanel tableLayoutPanel)
		{
			num = TableLayoutPanel.GetCellBorderWidth(tableLayoutPanel.CellBorderStyle);
		}
		int length = actual_positions.GetLength(0);
		int length2 = actual_positions.GetLength(1);
		Point point = new Point(panel.DisplayRectangle.Left + num, panel.DisplayRectangle.Top + num);
		for (int i = 0; i < length2; i++)
		{
			for (int j = 0; j < length; j++)
			{
				IArrangedElement arrangedElement = actual_positions[j, i];
				if (arrangedElement != null && arrangedElement != dummy_control && arrangedElement.Visible)
				{
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					int num6 = column_widths[j];
					for (int k = 1; k < Math.Min(layoutSettings.GetColumnSpan(arrangedElement), column_widths.Length - j); k++)
					{
						num6 += column_widths[j + k];
					}
					int num7 = row_heights[i];
					for (int l = 1; l < Math.Min(layoutSettings.GetRowSpan(arrangedElement), row_heights.Length - i); l++)
					{
						num7 += row_heights[i + l];
					}
					Size controlSize = GetControlSize(arrangedElement, new Size(num6 - arrangedElement.Margin.Horizontal, num7 - arrangedElement.Margin.Vertical));
					num4 = ((arrangedElement.Dock != DockStyle.Fill && arrangedElement.Dock != DockStyle.Top && arrangedElement.Dock != DockStyle.Bottom && ((arrangedElement.Anchor & AnchorStyles.Left) != AnchorStyles.Left || (arrangedElement.Anchor & AnchorStyles.Right) != AnchorStyles.Right)) ? Math.Min(controlSize.Width, num6 - arrangedElement.Margin.Left - arrangedElement.Margin.Right) : (num6 - arrangedElement.Margin.Left - arrangedElement.Margin.Right));
					num5 = ((arrangedElement.Dock != DockStyle.Fill && arrangedElement.Dock != DockStyle.Left && arrangedElement.Dock != DockStyle.Right && ((arrangedElement.Anchor & AnchorStyles.Top) != AnchorStyles.Top || (arrangedElement.Anchor & AnchorStyles.Bottom) != AnchorStyles.Bottom)) ? Math.Min(controlSize.Height, num7 - arrangedElement.Margin.Top - arrangedElement.Margin.Bottom) : (num7 - arrangedElement.Margin.Top - arrangedElement.Margin.Bottom));
					num2 = ((arrangedElement.Dock != DockStyle.Left && arrangedElement.Dock != DockStyle.Fill && (arrangedElement.Anchor & AnchorStyles.Left) != AnchorStyles.Left) ? ((arrangedElement.Dock != DockStyle.Right && (arrangedElement.Anchor & AnchorStyles.Right) != AnchorStyles.Right) ? (point.X + (num6 - arrangedElement.Margin.Left - arrangedElement.Margin.Right) / 2 + arrangedElement.Margin.Left - num4 / 2) : (point.X + num6 - num4 - arrangedElement.Margin.Right)) : (point.X + arrangedElement.Margin.Left));
					num3 = ((arrangedElement.Dock != DockStyle.Top && arrangedElement.Dock != DockStyle.Fill && (arrangedElement.Anchor & AnchorStyles.Top) != AnchorStyles.Top) ? ((arrangedElement.Dock != DockStyle.Bottom && (arrangedElement.Anchor & AnchorStyles.Bottom) != AnchorStyles.Bottom) ? (point.Y + (num7 - arrangedElement.Margin.Top - arrangedElement.Margin.Bottom) / 2 + arrangedElement.Margin.Top - num5 / 2) : (point.Y + num7 - num5 - arrangedElement.Margin.Bottom)) : (point.Y + arrangedElement.Margin.Top));
					arrangedElement.SetBounds(num2, num3, num4, num5, BoundsSpecified.None);
				}
				point.Offset(column_widths[j] + num, 0);
			}
			point.Offset(-1 * point.X + num + panel.DisplayRectangle.Left, row_heights[i] + num);
		}
	}

	internal override Size GetPreferredSize(object container, Size proposedSize)
	{
		IArrangedContainer arrangedContainer = (IArrangedContainer)container;
		TableLayoutSettings layoutSettings = GetLayoutSettings(arrangedContainer);
		IArrangedElement[,] actual_positions = CalculateControlPositions(arrangedContainer, Math.Max(layoutSettings.ColumnCount, 1), Math.Max(layoutSettings.RowCount, 1));
		int num = 0;
		if (arrangedContainer is TableLayoutPanel tableLayoutPanel)
		{
			num = TableLayoutPanel.GetCellBorderWidth(tableLayoutPanel.CellBorderStyle);
		}
		CalculateColumnRowSizes(arrangedContainer, actual_positions, out var column_widths, out var row_heights, proposedSize, measureOnly: true);
		int num2 = (column_widths.Length + 1) * num;
		for (int i = 0; i < column_widths.Length; i++)
		{
			num2 += column_widths[i];
		}
		int num3 = (row_heights.Length + 1) * num;
		for (int j = 0; j < row_heights.Length; j++)
		{
			num3 += row_heights[j];
		}
		return new Size(num2, num3);
	}

	[Conditional("TABLE_DEBUG")]
	private void OutputControlGrid(IArrangedElement[,] grid, int[] column_widths, int[] row_heights)
	{
		Console.WriteLine("     Size: {0}x{1}", grid.GetLength(0), grid.GetLength(1));
		Console.Write("        ");
		foreach (int num in column_widths)
		{
			Console.Write(" {0}px  ", num.ToString().PadLeft(3));
		}
		Console.WriteLine();
		for (int j = 0; j < grid.GetLength(1); j++)
		{
			Console.Write(" {0}px |", row_heights[j].ToString().PadLeft(3));
			for (int k = 0; k < grid.GetLength(0); k++)
			{
				if (grid[k, j] == null)
				{
					Console.Write("  ---  |");
				}
				else if (string.IsNullOrEmpty(grid[k, j].Name))
				{
					Console.Write("  ???  |");
				}
				else
				{
					Console.Write(" {0} |", grid[k, j].Name.PadRight(5).Substring(0, 5));
				}
			}
			Console.WriteLine();
		}
	}
}
