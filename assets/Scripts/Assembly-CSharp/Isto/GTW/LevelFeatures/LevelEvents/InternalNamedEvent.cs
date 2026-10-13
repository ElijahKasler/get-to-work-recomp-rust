using Isto.Core;
using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class InternalNamedEvent : LevelEvent
{
	[SerializeField]
	private string _name;

	private BoxCollider _collider;

	private BoxCollider Collider
	{
		get
		{
			if (_collider == null)
			{
				_collider = GetComponent<BoxCollider>();
			}
			return _collider;
		}
	}

	public override void TriggerEvent(bool initialization = false)
	{
		Events.RaiseEvent(_name);
	}
}
