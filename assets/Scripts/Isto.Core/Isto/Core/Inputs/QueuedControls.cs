using System;
using System.Collections.Generic;
using Isto.Core.Beings;
using Rewired;
using UnityEngine;
using Zenject;

namespace Isto.Core.Inputs;

public class QueuedControls : MonoBehaviour, IControls
{
	public List<ControlInput> inputs;

	public float overrideMouseSearchRadius = 0.5f;

	private ControllerGlyphs _glyphs;

	private int _index;

	private bool _moveToNextInput;

	private Player _player;

	private Controls.Mode _currentMode;

	private float _nextActionTime;

	[Inject]
	public void Inject(ControllerGlyphs glyphs)
	{
		_glyphs = glyphs;
	}

	public void Awake()
	{
		_index = 0;
		_moveToNextInput = false;
		inputs.Add(new ControlInput
		{
			action = UserActions.INTERACT,
			position = Vector3.zero,
			timeBeforeAction = float.PositiveInfinity
		});
		_player = ReInput.players.GetPlayer(0);
	}

	public void Start()
	{
		PlayerItemInteraction playerItemInteraction = UnityEngine.Object.FindObjectOfType<PlayerItemInteraction>();
		if (!playerItemInteraction.IsNullOrDestroyed())
		{
			playerItemInteraction.mouseSearchRadius = overrideMouseSearchRadius;
		}
		_nextActionTime = ((inputs.Count > 0) ? inputs[0].timeBeforeAction : Time.time);
	}

	public void LateUpdate()
	{
		if (_moveToNextInput)
		{
			_index++;
			_nextActionTime = Time.time + inputs[_index].timeBeforeAction;
			_moveToNextInput = false;
		}
	}

	public void DisableControls(float time)
	{
	}

	public void EnableControls()
	{
	}

	public bool GetAnyButton()
	{
		if (_nextActionTime >= inputs[_index].timeBeforeAction)
		{
			return true;
		}
		return false;
	}

	public float GetAxis(Controls.MovementAxis axis)
	{
		return 0f;
	}

	public string GetAxisName(Controls.MovementAxis axis)
	{
		return "";
	}

	public bool GetButton(UserActions action, bool ignoreMouse = false)
	{
		return IsCurrentAction(inputs[_index], action);
	}

	public bool GetButtonDown(UserActions action)
	{
		return IsCurrentAction(inputs[_index], action);
	}

	public string GetButtonName(UserActions action)
	{
		return "";
	}

	public bool GetButtonTap(UserActions action, bool ignoreKeyboard = false)
	{
		return IsCurrentAction(inputs[_index], action);
	}

	public bool GetButtonUp(UserActions action)
	{
		return IsCurrentAction(inputs[_index], action);
	}

	public Vector3 GetCanvasMousePosition(Canvas parent)
	{
		return Vector3.zero;
	}

	public Controls.Mode GetControlMode()
	{
		return _currentMode;
	}

	public bool GetDoubleClick(UserActions action)
	{
		return IsCurrentAction(inputs[_index], action);
	}

	public Sprite GetIconForAction(UserActions action)
	{
		return _glyphs.GetGlyph(action.ToString(), Controls.InputDevice.Mouse);
	}

	public Controls.InputDevice GetLastInputDevice()
	{
		return Controls.InputDevice.Mouse;
	}

	public Vector2 GetPointerPosition()
	{
		return Vector2.zero;
	}

	public Vector3 GetPointerPositionOnGround()
	{
		return inputs[_index].position;
	}

	public float GetRawAxis(Controls.MovementAxis axis)
	{
		return 0f;
	}

	public Ray GetRayToPointerPosition()
	{
		Vector3 pointerPositionOnGround = GetPointerPositionOnGround();
		Vector2 vector = Camera.main.WorldToScreenPoint(pointerPositionOnGround);
		return Camera.main.ScreenPointToRay(vector);
	}

	public void SetControlMode(Controls.Mode mode)
	{
		_currentMode = mode;
		switch (mode)
		{
		case Controls.Mode.Gameplay:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			_player.controllers.maps.SetMapsEnabled(state: true, "GameplayMouseKey");
			break;
		case Controls.Mode.UI:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			_player.controllers.maps.SetMapsEnabled(state: true, "UIMouseKey");
			break;
		case Controls.Mode.IntroUI:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			_player.controllers.maps.SetMapsEnabled(state: true, "UIJoy");
			_player.controllers.maps.SetMapsEnabled(state: true, "UIMouseKey");
			break;
		case Controls.Mode.Building:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			_player.controllers.maps.SetMapsEnabled(state: true, "GameplayBuildingMouseKey");
			break;
		case Controls.Mode.Dismantling:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			_player.controllers.maps.SetMapsEnabled(state: true, "GameplayDismantlingMouseKey");
			break;
		case Controls.Mode.DeveloperConsole:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			_player.controllers.maps.SetMapsEnabled(state: true, "DeveloperConsole");
			break;
		case Controls.Mode.BugReportingTool:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			_player.controllers.maps.SetMapsEnabled(state: true, "BugReportingTool");
			break;
		case Controls.Mode.Disabled:
			_player.controllers.maps.SetAllMapsEnabled(state: false);
			break;
		}
		Events.RaiseEvent("SettingsChanged");
	}

	public void SetInputDevice(Controls.InputDevice input)
	{
	}

	public bool UsingJoystick()
	{
		return false;
	}

	public void VibrateController(Controls.VibrationMode mode)
	{
	}

	private bool IsCurrentAction(ControlInput nextInput, UserActions action)
	{
		if (Time.time >= _nextActionTime && action == nextInput.action)
		{
			Debug.Log($"Performing action {nextInput.action} at {nextInput.position}");
			_moveToNextInput = true;
			return true;
		}
		return false;
	}

	public void OnDrawGizmos()
	{
		if (inputs == null || inputs.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < inputs.Count; i++)
		{
			Vector3 position = inputs[i].position;
			Gizmos.color = inputs[i].sphereColor;
			Gizmos.DrawSphere(position, 0.25f);
			new GUIStyle().normal.textColor = Color.yellow;
			if (i > 0)
			{
				Vector3 position2 = inputs[i - 1].position;
				Gizmos.DrawLine(position2, position);
				_ = position2 != position;
			}
		}
	}

	public bool IsMouseOverUIRectTransform(RectTransform rectTransform)
	{
		return true;
	}

	public bool GetPointerOverUI()
	{
		return false;
	}

	public bool GetStartGameAction()
	{
		throw new NotImplementedException();
	}

	public bool GetResetMappingsButtonDown()
	{
		throw new NotImplementedException();
	}
}
