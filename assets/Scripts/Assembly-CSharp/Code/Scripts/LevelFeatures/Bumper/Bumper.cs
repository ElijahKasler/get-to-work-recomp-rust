using Code.Scripts.LevelFeatures.ForceTrigger;
using UnityEngine;

namespace Code.Scripts.LevelFeatures.Bumper;

public class Bumper : ForceTriggerBase
{
	protected override void ApplyForce()
	{
		Vector3 position = base.transform.position;
		Vector3 vector = new Plane(base.transform.up, position).ClosestPointOnPlane(_playerController.PlayerPosition) - position;
		vector.Normalize();
		Vector3 force = vector * _force;
		if (Vector3.Angle(vector, _playerController.Rigidbody.linearVelocity) > 90f)
		{
			Vector3 vector2 = Vector3.Project(_playerController.Rigidbody.linearVelocity, vector);
			force -= vector2;
		}
		_playerController.Rigidbody.AddForce(force, ForceMode.VelocityChange);
	}
}
