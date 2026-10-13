using System;
using System.Collections.Generic;

namespace UPool;

public abstract class AbstractPool
{
	protected IGenerator _generator;

	protected HashSet<IPoolable> _pool;

	protected HashSet<IPoolable> _allocatedObjects;

	protected Queue<IPoolable> _availableObjects;

	public int Size => _pool.Count;

	public int AvailableItems => _availableObjects.Count;

	public abstract Type PoolType { get; }

	public virtual void Recycle(IPoolable obj)
	{
		if (_pool == null)
		{
			throw new InvalidOperationException("The Pool has been destroyed. Objects can no longer be Recycled into it.");
		}
		if (_pool.Contains(obj))
		{
			if (_allocatedObjects.Contains(obj))
			{
				obj.OnDeallocate();
				_allocatedObjects.Remove(obj);
				_availableObjects.Enqueue(obj);
			}
			return;
		}
		throw new InvalidOperationException("Cannot Recycle Objects into a Pool that did not originate from it.");
	}

	public void RecycleAll()
	{
		if (_pool == null)
		{
			throw new InvalidOperationException("Pool has already been destroyed.");
		}
		IPoolable[] array = new IPoolable[_allocatedObjects.Count];
		_allocatedObjects.CopyTo(array);
		IPoolable[] array2 = array;
		foreach (IPoolable obj in array2)
		{
			Recycle(obj);
		}
		_allocatedObjects.Clear();
	}

	public virtual void Destroy()
	{
		if (_pool == null)
		{
			throw new InvalidOperationException("Pool has already been destroyed.");
		}
		while (_availableObjects.Count > 0)
		{
			_availableObjects.Dequeue().Destroy();
		}
		_pool = null;
		_allocatedObjects = null;
		_availableObjects = null;
	}

	public virtual void DestroyAndDeallocateAll()
	{
		if (_pool == null)
		{
			throw new InvalidOperationException("Pool has already been destroyed.");
		}
		foreach (IPoolable allocatedObject in _allocatedObjects)
		{
			allocatedObject.OnDeallocate();
		}
		foreach (IPoolable item in _pool)
		{
			item.Destroy();
		}
		_pool = null;
		_allocatedObjects = null;
		_availableObjects = null;
	}

	protected IPoolable Acquire()
	{
		if (_pool == null)
		{
			throw new InvalidOperationException("The Pool has been destroyed. Objects can no longer be Aquired from it.");
		}
		if (_availableObjects.Count == 0)
		{
			CreateNewInstance(_allocatedObjects.Count);
		}
		IPoolable poolable = _availableObjects.Dequeue();
		poolable.OnAllocate();
		_allocatedObjects.Add(poolable);
		return poolable;
	}

	protected void InitializePool(int initialSize)
	{
		initialSize = ((initialSize > 0) ? initialSize : 0);
		_pool = new HashSet<IPoolable>();
		_allocatedObjects = new HashSet<IPoolable>();
		_availableObjects = new Queue<IPoolable>();
		for (int i = 0; i < initialSize; i++)
		{
			CreateNewInstance(i);
		}
	}

	protected void CreateNewInstance(int uid)
	{
		IPoolable poolable = _generator.CreateInstance();
		_pool.Add(poolable);
		_availableObjects.Enqueue(poolable);
		poolable.Init(this);
		if (poolable is PoolableObject poolableObject)
		{
			poolableObject.gameObject.name += uid;
		}
	}
}
