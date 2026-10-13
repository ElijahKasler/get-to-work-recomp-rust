using System.Collections.Generic;
using Isto.Core.AI;
using UnityEngine;
using Zenject;

namespace Isto.Core.StateMachine;

public class MobState : MonoBehaviour
{
	public string description;

	public float actionUpdateRate = 0.1f;

	public List<AIAction> actions;

	private AIActionSelector _selector;

	protected AIAction _currentAction;

	private AIAction _previousAction;

	private float _actionUpdateTimer;

	private MobStateMachine _controller;

	public AIAction CurrentAction => _currentAction;

	[Inject]
	public void Inject(AIActionSelector selector)
	{
		_selector = selector;
	}

	public virtual void Enter(MobStateMachine controller)
	{
		_controller = controller;
	}

	public void Exit(MobStateMachine controller)
	{
		if (_currentAction != null)
		{
			_currentAction.StopAction();
		}
		_currentAction = null;
	}

	public MobState Run(MobStateMachine controller)
	{
		_actionUpdateTimer += Time.deltaTime;
		if (_actionUpdateTimer > actionUpdateRate && (_currentAction == null || _currentAction.isInteruptable || (!_currentAction.isInteruptable && !_currentAction.isRunning)))
		{
			AIAction aIAction = _selector.SelectNextAction(actions, _currentAction, _previousAction, controller.gameObject);
			if (aIAction != _currentAction || !_currentAction.isRunning)
			{
				if (_currentAction != null)
				{
					_currentAction.StopAction();
				}
				_previousAction = _currentAction;
				_currentAction = aIAction;
				if (_controller.actionIcon != null)
				{
					_controller.actionIcon.sprite = _currentAction.activeIcon;
				}
				_currentAction.StartAction(_controller);
				_actionUpdateTimer = 0f;
			}
		}
		if (_currentAction != null)
		{
			_currentAction.UpdateAction();
		}
		if (_currentAction is AIChangeStateAction)
		{
			return ((AIChangeStateAction)_currentAction).state;
		}
		if (_currentAction is AISwitchToAgro)
		{
			return _controller.agroState;
		}
		if (_currentAction is AISwitchToNeutral)
		{
			return _controller.neutralState;
		}
		return this;
	}
}
