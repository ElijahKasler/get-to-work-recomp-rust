using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class AnimatorSetBoolEvent : LevelEvent
{
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private string _parameterName = "";

	[SerializeField]
	private bool _boolValue = true;

	public override void TriggerEvent(bool initialization = false)
	{
		_animator.SetBool(_parameterName, _boolValue);
	}
}
