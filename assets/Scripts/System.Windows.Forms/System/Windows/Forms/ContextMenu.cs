using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

[DefaultEvent("Popup")]
public class ContextMenu : Menu
{
	private RightToLeft right_to_left;

	private Control src_control;

	private static object CollapseEvent = new object();

	private static object PopupEvent = new object();

	[Localizable(true)]
	[DefaultValue(RightToLeft.No)]
	public virtual RightToLeft RightToLeft
	{
		get
		{
			return right_to_left;
		}
		set
		{
			right_to_left = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Control SourceControl => src_control;

	public event EventHandler Collapse
	{
		add
		{
			base.Events.AddHandler(CollapseEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(CollapseEvent, value);
		}
	}

	public event EventHandler Popup
	{
		add
		{
			base.Events.AddHandler(PopupEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(PopupEvent, value);
		}
	}

	public ContextMenu()
		: base(null)
	{
		tracker = new MenuTracker(this);
		right_to_left = RightToLeft.Inherit;
	}

	public ContextMenu(MenuItem[] menuItems)
		: base(menuItems)
	{
		tracker = new MenuTracker(this);
		right_to_left = RightToLeft.Inherit;
	}

	protected internal virtual bool ProcessCmdKey(ref Message msg, Keys keyData, Control control)
	{
		src_control = control;
		return ProcessCmdKey(ref msg, keyData);
	}

	protected internal virtual void OnCollapse(EventArgs e)
	{
		((EventHandler)base.Events[CollapseEvent])?.Invoke(this, e);
	}

	protected internal virtual void OnPopup(EventArgs e)
	{
		((EventHandler)base.Events[PopupEvent])?.Invoke(this, e);
	}

	public void Show(Control control, Point pos)
	{
		if (control == null)
		{
			throw new ArgumentException();
		}
		src_control = control;
		OnPopup(EventArgs.Empty);
		pos = control.PointToScreen(pos);
		MenuTracker.TrackPopupMenu(this, pos);
		OnCollapse(EventArgs.Empty);
	}

	public void Show(Control control, Point pos, LeftRightAlignment alignment)
	{
		Point pos2 = ((alignment != LeftRightAlignment.Left) ? pos : new Point(pos.X - control.Width, pos.Y));
		Show(control, pos2);
	}

	internal void Hide()
	{
		tracker.Deactivate();
	}
}
