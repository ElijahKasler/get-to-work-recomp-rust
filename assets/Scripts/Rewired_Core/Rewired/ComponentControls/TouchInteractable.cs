using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rewired.ComponentControls;

[Serializable]
[ExecuteInEditMode]
[DisallowMultipleComponent]
public abstract class TouchInteractable : TouchControl, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public enum InteractionState
	{
		Normal = 0,
		Highlighted = 1,
		Pressed = 2,
		Disabled = 3
	}

	[Flags]
	public enum TransitionTypeFlags
	{
		None = 0,
		ColorTint = 1,
		SpriteSwap = 2,
		Animation = 4
	}

	[Flags]
	public enum MouseButtonFlags
	{
		None = 0,
		LeftButton = 1,
		RightButton = 2,
		MiddleButton = 4,
		AnyButton = -1
	}

	[Serializable]
	public class InteractionStateTransitionEventHandler : UnityEvent<InteractionStateTransitionArgs>
	{
	}

	[Serializable]
	public class VisibilityChangedEventHandler : UnityEvent<bool>
	{
	}

	public class InteractionStateTransitionArgs
	{
		private TouchInteractable cQdQarjraGQTFmoexbwZfzMcYCvaA;

		private InteractionState xlgqSqDZaGDRDZRVLgykIfFjjxAhA;

		private float awVOtIigkISIczhieFltIMANErUk;

		public TouchInteractable sender => cQdQarjraGQTFmoexbwZfzMcYCvaA;

		public InteractionState state => xlgqSqDZaGDRDZRVLgykIfFjjxAhA;

		public float duration => awVOtIigkISIczhieFltIMANErUk;

		internal InteractionStateTransitionArgs()
		{
		}

		internal void NBEdYTfjtRocMsQzKCoNJHpUhuaB(TouchInteractable P_0, InteractionState P_1, float P_2)
		{
			cQdQarjraGQTFmoexbwZfzMcYCvaA = P_0;
			xlgqSqDZaGDRDZRVLgykIfFjjxAhA = P_1;
			awVOtIigkISIczhieFltIMANErUk = P_2;
		}
	}

	public interface IInteractionStateTransitionHandler
	{
		void OnInteractionStateTransition(InteractionStateTransitionArgs data);
	}

	[Serializable]
	private sealed class sbqLZCsbjaHCcyeFnazWxQwSjuRo
	{
		public static readonly sbqLZCsbjaHCcyeFnazWxQwSjuRo _003C_003E9 = new sbqLZCsbjaHCcyeFnazWxQwSjuRo();

		public static nAyecUrILTBdncCpsxajfiIEYETo.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> _003C_003E9__152_0;

		internal void SJLbOIJVttjijdFVJKXnMOmpPeJrA(IInteractionStateTransitionHandler P_0, InteractionStateTransitionArgs P_1)
		{
			P_0.OnInteractionStateTransition(P_1);
		}
	}

	public const int POINTER_ID_NULL = int.MinValue;

	public const int POINTER_ID_MOUSE_LEFT_BUTTON = -1;

	public const int POINTER_ID_MOUSE_RIGHT_BUTTON = -2;

	public const int POINTER_ID_MOUSE_MIDDLE_BUTTON = -3;

	internal const int MAX_MOUSE_BUTTONS = 3;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Tooltip("Toggles whether the control can be interacted with by the user.")]
	private bool _interactable = true;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Tooltip("Toggles visibility. An invisible control can still be interacted with. This property only has any effect when used with an Image Component.")]
	private bool _visible = true;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Tooltip("Sets visibility to False when the control is idle. When the control is no longer idle, visibility will be set to True again.")]
	private bool _hideWhenIdle;

	[Tooltip("The mouse buttons that are allowed to interact with this control.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Bitmask(typeof(MouseButtonFlags))]
	private MouseButtonFlags _allowedMouseButtons = MouseButtonFlags.LeftButton;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Tooltip("The transition type(s) to be used when transitioning to various states. Multiple transition types can be used simultaneously.")]
	[Bitmask(typeof(TransitionTypeFlags))]
	private TransitionTypeFlags _transitionType;

	[Tooltip("Settings using for Color Tint transitions.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private ColorBlock _transitionColorTint = new ColorBlock
	{
		colorMultiplier = 1f,
		disabledColor = new Color(25f / 32f, 25f / 32f, 25f / 32f, 0.5f),
		highlightedColor = Color.white,
		normalColor = Color.white,
		pressedColor = Color.white,
		fadeDuration = 0.1f
	};

	[Tooltip("Settings using for Sprite State transitions.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private SpriteState _transitionSpriteState;

	[Tooltip("Settings using for Animation Trigger transitions.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private AnimationTriggers _transitionAnimationTriggers = new AnimationTriggers();

	[Tooltip("The target Graphic component for interaction state transitions. This should normally be set to an Image component on this GameObject.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Graphic _targetGraphic;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Tooltip("Event sent when the Interaction State changes.")]
	private InteractionStateTransitionEventHandler _onInteractionStateTransition = new InteractionStateTransitionEventHandler();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Tooltip("Event sent when visibility changes.")]
	private VisibilityChangedEventHandler _onVisibilityChanged = new VisibilityChangedEventHandler();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Tooltip("Event sent when interaction state changes to Normal.")]
	private UnityEvent _onInteractionStateChangedToNormal = new UnityEvent();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Tooltip("Event sent when interaction state changes to Highlighted.")]
	private UnityEvent _onInteractionStateChangedToHighlighted = new UnityEvent();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Tooltip("Event sent when interaction state changes to Pressed.")]
	private UnityEvent _onInteractionStateChangedToPressed = new UnityEvent();

	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Tooltip("Event sent when interaction state changes to Disabled.")]
	private UnityEvent _onInteractionStateChangedToDisabled = new UnityEvent();

	private readonly List<CanvasGroup> _canvasGroupCache = new List<CanvasGroup>();

	private bool _groupsAllowInteraction = true;

	private InteractionState _interactionState;

	[NonSerialized]
	private bool CYbIXNEjSCqyHZkKxoLBHgOrNJeQ;

	[NonSerialized]
	private bool CAhDMgSoccIBttOWNuRutaIMwfjg;

	private bool _varWatch_visible;

	private bool _varWatch_interactable;

	private bool _allowSendingEvents = true;

	private static InteractionStateTransitionArgs _transitionArgs = new InteractionStateTransitionArgs();

	private nAyecUrILTBdncCpsxajfiIEYETo.HierarchyEventHelper<IVisibilityChangedHandler, bool> __hierarchyVisibilityChangedHandlers;

	private nAyecUrILTBdncCpsxajfiIEYETo.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __hierarchyInteractionStateTransitionHandlers;

	private static nAyecUrILTBdncCpsxajfiIEYETo.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> __interactionStateTransitionHandlerDelegate;

	private nAyecUrILTBdncCpsxajfiIEYETo.HierarchyEventHelper<IVisibilityChangedHandler, bool> lfBGnyKCfCgleCVpFlWcUyZvKKCl => NRGdGaxdsawDszrVjmShYZanfzui();

	private nAyecUrILTBdncCpsxajfiIEYETo.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> lFXwmBCNRbZGLomyvGNSZAHVfRcM => PWidLqsoCvANUCdLUdFZKXfgFySE();

	public bool interactable
	{
		get
		{
			return _interactable;
		}
		set
		{
			if (_interactable != value)
			{
				_interactable = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public bool visible
	{
		get
		{
			return _visible;
		}
		set
		{
			if (visible != value)
			{
				RyWDISUhTXmyeeBspuhOZRZxHQMe(value, false);
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public bool hideWhenIdle
	{
		get
		{
			return _hideWhenIdle;
		}
		set
		{
			if (_hideWhenIdle != value)
			{
				_hideWhenIdle = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public MouseButtonFlags allowedMouseButtons
	{
		get
		{
			return _allowedMouseButtons;
		}
		set
		{
			if (_allowedMouseButtons != value)
			{
				_allowedMouseButtons = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public TransitionTypeFlags transitionType
	{
		get
		{
			return _transitionType;
		}
		set
		{
			if (_transitionType != value)
			{
				_transitionType = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public ColorBlock transitionColorTint
	{
		get
		{
			return _transitionColorTint;
		}
		set
		{
			_transitionColorTint = value;
			vkqeMcpvYrejUrwxCMROyCrCSmcD();
		}
	}

	public SpriteState transitionSpriteState
	{
		get
		{
			return _transitionSpriteState;
		}
		set
		{
			if (!_transitionSpriteState.Equals(value))
			{
				_transitionSpriteState = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public AnimationTriggers transitionAnimationTriggers
	{
		get
		{
			return _transitionAnimationTriggers;
		}
		set
		{
			if (_transitionAnimationTriggers != value)
			{
				_transitionAnimationTriggers = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public Graphic targetGraphic
	{
		get
		{
			return _targetGraphic;
		}
		set
		{
			if (!(_targetGraphic == value))
			{
				_targetGraphic = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public Image image
	{
		get
		{
			return _targetGraphic as Image;
		}
		set
		{
			if (!(_targetGraphic == value))
			{
				_targetGraphic = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public Animator animator => base.gameObject.GetComponent<Animator>();

	public InteractionState interactionState => _interactionState;

	internal static nAyecUrILTBdncCpsxajfiIEYETo.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> RdKRlIBMldwadujEwEVrhtnHXvVd => WhtJpSJvIIqSlgWVcSJaxsaSVimX();

	public event UnityAction<InteractionStateTransitionArgs> InteractionStateSetEvent
	{
		add
		{
			_onInteractionStateTransition.AddListener(value);
		}
		remove
		{
			_onInteractionStateTransition.RemoveListener(value);
		}
	}

	public event UnityAction<bool> VisibilityChangedEvent
	{
		add
		{
			_onVisibilityChanged.AddListener(value);
		}
		remove
		{
			_onVisibilityChanged.RemoveListener(value);
		}
	}

	public event UnityAction InteractionStateChangedToNormal
	{
		add
		{
			_onInteractionStateChangedToNormal.AddListener(value);
		}
		remove
		{
			_onInteractionStateChangedToNormal.RemoveListener(value);
		}
	}

	public event UnityAction InteractionStateChangedToHighlighted
	{
		add
		{
			_onInteractionStateChangedToHighlighted.AddListener(value);
		}
		remove
		{
			_onInteractionStateChangedToHighlighted.RemoveListener(value);
		}
	}

	public event UnityAction InteractionStateChangedToPressed
	{
		add
		{
			_onInteractionStateChangedToPressed.AddListener(value);
		}
		remove
		{
			_onInteractionStateChangedToPressed.RemoveListener(value);
		}
	}

	public event UnityAction InteractionStateChangedToDisabled
	{
		add
		{
			_onInteractionStateChangedToDisabled.AddListener(value);
		}
		remove
		{
			_onInteractionStateChangedToDisabled.RemoveListener(value);
		}
	}

	private nAyecUrILTBdncCpsxajfiIEYETo.HierarchyEventHelper<IVisibilityChangedHandler, bool> NRGdGaxdsawDszrVjmShYZanfzui()
	{
		if (__hierarchyVisibilityChangedHandlers == null)
		{
			__hierarchyVisibilityChangedHandlers = new nAyecUrILTBdncCpsxajfiIEYETo.HierarchyEventHelper<IVisibilityChangedHandler, bool>(BKPVXCPsnIkGhOzTNaVXkZEvEDVH.VvaOTkJkMYtWeIZnJWHBLqkRkstc());
			__hierarchyVisibilityChangedHandlers.GetHandlers(base.transform);
		}
		return __hierarchyVisibilityChangedHandlers;
	}

	private nAyecUrILTBdncCpsxajfiIEYETo.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> PWidLqsoCvANUCdLUdFZKXfgFySE()
	{
		if (__hierarchyInteractionStateTransitionHandlers == null)
		{
			__hierarchyInteractionStateTransitionHandlers = new nAyecUrILTBdncCpsxajfiIEYETo.HierarchyEventHelper<IInteractionStateTransitionHandler, InteractionStateTransitionArgs>(WhtJpSJvIIqSlgWVcSJaxsaSVimX());
			__hierarchyInteractionStateTransitionHandlers.GetHandlers(base.transform);
		}
		return __hierarchyInteractionStateTransitionHandlers;
	}

	[CustomObfuscation(rename = false)]
	internal TouchInteractable()
	{
	}

	[CustomObfuscation(rename = false)]
	internal override void Awake()
	{
		base.Awake();
		if (Application.isPlaying)
		{
			if (_targetGraphic == null)
			{
				_targetGraphic = base.gameObject.GetComponent<Graphic>();
			}
			ZNlDMlkozyFRlAmNyoeHqkzIZJRb();
		}
	}

	[CustomObfuscation(rename = false)]
	internal override void OnCanvasGroupChanged()
	{
		base.OnCanvasGroupChanged();
		bool flag = true;
		Transform parent = base.transform;
		while (parent != null)
		{
			parent.GetComponents(_canvasGroupCache);
			bool flag2 = false;
			for (int i = 0; i < _canvasGroupCache.Count; i++)
			{
				if (!_canvasGroupCache[i].interactable)
				{
					flag = false;
					flag2 = true;
				}
				if (_canvasGroupCache[i].ignoreParentGroups)
				{
					flag2 = true;
				}
			}
			if (flag2)
			{
				break;
			}
			parent = parent.parent;
		}
		if (flag != _groupsAllowInteraction)
		{
			_groupsAllowInteraction = flag;
			QgHnJOzFgImYqbrCcsyCryBRgbkL();
		}
	}

	[CustomObfuscation(rename = false)]
	internal override void OnDidApplyAnimationProperties()
	{
		base.OnDidApplyAnimationProperties();
		QgHnJOzFgImYqbrCcsyCryBRgbkL();
	}

	[CustomObfuscation(rename = false)]
	internal override void OnEnable()
	{
		base.OnEnable();
		if (!Application.isPlaying)
		{
			ZNlDMlkozyFRlAmNyoeHqkzIZJRb();
		}
		KlDYdcRIYcvmKYBDvSkFIsWCgNggA(InteractionState.Normal);
		zFWddvQYvsALSVfHZjgSBQcOQXmxA(true);
	}

	[CustomObfuscation(rename = false)]
	internal override void OnDisable()
	{
		dTgMRAsXfwKiaTGhiImeiiIfnBqd();
		base.OnDisable();
	}

	[CustomObfuscation(rename = false)]
	internal override void OnValidate()
	{
		base.OnValidate();
		_transitionColorTint.fadeDuration = Mathf.Max(_transitionColorTint.fadeDuration, 0f);
		if (oaeJwcBeZoMZRNVcTgpbqRThFymT())
		{
			if (!_interactable && EventSystem.current != null && EventSystem.current.currentSelectedGameObject == base.gameObject)
			{
				EventSystem.current.SetSelectedGameObject(null);
			}
			kvdGyKHvIJQlXFvLgNGOklMFAQgeb(null);
			jygErvHRNITpxvkOvHijQuNXWhDM(Color.white, true);
			OTxBYDslMzCFIPZemyfWnCBWsnHm(_transitionAnimationTriggers.normalTrigger);
			zFWddvQYvsALSVfHZjgSBQcOQXmxA(true);
		}
		GkMGanfgdcdYWodgbFqOFtnwUVUdb();
		QgHnJOzFgImYqbrCcsyCryBRgbkL();
	}

	[CustomObfuscation(rename = false)]
	internal override void Reset()
	{
		_targetGraphic = base.gameObject.GetComponent<Graphic>();
		_allowedMouseButtons = MouseButtonFlags.LeftButton;
		base.Reset();
	}

	internal virtual void rmFjFJDwYKnSzXfJKtFQGPJRpyTq()
	{
		NjnITELCJXnacXZojvszsHYThgOM();
		QgHnJOzFgImYqbrCcsyCryBRgbkL();
	}

	internal virtual void wxXCKHAvKPAIKSbiLofobmeEiwyHA()
	{
		base.KLBZDaJRxBjwjoskHhzNSdorplRS();
		GkMGanfgdcdYWodgbFqOFtnwUVUdb();
	}

	private void dTgMRAsXfwKiaTGhiImeiiIfnBqd()
	{
		string normalTrigger = _transitionAnimationTriggers.normalTrigger;
		CYbIXNEjSCqyHZkKxoLBHgOrNJeQ = false;
		CAhDMgSoccIBttOWNuRutaIMwfjg = false;
		if ((_transitionType & TransitionTypeFlags.ColorTint) != TransitionTypeFlags.None)
		{
			jygErvHRNITpxvkOvHijQuNXWhDM(Color.white, true);
		}
		if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
		{
			kvdGyKHvIJQlXFvLgNGOklMFAQgeb(null);
		}
		if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
		{
			OTxBYDslMzCFIPZemyfWnCBWsnHm(normalTrigger);
		}
	}

	private void ysmJbMqAeaTlWhvCCuYhSLZUEhWI(InteractionState P_0, bool P_1)
	{
		Color color;
		Sprite sprite;
		string text;
		UnityEvent unityEvent;
		switch (P_0)
		{
		case InteractionState.Normal:
			color = _transitionColorTint.normalColor;
			sprite = null;
			text = _transitionAnimationTriggers.normalTrigger;
			unityEvent = _onInteractionStateChangedToNormal;
			break;
		case InteractionState.Highlighted:
			color = _transitionColorTint.highlightedColor;
			sprite = _transitionSpriteState.highlightedSprite;
			text = _transitionAnimationTriggers.highlightedTrigger;
			unityEvent = _onInteractionStateChangedToHighlighted;
			break;
		case InteractionState.Pressed:
			color = _transitionColorTint.pressedColor;
			sprite = _transitionSpriteState.pressedSprite;
			text = _transitionAnimationTriggers.pressedTrigger;
			unityEvent = _onInteractionStateChangedToPressed;
			break;
		case InteractionState.Disabled:
			color = _transitionColorTint.disabledColor;
			sprite = _transitionSpriteState.disabledSprite;
			text = _transitionAnimationTriggers.disabledTrigger;
			unityEvent = _onInteractionStateChangedToDisabled;
			break;
		default:
			color = Color.black;
			sprite = null;
			text = string.Empty;
			unityEvent = null;
			break;
		}
		bool flag = (_transitionType & TransitionTypeFlags.ColorTint) != 0;
		if (!flag)
		{
			color = Color.white;
		}
		if (!_visible)
		{
			color.a = 0f;
		}
		if (base.gameObject.activeInHierarchy)
		{
			if (flag)
			{
				jygErvHRNITpxvkOvHijQuNXWhDM(color * _transitionColorTint.colorMultiplier, P_1);
			}
			else
			{
				jygErvHRNITpxvkOvHijQuNXWhDM(color, P_1);
			}
			if ((_transitionType & TransitionTypeFlags.SpriteSwap) != TransitionTypeFlags.None)
			{
				kvdGyKHvIJQlXFvLgNGOklMFAQgeb(sprite);
			}
			if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None)
			{
				OTxBYDslMzCFIPZemyfWnCBWsnHm(text);
			}
		}
		if (_allowSendingEvents)
		{
			_transitionArgs.NBEdYTfjtRocMsQzKCoNJHpUhuaB(this, P_0, P_1 ? 0f : _transitionColorTint.fadeDuration);
			PWidLqsoCvANUCdLUdFZKXfgFySE().ExecuteOnAll(_transitionArgs);
			if (_onInteractionStateTransition != null)
			{
				_onInteractionStateTransition.Invoke(_transitionArgs);
			}
			unityEvent?.Invoke();
		}
	}

	private void jygErvHRNITpxvkOvHijQuNXWhDM(Color P_0, bool P_1)
	{
		if (!(_targetGraphic == null))
		{
			_targetGraphic.CrossFadeColor(P_0, P_1 ? 0f : _transitionColorTint.fadeDuration, ignoreTimeScale: true, useAlpha: true);
		}
	}

	private void kvdGyKHvIJQlXFvLgNGOklMFAQgeb(Sprite P_0)
	{
		if (!(image == null))
		{
			image.overrideSprite = P_0;
		}
	}

	private void OTxBYDslMzCFIPZemyfWnCBWsnHm(string P_0)
	{
		if ((_transitionType & TransitionTypeFlags.Animation) != TransitionTypeFlags.None && !(animator == null) && UnityTools.IsActiveAndEnabled(animator) && !(animator.runtimeAnimatorController == null) && !string.IsNullOrEmpty(P_0))
		{
			animator.ResetTrigger(_transitionAnimationTriggers.normalTrigger);
			animator.ResetTrigger(_transitionAnimationTriggers.pressedTrigger);
			animator.ResetTrigger(_transitionAnimationTriggers.highlightedTrigger);
			animator.ResetTrigger(_transitionAnimationTriggers.disabledTrigger);
			animator.SetTrigger(P_0);
		}
	}

	private void zFWddvQYvsALSVfHZjgSBQcOQXmxA(bool P_0)
	{
		InteractionState interactionState = _interactionState;
		if (oaeJwcBeZoMZRNVcTgpbqRThFymT() && !IsInteractable())
		{
			interactionState = InteractionState.Disabled;
		}
		ysmJbMqAeaTlWhvCCuYhSLZUEhWI(interactionState, P_0);
	}

	public bool IsInteractable()
	{
		if (_groupsAllowInteraction)
		{
			return _interactable;
		}
		return false;
	}

	internal virtual bool uHAUleplbkeTtyPlphyfcqaKBGWkA()
	{
		if (!oaeJwcBeZoMZRNVcTgpbqRThFymT())
		{
			return false;
		}
		if (CYbIXNEjSCqyHZkKxoLBHgOrNJeQ)
		{
			return CAhDMgSoccIBttOWNuRutaIMwfjg;
		}
		return false;
	}

	internal void RZTNnKQoSmcdIfEdAoLXuuCuLVZf(BaseEventData P_0)
	{
		if (oaeJwcBeZoMZRNVcTgpbqRThFymT() && IsInteractable())
		{
			InteractionState interactionState = tVCLiPcuyhVgbIlepnustALmxuLb(P_0);
			if (interactionState != _interactionState)
			{
				KlDYdcRIYcvmKYBDvSkFIsWCgNggA(interactionState);
				zFWddvQYvsALSVfHZjgSBQcOQXmxA(false);
			}
		}
	}

	internal virtual bool MrKmabmcAESoxqBxPxIwSpBzktEh(GameObject P_0)
	{
		return base.gameObject == P_0;
	}

	private bool BopVpSkJLWVWGyVyDSyyxGYSnjLV(BaseEventData P_0)
	{
		bool flag = P_0 is PointerEventData;
		return lSxBaxRKyCojdMrmjtuWqnQpQIFW(flag, flag ? (P_0 as PointerEventData).pointerPress : null);
	}

	private bool lSxBaxRKyCojdMrmjtuWqnQpQIFW(bool P_0, GameObject P_1)
	{
		if (!oaeJwcBeZoMZRNVcTgpbqRThFymT())
		{
			return false;
		}
		if (uHAUleplbkeTtyPlphyfcqaKBGWkA())
		{
			return false;
		}
		bool flag = false;
		if (P_0)
		{
			return flag | ((CAhDMgSoccIBttOWNuRutaIMwfjg && !CYbIXNEjSCqyHZkKxoLBHgOrNJeQ && MrKmabmcAESoxqBxPxIwSpBzktEh(P_1)) || (!CAhDMgSoccIBttOWNuRutaIMwfjg && CYbIXNEjSCqyHZkKxoLBHgOrNJeQ && MrKmabmcAESoxqBxPxIwSpBzktEh(P_1)) || (!CAhDMgSoccIBttOWNuRutaIMwfjg && CYbIXNEjSCqyHZkKxoLBHgOrNJeQ && P_1 == null));
		}
		return flag | CYbIXNEjSCqyHZkKxoLBHgOrNJeQ;
	}

	private InteractionState tVCLiPcuyhVgbIlepnustALmxuLb(BaseEventData P_0)
	{
		if (uHAUleplbkeTtyPlphyfcqaKBGWkA())
		{
			return InteractionState.Pressed;
		}
		if (BopVpSkJLWVWGyVyDSyyxGYSnjLV(P_0))
		{
			return InteractionState.Highlighted;
		}
		return InteractionState.Normal;
	}

	private bool KlDYdcRIYcvmKYBDvSkFIsWCgNggA(InteractionState P_0)
	{
		if (_interactionState == P_0)
		{
			return false;
		}
		_interactionState = P_0;
		yHVrHxvREZReGTUSFnCKaYuLsSmv();
		return true;
	}

	private void yHVrHxvREZReGTUSFnCKaYuLsSmv()
	{
		UHAXYiwljIIGphPbErtRFHShNJfp();
	}

	private void UHAXYiwljIIGphPbErtRFHShNJfp()
	{
		if (Application.isPlaying && _hideWhenIdle)
		{
			RyWDISUhTXmyeeBspuhOZRZxHQMe(_interactionState == InteractionState.Pressed, false);
		}
	}

	private void RyWDISUhTXmyeeBspuhOZRZxHQMe(bool P_0, bool P_1)
	{
		if (_visible == P_0 && !P_1)
		{
			return;
		}
		_visible = P_0;
		_varWatch_visible = P_0;
		if (_allowSendingEvents)
		{
			NRGdGaxdsawDszrVjmShYZanfzui().ExecuteOnAll(P_0);
			if (_onVisibilityChanged != null)
			{
				_onVisibilityChanged.Invoke(P_0);
			}
		}
	}

	private void ZNlDMlkozyFRlAmNyoeHqkzIZJRb()
	{
		_varWatch_visible = _visible;
		_varWatch_interactable = IsInteractable();
		using (new SetAndRestoreVar<bool>(_allowSendingEvents, false, (bool P_0) =>
		{
			_allowSendingEvents = P_0;
		}))
		{
			RyWDISUhTXmyeeBspuhOZRZxHQMe(_visible, true);
			UHAXYiwljIIGphPbErtRFHShNJfp();
		}
		GkMGanfgdcdYWodgbFqOFtnwUVUdb();
		if (_allowSendingEvents)
		{
			NRGdGaxdsawDszrVjmShYZanfzui().ExecuteOnAll(_visible);
			if (_onVisibilityChanged != null)
			{
				_onVisibilityChanged.Invoke(_visible);
			}
		}
	}

	private void bvzfhikEWAMGlRpQtrDbUcJaFmUXA()
	{
		if (_varWatch_visible != _visible)
		{
			_varWatch_visible = _visible;
			if (_allowSendingEvents && _onVisibilityChanged != null)
			{
				NRGdGaxdsawDszrVjmShYZanfzui().ExecuteOnAll(_visible);
				_onVisibilityChanged.Invoke(_visible);
			}
		}
	}

	private void QgHnJOzFgImYqbrCcsyCryBRgbkL()
	{
		bvzfhikEWAMGlRpQtrDbUcJaFmUXA();
		UHAXYiwljIIGphPbErtRFHShNJfp();
		if (!Application.isPlaying)
		{
			zFWddvQYvsALSVfHZjgSBQcOQXmxA(true);
		}
		else
		{
			zFWddvQYvsALSVfHZjgSBQcOQXmxA(false);
		}
	}

	private void GkMGanfgdcdYWodgbFqOFtnwUVUdb()
	{
		NRGdGaxdsawDszrVjmShYZanfzui().GetHandlers(base.transform);
		PWidLqsoCvANUCdLUdFZKXfgFySE().GetHandlers(base.transform);
	}

	internal virtual void OnPointerDown(PointerEventData eventData)
	{
		if (otiaXVprkhnoYNaDsyXwRDXmfaMhA(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerDown))
		{
			CAhDMgSoccIBttOWNuRutaIMwfjg = true;
			RZTNnKQoSmcdIfEdAoLXuuCuLVZf(eventData);
		}
	}

	internal virtual void OnPointerUp(PointerEventData eventData)
	{
		if (otiaXVprkhnoYNaDsyXwRDXmfaMhA(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerUp))
		{
			CAhDMgSoccIBttOWNuRutaIMwfjg = false;
			RZTNnKQoSmcdIfEdAoLXuuCuLVZf(eventData);
		}
	}

	internal virtual void OnPointerEnter(PointerEventData eventData)
	{
		if (otiaXVprkhnoYNaDsyXwRDXmfaMhA(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerEnter))
		{
			CYbIXNEjSCqyHZkKxoLBHgOrNJeQ = true;
			RZTNnKQoSmcdIfEdAoLXuuCuLVZf(eventData);
		}
	}

	internal virtual void OnPointerExit(PointerEventData eventData)
	{
		if (otiaXVprkhnoYNaDsyXwRDXmfaMhA(eventData.pointerId, _allowedMouseButtons, EventTriggerType.PointerExit))
		{
			CYbIXNEjSCqyHZkKxoLBHgOrNJeQ = false;
			RZTNnKQoSmcdIfEdAoLXuuCuLVZf(eventData);
		}
	}

	internal virtual void OnBeginDrag(PointerEventData eventData)
	{
		otiaXVprkhnoYNaDsyXwRDXmfaMhA(eventData.pointerId, _allowedMouseButtons, EventTriggerType.BeginDrag);
	}

	internal virtual void OnDrag(PointerEventData eventData)
	{
		otiaXVprkhnoYNaDsyXwRDXmfaMhA(eventData.pointerId, _allowedMouseButtons, EventTriggerType.Drag);
	}

	internal virtual void OnEndDrag(PointerEventData eventData)
	{
		otiaXVprkhnoYNaDsyXwRDXmfaMhA(eventData.pointerId, _allowedMouseButtons, EventTriggerType.EndDrag);
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		OnPointerDown(eventData);
	}

	void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
	{
		OnPointerUp(eventData);
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		OnPointerEnter(eventData);
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		OnPointerExit(eventData);
	}

	void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
	{
		OnBeginDrag(eventData);
	}

	void IDragHandler.OnDrag(PointerEventData eventData)
	{
		OnDrag(eventData);
	}

	void IEndDragHandler.OnEndDrag(PointerEventData eventData)
	{
		OnEndDrag(eventData);
	}

	internal static bool mRSYcsbbLGividPxxIsAwIGOQExrA(int P_0)
	{
		if (P_0 == int.MinValue)
		{
			return false;
		}
		if (taBoSkdUnCIFwXCeRCiuDjheGucHA(P_0))
		{
			int num = dpMiNaohktsigzPcxOePamowChEIA(P_0);
			if (num < 0)
			{
				return false;
			}
			Touch touch = Input.GetTouch(num);
			if (touch.phase != TouchPhase.Ended)
			{
				return touch.phase != TouchPhase.Canceled;
			}
			return false;
		}
		if (WXkxrLAoqcWTDUeJjBzBHrqWDPEHb(P_0) && Input.mousePresent)
		{
			int num2 = cpRMNLSjblAHcxtKcBLenDKbHTXHA(P_0);
			if (num2 >= 0)
			{
				return Input.GetMouseButton(num2);
			}
		}
		return false;
	}

	internal static Vector3 fSFFIqPCdTfnlcWytKtjAqgwwIbE(int P_0)
	{
		if (taBoSkdUnCIFwXCeRCiuDjheGucHA(P_0))
		{
			int num = dpMiNaohktsigzPcxOePamowChEIA(P_0);
			if (num >= 0 && Input.touchCount > num)
			{
				return Input.touches[num].position;
			}
		}
		else if (WXkxrLAoqcWTDUeJjBzBHrqWDPEHb(P_0) && Input.mousePresent)
		{
			return Input.mousePosition;
		}
		return Vector3.zero;
	}

	internal static bool taBoSkdUnCIFwXCeRCiuDjheGucHA(int P_0)
	{
		return P_0 >= 0;
	}

	internal static bool WXkxrLAoqcWTDUeJjBzBHrqWDPEHb(int P_0)
	{
		if (P_0 != -1 && P_0 != -3)
		{
			return P_0 == -2;
		}
		return true;
	}

	private static int dpMiNaohktsigzPcxOePamowChEIA(int P_0)
	{
		if (!taBoSkdUnCIFwXCeRCiuDjheGucHA(P_0))
		{
			return -1;
		}
		int touchCount = Input.touchCount;
		for (int i = 0; i < touchCount; i++)
		{
			if (Input.GetTouch(i).fingerId == P_0)
			{
				return i;
			}
		}
		return -1;
	}

	internal static bool wSqWLAZrZjugxohuwwtLrJJlOhED(MouseButtonFlags P_0, int P_1)
	{
		if (WXkxrLAoqcWTDUeJjBzBHrqWDPEHb(P_1))
		{
			if (!Cursor.visible)
			{
				return false;
			}
			if (!Input.mousePresent)
			{
				return false;
			}
		}
		if (taBoSkdUnCIFwXCeRCiuDjheGucHA(P_1))
		{
			return true;
		}
		if (QHCqxOnoxcueyqlzwnlJjwLxsieQ(P_0, P_1))
		{
			return true;
		}
		return false;
	}

	private static bool QHCqxOnoxcueyqlzwnlJjwLxsieQ(MouseButtonFlags P_0, int P_1)
	{
		return P_1 switch
		{
			-1 => (P_0 & MouseButtonFlags.LeftButton) != 0, 
			-2 => (P_0 & MouseButtonFlags.RightButton) != 0, 
			-3 => (P_0 & MouseButtonFlags.MiddleButton) != 0, 
			_ => false, 
		};
	}

	private static int cpRMNLSjblAHcxtKcBLenDKbHTXHA(int P_0)
	{
		if (!WXkxrLAoqcWTDUeJjBzBHrqWDPEHb(P_0))
		{
			return -1;
		}
		return P_0 switch
		{
			-1 => 0, 
			-2 => 1, 
			-3 => 2, 
			_ => -1, 
		};
	}

	internal static bool VAGTerhsNSvfwApYSuTWzWHLTYoN(MouseButtonFlags P_0, out int P_1)
	{
		for (int i = 0; i < 3; i++)
		{
			if (((uint)P_0 & (uint)(1 << i)) != 0 && Input.GetMouseButton(i))
			{
				P_1 = (i + 1) * -1;
				return true;
			}
		}
		P_1 = int.MinValue;
		return false;
	}

	internal static bool otiaXVprkhnoYNaDsyXwRDXmfaMhA(int P_0, MouseButtonFlags P_1, EventTriggerType P_2)
	{
		if (WXkxrLAoqcWTDUeJjBzBHrqWDPEHb(P_0) && (P_2 == EventTriggerType.PointerEnter || P_2 == EventTriggerType.PointerExit) && P_1 != MouseButtonFlags.None)
		{
			P_1 |= MouseButtonFlags.LeftButton;
		}
		return wSqWLAZrZjugxohuwwtLrJJlOhED(P_1, P_0);
	}

	internal static bool KOQRODyedkzAWhLBQerzLuXVDEwq(MouseButtonFlags P_0)
	{
		int num;
		return VAGTerhsNSvfwApYSuTWzWHLTYoN(P_0, out num);
	}

	internal static nAyecUrILTBdncCpsxajfiIEYETo.EventFunction<IInteractionStateTransitionHandler, InteractionStateTransitionArgs> WhtJpSJvIIqSlgWVcSJaxsaSVimX()
	{
		if (__interactionStateTransitionHandlerDelegate == null)
		{
			__interactionStateTransitionHandlerDelegate = sbqLZCsbjaHCcyeFnazWxQwSjuRo._003C_003E9.SJLbOIJVttjijdFVJKXnMOmpPeJrA;
		}
		return __interactionStateTransitionHandlerDelegate;
	}

	[CompilerGenerated]
	private void fMVPGNQFPfdUFGyDSMHAIJDBDXidb(bool P_0)
	{
		_allowSendingEvents = P_0;
	}
}
