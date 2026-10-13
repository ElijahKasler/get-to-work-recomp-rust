using UnityEngine;

namespace Isto.GTW.Tools.Anim.StateBehavior;

public class DisableAnimatorStateBehaviorEvent : StateBehaviorEvent
{
	protected override void TriggerEvent(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.enabled = false;
	}
}
