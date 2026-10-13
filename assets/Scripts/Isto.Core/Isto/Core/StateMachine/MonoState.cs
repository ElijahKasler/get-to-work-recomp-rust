using UnityEngine;

namespace Isto.Core.StateMachine;

public abstract class MonoState : MonoBehaviour
{
	public abstract void Enter(MonoStateMachine controller);

	public abstract void Exit(MonoStateMachine controller);

	public abstract MonoState Run(MonoStateMachine controller);

	public virtual void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
	}
}
