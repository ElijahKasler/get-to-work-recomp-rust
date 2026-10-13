using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XGameUiTextEntryExtents
{
	internal Unity.XGamingRuntime.Interop.XGameUiTextEntryExtents interop;

	public float Left
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

	public float Top
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

	public float Right
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

	public float Bottom
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

	internal XGameUiTextEntryExtents(Unity.XGamingRuntime.Interop.XGameUiTextEntryExtents interop)
	{
		this.interop = interop;
	}

	public XGameUiTextEntryExtents()
	{
		interop = default;
	}
}
