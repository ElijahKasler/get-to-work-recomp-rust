using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.AI;

public class AIChangeStateAction : AIAction
{
	[Tooltip("State to change to if this action is selected")]
	public MobState state;

	public override void UpdateAction()
	{
	}
}
