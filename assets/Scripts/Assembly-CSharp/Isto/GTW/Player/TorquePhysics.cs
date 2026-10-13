using System;
using Isto.GTW.DebugTools;
using UnityEngine;

namespace Isto.GTW.Player;

[Serializable]
public class TorquePhysics
{
	[Header("Physics")]
	[SerializeField]
	private TorquePlayerPhysicsPreset _playerPhysicsPreset;

	private PlayerController _playerController;

	private float _currentBallRadius = -1f;

	private float _accelerationCoefficient = 1f;

	private Vector3 _gravityDirection = Vector3.down;

	private PlayerPhysicsOverride.PhysicsOverride _physicsOverride;

	public PlayerController PlayerController
	{
		get
		{
			return _playerController;
		}
		set
		{
			_playerController = value;
		}
	}

	public Rigidbody Rigidbody => PlayerController.Rigidbody;

	public float GravityMagnitude
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return 9.8f;
			}
			return _playerPhysicsPreset.gravity;
		}
	}

	public float MaxGravityAngle
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return 25f;
			}
			return _playerPhysicsPreset.maxGravityAngle;
		}
	}

	public float MaxTorque
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return 20f;
			}
			return _playerPhysicsPreset.maxTorque;
		}
	}

	public float Acceleration
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return 80f;
			}
			return _playerPhysicsPreset.acceleration;
		}
	}

	public float VelocityDrag
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return 0.01f;
			}
			return _playerPhysicsPreset.velocityDrag;
		}
	}

	public float GrabAbilityDrag
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return 5f;
			}
			return _playerPhysicsPreset.grabAbilityDrag;
		}
	}

	public AnimationCurve DragSpeedCurve
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return AnimationCurve.Linear(0f, 0f, 200f, 0f);
			}
			return _playerPhysicsPreset.dragSpeedCurve;
		}
	}

	public AnimationCurve AngularDragSpeedCurve
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return AnimationCurve.Linear(0f, 0.1f, 1f, 0.1f);
			}
			return _playerPhysicsPreset.angularDragSpeedCurve;
		}
	}

	public float BallRadius
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return 0.25f;
			}
			return _playerPhysicsPreset.ballRadius;
		}
	}

	public AnimationCurve InputCurve
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return AnimationCurve.Linear(0f, 0f, 1f, 1f);
			}
			return _playerPhysicsPreset.inputCurve;
		}
	}

	public AnimationCurve AccelerationCurve
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return AnimationCurve.Linear(0f, 1f, 1f, 0f);
			}
			return _playerPhysicsPreset.accelerationCurve;
		}
	}

	public AnimationCurve AirAccelerationCurve
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return AnimationCurve.Linear(0f, 1f, 1f, 0f);
			}
			return _playerPhysicsPreset.airAccelerationCurve;
		}
	}

	public AnimationCurve SlopeFrictionCurve
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return AnimationCurve.Linear(20f, 1f, 45f, 0.5f);
			}
			return _playerPhysicsPreset.slopeFrictionCurve;
		}
	}

	public AnimationCurve SlopeAirControlCurve
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return AnimationCurve.Linear(20f, 0f, 45f, 1f);
			}
			return _playerPhysicsPreset.slopeAirControlCurve;
		}
	}

	public float GroundBounciness
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return 0.5f;
			}
			return _playerPhysicsPreset.groundedBounciness;
		}
	}

	public float AirBounciness
	{
		get
		{
			if (!(_playerPhysicsPreset != null))
			{
				return 0.8f;
			}
			return _playerPhysicsPreset.airBounciness;
		}
	}

	public float CurrentTorqueMaxTorqueRatio => PlayerController.CurrentTorque / MaxTorque;

	public float AccelerationCoefficient => _accelerationCoefficient;

	public Vector3 GravityDirection => _gravityDirection;

	public Vector3 Gravity
	{
		get
		{
			float num = GravityMagnitude;
			if (_physicsOverride != null && _physicsOverride.hasGravityOverride)
			{
				num = _physicsOverride.gravityOverride;
			}
			return _gravityDirection * num;
		}
	}

	public void Initialize()
	{
		UpdateBallRadius();
	}

	public void PhysicsUpdate()
	{
		_physicsOverride = PlayerController.PlayerPhysicsOverride.GetOverride();
		UpdateBallRadius();
		if (PlayerController.IsMoveState || PlayerController.IsFreezeControlsState)
		{
			UpdateFriction();
			UpdateBounciness();
			UpdateTorque();
			UpdateGravity();
		}
	}

	private void UpdateBallRadius()
	{
		if (!Mathf.Approximately(_currentBallRadius, BallRadius))
		{
			_currentBallRadius = BallRadius;
			PlayerController.MainBallCollider.radius = _currentBallRadius;
			PlayerController.DebugBallTransform.localScale = Vector3.one * (_currentBallRadius * 2f);
			PlayerController.PlayerEventTrigger.radius = _currentBallRadius;
			PlayerController.BodyEventTrigger.radius = _currentBallRadius;
		}
	}

	private void UpdateFriction()
	{
		float time = PlayerController.PlayerCollisionHandler.FloorAngle;
		if (PlayerController.HighFrictionMode)
		{
			time = 0f;
		}
		PlayerController.MainBallCollider.material.dynamicFriction = SlopeFrictionCurve.Evaluate(time);
		PlayerController.MainBallCollider.material.staticFriction = PlayerController.MainBallCollider.material.dynamicFriction;
	}

	private void UpdateBounciness()
	{
		float bounciness = ((PlayerController.PlayerCollisionHandler.GroundedTime > 0.1f) ? GroundBounciness : AirBounciness);
		if (_physicsOverride != null && _physicsOverride.hasBouninesseOverride)
		{
			bounciness = _physicsOverride.bouncinessOverride;
		}
		PlayerController.MainBallCollider.material.bounciness = bounciness;
	}

	private void UpdateTorque()
	{
		Vector3 angularVelocity = PlayerController.Rigidbody.angularVelocity;
		float magnitude = PlayerController.Rigidbody.linearVelocity.magnitude;
		Vector3 lhs = PlayerController.MovementInput;
		lhs *= InputCurve.Evaluate(lhs.magnitude);
		if (PlayerController.IsFreezeControlsState)
		{
			lhs = Vector3.zero;
		}
		if (PlayerController.IsGrabLinkActive)
		{
			lhs = Vector3.zero;
		}
		Vector3 vector = Vector3.Cross(lhs, Vector3.down) * Acceleration;
		Quaternion quaternion = Quaternion.FromToRotation(angularVelocity.normalized, new Vector3(1f, 0f, 0f));
		Vector3 vector2 = quaternion * vector;
		Vector3 vector3 = quaternion * angularVelocity;
		_accelerationCoefficient = 1f;
		if (Mathf.Sign(vector2.x) == Mathf.Sign(vector3.x))
		{
			if (PlayerController.PlayerCollisionHandler.IsGrounded)
			{
				_accelerationCoefficient = AccelerationCurve.Evaluate(Mathf.Abs(vector3.x) / MaxTorque);
			}
			else
			{
				_accelerationCoefficient = AirAccelerationCurve.Evaluate(Mathf.Abs(vector3.x) / MaxTorque);
			}
			vector2.x *= _accelerationCoefficient;
		}
		vector2 = Quaternion.Inverse(quaternion) * vector2;
		Rigidbody.AddTorque(vector2, ForceMode.Acceleration);
		Rigidbody.linearDamping = ((_physicsOverride != null && _physicsOverride.hasDragOverride) ? _physicsOverride.dragOverride : VelocityDrag);
		if (PlayerController.IsGrabLinkActive)
		{
			Rigidbody.linearDamping = Mathf.Max(Rigidbody.linearDamping, GrabAbilityDrag);
		}
		Rigidbody.linearDamping += DragSpeedCurve.Evaluate(magnitude);
		Rigidbody.angularDamping = ((_physicsOverride != null && _physicsOverride.hasAngularDragOverride) ? _physicsOverride.angularDragOverride : AngularDragSpeedCurve.Evaluate(magnitude));
		if (magnitude > 200f)
		{
			Rigidbody.linearVelocity = Vector3.ClampMagnitude(Rigidbody.linearVelocity, 200f);
		}
	}

	private void UpdateGravity()
	{
		Vector3 movementInput = PlayerController.MovementInput;
		float num = GravityMagnitude;
		if (_physicsOverride != null && _physicsOverride.hasGravityOverride)
		{
			num = _physicsOverride.gravityOverride;
		}
		Vector3 vector = Vector3.down * num;
		Vector3 vector2 = vector;
		Vector3 linearVelocity = Rigidbody.linearVelocity;
		Vector3 vector3 = Quaternion.FromToRotation(linearVelocity.normalized, new Vector3(0f, 0f, 1f)) * movementInput;
		if (vector3.z > 0f)
		{
			movementInput *= AccelerationCurve.Evaluate(vector3.z * linearVelocity.magnitude / MaxTorque);
		}
		float num2 = MaxGravityAngle;
		if (PlayerController.HighFrictionMode)
		{
			num2 *= 2f;
		}
		vector2 = Quaternion.Euler((0f - movementInput.z) * num2, 0f, movementInput.x * num2) * vector2;
		if (PlayerController.PlayerCollisionHandler.IsGrounded)
		{
			float time = Vector3.Angle(-PlayerController.PlayerCollisionHandler.FloorNormal, vector2);
			float t = SlopeAirControlCurve.Evaluate(time);
			if (PlayerController.HighFrictionMode)
			{
				t = 1f;
			}
			vector2 = Vector3.Lerp(vector, vector2, t);
		}
		if (PlayerController.showDebug)
		{
			DebugExtensions.DrawArrow(PlayerController.PlayerPosition, PlayerController.PlayerPosition + vector2 * 0.1f, Color.black);
		}
		_gravityDirection = vector2.normalized;
		if (PlayerController.IsGrabLinkActive)
		{
			_gravityDirection = vector.normalized;
			vector2 = Vector3.zero;
		}
		Rigidbody.AddForce(vector2, ForceMode.Acceleration);
		if (_physicsOverride != null && _physicsOverride.hasAdditiveVelocity)
		{
			Rigidbody.AddForce(_physicsOverride.additiveVelocity, ForceMode.Acceleration);
		}
	}
}
