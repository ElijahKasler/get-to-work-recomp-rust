using System;
using System.Collections.Generic;
using System.Linq;

namespace Zenject.Internal;

public class DecoratorProvider<TContract> : IDecoratorProvider
{
	private readonly Dictionary<IProvider, List<object>> _cachedInstances = new Dictionary<IProvider, List<object>>();

	private readonly DiContainer _container;

	private readonly List<Guid> _factoryBindIds = new List<Guid>();

	private List<IFactory<TContract, TContract>> _decoratorFactories;

	public DecoratorProvider(DiContainer container)
	{
		_container = container;
	}

	public void AddFactoryId(Guid factoryBindId)
	{
		_factoryBindIds.Add(factoryBindId);
	}

	private void LazyInitializeDecoratorFactories()
	{
		if (_decoratorFactories == null)
		{
			_decoratorFactories = _factoryBindIds.Select((Guid x) => _container.ResolveId<IFactory<TContract, TContract>>(x)).ToList();
		}
	}

	public List<object> GetAllInstances(IProvider provider, InjectContext context)
	{
		List<object> value;
		if (provider.IsCached)
		{
			if (!_cachedInstances.TryGetValue(provider, out value))
			{
				value = WrapProviderInstances(provider, context);
				_cachedInstances.Add(provider, value);
			}
		}
		else
		{
			value = WrapProviderInstances(provider, context);
		}
		return value;
	}

	private List<object> WrapProviderInstances(IProvider provider, InjectContext context)
	{
		LazyInitializeDecoratorFactories();
		List<object> allInstances = provider.GetAllInstances(context);
		List<object> list = new List<object>(allInstances.Count);
		for (int i = 0; i < allInstances.Count; i++)
		{
			list.Add(DecorateInstance(allInstances[i], context));
		}
		return list;
	}

	private object DecorateInstance(object instance, InjectContext context)
	{
		for (int i = 0; i < _decoratorFactories.Count; i++)
		{
			instance = _decoratorFactories[i].Create(context.Container.IsValidating ? default(TContract) : ((TContract)instance));
		}
		return instance;
	}
}
