using System;

namespace UPool;

public class DefaultGenerator<T> : IGenerator
{
	private AbstractPool _owner;

	public DefaultGenerator(AbstractPool owner)
	{
		_owner = owner;
	}

	public IPoolable CreateInstance()
	{
		if (_owner.PoolType.IsAbstract)
		{
			throw new ArgumentException("Cannot create an instance of Abstract type " + _owner.PoolType.Name);
		}
		return (IPoolable)_owner.PoolType.GetConstructor(Type.EmptyTypes).Invoke(null);
	}
}
