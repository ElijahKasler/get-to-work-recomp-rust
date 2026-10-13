using UnityEngine;

namespace Code.Scripts.LevelFeatures.AnimatedPhysicsObject;

public class FollowObject : MonoBehaviour
{
	[SerializeField]
	private Rigidbody _rigidbody;

	[SerializeField]
	private Rigidbody _target;

	[SerializeField]
	private bool _fixedUpdate = true;

	private void FixedUpdate()
	{
		if (_fixedUpdate && _rigidbody != null)
		{
			_rigidbody.MovePosition(_target.position);
		}
	}

	private void Update()
	{
		if (!_fixedUpdate)
		{
			base.transform.position = _target.position;
		}
	}
}
