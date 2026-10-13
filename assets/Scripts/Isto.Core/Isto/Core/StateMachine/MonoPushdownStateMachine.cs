using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.StateMachine;

public class MonoPushdownStateMachine : MonoStateMachine
{
	protected Stack<MonoState> _stateStack;

	protected virtual void Awake()
	{
		_stateStack = new Stack<MonoState>();
	}

	protected override void Start()
	{
		if (startState != null)
		{
			PushState(startState);
		}
	}

	protected override void Update()
	{
		if (_currentState == null)
		{
			Debug.LogWarning("Null state set in state machine: " + base.gameObject.name);
			PushState(startState);
		}
		_currentState?.Run(this);
	}

	public virtual void EnterSubState(MonoState subState)
	{
		if (subState == null)
		{
			Debug.LogError("Trying to push null substate onto stack.  Current state: " + _currentState);
		}
		else
		{
			PushState(subState);
		}
	}

	public virtual void ExitSubState()
	{
		MonoState previousState = PopState();
		_currentState.ReturnFromSubState(this, previousState);
	}

	protected void PushState(MonoState state)
	{
		_currentState = state;
		_stateStack.Push(state);
		state.Enter(this);
	}

	protected MonoState PopState()
	{
		_currentState.Exit(this);
		MonoState result = _stateStack.Pop();
		if (_stateStack.Count == 0)
		{
			_currentState = null;
			return result;
		}
		_currentState = _stateStack.Peek();
		return result;
	}

	public override void ChangeState(MonoState nextState)
	{
		if (_currentState != null)
		{
			PopState();
		}
		PushState(nextState);
	}
}
