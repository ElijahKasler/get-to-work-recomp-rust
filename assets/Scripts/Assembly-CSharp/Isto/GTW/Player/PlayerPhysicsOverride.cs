using System;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.GTW.Player;

public class PlayerPhysicsOverride : MonoBehaviour
{
	[Serializable]
	public class PhysicsOverride
	{
		[HideInInspector]
		public UnityEngine.Object source;

		public int priority;

		[Space]
		public bool hasGravityOverride;

		public float gravityOverride = 9.8f;

		[Space]
		public bool hasBouninesseOverride;

		[Range(0f, 1f)]
		public float bouncinessOverride;

		[Space]
		public bool hasDragOverride;

		public float dragOverride;

		[Space]
		public bool hasAngularDragOverride;

		public float angularDragOverride;

		[Space]
		public bool hasAdditiveVelocity;

		public Vector3 additiveVelocity = Vector3.zero;
	}

	private List<PhysicsOverride> _physicOverrides = new List<PhysicsOverride>();

	public PhysicsOverride GetOverride()
	{
		if (_physicOverrides.Count == 0)
		{
			return null;
		}
		return _physicOverrides[_physicOverrides.Count - 1];
	}

	public void AddPhysicsOverride(PhysicsOverride physicsOverride)
	{
		_physicOverrides.Add(physicsOverride);
		_physicOverrides.Sort((PhysicsOverride x, PhysicsOverride y) => x.priority.CompareTo(y.priority));
	}

	public void RemovePhysicsOverride(UnityEngine.Object source)
	{
		_physicOverrides.RemoveAll((PhysicsOverride x) => x.source == source);
	}

	public void RemovePhysicsOverride(PhysicsOverride physicsOverride)
	{
		_physicOverrides.Remove(physicsOverride);
	}
}
