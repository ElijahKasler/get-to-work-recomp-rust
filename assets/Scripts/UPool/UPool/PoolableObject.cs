using System;
using UnityEngine;

namespace UPool;

public sealed class PoolableObject : MonoBehaviour, IPoolable
{
	[SerializeField]
	private bool _disableOnDeallocation;

	[SerializeField]
	private bool _disableCollidersOnDeallocation = true;

	[SerializeField]
	private bool _disableRenderersOnDeallocation;

	public Action ObjectAllocated;

	public Action ObjectDeallocated;

	private AbstractPool _owner;

	private Collider[] _colliders;

	private Collider2D[] _2dColliders;

	private Renderer[] _renderers;

	private bool EnableOnAllocation => !_disableOnDeallocation;

	private bool EnableCollidersOnAllocation => !_disableCollidersOnDeallocation;

	private bool EnableRenderersOnAllocation => !_disableRenderersOnDeallocation;

	void IPoolable.Init(AbstractPool owner)
	{
		_owner = owner;
		_colliders = GetComponentsInChildren<Collider>();
		_2dColliders = GetComponentsInChildren<Collider2D>();
		_renderers = GetComponentsInChildren<Renderer>();
	}

	void IPoolable.OnAllocate()
	{
		if (EnableOnAllocation)
		{
			base.gameObject.SetActive(value: true);
		}
		else
		{
			if (EnableCollidersOnAllocation)
			{
				EnableColliders();
			}
			if (EnableRenderersOnAllocation)
			{
				EnableRenderers();
			}
		}
		if (ObjectAllocated != null)
		{
			ObjectAllocated();
		}
	}

	void IPoolable.OnDeallocate()
	{
		if (_disableOnDeallocation)
		{
			base.gameObject.SetActive(value: false);
		}
		else
		{
			if (_disableCollidersOnDeallocation)
			{
				DisableColliders();
			}
			if (_disableRenderersOnDeallocation)
			{
				DisableRenderers();
			}
		}
		if (ObjectDeallocated != null)
		{
			ObjectDeallocated();
		}
	}

	void IPoolable.Destroy()
	{
		_owner = null;
		_colliders = null;
		_2dColliders = null;
		_renderers = null;
		ObjectAllocated = null;
		ObjectDeallocated = null;
	}

	public void Recycle()
	{
		_owner.Recycle(this);
	}

	private void EnableColliders()
	{
		int i = 0;
		for (int num = _colliders.Length; i < num; i++)
		{
			_colliders[i].enabled = true;
		}
		int j = 0;
		for (int num2 = _2dColliders.Length; j < num2; j++)
		{
			_2dColliders[j].enabled = true;
		}
	}

	private void DisableColliders()
	{
		int i = 0;
		for (int num = _colliders.Length; i < num; i++)
		{
			_colliders[i].enabled = false;
		}
		int j = 0;
		for (int num2 = _2dColliders.Length; j < num2; j++)
		{
			_2dColliders[j].enabled = false;
		}
	}

	private void EnableRenderers()
	{
		int i = 0;
		for (int num = _renderers.Length; i < num; i++)
		{
			_renderers[i].enabled = true;
		}
	}

	private void DisableRenderers()
	{
		int i = 0;
		for (int num = _renderers.Length; i < num; i++)
		{
			_renderers[i].enabled = false;
		}
	}
}
