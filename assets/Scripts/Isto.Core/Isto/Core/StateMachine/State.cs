using UnityEngine;

namespace Isto.Core.StateMachine;

public abstract class State : ScriptableObject, IState
{
	public bool isInterruptable;

	public abstract void Enter(ScriptableStateMachine controller);

	public abstract IState Run(ScriptableStateMachine controller);

	public abstract void Exit(ScriptableStateMachine controller);
}
