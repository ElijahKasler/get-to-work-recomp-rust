using UnityEngine;

namespace Isto.GTW.Tools.Anim.StateBehavior;

public class SetIntStateBehaviorEvent : StateBehaviorEvent
{
	[SerializeField]
	private string _parameterName = "";

	[SerializeField]
	private float _intValue;

	protected override void TriggerEvent(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetFloat(_parameterName, _intValue);
	}
}
