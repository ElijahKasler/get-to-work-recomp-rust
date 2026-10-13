using UnityEngine;

namespace Isto.Core.StateMachine;

public class ScriptableStateMachine : MonoBehaviour
{
	public State startState;

	protected State _currentState;

	protected virtual void Start()
	{
		ChangeState(startState);
	}

	private void Update()
	{
		State state = _currentState.Run(this) as State;
		if (state != _currentState)
		{
			ChangeState(state);
		}
	}

	public void ChangeState(State nextState)
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
}
