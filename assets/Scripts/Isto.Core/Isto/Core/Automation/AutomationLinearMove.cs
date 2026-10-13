using UnityEngine;

namespace Isto.Core.Automation;

public class AutomationLinearMove : IItemMoveType
{
	private AutomationCoreItem _item;

	private Vector3 _targetPosition;

	private Vector3 _startPosition;

	private float _moveTotalTime;

	private float _moveTimer;

	public bool Complete { get; private set; }

	public AutomationLinearMove(AutomationCoreItem item, Vector3 targetPosition, float moveTime)
	{
		_item = item;
		_targetPosition = targetPosition;
		_moveTotalTime = moveTime;
		_moveTimer = 0f;
		_startPosition = item.position;
		_item.StartItemMove(_targetPosition, moveTime, this);
	}

	public void Tick(float deltaTime)
	{
		if (!Complete)
		{
			_moveTimer += deltaTime;
			float num = _moveTimer / _moveTotalTime;
			_item.position = Vector3.Lerp(_startPosition, _targetPosition, num);
			if (num >= 1f)
			{
				Complete = true;
				_item.EndItemMove();
			}
		}
	}

	public void Cancel()
	{
		_item.EndItemMove();
	}
}
