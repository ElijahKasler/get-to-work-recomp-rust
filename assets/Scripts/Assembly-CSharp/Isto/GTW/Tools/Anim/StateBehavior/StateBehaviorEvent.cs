using UnityEngine;

namespace Isto.GTW.Tools.Anim.StateBehavior;

public abstract class StateBehaviorEvent : StateMachineBehaviour
{
	public enum EventTrigger
	{
		OnStateEnter = 0,
		OnStateExit = 1,
		Percent = 2,
		OnStateMachineEnter = 3,
		OnStateMachineExit = 4
	}

	[SerializeField]
	private EventTrigger _eventTrigger;

	[SerializeField]
	[Range(0f, 1f)]
	private float _percent;

	private float _lastNormalizedTime;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		_lastNormalizedTime = stateInfo.normalizedTime;
		if (_eventTrigger == EventTrigger.OnStateEnter)
		{
			TriggerEvent(animator, stateInfo, layerIndex);
		}
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (_eventTrigger == EventTrigger.OnStateExit)
		{
			TriggerEvent(animator, stateInfo, layerIndex);
		}
	}

	public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
	{
		if (_eventTrigger == EventTrigger.OnStateMachineEnter)
		{
			TriggerEvent(animator, default, -1);
		}
	}

	public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
	{
		if (_eventTrigger == EventTrigger.OnStateMachineExit)
		{
			TriggerEvent(animator, default, -1);
		}
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		float num = stateInfo.normalizedTime;
		if (stateInfo.loop)
		{
			num %= 1f;
		}
		if (_eventTrigger == EventTrigger.Percent)
		{
			float num2 = ((_lastNormalizedTime <= _percent || !stateInfo.loop) ? _percent : (_percent + 1f));
			float num3 = ((_lastNormalizedTime <= num) ? num : (num + 1f));
			if (_lastNormalizedTime <= num2 && num2 < num3)
			{
				TriggerEvent(animator, stateInfo, layerIndex);
			}
		}
		_lastNormalizedTime = num;
	}

	protected abstract void TriggerEvent(Animator animator, AnimatorStateInfo stateInfo, int layerIndex);
}
