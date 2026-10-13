namespace System.Windows.Forms;

public struct DataGridCell(int r, int c)
{
	private int row = r;

	private int column = c;

	public int ColumnNumber
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

	public int RowNumber
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

	public override bool Equals(object o)
	{
		if (!(o is DataGridCell dataGridCell))
		{
			return false;
		}
		if (dataGridCell.ColumnNumber == column)
		{
			return dataGridCell.RowNumber == row;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return row ^ column;
	}

	public override string ToString()
	{
		return "DataGridCell {RowNumber = " + row + ", ColumnNumber = " + column + "}";
	}
}
