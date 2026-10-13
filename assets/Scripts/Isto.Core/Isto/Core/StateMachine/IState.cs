namespace Isto.Core.StateMachine;

public interface IState
{
	void Enter(ScriptableStateMachine controller);

	IState Run(ScriptableStateMachine controller);

	void Exit(ScriptableStateMachine controller);
}
