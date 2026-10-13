using System.ComponentModel;

namespace System.Windows.Forms;

public sealed class DataGridViewAdvancedBorderStyle : ICloneable
{
	private DataGridViewAdvancedCellBorderStyle bottom;

	private DataGridViewAdvancedCellBorderStyle left;

	private DataGridViewAdvancedCellBorderStyle right;

	private DataGridViewAdvancedCellBorderStyle top;

	public DataGridViewAdvancedCellBorderStyle All
	{
		get
		{
			if (bottom == left && left == right && right == top)
			{
				return bottom;
			}
			return DataGridViewAdvancedCellBorderStyle.NotSet;
		}
		set
		{
			if (!Enum.IsDefined(typeof(DataGridViewAdvancedCellBorderStyle), value))
			{
				throw new InvalidEnumArgumentException("Value is not valid DataGridViewAdvancedCellBorderStyle.");
			}
			bottom = (left = (right = (top = value)));
		}
	}

	public DataGridViewAdvancedCellBorderStyle Bottom
	{
		get
		{
			return bottom;
		}
		set
		{
			if (!Enum.IsDefined(typeof(DataGridViewAdvancedCellBorderStyle), value))
			{
				throw new InvalidEnumArgumentException("Value is not valid DataGridViewAdvancedCellBorderStyle.");
			}
			if (value == DataGridViewAdvancedCellBorderStyle.NotSet)
			{
				throw new ArgumentException("Invlid Bottom value.");
			}
			bottom = value;
		}
	}

	public DataGridViewAdvancedCellBorderStyle Left
	{
		get
		{
			return left;
		}
		set
		{
			if (!Enum.IsDefined(typeof(DataGridViewAdvancedCellBorderStyle), value))
			{
				throw new InvalidEnumArgumentException("Value is not valid DataGridViewAdvancedCellBorderStyle.");
			}
			if (value == DataGridViewAdvancedCellBorderStyle.NotSet)
			{
				throw new ArgumentException("Invlid Left value.");
			}
			left = value;
		}
	}

	public DataGridViewAdvancedCellBorderStyle Right
	{
		get
		{
			return right;
		}
		set
		{
			if (!Enum.IsDefined(typeof(DataGridViewAdvancedCellBorderStyle), value))
			{
				throw new InvalidEnumArgumentException("Value is not valid DataGridViewAdvancedCellBorderStyle.");
			}
			if (value == DataGridViewAdvancedCellBorderStyle.NotSet)
			{
				throw new ArgumentException("Invlid Right value.");
			}
			right = value;
		}
	}

	public DataGridViewAdvancedCellBorderStyle Top
	{
		get
		{
			return top;
		}
		set
		{
			if (!Enum.IsDefined(typeof(DataGridViewAdvancedCellBorderStyle), value))
			{
				throw new InvalidEnumArgumentException("Value is not valid DataGridViewAdvancedCellBorderStyle.");
			}
			if (value == DataGridViewAdvancedCellBorderStyle.NotSet)
			{
				throw new ArgumentException("Invlid Top value.");
			}
			top = value;
		}
	}

	public DataGridViewAdvancedBorderStyle()
	{
		All = DataGridViewAdvancedCellBorderStyle.None;
	}

	public override bool Equals(object other)
	{
		if (other is DataGridViewAdvancedBorderStyle)
		{
			DataGridViewAdvancedBorderStyle dataGridViewAdvancedBorderStyle = (DataGridViewAdvancedBorderStyle)other;
			if (bottom == dataGridViewAdvancedBorderStyle.bottom && left == dataGridViewAdvancedBorderStyle.left && right == dataGridViewAdvancedBorderStyle.right)
			{
				return top == dataGridViewAdvancedBorderStyle.top;
			}
			return false;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format("DataGridViewAdvancedBorderStyle { All={0}, Left={1}, Right={2}, Top={3}, Bottom={4} }", All, Left, Right, Top, Bottom);
	}

	object ICloneable.Clone()
	{
		return new DataGridViewAdvancedBorderStyle
		{
			bottom = bottom,
			left = left,
			right = right,
			top = top
		};
	}
}
