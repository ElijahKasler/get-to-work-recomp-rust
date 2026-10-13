using System;

namespace Zenject;

public class SignalCallbackWrapper : IDisposable
{
	private readonly SignalBus _signalBus;

	private readonly Action<object> _action;

	private readonly Type _signalType;

	public SignalCallbackWrapper(Type signalType, Action<object> action, SignalBus signalBus)
	{
		_signalType = signalType;
		_signalBus = signalBus;
		_action = action;
		signalBus.Subscribe(signalType, OnSignalFired);
	}

	private void OnSignalFired(object signal)
	{
		_action(signal);
	}

	public void Dispose()
	{
		_signalBus.Unsubscribe(_signalType, OnSignalFired);
	}
}
