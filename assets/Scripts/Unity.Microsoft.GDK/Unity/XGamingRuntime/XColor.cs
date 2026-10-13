using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XColor
{
	internal Unity.XGamingRuntime.Interop.XColor _interop;

	internal ARGB _argb;

	internal Unity.XGamingRuntime.Interop.XColor interop
	{
		get
		{
			_interop.Argb = _argb.interop;
			return _interop;
		}
	}

	public ARGB Argb
	{
		get
		{
			return _argb;
		}
		set
		{
			_argb = value;
		}
	}

	public uint Value
	{
		get
		{
			return _interop.Value;
		}
		set
		{
			_interop.Value = value;
		}
	}

	internal XColor(Unity.XGamingRuntime.Interop.XColor interop)
	{
		_argb = new ARGB(interop.Argb);
		_interop = interop;
	}

	public XColor()
	{
		_interop = default;
	}
}
