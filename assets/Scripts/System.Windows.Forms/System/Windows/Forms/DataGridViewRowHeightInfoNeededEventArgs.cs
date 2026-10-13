using Unity;

namespace System.Windows.Forms;

public class DataGridViewRowHeightInfoNeededEventArgs : EventArgs
{
	private int height;

	private int minimumHeight;

	private int rowIndex;

	public int Height
	{
		get
		{
			return height;
		}
		set
		{
			height = ((value < minimumHeight) ? minimumHeight : value);
		}
	}

	public int MinimumHeight
	{
		get
		{
			return minimumHeight;
		}
		set
		{
			minimumHeight = value;
		}
	}

	public int RowIndex => rowIndex;

	internal DataGridViewRowHeightInfoNeededEventArgs(int rowIndex, int height, int minimumHeight)
	{
		this.rowIndex = rowIndex;
		this.height = height;
		this.minimumHeight = minimumHeight;
	}

	internal DataGridViewRowHeightInfoNeededEventArgs()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
