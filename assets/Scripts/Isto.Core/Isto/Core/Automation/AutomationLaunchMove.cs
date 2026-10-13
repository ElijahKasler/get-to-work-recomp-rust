using UnityEngine;

namespace Isto.Core.Automation;

public class AutomationLaunchMove : IItemMoveType
{
	private AutomationCoreItem _item;

	private Vector3 _targetPosition;

	private Vector3 _startPosition;

	private float _moveTotalTime;

	private float _moveTimer;

	private float _pauseAmount = 0.2f;

	private bool _launchStarted;

	private float _gravity;

	private Vector3 _positionDelta;

	public bool Complete { get; private set; }

	public Vector3 FinalPosition => _targetPosition;

	public AutomationLaunchMove(AutomationCoreItem item, Vector3 targetPosition, float moveTime)
	{
		_item = item;
		_targetPosition = targetPosition;
		int moveTimeMultiplier = GetMoveTimeMultiplier(Vector3.Distance(item.position, targetPosition));
		_moveTotalTime = (float)moveTimeMultiplier * moveTime - _pauseAmount;
		_moveTimer = 0f;
		_startPosition = item.position;
		_item.StartItemMove(_targetPosition, _moveTotalTime, this);
		_gravity = GetGravity();
	}

	public void Tick(float deltaTime)
	{
		if (Complete)
		{
			return;
		}
		_moveTimer += deltaTime;
		if (!(_moveTimer < _pauseAmount))
		{
			if (!_launchStarted)
			{
				_launchStarted = true;
				_item.LaunchItem();
			}
			float newX = CalculatePosition(0f, _moveTotalTime, _targetPosition.x, _startPosition.x, _moveTimer - _pauseAmount);
			float newY = CalculatePosition(_gravity, _moveTotalTime, _targetPosition.y, _startPosition.y, _moveTimer - _pauseAmount);
			float newZ = CalculatePosition(0f, _moveTotalTime, _targetPosition.z, _startPosition.z, _moveTimer - _pauseAmount);
			if (_moveTimer > _moveTotalTime + _pauseAmount)
			{
				EndMovement();
				return;
			}
			_positionDelta.Set(newX, newY, newZ);
			_item.position = _startPosition + _positionDelta;
		}
	}

	private void EndMovement()
	{
		_launchStarted = false;
		_item.position = _targetPosition;
		Complete = true;
		_item.EndItemMove();
	}

	private float GetGravity()
	{
		float num = Vector3.Distance(_startPosition, _targetPosition);
		if (num < 8f)
		{
			return (0f - Physics.gravity.magnitude) * 5f;
		}
		if (num < 10f)
		{
			return (0f - Physics.gravity.magnitude) * 4f;
		}
		return (0f - Physics.gravity.magnitude) * 3f;
	}

	private float CalculatePosition(float a, float T, float yf, float yi, float t)
	{
		float num = Mathf.Pow(T, 2f);
		float num2 = Mathf.Pow(t, 2f);
		return (yf - yi - 0.5f * a * num) / T * t + 0.5f * a * num2;
	}

	public static int GetMoveTimeMultiplier(float distance)
	{
		if (distance <= 3f)
		{
			return 1;
		}
		if (distance <= 8f)
		{
			return 2;
		}
		return 3;
	}

	public void Cancel()
	{
		EndMovement();
	}
}
