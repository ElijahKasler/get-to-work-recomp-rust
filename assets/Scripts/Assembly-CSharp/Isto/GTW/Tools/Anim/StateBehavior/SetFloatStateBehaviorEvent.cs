using UnityEngine;

namespace Isto.GTW.Tools.Anim.StateBehavior;

public class SetFloatStateBehaviorEvent : StateBehaviorEvent
{
	[SerializeField]
	private string _parameterName = "";

	[SerializeField]
	private float _floatValue;

	protected override void TriggerEvent(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetFloat(_parameterName, _floatValue);
	}
}
