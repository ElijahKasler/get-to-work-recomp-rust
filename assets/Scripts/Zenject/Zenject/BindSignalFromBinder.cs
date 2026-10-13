using System;
using ModestTree;

namespace Zenject;

public class BindSignalFromBinder<TObject, TSignal>
{
	private readonly BindFinalizerWrapper _finalizerWrapper;

	private readonly Func<TObject, Action<TSignal>> _methodGetter;

	private readonly DiContainer _container;

	public BindSignalFromBinder(BindFinalizerWrapper finalizerWrapper, Func<TObject, Action<TSignal>> methodGetter, DiContainer container)
	{
		_finalizerWrapper = finalizerWrapper;
		_methodGetter = methodGetter;
		_container = container;
	}

	public SignalCopyBinder FromResolve()
	{
		return From((ConcreteBinderGeneric<TObject> x) =>
		{
			x.FromResolve().AsCached();
		});
	}

	public SignalCopyBinder FromResolveAll()
	{
		return From((ConcreteBinderGeneric<TObject> x) =>
		{
			x.FromResolveAll().AsCached();
		});
	}

	public SignalCopyBinder FromNew()
	{
		return From((ConcreteBinderGeneric<TObject> x) =>
		{
			x.FromNew().AsCached();
		});
	}

	public SignalCopyBinder From(Action<ConcreteBinderGeneric<TObject>> objectBindCallback)
	{
		Assert.IsNull(_finalizerWrapper.SubFinalizer);
		_finalizerWrapper.SubFinalizer = new NullBindingFinalizer();
		Guid guid = Guid.NewGuid();
		ConcreteBinderGeneric<TObject> concreteBinderGeneric = _container.BindNoFlush<TObject>().WithId(guid);
		objectBindCallback(concreteBinderGeneric);
		Func<object, Action<object>> param = (object obj) => (object s) =>
		{
			_methodGetter((TObject)obj)((TSignal)s);
		};
		SignalCopyBinder signalCopyBinder = new SignalCopyBinder(_container.Bind<IDisposable>().To<SignalCallbackWithLookupWrapper>().AsCached()
			.WithArguments(typeof(TSignal), typeof(TObject), guid, param)
			.NonLazy()
			.BindInfo);
		signalCopyBinder.AddCopyBindInfo(concreteBinderGeneric.BindInfo);
		return signalCopyBinder;
	}
}
