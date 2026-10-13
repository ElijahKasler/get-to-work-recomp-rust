using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls;

[Serializable]
[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]
public abstract class TouchControl : CustomControllerControl
{
	private Canvas _canvas;

	private RectTransform __rectTransform;

	internal TouchController JqhKIzjYhpSfywSfyYnlDBWmhgi => CItSKWNCrpFEYpHelQesNaXrFvaHA();

	internal Canvas ZFObATvOAzNjrgdNgchuZXGTsevh => qVnIqObCTShIxSKGdNESmpBXjwRK();

	internal RectTransform IvwMVWpRAHkiVDaAmMaSUGXDyocK => PvPMQFDzlybbkuSgSSLnUkAlIJPiA();

	internal RectTransform nfJlANeXDrkGzzDgMPmxTaHsdele => kJMTokSRJfFCvJTzvbFYrXMRhvEn();

	bool cGatEfztsIqCLsTucDMygLcPoUUK => cGatEfztsIqCLsTucDMygLcPoUUK();

	internal TouchController CItSKWNCrpFEYpHelQesNaXrFvaHA()
	{
		return BuIhXAQcFtYVfhAxQBezxvNwKXPV() as TouchController;
	}

	internal Canvas qVnIqObCTShIxSKGdNESmpBXjwRK()
	{
		return _canvas;
	}

	internal RectTransform PvPMQFDzlybbkuSgSSLnUkAlIJPiA()
	{
		Canvas canvas = qVnIqObCTShIxSKGdNESmpBXjwRK();
		if (canvas == null)
		{
			return null;
		}
		return canvas.transform as RectTransform;
	}

	internal RectTransform kJMTokSRJfFCvJTzvbFYrXMRhvEn()
	{
		return __rectTransform ?? (__rectTransform = GetComponent<RectTransform>());
	}

	[CustomObfuscation(rename = false)]
	internal TouchControl()
	{
	}

	[CustomObfuscation(rename = false)]
	internal override void OnValidate()
	{
		base.OnValidate();
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			JdmVoRuQzuQqasyLchVjExaePAZC(true, false);
		}
	}

	[CustomObfuscation(rename = false)]
	internal override void OnCanvasGroupChanged()
	{
		base.OnCanvasGroupChanged();
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			JdmVoRuQzuQqasyLchVjExaePAZC(false, true);
		}
	}

	[CustomObfuscation(rename = false)]
	internal override void OnTransformParentChanged()
	{
		base.OnTransformParentChanged();
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			JdmVoRuQzuQqasyLchVjExaePAZC(false, true);
		}
	}

	internal override bool cGatEfztsIqCLsTucDMygLcPoUUK()
	{
		return BuIhXAQcFtYVfhAxQBezxvNwKXPV() as TouchController != null;
	}

	internal virtual bool TgEbbHyrtOqZjiwcGxLVOjyndluD()
	{
		if (!base.FsdUEhTyInDeflICOqtuQITqTrWT())
		{
			return false;
		}
		if (!JdmVoRuQzuQqasyLchVjExaePAZC(true, true))
		{
			return false;
		}
		return true;
	}

	internal virtual void NjnITELCJXnacXZojvszsHYThgOM()
	{
		base.vkqeMcpvYrejUrwxCMROyCrCSmcD();
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			JdmVoRuQzuQqasyLchVjExaePAZC(true, true);
		}
	}

	[CustomObfuscation(rename = false)]
	internal override IComponentController FindController()
	{
		return UnityTools.GetComponentInSelfOrParents<CustomController>(base.transform);
	}

	[CustomObfuscation(rename = false)]
	internal override Type GetRequiredControllerType()
	{
		return typeof(TouchController);
	}

	private bool JdmVoRuQzuQqasyLchVjExaePAZC(bool P_0, bool P_1)
	{
		_canvas = UnityTools.GetComponentInSelfOrParents<Canvas>(base.gameObject);
		if (_canvas == null)
		{
			if (P_0)
			{
				Logger.LogError("No Canvas was found. Touch controls must be a child of a Canvas.");
			}
			return false;
		}
		if (_canvas.renderMode == RenderMode.WorldSpace)
		{
			if (P_1)
			{
				Logger.LogError("Touch controls cannot be used with a world space Canvas. Change the canvas render mode to screen space.");
			}
			return false;
		}
		return true;
	}
}
