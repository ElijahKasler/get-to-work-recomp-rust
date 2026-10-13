using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.GTW.Player.States;

[CreateAssetMenu(fileName = "GTW-PlayerFreezeControls", menuName = "Scriptables/GTW/States/New GTW Player FreezeControls")]
public class GTWPlayerFreezeControls : State
{
	private PlayerController _playerController;

	private bool _forceGrabAbility;

	private bool _forceBrake;

	private PlayerPhysicsOverride.PhysicsOverride _brakePhysicsOverride;

	public bool ForceGrabAbility
	{
		get
		{
			return _forceGrabAbility;
		}
		set
		{
			_forceGrabAbility = value;
		}
	}

	public bool ForceBrake
	{
		get
		{
			return _forceBrake;
		}
		set
		{
			_forceBrake = value;
		}
	}

	public override void Enter(ScriptableStateMachine controller)
	{
		_brakePhysicsOverride = new PlayerPhysicsOverride.PhysicsOverride
		{
			priority = 9000,
			hasDragOverride = true,
			dragOverride = 10f
		};
		_playerController = controller as PlayerController;
		_playerController.Rigidbody.isKinematic = false;
		_playerController.SetPlayerColliderState(state: true);
		if (_forceBrake)
		{
			_playerController.PlayerPhysicsOverride.AddPhysicsOverride(_brakePhysicsOverride);
		}
	}

	public override IState Run(ScriptableStateMachine controller)
	{
		_playerController.UpdateDirectionalVectorsAndSpeed();
		_playerController.UpdateBodyVelocity();
		_playerController.UpdateAngularVelocity();
		bool forceGrabAbility = ForceGrabAbility;
		if (!_playerController.IsGrabLinkActive & forceGrabAbility)
		{
			_playerController.ActivateGrabLink();
		}
		else if (_playerController.IsGrabLinkActive && !forceGrabAbility)
		{
			_playerController.DeactivateGrabLink();
			if (!_playerController.IsGrabLinkActive)
			{
				_playerController.TurnPlayerTowardCamera();
			}
		}
		return this;
	}

	public override void Exit(ScriptableStateMachine controller)
	{
		_playerController.DeactivateGrabLink();
		_playerController.TimeManager.SetSlowMotionActive(isActive: false, instant: true);
		_playerController.PlayerPhysicsOverride.RemovePhysicsOverride(_brakePhysicsOverride);
	}
}
