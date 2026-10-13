using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime;

public class XGameStreamingTouchControlsStateOperation
{
	internal Unity.XGamingRuntime.Interop.XGameStreamingTouchControlsStateOperation _interop;

	internal XGameStreamingTouchControlsStateValue _value;

	internal Unity.XGamingRuntime.Interop.XGameStreamingTouchControlsStateOperation interop
	{
		get
		{
			_interop.value = _value.interop;
			return _interop;
		}
	}

	public XGameStreamingTouchControlsStateOperationKind OperationKind
	{
		get
		{
			return _interop.operationKind;
		}
		set
		{
			_interop.operationKind = value;
		}
	}

	public string Path
	{
		get
		{
			return _interop.path;
		}
		set
		{
			_interop.path = value;
		}
	}

	public XGameStreamingTouchControlsStateValue Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
		}
	}

	internal XGameStreamingTouchControlsStateOperation(Unity.XGamingRuntime.Interop.XGameStreamingTouchControlsStateOperation interop)
	{
		_interop = interop;
		_value = new XGameStreamingTouchControlsStateValue(interop.value);
	}

	public XGameStreamingTouchControlsStateOperation()
	{
		_interop = default;
		_value = new XGameStreamingTouchControlsStateValue();
	}
}
