using System.Collections.Generic;
using I2.Loc;
using Isto.Core.Localization;
using Isto.Core.StateMachine;
using Isto.Core.UI;
using UnityEngine;

namespace Isto.GTW.UI;

public class GTWUISettingsGameplaySubState : UISettingsGameplaySubState
{
	[Header("GTW Specifics")]
	[SerializeField]
	private UISettingsOptionSlider _cameraSensitivitySlider;

	[SerializeField]
	private UISettingsOptionToggle _cameraInvertHorizontalToggle;

	[SerializeField]
	private UISettingsOptionToggle _cameraInvertVerticalToggle;

	[SerializeField]
	private UISettingsOptionToggle _cameraHorizontalAutoRotationToggle;

	[SerializeField]
	private UISettingsOptionToggle _cameraVerticalAutoRotationToggle;

	[SerializeField]
	private UISettingsOptionSlider _cameraHorizontalAutoRotationSpeedSlider;

	[SerializeField]
	private UISettingsOptionSlider _cameraVerticalAutoRotationSpeedSlider;

	[SerializeField]
	private UISettingsOptionCarousel _speedUnitCarousel;

	[SerializeField]
	private UISettingsOptionToggle _motionSicknessDotButtonToggle;

	[SerializeField]
	private UISettingsOptionToggle _showRestartButtonToggle;

	[SerializeField]
	private UISettingsOptionToggle _showSaveBestTimesButtonToggle;

	[Header("Unit Localization")]
	[SerializeField]
	private LocalizedString _unitKph;

	[SerializeField]
	private LocalizedString _unitMph;

	[SerializeField]
	private LocalizedString _unitMach;

	public static readonly string CAMERA_SENSITIVITY_PLAYER_PREFS_KEY = "CameraSensitivitySetting";

	public static readonly string CAMERA_INVERT_HORIZONTAL_PREFS_KEY = "CameraInvertHorizontalSetting";

	public static readonly string CAMERA_INVERT_VERTICAL_PREFS_KEY = "CameraInvertVerticalSetting";

	public static readonly string CAMERA_HORIZONTAL_AUTO_ROTATION_PLAYER_PREFS_KEY = "CameraHorizontalAutoRotationSetting";

	public static readonly string CAMERA_VERTICAL_AUTO_ROTATION_PLAYER_PREFS_KEY = "CameraVerticalAutoRotationSetting";

	public static readonly string CAMERA_HORIZONTAL_AUTO_ROTATION_SPEED_PLAYER_PREFS_KEY = "CameraHorizontalAutoRotationSpeedSetting";

	public static readonly string CAMERA_VERTICAL_AUTO_ROTATION_SPEED_PLAYER_PREFS_KEY = "CameraVerticalAutoRotationSpeedSetting";

	public static readonly string SPEED_UNIT_PLAYER_PREFS_KEY = "SpeedUnitSetting";

	public static readonly string MOTION_SICKNESS_DOT_PREFS_KEY = "MotionSicknessDotButtonSetting";

	public static readonly string SHOW_RESTART_BUTTON_PREFS_KEY = "ShowRestartButtonSetting";

	public static readonly string SHOW_SAVE_PB_BUTTON_PREFS_KEY = "ShowSavePBSetting";

	public static readonly float DEFAULT_CAMERA_SENSITIVITY = 0.5f;

	public static readonly int DEFAULT_CAMERA_INVERT_HORIZONTAL = 0;

	public static readonly int DEFAULT_CAMERA_INVERT_VERTICAL = 0;

	public static readonly int DEFAULT_CAMERA_HORIZONTAL_AUTO_ROTATION = 1;

	public static readonly int DEFAULT_CAMERA_VERTICAL_AUTO_ROTATION = 1;

	public static readonly float DEFAULT_CAMERA_HORIZONTAL_AUTO_ROTATION_SPEED = 1f;

	public static readonly float DEFAULT_CAMERA_VERTICAL_AUTO_ROTATION_SPEED = 1f;

	public static readonly int DEFAULT_SPEED_UNIT = 0;

	public static readonly int DEFAULT_MOTION_SICKNESS_DOT_BUTTON = 0;

	public static readonly int DEFAULT_SHOW_RESTART_BUTTON = 0;

	public static readonly int DEFAULT_SHOW_SAVE_PB_BUTTON = 0;

	private List<LocExpression> _currentSpeedUnitOptions = new List<LocExpression>();

	private float _previousCameraSensitivity;

	private bool _previousCameraInvertHorizontal;

	private bool _previousCameraInvertVertical;

	private bool _previousCameraHorizontalAutoRotation;

	private bool _previousCameraVerticalAutoRotation;

	private float _previousCameraHorizontalAutoRotationSpeed;

	private float _previousCameraVerticalAutoRotationSpeed;

	private int _previousSpeedUnit;

	private bool _previousMotionSicknessDotButton;

	private bool _previousShowRestartButton;

	private bool _previousShowSaveBestsButton;

	public override bool HasChanges
	{
		get
		{
			if (!base.HasChanges)
			{
				return IsGTWGameplaySettingsChanged();
			}
			return true;
		}
	}

	protected override void Start()
	{
		base.Start();
		InitializeCameraSensitivitySlider();
		InitializeCameraInvertHorizontal();
		InitializeCameraInvertVertical();
		InitializeCameraHorizontalAutoRotationToggle();
		InitializeCameraVerticalAutoRotationToggle();
		InitializeCameraHorizontalAutoRotationSpeedSlider();
		InitializeCameraVerticalAutoRotationSpeedSlider();
		InitializeSpeedUnitCarousel();
		InitializeMotionSicknessDotButtonToggle();
		InitializeShowRestartButtonToggle();
		InitializeShowSaveBestsButtonToggle();
	}

	public override void Enter(MonoStateMachine controller)
	{
		base.Enter(controller);
	}

	protected override void RegisterEvents()
	{
		base.RegisterEvents();
		_cameraSensitivitySlider.OnValueChangedPercentage += CameraSensitivitySlider_OnValueChanged;
		_cameraInvertHorizontalToggle.OnValueChanged += CameraInvertHorizontalToggleOnValueChanged;
		_cameraInvertVerticalToggle.OnValueChanged += CameraInvertVerticalToggleOnValueChanged;
		_cameraHorizontalAutoRotationToggle.OnValueChanged += CameraHorizontalAutoRotationToggleOnValueChanged;
		_cameraVerticalAutoRotationToggle.OnValueChanged += CameraVerticalAutoRotationToggleOnValueChanged;
		_cameraHorizontalAutoRotationSpeedSlider.OnValueChangedPercentage += CameraHorizontalAutoRotationSpeedSlider_OnValueChanged;
		_cameraVerticalAutoRotationSpeedSlider.OnValueChangedPercentage += CameraVerticalAutoRotationSpeedSlider_OnValueChanged;
		_speedUnitCarousel.OnValueChanged += SpeedUnitCarousel_OnValueChanged;
		_motionSicknessDotButtonToggle.OnValueChanged += MotionSicknessDotButtonToggle_OnValueChanged;
		_showRestartButtonToggle.OnValueChanged += ShowRestartButtonToggle_OnValueChanged;
		_showSaveBestTimesButtonToggle.OnValueChanged += ShowSaveBestsToggle_OnValueChanged;
	}

	protected override void UnregisterEvents()
	{
		base.UnregisterEvents();
		_cameraSensitivitySlider.OnValueChangedPercentage -= CameraSensitivitySlider_OnValueChanged;
		_cameraInvertHorizontalToggle.OnValueChanged -= CameraInvertHorizontalToggleOnValueChanged;
		_cameraInvertVerticalToggle.OnValueChanged -= CameraInvertVerticalToggleOnValueChanged;
		_cameraHorizontalAutoRotationToggle.OnValueChanged -= CameraHorizontalAutoRotationToggleOnValueChanged;
		_cameraVerticalAutoRotationToggle.OnValueChanged -= CameraVerticalAutoRotationToggleOnValueChanged;
		_cameraHorizontalAutoRotationSpeedSlider.OnValueChangedPercentage -= CameraHorizontalAutoRotationSpeedSlider_OnValueChanged;
		_cameraVerticalAutoRotationSpeedSlider.OnValueChangedPercentage -= CameraVerticalAutoRotationSpeedSlider_OnValueChanged;
		_speedUnitCarousel.OnValueChanged -= SpeedUnitCarousel_OnValueChanged;
		_motionSicknessDotButtonToggle.OnValueChanged -= MotionSicknessDotButtonToggle_OnValueChanged;
		_showRestartButtonToggle.OnValueChanged -= ShowRestartButtonToggle_OnValueChanged;
		_showSaveBestTimesButtonToggle.OnValueChanged -= ShowSaveBestsToggle_OnValueChanged;
	}

	private void CameraSensitivitySlider_OnValueChanged(float updatedCameraSensitivity)
	{
		PlayerPrefs.SetFloat(CAMERA_SENSITIVITY_PLAYER_PREFS_KEY, Mathf.Clamp01(updatedCameraSensitivity));
		bool dirtyFlag = !Mathf.Approximately(_previousCameraSensitivity, updatedCameraSensitivity);
		_cameraSensitivitySlider.SetDirtyFlag(dirtyFlag);
	}

	private void CameraInvertHorizontalToggleOnValueChanged(bool isInvertHorizontalEnabled)
	{
		int value = (isInvertHorizontalEnabled ? 1 : 0);
		PlayerPrefs.SetInt(CAMERA_INVERT_HORIZONTAL_PREFS_KEY, value);
		bool dirtyFlag = _previousCameraInvertHorizontal != isInvertHorizontalEnabled;
		_cameraInvertHorizontalToggle.SetDirtyFlag(dirtyFlag);
	}

	private void CameraInvertVerticalToggleOnValueChanged(bool isInvertVerticalEnabled)
	{
		int value = (isInvertVerticalEnabled ? 1 : 0);
		PlayerPrefs.SetInt(CAMERA_INVERT_VERTICAL_PREFS_KEY, value);
		bool dirtyFlag = _previousCameraInvertVertical != isInvertVerticalEnabled;
		_cameraInvertVerticalToggle.SetDirtyFlag(dirtyFlag);
	}

	private void CameraHorizontalAutoRotationToggleOnValueChanged(bool isAutoRotationEnabled)
	{
		int value = (isAutoRotationEnabled ? 1 : 0);
		PlayerPrefs.SetInt(CAMERA_HORIZONTAL_AUTO_ROTATION_PLAYER_PREFS_KEY, value);
		bool dirtyFlag = _previousCameraHorizontalAutoRotation != isAutoRotationEnabled;
		_cameraHorizontalAutoRotationToggle.SetDirtyFlag(dirtyFlag);
	}

	private void CameraVerticalAutoRotationToggleOnValueChanged(bool isAutoRotationEnabled)
	{
		int value = (isAutoRotationEnabled ? 1 : 0);
		PlayerPrefs.SetInt(CAMERA_VERTICAL_AUTO_ROTATION_PLAYER_PREFS_KEY, value);
		bool dirtyFlag = _previousCameraVerticalAutoRotation != isAutoRotationEnabled;
		_cameraVerticalAutoRotationToggle.SetDirtyFlag(dirtyFlag);
	}

	private void CameraHorizontalAutoRotationSpeedSlider_OnValueChanged(float updatedCameraRotationSpeed)
	{
		PlayerPrefs.SetFloat(CAMERA_HORIZONTAL_AUTO_ROTATION_SPEED_PLAYER_PREFS_KEY, Mathf.Clamp01(updatedCameraRotationSpeed));
		bool dirtyFlag = !Mathf.Approximately(_previousCameraHorizontalAutoRotationSpeed, updatedCameraRotationSpeed);
		_cameraHorizontalAutoRotationSpeedSlider.SetDirtyFlag(dirtyFlag);
	}

	private void CameraVerticalAutoRotationSpeedSlider_OnValueChanged(float updatedCameraRotationSpeed)
	{
		PlayerPrefs.SetFloat(CAMERA_VERTICAL_AUTO_ROTATION_SPEED_PLAYER_PREFS_KEY, Mathf.Clamp01(updatedCameraRotationSpeed));
		bool dirtyFlag = !Mathf.Approximately(_previousCameraVerticalAutoRotationSpeed, updatedCameraRotationSpeed);
		_cameraVerticalAutoRotationSpeedSlider.SetDirtyFlag(dirtyFlag);
	}

	private void SpeedUnitCarousel_OnValueChanged(LocExpression newSpeedUnit)
	{
		int num = _currentSpeedUnitOptions.IndexOf(newSpeedUnit);
		PlayerPrefs.SetInt(SPEED_UNIT_PLAYER_PREFS_KEY, num);
		_speedUnitCarousel.SetDirtyFlag(_previousSpeedUnit != num);
	}

	private void MotionSicknessDotButtonToggle_OnValueChanged(bool showButton)
	{
		int value = (showButton ? 1 : 0);
		PlayerPrefs.SetInt(MOTION_SICKNESS_DOT_PREFS_KEY, value);
		bool dirtyFlag = _previousMotionSicknessDotButton != showButton;
		_motionSicknessDotButtonToggle.SetDirtyFlag(dirtyFlag);
	}

	private void ShowRestartButtonToggle_OnValueChanged(bool showButton)
	{
		int value = (showButton ? 1 : 0);
		PlayerPrefs.SetInt(SHOW_RESTART_BUTTON_PREFS_KEY, value);
		bool dirtyFlag = _previousShowRestartButton != showButton;
		_showRestartButtonToggle.SetDirtyFlag(dirtyFlag);
	}

	private void ShowSaveBestsToggle_OnValueChanged(bool showButton)
	{
		int value = (showButton ? 1 : 0);
		PlayerPrefs.SetInt(SHOW_SAVE_PB_BUTTON_PREFS_KEY, value);
		bool dirtyFlag = _previousShowSaveBestsButton != showButton;
		_showSaveBestTimesButtonToggle.SetDirtyFlag(dirtyFlag);
	}

	public override void ApplySettingsChanges()
	{
		base.ApplySettingsChanges();
		_previousCameraSensitivity = PlayerPrefs.GetFloat(CAMERA_SENSITIVITY_PLAYER_PREFS_KEY, DEFAULT_CAMERA_SENSITIVITY);
		_previousCameraInvertHorizontal = PlayerPrefs.GetInt(CAMERA_INVERT_HORIZONTAL_PREFS_KEY, DEFAULT_CAMERA_INVERT_HORIZONTAL) == 1;
		_previousCameraInvertVertical = PlayerPrefs.GetInt(CAMERA_INVERT_VERTICAL_PREFS_KEY, DEFAULT_CAMERA_INVERT_VERTICAL) == 1;
		_previousCameraHorizontalAutoRotation = PlayerPrefs.GetInt(CAMERA_HORIZONTAL_AUTO_ROTATION_PLAYER_PREFS_KEY, DEFAULT_CAMERA_HORIZONTAL_AUTO_ROTATION) == 1;
		_previousCameraVerticalAutoRotation = PlayerPrefs.GetInt(CAMERA_VERTICAL_AUTO_ROTATION_PLAYER_PREFS_KEY, DEFAULT_CAMERA_VERTICAL_AUTO_ROTATION) == 1;
		_previousCameraHorizontalAutoRotationSpeed = PlayerPrefs.GetFloat(CAMERA_HORIZONTAL_AUTO_ROTATION_SPEED_PLAYER_PREFS_KEY, DEFAULT_CAMERA_HORIZONTAL_AUTO_ROTATION_SPEED);
		_previousCameraVerticalAutoRotationSpeed = PlayerPrefs.GetFloat(CAMERA_VERTICAL_AUTO_ROTATION_SPEED_PLAYER_PREFS_KEY, DEFAULT_CAMERA_VERTICAL_AUTO_ROTATION_SPEED);
		_previousSpeedUnit = PlayerPrefs.GetInt(SPEED_UNIT_PLAYER_PREFS_KEY, DEFAULT_SPEED_UNIT);
		_previousMotionSicknessDotButton = PlayerPrefs.GetInt(MOTION_SICKNESS_DOT_PREFS_KEY, DEFAULT_MOTION_SICKNESS_DOT_BUTTON) == 1;
		_previousShowRestartButton = PlayerPrefs.GetInt(SHOW_RESTART_BUTTON_PREFS_KEY, DEFAULT_SHOW_RESTART_BUTTON) == 1;
		_previousShowSaveBestsButton = PlayerPrefs.GetInt(SHOW_SAVE_PB_BUTTON_PREFS_KEY, DEFAULT_SHOW_SAVE_PB_BUTTON) == 1;
	}

	public override void DiscardSettingsChanges()
	{
		SetCameraSensitivity(_previousCameraSensitivity);
		SetCameraInvertHorizontal(_previousCameraInvertHorizontal);
		SetCameraInvertVertical(_previousCameraInvertVertical);
		SetCameraHorizontalAutoRotation(_previousCameraHorizontalAutoRotation);
		SetCameraVerticalAutoRotation(_previousCameraVerticalAutoRotation);
		SetCameraHorizontalAutoRotationSpeed(_previousCameraHorizontalAutoRotationSpeed);
		SetCameraVerticalAutoRotationSpeed(_previousCameraVerticalAutoRotationSpeed);
		SetSpeedUnit(_previousSpeedUnit);
		SetMotionSicknessDotButtonValue(_previousMotionSicknessDotButton);
		SetShowRestartButtonValue(_previousShowRestartButton);
		SetShowSaveBestsButtonValue(_previousShowSaveBestsButton);
		SetShowRestartButtonValue(_previousShowRestartButton);
		SetShowSaveBestsButtonValue(_previousShowSaveBestsButton);
		base.DiscardSettingsChanges();
	}

	public override void ResetToDefaults()
	{
		SetCameraSensitivity(DEFAULT_CAMERA_SENSITIVITY);
		SetCameraInvertHorizontal(DEFAULT_CAMERA_INVERT_HORIZONTAL == 1);
		SetCameraInvertVertical(DEFAULT_CAMERA_INVERT_VERTICAL == 1);
		SetCameraHorizontalAutoRotation(DEFAULT_CAMERA_HORIZONTAL_AUTO_ROTATION == 1);
		SetCameraVerticalAutoRotation(DEFAULT_CAMERA_VERTICAL_AUTO_ROTATION == 1);
		SetCameraHorizontalAutoRotationSpeed(DEFAULT_CAMERA_HORIZONTAL_AUTO_ROTATION_SPEED);
		SetCameraVerticalAutoRotationSpeed(DEFAULT_CAMERA_VERTICAL_AUTO_ROTATION_SPEED);
		SetSpeedUnit(DEFAULT_SPEED_UNIT);
		SetMotionSicknessDotButtonValue(DEFAULT_MOTION_SICKNESS_DOT_BUTTON == 1);
		SetShowRestartButtonValue(DEFAULT_SHOW_RESTART_BUTTON == 1);
		SetShowSaveBestsButtonValue(DEFAULT_SHOW_SAVE_PB_BUTTON == 1);
		base.ResetToDefaults();
	}

	private void SetCameraSensitivity(float newCameraSensitivity)
	{
		PlayerPrefs.SetFloat(CAMERA_SENSITIVITY_PLAYER_PREFS_KEY, newCameraSensitivity);
		_cameraSensitivitySlider.SetSliderAmountPercentage(newCameraSensitivity);
	}

	private void SetCameraInvertHorizontal(bool isCameraInvertHorizontal)
	{
		PlayerPrefs.SetInt(CAMERA_INVERT_HORIZONTAL_PREFS_KEY, isCameraInvertHorizontal ? 1 : 0);
		_cameraInvertHorizontalToggle.SetToggleValueNoNotify(isCameraInvertHorizontal);
	}

	private void SetCameraInvertVertical(bool isCameraInvertVertical)
	{
		PlayerPrefs.SetInt(CAMERA_INVERT_VERTICAL_PREFS_KEY, isCameraInvertVertical ? 1 : 0);
		_cameraInvertVerticalToggle.SetToggleValueNoNotify(isCameraInvertVertical);
	}

	private void SetCameraHorizontalAutoRotation(bool isAutoRotationEnabled)
	{
		PlayerPrefs.SetInt(CAMERA_HORIZONTAL_AUTO_ROTATION_PLAYER_PREFS_KEY, isAutoRotationEnabled ? 1 : 0);
		_cameraHorizontalAutoRotationToggle.SetToggleValueNoNotify(isAutoRotationEnabled);
	}

	private void SetCameraVerticalAutoRotation(bool isAutoRotationEnabled)
	{
		PlayerPrefs.SetInt(CAMERA_VERTICAL_AUTO_ROTATION_PLAYER_PREFS_KEY, isAutoRotationEnabled ? 1 : 0);
		_cameraVerticalAutoRotationToggle.SetToggleValueNoNotify(isAutoRotationEnabled);
	}

	private void SetCameraHorizontalAutoRotationSpeed(float newCameraAutoRotationSpeed)
	{
		PlayerPrefs.SetFloat(CAMERA_HORIZONTAL_AUTO_ROTATION_SPEED_PLAYER_PREFS_KEY, newCameraAutoRotationSpeed);
		_cameraHorizontalAutoRotationSpeedSlider.SetSliderAmountPercentage(newCameraAutoRotationSpeed);
	}

	private void SetCameraVerticalAutoRotationSpeed(float newCameraAutoRotationSpeed)
	{
		PlayerPrefs.SetFloat(CAMERA_VERTICAL_AUTO_ROTATION_SPEED_PLAYER_PREFS_KEY, newCameraAutoRotationSpeed);
		_cameraVerticalAutoRotationSpeedSlider.SetSliderAmountPercentage(newCameraAutoRotationSpeed);
	}

	private void SetSpeedUnit(int newSpeedUnitIndex)
	{
		PlayerPrefs.SetInt(SPEED_UNIT_PLAYER_PREFS_KEY, newSpeedUnitIndex);
		_speedUnitCarousel.SetCarouselList(_currentSpeedUnitOptions, _currentSpeedUnitOptions[newSpeedUnitIndex]);
	}

	private void SetMotionSicknessDotButtonValue(bool value)
	{
		PlayerPrefs.SetInt(MOTION_SICKNESS_DOT_PREFS_KEY, value ? 1 : 0);
		_motionSicknessDotButtonToggle.SetToggleValueNoNotify(value);
	}

	private void SetShowRestartButtonValue(bool value)
	{
		PlayerPrefs.SetInt(SHOW_RESTART_BUTTON_PREFS_KEY, value ? 1 : 0);
		_showRestartButtonToggle.SetToggleValueNoNotify(value);
	}

	private void SetShowSaveBestsButtonValue(bool value)
	{
		PlayerPrefs.SetInt(SHOW_SAVE_PB_BUTTON_PREFS_KEY, value ? 1 : 0);
		_showSaveBestTimesButtonToggle.SetToggleValueNoNotify(value);
	}

	private void InitializeCameraHorizontalAutoRotationToggle()
	{
		bool toggleValue = (_previousCameraHorizontalAutoRotation = PlayerPrefs.GetInt(CAMERA_HORIZONTAL_AUTO_ROTATION_PLAYER_PREFS_KEY, DEFAULT_CAMERA_HORIZONTAL_AUTO_ROTATION) == 1);
		_cameraHorizontalAutoRotationToggle.SetToggleValue(toggleValue);
	}

	private void InitializeCameraVerticalAutoRotationToggle()
	{
		bool toggleValue = (_previousCameraVerticalAutoRotation = PlayerPrefs.GetInt(CAMERA_VERTICAL_AUTO_ROTATION_PLAYER_PREFS_KEY, DEFAULT_CAMERA_VERTICAL_AUTO_ROTATION) == 1);
		_cameraVerticalAutoRotationToggle.SetToggleValue(toggleValue);
	}

	private void InitializeCameraHorizontalAutoRotationSpeedSlider()
	{
		float sliderAmountPercentage = (_previousCameraHorizontalAutoRotationSpeed = PlayerPrefs.GetFloat(CAMERA_HORIZONTAL_AUTO_ROTATION_SPEED_PLAYER_PREFS_KEY, DEFAULT_CAMERA_HORIZONTAL_AUTO_ROTATION_SPEED));
		_cameraHorizontalAutoRotationSpeedSlider.SetSliderAmountPercentage(sliderAmountPercentage);
	}

	private void InitializeCameraVerticalAutoRotationSpeedSlider()
	{
		float sliderAmountPercentage = (_previousCameraVerticalAutoRotationSpeed = PlayerPrefs.GetFloat(CAMERA_VERTICAL_AUTO_ROTATION_SPEED_PLAYER_PREFS_KEY, DEFAULT_CAMERA_VERTICAL_AUTO_ROTATION_SPEED));
		_cameraVerticalAutoRotationSpeedSlider.SetSliderAmountPercentage(sliderAmountPercentage);
	}

	private void InitializeCameraSensitivitySlider()
	{
		float sliderAmountPercentage = (_previousCameraSensitivity = PlayerPrefs.GetFloat(CAMERA_SENSITIVITY_PLAYER_PREFS_KEY, DEFAULT_CAMERA_SENSITIVITY));
		_cameraSensitivitySlider.SetSliderAmountPercentage(sliderAmountPercentage);
	}

	private void InitializeCameraInvertHorizontal()
	{
		bool toggleValue = (_previousCameraInvertHorizontal = PlayerPrefs.GetInt(CAMERA_INVERT_HORIZONTAL_PREFS_KEY, DEFAULT_CAMERA_INVERT_HORIZONTAL) == 1);
		_cameraInvertHorizontalToggle.SetToggleValue(toggleValue);
	}

	private void InitializeCameraInvertVertical()
	{
		bool toggleValue = (_previousCameraInvertVertical = PlayerPrefs.GetInt(CAMERA_INVERT_VERTICAL_PREFS_KEY, DEFAULT_CAMERA_INVERT_VERTICAL) == 1);
		_cameraInvertVerticalToggle.SetToggleValue(toggleValue);
	}

	private void InitializeSpeedUnitCarousel()
	{
		int num = PlayerPrefs.GetInt(SPEED_UNIT_PLAYER_PREFS_KEY, DEFAULT_SPEED_UNIT);
		_currentSpeedUnitOptions = new List<LocExpression>();
		LocTerm locTerm = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _unitKph.mTerm);
		LocTerm locTerm2 = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _unitMph.mTerm);
		LocTerm locTerm3 = _localizedStringFactory.Create(LocTerm.LocalizationType.Localized, _unitMach.mTerm);
		_currentSpeedUnitOptions.Add(new SingleTermLocExpression(locTerm));
		_currentSpeedUnitOptions.Add(new SingleTermLocExpression(locTerm2));
		_currentSpeedUnitOptions.Add(new SingleTermLocExpression(locTerm3));
		_previousSpeedUnit = num;
		_speedUnitCarousel.SetCarouselList(_currentSpeedUnitOptions, _currentSpeedUnitOptions[num]);
	}

	private void InitializeMotionSicknessDotButtonToggle()
	{
		bool toggleValue = (_previousMotionSicknessDotButton = PlayerPrefs.GetInt(MOTION_SICKNESS_DOT_PREFS_KEY, DEFAULT_MOTION_SICKNESS_DOT_BUTTON) == 1);
		_motionSicknessDotButtonToggle.SetToggleValue(toggleValue);
	}

	private void InitializeShowRestartButtonToggle()
	{
		bool toggleValue = (_previousShowRestartButton = PlayerPrefs.GetInt(SHOW_RESTART_BUTTON_PREFS_KEY, DEFAULT_SHOW_RESTART_BUTTON) == 1);
		_showRestartButtonToggle.SetToggleValue(toggleValue);
	}

	private void InitializeShowSaveBestsButtonToggle()
	{
		bool toggleValue = (_previousShowSaveBestsButton = PlayerPrefs.GetInt(SHOW_SAVE_PB_BUTTON_PREFS_KEY, DEFAULT_SHOW_SAVE_PB_BUTTON) == 1);
		_showSaveBestTimesButtonToggle.SetToggleValue(toggleValue);
	}

	private bool IsGTWGameplaySettingsChanged()
	{
		float b = PlayerPrefs.GetFloat(CAMERA_SENSITIVITY_PLAYER_PREFS_KEY, DEFAULT_CAMERA_SENSITIVITY);
		bool flag = PlayerPrefs.GetInt(CAMERA_INVERT_HORIZONTAL_PREFS_KEY, DEFAULT_CAMERA_INVERT_HORIZONTAL) == 1;
		bool flag2 = PlayerPrefs.GetInt(CAMERA_INVERT_VERTICAL_PREFS_KEY, DEFAULT_CAMERA_INVERT_VERTICAL) == 1;
		bool flag3 = PlayerPrefs.GetInt(CAMERA_HORIZONTAL_AUTO_ROTATION_PLAYER_PREFS_KEY, DEFAULT_CAMERA_HORIZONTAL_AUTO_ROTATION) == 1;
		bool flag4 = PlayerPrefs.GetInt(CAMERA_VERTICAL_AUTO_ROTATION_PLAYER_PREFS_KEY, DEFAULT_CAMERA_VERTICAL_AUTO_ROTATION) == 1;
		float b2 = PlayerPrefs.GetFloat(CAMERA_HORIZONTAL_AUTO_ROTATION_SPEED_PLAYER_PREFS_KEY, DEFAULT_CAMERA_HORIZONTAL_AUTO_ROTATION_SPEED);
		float b3 = PlayerPrefs.GetFloat(CAMERA_VERTICAL_AUTO_ROTATION_SPEED_PLAYER_PREFS_KEY, DEFAULT_CAMERA_VERTICAL_AUTO_ROTATION_SPEED);
		int num = PlayerPrefs.GetInt(SPEED_UNIT_PLAYER_PREFS_KEY, DEFAULT_SPEED_UNIT);
		bool flag5 = PlayerPrefs.GetInt(SHOW_RESTART_BUTTON_PREFS_KEY, DEFAULT_SHOW_RESTART_BUTTON) == 1;
		bool flag6 = PlayerPrefs.GetInt(SHOW_SAVE_PB_BUTTON_PREFS_KEY, DEFAULT_SHOW_SAVE_PB_BUTTON) == 1;
		bool flag7 = PlayerPrefs.GetInt(MOTION_SICKNESS_DOT_PREFS_KEY, DEFAULT_MOTION_SICKNESS_DOT_BUTTON) == 1;
		bool num2 = !Mathf.Approximately(_previousCameraSensitivity, b);
		bool flag8 = _previousCameraInvertHorizontal != flag;
		bool flag9 = _previousCameraInvertVertical != flag2;
		bool flag10 = _previousCameraHorizontalAutoRotation != flag3;
		bool flag11 = _previousCameraVerticalAutoRotation != flag4;
		bool flag12 = !Mathf.Approximately(_previousCameraHorizontalAutoRotationSpeed, b2);
		bool flag13 = !Mathf.Approximately(_previousCameraVerticalAutoRotationSpeed, b3);
		bool flag14 = _previousSpeedUnit != num;
		bool flag15 = _previousShowRestartButton != flag5;
		bool flag16 = _previousShowSaveBestsButton != flag6;
		bool flag17 = _previousMotionSicknessDotButton != flag7;
		return num2 | flag8 | flag9 | flag10 | flag11 | flag12 | flag13 | flag14 | flag15 | flag16 | flag17;
	}
}
