using System;
using Isto.Core.Configuration;
using UnityEngine;
using Zenject;

namespace Isto.Core.Inputs;

public class ScriptedControls : MonoBehaviour, IControls
{
	public Controls.Mode currentMode;

	private ControllerGlyphs _glyphs;

	private Controls.InputDevice _lastInputDevice = Controls.InputDevice.Mouse;

	public Vector3 mouseGroundPosition;

	private UserActions _nextAction;

	[Inject]
	public void Inject(Settings settings, ControllerGlyphs glyphs)
	{
		_glyphs = glyphs;
	}

	public void DisableControls(float time)
	{
	}

	public void EnableControls()
	{
		throw new NotImplementedException();
	}

	public bool GetAnyButton()
	{
		return false;
	}

	public float GetAxis(Controls.MovementAxis axis)
	{
		return 0f;
	}

	public string GetAxisName(Controls.MovementAxis axis)
	{
		throw new NotImplementedException();
	}

	public bool GetButton(UserActions action, bool ignoreMouse = false)
	{
		return IsActionNext(action);
	}

	public bool GetButtonDown(UserActions action)
	{
		return IsActionNext(action);
	}

	public string GetButtonName(UserActions action)
	{
		throw new NotImplementedException();
	}

	public bool GetButtonTap(UserActions action, bool ignoreKeyboard = false)
	{
		return IsActionNext(action);
	}

	public bool GetButtonUp(UserActions action)
	{
		return IsActionNext(action);
	}

	public Vector3 GetCanvasMousePosition(Canvas parent)
	{
		throw new NotImplementedException();
	}

	public Controls.Mode GetControlMode()
	{
		return currentMode;
	}

	public bool GetDoubleClick(UserActions action)
	{
		throw new NotImplementedException();
	}

	public Sprite GetIconForAction(UserActions action)
	{
		return _glyphs.GetGlyph(action.ToString(), _lastInputDevice);
	}

	public Controls.InputDevice GetLastInputDevice()
	{
		return Controls.InputDevice.Keyboard;
	}

	public Vector2 GetPointerPosition()
	{
		return Vector2.zero;
	}

	public Vector3 GetPointerPositionOnGround()
	{
		return mouseGroundPosition;
	}

	public float GetRawAxis(Controls.MovementAxis axis)
	{
		return 0f;
	}

	public Ray GetRayToPointerPosition()
	{
		Vector3 position = Camera.main.transform.position;
		return new Ray(position, mouseGroundPosition - position);
	}

	public void SetControlMode(Controls.Mode mode)
	{
		currentMode = mode;
	}

	public void SetInputDevice(Controls.InputDevice input)
	{
		throw new NotImplementedException();
	}

	public bool UsingJoystick()
	{
		return false;
	}

	public void VibrateController(Controls.VibrationMode mode)
	{
	}

	public void SetNextAction(UserActions action)
	{
		_nextAction = action;
	}

	public void ClearAction()
	{
		_nextAction = UserActions.USEITEM;
	}

	private bool IsActionNext(UserActions action)
	{
		if (_nextAction == action)
		{
			return true;
		}
		return false;
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
