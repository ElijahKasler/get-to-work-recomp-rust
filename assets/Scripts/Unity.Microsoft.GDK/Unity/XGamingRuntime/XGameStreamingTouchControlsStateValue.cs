using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XGameStreamingTouchControlsStateValue
{
	internal Unity.XGamingRuntime.Interop.XGameStreamingTouchControlsStateValue interop;

	internal string _stringValue;

	public XGameStreamingTouchControlsStateValueKind ValueKind
	{
		get
		{
			return interop.valueKind;
		}
		set
		{
			interop.valueKind = value;
		}
	}

	public string StringValue
	{
		get
		{
			return _stringValue;
		}
		set
		{
			_stringValue = value;
		}
	}

	public double DoubleValue
	{
		get
		{
			return interop.doubleValue;
		}
		set
		{
			interop.doubleValue = value;
		}
	}

	public bool BoolValue
	{
		get
		{
			return interop.boolValue;
		}
		set
		{
			interop.boolValue = value;
		}
	}

	public uint IntegerValue
	{
		get
		{
			return interop.integerValue;
		}
		set
		{
			interop.integerValue = value;
		}
	}

	internal XGameStreamingTouchControlsStateValue(Unity.XGamingRuntime.Interop.XGameStreamingTouchControlsStateValue interop)
	{
		this.interop = interop;
	}

	public XGameStreamingTouchControlsStateValue()
	{
		interop = default;
	}
}
