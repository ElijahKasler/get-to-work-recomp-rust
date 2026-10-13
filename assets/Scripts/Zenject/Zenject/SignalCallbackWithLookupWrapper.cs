using System;
using System.Collections;

namespace Zenject;

public class SignalCallbackWithLookupWrapper : IDisposable
{
	private readonly DiContainer _container;

	private readonly SignalBus _signalBus;

	private readonly Guid _lookupId;

	private readonly Func<object, Action<object>> _methodGetter;

	private readonly Type _objectType;

	private readonly Type _signalType;

	public SignalCallbackWithLookupWrapper(Type signalType, Type objectType, Guid lookupId, Func<object, Action<object>> methodGetter, SignalBus signalBus, DiContainer container)
	{
		_objectType = objectType;
		_signalType = signalType;
		_container = container;
		_methodGetter = methodGetter;
		_signalBus = signalBus;
		_lookupId = lookupId;
		signalBus.Subscribe(signalType, OnSignalFired);
	}

	private void OnSignalFired(object signal)
	{
		IList list = _container.ResolveIdAll(_objectType, _lookupId);
		for (int i = 0; i < list.Count; i++)
		{
			_methodGetter(list[i])(signal);
		}
	}

	public void Dispose()
	{
		_signalBus.Unsubscribe(_signalType, OnSignalFired);
	}
}
