using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class ARGB
{
	internal Unity.XGamingRuntime.Interop.ARGB interop;

	public byte A
	{
		get
		{
			return interop.A;
		}
		set
		{
			interop.A = value;
		}
	}

	public byte R
	{
		get
		{
			return interop.R;
		}
		set
		{
			interop.R = value;
		}
	}

	public byte G
	{
		get
		{
			return interop.G;
		}
		set
		{
			interop.G = value;
		}
	}

	public byte B
	{
		get
		{
			return interop.B;
		}
		set
		{
			interop.B = value;
		}
	}

	internal ARGB(Unity.XGamingRuntime.Interop.ARGB interopARGB)
	{
		interop = interopARGB;
	}

	public ARGB()
	{
		interop = default;
	}
}
