using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XGameStreamingDisplayDetails
{
	internal Unity.XGamingRuntime.Interop.XGameStreamingDisplayDetails _interop;

	internal RECT rect;

	internal Unity.XGamingRuntime.Interop.XGameStreamingDisplayDetails interop
	{
		get
		{
			_interop.safeArea = rect.interop;
			return _interop;
		}
	}

	public uint PreferredWidth
	{
		get
		{
			return _interop.preferredWidth;
		}
		set
		{
			_interop.preferredWidth = value;
		}
	}

	public uint PreferredHeight
	{
		get
		{
			return _interop.preferredHeight;
		}
		set
		{
			_interop.preferredHeight = value;
		}
	}

	public RECT SafeArea
	{
		get
		{
			return rect;
		}
		set
		{
			rect = value;
		}
	}

	public uint MaxPixels
	{
		get
		{
			return _interop.maxPixels;
		}
		set
		{
			_interop.maxPixels = value;
		}
	}

	public uint MaxWidth
	{
		get
		{
			return _interop.maxWidth;
		}
		set
		{
			_interop.maxWidth = value;
		}
	}

	public uint MaxHeight
	{
		get
		{
			return _interop.maxHeight;
		}
		set
		{
			_interop.maxHeight = value;
		}
	}

	public XGameStreamingVideoFlags Flags
	{
		get
		{
			return _interop.flags;
		}
		set
		{
			_interop.flags = value;
		}
	}

	internal XGameStreamingDisplayDetails(Unity.XGamingRuntime.Interop.XGameStreamingDisplayDetails interop)
	{
		_interop = interop;
		rect = new RECT(interop.safeArea);
	}

	public XGameStreamingDisplayDetails()
	{
		_interop = default;
		rect = new RECT();
	}
}
