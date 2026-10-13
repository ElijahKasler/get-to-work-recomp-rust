using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class SYSTEMTIME
{
	internal Unity.XGamingRuntime.Interop.SYSTEMTIME interop;

	public ushort WYear
	{
		get
		{
			return interop.wYear;
		}
		set
		{
			interop.wYear = value;
		}
	}

	public ushort WMonth
	{
		get
		{
			return interop.wMonth;
		}
		set
		{
			interop.wMonth = value;
		}
	}

	public ushort WDayOfWeek
	{
		get
		{
			return interop.wDayOfWeek;
		}
		set
		{
			interop.wDayOfWeek = value;
		}
	}

	public ushort WDay
	{
		get
		{
			return interop.wDay;
		}
		set
		{
			interop.wDay = value;
		}
	}

	public ushort WHour
	{
		get
		{
			return interop.wHour;
		}
		set
		{
			interop.wHour = value;
		}
	}

	public ushort WMinute
	{
		get
		{
			return interop.wMinute;
		}
		set
		{
			interop.wMinute = value;
		}
	}

	public ushort WSecond
	{
		get
		{
			return interop.wSecond;
		}
		set
		{
			interop.wSecond = value;
		}
	}

	public ushort WMilliseconds
	{
		get
		{
			return interop.wMilliseconds;
		}
		set
		{
			interop.wMilliseconds = value;
		}
	}

	internal SYSTEMTIME(Unity.XGamingRuntime.Interop.SYSTEMTIME interop)
	{
		this.interop = interop;
	}

	public SYSTEMTIME()
	{
		interop = default;
	}
}
