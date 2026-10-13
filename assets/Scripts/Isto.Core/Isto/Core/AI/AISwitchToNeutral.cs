using Isto.Core.StateMachine;

namespace Isto.Core.AI;

public class AISwitchToNeutral : AIAction
{
	public override void StartAction(MobStateMachine controller)
	{
		base.StartAction(controller);
		_controller.agent.ResetPath();
	}

	public override void UpdateAction()
	{
	}
}
