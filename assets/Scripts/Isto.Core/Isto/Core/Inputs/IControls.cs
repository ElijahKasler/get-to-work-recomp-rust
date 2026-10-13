using UnityEngine;

namespace Isto.Core.Inputs;

public interface IControls
{
	string GetAxisName(Controls.MovementAxis axis);

	string GetButtonName(UserActions action);

	float GetAxis(Controls.MovementAxis axis);

	float GetRawAxis(Controls.MovementAxis axis);

	bool GetButton(UserActions action, bool ignoreMouse = false);

	bool GetButtonDown(UserActions action);

	bool GetButtonUp(UserActions action);

	bool GetButtonTap(UserActions action, bool ignoreKeyboard = false);

	bool GetDoubleClick(UserActions action);

	bool GetAnyButton();

	bool GetStartGameAction();

	bool GetResetMappingsButtonDown();

	Vector3 GetPointerPositionOnGround();

	bool GetPointerOverUI();

	Vector2 GetPointerPosition();

	Vector3 GetCanvasMousePosition(Canvas parent);

	Ray GetRayToPointerPosition();

	Sprite GetIconForAction(UserActions action);

	void SetControlMode(Controls.Mode mode);

	void DisableControls(float time);

	void EnableControls();

	Controls.Mode GetControlMode();

	void SetInputDevice(Controls.InputDevice input);

	bool UsingJoystick();

	Controls.InputDevice GetLastInputDevice();

	void VibrateController(Controls.VibrationMode mode);

	bool IsMouseOverUIRectTransform(RectTransform rectTransform);
}
