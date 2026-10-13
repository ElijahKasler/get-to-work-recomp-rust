using System.Collections;
using UnityEngine;

public class AnimationTimeDelay : MonoBehaviour
{
	[SerializeField]
	private float _waitBeforeStartingAnimation;

	[SerializeField]
	private float _playSpeed = 1f;

	private Animator _animator;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_animator.speed = 0f;
	}

	private void Start()
	{
		StartCoroutine(WaitToStartAnimation());
	}

	private IEnumerator WaitToStartAnimation()
	{
		yield return new WaitForSeconds(_waitBeforeStartingAnimation);
		_animator.speed = _playSpeed;
	}
}
