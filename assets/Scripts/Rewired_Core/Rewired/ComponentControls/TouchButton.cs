using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.ComponentControls.Data;
using Rewired.Internal;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rewired.ComponentControls;

[Serializable]
[DisallowMultipleComponent]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[AddComponentMenu("Rewired/Touch Controls/Touch Button")]
public sealed class TouchButton : TouchInteractable
{
	public enum ButtonType
	{
		Standard = 0,
		ToggleSwitch = 1
	}

	private enum MvIcqNAoAuzpaUeLdvXdawySsjtTA
	{
		None = 0,
		TowardTouch = 1,
		TowardHome = 2
	}

	private enum KoKdNThSRpjZqvUDkRiYgbHNgHviA
	{
		Local = 0,
		TouchRegion = 1
	}

	[Serializable]
	public class AxisValueChangedEventHandler : UnityEvent<float>
	{
	}

	[Serializable]
	public class ButtonValueChangedEventHandler : UnityEvent<bool>
	{
	}

	[Serializable]
	public class ButtonDownEventHandler : UnityEvent
	{
	}

	[Serializable]
	public class ButtonUpEventHandler : UnityEvent
	{
	}

	private sealed class IeURYPZQrlqYJRaZoFJkKmLhYsPz : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int UhzyMdFDjOWHhXZYseKPYQSEqgSw;

		private object uNEHPWpSYWpaGTkKrHHrwswkEsod;

		public float vLqNhndajEQthKAzFdJiDgJYeEmh;

		public TouchButton mzPYGJDuURdgRWbzgXYwBiTfpCWO;

		public PositionType mrGJRuAdsHLHkixOWkPCAgPsiwhU;

		public Vector2 qIxEAQeteQoIPkWWUMvKGIVwOanc;

		public MvIcqNAoAuzpaUeLdvXdawySsjtTA XjTONMwDjGWnpDqekBypBSEafICy;

		private RectTransform ypMaCYfYMUpfdRuqTpisYfSVVLaw;

		private Vector2 EGGpLaXioDdFydnCjvamNhPKetGC;

		private float evhOslwBPabGYfKpxrhebWRauflJA;

		private float tKeDLaqjJRovtQXAavtjfwWAsnPk;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return uNEHPWpSYWpaGTkKrHHrwswkEsod;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return uNEHPWpSYWpaGTkKrHHrwswkEsod;
			}
		}

		[DebuggerHidden]
		public IeURYPZQrlqYJRaZoFJkKmLhYsPz(int P_0)
		{
			UhzyMdFDjOWHhXZYseKPYQSEqgSw = P_0;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int uhzyMdFDjOWHhXZYseKPYQSEqgSw = UhzyMdFDjOWHhXZYseKPYQSEqgSw;
			TouchButton touchButton = mzPYGJDuURdgRWbzgXYwBiTfpCWO;
			if (uhzyMdFDjOWHhXZYseKPYQSEqgSw != 0)
			{
				if (uhzyMdFDjOWHhXZYseKPYQSEqgSw != 1)
				{
					return false;
				}
				UhzyMdFDjOWHhXZYseKPYQSEqgSw = -1;
				goto IL_010c;
			}
			UhzyMdFDjOWHhXZYseKPYQSEqgSw = -1;
			if (!(vLqNhndajEQthKAzFdJiDgJYeEmh <= 0f))
			{
				ypMaCYfYMUpfdRuqTpisYfSVVLaw = touchButton.kJMTokSRJfFCvJTzvbFYrXMRhvEn();
				EGGpLaXioDdFydnCjvamNhPKetGC = wbMBRTDcWhifYEiuPKvXmWDTvFpu.rGaDMSSCdJYvvTbfrvDkcBaOopdW(ypMaCYfYMUpfdRuqTpisYfSVVLaw, mrGJRuAdsHLHkixOWkPCAgPsiwhU);
				float magnitude = (qIxEAQeteQoIPkWWUMvKGIVwOanc - EGGpLaXioDdFydnCjvamNhPKetGC).magnitude;
				if (!(magnitude < 0.01f))
				{
					touchButton.bxhOYXVosvvqAMOpnMgARLJRIoTe = true;
					evhOslwBPabGYfKpxrhebWRauflJA = magnitude / vLqNhndajEQthKAzFdJiDgJYeEmh;
					tKeDLaqjJRovtQXAavtjfwWAsnPk = 0f;
					goto IL_010c;
				}
			}
			goto IL_0119;
			IL_0119:
			touchButton.OFtFmptuiQWbcULqlMMjWjDuBryGA(XjTONMwDjGWnpDqekBypBSEafICy, qIxEAQeteQoIPkWWUMvKGIVwOanc, mrGJRuAdsHLHkixOWkPCAgPsiwhU);
			return false;
			IL_010c:
			if (tKeDLaqjJRovtQXAavtjfwWAsnPk <= 1f)
			{
				tKeDLaqjJRovtQXAavtjfwWAsnPk += Time.unscaledDeltaTime / evhOslwBPabGYfKpxrhebWRauflJA;
				wbMBRTDcWhifYEiuPKvXmWDTvFpu.yaNeOifnmoVsOaBmHgYqgMJiZRxc(ypMaCYfYMUpfdRuqTpisYfSVVLaw, Vector2.Lerp(EGGpLaXioDdFydnCjvamNhPKetGC, qIxEAQeteQoIPkWWUMvKGIVwOanc, Mathf.SmoothStep(0f, 1f, tKeDLaqjJRovtQXAavtjfwWAsnPk)), mrGJRuAdsHLHkixOWkPCAgPsiwhU);
				uNEHPWpSYWpaGTkKrHHrwswkEsod = null;
				UhzyMdFDjOWHhXZYseKPYQSEqgSw = 1;
				return true;
			}
			goto IL_0119;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private const float RUbfEbjieWxtcIYfllVvOOpOPOOC = 20f;

	[Tooltip("The Custom Controller element that will receive input values from this control.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private CustomControllerElementTargetSetForFloat _targetCustomControllerElement = new CustomControllerElementTargetSetForFloat(new CustomControllerElementTarget(new CustomControllerElementSelector
	{
		elementType = CustomControllerElementSelector.ElementType.Button
	}));

	[Tooltip("The type of button.\nStandard: A momentary switch. Returns True while the button is pressed down.\nToggle Switch: Alternately turns on and off with each press.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private ButtonType _buttonType;

	[Tooltip("If true, the button can be turned on by a touch swipe that began in an area outside the button region. If false, the button can only be turned on by a direct press.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _activateOnSwipeIn;

	[Tooltip("If true, the button will stay on even if the touch that activated it moves outside the button region. If false, the button will turn off once the touch that activated it moves outside the button region.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _stayActiveOnSwipeOut = true;

	[Tooltip("Makes the axis value gradually change over time based on gravity and sensitivity as the button is pressed.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _useDigitalAxisSimulation;

	[Tooltip("Speed (units/sec) that the axis value falls toward 0 when not pressed. A value of 1.0 means an axis value of 1 will drain to 0 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	[FieldRange(0f, float.PositiveInfinity)]
	private float _digitalAxisGravity = 3f;

	[Tooltip("Speed to move toward an axis value of 1.0 in units/sec when pressed. A value of 1.0 means an axis value of 0 will reach 1 over 1 second. A value of 3 equates to 1/3 of a second, and so on.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	[FieldRange(0f, float.PositiveInfinity)]
	private float _digitalAxisSensitivity = 3f;

	[Tooltip("The internal axis of the button. The axis is used for all value calculations.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private StandaloneAxis _axis = new StandaloneAxis();

	[Tooltip("Optional external region to use for hover/click/touch detection. If set, this region will be used for touch detection instead of or in addition to the button's RectTransform. This can be useful if you want a larger area of the screen to act as a button.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private TouchRegion _touchRegion;

	[Tooltip("If True, hovers/clicks/touches on the local button will be ignored and only Touch Region touches will be used. Otherwise, both touches on the button and on the Touch Region will be used. This also applies to mouse hover. This setting has no effect if no Touch Region is set.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _useTouchRegionOnly = true;

	[Tooltip("If True, the button will move to the location of the current touch in the Touch Region. This can be used to designate an area of the screen as a hot-spot for a button and have the button graphics follow the users touches. This only has an effect if a Touch Region is set.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _moveToTouchPosition;

	[Tooltip("If Move To Touch Position is enabled, this will make the button return to its original position after the press is released. This only has an effect if a Touch Region is set.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _returnOnRelease = true;

	[Tooltip("If True, the button will follow the touch around until released. This setting overrides Move To Touch Position.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _followTouchPosition;

	[Tooltip("Should the button animate when moving to the touch point? This only has an effect if Move To Touch Position is True and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _animateOnMoveToTouch = true;

	[Tooltip("The speed at which the button will move toward the touch position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Move To Touch Position is True, Animate On Move To Touch is true, and a Touch Region is set. This setting is ignored if Follow Touch Position is True.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Range(0f, 20f)]
	private float _moveToTouchSpeed = 2f;

	[Tooltip("Should the button animate when moving back to its original position? This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release is True.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _animateOnReturn = true;

	[Tooltip("The speed at which the button will move back toward its original position measured in screens per second (based on the larger of width and height). [1.0 = Move 1 screen/sec]. This only has an effect if Follow Touch Position is True, or if Move To Touch Position is True and a Touch Region is set, and Return on Release and Animate on Return are both True.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	[Range(0f, 20f)]
	private float _returnSpeed = 2f;

	[Tooltip("If True, it will attempt to automatically manage Graphic component raycasting for best results based on your current settings.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _manageRaycasting = true;

	private float XfqUHJABuWdPWUSOwwnRWNqnsWbQ;

	private float SyzfmCguVFvqtDaQsirfFjmIfwFC;

	private TouchRegion oFEYnkRhpQVFEtEVyAuFijiMMedjb;

	private Vector2 iGxxmADCWdLXaIuXgtTYbTrpaUNg;

	private bool bxhOYXVosvvqAMOpnMgARLJRIoTe;

	private bool LZiYLwtmBSuJprBbRHFQjcDQjpQfA;

	private MvIcqNAoAuzpaUeLdvXdawySsjtTA RWpDfQrgZedozPqFmTwyDgrqmeit;

	private int OAtpSggWiVdqwlApjqfNaWiVfgkp = int.MinValue;

	private int dbxwpmvwNsbfvDhEtjlhWMBhXHrF = int.MinValue;

	[NonSerialized]
	private bool zONOBcTjnJhlYDLKAqTfyCjuvoXdA;

	[NonSerialized]
	private bool RnIAfIHDxmdKaAyDsbWmDMoGZqnyA;

	private IEnumerator ksWorNLgqAEqcJRPNTjkeQVjGiD;

	private gKahgoUyGUFMoHdupCKpyrbypxbO CrxVUBIZrcuCOQzwOUKwzRUPWqod = new gKahgoUyGUFMoHdupCKpyrbypxbO();

	private Action<MvIcqNAoAuzpaUeLdvXdawySsjtTA> vqccybhcrZKTTpLHxQGkbfhuITwCA;

	private Action<MvIcqNAoAuzpaUeLdvXdawySsjtTA> nIHxbxFsAVjBdEciYfyVHVdtyQEy;

	[Tooltip("Event sent when the axis value changes.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private AxisValueChangedEventHandler _onAxisValueChanged = new AxisValueChangedEventHandler();

	[Tooltip("Event sent when the button value changes.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private ButtonValueChangedEventHandler _onButtonValueChanged = new ButtonValueChangedEventHandler();

	[Tooltip("Event sent when the button is pressed.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private ButtonDownEventHandler _onButtonDown = new ButtonDownEventHandler();

	[Tooltip("Event sent when the button is released.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private ButtonUpEventHandler _onButtonUp = new ButtonUpEventHandler();

	private Dictionary<int, PointerEventData> UKWEzEbWKrpHqnivAeAYeXPdqLlS;

	public CustomControllerElementTargetSetForFloat targetCustomControllerElement => _targetCustomControllerElement;

	public ButtonType buttonType
	{
		get
		{
			return _buttonType;
		}
		set
		{
			if (_buttonType != value)
			{
				_buttonType = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public bool activateOnSwipeIn
	{
		get
		{
			return _activateOnSwipeIn;
		}
		set
		{
			if (_activateOnSwipeIn != value)
			{
				_activateOnSwipeIn = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public bool stayActiveOnSwipeOut
	{
		get
		{
			if (ulqsmOwvmuIOhUpbPRQELGaNCRMC())
			{
				return true;
			}
			return _stayActiveOnSwipeOut;
		}
		set
		{
			if (_stayActiveOnSwipeOut != value)
			{
				_stayActiveOnSwipeOut = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public bool useDigitalAxisSimulation
	{
		get
		{
			return _useDigitalAxisSimulation;
		}
		set
		{
			if (_useDigitalAxisSimulation != value)
			{
				_useDigitalAxisSimulation = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public float digitalAxisGravity
	{
		get
		{
			return _digitalAxisGravity;
		}
		set
		{
			if (_digitalAxisGravity != value)
			{
				_digitalAxisGravity = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public float digitalAxisSensitivity
	{
		get
		{
			return _digitalAxisSensitivity;
		}
		set
		{
			if (_digitalAxisSensitivity != value)
			{
				_digitalAxisSensitivity = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public TouchRegion touchRegion
	{
		get
		{
			return _touchRegion;
		}
		set
		{
			if (!(_touchRegion == value))
			{
				_touchRegion = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public bool useTouchRegionOnly
	{
		get
		{
			return _useTouchRegionOnly;
		}
		set
		{
			if (_useTouchRegionOnly != value)
			{
				_useTouchRegionOnly = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public bool moveToTouchPosition
	{
		get
		{
			return _moveToTouchPosition;
		}
		set
		{
			if (_moveToTouchPosition != value)
			{
				_moveToTouchPosition = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public bool returnOnRelease
	{
		get
		{
			return _returnOnRelease;
		}
		set
		{
			if (_returnOnRelease != value)
			{
				_returnOnRelease = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public bool followTouchPosition
	{
		get
		{
			return _followTouchPosition;
		}
		set
		{
			if (_followTouchPosition != value)
			{
				_followTouchPosition = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public bool animateOnMoveToTouch
	{
		get
		{
			return _animateOnMoveToTouch;
		}
		set
		{
			if (_animateOnMoveToTouch != value)
			{
				_animateOnMoveToTouch = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public float moveToTouchSpeed
	{
		get
		{
			return _moveToTouchSpeed;
		}
		set
		{
			value = MathTools.Clamp(value, 0f, 20f);
			if (_moveToTouchSpeed != value)
			{
				_moveToTouchSpeed = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public bool animateOnReturn
	{
		get
		{
			return _animateOnReturn;
		}
		set
		{
			if (_animateOnReturn != value)
			{
				_animateOnReturn = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public float returnSpeed
	{
		get
		{
			return _returnSpeed;
		}
		set
		{
			value = MathTools.Clamp(value, 0f, 20f);
			if (_returnSpeed != value)
			{
				_returnSpeed = value;
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public bool manageRaycasting
	{
		get
		{
			return _manageRaycasting;
		}
		set
		{
			if (_manageRaycasting != value)
			{
				_manageRaycasting = value;
				if (value)
				{
					eRKmmqrkFUNgMAGQmCSKrkwvhwk();
				}
				else
				{
					CrxVUBIZrcuCOQzwOUKwzRUPWqod.ylsfmpHjfEYWwRkBDCpgaEeOLhpw();
				}
				vkqeMcpvYrejUrwxCMROyCrCSmcD();
			}
		}
	}

	public int pointerId
	{
		get
		{
			return OAtpSggWiVdqwlApjqfNaWiVfgkp;
		}
		set
		{
			OAtpSggWiVdqwlApjqfNaWiVfgkp = value;
		}
	}

	public bool hasPointer => OAtpSggWiVdqwlApjqfNaWiVfgkp != int.MinValue;

	internal StandaloneAxis axis => _axis;

	private Action<MvIcqNAoAuzpaUeLdvXdawySsjtTA> moveStartedDelegate => kydeRKCcmzQnnassANDheZUgGFZO();

	private Action<MvIcqNAoAuzpaUeLdvXdawySsjtTA> moveEndedDelegate => mrZfQAqjvGOCwyMruJbCUGjAJHlDA();

	private float axisValue => XUMHHcxIvvNqyJMrhOveIcplEdLs();

	private float axisValuePrev => sQGvhOjRMviJIlKewFNjszVquDxU();

	private bool buttonValue => ToDOPOHUUOXKMBEzPmGhJgSlSLgc();

	private bool buttonValuePrev => klodnsbnMkOQFTotFDxtdXCnSuSY();

	private int effectivePointerId => YQFzafkYxcmQYFBqmfUKLTSfsrky();

	public event UnityAction<float> AxisValueChangedEvent
	{
		add
		{
			_onAxisValueChanged.AddListener(value);
		}
		remove
		{
			_onAxisValueChanged.RemoveListener(value);
		}
	}

	public event UnityAction<bool> ButtonValueChangedEvent
	{
		add
		{
			_onButtonValueChanged.AddListener(value);
		}
		remove
		{
			_onButtonValueChanged.RemoveListener(value);
		}
	}

	public event UnityAction ButtonDownEvent
	{
		add
		{
			_onButtonDown.AddListener(value);
		}
		remove
		{
			_onButtonDown.RemoveListener(value);
		}
	}

	public event UnityAction ButtonUpEvent
	{
		add
		{
			_onButtonUp.AddListener(value);
		}
		remove
		{
			_onButtonUp.RemoveListener(value);
		}
	}

	private Action<MvIcqNAoAuzpaUeLdvXdawySsjtTA> kydeRKCcmzQnnassANDheZUgGFZO()
	{
		if (vqccybhcrZKTTpLHxQGkbfhuITwCA == null)
		{
			return vqccybhcrZKTTpLHxQGkbfhuITwCA = zgLrVDMJPmswJsBRjKCAvwbkfwBT;
		}
		return vqccybhcrZKTTpLHxQGkbfhuITwCA;
	}

	private Action<MvIcqNAoAuzpaUeLdvXdawySsjtTA> mrZfQAqjvGOCwyMruJbCUGjAJHlDA()
	{
		if (nIHxbxFsAVjBdEciYfyVHVdtyQEy == null)
		{
			return nIHxbxFsAVjBdEciYfyVHVdtyQEy = jzcgVVdUbfhafYRmdFewhaukADpxB;
		}
		return nIHxbxFsAVjBdEciYfyVHVdtyQEy;
	}

	private float XUMHHcxIvvNqyJMrhOveIcplEdLs()
	{
		if (!_useDigitalAxisSimulation)
		{
			return _axis.value;
		}
		return XfqUHJABuWdPWUSOwwnRWNqnsWbQ;
	}

	private float sQGvhOjRMviJIlKewFNjszVquDxU()
	{
		if (!_useDigitalAxisSimulation)
		{
			return _axis.valuePrev;
		}
		return SyzfmCguVFvqtDaQsirfFjmIfwFC;
	}

	private bool ToDOPOHUUOXKMBEzPmGhJgSlSLgc()
	{
		return _axis.buttonValue;
	}

	private bool klodnsbnMkOQFTotFDxtdXCnSuSY()
	{
		return _axis.buttonValuePrev;
	}

	private int YQFzafkYxcmQYFBqmfUKLTSfsrky()
	{
		if (OAtpSggWiVdqwlApjqfNaWiVfgkp == int.MinValue)
		{
			return int.MinValue;
		}
		if (dbxwpmvwNsbfvDhEtjlhWMBhXHrF != int.MinValue)
		{
			return dbxwpmvwNsbfvDhEtjlhWMBhXHrF;
		}
		return OAtpSggWiVdqwlApjqfNaWiVfgkp;
	}

	[CustomObfuscation(rename = false)]
	private TouchButton()
	{
	}

	public void SetRawValue(float value)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			_axis.SetRawValue(value);
		}
	}

	public void SetDefaultPosition()
	{
		AEwanWIkzyhxpLEBQnkDdPzdhvWf(kJMTokSRJfFCvJTzvbFYrXMRhvEn().anchoredPosition);
	}

	private void AEwanWIkzyhxpLEBQnkDdPzdhvWf(Vector2 P_0)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			iGxxmADCWdLXaIuXgtTYbTrpaUNg = P_0;
		}
	}

	public void ReturnToDefaultPosition(bool instant)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			jLCLstcywHltDsDHytmakSQUaGau(iGxxmADCWdLXaIuXgtTYbTrpaUNg, PositionType.Anchored, !instant && _animateOnReturn, _returnSpeed, MvIcqNAoAuzpaUeLdvXdawySsjtTA.TowardHome);
		}
	}

	public void ReturnToDefaultPosition()
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			ReturnToDefaultPosition(instant: false);
		}
	}

	[CustomObfuscation(rename = false)]
	internal override void Awake()
	{
		base.Awake();
		if (Application.isPlaying)
		{
			iGxxmADCWdLXaIuXgtTYbTrpaUNg = kJMTokSRJfFCvJTzvbFYrXMRhvEn().anchoredPosition;
		}
	}

	[CustomObfuscation(rename = false)]
	internal override void OnEnable()
	{
		base.OnEnable();
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			AFfUjafoRysUBBTrqtgeESVhPdbp();
		}
	}

	[CustomObfuscation(rename = false)]
	internal override void OnDisable()
	{
		base.OnDisable();
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			WGrRWPjtyGMsKfDIUdyYmUlKIsvP();
		}
	}

	[CustomObfuscation(rename = false)]
	internal override void OnValidate()
	{
		base.OnValidate();
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			AFfUjafoRysUBBTrqtgeESVhPdbp();
		}
	}

	[CustomObfuscation(rename = false)]
	internal override void Reset()
	{
		base.Reset();
		base.transitionType = TransitionTypeFlags.ColorTint;
	}

	internal void OnUpdate()
	{
		base.kIQxGaVRogzibbsOOvqmUHztgwdB();
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			sXDjHkOszDSLWToWNTBpFKFFXlye();
			AxqEkQvxYlNyheRJzEQLdpWDaqPf();
			NBxGAVshRihjdGHuMCiLLHaIGAqd();
			if (_followTouchPosition)
			{
				HzzKgbYgXhrODJiyGKGZfLowMPLy(YQFzafkYxcmQYFBqmfUKLTSfsrky());
			}
		}
	}

	internal bool OnInitialize()
	{
		if (!TgEbbHyrtOqZjiwcGxLVOjyndluD())
		{
			return false;
		}
		return true;
	}

	internal void OnCustomControllerUpdate()
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && cGatEfztsIqCLsTucDMygLcPoUUK())
		{
			eNqvXoPsNNtXujHQmteeYomcshNn(_targetCustomControllerElement, XUMHHcxIvvNqyJMrhOveIcplEdLs(), _axis.buttonActivationThreshold);
		}
	}

	internal void OnSubscribeEvents()
	{
		mWLBLrveMMaolVHnoPlWNjIGkOPG();
		_axis.AxisValueChangedEvent += UubGyGHrPYmzFeGcJTDRISMxXrZM;
		_axis.ButtonValueChangedEvent += MCyWAFFaGUQQsorRVZDLbdzqqNSk;
		_axis.ButtonDownEvent += dYnGKlxAPAPXpfqaOnukpwDeWvBl;
		_axis.ButtonUpEvent += ZrcLXlibwyQinFnFZuqUzOVczwlD;
	}

	internal void OnUnsubscribeEvents()
	{
		DQtDAHQvpQLNGcSsvmpJRSyVEqRO();
		_axis.AxisValueChangedEvent -= UubGyGHrPYmzFeGcJTDRISMxXrZM;
		_axis.ButtonValueChangedEvent -= MCyWAFFaGUQQsorRVZDLbdzqqNSk;
		_axis.ButtonDownEvent -= dYnGKlxAPAPXpfqaOnukpwDeWvBl;
		_axis.ButtonUpEvent -= ZrcLXlibwyQinFnFZuqUzOVczwlD;
	}

	internal void OnSetProperty()
	{
		rmFjFJDwYKnSzXfJKtFQGPJRpyTq();
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			AFfUjafoRysUBBTrqtgeESVhPdbp();
		}
	}

	internal void OnClear()
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			OAtpSggWiVdqwlApjqfNaWiVfgkp = int.MinValue;
			dbxwpmvwNsbfvDhEtjlhWMBhXHrF = int.MinValue;
			zONOBcTjnJhlYDLKAqTfyCjuvoXdA = false;
			RnIAfIHDxmdKaAyDsbWmDMoGZqnyA = false;
			if (_returnOnRelease && LZiYLwtmBSuJprBbRHFQjcDQjpQfA && (_moveToTouchPosition || _followTouchPosition))
			{
				ReturnToDefaultPosition(instant: true);
			}
			LZiYLwtmBSuJprBbRHFQjcDQjpQfA = false;
			bxhOYXVosvvqAMOpnMgARLJRIoTe = false;
			RWpDfQrgZedozPqFmTwyDgrqmeit = MvIcqNAoAuzpaUeLdvXdawySsjtTA.None;
			VdpwquifjgrsASAjShoNIMBpEUoIA();
			_axis.Clear();
			XfqUHJABuWdPWUSOwwnRWNqnsWbQ = 0f;
			SyzfmCguVFvqtDaQsirfFjmIfwFC = 0f;
			AFfUjafoRysUBBTrqtgeESVhPdbp();
		}
	}

	public override void ClearValue()
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			_axis.Clear();
			XfqUHJABuWdPWUSOwwnRWNqnsWbQ = 0f;
			if (cGatEfztsIqCLsTucDMygLcPoUUK())
			{
				VsclIioRziGKoShuiaSyIrqcUiRG().ClearElementValue(_targetCustomControllerElement);
			}
		}
	}

	internal bool IsPressed()
	{
		if (!QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			return false;
		}
		if (!oaeJwcBeZoMZRNVcTgpbqRThFymT())
		{
			return false;
		}
		if (!_axis.buttonValue)
		{
			return _axis.value != 0f;
		}
		return true;
	}

	internal bool IsThisOrTouchRegionGameObject(GameObject gameObject)
	{
		if (gameObject == null)
		{
			return false;
		}
		if (base.MrKmabmcAESoxqBxPxIwSpBzktEh(gameObject))
		{
			return true;
		}
		if (oFEYnkRhpQVFEtEVyAuFijiMMedjb != null)
		{
			return oFEYnkRhpQVFEtEVyAuFijiMMedjb.gameObject == gameObject;
		}
		return false;
	}

	private void NBxGAVshRihjdGHuMCiLLHaIGAqd()
	{
		if (_useDigitalAxisSimulation)
		{
			if (_axis.buttonValue)
			{
				GJyKZZvzzwtozwFXGrAtXuFZwOgj();
			}
			else
			{
				RxlfhDhWzJMHWSpozcyVQUUWlOvOA();
			}
		}
	}

	private void GJyKZZvzzwtozwFXGrAtXuFZwOgj()
	{
		float num = ((_axis.value >= 0f) ? 1f : (-1f));
		float num2 = MathTools.Abs(_digitalAxisSensitivity);
		num *= num2 * Time.unscaledDeltaTime;
		num += XfqUHJABuWdPWUSOwwnRWNqnsWbQ;
		num = MathTools.Clamp(num, -1f, 1f);
		ocMrgZnbxAGPseBTNLVjUqTQMADDb(num, true);
	}

	private void RxlfhDhWzJMHWSpozcyVQUUWlOvOA()
	{
		float num = _digitalAxisGravity;
		if (num == 0f)
		{
			return;
		}
		float xfqUHJABuWdPWUSOwwnRWNqnsWbQ = XfqUHJABuWdPWUSOwwnRWNqnsWbQ;
		if (xfqUHJABuWdPWUSOwwnRWNqnsWbQ != 0f)
		{
			float num2 = num * Time.unscaledDeltaTime;
			float num3;
			if (MathTools.Abs(num2) >= MathTools.Abs(xfqUHJABuWdPWUSOwwnRWNqnsWbQ))
			{
				num3 = 0f;
			}
			else
			{
				float num4 = ((xfqUHJABuWdPWUSOwwnRWNqnsWbQ > 0f) ? (-1f) : 1f);
				num3 = xfqUHJABuWdPWUSOwwnRWNqnsWbQ + num4 * num2;
			}
			ocMrgZnbxAGPseBTNLVjUqTQMADDb(num3, true);
		}
	}

	private void ocMrgZnbxAGPseBTNLVjUqTQMADDb(float P_0, bool P_1)
	{
		SyzfmCguVFvqtDaQsirfFjmIfwFC = XfqUHJABuWdPWUSOwwnRWNqnsWbQ;
		XfqUHJABuWdPWUSOwwnRWNqnsWbQ = P_0;
		if (P_0 != SyzfmCguVFvqtDaQsirfFjmIfwFC)
		{
			RZTNnKQoSmcdIfEdAoLXuuCuLVZf(null);
		}
		if (P_1 && P_0 != SyzfmCguVFvqtDaQsirfFjmIfwFC)
		{
			_onAxisValueChanged.Invoke(P_0);
		}
	}

	private void MkpsokElUAYtTdoaqUvkkSSFEoNW()
	{
		if (_buttonType == ButtonType.ToggleSwitch)
		{
			if (ToDOPOHUUOXKMBEzPmGhJgSlSLgc())
			{
				_axis.SetRawValue(_axis.rawZero);
			}
			else
			{
				_axis.SetRawValue(_axis.rawMax);
			}
		}
		else if (_buttonType == ButtonType.Standard)
		{
			_axis.SetRawValue(_axis.rawMax);
		}
	}

	private void aKhXRIxgIKkCHfCtxzlFXWKTqFhK()
	{
		if (_buttonType == ButtonType.Standard)
		{
			_axis.SetRawValue(_axis.rawZero);
		}
	}

	private void AFfUjafoRysUBBTrqtgeESVhPdbp()
	{
		_targetCustomControllerElement.ClearElementCaches();
		AxqEkQvxYlNyheRJzEQLdpWDaqPf();
		eRKmmqrkFUNgMAGQmCSKrkwvhwk();
	}

	private void eRKmmqrkFUNgMAGQmCSKrkwvhwk()
	{
		if (_manageRaycasting)
		{
			CrxVUBIZrcuCOQzwOUKwzRUPWqod.HNgQfMITEkAnTxRwkMrIubiErhfO(base.transform, sdRKPqCeFVVlhdmntokiGdiaaGFb());
		}
	}

	private bool sdRKPqCeFVVlhdmntokiGdiaaGFb()
	{
		if (oFEYnkRhpQVFEtEVyAuFijiMMedjb != null && _useTouchRegionOnly)
		{
			return false;
		}
		return true;
	}

	private void BCxZKYeHSXdGoupaSfGFaVTCbVuu(TouchRegion P_0)
	{
		if (!(P_0 == null))
		{
			IdWNVDsJCndNfHoDGGBVVWkNWtlIA(P_0);
			P_0.PointerDownEvent += eIPqzfIAuFAfKCSQFjARJoyeZgHnA;
			P_0.PointerUpEvent += ETiQLINTjaxjNsIvsjceZESxAuYq;
			P_0.PointerEnterEvent += lCsgQYSVoCViEiBDUrRIJMzEhgmF;
			P_0.PointerExitEvent += RIqDqAlWjxclqmwLFBBtUPFvBNlQ;
		}
	}

	private void IdWNVDsJCndNfHoDGGBVVWkNWtlIA(TouchRegion P_0)
	{
		if (!(P_0 == null))
		{
			P_0.PointerDownEvent -= eIPqzfIAuFAfKCSQFjARJoyeZgHnA;
			P_0.PointerUpEvent -= ETiQLINTjaxjNsIvsjceZESxAuYq;
			P_0.PointerEnterEvent -= lCsgQYSVoCViEiBDUrRIJMzEhgmF;
			P_0.PointerExitEvent -= RIqDqAlWjxclqmwLFBBtUPFvBNlQ;
		}
	}

	private void AxqEkQvxYlNyheRJzEQLdpWDaqPf()
	{
		if (!(oFEYnkRhpQVFEtEVyAuFijiMMedjb == _touchRegion))
		{
			IdWNVDsJCndNfHoDGGBVVWkNWtlIA(oFEYnkRhpQVFEtEVyAuFijiMMedjb);
			oFEYnkRhpQVFEtEVyAuFijiMMedjb = _touchRegion;
			BCxZKYeHSXdGoupaSfGFaVTCbVuu(oFEYnkRhpQVFEtEVyAuFijiMMedjb);
		}
	}

	private void KyNuIWVFtSAaigEzzfAVIphjyuCk(Vector2 P_0, bool P_1, float P_2, MvIcqNAoAuzpaUeLdvXdawySsjtTA P_3)
	{
		RectTransform rectTransform = base.transform.parent as RectTransform;
		Vector2 vector = wbMBRTDcWhifYEiuPKvXmWDTvFpu.gcziLTFTNMIQSalliEHGfNehgcAd(qVnIqObCTShIxSKGdNESmpBXjwRK(), rectTransform, P_0);
		Vector2 pivot = kJMTokSRJfFCvJTzvbFYrXMRhvEn().pivot;
		Vector2 sizeDelta = kJMTokSRJfFCvJTzvbFYrXMRhvEn().sizeDelta;
		Vector3 localScale = kJMTokSRJfFCvJTzvbFYrXMRhvEn().localScale;
		vector += new Vector2((pivot.x - 0.5f) * sizeDelta.x * localScale.x, (pivot.y - 0.5f) * sizeDelta.y * localScale.y);
		jLCLstcywHltDsDHytmakSQUaGau(vector, PositionType.Local, P_1, P_2, P_3);
	}

	private void jLCLstcywHltDsDHytmakSQUaGau(Vector2 P_0, PositionType P_1, bool P_2, float P_3, MvIcqNAoAuzpaUeLdvXdawySsjtTA P_4)
	{
		if ((bxhOYXVosvvqAMOpnMgARLJRIoTe & P_2) && RWpDfQrgZedozPqFmTwyDgrqmeit == P_4)
		{
			return;
		}
		if (bxhOYXVosvvqAMOpnMgARLJRIoTe && ksWorNLgqAEqcJRPNTjkeQVjGiD != null)
		{
			VdpwquifjgrsASAjShoNIMBpEUoIA();
			bxhOYXVosvvqAMOpnMgARLJRIoTe = false;
			RWpDfQrgZedozPqFmTwyDgrqmeit = MvIcqNAoAuzpaUeLdvXdawySsjtTA.None;
		}
		if (qVnIqObCTShIxSKGdNESmpBXjwRK() == null)
		{
			Logger.LogWarning("Animation cannot be used without a Canvas.");
			P_2 = false;
		}
		else if (qVnIqObCTShIxSKGdNESmpBXjwRK().renderMode == RenderMode.WorldSpace)
		{
			Logger.LogWarning("Animation can only be used with a screen space Canvas.");
			P_2 = false;
		}
		if (P_2)
		{
			Transform parent = base.transform;
			RectTransform rectTransform = PvPMQFDzlybbkuSgSSLnUkAlIJPiA();
			Vector2 one = Vector2.one;
			while ((parent = parent.parent) != rectTransform && !(parent == null))
			{
				one.x *= parent.localScale.x;
				one.y *= parent.localScale.y;
			}
			Vector2 sizeDelta = rectTransform.sizeDelta;
			bool num = sizeDelta.x < sizeDelta.y;
			float num2 = MathTools.Max(sizeDelta.x, sizeDelta.y);
			float num3 = (num ? one.y : one.x);
			if (num3 == 0f)
			{
				num3 = 0.0001f;
			}
			P_3 = P_3 / num3 * num2;
			ksWorNLgqAEqcJRPNTjkeQVjGiD = GaRhaivbeozoPHYFVTQWhXlrljhq(P_0, P_1, P_3, P_4);
			StartCoroutine(ksWorNLgqAEqcJRPNTjkeQVjGiD);
			RWpDfQrgZedozPqFmTwyDgrqmeit = P_4;
			LZiYLwtmBSuJprBbRHFQjcDQjpQfA = true;
			kydeRKCcmzQnnassANDheZUgGFZO()(P_4);
		}
		else
		{
			kydeRKCcmzQnnassANDheZUgGFZO()(P_4);
			OFtFmptuiQWbcULqlMMjWjDuBryGA(P_4, P_0, P_1);
		}
	}

	[IteratorStateMachine(typeof(IeURYPZQrlqYJRaZoFJkKmLhYsPz))]
	private IEnumerator GaRhaivbeozoPHYFVTQWhXlrljhq(Vector2 P_0, PositionType P_1, float P_2, MvIcqNAoAuzpaUeLdvXdawySsjtTA P_3)
	{
		return new IeURYPZQrlqYJRaZoFJkKmLhYsPz(0)
		{
			mzPYGJDuURdgRWbzgXYwBiTfpCWO = this,
			qIxEAQeteQoIPkWWUMvKGIVwOanc = P_0,
			mrGJRuAdsHLHkixOWkPCAgPsiwhU = P_1,
			vLqNhndajEQthKAzFdJiDgJYeEmh = P_2,
			XjTONMwDjGWnpDqekBypBSEafICy = P_3
		};
	}

	private void OFtFmptuiQWbcULqlMMjWjDuBryGA(MvIcqNAoAuzpaUeLdvXdawySsjtTA P_0, Vector2 P_1, PositionType P_2)
	{
		wbMBRTDcWhifYEiuPKvXmWDTvFpu.yaNeOifnmoVsOaBmHgYqgMJiZRxc(kJMTokSRJfFCvJTzvbFYrXMRhvEn(), P_1, P_2);
		bxhOYXVosvvqAMOpnMgARLJRIoTe = false;
		RWpDfQrgZedozPqFmTwyDgrqmeit = MvIcqNAoAuzpaUeLdvXdawySsjtTA.None;
		switch (P_0)
		{
		case MvIcqNAoAuzpaUeLdvXdawySsjtTA.TowardHome:
			LZiYLwtmBSuJprBbRHFQjcDQjpQfA = false;
			break;
		case MvIcqNAoAuzpaUeLdvXdawySsjtTA.TowardTouch:
			LZiYLwtmBSuJprBbRHFQjcDQjpQfA = true;
			break;
		}
		VdpwquifjgrsASAjShoNIMBpEUoIA();
		mrZfQAqjvGOCwyMruJbCUGjAJHlDA()(P_0);
	}

	private void zgLrVDMJPmswJsBRjKCAvwbkfwBT(MvIcqNAoAuzpaUeLdvXdawySsjtTA P_0)
	{
		if (_manageRaycasting)
		{
			bool flag = false;
			bool flag2 = false;
			if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && oFEYnkRhpQVFEtEVyAuFijiMMedjb != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == MvIcqNAoAuzpaUeLdvXdawySsjtTA.TowardTouch)
			{
				flag = true;
				flag2 = false;
			}
			if (flag)
			{
				CrxVUBIZrcuCOQzwOUKwzRUPWqod.HNgQfMITEkAnTxRwkMrIubiErhfO(base.transform, flag2);
			}
		}
	}

	private void jzcgVVdUbfhafYRmdFewhaukADpxB(MvIcqNAoAuzpaUeLdvXdawySsjtTA P_0)
	{
		if (_manageRaycasting)
		{
			bool flag = false;
			bool flag2 = false;
			if (((_followTouchPosition && stayActiveOnSwipeOut) || (!_followTouchPosition && oFEYnkRhpQVFEtEVyAuFijiMMedjb != null && !_useTouchRegionOnly && _moveToTouchPosition)) && _returnOnRelease && P_0 == MvIcqNAoAuzpaUeLdvXdawySsjtTA.TowardHome)
			{
				flag = true;
				flag2 = sdRKPqCeFVVlhdmntokiGdiaaGFb();
			}
			if (flag)
			{
				CrxVUBIZrcuCOQzwOUKwzRUPWqod.HNgQfMITEkAnTxRwkMrIubiErhfO(base.transform, flag2);
			}
		}
	}

	private void HzzKgbYgXhrODJiyGKGZfLowMPLy(int P_0)
	{
		if (TouchInteractable.mRSYcsbbLGividPxxIsAwIGOQExrA(P_0))
		{
			KyNuIWVFtSAaigEzzfAVIphjyuCk(TouchInteractable.fSFFIqPCdTfnlcWytKtjAqgwwIbE(P_0), false, 0f, MvIcqNAoAuzpaUeLdvXdawySsjtTA.TowardTouch);
		}
	}

	private void VdpwquifjgrsASAjShoNIMBpEUoIA()
	{
		if (ksWorNLgqAEqcJRPNTjkeQVjGiD != null)
		{
			try
			{
				StopCoroutine(ksWorNLgqAEqcJRPNTjkeQVjGiD);
			}
			catch
			{
			}
			ksWorNLgqAEqcJRPNTjkeQVjGiD = null;
		}
	}

	private void sXDjHkOszDSLWToWNTBpFKFFXlye()
	{
		if (hasPointer && !TouchInteractable.mRSYcsbbLGividPxxIsAwIGOQExrA(YQFzafkYxcmQYFBqmfUKLTSfsrky()))
		{
			PointerEventData pointerEventData = KHDtStwGHWadAdgsjaBeysiWulfq(YQFzafkYxcmQYFBqmfUKLTSfsrky());
			if (pointerEventData != null && pointerEventData.pointerPress != null)
			{
				xReEESFUkuPVQiAKCriuDNPoSNmA(pointerEventData);
			}
			else
			{
				xuNSlwrWMCQkGAjcuDQoOZIGqjkx();
			}
		}
	}

	private bool ulqsmOwvmuIOhUpbPRQELGaNCRMC()
	{
		if (!_followTouchPosition)
		{
			return false;
		}
		if (_touchRegion != null && _useTouchRegionOnly)
		{
			return false;
		}
		return true;
	}

	private void uKMPNkBASzdhHRJEXOAGvyqmCAYh()
	{
		OAtpSggWiVdqwlApjqfNaWiVfgkp = int.MinValue;
		dbxwpmvwNsbfvDhEtjlhWMBhXHrF = int.MinValue;
	}

	private bool zjVClKtlBUmNIzGpidvTjTdpavCx(int P_0)
	{
		if (P_0 == int.MinValue)
		{
			return false;
		}
		if (OAtpSggWiVdqwlApjqfNaWiVfgkp == int.MinValue)
		{
			return false;
		}
		if (OAtpSggWiVdqwlApjqfNaWiVfgkp == P_0)
		{
			return true;
		}
		if (TouchInteractable.WXkxrLAoqcWTDUeJjBzBHrqWDPEHb(P_0) && dbxwpmvwNsbfvDhEtjlhWMBhXHrF != int.MinValue && P_0 == dbxwpmvwNsbfvDhEtjlhWMBhXHrF)
		{
			return true;
		}
		return false;
	}

	private PointerEventData uNWNkTzmAJFWNvfLEBrQuivYQoWU(int P_0, GameObject P_1)
	{
		PointerEventData pointerEventData = KHDtStwGHWadAdgsjaBeysiWulfq(P_0);
		if (pointerEventData == null)
		{
			return null;
		}
		pointerEventData.position = TouchInteractable.fSFFIqPCdTfnlcWytKtjAqgwwIbE(P_0);
		if (TouchInteractable.taBoSkdUnCIFwXCeRCiuDjheGucHA(P_0))
		{
			pointerEventData.eligibleForClick = true;
			pointerEventData.delta = Vector2.zero;
			pointerEventData.dragging = false;
			pointerEventData.useDragThreshold = true;
			pointerEventData.pressPosition = pointerEventData.position;
			pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
			if (pointerEventData.pointerEnter != P_1)
			{
				pointerEventData.pointerEnter = P_1;
			}
			float unscaledTime = Time.unscaledTime;
			if (P_1 == pointerEventData.lastPress)
			{
				if (unscaledTime - pointerEventData.clickTime < 0.3f)
				{
					int clickCount = pointerEventData.clickCount + 1;
					pointerEventData.clickCount = clickCount;
				}
				else
				{
					pointerEventData.clickCount = 1;
				}
				pointerEventData.clickTime = unscaledTime;
			}
			else
			{
				pointerEventData.clickCount = 1;
			}
			pointerEventData.pointerPress = P_1;
			pointerEventData.rawPointerPress = P_1;
			pointerEventData.clickTime = unscaledTime;
			pointerEventData.pointerDrag = P_1;
		}
		else
		{
			if (!TouchInteractable.WXkxrLAoqcWTDUeJjBzBHrqWDPEHb(P_0))
			{
				Logger.LogWarning("Unsupported pointerId: " + P_0);
				return null;
			}
			pointerEventData.eligibleForClick = true;
			pointerEventData.delta = Vector2.zero;
			pointerEventData.dragging = false;
			pointerEventData.useDragThreshold = true;
			pointerEventData.pressPosition = pointerEventData.position;
			pointerEventData.pointerPressRaycast = pointerEventData.pointerCurrentRaycast;
			float unscaledTime2 = Time.unscaledTime;
			if (P_1 == pointerEventData.lastPress)
			{
				if (unscaledTime2 - pointerEventData.clickTime < 0.3f)
				{
					int clickCount = pointerEventData.clickCount + 1;
					pointerEventData.clickCount = clickCount;
				}
				else
				{
					pointerEventData.clickCount = 1;
				}
				pointerEventData.clickTime = unscaledTime2;
			}
			else
			{
				pointerEventData.clickCount = 1;
			}
			pointerEventData.pointerPress = P_1;
			pointerEventData.rawPointerPress = P_1;
			pointerEventData.clickTime = unscaledTime2;
			pointerEventData.pointerDrag = P_1;
		}
		return pointerEventData;
	}

	private PointerEventData bKcecKILVFFykoEBDFOkaziDiEppB(int P_0)
	{
		PointerEventData pointerEventData = KHDtStwGHWadAdgsjaBeysiWulfq(P_0);
		if (pointerEventData == null)
		{
			return null;
		}
		if (TouchInteractable.taBoSkdUnCIFwXCeRCiuDjheGucHA(P_0))
		{
			pointerEventData.eligibleForClick = false;
			pointerEventData.pointerPress = null;
			pointerEventData.rawPointerPress = null;
			pointerEventData.dragging = false;
			pointerEventData.pointerDrag = null;
			pointerEventData.pointerEnter = null;
		}
		else
		{
			if (!TouchInteractable.WXkxrLAoqcWTDUeJjBzBHrqWDPEHb(P_0))
			{
				Logger.LogWarning("Unsupported pointerId: " + P_0);
				return null;
			}
			pointerEventData.eligibleForClick = false;
			pointerEventData.pointerPress = null;
			pointerEventData.rawPointerPress = null;
			pointerEventData.dragging = false;
			pointerEventData.pointerDrag = null;
		}
		return pointerEventData;
	}

	private void xReEESFUkuPVQiAKCriuDNPoSNmA(PointerEventData P_0)
	{
		if (P_0 != null)
		{
			OnPointerUp(P_0);
			bKcecKILVFFykoEBDFOkaziDiEppB(YQFzafkYxcmQYFBqmfUKLTSfsrky());
		}
	}

	private PointerEventData KHDtStwGHWadAdgsjaBeysiWulfq(int P_0)
	{
		if (P_0 == int.MinValue)
		{
			return null;
		}
		if (UKWEzEbWKrpHqnivAeAYeXPdqLlS == null)
		{
			UKWEzEbWKrpHqnivAeAYeXPdqLlS = new Dictionary<int, PointerEventData>();
		}
		if (!UKWEzEbWKrpHqnivAeAYeXPdqLlS.TryGetValue(P_0, out var value))
		{
			value = new PointerEventData(EventSystem.current);
			value.pointerId = P_0;
			UKWEzEbWKrpHqnivAeAYeXPdqLlS.Add(P_0, value);
			if (TouchInteractable.WXkxrLAoqcWTDUeJjBzBHrqWDPEHb(P_0))
			{
				PointerEventData.InputButton button = P_0 switch
				{
					-1 => PointerEventData.InputButton.Left, 
					-2 => PointerEventData.InputButton.Right, 
					-3 => PointerEventData.InputButton.Middle, 
					_ => throw new NotImplementedException(), 
				};
				value.button = button;
			}
		}
		return value;
	}

	private void oyqpiUYoIIdmaqtoirrdfYrgdtOt(PointerEventData P_0, KoKdNThSRpjZqvUDkRiYgbHNgHviA P_1)
	{
		if (!hasPointer || zjVClKtlBUmNIzGpidvTjTdpavCx(P_0.pointerId))
		{
			if (oaeJwcBeZoMZRNVcTgpbqRThFymT() && IsInteractable())
			{
				UioBdAIqDelzpslYqtWHEMOmXDCU(P_0.pointerId, P_0.pressPosition, P_1);
			}
			base.OnPointerDown(P_0);
		}
	}

	private void vtUlYaQGVayFLEMGrgMyhHoIDeHL(PointerEventData P_0, KoKdNThSRpjZqvUDkRiYgbHNgHviA P_1)
	{
		if ((!hasPointer || zjVClKtlBUmNIzGpidvTjTdpavCx(P_0.pointerId)) && !TouchInteractable.mRSYcsbbLGividPxxIsAwIGOQExrA(YQFzafkYxcmQYFBqmfUKLTSfsrky()))
		{
			xuNSlwrWMCQkGAjcuDQoOZIGqjkx();
			base.OnPointerUp(P_0);
		}
	}

	private void TqOOEfriSTGAdCOyvFMsipbOUPBq(PointerEventData P_0, KoKdNThSRpjZqvUDkRiYgbHNgHviA P_1)
	{
		if (hasPointer && !zjVClKtlBUmNIzGpidvTjTdpavCx(P_0.pointerId))
		{
			return;
		}
		bool flag = TouchInteractable.WXkxrLAoqcWTDUeJjBzBHrqWDPEHb(P_0.pointerId);
		bool flag2 = false;
		MouseButtonFlags mouseButtonFlags = P_1 switch
		{
			KoKdNThSRpjZqvUDkRiYgbHNgHviA.Local => base.allowedMouseButtons, 
			KoKdNThSRpjZqvUDkRiYgbHNgHviA.TouchRegion => _touchRegion.allowedMouseButtons, 
			_ => throw new NotImplementedException(), 
		};
		if (_activateOnSwipeIn && oaeJwcBeZoMZRNVcTgpbqRThFymT() && IsInteractable() && (!flag || TouchInteractable.KOQRODyedkzAWhLBQerzLuXVDEwq(mouseButtonFlags)) && !zONOBcTjnJhlYDLKAqTfyCjuvoXdA)
		{
			if (flag)
			{
				if (TouchInteractable.VAGTerhsNSvfwApYSuTWzWHLTYoN(mouseButtonFlags, out var num))
				{
					dbxwpmvwNsbfvDhEtjlhWMBhXHrF = num;
				}
				else
				{
					dbxwpmvwNsbfvDhEtjlhWMBhXHrF = P_0.pointerId;
				}
			}
			flag2 = true;
		}
		base.OnPointerEnter(P_0);
		if (flag2)
		{
			GameObject gameObject = P_1 switch
			{
				KoKdNThSRpjZqvUDkRiYgbHNgHviA.Local => base.gameObject, 
				KoKdNThSRpjZqvUDkRiYgbHNgHviA.TouchRegion => oFEYnkRhpQVFEtEVyAuFijiMMedjb.gameObject, 
				_ => throw new NotImplementedException(), 
			};
			PointerEventData pointerEventData = uNWNkTzmAJFWNvfLEBrQuivYQoWU((dbxwpmvwNsbfvDhEtjlhWMBhXHrF != int.MinValue) ? dbxwpmvwNsbfvDhEtjlhWMBhXHrF : P_0.pointerId, gameObject);
			if (pointerEventData != null)
			{
				oyqpiUYoIIdmaqtoirrdfYrgdtOt(pointerEventData, P_1);
			}
		}
		RnIAfIHDxmdKaAyDsbWmDMoGZqnyA = true;
	}

	private void AQZGmjaphueuJNCGEJmCEXTrZCPaA(PointerEventData P_0, KoKdNThSRpjZqvUDkRiYgbHNgHviA P_1)
	{
		if (hasPointer && !zjVClKtlBUmNIzGpidvTjTdpavCx(P_0.pointerId))
		{
			base.OnPointerExit(P_0);
			return;
		}
		if (!stayActiveOnSwipeOut && zONOBcTjnJhlYDLKAqTfyCjuvoXdA)
		{
			xuNSlwrWMCQkGAjcuDQoOZIGqjkx();
		}
		base.OnPointerExit(P_0);
		RnIAfIHDxmdKaAyDsbWmDMoGZqnyA = false;
	}

	private void UioBdAIqDelzpslYqtWHEMOmXDCU(int P_0, Vector2 P_1, KoKdNThSRpjZqvUDkRiYgbHNgHviA P_2)
	{
		OAtpSggWiVdqwlApjqfNaWiVfgkp = P_0;
		zONOBcTjnJhlYDLKAqTfyCjuvoXdA = true;
		if (_followTouchPosition)
		{
			HzzKgbYgXhrODJiyGKGZfLowMPLy(P_0);
		}
		else if (P_2 == KoKdNThSRpjZqvUDkRiYgbHNgHviA.TouchRegion && _moveToTouchPosition)
		{
			KyNuIWVFtSAaigEzzfAVIphjyuCk(P_1, _animateOnMoveToTouch, _moveToTouchSpeed, MvIcqNAoAuzpaUeLdvXdawySsjtTA.TowardTouch);
		}
		MkpsokElUAYtTdoaqUvkkSSFEoNW();
	}

	private void xuNSlwrWMCQkGAjcuDQoOZIGqjkx()
	{
		uKMPNkBASzdhHRJEXOAGvyqmCAYh();
		zONOBcTjnJhlYDLKAqTfyCjuvoXdA = false;
		if ((_followTouchPosition || _moveToTouchPosition) && _returnOnRelease && LZiYLwtmBSuJprBbRHFQjcDQjpQfA)
		{
			ReturnToDefaultPosition();
		}
		aKhXRIxgIKkCHfCtxzlFXWKTqFhK();
	}

	internal override void OnPointerDown(PointerEventData eventData)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && (!(oFEYnkRhpQVFEtEVyAuFijiMMedjb != null) || !_useTouchRegionOnly))
		{
			oyqpiUYoIIdmaqtoirrdfYrgdtOt(eventData, KoKdNThSRpjZqvUDkRiYgbHNgHviA.Local);
		}
	}

	internal override void OnPointerUp(PointerEventData eventData)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && (!(oFEYnkRhpQVFEtEVyAuFijiMMedjb != null) || !_useTouchRegionOnly))
		{
			vtUlYaQGVayFLEMGrgMyhHoIDeHL(eventData, KoKdNThSRpjZqvUDkRiYgbHNgHviA.Local);
		}
	}

	internal override void OnPointerEnter(PointerEventData eventData)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && (!(oFEYnkRhpQVFEtEVyAuFijiMMedjb != null) || !_useTouchRegionOnly))
		{
			TqOOEfriSTGAdCOyvFMsipbOUPBq(eventData, KoKdNThSRpjZqvUDkRiYgbHNgHviA.Local);
		}
	}

	internal override void OnPointerExit(PointerEventData eventData)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && (!(oFEYnkRhpQVFEtEVyAuFijiMMedjb != null) || !_useTouchRegionOnly))
		{
			AQZGmjaphueuJNCGEJmCEXTrZCPaA(eventData, KoKdNThSRpjZqvUDkRiYgbHNgHviA.Local);
		}
	}

	private void eIPqzfIAuFAfKCSQFjARJoyeZgHnA(PointerEventData P_0)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerDown))
		{
			oyqpiUYoIIdmaqtoirrdfYrgdtOt(P_0, KoKdNThSRpjZqvUDkRiYgbHNgHviA.TouchRegion);
		}
	}

	private void ETiQLINTjaxjNsIvsjceZESxAuYq(PointerEventData P_0)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerUp))
		{
			vtUlYaQGVayFLEMGrgMyhHoIDeHL(P_0, KoKdNThSRpjZqvUDkRiYgbHNgHviA.TouchRegion);
		}
	}

	private void lCsgQYSVoCViEiBDUrRIJMzEhgmF(PointerEventData P_0)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerEnter))
		{
			TqOOEfriSTGAdCOyvFMsipbOUPBq(P_0, KoKdNThSRpjZqvUDkRiYgbHNgHviA.TouchRegion);
		}
	}

	private void RIqDqAlWjxclqmwLFBBtUPFvBNlQ(PointerEventData P_0)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && TouchInteractable.otiaXVprkhnoYNaDsyXwRDXmfaMhA(P_0.pointerId, _touchRegion.allowedMouseButtons, EventTriggerType.PointerExit))
		{
			AQZGmjaphueuJNCGEJmCEXTrZCPaA(P_0, KoKdNThSRpjZqvUDkRiYgbHNgHviA.TouchRegion);
		}
	}

	private void UubGyGHrPYmzFeGcJTDRISMxXrZM(float P_0)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc() && !_useDigitalAxisSimulation)
		{
			RZTNnKQoSmcdIfEdAoLXuuCuLVZf(null);
			_onAxisValueChanged.Invoke(P_0);
		}
	}

	private void MCyWAFFaGUQQsorRVZDLbdzqqNSk(bool P_0)
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			RZTNnKQoSmcdIfEdAoLXuuCuLVZf(null);
			_onButtonValueChanged.Invoke(P_0);
		}
	}

	private void dYnGKlxAPAPXpfqaOnukpwDeWvBl()
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			RZTNnKQoSmcdIfEdAoLXuuCuLVZf(null);
			_onButtonDown.Invoke();
		}
	}

	private void ZrcLXlibwyQinFnFZuqUzOVczwlD()
	{
		if (QlySyzScDMyjiCtNiwSFHhQYXMxc())
		{
			RZTNnKQoSmcdIfEdAoLXuuCuLVZf(null);
			_onButtonUp.Invoke();
		}
	}
}
