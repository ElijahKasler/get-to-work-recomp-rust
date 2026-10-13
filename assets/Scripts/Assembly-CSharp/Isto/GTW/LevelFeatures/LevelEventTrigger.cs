using System;
using UnityEngine;

namespace Isto.GTW.LevelFeatures;

public abstract class LevelEventTrigger : MonoBehaviour
{
	[SerializeField]
	private Color _gizmoColor = new Color(0.7f, 0f, 0f, 0.5f);

	[Tooltip("If \"triggerOnce\" is checked, trigger will not be launched if \"WwsTrigger\" is checked.")]
	[SerializeField]
	protected bool _triggerOnce;

	public bool wasTriggered;

	public Action OnTriggerEvent;

	protected virtual void Reset()
	{
		base.gameObject.layer = LayerMask.NameToLayer("PlayerTrigger");
	}

	protected virtual void OnDrawGizmosSelected()
	{
		DrawGizmosFromTransform(base.transform);
	}

	private Vector3 GetDirectionVector(CapsuleCollider capsuleCollider, Transform colliderTransform)
	{
		return capsuleCollider.direction switch
		{
			0 => colliderTransform.right, 
			1 => colliderTransform.up, 
			2 => colliderTransform.forward, 
			_ => colliderTransform.right, 
		};
	}

	public void CopyFrom(LevelEventTrigger levelEventTrigger)
	{
		_gizmoColor = levelEventTrigger._gizmoColor;
		_triggerOnce = levelEventTrigger._triggerOnce;
	}

	public virtual void TriggerEvent(bool force = false)
	{
		if (force || !_triggerOnce || !wasTriggered)
		{
			wasTriggered = true;
			OnTriggerEvent?.Invoke();
		}
	}

	private void DrawGizmosFromTransform(Transform colliderTransform)
	{
		Gizmos.color = _gizmoColor;
		BoxCollider[] components = colliderTransform.GetComponents<BoxCollider>();
		foreach (BoxCollider boxCollider in components)
		{
			Gizmos.matrix = colliderTransform.localToWorldMatrix;
			Gizmos.DrawCube(boxCollider.center, new Vector3(boxCollider.size.x, boxCollider.size.y, boxCollider.size.z));
		}
		SphereCollider[] components2 = colliderTransform.GetComponents<SphereCollider>();
		foreach (SphereCollider sphereCollider in components2)
		{
			Gizmos.matrix = colliderTransform.localToWorldMatrix;
			Gizmos.DrawSphere(sphereCollider.center, sphereCollider.radius);
		}
		CapsuleCollider[] components3 = colliderTransform.GetComponents<CapsuleCollider>();
		foreach (CapsuleCollider capsuleCollider in components3)
		{
			Gizmos.matrix = Matrix4x4.identity;
			float height = capsuleCollider.height;
			float radius = capsuleCollider.radius;
			Vector3 vector = colliderTransform.position + colliderTransform.TransformDirection(capsuleCollider.center);
			Vector3 directionVector = GetDirectionVector(capsuleCollider, colliderTransform);
			float num = height * 0.5f - radius;
			Vector3 center = vector + directionVector * num;
			Vector3 center2 = vector - directionVector * num;
			Gizmos.DrawSphere(center, radius);
			Gizmos.DrawSphere(center2, radius);
			Gizmos.DrawSphere(vector, radius);
		}
	}
}
