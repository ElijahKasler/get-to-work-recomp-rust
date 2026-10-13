using System;
using Isto.Core.StateMachine;

namespace Isto.Core.Cameras;

public class CameraFixedState : MonoState
{
	public override void Enter(MonoStateMachine controller)
	{
	}

	public override void Exit(MonoStateMachine controller)
	{
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		throw new NotImplementedException();
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		return this;
	}
}
