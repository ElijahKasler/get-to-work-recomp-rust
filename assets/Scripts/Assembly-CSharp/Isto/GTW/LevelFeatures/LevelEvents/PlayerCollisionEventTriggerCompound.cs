using System.Collections.Generic;
using Isto.GTW.LevelFeatures.LevelEventTriggers;
using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

[RequireComponent(typeof(PlayerCollisionEventTrigger))]
public class PlayerCollisionEventTriggerCompound : MonoBehaviour
{
	[SerializeField]
	private Color _gizmoColorUnSet = new Color(0.7f, 0.7f, 0f, 0.5f);

	[SerializeField]
	private Color _gizmoColorSetup = new Color(0.7f, 0f, 0f, 0.5f);

	[Space]
	[SerializeField]
	private LevelEvent _levelEvent;

	[SerializeField]
	private List<GameObject> _compoundColliders = new List<GameObject>();

	protected virtual void OnDrawGizmosSelected()
	{
		foreach (GameObject compoundCollider in _compoundColliders)
		{
			if (compoundCollider != null)
			{
				DrawGizmosFromTransform(compoundCollider.transform);
			}
		}
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

	[ContextMenu("Setup Compound Collider events")]
	public void SetupCompoundColliderEvents()
	{
		PlayerCollisionEventTrigger component = GetComponent<PlayerCollisionEventTrigger>();
		foreach (GameObject compoundCollider in _compoundColliders)
		{
			PlayerCollisionEventTrigger playerCollisionEventTrigger = compoundCollider.GetComponent<PlayerCollisionEventTrigger>();
			if (playerCollisionEventTrigger == null)
			{
				playerCollisionEventTrigger = compoundCollider.AddComponent<PlayerCollisionEventTrigger>();
			}
			playerCollisionEventTrigger.CopyFrom(component);
			playerCollisionEventTrigger.ValidateLayer();
			DelayTriggerEvent delayTriggerEvent = compoundCollider.GetComponent<DelayTriggerEvent>();
			if (delayTriggerEvent == null)
			{
				delayTriggerEvent = compoundCollider.AddComponent<DelayTriggerEvent>();
			}
			delayTriggerEvent._levelEvent = _levelEvent;
			delayTriggerEvent._delay = 0f;
		}
	}

	[ContextMenu("Remove Compound Collider events")]
	public void RemoveCompoundColliderEvents()
	{
		foreach (GameObject compoundCollider in _compoundColliders)
		{
			if (!(compoundCollider == null))
			{
				PlayerCollisionEventTrigger component = compoundCollider.GetComponent<PlayerCollisionEventTrigger>();
				if (component != null)
				{
					Object.DestroyImmediate(component);
				}
				DelayTriggerEvent component2 = compoundCollider.GetComponent<DelayTriggerEvent>();
				if (component2 != null)
				{
					Object.DestroyImmediate(component2);
				}
			}
		}
	}

	private void DrawGizmosFromTransform(Transform colliderTransform)
	{
		if (colliderTransform.GetComponent<PlayerCollisionEventTrigger>() != null)
		{
			Gizmos.color = _gizmoColorSetup;
		}
		else
		{
			Gizmos.color = _gizmoColorUnSet;
		}
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
		MeshCollider[] components4 = colliderTransform.GetComponents<MeshCollider>();
		for (int i = 0; i < components4.Length; i++)
		{
			Bounds bounds = components4[i].bounds;
			Gizmos.DrawCube(bounds.center, new Vector3(bounds.size.x, bounds.size.y, bounds.size.z));
		}
	}
}
