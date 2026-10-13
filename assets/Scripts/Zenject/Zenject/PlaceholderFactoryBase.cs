using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject;

public abstract class PlaceholderFactoryBase<TValue> : IPlaceholderFactory, IValidatable
{
	private IProvider _provider;

	private InjectContext _injectContext;

	protected abstract IEnumerable<Type> ParamTypes { get; }

	[Inject]
	private void Construct(IProvider provider, InjectContext injectContext)
	{
		Assert.IsNotNull(provider);
		Assert.IsNotNull(injectContext);
		_provider = provider;
		_injectContext = injectContext;
	}

	protected TValue CreateInternal(List<TypeValuePair> extraArgs)
	{
		try
		{
			object instance = _provider.GetInstance(_injectContext, extraArgs);
			if (_injectContext.Container.IsValidating && instance is ValidationMarker)
			{
				return default;
			}
			Assert.That(instance?.GetType().DerivesFromOrEqual<TValue>() ?? true);
			return (TValue)instance;
		}
		catch (Exception innerException)
		{
			throw new ZenjectException("Error during construction of type '{0}' via {1}.Create method!".Fmt(typeof(TValue), GetType().PrettyName()), innerException);
		}
	}

	public virtual void Validate()
	{
		_provider.GetInstance(_injectContext, ValidationUtil.CreateDefaultArgs(ParamTypes.ToArray()));
	}
}
