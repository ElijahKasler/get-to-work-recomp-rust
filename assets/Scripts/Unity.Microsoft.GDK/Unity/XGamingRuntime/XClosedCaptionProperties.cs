using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XClosedCaptionProperties
{
	internal Unity.XGamingRuntime.Interop.XClosedCaptionProperties _interop;

	internal XColor _backgroundColor;

	internal XColor _fontColor;

	internal XColor _windowColor;

	internal Unity.XGamingRuntime.Interop.XClosedCaptionProperties interop
	{
		get
		{
			_interop.BackgroundColor = _backgroundColor.interop;
			_interop.FontColor = _fontColor.interop;
			_interop.WindowColor = _windowColor.interop;
			return _interop;
		}
	}

	public XColor BackgroundColor
	{
		get
		{
			return _backgroundColor;
		}
		set
		{
			_backgroundColor = value;
		}
	}

	public XColor FontColor
	{
		get
		{
			return _fontColor;
		}
		set
		{
			_fontColor = value;
		}
	}

	public XColor WindowColor
	{
		get
		{
			return _windowColor;
		}
		set
		{
			_windowColor = value;
		}
	}

	public XClosedCaptionFontEdgeAttribute FontEdgeAttribute
	{
		get
		{
			return _interop.FontEdgeAttribute;
		}
		set
		{
			_interop.FontEdgeAttribute = value;
		}
	}

	public XClosedCaptionFontStyle FontStyle
	{
		get
		{
			return _interop.FontStyle;
		}
		set
		{
			_interop.FontStyle = value;
		}
	}

	public float FontScale
	{
		get
		{
			return _interop.FontScale;
		}
		set
		{
			_interop.FontScale = value;
		}
	}

	public bool Enabled
	{
		get
		{
			return _interop.Enabled;
		}
		set
		{
			_interop.Enabled = value;
		}
	}

	internal XClosedCaptionProperties(Unity.XGamingRuntime.Interop.XClosedCaptionProperties interop)
	{
		BackgroundColor = new XColor(interop.BackgroundColor);
		FontColor = new XColor(interop.FontColor);
		WindowColor = new XColor(interop.WindowColor);
		_interop = interop;
	}

	public XClosedCaptionProperties()
	{
		_interop = default;
	}
}
