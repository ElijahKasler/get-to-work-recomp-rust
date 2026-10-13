using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject;

public class SignalBus : ILateDisposable
{
	private readonly SignalSubscription.Pool _subscriptionPool;

	private readonly Dictionary<Type, SignalDeclaration> _localDeclarationMap;

	private readonly List<SignalDeclaration> _localDeclarations;

	private readonly SignalBus _parentBus;

	private readonly Dictionary<SignalSubscriptionId, SignalSubscription> _subscriptionMap = new Dictionary<SignalSubscriptionId, SignalSubscription>();

	private readonly ZenjectSettings.SignalSettings _settings;

	public SignalBus ParentBus => _parentBus;

	public int NumSubscribers => _subscriptionMap.Count;

	public SignalBus([Inject(Source = InjectSources.Local)] List<SignalDeclaration> signalDeclarations, [Inject(Source = InjectSources.Parent, Optional = true)] SignalBus parentBus, [InjectOptional] ZenjectSettings zenjectSettings, SignalSubscription.Pool subscriptionPool)
	{
		_subscriptionPool = subscriptionPool;
		zenjectSettings = zenjectSettings ?? ZenjectSettings.Default;
		_settings = zenjectSettings.Signals ?? ZenjectSettings.SignalSettings.Default;
		_localDeclarations = signalDeclarations;
		_localDeclarationMap = signalDeclarations.ToDictionary((SignalDeclaration x) => x.SignalType, (SignalDeclaration x) => x);
		_parentBus = parentBus;
	}

	public void LateDispose()
	{
		if (_settings.RequireStrictUnsubscribe)
		{
			if (!_subscriptionMap.IsEmpty())
			{
				throw Assert.CreateException("Found subscriptions for signals '{0}' in SignalBus.LateDispose!  Either add the explicit Unsubscribe or set SignalSettings.AutoUnsubscribeInDispose to true", _subscriptionMap.Values.Select((SignalSubscription x) => x.SignalType.PrettyName()).Join(", "));
			}
		}
		else
		{
			foreach (SignalSubscription value in _subscriptionMap.Values)
			{
				value.Dispose();
			}
		}
		for (int num = 0; num < _localDeclarations.Count; num++)
		{
			_localDeclarations[num].Dispose();
		}
	}

	public void Fire<TSignal>()
	{
		GetDeclaration(typeof(TSignal)).Fire((TSignal)Activator.CreateInstance(typeof(TSignal)));
	}

	public void Fire(object signal)
	{
		GetDeclaration(signal.GetType()).Fire(signal);
	}

	public void TryFire<TSignal>()
	{
		GetDeclaration(typeof(TSignal), requireDeclaration: false)?.Fire((TSignal)Activator.CreateInstance(typeof(TSignal)));
	}

	public void TryFire(object signal)
	{
		GetDeclaration(signal.GetType(), requireDeclaration: false)?.Fire(signal);
	}

	public void Subscribe<TSignal>(Action callback)
	{
		Action<object> callback2 = (object args) =>
		{
			callback();
		};
		SubscribeInternal(typeof(TSignal), callback, callback2);
	}

	public void Subscribe<TSignal>(Action<TSignal> callback)
	{
		Action<object> callback2 = (object args) =>
		{
			callback((TSignal)args);
		};
		SubscribeInternal(typeof(TSignal), callback, callback2);
	}

	public void Subscribe(Type signalType, Action<object> callback)
	{
		SubscribeInternal(signalType, callback, callback);
	}

	public void Unsubscribe<TSignal>(Action callback)
	{
		Unsubscribe(typeof(TSignal), callback);
	}

	public void Unsubscribe(Type signalType, Action callback)
	{
		UnsubscribeInternal(signalType, callback, throwIfMissing: true);
	}

	public void Unsubscribe(Type signalType, Action<object> callback)
	{
		UnsubscribeInternal(signalType, callback, throwIfMissing: true);
	}

	public void Unsubscribe<TSignal>(Action<TSignal> callback)
	{
		UnsubscribeInternal(typeof(TSignal), callback, throwIfMissing: true);
	}

	public void TryUnsubscribe<TSignal>(Action callback)
	{
		UnsubscribeInternal(typeof(TSignal), callback, throwIfMissing: false);
	}

	public void TryUnsubscribe(Type signalType, Action callback)
	{
		UnsubscribeInternal(signalType, callback, throwIfMissing: false);
	}

	public void TryUnsubscribe(Type signalType, Action<object> callback)
	{
		UnsubscribeInternal(signalType, callback, throwIfMissing: false);
	}

	public void TryUnsubscribe<TSignal>(Action<TSignal> callback)
	{
		UnsubscribeInternal(typeof(TSignal), callback, throwIfMissing: false);
	}

	private void UnsubscribeInternal(Type signalType, object token, bool throwIfMissing)
	{
		UnsubscribeInternal(new SignalSubscriptionId(signalType, token), throwIfMissing);
	}

	private void UnsubscribeInternal(SignalSubscriptionId id, bool throwIfMissing)
	{
		if (_subscriptionMap.TryGetValue(id, out var value))
		{
			_subscriptionMap.RemoveWithConfirm(id);
			value.Dispose();
		}
		else if (throwIfMissing)
		{
			throw Assert.CreateException("Called unsubscribe for signal '{0}' but could not find corresponding subscribe.  If this is intentional, call TryUnsubscribe instead.");
		}
	}

	private void SubscribeInternal(Type signalType, object token, Action<object> callback)
	{
		SubscribeInternal(new SignalSubscriptionId(signalType, token), callback);
	}

	private void SubscribeInternal(SignalSubscriptionId id, Action<object> callback)
	{
		Assert.That(!_subscriptionMap.ContainsKey(id), "Tried subscribing to the same signal with the same callback on Zenject.SignalBus");
		SignalDeclaration declaration = GetDeclaration(id.SignalType);
		SignalSubscription value = _subscriptionPool.Spawn(callback, declaration);
		_subscriptionMap.Add(id, value);
	}

	private SignalDeclaration GetDeclaration(Type signalType, bool requireDeclaration = true)
	{
		if (_localDeclarationMap.TryGetValue(signalType, out var value))
		{
			return value;
		}
		if (_parentBus != null)
		{
			return _parentBus.GetDeclaration(signalType, requireDeclaration);
		}
		if (requireDeclaration)
		{
			throw Assert.CreateException("Fired undeclared signal with type '{0}'!", signalType);
		}
		return null;
	}
}
