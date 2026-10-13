using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Isto.GTW.Player.Audio;

public class PlayerAudio : MonoBehaviour
{
	[Serializable]
	private struct ImpactAudioRef
	{
		public float impulse;

		public EventReference _sfxRef;
	}

	[SerializeField]
	private EventReference _rollerBladeMotorRef;

	[SerializeField]
	private EventReference _rollerBladeStopScreechRef;

	[SerializeField]
	private EventReference _jumpWooshRef;

	[SerializeField]
	private ImpactAudioRef[] _bodyImpactAudio = new ImpactAudioRef[2];

	[SerializeField]
	private ImpactAudioRef[] _landAudio = new ImpactAudioRef[3];

	[SerializeField]
	private ImpactAudioRef[] _ontoRamp = new ImpactAudioRef[1];

	[SerializeField]
	private ImpactAudioRef[] _hurtRef;

	[SerializeField]
	private float _hurtCooldown = 0.5f;

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
	private float _windSpeedSoundCoefficientLowering = 2f;

	[Space]
	[SerializeField]
	private bool _wheelScreech = true;

	[SerializeField]
	private bool _jumpWoosh;

	[Space]
	[SerializeField]
	private float _minImpulseLand = 1000f;

	[SerializeField]
	private float _minImpulseHurt = 10000f;

	private PlayerController _playerController;

	private EventInstance _motorEvent;

	private float _wheelSpeed;

	private float _windSpeed;

	private float _lastHurtTime = float.MinValue;

	private bool _canScreech = true;

	private EventInstance _screechEvent;

	private string _wheelSpeedParam = "WheelSpeed";

	private string _windSpeedParam = "WindSpeed";

	private string _wheelScreechParam = "PlayerScreechStrength";

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
		_motorEvent = RuntimeManager.CreateInstance(_rollerBladeMotorRef);
		_motorEvent.start();
		_screechEvent = RuntimeManager.CreateInstance(_rollerBladeStopScreechRef);
		if (_wheelScreech)
		{
			_screechEvent.start();
		}
		RuntimeManager.AttachInstanceToGameObject(_motorEvent, _playerController.PlayerTransform, _playerController.Rigidbody);
		RuntimeManager.AttachInstanceToGameObject(_screechEvent, _playerController.PlayerTransform, _playerController.Rigidbody);
		PlayerCollisionHandler playerCollisionHandler = _playerController.PlayerCollisionHandler;
		playerCollisionHandler.OnCollision = (Action<Collision>)Delegate.Combine(playerCollisionHandler.OnCollision, new Action<Collision>(PlayerCollisionHandler_OnCollision));
		PlayerRagdoll playerRagdoll = _playerController.PlayerIkController.PlayerRagdoll;
		playerRagdoll.OnRagdollCollisionHit = (Action<Vector3, Transform>)Delegate.Combine(playerRagdoll.OnRagdollCollisionHit, new Action<Vector3, Transform>(PlayerRagdoll_OnRagdollCollisionHit));
	}

	private void OnDestroy()
	{
		_motorEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		_screechEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
		PlayerCollisionHandler playerCollisionHandler = _playerController.PlayerCollisionHandler;
		playerCollisionHandler.OnCollision = (Action<Collision>)Delegate.Remove(playerCollisionHandler.OnCollision, new Action<Collision>(PlayerCollisionHandler_OnCollision));
		PlayerRagdoll playerRagdoll = _playerController.PlayerIkController.PlayerRagdoll;
		playerRagdoll.OnRagdollCollisionHit = (Action<Vector3, Transform>)Delegate.Remove(playerRagdoll.OnRagdollCollisionHit, new Action<Vector3, Transform>(PlayerRagdoll_OnRagdollCollisionHit));
	}

	private void Update()
	{
		bool isGrounded = _playerController.PlayerCollisionHandler.IsGrounded;
		bool hasJustLeftGround = _playerController.PlayerCollisionHandler.HasJustLeftGround;
		float num = Mathf.Clamp01(_playerController.BodyVelocity.magnitude * 3.6f / _playerTopSpeedKPH);
		float num2 = Mathf.Clamp01(_playerController.CurrentSpeedKPH / _playerTopSpeedKPH);
		if (!isGrounded || _playerController.PlayerIkController.PlayerRagdoll.IsRagdollEnabled)
		{
			num2 = 0f;
		}
		if (_playerController.GrabbingStickySurface)
		{
			num2 = 0f;
		}
		if ((double)_playerController.MovementInput.sqrMagnitude > 0.001)
		{
			float f = Vector3.SignedAngle(_playerController.DirectionFlat, _playerController.MovementInput, Vector3.up);
			num2 *= 1f + Mathf.InverseLerp(0f, 45f, Mathf.Abs(f)) * 0.5f;
		}
		float num3 = ((num > _windSpeed) ? _windSpeedSoundCoefficientRising : _windSpeedSoundCoefficientLowering);
		_wheelSpeed = Mathf.MoveTowards(_wheelSpeed, num2, Time.deltaTime * _wheelSpeedSoundCoefficient);
		_windSpeed = Mathf.MoveTowards(_windSpeed, num, Time.deltaTime * num3);
		_motorEvent.setParameterByName(_wheelSpeedParam, _wheelSpeed);
		_motorEvent.setParameterByName(_windSpeedParam, _windSpeed);
		if ((_jumpWoosh && !isGrounded) & hasJustLeftGround)
		{
			RuntimeManager.PlayOneShot(_jumpWooshRef, _playerController.PlayerPosition);
		}
		ScreechCheck();
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

	private static void PlayImpactAudioRef(ImpactAudioRef[] impactAudioRef, float hitImpulse, Vector3 position)
	{
		for (int num = impactAudioRef.Length - 1; num >= 0; num--)
		{
			if (hitImpulse > impactAudioRef[num].impulse)
			{
				RuntimeManager.PlayOneShot(impactAudioRef[num]._sfxRef, position);
				break;
			}
		}
	}

	private void ScreechCheck()
	{
		float num = Mathf.Abs(_playerController.CurrentBallSurfaceSpeed - _playerController.Rigidbody.linearVelocity.magnitude);
		float num2 = Mathf.InverseLerp(0f, 3f, num - 1f);
		if (!_playerController.IsMoveState || !_playerController.PlayerCollisionHandler.IsGrounded || _playerController.GrabbingStickySurface)
		{
			num2 = 0f;
		}
		num2 *= Mathf.Lerp(0.3f, 1f, _playerController.MainBallCollider.material.dynamicFriction);
		if (!_wheelScreech)
		{
			num2 = 0f;
		}
		_screechEvent.setParameterByName(_wheelScreechParam, num2);
	}

	public void Hurt(float hitImpulse)
	{
		if (_lastHurtTime + _hurtCooldown > Time.time)
		{
			return;
		}
		for (int num = _hurtRef.Length - 1; num >= 0; num--)
		{
			if (hitImpulse > _hurtRef[num].impulse)
			{
				RuntimeManager.PlayOneShot(_hurtRef[num]._sfxRef, PlayerPosition);
				_lastHurtTime = Time.time;
				break;
			}
		}
	}

	private void Land(float hitImpulse)
	{
		if (_playerController.PlayerCollisionHandler.PreviousGroundHitData.time > 0.05f)
		{
			PlayImpactAudioRef(_landAudio, hitImpulse, PlayerPosition);
		}
		else
		{
			PlayImpactAudioRef(_ontoRamp, hitImpulse, PlayerPosition);
		}
	}

	private void BodyImpact(float hitImpulse)
	{
		if (hitImpulse > _bodyImpactAudio[1].impulse)
		{
			RuntimeManager.PlayOneShot(_bodyImpactAudio[1]._sfxRef, PlayerPosition);
		}
		else if (hitImpulse > _bodyImpactAudio[0].impulse)
		{
			RuntimeManager.PlayOneShot(_bodyImpactAudio[0]._sfxRef, PlayerPosition);
		}
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
