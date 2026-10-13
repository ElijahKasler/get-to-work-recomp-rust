using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;

namespace System.Windows.Forms;

[DefaultProperty("Text")]
[ToolboxItemFilter("System.Windows.Forms", ToolboxItemFilterType.Allow)]
[Designer("System.Windows.Forms.Design.NotifyIconDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.IDesigner")]
[DefaultEvent("MouseDoubleClick")]
public sealed class NotifyIcon : Component
{
	internal class NotifyIconWindow : Form
	{
		private NotifyIcon owner;

		private Rectangle rect;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.Parent = IntPtr.Zero;
				createParams.Style = int.MinValue;
				createParams.Style |= 67108864;
				createParams.ExStyle = 128;
				return createParams;
			}
		}

		public NotifyIconWindow(NotifyIcon owner)
		{
			this.owner = owner;
			is_visible = false;
			rect = new Rectangle(0, 0, 1, 1);
			base.FormBorderStyle = FormBorderStyle.None;
			base.SizeChanged += HandleSizeChanged;
			base.DoubleClick += HandleDoubleClick;
			base.MouseDown += HandleMouseDown;
			base.MouseUp += HandleMouseUp;
			base.MouseMove += HandleMouseMove;
			ContextMenu = owner.context_menu;
			ContextMenuStrip = owner.context_menu_strip;
		}

		protected override void WndProc(ref Message m)
		{
			switch ((Msg)m.Msg)
			{
			case Msg.WM_CONTEXTMENU:
				break;
			case Msg.WM_USER:
				switch ((Msg)m.LParam.ToInt32())
				{
				case Msg.WM_LBUTTONDOWN:
					owner.OnMouseDown(new MouseEventArgs(MouseButtons.Left, 1, Control.MousePosition.X, Control.MousePosition.Y, 0));
					break;
				case Msg.WM_LBUTTONUP:
					owner.OnMouseUp(new MouseEventArgs(MouseButtons.Left, 1, Control.MousePosition.X, Control.MousePosition.Y, 0));
					break;
				case Msg.WM_LBUTTONDBLCLK:
					owner.OnDoubleClick(EventArgs.Empty);
					owner.OnMouseDoubleClick(new MouseEventArgs(MouseButtons.Left, 2, Control.MousePosition.X, Control.MousePosition.Y, 0));
					break;
				case Msg.WM_MOUSEMOVE:
					owner.OnMouseMove(new MouseEventArgs(MouseButtons.None, 1, Control.MousePosition.X, Control.MousePosition.Y, 0));
					break;
				case Msg.WM_RBUTTONDOWN:
					owner.OnMouseDown(new MouseEventArgs(MouseButtons.Right, 1, Control.MousePosition.X, Control.MousePosition.Y, 0));
					break;
				case Msg.WM_RBUTTONUP:
					owner.OnMouseUp(new MouseEventArgs(MouseButtons.Right, 1, Control.MousePosition.X, Control.MousePosition.Y, 0));
					break;
				case Msg.WM_RBUTTONDBLCLK:
					owner.OnDoubleClick(EventArgs.Empty);
					owner.OnMouseDoubleClick(new MouseEventArgs(MouseButtons.Left, 2, Control.MousePosition.X, Control.MousePosition.Y, 0));
					break;
				case Msg.NIN_BALLOONUSERCLICK:
					owner.OnBalloonTipClicked(EventArgs.Empty);
					break;
				case Msg.NIN_BALLOONSHOW:
					owner.OnBalloonTipShown(EventArgs.Empty);
					break;
				case Msg.WM_ASYNC_MESSAGE:
				case Msg.NIN_BALLOONTIMEOUT:
					owner.OnBalloonTipClosed(EventArgs.Empty);
					break;
				}
				break;
			default:
				base.WndProc(ref m);
				break;
			}
		}

		internal void CalculateIconRect()
		{
			int num = ((base.ClientRectangle.Width >= base.ClientRectangle.Height) ? base.ClientRectangle.Height : base.ClientRectangle.Width);
			int x = base.ClientRectangle.Width / 2 - num / 2;
			int y = base.ClientRectangle.Height / 2 - num / 2;
			rect = new Rectangle(x, y, num, num);
			base.Bounds = new Rectangle(0, 0, num, num);
		}

		internal override void OnPaintInternal(PaintEventArgs e)
		{
			if (owner.icon != null)
			{
				e.Graphics.FillRectangle(ThemeEngine.Current.ResPool.GetSolidBrush(SystemColors.Menu), rect);
				e.Graphics.DrawImage(owner.icon_bitmap, rect, new Rectangle(0, 0, owner.icon_bitmap.Width, owner.icon_bitmap.Height), GraphicsUnit.Pixel);
			}
		}

		internal void InternalRecreateHandle()
		{
			RecreateHandle();
		}

		private void HandleSizeChanged(object sender, EventArgs e)
		{
			owner.Recalculate();
		}

		private void HandleDoubleClick(object sender, EventArgs e)
		{
			owner.OnDoubleClick(e);
			owner.OnMouseDoubleClick(new MouseEventArgs(MouseButtons.Left, 2, Control.MousePosition.X, Control.MousePosition.Y, 0));
		}

		private void HandleMouseDown(object sender, MouseEventArgs e)
		{
			owner.OnMouseDown(e);
		}

		private void HandleMouseUp(object sender, MouseEventArgs e)
		{
			owner.OnMouseUp(e);
		}

		private void HandleMouseMove(object sender, MouseEventArgs e)
		{
			owner.OnMouseMove(e);
		}
	}

	internal class BalloonWindow : Form
	{
		private IntPtr owner;

		private Timer timer;

		private string title;

		private string text;

		private ToolTipIcon icon;

		public IntPtr OwnerHandle => owner;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.Style = int.MinValue;
				createParams.Style |= 67108864;
				createParams.ExStyle = 136;
				return createParams;
			}
		}

		internal StringFormat Format => new StringFormat
		{
			Alignment = StringAlignment.Near,
			HotkeyPrefix = HotkeyPrefix.Hide
		};

		public new ToolTipIcon Icon
		{
			get
			{
				return icon;
			}
			set
			{
				if (value != icon)
				{
					icon = value;
					Recalculate();
				}
			}
		}

		public string Title
		{
			get
			{
				return title;
			}
			set
			{
				if (!(value == title))
				{
					title = value;
					Recalculate();
				}
			}
		}

		public override string Text
		{
			get
			{
				return text;
			}
			set
			{
				if (!(value == text))
				{
					text = value;
					Recalculate();
				}
			}
		}

		public int Timeout
		{
			get
			{
				return timer.Interval;
			}
			set
			{
				if (value < 10000)
				{
					timer.Interval = 10000;
				}
				else if (value > 30000)
				{
					timer.Interval = 30000;
				}
				else
				{
					timer.Interval = value;
				}
			}
		}

		public BalloonWindow(IntPtr owner)
		{
			this.owner = owner;
			base.StartPosition = FormStartPosition.Manual;
			base.FormBorderStyle = FormBorderStyle.None;
			base.MouseDown += HandleMouseDown;
			timer = new Timer();
			timer.Enabled = false;
			timer.Tick += HandleTimer;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				timer.Stop();
				timer.Dispose();
			}
			base.Dispose(disposing);
		}

		public new void Close()
		{
			base.Close();
			XplatUI.SendMessage(owner, Msg.WM_USER, IntPtr.Zero, (IntPtr)1027);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			timer.Start();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			ThemeEngine.Current.DrawBalloonWindow(e.Graphics, base.ClientRectangle, this);
			base.OnPaint(e);
		}

		private void Recalculate()
		{
			Rectangle rectangle = ThemeEngine.Current.BalloonWindowRect(this);
			base.Left = rectangle.Left;
			base.Top = rectangle.Top;
			base.Width = rectangle.Width;
			base.Height = rectangle.Height;
		}

		private void HandleMouseDown(object sender, MouseEventArgs e)
		{
			XplatUI.SendMessage(owner, Msg.WM_USER, IntPtr.Zero, (IntPtr)1029);
			base.Close();
		}

		private void HandleTimer(object sender, EventArgs e)
		{
			timer.Stop();
			XplatUI.SendMessage(owner, Msg.WM_USER, IntPtr.Zero, (IntPtr)1028);
			base.Close();
		}
	}

	private ContextMenu context_menu;

	private Icon icon;

	private Bitmap icon_bitmap;

	private string text;

	private bool visible;

	private NotifyIconWindow window;

	private bool systray_active;

	private ToolTip tooltip;

	private bool double_click;

	private string balloon_text;

	private string balloon_title;

	private ToolTipIcon balloon_icon;

	private ContextMenuStrip context_menu_strip;

	private object tag;

	private static object ClickEvent = new object();

	private static object DoubleClickEvent = new object();

	private static object MouseDownEvent = new object();

	private static object MouseMoveEvent = new object();

	private static object MouseUpEvent = new object();

	private static object BalloonTipClickedEvent = new object();

	private static object BalloonTipClosedEvent = new object();

	private static object BalloonTipShownEvent = new object();

	private static object MouseClickEvent = new object();

	private static object MouseDoubleClickEvent = new object();

	[DefaultValue("None")]
	public ToolTipIcon BalloonTipIcon
	{
		get
		{
			return balloon_icon;
		}
		set
		{
			if (value != balloon_icon)
			{
				balloon_icon = value;
			}
		}
	}

	[DefaultValue("")]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[Localizable(true)]
	public string BalloonTipText
	{
		get
		{
			return balloon_text;
		}
		set
		{
			if (!(value == balloon_text))
			{
				balloon_text = value;
			}
		}
	}

	[DefaultValue("")]
	[Localizable(true)]
	public string BalloonTipTitle
	{
		get
		{
			return balloon_title;
		}
		set
		{
			if (!(value == balloon_title))
			{
				balloon_title = value;
			}
		}
	}

	[DefaultValue(null)]
	[Browsable(false)]
	public ContextMenu ContextMenu
	{
		get
		{
			return context_menu;
		}
		set
		{
			if (context_menu != value)
			{
				context_menu = value;
				window.ContextMenu = value;
			}
		}
	}

	[DefaultValue(null)]
	public ContextMenuStrip ContextMenuStrip
	{
		get
		{
			return context_menu_strip;
		}
		set
		{
			if (context_menu_strip != value)
			{
				context_menu_strip = value;
				window.ContextMenuStrip = value;
			}
		}
	}

	[DefaultValue(null)]
	[Localizable(true)]
	public Icon Icon
	{
		get
		{
			return icon;
		}
		set
		{
			if (icon != value)
			{
				icon = value;
				Recalculate();
			}
		}
	}

	[TypeConverter(typeof(StringConverter))]
	[DefaultValue(null)]
	[Bindable(true)]
	[Localizable(false)]
	public object Tag
	{
		get
		{
			return tag;
		}
		set
		{
			tag = value;
		}
	}

	[Localizable(true)]
	[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
	[DefaultValue("")]
	public string Text
	{
		get
		{
			return text;
		}
		set
		{
			if (text != value)
			{
				if (value.Length >= 64)
				{
					throw new ArgumentException("ToolTip length must be less than 64 characters long", "Text");
				}
				text = value;
				Recalculate();
			}
		}
	}

	[DefaultValue(false)]
	[Localizable(true)]
	public bool Visible
	{
		get
		{
			return visible;
		}
		set
		{
			if (visible != value)
			{
				visible = value;
				window.is_visible = value;
				if (visible)
				{
					ShowSystray();
				}
				else
				{
					HideSystray();
				}
			}
		}
	}

	[MWFCategory("Action")]
	public event EventHandler BalloonTipClicked
	{
		add
		{
			base.Events.AddHandler(BalloonTipClickedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(BalloonTipClickedEvent, value);
		}
	}

	[MWFCategory("Action")]
	public event EventHandler BalloonTipClosed
	{
		add
		{
			base.Events.AddHandler(BalloonTipClosedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(BalloonTipClosedEvent, value);
		}
	}

	[MWFCategory("Action")]
	public event EventHandler BalloonTipShown
	{
		add
		{
			base.Events.AddHandler(BalloonTipShownEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(BalloonTipShownEvent, value);
		}
	}

	[MWFCategory("Action")]
	public event MouseEventHandler MouseClick
	{
		add
		{
			base.Events.AddHandler(MouseClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseClickEvent, value);
		}
	}

	[MWFCategory("Action")]
	public event MouseEventHandler MouseDoubleClick
	{
		add
		{
			base.Events.AddHandler(MouseDoubleClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseDoubleClickEvent, value);
		}
	}

	[MWFCategory("Action")]
	public event EventHandler Click
	{
		add
		{
			base.Events.AddHandler(ClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ClickEvent, value);
		}
	}

	[MWFCategory("Action")]
	public event EventHandler DoubleClick
	{
		add
		{
			base.Events.AddHandler(DoubleClickEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(DoubleClickEvent, value);
		}
	}

	public event MouseEventHandler MouseDown
	{
		add
		{
			base.Events.AddHandler(MouseDownEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseDownEvent, value);
		}
	}

	public event MouseEventHandler MouseMove
	{
		add
		{
			base.Events.AddHandler(MouseMoveEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseMoveEvent, value);
		}
	}

	public event MouseEventHandler MouseUp
	{
		add
		{
			base.Events.AddHandler(MouseUpEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(MouseUpEvent, value);
		}
	}

	public NotifyIcon()
	{
		window = new NotifyIconWindow(this);
		systray_active = false;
		balloon_title = "";
		balloon_text = "";
	}

	public NotifyIcon(IContainer container)
		: this()
	{
	}

	public void ShowBalloonTip(int timeout)
	{
		ShowBalloonTip(timeout, balloon_title, balloon_text, balloon_icon);
	}

	public void ShowBalloonTip(int timeout, string tipTitle, string tipText, ToolTipIcon tipIcon)
	{
		XplatUI.SystrayBalloon(window.Handle, timeout, tipTitle, tipText, tipIcon);
	}

	private void OnBalloonTipClicked(EventArgs e)
	{
		((EventHandler)base.Events[BalloonTipClickedEvent])?.Invoke(this, e);
	}

	private void OnBalloonTipClosed(EventArgs e)
	{
		((EventHandler)base.Events[BalloonTipClosedEvent])?.Invoke(this, e);
	}

	private void OnBalloonTipShown(EventArgs e)
	{
		((EventHandler)base.Events[BalloonTipShownEvent])?.Invoke(this, e);
	}

	private void OnClick(EventArgs e)
	{
		((EventHandler)base.Events[ClickEvent])?.Invoke(this, e);
	}

	private void OnDoubleClick(EventArgs e)
	{
		double_click = true;
		((EventHandler)base.Events[DoubleClickEvent])?.Invoke(this, e);
	}

	private void OnMouseClick(MouseEventArgs e)
	{
		((MouseEventHandler)base.Events[MouseClickEvent])?.Invoke(this, e);
	}

	private void OnMouseDoubleClick(MouseEventArgs e)
	{
		((MouseEventHandler)base.Events[MouseDoubleClickEvent])?.Invoke(this, e);
	}

	private void OnMouseDown(MouseEventArgs e)
	{
		((MouseEventHandler)base.Events[MouseDownEvent])?.Invoke(this, e);
	}

	private void OnMouseUp(MouseEventArgs e)
	{
		if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
		{
			if (context_menu != null)
			{
				XplatUI.SetForegroundWindow(window.Handle);
				context_menu.Show(window, new Point(e.X, e.Y));
			}
			else if (context_menu_strip != null)
			{
				XplatUI.SetForegroundWindow(window.Handle);
				context_menu_strip.Show(window, new Point(e.X, e.Y), ToolStripDropDownDirection.AboveLeft);
			}
		}
		((MouseEventHandler)base.Events[MouseUpEvent])?.Invoke(this, e);
		if (!double_click)
		{
			OnClick(EventArgs.Empty);
			OnMouseClick(e);
			double_click = false;
		}
	}

	private void OnMouseMove(MouseEventArgs e)
	{
		((MouseEventHandler)base.Events[MouseMoveEvent])?.Invoke(this, e);
	}

	private void Recalculate()
	{
		window.CalculateIconRect();
		if (!Visible || (text == string.Empty && icon == null))
		{
			HideSystray();
		}
		else if (systray_active)
		{
			UpdateSystray();
		}
		else
		{
			ShowSystray();
		}
	}

	private void ShowSystray()
	{
		if (icon != null)
		{
			icon_bitmap = icon.ToBitmap();
			systray_active = true;
			XplatUI.SystrayAdd(window.Handle, text, icon, out tooltip);
		}
	}

	private void HideSystray()
	{
		if (systray_active)
		{
			systray_active = false;
			XplatUI.SystrayRemove(window.Handle, ref tooltip);
		}
	}

	private void UpdateSystray()
	{
		if (icon_bitmap != null)
		{
			icon_bitmap.Dispose();
		}
		if (icon != null)
		{
			icon_bitmap = icon.ToBitmap();
		}
		window.Invalidate();
		XplatUI.SystrayChange(window.Handle, text, icon, ref tooltip);
	}

	protected override void Dispose(bool disposing)
	{
		if (visible)
		{
			HideSystray();
		}
		if (icon_bitmap != null)
		{
			icon_bitmap.Dispose();
		}
		if (disposing)
		{
			icon = null;
		}
		base.Dispose(disposing);
	}
}
