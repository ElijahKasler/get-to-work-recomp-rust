using UnityEngine;

namespace Isto.Core.StateMachine;

public class MonoStateMachine : MonoBehaviour
{
	public MonoState startState;

	protected MonoState _currentState;

	protected virtual void Start()
	{
		ChangeState(startState);
	}

	protected virtual void Update()
	{
		MonoState monoState = _currentState.Run(this);
		if (monoState != _currentState)
		{
			ChangeState(monoState);
		}
	}

	public virtual void ChangeState(MonoState nextState)
	{
		if (_currentState != null)
		{
			_currentState.Exit(this);
		}
		_currentState = nextState;
		if (_currentState != null)
		{
			_currentState.Enter(this);
		}
	}

	public virtual MonoState GetCurrentState()
	{
		return _currentState;
	}
}
