using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

namespace Zenject;

public class GetFromPrefabComponentProvider : IProvider
{
	private readonly IPrefabInstantiator _prefabInstantiator;

	private readonly Type _componentType;

	private readonly bool _matchSingle;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	public GetFromPrefabComponentProvider(Type componentType, IPrefabInstantiator prefabInstantiator, bool matchSingle)
	{
		_prefabInstantiator = prefabInstantiator;
		_componentType = componentType;
		_matchSingle = matchSingle;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return _componentType;
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsNotNull(context);
		GameObject gameObject = _prefabInstantiator.Instantiate(args, out injectAction);
		if (_matchSingle)
		{
			Component componentInChildren = gameObject.GetComponentInChildren(_componentType, includeInactive: true);
			Assert.IsNotNull(componentInChildren, "Could not find component with type '{0}' on prefab '{1}'", _componentType, _prefabInstantiator.GetPrefab().name);
			return new List<object> { componentInChildren };
		}
		Component[] componentsInChildren = gameObject.GetComponentsInChildren(_componentType, includeInactive: true);
		Assert.That(componentsInChildren.Length >= 1, "Expected to find at least one component with type '{0}' on prefab '{1}'", _componentType, _prefabInstantiator.GetPrefab().name);
		return componentsInChildren.Cast<object>().ToList();
	}
}
