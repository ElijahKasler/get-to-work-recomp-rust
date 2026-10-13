using System;
using Isto.Core.StateMachine;

namespace Isto.Core.Cameras;

public class CameraDoNothingState : MonoState
{
	private void Awake()
	{
	}

	public override void Enter(MonoStateMachine controller)
	{
	}

	public override void Exit(MonoStateMachine controller)
	{
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		throw new NotImplementedException("Sub states not supported on main camera rig.");
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		return this;
	}
}
