using System;
using Isto.GTW.DebugTools;
using UnityEngine;

namespace Isto.GTW.Player;

public class PlayerModelController : MonoBehaviour
{
	[SerializeField]
	private PlayerController _playerController;

	[SerializeField]
	private Transform _root;

	[Tooltip("Speed at which the character model rotates when grounded. \n\nBased on the values in the playerPhysics presets Decided by feel.\nIn degrees per second")]
	[SerializeField]
	private float _groundedRotationSpeed = 360f;

	[Tooltip("Speed at which the character model rotates when in the air. \n\nBased on the values in the playerPhysics presets Decided by feel.\nIn degrees per second")]
	[SerializeField]
	private float _airRotationSpeed = 360f;

	[Tooltip("Controls the character model's tilt back or forward depending on its acceleration\nx is in m/s, y is in degrees\n")]
	[SerializeField]
	private AnimationCurve _accelerationPitchCurve = AnimationCurve.Constant(-5f, 5f, 0f);

	[SerializeField]
	private float _accelerationPitchResponseTime = 0.05f;

	private PlayerIkController _playerIkController;

	private PlayerGrounder _playerGrounder;

	private int _elevatorLayer;

	private Quaternion _targetRotation = Quaternion.identity;

	private Vector3 _up = Vector3.up;

	private Vector3 _forward = Vector3.forward;

	private float _accelerationPitch;

	private float _accelerationPitchVelocity;

	private float _grabLinkWeight;

	private Vector3 _grabInitialPosition = Vector3.zero;

	private Quaternion _grabInitialRotation = Quaternion.identity;

	private Outline _outlineShader;

	public bool ShowDebug => _playerController.showDebug;

	public PlayerController PlayerController => _playerController;

	public PlayerIkController PlayerIkController => _playerIkController;

	public PlayerGrounder PlayerGrounder => _playerGrounder;

	public Transform ModelRoot => _root;

	public Quaternion TargetRotation => _targetRotation;

	public Outline OutlineShader => _outlineShader;

	private void Awake()
	{
		_playerIkController = GetComponent<PlayerIkController>();
		_playerGrounder = GetComponent<PlayerGrounder>();
		_outlineShader = GetComponentInChildren<Outline>();
		_outlineShader.enabled = false;
		_elevatorLayer = LayerMask.NameToLayer("Elevator");
		_targetRotation = base.transform.rotation;
		_forward = _playerController.PlayerTransform.forward;
		_up = _playerController.PlayerTransform.up;
		PlayerController playerController = _playerController;
		playerController.OnResetVelocity = (Action)Delegate.Combine(playerController.OnResetVelocity, new Action(PlayerController_OnResetVelocity));
		PlayerController playerController2 = _playerController;
		playerController2.OnActivateGrab = (Action)Delegate.Combine(playerController2.OnActivateGrab, new Action(PlayerController_OnActivateGrabLink));
	}

	private void OnDestroy()
	{
		PlayerController playerController = _playerController;
		playerController.OnResetVelocity = (Action)Delegate.Remove(playerController.OnResetVelocity, new Action(PlayerController_OnResetVelocity));
		PlayerController playerController2 = _playerController;
		playerController2.OnActivateGrab = (Action)Delegate.Remove(playerController2.OnActivateGrab, new Action(PlayerController_OnActivateGrabLink));
	}

	private void Update()
	{
		if (!PlayerIkController.PlayerRagdoll.IsRagdollEnabled)
		{
			if (_playerController.IsGrabLinkActive)
			{
				_grabLinkWeight += Time.deltaTime * 10f;
				UpdateModelPositionWhileGrabbing();
			}
			else
			{
				_grabLinkWeight = 0f;
				UpdateModelPosition();
			}
		}
	}

	private void UpdateModelPosition()
	{
		base.transform.position = _playerController.PlayerPosition;
		float num = (_playerController.PlayerCollisionHandler.IsGrounded ? _groundedRotationSpeed : _airRotationSpeed);
		Vector3 vector = (_playerController.PlayerCollisionHandler.IsGrounded ? _playerController.PlayerCollisionHandler.FloorNormal : Vector3.up);
		Vector3 directionSmooth = _playerController.DirectionSmooth;
		if (!PlayerController.IsGrabLinkActive)
		{
			(vector, directionSmooth) = GetDirectionTargets();
		}
		else
		{
			directionSmooth = PlayerController.Rigidbody.transform.forward;
			vector = PlayerController.Rigidbody.transform.up;
		}
		Vector3 lhs = Vector3.Cross(directionSmooth, vector);
		Vector3 vector2 = -vector + directionSmooth;
		Vector3 vector3 = -vector + -directionSmooth;
		Vector3 normalized = (vector2 / 2f).normalized;
		Vector3 normalized2 = (vector3 / 2f).normalized;
		if (GroundRaycast(normalized, out var hit))
		{
			vector2 = hit.point - _playerController.PlayerPosition;
			if (ShowDebug)
			{
				DebugExtensions.DrawArrow(_playerController.PlayerPosition, hit.point, Color.blue);
			}
		}
		if (GroundRaycast(normalized2, out hit))
		{
			vector3 = hit.point - _playerController.PlayerPosition;
			if (ShowDebug)
			{
				DebugExtensions.DrawArrow(_playerController.PlayerPosition, hit.point, Color.blue);
			}
		}
		directionSmooth = (vector2 - vector3).normalized;
		vector = Vector3.Cross(lhs, directionSmooth);
		_up = vector;
		_forward = directionSmooth;
		lhs = Vector3.Cross(_up, _forward);
		_forward = Vector3.Cross(lhs, _up);
		if (!(_forward == Vector3.zero) && !(_up == Vector3.zero))
		{
			_targetRotation = Quaternion.LookRotation(_forward, _up);
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, _targetRotation, Time.deltaTime * num);
		}
	}

	public void UpdateModelPositionWhileGrabbing(bool instant = false)
	{
		Quaternion quaternion = _playerController.GrabTargetRotation;
		bool num = _playerController.GrabLinkCollider.gameObject.CompareTag("Sticky");
		if (!num && PlayerController.Speed > 0.001f)
		{
			float num2 = Vector3.SignedAngle(_playerController.DirectionFlatSmooth, _playerController.MovementInput, Vector3.up);
			Vector3 vector = quaternion * Vector3.forward;
			Vector3 vector2 = quaternion * Vector3.up;
			Vector3 vector3 = PlayerController.Velocity.normalized;
			if (instant)
			{
				vector = -vector3;
			}
			else
			{
				if (Vector3.Angle(vector, vector3) < 10f)
				{
					vector3 = Quaternion.AngleAxis(0f - num2, vector2) * vector3;
				}
				vector = Vector3.RotateTowards(vector, -vector3, Time.deltaTime * PlayerController.Speed * 1f, float.MaxValue);
			}
			quaternion = Quaternion.LookRotation(vector, vector2);
		}
		if (num)
		{
			base.transform.position = _playerController.GrabTargetPosition;
		}
		else
		{
			base.transform.position = _playerController.PlayerTransform.position;
		}
		base.transform.rotation = quaternion;
	}

	private void PlayerController_OnActivateGrabLink()
	{
		_grabInitialPosition = base.transform.position;
		_grabInitialRotation = base.transform.rotation;
	}

	private (Vector3, Vector3) GetDirectionTargets()
	{
		Vector3 item = (_playerController.PlayerCollisionHandler.IsGrounded ? _playerController.PlayerCollisionHandler.FloorNormal : Vector3.up);
		Vector3 directionSmooth = _playerController.DirectionSmooth;
		directionSmooth = _playerController.AngularVelocityDirectionSmooth;
		if (!_playerController.PlayerCollisionHandler.IsGrounded)
		{
			directionSmooth.y = _playerController.DirectionSmooth.y;
			directionSmooth.Normalize();
		}
		if (_playerController.PlayerCollisionHandler.IsGrounded && _playerController.PlayerCollisionHandler.GroundLayer == _elevatorLayer)
		{
			directionSmooth = _playerController.DirectionFlatSmooth;
		}
		if (_playerController.PlayerCollisionHandler.IsGrounded && Mathf.Abs(directionSmooth.y) > 0.9999f && Mathf.Abs(item.y) > 0.9999f)
		{
			directionSmooth = _playerController.PlayerTransform.forward;
		}
		if ((!_playerController.PlayerCollisionHandler.IsGrounded && directionSmooth.y > 0.5f) || directionSmooth.y < -0.5f)
		{
			item = _up;
		}
		return (item, directionSmooth);
	}

	private void UpdateAccelerationPitch()
	{
		float num = 0f;
		if ((double)_playerController.MovementInput.sqrMagnitude > 0.001)
		{
			num = Vector3.Angle(_playerController.DirectionFlatSmooth, _playerController.MovementInput);
			num = ((!(num < 90f)) ? Mathf.InverseLerp(90f, 180f, num) : Mathf.InverseLerp(90f, 0f, num));
		}
		float target = (_playerController.PlayerCollisionHandler.IsGrounded ? _accelerationPitchCurve.Evaluate(_playerController.VelocityAccelerationSpeed * num) : 0f);
		_accelerationPitch = Mathf.SmoothDamp(_accelerationPitch, target, ref _accelerationPitchVelocity, _accelerationPitchResponseTime);
		Vector3 eulerAngles = _root.localRotation.eulerAngles;
		eulerAngles.x = _accelerationPitch;
		_root.localRotation = Quaternion.Euler(eulerAngles);
	}

	private bool GroundRaycast(Vector3 direction, out RaycastHit hit)
	{
		float num = 1.5f * _playerController.BallRadius;
		float num2 = 0.1f;
		Vector3 playerPosition = _playerController.PlayerPosition;
		if (Physics.SphereCast(playerPosition, num2, direction, out hit, num, _playerController.PlayerCollisionHandler.GroundLayerMask))
		{
			if (ShowDebug)
			{
				DebugExtensions.DrawArrow(playerPosition, hit.point, new Color(0f, 0f, 1f));
			}
			return true;
		}
		if (ShowDebug)
		{
			DebugExtensions.DrawArrow(playerPosition, playerPosition + direction * (num + num2), new Color(0f, 0.5f, 1f));
		}
		return false;
	}

	private void PlayerController_OnResetVelocity()
	{
		_forward = _playerController.PlayerTransform.forward;
		_up = _playerController.PlayerTransform.up;
		_accelerationPitch = 0f;
		_accelerationPitchVelocity = 0f;
		base.transform.position = _playerController.PlayerPosition;
		base.transform.rotation = Quaternion.LookRotation(_forward, _up);
	}
}
