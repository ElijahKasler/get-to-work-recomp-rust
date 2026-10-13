using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using UnityEngine;
using Zenject;

namespace Isto.Core.Beings;

[CreateAssetMenu(fileName = "New Player AutomationMoveState", menuName = "Scriptables/State/Automation Player Move State")]
public class AutomationPlayerMoveState : State
{
	public float speed;

	private AutomationPlayerController _controller;

	private IControls _controls;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	public override void Enter(ScriptableStateMachine controller)
	{
		_controller = controller as AutomationPlayerController;
		if (_controller.IsSpeedOverrideEnabled())
		{
			_controller.SetMoveSpeed(_controller.GetMoveSpeedOverride());
		}
		else
		{
			_controller.SetMoveSpeed(speed);
		}
		if (_controls.GetButton(UserActions.INTERACT))
		{
			_controller.SetCurrentInteractionConsumed();
		}
	}

	public override void Exit(ScriptableStateMachine controller)
	{
	}

	public override IState Run(ScriptableStateMachine controller)
	{
		object obj = _controller.ProcessMovementAndInteractions(movement: true, ability: true, itemInteraction: true);
		if ((Object)obj == null && !_controller.IsMoving)
		{
			_controller.SetCharacterIdle();
		}
		if (obj == null)
		{
			obj = this;
		}
		return (IState)obj;
	}
}
