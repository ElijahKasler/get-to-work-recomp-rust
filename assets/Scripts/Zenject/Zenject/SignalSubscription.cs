using System;
using System.Linq;
using ModestTree;

namespace Zenject;

public class SignalSubscription : IDisposable, IPoolable<Action<object>, SignalDeclaration>
{
	public class Pool : PoolableMemoryPool<Action<object>, SignalDeclaration, SignalSubscription>
	{
	}

	private readonly Pool _pool;

	private Action<object> _callback;

	private SignalDeclaration _declaration;

	private Type _signalType;

	public Type SignalType => _signalType;

	public SignalSubscription(Pool pool)
	{
		_pool = pool;
		SetDefaults();
	}

	public void OnSpawned(Action<object> callback, SignalDeclaration declaration)
	{
		Assert.IsNull(_callback);
		_callback = callback;
		_declaration = declaration;
		_signalType = declaration.SignalType;
		declaration.Add(this);
	}

	public void OnDespawned()
	{
		if (_declaration != null)
		{
			_declaration.Remove(this);
		}
		SetDefaults();
	}

	private void SetDefaults()
	{
		_callback = null;
		_declaration = null;
		_signalType = null;
	}

	public void Dispose()
	{
		if (!_pool.InactiveItems.Contains(this))
		{
			_pool.Despawn(this);
		}
	}

	public void OnDeclarationDespawned()
	{
		_declaration = null;
	}

	public void Invoke(object signal)
	{
		_callback(signal);
	}
}
