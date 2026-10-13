using System;
using System.Collections.Generic;
using System.Text;
using Isto.Core;
using Isto.Core.Beings;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using Isto.GTW.Camera;
using Isto.GTW.DebugTools;
using Isto.GTW.Inputs;
using Isto.GTW.LevelFeatures;
using Isto.GTW.Managers;
using Isto.GTW.Player.Audio;
using Isto.GTW.Player.States;
using Isto.GTW.Tools;
using RootMotion.FinalIK;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Player;

[DefaultExecutionOrder(100)]
public class PlayerController : CorePlayerController
{
	[SerializeField]
	private PlayerModelController _playerModelController;

	[Space]
	[SerializeField]
	private Transform _playerCameraTransform;

	[SerializeField]
	private Rigidbody _rigidbody;

	[SerializeField]
	private Collider _mainHitBox;

	[SerializeField]
	private SphereCollider _mainBallCollider;

	[SerializeField]
	protected SphereCollider _playerEventTrigger;

	[SerializeField]
	protected SphereCollider _bodyEventTrigger;

	[Space]
	[Header("Grab Ability")]
	[Tooltip("The duration (s) after you touch the ground that will still allow you to activate grab-mode")]
	[SerializeField]
	private float _grabGracePeriod = 0.05f;

	[Tooltip("The amount of force required to \"break\" the grab.\nUsually occurs when you get pushed by another moving object.\n\nForce is a Unity unit (distance per second)\nValue is chosen by feel - a small value, but not small enough that it'll break the grab by itself.")]
	[SerializeField]
	private float _grabBreakForce = 0.1f;

	[Tooltip("The amount of force applied to the character when swinging in ledge-grab mode.\nApplied to the pelvis of the character. The anchor is at the players' hands.\n\nForce is a Unity unit (m/s).\n\nValue is chosen by feel.")]
	[SerializeField]
	private float _ledgeGrabForceControl = 500f;

	[Tooltip("A force applied to the character when letting go of ledge-grab mode.\nValue is chosen by feel.")]
	[SerializeField]
	private float _ledgeGrabFlingVerticalForce = 3f;

	[Space]
	[SerializeField]
	protected Transform _debugBallTransform;

	[Space]
	[Header("States")]
	public GTWPlayerMoveState _moveState;

	public GTWPlayerWaitForSectionLoading _waitForSectionLoading;

	public GTWPlayerNoClipState _noClipState;

	public GTWPlayerRagdollState _ragdollState;

	public GTWPlayerCutsceneState _cutsceneState;

	public GTWPlayerFreezeControls _freezeControlsState;

	[Space]
	[Header("Abilities")]
	public bool grabAbilityAvailable = true;

	public bool slowMotionAbilityAvailable;

	public bool noClipAbilityAvailable;

	public bool ragDollAbilityAvailable;

	public bool restartAbilityAvailable;

	public bool restartStartingCheckpointAbilityAvailable;

	public bool noClipHighSpeedMode;

	public float noClipHighSpeedMultiplier = 3f;

	[Space]
	[SerializeField]
	private TorquePhysics _torquePhysics = new TorquePhysics();

	[Space]
	public bool showDebug = true;

	protected PlayerVirtualCameraController _playerVirtualCameraController;

	protected PlayerCollisionHandler _playerCollisionHandler;

	protected PlayerAudio _playerAudio;

	protected TimeManager _timeManager;

	protected PlayerWearableController _playerWearableController;

	protected Vector3 _velocity = Vector3.zero;

	protected float _speed;

	protected float _speedKPH;

	protected float _timeSinceLastMoving;

	protected Vector3 _velocityAcceleration = Vector3.zero;

	protected float _velocityAccelerationSpeed;

	protected Vector3 _velocityAccelerationRaw = Vector3.zero;

	protected float _velocityAccelerationSpeedRaw;

	protected Vector3 _direction = Vector3.forward;

	protected Vector3 _directionUp = Vector3.up;

	protected Vector3 _directionFlat = Vector3.forward;

	protected Vector3 _oldDirectionSmooth = Vector3.forward;

	protected Vector3 _directionSmooth = Vector3.forward;

	protected Vector3 _directionUpSmooth = Vector3.forward;

	protected Vector3 _directionFlatSmooth = Vector3.forward;

	protected Vector3 _angularVelocityDirection = Vector3.forward;

	protected Vector3 _angularVelocityUp = Vector3.up;

	protected Vector3 _oldAngularVelocityDirectionSmooth = Vector3.forward;

	protected Vector3 _angularVelocityDirectionSmooth = Vector3.forward;

	protected Vector3 _ballSurfaceVelocity = Vector3.zero;

	protected float _ballSurfaceSpeed;

	protected Vector3 _bodyVelocity = Vector3.zero;

	protected float _bodySpeed;

	protected float _bodySpeedKPH;

	protected float _noClipVerticalInput;

	protected Vector3 _noClipVelocity = Vector3.zero;

	protected Vector3 _rawInput = Vector3.zero;

	protected Vector3 _movementInput = Vector3.zero;

	protected Vector3 _characterSpaceInput = Vector3.zero;

	private PlayerPhysicsOverride _playerPhysicsOverride;

	private Vector3 _lastPosition = Vector3.zero;

	private Quaternion _lastRotation = Quaternion.identity;

	private float _lastSpeed;

	private Vector3 _lastVelocity = Vector3.zero;

	private float _lastSpeedRaw;

	private Vector3 _lastVelocityRaw = Vector3.zero;

	private bool _isGrabLinkActive;

	private bool _forceHoldGrab;

	private bool _grabbingStickySurface;

	private List<string> _sceneNameCollidersToIgnore = new List<string>();

	private const float GRAB_COOLDOWN = 0.25f;

	private float _grabCooldownTimeLeft = 0.25f;

	private bool _grabRagdoll;

	private Transform _grabLinkParent;

	private Collider _grabLinkCollider;

	private Rigidbody _grabLinkParentRigidbody;

	private Vector3 _grabLinkNormal = Vector3.zero;

	private GTWExtensions.Location _grabLocalLocation;

	private Vector3 _lastGrabTargetPosition;

	private Queue<Vector3> _lastGrabVelocities = new Queue<Vector3>();

	private Vector3 _lastGrabVelocity = Vector3.zero;

	private Vector3 _lastGrabRigidbodyVelocity = Vector3.zero;

	private float _highFrictionModeTime = -1f;

	private int _slipperyLayer;

	private bool _hasPlayerInputted;

	public Action OnResetVelocity;

	public Action OnPlayerTeleport;

	public Action OnPlayerRespawn;

	public Action OnActivateGrab;

	public Action OnDeactivateGrab;

	private float _grabHoldVelocityTime;

	public static PlayerController CurrentPlayer { get; private set; }

	public TorquePhysics TorquePhysics => _torquePhysics;

	public CheckpointManager CheckpointManager { get; set; }

	public PlayerModelController PlayerModelController => _playerModelController;

	public PlayerIkController PlayerIkController => PlayerModelController.PlayerIkController;

	public IControls InputControls => _controls;

	public PlayerCollisionHandler PlayerCollisionHandler => _playerCollisionHandler;

	public PlayerAudio PlayerAudio => _playerAudio;

	public PlayerWearableController PlayerWearableController => _playerWearableController;

	public PlayerVirtualCameraController PlayerVirtualCameraController => _playerVirtualCameraController;

	public SphereCollider PlayerEventTrigger => _playerEventTrigger;

	public SphereCollider BodyEventTrigger => _bodyEventTrigger;

	public TimeManager TimeManager => _timeManager;

	protected override Collider MainHitBox => _mainHitBox;

	public SphereCollider MainBallCollider => _mainBallCollider;

	public Rigidbody Rigidbody => _rigidbody;

	public float BallRadius => TorquePhysics.BallRadius;

	public bool IsMoveState => _currentState?.GetType() == typeof(GTWPlayerMoveState);

	public bool IsFreezeControlsState => _currentState?.GetType() == typeof(GTWPlayerFreezeControls);

	public bool IsRagdollState => _currentState?.GetType() == typeof(GTWPlayerRagdollState);

	public Transform PlayerTransform => _rigidbody.transform;

	public Vector3 PlayerPosition => PlayerTransform.position;

	public Transform PlayerCameraTransform => _playerCameraTransform;

	public Vector3 Velocity => _velocity;

	public Vector3 BallSurfaceVelocity => _ballSurfaceVelocity;

	public float Speed => _speed;

	public Vector3 BodyVelocity => _bodyVelocity;

	public float BodySpeed => _bodySpeed;

	public float BodySpeedKPH => _bodySpeedKPH;

	public Vector3 VelocityAcceleration => _velocityAcceleration;

	public float VelocityAccelerationSpeed => _velocityAccelerationSpeed;

	public Vector3 VelocityAccelerationRaw => _velocityAccelerationRaw;

	public float VelocityAccelerationSpeedRaw => _velocityAccelerationSpeedRaw;

	public Vector3 Direction => _direction;

	public Vector3 DirectionUp => _directionUp;

	public Vector3 DirectionFlat => _directionFlat;

	public Vector3 DirectionSmooth => _directionSmooth;

	public Vector3 DirectionUpSmooth => _directionUpSmooth;

	public Vector3 DirectionFlatSmooth => _directionFlatSmooth;

	public Vector3 GravityDirection => TorquePhysics.GravityDirection;

	public Vector3 Gravity => TorquePhysics.Gravity;

	public Vector3 AngularVelocityDirection => _angularVelocityDirection;

	public Vector3 AngularVelocityUp => _angularVelocityUp;

	public Vector3 AngularVelocityDirectionSmooth => _angularVelocityDirectionSmooth;

	public PlayerPhysicsOverride PlayerPhysicsOverride => _playerPhysicsOverride;

	public Vector3 RawInput => _rawInput;

	public Vector3 MovementInput => _movementInput;

	public Vector3 CharacterSpaceInput => _characterSpaceInput;

	public float CurrentTorque => Rigidbody.angularVelocity.magnitude;

	public float CurrentSpeed
	{
		get
		{
			if (!IsRagdollState)
			{
				return _speed;
			}
			return _bodySpeed;
		}
	}

	public float CurrentSpeedKPH
	{
		get
		{
			if (!IsRagdollState)
			{
				return _speedKPH;
			}
			return _bodySpeedKPH;
		}
	}

	public float CurrentBallSurfaceSpeed => _ballSurfaceSpeed;

	public float CurrentBallSurfaceSpeedKPH => _ballSurfaceSpeed * 3.6f;

	public bool IsGrabLinkActive => _isGrabLinkActive;

	public bool IsGrabRagDoll => _grabRagdoll;

	public bool GrabbingStickySurface => _grabbingStickySurface;

	public Collider GrabLinkCollider => _grabLinkCollider;

	public Vector3 GrabLinkNormal => _grabLinkNormal;

	public Transform GrabLinkParent => _grabLinkParent;

	public Rigidbody GrabLinkParentRigidbody => _grabLinkParentRigidbody;

	public Vector3 GrabTargetPosition => _grabLinkParent.TransformPoint(_grabLocalLocation.Position);

	public Quaternion GrabTargetRotation => _grabLinkParent.rotation * _grabLocalLocation.Rotation;

	public bool HighFrictionMode => _highFrictionModeTime > 0f;

	public List<string> SceneNameCollidersToIgnore => _sceneNameCollidersToIgnore;

	public bool ForceHoldGrab
	{
		get
		{
			return _forceHoldGrab;
		}
		set
		{
			_forceHoldGrab = value;
		}
	}

	public override State MovementState => _moveState;

	public override bool IsMoving => _speed > 0.0001f;

	public bool IsBodyMoving => _bodySpeed > 0.0001f;

	public float TimeSinceLastMoving => _timeSinceLastMoving;

	public Transform DebugBallTransform => _debugBallTransform;

	[Inject]
	public void Inject(TimeManager timeManager)
	{
		_timeManager = timeManager;
	}

	private void Reset()
	{
		_rigidbody = GetComponentInChildren<Rigidbody>();
	}

	protected override void Awake()
	{
		CurrentPlayer = this;
		TorquePhysics.PlayerController = this;
		base.Awake();
		_playerCollisionHandler = GetComponentInChildren<PlayerCollisionHandler>();
		_playerVirtualCameraController = GetComponentInChildren<PlayerVirtualCameraController>();
		_playerPhysicsOverride = GetComponent<PlayerPhysicsOverride>();
		_playerAudio = GetComponentInChildren<PlayerAudio>();
		_playerWearableController = GetComponentInChildren<PlayerWearableController>();
		_slipperyLayer = LayerMask.NameToLayer("Slippery");
		ResetVelocityToZero();
		DeactivateGrabLink();
		SetPhysicsActive(isActive: true);
		_torquePhysics.Initialize();
		Events.Subscribe(GTWEvents.GIVE_UP_ALLOWED, Events_OnGiveUpAllowed);
		Events.Subscribe(GTWEvents.DOINKLER_STAGE_START, Events_OnDoinklerStageStart);
	}

	private void OnDestroy()
	{
		Events.UnSubscribe(GTWEvents.GIVE_UP_ALLOWED, Events_OnGiveUpAllowed);
		Events.UnSubscribe(GTWEvents.DOINKLER_STAGE_START, Events_OnDoinklerStageStart);
	}

	protected override void OnEnable()
	{
		base.OnEnable();
	}

	protected override void OnDisable()
	{
	}

	protected virtual void FixedUpdate()
	{
		if (IsMoveState || IsFreezeControlsState)
		{
			UpdateGrabLinkFixedUpdate();
		}
		_highFrictionModeTime -= FixedTimeSync.FixedDeltaTime;
		_torquePhysics.PhysicsUpdate();
	}

	protected override void Update()
	{
		base.Update();
		_ = _movementInput;
		_movementInput = GetCameraSpaceMovementInput();
		_characterSpaceInput = GetCharacterSpaceMovementInput();
		if (IsMoveState || IsFreezeControlsState)
		{
			UpdateGrabLink();
		}
		if (!IsGrabLinkActive)
		{
			_grabCooldownTimeLeft -= Time.deltaTime;
		}
		if (showDebug)
		{
			DebugExtensions.DrawArrow(PlayerTransform.position, 0.1f, _direction * 1.5f, Color.red);
			DebugExtensions.DrawArrow(PlayerTransform.position, PlayerTransform.position + _angularVelocityDirection * 2f, Color.green);
			DebugExtensions.DrawArrow(PlayerTransform.position, 0.1f, _movementInput, new Color(1f, 0.3f, 0f, 1f));
		}
	}

	private void Events_OnGiveUpAllowed()
	{
		ragDollAbilityAvailable = true;
	}

	private void Events_OnDoinklerStageStart()
	{
		_hasPlayerInputted = false;
	}

	public void SetIgnoreLevelDataColliders(List<string> sceneNameCollidersToIgnore)
	{
		_sceneNameCollidersToIgnore = sceneNameCollidersToIgnore;
	}

	public override void ChangeToMoveState()
	{
		ChangeState(_moveState);
	}

	public override void ChangeToCustomState(State state)
	{
		ChangeState(state);
	}

	public void ChangeToRagdollState()
	{
		ChangeState(_ragdollState);
	}

	public void ChangeToWaitForSectionLoadingState()
	{
		ChangeState(_waitForSectionLoading);
	}

	public void ChangeToWaitForSectionLoadingState(Vector3 velocity, Vector3 angularVelocity)
	{
		ChangeState(_waitForSectionLoading);
		_waitForSectionLoading.keepVelocity = true;
		_waitForSectionLoading.velocity = velocity;
		_waitForSectionLoading.angularVelocity = angularVelocity;
	}

	public void ChangeToFreezeControlsState()
	{
		ChangeState(_freezeControlsState);
	}

	public override void Respawn()
	{
		OnPlayerRespawn?.Invoke();
	}

	public void RespawnAtCheckpoint(CheckpointData.LevelCheckpointData checkpoint)
	{
		Debug.Log("Respawning Player at checkpoint:" + checkpoint.checkpointName + " in scene:" + checkpoint.sceneName);
		Respawn();
		TeleportCharacter(checkpoint.position, checkpoint.forward);
		if (checkpoint.spawnOnGround)
		{
			_waitForSectionLoading.teleportToGroundOnExit = true;
		}
		ResetVelocityToZero();
		PlayerVirtualCameraController.UpdateCamera(instantUpdate: true);
		ChangeToWaitForSectionLoadingState();
	}

	public override Vector3 GetPlayerPosition()
	{
		return PlayerTransform.position;
	}

	public void TeleportCharacter(Vector3 position)
	{
		Rigidbody.position = position;
		PlayerTransform.position = position;
		OnPlayerTeleport?.Invoke();
	}

	public void TeleportCharacter(Vector3 position, Vector3 forward)
	{
		Rigidbody.position = position;
		Rigidbody.rotation = Quaternion.LookRotation(forward, Vector3.up);
		PlayerTransform.position = position;
		PlayerTransform.rotation = Quaternion.LookRotation(forward, Vector3.up);
		OnPlayerTeleport?.Invoke();
	}

	public void TeleportCharacter(Vector3 position, Quaternion orientation)
	{
		Rigidbody.position = position;
		Rigidbody.rotation = orientation;
		PlayerTransform.position = position;
		PlayerTransform.rotation = orientation;
		OnPlayerTeleport?.Invoke();
	}

	public bool TeleportToGround(float maxDistance = 5f, float verticalStartHeightOffset = 0f)
	{
		if (Physics.Raycast(PlayerPosition + new Vector3(0f, verticalStartHeightOffset, 0f), GravityDirection, out var hitInfo, maxDistance, _playerCollisionHandler.GroundLayerMask))
		{
			TeleportCharacter(hitInfo.point + -GravityDirection * BallRadius);
			return true;
		}
		return false;
	}

	public void ResetVelocityToZero()
	{
		Rigidbody.linearVelocity = Vector3.zero;
		Rigidbody.angularVelocity = Vector3.zero;
		_direction = PlayerTransform.forward;
		_directionUp = PlayerTransform.up;
		_directionFlat = _direction;
		_directionFlat.y = 0f;
		_directionFlat.Normalize();
		_lastPosition = PlayerTransform.position;
		_lastRotation = PlayerTransform.rotation;
		_velocity = Vector3.zero;
		_speed = 0f;
		_speedKPH = 0f;
		_bodySpeedKPH = 0f;
		_velocityAcceleration = Vector3.zero;
		_velocityAccelerationSpeed = 0f;
		_angularVelocityDirection = _direction;
		_angularVelocityUp = _directionUp;
		_lastSpeed = 0f;
		_lastVelocity = Vector3.zero;
		OnResetVelocity?.Invoke();
	}

	public void SetVelocity(Vector3 velocity, Vector3 angularVelocity)
	{
		Rigidbody.linearVelocity = velocity;
		Rigidbody.angularVelocity = angularVelocity;
		_velocity = velocity;
		_speed = velocity.magnitude;
		_speedKPH = _speed * 3.6f;
		_velocityAcceleration = Vector3.zero;
		_velocityAccelerationSpeed = 0f;
		_lastSpeed = _speed;
		_lastVelocity = velocity;
	}

	public void SetDirection(Vector3 direction)
	{
		direction.Normalize();
		_direction = direction;
		_directionSmooth = direction;
		_directionFlat = _direction;
		_directionFlat.y = 0f;
		_directionFlat.Normalize();
	}

	public void SetPhysicsActive(bool isActive)
	{
		Rigidbody.gameObject.SetActive(isActive);
		_playerEventTrigger.gameObject.SetActive(isActive);
		_bodyEventTrigger.gameObject.SetActive(!isActive);
	}

	private Vector3 GetCameraSpaceMovementInput()
	{
		_rawInput = Vector2.zero;
		_rawInput.x = _controls.GetAxis(Controls.MovementAxis.MoveHorizontal);
		_rawInput.z = _controls.GetAxis(Controls.MovementAxis.MoveVertical);
		float magnitude = _rawInput.magnitude;
		if (magnitude > 1f)
		{
			_rawInput.Normalize();
		}
		if (magnitude > Mathf.Epsilon && !_hasPlayerInputted)
		{
			_hasPlayerInputted = true;
			Events.RaiseEvent(GTWEvents.PLAYER_FIRST_INPUT);
		}
		Vector3 forward = PlayerVirtualCameraController.AimTarget.forward;
		forward.y = 0f;
		forward.Normalize();
		return Quaternion.LookRotation(forward, Vector3.up) * _rawInput;
	}

	private Vector3 GetCharacterSpaceMovementInput()
	{
		Vector3 upwards = Vector3.up;
		Vector3 up = PlayerModelController.transform.up;
		if (Vector3.Angle(Vector3.up, PlayerModelController.transform.up) < 10f)
		{
			upwards = Vector3.ProjectOnPlane(PlayerVirtualCameraController.AimTarget.forward, Vector3.up);
		}
		float num = 1f;
		if (up.y < 0.5f && Vector3.Angle(up, PlayerVirtualCameraController.AimTarget.forward) < 90f)
		{
			num = -1f;
		}
		Quaternion quaternion = Quaternion.LookRotation(up, upwards);
		Vector3 vector = quaternion * Vector3.up * _rawInput.z + quaternion * Vector3.left * num * _rawInput.x;
		DebugExtensions.DrawArrow(PlayerPosition, 0.1f, vector, Color.magenta);
		return vector;
	}

	public void UpdateDirectionalVectorsAndSpeed()
	{
		if (Time.timeScale == 0f || Mathf.Approximately(Time.deltaTime, 0f))
		{
			return;
		}
		_velocity = PlayerTransform.position - _lastPosition;
		_speed = _velocity.magnitude;
		if (_speed > 0.001f)
		{
			_timeSinceLastMoving = 0f;
			Vector3 normalized = _velocity.normalized;
			Vector3 rhs = Vector3.up;
			if (Mathf.Abs(Vector3.Dot(normalized, Vector3.up)) < 0.999f)
			{
				_direction = normalized;
				rhs = _directionUp;
				_directionSmooth = Vector3.Lerp(_oldDirectionSmooth, normalized, _speed).normalized;
				_oldDirectionSmooth = _directionSmooth;
			}
			Vector3 lhs = Vector3.Cross(_direction, rhs);
			_directionUp = Vector3.Cross(lhs, _direction);
			Vector3 lhs2 = Vector3.Cross(_directionSmooth, rhs);
			_directionUpSmooth = Vector3.Cross(lhs2, _directionSmooth);
			Vector3 velocity = _velocity;
			velocity.y = 0f;
			if (velocity.sqrMagnitude > 1E-08f)
			{
				_directionFlat = velocity.normalized;
			}
			Vector3 directionSmooth = _directionSmooth;
			directionSmooth.y = 0f;
			if (directionSmooth.sqrMagnitude > 1E-08f)
			{
				_directionFlatSmooth = directionSmooth.normalized;
			}
		}
		else
		{
			_speed = 0f;
			_velocity = Vector3.zero;
			_timeSinceLastMoving += Time.deltaTime;
		}
		float magnitude = Rigidbody.linearVelocity.magnitude;
		_velocityAccelerationRaw = Rigidbody.linearVelocity - _lastVelocityRaw;
		_velocityAccelerationSpeedRaw = magnitude - _lastSpeedRaw;
		_speed /= Time.deltaTime;
		_speedKPH = _speed * 3.6f;
		_velocity /= Time.deltaTime;
		_velocityAccelerationRaw /= Time.deltaTime;
		_velocityAccelerationSpeedRaw /= Time.deltaTime;
		_velocityAcceleration = _velocity - _lastVelocity;
		_velocityAccelerationSpeed = _speed - _lastSpeed;
		_lastSpeed = _speed;
		_lastVelocity = _velocity;
		_lastSpeedRaw = magnitude;
		_lastVelocityRaw = Rigidbody.linearVelocity;
		_velocityAcceleration /= Time.deltaTime;
		_velocityAccelerationSpeed /= Time.deltaTime;
		_lastPosition = PlayerTransform.position;
	}

	public void UpdateBodyVelocity()
	{
		_bodyVelocity = Rigidbody.linearVelocity;
		if (IsRagdollState)
		{
			_bodyVelocity = PlayerModelController.PlayerIkController.PlayerRagdoll.PelvisRigidBody.linearVelocity;
		}
		_bodySpeed = _bodyVelocity.magnitude;
		_bodySpeedKPH = _bodySpeed * 3.6f;
	}

	public void UpdateDirectionalVectorsInNoClipMode()
	{
		Vector3 direction = PlayerPosition - PlayerCameraTransform.position;
		direction.y = 0f;
		direction.Normalize();
		_direction = direction;
		_directionUp = Vector3.up;
		_velocity = PlayerTransform.position - _lastPosition;
		_speed = _velocity.magnitude;
		_speed /= Time.deltaTime;
		_speedKPH = _speed * 3.6f;
		_velocity /= Time.deltaTime;
		_lastPosition = PlayerTransform.position;
		_lastRotation = PlayerTransform.rotation;
	}

	public void UpdateAngularVelocity()
	{
		if (_speed > 0.0001f)
		{
			Quaternion quaternion = PlayerTransform.rotation * Quaternion.Inverse(_lastRotation);
			Vector3 lhs = new Vector3(quaternion.x, quaternion.y, quaternion.z);
			_angularVelocityUp = (_playerCollisionHandler.IsGrounded ? (-_playerCollisionHandler.FloorDirection) : Vector3.up);
			Vector3 vector = Vector3.Cross(lhs, _angularVelocityUp);
			_angularVelocityDirection = vector.normalized;
			_angularVelocityDirectionSmooth = Vector3.Lerp(_oldAngularVelocityDirectionSmooth, vector.normalized, _speed).normalized;
			_oldAngularVelocityDirectionSmooth = _angularVelocityDirectionSmooth;
			_lastRotation = PlayerTransform.rotation;
		}
		float magnitude = Rigidbody.angularVelocity.magnitude;
		_ballSurfaceSpeed = magnitude * BallRadius;
		_ballSurfaceVelocity = _angularVelocityDirection * _ballSurfaceSpeed;
	}

	public void UpdateNoClipMovements()
	{
		Vector3 movementInput = _movementInput;
		float target = (InputControls.GetButton(GTWUserActions.NOCLIPMOVEUP) ? 1f : 0f) + (InputControls.GetButton(GTWUserActions.NOCLIPMOVEDOWN) ? (-1f) : 0f);
		_noClipVerticalInput = Mathf.MoveTowards(_noClipVerticalInput, target, Time.deltaTime * 5f);
		movementInput.y = _noClipVerticalInput;
		_noClipVelocity = Vector3.MoveTowards(_noClipVelocity, movementInput, Time.deltaTime * 5f);
		float num = 10f;
		bool flag = noClipHighSpeedMode;
		if (InputControls.GetButton(GTWUserActions.NOCLIPHIGHSPEED))
		{
			flag = !flag;
		}
		if (flag)
		{
			num *= noClipHighSpeedMultiplier;
		}
		PlayerTransform.position += _noClipVelocity * Time.deltaTime * num;
	}

	public void ActivateGrabLink()
	{
		if (_isGrabLinkActive || _grabCooldownTimeLeft > 0f)
		{
			return;
		}
		PlayerCollisionHandler.GroundHitData groundHitData = PlayerCollisionHandler.CurrentCurrentGroundHitData;
		if (!PlayerCollisionHandler.IsGrounded)
		{
			if (PlayerCollisionHandler.PreviousGroundHitData.time < _grabGracePeriod)
			{
				groundHitData = PlayerCollisionHandler.PreviousGroundHitData;
				PlayerCollisionHandler.Reground();
			}
			if (!PlayerCollisionHandler.IsGrounded)
			{
				return;
			}
		}
		RetargetGrabLink();
		if (_grabRagdoll)
		{
			PlayerModelController.PlayerGrounder.UpdateGrounder();
			if (!PlayerModelController.PlayerGrounder.LeftHandGrounded && !PlayerModelController.PlayerGrounder.RightHandGrounded)
			{
				return;
			}
			PlayerIkController.PlayerRagdoll.SetRagdollActive(isActive: true);
			PlayerIkController.PlayerRagdoll.ActivateHandFixedJoints(groundHitData.hit.transform);
		}
		else
		{
			Vector3 grabTargetPosition = GrabTargetPosition;
			Quaternion grabTargetRotation = GrabTargetRotation;
			bool num = _grabLinkCollider.gameObject.tag == "Sticky";
			Rigidbody.MoveRotation(grabTargetRotation);
			if (num)
			{
				Rigidbody.linearVelocity = (grabTargetPosition - Rigidbody.position) / FixedTimeSync.FixedDeltaTime;
			}
			else
			{
				Rigidbody.linearVelocity = Vector3.ProjectOnPlane(Rigidbody.linearVelocity, groundHitData.FloorNormal);
			}
			Rigidbody.angularVelocity = Vector3.zero;
			_lastGrabTargetPosition = grabTargetPosition;
			_lastGrabVelocity = Velocity;
			_lastGrabVelocities.Clear();
			AddLastGrabVelocity(_lastGrabVelocity);
			_lastGrabRigidbodyVelocity = Rigidbody.linearVelocity;
		}
		_grabHoldVelocityTime = -1f;
		_grabCooldownTimeLeft = 0.25f;
		_isGrabLinkActive = true;
		OnActivateGrab?.Invoke();
	}

	private void RetargetGrabLink()
	{
		if (PlayerCollisionHandler.IsGrounded)
		{
			RaycastHit hit = PlayerCollisionHandler.Hit;
			_grabLinkParent = hit.transform;
			_grabLinkCollider = hit.collider;
			_grabLinkNormal = hit.normal;
			Quaternion quaternion = Quaternion.LookRotation(Vector3.Cross(Vector3.Cross(hit.normal, PlayerModelController.transform.forward), hit.normal), hit.normal);
			_grabLinkParentRigidbody = _grabLinkParent.GetComponent<Rigidbody>();
			Vector3 vector = ((_grabLinkParentRigidbody != null) ? _grabLinkParentRigidbody.linearVelocity : Vector3.zero);
			Vector3 position = hit.point + hit.normal * BallRadius + vector * FixedTimeSync.FixedDeltaTime;
			_grabLocalLocation = new GTWExtensions.Location
			{
				Position = _grabLinkParent.InverseTransformPoint(position),
				Rotation = Quaternion.Inverse(_grabLinkParent.rotation) * quaternion
			};
		}
	}

	public void DeactivateGrabLink(float grabCooldown)
	{
		_grabCooldownTimeLeft = grabCooldown;
		if (_isGrabLinkActive && !_forceHoldGrab)
		{
			DeactivateGrabLink();
		}
	}

	public void DeactivateGrabLink()
	{
		if (_isGrabLinkActive && !_forceHoldGrab)
		{
			if (_grabbingStickySurface)
			{
				SetVelocity(_lastGrabVelocity, Vector3.zero);
			}
			if (_grabRagdoll)
			{
				Vector3 to = PlayerIkController.PelvisBone.position - GrabTargetPosition;
				float num = Mathf.Clamp01(Vector3.Angle(Vector3.down, to) / 90f);
				Rigidbody.linearVelocity = new Vector3(0f, num * _ledgeGrabFlingVerticalForce, 0f);
			}
			if (!_grabLinkCollider.gameObject.CompareTag("Slippery") && !_grabLinkCollider.gameObject.CompareTag("Sticky"))
			{
				_highFrictionModeTime = 0.25f;
			}
			PlayerIkController.PlayerRagdoll.SetRagdollActive(isActive: false);
			PlayerIkController.PlayerRagdoll.DeactivateHandFixedJoints();
			_isGrabLinkActive = false;
			_grabbingStickySurface = false;
			_grabRagdoll = false;
			OnDeactivateGrab?.Invoke();
		}
	}

	public void TurnPlayerTowardCamera()
	{
		Vector3 directionFlat = PlayerPosition - PlayerCameraTransform.position;
		directionFlat.y = 0f;
		directionFlat.Normalize();
		_directionFlat = directionFlat;
		_directionFlatSmooth = _directionFlat;
		_angularVelocityDirection = _directionFlat;
		_angularVelocityDirectionSmooth = _directionFlat;
		_oldAngularVelocityDirectionSmooth = _directionFlat;
		Vector3 rhs = Vector3.Cross(_directionFlat, _directionUp);
		_direction = Vector3.Cross(_directionUp, rhs);
		_directionSmooth = _direction;
		_oldDirectionSmooth = _direction;
	}

	private void UpdateGrabLinkFixedUpdate()
	{
		if (!_isGrabLinkActive)
		{
			return;
		}
		if (_grabLinkParent == null || !_grabLinkParent.gameObject.activeInHierarchy || _grabLinkCollider == null || !_grabLinkCollider.enabled)
		{
			DeactivateGrabLink();
			return;
		}
		if (_grabRagdoll)
		{
			Rigidbody.linearVelocity = Vector3.zero;
			Rigidbody.angularVelocity = Vector3.zero;
			Rigidbody.MovePosition(PlayerIkController.PlayerRagdoll.RagdollBallTarget.position);
			PlayerIkController.PlayerRagdoll.UpdateHandFixedJoints();
			Vector3 force = MovementInput * _ledgeGrabForceControl;
			PlayerIkController.PlayerRagdoll.PelvisRigidBody.AddForce(force, ForceMode.Acceleration);
			return;
		}
		_grabbingStickySurface = _grabLinkCollider.gameObject.CompareTag("Sticky");
		bool flag = _grabLinkCollider.gameObject.layer == _slipperyLayer;
		float num = Vector3.Distance(Rigidbody.transform.position, _lastGrabTargetPosition);
		if (!PlayerCollisionHandler.IsGrounded || num > _grabBreakForce + _lastGrabRigidbodyVelocity.magnitude)
		{
			Debug.Log("break grab:" + num);
			DeactivateGrabLink();
			return;
		}
		if (!_grabbingStickySurface)
		{
			RetargetGrabLink();
			if (PlayerCollisionHandler.FloorAngle > 110f)
			{
				PlayerModelController.UpdateModelPositionWhileGrabbing(instant: true);
				PlayerModelController.PlayerGrounder.UpdateGrounder();
				PlayerIkController.PlayerRagdoll.SetRagdollActive(isActive: true);
				PlayerIkController.PlayerRagdoll.ActivateHandFixedJoints(PlayerCollisionHandler.Hit.transform);
				_grabRagdoll = true;
				return;
			}
		}
		Vector3 grabTargetPosition = GrabTargetPosition;
		Quaternion grabTargetRotation = GrabTargetRotation;
		if (!_grabbingStickySurface)
		{
			if (PlayerCollisionHandler.FloorAngle > 45f)
			{
				float num2 = (flag ? 0.1f : 0.05f);
				if (Rigidbody.linearVelocity.y > Gravity.y * num2)
				{
					Rigidbody.AddForce(Gravity, ForceMode.Acceleration);
				}
			}
			Rigidbody.AddForce((grabTargetPosition - Rigidbody.position).normalized, ForceMode.Acceleration);
		}
		else
		{
			Rigidbody.linearVelocity = (grabTargetPosition - Rigidbody.transform.position) / FixedTimeSync.FixedDeltaTime;
		}
		Rigidbody.angularVelocity = Vector3.zero;
		Rigidbody.MoveRotation(grabTargetRotation);
		_lastGrabTargetPosition = grabTargetPosition;
		_lastGrabRigidbodyVelocity = Rigidbody.linearVelocity;
		AddLastGrabVelocity(Rigidbody.linearVelocity);
		_lastGrabVelocity = LastGrabVelocityAverage();
		_lastGrabVelocity = Rigidbody.linearVelocity.normalized * _lastGrabVelocity.magnitude;
	}

	private void AddLastGrabVelocity(Vector3 velocity)
	{
		_lastGrabVelocities.Enqueue(velocity);
		while (_lastGrabVelocities.Count > 5)
		{
			_lastGrabVelocities.Dequeue();
		}
	}

	private Vector3 LastGrabVelocityAverage()
	{
		Vector3 zero = Vector3.zero;
		if (_lastGrabVelocities.Count == 0)
		{
			return zero;
		}
		foreach (Vector3 lastGrabVelocity in _lastGrabVelocities)
		{
			zero += lastGrabVelocity;
		}
		return zero / _lastGrabVelocities.Count;
	}

	private void UpdateGrabLink()
	{
		if (_isGrabLinkActive && !_grabRagdoll)
		{
			Vector3 characterSpaceInput = CharacterSpaceInput;
			Vector3 force = Vector3.ClampMagnitude(-VelocityAcceleration * 0.01f, 0.1f) + characterSpaceInput * 0.1f;
			PlayerIkController.SetBodyHorizontalForce(force);
		}
	}

	protected override void OnPlayerTakeDamage(object sender, HealthEventArgs e)
	{
		throw new NotImplementedException();
	}

	protected override void OnPlayerKilled(object sender, HealthEventArgs e)
	{
		throw new NotImplementedException();
	}

	public override void SetMovementEnabled(bool active)
	{
		throw new NotImplementedException();
	}

	[ContextMenu("PrintCharacterInfo")]
	private void PrintCharacterInfo()
	{
		StringBuilder stringBuilder = new StringBuilder("Player State Info: ...\n");
		stringBuilder.Append($"Player Transform P={base.transform.position}\n");
		stringBuilder.Append(".\n");
		stringBuilder.Append($"Player Rigidbody Transform P={_rigidbody.transform.position} (correct PlayerPosition)\n");
		stringBuilder.Append($"Player Ragdoll Pelvis Transform P={_bodyEventTrigger.transform.position}\n");
		PlayerPhysicsOverride.PhysicsOverride physicsOverride = PlayerPhysicsOverride?.GetOverride();
		stringBuilder.Append("Player Physics Override " + NullMsg(physicsOverride) + " source=" + GOName(physicsOverride?.source) + "\n");
		stringBuilder.Append(".\n");
		stringBuilder.Append("CinemachineVirtualCamera standby mode=" + NullVal((PlayerVirtualCameraController?.CVC)?.m_StandbyUpdate.ToString()) + "\n");
		stringBuilder.Append("Player AimTarget Transform P=" + NullVal(PlayerVirtualCameraController?.AimTarget.ToString()) + "\n");
		stringBuilder.Append("Player FollowCam Transform P=" + NullVal(PlayerVirtualCameraController?.FollowCam.ToString()) + "\n");
		stringBuilder.Append("Player FollowPosition Transform P=" + NullVal(PlayerVirtualCameraController?.FollowPosition.ToString()) + "\n");
		PlayerCameraOverride.CameraOverride cameraOverride = PlayerVirtualCameraController?.PlayerCameraOverride?.GetOverride();
		stringBuilder.Append("Player Camera Override " + NullMsg(cameraOverride) + " source=" + GOName(cameraOverride?.source) + "\n");
		stringBuilder.Append(".\n");
		PlayerRagdoll playerRagdoll = PlayerModelController?.PlayerIkController?.PlayerRagdoll;
		bool flag = (bool)playerRagdoll && playerRagdoll.IsRagdollEnabled;
		RagdollUtility ragdollUtility = playerRagdoll?.RagdollUtility;
		bool flag2 = (bool)ragdollUtility && ragdollUtility.isRagdoll;
		stringBuilder.Append($"Player Ragdoll IsRagdollState={IsRagdollState}, IsRagEnabled={flag}, IsRagdoll={flag2}\n");
		stringBuilder.Append(".\n");
		stringBuilder.Append($"Player grabAbilityAvailable={grabAbilityAvailable}\n");
		stringBuilder.Append($"Player slowMotionAbilityAvailable={slowMotionAbilityAvailable}\n");
		stringBuilder.Append($"Player noClipAbilityAvailable={noClipAbilityAvailable}\n");
		stringBuilder.Append($"Player ragDollAbilityAvailable={ragDollAbilityAvailable}\n");
		stringBuilder.Append($"Player restartAbilityAvailable={restartAbilityAvailable}\n");
		stringBuilder.Append($"Player restartAbilityAvailable={restartStartingCheckpointAbilityAvailable}\n");
		stringBuilder.Append($"Player noClipHighSpeedMode={noClipHighSpeedMode}\n");
		stringBuilder.Append(".\n");
		stringBuilder.Append($"Player IsMoveState={IsMoveState}, Velocity={Velocity}, BallSurfaceVelocity={BallSurfaceVelocity}, Speed={Speed}\n");
		stringBuilder.Append($"Player BodyVelocity={BodyVelocity}, BodySpeed={BodySpeed}, BodySpeedKPH={BodySpeedKPH}\n");
		stringBuilder.Append($"Player Direction={Direction}, GravityDirection={GravityDirection}, Gravity={Gravity}\n");
		stringBuilder.Append($"Player AngularVelocityDirection={AngularVelocityDirection}\n");
		stringBuilder.Append($"Player IsMoving={IsMoving}, IsBodyMoving={IsBodyMoving}\n");
		stringBuilder.Append(".\n");
		stringBuilder.Append($"Player IsGrabLinkActive={IsGrabLinkActive}\n");
		stringBuilder.Append($"Player IsGrabRagDoll={IsGrabRagDoll}\n");
		stringBuilder.Append($"Player GrabbingStickySurface={GrabbingStickySurface}\n");
		stringBuilder.Append("Player GrabLinkCollider=" + GOName(_grabLinkCollider) + "\n");
		stringBuilder.Append($"Player GrabLinkNormal={GrabLinkNormal}\n");
		stringBuilder.Append("Player GrabLinkParentRigidbody=" + GOName(_grabLinkParentRigidbody) + "\n");
		stringBuilder.Append($"Player IsGrabLinkActive={IsGrabLinkActive}\n");
		if (GrabLinkParent != null)
		{
			stringBuilder.Append($"Player GrabTargetPosition={GrabTargetPosition}\n");
			stringBuilder.Append($"Player GrabTargetRotation={GrabTargetRotation}\n");
		}
		stringBuilder.Append($"Player HighFrictionMode={HighFrictionMode}\n");
		stringBuilder.Append(".\n");
		stringBuilder.Append($"Player ForceHoldGrab={ForceHoldGrab}\n");
		stringBuilder.Append($"Player _grabCooldownTimeLeft={_grabCooldownTimeLeft}\n");
		stringBuilder.Append($"Player _grabLocalLocation position={_grabLocalLocation.Position}, rotation={_grabLocalLocation.Rotation}\n");
		stringBuilder.Append($"Player _lastGrabTargetPosition={_lastGrabTargetPosition}\n");
		stringBuilder.Append($"Player _lastGrabVelocity={_lastGrabVelocity}\n");
		stringBuilder.Append($"Player _lastGrabRigidbodyVelocity={_lastGrabRigidbodyVelocity}\n");
		stringBuilder.Append($"Player _highFrictionModeTime={_highFrictionModeTime}\n");
		stringBuilder.Append($"Player _slipperyLayer={_slipperyLayer}\n");
		stringBuilder.Append($"Player _hasPlayerInputted={_hasPlayerInputted}\n");
		Debug.LogError(stringBuilder.ToString());
	}

	private string NullVal(string value)
	{
		if (value == null)
		{
			return "(...)";
		}
		return value;
	}

	private string GOName(object obj)
	{
		if (obj == null)
		{
			return "(...)";
		}
		Component component = obj as Component;
		if (component != null)
		{
			obj = component.gameObject;
		}
		GameObject gameObject = obj as GameObject;
		if (gameObject == null)
		{
			return "(...)";
		}
		return gameObject.name;
	}

	private string NullMsg(object obj)
	{
		if (obj == null)
		{
			return "(is null)";
		}
		return "(is not null)";
	}
}
