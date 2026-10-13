using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

namespace Zenject;

public class GetFromGameObjectGetterComponentProvider : IProvider
{
	private readonly Func<InjectContext, GameObject> _gameObjectGetter;

	private readonly Type _componentType;

	private readonly bool _matchSingle;

	public bool IsCached => false;

	public bool TypeVariesBasedOnMemberType => false;

	public GetFromGameObjectGetterComponentProvider(Type componentType, Func<InjectContext, GameObject> gameObjectGetter, bool matchSingle)
	{
		_componentType = componentType;
		_matchSingle = matchSingle;
		_gameObjectGetter = gameObjectGetter;
	}

	public Type GetInstanceType(InjectContext context)
	{
		return _componentType;
	}

	public List<object> GetAllInstancesWithInjectSplit(InjectContext context, List<TypeValuePair> args, out Action injectAction)
	{
		Assert.IsNotNull(context);
		injectAction = null;
		if (context.Container.IsValidating)
		{
			return new List<object>
			{
				new ValidationMarker(_componentType)
			};
		}
		GameObject gameObject = _gameObjectGetter(context);
		if (_matchSingle)
		{
			Component component = gameObject.GetComponent(_componentType);
			Assert.IsNotNull(component, "Could not find component with type '{0}' on game object '{1}'", _componentType, gameObject.name);
			return new List<object> { component };
		}
		Component[] components = gameObject.GetComponents(_componentType);
		Assert.That(components.Length >= 1, "Expected to find at least one component with type '{0}' on prefab '{1}'", _componentType, gameObject.name);
		return components.Cast<object>().ToList();
	}
}
