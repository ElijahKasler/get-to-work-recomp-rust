using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEventTriggers;

public class PlayerCollisionEventTrigger : LevelEventTrigger
{
	[Space]
	[SerializeField]
	private bool _triggerOnEnter = true;

	[SerializeField]
	private bool _triggerOnStay;

	[SerializeField]
	private bool _triggerOnExit;

	[Space]
	[SerializeField]
	private bool _collisionEnter;

	[SerializeField]
	private bool _collisionStay;

	[SerializeField]
	private bool _collisionExit;

	public bool IsSolidTrigger
	{
		get
		{
			if (!_collisionEnter && !_collisionStay)
			{
				return _collisionExit;
			}
			return true;
		}
	}

	protected virtual void Awake()
	{
		Collider[] components = GetComponents<Collider>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].isTrigger = !IsSolidTrigger;
		}
	}

	protected void OnValidate()
	{
		ValidateLayer();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (_triggerOnEnter)
		{
			OnTrigger(other);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (_triggerOnStay)
		{
			OnTrigger(other);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (_triggerOnExit)
		{
			OnTrigger(other);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (_collisionEnter)
		{
			OnTrigger(other.collider);
		}
	}

	private void OnCollisionStay(Collision other)
	{
		if (_collisionStay)
		{
			OnTrigger(other.collider);
		}
	}

	private void OnCollisionExit(Collision other)
	{
		if (_collisionExit)
		{
			OnTrigger(other.collider);
		}
	}

	private void OnTrigger(Collider other)
	{
		PlayerEventTrigger playerEventTrigger = other.gameObject.GetComponentInParent<PlayerEventTrigger>();
		if (playerEventTrigger == null)
		{
			playerEventTrigger = other.gameObject.GetComponentInChildren<PlayerEventTrigger>();
		}
		if (playerEventTrigger != null)
		{
			TriggerEvent();
		}
	}

	public void ValidateLayer()
	{
		if (IsSolidTrigger && base.gameObject.layer == LayerMask.NameToLayer("PlayerTrigger"))
		{
			base.gameObject.layer = LayerMask.NameToLayer("Default");
		}
	}

	public void CopyFrom(PlayerCollisionEventTrigger playerCollisionEventTrigger)
	{
		CopyFrom((LevelEventTrigger)playerCollisionEventTrigger);
		_triggerOnEnter = playerCollisionEventTrigger._triggerOnEnter;
		_triggerOnStay = playerCollisionEventTrigger._triggerOnStay;
		_triggerOnExit = playerCollisionEventTrigger._triggerOnExit;
		_collisionEnter = playerCollisionEventTrigger._collisionEnter;
		_collisionStay = playerCollisionEventTrigger._collisionStay;
		_collisionExit = playerCollisionEventTrigger._collisionExit;
	}
}
