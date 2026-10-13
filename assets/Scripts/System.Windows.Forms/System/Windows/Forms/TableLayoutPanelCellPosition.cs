using System.ComponentModel;

namespace System.Windows.Forms;

[TypeConverter(typeof(TableLayoutPanelCellPositionTypeConverter))]
public struct TableLayoutPanelCellPosition(int column, int row)
{
	private int column = column;

	private int row = row;

	public int Column
	{
		get
		{
			return column;
		}
		set
		{
			column = value;
		}
	}

	public int Row
	{
		get
		{
			return row;
		}
		set
		{
			row = value;
		}
	}

	public override string ToString()
	{
		return column + "," + row;
	}

	public override int GetHashCode()
	{
		return column.GetHashCode() ^ row.GetHashCode();
	}

	public static bool operator ==(TableLayoutPanelCellPosition p1, TableLayoutPanelCellPosition p2)
	{
		if (p1.column == p2.column)
		{
			return p1.row == p2.row;
		}
		return false;
	}

	public static bool operator !=(TableLayoutPanelCellPosition p1, TableLayoutPanelCellPosition p2)
	{
		if (p1.column == p2.column)
		{
			return p1.row != p2.row;
		}
		return true;
	}

	public override bool Equals(object other)
	{
		if (other == null)
		{
			return false;
		}
		if (!(other is TableLayoutPanelCellPosition tableLayoutPanelCellPosition))
		{
			return false;
		}
		if (tableLayoutPanelCellPosition.column == column)
		{
			return tableLayoutPanelCellPosition.row == row;
		}
		return false;
	}
}
