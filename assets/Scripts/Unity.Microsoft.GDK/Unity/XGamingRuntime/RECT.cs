using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class RECT
{
	internal Unity.XGamingRuntime.Interop.RECT interop;

	public uint Left
	{
		get
		{
			return interop.left;
		}
		set
		{
			interop.left = value;
		}
	}

	public uint Top
	{
		get
		{
			return interop.top;
		}
		set
		{
			interop.top = value;
		}
	}

	public uint Right
	{
		get
		{
			return interop.right;
		}
		set
		{
			interop.right = value;
		}
	}

	public uint Bottom
	{
		get
		{
			return interop.bottom;
		}
		set
		{
			interop.bottom = value;
		}
	}

	internal RECT(Unity.XGamingRuntime.Interop.RECT interop)
	{
		this.interop = interop;
	}

	public RECT()
	{
		interop = default;
	}
}
