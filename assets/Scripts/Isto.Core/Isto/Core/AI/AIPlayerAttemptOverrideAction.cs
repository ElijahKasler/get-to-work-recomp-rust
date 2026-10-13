using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.AI;

public class AIPlayerAttemptOverrideAction : AIAction
{
	public float overrideTime;

	private float _overrideTimer;

	public override void StartAction(MobStateMachine controller)
	{
		base.StartAction(controller);
		_controller.SetOverrideSliderActive(active: true);
		_controller.SetOverrideSliderValue(0f);
		isInteruptable = false;
	}

	public override void UpdateAction()
	{
		_overrideTimer += Time.deltaTime;
		if (_overrideTimer > overrideTime)
		{
			isInteruptable = true;
		}
		else
		{
			_controller.SetOverrideSliderValue(_overrideTimer / overrideTime);
		}
	}

	public override void StopAction()
	{
		_controller.SetOverrideSliderActive(active: false);
		base.StopAction();
	}
}
