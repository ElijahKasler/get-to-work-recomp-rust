using System.Drawing;

namespace System.Windows.Forms;

public class Screen
{
	private static Screen[] all_screens;

	private bool primary;

	private Rectangle bounds;

	private Rectangle workarea;

	private string name;

	private int bits_per_pixel;

	public static Screen[] AllScreens => all_screens;

	public static Screen PrimaryScreen => all_screens[0];

	[System.MonoTODO("Stub, always returns 32")]
	public int BitsPerPixel => bits_per_pixel;

	public Rectangle Bounds => bounds;

	public string DeviceName => name;

	public bool Primary => primary;

	public Rectangle WorkingArea => workarea;

	static Screen()
	{
		try
		{
			all_screens = XplatUI.AllScreens;
		}
		catch (Exception ex)
		{
			Console.WriteLine("{0} trying to get all screens: {1}", ex.GetType(), ex.Message);
		}
		if (all_screens == null || all_screens.Length == 0)
		{
			all_screens = new Screen[1]
			{
				new Screen(primary: true, "Mono MWF Primary Display", XplatUI.VirtualScreen, XplatUI.WorkingArea)
			};
		}
	}

	internal Screen()
	{
		primary = true;
		bounds = XplatUI.WorkingArea;
	}

	internal Screen(bool primary, string name, Rectangle bounds, Rectangle workarea)
	{
		this.primary = primary;
		this.name = name;
		this.bounds = bounds;
		this.workarea = workarea;
		bits_per_pixel = 32;
	}

	public static Screen FromControl(Control control)
	{
		return FromPoint((control.Parent != null) ? control.Parent.PointToScreen(control.Location) : control.Location);
	}

	public static Screen FromHandle(IntPtr hwnd)
	{
		Control control = Control.FromHandle(hwnd);
		if (control != null)
		{
			return FromPoint((control.Parent != null) ? control.Parent.PointToScreen(control.Location) : control.Location);
		}
		return PrimaryScreen;
	}

	public static Screen FromPoint(Point point)
	{
		for (int i = 0; i < all_screens.Length; i++)
		{
			if (all_screens[i].Bounds.Contains(point))
			{
				return all_screens[i];
			}
		}
		return PrimaryScreen;
	}

	public static Screen FromRectangle(Rectangle rect)
	{
		Screen result = null;
		int num = int.MaxValue;
		Screen[] allScreens = AllScreens;
		foreach (Screen screen in allScreens)
		{
			Rectangle rectangle = screen.Bounds;
			int num2 = 0;
			if (rect.Left > rectangle.Right)
			{
				num2 += rect.Left - rectangle.Right;
			}
			else if (rectangle.Left > rect.Left)
			{
				num2 += rectangle.Left - rect.Left;
			}
			if (rectangle.Left > rect.Right)
			{
				num2 += rectangle.Left - rect.Right;
			}
			else if (rect.Right > rectangle.Right)
			{
				num2 += rect.Right - rectangle.Right;
			}
			if (rect.Top > rectangle.Bottom)
			{
				num2 += rect.Top - rectangle.Bottom;
			}
			else if (rectangle.Top > rect.Top)
			{
				num2 += rectangle.Top - rect.Top;
			}
			if (rectangle.Top > rect.Bottom)
			{
				num2 += rectangle.Top - rect.Bottom;
			}
			else if (rect.Bottom > rectangle.Bottom)
			{
				num2 += rect.Bottom - rectangle.Bottom;
			}
			if (num2 < num)
			{
				result = screen;
				num = num2;
			}
		}
		return result;
	}

	public static Rectangle GetBounds(Control ctl)
	{
		return FromControl(ctl).Bounds;
	}

	public static Rectangle GetBounds(Point pt)
	{
		return FromPoint(pt).Bounds;
	}

	public static Rectangle GetBounds(Rectangle rect)
	{
		return FromRectangle(rect).Bounds;
	}

	public static Rectangle GetWorkingArea(Control ctl)
	{
		return FromControl(ctl).WorkingArea;
	}

	public static Rectangle GetWorkingArea(Point pt)
	{
		return FromPoint(pt).WorkingArea;
	}

	public static Rectangle GetWorkingArea(Rectangle rect)
	{
		return FromRectangle(rect).WorkingArea;
	}

	public override bool Equals(object obj)
	{
		if (obj is Screen)
		{
			Screen screen = (Screen)obj;
			if (name.Equals(screen.name) && primary == screen.primary && bounds.Equals(screen.Bounds) && workarea.Equals(screen.workarea))
			{
				return true;
			}
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override string ToString()
	{
		return "Screen[Bounds={" + Bounds.ToString() + "} WorkingArea={" + WorkingArea.ToString() + "} Primary={" + Primary + "} DeviceName=" + DeviceName;
	}
}
