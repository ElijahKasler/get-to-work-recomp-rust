using UnityEngine;

namespace Isto.GTW.Tools.Anim.SetAnimParam;

public class SetAnimatorFloat : MonoBehaviour
{
	[SerializeField]
	private Animator _animator;

	[SerializeField]
	private string _parameterName = "";

	[SerializeField]
	private float _floatValue;

	private void OnEnable()
	{
		if (_animator != null)
		{
			_animator.SetFloat(_parameterName, _floatValue);
		}
	}

	private void Reset()
	{
		_animator = GetComponent<Animator>();
	}

	private void OnValidate()
	{
		if (Application.isPlaying && _animator != null)
		{
			_animator.SetFloat(_parameterName, _floatValue);
		}
	}
}
