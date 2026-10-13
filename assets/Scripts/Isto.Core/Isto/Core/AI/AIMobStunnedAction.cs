using Isto.Core.Beings;
using Isto.Core.StateMachine;
using UnityEngine;

namespace Isto.Core.AI;

public class AIMobStunnedAction : AIAction
{
	public float stunTime;

	public bool canBePickedUpWhenStunned;

	private float _stunTimer;

	private Health _health;

	public void Awake()
	{
		_health = GetComponent<Health>();
	}

	public override void StartAction(MobStateMachine controller)
	{
		base.StartAction(controller);
		_controller.agent.speed = 0f;
		_controller.agent.ResetPath();
		_controller.SetSliderValue(0f);
		_controller.SetSliderActive(active: true);
		_stunTimer = 0f;
		_controller.gameObject.tag = Tags.STUNNED_MOB;
	}

	public override void UpdateAction()
	{
		_stunTimer += Time.deltaTime;
		_controller.SetSliderValue(_stunTimer / stunTime);
		if (_stunTimer > stunTime)
		{
			isRunning = false;
		}
	}

	public override void StopAction()
	{
		_controller.gameObject.tag = Tags.MOB;
		_controller.SetSliderActive(active: false);
		_health.Heal(float.PositiveInfinity, Health.DamageTypeEnum.STUN);
	}
}
