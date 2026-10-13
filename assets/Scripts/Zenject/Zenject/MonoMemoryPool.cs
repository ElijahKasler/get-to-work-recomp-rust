using UnityEngine;

namespace Zenject;

public class MonoMemoryPool<TValue> : MemoryPool<TValue> where TValue : Component
{
	private Transform _originalParent;

	[Inject]
	public MonoMemoryPool()
	{
	}

	protected override void OnCreated(TValue item)
	{
		item.gameObject.SetActive(value: false);
		_originalParent = item.transform.parent;
	}

	protected override void OnDestroyed(TValue item)
	{
		Object.Destroy(item.gameObject);
	}

	protected override void OnSpawned(TValue item)
	{
		item.gameObject.SetActive(value: true);
	}

	protected override void OnDespawned(TValue item)
	{
		item.gameObject.SetActive(value: false);
		if (item.transform.parent != _originalParent)
		{
			item.transform.SetParent(_originalParent, worldPositionStays: false);
		}
	}
}
public class MonoMemoryPool<TParam1, TValue> : MemoryPool<TParam1, TValue> where TValue : Component
{
	private Transform _originalParent;

	[Inject]
	public MonoMemoryPool()
	{
	}

	protected override void OnCreated(TValue item)
	{
		item.gameObject.SetActive(value: false);
		_originalParent = item.transform.parent;
	}

	protected override void OnDestroyed(TValue item)
	{
		Object.Destroy(item.gameObject);
	}

	protected override void OnSpawned(TValue item)
	{
		item.gameObject.SetActive(value: true);
	}

	protected override void OnDespawned(TValue item)
	{
		item.gameObject.SetActive(value: false);
		if (item.transform.parent != _originalParent)
		{
			item.transform.SetParent(_originalParent, worldPositionStays: false);
		}
	}
}
public class MonoMemoryPool<TParam1, TParam2, TValue> : MemoryPool<TParam1, TParam2, TValue> where TValue : Component
{
	private Transform _originalParent;

	[Inject]
	public MonoMemoryPool()
	{
	}

	protected override void OnCreated(TValue item)
	{
		item.gameObject.SetActive(value: false);
		_originalParent = item.transform.parent;
	}

	protected override void OnDestroyed(TValue item)
	{
		Object.Destroy(item.gameObject);
	}

	protected override void OnSpawned(TValue item)
	{
		item.gameObject.SetActive(value: true);
	}

	protected override void OnDespawned(TValue item)
	{
		item.gameObject.SetActive(value: false);
		if (item.transform.parent != _originalParent)
		{
			item.transform.SetParent(_originalParent, worldPositionStays: false);
		}
	}
}
public class MonoMemoryPool<TParam1, TParam2, TParam3, TValue> : MemoryPool<TParam1, TParam2, TParam3, TValue> where TValue : Component
{
	private Transform _originalParent;

	[Inject]
	public MonoMemoryPool()
	{
	}

	protected override void OnCreated(TValue item)
	{
		item.gameObject.SetActive(value: false);
		_originalParent = item.transform.parent;
	}

	protected override void OnDestroyed(TValue item)
	{
		Object.Destroy(item.gameObject);
	}

	protected override void OnSpawned(TValue item)
	{
		item.gameObject.SetActive(value: true);
	}

	protected override void OnDespawned(TValue item)
	{
		item.gameObject.SetActive(value: false);
		if (item.transform.parent != _originalParent)
		{
			item.transform.SetParent(_originalParent, worldPositionStays: false);
		}
	}
}
public class MonoMemoryPool<TParam1, TParam2, TParam3, TParam4, TValue> : MemoryPool<TParam1, TParam2, TParam3, TParam4, TValue> where TValue : Component
{
	private Transform _originalParent;

	[Inject]
	public MonoMemoryPool()
	{
	}

	protected override void OnCreated(TValue item)
	{
		item.gameObject.SetActive(value: false);
		_originalParent = item.transform.parent;
	}

	protected override void OnDestroyed(TValue item)
	{
		Object.Destroy(item.gameObject);
	}

	protected override void OnSpawned(TValue item)
	{
		item.gameObject.SetActive(value: true);
	}

	protected override void OnDespawned(TValue item)
	{
		item.gameObject.SetActive(value: false);
		if (item.transform.parent != _originalParent)
		{
			item.transform.SetParent(_originalParent, worldPositionStays: false);
		}
	}
}
public class MonoMemoryPool<TParam1, TParam2, TParam3, TParam4, TParam5, TValue> : MemoryPool<TParam1, TParam2, TParam3, TParam4, TParam5, TValue> where TValue : Component
{
	private Transform _originalParent;

	[Inject]
	public MonoMemoryPool()
	{
	}

	protected override void OnCreated(TValue item)
	{
		item.gameObject.SetActive(value: false);
		_originalParent = item.transform.parent;
	}

	protected override void OnDestroyed(TValue item)
	{
		Object.Destroy(item.gameObject);
	}

	protected override void OnSpawned(TValue item)
	{
		item.gameObject.SetActive(value: true);
	}

	protected override void OnDespawned(TValue item)
	{
		item.gameObject.SetActive(value: false);
		if (item.transform.parent != _originalParent)
		{
			item.transform.SetParent(_originalParent, worldPositionStays: false);
		}
	}
}
