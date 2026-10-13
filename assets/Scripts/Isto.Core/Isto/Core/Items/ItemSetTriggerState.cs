using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.Items;

public class ItemSetTriggerState : MonoState
{
	public string trigger;

	public MonoState nextState;

	protected ItemPlacementController _controller;

	public override void Enter(MonoStateMachine controller)
	{
		_controller = controller as ItemPlacementController;
		Animator animator = GetComponent<Animator>();
		if (animator == null)
		{
			animator = GetComponentInChildren<Animator>();
		}
		if (animator != null)
		{
			animator.SetTrigger(trigger);
		}
		else
		{
			Debug.LogError("No animator found on object with ItemSetTriggerState attached.");
		}
	}

	public override void Exit(MonoStateMachine controller)
	{
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		_controller.ChangeState(nextState);
		return this;
	}
}
