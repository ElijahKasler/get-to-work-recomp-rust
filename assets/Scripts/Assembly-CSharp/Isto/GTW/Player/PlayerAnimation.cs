using UnityEngine;

namespace Isto.GTW.Player;

public class PlayerAnimation : MonoBehaviour
{
	[SerializeField]
	private Animator _animator;

	[Tooltip("Controls how quickly the VelocityZ parameter moves within the blend tree. \nVelocityZ changes the forward to backward animations (such as the forward brake and neutral position)\n- Value is based on the characters acceleration/decceleration but picked on feel.")]
	[SerializeField]
	private AnimationCurve _accelerationCurve = AnimationCurve.Linear(-5f, -1f, 5f, 1f);

	[Tooltip("Controls how the VelocityX parameter moves within the blend tree. \nVelocityX changes the left to right animations (such as turning left and right)\n- Value is based on how quickly you are turning.")]
	[SerializeField]
	private AnimationCurve _steeringCurve = AnimationCurve.Linear(-90f, -1f, 90f, 1f);

	[Tooltip("How fast the VelocityX will reach the target VelocityX. A higher value will take longer to reach the target velocity")]
	[SerializeField]
	private float _velXResponseTime = 0.1f;

	[Tooltip("How fast the VelocityZ will reach the target VelocityZ. A higher value will take longer to reach the target velocity")]
	[SerializeField]
	private float _velZResponseTime = 0.1f;

	[Space]
	[Tooltip("Controls how much the cloth of the players tailcoat goes up and down.\n- X is the player's speed in km/hr \n- Y is a weight from 0 to 1. 0 is idle, 1 is the full flapping animation.")]
	[SerializeField]
	private AnimationCurve _clothWindWeightCurve = AnimationCurve.Constant(0f, 50f, 0f);

	[Tooltip("Controls the frequency at which the players tailcoat flaps.\n- X is a the player's speed in km/hr \n- Y is a speed multiplier on the aimation. 0 would not play, 5 would play the animation at 5x speed.")]
	[SerializeField]
	private AnimationCurve _clothWindSpeedCurve = AnimationCurve.Constant(0f, 50f, 1f);

	[Space]
	[Tooltip("UNUSED - we originally had the player do a unique animation when going really fast. Deprecated now\n")]
	[SerializeField]
	private float _fastSpeedKm = 30f;

	[Tooltip("UNUSED - we originally had the player do a unique animation when in air. Deprecated now\n")]
	[SerializeField]
	private bool _midairAnim;

	private PlayerModelController _playerModelController;

	private PlayerController _playerController;

	private bool _fastMode;

	private float _goingFastTime = -1f;

	private float _velX;

	private float _velY;

	private float _velZ;

	private float _velXVelocity;

	private float _velYVelocity;

	private float _velZVelocity;

	private float _airForwardInput;

	private float _clothWindLayerWeight;

	private float _clothWindSpeed = 1f;

	private Vector3 _lastPelvisPosition = Vector3.zero;

	private Vector3 _pelvisVelocity = Vector3.zero;

	private float _clothVelocityX;

	private int _fastModeParam = Animator.StringToHash("FastMode");

	private int _velocityXParam = Animator.StringToHash("VelocityX");

	private int _velocityYParam = Animator.StringToHash("VelocityY");

	private int _velocityZParam = Animator.StringToHash("VelocityZ");

	private int _grabParam = Animator.StringToHash("Grab");

	private int _groundedParam = Animator.StringToHash("Grounded");

	private int _clothSpeedParam = Animator.StringToHash("ClothSpeed");

	private int _clothVelocityXParam = Animator.StringToHash("ClothVelocityX");

	public float AirForwardInput => _airForwardInput;

	private void Awake()
	{
		_playerModelController = GetComponent<PlayerModelController>();
		_playerController = GetComponentInParent<PlayerController>();
	}

	private void Update()
	{
		_airForwardInput = GetAirForwardInput();
		UpdateFastMode();
		UpdateVelocityX();
		UpdateVelocityZ();
		UpdateClothFlapAnimation();
		_animator.SetBool(_fastModeParam, _fastMode);
		_animator.SetFloat(_velocityXParam, _velX);
		_animator.SetFloat(_velocityZParam, _velZ);
		_animator.SetBool(_grabParam, _playerController.IsGrabLinkActive);
		_animator.SetLayerWeight(1, _clothWindLayerWeight);
		_animator.SetFloat(_clothSpeedParam, _clothWindSpeed);
		_animator.SetFloat(_clothVelocityXParam, _clothVelocityX);
		if (_midairAnim)
		{
			_animator.SetBool(_groundedParam, _playerController.PlayerCollisionHandler.IsGrounded);
		}
		else
		{
			_animator.SetBool(_groundedParam, value: true);
		}
	}

	private void LateUpdate()
	{
		CalculatePelvisVelocity();
	}

	private void UpdateFastMode()
	{
		if (_playerController.PlayerCollisionHandler.GroundedTime > 0.5f && _playerController.CurrentSpeedKPH > _fastSpeedKm)
		{
			_goingFastTime += Time.deltaTime;
		}
		else
		{
			_goingFastTime = 0f;
		}
		_fastMode = _goingFastTime > 0.5f;
	}

	private void UpdateVelocityX()
	{
		float num = 0f;
		float target = 0f;
		if ((double)_playerController.MovementInput.sqrMagnitude > 0.001)
		{
			num = Vector3.SignedAngle(_playerController.DirectionFlat, _playerController.MovementInput, Vector3.up);
			target = _steeringCurve.Evaluate(num);
		}
		_velX = Mathf.SmoothDamp(_velX, target, ref _velXVelocity, _velXResponseTime);
	}

	private void UpdateVelocityZ()
	{
		float num = 0f;
		if ((double)_playerController.MovementInput.sqrMagnitude > 0.001)
		{
			num = Vector3.Angle(_playerController.DirectionFlat, _playerController.MovementInput);
			num = ((!(num < 90f)) ? Mathf.InverseLerp(90f, 180f, num) : Mathf.InverseLerp(90f, 0f, num));
		}
		float target = (_playerController.PlayerCollisionHandler.IsGrounded ? _accelerationCurve.Evaluate(_playerController.VelocityAccelerationSpeed * num) : (_midairAnim ? _airForwardInput : 0f));
		_velZ = Mathf.SmoothDamp(_velZ, target, ref _velZVelocity, _velZResponseTime);
	}

	private void CalculatePelvisVelocity()
	{
		if (!(Time.timeScale <= 0f))
		{
			Transform pelvisBone = _playerController.PlayerIkController.PelvisBone;
			Vector3 position = pelvisBone.position;
			_pelvisVelocity = position - _lastPelvisPosition;
			_pelvisVelocity /= Time.deltaTime;
			_lastPelvisPosition = position;
			Vector3 vector = Vector3.Project(_pelvisVelocity, pelvisBone.right);
			_clothVelocityX = 0f - (Quaternion.Inverse(pelvisBone.rotation) * vector).x;
			if (!_playerController.IsMoveState)
			{
				_clothVelocityX = 0f;
			}
		}
	}

	private void UpdateClothFlapAnimation()
	{
		float clothWindLayerWeight = _clothWindWeightCurve.Evaluate(_playerController.CurrentSpeedKPH);
		if (!_playerController.IsMoveState)
		{
			clothWindLayerWeight = 0f;
		}
		_clothWindLayerWeight = clothWindLayerWeight;
		_clothWindSpeed = _clothWindSpeedCurve.Evaluate(_playerController.CurrentSpeedKPH);
	}

	private float GetAirForwardInput()
	{
		float result = 0f;
		if ((double)_playerController.MovementInput.sqrMagnitude > 0.001)
		{
			float num = Vector3.Angle(_playerController.DirectionFlat, _playerController.MovementInput);
			result = ((!(num < 90f)) ? (0f - Mathf.InverseLerp(90f, 180f, num)) : Mathf.InverseLerp(90f, 0f, num));
		}
		return result;
	}
}
