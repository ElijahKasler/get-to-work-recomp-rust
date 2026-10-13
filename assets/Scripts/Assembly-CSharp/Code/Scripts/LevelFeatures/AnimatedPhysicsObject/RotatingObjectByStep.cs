using System;
using Isto.GTW.Player;
using UnityEngine;
using Zenject;

namespace Code.Scripts.LevelFeatures.AnimatedPhysicsObject;

public class RotatingObjectByStep : MonoBehaviour
{
	[SerializeField]
	private Rigidbody _rigidbody;

	[SerializeField]
	private Vector3 _stepDegree = Vector3.zero;

	[SerializeField]
	private float _stepSmoothTime = 0.2f;

	[SerializeField]
	private float _inBetweenStepDelay = 1f;

	[SerializeField]
	private bool _fixedUpdate = true;

	private Vector3 _defaultRotation = Vector3.zero;

	private Vector3 _currentRotation = Vector3.zero;

	private Vector3 _nextRotation = Vector3.zero;

	private Vector3 _velocity = Vector3.zero;

	private float _time;

	private bool _moving;

	private PlayerController _playerController;

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	private void Awake()
	{
		_defaultRotation = _rigidbody.rotation.eulerAngles;
		_currentRotation = _defaultRotation;
		_nextRotation = _defaultRotation;
		_time = _inBetweenStepDelay;
	}

	private void Start()
	{
		PlayerController playerController = _playerController;
		playerController.OnPlayerRespawn = (Action)Delegate.Combine(playerController.OnPlayerRespawn, new Action(PlayerRespawn));
	}

	private void OnDestroy()
	{
		PlayerController playerController = _playerController;
		playerController.OnPlayerRespawn = (Action)Delegate.Remove(playerController.OnPlayerRespawn, new Action(PlayerRespawn));
	}

	private void FixedUpdate()
	{
		if (_fixedUpdate && _rigidbody != null)
		{
			_rigidbody.MoveRotation(Quaternion.Euler(GetNextPosition(Time.fixedDeltaTime)));
		}
	}

	private void Update()
	{
		if (!_fixedUpdate)
		{
			base.transform.Rotate(GetNextPosition(Time.deltaTime));
		}
	}

	private Vector3 GetNextPosition(float deltaTime)
	{
		_time -= Time.deltaTime;
		_currentRotation = Vector3.SmoothDamp(_currentRotation, _nextRotation, ref _velocity, _stepSmoothTime, float.MaxValue, deltaTime);
		if (_time <= 0f)
		{
			_moving = !_moving;
			if (_moving)
			{
				_time = _stepSmoothTime;
				_nextRotation += _stepDegree;
			}
			else
			{
				_time = _inBetweenStepDelay;
			}
		}
		return _currentRotation;
	}

	private void PlayerRespawn()
	{
		_currentRotation = _defaultRotation;
		_nextRotation = _defaultRotation;
		_velocity = Vector3.zero;
		_time = _inBetweenStepDelay;
		_moving = false;
		if (_fixedUpdate)
		{
			if (_rigidbody != null)
			{
				_rigidbody.rotation = Quaternion.Euler(_currentRotation);
			}
		}
		else
		{
			base.transform.Rotate(_currentRotation);
		}
	}
}
