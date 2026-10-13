using System.ComponentModel;
using System.Runtime.InteropServices;

namespace System.Windows.Forms;

[ComVisible(true)]
[DesignTimeVisible(false)]
[ToolboxItem(false)]
[DefaultProperty("GridEditName")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public class DataGridTextBox : TextBox
{
	private bool isnavigating;

	private DataGrid grid;

	public bool IsInEditOrNavigateMode
	{
		get
		{
			return isnavigating;
		}
		set
		{
			isnavigating = value;
		}
	}

	public DataGridTextBox()
	{
		isnavigating = true;
		grid = null;
		accepts_tab = true;
		accepts_return = false;
		SetStyle(ControlStyles.UserPaint | ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, value: false);
		SetStyle(ControlStyles.FixedHeight, value: true);
	}

	protected override void OnKeyPress(KeyPressEventArgs e)
	{
		if (!base.ReadOnly)
		{
			isnavigating = false;
			grid.ColumnStartedEditing(base.Bounds);
		}
		base.OnKeyPress(e);
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
	}

	protected internal override bool ProcessKeyMessage(ref Message m)
	{
		Keys keys = (Keys)m.WParam.ToInt32();
		if (isnavigating && ProcessKeyPreview(ref m))
		{
			return true;
		}
		switch ((Msg)m.Msg)
		{
		case Msg.WM_CHAR:
			if (keys == Keys.Return)
			{
				isnavigating = true;
				return false;
			}
			return ProcessKeyEventArgs(ref m);
		case Msg.WM_KEYDOWN:
			switch (keys)
			{
			case Keys.F2:
				base.SelectionStart = Text.Length;
				SelectionLength = 0;
				return false;
			case Keys.Left:
				if (base.SelectionStart == 0)
				{
					return ProcessKeyPreview(ref m);
				}
				return false;
			case Keys.Right:
				if (base.SelectionStart + SelectionLength >= Text.Length)
				{
					return ProcessKeyPreview(ref m);
				}
				return false;
			case Keys.Return:
				return true;
			case Keys.Tab:
			case Keys.Up:
			case Keys.Down:
				return ProcessKeyPreview(ref m);
			default:
				return ProcessKeyEventArgs(ref m);
			}
		default:
			return false;
		}
	}

	public void SetDataGrid(DataGrid parentGrid)
	{
		grid = parentGrid;
	}

	protected override void WndProc(ref Message m)
	{
		Msg msg = (Msg)m.Msg;
		if (msg == Msg.WM_LBUTTONDOWN || msg == Msg.WM_LBUTTONDBLCLK)
		{
			isnavigating = false;
		}
		base.WndProc(ref m);
	}
}
