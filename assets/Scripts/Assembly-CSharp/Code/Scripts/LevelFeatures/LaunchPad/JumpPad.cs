using Code.Scripts.LevelFeatures.ForceTrigger;
using Isto.GTW.DebugTools;
using UnityEngine;

namespace Code.Scripts.LevelFeatures.LaunchPad;

public class JumpPad : ForceTriggerBase
{
	[Space]
	[SerializeField]
	private Transform _direction;

	private Vector3 LaunchDirection
	{
		get
		{
			if (!(_direction != null))
			{
				return base.transform.forward;
			}
			return _direction.forward;
		}
	}

	protected override void ApplyForce()
	{
		Vector3 force = LaunchDirection * _force;
		if (Vector3.Angle(LaunchDirection, _playerController.Rigidbody.linearVelocity) > 90f)
		{
			Vector3 vector = Vector3.Project(_playerController.Rigidbody.linearVelocity, LaunchDirection);
			force -= vector;
		}
		_playerController.Rigidbody.AddForce(force, ForceMode.VelocityChange);
	}

	protected override void OnDrawGizmosSelected()
	{
		base.OnDrawGizmosSelected();
		DebugExtensions.DrawArrow(base.transform.position, 0.3f, LaunchDirection, Color.red);
	}
}
