using UnityEngine;

namespace Isto.GTW.Tools.Anim.StateBehavior;

public class SetBoolStateBehaviorEvent : StateBehaviorEvent
{
	[SerializeField]
	private string _parameterName = "";

	[SerializeField]
	private bool _boolValue = true;

	protected override void TriggerEvent(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool(_parameterName, _boolValue);
	}
}
