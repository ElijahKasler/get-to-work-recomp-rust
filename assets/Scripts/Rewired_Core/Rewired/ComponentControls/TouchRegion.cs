using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rewired.ComponentControls;

[Serializable]
[DisallowMultipleComponent]
[AddComponentMenu("Rewired/Touch Controls/Touch Region")]
public sealed class TouchRegion : TouchInteractable
{
	[Serializable]
	private class gGngxbGydxcKNMhppxzGnMydTpWT : UnityEvent<PointerEventData>
	{
	}

	[Serializable]
	private class nNcOfJhNiZKcuwsjbCuywBrCsrmm : UnityEvent<PointerEventData>
	{
	}

	[Serializable]
	private class AhfULYkJEozJhoVZWMDZbQVawsEm : UnityEvent<PointerEventData>
	{
	}

	[Serializable]
	private class wFLMVdBDmRajrpWKJLrUAbymipfD : UnityEvent<PointerEventData>
	{
	}

	[Serializable]
	private class rmRponqnvWDevJCkfOVlQnAlAoVH : UnityEvent<PointerEventData>
	{
	}

	[Serializable]
	private class VAZcUzAVcqnWxuXjMCVGwAuloJqX : UnityEvent<PointerEventData>
	{
	}

	[Serializable]
	private class MSnyyPwCLiCBFGTUYJRVIsxVqFuK : UnityEvent<PointerEventData>
	{
	}

	[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _hideAtRuntime = true;

	private gGngxbGydxcKNMhppxzGnMydTpWT _onPointerDown = new gGngxbGydxcKNMhppxzGnMydTpWT();

	private nNcOfJhNiZKcuwsjbCuywBrCsrmm _onPointerUp = new nNcOfJhNiZKcuwsjbCuywBrCsrmm();

	private AhfULYkJEozJhoVZWMDZbQVawsEm _onPointerEnter = new AhfULYkJEozJhoVZWMDZbQVawsEm();

	private wFLMVdBDmRajrpWKJLrUAbymipfD _onPointerExit = new wFLMVdBDmRajrpWKJLrUAbymipfD();

	private rmRponqnvWDevJCkfOVlQnAlAoVH _onBeginDrag = new rmRponqnvWDevJCkfOVlQnAlAoVH();

	private VAZcUzAVcqnWxuXjMCVGwAuloJqX _onDrag = new VAZcUzAVcqnWxuXjMCVGwAuloJqX();

	private MSnyyPwCLiCBFGTUYJRVIsxVqFuK _onEndDrag = new MSnyyPwCLiCBFGTUYJRVIsxVqFuK();

	public bool hideAtRuntime
	{
		get
		{
			return _hideAtRuntime;
		}
		set
		{
			if (!(_hideAtRuntime = value))
			{
				_hideAtRuntime = true;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public event UnityAction<PointerEventData> PointerDownEvent
	{
		add
		{
			_onPointerDown.AddListener(value);
		}
		remove
		{
			_onPointerDown.RemoveListener(value);
		}
	}

	public event UnityAction<PointerEventData> PointerUpEvent
	{
		add
		{
			_onPointerUp.AddListener(value);
		}
		remove
		{
			_onPointerUp.RemoveListener(value);
		}
	}

	public event UnityAction<PointerEventData> PointerEnterEvent
	{
		add
		{
			_onPointerEnter.AddListener(value);
		}
		remove
		{
			_onPointerEnter.RemoveListener(value);
		}
	}

	public event UnityAction<PointerEventData> PointerExitEvent
	{
		add
		{
			_onPointerExit.AddListener(value);
		}
		remove
		{
			_onPointerExit.RemoveListener(value);
		}
	}

	public event UnityAction<PointerEventData> BeginDragEvent
	{
		add
		{
			_onBeginDrag.AddListener(value);
		}
		remove
		{
			_onBeginDrag.RemoveListener(value);
		}
	}

	public event UnityAction<PointerEventData> DragEvent
	{
		add
		{
			_onDrag.AddListener(value);
		}
		remove
		{
			_onDrag.RemoveListener(value);
		}
	}

	public event UnityAction<PointerEventData> EndDragEvent
	{
		add
		{
			_onEndDrag.AddListener(value);
		}
		remove
		{
			_onEndDrag.RemoveListener(value);
		}
	}

	[CustomObfuscation(rename = false)]
	private TouchRegion()
	{
	}

	[CustomObfuscation(rename = false)]
	internal override void Awake()
	{
		base.Awake();
		if (Application.isPlaying && _hideAtRuntime)
		{
			base.visible = false;
		}
	}

	public override void ClearValue()
	{
	}

	internal void zRllZhSXgLimEGvwUGsKogDzobOD()
	{
	}

	internal void KlzapRcPVGsUlfTNolUpbMplUMVMA(PointerEventData P_0)
	{
		base.OnPointerDown(P_0);
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && oaeJwcBeZoMZRNVcTgpbqRThFymT() && IsInteractable() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && _onPointerDown != null)
		{
			_onPointerDown.Invoke(P_0);
		}
	}

	internal void oYzCEmZKdtrlhOTZBOuVonQaIKgA(PointerEventData P_0)
	{
		base.OnPointerUp(P_0);
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && oaeJwcBeZoMZRNVcTgpbqRThFymT() && IsInteractable() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && _onPointerUp != null)
		{
			_onPointerUp.Invoke(P_0);
		}
	}

	internal void ZuIbHcxiPygaSZlbAwYxmeAItRAh(PointerEventData P_0)
	{
		base.OnPointerEnter(P_0);
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && oaeJwcBeZoMZRNVcTgpbqRThFymT() && IsInteractable() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && _onPointerEnter != null)
		{
			_onPointerEnter.Invoke(P_0);
		}
	}

	internal void fqsHjmufzxBlIQPtzrBkxKawjOzU(PointerEventData P_0)
	{
		base.OnPointerExit(P_0);
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && oaeJwcBeZoMZRNVcTgpbqRThFymT() && IsInteractable() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && _onPointerExit != null)
		{
			_onPointerExit.Invoke(P_0);
		}
	}

	internal void vpAAViiJCmXHfflPklUpDeQCktkaB(PointerEventData P_0)
	{
		base.OnBeginDrag(P_0);
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && oaeJwcBeZoMZRNVcTgpbqRThFymT() && IsInteractable() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && _onBeginDrag != null)
		{
			_onBeginDrag.Invoke(P_0);
		}
	}

	internal void DrZKGPQVfYXnhVAleyZXdoqWvkPJ(PointerEventData P_0)
	{
		base.OnDrag(P_0);
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && oaeJwcBeZoMZRNVcTgpbqRThFymT() && IsInteractable() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && _onDrag != null)
		{
			_onDrag.Invoke(P_0);
		}
	}

	internal void hqDFBoauDSsrYDefXLkFtPuVgSAXA(PointerEventData P_0)
	{
		base.OnEndDrag(P_0);
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && oaeJwcBeZoMZRNVcTgpbqRThFymT() && IsInteractable() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && _onEndDrag != null)
		{
			_onEndDrag.Invoke(P_0);
		}
	}
}
