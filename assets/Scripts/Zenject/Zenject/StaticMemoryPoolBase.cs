using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject;

public abstract class StaticMemoryPoolBase<TValue> : IDespawnableMemoryPool<TValue>, IMemoryPool, IDisposable where TValue : class, new()
{
	private readonly Stack<TValue> _stack = new Stack<TValue>();

	private Action<TValue> _onDespawnedMethod;

	private int _activeCount;

	public Action<TValue> OnDespawnedMethod
	{
		set
		{
			_onDespawnedMethod = value;
		}
	}

	public int NumTotal => NumInactive + NumActive;

	public int NumActive => _activeCount;

	public int NumInactive => _stack.Count;

	public Type ItemType => typeof(TValue);

	public StaticMemoryPoolBase(Action<TValue> onDespawnedMethod)
	{
		_onDespawnedMethod = onDespawnedMethod;
		StaticMemoryPoolRegistry.Add(this);
	}

	public void Resize(int desiredPoolSize)
	{
		Assert.That(desiredPoolSize >= 0, "Attempted to resize the pool to a negative amount");
		while (_stack.Count > desiredPoolSize)
		{
			_stack.Pop();
		}
		while (desiredPoolSize > _stack.Count)
		{
			_stack.Push(Alloc());
		}
		Assert.IsEqual(_stack.Count, desiredPoolSize);
	}

	public void Dispose()
	{
		StaticMemoryPoolRegistry.Remove(this);
	}

	public void ClearActiveCount()
	{
		_activeCount = 0;
	}

	public void Clear()
	{
		Resize(0);
	}

	public void ShrinkBy(int numToRemove)
	{
		Resize(_stack.Count - numToRemove);
	}

	public void ExpandBy(int numToAdd)
	{
		Resize(_stack.Count + numToAdd);
	}

	private TValue Alloc()
	{
		return new TValue();
	}

	protected TValue SpawnInternal()
	{
		TValue result = ((_stack.Count != 0) ? _stack.Pop() : Alloc());
		_activeCount++;
		return result;
	}

	void IMemoryPool.Despawn(object item)
	{
		Despawn((TValue)item);
	}

	public void Despawn(TValue element)
	{
		if (_onDespawnedMethod != null)
		{
			_onDespawnedMethod(element);
		}
		if (_stack.Count > 0 && _stack.Peek() == element)
		{
			Log.Error("Despawn error. Trying to destroy object that is already released to pool.");
		}
		Assert.That(!_stack.Contains(element), "Attempted to despawn element twice!");
		_activeCount--;
		_stack.Push(element);
	}
}
