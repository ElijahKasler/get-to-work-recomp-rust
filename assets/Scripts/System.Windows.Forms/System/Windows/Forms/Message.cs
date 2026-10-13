using System.Runtime.InteropServices;

namespace System.Windows.Forms;

public struct Message
{
	private int msg;

	private IntPtr hwnd;

	private IntPtr lParam;

	private IntPtr wParam;

	private IntPtr result;

	public IntPtr HWnd
	{
		get
		{
			return hwnd;
		}
		set
		{
			hwnd = value;
		}
	}

	public IntPtr LParam
	{
		get
		{
			return lParam;
		}
		set
		{
			lParam = value;
		}
	}

	public int Msg
	{
		get
		{
			return msg;
		}
		set
		{
			msg = value;
		}
	}

	public IntPtr Result
	{
		get
		{
			return result;
		}
		set
		{
			result = value;
		}
	}

	public IntPtr WParam
	{
		get
		{
			return wParam;
		}
		set
		{
			wParam = value;
		}
	}

	public static Message Create(IntPtr hWnd, int msg, IntPtr wparam, IntPtr lparam)
	{
		return new Message
		{
			msg = msg,
			hwnd = hWnd,
			wParam = wparam,
			lParam = lparam
		};
	}

	public static bool operator ==(Message a, Message b)
	{
		if (a.hwnd == b.hwnd && a.lParam == b.lParam && a.msg == b.msg && a.result == b.result)
		{
			return a.wParam == b.wParam;
		}
		return false;
	}

	public static bool operator !=(Message a, Message b)
	{
		return !(a == b);
	}

	public override bool Equals(object o)
	{
		if (!(o is Message))
		{
			return false;
		}
		if (msg == ((Message)o).msg && hwnd == ((Message)o).hwnd && lParam == ((Message)o).lParam && wParam == ((Message)o).wParam)
		{
			return result == ((Message)o).result;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public object GetLParam(Type cls)
	{
		return Marshal.PtrToStructure(lParam, cls);
	}

	public override string ToString()
	{
		object[] obj = new object[6] { this.msg, null, null, null, null, null };
		Msg msg = (Msg)this.msg;
		obj[1] = msg.ToString();
		obj[2] = hwnd.ToInt32();
		obj[3] = wParam.ToInt32();
		obj[4] = lParam.ToInt32();
		obj[5] = result.ToInt32();
		return string.Format("msg=0x{0:x} ({1}) hwnd=0x{2:x} wparam=0x{3:x} lparam=0x{4:x} result=0x{5:x}", obj);
	}
}
