using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace Zenject;

public class InstantiateOnPrefabComponentProvider : IProvider
{
	private readonly IPrefabInstantiator _prefabInstantiator;

	private readonly Type _componentType;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	public InstantiateOnPrefabComponentProvider(Type componentType, IPrefabInstantiator prefabInstantiator)
	{
		_prefabInstantiator = prefabInstantiator;
		_componentType = componentType;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return _componentType;
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsNotNull(context);
		Component item = _prefabInstantiator.Instantiate(args, out injectAction).AddComponent(_componentType);
		return new List<object> { item };
	}
}
