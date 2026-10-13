using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;

namespace Zenject;

public class SubContainerDependencyProvider : IProvider
{
	private readonly ISubContainerCreator _subContainerCreator;

	private readonly Type _dependencyType;

	private readonly object _identifier;

	private readonly bool _resolveAll;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	public SubContainerDependencyProvider(Type dependencyType, object identifier, ISubContainerCreator subContainerCreator, bool resolveAll)
	{
		_subContainerCreator = subContainerCreator;
		_dependencyType = dependencyType;
		_identifier = identifier;
		_resolveAll = resolveAll;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return _dependencyType;
	}

	private InjectContext CreateSubContext(InjectContext parent, DiContainer subContainer)
	{
		InjectContext injectContext = parent.CreateSubContext(_dependencyType, _identifier);
		injectContext.Container = subContainer;
		injectContext.SourceType = InjectSources.Local;
		return injectContext;
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsNotNull(context);
		DiContainer diContainer = _subContainerCreator.CreateSubContainer(args, context);
		InjectContext context2 = CreateSubContext(context, diContainer);
		injectAction = null;
		if (_resolveAll)
		{
			return diContainer.ResolveAll(context2).Cast<object>().ToList();
		}
		return new List<object> { diContainer.Resolve(context2) };
	}
}
