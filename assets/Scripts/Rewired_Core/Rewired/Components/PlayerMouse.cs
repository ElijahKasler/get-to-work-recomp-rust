using System;
using System.Collections.Generic;
using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Rewired.Components;

[Serializable]
[AddComponentMenu("Rewired/Player Controllers/Player Mouse")]
public sealed class PlayerMouse : PlayerController, IPlayerMouse, IPlayerController, IMouseInputSource
{
	[Serializable]
	public class ScreenPositionChangedHandler : UnityEvent<Vector2>
	{
	}

	[Tooltip("If enabled, the screen position will default to the center of the allowed movement area. Otherwise, it will default to the lower-left corner of the allowed movement area.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _defaultToCenter = true;

	[Tooltip("The pointer speed. This does not affect the speed of input from the mouse x/y axes if useHardwarePointerPosition is enabled. It only affects the speed from input sources other than mouse x/y or if mouse x/y are mapped to Actions assigned to Axes. ")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private float _pointerSpeed = 1f;

	[Tooltip("If enabled, the hardware pointer position will be used for mouse input. Otherwise, the position of the pointer will be calculated only from the Axis Action values. The Player that owns this Player Mouse must have the physical mouse assigned to it in order for the hardware position to be used, ex: player.controllers.hasMouse == true.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _useHardwarePointerPosition = true;

	[Tooltip("If enabled, movement will be clamped to the Movement Area.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _clampToMovementArea = true;

	[Tooltip("The allowed movement area for the mouse pointer. Set Movement Area Unit to determine the data format of this value. This rect is a screen-space rect with 0, 0 at the lower-left corner.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Rect _movementArea = new Rect(0f, 0f, 1f, 1f);

	[Tooltip("The unit format of the movement area. This is used to determine the data format of Movement Area.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Rewired.PlayerMouse.MovementAreaUnit _movementAreaUnit;

	[Tooltip("Triggered when the screen position changes. Link this to your pointer to drive its position.")]
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private ScreenPositionChangedHandler _onScreenPositionChanged = new ScreenPositionChangedHandler();

	private Rewired.PlayerMouse aHfAfUWWbGNqctBbVsCrwdcesbQt => HvRHMSrnOGXvBZagcnZuBOApnAnl();

	bool IPlayerMouse.defaultToCenter
	{
		get
		{
			return get_defaultToCenter();
		}
		set
		{
			set_defaultToCenter(value);
		}
	}

	public bool clampToMovementArea
	{
		get
		{
			if (!base.initialized)
			{
				return _clampToMovementArea;
			}
			return HvRHMSrnOGXvBZagcnZuBOApnAnl().clampToMovementArea;
		}
		set
		{
			if (HvRHMSrnOGXvBZagcnZuBOApnAnl() == null)
			{
				_clampToMovementArea = value;
				return;
			}
			HvRHMSrnOGXvBZagcnZuBOApnAnl().clampToMovementArea = value;
			_clampToMovementArea = HvRHMSrnOGXvBZagcnZuBOApnAnl().clampToMovementArea;
		}
	}

	ScreenRect IPlayerMouse.movementArea
	{
		get
		{
			return get_movementArea();
		}
		set
		{
			set_movementArea(value);
		}
	}

	Rewired.PlayerMouse.MovementAreaUnit IPlayerMouse.movementAreaUnit
	{
		get
		{
			return get_movementAreaUnit();
		}
		set
		{
			set_movementAreaUnit(value);
		}
	}

	Vector2 IPlayerMouse.screenPosition
	{
		get
		{
			return get_screenPosition();
		}
		set
		{
			set_screenPosition(value);
		}
	}

	Vector2 IPlayerMouse.screenPositionPrev => get_screenPositionPrev();

	Vector2 IPlayerMouse.screenPositionDelta => get_screenPositionDelta();

	Rewired.PlayerController.MouseAxis IPlayerMouse.xAxis => get_xAxis();

	Rewired.PlayerController.MouseAxis IPlayerMouse.yAxis => get_yAxis();

	Rewired.PlayerController.MouseWheel IPlayerMouse.wheel => get_wheel();

	Rewired.PlayerController.Button IPlayerMouse.leftButton => get_leftButton();

	Rewired.PlayerController.Button IPlayerMouse.rightButton => get_rightButton();

	Rewired.PlayerController.Button IPlayerMouse.middleButton => get_middleButton();

	float IPlayerMouse.pointerSpeed
	{
		get
		{
			return get_pointerSpeed();
		}
		set
		{
			set_pointerSpeed(value);
		}
	}

	bool IPlayerMouse.useHardwarePointerPosition
	{
		get
		{
			return get_useHardwarePointerPosition();
		}
		set
		{
			set_useHardwarePointerPosition(value);
		}
	}

	bool IMouseInputSource.enabled
	{
		get
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)HvRHMSrnOGXvBZagcnZuBOApnAnl()).enabled;
		}
	}

	Vector2 IMouseInputSource.screenPosition
	{
		get
		{
			if (!base.initialized)
			{
				return Vector2.zero;
			}
			return ((IMouseInputSource)HvRHMSrnOGXvBZagcnZuBOApnAnl()).screenPosition;
		}
	}

	Vector2 IMouseInputSource.screenPositionDelta
	{
		get
		{
			if (!base.initialized)
			{
				return Vector2.zero;
			}
			return ((IMouseInputSource)HvRHMSrnOGXvBZagcnZuBOApnAnl()).screenPositionDelta;
		}
	}

	Vector2 IMouseInputSource.wheelDelta
	{
		get
		{
			if (!base.initialized)
			{
				return Vector2.zero;
			}
			return ((IMouseInputSource)HvRHMSrnOGXvBZagcnZuBOApnAnl()).wheelDelta;
		}
	}

	bool IMouseInputSource.locked
	{
		get
		{
			if (!base.initialized)
			{
				return false;
			}
			return ((IMouseInputSource)HvRHMSrnOGXvBZagcnZuBOApnAnl()).locked;
		}
	}

	bool IPlayerController.enabled
	{
		get
		{
			return base.enabled;
		}
		set
		{
			base.enabled = value;
		}
	}

	event Action<Vector2> IPlayerMouse.ScreenPositionChangedEvent
	{
		add
		{
			add_ScreenPositionChangedEvent(value);
		}
		remove
		{
			remove_ScreenPositionChangedEvent(value);
		}
	}

	private Rewired.PlayerMouse HvRHMSrnOGXvBZagcnZuBOApnAnl()
	{
		return base.source as Rewired.PlayerMouse;
	}

	public bool get_defaultToCenter()
	{
		if (!base.initialized)
		{
			return _defaultToCenter;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_defaultToCenter();
	}

	public void set_defaultToCenter(bool value)
	{
		if (HvRHMSrnOGXvBZagcnZuBOApnAnl() == null)
		{
			_defaultToCenter = value;
			return;
		}
		HvRHMSrnOGXvBZagcnZuBOApnAnl().set_defaultToCenter(value);
		_defaultToCenter = HvRHMSrnOGXvBZagcnZuBOApnAnl().get_defaultToCenter();
	}

	public ScreenRect get_movementArea()
	{
		if (!base.initialized)
		{
			return new ScreenRect(_movementArea.xMin, _movementArea.yMin, _movementArea.width, _movementArea.height);
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_movementArea();
	}

	public void set_movementArea(ScreenRect value)
	{
		if (HvRHMSrnOGXvBZagcnZuBOApnAnl() == null)
		{
			_movementArea = new Rect(value.xMin, value.yMin, value.width, value.height);
			return;
		}
		HvRHMSrnOGXvBZagcnZuBOApnAnl().set_movementArea(value);
		_movementArea = new Rect(HvRHMSrnOGXvBZagcnZuBOApnAnl().get_movementArea().xMin, HvRHMSrnOGXvBZagcnZuBOApnAnl().get_movementArea().yMin, HvRHMSrnOGXvBZagcnZuBOApnAnl().get_movementArea().width, HvRHMSrnOGXvBZagcnZuBOApnAnl().get_movementArea().height);
	}

	public Rewired.PlayerMouse.MovementAreaUnit get_movementAreaUnit()
	{
		if (!base.initialized)
		{
			return _movementAreaUnit;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_movementAreaUnit();
	}

	public void set_movementAreaUnit(Rewired.PlayerMouse.MovementAreaUnit value)
	{
		if (HvRHMSrnOGXvBZagcnZuBOApnAnl() == null)
		{
			_movementAreaUnit = value;
			return;
		}
		HvRHMSrnOGXvBZagcnZuBOApnAnl().set_movementAreaUnit(value);
		_movementAreaUnit = HvRHMSrnOGXvBZagcnZuBOApnAnl().get_movementAreaUnit();
	}

	public Vector2 get_screenPosition()
	{
		if (!base.initialized)
		{
			return Vector2.zero;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_screenPosition();
	}

	public void set_screenPosition(Vector2 value)
	{
		if (HvRHMSrnOGXvBZagcnZuBOApnAnl() != null)
		{
			HvRHMSrnOGXvBZagcnZuBOApnAnl().set_screenPosition(value);
		}
	}

	public Vector2 get_screenPositionPrev()
	{
		if (!base.initialized)
		{
			return Vector2.zero;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_screenPositionPrev();
	}

	public Vector2 get_screenPositionDelta()
	{
		if (!base.initialized)
		{
			return Vector2.zero;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_screenPositionDelta();
	}

	public Rewired.PlayerController.MouseAxis get_xAxis()
	{
		if (!base.initialized)
		{
			return null;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_xAxis();
	}

	public Rewired.PlayerController.MouseAxis get_yAxis()
	{
		if (!base.initialized)
		{
			return null;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_yAxis();
	}

	public Rewired.PlayerController.MouseWheel get_wheel()
	{
		if (!base.initialized)
		{
			return null;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_wheel();
	}

	public Rewired.PlayerController.Button get_leftButton()
	{
		if (!base.initialized)
		{
			return null;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_leftButton();
	}

	public Rewired.PlayerController.Button get_rightButton()
	{
		if (!base.initialized)
		{
			return null;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_rightButton();
	}

	public Rewired.PlayerController.Button get_middleButton()
	{
		if (!base.initialized)
		{
			return null;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_middleButton();
	}

	public float get_pointerSpeed()
	{
		if (!base.initialized)
		{
			return _pointerSpeed;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_pointerSpeed();
	}

	public void set_pointerSpeed(float value)
	{
		if (value < 0f)
		{
			value = 0f;
		}
		_pointerSpeed = value;
		if (base.initialized)
		{
			HvRHMSrnOGXvBZagcnZuBOApnAnl().set_pointerSpeed(value);
			_pointerSpeed = HvRHMSrnOGXvBZagcnZuBOApnAnl().get_pointerSpeed();
		}
	}

	public bool get_useHardwarePointerPosition()
	{
		if (!base.initialized)
		{
			return _useHardwarePointerPosition;
		}
		return HvRHMSrnOGXvBZagcnZuBOApnAnl().get_useHardwarePointerPosition();
	}

	public void set_useHardwarePointerPosition(bool value)
	{
		_useHardwarePointerPosition = value;
		if (base.initialized)
		{
			HvRHMSrnOGXvBZagcnZuBOApnAnl().set_useHardwarePointerPosition(value);
		}
	}

	public void add_ScreenPositionChangedEvent(Action<Vector2> value)
	{
		if (base.initialized)
		{
			HvRHMSrnOGXvBZagcnZuBOApnAnl().add_ScreenPositionChangedEvent(value);
		}
	}

	public void remove_ScreenPositionChangedEvent(Action<Vector2> value)
	{
		if (base.initialized)
		{
			HvRHMSrnOGXvBZagcnZuBOApnAnl().remove_ScreenPositionChangedEvent(value);
		}
	}

	protected override void OnValidated()
	{
		base.OnValidated();
		set_defaultToCenter(_defaultToCenter);
		clampToMovementArea = _clampToMovementArea;
		set_movementArea(new ScreenRect(_movementArea.xMin, _movementArea.yMin, _movementArea.width, _movementArea.height));
		set_movementAreaUnit(_movementAreaUnit);
		set_pointerSpeed(_pointerSpeed);
		set_useHardwarePointerPosition(_useHardwarePointerPosition);
	}

	protected override void OnReset()
	{
		base.OnReset();
		_clampToMovementArea = true;
		_defaultToCenter = true;
		_pointerSpeed = 1f;
		_useHardwarePointerPosition = true;
		_movementArea = new Rect(0f, 0f, 1f, 1f);
		_movementAreaUnit = Rewired.PlayerMouse.MovementAreaUnit.Screen;
		_onScreenPositionChanged = new ScreenPositionChangedHandler();
	}

	protected override Rewired.PlayerController CreateSource(object args)
	{
		IList<ElementInfo> list = args as IList<ElementInfo>;
		if (list == null || list.Count == 0)
		{
			Logger.LogWarning("Invalid element information. Did you configure elements in the inspector? Using defaults.");
			list = SEVccEdWkRTDVndXbfgozYMdgZPrA();
		}
		List<Rewired.PlayerController.Element.Definition> list2 = new List<Rewired.PlayerController.Element.Definition>(list.Count);
		foreach (ElementInfo item in list)
		{
			list2.Add(item.ToDefinition());
		}
		return Rewired.PlayerMouse.Factory.Create(new Rewired.PlayerMouse.Definition
		{
			playerId = get_playerId(),
			elements = list2,
			defaultToCenter = _defaultToCenter,
			clampToMovementArea = _clampToMovementArea,
			movementArea = new ScreenRect(_movementArea.xMin, _movementArea.yMin, _movementArea.width, _movementArea.height),
			movementAreaUnit = _movementAreaUnit,
			pointerSpeed = _pointerSpeed,
			useHardwarePointerPosition = _useHardwarePointerPosition
		});
	}

	protected override void Deinitialize()
	{
		base.Deinitialize();
	}

	protected override void Subscribe()
	{
		base.Subscribe();
		if (HvRHMSrnOGXvBZagcnZuBOApnAnl() != null)
		{
			HvRHMSrnOGXvBZagcnZuBOApnAnl().add_ScreenPositionChangedEvent(gRIYYpNShOdQApFMdchvBplRSbed);
		}
	}

	protected override void Unsubscribe()
	{
		base.Unsubscribe();
		if (HvRHMSrnOGXvBZagcnZuBOApnAnl() != null)
		{
			HvRHMSrnOGXvBZagcnZuBOApnAnl().remove_ScreenPositionChangedEvent(gRIYYpNShOdQApFMdchvBplRSbed);
		}
	}

	internal List<ElementInfo> zxIdMbBvrOozjcERHNHBDRvFBSzUb()
	{
		List<ElementInfo> list = new List<ElementInfo>();
		list.Add(new ElementInfo
		{
			name = "Movement",
			elementType = Rewired.PlayerController.Element.Type.MouseAxis2D,
			elements = new ElementWithSourceInfo[2]
			{
				new ElementWithSourceInfo
				{
					name = "Horizontal",
					elementType = Rewired.PlayerController.Element.TypeWithSource.MouseAxis,
					coordinateMode = AxisCoordinateMode.Relative,
					absoluteSourceSensitivity = 600f
				},
				new ElementWithSourceInfo
				{
					name = "Vertical",
					elementType = Rewired.PlayerController.Element.TypeWithSource.MouseAxis,
					coordinateMode = AxisCoordinateMode.Relative,
					absoluteSourceSensitivity = 600f
				}
			}
		});
		list.Add(new ElementInfo
		{
			name = "Wheel",
			elementType = Rewired.PlayerController.Element.Type.MouseWheel,
			elements = new ElementWithSourceInfo[2]
			{
				new ElementWithSourceInfo
				{
					name = "Wheel Horizontal",
					elementType = Rewired.PlayerController.Element.TypeWithSource.MouseWheelAxis,
					coordinateMode = AxisCoordinateMode.Relative
				},
				new ElementWithSourceInfo
				{
					name = "Wheel Vertical",
					elementType = Rewired.PlayerController.Element.TypeWithSource.MouseWheelAxis,
					coordinateMode = AxisCoordinateMode.Relative
				}
			}
		});
		list.Add(new ElementInfo
		{
			elements = new ElementWithSourceInfo[1]
			{
				new ElementWithSourceInfo
				{
					name = "Left Button",
					elementType = Rewired.PlayerController.Element.TypeWithSource.Button
				}
			}
		});
		list.Add(new ElementInfo
		{
			elements = new ElementWithSourceInfo[1]
			{
				new ElementWithSourceInfo
				{
					name = "Right Button",
					elementType = Rewired.PlayerController.Element.TypeWithSource.Button
				}
			}
		});
		list.Add(new ElementInfo
		{
			elements = new ElementWithSourceInfo[1]
			{
				new ElementWithSourceInfo
				{
					name = "Middle Button",
					elementType = Rewired.PlayerController.Element.TypeWithSource.Button
				}
			}
		});
		return list;
	}

	private void gRIYYpNShOdQApFMdchvBplRSbed(Vector2 P_0)
	{
		if (!UnityTools.IsActiveAndEnabled(this))
		{
			return;
		}
		try
		{
			if (_onScreenPositionChanged != null)
			{
				_onScreenPositionChanged.Invoke(P_0);
			}
		}
		catch (Exception ex)
		{
			Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
		}
	}

	bool IMouseInputSource.GetButtonDown(int button)
	{
		if (!base.initialized)
		{
			return false;
		}
		return ((IMouseInputSource)HvRHMSrnOGXvBZagcnZuBOApnAnl()).GetButtonDown(button);
	}

	bool IMouseInputSource.GetButtonUp(int button)
	{
		if (!base.initialized)
		{
			return false;
		}
		return ((IMouseInputSource)HvRHMSrnOGXvBZagcnZuBOApnAnl()).GetButtonUp(button);
	}

	bool IMouseInputSource.GetButton(int button)
	{
		if (!base.initialized)
		{
			return false;
		}
		return ((IMouseInputSource)HvRHMSrnOGXvBZagcnZuBOApnAnl()).GetButton(button);
	}
}
