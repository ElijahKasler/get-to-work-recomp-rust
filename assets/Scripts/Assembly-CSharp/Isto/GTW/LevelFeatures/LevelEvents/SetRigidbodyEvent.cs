using System.Collections.Generic;
using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class SetRigidbodyEvent : LevelEvent
{
	[SerializeField]
	private List<Rigidbody> _rigidbody;

	[Space]
	[SerializeField]
	private bool _setUseGravity;

	[SerializeField]
	private bool _useGravityValue = true;

	[SerializeField]
	private bool _setIsKinematic;

	[SerializeField]
	private bool _isKinematicValue;

	[SerializeField]
	private bool _setMass;

	[SerializeField]
	private float _massValue;

	[SerializeField]
	private bool _setLinearDamping;

	[SerializeField]
	private float _linearDamping;

	[SerializeField]
	private bool _setAngularDamping;

	[SerializeField]
	private float _angularDamping;

	public override void TriggerEvent(bool initialization = false)
	{
		foreach (Rigidbody item in _rigidbody)
		{
			if (!(item == null))
			{
				if (_setUseGravity)
				{
					item.useGravity = _useGravityValue;
				}
				if (_setIsKinematic)
				{
					item.isKinematic = _isKinematicValue;
				}
				if (_setMass)
				{
					item.mass = _massValue;
				}
				if (_setLinearDamping)
				{
					item.linearDamping = _linearDamping;
				}
				if (_setAngularDamping)
				{
					item.angularDamping = _angularDamping;
				}
			}
		}
	}
}
