using System;
using Isto.Core.Inputs;
using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.Beings;

public class SimplePlayerController : CorePlayerController
{
	protected override Collider MainHitBox => null;

	public override State MovementState => startState;

	public override bool IsMoving
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public Vector2 GetInputs()
	{
		Vector2 result = Vector3.zero;
		result.x = _controls.GetAxis(Controls.MovementAxis.MoveHorizontal);
		result.y = _controls.GetAxis(Controls.MovementAxis.MoveVertical);
		return result;
	}

	protected override void OnPlayerTakeDamage(object sender, HealthEventArgs e)
	{
		throw new NotImplementedException();
	}

	protected override void OnPlayerKilled(object sender, HealthEventArgs e)
	{
		throw new NotImplementedException();
	}

	public override void SetMovementEnabled(bool active)
	{
		throw new NotImplementedException();
	}

	public override void ChangeToMoveState()
	{
		throw new NotImplementedException();
	}

	public override void ChangeToCustomState(State state)
	{
		throw new NotImplementedException();
	}
}
