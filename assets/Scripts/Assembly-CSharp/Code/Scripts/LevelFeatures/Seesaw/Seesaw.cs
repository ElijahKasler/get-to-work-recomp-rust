using Isto.GTW.DebugTools;
using Isto.GTW.Tools;
using UnityEngine;

namespace Code.Scripts.LevelFeatures.Seesaw;

public class Seesaw : MonoBehaviour
{
	[SerializeField]
	private Rigidbody _pivot;

	[SerializeField]
	private float _spinForce = 5f;

	[SerializeField]
	private float _lowLimit = -85f;

	[SerializeField]
	private float _highLimit = 85f;

	[Space]
	[SerializeField]
	private float _springStiffness = 50f;

	[SerializeField]
	private float _springDamping = 30f;

	[SerializeField]
	private float _springResetDamping = 10f;

	private Transform _pivotTransform;

	private float _currentRotation;

	private float _targetRotation;

	private float _targetAddForce;

	private float _currentRotationVelocity;

	private float _resetCD;

	private void Awake()
	{
		_pivotTransform = _pivot.transform;
	}

	private void OnDrawGizmosSelected()
	{
		DebugExtensions.DrawArrow(_pivot.transform.position, 0.3f, _pivot.transform.forward * 5f, Color.red);
	}

	private void FixedUpdate()
	{
		if (_resetCD < 0f)
		{
			_targetRotation = 0f;
			_currentRotation = GTWExtensions.Spring(_currentRotation, _targetRotation, ref _currentRotationVelocity, Time.fixedDeltaTime, _springResetDamping, _springStiffness);
		}
		else
		{
			_targetRotation = ((Mathf.Sign(_targetAddForce) > 0f) ? _highLimit : _lowLimit);
			_targetRotation = Mathf.Clamp(_targetRotation, _lowLimit, _highLimit);
			_currentRotation = GTWExtensions.Spring(_currentRotation, _targetRotation, ref _currentRotationVelocity, Time.fixedDeltaTime, _springDamping, _springStiffness);
		}
		_resetCD -= Time.fixedDeltaTime;
		_pivot.MoveRotation(Quaternion.Euler(0f, 0f, _currentRotation) * base.transform.rotation);
	}

	public void PlayerCollision(Vector3 hitPosition)
	{
		float distanceToPoint = new Plane(_pivotTransform.right, _pivotTransform.position).GetDistanceToPoint(hitPosition);
		_targetAddForce = distanceToPoint;
		_resetCD = 0.1f;
	}
}
