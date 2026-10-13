using System;
using Cinemachine;
using Isto.Core.Game;
using Isto.Core.Inputs;
using Isto.GTW.Player;
using Isto.GTW.Player.States;
using Isto.GTW.SectionLoading;
using Isto.GTW.UI;
using PixelCrushers;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Camera;

[DefaultExecutionOrder(110)]
public class PlayerVirtualCameraController : MonoBehaviour
{
	[SerializeField]
	private PlayerController _playerController;

	[SerializeField]
	private CinemachineVirtualCamera _virtualCamera;

	[SerializeField]
	private Transform _aimTarget;

	[SerializeField]
	private Transform _followCam;

	[SerializeField]
	private Transform _followPosition;

	[Header("Settings")]
	[SerializeField]
	private PlayerVirtualCameraPreset _playerVirtualCameraPreset;

	private const float PLAYER_STOPPED_SPEED = 0.001f;

	private const float PLAYER_STOPPED_SPEED_PRECISE = 0.0001f;

	private static string CAMERA_HORIZONTAL_AUTO_ROTATION_PLAYER_PREFS_KEY = GTWUISettingsGameplaySubState.CAMERA_HORIZONTAL_AUTO_ROTATION_PLAYER_PREFS_KEY;

	private static string CAMERA_VERTICAL_AUTO_ROTATION_PLAYER_PREFS_KEY = GTWUISettingsGameplaySubState.CAMERA_VERTICAL_AUTO_ROTATION_PLAYER_PREFS_KEY;

	public static readonly string OCCLUSION_CULLING_DISABLED_EDITOR_PREF_KEY = "OcclusionCullingDisabled";

	private CustomCinemachineCollider _cinemachineCollider;

	private CinemachineTransposer _transposer;

	private Vector2 _cameraInput = Vector2.zero;

	private Vector3 _rawMovementInput = Vector3.zero;

	private bool _hasControllerInput;

	private bool _hasMouseInput;

	private Vector3 _cameraPositionOffset = Vector3.zero;

	private Vector3 _cameraPositionOffsetVelocity = Vector3.zero;

	private Vector3 _animatedCameraPositionOffset = Vector3.zero;

	private Vector3 _defaultCameraPositionDamping = Vector3.zero;

	private Vector3 _defaultCameraRotationDamping = Vector3.zero;

	private Vector3 _defaultMouseCameraPositionDamping = Vector3.zero;

	private Vector3 _currentCameraPositionDamping = Vector3.zero;

	private Vector3 _currentCameraRotationDamping = Vector3.zero;

	private Vector3 _dampingMultiplier = Vector3.one;

	private Vector3 _dampingMultiplierVel = Vector3.one;

	private Vector3 _camRotationEuler = Vector3.zero;

	private float _camVerticalTarget;

	private float _camVerticalVelocity;

	private Quaternion _tiltRotation = Quaternion.identity;

	private float _rotationInputBlockTimeLeft = -1f;

	private float _autoRotateResetTimeLeft = -1f;

	private float _reactionSpeed;

	private float _reactionSpeedVel;

	private Vector3 _cameraPlaneUp = Vector3.up;

	private Vector3 _cameraPlaneUpVel = Vector3.zero;

	private float _autoRotatedWeight = 1f;

	private float _autoRotateWeightVel;

	private float _currentVerticalWeight;

	private float _verticalWeightVel;

	private float _timeScaleFovIncrement;

	private float _timeScaleFovVelocity;

	private PlayerCameraOverride _playerCameraOverride;

	private PlayerCameraOverride.CameraOverride _cameraOverride;

	private float _currentCameraDistance = -1f;

	private LayerMask _defaultCameraColliderLayerMask;

	protected IControls _controls;

	protected CinemachineBrain _cinemachineBrain;

	private float _ragdollPositionTargetWeight;

	public Transform FollowPosition => _followPosition;

	public CinemachineVirtualCamera CVC => _virtualCamera;

	private static string CAMERA_SENSITIVITY_PLAYER_PREFS_KEY => GTWUISettingsGameplaySubState.CAMERA_SENSITIVITY_PLAYER_PREFS_KEY;

	private static string CAMERA_INVERT_HORIZONTAL_PREFS_KEY => GTWUISettingsGameplaySubState.CAMERA_INVERT_HORIZONTAL_PREFS_KEY;

	private static string CAMERA_INVERT_VERTICAL_PREFS_KEY => GTWUISettingsGameplaySubState.CAMERA_INVERT_VERTICAL_PREFS_KEY;

	public bool UsingController => _controls.UsingJoystick();

	public Transform AimTarget => _aimTarget;

	public Transform FollowCam => _followCam;

	public Vector2 CameraInput => _cameraInput;

	public bool HasControllerInput => _hasControllerInput;

	public bool HasMouseInput => _hasMouseInput;

	public float InputRotateSpeedMultiplier
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 200f;
			}
			return _playerVirtualCameraPreset.inputRotateSpeedMultiplier;
		}
	}

	public float MouseSensitivity
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 0.1f;
			}
			return _playerVirtualCameraPreset.mouseSensitivity;
		}
	}

	public bool AutoRotateEnabled
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return true;
			}
			return _playerVirtualCameraPreset.autoRotateEnabled;
		}
	}

	public bool AutoRotateEnabledDuringGrab
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return true;
			}
			return _playerVirtualCameraPreset.autoRotateEnabledDuringGrab;
		}
	}

	public float BaseAutoRotateGroundSpeed
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 3f;
			}
			return _playerVirtualCameraPreset.baseAutoRotateGroundSpeed;
		}
	}

	public float BaseAutoRotateAirSpeed
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 3f;
			}
			return _playerVirtualCameraPreset.baseAutoRotateAirSpeed;
		}
	}

	public AnimationCurve VerticalSpeedWeightCurve
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return AnimationCurve.Linear(0f, 1f, 1f, 1f);
			}
			return _playerVirtualCameraPreset.verticalSpeedWeightCurve;
		}
	}

	public AnimationCurve AutoRotatePlayerSpeedCurve
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return AnimationCurve.Linear(0f, 1f, 1f, 1f);
			}
			return _playerVirtualCameraPreset.autoRotatePlayerSpeedCurve;
		}
	}

	public AnimationCurve AutoRotateDampingPlayerSpeedCurve
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return AnimationCurve.Linear(0f, 1f, 1f, 1f);
			}
			return _playerVirtualCameraPreset.autoRotateDampingPlayerSpeedCurve;
		}
	}

	public float DampingVerticalReturnThreshold
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 10f;
			}
			return _playerVirtualCameraPreset.dampingVerticalReturnThreshold;
		}
	}

	public float TimeToTurnDampingBackOn
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 0.1f;
			}
			return _playerVirtualCameraPreset.timeToTurnDampingBackOn;
		}
	}

	public float MouseAutoRotateResetDelay
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 1f;
			}
			return _playerVirtualCameraPreset.mouseAutoRotateResetDelay;
		}
	}

	public float ControllerAutoRotateResetDelay
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 1f;
			}
			return _playerVirtualCameraPreset.controllerAutoRotateResetDelay;
		}
	}

	public float AutoRotateEnableTransitionTime
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 0.5f;
			}
			return _playerVirtualCameraPreset.autoRotateEnableTransitionTime;
		}
	}

	public float MinVerticalAngleLimit
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return -85f;
			}
			return _playerVirtualCameraPreset.minVerticalAngleLimit;
		}
	}

	public float MaxVerticalAngleLimit
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 85f;
			}
			return _playerVirtualCameraPreset.maxVerticalAngleLimit;
		}
	}

	public float Fov
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 60f;
			}
			return _playerVirtualCameraPreset.fov;
		}
	}

	public float SlowTimeFovIncrement => 20f;

	public float Distance
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 1f;
			}
			return _playerVirtualCameraPreset.distance;
		}
	}

	public float AimTargetHeight
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 0.5f;
			}
			return _playerVirtualCameraPreset.aimTargetHeight;
		}
	}

	public float FollowCamHeight
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 0.5f;
			}
			return _playerVirtualCameraPreset.followCamHeight;
		}
	}

	public float HorizontalTiltAngle
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 15f;
			}
			return _playerVirtualCameraPreset.horizontaltiltAngle;
		}
	}

	public float VerticalTiltAngle
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 15f;
			}
			return _playerVirtualCameraPreset.verticaltiltAngle;
		}
	}

	public float TiltResponsiveness
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 1f;
			}
			return _playerVirtualCameraPreset.tiltResponsiveness;
		}
	}

	public float EdgeGrabCameraOffset
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 0.1f;
			}
			return _playerVirtualCameraPreset.edgeGrabCameraOffset;
		}
	}

	public float TimeToReachEdgeGrabOffset
	{
		get
		{
			if (!(_playerVirtualCameraPreset != null))
			{
				return 0.5f;
			}
			return _playerVirtualCameraPreset.timeToReachEdgeGrabOffset;
		}
	}

	public Vector3 AnimatedCameraPositionOffset
	{
		get
		{
			return _animatedCameraPositionOffset;
		}
		set
		{
			_animatedCameraPositionOffset = value;
		}
	}

	public PlayerCameraOverride PlayerCameraOverride => _playerCameraOverride;

	public float CameraSensitivitySetting => PlayerPrefs.GetFloat(CAMERA_SENSITIVITY_PLAYER_PREFS_KEY, GTWUISettingsGameplaySubState.DEFAULT_CAMERA_SENSITIVITY);

	public bool CameraInvertHorizontal => PlayerPrefs.GetInt(CAMERA_INVERT_HORIZONTAL_PREFS_KEY, GTWUISettingsGameplaySubState.DEFAULT_CAMERA_INVERT_HORIZONTAL) == 1;

	public bool CameraInvertVertical => PlayerPrefs.GetInt(CAMERA_INVERT_VERTICAL_PREFS_KEY, GTWUISettingsGameplaySubState.DEFAULT_CAMERA_INVERT_VERTICAL) == 1;

	public float CameraHorizontalAutoRotationSpeedSetting
	{
		get
		{
			bool num = PlayerPrefs.GetInt(CAMERA_HORIZONTAL_AUTO_ROTATION_PLAYER_PREFS_KEY, GTWUISettingsGameplaySubState.DEFAULT_CAMERA_HORIZONTAL_AUTO_ROTATION) == 1;
			float result = ((_playerVirtualCameraPreset != null) ? _playerVirtualCameraPreset.horizontalAutoRotateSpeedMultiplier : 0.5f);
			if (!num)
			{
				return 0f;
			}
			return result;
		}
	}

	public float CameraVerticalAutoRotationSpeedSetting
	{
		get
		{
			bool num = PlayerPrefs.GetInt(CAMERA_VERTICAL_AUTO_ROTATION_PLAYER_PREFS_KEY, GTWUISettingsGameplaySubState.DEFAULT_CAMERA_VERTICAL_AUTO_ROTATION) == 1;
			float result = ((_playerVirtualCameraPreset != null) ? _playerVirtualCameraPreset.verticalAutoRotateSpeedMultiplier : 0.5f);
			if (!num)
			{
				return 0f;
			}
			return result;
		}
	}

	[Inject]
	private void Inject(IControls controls, CinemachineBrain cinemachineBrain)
	{
		_controls = controls;
		_cinemachineBrain = cinemachineBrain;
	}

	private void Awake()
	{
		_playerCameraOverride = GetComponent<PlayerCameraOverride>();
		_cinemachineCollider = _virtualCamera.GetComponent<CustomCinemachineCollider>();
		_defaultCameraColliderLayerMask = _cinemachineCollider.m_CollideAgainst;
		CinemachineComponentBase cinemachineComponent = _virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
		_transposer = cinemachineComponent as CinemachineTransposer;
		_defaultCameraPositionDamping.x = _transposer.m_XDamping;
		_defaultCameraPositionDamping.y = _transposer.m_YDamping;
		_defaultCameraPositionDamping.z = _transposer.m_ZDamping;
		_defaultCameraRotationDamping.x = _transposer.m_PitchDamping;
		_defaultCameraRotationDamping.y = _transposer.m_YawDamping;
		_defaultCameraRotationDamping.z = _transposer.m_RollDamping;
		_defaultMouseCameraPositionDamping = new Vector3(0.1f, 0.1f, _defaultCameraPositionDamping.z);
	}

	private void Start()
	{
		_camRotationEuler = _aimTarget.rotation.eulerAngles;
	}

	private void OnDestroy()
	{
		CursorControl.SetCursorActive(value: true);
	}

	private void Update()
	{
		_cameraOverride = _playerCameraOverride.GetOverride();
		_cameraInput = GetCameraRotationInput();
		_rawMovementInput = _playerController.RawInput;
		UpdateCamera();
		UpdateOcclusionCulling();
	}

	private void LateUpdate()
	{
		UpdateCameraPosition();
		LateUpdateVirtualCameraParameters();
		if (_controls.GetControlMode() == Controls.Mode.Gameplay)
		{
			CursorControl.SetCursorActive(value: false);
		}
		else
		{
			CursorControl.SetCursorActive(!_controls.UsingJoystick());
		}
	}

	private void SetCameraTransposerDamping(Vector3 positionDamping, Vector3 rotationDamping)
	{
		_currentCameraPositionDamping = positionDamping;
		_currentCameraRotationDamping = rotationDamping;
		_transposer.m_XDamping = positionDamping.x;
		_transposer.m_YDamping = positionDamping.y;
		_transposer.m_ZDamping = positionDamping.z;
		_transposer.m_PitchDamping = rotationDamping.x;
		_transposer.m_YawDamping = rotationDamping.y;
		_transposer.m_RollDamping = rotationDamping.z;
	}

	private void UpdateCameraTransposerDampingMultiplier(float multiplier)
	{
		UpdateCameraTransposerDampingMultiplier(new Vector3(multiplier, multiplier, multiplier));
	}

	private void UpdateCameraTransposerDampingMultiplier(Vector3 multiplier)
	{
		_transposer.m_XDamping = _currentCameraPositionDamping.x * multiplier.x;
		_transposer.m_YDamping = _currentCameraPositionDamping.y * multiplier.y;
		_transposer.m_ZDamping = _currentCameraPositionDamping.z * multiplier.z;
		_transposer.m_PitchDamping = _currentCameraRotationDamping.x * multiplier.x;
		_transposer.m_YawDamping = _currentCameraRotationDamping.y * multiplier.y;
		_transposer.m_RollDamping = _currentCameraRotationDamping.z * multiplier.z;
	}

	public void SetCameraDamping(Vector3 positionDamping)
	{
		SetCameraDamping(positionDamping, _defaultCameraRotationDamping);
	}

	public void SetCameraDamping(Vector3 positionDamping, Vector3 rotationDamping)
	{
		SetCameraTransposerDamping(positionDamping, rotationDamping);
	}

	public void SetDefaultCameraDamping(bool hasMouseInput = false)
	{
		if (_playerController.CurrentState.GetType() == typeof(GTWPlayerNoClipState))
		{
			SetCameraDamping(Vector3.zero, Vector3.zero);
		}
		else if (hasMouseInput)
		{
			SetCameraDamping(_defaultMouseCameraPositionDamping, _defaultCameraRotationDamping);
		}
		else
		{
			SetCameraDamping(_defaultCameraPositionDamping, _defaultCameraRotationDamping);
		}
	}

	public void SetCameraRotation(Vector2 rotationEuler)
	{
		_camRotationEuler = rotationEuler;
		_camVerticalTarget = rotationEuler.x;
		_camVerticalVelocity = 0f;
		float min = ((_cameraOverride != null && _cameraOverride.hasMinVerticalAngleOverride) ? _cameraOverride.minVerticalAngleOverride : MinVerticalAngleLimit);
		float max = ((_cameraOverride != null && _cameraOverride.hasMaxVerticalAngleOverride) ? _cameraOverride.maxVerticalAngleOverride : MaxVerticalAngleLimit);
		_camRotationEuler.x = Mathf.Clamp(_camRotationEuler.x, min, max);
		_aimTarget.rotation = Quaternion.Euler(_camRotationEuler);
	}

	public void UpdateCameraPosition(bool instant = false)
	{
		Vector3 position = base.transform.position;
		if (_playerController.PlayerModelController.PlayerIkController.PlayerRagdoll.IsRagdollEnabled)
		{
			Vector3 vector = _playerController.PlayerModelController.PlayerIkController.PlayerRagdoll.RagdollBallTarget.position;
			if (_playerController.IsGrabLinkActive)
			{
				vector = _playerController.GrabTargetPosition;
				Vector3 movementInput = _playerController.MovementInput;
				_cameraPositionOffset = Vector3.SmoothDamp(_cameraPositionOffset, movementInput * EdgeGrabCameraOffset, ref _cameraPositionOffsetVelocity, TimeToReachEdgeGrabOffset, float.MaxValue, Time.deltaTime);
			}
			if (instant)
			{
				position = vector;
				_ragdollPositionTargetWeight = 1f;
			}
			else
			{
				float num = Vector3.Distance(base.transform.position, vector);
				_ragdollPositionTargetWeight = Mathf.MoveTowards(_ragdollPositionTargetWeight, 1f, Time.deltaTime * 5f);
				position = ((!(_ragdollPositionTargetWeight >= 0.999f)) ? Vector3.MoveTowards(base.transform.position, vector, Time.deltaTime * num * Mathf.Lerp(20f, 1000f, _ragdollPositionTargetWeight)) : vector);
			}
		}
		else
		{
			_cameraPositionOffset = Vector3.SmoothDamp(_cameraPositionOffset, Vector3.zero, ref _cameraPositionOffsetVelocity, TimeToReachEdgeGrabOffset, float.MaxValue, Time.deltaTime);
			position = _playerController.PlayerModelController.transform.position;
			_ragdollPositionTargetWeight = 0f;
		}
		if (_cameraOverride != null && _cameraOverride.hasPositionOverride)
		{
			position = _cameraOverride.positionRotationOverride.position;
		}
		base.transform.position = position + _cameraPositionOffset + _animatedCameraPositionOffset;
		_followPosition.rotation = Quaternion.identity;
	}

	public void UpdateCamera(bool instantUpdate = false)
	{
		UpdateVirtualCameraParameters();
		Vector2 vector = _cameraInput;
		if (instantUpdate)
		{
			vector = Vector2.zero;
			_rawMovementInput = Vector3.zero;
		}
		if (GameState.CurrentlyLoading || SectionLoader.IsBusy)
		{
			vector = Vector2.zero;
		}
		if (_rotationInputBlockTimeLeft > 0f)
		{
			vector = Vector2.zero;
		}
		_rotationInputBlockTimeLeft -= Time.deltaTime;
		if (instantUpdate)
		{
			UpdateCameraPosition(instant: true);
		}
		bool flag = AutoRotateEnabled && _autoRotateResetTimeLeft < 0f;
		if (!AutoRotateEnabledDuringGrab && _playerController.IsGrabLinkActive)
		{
			flag = false;
		}
		if (_playerController.TimeSinceLastMoving > 0.5f)
		{
			flag = false;
		}
		if (_cinemachineBrain.ActiveVirtualCamera != _virtualCamera)
		{
			flag = false;
			vector = Vector2.zero;
		}
		if (flag)
		{
			float target = 1f;
			_autoRotatedWeight = Mathf.SmoothDamp(_autoRotatedWeight, target, ref _autoRotateWeightVel, AutoRotateEnableTransitionTime, float.MaxValue, Time.deltaTime);
		}
		else
		{
			_autoRotateWeightVel = 0f;
			_autoRotatedWeight = 0f;
		}
		Vector3 forward = _playerController.DirectionFlat;
		if (_playerController.IsGrabLinkActive && _playerController.Speed > 0.001f)
		{
			forward = _playerController.Velocity;
		}
		forward.Normalize();
		Vector3 direction = _playerController.Direction;
		Quaternion quaternion = Quaternion.LookRotation(forward, Vector3.up);
		float currentSpeedKPH = _playerController.CurrentSpeedKPH;
		float num = ((_playerController.PlayerCollisionHandler.IsGrounded && !_playerController.IsGrabLinkActive) ? BaseAutoRotateGroundSpeed : BaseAutoRotateAirSpeed);
		float target2 = ((_cameraOverride != null && _cameraOverride.hasReactionSpeedOverride) ? _cameraOverride.reactionSpeedOverride : num);
		_reactionSpeed = Mathf.SmoothDamp(_reactionSpeed, target2, ref _reactionSpeedVel, 1f, float.MaxValue, Time.deltaTime);
		float num2 = _reactionSpeed * AutoRotatePlayerSpeedCurve.Evaluate(currentSpeedKPH);
		num2 *= 1f - Mathf.InverseLerp(0.9f, 0.95f, Mathf.Abs(direction.y));
		float num3 = (UsingController ? 0.5f : 1f);
		_camRotationEuler.y += vector.x * InputRotateSpeedMultiplier * Time.deltaTime;
		_camRotationEuler.x += (0f - vector.y) * InputRotateSpeedMultiplier * Time.deltaTime * num3;
		_camRotationEuler.x = Mathf.Clamp(_camRotationEuler.x, MinVerticalAngleLimit + VerticalTiltAngle, MaxVerticalAngleLimit - VerticalTiltAngle);
		if (instantUpdate)
		{
			_autoRotateWeightVel = 0f;
			_reactionSpeedVel = 0f;
		}
		bool flag2 = _playerController.CurrentState.GetType() == typeof(GTWPlayerNoClipState);
		if (((_autoRotatedWeight > 0f) | instantUpdate) && !flag2)
		{
			float num4 = quaternion.eulerAngles.y;
			if (_playerController.IsGrabLinkActive && _playerController.IsGrabRagDoll && _playerController.PlayerIkController.PlayerRagdoll.GrabParent != null)
			{
				Vector3 to = -_playerController.GrabLinkNormal;
				num4 = Vector3.SignedAngle(Vector3.forward, to, Vector3.up);
			}
			if (_cameraOverride != null && _cameraOverride.hasRotationOverride)
			{
				num4 = _cameraOverride.positionRotationOverride.rotation.eulerAngles.y;
			}
			float num5 = Mathf.Abs(Mathf.DeltaAngle(_camRotationEuler.y, num4));
			if (instantUpdate)
			{
				_camRotationEuler.y = num4;
			}
			else
			{
				_camRotationEuler.y = Mathf.MoveTowardsAngle(_camRotationEuler.y, num4, Time.deltaTime * num2 * (num5 / 90f) * CameraHorizontalAutoRotationSpeedSetting * _autoRotatedWeight);
			}
			float num6 = 0f;
			num6 = AutoRotateTargetAngleFromFloorOrientation(instantUpdate);
			float num7 = GetAutoRotateSpeedCoefficient(_playerController.Speed, 2f, 10f);
			if (_playerController.IsGrabLinkActive && _playerController.IsGrabRagDoll)
			{
				num6 = -10f;
				num7 = 0.2f;
			}
			else if (_playerController.IsRagdollState && !_playerController.IsBodyMoving)
			{
				num6 = -10f;
				num7 = 0.4f;
			}
			if (_cameraOverride != null && _cameraOverride.hasRotationOverride)
			{
				num6 = _cameraOverride.positionRotationOverride.rotation.eulerAngles.x;
			}
			float smoothTime = Mathf.Lerp(0.5f, 0.1f, CameraVerticalAutoRotationSpeedSetting);
			_camVerticalTarget = Mathf.SmoothDamp(_camVerticalTarget, num6, ref _camVerticalVelocity, smoothTime, float.MaxValue, Time.deltaTime);
			if (instantUpdate)
			{
				_camVerticalTarget = num6;
				_camVerticalVelocity = 0f;
				_camRotationEuler.x = _camVerticalTarget;
			}
			else
			{
				float num8 = Mathf.InverseLerp(0f, DampingVerticalReturnThreshold, Mathf.Abs(_camVerticalTarget - _camRotationEuler.x));
				float maxDelta = Time.deltaTime * num8 * num7 * 180f * CameraVerticalAutoRotationSpeedSetting * _autoRotatedWeight;
				_camRotationEuler.x = Mathf.MoveTowardsAngle(_camRotationEuler.x, _camVerticalTarget, maxDelta);
			}
		}
		float min = ((_cameraOverride != null && _cameraOverride.hasMinVerticalAngleOverride) ? _cameraOverride.minVerticalAngleOverride : MinVerticalAngleLimit);
		float max = ((_cameraOverride != null && _cameraOverride.hasMaxVerticalAngleOverride) ? _cameraOverride.maxVerticalAngleOverride : MaxVerticalAngleLimit);
		_camRotationEuler.x = Mathf.Clamp(_camRotationEuler.x, min, max);
		Quaternion rotation = Quaternion.Euler(_camRotationEuler);
		if (!flag2 && UsingController)
		{
			_tiltRotation = Quaternion.RotateTowards(_tiltRotation, Quaternion.Euler(_rawMovementInput.z * VerticalTiltAngle, 0f, _rawMovementInput.x * HorizontalTiltAngle), Time.deltaTime * 360f * TiltResponsiveness);
			rotation *= _tiltRotation;
		}
		_aimTarget.rotation = rotation;
		if (instantUpdate)
		{
			_virtualCamera.PreviousStateIsValid = false;
		}
	}

	private float GetAutoRotateSpeedCoefficient(float playerSpeed, float slowestSpeed, float maxSpeed)
	{
		return Mathf.Clamp01(Mathf.Max(0f, playerSpeed - slowestSpeed) / maxSpeed);
	}

	private float AutoRotateTargetAngleFromFloorOrientation(bool instantUpdate)
	{
		Vector3 b = _playerController.Velocity.normalized;
		if (instantUpdate && b.magnitude < 0.0001f)
		{
			b = _playerController.PlayerTransform.forward;
		}
		float target = VerticalSpeedWeightCurve.Evaluate(_playerController.Velocity.y);
		_currentVerticalWeight = Mathf.SmoothDamp(_currentVerticalWeight, target, ref _verticalWeightVel, 1f, float.MaxValue, Time.deltaTime);
		b = Vector3.Lerp(_playerController.DirectionFlat, b, _currentVerticalWeight);
		Vector3 vector = Vector3.Cross(Vector3.Cross(b, Vector3.up), b);
		if (instantUpdate)
		{
			_cameraPlaneUp = (_playerController.PlayerCollisionHandler.IsGrounded ? _playerController.PlayerCollisionHandler.FloorNormal : vector);
			_cameraPlaneUpVel = Vector3.zero;
			_verticalWeightVel = 0f;
		}
		else
		{
			_cameraPlaneUp = Vector3.SmoothDamp(_cameraPlaneUp, _playerController.PlayerCollisionHandler.IsGrounded ? _playerController.PlayerCollisionHandler.FloorNormal : vector, ref _cameraPlaneUpVel, 0.2f, float.MaxValue, Time.deltaTime);
		}
		Vector3 vector2 = new Plane(_cameraPlaneUp, _playerController.PlayerPosition).ClosestPointOnPlane(_aimTarget.position - _aimTarget.forward) - _playerController.PlayerPosition;
		vector2.Normalize();
		return vector2.y * 45f;
	}

	private void UpdateVirtualCameraParameters()
	{
		float target = Mathf.Lerp(0f, SlowTimeFovIncrement, _playerController.TimeManager.SlowTimeWeight);
		_timeScaleFovIncrement = Mathf.SmoothDamp(_timeScaleFovIncrement, target, ref _timeScaleFovVelocity, 0.05f);
		_virtualCamera.m_Lens.FieldOfView = Fov + _timeScaleFovIncrement;
		float y = ((_cameraOverride != null && _cameraOverride.hasFollowCamHeightOverride) ? _cameraOverride.followCamHeightOverride : FollowCamHeight);
		Vector3 localPosition = _followCam.localPosition;
		_currentCameraDistance = Mathf.MoveTowards(_currentCameraDistance, (_cameraOverride != null && _cameraOverride.hasDistanceOverride) ? (0f - Mathf.Abs(_cameraOverride.distanceOverride)) : (0f - Distance), Time.deltaTime * 15f);
		localPosition.z = _currentCameraDistance;
		localPosition.y = y;
		_followCam.localPosition = localPosition;
		float target2 = ((_cameraOverride != null && _cameraOverride.hasAimTargetHeightOverride) ? _cameraOverride.aimTargetHeightOverride : AimTargetHeight);
		if (_playerController.PlayerModelController.PlayerIkController.PlayerRagdoll.IsRagdollEnabled)
		{
			target2 = 0f;
		}
		Vector3 localPosition2 = _aimTarget.localPosition;
		localPosition2.y = Mathf.MoveTowards(localPosition2.y, target2, Time.deltaTime);
		_aimTarget.localPosition = localPosition2;
		_followCam.LookAt(_aimTarget, _aimTarget.up);
		_cinemachineCollider.m_CollideAgainst = ((_cameraOverride != null && _cameraOverride.hasCollisionLayerOverride) ? _cameraOverride.collisionLayerOverride : _defaultCameraColliderLayerMask);
	}

	private void LateUpdateVirtualCameraParameters()
	{
		float time = _playerController.CurrentSpeedKPH;
		if (_playerController.CurrentState.GetType() == typeof(GTWPlayerRagdollState))
		{
			time = _playerController.PlayerIkController.PlayerRagdoll.PelvisRigidBody.linearVelocity.magnitude * 3.6f;
		}
		Vector3 one = Vector3.one;
		one.z = AutoRotateDampingPlayerSpeedCurve.Evaluate(time);
		Vector3 to = AimTarget.position - _followCam.position;
		Vector3 direction = _playerController.Direction;
		float x = Vector3.Angle(Vector3.up, to);
		float y = Vector3.Angle(Vector3.down, to);
		float value = Vector3.Angle(direction, to);
		to.y = 0f;
		float y2 = Vector3.Angle(direction, to);
		float value2 = MathF.Max(MathF.Max(x, y), y2);
		one.x *= Mathf.InverseLerp(170f, 130f, value2);
		one.y *= Mathf.InverseLerp(170f, 130f, value2);
		one.z *= Mathf.InverseLerp(170f, 130f, value);
		bool flag = _playerController.IsGrabLinkActive && _playerController.GrabbingStickySurface;
		bool flag2 = _autoRotateResetTimeLeft > 0f;
		one.x *= ((flag | flag2) ? 0f : 1f);
		one.y *= ((flag | flag2) ? 0f : 1f);
		one.z *= (flag ? 0f : 1f);
		_dampingMultiplier = Vector3.SmoothDamp(_dampingMultiplier, one, ref _dampingMultiplierVel, flag2 ? 0.1f : TimeToTurnDampingBackOn, float.MaxValue, Time.deltaTime);
		UpdateCameraTransposerDampingMultiplier(_dampingMultiplier);
	}

	private Vector2 GetCameraRotationInput()
	{
		Vector2 zero = Vector2.zero;
		zero.x = _controls.GetAxis(Controls.MovementAxis.SecondaryHorizontal);
		zero.y = _controls.GetAxis(Controls.MovementAxis.SecondaryVertical);
		if (Mathf.Abs(zero.x) < 0.05f)
		{
			zero.x = 0f;
		}
		if (Mathf.Abs(zero.y) < 0.05f)
		{
			zero.y = 0f;
		}
		_hasControllerInput = zero.sqrMagnitude > 1E-06f;
		_hasMouseInput = false;
		if (Time.deltaTime > 0f)
		{
			Vector2 vector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) / Time.deltaTime;
			zero += vector * MouseSensitivity;
			_hasMouseInput = vector.sqrMagnitude > 1E-06f;
			if (_hasMouseInput)
			{
				_hasControllerInput = false;
			}
		}
		if (_hasMouseInput)
		{
			SetAutoRotateResetTime(MouseAutoRotateResetDelay);
		}
		else if (_hasControllerInput)
		{
			SetAutoRotateResetTime(ControllerAutoRotateResetDelay);
		}
		else if (_autoRotateResetTimeLeft < 0f)
		{
			SetDefaultCameraDamping();
		}
		if (!_hasMouseInput)
		{
			if (Mathf.Abs(zero.x) > Mathf.Abs(zero.y))
			{
				zero.y *= 1f - Mathf.Abs(zero.x) * 0.5f;
			}
			else
			{
				zero.x *= 1f - Mathf.Abs(zero.y) * 0.5f;
			}
		}
		_autoRotateResetTimeLeft -= Time.deltaTime;
		float cameraSensitivitySetting = CameraSensitivitySetting;
		cameraSensitivitySetting *= 2f;
		zero.x *= (CameraInvertHorizontal ? (-1f) : 1f);
		zero.y *= (CameraInvertVertical ? (-1f) : 1f);
		return zero * cameraSensitivitySetting;
	}

	public void SetAutoRotateResetTime(float time)
	{
		if (_autoRotateResetTimeLeft < time)
		{
			_autoRotateResetTimeLeft = time;
		}
	}

	public void SetRotationInputBlockTime(float time)
	{
		if (_rotationInputBlockTimeLeft < time)
		{
			_rotationInputBlockTimeLeft = time;
		}
	}

	private void UpdateOcclusionCulling()
	{
	}
}
