using UnityEngine;

namespace Isto.GTW.Tools.Anim.SetAnimParam;

public class SetAnimatorBool : MonoBehaviour
{
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private string _parameterName = "";

	[SerializeField]
	private bool _boolValue = true;

	private void Awake()
	{
		if (_animator != null)
		{
			_animator.SetBool(_parameterName, _boolValue);
		}
	}

	private void Reset()
	{
		_animator = GetComponent<Animator>();
	}
}
