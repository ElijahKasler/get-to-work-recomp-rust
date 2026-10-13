using System;
using ModestTree;

namespace Zenject;

public class BindSignalToBinder<TSignal>
{
	private DiContainer _container;

	private BindFinalizerWrapper _finalizerWrapper;

	public BindSignalToBinder(DiContainer container)
	{
		_container = container;
		_finalizerWrapper = container.StartBinding("Missing method/object for BindSignal< {0} >".Fmt(typeof(TSignal).PrettyName()));
	}

	public SignalCopyBinder ToMethod(Action<TSignal> callback)
	{
		Assert.IsNull(_finalizerWrapper.SubFinalizer);
		_finalizerWrapper.SubFinalizer = new NullBindingFinalizer();
		return new SignalCopyBinder(_container.Bind<IDisposable>().To<SignalCallbackWrapper>().AsCached()
			.WithArguments<Type, Action<object>>(typeof(TSignal), (object o) =>
			{
				callback((TSignal)o);
			})
			.NonLazy()
			.BindInfo);
	}

	public SignalCopyBinder ToMethod(Action callback)
	{
		return ToMethod((TSignal signal) =>
		{
			callback();
		});
	}

	public BindSignalFromBinder<TObject, TSignal> ToMethod<TObject>(Action<TObject, TSignal> handler)
	{
		return ToMethod((TObject x) => (TSignal s) =>
		{
			handler(x, s);
		});
	}

	public BindSignalFromBinder<TObject, TSignal> ToMethod<TObject>(Func<TObject, Action> handlerGetter)
	{
		return ToMethod((TObject x) => (TSignal s) =>
		{
			handlerGetter(x)();
		});
	}

	public BindSignalFromBinder<TObject, TSignal> ToMethod<TObject>(Func<TObject, Action<TSignal>> handlerGetter)
	{
		return new BindSignalFromBinder<TObject, TSignal>(_finalizerWrapper, handlerGetter, _container);
	}
}
