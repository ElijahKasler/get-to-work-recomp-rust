using System;
using System.Collections.Generic;
using ModestTree;

namespace Zenject;

public class SignalDeclaration : ITickable, IDisposable
{
	private readonly List<SignalSubscription> _subscriptions = new List<SignalSubscription>();

	private readonly List<object> _asyncQueue = new List<object>();

	private readonly Type _signalType;

	private readonly SignalMissingHandlerResponses _missingHandlerResponses;

	private readonly bool _isAsync;

	private readonly ZenjectSettings.SignalSettings _settings;

	public int TickPriority { get; private set; }

	public bool IsAsync => _isAsync;

	public Type SignalType => _signalType;

	public SignalDeclaration(Type signalType, SignalDeclarationBindInfo bindInfo, [InjectOptional] ZenjectSettings zenjectSettings)
	{
		zenjectSettings = zenjectSettings ?? ZenjectSettings.Default;
		_settings = zenjectSettings.Signals ?? ZenjectSettings.SignalSettings.Default;
		_signalType = signalType;
		_missingHandlerResponses = bindInfo.MissingHandlerResponse;
		_isAsync = bindInfo.RunAsync;
		TickPriority = bindInfo.TickPriority;
	}

	public void Dispose()
	{
		if (_settings.RequireStrictUnsubscribe)
		{
			Assert.That(_subscriptions.IsEmpty(), "Found {0} signal handlers still added to declaration {1}", _subscriptions.Count, _signalType);
			return;
		}
		for (int i = 0; i < _subscriptions.Count; i++)
		{
			_subscriptions[i].OnDeclarationDespawned();
		}
	}

	public void Fire(object signal)
	{
		Assert.That(signal.GetType().DerivesFromOrEqual(_signalType));
		if (_isAsync)
		{
			_asyncQueue.Add(signal);
			return;
		}
		using DisposeBlock disposeBlock = DisposeBlock.Spawn();
		List<SignalSubscription> list = disposeBlock.SpawnList<SignalSubscription>();
		list.AddRange(_subscriptions);
		FireInternal(list, signal);
	}

	private void FireInternal(List<SignalSubscription> subscriptions, object signal)
	{
		if (subscriptions.IsEmpty())
		{
			if (_missingHandlerResponses == SignalMissingHandlerResponses.Warn)
			{
				Log.Warn("Fired signal '{0}' but no subscriptions found!  If this is intentional then either add OptionalSubscriber() to the binding or change the default in ZenjectSettings", signal.GetType());
			}
			else if (_missingHandlerResponses == SignalMissingHandlerResponses.Throw)
			{
				throw Assert.CreateException("Fired signal '{0}' but no subscriptions found!  If this is intentional then either add OptionalSubscriber() to the binding or change the default in ZenjectSettings", signal.GetType());
			}
		}
		for (int i = 0; i < subscriptions.Count; i++)
		{
			SignalSubscription signalSubscription = subscriptions[i];
			if (_subscriptions.Contains(signalSubscription))
			{
				signalSubscription.Invoke(signal);
			}
		}
	}

	public void Tick()
	{
		Assert.That(_isAsync);
		if (_asyncQueue.IsEmpty())
		{
			return;
		}
		using DisposeBlock disposeBlock = DisposeBlock.Spawn();
		List<SignalSubscription> list = disposeBlock.SpawnList<SignalSubscription>();
		list.AddRange(_subscriptions);
		List<object> list2 = disposeBlock.SpawnList<object>();
		list2.AddRange(_asyncQueue);
		_asyncQueue.Clear();
		for (int i = 0; i < list2.Count; i++)
		{
			FireInternal(list, list2[i]);
		}
	}

	public void Add(SignalSubscription subscription)
	{
		Assert.That(!_subscriptions.Contains(subscription));
		_subscriptions.Add(subscription);
	}

	public void Remove(SignalSubscription subscription)
	{
		_subscriptions.RemoveWithConfirm(subscription);
	}
}
