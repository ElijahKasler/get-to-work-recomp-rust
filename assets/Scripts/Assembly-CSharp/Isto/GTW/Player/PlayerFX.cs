using System;
using UnityEngine;

namespace Isto.GTW.Player;

public class PlayerFX : MonoBehaviour
{
	[Serializable]
	private struct ImpactFXRef
	{
		public string internalName;

		public float impulse;

		public ParticleSystem fxRef;
	}

	[SerializeField]
	private ImpactFXRef[] _landFX = new ImpactFXRef[1];

	[SerializeField]
	private float _poofCooldown = 0.5f;

	[Space]
	[Tooltip("Top speed measured in game")]
	[SerializeField]
	private float _playerTopSpeedKPH = 60f;

	[Tooltip("Speed at which the sound reaches its intended volume.\nControls how fast the wheel sound fades out when going airbone.\nA Higher value will cut out faster")]
	[SerializeField]
	private float _wheelSpeedSoundCoefficient = 2f;

	[SerializeField]
	private float _windSpeedSoundCoefficientRising = 3f;

	[SerializeField]
	private float _windSpeedSoundCoefficientLowering = 1f;

	[Space]
	[SerializeField]
	private float _minImpulseLand = 3000f;

	[SerializeField]
	private float _minImpulseHurt = 10000f;

	private PlayerController _playerController;

	private float _wheelSpeed;

	private float _windSpeed;

	private float _lastHurtTime = float.MinValue;

	private Vector3 PlayerPosition
	{
		get
		{
			if (!_playerController.IsMoveState)
			{
				return _playerController.PlayerIkController.PelvisBone.position;
			}
			return _playerController.PlayerPosition;
		}
	}

	private void Awake()
	{
		_playerController = GetComponentInParent<PlayerController>();
	}

	private void Start()
	{
		PlayerCollisionHandler playerCollisionHandler = _playerController.PlayerCollisionHandler;
		playerCollisionHandler.OnCollision = (Action<Collision>)Delegate.Combine(playerCollisionHandler.OnCollision, new Action<Collision>(PlayerCollisionHandler_OnCollision));
		PlayerRagdoll playerRagdoll = _playerController.PlayerIkController.PlayerRagdoll;
		playerRagdoll.OnRagdollCollisionHit = (Action<Vector3, Transform>)Delegate.Combine(playerRagdoll.OnRagdollCollisionHit, new Action<Vector3, Transform>(PlayerRagdoll_OnRagdollCollisionHit));
	}

	private void OnDestroy()
	{
		PlayerCollisionHandler playerCollisionHandler = _playerController.PlayerCollisionHandler;
		playerCollisionHandler.OnCollision = (Action<Collision>)Delegate.Remove(playerCollisionHandler.OnCollision, new Action<Collision>(PlayerCollisionHandler_OnCollision));
		PlayerRagdoll playerRagdoll = _playerController.PlayerIkController.PlayerRagdoll;
		playerRagdoll.OnRagdollCollisionHit = (Action<Vector3, Transform>)Delegate.Remove(playerRagdoll.OnRagdollCollisionHit, new Action<Vector3, Transform>(PlayerRagdoll_OnRagdollCollisionHit));
	}

	private void Update()
	{
		bool isGrounded = _playerController.PlayerCollisionHandler.IsGrounded;
		_ = _playerController.PlayerCollisionHandler.HasJustLeftGround;
		Mathf.Clamp01(_playerController.BodyVelocity.magnitude * 3.6f / _playerTopSpeedKPH);
		float num = Mathf.Clamp01(_playerController.CurrentSpeedKPH / _playerTopSpeedKPH);
		if (!isGrounded || _playerController.PlayerIkController.PlayerRagdoll.IsRagdollEnabled)
		{
			num = 0f;
		}
		if (_playerController.GrabbingStickySurface)
		{
			num = 0f;
		}
		if ((double)_playerController.MovementInput.sqrMagnitude > 0.001)
		{
			float f = Vector3.SignedAngle(_playerController.DirectionFlat, _playerController.MovementInput, Vector3.up);
			num *= 1f + Mathf.InverseLerp(0f, 45f, Mathf.Abs(f)) * 0.5f;
		}
	}

	private void PlayerRagdoll_OnRagdollCollisionHit(Vector3 impulse, Transform bodyPart)
	{
		float magnitude = impulse.magnitude;
		if (magnitude > 0.001f && !_playerController.IsGrabLinkActive)
		{
			Hurt(magnitude);
			BodyImpact(magnitude);
		}
	}

	private void PlayerCollisionHandler_OnCollision(Collision collision)
	{
		Land(collision.contacts[0].normal, collision.impulse.magnitude, collision.collider);
	}

	private static void PlayImpactFX(ImpactFXRef[] impactFX, float hitImpulse, Vector3 position)
	{
		for (int num = impactFX.Length - 1; num >= 0; num--)
		{
			if (hitImpulse > impactFX[num].impulse)
			{
				if (impactFX[num].fxRef != null)
				{
					UnityEngine.Object.Instantiate(impactFX[num].fxRef, position, Quaternion.identity);
				}
				break;
			}
		}
	}

	public void Hurt(float hitImpulse)
	{
		_ = _lastHurtTime + _poofCooldown;
		_ = Time.time;
	}

	private void Land(float hitImpulse)
	{
		if (_playerController.PlayerCollisionHandler.PreviousGroundHitData.time > 0.05f)
		{
			PlayImpactFX(_landFX, hitImpulse, PlayerPosition);
		}
	}

	private void BodyImpact(float hitImpulse)
	{
	}

	private void Land(Vector3 floorNormal, float hitImpulse, Collider collider)
	{
		if (!(hitImpulse > _minImpulseLand))
		{
			return;
		}
		Vector3 up = _playerController.PlayerModelController.transform.up;
		bool flag = collider.CompareTag("Sticky");
		if (Vector3.Angle(floorNormal, up) > 130f)
		{
			if (!flag)
			{
				Hurt(hitImpulse);
			}
			BodyImpact(hitImpulse);
		}
		else
		{
			Land(hitImpulse);
			if (!flag && hitImpulse > _minImpulseHurt)
			{
				Hurt(hitImpulse);
			}
		}
	}
}
